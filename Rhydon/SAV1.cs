using System;
using System.Globalization;
using System.Linq;

namespace Rhydon
{
    public class SAV1
    {
        private const int OT_NAME_OFS = 0x2598;
        private const int POKEDEX_OWNED_OFS = 0x25A3;
        private const int POKEDEX_SEEN_OFS = 0x25B6;
        private const int ITEM_LIST_OFS = 0x25C9;
        private const int MONEY_OFS = 0x25F3;
        private const int RIVAL_NAME_OFS = 0x25F6;
        private const int OPTIONS_OFS = 0x2601;
        private const int BADGE_OFS = 0x2602;
        private const int TID_OFS = 0x2605;
        private const int FRIENDSHIP_OFS = 0x271C;
        private const int PC_ITEM_LIST_OFS = 0x27E6;
        private const int CURRENT_BOX_INDEX_OFS = 0x284C;
        private const int COINS_OFS = 0x2850;
        private const int TIME_OFS = 0x2CED;
        private const int DAYCARE_OFS = 0x2CF4;
        private const int PARTY_OFS = 0x2F2C;
        private const int CURRENT_BOX_OFS = 0x30C0;
        private const int CHECKSUM_OFS = 0x3523;
        private readonly int[] BOX_OFS = {0x4000, 0x4462, 0x48C4, 0x4D26, 0x5188, 0x55EA, 0x6000, 0x6462, 0x68C4, 0x6D26, 0x7188, 0x75EA};

        public SAV1(byte[] d)
        {
            if (d == null)
            {
                throw new ArgumentException("SAV file cannot be null.");
            }
            Data = d;

            Pokedex_Seen = new Pokedex(ref Data, POKEDEX_SEEN_OFS);
            Pokedex_Caught = new Pokedex(ref Data, POKEDEX_OWNED_OFS);

            Items_Pocket = new ItemList(Data.Skip(ITEM_LIST_OFS).Take(2 * (Data[ITEM_LIST_OFS] + 1)).ToArray(), 20);
            Items_PC = new ItemList(Data.Skip(PC_ITEM_LIST_OFS).Take(2 * (Data[PC_ITEM_LIST_OFS] + 1)).ToArray(), 50);
        }
        public readonly byte[] Data;
        public string FileName;
        public string FilePath;

        public string OT_Name
        {
            get { return RBY_Encoding.GetString(Data.Skip(OT_NAME_OFS).Take(0xB).ToArray()); }
            set
            {
                string s = value;
                if (!RBY_Encoding.Validate(s))
                    s = RBY_Encoding.FixString(s);
                RBY_Encoding.GetBytes(s).CopyTo(Data, OT_NAME_OFS);
            }
        }

        public string Rival_Name
        {
            get { return RBY_Encoding.GetString(Data.Skip(RIVAL_NAME_OFS).Take(0xB).ToArray()); }
            set
            {
                string s = value;
                if (!RBY_Encoding.Validate(s))
                    s = RBY_Encoding.FixString(s);
                RBY_Encoding.GetBytes(s).CopyTo(Data, RIVAL_NAME_OFS);
            }
        }

        public bool[] Badges
        {
            get
            {
                bool[] b = new bool[8];
                for (int i = 0; i < b.Length; i++)
                    b[i] = (Data[BADGE_OFS] & (0x1 << i)) != 0;
                return b;
            }
            set
            {
                if (value == null || value.Length != 8)
                    return;
                for (int i = 0; i < value.Length; i++)
                    Data[BADGE_OFS] = (byte)((Data[BADGE_OFS] & ~(0x1 << i)) | ((value[i] ? 0x1 : 0) << i));
            }
        }

        public int[] Time_Played
        {
            get { return new[] {(int) BitConverter.ToUInt16(Data, TIME_OFS), Data[TIME_OFS + 2], Data[TIME_OFS + 3]}; }
            set
            {
                if (value == null || value.Length != 3) return;
                BitConverter.GetBytes((ushort)value[0]).CopyTo(Data, TIME_OFS);
                Data[TIME_OFS + 2] = (byte) value[1];
                Data[TIME_OFS + 3] = (byte) value[2];
            }
        }

