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

        public PowerSet<T> Intersection(PowerSet<T> intersectionSet)
        {
            var result = new PowerSet<T>();
            foreach (var e in intersectionSet.Set) if (Get(e)) result.Put(e);
            result.Set.TrimExcess();
            return result;
        }

        public PowerSet<T> Union(PowerSet<T> unionSet)
        {
            var result = new PowerSet<T>();
            foreach (var e in Set) result.Put(e);
            foreach (var e in unionSet.Set) if (!Get(e)) result.Put(e);
            result.Set.TrimExcess();
            return result;
        }

        public PowerSet<T> Difference(PowerSet<T> differenceSet)
        {
            var result = new PowerSet<T>();
            foreach (var e in Set) if (!differenceSet.Get(e)) result.Put(e);
            result.Set.TrimExcess();
            return result;
        }

        public bool IsSubset(PowerSet<T> subSet)
        {
            foreach (var e in subSet.Set) if (!Get(e)) return false;
            return true;
        }
    }
}
