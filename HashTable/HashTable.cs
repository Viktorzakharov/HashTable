using System.Text;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class PowerSet
    {
        public readonly int Size;
        private int Step;
        public string[] Array;

        public PowerSet()
        {
            Size = 17;
            Step = 3;
            Array = new string[Size];
        }

        public int HashFun(string value)
        {
            var result = 0;
            byte[] text = Encoding.UTF8.GetBytes(value);
            foreach(var e in text)
                result += e;
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

        public string[] Intersection(PowerSet getSet)
        {
            var result = new List<string>();
            foreach (var e in Array)
                if (e != null)
                    if (getSet.Find(e)) result.Add(e);
            return result.ToArray();
        }

        public string[] Union(PowerSet getSet)
        {
            var result = new List<string>();
            foreach (var e in getSet.Array)
                if (e != null)
                    result.Add(e);
            foreach (var e in Array)
                if (e != null)
                    if (!getSet.Find(e)) result.Add(e);
            return result.ToArray();
        }

        public string[] Difference(PowerSet getSet)
        {
            var result = new List<string>();
            foreach (var e in Array)
                if (e != null)
                    if (!getSet.Find(e)) result.Add(e);
            return result.ToArray();
        }

        public bool Issubset(PowerSet getSet)
        {
            foreach (var e in getSet.Array)
                if (e != null)
                    if (!Find(e)) return false;
            return true;
        }
    }
}
