using System;

namespace BetaFramework.Variable
{
    public abstract class Variable<T> : IVariable
    {
        private T m_Value;

        /// <summary>
        /// 初始化变量的新实例。
        /// </summary>
        protected Variable()
        {
            m_Value = default(T);
        }

        /// <summary>
        /// 初始化变量的新实例。
        /// </summary>
        /// <param name="value">初始值。</param>
        protected Variable(T value)
        {
            m_Value = value;
        }

        /// <summary>
        /// 获取变量类型。
        /// </summary>
        public Type Type => typeof(T);

        /// <summary>
        /// 获取或设置变量值。
        /// </summary>
        public T Value
        {
            get => m_Value;
            set => m_Value = value;
        }

        /// <summary>
        /// 获取变量值。
        /// </summary>
        /// <returns>变量值。</returns>
        public object GetValue()
        {
            return m_Value;
        }

        /// <summary>
        /// 设置变量值。
        /// </summary>
        /// <param name="value">变量值。</param>
        public void SetValue(object value)
        {
            m_Value = (T)value;
        }

        /// <summary>
        /// 重置变量值。
        /// </summary>
        public void Reset()
        {
            m_Value = default(T);
        }

        /// <summary>
        /// 获取变量字符串。
        /// </summary>
        /// <returns>变量字符串。</returns>
        public override string ToString()
        {
            return (m_Value != null) ? m_Value.ToString() : "<Null>";
        }
    }
}