using System;
using System.Windows.Forms;

namespace Rhydon.SAV
{
    public partial class SAV_Pokedex : Form
    {
        private SAV1 sav;

        internal const int MAX_SPECIES = 151;

        private bool initialized = false;

        private bool[] initial_seen = new bool[MAX_SPECIES];
        private bool[] initial_caught = new bool[MAX_SPECIES];
        public SAV_Pokedex(ref SAV1 source)
        {
            InitializeComponent();

            sav = source;

            foreach (int mon in Tables.Dex_To_ID)
            {
                if (mon != 0)
                {
                    CLB_Seen.Items.Add(Tables.ID_To_Name[mon]);
                    CLB_Caught.Items.Add(Tables.ID_To_Name[mon]);
                }
            }

            for (int i = 0; i < MAX_SPECIES; i++)
            {
                CLB_Seen.SetItemChecked(i, sav.Pokedex_Seen[i+1]);
                initial_seen[i] = sav.Pokedex_Seen[i + 1];
                CLB_Caught.SetItemChecked(i, sav.Pokedex_Caught[i+1]);
                initial_caught[i] = sav.Pokedex_Caught[i + 1];
            }
            initialized = true;
        }

        private void CLB_Seen_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!initialized) return;
            sav.Pokedex_Seen[e.Index + 1] = e.NewValue == CheckState.Checked;
        }

        private void CLB_Caught_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!initialized) return;
            sav.Pokedex_Caught[e.Index + 1] = e.NewValue == CheckState.Checked;
        }

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MAX_SPECIES; i++)
            {
                sav.Pokedex_Seen[i + 1] = initial_seen[i];
                sav.Pokedex_Caught[i + 1] = initial_caught[i];
            }
            Close();
        }

        private void B_Save_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void B_SeenAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MAX_SPECIES; i++)
                CLB_Seen.SetItemChecked(i, true);
        }

        private void B_SeenNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MAX_SPECIES; i++)
                CLB_Seen.SetItemChecked(i, false);
        }

        private void B_CaughtAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MAX_SPECIES; i++)
                CLB_Caught.SetItemChecked(i, true);
        }

        private void B_CaughtNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MAX_SPECIES; i++)
                CLB_Caught.SetItemChecked(i, false);
        }

    }
}
