using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;

public enum GSocketConnectionState
{
	None,
	Connecting,
	Connected,
	Disconnected
}
public enum GSocketError
{
	None,
	Normal, // 服务器停服
	SocketError, // 网络错误
	Initiative, // 主动断开
	Timeout, // 超时断开
}
public class GTCPSocket : ITicker
{
	private GSocketConnectionState _connectionState;
	private GSocketError _lastError;
	private TcpClient _tcpClient = null;
	private string _ip;
	private int _port;
	private Queue<GByteArray> _sendQueue;
	private Queue<GByteArray> _receiveQueue;
	private GByteArray _receiveByteArray;
	private int _curMsgLength = -1;
	private const int MaxRead = 8192;
	private byte[] byteBuffer = new byte[MaxRead];
	private float _conTimer = 0;
	private const float ConTimeOut = 3;

	public GSocketConnectionState ConnectionState
	{
		get
		{
			return _connectionState;
		}
	}
	public GSocketError LastError
	{
		get
		{
			return _lastError;
		}
	}
	public GTCPSocket()
	{
		_connectionState = GSocketConnectionState.None;
		_sendQueue = new Queue<GByteArray>();
		_receiveQueue = new Queue<GByteArray>();
		_receiveByteArray = new GByteArray();
		_curMsgLength = -1;
		TickRunner.GetInstance().AddTicker(this);
	}

	public bool Connect(string ip, int port)
	{
		ReleaseAll();

		_ip = ip;
		_port = port;

		// 检测传入参数合法性
		if (_port <= 0)
		{
			GDebug.LogError("Port is invalid.");
			return false;
		}
		if (string.IsNullOrEmpty(_ip))
		{
			GDebug.LogError("Ip is invalid.");
			return false;
		}

		// 检测TCP连接状态
		if (_tcpClient != null && _tcpClient.Connected)
		{
			GDebug.LogError("TcpClient is connected : " + ToString());
			return false;
		}

		// 检测自身保留状态
		if (_connectionState == GSocketConnectionState.Connecting)
		{
			GDebug.LogWarning("Is connecting : " + ToString());
			return false;
		}
		if (_connectionState == GSocketConnectionState.Connected)
		{
			GDebug.LogWarning("Is connected : " + ToString());
			return false;
		}

		// 设置状态
		SetConnectionState(GSocketConnectionState.Connecting);

		try
		{
			AddressFamily ipType = AddressFamily.InterNetwork;
			_tcpClient = new TcpClient(ipType);
			_tcpClient.NoDelay = true;
			_tcpClient.SendTimeout = 1000;
			_tcpClient.ReceiveTimeout = 1000;
			_tcpClient.ReceiveBufferSize = GSocketDefine.RECEIVE_BUFFER_SIZE;
			_tcpClient.SendBufferSize = GSocketDefine.SEND_BUFFER_SIZE;

			_tcpClient.Client.BeginConnect(ip, port, new AsyncCallback(ConnectCallback), _tcpClient);
		}
		catch (SocketException e)
		{
			HandleSocketError("Connect failed SocketException: " + e.Message + " " + e.StackTrace);
		}
		catch (Exception e)
		{
			HandleSocketError("Connect failed Exception: " + e.Message + " " + e.StackTrace);
		}

		return true;
	}

	void ConnectCallback(IAsyncResult ar)
	{
		lock (_tcpClient.GetStream())
		{
			_tcpClient = (TcpClient)ar.AsyncState;
			_tcpClient.EndConnect(ar);
		}

		if (_tcpClient.Connected)
		{
			_tcpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

			SetConnectionState(GSocketConnectionState.Connected);

			IPEndPoint endPoint = (IPEndPoint)_tcpClient.Client.LocalEndPoint;
			GDebug.Log("Local ip {0}, on port {1}", endPoint.Address.ToString(), endPoint.Port.ToString());

			try
			{
				_tcpClient.GetStream().BeginRead(byteBuffer, 0, MaxRead, new AsyncCallback(ReceiveCallback), null);
			}
			catch (SocketException e)
			{
				HandleSocketError("Read failed SocketException: " + e.Message + " " + e.StackTrace);
			}
			catch (Exception e)
			{
				HandleSocketError("Read failed Exception: " + e.Message + " " + e.StackTrace);
			}
		}
	}

