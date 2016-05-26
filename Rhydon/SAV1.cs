using System;
using System.Globalization;
using System.Linq;

namespace Rhydon
{
    public abstract class SAV1
    {
        public virtual int OT_NAME_OFS { get; }
        public virtual int POKEDEX_OWNED_OFS { get; }
        public virtual int POKEDEX_SEEN_OFS { get; }
        public virtual int ITEM_LIST_OFS { get; }
        public virtual int MONEY_OFS { get; }
        public virtual int RIVAL_NAME_OFS { get; }
        public virtual int OPTIONS_OFS { get; }
        public virtual int BADGE_OFS { get; }
        public virtual int TID_OFS { get; }
        public virtual int FRIENDSHIP_OFS { get; }
        public virtual int PC_ITEM_LIST_OFS { get; }
        public virtual int CURRENT_BOX_INDEX_OFS { get; }
        public virtual int COINS_OFS { get; }
        public virtual int TIME_OFS { get; }
        public virtual int DAYCARE_OFS { get; }
        public virtual int PARTY_OFS { get; }
        public virtual int CURRENT_BOX_OFS { get; }
        public virtual int CHECKSUM_OFS { get; }

        public virtual int[] BOX_OFS { get; }

        public virtual bool IS_JAPANESE { get; }

        public virtual int NUM_BOXES { get; }

        public virtual int STR_LEN { get; }

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
            get { return RBY_Encoding.GetString(Data.Skip(OT_NAME_OFS).Take(STR_LEN).ToArray(), IS_JAPANESE); }
            set
            {
                string s = value;
                if (!RBY_Encoding.Validate(s, IS_JAPANESE))
                    s = RBY_Encoding.FixString(s, IS_JAPANESE);
                RBY_Encoding.GetBytes(s, IS_JAPANESE).CopyTo(Data, OT_NAME_OFS);
            }
        }

