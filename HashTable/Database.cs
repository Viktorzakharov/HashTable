using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    public class Database
    {
        public Dictionary<object, object> Data = new Dictionary<object, object>();

        public void Create()
        {
            var symbol = "0";

            for (int i = 0; i < 81; i++)
            {
                Data.Add(symbol, symbol + symbol);
                var symbolByte = Encoding.UTF8.GetBytes(symbol);
                symbolByte[0]++;
                symbol = Encoding.UTF8.GetString(symbolByte);
            }
        }

        public void Clean()
        {
            Data = new Dictionary<object, object>();
        }

        public void Write()
        {
            foreach (var e in Data)
                Console.WriteLine("{0}\t{1}", e.Key, e.Value);
        }
    }
}
