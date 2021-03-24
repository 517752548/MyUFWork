using UnityEngine;
using System.Collections;
using System;
using LuaFramework;
public class GNetManager : ITicker
{
	private static GNetManager _instance;
	private GTCPSocket _socket;
	public delegate void OnConnectedDelegate();
	public OnConnectedDelegate OnConnected;
	public delegate void OnDisconnectDelegate(int error);
	public OnDisconnectDelegate OnDisconnected;
	public delegate void OnResponseDelegate(GByteArray msg);
	public OnResponseDelegate OnResponse;
	public static GNetManager GetInstance()
	{
		if (_instance == null)
		{
			_instance = new GNetManager();

		}
		return _instance;
	}

	public void Init()
	{
		_socket = new GTCPSocket();
	}

	public void Connect(string ip, int port, OnConnectedDelegate connectedCallBack = null, OnDisconnectDelegate disconnectedCallBack = null)
	{
		if (null == _socket)
			return;

		OnConnected = connectedCallBack;
		OnDisconnected = disconnectedCallBack;
		TickRunner.GetInstance().AddTicker(this);
		_socket.Connect(ip, port);
		GSocketDefine.netIdx = 1;
	}

	public void Disconnect()
	{
		TickRunner.GetInstance().RemoveTicker(this);
		_socket.Disconnect(false);
#if UNITY_ANDROID
		// NOTE : 修复安卓IL2CPP第二次连接后读取数据报错的BUG
		System.GC.Collect();
#endif
	}

	public void Send(short msgId, GByteArray byteArray)
	{
		if (null == _socket)
			return;
		if (_socket.ConnectionState == GSocketConnectionState.Connected)
		{
			GSocketDefine.Encode(msgId, byteArray);
			_socket.Send(byteArray);

			GSocketDefine.netIdx = GSocketDefine.netIdx + 1;
			if (GSocketDefine.netIdx > 9999)
			{
				GSocketDefine.netIdx = 1;
			}
		}
	}

	public void OnTick()
	{
		if (null == _socket)
			return;

		if (_socket.ConnectionState == GSocketConnectionState.Connected && OnConnected != null)
		{
			OnConnected();
			OnConnected = null;
		}

		if (_socket.ConnectionState == GSocketConnectionState.Disconnected && OnDisconnected != null)
		{
			OnDisconnected((int)_socket.LastError);
			OnDisconnected = null;
		}
		while (_socket.HasMessageByteArray())
		{
			//在这里取出返回的消息
			GByteArray b = _socket.PopMessageByteArray();
			if (null == b)
				return;

			try
			{
				b.Position = GSocketDefine.MSG_ID_POS;
				int msgID = b.ReadShort();
				GSocketDefine.Decode(b);
				Util.CallMethod("MsgManager", "OnResponse", msgID, b);
			}
			catch (Exception e)
			{
				GDebug.LogError("Msg Error {0}", e);
			}
		}
	}

	public void OnLateTick() { }
}
