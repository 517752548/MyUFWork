using UnityEngine;
using System.Collections;
using Unity.IO.Compression;
using System.IO;

public class GSocketDefine
{
	public const int PING_INTERVAL = 3000;
	public const int SEND_BUFFER_SIZE = 256 * 1024;// 发送缓冲区大小
	public const int RECEIVE_BUFFER_SIZE = 256 * 1024; // 接收缓冲区大小
	public const int MSG_HEAD_SIZE = 16;// 消息包头大小
	public const int MSG_ID_POS = 12;// 消息包中协议ID的字节位置
	public const int MSG_CONTENT_COMPRESS_SIZE_POS = 2;//消息包中压缩后的协议长度的位置
	public const int MSG_CONTENT_SIZE_POS = 8;//消息包中实际协议长度的存放位置
	public const int MSG_INDEX_OFF_SETPOS = 4;//消息包索引偏移
	public const int COMPRESS_THRESHOLD = 128; //消息包大于这个字节需要压缩
	public const short MSG_HEAD_MAGIC = 0x52FA;//消息包 内容头部固定内容

	public static byte[] encrypt_key = {
        0x90, 0xee, 0x70, 0x07, 0x02,
	    0x78, 0xe9, 0x9e, 0x0e, 0x79,
	    0xe0, 0x87, 0x04, 0x7e, 0xe6,
	    0x90, 0x1d, 0x3a, 0xe3, 0x82,
	    0x2a, 0x6d, 0xf4, 0x52, 0x33,
	    0xfc, 0xf0, 0x8b, 0x14, 0x63
    };

	public const int encrypt_key_len = 30;

	public static int netIdx = 1;

	private static GByteArray _sendTempArray = new GByteArray();
	private static GByteArray _receiveTempArray = new GByteArray();

	public static void Encode(short msgId, GByteArray msg)
	{
		msg.Position = 0;
		int dataSize = msg.Length;
		int compressDataSize = 0;

		_sendTempArray.Clear();
		_sendTempArray.WriteShort(msgId);
		_sendTempArray.WriteShort((short)GSocketDefine.netIdx);
		_sendTempArray.WriteBytes(msg, 0, msg.Length);

		System.Random rand = new System.Random();
		byte result = (byte)rand.Next(255);
		int checkSum = CheckSum(result, _sendTempArray.ToArray(), _sendTempArray.Length);

		if (dataSize > GSocketDefine.COMPRESS_THRESHOLD)
		{
			byte[] ziparr = Compress2(msg.ToArray());

			_sendTempArray.Clear();
			_sendTempArray.WriteShort((short)msgId);
			_sendTempArray.WriteShort((short)GSocketDefine.netIdx);
			compressDataSize = ziparr.Length;

			msg.Clear();
			msg.WriteShort(GSocketDefine.MSG_HEAD_MAGIC);
			msg.WriteInt(compressDataSize);
			msg.WriteByte(result);
			msg.WriteByte((byte)checkSum);
			msg.WriteInt(dataSize);
			msg.WriteBytes(EncryptPak(_sendTempArray.ToArray(), _sendTempArray.Length), 0, _sendTempArray.Length);
			msg.WriteBytes(EncryptPak(ziparr, ziparr.Length), 0, ziparr.Length);
		}
		else if (dataSize > 0)
		{
			msg.Clear();
			msg.WriteShort(GSocketDefine.MSG_HEAD_MAGIC);
			msg.WriteInt(dataSize);
			msg.WriteByte(result);
			msg.WriteByte((byte)checkSum);
			msg.WriteInt(0);
			msg.WriteBytes(EncryptPak(_sendTempArray.ToArray(), _sendTempArray.Length), 0, _sendTempArray.Length);
		}
		else
		{
			msg.Clear();
			msg.WriteShort(GSocketDefine.MSG_HEAD_MAGIC);
			msg.WriteInt(0);
			msg.WriteByte(result);
			msg.WriteByte((byte)checkSum);
			msg.WriteInt(0);
			msg.WriteBytes(EncryptPak(_sendTempArray.ToArray(), _sendTempArray.Length), 0, _sendTempArray.Length);
		}

		msg.Position = 0;
	}
	public static void Decode(GByteArray msg)
	{
		msg.Position = GSocketDefine.MSG_CONTENT_COMPRESS_SIZE_POS;
		int compressDataSize = msg.ReadInt();
		msg.Position = GSocketDefine.MSG_CONTENT_SIZE_POS;
		int dataSize = msg.ReadInt();
		msg.Position = GSocketDefine.MSG_ID_POS;
		short msgID = msg.ReadShort();
		msg.Position = GSocketDefine.MSG_HEAD_SIZE;

		_receiveTempArray.Clear();
		_receiveTempArray.WriteBytes(msg, msg.Position, msg.BytesAvailable);
		byte[] message = DecryptPak(_receiveTempArray.ToArray(), _receiveTempArray.Length);

		if (dataSize != 0)
		{
			byte[] temp = Decompress2(message, dataSize);
			msg.Clear();
			msg.WriteBytes(temp, 0, temp.Length);
		}
		else
		{
			msg.Clear();
			msg.WriteBytes(message, 0, message.Length);
		}
		msg.Position = 0;
	}

