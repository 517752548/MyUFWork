namespace BetaFramework
{
    public class DownloadUpdateEventArgs : BetaFrameworkEventArgs
    {
        public DownloadUpdateEventArgs(ulong length, byte[] bytes)
        {
            this.Length = length;
            this.Bytes = bytes;
        }

        /// <summary>
        /// 下载内容大小
        /// </summary>
        public ulong Length
        {
            get;
            private set;
        }

        /// <summary>
        /// 实际数据
        /// </summary>
        public byte[] Bytes
        {
            get;
            private set;
        }
    }
}