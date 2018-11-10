using System;
using System.Text;

namespace HashTable
{
    public class Program
    {
        static void Main()
        {
            var cache = new Cache();
            var random = GenerateCache(cache);
            var newKey = NewKey(cache, random);

            Console.WriteLine("Before");
            Write(cache.KeyArray);
            Write(cache.ValueArray);
            Write(cache.Appeals);

            cache.GetValue(newKey);

            Console.WriteLine("After");
            Write(cache.KeyArray);
            Write(cache.ValueArray);
            Write(cache.Appeals);
        }

        public static Random GenerateCache(Cache cache)
        {
            var random = new Random();

            for (int i = 0; i < 80; i++)
                cache.GetValue(Encoding.UTF8.GetString(new byte[] { (byte)random.Next(48, 128) }));
            return random;
        }

        public static bool CheckKey(string key, Cache cache)
        {
            foreach (var e in cache.KeyArray)
                if ((string)e == key)
                    return false;
            return true;
        }

        public static string NewKey(Cache cache, Random random)
        {
            var newKey = Encoding.UTF8.GetString(new byte[] { (byte)random.Next(48, 128) });
            while (true)
            {
                if (CheckKey(newKey, cache)) break;
                newKey = Encoding.UTF8.GetString(new byte[] { (byte)random.Next(48, 128) });
            }
            return newKey;
        }

        public static void Write(object array)
        {
            if (array is object[])
                foreach (var e in (object[])array)
                    Console.Write("{0,3}", e);
            else if(array is int[])
                foreach (var e in (int[])array)
                    Console.Write("{0,3}", e);
            Console.WriteLine();
        }
    }


}
