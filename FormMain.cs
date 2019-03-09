using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Octokit;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;

namespace DoomRPG
{
    public partial class FormMain : Form
    {
        Version version = Assembly.GetExecutingAssembly().GetName().Version;
        Config config = new Config();
        string currentBranch = string.Empty;
        List<PatchInfo> patches = new List<PatchInfo>();
        Dictionary<int, string> loadOrder = new Dictionary<int, string>();
        List<DMFlag> DMFlags = new List<DMFlag>();
        List<DMFlag> DMFlags2 = new List<DMFlag>();

        // Extensions of known mod filetypes
        string[] fileTypes =
        {
            "wad",                  // Original vanilla Doom archive type
            "zip", "pk3", "pk7",    // Archive File Types
            "deh", "bex"            // DeHackEd File Types
        };

        public FormMain()
        {
            InitializeComponent();
            
            // Title
            Text = "Doom RPG SE Launcher v" + version;

            // Load config
            config.Load();

            // Populate dynamic controls
            PopulateComboBoxes();

            // Patches
            PopulatePatches();

            // Mods
            PopulateMods();

            // DMFLags
            PopulateDMFlags();

            // Load Controls
            LoadControls();

            // Load Credits
            LoadCredits();

            // Populate branches combo box
            _ = PopulateBranchesComboBox();
        }

        private void PopulateDMFlags()
        {
            string[] lines = Properties.Resources.DMFlags.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
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

        private void ListViewDMFlags_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                if (e.Index == 4 || e.Index == 5)
                    listViewDMFlags.Items[3].Checked = false;
                if (e.Index == 3 || e.Index == 5)
                    listViewDMFlags.Items[4].Checked = false;
                if (e.Index == 3 || e.Index == 4 )
                    listViewDMFlags.Items[5].Checked = false;
            }
        }

        private void SkipSelection(object sender, EventArgs e)
        {
            ((ListView)sender).SelectedIndices.Clear();
        }

        private void ProcessLoadOrder()
        {
        }

        private void LoadCredits()
        {
            string creditsPath = textBoxDRPGPath.Text + "\\CREDITS.txt";

            if (File.Exists(creditsPath))
            {
                string credits = File.ReadAllText(creditsPath);

                richTextBoxCredits.Text = credits;
                RichTextBoxCredits_TextChanged(null, null);
            }
        }

        private void PopulateComboBoxes()
        {
            // IWAD
            for (int i = 0; i < Enum.GetNames(typeof(IWAD)).Length; i++)
                comboBoxIWAD.Items.Add(Enum.GetName(typeof(IWAD), i));
            comboBoxIWAD.SelectedIndex = (int)config.iwad;

            // Difficulty
            for (int i = 0; i < Enum.GetNames(typeof(Difficulty)).Length; i++)
                comboBoxDifficulty.Items.Add(Enum.GetName(typeof(Difficulty), i));
            comboBoxDifficulty.SelectedIndex = (int)config.difficulty;

            // DRLA Class
            for (int i = 0; i < Enum.GetNames(typeof(DRLAClass)).Length; i++)
                comboBoxClass.Items.Add(Enum.GetName(typeof(DRLAClass), i));
            comboBoxClass.SelectedIndex = (int)config.rlClass;

            // Savegames
            if (config.portPath != string.Empty)
            {
                List<string> files = Directory.EnumerateFiles(Path.GetDirectoryName(config.portPath)).ToList<string>();

                foreach (string file in files)
                    if (file.EndsWith(".zds"))
                        comboBoxSaveGame.Items.Add(Path.GetFileName(file));
            }
        }

        private async Task PopulateBranchesComboBox()
        {
            List<string> branches = await GetBranches();
            foreach (string branch in branches)
                comboBoxBranch.Items.Add(branch);
            comboBoxBranch.Text = "master";
            comboBoxBranch.Enabled = true;
        }

        private void PopulatePatches()
        {
            patches.Clear();
            checkedListBoxPatches.Items.Clear();

            // Populate the patches list
            if (config.DRPGPath != string.Empty)
                if (Directory.Exists(config.DRPGPath))
                {
                    List<string> folders = Directory.EnumerateDirectories(config.DRPGPath).ToList<string>();

                    foreach (string folder in folders)
                    {
                        List<string> files = Directory.EnumerateFiles(folder).ToList<string>();
                        bool isValid = false;

                        foreach (string file in files)
                            if (file.Contains("DRPGINFO.txt"))
                            {
                                isValid = true;
                                break;
                            }

                        if (isValid)
                        {
                            PatchInfo info = PatchInfo.ReadPatch(folder + "\\DRPGINFO.txt");
                            patches.Add(info);
                        }
                        else
                            continue;
                    }
                }

            // Populate the Patches checklist box
            foreach (PatchInfo patch in patches)
            {
                checkedListBoxPatches.Items.Add(patch);
            }
        }

