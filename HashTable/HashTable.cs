using System;
using System.Text;

namespace HashTable
{
    public class HashTable
    {
        public readonly int Size;
        private int Step;
        public string[] Array;

        public HashTable()
        {
            Size = 17;
            Step = 3;
            Array = new string[Size];
        }

        public int HashFun(string value)
        {
            var result = 0;
            byte[] text = Encoding.UTF8.GetBytes(value);
            for (int i = 0; i < text.Length; i++)
                result += text[i];
            return result % 17;
        }

        public int SeekSlot(string value, string param)
        {
            var slot = HashFun(value);
            for (int i = 0; i < Size; i++)
            {
                if (Array[slot % Size] == param) return slot % Size;
                slot += Step;
            }
            return -1;
        }

        public bool Put(string value)
        {
            var slot = SeekSlot(value, null);
            if (slot < 0) return false;
            Array[slot] = value;
            return true;
        }

        public int Find(string value)
        {
            var result = SeekSlot(value, value);
            if (result < 0) return -1;
            return result;
        }
    }
}
