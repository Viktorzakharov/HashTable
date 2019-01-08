using System;

namespace AlgorithmsDataStructures
{
    class Program
    {
        static void Main()
        {
            var table = GenerateTable();
            for (int i = 0; i < table.size; i++)
                Console.WriteLine("{0}\t{1}", table.slots[i], table.values[i]);
            Console.WriteLine();
        }

        public static NativeDictionary<string> GenerateTable()
        {
            var table = new NativeDictionary<string>(17);
            table.Put("a", "aa");
            table.Put("b", "bb");
            table.Put("c", "cc");
            table.Put("d", "dd");
            table.Put("e", "ee");
            table.Put("f", "ff");
            table.Put("g", "gg");
            table.Put("h", "hh");
            table.Put("i", "ii");
            table.Put("j", "jj");
            return table;
        }
    }
}
