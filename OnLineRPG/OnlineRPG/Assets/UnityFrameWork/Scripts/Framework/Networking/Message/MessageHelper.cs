using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine.Networking;

namespace BetaFramework
{
    /// <summary>
    ///     消息Helper类, 使用消息工厂创建消息
    /// </summary>
    public static class MessageHelper
    {
        private static IMessageFactory m_Factory;
        private static readonly EndianBitConverter m_Converter;
        private static readonly NetworkWriter m_Writer;

        static MessageHelper()
        {
            m_Converter = EndianBitConverter.Big;
            m_Factory = new MessageFactory();
            m_Writer = new NetworkWriter();
        }

        /// <summary>
        ///     set消息工厂.
        /// </summary>
        /// <param name="factory"></param>
        public static void SetFactory(IMessageFactory factory)
        {
            m_Factory = factory;
        }

        /// <summary>
        ///     解析消息包
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="packet"></param>
        /// <returns></returns>
        public static T Deserialize<T>(byte[] data) where T : ISerializablePacket
        {
            return SerializablePacket.FromBytes<T>(data);
        }

        /// <summary>
        ///     解析消息包列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="packetCreator">Factory function</param>
        /// <returns></returns>
        public static IEnumerable<T> DeserializeList<T>(byte[] data, Func<T> packetCreator)
            where T : ISerializablePacket
        {
            using (var ms = new MemoryStream(data))
            {
                using (var reader = new EndianBinaryReader(EndianBitConverter.Big, ms))
                {
                    var count = reader.ReadInt32();
                    var list = new List<T>(count);

                    for (var i = 0; i < count; i++)
                    {
                        var packet = packetCreator();
                        packet.FromBinaryReader(reader);
                        list.Add(packet);
                    }

                    return list;
                }
            }
        }

        /// <summary>
        ///     创建一个空消息
        /// </summary>
        /// <param name="opCode"></param>
        /// <returns></returns>
        public static IMessage Create(short opCode)
        {
            return m_Factory.Create(opCode);
        }

        /// <summary>
        ///     创建一个带数据的消息类
        /// </summary>
        /// <param name="opCode"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static IMessage Create(short opCode, byte[] data)
        {
            return m_Factory.Create(opCode, data);
        }

        /// <summary>
        ///     根据string创建消息类
        /// </summary>
        /// <param name="opCode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static IMessage Create(short opCode, string message)
        {
            return m_Factory.Create(opCode, Encoding.UTF8.GetBytes(message));
        }

        /// <summary>
        ///     根据int创建一个消息类
        /// </summary>
        /// <param name="opCode"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IMessage Create(short opCode, int value)
        {
            var bytes = new byte[4];
            m_Converter.CopyBytes(value, bytes, 0);
            return m_Factory.Create(opCode, bytes);
        }

        public static IMessage Create(short opCode, ISerializablePacket packet)
        {
            return Create(opCode, packet.ToBytes());
        }

        /// <summary>
        ///     消息恢复成IIncommingMessage类型
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="peer"></param>
        /// <returns></returns>
        public static IIncommingMessage FromBytes(byte[] buffer, int start, IPeer peer)
        {
            return m_Factory.FromBytes(buffer, start, peer);
        }
    }
}