using System;
using System.Linq;

namespace Rhydon
{
    public class PokemonList
    {
        internal const int CAPACITY_DAYCARE = 1;
        internal const int CAPACITY_PARTY = 6;
        internal const int CAPACITY_STORED = 20;

        internal static readonly byte[] EMPTY_LIST = { 0x01, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50 };

        public enum CapacityType
        {
            Daycare = CAPACITY_DAYCARE,
            Party = CAPACITY_PARTY,
            Stored = CAPACITY_STORED,
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

        private byte[] getEmptyList(CapacityType c)
        {
            int cap = getCapacity(c);
            return new[] { (byte)0 }.Concat(Enumerable.Repeat((byte)0xFF, cap + 1)).Concat(Enumerable.Repeat((byte)0, getEntrySize(c) * cap)).Concat(Enumerable.Repeat((byte)0x50, 0xB * 2 * cap)).ToArray();
        }

        public PokemonList(byte[] d, CapacityType c = CapacityType.Single)
        {
            Data = d ?? getEmptyList(c);
            Capacity = getCapacity(c);
            Entry_Size = getEntrySize(c);
            if (Data.Length != DataSize)
            {
                Array.Resize(ref Data, DataSize);
            }

            Pokemon = new PK1[Capacity];
            for (int i = 0; i < Capacity; i++)
            {
                int base_ofs = 2 + Capacity;
                Pokemon[i] = new PK1(Data.Skip(base_ofs + Entry_Size * i).Take(Entry_Size).ToArray());
                Pokemon[i].OT_Name = Data.Skip(base_ofs + Capacity * Entry_Size + 0xB * i).Take(0xB).ToArray();
                Pokemon[i].Nickname = Data.Skip(base_ofs + Capacity * Entry_Size + 0xB * Capacity + 0xB * i).Take(0xB).ToArray();
            }
        }

        public PokemonList(CapacityType c = CapacityType.Single)
            : this(null, c)
        {
            Count = 1;
        }

        public PokemonList(PK1 pk)
            : this()
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
                Array.Copy(Pokemon[i].OT_Name, 0, Data, 2 + Capacity + Capacity * Entry_Size + 0xB * i, 0xB);
                Array.Copy(Pokemon[i].Nickname, 0, Data, 2 + Capacity + Capacity * Entry_Size + 0xB * Capacity + 0xB * i, 0xB);
            }
            Data[1 + Count] = byte.MaxValue;
        }

        public byte[] GetBytes()
        {
            Update();
            return Data;
        }

        private int DataSize
        {
            get { return Capacity * (Entry_Size + 23) + 2; }
        }

        public static int GetDataLength(CapacityType c)
        {
            return getCapacity(c) * (getEntrySize(c) + 23) + 2;
        }
    }
}
