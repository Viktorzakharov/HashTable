using System;

namespace AlgorithmsDataStructures
{
    class Program
    {
        static void Main()
        {
            var table = new HashTable(17, 3);
            table.Put("a");
            table.Put("b");
            table.Put("c");
            table.Put("c");
            table.Put("d");
            table.Put("e");
            Write(table.slots);
            Console.WriteLine(table.Find("c"));
        }

        public static void Write(string[] array)
        {
            foreach (var e in array)
                Console.Write(e + " ");
            Console.WriteLine();
        }
    }
}
