using System.IO;
using System.Text;

public class GByteArray
{
	public const string BIG_ENDIAN = "BIG_ENDIAN";
	public const string LITTLE_ENDIAN = "LITTLE_ENDIAN";

	private MemoryStream _memoryStream;
	public string endian = LITTLE_ENDIAN;
	private const byte BooleanFalse = 0;
	private const byte BooleanTrue = 1;


	public GByteArray()
	{
		_memoryStream = new MemoryStream();
		_memoryStream.Capacity = 512;
	}

	public GByteArray(MemoryStream ms)
	{
		_memoryStream = ms;
		_memoryStream.Capacity = 512;
	}

	public void Clear()
	{
		if (_memoryStream != null)
		{
			_memoryStream.SetLength(0);
			Position = 0;
		}
	}

	public void Dispose()
	{
		if (_memoryStream != null)
		{
			_memoryStream.Close();
			_memoryStream.Dispose();
		}
		_memoryStream = null;
	}

	public int Length
	{
		get
		{
			return (int)_memoryStream.Length;
		}
	}

	public int Position
	{
		get { return (int)_memoryStream.Position; }
		set { _memoryStream.Position = value; }
	}

	public int BytesAvailable
	{
		get { return Length - Position; }
	}

	public byte[] GetBuffer()
	{
		return _memoryStream.GetBuffer();
	}

	public byte[] ToArray()
	{
		return _memoryStream.ToArray();
	}

	public MemoryStream MemoryStream
	{
		get
		{
			return _memoryStream;
		}
	}

	public bool ReadBoolean()
	{
		return _memoryStream.ReadByte() == BooleanTrue;
	}

	public byte ReadByte()
	{
		return (byte)_memoryStream.ReadByte();
	}

	public void ReadBytes(byte[] bytes, int offset, int length)
	{
		_memoryStream.Read(bytes, (int)offset, (int)length);
	}

	public void ReadBytes(GByteArray bytes, int offset, int length)
	{
		int tmp = bytes.Position;
		int count = (int)(length != 0 ? length : BytesAvailable);
		for (int i = 0; i < count; i++)
		{
			bytes._memoryStream.Position = i + offset;
			bytes._memoryStream.WriteByte(ReadByte());
		}
		bytes.Position = tmp;
	}

	private byte[] priReadBytes(int c)
	{
		byte[] a = new byte[c];
		if (endian == GByteArray.BIG_ENDIAN)
		{
			//BIG_ENDIAN
			for (int i = 0; i < c; i++)
			{
				a[c - 1 - i] = (byte)_memoryStream.ReadByte();
			}
		}
		else
		{
			//LITTLE_ENDIAN
			for (int i = 0; i < c; i++)
			{
				a[i] = (byte)_memoryStream.ReadByte();
			}
		}
		return a;
	}

	public double ReadDouble()
	{
		byte[] bytes = priReadBytes(8);
		double value = System.BitConverter.ToDouble(bytes, 0);
		return value;
	}

	public float ReadFloat()
	{
		byte[] bytes = priReadBytes(4);
		float value = System.BitConverter.ToSingle(bytes, 0);
		return value;
	}

	public int ReadInt()
	{
		byte[] bytes = priReadBytes(4);
		int value = System.BitConverter.ToInt32(bytes, 0);
		return value;
	}

	public short ReadShort()
	{
		byte[] bytes = priReadBytes(2);
		short value = System.BitConverter.ToInt16(bytes, 0);
		return value;
	}

	public long ReadLong()
	{
		byte[] bytes = priReadBytes(8);
		long value = System.BitConverter.ToInt64(bytes, 0);
		return value;
	}

    public string ReadUTF(int length = 0)
	{
        if (length == 0)
        {
            length = ReadInt();
        }
        byte[] encodedBytes = new byte[length];
        for (int i = 0; i < length; i++)
        {
            encodedBytes[i] = (byte)_memoryStream.ReadByte();
        }
        return Encoding.UTF8.GetString(encodedBytes, 0, encodedBytes.Length);
    }

