using System.Collections.Generic;
using System.Linq;

namespace BetaFramework
{
    public class Binding<T, V>
    {
        public Dictionary<T, V> Bindings = new Dictionary<T, V>();

        public void Bind(T type, V val)
        {
            if (Bindings.ContainsKey(type))
            {
                Bindings[type] = val;
            }
            else
            {
                Bindings.Add(type, val);
            }
        }

        public V Resolve(T type)
        {
            return Bindings.ContainsKey(type) ? Bindings[type] : default(V);
        }

        public IEnumerable<T> FindKeyMatches(V value)
        {
            return Bindings.Where(pair => pair.Value.Equals(value))
                .Select(pair => pair.Key);
        }

        public bool IsBound(T type)
        {
            return Bindings.ContainsKey(type);
        }

        public void Clear()
        {
            Bindings.Clear();
        }

        public V Clear(T type)
        {
            var obj = Bindings[type];
            Bindings[type] = default(V);
            Bindings.Remove(type);
            return obj;
        }

        public KeyValuePair<T, V>[] ToArray()
        {
            return Bindings.ToArray();
        }

        public int Count
        {
            get { return Bindings.Count; }
        }

        public V this[T type]
        {
            get { return Resolve(type); }
            set { Bind(type, value); }
        }
    }
}