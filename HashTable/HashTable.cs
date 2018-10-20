using System.Text;

namespace HashTable
{
    public class NativeDictionary
    {
        public readonly int Size;
        private int Step;
        public object[] KeyArray;
        public object[] ValueArray;

        public NativeDictionary()
        {
            Size = 17;
            Step = 3;
            KeyArray = new object[Size];
            ValueArray = new object[Size];
        }

        public int HashFun(string value)
        {
            var result = 0;
            byte[] text = Encoding.UTF8.GetBytes(value);
            for (int i = 0; i < text.Length; i++)
                result += text[i];
            return result % 17;
        }

        public int[] IsKey(object key)
        {
            var slot = HashFun(key.ToString());
            for (int i = 0; i < Size; i++)
            {
                var item = KeyArray[slot % Size];
                if (item == key) return new int[] { 1, slot % Size };
                if (item == null) return new int[] { -1, slot % Size };
                slot += Step;
            }
            return new int[] { -1, -1 };
        }

        public bool Put(object key, object value)
        {
            var slot = IsKey(key);
            if (slot[0] < 0 && slot[1] < 0) return false;
            KeyArray[slot[1]] = key;
            ValueArray[slot[1]] = value;
            return true;
        }

        public object Get(object key)
        {
            var slot = IsKey(key);
            if (slot[0] < 0) return null;
            return ValueArray[slot[1]];
        }
    }
}