	public string ReadString(int length = 0)
	{
		if (length == 0)
		{
			length = ReadInt();
		}
		byte[] encodedBytes = new byte[length];
		for (int i = 0; i < length; i++)
		{
			encodedBytes[i] = (byte)_memoryStream.ReadByte();
		}
		Encoding e = Encoding.GetEncoding("gb2312");
		return e.GetString(encodedBytes, 0, encodedBytes.Length);
	}

    public string ReadLongToString()
    {
        return ((long)ReadLong()).ToString();
    }

    public void WriteBoolean(bool value)
	{
		WriteByte((byte)(value ? BooleanTrue : BooleanFalse));
	}

	public void WriteByte(byte value)
	{
		_memoryStream.WriteByte(value);
	}

	public void WriteBytes(byte[] bytes, int offset, int length)
	{
		for (int i = offset; i < offset + length; i++)
		{
			if (i < bytes.Length)
			{
				_memoryStream.WriteByte(bytes[i]);
			}
			else
			{
				break;
			}
		}
	}

	public void WriteBytes(GByteArray bytes, int offset, int length)
	{
		byte[] data = bytes.ToArray();
		WriteBytes(data, offset, length);
	}

	public void WriteDouble(double value)
	{
		byte[] bytes = System.BitConverter.GetBytes(value);
		WriteBigEndian(bytes);
	}

	private void WriteBigEndian(byte[] bytes)
	{
		if (bytes == null)
			return;
		if (endian == GByteArray.BIG_ENDIAN)
		{
			//BIG_ENDIAN
			for (int i = bytes.Length - 1; i >= 0; i--)
			{
				WriteByte(bytes[i]);
			}
		}
		else
		{
			//LITTLE_ENDIAN;
			for (int i = 0; i < bytes.Length; i++)
			{
				_memoryStream.WriteByte(bytes[i]);
			}
		}
	}

	public void WriteFloat(float value)
	{
		byte[] bytes = System.BitConverter.GetBytes(value);
		WriteBigEndian(bytes);
	}

	public void WriteInt(int value)
	{
		WriteInt32(value);
	}

	private void WriteInt32(int value)
	{
		byte[] bytes = System.BitConverter.GetBytes(value);
		WriteBigEndian(bytes);
	}

	public void WriteShort(short value)
	{
		byte[] bytes = System.BitConverter.GetBytes(value);
		WriteBigEndian(bytes);
	}

	public void WriteLong(long value)
	{
		byte[] bytes = System.BitConverter.GetBytes(value);
		WriteBigEndian(bytes);
	}

	public void WriteUTF(string value, int length = 0)
	{
        byte[] bytes = Encoding.UTF8.GetBytes(value);
        if (length == 0)
        {
            length = bytes.Length + 1;
            this.WriteInt(length);
        }

        byte[] lengthBytes = new byte[length];
        if (length > bytes.Length)
        {
            for (int i = 0; i < bytes.Length; ++i)
            {
                lengthBytes[i] = bytes[i];
            }
            lengthBytes[bytes.Length] = (byte)'\0';
        }
        else
        {
            if(length > 0)
            {
                for (int i = 0; i < length - 1; ++i)
                {
                    lengthBytes[i] = bytes[i];
                }
                lengthBytes[length - 1] = (byte)'\0';
            }
        }
        this.WriteBytes(lengthBytes, 0, lengthBytes.Length);
    }
	//非UTF8编码的string
	public void WriteString(string value, int length = 0)
	{
		int size = value.Length;
		string result = value;
		if (length > 0)
		{
			int pad = length - size;
			if (pad > 0)
			{
				for (int i = 0; i < pad; i++)
				{
					result += "\0";
				}
			}
			else
			{
				result = result.Substring(0, length);
			}
		}
		else
		{
			this.WriteInt(size);
		}
		Encoding e = Encoding.GetEncoding("gb2312");
		byte[] bytes = e.GetBytes(result);
		if (bytes != null && bytes.Length > 0)
		{
			this.WriteBytes(bytes, 0, bytes.Length);
		}
	}

    public void WriteStringToLong(string v)
    {
        WriteLong((long)(long.Parse(v)));
    }
}