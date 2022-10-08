using System;
using System.Collections.Generic;
using System.Text;

namespace CustomList
{
    public class CustomList
    {
        private const int InitialCapacity = 2;

        private int[] items;

        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; }
        //За достъпване на елементите в масива!!!!
        public int this[int index]
        {
            get 
            {  
                if (index >= this.items.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                return this.items[index]; 
            }
            set 
            {
                if (index >= this.items.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                this[index] = value; 
            }
        }
        public void Add(int item)
        {
            if (this.Count == this.items.Length)
            {
                Resize();
            }
            this.items[this.Count] = item;
            this.Count++;
        }
        public int RemoveAt (int index)
        {
            //Check validity of index
            if (this.Count < index)
            {
                throw new Exception("Error!");
            }

            var item = this.items[index];
            this.items[index] = default(int);
            this.Shift(index);
            this.Count--;
            if (this.Count <= this.items.Length/4)
            {
                Shrink();
            }
            return item;

        }
        public void Insert(int index, int item)
        {
            if (index > this.Count)
            {
                throw new Exception("Error!!!");
            }

            if (this.Count == this.items.Length)
            {
                Resize();
            }
            this.ShiftToRight(index);
            this.items[index] = item;
            this.Count++;
        }


        public void Swap(int firstIndex, int secondIndex)
        {
            int temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }

        public bool Contains(int item)
        {
            foreach (var i in this.items)
            {
                if (i == item)
                {
                    return true;
                }
            }
            return false;
        }

        //private methods
        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }
        private void Shift(int index)
        {
            for (int i = 0; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }
        private void ShiftToRight(int index)
        {
            for (int i = this.Count ; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
    }
}
