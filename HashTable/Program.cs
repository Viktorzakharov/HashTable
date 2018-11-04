﻿using System;

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

            var checkTable = new HashTable();
            checkTable.Put("c");
            checkTable.Put("d");
            checkTable.Put("e");

            Write(table.Array);
            Write(checkTable.Array);
            Write(table.Intersection(checkTable));
            Write(table.Union(checkTable));
            Write(table.Difference(checkTable));
        }

        public static void Write(string[] array)
        {
            foreach (var e in array)
                Console.Write(e + " ");
            Console.WriteLine();
        }
    }
}
