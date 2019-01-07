using System;

namespace AlgorithmsDataStructures
{
    class Program
    {
        static void Main()
        {
            var array = new HashFunction[]
            { (line, size) => (10 * HashTable.LineInByte(line) + 1) % 100 % size,
              (line, size) => (10 * HashTable.LineInByte(line) + 1) % 100 % size,
              (line, size) => (10 * HashTable.LineInByte(line) + 1) % 100 % size
            };
            var table = new HashTable(17, 3, array);
        }

        public static void Write(string[] array)
        {
            foreach (var e in array)
                Console.Write(e + " ");
            Console.WriteLine();
        }
    }
}
