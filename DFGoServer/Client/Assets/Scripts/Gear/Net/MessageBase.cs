using System;
using System.IO;
using Unity.IO.Compression;
public class MessageBase : IMessageBase, IDispose
{
	protected short _messageID;
	protected string _messageType;
	protected int _messageLength;
	protected int _compressedLength;
	protected GByteArray _byteArray = new GByteArray();
	public short MessageID
	{
		get
		{
			return _messageID;
		}
		set {
			_messageID = value;
		}
	}

	public GByteArray ByteArray
	{
		get
		{
			return _byteArray;
		}
		set
		{
			_byteArray = value;
		}
	}

	public virtual void Encode()
	{
		_byteArray.Position = 0;
		int dataSize = _byteArray.Length;
		int compressDataSize = 0;
		GByteArray contentByteArray = new GByteArray();

        contentByteArray.WriteShort((short)_messageID);
        contentByteArray.WriteShort((short)GSocketDefine.netIdx);
        contentByteArray.WriteBytes(_byteArray, 0, _byteArray.Length);

        System.Random rand = new System.Random();
        byte result = (byte)rand.Next(255);
        int checkSum = CheckSum(result, contentByteArray.ToArray(), contentByteArray.Length);

        if (dataSize > GSocketDefine.COMPRESS_THRESHOLD)
		{
			//—πÀı
			MemoryStream ms = new MemoryStream();
			using (DeflateStream ds = new DeflateStream(ms, CompressionMode.Compress, true))
			{
				ds.Write(_byteArray.ToArray(), 0, _byteArray.Length);
			};
            byte[] ziparr = ms.ToArray();
            contentByteArray.Clear();
            contentByteArray.WriteShort((short)_messageID);
            contentByteArray.WriteShort((short)GSocketDefine.netIdx);
            contentByteArray.Position = 0;
			compressDataSize = ziparr.Length;

            _byteArray.Clear();
            _byteArray.WriteShort(GSocketDefine.MSG_HEAD_MAGIC);
            _byteArray.WriteInt(compressDataSize);
            _byteArray.WriteByte(result);
            _byteArray.WriteByte((byte)checkSum);
            _byteArray.WriteInt(dataSize);
            _byteArray.WriteBytes(EncryptPak(contentByteArray.ToArray(), contentByteArray.Length), 0, contentByteArray.Length);
            _byteArray.WriteBytes(EncryptPak(ziparr, ziparr.Length), 0, ziparr.Length);
        }
		else if (dataSize > 0)
		{
            _byteArray.Clear();
            _byteArray.WriteShort(GSocketDefine.MSG_HEAD_MAGIC);
            _byteArray.WriteInt(dataSize);
            _byteArray.WriteByte(result);
            _byteArray.WriteByte((byte)checkSum);
            _byteArray.WriteInt(0);
            contentByteArray.Position = 0;
            _byteArray.WriteBytes(EncryptPak(contentByteArray.ToArray(), contentByteArray.Length), 0, contentByteArray.Length);
        }
        else
        {
            _byteArray.Clear();
            _byteArray.WriteShort(GSocketDefine.MSG_HEAD_MAGIC);
            _byteArray.WriteInt(0);
            _byteArray.WriteByte(result);
            _byteArray.WriteByte((byte)checkSum);
            _byteArray.WriteInt(0);
            contentByteArray.Position = 0;
            _byteArray.WriteBytes(EncryptPak(contentByteArray.ToArray(), contentByteArray.Length), 0, contentByteArray.Length);
        }

		_byteArray.Position = 0;
		contentByteArray.Dispose();
		contentByteArray = null;
	}
	public virtual void Decode()
	{
		_byteArray.Position = GSocketDefine.MSG_CONTENT_COMPRESS_SIZE_POS;
		int compressDataSize = _byteArray.ReadInt();
		_byteArray.Position = GSocketDefine.MSG_CONTENT_SIZE_POS;
		int dataSize = _byteArray.ReadInt();
		_byteArray.Position = GSocketDefine.MSG_ID_POS;
		short msgID = _byteArray.ReadShort();
		_messageID = msgID;
		_byteArray.Position = GSocketDefine.MSG_HEAD_SIZE;

        GByteArray contentByteArray = new GByteArray();
        contentByteArray.WriteBytes(_byteArray, _byteArray.Position, _byteArray.BytesAvailable);
        byte[] message = DecryptPak(contentByteArray.ToArray(), contentByteArray.Length);

        if (dataSize != 0)
		{
            //Ω‚—πÀı
            contentByteArray.Clear();
            contentByteArray.WriteBytes(message, 0, message.Length);
            byte[] temp = new byte[dataSize];
            using (DeflateStream ds = new DeflateStream(contentByteArray.MemoryStream, CompressionMode.Decompress, true))
			{
				ds.Read(temp, 0, contentByteArray.Length);
			};
            _byteArray.Clear();
            _byteArray.WriteBytes(temp, 0, temp.Length);
        }
		else
		{
            _byteArray.Clear();
            _byteArray.WriteBytes(message, 0, message.Length);
		}
        _byteArray.Position = 0;
        contentByteArray.Dispose();
		contentByteArray = null;
	}

	public void Dispose()
	{
		_messageID = 0;
		_messageType = null;
		_messageLength = 0;
		_compressedLength = 0;
		_byteArray.Dispose();
		_byteArray = null;
	}

	public override string ToString()
	{
		return string.Format("[MessageBase: _messageID={0}, _messageType={1}, _messageLength={2}, _compressedLength={3}]", _messageID, _messageType, _messageLength, _compressedLength);
	}


    private int CheckSum(int seed, byte[] data, int len)
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

    public byte[] EncryptPak(byte[] data, int len)
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

    public byte[] DecryptPak(byte[] data, int len)
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

}
