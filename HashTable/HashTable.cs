using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsDataStructures
{
    public delegate int HashFunction(string line, int size);

    public class HashTable
    {
        public int size;
        private int step;
        public string[] slots;
        public HashFunction func;

        public HashTable(int sz, int stp, HashFunction[] functions)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            func = functions[new Random(DateTime.Now.Millisecond).Next() % functions.Length];
        }

        public int HashFun(string value)
        {
            return func(value, size);
        }

        public int SeekSlot(string value)
        {
            return FindSlot(value, null);
        }

        public int Put(string value)
        {
            var slot = SeekSlot(value);
            if (slot < 0) return -1;
            slots[slot] = value;
            return slot;
        }

        public int Find(string value)
        {
            var result = FindSlot(value, value);
            if (result < 0 || slots[result] == null) return -1;
            return result;
        }

        public int FindSlot(string value, string param)
        {
            var slot = HashFun(value);
            for (int i = 0; i < size; i++)
            {
                if (slots[slot % size] == param || slots[slot % size] == null) return slot % size;
                slot += step;
            }
            return -1;
        }

        public static int LineInByte(string value)
        {
            var result = 0;
            byte[] text = Encoding.UTF8.GetBytes(value);
            for (int i = 0; i < text.Length; i++)
                result += text[i];
            return result;
        }
    }
}