        public byte Pika_Friendship
        {
            get { return Data[FRIENDSHIP_OFS]; }
            set { Data[FRIENDSHIP_OFS] = value; }
        }

        public string Money
        {
            get { return (Util.ToUInt32(Data, MONEY_OFS) >> 8).ToString("X6"); }
            set { Util.GetBytes(uint.Parse(value, NumberStyles.HexNumber)).Skip(1).ToArray().CopyTo(Data, MONEY_OFS); }
        }

        public string Coins
        {
            get { return Util.ToUInt16(Data, COINS_OFS).ToString("X4"); }
            set { Util.GetBytes(ushort.Parse(value, NumberStyles.HexNumber)).CopyTo(Data, COINS_OFS); }
        }

        public Pokedex Pokedex_Seen;
        public Pokedex Pokedex_Caught;

        public ItemList Items_Pocket
        {
            get
            {
                var count = 20;
                return new ItemList(Data.Skip(ITEM_LIST_OFS).Take(2 * (count + 1)).ToArray(), count);
            }
            set { value.getBytes().CopyTo(Data, ITEM_LIST_OFS); }
        }

        public ItemList Items_PC
        {
            get
            {
                var count = 50;
                return new ItemList(Data.Skip(PC_ITEM_LIST_OFS).Take(2 * (count + 1)).ToArray(), count);
            }
            set { value.getBytes().CopyTo(Data, PC_ITEM_LIST_OFS); }
        }

        public int Current_Box_Index
        {
            get { return Data[CURRENT_BOX_INDEX_OFS] & 0x7F; }
            set
            {
                byte v = (byte)(value % 12);
                Array.Copy(Data, CURRENT_BOX_OFS, Data, Current_Stored_Box_Offset, PokemonList.GetDataLength(PokemonList.CapacityType.Stored));
                Data[CURRENT_BOX_INDEX_OFS] = (byte)((Data[CURRENT_BOX_INDEX_OFS] & 0x80) | (v & 0x7F));
                Array.Copy(Data, Current_Stored_Box_Offset, Data, CURRENT_BOX_OFS, PokemonList.GetDataLength(PokemonList.CapacityType.Stored));
            }
        }

        public int Current_Stored_Box_Offset
        {
            get { return BOX_OFS[Current_Box_Index]; }
            set { return; }
        }

        public bool BattleEffects
        {
            get { return (Data[OPTIONS_OFS] & 0x80) == 0; }
            set { Data[OPTIONS_OFS] = (byte)((Data[OPTIONS_OFS] & 0x7F) | (value ? 0 : 0x80)); }
        }

        public bool BattleStyleSwitch
        {
            get { return (Data[OPTIONS_OFS] & 0x40) == 0; }
            set { Data[OPTIONS_OFS] = (byte)((Data[OPTIONS_OFS] & 0xBF) | (value ? 0 : 0x40)); }
        }

        public int Sound
        {
            get { return (Data[OPTIONS_OFS] & 0x30) >> 4; }
            set
            {
                var new_sound = value;
                if (new_sound > 3)
                    new_sound = 3;
                if (new_sound < 0)
                    new_sound = 0;
                Data[OPTIONS_OFS] = (byte) ((Data[OPTIONS_OFS] & 0xCF) | (new_sound << 4));
            }
        }

        public int TextSpeed
        {
            get { return Data[OPTIONS_OFS] & 0x7; }
            set
            {
                var new_speed = value;
                if (new_speed > 7)
                    new_speed = 7;
                if (new_speed < 0)
                    new_speed = 0;
                Data[OPTIONS_OFS] = (byte)((Data[OPTIONS_OFS] & 0xF8) | new_speed);
            }
        }

        public PokemonList CurrentBox
        {
            get
            {
                return
                  new PokemonList(
                      Data.Skip(CURRENT_BOX_OFS)
                          .Take(PokemonList.GetDataLength(PokemonList.CapacityType.Stored))
                          .ToArray(), PokemonList.CapacityType.Stored);
            }
            set { byte[] v = value.GetBytes(); Array.Copy(v, 0, Data, CURRENT_BOX_OFS, v.Length); }
        }