        public string Rival_Name
        {
            get { return RBY_Encoding.GetString(Data.Skip(RIVAL_NAME_OFS).Take(STR_LEN).ToArray(), IS_JAPANESE); }
            set
            {
                string s = value;
                if (!RBY_Encoding.Validate(s, IS_JAPANESE))
                    s = RBY_Encoding.FixString(s, IS_JAPANESE);
                RBY_Encoding.GetBytes(s, IS_JAPANESE).CopyTo(Data, RIVAL_NAME_OFS);
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
            get { return new[] { (int)BitConverter.ToUInt16(Data, TIME_OFS), Data[TIME_OFS + 2], Data[TIME_OFS + 3] }; }
            set
            {
                if (value == null || value.Length != 3) return;
                BitConverter.GetBytes((ushort)value[0]).CopyTo(Data, TIME_OFS);
                Data[TIME_OFS + 2] = (byte)value[1];
                Data[TIME_OFS + 3] = (byte)value[2];
            }
        }

        public ushort TID
        {
            get { return Util.ToUInt16(Data, TID_OFS); }
            set { Util.GetBytes(value).CopyTo(Data, TID_OFS); }
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
                byte v = (byte)(value % NUM_BOXES);
                Array.Copy(Data, CURRENT_BOX_OFS, Data, Current_Stored_Box_Offset, PokemonList.GetDataLength(IS_JAPANESE ? PokemonList.CapacityType.Stored_JP : PokemonList.CapacityType.Stored, IS_JAPANESE));
                Data[CURRENT_BOX_INDEX_OFS] = (byte)((Data[CURRENT_BOX_INDEX_OFS] & 0x80) | (v & 0x7F));
                Array.Copy(Data, Current_Stored_Box_Offset, Data, CURRENT_BOX_OFS, PokemonList.GetDataLength(IS_JAPANESE ? PokemonList.CapacityType.Stored_JP : PokemonList.CapacityType.Stored, IS_JAPANESE));
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
                Data[OPTIONS_OFS] = (byte)((Data[OPTIONS_OFS] & 0xCF) | (new_sound << 4));
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
                          .Take(PokemonList.GetDataLength(IS_JAPANESE ? PokemonList.CapacityType.Stored_JP : PokemonList.CapacityType.Stored, IS_JAPANESE))
                          .ToArray(), IS_JAPANESE ? PokemonList.CapacityType.Stored_JP : PokemonList.CapacityType.Stored, IS_JAPANESE);
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
                            .Take(PokemonList.GetDataLength(PokemonList.CapacityType.Party, IS_JAPANESE))
                            .ToArray(), PokemonList.CapacityType.Party, IS_JAPANESE);
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
                byte[] fake_list = new byte[PokemonList.GetDataLength(PokemonList.CapacityType.Daycare, IS_JAPANESE)];
                fake_list[0] = dc[0];
                int name_ofs = 2 + PokemonList.getCapacity(PokemonList.CapacityType.Daycare) + PokemonList.getCapacity(PokemonList.CapacityType.Daycare) * PokemonList.getEntrySize(PokemonList.CapacityType.Daycare);
                Array.Copy(dc, 1, fake_list, name_ofs + STR_LEN, STR_LEN);
                Array.Copy(dc, 1 + STR_LEN, fake_list, name_ofs, STR_LEN);
                Array.Copy(dc, 1 + STR_LEN + STR_LEN, fake_list, 2 + PokemonList.getCapacity(PokemonList.CapacityType.Daycare), PokemonList.getEntrySize(PokemonList.CapacityType.Daycare));
                return new PokemonList(fake_list, PokemonList.CapacityType.Daycare, IS_JAPANESE);
            }
            set
            {
                byte[] fake_list = value.GetBytes();
                byte[] dc = new byte[1 + 2*STR_LEN + PK1.SIZE_STORED];
                dc[0] = fake_list[0];
                int name_ofs = 2 + PokemonList.getCapacity(PokemonList.CapacityType.Daycare) + PokemonList.getCapacity(PokemonList.CapacityType.Daycare) * PokemonList.getEntrySize(PokemonList.CapacityType.Daycare);
                Array.Copy(fake_list, name_ofs + STR_LEN, dc, 1, STR_LEN);
                Array.Copy(fake_list, name_ofs, dc, 1 + STR_LEN, STR_LEN);
                Array.Copy(fake_list, 2 + PokemonList.getCapacity(PokemonList.CapacityType.Daycare), dc, 1 + STR_LEN + STR_LEN, PokemonList.getEntrySize(PokemonList.CapacityType.Daycare));

                Array.Copy(dc, 0, Data, DAYCARE_OFS, dc.Length);
            }
        }

        public void UpdateChecksum()
        {
            Data[CHECKSUM_OFS] = 0;
            uint chksum = 0;
            for (int i = 0x2598; i < CHECKSUM_OFS; i++)
            {
                chksum += Data[i];
            }

            chksum = ~chksum;
            chksum &= 0xFF;

            Data[CHECKSUM_OFS] = (byte)chksum;
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

        public static bool IsJapanese(byte[] d)
        {
            if (d == null)
            {
                throw new ArgumentException("SAV file cannot be null.");
            }

            foreach (int ofs in JSAV1.GetBoxOffsets())
            {
                byte num_entries = d[ofs];
                if (num_entries > 30 || d[ofs + 1 + num_entries] != 0xFF)
                    return false;
            }

            return true;
        }

        public static bool IsAmerican(byte[] d)
        {
            if (d == null)
            {
                throw new ArgumentException("SAV file cannot be null.");
            }
            foreach (int ofs in USAV1.GetBoxOffsets())
            {
                byte num_entries = d[ofs];
                if (num_entries > 20 || d[ofs + 1 + num_entries] != 0xFF)
                    return false;
            }
            return true;
        }
    }

    public class JSAV1 : SAV1
    {
        public override int OT_NAME_OFS { get { return 0x2598; } }
        public override int POKEDEX_OWNED_OFS { get { return 0x259E; } }
        public override int POKEDEX_SEEN_OFS { get { return 0x25B1; } }
        public override int ITEM_LIST_OFS { get { return 0x25C4; } }
        public override int MONEY_OFS { get { return 0x25EE; } }
        public override int RIVAL_NAME_OFS { get { return 0x25F1; } }
        public override int OPTIONS_OFS { get { return 0x25F7; } }
        public override int BADGE_OFS { get { return 0x25F8; } }
        public override int TID_OFS { get { return 0x25FB; } }
        public override int FRIENDSHIP_OFS { get { return 0x2712; } }
        public override int PC_ITEM_LIST_OFS { get { return 0x27DC; } }
        public override int CURRENT_BOX_INDEX_OFS { get { return 0x2842; } }
        public override int COINS_OFS { get { return 0x2846; } }
        public override int TIME_OFS { get { return 0x2CA0; } }
        public override int DAYCARE_OFS { get { return 0x2CA7; } }
        public override int PARTY_OFS { get { return 0x2ED5; } }
        public override int CURRENT_BOX_OFS { get { return 0x302D; } }
        public override int CHECKSUM_OFS { get { return 0x3594; } }

        public override bool IS_JAPANESE { get { return true; } }

        public override int NUM_BOXES { get { return 8; } }

        public override int STR_LEN { get { return 6; } }

        public override int[] BOX_OFS
        {
            get
            {
                int[] offsets =
                {
                    0x4000, 0x4566, 0x4ACC, 0x5032, 0x6000, 0x6566, 0x6ACC, 0x7032
                };
                return offsets;
            }
        }

        public JSAV1(byte[] d) : base(d)
        {

        }

        public static int[] GetBoxOffsets()
        {
            return new[] { 0x4000, 0x4566, 0x4ACC, 0x5032, 0x6000, 0x6566, 0x6ACC, 0x7032 };
        }
    }

    public class USAV1 : SAV1
    {
        public override int OT_NAME_OFS { get { return 0x2598; } }
        public override int POKEDEX_OWNED_OFS { get { return 0x25A3; } }
        public override int POKEDEX_SEEN_OFS { get { return 0x25B6; } }
        public override int ITEM_LIST_OFS { get { return 0x25C9; } }
        public override int MONEY_OFS { get { return 0x25F3; } }
        public override int RIVAL_NAME_OFS { get { return 0x25F6; } }
        public override int OPTIONS_OFS { get { return 0x2601; } }
        public override int BADGE_OFS { get { return 0x2602; } }
        public override int TID_OFS { get { return 0x2605; } }
        public override int FRIENDSHIP_OFS { get { return 0x271C; } }
        public override int PC_ITEM_LIST_OFS { get { return 0x27E6; } }
        public override int CURRENT_BOX_INDEX_OFS { get { return 0x284C; } }
        public override int COINS_OFS { get { return 0x2850; } }
        public override int TIME_OFS { get { return 0x2CED; } }
        public override int DAYCARE_OFS { get { return 0x2CF4; } }
        public override int PARTY_OFS { get { return 0x2F2C; } }
        public override int CURRENT_BOX_OFS { get { return 0x30C0; } }
        public override int CHECKSUM_OFS { get { return 0x3523; } }

        public override bool IS_JAPANESE { get { return false; } }

        public override int NUM_BOXES { get { return 12; } }

        public override int STR_LEN { get { return 11; } }

        public override int[] BOX_OFS
        {
            get
            {
                int[] offsets =
                {
                    0x4000, 0x4462, 0x48C4, 0x4D26, 0x5188, 0x55EA, 0x6000, 0x6462, 0x68C4, 0x6D26, 0x7188,
                    0x75EA
                };
                return offsets;
            }
        }


        public USAV1(byte[] d) : base(d)
        {

        }

        public static int[] GetBoxOffsets()
        {
            return new[] { 0x4000, 0x4462, 0x48C4, 0x4D26, 0x5188, 0x55EA, 0x6000, 0x6462, 0x68C4, 0x6D26, 0x7188, 0x75EA };
        }
    }
}
