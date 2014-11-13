namespace System.Collections.Generic
{
    public static class DictionaryExtensions
    {
        public struct TryGetValueResult<TValue>
        {
            public readonly bool Succes;
            public readonly TValue Value;

            private TryGetValueResult(bool succes, TValue value)
            {
                Succes = succes;
                Value = value;
            }

            public static TryGetValueResult<TValue> Create(bool succes, TValue value)
            {
                return new TryGetValueResult<TValue>(succes, value);
            }
        }

        public static TryGetValueResult<TValue> TryGetValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            if ( dictionary == null )
                throw new ArgumentNullException("dictionary");

            TValue value;
            var gotten = dictionary.TryGetValue(key, out value);

            return TryGetValueResult<TValue>.Create(gotten, value);
        }

        public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
            where TValue : class
        {
            if ( dictionary == null )
                throw new ArgumentNullException("dictionary");

            TValue value = null;
            dictionary.TryGetValue(key, out value);

            return value;
        }
    }
}
