using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 配置表基类
/// </summary>

namespace BetaFramework
{
    public class TableSOBaseData<T> : ScriptableObject
    {
        public T Key;
    }

    public class TableSOContainer<TKey, TValue> : ScriptableObject where TValue : TableSOBaseData<TKey>
    {
        [SerializeField]
        private List<TValue> m_Value = new List<TValue>();

        private Dictionary<TKey, TValue> m_Dict = new Dictionary<TKey, TValue>();

        public void UpdateDic()
        {
            if (m_Dict != null && m_Dict.Count > 0) return;
            m_Dict = new Dictionary<TKey, TValue>();

            if (m_Value == null)
            {
                m_Value = new List<TValue>();
                return;
            }

            foreach (var v in m_Value)
            {
                m_Dict[v.Key] = v;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                UpdateDic();
                return m_Dict[key];
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                UpdateDic();
                return m_Dict.Keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                UpdateDic();
                return m_Dict.Values;
            }
        }

        public Dictionary<TKey, TValue>.Enumerator GetEnumerator()
        {
            UpdateDic();
            return m_Dict.GetEnumerator();
        }

        public void Add(TKey key, TValue value)
        {
            if (m_Dict == null)
                m_Dict = new Dictionary<TKey, TValue>();

            if (m_Value == null)
                m_Value = new List<TValue>();

            m_Value.Add(value);
            m_Dict.Add(key, value);
        }

        public int Count
        {
            get
            {
                UpdateDic();
                return m_Dict.Count;
            }
        }

        public bool ContainsKey(TKey key)
        {
            UpdateDic();
            return m_Dict.ContainsKey(key);
        }
    }
}