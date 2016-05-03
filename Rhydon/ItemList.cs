using System;

namespace Rhydon
{
    public class ItemList
    {
        private readonly int Capacity;
        private int Count;

        private readonly ItemEntry[] items; 

        public ItemList(byte[] Source, int c)
        {
            Capacity = c;
            Count = Source[0];
            if (Count > Capacity)
                throw new ArgumentOutOfRangeException();
            items = new ItemEntry[Capacity];
            for (int i = 0; i < Capacity; i++)
            {
                items[i] = i < Count 
                    ? new ItemEntry(Source[1 + 2*i], Source[2 + 2*i]) 
                    : new ItemEntry(0, 0);
            }
        }

        public byte[] getBytes()
        {
            byte[] b = new byte[2*(Count + 1)];
            b[0] = (byte)Count;
            b[b.Length - 1] = 0xFF;
            for (int i = 0; i < Count; i++)
                items[i].getBytes().CopyTo(b, 1 + 2*i);
            return b;
        }

        public int getCount()
        {
            return Count;
        }

        public void updateCount()
        {
            int count = 0;
            while (count < Capacity && this[count].Index != 0)
                count++;
            Count = count;
        }

        public int getCapacity()
        {
            return Capacity;
        }

        public ItemEntry this[int i]
        {
            get { return items[i]; }
            set { items[i] = value; }
        }


        public class ItemEntry
        {
            public byte Index;
            public byte Count;

            public ItemEntry(byte i, byte c)
            {
                Index = i;
                Count = c;
            }

            public byte[] getBytes()
            {
                return new[] {Index, Count};
            }
        }
    }
}
