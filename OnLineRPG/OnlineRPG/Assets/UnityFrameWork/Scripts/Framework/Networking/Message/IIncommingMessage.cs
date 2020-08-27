using System;
using System.Collections.Generic;

namespace BetaFramework
{
    public interface IIncommingMessage
    {
        /// <summary>
        ///     消息类型
        /// </summary>
        short OpCode { get; }

        /// <summary>
        ///     负责发送的peer
        /// </summary>
        IPeer Peer { get; }

        /// <summary>
        ///     确认消息正在响应
        /// </summary>
        int? AckResponseId { get; }

        /// <summary>
        ///     将其添加到数据包中以便接收方知道接收的是哪个to
        /// </summary>
        int? AckRequestId { get; }

        /// <summary>
        ///     消息状态码
        /// </summary>
        ResponseStatus Status { get; }

        /// <summary>
        ///     如果消息有数据则返回true
        /// </summary>
        bool HasData { get; }

        /// <summary>
        ///     消息响应
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        void Respond(IMessage message, ResponseStatus statusCode = ResponseStatus.Default);

        /// <summary>
        ///     响应数据（消息在内部创建）
        /// </summary>
        /// <param name="data"></param>
        /// <param name="statusCode"></param>
        void Respond(byte[] data, ResponseStatus statusCode = ResponseStatus.Default);

        /// <summary>
        ///     响应数据（消息在内部创建）
        /// </summary>
        /// <param name="data"></param>
        /// <param name="statusCode"></param>
        void Respond(ISerializablePacket packet, ResponseStatus statusCode = ResponseStatus.Default);

        /// <summary>
        ///     回复空消息和状态代码
        /// </summary>
        /// <param name="statusCode"></param>
        void Respond(ResponseStatus statusCode);

        /// <summary>
        ///     string消息响应
        /// </summary>
        void Respond(string message, ResponseStatus statusCode = ResponseStatus.Default);

        /// <summary>
        ///     int消息响应
        /// </summary>
        /// <param name="response"></param>
        /// <param name="statusCode"></param>
        void Respond(int response, ResponseStatus statusCode = ResponseStatus.Default);

        /// <summary>
        ///     返回此消息内容
        /// </summary>
        /// <returns></returns>
        byte[] AsBytes();

        /// <summary>
        ///     将内容解码为字符串
        /// </summary>
        /// <returns></returns>
        string AsString();

        /// <summary>
        ///     将内容解码为字符串。 如果没有内容，返回defaultValue
        /// </summary>
        /// <returns></returns>
        string AsString(string defaultValue);

        /// <summary>
        ///     将内容解码为 integer
        /// </summary>
        /// <returns></returns>
        int AsInt();

        /// <summary>
        ///     将消息的内容写入数据包
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="packetToBeFilled"></param>
        /// <returns></returns>
        T Deserialize<T>() where T : ISerializablePacket;

        /// <summary>
        ///     使用消息内容重新生成数据包列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="packetCreator"></param>
        /// <returns></returns>
        IEnumerable<T> DeserializeList<T>(Func<T> packetCreator) where T : ISerializablePacket;
    }
}