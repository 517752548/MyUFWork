namespace BetaFramework
{
    public interface IPacketHandler
    {
        /// <summary>
        ///     消息处理号
        /// </summary>
        short OpCode { get; set; }

        /// <summary>
        ///     处理的消息
        /// </summary>
        /// <param name="message"></param>
        void Handle(IIncommingMessage message);
    }
}