using System.Text;
using System.Collections.Generic;

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

        public int[] SeekSlot(string value)
        {
            var slot = HashFun(value);
            for (int i = 0; i < Size; i++)
            {
                if (Array[slot % Size] == value) return new int[] { 1, slot % Size };
                if (Array[slot % Size] == null) return new int[] { -1, slot % Size };
                slot += Step;
            }
            return new int[] { 0, -1 };
        }

        public bool Put(string value)
        {
            var slot = SeekSlot(value);
            if (slot[0] >= 0) return false;
            Array[slot[1]] = value;
            return true;
        }

        public bool Find(string value)
        {
            var slot = SeekSlot(value);
            if (slot[0] <= 0) return false;
            return true;
        }

        public bool Remove(string value)
        {
            var slot = SeekSlot(value);
            if (slot[0] <= 0) return false;
            Array[slot[1]] = null;
            return true;
        }

        public List<string> Intersection(HashTable getSet)
        {
            var result = new List<string>();
            foreach (var e in Array)
                if (e != null)
                    if (getSet.Find(e)) result.Add(e);
            return result;
        }

        public List<string> Union(HashTable getSet)
        {
            var result = new List<string>();
            foreach (var e in getSet.Array)
                if (e != null)
                    result.Add(e);
            foreach (var e in Array)
                if (e != null)
                    if (!getSet.Find(e)) result.Add(e);
            return result;
        }

        public List<string> Difference(HashTable getSet)
        {
            var result = new List<string>();
            foreach (var e in Array)
                if (e != null)
                    if (!getSet.Find(e)) result.Add(e);
            return result;
        }

        public bool Issubset(HashTable getSet)
        {
            foreach (var e in getSet.Array)
                if (e != null)
                    if (!Find(e)) return false;
            return true;
        }
    }
}
