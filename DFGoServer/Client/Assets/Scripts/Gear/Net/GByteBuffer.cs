using System;
using System.IO;
using System.Collections;
public class GByteBuffer : IDispose
{
	private byte[] _buffer;
	private int _position;
	public int Length
	{
		get
		{
			return Buffer.Length;
		}
	}

	public int Position
	{
		get
		{
			return _position;
		}

		set
		{
			_position = value;
			if (_position > Length)
			{
				_position = Length;
			}
		}
	}

	public int BytesAvailable
	{
		get { return Length - Position; }
	}

	public byte[] Buffer
	{
		get
		{
			return _buffer;
		}
	}

	public GByteBuffer(int length)
	{
		_position = 0;
		_buffer = new byte[length];
	}
	// 从stream流写入到自身
	// 返回写入的字节数
	public int WriteFromStream(Stream stream)
	{
		if (null == stream)
			return 0;

		int count = stream.Read(_buffer, _position, BytesAvailable);
		_position += count;
		return count;
	}
	// 读取到bytearray中
	public void ReadToByteArray(GByteArray byteArray)
	{
		if (null == byteArray)
			return;
		byteArray.WriteBytes(_buffer, 0, _position);
	}

	public void Clear()
	{
		_position = 0;
		Array.Clear(_buffer, 0, _buffer.Length);
	}

	public void Dispose()
	{
		_position = 0;
		_buffer = null;
	}

}
