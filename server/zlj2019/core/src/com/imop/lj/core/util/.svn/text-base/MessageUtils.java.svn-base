package com.imop.lj.core.util;

import java.io.UnsupportedEncodingException;

import org.apache.mina.core.buffer.IoBuffer;

import com.imop.lj.common.constants.SharedConstants;

/**
 * 消息写入ByteBuff的一些公用方法,待修改 (来自天书)
 *
 *
 */
public class MessageUtils {
	public static void writeByte(int data, IoBuffer buffer) {
		if (buffer != null) {
			buffer.put((byte) data);
		}

	}

	public static void writeShort(int data, IoBuffer buffer) {
		if (buffer != null) {
			buffer.putShort((short) data);
		}

	}

	public static void writeInt(int data, IoBuffer buffer) {
		if (buffer != null) {
			buffer.putInt(data);
		}

	}

	public static void writeInt(float data, IoBuffer buffer) {
		if (buffer != null) {
			buffer.putInt((int) (data + 0.5));
		}

	}

	public static void writeLong(long data, IoBuffer buffer) {
		if (buffer != null) {
			buffer.putLong(data);
		}

	}

	public static void writeFloat(float data, IoBuffer buffer) {
		if (buffer != null) {
			buffer.putFloat(data);
		}

	}

	public static void writeDouble(double data, IoBuffer buffer) {
		if (buffer != null) {
			buffer.putDouble(data);
		}

	}

	public static void writeBytes(byte[] data, IoBuffer buffer) {
		if (buffer != null) {
			buffer.put(data);
		}
	}

	public static void writeString(String str, IoBuffer buffer) {
		writeString(str, buffer, SharedConstants.DEFAULT_CHARSET);
	}

	private static void writeString(String str, IoBuffer buffer, String charset) {
		try {
			if (str == null) {
				str = "";
			}
			if (buffer != null) {
				byte[] bytes = str.getBytes(charset);
				buffer.putShort((short) bytes.length);
				buffer.put(bytes);
			}

		} catch (UnsupportedEncodingException e) {
			e.printStackTrace();
		}
	}

	public static int readInt(IoBuffer buffer) {
		if (buffer != null) {
			return buffer.getInt();
		} else {
			return 0;
		}
	}

	public static short readShort(IoBuffer buffer) {
		if (buffer != null) {
			return buffer.getShort();
		} else {
			return 0;
		}
	}

	public static String readString(IoBuffer buffer) {
		return readString(SharedConstants.DEFAULT_CHARSET, buffer);
	}

	protected static String readString(String charset, IoBuffer buffer) {
		short len = buffer.getShort();
		byte[] bytes = new byte[len];
		buffer.get(bytes);
		try {
			return new String(bytes, charset);
		} catch (UnsupportedEncodingException e) {
			e.printStackTrace();
			return "";
		}

	}

	public static Long readLong(IoBuffer buffer) {
		if (buffer != null) {
			return buffer.getLong();
		} else {
			return 0L;
		}
	}

	public static Float readFloat(IoBuffer buffer) {
		if (buffer != null) {
			return buffer.getFloat();
		} else {
			return 0f;
		}
	}

	public static Double readDouble(IoBuffer buffer) {
		if (buffer != null) {
			return buffer.getDouble();
		} else {
			return 0.0d;
		}
	}

}
