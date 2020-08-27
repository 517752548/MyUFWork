using Newtonsoft.Json;
using System;

namespace BetaFramework
{
    /// <summary>
    ///     serializable packets的基类
    /// </summary>
    public abstract class SerializablePacket : ISerializablePacket
    {
        public byte[] ToBytes()
        {
            string str = JsonConvert.SerializeObject(this);
            return System.Text.Encoding.UTF8.GetBytes(str);

            /***********************custom serializable***********************
            byte[] b;
            using (var ms = new MemoryStream())
            {
                using (var writer = new EndianBinaryWriter(EndianBitConverter.Big, ms))
                {
                    ToBinaryWriter(writer);
                }

                b = ms.ToArray();
            }

            return b;
            ****************************************************************/
        }

        public virtual void ToBinaryWriter(EndianBinaryWriter writer)
        {
        }

        public virtual void FromBinaryReader(EndianBinaryReader reader)
        {
        }

        public static T FromBytes<T>(byte[] data) where T : ISerializablePacket
        {
            try
            {
                string str = System.Text.Encoding.UTF8.GetString(data);
                return JsonConvert.DeserializeObject<T>(str);
            }
            catch (Exception ex)
            {
                LoggerHelper.Exception(ex);
                return default(T);
            }
            /***********************custom serializable***********************
            using (var ms = new MemoryStream(data))
            {
                using (var reader = new EndianBinaryReader(EndianBitConverter.Big, ms))
                {
                    packet.FromBinaryReader(reader);
                    return packet;
                }
            }
            ****************************************************************/
        }

        /// <summary>
        ///     写一个长度低于字节值的数组
        /// </summary>
        /// <param name="data"></param>
        /// <param name="writer"></param>
        public void WriteSmallArray(float[] data, EndianBinaryWriter writer)
        {
            writer.Write((byte)(data != null ? data.Length : 0));

            if (data != null)
                foreach (var val in data)
                    writer.Write(val);
        }

        /// <summary>
        ///     读取长度低于字节值的数组
        /// </summary>
        /// <param name="reader"></param>
        public float[] ReadSmallArray(EndianBinaryReader reader)
        {
            var length = reader.ReadByte();

            if (length == 0) return null;

            var result = new float[length];
            for (var i = 0; i < length; i++)
                result[i] = reader.ReadSingle();
            return result;
        }
    }
}