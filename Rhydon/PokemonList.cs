using System;
using System.Linq;

namespace Rhydon
{
    public class PokemonList
    {
        internal const int CAPACITY_DAYCARE = 1;
        internal const int CAPACITY_PARTY = 6;
        internal const int CAPACITY_STORED = 20;
        internal const int CAPACITY_STORED_JP = 30;

        internal static readonly byte[] EMPTY_LIST = { 0x01, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50 };

        private bool JP;

        public enum CapacityType
        {
            Daycare = CAPACITY_DAYCARE,
            Party = CAPACITY_PARTY,
            Stored = CAPACITY_STORED,
            Stored_JP = CAPACITY_STORED_JP,
            Single
        }

        public static int getEntrySize(CapacityType c)
        {
            return c == CapacityType.Single || c == CapacityType.Party 
                ? PK1.SIZE_PARTY 
                : PK1.SIZE_STORED;
        }

        public static byte getCapacity(CapacityType c)
        {
            return c == CapacityType.Single ? (byte)1 : (byte)c;
        }

        private byte[] getEmptyList(CapacityType c, bool is_JP = false)
        {
            int cap = getCapacity(c);
            return new[] { (byte)0 }.Concat(Enumerable.Repeat((byte)0xFF, cap + 1)).Concat(Enumerable.Repeat((byte)0, getEntrySize(c) * cap)).Concat(Enumerable.Repeat((byte)0x50, (is_JP ? 0x6 : 0xB) * 2 * cap)).ToArray();
        }

        public PokemonList(byte[] d, CapacityType c = CapacityType.Single, bool jp = false)
        {
            JP = jp;
            Data = d ?? getEmptyList(c, JP);
            Capacity = getCapacity(c);
            Entry_Size = getEntrySize(c);

            if (Data.Length != DataSize)
            {
                Array.Resize(ref Data, DataSize);
            }

            Pokemon = jp ? new JPK1[Capacity] : new PK1[Capacity];
            for (int i = 0; i < Capacity; i++)
            {
                int base_ofs = 2 + Capacity;
                byte[] dat = Data.Skip(base_ofs + Entry_Size*i).Take(Entry_Size).ToArray();
                Pokemon[i] = jp ? new JPK1(dat) : new PK1(dat);
                Pokemon[i].OT_Name = Data.Skip(base_ofs + Capacity * Entry_Size + (JP ? 6 : 0xB) * i).Take((JP ? 6 : 0xB)).ToArray();
                Pokemon[i].Nickname = Data.Skip(base_ofs + Capacity * Entry_Size + (JP ? 6 : 0xB) * Capacity + (JP ? 6 : 0xB) * i).Take((JP ? 6 : 0xB)).ToArray();
            }
        }

        public PokemonList(CapacityType c = CapacityType.Single, bool jp = false)
            : this(null, c, jp)
        {
            Count = 1;
        }

        public PokemonList(PK1 pk)
            : this(CapacityType.Single, pk is JPK1)
        {
            this[0] = pk;
            Count = 1;
        }

        private readonly byte[] Data;
        private readonly byte Capacity;
        private readonly int Entry_Size;

        public byte Count
        {
            get { return Data[0]; }
            set { Data[0] = value > Capacity ? Capacity : value; }
        }

        public int GetCapacity()
        {
            return Capacity;
        }


        public readonly PK1[] Pokemon;

        public PK1 this[int i]
        {
            get
            {
                if (i > Capacity || i < 0) throw new IndexOutOfRangeException($"Invalid PokemonList Access: {i}");
                return Pokemon[i];
            }
            set
            {
                if (value == null) return;
                Pokemon[i] = value.Clone();
            }
        }

        private void Update()
        {
            for (int i = 0; i < Count; i++)
            {
                Data[1 + i] = Pokemon[i].Species;
                Array.Copy(Pokemon[i].Data, 0, Data, 2 + Capacity + Entry_Size * i, Entry_Size);
                Array.Copy(Pokemon[i].OT_Name, 0, Data, 2 + Capacity + Capacity * Entry_Size + (JP ? 6 : 0xB) * i, (JP ? 6 : 0xB));
                Array.Copy(Pokemon[i].Nickname, 0, Data, 2 + Capacity + Capacity * Entry_Size + (JP ? 6 : 0xB) * Capacity + (JP ? 6 : 0xB) * i, (JP ? 6 : 0xB));
            }
            Data[1 + Count] = byte.MaxValue;
            if (Data[1] == 0xD2)
            {
                Console.WriteLine("wat");
            }
        }

        public byte[] GetBytes()
        {
            Update();
            return Data;
        }

        private int DataSize
        {
            get { return Capacity * (Entry_Size + 1 + 2 * (JP ? 6 : 0xB)) + 2; }
        }

        public static int GetDataLength(CapacityType c, bool jp = false)
        {
            return getCapacity(c) * (getEntrySize(c) + 1 + 2 * (jp ? 6 : 0xB)) + 2;
        }
    }
}