	void ReceiveCallback(IAsyncResult asr)
	{
		try
		{
			var bytesRead = 0;
			lock (_tcpClient.GetStream())
			{
				//读取字节流到缓冲区
				bytesRead = _tcpClient.GetStream().EndRead(asr);
			}
			if (bytesRead < 1)
			{
				//包尺寸有问题，断线处理
				HandleSocketError("Read callback failed packet size");
				return;
			}

			//分析数据包内容，抛给逻辑层
			OnReceive(byteBuffer, bytesRead);

			lock (_tcpClient.GetStream())
			{
				//分析完，再次监听服务器发过来的新消息
				Array.Clear(byteBuffer, 0, byteBuffer.Length); //清空数组
				_tcpClient.GetStream().BeginRead(byteBuffer, 0, MaxRead, new AsyncCallback(ReceiveCallback), null);
			}
		}
		catch (SocketException e)
		{
			HandleSocketError("Read callback failed SocketException: " + e.Message + " " + e.StackTrace);
		}
		catch (Exception e)
		{
			HandleSocketError("Read callback failed Exception: " + e.Message + " " + e.StackTrace);
		}
	}

	void OnReceive(byte[] bytes, int length)
	{
		_receiveByteArray.Position = _receiveByteArray.Length;
		_receiveByteArray.WriteBytes(bytes, 0, length);
		_receiveByteArray.Position = 0;
		_curMsgLength = -1;
		while (_receiveByteArray.BytesAvailable > 0)
		{
			// 数据没有大于包头长度
			if (_receiveByteArray.BytesAvailable < GSocketDefine.MSG_HEAD_SIZE)
			{
				break;
			}
			if (_curMsgLength == -1)
			{
				_receiveByteArray.Position = GSocketDefine.MSG_CONTENT_COMPRESS_SIZE_POS;
				//包体长度
				_curMsgLength = _receiveByteArray.ReadInt();
				_receiveByteArray.Position = GSocketDefine.MSG_HEAD_SIZE;
			}
			if (_receiveByteArray.BytesAvailable >= _curMsgLength)
			{
				//一个消息的内容 包头+内容(压缩或未压缩)
				GByteArray b = new GByteArray();
				_receiveByteArray.Position = 0;
				_receiveByteArray.ReadBytes(b, 0, GSocketDefine.MSG_HEAD_SIZE + _curMsgLength);
				//清空当前接收的 放入一次
				GByteArray tempB = new GByteArray();
				_receiveByteArray.ReadBytes(tempB, 0, _receiveByteArray.BytesAvailable);
				_receiveByteArray.Clear();
				_receiveByteArray = tempB;
				_receiveByteArray.Position = 0;
				_curMsgLength = -1;
				lock (_receiveQueue)
				{
					b.Position = GSocketDefine.MSG_ID_POS;
					int msgID = b.ReadShort();
					b.Position = 0;
					_receiveQueue.Enqueue(b);
				}
			}
			else
			{
				break;
			}
		}
	}


	public void Disconnect(bool timeOut)
	{
		lock (this)
		{
			GSocketError reason = timeOut ? GSocketError.Timeout : GSocketError.Initiative;
			SetConnectionState(GSocketConnectionState.Disconnected, reason);
			ReleaseAll();
		}
	}
	/// <summary>
	/// 写消息到队列（主线程调用）
	/// </summary>
	public void Send(GByteArray byteArray)
	{
		if (_connectionState == GSocketConnectionState.Disconnected)
		{
			GDebug.LogWarning("Send Failed, because you are not connected. Please start server and try again. {0}", GetType());
			return;
		}

		//不使用队列发送，直接发送
		WriteToNetworkStream(byteArray);
	}

	public void OnTick()
	{
		if (_connectionState == GSocketConnectionState.Connecting)
		{
			_conTimer += Time.deltaTime;
			if (_conTimer > ConTimeOut)
			{
				_conTimer = 0;
				Disconnect(true);
			}
		}
		else if (_connectionState == GSocketConnectionState.Connected)
		{
			CheckSend();
		}
	}

