namespace DoomRPG
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem("Mod1");
            System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem("Mod2");
            System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem("Mod3");
            System.Windows.Forms.ListViewItem listViewItem19 = new System.Windows.Forms.ListViewItem("Mod4");
            System.Windows.Forms.ListViewItem listViewItem20 = new System.Windows.Forms.ListViewItem("Mod5");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageBasic = new System.Windows.Forms.TabPage();
            this.buttonConfigSave = new System.Windows.Forms.Button();
            this.buttonBrowseIWADsPath = new System.Windows.Forms.Button();
            this.textBoxIWADsPath = new System.Windows.Forms.TextBox();
            this.labelIWADsLocation = new System.Windows.Forms.Label();
            this.buttonConfigRemove = new System.Windows.Forms.Button();
            this.buttonDuplicateConfig = new System.Windows.Forms.Button();
            this.buttonRenameConfig = new System.Windows.Forms.Button();
            this.buttonCreateConfig = new System.Windows.Forms.Button();
            this.comboBoxConfig = new System.Windows.Forms.ComboBox();
            this.labelConfig = new System.Windows.Forms.Label();
            this.checkBoxDRPG = new System.Windows.Forms.CheckBox();
            this.comboBoxBranch = new System.Windows.Forms.ComboBox();
            this.labelBranch = new System.Windows.Forms.Label();
            this.buttonShowCommandLine = new System.Windows.Forms.Button();
            this.textBoxDemo = new System.Windows.Forms.TextBox();
            this.labelRecordDemo = new System.Windows.Forms.Label();
            this.checkBoxLogging = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableCheats = new System.Windows.Forms.CheckBox();
            this.comboBoxSaveGame = new System.Windows.Forms.ComboBox();
            this.labelSavegame = new System.Windows.Forms.Label();
            this.comboBoxClass = new System.Windows.Forms.ComboBox();
            this.labelPlayerClass = new System.Windows.Forms.Label();
            this.comboBoxIWAD = new System.Windows.Forms.ComboBox();
            this.labelIWAD = new System.Windows.Forms.Label();
            this.buttonBrowseModsPath = new System.Windows.Forms.Button();
            this.textBoxModsPath = new System.Windows.Forms.TextBox();
            this.labelModsLocation = new System.Windows.Forms.Label();
            this.numericUpDownMapNumber = new System.Windows.Forms.NumericUpDown();
            this.labelMapNumber = new System.Windows.Forms.Label();
            this.comboBoxDifficulty = new System.Windows.Forms.ComboBox();
            this.labelDifficulty = new System.Windows.Forms.Label();
            this.buttonBrowseDRPGPath = new System.Windows.Forms.Button();
            this.textBoxDRPGPath = new System.Windows.Forms.TextBox();
            this.labelDoomRPGFolderLocation = new System.Windows.Forms.Label();
            this.buttonBrowsePortPath = new System.Windows.Forms.Button();
            this.textBoxPortPath = new System.Windows.Forms.TextBox();
            this.labelPortLocation = new System.Windows.Forms.Label();
            this.tabPageMultiplayer = new System.Windows.Forms.TabPage();
            this.groupBoxServerOptions = new System.Windows.Forms.GroupBox();
            this.labelDuplicate = new System.Windows.Forms.Label();
            this.numericUpDownDuplicate = new System.Windows.Forms.NumericUpDown();
            this.checkBoxExtraTics = new System.Windows.Forms.CheckBox();
            this.groupBoxServerMode = new System.Windows.Forms.GroupBox();
            this.radioButtonPacketServer = new System.Windows.Forms.RadioButton();
            this.radioButtonPeerToPeer = new System.Windows.Forms.RadioButton();
            this.groupBoxMode = new System.Windows.Forms.GroupBox();
            this.numericUpDownPlayers = new System.Windows.Forms.NumericUpDown();
            this.labelPlayers = new System.Windows.Forms.Label();
            this.textBoxHostname = new System.Windows.Forms.TextBox();
            this.radioButtonHosting = new System.Windows.Forms.RadioButton();
            this.radioButtonJoining = new System.Windows.Forms.RadioButton();
            this.checkBoxMultiplayer = new System.Windows.Forms.CheckBox();
            this.tabPageMods = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.listViewLoadOrder = new System.Windows.Forms.ListView();
            this.columnHeaderModName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelLoadOrder = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.labelMods = new System.Windows.Forms.Label();
            this.treeViewMods = new System.Windows.Forms.TreeView();
            this.tabPageDMFlags = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listViewDMFlags2 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkBoxDMFlags2 = new System.Windows.Forms.CheckBox();
            this.checkBoxDMFlags = new System.Windows.Forms.CheckBox();
            this.listViewDMFlags = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageCredits = new System.Windows.Forms.TabPage();
            this.richTextBoxCredits = new System.Windows.Forms.RichTextBox();
            this.buttonLaunch = new System.Windows.Forms.Button();
            this.labelCustomCommands = new System.Windows.Forms.Label();
            this.textBoxCustomCommands = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.buttonCheckUpdates = new System.Windows.Forms.Button();
            this.timerPulse = new System.Windows.Forms.Timer(this.components);
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxForks = new System.Windows.Forms.ComboBox();
            this.labelFork = new System.Windows.Forms.Label();
            this.tabControlMain.SuspendLayout();
            this.tabPageBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMapNumber)).BeginInit();
            this.tabPageMultiplayer.SuspendLayout();
            this.groupBoxServerOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuplicate)).BeginInit();
            this.groupBoxServerMode.SuspendLayout();
            this.groupBoxMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayers)).BeginInit();
            this.tabPageMods.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPageDMFlags.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPageCredits.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.tabControlMain, 2);
            this.tabControlMain.Controls.Add(this.tabPageBasic);
            this.tabControlMain.Controls.Add(this.tabPageMultiplayer);
            this.tabControlMain.Controls.Add(this.tabPageMods);
            this.tabControlMain.Controls.Add(this.tabPageDMFlags);
            this.tabControlMain.Controls.Add(this.tabPageCredits);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(6, 6);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(6);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(904, 721);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageBasic
            // 
            this.tabPageBasic.Controls.Add(this.comboBoxForks);
            this.tabPageBasic.Controls.Add(this.labelFork);
            this.tabPageBasic.Controls.Add(this.buttonConfigSave);
            this.tabPageBasic.Controls.Add(this.buttonBrowseIWADsPath);
            this.tabPageBasic.Controls.Add(this.textBoxIWADsPath);
            this.tabPageBasic.Controls.Add(this.labelIWADsLocation);
            this.tabPageBasic.Controls.Add(this.buttonConfigRemove);
            this.tabPageBasic.Controls.Add(this.buttonDuplicateConfig);
            this.tabPageBasic.Controls.Add(this.buttonRenameConfig);
            this.tabPageBasic.Controls.Add(this.buttonCreateConfig);
            this.tabPageBasic.Controls.Add(this.comboBoxConfig);
            this.tabPageBasic.Controls.Add(this.labelConfig);
            this.tabPageBasic.Controls.Add(this.checkBoxDRPG);
            this.tabPageBasic.Controls.Add(this.comboBoxBranch);
            this.tabPageBasic.Controls.Add(this.labelBranch);
            this.tabPageBasic.Controls.Add(this.buttonShowCommandLine);
            this.tabPageBasic.Controls.Add(this.textBoxDemo);
            this.tabPageBasic.Controls.Add(this.labelRecordDemo);
            this.tabPageBasic.Controls.Add(this.checkBoxLogging);
            this.tabPageBasic.Controls.Add(this.checkBoxEnableCheats);
            this.tabPageBasic.Controls.Add(this.comboBoxSaveGame);
            this.tabPageBasic.Controls.Add(this.labelSavegame);
            this.tabPageBasic.Controls.Add(this.comboBoxClass);
            this.tabPageBasic.Controls.Add(this.labelPlayerClass);
            this.tabPageBasic.Controls.Add(this.comboBoxIWAD);
            this.tabPageBasic.Controls.Add(this.labelIWAD);
            this.tabPageBasic.Controls.Add(this.buttonBrowseModsPath);
            this.tabPageBasic.Controls.Add(this.textBoxModsPath);
            this.tabPageBasic.Controls.Add(this.labelModsLocation);
            this.tabPageBasic.Controls.Add(this.numericUpDownMapNumber);
            this.tabPageBasic.Controls.Add(this.labelMapNumber);
            this.tabPageBasic.Controls.Add(this.comboBoxDifficulty);
            this.tabPageBasic.Controls.Add(this.labelDifficulty);
            this.tabPageBasic.Controls.Add(this.buttonBrowseDRPGPath);
            this.tabPageBasic.Controls.Add(this.textBoxDRPGPath);
            this.tabPageBasic.Controls.Add(this.labelDoomRPGFolderLocation);
            this.tabPageBasic.Controls.Add(this.buttonBrowsePortPath);
            this.tabPageBasic.Controls.Add(this.textBoxPortPath);
            this.tabPageBasic.Controls.Add(this.labelPortLocation);
            this.tabPageBasic.Location = new System.Drawing.Point(8, 39);
            this.tabPageBasic.Margin = new System.Windows.Forms.Padding(6);
            this.tabPageBasic.Name = "tabPageBasic";
            this.tabPageBasic.Padding = new System.Windows.Forms.Padding(6);
            this.tabPageBasic.Size = new System.Drawing.Size(888, 674);
            this.tabPageBasic.TabIndex = 0;
            this.tabPageBasic.Text = "Basic";
            this.tabPageBasic.UseVisualStyleBackColor = true;
            // 
            // buttonConfigSave
            // 
            this.buttonConfigSave.BackgroundImage = global::DoomRPG.Properties.Resources.Save_16x;
            this.buttonConfigSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonConfigSave.Location = new System.Drawing.Point(362, 533);
            this.buttonConfigSave.Margin = new System.Windows.Forms.Padding(6);
            this.buttonConfigSave.Name = "buttonConfigSave";
            this.buttonConfigSave.Size = new System.Drawing.Size(48, 48);
            this.buttonConfigSave.TabIndex = 38;
            this.toolTipMain.SetToolTip(this.buttonConfigSave, "Save current config");
            this.buttonConfigSave.UseVisualStyleBackColor = true;
            this.buttonConfigSave.Click += new System.EventHandler(this.ButtonConfigSave_Click);
            // 
            // buttonBrowseIWADsPath
            // 
            this.buttonBrowseIWADsPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseIWADsPath.Location = new System.Drawing.Point(740, 183);
            this.buttonBrowseIWADsPath.Margin = new System.Windows.Forms.Padding(6);
            this.buttonBrowseIWADsPath.Name = "buttonBrowseIWADsPath";
            this.buttonBrowseIWADsPath.Size = new System.Drawing.Size(132, 38);
            this.buttonBrowseIWADsPath.TabIndex = 37;
            this.buttonBrowseIWADsPath.Text = "Browse...";
            this.buttonBrowseIWADsPath.UseVisualStyleBackColor = true;
            this.buttonBrowseIWADsPath.Click += new System.EventHandler(this.ButtonBrowseIWADsPath_Click);
            // 
            // textBoxIWADsPath
            // 
            this.textBoxIWADsPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIWADsPath.Location = new System.Drawing.Point(21, 187);
            this.textBoxIWADsPath.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxIWADsPath.Name = "textBoxIWADsPath";
            this.textBoxIWADsPath.Size = new System.Drawing.Size(702, 31);
            this.textBoxIWADsPath.TabIndex = 36;
            this.textBoxIWADsPath.TextChanged += new System.EventHandler(this.TextBoxIWADsPath_TextChanged);
            // 
            // labelIWADsLocation
            // 
            this.labelIWADsLocation.AutoSize = true;
            this.labelIWADsLocation.Location = new System.Drawing.Point(17, 156);
            this.labelIWADsLocation.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelIWADsLocation.Name = "labelIWADsLocation";
            this.labelIWADsLocation.Size = new System.Drawing.Size(221, 25);
            this.labelIWADsLocation.TabIndex = 35;
            this.labelIWADsLocation.Text = "IWAD Folder Location";
            this.labelIWADsLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonConfigRemove
            // 
            this.buttonConfigRemove.BackgroundImage = global::DoomRPG.Properties.Resources.Eraser_16x;
            this.buttonConfigRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonConfigRemove.Location = new System.Drawing.Point(542, 533);
            this.buttonConfigRemove.Margin = new System.Windows.Forms.Padding(6);
            this.buttonConfigRemove.Name = "buttonConfigRemove";
            this.buttonConfigRemove.Size = new System.Drawing.Size(48, 48);
            this.buttonConfigRemove.TabIndex = 34;
            this.toolTipMain.SetToolTip(this.buttonConfigRemove, "Remove selected config");
            this.buttonConfigRemove.UseVisualStyleBackColor = true;
            this.buttonConfigRemove.Click += new System.EventHandler(this.ButtonConfigRemove_Click);
            // 
            // buttonDuplicateConfig
            // 
            this.buttonDuplicateConfig.BackgroundImage = global::DoomRPG.Properties.Resources.Copy_16x;
            this.buttonDuplicateConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDuplicateConfig.Location = new System.Drawing.Point(482, 533);
            this.buttonDuplicateConfig.Margin = new System.Windows.Forms.Padding(6);
            this.buttonDuplicateConfig.Name = "buttonDuplicateConfig";
            this.buttonDuplicateConfig.Size = new System.Drawing.Size(48, 48);
            this.buttonDuplicateConfig.TabIndex = 33;
            this.toolTipMain.SetToolTip(this.buttonDuplicateConfig, "Duplicate selected config");
            this.buttonDuplicateConfig.UseVisualStyleBackColor = true;
            this.buttonDuplicateConfig.Click += new System.EventHandler(this.ButtonDuplicateConfig_Click);
            // 
            // buttonRenameConfig
            // 
            this.buttonRenameConfig.BackgroundImage = global::DoomRPG.Properties.Resources.Pen1_16x;
            this.buttonRenameConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRenameConfig.Location = new System.Drawing.Point(422, 533);
            this.buttonRenameConfig.Margin = new System.Windows.Forms.Padding(6);
            this.buttonRenameConfig.Name = "buttonRenameConfig";
            this.buttonRenameConfig.Size = new System.Drawing.Size(48, 48);
            this.buttonRenameConfig.TabIndex = 32;
            this.toolTipMain.SetToolTip(this.buttonRenameConfig, "Rename selected config");
            this.buttonRenameConfig.UseVisualStyleBackColor = true;
            this.buttonRenameConfig.Click += new System.EventHandler(this.ButtonRenameConfig_Click);
            // 
            // buttonCreateConfig
            // 
            this.buttonCreateConfig.BackgroundImage = global::DoomRPG.Properties.Resources.AddFile_16x;
            this.buttonCreateConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCreateConfig.Location = new System.Drawing.Point(302, 533);
            this.buttonCreateConfig.Margin = new System.Windows.Forms.Padding(6);
            this.buttonCreateConfig.Name = "buttonCreateConfig";
            this.buttonCreateConfig.Size = new System.Drawing.Size(48, 48);
            this.buttonCreateConfig.TabIndex = 31;
            this.toolTipMain.SetToolTip(this.buttonCreateConfig, "Create new config");
            this.buttonCreateConfig.UseVisualStyleBackColor = true;
            this.buttonCreateConfig.Click += new System.EventHandler(this.ButtonCreateConfig_Click);
            // 
            // comboBoxConfig
            // 
            this.comboBoxConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConfig.FormattingEnabled = true;
            this.comboBoxConfig.Location = new System.Drawing.Point(302, 488);
            this.comboBoxConfig.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxConfig.Name = "comboBoxConfig";
            this.comboBoxConfig.Size = new System.Drawing.Size(287, 33);
            this.comboBoxConfig.TabIndex = 30;
            this.comboBoxConfig.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxConfig_SelectionChangeCommitted);
            // 
            // labelConfig
            // 
            this.labelConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelConfig.AutoSize = true;
            this.labelConfig.Location = new System.Drawing.Point(296, 458);
            this.labelConfig.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelConfig.Name = "labelConfig";
            this.labelConfig.Size = new System.Drawing.Size(140, 25);
            this.labelConfig.TabIndex = 29;
            this.labelConfig.Text = "Config preset";
            // 
            // checkBoxDRPG
            // 
            this.checkBoxDRPG.AutoSize = true;
            this.checkBoxDRPG.Checked = true;
            this.checkBoxDRPG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDRPG.Location = new System.Drawing.Point(20, 472);
            this.checkBoxDRPG.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxDRPG.Name = "checkBoxDRPG";
            this.checkBoxDRPG.Size = new System.Drawing.Size(218, 29);
            this.checkBoxDRPG.TabIndex = 28;
            this.checkBoxDRPG.Text = "Enable DoomRPG";
            this.checkBoxDRPG.UseVisualStyleBackColor = true;
            this.checkBoxDRPG.CheckedChanged += new System.EventHandler(this.CheckBoxDRPG_CheckedChanged);
            // 
            // comboBoxBranch
            // 
            this.comboBoxBranch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBranch.Enabled = false;
            this.comboBoxBranch.FormattingEnabled = true;
            this.comboBoxBranch.Location = new System.Drawing.Point(635, 566);
            this.comboBoxBranch.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxBranch.Name = "comboBoxBranch";
            this.comboBoxBranch.Size = new System.Drawing.Size(232, 33);
            this.comboBoxBranch.TabIndex = 27;
            this.comboBoxBranch.SelectedIndexChanged += new System.EventHandler(this.ComboBoxBranch_SelectedIndexChanged);
            // 
            // labelBranch
            // 
            this.labelBranch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBranch.AutoSize = true;
            this.labelBranch.Location = new System.Drawing.Point(629, 536);
            this.labelBranch.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelBranch.Name = "labelBranch";
            this.labelBranch.Size = new System.Drawing.Size(80, 25);
            this.labelBranch.TabIndex = 26;
            this.labelBranch.Text = "Branch";
            // 
            // buttonShowCommandLine
            // 
            this.buttonShowCommandLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowCommandLine.Location = new System.Drawing.Point(12, 618);
            this.buttonShowCommandLine.Margin = new System.Windows.Forms.Padding(6);
            this.buttonShowCommandLine.Name = "buttonShowCommandLine";
            this.buttonShowCommandLine.Size = new System.Drawing.Size(338, 44);
            this.buttonShowCommandLine.TabIndex = 25;
            this.buttonShowCommandLine.Text = "Show Entire Command-Line";
            this.buttonShowCommandLine.UseVisualStyleBackColor = true;
            this.buttonShowCommandLine.Click += new System.EventHandler(this.ButtonShowCommandLine_Click);
            // 
            // textBoxDemo
            // 
            this.textBoxDemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDemo.Location = new System.Drawing.Point(635, 413);
            this.textBoxDemo.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxDemo.Name = "textBoxDemo";
            this.textBoxDemo.Size = new System.Drawing.Size(232, 31);
            this.textBoxDemo.TabIndex = 24;
            // 
            // labelRecordDemo
            // 
            this.labelRecordDemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRecordDemo.AutoSize = true;
            this.labelRecordDemo.Location = new System.Drawing.Point(629, 383);
            this.labelRecordDemo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelRecordDemo.Name = "labelRecordDemo";
            this.labelRecordDemo.Size = new System.Drawing.Size(143, 25);
            this.labelRecordDemo.TabIndex = 23;
            this.labelRecordDemo.Text = "Record Demo";
            // 
            // checkBoxLogging
            // 
            this.checkBoxLogging.AutoSize = true;
            this.checkBoxLogging.Location = new System.Drawing.Point(20, 554);
            this.checkBoxLogging.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxLogging.Name = "checkBoxLogging";
            this.checkBoxLogging.Size = new System.Drawing.Size(259, 29);
            this.checkBoxLogging.TabIndex = 22;
            this.checkBoxLogging.Text = "Enable Logging to File";
            this.checkBoxLogging.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnableCheats
            // 
            this.checkBoxEnableCheats.AutoSize = true;
            this.checkBoxEnableCheats.Location = new System.Drawing.Point(20, 513);
            this.checkBoxEnableCheats.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxEnableCheats.Name = "checkBoxEnableCheats";
            this.checkBoxEnableCheats.Size = new System.Drawing.Size(185, 29);
            this.checkBoxEnableCheats.TabIndex = 21;
            this.checkBoxEnableCheats.Text = "Enable Cheats";
            this.checkBoxEnableCheats.UseVisualStyleBackColor = true;
            // 
            // comboBoxSaveGame
            // 
            this.comboBoxSaveGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSaveGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSaveGame.FormattingEnabled = true;
            this.comboBoxSaveGame.Location = new System.Drawing.Point(303, 413);
            this.comboBoxSaveGame.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxSaveGame.Name = "comboBoxSaveGame";
            this.comboBoxSaveGame.Size = new System.Drawing.Size(286, 33);
            this.comboBoxSaveGame.TabIndex = 20;
            // 
            // labelSavegame
            // 
            this.labelSavegame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSavegame.AutoSize = true;
            this.labelSavegame.Location = new System.Drawing.Point(297, 383);
            this.labelSavegame.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSavegame.Name = "labelSavegame";
            this.labelSavegame.Size = new System.Drawing.Size(114, 25);
            this.labelSavegame.TabIndex = 19;
            this.labelSavegame.Text = "Savegame";
            // 
            // comboBoxClass
            // 
            this.comboBoxClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClass.Enabled = false;
            this.comboBoxClass.FormattingEnabled = true;
            this.comboBoxClass.Location = new System.Drawing.Point(20, 414);
            this.comboBoxClass.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxClass.Name = "comboBoxClass";
            this.comboBoxClass.Size = new System.Drawing.Size(238, 33);
            this.comboBoxClass.TabIndex = 18;
            // 
            // labelPlayerClass
            // 
            this.labelPlayerClass.AutoSize = true;
            this.labelPlayerClass.Location = new System.Drawing.Point(15, 383);
            this.labelPlayerClass.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelPlayerClass.Name = "labelPlayerClass";
            this.labelPlayerClass.Size = new System.Drawing.Size(133, 25);
            this.labelPlayerClass.TabIndex = 17;
            this.labelPlayerClass.Text = "Player Class";
            // 
            // comboBoxIWAD
            // 
            this.comboBoxIWAD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIWAD.FormattingEnabled = true;
            this.comboBoxIWAD.Location = new System.Drawing.Point(20, 335);
            this.comboBoxIWAD.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxIWAD.Name = "comboBoxIWAD";
            this.comboBoxIWAD.Size = new System.Drawing.Size(238, 33);
            this.comboBoxIWAD.TabIndex = 16;
            // 
            // labelIWAD
            // 
            this.labelIWAD.AutoSize = true;
            this.labelIWAD.Location = new System.Drawing.Point(17, 304);
            this.labelIWAD.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelIWAD.Name = "labelIWAD";
            this.labelIWAD.Size = new System.Drawing.Size(128, 25);
            this.labelIWAD.TabIndex = 15;
            this.labelIWAD.Text = "Doom IWAD";
            // 
            // buttonBrowseModsPath
            // 
            this.buttonBrowseModsPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseModsPath.Location = new System.Drawing.Point(740, 256);
            this.buttonBrowseModsPath.Margin = new System.Windows.Forms.Padding(6);
            this.buttonBrowseModsPath.Name = "buttonBrowseModsPath";
            this.buttonBrowseModsPath.Size = new System.Drawing.Size(132, 38);
            this.buttonBrowseModsPath.TabIndex = 14;
            this.buttonBrowseModsPath.Text = "Browse...";
            this.buttonBrowseModsPath.UseVisualStyleBackColor = true;
            this.buttonBrowseModsPath.Click += new System.EventHandler(this.ButtonBrowseModsPath_Click);
            // 
            // textBoxModsPath
            // 
            this.textBoxModsPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxModsPath.Location = new System.Drawing.Point(21, 260);
            this.textBoxModsPath.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxModsPath.Name = "textBoxModsPath";
            this.textBoxModsPath.Size = new System.Drawing.Size(702, 31);
            this.textBoxModsPath.TabIndex = 13;
            this.textBoxModsPath.TextChanged += new System.EventHandler(this.TextBoxModsPath_TextChanged);
            // 
            // labelModsLocation
            // 
            this.labelModsLocation.AutoSize = true;
            this.labelModsLocation.Location = new System.Drawing.Point(17, 229);
            this.labelModsLocation.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelModsLocation.Name = "labelModsLocation";
            this.labelModsLocation.Size = new System.Drawing.Size(273, 25);
            this.labelModsLocation.TabIndex = 12;
            this.labelModsLocation.Text = "WAD/PK3s Folder Location";
            this.labelModsLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDownMapNumber
            // 
            this.numericUpDownMapNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownMapNumber.Location = new System.Drawing.Point(635, 335);
            this.numericUpDownMapNumber.Margin = new System.Windows.Forms.Padding(6);
            this.numericUpDownMapNumber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownMapNumber.Name = "numericUpDownMapNumber";
            this.numericUpDownMapNumber.Size = new System.Drawing.Size(148, 31);
            this.numericUpDownMapNumber.TabIndex = 9;
            this.numericUpDownMapNumber.ValueChanged += new System.EventHandler(this.NumericUpDownMapNumber_ValueChanged);
            // 
            // labelMapNumber
            // 
            this.labelMapNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMapNumber.AutoSize = true;
            this.labelMapNumber.Location = new System.Drawing.Point(629, 304);
            this.labelMapNumber.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelMapNumber.Name = "labelMapNumber";
            this.labelMapNumber.Size = new System.Drawing.Size(135, 25);
            this.labelMapNumber.TabIndex = 8;
            this.labelMapNumber.Text = "Map Number";
            // 
            // comboBoxDifficulty
            // 
            this.comboBoxDifficulty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDifficulty.FormattingEnabled = true;
            this.comboBoxDifficulty.Location = new System.Drawing.Point(303, 335);
            this.comboBoxDifficulty.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxDifficulty.Name = "comboBoxDifficulty";
            this.comboBoxDifficulty.Size = new System.Drawing.Size(286, 33);
            this.comboBoxDifficulty.TabIndex = 7;
            // 
            // labelDifficulty
            // 
            this.labelDifficulty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDifficulty.AutoSize = true;
            this.labelDifficulty.Location = new System.Drawing.Point(297, 304);
            this.labelDifficulty.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelDifficulty.Name = "labelDifficulty";
            this.labelDifficulty.Size = new System.Drawing.Size(94, 25);
            this.labelDifficulty.TabIndex = 6;
            this.labelDifficulty.Text = "Difficulty";
            // 
            // buttonBrowseDRPGPath
            // 
            this.buttonBrowseDRPGPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseDRPGPath.Location = new System.Drawing.Point(740, 108);
            this.buttonBrowseDRPGPath.Margin = new System.Windows.Forms.Padding(6);
            this.buttonBrowseDRPGPath.Name = "buttonBrowseDRPGPath";
            this.buttonBrowseDRPGPath.Size = new System.Drawing.Size(132, 38);
            this.buttonBrowseDRPGPath.TabIndex = 5;
            this.buttonBrowseDRPGPath.Text = "Browse...";
            this.buttonBrowseDRPGPath.UseVisualStyleBackColor = true;
            this.buttonBrowseDRPGPath.Click += new System.EventHandler(this.ButtonBrowseDRPGPath_Click);
            // 
            // textBoxDRPGPath
            // 
            this.textBoxDRPGPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDRPGPath.Location = new System.Drawing.Point(21, 112);
            this.textBoxDRPGPath.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxDRPGPath.Name = "textBoxDRPGPath";
            this.textBoxDRPGPath.Size = new System.Drawing.Size(702, 31);
            this.textBoxDRPGPath.TabIndex = 4;
            this.textBoxDRPGPath.TextChanged += new System.EventHandler(this.TextBoxDRPGPath_TextChanged);
            // 
            // labelDoomRPGFolderLocation
            // 
            this.labelDoomRPGFolderLocation.AutoSize = true;
            this.labelDoomRPGFolderLocation.Location = new System.Drawing.Point(16, 81);
            this.labelDoomRPGFolderLocation.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelDoomRPGFolderLocation.Name = "labelDoomRPGFolderLocation";
            this.labelDoomRPGFolderLocation.Size = new System.Drawing.Size(274, 25);
            this.labelDoomRPGFolderLocation.TabIndex = 3;
            this.labelDoomRPGFolderLocation.Text = "Doom RPG Folder Location";
            this.labelDoomRPGFolderLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonBrowsePortPath
            // 
            this.buttonBrowsePortPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowsePortPath.Location = new System.Drawing.Point(740, 33);
            this.buttonBrowsePortPath.Margin = new System.Windows.Forms.Padding(6);
            this.buttonBrowsePortPath.Name = "buttonBrowsePortPath";
            this.buttonBrowsePortPath.Size = new System.Drawing.Size(132, 38);
            this.buttonBrowsePortPath.TabIndex = 2;
            this.buttonBrowsePortPath.Text = "Browse...";
            this.buttonBrowsePortPath.UseVisualStyleBackColor = true;
            this.buttonBrowsePortPath.Click += new System.EventHandler(this.ButtonBrowsePortPath_Click);
            // 
            // textBoxPortPath
            // 
            this.textBoxPortPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPortPath.Location = new System.Drawing.Point(21, 37);
            this.textBoxPortPath.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxPortPath.Name = "textBoxPortPath";
            this.textBoxPortPath.Size = new System.Drawing.Size(702, 31);
            this.textBoxPortPath.TabIndex = 1;
            this.textBoxPortPath.TextChanged += new System.EventHandler(this.TextBoxPortPath_TextChanged);
            // 
            // labelPortLocation
            // 
            this.labelPortLocation.AutoSize = true;
            this.labelPortLocation.Location = new System.Drawing.Point(16, 6);
            this.labelPortLocation.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelPortLocation.Name = "labelPortLocation";
            this.labelPortLocation.Size = new System.Drawing.Size(185, 25);
            this.labelPortLocation.TabIndex = 0;
            this.labelPortLocation.Text = "GZDoom Location";
            this.labelPortLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageMultiplayer
            // 
            this.tabPageMultiplayer.Controls.Add(this.groupBoxServerOptions);
            this.tabPageMultiplayer.Controls.Add(this.groupBoxServerMode);
            this.tabPageMultiplayer.Controls.Add(this.groupBoxMode);
            this.tabPageMultiplayer.Controls.Add(this.checkBoxMultiplayer);
            this.tabPageMultiplayer.Location = new System.Drawing.Point(8, 39);
            this.tabPageMultiplayer.Margin = new System.Windows.Forms.Padding(6);
            this.tabPageMultiplayer.Name = "tabPageMultiplayer";
            this.tabPageMultiplayer.Padding = new System.Windows.Forms.Padding(6);
            this.tabPageMultiplayer.Size = new System.Drawing.Size(888, 674);
            this.tabPageMultiplayer.TabIndex = 1;
            this.tabPageMultiplayer.Text = "Multiplayer";
            this.tabPageMultiplayer.UseVisualStyleBackColor = true;
            // 
            // groupBoxServerOptions
            // 
            this.groupBoxServerOptions.Controls.Add(this.labelDuplicate);
            this.groupBoxServerOptions.Controls.Add(this.numericUpDownDuplicate);
            this.groupBoxServerOptions.Controls.Add(this.checkBoxExtraTics);
            this.groupBoxServerOptions.Location = new System.Drawing.Point(350, 56);
            this.groupBoxServerOptions.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxServerOptions.Name = "groupBoxServerOptions";
            this.groupBoxServerOptions.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxServerOptions.Size = new System.Drawing.Size(474, 373);
            this.groupBoxServerOptions.TabIndex = 5;
            this.groupBoxServerOptions.TabStop = false;
            this.groupBoxServerOptions.Text = "Server Options";
            // 
            // labelDuplicate
            // 
            this.labelDuplicate.Location = new System.Drawing.Point(12, 79);
            this.labelDuplicate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelDuplicate.Name = "labelDuplicate";
            this.labelDuplicate.Size = new System.Drawing.Size(278, 38);
            this.labelDuplicate.TabIndex = 6;
            this.labelDuplicate.Text = "Server-side tic duplication";
            this.labelDuplicate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTipMain.SetToolTip(this.labelDuplicate, "Causes GZDoom to transmit fewer player movement commands across the network.\r\nFor" +
        " example, -dup 2 would cause GZDoom to send half as many movements as normal.");
            // 
            // numericUpDownDuplicate
            // 
            this.numericUpDownDuplicate.Location = new System.Drawing.Point(302, 84);
            this.numericUpDownDuplicate.Margin = new System.Windows.Forms.Padding(6);
            this.numericUpDownDuplicate.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDownDuplicate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDuplicate.Name = "numericUpDownDuplicate";
            this.numericUpDownDuplicate.Size = new System.Drawing.Size(160, 31);
            this.numericUpDownDuplicate.TabIndex = 6;
            this.toolTipMain.SetToolTip(this.numericUpDownDuplicate, "Causes GZDoom to transmit fewer player movement commands across the network.");
            this.numericUpDownDuplicate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBoxExtraTics
            // 
            this.checkBoxExtraTics.AutoSize = true;
            this.checkBoxExtraTics.Location = new System.Drawing.Point(12, 38);
            this.checkBoxExtraTics.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxExtraTics.Name = "checkBoxExtraTics";
            this.checkBoxExtraTics.Size = new System.Drawing.Size(129, 29);
            this.checkBoxExtraTics.TabIndex = 0;
            this.checkBoxExtraTics.Text = "Extra Tic";
            this.toolTipMain.SetToolTip(this.checkBoxExtraTics, "Causes GZDoom to send a backup copy of every movement command across the network." +
        "");
            this.checkBoxExtraTics.UseVisualStyleBackColor = true;
            // 
            // groupBoxServerMode
            // 
            this.groupBoxServerMode.Controls.Add(this.radioButtonPacketServer);
            this.groupBoxServerMode.Controls.Add(this.radioButtonPeerToPeer);
            this.groupBoxServerMode.Location = new System.Drawing.Point(16, 298);
            this.groupBoxServerMode.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxServerMode.Name = "groupBoxServerMode";
            this.groupBoxServerMode.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxServerMode.Size = new System.Drawing.Size(322, 131);
            this.groupBoxServerMode.TabIndex = 4;
            this.groupBoxServerMode.TabStop = false;
            this.groupBoxServerMode.Text = "Server Mode";
            // 
            // radioButtonPacketServer
            // 
            this.radioButtonPacketServer.AutoSize = true;
            this.radioButtonPacketServer.Location = new System.Drawing.Point(12, 81);
            this.radioButtonPacketServer.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonPacketServer.Name = "radioButtonPacketServer";
            this.radioButtonPacketServer.Size = new System.Drawing.Size(178, 29);
            this.radioButtonPacketServer.TabIndex = 1;
            this.radioButtonPacketServer.TabStop = true;
            this.radioButtonPacketServer.Text = "Packet Server";
            this.radioButtonPacketServer.UseVisualStyleBackColor = true;
            // 
            // radioButtonPeerToPeer
            // 
            this.radioButtonPeerToPeer.AutoSize = true;
            this.radioButtonPeerToPeer.Location = new System.Drawing.Point(12, 37);
            this.radioButtonPeerToPeer.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonPeerToPeer.Name = "radioButtonPeerToPeer";
            this.radioButtonPeerToPeer.Size = new System.Drawing.Size(165, 29);
            this.radioButtonPeerToPeer.TabIndex = 0;
            this.radioButtonPeerToPeer.TabStop = true;
            this.radioButtonPeerToPeer.Text = "Peer-to-Peer";
            this.radioButtonPeerToPeer.UseVisualStyleBackColor = true;
            // 
            // groupBoxMode
            // 
            this.groupBoxMode.Controls.Add(this.numericUpDownPlayers);
            this.groupBoxMode.Controls.Add(this.labelPlayers);
            this.groupBoxMode.Controls.Add(this.textBoxHostname);
            this.groupBoxMode.Controls.Add(this.radioButtonHosting);
            this.groupBoxMode.Controls.Add(this.radioButtonJoining);
            this.groupBoxMode.Location = new System.Drawing.Point(16, 56);
            this.groupBoxMode.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxMode.Name = "groupBoxMode";
            this.groupBoxMode.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxMode.Size = new System.Drawing.Size(322, 231);
            this.groupBoxMode.TabIndex = 3;
            this.groupBoxMode.TabStop = false;
            this.groupBoxMode.Text = "Mode";
            // 
            // numericUpDownPlayers
            // 
            this.numericUpDownPlayers.Location = new System.Drawing.Point(170, 84);
            this.numericUpDownPlayers.Margin = new System.Windows.Forms.Padding(6);
            this.numericUpDownPlayers.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownPlayers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPlayers.Name = "numericUpDownPlayers";
            this.numericUpDownPlayers.Size = new System.Drawing.Size(140, 31);
            this.numericUpDownPlayers.TabIndex = 8;
            this.numericUpDownPlayers.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // labelPlayers
            // 
            this.labelPlayers.Location = new System.Drawing.Point(12, 79);
            this.labelPlayers.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(146, 38);
            this.labelPlayers.TabIndex = 7;
            this.labelPlayers.Text = "Players";
            this.labelPlayers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxHostname
            // 
            this.textBoxHostname.Location = new System.Drawing.Point(14, 181);
            this.textBoxHostname.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxHostname.Name = "textBoxHostname";
            this.textBoxHostname.Size = new System.Drawing.Size(292, 31);
            this.textBoxHostname.TabIndex = 6;
            // 
            // radioButtonHosting
            // 
            this.radioButtonHosting.AutoSize = true;
            this.radioButtonHosting.Location = new System.Drawing.Point(12, 37);
            this.radioButtonHosting.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonHosting.Name = "radioButtonHosting";
            this.radioButtonHosting.Size = new System.Drawing.Size(116, 29);
            this.radioButtonHosting.TabIndex = 1;
            this.radioButtonHosting.TabStop = true;
            this.radioButtonHosting.Text = "Hosting";
            this.radioButtonHosting.UseVisualStyleBackColor = true;
            this.radioButtonHosting.CheckedChanged += new System.EventHandler(this.RadioButtonHosting_CheckedChanged);
            // 
            // radioButtonJoining
            // 
            this.radioButtonJoining.AutoSize = true;
            this.radioButtonJoining.Location = new System.Drawing.Point(12, 137);
            this.radioButtonJoining.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonJoining.Name = "radioButtonJoining";
            this.radioButtonJoining.Size = new System.Drawing.Size(112, 29);
            this.radioButtonJoining.TabIndex = 2;
            this.radioButtonJoining.TabStop = true;
            this.radioButtonJoining.Text = "Joining";
            this.radioButtonJoining.UseVisualStyleBackColor = true;
            this.radioButtonJoining.CheckedChanged += new System.EventHandler(this.RadioButtonJoining_CheckedChanged);
            // 
            // checkBoxMultiplayer
            // 
            this.checkBoxMultiplayer.AutoSize = true;
            this.checkBoxMultiplayer.Location = new System.Drawing.Point(16, 12);
            this.checkBoxMultiplayer.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxMultiplayer.Name = "checkBoxMultiplayer";
            this.checkBoxMultiplayer.Size = new System.Drawing.Size(212, 29);
            this.checkBoxMultiplayer.TabIndex = 0;
            this.checkBoxMultiplayer.Text = "Multiplayer Game";
            this.checkBoxMultiplayer.UseVisualStyleBackColor = true;
            this.checkBoxMultiplayer.CheckedChanged += new System.EventHandler(this.CheckBoxMultiplayer_CheckedChanged);
            // 
            // tabPageMods
            // 
            this.tabPageMods.Controls.Add(this.tableLayoutPanel2);
            this.tabPageMods.Location = new System.Drawing.Point(8, 39);
            this.tabPageMods.Margin = new System.Windows.Forms.Padding(6);
            this.tabPageMods.Name = "tabPageMods";
            this.tabPageMods.Size = new System.Drawing.Size(888, 674);
            this.tabPageMods.TabIndex = 3;
            this.tabPageMods.Text = "Mods";
            this.tabPageMods.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.listViewLoadOrder, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelLoadOrder, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonRefresh, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelMods, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.treeViewMods, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(888, 674);
            this.tableLayoutPanel2.TabIndex = 30;
            // 
            // listViewLoadOrder
            // 
            this.listViewLoadOrder.AllowDrop = true;
            this.listViewLoadOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderModName});
            this.listViewLoadOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLoadOrder.GridLines = true;
            this.listViewLoadOrder.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewLoadOrder.HideSelection = false;
            this.listViewLoadOrder.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem16,
            listViewItem17,
            listViewItem18,
            listViewItem19,
            listViewItem20});
            this.listViewLoadOrder.LabelWrap = false;
            this.listViewLoadOrder.Location = new System.Drawing.Point(447, 28);
            this.listViewLoadOrder.MultiSelect = false;
            this.listViewLoadOrder.Name = "listViewLoadOrder";
            this.listViewLoadOrder.ShowGroups = false;
            this.listViewLoadOrder.Size = new System.Drawing.Size(438, 575);
            this.listViewLoadOrder.TabIndex = 32;
            this.listViewLoadOrder.UseCompatibleStateImageBehavior = false;
            this.listViewLoadOrder.View = System.Windows.Forms.View.Details;
            this.listViewLoadOrder.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ListViewLoadOrder_ItemDrag);
            this.listViewLoadOrder.SizeChanged += new System.EventHandler(this.ListViewLoadOrder_SizeChanged);
            this.listViewLoadOrder.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListViewLoadOrder_DragDrop);
            this.listViewLoadOrder.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListViewLoadOrder_DragEnter);
            this.listViewLoadOrder.DragOver += new System.Windows.Forms.DragEventHandler(this.ListViewLoadOrder_DragOver);
            this.listViewLoadOrder.DragLeave += new System.EventHandler(this.ListViewLoadOrder_DragLeave);
            // 
            // columnHeaderModName
            // 
            this.columnHeaderModName.Text = "Mod Name";
            this.columnHeaderModName.Width = 438;
            // 
            // labelLoadOrder
            // 
            this.labelLoadOrder.AutoSize = true;
            this.labelLoadOrder.Location = new System.Drawing.Point(450, 0);
            this.labelLoadOrder.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelLoadOrder.Name = "labelLoadOrder";
            this.labelLoadOrder.Size = new System.Drawing.Size(120, 25);
            this.labelLoadOrder.TabIndex = 31;
            this.labelLoadOrder.Text = "Load Order";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.buttonRefresh, 2);
            this.buttonRefresh.Location = new System.Drawing.Point(6, 612);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(6);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(876, 56);
            this.buttonRefresh.TabIndex = 21;
            this.buttonRefresh.Text = "Reload Mods";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // labelMods
            // 
            this.labelMods.AutoSize = true;
            this.labelMods.Location = new System.Drawing.Point(6, 0);
            this.labelMods.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelMods.Name = "labelMods";
            this.labelMods.Size = new System.Drawing.Size(159, 25);
            this.labelMods.TabIndex = 19;
            this.labelMods.Text = "WAD/PK3 Files";
            // 
            // treeViewMods
            // 
            this.treeViewMods.CheckBoxes = true;
            this.treeViewMods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewMods.Location = new System.Drawing.Point(3, 28);
            this.treeViewMods.Name = "treeViewMods";
            this.treeViewMods.Size = new System.Drawing.Size(438, 575);
            this.treeViewMods.TabIndex = 30;
            this.treeViewMods.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewMods_AfterCheck);
            // 
            // tabPageDMFlags
            // 
            this.tabPageDMFlags.Controls.Add(this.tableLayoutPanel1);
            this.tabPageDMFlags.Location = new System.Drawing.Point(8, 39);
            this.tabPageDMFlags.Margin = new System.Windows.Forms.Padding(6);
            this.tabPageDMFlags.Name = "tabPageDMFlags";
            this.tabPageDMFlags.Size = new System.Drawing.Size(888, 674);
            this.tabPageDMFlags.TabIndex = 4;
            this.tabPageDMFlags.Text = "Gameplay options";
            this.tabPageDMFlags.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.listViewDMFlags2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxDMFlags2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxDMFlags, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listViewDMFlags, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(888, 674);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // listViewDMFlags2
            // 
            this.listViewDMFlags2.CheckBoxes = true;
            this.listViewDMFlags2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listViewDMFlags2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewDMFlags2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewDMFlags2.HideSelection = false;
            this.listViewDMFlags2.Location = new System.Drawing.Point(447, 44);
            this.listViewDMFlags2.Name = "listViewDMFlags2";
            this.listViewDMFlags2.ShowItemToolTips = true;
            this.listViewDMFlags2.Size = new System.Drawing.Size(438, 627);
            this.listViewDMFlags2.TabIndex = 25;
            this.listViewDMFlags2.UseCompatibleStateImageBehavior = false;
            this.listViewDMFlags2.View = System.Windows.Forms.View.Details;
            // 
            // checkBoxDMFlags2
            // 
            this.checkBoxDMFlags2.AutoSize = true;
            this.checkBoxDMFlags2.Location = new System.Drawing.Point(450, 6);
            this.checkBoxDMFlags2.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxDMFlags2.Name = "checkBoxDMFlags2";
            this.checkBoxDMFlags2.Size = new System.Drawing.Size(215, 29);
            this.checkBoxDMFlags2.TabIndex = 23;
            this.checkBoxDMFlags2.Text = "Enable DMFlags2";
            this.checkBoxDMFlags2.UseVisualStyleBackColor = true;
            // 
            // checkBoxDMFlags
            // 
            this.checkBoxDMFlags.AutoSize = true;
            this.checkBoxDMFlags.Location = new System.Drawing.Point(6, 6);
            this.checkBoxDMFlags.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxDMFlags.Name = "checkBoxDMFlags";
            this.checkBoxDMFlags.Size = new System.Drawing.Size(203, 29);
            this.checkBoxDMFlags.TabIndex = 22;
            this.checkBoxDMFlags.Text = "Enable DMFlags";
            this.checkBoxDMFlags.UseVisualStyleBackColor = true;
            // 
            // listViewDMFlags
            // 
            this.listViewDMFlags.CheckBoxes = true;
            this.listViewDMFlags.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewDMFlags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewDMFlags.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewDMFlags.HideSelection = false;
            this.listViewDMFlags.LabelWrap = false;
            this.listViewDMFlags.Location = new System.Drawing.Point(3, 44);
            this.listViewDMFlags.Name = "listViewDMFlags";
            this.listViewDMFlags.ShowItemToolTips = true;
            this.listViewDMFlags.Size = new System.Drawing.Size(438, 627);
            this.listViewDMFlags.TabIndex = 24;
            this.listViewDMFlags.UseCompatibleStateImageBehavior = false;
            this.listViewDMFlags.View = System.Windows.Forms.View.Details;
            // 
            // tabPageCredits
            // 
            this.tabPageCredits.Controls.Add(this.richTextBoxCredits);
            this.tabPageCredits.Location = new System.Drawing.Point(8, 39);
            this.tabPageCredits.Margin = new System.Windows.Forms.Padding(6);
            this.tabPageCredits.Name = "tabPageCredits";
            this.tabPageCredits.Size = new System.Drawing.Size(888, 674);
            this.tabPageCredits.TabIndex = 2;
            this.tabPageCredits.Text = "Credits";
            this.tabPageCredits.UseVisualStyleBackColor = true;
            // 
            // richTextBoxCredits
            // 
            this.richTextBoxCredits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxCredits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxCredits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxCredits.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxCredits.Margin = new System.Windows.Forms.Padding(6);
            this.richTextBoxCredits.Name = "richTextBoxCredits";
            this.richTextBoxCredits.ReadOnly = true;
            this.richTextBoxCredits.Size = new System.Drawing.Size(888, 674);
            this.richTextBoxCredits.TabIndex = 0;
            this.richTextBoxCredits.Text = "";
            this.richTextBoxCredits.TextChanged += new System.EventHandler(this.RichTextBoxCredits_TextChanged);
            // 
            // buttonLaunch
            // 
            this.buttonLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLaunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLaunch.Location = new System.Drawing.Point(464, 809);
            this.buttonLaunch.Margin = new System.Windows.Forms.Padding(6);
            this.buttonLaunch.Name = "buttonLaunch";
            this.buttonLaunch.Size = new System.Drawing.Size(446, 67);
            this.buttonLaunch.TabIndex = 6;
            this.buttonLaunch.Text = "Launch Doom RPG";
            this.buttonLaunch.UseVisualStyleBackColor = true;
            this.buttonLaunch.Click += new System.EventHandler(this.ButtonLaunch_Click);
            // 
            // labelCustomCommands
            // 
            this.labelCustomCommands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.labelCustomCommands, 2);
            this.labelCustomCommands.Location = new System.Drawing.Point(6, 733);
            this.labelCustomCommands.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelCustomCommands.Name = "labelCustomCommands";
            this.labelCustomCommands.Size = new System.Drawing.Size(904, 27);
            this.labelCustomCommands.TabIndex = 7;
            this.labelCustomCommands.Text = "Custom Commands";
            this.labelCustomCommands.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxCustomCommands
            // 
            this.textBoxCustomCommands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.textBoxCustomCommands, 2);
            this.textBoxCustomCommands.Location = new System.Drawing.Point(6, 766);
            this.textBoxCustomCommands.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxCustomCommands.Name = "textBoxCustomCommands";
            this.textBoxCustomCommands.Size = new System.Drawing.Size(904, 31);
            this.textBoxCustomCommands.TabIndex = 8;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
            this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip.Location = new System.Drawing.Point(0, 882);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip.Size = new System.Drawing.Size(916, 42);
            this.statusStrip.TabIndex = 9;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(79, 32);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.Text = "Ready";
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar.Margin = new System.Windows.Forms.Padding(1, 3, 0, 3);
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(200, 36);
            this.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // buttonCheckUpdates
            // 
            this.buttonCheckUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCheckUpdates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCheckUpdates.Location = new System.Drawing.Point(6, 809);
            this.buttonCheckUpdates.Margin = new System.Windows.Forms.Padding(6);
            this.buttonCheckUpdates.Name = "buttonCheckUpdates";
            this.buttonCheckUpdates.Size = new System.Drawing.Size(446, 67);
            this.buttonCheckUpdates.TabIndex = 10;
            this.buttonCheckUpdates.Text = "Check for Updates";
            this.buttonCheckUpdates.UseVisualStyleBackColor = true;
            this.buttonCheckUpdates.Click += new System.EventHandler(this.ButtonCheckUpdates_Click);
            // 
            // timerPulse
            // 
            this.timerPulse.Enabled = true;
            this.timerPulse.Interval = 10;
            this.timerPulse.Tick += new System.EventHandler(this.TimerPulse_Tick);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tabControlMain, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelCustomCommands, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBoxCustomCommands, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.buttonCheckUpdates, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.buttonLaunch, 1, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(916, 882);
            this.tableLayoutPanel3.TabIndex = 11;
            // 
            // comboBoxForks
            // 
            this.comboBoxForks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxForks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxForks.FormattingEnabled = true;
            this.comboBoxForks.Location = new System.Drawing.Point(635, 488);
            this.comboBoxForks.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxForks.Name = "comboBoxForks";
            this.comboBoxForks.Size = new System.Drawing.Size(232, 33);
            this.comboBoxForks.TabIndex = 40;
            this.comboBoxForks.SelectedIndexChanged += new System.EventHandler(this.ComboBoxForks_SelectedIndexChanged);
            // 
            // labelFork
            // 
            this.labelFork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFork.AutoSize = true;
            this.labelFork.Location = new System.Drawing.Point(629, 458);
            this.labelFork.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelFork.Name = "labelFork";
            this.labelFork.Size = new System.Drawing.Size(55, 25);
            this.labelFork.TabIndex = 39;
            this.labelFork.Text = "Fork";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 924);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(882, 995);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doom RPG SE Launcher";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageBasic.ResumeLayout(false);
            this.tabPageBasic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMapNumber)).EndInit();
            this.tabPageMultiplayer.ResumeLayout(false);
            this.tabPageMultiplayer.PerformLayout();
            this.groupBoxServerOptions.ResumeLayout(false);
            this.groupBoxServerOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuplicate)).EndInit();
            this.groupBoxServerMode.ResumeLayout(false);
            this.groupBoxServerMode.PerformLayout();
            this.groupBoxMode.ResumeLayout(false);
            this.groupBoxMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayers)).EndInit();
            this.tabPageMods.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPageDMFlags.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPageCredits.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageBasic;
        private System.Windows.Forms.TabPage tabPageMultiplayer;
        private System.Windows.Forms.Label labelPortLocation;
        private System.Windows.Forms.Button buttonBrowsePortPath;
        private System.Windows.Forms.TextBox textBoxPortPath;
        private System.Windows.Forms.Button buttonBrowseDRPGPath;
        private System.Windows.Forms.TextBox textBoxDRPGPath;
        private System.Windows.Forms.Label labelDoomRPGFolderLocation;
        private System.Windows.Forms.Button buttonLaunch;
        private System.Windows.Forms.ComboBox comboBoxDifficulty;
        private System.Windows.Forms.Label labelDifficulty;
        private System.Windows.Forms.NumericUpDown numericUpDownMapNumber;
        private System.Windows.Forms.Label labelMapNumber;
        private System.Windows.Forms.CheckBox checkBoxMultiplayer;
        private System.Windows.Forms.RadioButton radioButtonJoining;
        private System.Windows.Forms.RadioButton radioButtonHosting;
        private System.Windows.Forms.GroupBox groupBoxServerMode;
        private System.Windows.Forms.RadioButton radioButtonPacketServer;
        private System.Windows.Forms.RadioButton radioButtonPeerToPeer;
        private System.Windows.Forms.GroupBox groupBoxMode;
        private System.Windows.Forms.GroupBox groupBoxServerOptions;
        private System.Windows.Forms.Label labelDuplicate;
        private System.Windows.Forms.NumericUpDown numericUpDownDuplicate;
        private System.Windows.Forms.CheckBox checkBoxExtraTics;
        private System.Windows.Forms.TextBox textBoxHostname;
        private System.Windows.Forms.NumericUpDown numericUpDownPlayers;
        private System.Windows.Forms.Label labelPlayers;
        private System.Windows.Forms.Button buttonBrowseModsPath;
        private System.Windows.Forms.TextBox textBoxModsPath;
        private System.Windows.Forms.Label labelModsLocation;
        private System.Windows.Forms.Label labelCustomCommands;
        private System.Windows.Forms.TextBox textBoxCustomCommands;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TabPage tabPageCredits;
        private System.Windows.Forms.RichTextBox richTextBoxCredits;
        private System.Windows.Forms.Button buttonCheckUpdates;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.TabPage tabPageMods;
        private System.Windows.Forms.Label labelMods;
        private System.Windows.Forms.ComboBox comboBoxIWAD;
        private System.Windows.Forms.Label labelIWAD;
        private System.Windows.Forms.ComboBox comboBoxClass;
        private System.Windows.Forms.Label labelPlayerClass;
        private System.Windows.Forms.ComboBox comboBoxSaveGame;
        private System.Windows.Forms.Label labelSavegame;
        private System.Windows.Forms.CheckBox checkBoxLogging;
        private System.Windows.Forms.CheckBox checkBoxEnableCheats;
        private System.Windows.Forms.TextBox textBoxDemo;
        private System.Windows.Forms.Label labelRecordDemo;
        private System.Windows.Forms.Button buttonShowCommandLine;
        private System.Windows.Forms.ComboBox comboBoxBranch;
        private System.Windows.Forms.Label labelBranch;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Timer timerPulse;
        private System.Windows.Forms.ToolTip toolTipMain;
        private System.Windows.Forms.TabPage tabPageDMFlags;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listViewDMFlags2;
        private System.Windows.Forms.CheckBox checkBoxDMFlags2;
        private System.Windows.Forms.CheckBox checkBoxDMFlags;
        private System.Windows.Forms.ListView listViewDMFlags;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.CheckBox checkBoxDRPG;
        private System.Windows.Forms.Button buttonCreateConfig;
        private System.Windows.Forms.ComboBox comboBoxConfig;
        private System.Windows.Forms.Label labelConfig;
        private System.Windows.Forms.Button buttonConfigRemove;
        private System.Windows.Forms.Button buttonDuplicateConfig;
        private System.Windows.Forms.Button buttonRenameConfig;
        private System.Windows.Forms.Button buttonBrowseIWADsPath;
        private System.Windows.Forms.TextBox textBoxIWADsPath;
        private System.Windows.Forms.Label labelIWADsLocation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button buttonConfigSave;
        private System.Windows.Forms.Label labelLoadOrder;
        private System.Windows.Forms.TreeView treeViewMods;
        private System.Windows.Forms.ListView listViewLoadOrder;
        private System.Windows.Forms.ColumnHeader columnHeaderModName;
        private System.Windows.Forms.ComboBox comboBoxForks;
        private System.Windows.Forms.Label labelFork;
    }
}

