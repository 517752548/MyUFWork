namespace BetaFramework
{
    public interface IMessageFactory
    {
        /// <summary>
        ///     创建一个空消息类
        /// </summary>
        /// <param name="opCode"></param>
        /// <returns></returns>
        IMessage Create(short opCode);

        /// <summary>
        ///    创建一个带data的消息类
        /// </summary>
        /// <param name="opCode"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        IMessage Create(short opCode, byte[] data);

        /// <summary>
        ///     重置 bytes 为IIncommingMessage类型
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="peer"></param>
        /// <returns></returns>
        IIncommingMessage FromBytes(byte[] buffer, int start, IPeer peer);
    }
}