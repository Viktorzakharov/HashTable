using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsDataStructures
{
    public class NativeDictionary<T>
    {
        public int size;
        private int step;
        public string[] slots;
        public T[] values;

        public NativeDictionary(int sz)
        {
            size = sz;
            step = 3;
            if (sz < 4) step = 1;
            slots = new string[size];
            values = new T[size];
        }

        public int HashFun(string key)
        {
            var result = 0;
            byte[] text = Encoding.UTF8.GetBytes(key);
            for (int i = 0; i < text.Length; i++)
                result += text[i];
            return result % size;
        }

        public bool IsKey(string key)
        {
            var slot = HashFun(key);
            for (int i = 0; i < size; i++)
            {
                var item = slots[slot % size];
                if (item == key) return true;
                if (item == null) return false;
                slot += step;
            }
            return false;
        }

        public void Put(string key, T value)
        {
            var slot = FindSlot(key);
            if (slot == -1) return;
            if (slots[slot] == null) slots[slot]=key;
            values[slot] = value;
        }

        public T Get(string key)
        {
            var slot = FindSlot(key);
            if (slot == -1 && slots[slot] == null) return default(T);
            return values[slot];
        }

        public int FindSlot(string key)
        {
            var slot = HashFun(key);
            for (int i = 0; i < size; i++)
            {
                var item = slots[slot % size];
                if (item == key) return slot % size;
                if (item == null) return slot % size;
                slot += step;
            }
            return -1;
        }
    }
}
