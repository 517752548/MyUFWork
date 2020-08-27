using System;
using System.Collections.Generic;
using System.Text;

namespace BetaFramework
{
    public class IncommingMessage : IIncommingMessage
    {
        private readonly byte[] _data;

        public IncommingMessage(short opCode, byte[] data, IPeer peer)
        {
            OpCode = opCode;
            Peer = peer;
            _data = data;
        }

        public short OpCode { get; private set; }

        public IPeer Peer { get; private set; }

        public int? AckResponseId { get; set; }

        /// <summary>
        ///    我们将其添加到数据包中，以便接收方知道是哪一个返回了
        /// </summary>
        public int? AckRequestId { get; set; }

        /// <summary>
        ///     消息状态码
        /// </summary>
        public ResponseStatus Status { get; set; }

        /// <summary>
        ///     消息响应
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        public void Respond(IMessage message, ResponseStatus statusCode = ResponseStatus.Default)
        {
            message.Status = statusCode;

            if (AckResponseId.HasValue)
                message.AckResponseId = AckResponseId.Value;

            Peer.SendMessage(message);
        }

        /// <summary>
        ///     响应数据（消息在内部创建）
        /// </summary>
        /// <param name="data"></param>
        /// <param name="statusCode"></param>
        public void Respond(byte[] data, ResponseStatus statusCode = ResponseStatus.Default)
        {
            Respond(MessageHelper.Create(OpCode, data), statusCode);
        }

        /// <summary>
        ///     响应数据（消息在内部创建）
        /// </summary>
        /// <param name="data"></param>
        /// <param name="statusCode"></param>
        public void Respond(ISerializablePacket packet, ResponseStatus statusCode = ResponseStatus.Default)
        {
            Respond(MessageHelper.Create(OpCode, packet.ToBytes()), statusCode);
        }

        /// <summary>
        ///     空消息和状态码
        /// </summary>
        /// <param name="statusCode"></param>
        public void Respond(ResponseStatus statusCode = ResponseStatus.Default)
        {
            Respond(MessageHelper.Create(OpCode), statusCode);
        }

        public void Respond(string message, ResponseStatus statusCode = ResponseStatus.Default)
        {
            Respond(message.ToBytes(), statusCode);
        }

        public void Respond(int response, ResponseStatus statusCode = ResponseStatus.Default)
        {
            Respond(MessageHelper.Create(OpCode, response), statusCode);
        }

        /// <summary>
        ///     如果有任何消息则返回true
        /// </summary>
        public bool HasData
        {
            get { return _data.Length > 0; }
        }

        /// <summary>
        ///     返回消息内容
        /// </summary>
        /// <returns></returns>
        public byte[] AsBytes()
        {
            return _data;
        }

        public string AsString()
        {
            return Encoding.UTF8.GetString(_data);
        }

        public string AsString(string defaultValue)
        {
            return HasData ? AsString() : defaultValue;
        }

        public int AsInt()
        {
            return EndianBitConverter.Big.ToInt32(_data, 0);
        }

        public T Deserialize<T>() where T : ISerializablePacket
        {
            return MessageHelper.Deserialize<T>(_data);
        }

        public IEnumerable<T> DeserializeList<T>(Func<T> packetCreator) where T : ISerializablePacket
        {
            return MessageHelper.DeserializeList(_data, packetCreator);
        }

        public override string ToString()
        {
            return AsString(base.ToString());
        }
    }
}