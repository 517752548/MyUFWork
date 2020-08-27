using System;

namespace BetaFramework.Variable
{
    /// <summary>
    /// 变量。
    /// </summary>
    public interface IVariable
    {
        /// <summary>
        /// 获取变量类型。
        /// </summary>
        Type Type
        {
            get;
        }

        /// <summary>
        /// 获取变量值。
        /// </summary>
        /// <returns>变量值。</returns>
        object GetValue();

        /// <summary>
        /// 设置变量值。
        /// </summary>
        /// <param name="value">变量值。</param>
        void SetValue(object value);

        /// <summary>
        /// 重置变量值。
        /// </summary>
        void Reset();
    }
}