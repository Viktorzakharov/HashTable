using System;

namespace HashTable
{
    class Program
    {
        static void Main()
        {
            var table = GenerateTable();

            for (int i = 0; i < table.KeyArray.Length; i++)
                Console.Write(table.KeyArray[i] + " ");
            Console.WriteLine();

            for (int i = 0; i < table.ValueArray.Length; i++)
                Console.Write(table.ValueArray[i] + " ");

        }

        public static NativeDictionary GenerateTable()
        {
            var table = new NativeDictionary();
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
