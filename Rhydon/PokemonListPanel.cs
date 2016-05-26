using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Rhydon
{
    public sealed class PokemonListPanel : Panel
    {
        public PokemonList pokemonlist;
        private PictureBox[] PartySprites;
        private Label[] Pokemon;
        private int Capacity;
        private readonly string salt;
        private readonly ContextMenuStrip mnu;

        public PokemonListPanel(PokemonList pl, ContextMenuStrip cms, int num_visible = 6)
        {
            pokemonlist = pl;
            mnu = cms ?? new ContextMenuStrip();
            Capacity = pokemonlist.GetCapacity();
            PartySprites = new PictureBox[Capacity];
            Pokemon = new Label[Capacity];

            salt = string.Empty;

            mnu.Items[0].Click += HandleView;
            mnu.Items[1].Click += HandleSet;
            mnu.Items[2].Click += HandleDelete;

            AutoScroll = true;
            Size = MaximumSize = MinimumSize = new Size(191, 26*num_visible);
            Location = new Point(5, 20);
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;

            if (Capacity == 30)
                Console.WriteLine("JP Box.");

            for (int i = 0; i < Capacity; i++)
            {
                PartySprites[i] = new PictureBox
                {
                    Size = new Size(16, 16),
                    Location = new Point(10, 5 + i*26),
                    Name = salt + salt + "_" + i,
                    ContextMenuStrip = mnu,
                    Tag = pokemonlist,
                    AllowDrop = true
                };
                PartySprites[i].DragEnter += HandleDragEnter;
                PartySprites[i].DragDrop += HandleDragDrop;
                PartySprites[i].MouseDown += HandleMouseDown;

                Pokemon[i] = new Label
                {
                    Font = Util.Pokered_US,
                    AutoSize = true,
                    Location = new Point(31, 5 + i*26),
                    Name = salt + salt + "_" + i,
                    ContextMenuStrip = mnu,
                    Tag = pokemonlist,
                    AllowDrop = true
                };
                Pokemon[i].DragEnter += HandleDragEnter;
                Pokemon[i].DragDrop += HandleDragDrop;
                Pokemon[i].MouseDown += HandleMouseDown;

                Controls.Add(PartySprites[i]);
                Controls.Add(Pokemon[i]);
            }

            for (int i = 0; i < pokemonlist.Count; i++)
            {
                update(i);
            }
        }

        public void SetList(PokemonList pl)
        {
            pokemonlist = pl;
            int old_cap = Capacity;
            Capacity = pokemonlist.GetCapacity();
            if (Capacity != old_cap)
            {
                Size = MaximumSize = MinimumSize = new Size(191, 26 * Math.Min(6, Capacity));
                PartySprites = new PictureBox[Capacity];
                Pokemon = new Label[Capacity];
                Controls.Clear();
                for (int i = 0; i < Capacity; i++)
                {
                    PartySprites[i] = new PictureBox
                    {
                        Size = new Size(16, 16),
                        Location = new Point(10, 5 + i*26),
                        Name = salt + "_" + i,
                        ContextMenuStrip = mnu,
                        Tag = pokemonlist,
                        AllowDrop = true
                    };
                    PartySprites[i].DragEnter += HandleDragEnter;
                    PartySprites[i].DragDrop += HandleDragDrop;
                    PartySprites[i].MouseDown += HandleMouseDown;

                    Pokemon[i] = new Label
                    {
                        Font = Util.Pokered_US,
                        AutoSize = true,
                        Location = new Point(31, 5 + i*26),
                        Name = salt + "_" + i,
                        ContextMenuStrip = mnu,
                        Tag = pokemonlist,
                        AllowDrop = true
                    };
                    Pokemon[i].DragEnter += HandleDragEnter;
                    Pokemon[i].DragDrop += HandleDragDrop;
                    Pokemon[i].MouseDown += HandleMouseDown;

                    Controls.Add(PartySprites[i]);
                    Controls.Add(Pokemon[i]);
                }
            }
            for (int i = 0; i < Capacity; i++)
                update(i);
        }

        public void updateAll()
        {
            for (int i = 0; i < Capacity; i++)
                update(i);
        }

        private void update(int i)
        {
            if (i < pokemonlist.Count)
            {
                PartySprites[i].Image = Util.GetPartySprite(pokemonlist[i]);
                Pokemon[i].Text = RBY_Encoding.GetString(pokemonlist[i].Nickname, pokemonlist[i] is JPK1);  
            }
            else
            {
                Pokemon[i].Text = "(None)";
                PartySprites[i].Image = new Bitmap(16, 16);
            }
        }

        private int getSlot(object sender)
        {
            sender = ((sender as ToolStripItem)?.GetCurrentParent() as ContextMenuStrip)?.SourceControl ?? sender as Control;
            return int.Parse((sender as Control).Name.TrimStart('_'));
        }

        private void set(int index, PK1 to_set)
        {
            if (index < pokemonlist.Count)
            {
                pokemonlist[index] = to_set;
                update(index);
            }
            else
            {
                pokemonlist.Count++;
                pokemonlist[pokemonlist.Count - 1] = to_set;
                update(pokemonlist.Count - 1);
            }
        }

        private void HandleSet(object sender, EventArgs e)
        {
            int index = getSlot(sender);
            MainForm mf = FindForm() as MainForm;
            PK1 to_set = mf.pk1;
            PokemonListPanel PLC = (((sender as ToolStripItem)?.GetCurrentParent() as ContextMenuStrip)?.SourceControl).Parent as PokemonListPanel;
            if (PLC == this)
            {
                PLC.set(index, to_set);
                if (mf.modify_dex)
                    mf.sav.Pokedex_Seen[Tables.ID_To_Dex[to_set.Species]] =
                        mf.sav.Pokedex_Caught[Tables.ID_To_Dex[to_set.Species]] = true;
            }
        }

        private void view(int index, MainForm mf)
        {
            if (index < pokemonlist.Count)
                mf.PopulateFields(pokemonlist[index]);
        }

        private void HandleView(object sender, EventArgs e)
        {
            int index = getSlot(sender);
            MainForm mf = FindForm() as MainForm;
            PokemonListPanel PLC =
                (((sender as ToolStripItem)?.GetCurrentParent() as ContextMenuStrip)?.SourceControl).Parent as
                    PokemonListPanel;
            if (PLC == this)
                PLC.view(index, mf);
        }

        private void delete(int index)
        {
            if (index < pokemonlist.Count)
            {
                pokemonlist.Count--;
                for (int i = index; i <= pokemonlist.Count; i++)
                {
                    if (i + 1 < Capacity)
                    {
                        pokemonlist[i] = pokemonlist[i + 1];
                    }
                    update(i);
                }
            }
        }

        private void HandleDelete(object sender, EventArgs e)
        {
            int index = getSlot(sender);
            PokemonListPanel PLC =
                (((sender as ToolStripItem)?.GetCurrentParent() as ContextMenuStrip)?.SourceControl).Parent as
                    PokemonListPanel;
            if (PLC == this)
                PLC.delete(index);
        }

        private void HandleDragDrop(object sender, DragEventArgs e)
        {
            Control c = sender as Control;
            if (!(c.FindForm() is MainForm))
                return;
            MainForm mf = c.FindForm() as MainForm;
            if (mf.getInChildForm())
                return;
            if (!(c.Parent is PokemonListPanel))
                return;
            PokemonListPanel parent = c.Parent as PokemonListPanel;
            int slot = getSlot(sender);

            // Check for In-Dropped files
            object[] files = (object[])e.Data.GetData(DataFormats.FileDrop);
            if (e.Effect == DragDropEffects.Copy)
            {
                if (files.Length <= 0)
                    return;
                FileInfo fi = new FileInfo((string)files[0]);
                if ((int) fi.Length == PokemonList.GetDataLength(PokemonList.CapacityType.Single) && !mf.JP_Mode)
                {
                    byte[] data = File.ReadAllBytes((string) files[0]);
                    if (data[0] == 1 && data[2] == 0xFF && data[1] == data[3]) // PK1
                    {
                        parent.set(slot, new PokemonList(data)[0]);
                    }
                    else
                    {
                        mf.openFile((string)files[0]);
                    }
                }
                else if ((int) fi.Length == PokemonList.GetDataLength(PokemonList.CapacityType.Single, true) && mf.JP_Mode)
                {
                    byte[] data = File.ReadAllBytes((string)files[0]);
                    if (data[0] == 1 && data[2] == 0xFF && data[1] == data[3]) // JPK1
                    {
                        parent.set(slot, new PokemonList(data, PokemonList.CapacityType.Single, true)[0]);
                    }
                    else
                    {
                        mf.openFile((string)files[0]);
                    }
                }
                else
                {
                    mf.openFile((string)files[0]);
                }
            }
            else if (e.Effect == DragDropEffects.Move)
            {
                if (files.Length != 1)
                    return;
                if (sender_parent == null)
                {
                    FileInfo fi = new FileInfo((string)files[0]);
                    if ((int)fi.Length == PokemonList.GetDataLength(PokemonList.CapacityType.Single) && !mf.JP_Mode)
                    {
                        byte[] data = File.ReadAllBytes((string)files[0]);
                        if (data[0] == 1 && data[2] == 0xFF && data[1] == data[3]) // PK1
                        {
                            parent.set(slot, new PokemonList(data)[0]);
                        }
                        else
                        {
                            mf.openFile((string)files[0]);
                        }
                    }
                    else if ((int)fi.Length == PokemonList.GetDataLength(PokemonList.CapacityType.Single, true) && mf.JP_Mode)
                    {
                        byte[] data = File.ReadAllBytes((string)files[0]);
                        if (data[0] == 1 && data[2] == 0xFF && data[1] == data[3]) // JPK1
                        {
                            parent.set(slot, new PokemonList(data, PokemonList.CapacityType.Single, true)[0]);
                        }
                        else
                        {
                            mf.openFile((string)files[0]);
                        }
                    }
                    else
                    {
                        mf.openFile((string)files[0]);
                    }
                }
                else
                {
                    PK1 temp = parent.pokemonlist[slot];
                    int count = parent.pokemonlist.Count;
                    parent.set(slot, sender_parent.pokemonlist[sender_slot]);
                    if (slot < count)
                        sender_parent.set(sender_slot, temp);
                }
            }
        }

        private void HandleDragEnter(object sender, DragEventArgs e)
        {
            if (e.AllowedEffect == (DragDropEffects.Copy | DragDropEffects.Link)) // external file
                e.Effect = DragDropEffects.Copy;
            else if (e.Data != null) // within
                e.Effect = DragDropEffects.Move;
        }

        private void HandleMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.Clicks != 1) return;

            Console.WriteLine("HandleMouseDown");

            Control c = sender as Control;
            if (!(c.FindForm() is MainForm))
                return;
            MainForm mf = c.FindForm() as MainForm;
            if (mf.getInChildForm())
                return;
            if (!(c.Parent is PokemonListPanel))
                return;
            PokemonListPanel parent = c.Parent as PokemonListPanel;
            int index = getSlot(sender);

            if (index >= parent.pokemonlist.Count)
                return;
            Cursor.Current = Cursors.Hand;

            byte[] dragdata = new PokemonList(parent.pokemonlist[index]).GetBytes();


            string filename = RBY_Encoding.GetString(parent.pokemonlist[index].Nickname, parent.pokemonlist[index] is JPK1) + " - " +
                              RBY_Encoding.GetString(parent.pokemonlist[index].OT_Name, parent.pokemonlist[index] is JPK1) + (parent.pokemonlist[index] is JPK1 ? ".jpk1" : ".pk1");

            string newfile = Path.Combine(Path.GetTempPath(), Util.CleanFileName(filename));
            try
            {
                File.WriteAllBytes(newfile, dragdata);
                sender_parent = parent;
                sender_slot = index;
                DoDragDrop(new DataObject(DataFormats.FileDrop, new [] { newfile }), DragDropEffects.Move);
                
            }
            catch (ArgumentException x)
            { Util.Error("Drag & Drop Error:", x.ToString()); }
            File.Delete(newfile);
            sender_slot = 0;
            sender_parent = null;
        }

        private static PokemonListPanel sender_parent;
        private static int sender_slot;
    }
}
