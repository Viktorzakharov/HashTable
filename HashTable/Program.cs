using System;

namespace AlgorithmsDataStructures
{
    class Program
    {
        static void Main()
        {
            var table = new PowerSet<string>();
            table.Put("a");
            table.Put("b");
            table.Put("c");
            table.Put("a");

            var checkTable = new PowerSet<string>();
            checkTable.Put("c");
            checkTable.Put("d");
            checkTable.Put("e");

            Write(table);
            Write(checkTable);
            Write(table.Intersection(checkTable));
            Write(table.Union(checkTable));
            Write(table.Difference(checkTable));
        }

        public static void Write(PowerSet<string> table)
        {
            foreach (var e in table.Set)
                Console.Write(e + " ");
            Console.WriteLine();
        }
    }
}
