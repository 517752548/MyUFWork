namespace BetaFramework
{
    /// <summary>
    /// 下载错误事件
    /// </summary>
    public class DownloadErrorEventArgs : BetaFrameworkEventArgs
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        /// <param name="errorMessage"></param>
        public DownloadErrorEventArgs(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 获取错误信息。
        /// </summary>
        public string ErrorMessage
        {
            get;
            private set;
        }
    }
}