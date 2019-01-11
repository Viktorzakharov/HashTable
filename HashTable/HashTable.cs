using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class PowerSet<T>
    {
        public HashSet<T> Set;

        public PowerSet()
        {
            Set = new HashSet<T>();
        }

        public int Size()
        {
            return Set.Count;
        }

        public void Put(T value)
        {
            Set.Add(value);
        }

        public bool Get(T value)
        {
            return Set.Contains(value);
        }

        public bool Remove(T value)
        {
            return Set.Remove(value);
        }

        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            var result = new PowerSet<T>();
            foreach (var e in set2.Set) if (Get(e)) result.Put(e);
            result.Set.TrimExcess();
            return result;
        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            var result = new PowerSet<T>();
            foreach (var e in Set) result.Put(e);
            foreach (var e in set2.Set) if (!Get(e)) result.Put(e);
            result.Set.TrimExcess();
            return result;
        }

        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            var result = new PowerSet<T>();
            foreach (var e in Set) if (!set2.Get(e)) result.Put(e);
            result.Set.TrimExcess();
            return result;
        }

        public bool IsSubset(PowerSet<T> set2)
        {
            foreach (var e in set2.Set) if (!Get(e)) return false;
            return true;
        }
    }
}
