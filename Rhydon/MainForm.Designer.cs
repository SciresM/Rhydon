namespace Rhydon
{
    partial class MainForm
    {

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu_File = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_ExportSAV = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Modify = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_ModifyDex = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_UseOldSprites = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_JapaneseMode = new System.Windows.Forms.ToolStripMenuItem();
            this.Tab_Main = new System.Windows.Forms.TabPage();
            this.GB_CurrentMoves = new System.Windows.Forms.GroupBox();
            this.TB_PP4 = new System.Windows.Forms.MaskedTextBox();
            this.TB_PP3 = new System.Windows.Forms.MaskedTextBox();
            this.TB_PP2 = new System.Windows.Forms.MaskedTextBox();
            this.TB_PP1 = new System.Windows.Forms.MaskedTextBox();
            this.Label_CurPP = new System.Windows.Forms.Label();
            this.Label_PPups = new System.Windows.Forms.Label();
            this.CB_PPu4 = new System.Windows.Forms.ComboBox();
            this.CB_PPu3 = new System.Windows.Forms.ComboBox();
            this.CB_PPu2 = new System.Windows.Forms.ComboBox();
            this.CB_Move4 = new System.Windows.Forms.ComboBox();
            this.CB_PPu1 = new System.Windows.Forms.ComboBox();
            this.CB_Move3 = new System.Windows.Forms.ComboBox();
            this.CB_Move2 = new System.Windows.Forms.ComboBox();
            this.CB_Move1 = new System.Windows.Forms.ComboBox();
            this.Label_Nickname = new System.Windows.Forms.Label();
            this.TB_Nickname = new System.Windows.Forms.TextBox();
            this.TB_Level = new System.Windows.Forms.MaskedTextBox();
            this.TB_EXP = new System.Windows.Forms.MaskedTextBox();
            this.Label_CurLevel = new System.Windows.Forms.Label();
            this.CB_Species = new System.Windows.Forms.ComboBox();
            this.Label_EXP = new System.Windows.Forms.Label();
            this.Label_Species = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.GB_Stats = new System.Windows.Forms.GroupBox();
            this.Stat_SPD = new System.Windows.Forms.MaskedTextBox();
            this.Stat_SPC = new System.Windows.Forms.MaskedTextBox();
            this.Stat_DEF = new System.Windows.Forms.MaskedTextBox();
            this.Stat_ATK = new System.Windows.Forms.MaskedTextBox();
            this.Stat_HP = new System.Windows.Forms.MaskedTextBox();
            this.TB_SPDDV = new System.Windows.Forms.MaskedTextBox();
            this.TB_SPCDV = new System.Windows.Forms.MaskedTextBox();
            this.TB_DEFDV = new System.Windows.Forms.MaskedTextBox();
            this.TB_ATKDV = new System.Windows.Forms.MaskedTextBox();
            this.TB_HPDV = new System.Windows.Forms.MaskedTextBox();
            this.TB_ATKSTATEXP = new System.Windows.Forms.MaskedTextBox();
            this.TB_DEFSTATEXP = new System.Windows.Forms.MaskedTextBox();
            this.TB_SPDSTATEXP = new System.Windows.Forms.MaskedTextBox();
            this.TB_SPCSTATEXP = new System.Windows.Forms.MaskedTextBox();
            this.TB_HPSTATEXP = new System.Windows.Forms.MaskedTextBox();
            this.Label_Stats = new System.Windows.Forms.Label();
            this.Label_EVs = new System.Windows.Forms.Label();
            this.Label_DVs = new System.Windows.Forms.Label();
            this.Label_SPD = new System.Windows.Forms.Label();
            this.Label_SPC = new System.Windows.Forms.Label();
            this.Label_DEF = new System.Windows.Forms.Label();
            this.Label_ATK = new System.Windows.Forms.Label();
            this.Label_HP = new System.Windows.Forms.Label();
            this.GB_OT = new System.Windows.Forms.GroupBox();
            this.TB_OT = new System.Windows.Forms.TextBox();
            this.TB_TID = new System.Windows.Forms.MaskedTextBox();
            this.Label_OT = new System.Windows.Forms.Label();
            this.Label_TID = new System.Windows.Forms.Label();
            this.mnuVSD = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSet = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tabBoxMulti = new System.Windows.Forms.TabControl();
            this.Tab_Trainer = new System.Windows.Forms.TabPage();
            this.GB_TimePlayed = new System.Windows.Forms.GroupBox();
            this.MT_Seconds = new System.Windows.Forms.MaskedTextBox();
            this.MT_Hours = new System.Windows.Forms.MaskedTextBox();
            this.L_Seconds = new System.Windows.Forms.Label();
            this.L_Hours = new System.Windows.Forms.Label();
            this.MT_Minutes = new System.Windows.Forms.MaskedTextBox();
            this.L_Minutes = new System.Windows.Forms.Label();
            this.TB_PikaFriend = new System.Windows.Forms.MaskedTextBox();
            this.Label_PikaFriend = new System.Windows.Forms.Label();
            this.TB_Coins = new System.Windows.Forms.MaskedTextBox();
            this.Label_Coins = new System.Windows.Forms.Label();
            this.TB_Money = new System.Windows.Forms.MaskedTextBox();
            this.Label_Money = new System.Windows.Forms.Label();
            this.CLB_Badges = new System.Windows.Forms.CheckedListBox();
            this.TB_Rival = new System.Windows.Forms.TextBox();
            this.Label_Rival = new System.Windows.Forms.Label();
            this.TB_SaveName = new System.Windows.Forms.TextBox();
            this.Label_SaveName = new System.Windows.Forms.Label();
            this.Tab_BoxDaycare = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.B_BoxRight = new System.Windows.Forms.Button();
            this.B_BoxLeft = new System.Windows.Forms.Button();
            this.CB_BoxSelect = new System.Windows.Forms.ComboBox();
            this.Tab_PartyMisc = new System.Windows.Forms.TabPage();
            this.B_Options = new System.Windows.Forms.Button();
            this.B_Pokedex = new System.Windows.Forms.Button();
            this.B_Inventory = new System.Windows.Forms.Button();
            this.L_Party = new System.Windows.Forms.Label();
            this.L_Save = new System.Windows.Forms.Label();
            this.PB_DragOut = new System.Windows.Forms.PictureBox();
            this.TB_SaveTID = new System.Windows.Forms.MaskedTextBox();
            this.LBL_SaveTID = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.Tab_Main.SuspendLayout();
            this.GB_CurrentMoves.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.GB_Stats.SuspendLayout();
            this.GB_OT.SuspendLayout();
            this.mnuVSD.SuspendLayout();
            this.tabBoxMulti.SuspendLayout();
            this.Tab_Trainer.SuspendLayout();
            this.GB_TimePlayed.SuspendLayout();
            this.Tab_BoxDaycare.SuspendLayout();
            this.Tab_PartyMisc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_DragOut)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_File,
            this.Menu_Options});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(514, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu_File
            // 
            this.Menu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Open,
            this.Menu_Save,
            this.Menu_ExportSAV,
            this.Menu_Exit});
            this.Menu_File.Name = "Menu_File";
            this.Menu_File.Size = new System.Drawing.Size(37, 20);
            this.Menu_File.Text = "File";
            // 
            // Menu_Open
            // 
            this.Menu_Open.Name = "Menu_Open";
            this.Menu_Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.Menu_Open.ShowShortcutKeys = false;
            this.Menu_Open.Size = new System.Drawing.Size(139, 22);
            this.Menu_Open.Text = "&Open...";
            this.Menu_Open.Click += new System.EventHandler(this.mainMenuOpen);
            // 
            // Menu_Save
            // 
            this.Menu_Save.Name = "Menu_Save";
            this.Menu_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.Menu_Save.ShowShortcutKeys = false;
            this.Menu_Save.Size = new System.Drawing.Size(139, 22);
            this.Menu_Save.Text = "&Save PK1...";
            this.Menu_Save.Click += new System.EventHandler(this.mainMenuSave);
            // 
            // Menu_ExportSAV
            // 
            this.Menu_ExportSAV.Enabled = false;
            this.Menu_ExportSAV.Name = "Menu_ExportSAV";
            this.Menu_ExportSAV.Size = new System.Drawing.Size(139, 22);
            this.Menu_ExportSAV.Text = "&Export SAV...";
            this.Menu_ExportSAV.Click += new System.EventHandler(this.clickExportSav);
            // 
            // Menu_Exit
            // 
            this.Menu_Exit.Name = "Menu_Exit";
            this.Menu_Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.Menu_Exit.ShowShortcutKeys = false;
            this.Menu_Exit.Size = new System.Drawing.Size(139, 22);
            this.Menu_Exit.Text = "&Quit";
            this.Menu_Exit.Click += new System.EventHandler(this.mainMenuClose);
            // 
            // Menu_Options
            // 
            this.Menu_Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Modify,
            this.Menu_UseOldSprites,
            this.Menu_JapaneseMode});
            this.Menu_Options.Name = "Menu_Options";
            this.Menu_Options.Size = new System.Drawing.Size(61, 20);
            this.Menu_Options.Text = "Options";
            // 
            // Menu_Modify
            // 
            this.Menu_Modify.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_ModifyDex});
            this.Menu_Modify.Name = "Menu_Modify";
            this.Menu_Modify.Size = new System.Drawing.Size(194, 22);
            this.Menu_Modify.Text = "Set to SAV";
            // 
            // Menu_ModifyDex
            // 
            this.Menu_ModifyDex.Checked = true;
            this.Menu_ModifyDex.CheckOnClick = true;
            this.Menu_ModifyDex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Menu_ModifyDex.Name = "Menu_ModifyDex";
            this.Menu_ModifyDex.Size = new System.Drawing.Size(159, 22);
            this.Menu_ModifyDex.Text = "Modify Pokédex";
            this.Menu_ModifyDex.Click += new System.EventHandler(this.toggleModifyDex);
            // 
            // Menu_UseOldSprites
            // 
            this.Menu_UseOldSprites.Name = "Menu_UseOldSprites";
            this.Menu_UseOldSprites.Size = new System.Drawing.Size(194, 22);
            this.Menu_UseOldSprites.Text = "Use old sprites";
            this.Menu_UseOldSprites.Click += new System.EventHandler(this.toggleUseOldSprites);
            // 
            // Menu_JapaneseMode
            // 
            this.Menu_JapaneseMode.Name = "Menu_JapaneseMode";
            this.Menu_JapaneseMode.Size = new System.Drawing.Size(194, 22);
            this.Menu_JapaneseMode.Text = "Toggle Japanese Mode";
            this.Menu_JapaneseMode.Click += new System.EventHandler(this.toggleJapaneseMode);
            // 
            // Tab_Main
            // 
            this.Tab_Main.AllowDrop = true;
            this.Tab_Main.Controls.Add(this.GB_CurrentMoves);
            this.Tab_Main.Controls.Add(this.Label_Nickname);
            this.Tab_Main.Controls.Add(this.TB_Nickname);
            this.Tab_Main.Controls.Add(this.TB_Level);
            this.Tab_Main.Controls.Add(this.TB_EXP);
            this.Tab_Main.Controls.Add(this.Label_CurLevel);
            this.Tab_Main.Controls.Add(this.CB_Species);
            this.Tab_Main.Controls.Add(this.Label_EXP);
            this.Tab_Main.Controls.Add(this.Label_Species);
            this.Tab_Main.Location = new System.Drawing.Point(4, 22);
            this.Tab_Main.Name = "Tab_Main";
            this.Tab_Main.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Main.Size = new System.Drawing.Size(242, 259);
            this.Tab_Main.TabIndex = 0;
            this.Tab_Main.Text = "Main/Moves";
            this.Tab_Main.UseVisualStyleBackColor = true;
            // 
            // GB_CurrentMoves
            // 
            this.GB_CurrentMoves.Controls.Add(this.TB_PP4);
            this.GB_CurrentMoves.Controls.Add(this.TB_PP3);
            this.GB_CurrentMoves.Controls.Add(this.TB_PP2);
            this.GB_CurrentMoves.Controls.Add(this.TB_PP1);
            this.GB_CurrentMoves.Controls.Add(this.Label_CurPP);
            this.GB_CurrentMoves.Controls.Add(this.Label_PPups);
            this.GB_CurrentMoves.Controls.Add(this.CB_PPu4);
            this.GB_CurrentMoves.Controls.Add(this.CB_PPu3);
            this.GB_CurrentMoves.Controls.Add(this.CB_PPu2);
            this.GB_CurrentMoves.Controls.Add(this.CB_Move4);
            this.GB_CurrentMoves.Controls.Add(this.CB_PPu1);
            this.GB_CurrentMoves.Controls.Add(this.CB_Move3);
            this.GB_CurrentMoves.Controls.Add(this.CB_Move2);
            this.GB_CurrentMoves.Controls.Add(this.CB_Move1);
            this.GB_CurrentMoves.Location = new System.Drawing.Point(11, 107);
            this.GB_CurrentMoves.Name = "GB_CurrentMoves";
            this.GB_CurrentMoves.Size = new System.Drawing.Size(220, 134);
            this.GB_CurrentMoves.TabIndex = 65;
            this.GB_CurrentMoves.TabStop = false;
            this.GB_CurrentMoves.Text = "Current Moves";
            // 
            // TB_PP4
            // 
            this.TB_PP4.Location = new System.Drawing.Point(135, 105);
            this.TB_PP4.Mask = "000";
            this.TB_PP4.Name = "TB_PP4";
            this.TB_PP4.PromptChar = ' ';
            this.TB_PP4.Size = new System.Drawing.Size(31, 20);
            this.TB_PP4.TabIndex = 16;
            this.TB_PP4.TextChanged += new System.EventHandler(this.updateMovesPPs);
            // 
            // TB_PP3
            // 
            this.TB_PP3.Location = new System.Drawing.Point(135, 79);
            this.TB_PP3.Mask = "000";
            this.TB_PP3.Name = "TB_PP3";
            this.TB_PP3.PromptChar = ' ';
            this.TB_PP3.Size = new System.Drawing.Size(31, 20);
            this.TB_PP3.TabIndex = 15;
            this.TB_PP3.TextChanged += new System.EventHandler(this.updateMovesPPs);
            // 
            // TB_PP2
            // 
            this.TB_PP2.Location = new System.Drawing.Point(135, 53);
            this.TB_PP2.Mask = "000";
            this.TB_PP2.Name = "TB_PP2";
            this.TB_PP2.PromptChar = ' ';
            this.TB_PP2.Size = new System.Drawing.Size(31, 20);
            this.TB_PP2.TabIndex = 14;
            this.TB_PP2.TextChanged += new System.EventHandler(this.updateMovesPPs);
            // 
            // TB_PP1
            // 
            this.TB_PP1.Location = new System.Drawing.Point(135, 27);
            this.TB_PP1.Mask = "000";
            this.TB_PP1.Name = "TB_PP1";
            this.TB_PP1.PromptChar = ' ';
            this.TB_PP1.Size = new System.Drawing.Size(31, 20);
            this.TB_PP1.TabIndex = 13;
            this.TB_PP1.TextChanged += new System.EventHandler(this.updateMovesPPs);
            // 
            // Label_CurPP
            // 
            this.Label_CurPP.Location = new System.Drawing.Point(133, 12);
            this.Label_CurPP.Name = "Label_CurPP";
            this.Label_CurPP.Size = new System.Drawing.Size(35, 13);
            this.Label_CurPP.TabIndex = 2;
            this.Label_CurPP.Text = "PP";
            this.Label_CurPP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_PPups
            // 
            this.Label_PPups.Location = new System.Drawing.Point(169, 12);
            this.Label_PPups.Name = "Label_PPups";
            this.Label_PPups.Size = new System.Drawing.Size(45, 13);
            this.Label_PPups.TabIndex = 12;
            this.Label_PPups.Text = "PP Ups";
            this.Label_PPups.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CB_PPu4
            // 
            this.CB_PPu4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_PPu4.FormattingEnabled = true;
            this.CB_PPu4.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.CB_PPu4.Location = new System.Drawing.Point(172, 104);
            this.CB_PPu4.Name = "CB_PPu4";
            this.CB_PPu4.Size = new System.Drawing.Size(38, 21);
            this.CB_PPu4.TabIndex = 12;
            this.CB_PPu4.SelectedValueChanged += new System.EventHandler(this.updateMovesPPs);
            // 
            // CB_PPu3
            // 
            this.CB_PPu3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_PPu3.FormattingEnabled = true;
            this.CB_PPu3.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.CB_PPu3.Location = new System.Drawing.Point(172, 78);
            this.CB_PPu3.Name = "CB_PPu3";
            this.CB_PPu3.Size = new System.Drawing.Size(38, 21);
            this.CB_PPu3.TabIndex = 9;
            this.CB_PPu3.SelectedValueChanged += new System.EventHandler(this.updateMovesPPs);
            // 
            // CB_PPu2
            // 
            this.CB_PPu2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_PPu2.FormattingEnabled = true;
            this.CB_PPu2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.CB_PPu2.Location = new System.Drawing.Point(172, 52);
            this.CB_PPu2.Name = "CB_PPu2";
            this.CB_PPu2.Size = new System.Drawing.Size(38, 21);
            this.CB_PPu2.TabIndex = 6;
            this.CB_PPu2.SelectedValueChanged += new System.EventHandler(this.updateMovesPPs);
            // 
            // CB_Move4
            // 
            this.CB_Move4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CB_Move4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Move4.FormattingEnabled = true;
            this.CB_Move4.Location = new System.Drawing.Point(9, 104);
            this.CB_Move4.Name = "CB_Move4";
            this.CB_Move4.Size = new System.Drawing.Size(121, 21);
            this.CB_Move4.TabIndex = 10;
            this.CB_Move4.SelectedValueChanged += new System.EventHandler(this.updateMovesPPs);
            // 
            // CB_PPu1
            // 
            this.CB_PPu1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_PPu1.FormattingEnabled = true;
            this.CB_PPu1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.CB_PPu1.Location = new System.Drawing.Point(172, 26);
            this.CB_PPu1.Name = "CB_PPu1";
            this.CB_PPu1.Size = new System.Drawing.Size(38, 21);
            this.CB_PPu1.TabIndex = 3;
            this.CB_PPu1.SelectedValueChanged += new System.EventHandler(this.updateMovesPPs);
            // 
            // CB_Move3
            // 
            this.CB_Move3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CB_Move3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Move3.FormattingEnabled = true;
            this.CB_Move3.Location = new System.Drawing.Point(9, 78);
            this.CB_Move3.Name = "CB_Move3";
            this.CB_Move3.Size = new System.Drawing.Size(121, 21);
            this.CB_Move3.TabIndex = 7;
            this.CB_Move3.SelectedValueChanged += new System.EventHandler(this.updateMovesPPs);
            // 
            // CB_Move2
            // 
            this.CB_Move2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CB_Move2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Move2.FormattingEnabled = true;
            this.CB_Move2.Location = new System.Drawing.Point(9, 52);
            this.CB_Move2.Name = "CB_Move2";
            this.CB_Move2.Size = new System.Drawing.Size(121, 21);
            this.CB_Move2.TabIndex = 4;
            this.CB_Move2.SelectedValueChanged += new System.EventHandler(this.updateMovesPPs);
            // 
            // CB_Move1
            // 
            this.CB_Move1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CB_Move1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Move1.FormattingEnabled = true;
            this.CB_Move1.Location = new System.Drawing.Point(9, 26);
            this.CB_Move1.Name = "CB_Move1";
            this.CB_Move1.Size = new System.Drawing.Size(121, 21);
            this.CB_Move1.TabIndex = 1;
            this.CB_Move1.SelectedValueChanged += new System.EventHandler(this.updateMovesPPs);
            // 
            // Label_Nickname
            // 
            this.Label_Nickname.Location = new System.Drawing.Point(1, 42);
            this.Label_Nickname.Name = "Label_Nickname";
            this.Label_Nickname.Size = new System.Drawing.Size(77, 13);
            this.Label_Nickname.TabIndex = 62;
            this.Label_Nickname.Text = "Nickname:";
            this.Label_Nickname.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_Nickname
            // 
            this.TB_Nickname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_Nickname.Location = new System.Drawing.Point(81, 39);
            this.TB_Nickname.MaximumSize = new System.Drawing.Size(140, 20);
            this.TB_Nickname.MaxLength = 10;
            this.TB_Nickname.MinimumSize = new System.Drawing.Size(140, 20);
            this.TB_Nickname.Name = "TB_Nickname";
            this.TB_Nickname.Size = new System.Drawing.Size(140, 20);
            this.TB_Nickname.TabIndex = 5;
            this.TB_Nickname.TextChanged += new System.EventHandler(this.updateNickname);
            // 
            // TB_Level
            // 
            this.TB_Level.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_Level.Location = new System.Drawing.Point(199, 64);
            this.TB_Level.Mask = "000";
            this.TB_Level.Name = "TB_Level";
            this.TB_Level.Size = new System.Drawing.Size(22, 20);
            this.TB_Level.TabIndex = 8;
            this.TB_Level.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_Level.TextChanged += new System.EventHandler(this.updateEXPLevel);
            // 
            // TB_EXP
            // 
            this.TB_EXP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_EXP.Location = new System.Drawing.Point(81, 64);
            this.TB_EXP.Mask = "0000000";
            this.TB_EXP.Name = "TB_EXP";
            this.TB_EXP.Size = new System.Drawing.Size(46, 20);
            this.TB_EXP.TabIndex = 7;
            this.TB_EXP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_EXP.TextChanged += new System.EventHandler(this.updateEXPLevel);
            // 
            // Label_CurLevel
            // 
            this.Label_CurLevel.Location = new System.Drawing.Point(147, 67);
            this.Label_CurLevel.Name = "Label_CurLevel";
            this.Label_CurLevel.Size = new System.Drawing.Size(50, 13);
            this.Label_CurLevel.TabIndex = 7;
            this.Label_CurLevel.Text = "Level:";
            this.Label_CurLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_Species
            // 
            this.CB_Species.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CB_Species.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Species.FormattingEnabled = true;
            this.CB_Species.Location = new System.Drawing.Point(81, 13);
            this.CB_Species.Name = "CB_Species";
            this.CB_Species.Size = new System.Drawing.Size(140, 21);
            this.CB_Species.TabIndex = 3;
            this.CB_Species.SelectedValueChanged += new System.EventHandler(this.UpdateSpecies);
            // 
            // Label_EXP
            // 
            this.Label_EXP.Location = new System.Drawing.Point(1, 67);
            this.Label_EXP.Name = "Label_EXP";
            this.Label_EXP.Size = new System.Drawing.Size(77, 13);
            this.Label_EXP.TabIndex = 3;
            this.Label_EXP.Text = "EXP:";
            this.Label_EXP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label_Species
            // 
            this.Label_Species.Location = new System.Drawing.Point(1, 16);
            this.Label_Species.Name = "Label_Species";
            this.Label_Species.Size = new System.Drawing.Size(77, 13);
            this.Label_Species.TabIndex = 1;
            this.Label_Species.Text = "Species:";
            this.Label_Species.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabMain
            // 
            this.tabMain.AllowDrop = true;
            this.tabMain.Controls.Add(this.Tab_Main);
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Location = new System.Drawing.Point(13, 27);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(250, 285);
            this.tabMain.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.GB_Stats);
            this.tabPage1.Controls.Add(this.GB_OT);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(242, 259);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Stats/OT";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // GB_Stats
            // 
            this.GB_Stats.Controls.Add(this.Stat_SPD);
            this.GB_Stats.Controls.Add(this.Stat_SPC);
            this.GB_Stats.Controls.Add(this.Stat_DEF);
            this.GB_Stats.Controls.Add(this.Stat_ATK);
            this.GB_Stats.Controls.Add(this.Stat_HP);
            this.GB_Stats.Controls.Add(this.TB_SPDDV);
            this.GB_Stats.Controls.Add(this.TB_SPCDV);
            this.GB_Stats.Controls.Add(this.TB_DEFDV);
            this.GB_Stats.Controls.Add(this.TB_ATKDV);
            this.GB_Stats.Controls.Add(this.TB_HPDV);
            this.GB_Stats.Controls.Add(this.TB_ATKSTATEXP);
            this.GB_Stats.Controls.Add(this.TB_DEFSTATEXP);
            this.GB_Stats.Controls.Add(this.TB_SPDSTATEXP);
            this.GB_Stats.Controls.Add(this.TB_SPCSTATEXP);
            this.GB_Stats.Controls.Add(this.TB_HPSTATEXP);
            this.GB_Stats.Controls.Add(this.Label_Stats);
            this.GB_Stats.Controls.Add(this.Label_EVs);
            this.GB_Stats.Controls.Add(this.Label_DVs);
            this.GB_Stats.Controls.Add(this.Label_SPD);
            this.GB_Stats.Controls.Add(this.Label_SPC);
            this.GB_Stats.Controls.Add(this.Label_DEF);
            this.GB_Stats.Controls.Add(this.Label_ATK);
            this.GB_Stats.Controls.Add(this.Label_HP);
            this.GB_Stats.Location = new System.Drawing.Point(11, 6);
            this.GB_Stats.Name = "GB_Stats";
            this.GB_Stats.Size = new System.Drawing.Size(220, 160);
            this.GB_Stats.TabIndex = 66;
            this.GB_Stats.TabStop = false;
            this.GB_Stats.Text = "Stats";
            // 
            // Stat_SPD
            // 
            this.Stat_SPD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Stat_SPD.Enabled = false;
            this.Stat_SPD.Location = new System.Drawing.Point(139, 125);
            this.Stat_SPD.Mask = "00000";
            this.Stat_SPD.Name = "Stat_SPD";
            this.Stat_SPD.PromptChar = ' ';
            this.Stat_SPD.Size = new System.Drawing.Size(31, 20);
            this.Stat_SPD.TabIndex = 73;
            this.Stat_SPD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Stat_SPC
            // 
            this.Stat_SPC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Stat_SPC.Enabled = false;
            this.Stat_SPC.Location = new System.Drawing.Point(139, 102);
            this.Stat_SPC.Mask = "00000";
            this.Stat_SPC.Name = "Stat_SPC";
            this.Stat_SPC.PromptChar = ' ';
            this.Stat_SPC.Size = new System.Drawing.Size(31, 20);
            this.Stat_SPC.TabIndex = 72;
            this.Stat_SPC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Stat_DEF
            // 
            this.Stat_DEF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Stat_DEF.Enabled = false;
            this.Stat_DEF.Location = new System.Drawing.Point(139, 80);
            this.Stat_DEF.Mask = "00000";
            this.Stat_DEF.Name = "Stat_DEF";
            this.Stat_DEF.PromptChar = ' ';
            this.Stat_DEF.Size = new System.Drawing.Size(31, 20);
            this.Stat_DEF.TabIndex = 71;
            this.Stat_DEF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Stat_ATK
            // 
            this.Stat_ATK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Stat_ATK.Enabled = false;
            this.Stat_ATK.Location = new System.Drawing.Point(139, 58);
            this.Stat_ATK.Mask = "00000";
            this.Stat_ATK.Name = "Stat_ATK";
            this.Stat_ATK.PromptChar = ' ';
            this.Stat_ATK.Size = new System.Drawing.Size(31, 20);
            this.Stat_ATK.TabIndex = 70;
            this.Stat_ATK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Stat_HP
            // 
            this.Stat_HP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Stat_HP.Enabled = false;
            this.Stat_HP.Location = new System.Drawing.Point(139, 36);
            this.Stat_HP.Mask = "00000";
            this.Stat_HP.Name = "Stat_HP";
            this.Stat_HP.PromptChar = ' ';
            this.Stat_HP.Size = new System.Drawing.Size(31, 20);
            this.Stat_HP.TabIndex = 69;
            this.Stat_HP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TB_SPDDV
            // 
            this.TB_SPDDV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_SPDDV.Location = new System.Drawing.Point(48, 125);
            this.TB_SPDDV.Mask = "00";
            this.TB_SPDDV.Name = "TB_SPDDV";
            this.TB_SPDDV.Size = new System.Drawing.Size(22, 20);
            this.TB_SPDDV.TabIndex = 55;
            this.TB_SPDDV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_SPDDV.TextChanged += new System.EventHandler(this.updateDVs);
            // 
            // TB_SPCDV
            // 
            this.TB_SPCDV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_SPCDV.Location = new System.Drawing.Point(48, 102);
            this.TB_SPCDV.Mask = "00";
            this.TB_SPCDV.Name = "TB_SPCDV";
            this.TB_SPCDV.Size = new System.Drawing.Size(22, 20);
            this.TB_SPCDV.TabIndex = 54;
            this.TB_SPCDV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_SPCDV.TextChanged += new System.EventHandler(this.updateDVs);
            // 
            // TB_DEFDV
            // 
            this.TB_DEFDV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_DEFDV.Location = new System.Drawing.Point(48, 80);
            this.TB_DEFDV.Mask = "00";
            this.TB_DEFDV.Name = "TB_DEFDV";
            this.TB_DEFDV.Size = new System.Drawing.Size(22, 20);
            this.TB_DEFDV.TabIndex = 53;
            this.TB_DEFDV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_DEFDV.TextChanged += new System.EventHandler(this.updateDVs);
            // 
            // TB_ATKDV
            // 
            this.TB_ATKDV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_ATKDV.Location = new System.Drawing.Point(48, 58);
            this.TB_ATKDV.Mask = "00";
            this.TB_ATKDV.Name = "TB_ATKDV";
            this.TB_ATKDV.Size = new System.Drawing.Size(22, 20);
            this.TB_ATKDV.TabIndex = 52;
            this.TB_ATKDV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_ATKDV.TextChanged += new System.EventHandler(this.updateDVs);
            // 
            // TB_HPDV
            // 
            this.TB_HPDV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_HPDV.Enabled = false;
            this.TB_HPDV.Location = new System.Drawing.Point(48, 36);
            this.TB_HPDV.Mask = "00";
            this.TB_HPDV.Name = "TB_HPDV";
            this.TB_HPDV.Size = new System.Drawing.Size(22, 20);
            this.TB_HPDV.TabIndex = 51;
            this.TB_HPDV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_HPDV.TextChanged += new System.EventHandler(this.updateDVs);
            // 
            // TB_ATKSTATEXP
            // 
            this.TB_ATKSTATEXP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_ATKSTATEXP.Location = new System.Drawing.Point(76, 58);
            this.TB_ATKSTATEXP.Mask = "00000";
            this.TB_ATKSTATEXP.Name = "TB_ATKSTATEXP";
            this.TB_ATKSTATEXP.Size = new System.Drawing.Size(57, 20);
            this.TB_ATKSTATEXP.TabIndex = 57;
            this.TB_ATKSTATEXP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_ATKSTATEXP.TextChanged += new System.EventHandler(this.updateStatEXPs);
            // 
            // TB_DEFSTATEXP
            // 
            this.TB_DEFSTATEXP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_DEFSTATEXP.Location = new System.Drawing.Point(76, 80);
            this.TB_DEFSTATEXP.Mask = "00000";
            this.TB_DEFSTATEXP.Name = "TB_DEFSTATEXP";
            this.TB_DEFSTATEXP.Size = new System.Drawing.Size(57, 20);
            this.TB_DEFSTATEXP.TabIndex = 58;
            this.TB_DEFSTATEXP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_DEFSTATEXP.TextChanged += new System.EventHandler(this.updateStatEXPs);
            // 
            // TB_SPDSTATEXP
            // 
            this.TB_SPDSTATEXP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_SPDSTATEXP.Location = new System.Drawing.Point(76, 125);
            this.TB_SPDSTATEXP.Mask = "00000";
            this.TB_SPDSTATEXP.Name = "TB_SPDSTATEXP";
            this.TB_SPDSTATEXP.Size = new System.Drawing.Size(57, 20);
            this.TB_SPDSTATEXP.TabIndex = 60;
            this.TB_SPDSTATEXP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_SPDSTATEXP.TextChanged += new System.EventHandler(this.updateStatEXPs);
            // 
            // TB_SPCSTATEXP
            // 
            this.TB_SPCSTATEXP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_SPCSTATEXP.Location = new System.Drawing.Point(76, 102);
            this.TB_SPCSTATEXP.Mask = "00000";
            this.TB_SPCSTATEXP.Name = "TB_SPCSTATEXP";
            this.TB_SPCSTATEXP.Size = new System.Drawing.Size(57, 20);
            this.TB_SPCSTATEXP.TabIndex = 59;
            this.TB_SPCSTATEXP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_SPCSTATEXP.TextChanged += new System.EventHandler(this.updateStatEXPs);
            // 
            // TB_HPSTATEXP
            // 
            this.TB_HPSTATEXP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_HPSTATEXP.Location = new System.Drawing.Point(76, 36);
            this.TB_HPSTATEXP.Mask = "00000";
            this.TB_HPSTATEXP.Name = "TB_HPSTATEXP";
            this.TB_HPSTATEXP.Size = new System.Drawing.Size(57, 20);
            this.TB_HPSTATEXP.TabIndex = 56;
            this.TB_HPSTATEXP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_HPSTATEXP.TextChanged += new System.EventHandler(this.updateStatEXPs);
            // 
            // Label_Stats
            // 
            this.Label_Stats.Location = new System.Drawing.Point(134, 23);
            this.Label_Stats.Name = "Label_Stats";
            this.Label_Stats.Size = new System.Drawing.Size(40, 13);
            this.Label_Stats.TabIndex = 68;
            this.Label_Stats.Text = "Stats";
            this.Label_Stats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_EVs
            // 
            this.Label_EVs.Location = new System.Drawing.Point(74, 23);
            this.Label_EVs.Name = "Label_EVs";
            this.Label_EVs.Size = new System.Drawing.Size(62, 13);
            this.Label_EVs.TabIndex = 67;
            this.Label_EVs.Text = "Stat Exp.";
            this.Label_EVs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_DVs
            // 
            this.Label_DVs.Location = new System.Drawing.Point(44, 23);
            this.Label_DVs.Name = "Label_DVs";
            this.Label_DVs.Size = new System.Drawing.Size(30, 13);
            this.Label_DVs.TabIndex = 66;
            this.Label_DVs.Text = "DVs";
            this.Label_DVs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_SPD
            // 
            this.Label_SPD.Location = new System.Drawing.Point(-12, 127);
            this.Label_SPD.Name = "Label_SPD";
            this.Label_SPD.Size = new System.Drawing.Size(57, 13);
            this.Label_SPD.TabIndex = 65;
            this.Label_SPD.Text = "Spd:";
            this.Label_SPD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label_SPC
            // 
            this.Label_SPC.Location = new System.Drawing.Point(-12, 104);
            this.Label_SPC.Name = "Label_SPC";
            this.Label_SPC.Size = new System.Drawing.Size(57, 13);
            this.Label_SPC.TabIndex = 64;
            this.Label_SPC.Text = "Spc:";
            this.Label_SPC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label_DEF
            // 
            this.Label_DEF.Location = new System.Drawing.Point(-12, 82);
            this.Label_DEF.Name = "Label_DEF";
            this.Label_DEF.Size = new System.Drawing.Size(57, 13);
            this.Label_DEF.TabIndex = 63;
            this.Label_DEF.Text = "Def:";
            this.Label_DEF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label_ATK
            // 
            this.Label_ATK.Location = new System.Drawing.Point(-12, 60);
            this.Label_ATK.Name = "Label_ATK";
            this.Label_ATK.Size = new System.Drawing.Size(57, 13);
            this.Label_ATK.TabIndex = 62;
            this.Label_ATK.Text = "Atk:";
            this.Label_ATK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label_HP
            // 
            this.Label_HP.Location = new System.Drawing.Point(-12, 38);
            this.Label_HP.Name = "Label_HP";
            this.Label_HP.Size = new System.Drawing.Size(57, 13);
            this.Label_HP.TabIndex = 61;
            this.Label_HP.Text = "HP:";
            this.Label_HP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GB_OT
            // 
            this.GB_OT.Controls.Add(this.TB_OT);
            this.GB_OT.Controls.Add(this.TB_TID);
            this.GB_OT.Controls.Add(this.Label_OT);
            this.GB_OT.Controls.Add(this.Label_TID);
            this.GB_OT.Location = new System.Drawing.Point(11, 172);
            this.GB_OT.Name = "GB_OT";
            this.GB_OT.Size = new System.Drawing.Size(220, 75);
            this.GB_OT.TabIndex = 65;
            this.GB_OT.TabStop = false;
            this.GB_OT.Text = "Trainer Information";
            // 
            // TB_OT
            // 
            this.TB_OT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_OT.Location = new System.Drawing.Point(46, 46);
            this.TB_OT.MaximumSize = new System.Drawing.Size(140, 20);
            this.TB_OT.MaxLength = 10;
            this.TB_OT.MinimumSize = new System.Drawing.Size(140, 20);
            this.TB_OT.Name = "TB_OT";
            this.TB_OT.Size = new System.Drawing.Size(140, 20);
            this.TB_OT.TabIndex = 3;
            this.TB_OT.TextChanged += new System.EventHandler(this.updateOT);
            // 
            // TB_TID
            // 
            this.TB_TID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_TID.Location = new System.Drawing.Point(46, 20);
            this.TB_TID.Mask = "00000";
            this.TB_TID.Name = "TB_TID";
            this.TB_TID.Size = new System.Drawing.Size(40, 20);
            this.TB_TID.TabIndex = 1;
            this.TB_TID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_TID.TextChanged += new System.EventHandler(this.updateTID);
            // 
            // Label_OT
            // 
            this.Label_OT.Location = new System.Drawing.Point(4, 48);
            this.Label_OT.Name = "Label_OT";
            this.Label_OT.Size = new System.Drawing.Size(40, 13);
            this.Label_OT.TabIndex = 5;
            this.Label_OT.Text = "OT:";
            this.Label_OT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label_TID
            // 
            this.Label_TID.Location = new System.Drawing.Point(4, 22);
            this.Label_TID.Name = "Label_TID";
            this.Label_TID.Size = new System.Drawing.Size(40, 13);
            this.Label_TID.TabIndex = 3;
            this.Label_TID.Text = "TID:";
            this.Label_TID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mnuVSD
            // 
            this.mnuVSD.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuView,
            this.mnuSet,
            this.mnuDelete});
            this.mnuVSD.Name = "mnuVSD";
            this.mnuVSD.Size = new System.Drawing.Size(108, 70);
            // 
            // mnuView
            // 
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(107, 22);
            this.mnuView.Text = "View";
            // 
            // mnuSet
            // 
            this.mnuSet.Name = "mnuSet";
            this.mnuSet.Size = new System.Drawing.Size(107, 22);
            this.mnuSet.Text = "Set";
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(107, 22);
            this.mnuDelete.Text = "Delete";
            // 
            // tabBoxMulti
            // 
            this.tabBoxMulti.Controls.Add(this.Tab_Trainer);
            this.tabBoxMulti.Controls.Add(this.Tab_BoxDaycare);
            this.tabBoxMulti.Controls.Add(this.Tab_PartyMisc);
            this.tabBoxMulti.Location = new System.Drawing.Point(269, 27);
            this.tabBoxMulti.Name = "tabBoxMulti";
            this.tabBoxMulti.SelectedIndex = 0;
            this.tabBoxMulti.Size = new System.Drawing.Size(238, 285);
            this.tabBoxMulti.TabIndex = 51;
            // 
            // Tab_Trainer
            // 
            this.Tab_Trainer.Controls.Add(this.TB_SaveTID);
            this.Tab_Trainer.Controls.Add(this.LBL_SaveTID);
            this.Tab_Trainer.Controls.Add(this.GB_TimePlayed);
            this.Tab_Trainer.Controls.Add(this.TB_PikaFriend);
            this.Tab_Trainer.Controls.Add(this.Label_PikaFriend);
            this.Tab_Trainer.Controls.Add(this.TB_Coins);
            this.Tab_Trainer.Controls.Add(this.Label_Coins);
            this.Tab_Trainer.Controls.Add(this.TB_Money);
            this.Tab_Trainer.Controls.Add(this.Label_Money);
            this.Tab_Trainer.Controls.Add(this.CLB_Badges);
            this.Tab_Trainer.Controls.Add(this.TB_Rival);
            this.Tab_Trainer.Controls.Add(this.Label_Rival);
            this.Tab_Trainer.Controls.Add(this.TB_SaveName);
            this.Tab_Trainer.Controls.Add(this.Label_SaveName);
            this.Tab_Trainer.Location = new System.Drawing.Point(4, 22);
            this.Tab_Trainer.Name = "Tab_Trainer";
            this.Tab_Trainer.Size = new System.Drawing.Size(230, 259);
            this.Tab_Trainer.TabIndex = 3;
            this.Tab_Trainer.Text = "Trainer";
            this.Tab_Trainer.UseVisualStyleBackColor = true;
            // 
            // GB_TimePlayed
            // 
            this.GB_TimePlayed.Controls.Add(this.MT_Seconds);
            this.GB_TimePlayed.Controls.Add(this.MT_Hours);
            this.GB_TimePlayed.Controls.Add(this.L_Seconds);
            this.GB_TimePlayed.Controls.Add(this.L_Hours);
            this.GB_TimePlayed.Controls.Add(this.MT_Minutes);
            this.GB_TimePlayed.Controls.Add(this.L_Minutes);
            this.GB_TimePlayed.Location = new System.Drawing.Point(22, 189);
            this.GB_TimePlayed.Name = "GB_TimePlayed";
            this.GB_TimePlayed.Size = new System.Drawing.Size(200, 57);
            this.GB_TimePlayed.TabIndex = 60;
            this.GB_TimePlayed.TabStop = false;
            this.GB_TimePlayed.Text = "Time Played";
            // 
            // MT_Seconds
            // 
            this.MT_Seconds.Location = new System.Drawing.Point(166, 22);
            this.MT_Seconds.Mask = "00";
            this.MT_Seconds.Name = "MT_Seconds";
            this.MT_Seconds.Size = new System.Drawing.Size(22, 20);
            this.MT_Seconds.TabIndex = 28;
            this.MT_Seconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MT_Seconds.TextChanged += new System.EventHandler(this.updateTimePlayed);
            // 
            // MT_Hours
            // 
            this.MT_Hours.Location = new System.Drawing.Point(44, 22);
            this.MT_Hours.Mask = "00000";
            this.MT_Hours.Name = "MT_Hours";
            this.MT_Hours.Size = new System.Drawing.Size(38, 20);
            this.MT_Hours.TabIndex = 25;
            this.MT_Hours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MT_Hours.TextChanged += new System.EventHandler(this.updateTimePlayed);
            // 
            // L_Seconds
            // 
            this.L_Seconds.AutoSize = true;
            this.L_Seconds.Location = new System.Drawing.Point(136, 25);
            this.L_Seconds.Name = "L_Seconds";
            this.L_Seconds.Size = new System.Drawing.Size(29, 13);
            this.L_Seconds.TabIndex = 30;
            this.L_Seconds.Text = "Sec:";
            // 
            // L_Hours
            // 
            this.L_Hours.AutoSize = true;
            this.L_Hours.Location = new System.Drawing.Point(12, 25);
            this.L_Hours.Name = "L_Hours";
            this.L_Hours.Size = new System.Drawing.Size(26, 13);
            this.L_Hours.TabIndex = 26;
            this.L_Hours.Text = "Hrs:";
            // 
            // MT_Minutes
            // 
            this.MT_Minutes.Location = new System.Drawing.Point(111, 22);
            this.MT_Minutes.Mask = "00";
            this.MT_Minutes.Name = "MT_Minutes";
            this.MT_Minutes.Size = new System.Drawing.Size(22, 20);
            this.MT_Minutes.TabIndex = 27;
            this.MT_Minutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MT_Minutes.TextChanged += new System.EventHandler(this.updateTimePlayed);
            // 
            // L_Minutes
            // 
            this.L_Minutes.AutoSize = true;
            this.L_Minutes.Location = new System.Drawing.Point(84, 25);
            this.L_Minutes.Name = "L_Minutes";
            this.L_Minutes.Size = new System.Drawing.Size(27, 13);
            this.L_Minutes.TabIndex = 29;
            this.L_Minutes.Text = "Min:";
            // 
            // TB_PikaFriend
            // 
            this.TB_PikaFriend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_PikaFriend.Location = new System.Drawing.Point(106, 122);
            this.TB_PikaFriend.Mask = "000";
            this.TB_PikaFriend.Name = "TB_PikaFriend";
            this.TB_PikaFriend.Size = new System.Drawing.Size(22, 20);
            this.TB_PikaFriend.TabIndex = 59;
            this.TB_PikaFriend.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_PikaFriend.TextChanged += new System.EventHandler(this.updatePikachuFriendship);
            // 
            // Label_PikaFriend
            // 
            this.Label_PikaFriend.Location = new System.Drawing.Point(6, 124);
            this.Label_PikaFriend.Name = "Label_PikaFriend";
            this.Label_PikaFriend.Size = new System.Drawing.Size(101, 13);
            this.Label_PikaFriend.TabIndex = 58;
            this.Label_PikaFriend.Text = "Pikachu Friendship:";
            this.Label_PikaFriend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_Coins
            // 
            this.TB_Coins.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_Coins.Location = new System.Drawing.Point(82, 93);
            this.TB_Coins.Mask = "0000";
            this.TB_Coins.Name = "TB_Coins";
            this.TB_Coins.Size = new System.Drawing.Size(46, 20);
            this.TB_Coins.TabIndex = 17;
            this.TB_Coins.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_Coins.TextChanged += new System.EventHandler(this.updateCoins);
            // 
            // Label_Coins
            // 
            this.Label_Coins.Location = new System.Drawing.Point(39, 96);
            this.Label_Coins.Name = "Label_Coins";
            this.Label_Coins.Size = new System.Drawing.Size(40, 13);
            this.Label_Coins.TabIndex = 16;
            this.Label_Coins.Text = "Coins:";
            this.Label_Coins.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_Money
            // 
            this.TB_Money.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_Money.Location = new System.Drawing.Point(82, 65);
            this.TB_Money.Mask = "000000";
            this.TB_Money.Name = "TB_Money";
            this.TB_Money.Size = new System.Drawing.Size(46, 20);
            this.TB_Money.TabIndex = 15;
            this.TB_Money.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_Money.TextChanged += new System.EventHandler(this.updateMoney);
            // 
            // Label_Money
            // 
            this.Label_Money.Location = new System.Drawing.Point(23, 69);
            this.Label_Money.Name = "Label_Money";
            this.Label_Money.Size = new System.Drawing.Size(57, 13);
            this.Label_Money.TabIndex = 14;
            this.Label_Money.Text = "Money:";
            this.Label_Money.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CLB_Badges
            // 
            this.CLB_Badges.FormattingEnabled = true;
            this.CLB_Badges.Location = new System.Drawing.Point(135, 65);
            this.CLB_Badges.Name = "CLB_Badges";
            this.CLB_Badges.Size = new System.Drawing.Size(87, 124);
            this.CLB_Badges.TabIndex = 10;
            this.CLB_Badges.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.updateBadges);
            // 
            // TB_Rival
            // 
            this.TB_Rival.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_Rival.Location = new System.Drawing.Point(82, 37);
            this.TB_Rival.MaximumSize = new System.Drawing.Size(140, 20);
            this.TB_Rival.MaxLength = 10;
            this.TB_Rival.MinimumSize = new System.Drawing.Size(140, 20);
            this.TB_Rival.Name = "TB_Rival";
            this.TB_Rival.Size = new System.Drawing.Size(140, 20);
            this.TB_Rival.TabIndex = 8;
            this.TB_Rival.TextChanged += new System.EventHandler(this.updateRivalName);
            // 
            // Label_Rival
            // 
            this.Label_Rival.Location = new System.Drawing.Point(3, 37);
            this.Label_Rival.Name = "Label_Rival";
            this.Label_Rival.Size = new System.Drawing.Size(77, 15);
            this.Label_Rival.TabIndex = 9;
            this.Label_Rival.Text = "Rival Name:";
            this.Label_Rival.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_SaveName
            // 
            this.TB_SaveName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_SaveName.Location = new System.Drawing.Point(82, 11);
            this.TB_SaveName.MaximumSize = new System.Drawing.Size(140, 20);
            this.TB_SaveName.MaxLength = 10;
            this.TB_SaveName.MinimumSize = new System.Drawing.Size(140, 20);
            this.TB_SaveName.Name = "TB_SaveName";
            this.TB_SaveName.Size = new System.Drawing.Size(140, 20);
            this.TB_SaveName.TabIndex = 6;
            this.TB_SaveName.TextChanged += new System.EventHandler(this.updateSaveTrainerName);
            // 
            // Label_SaveName
            // 
            this.Label_SaveName.Location = new System.Drawing.Point(40, 13);
            this.Label_SaveName.Name = "Label_SaveName";
            this.Label_SaveName.Size = new System.Drawing.Size(40, 13);
            this.Label_SaveName.TabIndex = 7;
            this.Label_SaveName.Text = "Name:";
            this.Label_SaveName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Tab_BoxDaycare
            // 
            this.Tab_BoxDaycare.Controls.Add(this.label1);
            this.Tab_BoxDaycare.Controls.Add(this.B_BoxRight);
            this.Tab_BoxDaycare.Controls.Add(this.B_BoxLeft);
            this.Tab_BoxDaycare.Controls.Add(this.CB_BoxSelect);
            this.Tab_BoxDaycare.Location = new System.Drawing.Point(4, 22);
            this.Tab_BoxDaycare.Name = "Tab_BoxDaycare";
            this.Tab_BoxDaycare.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_BoxDaycare.Size = new System.Drawing.Size(230, 259);
            this.Tab_BoxDaycare.TabIndex = 0;
            this.Tab_BoxDaycare.Text = "Boxes/Daycare";
            this.Tab_BoxDaycare.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Daycare:";
            // 
            // B_BoxRight
            // 
            this.B_BoxRight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.B_BoxRight.Location = new System.Drawing.Point(179, 9);
            this.B_BoxRight.Name = "B_BoxRight";
            this.B_BoxRight.Size = new System.Drawing.Size(27, 23);
            this.B_BoxRight.TabIndex = 61;
            this.B_BoxRight.Text = ">>";
            this.B_BoxRight.UseVisualStyleBackColor = true;
            this.B_BoxRight.Click += new System.EventHandler(this.clickBoxRight);
            // 
            // B_BoxLeft
            // 
            this.B_BoxLeft.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.B_BoxLeft.Location = new System.Drawing.Point(17, 9);
            this.B_BoxLeft.Name = "B_BoxLeft";
            this.B_BoxLeft.Size = new System.Drawing.Size(27, 23);
            this.B_BoxLeft.TabIndex = 60;
            this.B_BoxLeft.Text = "<<";
            this.B_BoxLeft.UseVisualStyleBackColor = true;
            this.B_BoxLeft.Click += new System.EventHandler(this.clickBoxLeft);
            // 
            // CB_BoxSelect
            // 
            this.CB_BoxSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_BoxSelect.FormattingEnabled = true;
            this.CB_BoxSelect.Items.AddRange(new object[] {
            "Box 1",
            "Box 2",
            "Box 3",
            "Box 4",
            "Box 5",
            "Box 6",
            "Box 7",
            "Box 8",
            "Box 9",
            "Box 10",
            "Box 11",
            "Box 12"});
            this.CB_BoxSelect.Location = new System.Drawing.Point(48, 10);
            this.CB_BoxSelect.Name = "CB_BoxSelect";
            this.CB_BoxSelect.Size = new System.Drawing.Size(127, 21);
            this.CB_BoxSelect.TabIndex = 0;
            this.CB_BoxSelect.SelectedIndexChanged += new System.EventHandler(this.getBox);
            // 
            // Tab_PartyMisc
            // 
            this.Tab_PartyMisc.Controls.Add(this.B_Options);
            this.Tab_PartyMisc.Controls.Add(this.B_Pokedex);
            this.Tab_PartyMisc.Controls.Add(this.B_Inventory);
            this.Tab_PartyMisc.Controls.Add(this.L_Party);
            this.Tab_PartyMisc.Location = new System.Drawing.Point(4, 22);
            this.Tab_PartyMisc.Name = "Tab_PartyMisc";
            this.Tab_PartyMisc.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_PartyMisc.Size = new System.Drawing.Size(230, 259);
            this.Tab_PartyMisc.TabIndex = 1;
            this.Tab_PartyMisc.Text = "Party/Misc";
            this.Tab_PartyMisc.UseVisualStyleBackColor = true;
            // 
            // B_Options
            // 
            this.B_Options.Location = new System.Drawing.Point(81, 214);
            this.B_Options.Name = "B_Options";
            this.B_Options.Size = new System.Drawing.Size(61, 26);
            this.B_Options.TabIndex = 67;
            this.B_Options.Text = "Options";
            this.B_Options.UseVisualStyleBackColor = true;
            this.B_Options.Click += new System.EventHandler(this.openOptionsForm);
            // 
            // B_Pokedex
            // 
            this.B_Pokedex.Location = new System.Drawing.Point(146, 214);
            this.B_Pokedex.Name = "B_Pokedex";
            this.B_Pokedex.Size = new System.Drawing.Size(61, 26);
            this.B_Pokedex.TabIndex = 66;
            this.B_Pokedex.Text = "Pokedex";
            this.B_Pokedex.UseVisualStyleBackColor = true;
            this.B_Pokedex.Click += new System.EventHandler(this.openPokedexForm);
            // 
            // B_Inventory
            // 
            this.B_Inventory.Location = new System.Drawing.Point(16, 214);
            this.B_Inventory.Name = "B_Inventory";
            this.B_Inventory.Size = new System.Drawing.Size(61, 26);
            this.B_Inventory.TabIndex = 64;
            this.B_Inventory.Text = "Inventory";
            this.B_Inventory.UseVisualStyleBackColor = true;
            this.B_Inventory.Click += new System.EventHandler(this.openInventoryForm);
            // 
            // L_Party
            // 
            this.L_Party.AutoSize = true;
            this.L_Party.Location = new System.Drawing.Point(13, 17);
            this.L_Party.Name = "L_Party";
            this.L_Party.Size = new System.Drawing.Size(34, 13);
            this.L_Party.TabIndex = 0;
            this.L_Party.Text = "Party:";
            // 
            // L_Save
            // 
            this.L_Save.AutoSize = true;
            this.L_Save.Location = new System.Drawing.Point(270, 9);
            this.L_Save.Name = "L_Save";
            this.L_Save.Size = new System.Drawing.Size(54, 13);
            this.L_Save.TabIndex = 52;
            this.L_Save.Text = "SAV: N/A";
            // 
            // PB_DragOut
            // 
            this.PB_DragOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_DragOut.Location = new System.Drawing.Point(242, 6);
            this.PB_DragOut.Name = "PB_DragOut";
            this.PB_DragOut.Size = new System.Drawing.Size(18, 18);
            this.PB_DragOut.TabIndex = 53;
            this.PB_DragOut.TabStop = false;
            // 
            // TB_SaveTID
            // 
            this.TB_SaveTID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_SaveTID.Location = new System.Drawing.Point(88, 151);
            this.TB_SaveTID.Mask = "00000";
            this.TB_SaveTID.Name = "TB_SaveTID";
            this.TB_SaveTID.Size = new System.Drawing.Size(40, 20);
            this.TB_SaveTID.TabIndex = 61;
            this.TB_SaveTID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_SaveTID.TextChanged += new System.EventHandler(this.updateSaveTID);
            // 
            // LBL_SaveTID
            // 
            this.LBL_SaveTID.Location = new System.Drawing.Point(46, 153);
            this.LBL_SaveTID.Name = "LBL_SaveTID";
            this.LBL_SaveTID.Size = new System.Drawing.Size(40, 13);
            this.LBL_SaveTID.TabIndex = 62;
            this.LBL_SaveTID.Text = "TID:";
            this.LBL_SaveTID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 321);
            this.Controls.Add(this.PB_DragOut);
            this.Controls.Add(this.L_Save);
            this.Controls.Add(this.tabBoxMulti);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(530, 360);
            this.MinimumSize = new System.Drawing.Size(530, 360);
            this.Name = "MainForm";
            this.Text = "Rhydon Save Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Tab_Main.ResumeLayout(false);
            this.Tab_Main.PerformLayout();
            this.GB_CurrentMoves.ResumeLayout(false);
            this.GB_CurrentMoves.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.GB_Stats.ResumeLayout(false);
            this.GB_Stats.PerformLayout();
            this.GB_OT.ResumeLayout(false);
            this.GB_OT.PerformLayout();
            this.mnuVSD.ResumeLayout(false);
            this.tabBoxMulti.ResumeLayout(false);
            this.Tab_Trainer.ResumeLayout(false);
            this.Tab_Trainer.PerformLayout();
            this.GB_TimePlayed.ResumeLayout(false);
            this.GB_TimePlayed.PerformLayout();
            this.Tab_BoxDaycare.ResumeLayout(false);
            this.Tab_BoxDaycare.PerformLayout();
            this.Tab_PartyMisc.ResumeLayout(false);
            this.Tab_PartyMisc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_DragOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu_File;
        private System.Windows.Forms.ToolStripMenuItem Menu_Open;
        private System.Windows.Forms.ToolStripMenuItem Menu_Save;
        private System.Windows.Forms.ToolStripMenuItem Menu_ExportSAV;
        private System.Windows.Forms.ToolStripMenuItem Menu_Exit;
        private System.Windows.Forms.ToolStripMenuItem Menu_Options;
        private System.Windows.Forms.ToolStripMenuItem Menu_Modify;
        private System.Windows.Forms.ToolStripMenuItem Menu_ModifyDex;
        private System.Windows.Forms.TabPage Tab_Main;
        private System.Windows.Forms.Label Label_Nickname;
        public System.Windows.Forms.TextBox TB_Nickname;
        private System.Windows.Forms.MaskedTextBox TB_Level;
        private System.Windows.Forms.MaskedTextBox TB_EXP;
        private System.Windows.Forms.Label Label_CurLevel;
        public System.Windows.Forms.ComboBox CB_Species;
        private System.Windows.Forms.Label Label_EXP;
        private System.Windows.Forms.Label Label_Species;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.ContextMenuStrip mnuVSD;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuSet;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.TabControl tabBoxMulti;
        private System.Windows.Forms.TabPage Tab_BoxDaycare;
        private System.Windows.Forms.Button B_BoxRight;
        private System.Windows.Forms.Button B_BoxLeft;
        private System.Windows.Forms.ComboBox CB_BoxSelect;
        private System.Windows.Forms.TabPage Tab_PartyMisc;
        private System.Windows.Forms.Label L_Party;
        private System.Windows.Forms.Label L_Save;
        private System.Windows.Forms.TabPage Tab_Trainer;
        private System.Windows.Forms.TextBox TB_SaveName;
        private System.Windows.Forms.Label Label_SaveName;
        private System.Windows.Forms.TextBox TB_Rival;
        private System.Windows.Forms.Label Label_Rival;
        private System.Windows.Forms.CheckedListBox CLB_Badges;
        private System.Windows.Forms.MaskedTextBox TB_Coins;
        private System.Windows.Forms.Label Label_Coins;
        private System.Windows.Forms.MaskedTextBox TB_Money;
        private System.Windows.Forms.Label Label_Money;
        private System.Windows.Forms.GroupBox GB_CurrentMoves;
        private System.Windows.Forms.MaskedTextBox TB_PP4;
        private System.Windows.Forms.MaskedTextBox TB_PP3;
        private System.Windows.Forms.MaskedTextBox TB_PP2;
        private System.Windows.Forms.MaskedTextBox TB_PP1;
        private System.Windows.Forms.Label Label_CurPP;
        private System.Windows.Forms.Label Label_PPups;
        private System.Windows.Forms.ComboBox CB_PPu4;
        private System.Windows.Forms.ComboBox CB_PPu3;
        private System.Windows.Forms.ComboBox CB_PPu2;
        private System.Windows.Forms.ComboBox CB_Move4;
        private System.Windows.Forms.ComboBox CB_PPu1;
        private System.Windows.Forms.ComboBox CB_Move3;
        private System.Windows.Forms.ComboBox CB_Move2;
        private System.Windows.Forms.ComboBox CB_Move1;
        private System.Windows.Forms.GroupBox GB_TimePlayed;
        private System.Windows.Forms.MaskedTextBox MT_Seconds;
        private System.Windows.Forms.MaskedTextBox MT_Hours;
        private System.Windows.Forms.Label L_Seconds;
        private System.Windows.Forms.Label L_Hours;
        private System.Windows.Forms.MaskedTextBox MT_Minutes;
        private System.Windows.Forms.Label L_Minutes;
        private System.Windows.Forms.MaskedTextBox TB_PikaFriend;
        private System.Windows.Forms.Label Label_PikaFriend;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox GB_Stats;
        private System.Windows.Forms.MaskedTextBox Stat_SPD;
        private System.Windows.Forms.MaskedTextBox Stat_SPC;
        private System.Windows.Forms.MaskedTextBox Stat_DEF;
        private System.Windows.Forms.MaskedTextBox Stat_ATK;
        private System.Windows.Forms.MaskedTextBox Stat_HP;
        private System.Windows.Forms.MaskedTextBox TB_SPDDV;
        private System.Windows.Forms.MaskedTextBox TB_SPCDV;
        private System.Windows.Forms.MaskedTextBox TB_DEFDV;
        private System.Windows.Forms.MaskedTextBox TB_ATKDV;
        private System.Windows.Forms.MaskedTextBox TB_HPDV;
        private System.Windows.Forms.MaskedTextBox TB_ATKSTATEXP;
        private System.Windows.Forms.MaskedTextBox TB_DEFSTATEXP;
        private System.Windows.Forms.MaskedTextBox TB_SPDSTATEXP;
        private System.Windows.Forms.MaskedTextBox TB_SPCSTATEXP;
        private System.Windows.Forms.MaskedTextBox TB_HPSTATEXP;
        private System.Windows.Forms.Label Label_Stats;
        private System.Windows.Forms.Label Label_EVs;
        private System.Windows.Forms.Label Label_DVs;
        private System.Windows.Forms.Label Label_SPD;
        private System.Windows.Forms.Label Label_SPC;
        private System.Windows.Forms.Label Label_DEF;
        private System.Windows.Forms.Label Label_ATK;
        private System.Windows.Forms.Label Label_HP;
        public System.Windows.Forms.GroupBox GB_OT;
        private System.Windows.Forms.TextBox TB_OT;
        private System.Windows.Forms.MaskedTextBox TB_TID;
        private System.Windows.Forms.Label Label_OT;
        private System.Windows.Forms.Label Label_TID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_Inventory;
        private System.Windows.Forms.Button B_Pokedex;
        private System.Windows.Forms.Button B_Options;
        private System.Windows.Forms.ToolStripMenuItem Menu_UseOldSprites;
        private System.Windows.Forms.PictureBox PB_DragOut;
        private System.Windows.Forms.ToolStripMenuItem Menu_JapaneseMode;
        private System.Windows.Forms.MaskedTextBox TB_SaveTID;
        private System.Windows.Forms.Label LBL_SaveTID;
    }
}

