using System;

namespace AlgorithmsDataStructures
{
    class Program
    {
        static void Main()
        {
            var table = new PowerSet<string>(17);            
            table.Put("a");
            table.Put("b");
            table.Put("c");

            var checkTable = new PowerSet<string>(17);
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
            foreach (var e in table.Slots)
                Console.Write(e + " ");
            Console.WriteLine();
        }
    }
}
