using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using Rhydon.SAV;

namespace Rhydon
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Util.LoadFont();

            InitializeControls();

            InitializeFields();
            initializedFields = true;
        }

        private readonly PokemonList pk1_wrapper = new PokemonList();

        private PokemonListPanel PLC_Box;
        private PokemonListPanel PLC_Party;
        private PokemonListPanel PLC_DayCare;

        public bool modify_dex = true;

        public PK1 pk1
        {
            get { return pk1_wrapper[0]; }
            set { pk1_wrapper[0] = value; }
        }

        public SAV1 sav;

        public static List<Util.cbItem> MoveDataSource, ItemDataSource, SpeciesDataSource;

        private void InitializeControls()
        {
            MoveDataSource = new List<Util.cbItem>();
            foreach (PK1.MoveType m in Enum.GetValues(typeof(PK1.MoveType)).Cast<PK1.MoveType>())
            {
                MoveDataSource.Add(new Util.cbItem { Text = Tables.ID_To_MoveName[(int)m], Value = (int)m });
            }
            MoveDataSource = MoveDataSource.OrderBy(cb => cb.Text).ToList();

            foreach (ComboBox cb in new[] { CB_Move1, CB_Move2, CB_Move3, CB_Move4 })
            {
                cb.DisplayMember = "Text";
                cb.ValueMember = "Value";
                cb.DataSource = new BindingSource(MoveDataSource, null);
            }

            SpeciesDataSource = new List<Util.cbItem>();
            foreach (PK1.SpeciesType m in Enum.GetValues(typeof(PK1.SpeciesType)).Cast<PK1.SpeciesType>())
            {
                if (m != PK1.SpeciesType.Missingno)
                    SpeciesDataSource.Add(new Util.cbItem { Text = Tables.ID_To_Name[(int)m], Value = (int)m });
            }
            SpeciesDataSource = SpeciesDataSource.OrderBy(cb => cb.Text).ToList();

            CB_Species.DisplayMember = "Text";
            CB_Species.ValueMember = "Value";
            CB_Species.DataSource = new BindingSource(SpeciesDataSource, null);
            CB_Species.SelectedValue = 1;

            foreach (TabPage tp in tabMain.TabPages)
                tp.Select();
            tabMain.SelectTab(tabMain.TabPages[0]);

            TB_OT.Font = Util.Pokered_US;
            TB_Nickname.Font = Util.Pokered_US;
            TB_SaveName.Font = Util.Pokered_US;
            TB_Rival.Font = Util.Pokered_US;

            PLC_Box = new PokemonListPanel(new PokemonList(PokemonList.CapacityType.Stored), mnuVSD) { Location = new Point(16, 35) };
            PLC_Party = new PokemonListPanel(new PokemonList(PokemonList.CapacityType.Party), mnuVSD) { Location = new Point(16, 35) };
            PLC_DayCare = new PokemonListPanel(new PokemonList(PokemonList.CapacityType.Daycare), mnuVSD, PokemonList.CAPACITY_DAYCARE) {Location = new Point(16, 214)}; 

            Tab_BoxDaycare.Controls.Add(PLC_Box);
            Tab_PartyMisc.Controls.Add(PLC_Party);
            Tab_BoxDaycare.Controls.Add(PLC_DayCare);
            foreach (TabPage tp in tabBoxMulti.TabPages)
            {
                tp.Select();
                tp.Enabled = false;
            }
            tabBoxMulti.SelectTab(tabBoxMulti.TabPages[0]);

            foreach (string badge in new[] { "Boulder", "Cascade", "Thunder", "Rainbow", "Soul", "Marsh", "Volcano", "Earth" })
            {
                CLB_Badges.Items.Add(badge);
            }

            foreach (Control c in new Control[] { this, PB_DragOut, tabMain })
            {
                c.AllowDrop = true;
                c.DragDrop += MF_DragDrop;
                c.DragEnter += MF_DragEnter;
            }

            foreach (TabPage tp in tabMain.Controls)
            {
                tp.AllowDrop = true;
                tp.DragDrop += MF_DragDrop;
                tp.DragEnter += MF_DragEnter;

                foreach (Control c in tp.Controls)
                {
                    c.AllowDrop = true;
                    c.DragDrop += MF_DragDrop;
                    c.DragEnter += MF_DragEnter;
                }
            }

            PB_DragOut.MouseDown += PB_MouseDown;
        }

        private void InitializeFields()
        {
            pk1.Species = (byte)PK1.SpeciesType.Rhydon;
            pk1.Move_1 = (byte)PK1.MoveType.Pound;

            PopulateFields(pk1);
            {
                TB_OT.Text = "Rhydon";
                TB_Nickname.Text = "RHYDON";
                TB_TID.Text = 12345.ToString();
                pk1.OT_Name = RBY_Encoding.GetBytes(TB_OT.Text);
                pk1.Nickname = RBY_Encoding.GetBytes(TB_Nickname.Text);
                pk1.TID = 12345;
                CB_PPu1.SelectedIndex = CB_PPu2.SelectedIndex = CB_PPu3.SelectedIndex = CB_PPu4.SelectedIndex = 0;
            }
        }

        private bool changingFields;
        private readonly bool initializedFields;
        private bool saveLoaded;

        private bool inChildForm;

        public bool getInChildForm()
        {
            return inChildForm;
        }

        public void PopulateFields(SAV1 s)
        {
            sav = s;

            L_Save.Text = "SAV: " + Path.GetFileNameWithoutExtension(sav.FileName); // more descriptive

            CB_BoxSelect.SelectedIndex = sav.Current_Box_Index;
            PLC_Party.SetList(sav.Party);
            PLC_DayCare.SetList(sav.Daycare);
            getBox(null, null);

            TB_SaveName.Text = sav.OT_Name;
            TB_Rival.Text = sav.Rival_Name;

            for (int i = 0; i < CLB_Badges.Items.Count; i++)
                CLB_Badges.SetItemChecked(i, sav.Badges[i]);

            changingFields = true;

            MT_Hours.Text = sav.Time_Played[0].ToString();
            MT_Minutes.Text = sav.Time_Played[1].ToString();
            MT_Seconds.Text = sav.Time_Played[2].ToString();

            changingFields = false;

            TB_Money.Text = sav.Money;
            TB_Coins.Text = sav.Coins;
            TB_BoxIndex.Text = (sav.Current_Box_Index + 1).ToString("00");

            TB_PikaFriend.Text = sav.Pika_Friendship.ToString("000");
        }

        public void PopulateFields(PK1 pk, bool focus = true)
        {
            pk1 = pk ?? new PK1();

            if (focus)
                Tab_Main.Focus();

            pk1.Current_Level = (byte)Tables.getLevel(pk1.Species, pk1.EXP);
            if (pk1.Level == 100)
                pk1.EXP = Tables.getEXP(pk1.Current_Level, pk1.Species);
            pk1.Level = pk1.Current_Level;

            changingFields = true;
            CB_Species.SelectedValue = (int)pk1.Species;

            TB_TID.Text = pk1.TID.ToString("00000");
            TB_OT.Text = RBY_Encoding.GetString(pk1.OT_Name);
            TB_Nickname.Text = RBY_Encoding.GetString(pk1.Nickname);

            TB_HPDV.Text = pk1.DV_HP.ToString();
            TB_ATKDV.Text = pk1.DV_ATK.ToString();
            TB_DEFDV.Text = pk1.DV_DEF.ToString();
            TB_SPDDV.Text = pk1.DV_SPD.ToString();
            TB_SPCDV.Text = pk1.DV_SPC.ToString();

            TB_HPSTATEXP.Text = pk1.STATEXP_HP.ToString();
            TB_ATKSTATEXP.Text = pk1.STATEXP_ATK.ToString();
            TB_DEFSTATEXP.Text = pk1.STATEXP_DEF.ToString();
            TB_SPCSTATEXP.Text = pk1.STATEXP_SPC.ToString();
            TB_SPDSTATEXP.Text = pk1.STATEXP_SPD.ToString();

            TB_EXP.Text = pk1.EXP.ToString();
            TB_Level.Text = pk1.Current_Level.ToString();

            CB_Move1.SelectedValue = (int)pk1.Move_1;
            CB_Move2.SelectedValue = (int)pk1.Move_2;
            CB_Move3.SelectedValue = (int)pk1.Move_3;
            CB_Move4.SelectedValue = (int)pk1.Move_4;

            CB_PPu1.SelectedIndex = pk1.PPUP_1;
            CB_PPu2.SelectedIndex = pk1.PPUP_2;
            CB_PPu3.SelectedIndex = pk1.PPUP_3;
            CB_PPu4.SelectedIndex = pk1.PPUP_4;
            TB_PP1.Text = pk1.PP_1.ToString();
            TB_PP2.Text = pk1.PP_2.ToString();
            TB_PP3.Text = pk1.PP_3.ToString();
            TB_PP4.Text = pk1.PP_4.ToString();
            changingFields = false;
            updateStats();

        }

        public void PopulateFieldsLegacy(byte[] input, bool focus = true)
        {
            pk1 = new PK1();
            pk1.Species = input[0];

            if (focus)
                Tab_Main.Focus();

            pk1.EXP = (Util.ToUInt32(input, 0x25) >> 8) & 0x00FFFFFF;

            pk1.Current_Level = (byte)Tables.getLevel(pk1.Species, pk1.EXP);
            if (pk1.Level == 100)
                pk1.EXP = Tables.getEXP(pk1.Current_Level, pk1.Species);
            pk1.Level = pk1.Current_Level;

            changingFields = true;
            CB_Species.SelectedValue = (int)pk1.Species;

            pk1.TID = Util.ToUInt16(input, 0x23);
            TB_TID.Text = pk1.TID.ToString("00000");

            byte[] otArray = { input[1], input[2], input[3], input[4], input[5], input[6], input[7], input[8], input[9], input[10], input[11] };
            pk1.OT_Name = otArray;
            byte[] nickArray = { input[12], input[13], input[14], input[15], input[16], input[17], input[18], input[19], input[20], input[21], input[22] };
            pk1.Nickname = nickArray;

            TB_OT.Text = RBY_Encoding.GetString(pk1.OT_Name);
            TB_Nickname.Text = RBY_Encoding.GetString(pk1.Nickname);

            ushort DV16val = Util.ToUInt16(input, 0x32);
            pk1.DV_ATK = (DV16val >> 12) & 0xF;
            pk1.DV_DEF = (DV16val >> 8) & 0xF;
            pk1.DV_SPD = (DV16val >> 4) & 0xF;
            pk1.DV_SPC = (DV16val >> 0) & 0xF;

            TB_HPDV.Text = pk1.DV_HP.ToString();
            TB_ATKDV.Text = pk1.DV_ATK.ToString();
            TB_DEFDV.Text = pk1.DV_DEF.ToString();
            TB_SPDDV.Text = pk1.DV_SPD.ToString();
            TB_SPCDV.Text = pk1.DV_SPC.ToString();

            pk1.STATEXP_HP = Util.ToUInt16(input, 0x28);
            pk1.STATEXP_ATK = Util.ToUInt16(input, 0x2A);
            pk1.STATEXP_DEF = Util.ToUInt16(input, 0x2C);
            pk1.STATEXP_SPC = Util.ToUInt16(input, 0x30);
            pk1.STATEXP_SPD = Util.ToUInt16(input, 0x2E);

            TB_HPSTATEXP.Text = pk1.STATEXP_HP.ToString();
            TB_ATKSTATEXP.Text = pk1.STATEXP_ATK.ToString();
            TB_DEFSTATEXP.Text = pk1.STATEXP_DEF.ToString();
            TB_SPCSTATEXP.Text = pk1.STATEXP_SPC.ToString();
            TB_SPDSTATEXP.Text = pk1.STATEXP_SPD.ToString();

            TB_EXP.Text = pk1.EXP.ToString();
            TB_Level.Text = pk1.Current_Level.ToString();

            pk1.Move_1 = input[31];
            pk1.Move_2 = input[32];
            pk1.Move_3 = input[33];
            pk1.Move_4 = input[34];
            CB_Move1.SelectedValue = (int)pk1.Move_1;
            CB_Move2.SelectedValue = (int)pk1.Move_2;
            CB_Move3.SelectedValue = (int)pk1.Move_3;
            CB_Move4.SelectedValue = (int)pk1.Move_4;

            pk1.PPUP_1 = (byte)((input[0x34] & 0xC0) >> 6);
            pk1.PPUP_2 = (byte)((input[0x35] & 0xC0) >> 6);
            pk1.PPUP_3 = (byte)((input[0x36] & 0xC0) >> 6);
            pk1.PPUP_4 = (byte)((input[0x37] & 0xC0) >> 6);
            pk1.PP_1 = (byte)(input[0x34] & 0x3F);
            pk1.PP_2 = (byte)(input[0x35] & 0x3F);
            pk1.PP_3 = (byte)(input[0x36] & 0x3F);
            pk1.PP_4 = (byte)(input[0x37] & 0x3F);

            CB_PPu1.SelectedIndex = pk1.PPUP_1;
            CB_PPu2.SelectedIndex = pk1.PPUP_2;
            CB_PPu3.SelectedIndex = pk1.PPUP_3;
            CB_PPu4.SelectedIndex = pk1.PPUP_4;
            TB_PP1.Text = pk1.PP_1.ToString();
            TB_PP2.Text = pk1.PP_2.ToString();
            TB_PP3.Text = pk1.PP_3.ToString();
            TB_PP4.Text = pk1.PP_4.ToString();

            changingFields = false;
            updateStats();
        }

        private void UpdateSpecies(object sender, EventArgs e)
        {
            // Change Species Prompted
            int Species = Util.getIndex(CB_Species);
            int Level = Util.ToInt32(TB_Level.Text);

            // Recalculate EXP for Given Level
            uint EXP = Tables.getEXP(Level, Species);
            TB_EXP.Text = EXP.ToString();

            if (TB_Nickname.Text == Tables.ID_To_Name[pk1.Species].ToUpper().Replace('♀', (char)RBY_Encoding.CHAR_FEM_NUM).Replace('♂', (char)RBY_Encoding.CHAR_MAL_NUM))
                TB_Nickname.Text = Tables.ID_To_Name[Species].ToUpper().Replace('♀', (char)RBY_Encoding.CHAR_FEM_NUM).Replace('♂', (char)RBY_Encoding.CHAR_MAL_NUM);

            pk1.Species = (byte)Species;

            UpdateDragOutBox();
        }

        private void UpdateDragOutBox()
        {
            PB_DragOut.Image = Util.GetPartySprite(pk1);
        }

        private void MF_DragDrop(object sender, DragEventArgs e)
        {
            if (inChildForm)
                return;
            // Check for In-Dropped files
            object[] files = (object[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                openFile((string)files[0]);
            }
        }

        private void MF_DragEnter(object sender, DragEventArgs e)
        {
            if (inChildForm)
                return;
            if (e.AllowedEffect == (DragDropEffects.Copy | DragDropEffects.Link)) // external file
                e.Effect = DragDropEffects.Copy;
            else if (e.Data != null) // within
                e.Effect = DragDropEffects.Move;
        }

        private void PB_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.Clicks != 1 || inChildForm) return;


            byte[] dragdata = pk1_wrapper.GetBytes();


            string filename = RBY_Encoding.GetString(pk1.Nickname) + " - " +
                              RBY_Encoding.GetString(pk1.OT_Name) + ".pk1";

            string newfile = Path.Combine(Path.GetTempPath(), Util.CleanFileName(filename));
            try
            {
                File.WriteAllBytes(newfile, dragdata);
                DoDragDrop(new DataObject(DataFormats.FileDrop, new[] { newfile }), DragDropEffects.Move);

            }
            catch (ArgumentException x)
            { Util.Error("Drag & Drop Error:", x.ToString()); }
            File.Delete(newfile);
        }

        private void updateEXPLevel(object sender, EventArgs e)
        {
            if (changingFields || !initializedFields) return;

            changingFields = true;
            if (sender == TB_EXP)
            {
                // Change the Level
                uint EXP = Util.ToUInt32(TB_EXP.Text);
                int Species = Util.getIndex(CB_Species);
                int Level = Tables.getLevel(Species, EXP);
                if (Level == 100)
                    EXP = Tables.getEXP(100, Species);

                TB_Level.Text = Level.ToString();
                TB_EXP.Text = EXP.ToString();
                pk1.Level = pk1.Current_Level = (byte)Level;
                pk1.EXP = EXP;
            }
            else if (sender == TB_Level)
            {
                // Change the XP
                int Level = Util.ToInt32(TB_Level.Text);
                int Species = Util.getIndex(CB_Species);
                if (Level > 100)
                {
                    Level = 100;
                    TB_Level.Text = "100";
                }

                uint EXP = Tables.getEXP(Level, Species);
                pk1.Level = pk1.Current_Level = (byte)Level;
                if (Tables.getLevel(Species, Util.ToUInt32(TB_EXP.Text)) != Level)
                {
                    pk1.EXP = EXP;
                    TB_EXP.Text = EXP.ToString();
                }
            }
            changingFields = false;
            updateStats();
        }

        private void updateDVs(object sender, EventArgs e)
        {
            if (changingFields || !initializedFields) return;

            if (sender != null && Util.ToInt32((sender as MaskedTextBox).Text) > 15)
                (sender as MaskedTextBox).Text = "15";

            changingFields = true;
            pk1.DV_ATK = Util.ToInt32(TB_ATKDV.Text);
            pk1.DV_DEF = Util.ToInt32(TB_DEFDV.Text);
            pk1.DV_SPD = Util.ToInt32(TB_SPDDV.Text);
            pk1.DV_SPC = Util.ToInt32(TB_SPCDV.Text);
            TB_HPDV.Text = pk1.DV_HP.ToString();

            changingFields = false;

            updateStats();
        }

        private void updateStatEXPs(object sender, EventArgs e)
        {
            if (changingFields || !initializedFields) return;

            if (sender != null && Util.ToInt32((sender as MaskedTextBox).Text) > 65535)
                (sender as MaskedTextBox).Text = "65535";

            changingFields = true;
            pk1.STATEXPs =
                new[] { TB_HPSTATEXP, TB_ATKSTATEXP, TB_DEFSTATEXP, TB_SPDSTATEXP, TB_SPCSTATEXP }.Select(
                    t => (ushort)Util.ToUInt32(t.Text)).ToArray();
            changingFields = false;

            updateStats();
        }

        private void updateOT(object sender, EventArgs e)
        {
            if (changingFields || !initializedFields) return;
            changingFields = true;

            if (!RBY_Encoding.Validate(TB_OT.Text))
                TB_OT.Text = RBY_Encoding.FixString(TB_OT.Text);

            pk1.OT_Name = RBY_Encoding.GetBytes(TB_OT.Text);
            changingFields = false;
        }

        private void updateNickname(object sender, EventArgs e)
        {
            if (changingFields || !initializedFields) return;
            changingFields = true;

            if (!RBY_Encoding.Validate(TB_Nickname.Text))
                TB_Nickname.Text = RBY_Encoding.FixString(TB_Nickname.Text);

            pk1.Nickname = RBY_Encoding.GetBytes(TB_Nickname.Text);
            changingFields = false;
        }

        private void updateStats()
        {
            pk1.CalculateStats();
            ushort[] stats = pk1.getStats();
            Stat_HP.Text = stats[0].ToString();
            Stat_ATK.Text = stats[1].ToString();
            Stat_DEF.Text = stats[2].ToString();
            Stat_SPD.Text = stats[3].ToString();
            Stat_SPC.Text = stats[4].ToString();
        }

        private void mainMenuOpen(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "PK1 File|*.pk1" +
                         "|SAV File|*.sav" +
                         "|DAT File|*.dat" +
                         "|BIN File|*.bin" +
                         "|All Files|*.*",
                RestoreDirectory = true,
                FilterIndex = 5,
            };

            if (ofd.ShowDialog() == DialogResult.OK)
                openFile(ofd.FileName);
        }
        private void mainMenuClose(object sender, EventArgs e)
        {
            Close();
        }

        public void openFile(string path)
        {
            string ext = Path.GetExtension(path);
            FileInfo fi = new FileInfo(path);
            if (fi.Length > 0x8000)
                Util.Error("Input file is too large.", path);
            else
            {
                byte[] input; try { input = File.ReadAllBytes(path); }
                catch { Util.Error("File is in use by another program!", path); return; }

                try { openFile(input, path, ext); }
                catch
                {
                    try
                    {
                        PokemonList empty = new PokemonList((byte[]) PokemonList.EMPTY_LIST.Clone())
                        {
                            [0] = {OT_Name = RBY_Encoding.GetBytes("Rhydon")},
                            [0] = {Nickname = RBY_Encoding.GetBytes("RHYDON")},
                            [0] = {TID = 12345},
                            [0] = {Species = 1},
                            [0] = {Level = 1}
                        };

                        openFile(empty.GetBytes(), path, ext);
                    }
                    catch { openFile(input, path, ext); }
                }
            }
        }

        private void openFile(byte[] input, string path, string ext)
        {
            // Fix case sensitivity with extensions
            ext = ext.ToLower();
            #region PK1
            if (input.Length == PokemonList.GetDataLength(PokemonList.CapacityType.Single))
            {
                if (new[] { ".pk1", "" }.Contains(ext) && input[0] == 1 && input[2] == 0xFF && input[1] == input[3])
                {
                    PopulateFields(new PokemonList(input)[0]);
                }
                else
                {
                    Util.Error("Unable to recognize file." + Environment.NewLine + "Only valid .pk1/.bin supported.", string.Format($"File Loaded:{Environment.NewLine}{path}"));
                }
            }
            else if (input.Length == 0x38 || input.Length == 0x43)
            {
                // Legacy PK1 from PKXDelta / PikaSav
                PopulateFieldsLegacy(input);
            }
            else if (input.Length == 0x8000)
            {
                if (ext != ".dat" && ext != ".sav")
                {
                    Util.Error("Unable to recognize file." + Environment.NewLine + "Only valid .sav/.dat supported.", string.Format($"File Loaded:{Environment.NewLine}{path}"));
                }
                saveLoaded = Menu_ExportSAV.Enabled = false;
                PopulateFields(new SAV1(input)
                {
                    FilePath = Path.GetDirectoryName(path),
                    FileName = Path.GetFileName(path)
                });
                foreach (TabPage tp in tabBoxMulti.TabPages)
                    tp.Enabled = true;
                saveLoaded = Menu_ExportSAV.Enabled = true;

                // Indicate audibly the save is loaded
                SystemSounds.Beep.Play();
            }
            #endregion
        }

        private void mainMenuSave(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PK1 File|*.pk1" +
                         "|BIN File|*.bin" +
                         "|All Files|*.*",
                DefaultExt = "pk1",
                FileName = TB_Nickname.Text + " - " + TB_OT.Text
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            string path = sfd.FileName;

            if (File.Exists(path))
            {
                // File already exists, save a .bak
                byte[] backupfile = File.ReadAllBytes(path);
                File.WriteAllBytes(path + ".bak", backupfile);
            }

            File.WriteAllBytes(path, new PokemonList(pk1).GetBytes());
        }

        private void clickBoxRight(object sender, EventArgs e)
        {
            sav.CurrentBox = PLC_Box.pokemonlist;
            CB_BoxSelect.SelectedIndex = (CB_BoxSelect.SelectedIndex + 1) % 12;
        }

        private void clickBoxLeft(object sender, EventArgs e)
        {
            sav.CurrentBox = PLC_Box.pokemonlist;
            CB_BoxSelect.SelectedIndex = (CB_BoxSelect.SelectedIndex + 11) % 12;
        }

        private void getBox(object sender, EventArgs e)
        {
            if (sender == CB_BoxSelect && saveLoaded)
                sav.CurrentBox = PLC_Box.pokemonlist;
            sav.Current_Box_Index = CB_BoxSelect.SelectedIndex;
            PLC_Box.SetList(sav.CurrentBox);
            TB_BoxIndex.Text = (sav.Current_Box_Index + 1).ToString("00");
        }

        private void clickExportSav(object sender, EventArgs e)
        {
            if (!Menu_ExportSAV.Enabled)
                return;

            sav.CurrentBox = PLC_Box.pokemonlist;
            sav.Party = PLC_Party.pokemonlist;
            sav.Daycare = PLC_DayCare.pokemonlist;

            sav.UpdateChecksum();

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "DAT file|*.dat|SAV File|*.sav",
                FileName = sav.FileName,
                RestoreDirectory = true,
                FilterIndex = Path.GetExtension(sav.FileName) == ".dat" ? 1 : 2
            };
            if (Directory.Exists(sav.FilePath))
                sfd.InitialDirectory = sav.FilePath;

            // Export
            if (sfd.ShowDialog() != DialogResult.OK) return;

            File.WriteAllBytes(sfd.FileName, sav.Data);
            Util.Alert("sav exported to:", sfd.FileName);
        }

        private void toggleUseOldSprites(object sender, EventArgs e)
        {
            Menu_UseOldSprites.Checked = !Menu_UseOldSprites.Checked;
            Util.UseFancySprites = !Menu_UseOldSprites.Checked;
            PLC_Box.updateAll();
            PLC_DayCare.updateAll();
            PLC_Party.updateAll();
            UpdateDragOutBox();
        }

        private void toggleModifyDex(object sender, EventArgs e)
        {
            modify_dex = Menu_ModifyDex.Checked;
        }

        private void updateSaveTrainerName(object sender, EventArgs e)
        {
            if (changingFields || !initializedFields) return;
            changingFields = true;

            if (!RBY_Encoding.Validate(TB_SaveName.Text))
                TB_SaveName.Text = RBY_Encoding.FixString(TB_SaveName.Text);

            sav.OT_Name = TB_SaveName.Text;
            changingFields = false;
        }

        private void updateRivalName(object sender, EventArgs e)
        {
            if (changingFields || !initializedFields) return;
            changingFields = true;

            if (!RBY_Encoding.Validate(TB_Rival.Text))
                TB_Rival.Text = RBY_Encoding.FixString(TB_Rival.Text);

            sav.Rival_Name = TB_Rival.Text;
            changingFields = false;
        }

        private void updateBadges(object sender, ItemCheckEventArgs e)
        {
            if (changingFields || !initializedFields) return;
            changingFields = true;
            bool[] new_badges = sav.Badges.Clone() as bool[];
            new_badges[e.Index] = e.NewValue == CheckState.Checked;

            sav.Badges = new_badges;
            changingFields = false;
        }

        private void updateMoney(object sender, EventArgs e)
        {
            if (changingFields || !initializedFields) return;
            changingFields = true;

            sav.Money = Util.ToInt32(TB_Money.Text).ToString("000000");

            changingFields = false;
        }

        private void updateCoins(object sender, EventArgs e)
        {
            if (changingFields || !initializedFields) return;
            changingFields = true;

            sav.Coins = Util.ToInt32(TB_Coins.Text).ToString("0000");

            changingFields = false;
        }

        private void updatePikachuFriendship(object sender, EventArgs e)
        {
            if (changingFields || !initializedFields) return;
            changingFields = true;

            uint val = Util.ToUInt32(TB_PikaFriend.Text);

            if (val > 255)
            {
                val = 255;
                TB_PikaFriend.Text = "255";
            }

            sav.Pika_Friendship = (byte)val;

            changingFields = false;
        }

        private void updateMovesPPs(object sender, EventArgs e)
        {
            if (changingFields || !initializedFields) return;

            changingFields = true;
            ComboBox[] moveBoxs = { CB_Move1, CB_Move2, CB_Move3, CB_Move4 };
            MaskedTextBox[] PPs = { TB_PP1, TB_PP2, TB_PP3, TB_PP4 };
            ComboBox[] PPus = { CB_PPu1, CB_PPu2, CB_PPu3, CB_PPu4 };

            pk1.Moves = moveBoxs.Select(cb => (byte)(int)cb.SelectedValue).ToArray();
            pk1.PPUPs = PPus.Select(cb => (byte)cb.SelectedIndex).ToArray();

            MaskedTextBox box = sender as MaskedTextBox;
            if (box != null)
            {
                int ind = Array.IndexOf(PPs, box);
                uint PP = Util.ToUInt32(PPs[ind].Text);
                if (PP > 63)
                    PP = 63;
                pk1.setPP(ind, (byte)PP);
                PPs[ind].Text = PP.ToString();
            }
            else
            {
                int ind = Math.Max(Array.IndexOf(moveBoxs, sender as ComboBox), Array.IndexOf(PPus, sender as ComboBox));
                int PP = Tables.getMovePP(pk1.Moves[ind], pk1.PPUPs[ind]);

                PPs[ind].Text = PP.ToString();
                pk1.setPP(ind, (byte)PP);
            }

            changingFields = false;
        }

        private void updateTID(object sender, EventArgs e)
        {
            if (changingFields || !initializedFields) return;

            changingFields = true;
            if (Util.ToUInt32(TB_TID.Text) > ushort.MaxValue) TB_TID.Text = "65535";

            pk1.TID = (ushort)Util.ToUInt32(TB_TID.Text);

            changingFields = false;
        }

        private void openOptionsForm(object sender, EventArgs e)
        {
            inChildForm = true;
            new SAV_Options(ref sav).ShowDialog(this);
            inChildForm = false;
        }

        private void updateTimePlayed(object sender, EventArgs e)
        {
            if (changingFields || !initializedFields) return;

            changingFields = true;

            int Hours = Util.ToInt32(MT_Hours.Text);
            int Mins = Util.ToInt32(MT_Minutes.Text);
            int Secs = Util.ToInt32(MT_Seconds.Text);

            if (Hours < 0)
                Hours = 0;
            if (Mins < 0)
                Mins = 0;
            if (Secs < 0)
                Secs = 0;
            if (Hours > ushort.MaxValue)
                Hours = ushort.MaxValue;
            if (Mins > 59)
                Mins = 59;
            if (Secs > 59)
                Secs = 59;
            if (Hours == ushort.MaxValue && (Mins > 0 || Secs > 0))
                Mins = Secs = 0;

            MT_Hours.Text = Hours.ToString();
            MT_Minutes.Text = Mins.ToString();
            MT_Seconds.Text = Secs.ToString();

            sav.Time_Played = new[] {Hours, Mins, Secs};

            changingFields = false;
        }

        private void openPokedexForm(object sender, EventArgs e)
        {
            inChildForm = true;
            new SAV_Pokedex(ref sav).ShowDialog(this);
            inChildForm = false;
        }

        private void openInventoryForm(object sender, EventArgs e)
        {
            inChildForm = true;
            new SAV_Inventory(ref sav).ShowDialog(this);
            inChildForm = false;
        }

    }
}
