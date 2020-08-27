namespace BetaFramework
{
    public interface IMessage
    {
        /// <summary>
        /// 消息号
        /// </summary>
        short OpCode { get; }

        /// <summary>
        /// 消息数据
        /// </summary>
        byte[] Data { get; }

        /// <summary>
        /// 数据是否为空
        /// </summary>
        bool HasData { get; }

        /// <summary>
        /// 确认请求的id。它在我们发送消息时设置
        /// </summary>
        int? AckRequestId { get; set; }

        /// <summary>
        ///     响应的消息id
        /// </summary>
        int? AckResponseId { get; set; }

        /// <summary>
        ///     识别收到的消息类型
        /// </summary>
        byte Flags { get; set; }

        /// <summary>
        ///     消息状态码
        /// </summary>
        ResponseStatus Status { get; set; }

        /// <summary>
        ///     赋值数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        IMessage SetBinary(byte[] data);

        /// <summary>
        ///     消息转化成bytes
        /// </summary>
        /// <returns></returns>
        byte[] ToBytes();
    }
}