package com.imop.lj.core.util;

import org.apache.mina.core.buffer.IoBuffer;
import org.apache.mina.core.buffer.IoBufferAllocator;
import org.apache.mina.core.buffer.SimpleBufferAllocator;

/**
 * Io相关的工厂类
 *
 *
 */
public class IoFactory {
	private static final IoBufferAllocator allocator = new SimpleBufferAllocator();

	/**
	 * 创建指定大的小Mina IoBuffer,使用SimpleByteBufferAllocator创建,同时将其设置为自动扩展
	 *
	 * @param capacity
	 * @return
	 */
	public static IoBuffer allocateByteBuffer(int capacity) {
		return allocator.allocate(capacity, false).setAutoExpand(true);
	}

	/**
	 * 将指定的byte数组包装成为Mina ByteBuffer的实现
	 *
	 * @param src
	 * @return
	 */
	public static IoBuffer wrapperByteBuffer(byte[] src) {
		return allocator.wrap(java.nio.ByteBuffer.wrap(src));
	}
}