	public void OnLateTick() { }

	private void CheckSend()
	{
		if (null == _sendQueue || _sendQueue.Count <= 0)
			return;

		while (_sendQueue.Count > 0)
		{
			GByteArray byteArray = _sendQueue.Dequeue();
			WriteToNetworkStream(byteArray);
		}
	}
	private void WriteToNetworkStream(GByteArray byteArray)
	{
		try
		{
			byte[] byteData = byteArray.ToArray();
			lock (_tcpClient.GetStream())
			{
				_tcpClient.GetStream().BeginWrite(byteData, 0, byteData.Length, new AsyncCallback(SendCallback), null);
			}
			byteArray.Dispose();
			byteArray = null;
		}
		catch (SocketException exception)
		{
			HandleSocketError("Send Failed SocketException:" + exception.Message + " " + exception.SocketErrorCode);
		}
		catch (Exception exception)
		{
			HandleSocketError("Send Failed Exception:" + exception.Message + " " + exception.StackTrace);
		}
	}

	void SendCallback(IAsyncResult ar)
	{
		try
		{
			lock (_tcpClient.GetStream())
			{
				_tcpClient.GetStream().EndWrite(ar);
			}
		}
		catch (SocketException exception)
		{
			HandleSocketError("Send Callback Failed SocketException:" + exception.Message + " " + exception.SocketErrorCode);
		}
		catch (Exception exception)
		{
			HandleSocketError("Send Callback Failed Exception:" + exception.Message + " " + exception.StackTrace);
		}
	}

	public GByteArray PopMessageByteArray()
	{
		if (null == _receiveQueue)
			return null;

		GByteArray b = null;
		lock (_receiveQueue)
		{
			if (_receiveQueue.Count > 0)
			{
				b = _receiveQueue.Dequeue();
				return b;
			}
		}

		return null;
	}

	public bool HasMessageByteArray()
	{
		return _receiveQueue.Count > 0;
	}

	public int GetMessageByteArrayCount()
	{
		return _receiveQueue.Count;
	}

	private void SetConnectionState(GSocketConnectionState state, GSocketError reason = GSocketError.None)
	{
		_connectionState = state;

		if (_connectionState == GSocketConnectionState.Disconnected)
		{
			// 释放资源
			try
			{
				CloseAll();
			}
			catch (Exception exception)
			{
				HandleSocketError("Please stop server and try again." + exception + exception.StackTrace);
			}

			// 设置最近一次断网原因
			_lastError = reason;

			if (reason == GSocketError.Timeout)
				GDebug.Log("Connection closed by timeOut");
			else if (reason == GSocketError.Normal)
				GDebug.Log("Connection closed by sever.");
			else if (reason == GSocketError.Initiative)
				GDebug.Log("Connection closed by user.");
			else if (reason == GSocketError.SocketError)
				GDebug.Log("Connection closed by socketError.");
			else
				GDebug.LogError("Should never get here.");

		}

		// 打印状态
		GDebug.Log(ToString());
	}
	private void HandleSocketError(string error)
	{
		GDebug.LogWarning(error + "{0}", GetType());

		if (_connectionState == GSocketConnectionState.Connecting || _connectionState == GSocketConnectionState.Connected)
			SetConnectionState(GSocketConnectionState.Disconnected, GSocketError.SocketError);
	}

	private void CloseAll()
	{
		if (_tcpClient != null)
		{
			_tcpClient.Close();
			_tcpClient = null;
		}
		_curMsgLength = -1;
		_sendQueue.Clear();
		_receiveQueue.Clear();
		_receiveByteArray.Clear();

	}
	private void ReleaseAll()
	{
		CloseAll();
	}
	public void Dispose()
	{
		ReleaseAll();
		_sendQueue = null;
		_receiveQueue = null;
		_receiveByteArray = null;
		TickRunner.GetInstance().RemoveTicker(this);
	}
	public override string ToString()
	{
		return string.Format("{0}:{1} State:{2}", _ip, _port, _connectionState);
	}
}
