using System.Text;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class PowerSet<T>
    {
        public int Size;
        private int Step;
        public T[] Slots;

        public PowerSet(int size)
        {
            Size = size;
            Step = 3;
            if (size < 4) Step = 1;
            Slots = new T[Size];
        }

        public int HashFun(string value)
        {
            var result = 0;
            byte[] text = Encoding.UTF8.GetBytes(value);
            foreach (var e in text)
                result += e;
            return result % Size;
        }

        public int SeekSlot(T value)
        {
            var slot = HashFun(value.ToString());
            for (int i = 0; i < Size; i++)
            {
                if (Equals(Slots[slot % Size], value)) return slot % Size;
                if (Equals(Slots[slot % Size], default(T))) return slot % Size;
                slot += Step;
            }
            return -1;
        }

        public void Put(T value)
        {
            var slot = SeekSlot(value);
            if (slot == -1 || Equals(Slots[slot], value)) return;
            Slots[slot] = value;
        }

        public bool Get(T value)
        {
            var slot = SeekSlot(value);
            if (slot != -1 && Equals(Slots[slot], value)) return true;
            return false;
        }

        public bool Remove(T value)
        {
            var slot = SeekSlot(value);
            if (slot == -1 || Equals(Slots[slot], default(T))) return false;
            Slots[slot] = default(T);
            return true;
        }

        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            var result = new List<T>();
            foreach (var e in Slots)
                if (!Equals(e, default(T)) && set2.Get(e)) result.Add(e);
            return ListToPowerSet(result);
        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            var result = new List<T>();
            foreach (var e in set2.Slots)
                if (!Equals(e, default(T))) result.Add(e);
            foreach (var e in Slots)
                if (!Equals(e, default(T)) && !set2.Get(e)) result.Add(e);
            return ListToPowerSet(result);
        }

        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            var result = new List<T>();
            foreach (var e in Slots)
                if (!Equals(e, default(T)) && !set2.Get(e)) result.Add(e);
            return ListToPowerSet(result);
        }

        public bool IsSubset(PowerSet<T> set2)
        {
            foreach (var e in set2.Slots)
                if (!Equals(e, default(T)) && !Get(e)) return false;
            return true;
        }

        PowerSet<T> ListToPowerSet(List<T> list)
        {
            var set = new PowerSet<T>(list.Count);
            foreach (var e in list) set.Put(e);
            return set;
        }
    }
}
