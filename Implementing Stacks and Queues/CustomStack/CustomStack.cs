using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class CustomStack
    {
        private const int initialCapacity = 4;
        private int[] items;
        private int count; 

        public CustomStack()
        {
            this.count = 0;
            this.items = new int[initialCapacity];
        }
        public int Count 
        {            
            get { return this.count; } 
        }

        public void Push(int item)
        {
            if (this.items.Length == this.Count)
            {
                Resize();
            }
            this.items[this.Count] = item;
            this.count++;
        }

        public int Pop()
        {
            if (this.items.Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            int last = this.items[this.Count - 1];
            this.count--;
            return last;
        }

        public int Peek()
        {
            return this.items[this.Count - 1];
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

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
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
    }
}
