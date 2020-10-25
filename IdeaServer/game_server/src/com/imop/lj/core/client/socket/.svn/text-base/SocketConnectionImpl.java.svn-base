package com.imop.lj.core.client.socket;

import java.io.EOFException;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.Socket;

import org.apache.mina.core.buffer.IoBuffer;

import com.imop.lj.core.msg.BaseMessage;
import com.imop.lj.core.util.IoFactory;

/**
 * 基于{@link Socket}实现的DBS Server的客户端连接
 *
  *
 *
 */
public class SocketConnectionImpl implements ISocketConnection {
	private Socket rawSocket;
	private OutputStream socketOut;
	private InputStream socketInput;
	private IoBuffer headerBuffer;

	public SocketConnectionImpl(Socket rawSocket) throws IOException {
		if (rawSocket == null) {
			throw new IllegalArgumentException("The rawSocket must not be null.");
		}
		this.rawSocket = rawSocket;
		this.socketOut = this.rawSocket.getOutputStream();
		this.socketInput = this.rawSocket.getInputStream();
		this.headerBuffer = IoFactory.allocateByteBuffer(BaseMessage.HEADER_SIZE);
	}

	/*
	 * (non-Javadoc)
	 *
	 * @see
	 * com.imop.webzt.dbs.client.IDBSClientConnection#send(org.apache.mina.common
	 * .IoBuffer)
	 */
	public synchronized void send(IoBuffer buffer) throws IOException {
		this.checkSocketOpen();
		final int _start = buffer.position();
		final int _len = buffer.limit() - buffer.position();
		if (_len <= 0) {
			throw new IllegalArgumentException("The buffer length is 0.");
		}
		byte[] _data = buffer.array();
		this.socketOut.write(_data, _start, _len);
	}

	/*
	 * (non-Javadoc)
	 *
	 * @see com.imop.webzt.dbs.client.IDBSClientConnection#receive()
	 */
	@Override
	public synchronized IoBuffer receive() throws IOException {
		this.checkSocketOpen();
		this.headerBuffer.clear();
		//开始读取 消息头
		for (int i = 0; i < this.headerBuffer.capacity(); i++) {
			int _data = this.socketInput.read();
			if (_data == -1) {
				throw new EOFException("The input stream has reached eof.");
			}
			headerBuffer.put((byte) _data);
		}
		headerBuffer.flip();
		final short _messageLength = headerBuffer.getShort();
		final byte[] _buffer = new byte[_messageLength];
		//拷贝消息头
		System.arraycopy(headerBuffer.array(), 0, _buffer, 0, headerBuffer.capacity());
		int _index = headerBuffer.capacity();
		int _leftLength = _messageLength - headerBuffer.capacity();

		int _readLen = 0;
		while (_leftLength > 0) {
			_readLen = this.socketInput.read(_buffer, _index, _leftLength);
			if (_readLen == -1) {
				throw new EOFException("The input stream has reached eof.");
			}
			_leftLength = _leftLength - _readLen;
			_index = _index + _readLen;
		}
		return IoFactory.wrapperByteBuffer(_buffer);
	}

	/*
	 * (non-Javadoc)
	 *
	 * @see com.imop.webzt.dbs.client.IDBSClientConnection#close()
	 */
	@Override
	public synchronized void close() throws IOException {
		if (this.rawSocket != null) {
			if (this.socketOut != null) {
				this.socketOut.close();
			}
			if (this.socketInput != null) {
				this.socketInput.close();
			}
			this.rawSocket.close();
			this.rawSocket = null;
			this.socketOut = null;
			this.socketInput = null;
		}
	}

	@Override
	public boolean isConnected() {
		return this.rawSocket.isConnected();
	}

	@Override
	public void closeNative() throws IOException {
		this.close();
	}

	/**
	 * 检查连接是否关闭
	 *
	 * @throws IOException
	 */
	private void checkSocketOpen() throws IOException {
		if (!this.rawSocket.isConnected()) {
			throw new IOException("The socket has been closed");
		}
		if (this.rawSocket.isOutputShutdown() || this.rawSocket.isInputShutdown()) {
			throw new IOException("The socket input or output stream has been closed");
		}
	}

}
