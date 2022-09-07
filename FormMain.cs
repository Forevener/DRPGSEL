using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoomRPG
{
    public partial class FormMain : Form
    {
        readonly string configPath = Application.StartupPath + "\\" + Assembly.GetEntryAssembly().GetName().Name + ".cfg";
        Config config;
        private List<Config> configs = new List<Config>();
        string currentBranch = string.Empty;
        private List<DMFlag> DMFlags = new List<DMFlag>();
        private List<DMFlag> DMFlags2 = new List<DMFlag>();
        private string launchProblem = String.Empty;

        // Extensions of known mod filetypes
        private readonly string[] fileTypes =
        {
            "wad",                  // Original vanilla Doom archive type
            "zip", "pk3", "pk7",    // Archive File Types
            "deh", "bex"            // DeHackEd File Types
        };

        private readonly List<string> IWADs = new List<string>()
        {
            "doom.wad",
            "doom2.wad",
            "tnt.wad",
            "plutonia.wad"
        };

        private List<PatchInfo> patches = new List<PatchInfo>();
        private readonly Version version = Assembly.GetExecutingAssembly().GetName().Version;

        private bool IsDRLAActive
        {
            get => config.mods.Exists(m => m.Contains("DoomRL_Arsenal"));
        }

        public FormMain()
        {
            InitializeComponent();

            // Title
            Text = "Doom RPG SE Launcher v" + version.ToString(3);

            // Load config
            LoadConfigs();

            // DMFLags
            PopulateDMFlags();

            // Populate controls
            LoadContent();
            CheckForMods();
        }

        private void ComboBoxForks_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ = PopulateBranchesComboBox();
        }

        private string BuildCommandLine()
        {
            string cmdline = string.Empty;

            // IWAD
            cmdline += " -iwad " + Utils.GetRelativePath(config.portPath, $"{config.IWADPath}\\{config.iwad}");

            if (config.startupMode == 0)
            {

            }
            else if (config.startupMode == 1)
            {
                // Skill/Difficulty
                cmdline += " -skill " + (config.difficulty + 1);

                // Map Number
                cmdline += " -warp " + config.mapNumber;

                // DRLA Class
                if (IsDRLAActive)
                    cmdline += " +playerclass " + config.rlClass.ToString();
            }
            else
            {
                // Load savegame
                string dir = Path.GetDirectoryName(config.portPath);
                dir = Directory.Exists(dir + "\\Save") ? dir + "\\Save" : dir;
                cmdline += $" -loadgame \"{dir}\\{comboBoxSaveGame.Text}\"";
            }

            // Record Demo
            if (textBoxDemo.TextLength > 0)
                cmdline += " -record " + textBoxDemo.Text + ".lmp";

            // Multiplayer
            if (config.multiplayer)
            {
                // Hosting/Joining
                if (config.multiplayerMode == MultiplayerMode.Hosting)
                    cmdline += " -host " + config.players;
                if (config.multiplayerMode == MultiplayerMode.Joining)
                    cmdline += " -join " + config.hostname;

                // Server-side stuff
                if (config.multiplayerMode == MultiplayerMode.Hosting)
                {
                    // Server Type
                    if (config.serverType == ServerType.PeerToPeer)
                        cmdline += " -netmode 0";
                    if (config.serverType == ServerType.PacketServer)
                        cmdline += " -netmode 1";

                    // Server Options
                    if (config.extraTics)
                        cmdline += " -extratic";
                    if (config.duplicate > 0)
                        cmdline += " -dup " + config.duplicate;
                }
            }

            // Enable Cheats
            if (checkBoxEnableCheats.Checked)
                cmdline += " +sv_cheats 1";

            // Enable Logging to File
            if (checkBoxLogging.Checked)
                cmdline += " +logfile \"Doom RPG.log\"";



            // Mods & Patches
            cmdline += " -file";

            // Mods selected from the mods list
            foreach (string mod in config.mods)
            {
                cmdline += " " + Utils.GetRelativePath(config.portPath, mod);
            }

            // DMFlags
            if (config.EnableDMFlags)
                cmdline += " +set dmflags " + config.DMFlags.ToString();

            if (config.EnableDMFlags2)
                cmdline += " +set dmflags2 " + config.DMFlags2.ToString();

            // Custom Commands
            if (config.customCommands != string.Empty)
                cmdline += " " + config.customCommands;

            return cmdline;
        }

        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection node)
        {
            TreeNode currentNode = node.Add(directoryInfo.Name);
            if (config.mods.Contains(directoryInfo.FullName))
                currentNode.Nodes[currentNode.Nodes.Count - 1].Checked = true;

            foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
            {
                if (directory.FullName != config.DRPGPath)
                    BuildTree(directory, currentNode.Nodes);
            }
            foreach (FileInfo file in directoryInfo.GetFiles().Where(file => fileTypes.Any(file.Name.EndsWith)))
            {
                currentNode.Nodes.Add(file.Name);
                if (config.mods.Contains(file.FullName))
                {
                    currentNode.Nodes[currentNode.Nodes.Count - 1].Checked = true;
                    currentNode.Expand();
                }
            }
        }

        private void ButtonBrowseDRPGPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (textBoxDRPGPath.Text == String.Empty)
                dialog.SelectedPath = Directory.GetCurrentDirectory();
            else
                dialog.SelectedPath = textBoxDRPGPath.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBoxDRPGPath.Text = dialog.SelectedPath;
                config.DRPGPath = dialog.SelectedPath;
                // Load Credits and re-populate the patches list
                LoadCredits();
                PopulatePatches();
            }
            dialog.Dispose();
        }

        private void ButtonBrowseIWADsPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (textBoxIWADsPath.Text == string.Empty)
            {
                if (Directory.Exists(textBoxPortPath.Text))
                    dialog.SelectedPath = textBoxPortPath.Text;
                else
                    dialog.SelectedPath = Directory.GetCurrentDirectory();
            }
            else
            {
                dialog.SelectedPath = textBoxDRPGPath.Text;
            }
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBoxIWADsPath.Text = dialog.SelectedPath;
            }
            dialog.Dispose();
        }

        private void ButtonBrowseModsPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (textBoxModsPath.Text == String.Empty)
                dialog.SelectedPath = Directory.GetCurrentDirectory();
            else
                dialog.SelectedPath = textBoxModsPath.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBoxModsPath.Text = dialog.SelectedPath;
                config.modsPath = dialog.SelectedPath;
            }
            dialog.Dispose();
        }

        private void ButtonBrowsePortPath_Click(object sender, EventArgs e)
        {
            FileDialog dialog = new OpenFileDialog() { Title = "Specify (G)ZDoom EXE...", Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*" };
            if (textBoxPortPath.Text == string.Empty)
                dialog.InitialDirectory = Directory.GetCurrentDirectory();
            else
                dialog.InitialDirectory = Path.GetDirectoryName(textBoxPortPath.Text);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPortPath.Text = dialog.FileName;
                config.portPath = dialog.FileName;
            }
            dialog.Dispose();
        }

        private async void ButtonCheckUpdates_Click(object sender, EventArgs e)
        {
            // Check the current branch
            if (currentBranch == string.Empty)
            {
                Utils.ShowError("No branch has been selected");
                return;
            }

            // Save config
            SaveControls();
            SaveConfigs();

            // Error Handling
            if (!CheckForErrors())
                return;

            SetMainControlsState(false);
            await CheckForUpdates();
        }

        private void ButtonConfigRemove_Click(object sender, EventArgs e)
        {
            string text = configs.Count > 1 ? $"Config {config.Name} will be removed" : $"Your last config ({config.Name}) will be removed";

            if (MessageBox.Show(text, "Attention", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                configs.Remove(config);
                if (configs.Count == 0)
                    configs.Add(new Config("main"));
                config = configs[0];
                LoadContent();
            }
        }

        private void ButtonConfigSave_Click(object sender, EventArgs e)
        {
            SaveControls();
            SaveConfigs();
        }

        private void ButtonCreateConfig_Click(object sender, EventArgs e)
        {
            FormSetName formName = new FormSetName("", from n in configs select n.Name);
            if (formName.ShowDialog() == DialogResult.OK)
            {
                SaveControls();
                configs.Add(new Config(formName.Result));
                comboBoxConfig.Items.Add(formName.Result);
                comboBoxConfig.SelectedItem = formName.Result;
                config = configs.Last();
                LoadContent();
            }
            formName.Dispose();
        }

        private void ButtonDuplicateConfig_Click(object sender, EventArgs e)
        {
            FormSetName formName = new FormSetName(config.Name, from n in configs select n.Name);
            if (formName.ShowDialog() == DialogResult.OK)
            {
                SaveControls();
                configs.Add(new Config("temp"));
                configs.Last().Load(config.Save());
                configs.Last().Name = formName.Result;
                comboBoxConfig.Items.Add(formName.Result);
                config = configs.Last();
                LoadContent();
            }
            formName.Dispose();
        }

        private void ButtonLaunch_Click(object sender, EventArgs e)
        {
            try
            {
                if (launchProblem != String.Empty)
                {
                    Utils.ShowError("There are some problems in the load order - please fix them first:\r\n" + launchProblem);
                    return;
                }

                // Save config
                SaveControls();
                CalculateDMFlags();
                SaveConfigs();

                // Error Handling
                if (!CheckForErrors())
                    return;

                // Launch
                Process.Start(config.portPath, BuildCommandLine());
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            PopulatePatches();
            PopulateMods();
            LoadControls();
        }

        private void ButtonRenameConfig_Click(object sender, EventArgs e)
        {
            FormSetName formName = new FormSetName(config.Name, from n in configs select n.Name);
            if (formName.ShowDialog() == DialogResult.OK)
            {
                config.Name = formName.Result;
                comboBoxConfig.Items[comboBoxConfig.SelectedIndex] = formName.Result;
            }
            formName.Dispose();
        }

        private void ButtonShowCommandLine_Click(object sender, EventArgs e)
        {
            // Now this method is showing the form containing command-line parameters instead of copying them to clipboard
            PatchInfo.CheckForConflicts(patches);
            SaveControls();
            CalculateDMFlags();
            SaveConfigs();
            FormCommandLine fcl = new FormCommandLine("\"" + config.portPath + "\"" + BuildCommandLine());
            fcl.ShowDialog();
            fcl.Dispose();
        }

        private void CalculateDMFlags()
        {
            int flags = 0;
            int flags2 = 0;

            for (int i = 0; i < DMFlags.Count; i++)
            {
                if (listViewDMFlags.Items[i].Checked ^ DMFlags[i].DefaultState)
                    flags |= DMFlags[i].Key;
            }

            for (int i = 0; i < DMFlags2.Count; i++)
            {
                if (listViewDMFlags2.Items[i].Checked ^ DMFlags2[i].DefaultState)
                    flags2 |= DMFlags2[i].Key;
            }

            config.DMFlags = flags;
            config.DMFlags2 = flags2;
        }

        private void CheckBoxDMFlags_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDMFlags.Checked)
                listViewDMFlags.Enabled = true;
            else
                listViewDMFlags.Enabled = false;
        }

        private void CheckBoxDMFlags2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDMFlags2.Checked)
                listViewDMFlags2.Enabled = true;
            else
                listViewDMFlags2.Enabled = false;
        }

        private void CheckedListBoxPatches_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue != e.CurrentValue)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    patches[e.Index].Enabled = true;
                    AddMod(patches[e.Index].Path);
                }
                else
                {
                    patches[e.Index].Enabled = false;
                    RemoveMod(patches[e.Index].Path, true);
                }
                RefreshLoadOrder();
            }
        }

        private void CheckBoxMultiplayer_CheckedChanged(object sender, EventArgs e)
        {
            CheckMultiplayer();
        }

        private bool CheckForErrors()
        {
            if (config.portPath == string.Empty)
            {
                Utils.ShowError("You must specify a source port path!");
                return false;
            }

            if (Path.GetDirectoryName(config.portPath) == config.DRPGPath)
            {
                Utils.ShowError("The Port Path and Doom RPG path cannot be the same!");
                return false;
            }

            if (config.DRPGPath == Application.StartupPath)
            {
                Utils.ShowError("You cannot keep the launcher within the Doom RPG folder! Please move it to a different location.");
                return false;
            }

            if (config.mods.Contains($"{config.DRPGPath}\\DoomRPG") && !PatchInfo.CheckForPatches(patches, config.mods))
            {
                return false;
            }

            return true;
        }

        private bool CheckForMods()
        {
            if (Directory.Exists(textBoxDRPGPath.Text))
            {
                var files = from file in Directory.EnumerateFiles(textBoxDRPGPath.Text) where file.Length > 3 select file.Substring(file.Length - 3).ToLower();
                foreach (string file in files)
                    if (fileTypes.Contains(file))
                        return true;
            }

            return false;
        }

        private async Task CheckForUpdates()
        {
            // Extra check to see if your selected Doom RPG path already has stuff in it
            if (CheckForMods())
            {
                DialogResult createResult = MessageBox.Show("The Doom RPG folder contains other mod files. Would you like to create a subfolder for Doom RPG?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (createResult == DialogResult.Yes)
                {
                    string path = $"\\{config.fork.Split('/').Last()}";
                    textBoxDRPGPath.Text += path;
                    config.DRPGPath += path;
                }
                else
                    return;
            }

            toolStripStatusLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            toolStripStatusLabel.Text = "Checking for updates...";
            toolStripProgressBar.Style = ProgressBarStyle.Marquee;

            try
            {
                string branchSHA = await GetBranchSHA(currentBranch);
                string SHAPath = config.DRPGPath + "\\SHA-1";

                // Does the SHA-1 of the current version match the remote branch?
                if (Directory.Exists(config.DRPGPath + "\\.git")) // Version is pulled from git, why bother updating with the launcher?
                {
                    toolStripStatusLabel.Text = "This version of Doom RPG is managed by git";
                    toolStripProgressBar.Style = ProgressBarStyle.Continuous;
                    SetMainControlsState(true);
                    return;
                }
                else if (!Directory.Exists(config.DRPGPath)) // Directory wasn't found
                {
                    toolStripStatusLabel.ForeColor = Color.Red;
                    toolStripStatusLabel.Text = "Could not find Doom RPG directory, downloading latest version...";
                }
                else if (File.Exists(SHAPath))
                {
                    string localSHA = File.ReadAllLines(SHAPath)[0];

                    // Not a match, need to grab the latest version
                    if (branchSHA != localSHA)
                    {
                        toolStripStatusLabel.ForeColor = Color.Red;
                        toolStripStatusLabel.Text = "Out-of-date, downloading latest version...";
                    }
                    else // Up-to-date
                    {
                        toolStripStatusLabel.ForeColor = Color.Green;
                        toolStripStatusLabel.Text = "Already up-to-date!";
                        toolStripProgressBar.Style = ProgressBarStyle.Continuous;
                        SetMainControlsState(true);
                        return;
                    }
                }
                else // Could not find SHA-1, download a new copy
                {
                    toolStripStatusLabel.ForeColor = Color.Red;
                    toolStripStatusLabel.Text = "Could not find SHA-1, downloading latest version...";
                }

                // Wipe Warning
                DialogResult result;
               
                if (config.wipeWarning)
                    result = MessageBox.Show("Updating Doom RPG will wipe whatever is in your selected Doom RPG folder. Are you sure you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                else
                    result = DialogResult.Yes;

                if (result == DialogResult.Yes)
                {
                    // Delete the old folder
                    if (Directory.Exists(config.DRPGPath))
                        Directory.Delete(config.DRPGPath, true);

                    await Task.Delay(1000 * 3);
                    toolStripProgressBar.Style = ProgressBarStyle.Continuous;

                    DownloadDRPG();
                }
                else
                {
                    toolStripStatusLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                    toolStripStatusLabel.Text = "Update was cancelled by user";
                    toolStripProgressBar.Style = ProgressBarStyle.Continuous;
                    SetMainControlsState(true);
                }
            }
            catch (Exception e)
            {
                Utils.ShowError(e);
            }
        }

        private void CheckMultiplayer()
        {
            if (checkBoxMultiplayer.Checked)
            {
                groupBoxMode.Enabled = true;
                groupBoxServerMode.Enabled = true;
                CheckMultiplayerHosting();
                CheckMultiplayerJoining();
            }
            else
            {
                groupBoxMode.Enabled = false;
                groupBoxServerMode.Enabled = false;
                groupBoxServerOptions.Enabled = false;
            }
        }

        private void CheckMultiplayerHosting()
        {
            if (radioButtonHosting.Checked)
            {
                numericUpDownPlayers.Enabled = true;
                radioButtonPeerToPeer.Enabled = true;
                radioButtonPacketServer.Enabled = true;
                groupBoxServerOptions.Enabled = true;
            }
            else
            {
                numericUpDownPlayers.Enabled = false;
                radioButtonPeerToPeer.Enabled = false;
                radioButtonPacketServer.Enabled = false;
                groupBoxServerOptions.Enabled = false;
            }
        }

        private void CheckMultiplayerJoining()
        {
            if (radioButtonJoining.Checked)
                textBoxHostname.Enabled = true;
            else
                textBoxHostname.Enabled = false;
        }

        private void CheckPaths()
        {
            if (Directory.Exists(textBoxDRPGPath.Text))
            {
                string problem = String.Empty;
                if (Directory.Exists(textBoxIWADsPath.Text))
                {
                    if (textBoxIWADsPath.Text.StartsWith(textBoxDRPGPath.Text))
                        problem += "DoomRPG folder should not contain IWADs folder\r\n";
                }
                if (Directory.Exists(textBoxModsPath.Text))
                {
                    if (textBoxModsPath.Text.StartsWith(textBoxDRPGPath.Text))
                        problem += "DoomRPG folder should not contain mods folder\r\n";
                    else if (textBoxDRPGPath.Text.StartsWith(textBoxModsPath.Text))
                        problem += "Mods folder should not contain DoomRPG folder\r\n";
                }
                if (File.Exists(textBoxPortPath.Text))
                {
                    if (Path.GetDirectoryName(textBoxPortPath.Text).StartsWith(textBoxDRPGPath.Text))
                        problem += "DoomRPG folder should not contain GZDoom folder\r\n";
                }

                if (problem != String.Empty)
                    Utils.ShowError(problem);
            }
        }

        private void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                ExtractDRPG();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            toolStripStatusLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            toolStripStatusLabel.Text = "Downloading... " + (e.BytesReceived / 1024) + "KB / " + (e.TotalBytesToReceive / 1024) + "KB (" + e.ProgressPercentage + "%)";
            toolStripProgressBar.Value = e.ProgressPercentage;
        }

        private void ComboBoxBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentBranch = comboBoxBranch.Text;
        }

        private void ComboBoxConfig_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SaveControls();
            config = configs.Find(c => c.Name == comboBoxConfig.SelectedItem.ToString());
            LoadContent();
            PopulateMods();
            PopulatePatches();
        }

        private void ConvertPaths()
        {
            // Check for relative paths and make them absolute
            if (config.DRPGPath.StartsWith("."))
            {
                config.DRPGPath = Path.GetFullPath(config.DRPGPath);
            }
            if (config.IWADPath.StartsWith("."))
            {
                config.IWADPath = Path.GetFullPath(config.IWADPath);
            }
            if (config.modsPath.StartsWith("."))
            {
                config.modsPath = Path.GetFullPath(config.modsPath);
            }
            if (config.portPath.StartsWith("."))
            {
                config.portPath = Path.GetFullPath(config.portPath);
            }
        }

        private void DownloadDRPG()
        {
            Uri uri = new Uri($@"https://github.com/{config.fork}/archive/{currentBranch}.zip");
            string path = Application.StartupPath;
            string zipName = "\\DoomRPG.zip";

            using (WebClient client = new WebClient())
            {
                client.DownloadFileAsync(uri, path + zipName);
                client.DownloadProgressChanged += Client_DownloadProgressChanged;
                client.DownloadFileCompleted += Client_DownloadFileCompleted;
            }
        }

        private void ExtractDRPG()
        {
            string path = Application.StartupPath;
            string zipPath = path + "\\DoomRPG.zip";

            try
            {
                toolStripStatusLabel.Text = "Extracting DoomRPG.zip...";
                toolStripProgressBar.Style = ProgressBarStyle.Marquee;
                Thread extractThread = new Thread(ExtractZip);
                extractThread.Start();
                TextBoxDRPGPath_TextChanged(null, null);
            }
            catch (Exception e)
            {
                Utils.ShowError(e);
            }
        }

        private async void ExtractZip()
        {
            string path = Application.StartupPath;
            string zipPath = path + "\\DoomRPG.zip";

            // Extract the zip
            ZipFile.ExtractToDirectory(zipPath, path);

            // Move the files to the root folder
            Directory.Move(path + $@"\{config.fork.Split('/')[1]}-" + currentBranch, config.DRPGPath);

            // Add the SHA-1 file
            File.WriteAllText(config.DRPGPath + "\\SHA-1", await GetBranchSHA(currentBranch));

            // Delete the zip
            File.Delete(zipPath);

            Invoke(new MethodInvoker(delegate
            {
                toolStripStatusLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                toolStripStatusLabel.Text = "Ready";
                toolStripProgressBar.Style = ProgressBarStyle.Continuous;
                SetMainControlsState(true);
                TextBoxDRPGPath_TextChanged(null, null);
            }));
        }

        private void SetMainControlsState(bool state)
        {
            buttonCheckUpdates.Enabled = state;
            buttonLaunch.Enabled = state;
            comboBoxForks.Enabled = state;
            comboBoxBranch.Enabled = state;
        }

        private async Task<List<string>> GetBranches()
        {
            List<string> branchNames = new List<string>();
            string[] fork = comboBoxForks.Text.Split('/');

            foreach (Branch branch in await Octokitten.GetAllBranches(fork[0], fork[1]))
                branchNames.Add(branch.name);

            return branchNames;
        }

        private async Task<string> GetBranchSHA(string branchName)
        {
            string[] fork = config.fork.Split('/');
            Branch branch = (await Octokitten.GetAllBranches(fork[0], fork[1])).Single(b => b.name == branchName);
            return branch?.commit.sha ?? string.Empty;
        }

        private void ListViewDMFlags_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                if (e.Index == 4 || e.Index == 5)
                    listViewDMFlags.Items[3].Checked = false;
                if (e.Index == 3 || e.Index == 5)
                    listViewDMFlags.Items[4].Checked = false;
                if (e.Index == 3 || e.Index == 4)
                    listViewDMFlags.Items[5].Checked = false;
            }
        }

        private void LoadConfigs()
        {
            try
            {
                if (File.Exists(configPath))
                {
                    string[] data = File.ReadAllLines(configPath);
                    List<string> package = new List<string>();
                    string current = string.Empty;

                    // Sort of backwards compatibility
                    if (!data[0].Contains("Name") && !data[1].Contains("Name"))
                        configs.Add(new Config("main"));

                    for (int i = 0; i < data.Length; i++)
                    {
                        if (data[i].StartsWith("Name=") || i == data.Length - 1)
                        {
                            if (package.Count > 0)
                            {
                                configs.Last().Load(package);
                                package = new List<string>();
                            }
                            if (i < data.Length - 1)
                                configs.Add(new Config(data[i].Substring(5)));
                        }
                        else if (data[i].StartsWith("CurrentConfig="))
                        {
                            current = data[i].Substring(14);
                        }
                        else
                        {
                            // Backwards compatibility again
                            if (data[i].StartsWith("difficulty=") && !int.TryParse(data[i].Substring(11), out _))
                                package.Add("difficulty=1");
                            else
                                package.Add(data[i]);
                        }
                    }

                    config = configs.Find(c => c.Name == current);

                    ConvertPaths();
                }

                if (config == null)
                {
                    if (configs.Count == 0)
                        configs.Add(new Config("main"));
                    config = configs[0];
                }
            }
            catch (Exception e)
            {
                Utils.ShowError(e);
            }
        }

        private void LoadContent()
        {
            // Populate dynamic controls
            PopulateComboBoxes();

            // Load Controls
            LoadControls();
        }

        private void LoadControls()
        {
            comboBoxForks.SelectedItem = config.fork;
            comboBoxForks.SelectedItem = config.branch;
            textBoxPortPath.Text = config.portPath;
            textBoxIWADsPath.Text = config.IWADPath;
            textBoxDRPGPath.Text = config.DRPGPath;
            textBoxModsPath.Text = config.modsPath;
            comboBoxStartupMode.SelectedIndex = config.startupMode;
            numericUpDownMapNumber.Value = config.mapNumber;
            textBoxDemo.Text = config.demo;
            checkBoxEnableCheats.Checked = config.enableCheats;
            checkBoxLogging.Checked = config.enableLogging;
            checkBoxMultiplayer.Checked = config.multiplayer;
            if (config.multiplayerMode == MultiplayerMode.Hosting)
                radioButtonHosting.Checked = true;
            if (config.multiplayerMode == MultiplayerMode.Joining)
                radioButtonJoining.Checked = true;
            if (config.serverType == ServerType.PeerToPeer)
                radioButtonPeerToPeer.Checked = true;
            if (config.serverType == ServerType.PacketServer)
                radioButtonPacketServer.Checked = true;
            CheckMultiplayer();
            numericUpDownPlayers.Value = config.players;
            textBoxHostname.Text = config.hostname;
            checkBoxExtraTics.Checked = config.extraTics;
            numericUpDownDuplicate.Value = config.duplicate;
            textBoxCustomCommands.Text = config.customCommands;
            checkBoxDMFlags.Checked = config.EnableDMFlags;
            checkBoxDMFlags2.Checked = config.EnableDMFlags2;
            this.Size = config.windowSize;
        }

        private void LoadCredits()
        {
            string creditsPath = textBoxDRPGPath.Text + "\\CREDITS.txt";

            if (File.Exists(creditsPath))
            {
                string[] credits = File.ReadAllLines(creditsPath);
                for (int i = 0; i < credits.Length; i++)
                    credits[i] = credits[i].Trim();
                richTextBoxCredits.Lines = credits;
                RichTextBoxCredits_TextChanged(null, null);
            }
        }

        private async Task PopulateBranchesComboBox()
        {
            comboBoxBranch.Items.Clear();
            comboBoxBranch.Items.AddRange((await GetBranches()).ToArray());
            comboBoxBranch.SelectedItem = "master";
            comboBoxBranch.Enabled = true;
        }

        private void PopulateComboBoxes()
        {
            // Configs
            comboBoxConfig.Items.Clear();
            foreach (Config c in configs)
                comboBoxConfig.Items.Add(c.Name);
            comboBoxConfig.SelectedIndex = configs.IndexOf(config);
            
            // Populate forks combo box
            PopulateForksComboBox();

            // IWADs
            PopulateIWADs();

            // Difficulty
            PopulateDifficulty();

            // Savegames
            PopulateSaveGames();
        }

        private void PopulateDifficulty()
        {
            var difficulties = IsDRLAActive ? Enum.GetValues(typeof(DRLADifficulty)) : Enum.GetValues(typeof(Difficulty));
            comboBoxDifficulty.DataSource = difficulties;
            comboBoxDifficulty.SelectedIndex = Math.Min(config.difficulty, difficulties.Length - 1);
        }

        private void PopulateDMFlags()
        {
            if (File.Exists("DMFlags.txt"))
            {
                try
                {
                    string[] lines = File.ReadAllLines("DMFlags.txt");
                    foreach (string line in lines)
                    {
                        string[] values = line.Split('\t');
                        if (values[0] == "DMFlags")
                            DMFlags.Add(new DMFlag(int.Parse(values[1]), values[2], bool.Parse(values[3]), values[4]));
                        else
                            DMFlags2.Add(new DMFlag(int.Parse(values[1]), values[2], bool.Parse(values[3]), values[4]));
                    }
                    // Disable selection of items to prevent confusion
                    listViewDMFlags.SelectedIndexChanged += SkipSelection;
                    // Allow only one type of FallingDamage selected
                    listViewDMFlags.ItemCheck += ListViewDMFlags_ItemCheck;
                    for (int i = 0; i < DMFlags.Count; i++)
                    {
                        listViewDMFlags.Items.Add(DMFlags[i].Name);
                        listViewDMFlags.Items[listViewDMFlags.Items.Count - 1].Checked = ((config.DMFlags & DMFlags[i].Key) == DMFlags[i].Key) ^ DMFlags[i].DefaultState;
                        listViewDMFlags.Items[listViewDMFlags.Items.Count - 1].ToolTipText = DMFlags[i].Description;
                    }
                    listViewDMFlags.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

                    listViewDMFlags2.SelectedIndexChanged += SkipSelection;
                    for (int i = 0; i < DMFlags2.Count; i++)
                    {
                        listViewDMFlags2.Items.Add(DMFlags2[i].Name);
                        listViewDMFlags2.Items[listViewDMFlags2.Items.Count - 1].Checked = ((config.DMFlags2 & DMFlags2[i].Key) == DMFlags2[i].Key) ^ DMFlags2[i].DefaultState;
                        listViewDMFlags2.Items[listViewDMFlags2.Items.Count - 1].ToolTipText = DMFlags2[i].Description;
                    }
                    listViewDMFlags2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
                catch (Exception e)
                {
                    Utils.ShowError(e);
                }
            }
            else
            {
                Utils.ShowError("Can't locate DMFlags.txt in DRPG SE Launcher folder. Please re-download the launcher");
            }
        }

        private void PopulateIWADs()
        {
            comboBoxIWAD.Items.Clear();
            foreach (string iwad in IWADs.Where(w => File.Exists(config.IWADPath + "\\" + w)))
            {
                comboBoxIWAD.Items.Add(iwad);
            }
            comboBoxIWAD.SelectedItem = config.iwad;
        }

        private void PopulateForksComboBox()
        {
            string[] forks;
            if (!File.Exists("Forks.txt"))
            {
                File.WriteAllText("Forks.txt", "Sumwunn/DoomRPG");
                forks = new string[] { "Sumwunn/DoomRPG" };
            }
            else
            {
                forks = File.ReadAllLines("Forks.txt");
            }

            comboBoxForks.Items.Clear();
            comboBoxForks.Items.AddRange(forks);
        }

        private void PopulateMods()
        {
            // Remove non-existant mods
            config.mods.RemoveAll(m => !File.Exists(m) && !Directory.Exists(m));

            RefreshLoadOrder();

            treeViewMods.Nodes.Clear();
            if (Directory.Exists($"{config.DRPGPath}\\DoomRPG"))
            {
                treeViewMods.Nodes.Add("DoomRPG");
                if (config.mods.Contains($"{config.DRPGPath}\\DoomRPG"))
                    treeViewMods.Nodes[0].Checked = true;
            }
            if (Directory.Exists(config.modsPath))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(config.modsPath);
                foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
                {
                    if (directory.FullName != config.DRPGPath)
                        BuildTree(directory, treeViewMods.Nodes);
                }
                foreach (FileInfo file in directoryInfo.GetFiles().Where(file => fileTypes.Any(file.Name.EndsWith)))
                {
                    treeViewMods.Nodes.Add(file.Name);
                    if (config.mods.Contains(file.FullName))
                        treeViewMods.Nodes[treeViewMods.Nodes.Count - 1].Checked = true;
                }
            }
        }

        private void ListViewLoadOrder_SizeChanged(object sender, EventArgs e)
        {
            listViewLoadOrder.Columns[0].Width = listViewLoadOrder.Width - 4;
        }

        private void PopulatePatches()
        {
            patches.Clear();
            checkedListBoxPatches.Items.Clear();

            // Populate the patches array
            if (Directory.Exists(config.DRPGPath))
            {
                List<string> folders = Directory.EnumerateDirectories(config.DRPGPath).ToList();

                foreach (string folder in folders)
                {
                    var files = from fullPath in Directory.EnumerateFiles(folder) select Path.GetFileName(fullPath);

                    if (files.Contains("DRPGINFO.txt"))
                    {
                        PatchInfo info = PatchInfo.ReadPatch(folder + "\\DRPGINFO.txt");
                        patches.Add(info);
                        checkedListBoxPatches.Items.Add(info.Name);
                        if (config.mods.Contains(info.Path))
                            checkedListBoxPatches.SetItemChecked(patches.Count - 1, true);
                    }
                }

                // Populate DRLA(X) Class
                PopulateClasses();
            }
        }

        private void PopulateClasses()
        {
            var classes = patches.Find(p => p.Name == "DoomRL Arsenal Extended")?.Enabled ?? false ? Enum.GetValues(typeof(DRLAXClass)) : Enum.GetValues(typeof(DRLAClass));
            comboBoxClass.DataSource = classes;
            comboBoxClass.SelectedIndex = Math.Min((int)config.rlClass, classes.Length - 1);
        }

        private void PopulateSaveGames()
        {
            comboBoxSaveGame.Items.Clear();

            if (File.Exists(config.portPath))
            {
                string dir = Path.GetDirectoryName(config.portPath);
                dir = Directory.Exists(dir + "\\Save") ? dir + "\\Save" : dir;
                List<string> files = Directory.EnumerateFiles(dir, "*.zds").ToList();

                foreach (string file in files)
                    comboBoxSaveGame.Items.Add(Path.GetFileName(file));
            }

            if (comboBoxSaveGame.Items.Count > 0)
                comboBoxSaveGame.SelectedIndex = 0;
        }

        private void RadioButtonHosting_CheckedChanged(object sender, EventArgs e)
        {
            CheckMultiplayerHosting();
        }

        private void RadioButtonJoining_CheckedChanged(object sender, EventArgs e)
        {
            CheckMultiplayerJoining();
        }

        private void RichTextBoxCredits_TextChanged(object sender, EventArgs e)
        {
            List<string> headers = new List<string>()
            {
                "Original Author", "Testers", "Contributors", "Resources", "Libraries", "Graphics", "Sounds", "Music", "Misc"
            };
            foreach (string s in headers)
            {
                int index = richTextBoxCredits.Text.IndexOf(s);
                while (index != -1)
                {
                    richTextBoxCredits.Select(index, s.Length);
                    richTextBoxCredits.SelectionFont = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
                    richTextBoxCredits.SelectionColor = Color.Green;
                    richTextBoxCredits.SelectionAlignment = HorizontalAlignment.Center;
                    index = richTextBoxCredits.Text.IndexOf(s, index + s.Length);
                }
            }
        }

        private void SaveConfigs()
        {
            try
            {
                List<string> data = new List<string> { $"CurrentConfig={config.Name}" };
                foreach (Config c in configs)
                {
                    data.AddRange(c.Save());
                }
                File.WriteAllLines(configPath, data);
            }
            catch (Exception e)
            {
                Utils.ShowError(e);
            }
        }

        private void SaveControls()
        {
            config.fork = comboBoxForks.SelectedItem.ToString() ?? "Sumwunn/DoomRPG";
            config.branch = comboBoxBranch.SelectedItem?.ToString() ?? "master";
            config.portPath = textBoxPortPath.Text;
            config.IWADPath = textBoxIWADsPath.Text;
            config.DRPGPath = textBoxDRPGPath.Text;
            config.modsPath = textBoxModsPath.Text;
            config.iwad = comboBoxIWAD.SelectedItem?.ToString() ?? "doom2.wad";
            config.startupMode = comboBoxStartupMode.SelectedIndex;
            config.difficulty = comboBoxDifficulty.SelectedIndex;
            config.rlClass = (DRLAXClass)comboBoxClass.SelectedIndex;
            config.mapNumber = (int)numericUpDownMapNumber.Value;
            config.demo = textBoxDemo.Text;
            config.enableCheats = checkBoxEnableCheats.Checked;
            config.enableLogging = checkBoxLogging.Checked;
            config.multiplayer = checkBoxMultiplayer.Checked;
            if (radioButtonHosting.Checked)
                config.multiplayerMode = MultiplayerMode.Hosting;
            if (radioButtonJoining.Checked)
                config.multiplayerMode = MultiplayerMode.Joining;
            if (radioButtonPeerToPeer.Checked)
                config.serverType = ServerType.PeerToPeer;
            if (radioButtonPacketServer.Checked)
                config.serverType = ServerType.PacketServer;
            config.players = (int)numericUpDownPlayers.Value;
            config.hostname = textBoxHostname.Text;
            config.extraTics = checkBoxExtraTics.Checked;
            config.duplicate = (int)numericUpDownDuplicate.Value;
            config.customCommands = textBoxCustomCommands.Text;
            config.EnableDMFlags = checkBoxDMFlags.Checked;
            config.EnableDMFlags2 = checkBoxDMFlags2.Checked;
            config.windowSize = this.Size;
        }

        private void SkipSelection(object sender, EventArgs e)
        {
            ((System.Windows.Forms.ListView)sender).SelectedIndices.Clear();
        }

        private void ComboBoxStartupMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.startupMode = comboBoxStartupMode.SelectedIndex;
            if (comboBoxStartupMode.SelectedIndex == 0)
            {
                comboBoxDifficulty.Enabled = false;
                comboBoxClass.Enabled = false;
                numericUpDownMapNumber.Enabled = false;
                checkBoxMultiplayer.Checked = false;
                checkBoxMultiplayer.Enabled = false;
                textBoxDemo.Enabled = false;
                comboBoxSaveGame.Enabled = false;
            }
            else if (comboBoxStartupMode.SelectedIndex == 1)
            {
                comboBoxDifficulty.Enabled = true;
                if (IsDRLAActive)
                    comboBoxClass.Enabled = true;
                numericUpDownMapNumber.Enabled = true;
                checkBoxMultiplayer.Enabled = true;
                textBoxDemo.Enabled = true;
                comboBoxSaveGame.Enabled = false;
            }
            else
            {
                comboBoxSaveGame.Enabled = true;
                checkBoxMultiplayer.Enabled = true;
                comboBoxDifficulty.Enabled = false;
                comboBoxClass.Enabled = false;
                numericUpDownMapNumber.Enabled = false;
            }
        }

        private void TextBoxDRPGPath_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(textBoxDRPGPath.Text))
            {
                textBoxDRPGPath.ForeColor = SystemColors.WindowText;
                LoadCredits();
                PopulatePatches();
                CheckPaths();
            }
            else
            {
                textBoxDRPGPath.ForeColor = Color.Red;
            }
        }

        private void TextBoxIWADsPath_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(textBoxIWADsPath.Text))
            {
                textBoxIWADsPath.ForeColor = SystemColors.WindowText;
                config.IWADPath = textBoxIWADsPath.Text;
                PopulateIWADs();
                CheckPaths();
            }
            else
            {
                textBoxIWADsPath.ForeColor = Color.Red;
            }
        }

        private void TextBoxModsPath_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(textBoxModsPath.Text))
            {
                textBoxModsPath.ForeColor = SystemColors.WindowText;
                // Re-populate the mods list
                PopulateMods();
                CheckPaths();
            }
            else
            {
                textBoxModsPath.ForeColor = Color.Red;
            }
        }

        private void TextBoxPortPath_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(textBoxPortPath.Text))
            {
                textBoxPortPath.ForeColor = SystemColors.WindowText;
                CheckPaths();
            }
            else
                textBoxPortPath.ForeColor = Color.Red;
            
            PopulateSaveGames();
        }

        private void TimerPulse_Tick(object sender, EventArgs e)
        {
            // Launch button pulse
            int red = 160 + (int)(Math.Sin((double)DateTime.Now.Millisecond / 256) * 64);
            buttonLaunch.ForeColor = Color.FromArgb(255, red, 0, 0);
        }

        private void TreeViewMods_AfterCheck(object sender, TreeViewEventArgs e)
        {
            string mod = e.Node.FullPath != "DoomRPG" ? $"{config.modsPath}\\{e.Node.FullPath}" : $"{config.DRPGPath}\\DoomRPG";

            if (e.Action != TreeViewAction.Unknown)
            {
                if (!e.Node.Checked)
                {
                    RemoveMod(mod, true);
                }
                else
                    AddMod(mod);
            }
        }

        private void RefreshLoadOrder()
        {
            listViewLoadOrder.Items.Clear();
            launchProblem = "";

            int drpgIndex = config.mods.IndexOf($"{config.DRPGPath}\\DoomRPG");

            for (int i = 0; i < config.mods.Count; i++)
            {
                string file = config.mods[i].Split('\\').Last();
                listViewLoadOrder.Items.Add(file);

                PatchInfo patch = patches.Find(p => p.Path == config.mods[i]);
                if (patch != null)
                {
                    foreach (string req in patch.Requires)
                    {
                        if (!patches.Find(p => p.Name == req).Enabled)
                        {
                            string msg = $"Patch [{patch}] requires [{req}] to be activated\r\n";
                            listViewLoadOrder.Items[i].BackColor = Color.PaleVioletRed;
                            listViewLoadOrder.Items[i].ToolTipText += msg;
                            launchProblem += msg;
                        }
                    }
                    foreach (string conf in patch.Conflicts)
                    {
                        if (patches.Find(p => p.Name == conf).Enabled)
                        {
                            string msg = $"Patch [{patch}] conflicts with [{conf}]\r\n";
                            listViewLoadOrder.Items[i].BackColor = Color.Orange;
                            listViewLoadOrder.Items[i].ToolTipText += msg;
                            launchProblem += msg;
                        }
                    }
                    foreach (string mod in patch.ReqiredMods)
                    {
                        if (!config.mods.Exists(m => m.Split('\\').Last() == mod))
                        {
                            string msg = $"Patch [{patch}] requires the file {mod}\r\n";
                            listViewLoadOrder.Items[i].BackColor = Color.PaleVioletRed;
                            listViewLoadOrder.Items[i].ToolTipText += msg;
                            launchProblem += msg;
                        }
                    }
                    if (drpgIndex < 0)
                    {
                        string msg = $"Patch [{patch}] works only with DoomRPG\r\n";
                        listViewLoadOrder.Items[i].BackColor = Color.PaleVioletRed;
                        listViewLoadOrder.Items[i].ToolTipText += msg;
                        launchProblem += msg;
                    }
                    if (i < drpgIndex)
                    {
                        string msg = $"Patch [{patch}] should be placed after DoomRPG in load order\r\n";
                        listViewLoadOrder.Items[i].BackColor = Color.PaleVioletRed;
                        listViewLoadOrder.Items[i].ToolTipText += msg;
                        launchProblem += msg;
                    }
                }
                else
                {
                    if (drpgIndex > -1)
                    {
                        if (drpgIndex < i)
                        {
                            string msg = $"DoomRPG should be placed after all mods in load order\r\n";
                            listViewLoadOrder.Items[drpgIndex].BackColor = Color.PaleVioletRed;
                            listViewLoadOrder.Items[drpgIndex].ToolTipText = msg;
                            if (!launchProblem.Contains(msg))
                                launchProblem += msg;
                        }
                        foreach (PatchInfo p in patches)
                        {
                            foreach (string mod in p.ReqiredMods)
                            {
                                if (!p.Enabled && mod == file)
                                {
                                    string msg = $"This mod requires patch [{p}] to be activated\r\n";
                                    listViewLoadOrder.Items[i].BackColor = Color.PaleVioletRed;
                                    listViewLoadOrder.Items[i].ToolTipText += msg;
                                    launchProblem += msg;
                                }
                            }
                        }
                    }
                }
            }

            buttonLaunch.Text = drpgIndex > 0 ? "Launch Doom RPG" : "Launch Doom";
        }

        private void ListViewLoadOrder_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (listViewLoadOrder.DoDragDrop(e.Item, DragDropEffects.Move) == DragDropEffects.None)
            {
                ListViewItem item = (ListViewItem)e.Item;
                RemoveMod(config.mods[listViewLoadOrder.Items.IndexOf(item)]);
                listViewLoadOrder.Items.Remove(item);
            }
        }

        private void UncheckNodes(TreeNodeCollection nodes, string text)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked && node.Text == text)
                    node.Checked = false;
                if (node.Nodes.Count > 0)
                    UncheckNodes(node.Nodes, text);
            }
        }

        private void ListViewLoadOrder_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void ListViewLoadOrder_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = listViewLoadOrder.PointToClient(new Point(e.X, e.Y));
            int targetIndex = listViewLoadOrder.InsertionMark.NearestIndex(targetPoint);

            if (targetIndex > -1)
            {
                Rectangle itemBounds = listViewLoadOrder.GetItemRect(targetIndex);
                if (targetPoint.Y > itemBounds.Top + (itemBounds.Height / 2))
                {
                    listViewLoadOrder.InsertionMark.AppearsAfterItem = true;
                }
                else
                {
                    listViewLoadOrder.InsertionMark.AppearsAfterItem = false;
                }
            }

            listViewLoadOrder.InsertionMark.Index = targetIndex;
        }

        private void ListViewLoadOrder_DragLeave(object sender, EventArgs e)
        {
            listViewLoadOrder.InsertionMark.Index = -1;
        }

        private void ListViewLoadOrder_DragDrop(object sender, DragEventArgs e)
        {
            int targetIndex = listViewLoadOrder.InsertionMark.Index;

            if (targetIndex >= 0)
            {
                if (listViewLoadOrder.InsertionMark.AppearsAfterItem)
                {
                    targetIndex++;
                }

                ListViewItem draggedItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
                ListViewItem item = (ListViewItem)draggedItem.Clone();
                string mod = config.mods[draggedItem.Index];
                int newIndex = draggedItem.Index > targetIndex ? targetIndex : targetIndex - 1;

                listViewLoadOrder.Items.Remove(draggedItem);
                config.mods.Remove(mod);
                listViewLoadOrder.Items.Insert(newIndex, item);
                config.mods.Insert(newIndex, mod);

                RefreshLoadOrder();
            }
        }

        private void AddMod(string mod)
        {
            if (!config.mods.Contains(mod))
            {
                int drpgIndex = config.mods.IndexOf($"{config.DRPGPath}\\DoomRPG");
                if (drpgIndex < 0 || patches.FindIndex(p => p.Path == mod) >= 0)
                    config.mods.Add(mod);
                else
                    config.mods.Insert(drpgIndex, mod);
            }

            if (mod.Contains("DoomRL_Arsenal"))
            {
                PopulateDifficulty();
                if (config.startupMode == 1)
                    comboBoxClass.Enabled = true;
            }
            else if (mod.Contains("DRLAX_"))
                PopulateClasses();

            RefreshLoadOrder();
        }

        private void RemoveMod(string mod, bool manually = false)
        {
            config.mods.Remove(mod);
            string name = mod.Split('\\').Last();

            int index = patches.FindIndex(p => p.Path == mod);
            if (index >= 0)
            {
                // It is patch
                if (patches[index].Enabled)
                    patches[index].Enabled = false;
                if (!manually && checkedListBoxPatches.GetItemChecked(index))
                    checkedListBoxPatches.SetItemChecked(index, false);
            }
            else
            {
                // It is mod
                if (!manually)
                    UncheckNodes(treeViewMods.Nodes, name);

                else if (mod.Contains("DoomRL_Arsenal"))
                {
                    PopulateDifficulty();
                    if (config.startupMode == 1)
                        comboBoxClass.Enabled = false;
                }
            }

            RefreshLoadOrder();
        }
    }
}
