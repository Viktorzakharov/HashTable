using System;

namespace HashTable
{
    class Program
    {
        static void Main()
        {
            var table = new HashTable();

            table.Put("a");
            table.Put("b");
            table.Put("c");
            table.Put("d");
            table.Put("e");
            table.Put("f");
            table.Put("g");
            table.Put("h");
            table.Put("i");
            table.Put("j");

            for (int i = 0; i < table.Array.Length; i++)
                Console.Write(table.Array[i] + " ");
            Console.WriteLine();

            Console.WriteLine(table.Find("i"));
        }
    }
}