        private void PopulateMods()
        {
            checkedListBoxMods.Items.Clear();

            if (config.modsPath != string.Empty)
                if (Directory.Exists(config.modsPath))
                {
                    List<string> folders = Directory.EnumerateDirectories(config.modsPath).ToList<string>();
                    folders.Add(config.modsPath);

                    foreach (string folder in folders)
                    {
                        List<string> files = Directory.EnumerateFiles(folder).ToList<string>();

                        foreach (string file in files)
                            for (int i = 0; i < fileTypes.Length; i++)
                                if (file.ToLower().EndsWith("." + fileTypes[i]))
                                {
                                    string filePath = Path.GetFullPath(file);
                                    filePath = filePath.Substring(textBoxModsPath.Text.Length + 1);
                                    checkedListBoxMods.Items.Add(filePath);
                                }
                    }
                }
        }

        private bool CheckForErrors()
        {
            if (config.portPath == string.Empty)
            {
                Utils.ShowError("You must specify a source port path!");
                return false;
            }

            if (config.DRPGPath == string.Empty)
            {
                Utils.ShowError("You must specify Doom RPG's path!");
                return false;
            }

            if (Path.GetDirectoryName(config.portPath) == config.DRPGPath)
            {
                Utils.ShowError("The Port Path and Doom RPG path cannot be the same!");
                return false;
            }

            if (config.DRPGPath == Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
            {
                Utils.ShowError("You cannot keep the launcher within the Doom RPG folder! Please move it to a different location.");
                return false;
            }

            return true;
        }

        private bool CheckForMods()
        {
            if (textBoxDRPGPath.Text != string.Empty)
                if (Directory.Exists(textBoxDRPGPath.Text))
                {
                    List<string> files = Directory.EnumerateFiles(textBoxDRPGPath.Text).ToList<string>();

                    foreach (string file in files)
                        for (int i = 0; i < fileTypes.Length; i++)
                            if (file.ToLower().EndsWith(fileTypes[i]))
                                return true;
                }

            return false;
        }

        private void LoadControls()
        {
            textBoxPortPath.Text = config.portPath;
            textBoxDRPGPath.Text = config.DRPGPath;
            textBoxModsPath.Text = config.modsPath;
            numericUpDownMapNumber.Value = config.mapNumber;
            textBoxDemo.Text = config.demo;
            checkBoxEnableCheats.Checked = config.enableCheats;
            checkBoxLogging.Checked = config.enableLogging;
            for (int i = 0; i < patches.Count; i++)
                foreach (string patch in config.patches)
                    if (patches[i].Name.ToLower() == patch.ToLower())
                        checkedListBoxPatches.SetItemChecked(i, true);
            checkBoxMultiplayer.Checked = config.multiplayer;
            for (int i = 0; i < config.mods.Count; i++)
                if (checkedListBoxMods.FindStringExact(config.mods[i]) != -1)
                    checkedListBoxMods.SetItemChecked(checkedListBoxMods.FindStringExact(config.mods[i]), true);
            if (config.multiplayerMode == MultiplayerMode.Hosting)
                radioButtonHosting.Checked = true;
            if (config.multiplayerMode == MultiplayerMode.Joining)
                radioButtonJoining.Checked = true;
            if (config.serverType == ServerType.PeerToPeer)
                radioButtonPeerToPeer.Checked = true;
            if (config.serverType == ServerType.PacketServer)
                radioButtonPacketServer.Checked = true;
            numericUpDownPlayers.Value = config.players;
            textBoxHostname.Text = config.hostname;
            checkBoxExtraTics.Checked = config.extraTics;
            numericUpDownDuplicate.Value = config.duplicate;
            textBoxCustomCommands.Text = config.customCommands;
            checkBoxDMFlags.Checked = config.EnableDMFlags;
            checkBoxDMFlags2.Checked = config.EnableDMFlags2;
        }

        private void SaveControls()
        {
            config.portPath = File.Exists(textBoxPortPath.Text) ? textBoxPortPath.Text : String.Empty;
            config.DRPGPath = Directory.Exists(textBoxDRPGPath.Text) ? textBoxDRPGPath.Text : String.Empty;
            config.modsPath = Directory.Exists(textBoxModsPath.Text) ? textBoxModsPath.Text : String.Empty;
            config.iwad = (IWAD)comboBoxIWAD.SelectedIndex;
            config.difficulty = (Difficulty)comboBoxDifficulty.SelectedIndex;
            config.rlClass = (DRLAClass)comboBoxClass.SelectedIndex;
            config.mapNumber = (int)numericUpDownMapNumber.Value;
            config.demo = textBoxDemo.Text;
            config.enableCheats = checkBoxEnableCheats.Checked;
            config.enableLogging = checkBoxLogging.Checked;
            config.patches.Clear();
            for (int i = 0; i < patches.Count; i++)
                if (checkedListBoxPatches.GetItemChecked(i))
                    config.patches.Add(patches[i].Name);
            config.mods.Clear();
            for (int i = 0; i < checkedListBoxMods.Items.Count; i++)
                if (checkedListBoxMods.GetItemChecked(i))
                    config.mods.Add(checkedListBoxMods.Items[i].ToString());
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
        }

        private async Task<string> GetMasterSHA()
        {
            GitHubClient client = new GitHubClient(new ProductHeaderValue("DoomRPG"));
            Branch master = await client.Repository.Branch.Get("Sumwunn", "DoomRPG", currentBranch);
            return master.Commit.Sha;
        }

        private async Task<List<String>> GetBranches()
        {
            GitHubClient client = new GitHubClient(new ProductHeaderValue("DoomRPG"));
            List<String> branchNames = new List<string>();
            IReadOnlyList<Branch> branches = await client.Repository.Branch.GetAll("Sumwunn", "DoomRPG");

            foreach (Branch branch in branches)
                branchNames.Add(branch.Name);

            return branchNames;
        }

        private async Task CheckForUpdates()
        {
            DialogResult result;

            // Save the config
            SaveControls();
            config.Save();

            // Wipe Warning
            if (!config.wipeWarning)
                result = MessageBox.Show("This process will wipe whatever is in your selected Doom RPG folder. Are you sure you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            else
                result = DialogResult.Yes;

            // Extra check to see if your selected Doom RPG path already has stuff in it
            if (CheckForMods())
            {
                DialogResult createResult = MessageBox.Show("The Doom RPG folder contains other mod files. Would you like to create a subfolder for Doom RPG?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (createResult == DialogResult.Yes)
                {
                    textBoxDRPGPath.Text += "\\DoomRPG";
                    config.DRPGPath += "\\DoomRPG";
                }
                else
                    return;
            }

            if (result == DialogResult.Yes)
            {
                config.wipeWarning = true;

                toolStripStatusLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                toolStripStatusLabel.Text = "Checking for updates...";
                toolStripProgressBar.Style = ProgressBarStyle.Marquee;

                try
                {
                    string masterSHA = await GetMasterSHA();
                    string SHAPath = config.DRPGPath + "\\SHA-1";

                    // Does the SHA-1 of the current version match the remote branch?
                    if (Directory.Exists(config.DRPGPath + "\\.git")) // Version is pulled from git, why bother updating with the launcher?
                    {
                        toolStripStatusLabel.Text = "This version of Doom RPG is managed by git";
                        toolStripProgressBar.Style = ProgressBarStyle.Continuous;
                        buttonCheckUpdates.Enabled = true;
                        buttonLaunch.Enabled = true;
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
                        if (masterSHA != localSHA || !File.Exists(SHAPath))
                        {
                            toolStripStatusLabel.ForeColor = Color.Red;
                            toolStripStatusLabel.Text = "Out-of-date, downloading latest version...";
                        }
                        else // Up-to-date
                        {
                            toolStripStatusLabel.ForeColor = Color.Green;
                            toolStripStatusLabel.Text = "Already up-to-date!";
                            toolStripProgressBar.Style = ProgressBarStyle.Continuous;
                            buttonCheckUpdates.Enabled = true;
                            buttonLaunch.Enabled = true;
                            return;
                        }
                    }
                    else // Could not find SHA-1, download a new copy
                    {
                        toolStripStatusLabel.ForeColor = Color.Red;
                        toolStripStatusLabel.Text = "Could not find SHA-1, downloading latest version...";
                    }

                    // Delete the old folder
                    if (Directory.Exists(config.DRPGPath))
                        Directory.Delete(config.DRPGPath, true);

                    await Task.Delay(1000 * 3);
                    toolStripProgressBar.Style = ProgressBarStyle.Continuous;

                    DownloadDRPG();
                }
                catch (Exception e)
                {
                    Utils.ShowError(e);
                }
            }
            else
            {
                buttonCheckUpdates.Enabled = true;
                buttonLaunch.Enabled = true;
            }
        }

        private void DownloadDRPG()
        {
            Uri uri = new Uri("https://github.com/Sumwunn/DoomRPG/archive/" + currentBranch + ".zip");
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
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
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string zipPath = path + "\\DoomRPG.zip";
            FastZip zip = new FastZip();

            try
            {
                toolStripStatusLabel.Text = "Extracting DoomRPG.zip...";
                toolStripProgressBar.Style = ProgressBarStyle.Marquee;
                Thread extractThread = new Thread(ExtractZip);
                extractThread.Start();
            }
            catch (Exception e)
            {
                Utils.ShowError(e);
            }
        }

        private async void ExtractZip()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string zipPath = path + "\\DoomRPG.zip";
            FastZip zip = new FastZip();

            // Extract the zip
            zip.ExtractZip(zipPath, path, string.Empty);

            // Move the files to the root folder
            Directory.Move(path + "\\DoomRPG-" + currentBranch, config.DRPGPath);

            // Add the SHA-1 file
            File.WriteAllText(config.DRPGPath + "\\SHA-1", await GetMasterSHA());

            // Delete the zip
            File.Delete(zipPath);

            Invoke(new MethodInvoker(delegate
            {
                toolStripStatusLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                toolStripStatusLabel.Text = "Ready";
                toolStripProgressBar.Style = ProgressBarStyle.Continuous;
                buttonCheckUpdates.Enabled = true;
                buttonLaunch.Enabled = true;
            }));
        }

        private string BuildCommandLine()
        {
            string cmdline = string.Empty;

            // IWAD
            if (config.iwad == IWAD.Doom1)
                cmdline += " -iwad Doom";
            else
                cmdline += " -iwad " + config.iwad.ToString();

            if (config.mapNumber > 0)
            {
                // Skill/Difficulty
                cmdline += " -skill " + ((int)config.difficulty + 1);

                // Map Number
                cmdline += " -warp " + config.mapNumber;

                // DRLA Class
                if (IsDRLAActive())
                    cmdline += " +playerclass " + config.rlClass.ToString();
            }

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

            // Load Savegame
            if (comboBoxSaveGame.Text != "None")
                cmdline += " -loadgame " + Path.GetDirectoryName(textBoxPortPath.Text) + "\\" + comboBoxSaveGame.Text;

            // Record Demo
            if (textBoxDemo.TextLength > 0)
                cmdline += " -record " + textBoxDemo.Text + ".lmp";

            // Mods & Patches
            cmdline += " -file";

            // Mods selected from the mods list
            for (int i = 0; i < checkedListBoxMods.Items.Count; i++)
                if (checkedListBoxMods.GetItemChecked(i))
                    cmdline += " \"" + config.modsPath + "\\" + checkedListBoxMods.Items[i].ToString() + "\"";

            // Doom RPG
            cmdline += " \"" + config.DRPGPath + "\\DoomRPG\"";

            // Doom RPG Patches
            for (int i = 0; i < patches.Count; i++)
                if (checkedListBoxPatches.GetItemChecked(i))
                    cmdline += " \"" + patches[i].Path + "\"";

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

        private bool IsDRLAActive()
        {
            for (int i = 0; i < patches.Count; i++)
                if (patches[i].Name.ToLower().Contains("doomrl"))
                    if (checkedListBoxPatches.GetItemChecked(i))
                        return true;

            return false;
        }

        private void ButtonBrowsePortPath_Click(object sender, EventArgs e)
        {
            FileDialog dialog = new OpenFileDialog() { Title = "Specify (G)ZDoom EXE..." };
            if (textBoxPortPath.Text == String.Empty)
                dialog.InitialDirectory = Directory.GetCurrentDirectory();
            else
                dialog.InitialDirectory = Path.GetDirectoryName(textBoxPortPath.Text);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPortPath.Text = dialog.FileName;
                config.portPath = dialog.FileName;
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
                // Re-populate the mods list
                PopulateMods();
            }
        }

        private void TextBoxModsPath_TextChanged(object sender, EventArgs e)
        {
            // Re-populate the mods list
            PopulateMods();
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
            config.Save();

            // Error Handling
            if (!CheckForErrors())
                return;

            buttonCheckUpdates.Enabled = false;
            buttonLaunch.Enabled = false;
            await CheckForUpdates();
        }

        private void ButtonLaunch_Click(object sender, EventArgs e)
        {
            try
            {
                // Check for patch requirements
                if (!PatchInfo.CheckForRequirements(patches))
                    return;

                // Check for patch conflicts
                if (!PatchInfo.CheckForConflicts(patches))
                    return;

                // Save config
                SaveControls();
                CalculateDMFlags();
                config.Save();

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

        private void CalculateDMFlags()
        {
            int flags = 0;
            int flags2 = 0;
            
            for (int i = 0; i < listViewDMFlags.Items.Count; i++)
            {
                if (listViewDMFlags.Items[i].Checked ^ DMFlags[i].DefaultState)
                    flags |= DMFlags[i].Key;
            }

            for (int i = 0; i < listViewDMFlags2.Items.Count; i++)
            {
                if (listViewDMFlags2.Items[i].Checked ^ DMFlags2[i].DefaultState)
                    flags |= DMFlags2[i].Key;
            }

            config.DMFlags = flags;
            config.DMFlags2 = flags2;
        }

        private void RichTextBoxCredits_TextChanged(object sender, EventArgs e)
        {
            richTextBoxCredits.Find("Testers");
            richTextBoxCredits.SelectionFont = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            richTextBoxCredits.SelectionColor = Color.Green;
            richTextBoxCredits.Find("Contributors");
            richTextBoxCredits.SelectionFont = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            richTextBoxCredits.SelectionColor = Color.Red;
            richTextBoxCredits.Find("Resources");
            richTextBoxCredits.SelectionFont = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            richTextBoxCredits.SelectionColor = Color.Blue;
            richTextBoxCredits.Find("Libraries");
            richTextBoxCredits.SelectionFont = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            richTextBoxCredits.SelectionColor = Color.Blue;
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            toolStripStatusLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            toolStripStatusLabel.Text = "Downloading... " + (e.BytesReceived / 1024) + "KB / " + (e.TotalBytesToReceive / 1024) + "KB (" + e.ProgressPercentage + "%)";
            toolStripProgressBar.Value = e.ProgressPercentage;
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

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Check loaded patches
            for (int i = 0; i < patches.Count; i++)
                patches[i].Enabled = checkedListBoxPatches.GetItemChecked(i);

            // If Map Number is 0, skill is irrelevent
            if (numericUpDownMapNumber.Value == 0)
                comboBoxDifficulty.Enabled = false;
            else
                comboBoxDifficulty.Enabled = true;

            // Player Class
            if (numericUpDownMapNumber.Value > 0 && IsDRLAActive())
                comboBoxClass.Enabled = true;
            else
                comboBoxClass.Enabled = false;

            // Multiplayer Checkbox
            if (checkBoxMultiplayer.Checked)
            {
                groupBoxMode.Enabled = true;
                groupBoxServerMode.Enabled = true;
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
                if (radioButtonJoining.Checked)
                    textBoxHostname.Enabled = true;
                else
                    textBoxHostname.Enabled = false;
            }
            else
            {
                groupBoxMode.Enabled = false;
                groupBoxServerMode.Enabled = false;
                groupBoxServerOptions.Enabled = false;
            }
        }

        private void TimerPulse_Tick(object sender, EventArgs e)
        {
            // Launch button pulse
            int red = 160 + (int)(Math.Sin((double)DateTime.Now.Millisecond / 256) * 64);
            buttonLaunch.ForeColor = Color.FromArgb(255, red, 0, 0);
        }
        
        private void ButtonShowCommandLine_Click(object sender, EventArgs e)
        {
            // Now this method is showing the form containing command-line parameters instead of copying them to clipboard
            PatchInfo.CheckForRequirements(patches);
            PatchInfo.CheckForConflicts(patches);
            SaveControls();
            CalculateDMFlags();
            config.Save();
            new FormCommandLine("\"" + config.portPath + "\"" + BuildCommandLine()) { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            PopulatePatches();
            PopulateMods();
            LoadControls();
        }

        private void TextBoxDRPGPath_TextChanged(object sender, EventArgs e)
        {
            LoadCredits();
        }
        
        private void ComboBoxBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentBranch = comboBoxBranch.Text;
        }
    }
}
