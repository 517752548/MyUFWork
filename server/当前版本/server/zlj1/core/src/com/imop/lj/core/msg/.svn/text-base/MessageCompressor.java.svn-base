package com.imop.lj.core.msg;

import java.io.ByteArrayOutputStream;
import java.util.zip.Deflater;
import java.util.zip.Inflater;

import org.apache.mina.core.buffer.IoBuffer;

/**
 * 消息数据压缩工具类
 * 
 * 
 */
public class MessageCompressor {
	/**
	 * 将指定消息的消息体进行压缩,通过调用message的{@link BaseMessage#writeImpl()}
	 * 将消息体的数据写入到字节流中再对该字节流进行压缩
	 * 
	 * @param message
	 */
	public static boolean compressMessageBody(BaseMessage message) {
		IoBuffer _old = message.getBuffer();
		IoBuffer _temp = IoBuffer.allocate(message.getInitBufferLength());
		_temp.setAutoExpand(true);
		message.setBuffer(_temp);
		message.writeImpl();
		_temp.flip();
		message.setBuffer(_old);
		byte[] compress_bytes = _temp.array();
		if(compress_bytes == null || compress_bytes.length <= 0){
			return false;
		}
		ByteArrayOutputStream bout = new ByteArrayOutputStream();
		bout.write(compress_bytes, 0, _temp.limit());
//		_temp.release();

		Deflater compressor = new Deflater();
		compressor.setLevel(Deflater.BEST_SPEED);
		byte[] input = bout.toByteArray();
		bout = null;
		compressor.setInput(input);
		compressor.finish();
		ByteArrayOutputStream bos = new ByteArrayOutputStream();
		byte[] buf = new byte[512];
		while (!compressor.finished()) {
			int count = compressor.deflate(buf);
			bos.write(buf, 0, count);
		}
		try {
			bos.close();
		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			compressor.end();
		}
		byte[] compressBytes = bos.toByteArray();
		for (byte be : compressBytes) {
			_old.put(be);
		}
		return true;
	}

	/**
	 * 将指定消息的消息体进行解压缩,通过调用message的{@link BaseMessage#readImpl()}
	 * 将消息体中数据byte数值解压缩再进行read操作
	 * 
	 * @param message
	 */
	public static boolean uncompressMessageBody(BaseMessage message) {
		IoBuffer _old = message.getBuffer();

		int _op = _old.position();
		int _limit = _old.limit();
		byte[] compress_bytes = new byte[_old.limit() - _op];
		ByteArrayOutputStream bout = new ByteArrayOutputStream();
		for (int i = _op; i < _limit; i++) {
			compress_bytes[i - _op] = _old.get();
		}
		if(compress_bytes == null || compress_bytes.length <= 0){
			return false;
		}
		bout.write(compress_bytes, 0, _limit - _op);

		byte[] input = bout.toByteArray();
		Inflater decompressor = new Inflater();
		ByteArrayOutputStream bos = new ByteArrayOutputStream(input.length);
		try {
			decompressor.setInput(input);

			final byte[] buf = new byte[1024];
			while (!decompressor.finished()) {
				int count = decompressor.inflate(buf);
				bos.write(buf, 0, count);
			}
		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			decompressor.end();
		}

		byte[] uncompressBytes = bos.toByteArray();

		IoBuffer _new = IoBuffer.allocate(message.getInitBufferLength());
		_new.setAutoExpand(true);
		message.setBuffer(_new);
		for (byte be : uncompressBytes) {
			_new.put(be);
		}
		_new.flip();
		return message.readImpl();
	}
}