	public static int CheckSum(int seed, byte[] data, int len)
	{
		int ret = 0;
		int i = 0;
		while (i < len)
		{
			int o = data[i];
			int pos = ((seed + o + len) % GSocketDefine.encrypt_key_len);
			ret = ret ^ GSocketDefine.encrypt_key[pos];
			i = i + 1;
		}
		return ret;
	}

	public static byte[] EncryptPak(byte[] data, int len)
	{
		byte[] tmpBytes = data;

		for (int i = 0; i < len / 2; i++)
		{
			byte tmp = data[i];

			tmpBytes[i] = (byte)((int)(data[len - i - 1]) ^ (int)(GSocketDefine.encrypt_key[(i + len) % GSocketDefine.encrypt_key_len]));
			tmpBytes[len - 1 - i] = (byte)((int)(tmp) ^ (int)(GSocketDefine.encrypt_key[(len - 1 - i + len) % GSocketDefine.encrypt_key_len]));
		}

		if (len % 2 != 0)
		{
			tmpBytes[len / 2] = (byte)((int)(data[len / 2]) ^ (int)(GSocketDefine.encrypt_key[(len / 2 + len) % GSocketDefine.encrypt_key_len]));
		}

		return tmpBytes;
	}

	public static byte[] DecryptPak(byte[] data, int len)
	{
		byte[] tmpBytes = data;

		for (int i = 0; i < len / 2; i++)
		{
			byte tmp = data[i];

			tmpBytes[i] = (byte)((int)(data[len - i - 1]) ^ (int)(GSocketDefine.encrypt_key[(len - 1 - i + len) % GSocketDefine.encrypt_key_len]));
			tmpBytes[len - 1 - i] = (byte)((int)(tmp) ^ (int)(GSocketDefine.encrypt_key[(i + len) % GSocketDefine.encrypt_key_len]));
		}

		if (len % 2 != 0)
		{
			tmpBytes[len / 2] = (byte)((int)(data[len / 2]) ^ (int)(GSocketDefine.encrypt_key[(len / 2 + len) % GSocketDefine.encrypt_key_len]));
		}

		return tmpBytes;
	}

	public static byte[] Compress2(byte[] inputBytes)
	{
        using (MemoryStream outStream = new MemoryStream())
        {
			using (DeflateStream zipStream = new DeflateStream(outStream, CompressionMode.Compress))
            {
                zipStream.Write(inputBytes, 0, inputBytes.Length);
                zipStream.Flush();
                zipStream.Dispose();
                return outStream.ToArray();
            }
        }
    }

	public static byte[] Decompress2(byte[] inputBytes, int size)
	{
        byte[] readBuffer = new byte[size];
        using (MemoryStream inputStream = new MemoryStream(inputBytes))
        {
            using (MemoryStream outStream = new MemoryStream())
            {
				using (DeflateStream zipStream = new DeflateStream(inputStream, CompressionMode.Decompress))
                {
                    int len;
                    while ((len = zipStream.Read(readBuffer, 0, readBuffer.Length)) > 0)
                    {
                        outStream.Write(readBuffer, 0, len);
                    }
                    zipStream.Flush();
                    zipStream.Dispose();
                    return outStream.ToArray();
                }
            }
        }
    }
}