using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rhydon
{
    public class ItemList
    {
        private int Capacity;
        private int Count;

        private ItemEntry[] items; 

        public ItemList(byte[] Source, int c)
        {
            Capacity = c;
            Count = Source[0];
            Count = Source[0];
            if (Count > Capacity)
                throw new ArgumentOutOfRangeException("Invalid Item List (count > Capacity)");
            items = new ItemEntry[Capacity];
            for (int i = 0; i < Capacity; i++)
            {
                if (i < Count)
                    items[i] = new ItemEntry(Source[1 + 2*i], Source[2 + 2*i]);
                else
                {
                    items[i] = new ItemEntry(0, 0);
                }
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
            while (this[count].Index != 0 && count < Capacity)
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
