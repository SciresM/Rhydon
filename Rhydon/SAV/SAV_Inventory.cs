using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rhydon.SAV
{
    public partial class SAV_Inventory : Form
    {
        private SAV1 sav;

        private ItemList inv;
        private ItemList stor;
        private bool loading;
        private bool updating;
        private bool initialized;

        private ItemList[] lists;

        public SAV_Inventory(ref SAV1 s)
        {
            InitializeComponent();

            sav = s;
            inv = sav.Items_Pocket;
            stor = sav.Items_PC;
            lists = new[] {inv, stor};
            CB_Storage.Items.AddRange(new []{"Inventory", "PC Storage"});
            CB_Storage.SelectedIndex = 0;
            initialized = true;
        }

        private void CB_Storage_SelectedIndexChanged(object sender, EventArgs e)
        {  
            updating = true;
            if (initialized)
                saveBag(lists[CB_Storage.SelectedIndex ^ 1]);
            updating = false;
            loading = true;
            populateList(lists[CB_Storage.SelectedIndex]);
            loading = false;
        }

        private void populateList(ItemList il)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            DataGridViewColumn dgvIndex = new DataGridViewTextBoxColumn();
            {
                dgvIndex.HeaderText = "CNT";
                dgvIndex.DisplayIndex = 1;
                dgvIndex.Width = 45;
                dgvIndex.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            DataGridViewComboBoxColumn dgvItemVal = new DataGridViewComboBoxColumn
            {
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                DisplayIndex = 0,
                Width = 135,
                FlatStyle = FlatStyle.Flat
            };
            foreach (string t in Tables.ID_To_ItemName.Where(s => !string.IsNullOrEmpty(s)).OrderBy(s => s))
                dgvItemVal.Items.Add(t);

            dataGridView1.Columns.Add(dgvItemVal);
            dataGridView1.Columns.Add(dgvIndex);

            dataGridView1.Rows.Add(il.getCapacity());
            dataGridView1.CancelEdit();

            for (int i = 0; i < il.getCapacity(); i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = Tables.getItemName(0);
                dataGridView1.Rows[i].Cells[1].Value = 0;
            }

            int cur_row = 0;
            for (int i = 0; i < il.getCapacity(); i++)
            {
                string new_item = Tables.getItemName(il[i].Index);
                if (dgvItemVal.Items.Contains(new_item))
                {
                    dataGridView1.Rows[cur_row].Cells[0].Value = Tables.getItemName(il[i].Index);
                    dataGridView1.Rows[cur_row].Cells[1].Value = il[i].Count;
                    cur_row++;
                }
                else
                    Util.Alert(new_item + " removed from item pouch.", "If you save changes the item will no longer be in the pouch.");
            }
        }

        private void saveBag(ItemList il)
        {
            int capacity = il.getCapacity();
            int count = 0;
            for (int i = 0; i < capacity; i++)
            {
                string item = dataGridView1.Rows[i].Cells[0].Value.ToString();
                if (item != Tables.getItemName(0))
                {
                    int item_index = Tables.getItemIndex(item);
                    int itemcnt;
                    try
                    { itemcnt = Convert.ToUInt16(dataGridView1.Rows[i].Cells[1].Value.ToString()); }
                    catch { itemcnt = 0; }
                    if (itemcnt == 0)
                        itemcnt++;
                    if (itemcnt > 99)
                        itemcnt = 99;

                    il[count].Index = (byte)item_index;
                    il[count].Count = (byte)itemcnt;
                    count++;
                }
            }
            for (int i = count; i < il.getCapacity(); i++)
            {
                il[i].Index = 0;
                il[i].Count = 0;
            }

            il.updateCount();
        }

        private void B_Save_Click(object sender, EventArgs e)
        {
            saveBag(lists[CB_Storage.SelectedIndex]);
            sav.Items_Pocket = inv;
            sav.Items_PC = stor;
            Close();
        }

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (updating || loading)
                return;
            int count = 0;
            for (int i = 0; i < lists[CB_Storage.SelectedIndex].getCapacity(); i++)
            {
                
            }
        }
    }
}
