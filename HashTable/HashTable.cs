using System.Text;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class NativeCache<T>
    {
        public int size;
        private int step;
        public string[] slots;
        public T[] values;
        public int[] hits;
        public readonly int hitsStart;
        public readonly int hitsGet;
        public Dictionary<string, T> data;

        public NativeCache(int sz)
        {
            size = sz;
            step = 3;
            if (sz < 4) step = 1;
            slots = new string[size];
            values = new T[size];
            hits = new int[size];
            hitsStart = 8;
            hitsGet = 18;
        }

        public int HashFun(string key)
        {
            var result = 0;
            byte[] text = Encoding.UTF8.GetBytes(key);
            for (int i = 0; i < text.Length; i++)
                result += text[i];
            return result % size;
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

        public T Get(string key)
        {
            if (data.Count == 0) return default(T);
            var slot = FindSlot(key);
            if (slot == -1) return Put(MinIndex(), key);
            if (slots[slot] == null) return Put(slot, key);
            return HitsManage(slot, false);
        }

        private T Put(int index, string key)
        {
            slots[index] = key;
            values[index] = data[key];
            return HitsManage(index, true);
        }

        private T HitsManage(int slot, bool put)
        {
            if (put) hits[slot] = hitsStart;
            else hits[slot] += hitsGet;
            for (int i = 0; i < hits.Length; i++) if (slots[i] != null) hits[i]--;
            return values[slot];
        }

        public int MinIndex()
        {
            var min = hits[0];
            var minIndex = 0;
            for (int i = 0; i < hits.Length; i++)
                if (min > hits[i])
                {
                    min = hits[i];
                    minIndex = i;
                }
            return minIndex;
        }
    }
}