        public PokemonList Party
        {
            get
            {
                return
                    new PokemonList(
                        Data.Skip(PARTY_OFS)
                            .Take(PokemonList.GetDataLength(PokemonList.CapacityType.Party))
                            .ToArray(), PokemonList.CapacityType.Party);
            }
            set
            {
                byte[] v = value.GetBytes();
                Array.Copy(v, 0, Data, PARTY_OFS, v.Length);
            }
        }

        public PokemonList Daycare
        {
            get
            {
                byte[] dc = Data.Skip(DAYCARE_OFS).Take(0x38).ToArray();
                byte[] fake_list = new byte[PokemonList.GetDataLength(PokemonList.CapacityType.Daycare)];
                fake_list[0] = dc[0];
                int name_ofs = 2 + PokemonList.getCapacity(PokemonList.CapacityType.Daycare) + PokemonList.getCapacity(PokemonList.CapacityType.Daycare) * PokemonList.getEntrySize(PokemonList.CapacityType.Daycare);
                Array.Copy(dc, 1, fake_list, name_ofs + 0xB, 0xB);
                Array.Copy(dc, 0xC, fake_list, name_ofs, 0xB);
                Array.Copy(dc, 1 + 0xB + 0xB, fake_list, 2 + PokemonList.getCapacity(PokemonList.CapacityType.Daycare), PokemonList.getEntrySize(PokemonList.CapacityType.Daycare));
                return new PokemonList(fake_list, PokemonList.CapacityType.Daycare);
            }
            set
            {
                byte[] fake_list = value.GetBytes();
                byte[] dc = new byte[0x38];
                dc[0] = fake_list[0];
                int name_ofs = 2 + PokemonList.getCapacity(PokemonList.CapacityType.Daycare) + PokemonList.getCapacity(PokemonList.CapacityType.Daycare) * PokemonList.getEntrySize(PokemonList.CapacityType.Daycare);
                Array.Copy(fake_list, name_ofs + 0xB, dc, 1, 0xB);
                Array.Copy(fake_list, name_ofs, dc, 0xC, 0xB);
                Array.Copy(fake_list, 2 + PokemonList.getCapacity(PokemonList.CapacityType.Daycare), dc, 1 + 0xB + 0xB, PokemonList.getEntrySize(PokemonList.CapacityType.Daycare));

                Array.Copy(dc, 0, Data, DAYCARE_OFS, dc.Length);
            }
        }

        public void UpdateChecksum()
        {
            Data[CHECKSUM_OFS] = 0;
            uint chksum = 0;
            for (int i = 0x2598; i <= 0x3522; i++)
            {
                chksum += Data[i];
            }

            chksum = ~chksum;
            chksum &= 0xFF;

            Data[CHECKSUM_OFS] = (byte) chksum;
        }

        public class Pokedex
        {
            private const int MAX_SPECIES = 151;
            private readonly byte[] saveData;
            private readonly int ofs;

            public Pokedex(ref byte[] d, int offset)
            {
                saveData = d;
                ofs = offset;
            }

            public bool this[int i]
            {
                get
                {
                    int ind = i - 1;
                    if (ind < 0 || ind > MAX_SPECIES)
                        throw new IndexOutOfRangeException("Invalid Pokedex Index");
                    return ((saveData[ofs + (ind >> 3)] >> (ind & 7)) & 1) == 1;
                }
                set
                {
                    int ind = i - 1;
                    if (ind < 0 || ind > MAX_SPECIES)
                        throw new IndexOutOfRangeException("Invalid Pokedex Index");
                    byte val = saveData[ofs + (ind >> 3)];
                    val &= (byte)~(1 << (ind & 7));
                    val |= (byte)((value ? 1 : 0) << (ind & 7));
                    saveData[ofs + (ind >> 3)] = val;
                }
            }
        }
    }
}
