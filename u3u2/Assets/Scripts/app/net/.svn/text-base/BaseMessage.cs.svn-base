using System;
using System.Text;
using System.IO;
using Ionic.Zlib;

namespace app.net
{
    public abstract class BaseMessage : IMessage
    {
        public const int MSG_TYPE_LEN = 2;
        public const int MSG_SIZE_LEN = 2;
        public const int MIN_MSG_LEN = MSG_SIZE_LEN + MSG_SIZE_LEN;
        public const int MAX_MSG_LEN = 1024 * 32;

        private short msgLen;
        public static Encoding DEFAULT_ENCODING = Encoding.UTF8;

        //��Ϣ���Ƿ����ܵı�ʶλ
        private static bool ENC_FLAG = false;
        private static byte[] ENC_ARR = { 1, 0, 1, 1, 0, 0, 1, 1 };
        private static int ENC_ARR_LEN = ENC_ARR.Length;

        //  private MemoryStream writer;

        public MemoryStream writeStream;

        public MemoryStream readeStream;

        public BinaryWriter writer;

        public BinaryReader reader;

        public byte[] Encode()
        {
            writeStream = new MemoryStream();
            writer = new BinaryWriter(writeStream, DEFAULT_ENCODING);
            this.WriteShort(0);
            this.WriteShort(GetMessageType());
            
            WriteImpl();

            byte[] bytes = writeStream.ToArray();

            encMsgBody(bytes);

            msgLen = (short)(bytes.Length);

            byte[] _msglen = ConvertLenToArry(msgLen);
            bytes [0] = _msglen [0];
            bytes [1] = _msglen [1];
            ResetWriter();

            return bytes;
        }
        protected abstract void WriteImpl();
        protected abstract void ReadImpl();

        public abstract short GetMessageType();

        public abstract string getEventType();

        protected void ReverseWrite(byte[] _byte)
        {
            Array.Reverse(_byte);
            writer.Write(_byte);
        }

        protected void WriteShort(short data)
        {
            byte[] _byte = BitConverter.GetBytes(data);
            ReverseWrite(_byte);
        }

        protected short ReadShort()
        {
            byte[] _arry = reader.ReadBytes(2);
            Array.Reverse(_arry);
            return BitConverter.ToInt16(_arry, 0);
        }

        protected void WriteInt(int data)
        {
            byte[] _byte = BitConverter.GetBytes(data);
            Array.Reverse(_byte);
            writer.Write(_byte);
        }

        protected int ReadInt()
        {
            byte[] _arry = reader.ReadBytes(4);
            Array.Reverse(_arry);
            return BitConverter.ToInt32(_arry, 0);
        }

        protected void WriteString(string data)
        {
            if (data == null || data.Length == 0)
            {
                this.WriteInt(0);
            }
            else
            {
                byte[] _bytes = DEFAULT_ENCODING.GetBytes(data);
                int _len = _bytes.Length;
                WriteInt(_len);
                writer.Write(_bytes);
            }
        }

        protected string ReadString()
        {
            int len = ReadInt();
            if (len == 0)
            {
                return "";
            }
            byte[] _bytes = reader.ReadBytes(len);

            string str = System.Text.Encoding.UTF8.GetString(_bytes);
            return str;
        }

        protected void WriteLong(Int64 data)
        {
            byte[] _bytes = BitConverter.GetBytes(data);
            ReverseWrite(_bytes);
        }

        protected long ReadLong()
        {
            byte[] _arry = reader.ReadBytes(8);
            Array.Reverse(_arry);
            return BitConverter.ToInt64(_arry, 0);
        }

        protected void WriteByte(byte data)
        {
            byte[] _arry = new byte[1];
            _arry [0] = data;
            ReverseWrite(_arry);
        }

        protected byte ReadByte()
        {
            byte[] b = reader.ReadBytes(1);
            return b [0];
        }

        protected void WriteBool(bool b)
        {
            byte[] _arry = new byte[1];
            _arry[0] = b ? (byte) 1 : (byte) 0;
            ReverseWrite(_arry);
        }

        protected bool ReadBool()
        {
            byte[] b = reader.ReadBytes(1);
            return b[0] == 1 ? true : false;
        }

        private byte[] ConvertLenToArry(short len)
        {
            byte[] _lenArry = new byte[2];
            _lenArry [0] = (byte)(len >> 8);
            _lenArry [1] = (byte)(len & 0x00FF);
            return _lenArry;
        }
        
        private void ResetWriter()
        {
            writeStream.Close();
            writer.Close();
            writeStream.Dispose();
        }

        public void Decode(byte[] bytes)
        {
            readeStream = new MemoryStream();
            reader = new BinaryReader(readeStream, DEFAULT_ENCODING);

            encMsgBody(bytes);

            if (isCompress())
            {
                unCompress(bytes, readeStream);
            }
            else
            {
                readeStream.Write(bytes, 0, bytes.Length);
            }

            readeStream.Position = 0;
            this.msgLen = ReadShort();
            short _type = ReadShort();
            
            ReadImpl();
            ResetReader();
        }

        /// <summary>
        /// ��Ϣ�����ܣ��������� ENC_ARR_LEN ���ֽ�
        /// </summary>
        /// <param name="bytes"></param>
        private void encMsgBody(byte[] bytes)
        {
            //����Ҫ���ܣ���ֱ�ӷ���
            if (!ENC_FLAG)
            {
                return;
            }

            int head = 4;
            int messageLength = bytes.Length;
            //����Ϣ���򲻴���
            if (messageLength <= head)
            {
                return;
            }

            int encLen = Math.Min(ENC_ARR_LEN, messageLength - head);
            for (int i = 0; i < encLen; i++)
            {
                bytes[i + head] = (byte)(bytes[i + head] ^ ENC_ARR[i]);
            }
        }

        private void unCompress(byte[] bytes, MemoryStream readeStream)
        {
            int head = 4;
            byte[] compressBodyArr = new byte[bytes.Length - head];
            Array.Copy(bytes, head, compressBodyArr, 0, compressBodyArr.Length);
            byte[] unCompressBodyArr = ZlibStream.UncompressBuffer(compressBodyArr);
            short newLen = (short)(unCompressBodyArr.Length + head);
            byte[] lenByte = BitConverter.GetBytes(newLen);
            Array.Reverse(lenByte);

            readeStream.Write(lenByte, 0, lenByte.Length);
            readeStream.Write(bytes, lenByte.Length, head - lenByte.Length);
            readeStream.Write(unCompressBodyArr, 0, unCompressBodyArr.Length);
        }

        private void ResetReader()
        {
            readeStream.Close();
            reader.Close();
            readeStream.Dispose();
            
        }

        public virtual bool isCompress()
        {
            return false;
        }
    }
}

