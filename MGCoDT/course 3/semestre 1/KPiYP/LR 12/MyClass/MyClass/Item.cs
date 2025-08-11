using System;
using System.Collections.Generic;
using System.Text;

namespace MyClass
{
    abstract class Item : IComparable
    {
        protected long invNumber;
        protected bool taken;
        public Item()
        {
            this.taken = true;
        }
        public Item(long invNumber, bool taken)
        {
            this.invNumber = invNumber;
            this.taken = taken;
        }
        public bool IsAvailable()
        {
            if (taken == true)
                return true;
            else
                return false;
        }
        public long GetInvNumber()
        {
            return invNumber;
        }
        public void Take()
        {
            taken = false;
        }
        abstract public void Return();
        public void Show()
        {
            Console.WriteLine($"\nСостояние единицы хранения:\n Инвентарный номер: {invNumber}\n Наличие: {taken}");
        }
        public void TakeItem()
        {
            if (this.IsAvailable())
                this.Take();
        }
        int IComparable.CompareTo(object obj)
        {
            Item it = (Item)obj;
            if (this.invNumber == it.invNumber) return 0;
            else if (this.invNumber > it.invNumber) return 1;
            else return -1;
        }
    }
}