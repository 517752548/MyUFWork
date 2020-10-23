using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using app.net;

class ByteBuffer
{
    private MemoryStream leftRecvMsgBuf;
    public ByteBuffer(int maxSize)
    {
        this.leftRecvMsgBuf = new MemoryStream(maxSize);
    }
    public void Put(byte[] data, int length)
    {
        leftRecvMsgBuf.Write(data, 0, length);
    }
    public void Put(byte[] data)
    {
        leftRecvMsgBuf.Write(data, 0, data.Length);
    }
    public void Get(byte[] data)
    {
        leftRecvMsgBuf.Read(data, 0, data.Length);
    }
    public void Flip()
    {
        this.leftRecvMsgBuf.Seek(0, SeekOrigin.Begin);
    }
    public void Compact()
    {
        if (leftRecvMsgBuf.Position == 0)
        {
            // ���������Ǳ�����ǰbuffer�е��������ݣ���Ҫ��position�õ�ĩβ
            endPosition();
            return;
        }
        long _remaining = this.Remaining();
        if (_remaining <= 0)
        {
            this.Clear();
            return;
        }
        byte[] _leftData = new byte[_remaining];
        this.Get(_leftData);
        this.Clear();
        this.Put(_leftData);
    }
    public void Clear()
    {
        leftRecvMsgBuf.Seek(0, SeekOrigin.Begin);
        leftRecvMsgBuf.SetLength(0);
    }
    public long Remaining()
    {
        return leftRecvMsgBuf.Length - leftRecvMsgBuf.Position;
    }
    public Boolean HasRemaining()
    {
        return leftRecvMsgBuf.Length > leftRecvMsgBuf.Position;
    }
    public long Position()
    {
        return leftRecvMsgBuf.Position;
    }
    public long Length()
    {
        return leftRecvMsgBuf.Length;
    }
    public void setPosition(long position)
    {
        leftRecvMsgBuf.Seek(position, SeekOrigin.Begin);
    }
    public void endPosition()
    {
        leftRecvMsgBuf.Seek(leftRecvMsgBuf.Length, SeekOrigin.Begin);
    }
}

public enum EClientConnectState
{
    CONNECT_STATE_NONE,
    CONMECT_STATE_TIME_OUT,
    CONNECT_STATE_CAN_RECONNECT,
    CONNECT_STATE_TRY_CONNECT,
    CONNECT_STATE_CONNECTED,
    CONNECT_STATE_DO_TRY_CONNECT
}

struct IPaddressWrapper
{
    public IPEndPoint ipPoint;
    public bool isTried;
}

class MsgReveiveHelper
{
    public Socket socket;
    public byte[] buffer;
}

public class SocketClient
{
    private const int MAX_MSG_PER_LOOP = 16;

    EClientConnectState ConnectState = EClientConnectState.CONNECT_STATE_NONE;

    IPaddressWrapper[] ipAddressArry;

    Socket socketClient;

    Queue<BaseMessage> recMsgs;

    ByteBuffer recMsgBuf;

    const int DEFAULT_RECEIVE_SIZE = 64 * 1024;
    const int DEFAULT_SEND_SIZE = 32 * 1024;

    GCmessageRevognizor msgRecognizer;

    bool m_bSecurityPolicy = false;

    static private object _ErrorLock = new object();
    static private int _showErrorIndex = 0;
    static private int _ErrorCode = 0;
    static private SocketError _SocketError;

    bool needReConnect;

    private BaseMessage lastSendMsg;

    public SocketClient(string serverIp, string serverPorts)
    {
        msgRecognizer = new GCmessageRevognizor();
        recMsgBuf = new ByteBuffer(BaseMessage.MAX_MSG_LEN);
        recMsgs = new Queue<BaseMessage>();

        createSocket(serverIp, serverPorts);
    }

    public void createSocket(string serverIp, string serverPorts)
    {
        if (socketClient != null)
        {
            socketClient.Close();
            ClientLog.LogWarning("old socketClient close!socketClient=" + socketClient);
            socketClient = null;
        }
		String newServerIp = "";
		AddressFamily newAddressFamily = AddressFamily.InterNetwork;
		IPv6SupportMidleware.getIPType(serverIp, serverPorts, out newServerIp, out newAddressFamily);

		if (!string.IsNullOrEmpty(newServerIp)) { serverIp = newServerIp; }
		socketClient = new Socket(newAddressFamily, SocketType.Stream, ProtocolType.Tcp);
//		socketClient.
        //ios64λ����������ģʽ
        socketClient.Blocking = true;
        socketClient.ReceiveBufferSize = DEFAULT_RECEIVE_SIZE;
        socketClient.SendBufferSize = DEFAULT_SEND_SIZE;

        //socketClient.ReceiveTimeout = 30000;
        //socketClient.SendTimeout = 30000;
        this.InitIpAddressArry(serverIp, serverPorts);
    }

    public void Close()
    {
        if (socketClient != null)
        {
            socketClient.Close();
        }
    }

    public BaseMessage DequeueMsg()
    {
        lock (recMsgs)
        {
            if (recMsgs.Count > 0)
            {
                return recMsgs.Dequeue();
            }
        }
        return null;
    }

    private void EnqueueMsg(BaseMessage msg)
    {
        lock (recMsgs)
        {
            recMsgs.Enqueue(msg);
        }
    }

    public BaseMessage[] getAllMsg()
    {
        lock (recMsgs)
        {
            BaseMessage[] arr = recMsgs.ToArray();
            recMsgs.Clear();
            return arr;
        }
    }

    private void InitIpAddressArry(String serverIp, String ports)
    {
		NativeLogger.Log ("now InitIpAddressArry" + serverIp);
        IPAddress _ipAddress = IPAddress.Parse(serverIp);
        string[] _tempArray = ports.Split(',');
        int _portSize = _tempArray.Length;
        ipAddressArry = new IPaddressWrapper[_portSize];
        for (int i = 0; i < _portSize; i++)
        {
            int _port = Convert.ToInt32(_tempArray[i].Trim());
            IPaddressWrapper _addressWrapper = new IPaddressWrapper();
            _addressWrapper.ipPoint = new IPEndPoint(_ipAddress, _port);
            _addressWrapper.isTried = false;
			ipAddressArry[i] = _addressWrapper;
        }
    }

    public bool TryConnect()
    {
        try
        {
            IPEndPoint _ep = GetServerAddress();
			NativeLogger.Log("_ep.AddressFamily"+_ep.AddressFamily);
            if (null == _ep)
            {
                ConnectState = EClientConnectState.CONNECT_STATE_DO_TRY_CONNECT;
                return false;
            }
            ConnectState = EClientConnectState.CONNECT_STATE_DO_TRY_CONNECT;

            IAsyncResult ar = socketClient.BeginConnect(_ep, new AsyncCallback(ConnectCallBack), socketClient);
            
            //bool f = ar.AsyncWaitHandle.WaitOne(10000, true);
            //if (!f)
            //{
            //    ClientLog.LogError("ar.AsyncWaitHandle.WaitOne return false!");
            //}

            ClientLog.LogWarning("Connect Server:" + _ep.Address.ToString() + ": port" + _ep.Port.ToString());
            return true;
        }
        catch (SocketException se)
        {
            ClientLog.LogError("TryConnect SocketException!" +
                ";SocketException.ErrorCode=" + se.ErrorCode + ";SocketException.ToString=" + se.ToString());
        }
        catch (Exception ex)
        {
            ClientLog.LogError("TryConnect Exception! " + ex.ToString());
        }
        return false;
    }

    private IPEndPoint GetServerAddress()
    {
        for (int i = 0; i < ipAddressArry.Length; i++)
        {
            IPaddressWrapper _wrapper = ipAddressArry[i];
            if (_wrapper.isTried)
            {
                continue;
            }
            _wrapper.isTried = true;
            ipAddressArry[i] = _wrapper;
            return _wrapper.ipPoint;
        }
        return null;
    }

    private void ConnectCallBack(IAsyncResult ar)
    {
		bool isSuccess = false;

        try
        {

            Socket _socket = (Socket)ar.AsyncState;
            if (!_socket.Connected)
            {
//                ClientLog.LogError("Connect failed:" + _socket.LocalEndPoint +
//                    ";_SocketError=" + _SocketError + ";_socket " + _socket.RemoteEndPoint
//                    + ";Available=" + _socket.Available);
            }
            else
            {
                ConnectState = EClientConnectState.CONNECT_STATE_CONNECTED;
				ClientLog.LogWarning("ConnectCallBack3");
                _socket.EndConnect(ar);

//                ClientLog.LogWarning("ConnectCallBack connect successful! LocalEndPoint=" +
//                    _socket.LocalEndPoint + ";RemoteEndPoint=" + _socket.RemoteEndPoint
//                    + ";Available=" + _socket.Available);

                //���ӳɹ�
                if (GameConnection.Instance.isConnecting())
                {
                    GameConnection.Instance.onConnSuccess();
                }
                else if (GameConnection.Instance.isReconnectDoing())
                {
                    GameConnection.Instance.onReconnSuccess();
                }

                isSuccess = true;

                this.StartRecevieMsg();
            }
        }
        catch (SocketException se)
        {
            ClientLog.LogError("ConnectCallBack SocketException!" +
                ";SocketException.ErrorCode=" + se.ErrorCode + ";SocketException.ToString=" + se.ToString());
        }
        catch (Exception ex)
        {
            ClientLog.LogError("ConnectCallBack Exception! " + ex.ToString());
        }
        finally
        {
            if (!isSuccess)
            {
                //��������ʧ�ܣ���Ҫ����
                GameConnection.Instance.onConnFailed("ConnectCallBack");
            }
        }
    }

    private void StartRecevieMsg()
    {
        //ClientLog.LogWarning("call StartRecevieMsg");
        MsgReveiveHelper _receiveHelper = new MsgReveiveHelper();
        _receiveHelper.socket = this.socketClient;
        _receiveHelper.buffer = new byte[DEFAULT_RECEIVE_SIZE];
        beginReceive(_receiveHelper);
    }

    private void beginReceive(MsgReveiveHelper _receiveHelper)
    {
        //ClientLog.LogWarning("call beginReceive,_receiveHelper.buffer.Length��" + _receiveHelper.buffer.Length);

        _receiveHelper.socket.BeginReceive(_receiveHelper.buffer, 0, _receiveHelper.buffer.Length,
            SocketFlags.None, out _SocketError, new AsyncCallback(ReceiveMsgCallback), _receiveHelper);
    }

    private void ReceiveMsgCallback(IAsyncResult receiveRes)
    {
        //ClientLog.LogWarning("call ReceiveMsgCallback");
        if (!IsConnected())
        {
            //ClientLog.LogError("ReceiveMsgCallback: the Socket is not connect");
            return;
        }

        bool isSuccess = false;
        MsgReveiveHelper _receiveHelper = null;
        try
        {
            int _recSize = this.socketClient.EndReceive(receiveRes);

            if (_recSize > 0)
            {
                _receiveHelper = (MsgReveiveHelper)receiveRes.AsyncState;
                this.DecodeMsg(_receiveHelper.buffer, _recSize);
                //ѭ��������Ϣ
                //beginReceive(_receiveHelper);

                isSuccess = true;

                //GameConnection.Instance.LastFailMsg = null;
            }
            else
            {
                ClientLog.LogError("ReceiveMsgCallback error, now close session!_recSize="
                    + _recSize + ";_SocketError=" + _SocketError + ";  time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                this.Close();
                if (GameConnection.Instance.HasConnected)
                {
                    GameConnection.Instance.onConnFailed("ReceiveMsgCallback! socket is closed!");
                }
                return;
            }
        }
        catch (SocketException se)
        {
            ClientLog.LogError("ReceiveMsgCallback SocketException!" +
                ";SocketException.ErrorCode=" + se.ErrorCode +
                "; SocketException.ToString=" + se.ToString() + ";  time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
        }
        catch (Exception ex)
        {
            ClientLog.LogError("ReceiveMsgCallback Exception!" + ex.ToString() + ";  time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
        }
        finally
        {
            //if (!isSuccess)
            //{
            //    //������Ϣ��ʱ�����������������������Ͽ���Ҳ��������
            //    //ֻ�ر����ӣ����򱻷����������ߺ���������������Ϣ������һ�λ��ɹ�����ʵ����Ӧ����ʧ�ܵ�
            //    this.Close();
            //    if (GameConnection.Instance.HasConnected)
            //    {
            //        GameConnection.Instance.onConnFailed("ReceiveMsgCallback! socket is closed!");
            //    }
            //}
            if (_receiveHelper != null)
            {
                beginReceive(_receiveHelper);
            }
            else
            {
                this.StartRecevieMsg();
            }
        }
    }

    public bool IsConnected()
    {
        return (null != this.socketClient && this.socketClient.Connected);
    }

    private void DecodeMsg(byte[] receiveBytes, int size)
    {
        if (size < 0)
        {
            return;
        }

        recMsgBuf.Put(receiveBytes, size);
        // position��0
        recMsgBuf.Flip();

        int count = 0;
        while (recMsgBuf.Remaining() >= BaseMessage.MIN_MSG_LEN)
        {
            long _curPosition = recMsgBuf.Position();
            byte[] _arry = new byte[BaseMessage.MSG_SIZE_LEN];
            recMsgBuf.Get(_arry);
            Array.Reverse(_arry);
            short _msgLen = BitConverter.ToInt16(_arry, 0);

            if (_msgLen <= 0)
            {
                // ��Ϣ����С�ڵ���0���Ƿ���Ȼ������������len
                continue;
            }

            // ��Ϊ_msgLenΪ��Ϣ�ܳ��ȣ����Խ�position�Ƶ���ʼ��λ��
            recMsgBuf.setPosition(_curPosition);

            if (_msgLen > recMsgBuf.Remaining())
            {
                // �ְ���һ����Ϣ̫�����ֶ��η��ġ���ʱ������ǰ���ݣ��ȴ��´δ�����
                break;
            }

            byte[] _msgData = new byte[_msgLen];
            recMsgBuf.Get(_msgData);

            count++;
            try
            {
                BaseMessage b = this.msgRecognizer.RecognizeMsg(_msgData);
                if (b == null)
                {
                    // δʶ������Ϣ����ʱ�������� XXX ��ע������ʽ��ʱ����Ҫ���� TODO
                    //ClientLog.Instance.LogError("call RecognizeMsg;unrecognize msg not handle!");
                    continue;
                }

                b.Decode(_msgData);
                ClientLog.LogWarning("ReceiveMessage:" + b.getEventType() + " " + b.GetMessageType() + ";  time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                EnqueueMsg(b);

                // ������Ϣ
                //MessageReciver.handleReviceMessage(b);
            }
            catch (Exception ex)
            {
                ClientLog.LogError("DecodeMsg error:" + ex.ToString() + ";  time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
        }

        if (recMsgBuf.HasRemaining())
        {
            //ClientLog.Instance.LogError("HasRemaining   recMsgBuf.Position=" + 
            //    recMsgBuf.Position());
            // �ְ����ȴ��´��յ���һ������
            recMsgBuf.Compact();
            //ClientLog.Instance.LogError("HasRemaining recMsgBuf.Compact();remaining=" +
            //    recMsgBuf.Remaining() + ";recMsgBuf.Position=" + recMsgBuf.Position());
        }
        else
        {
            // ȫ���������ϣ�����
            recMsgBuf.Clear();
            //ClientLog.Instance.LogError("recMsgBuf.Clear();remaining=" +
            //    recMsgBuf.Remaining());
        }
        return;
    }

    public void SendMessage(BaseMessage msg)
    {
        ClientLog.LogWarning("SendMessage:" + msg.ToString() + ";" + msg.GetMessageType() + ";  time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
        byte[] _byte = msg.Encode();
        if (_byte == null || _byte.Length <= 0)
        {
            ClientLog.LogError("send data is null:" + msg.GetType().ToString() + ";  time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            return;
        }
        this.lastSendMsg = msg;
        this.StartSendMsg(_byte);
    }

    public void StartSendMsg(byte[] bytes)
    {
        bool isSuccess = false;
        try
        {
            if (!this.IsConnected())
            {
                ClientLog.LogError("StartSendMsg is error,Server is not connect");
            }
            else
            {
                socketClient.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, out _SocketError, new AsyncCallback(SendMsgCallback), socketClient);
                isSuccess = true;
            }

            ClientLog.LogWarning("StartSendMsg isSuccess=" + isSuccess);
        }
        catch (SocketException se)
        {
            ClientLog.LogError("StartSendMsg SocketException!" +
                ";SocketException.ErrorCode=" + se.ErrorCode +
                "; SocketException.ToString=" + se.ToString());
        }
        catch (Exception ex)
        {
            ClientLog.LogError("StartSendMsg is error:" + ex.ToString() + ";_SocketError=" + _SocketError + ";  time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
        }
        finally
        {
            if (!isSuccess)
            {
                //�����쳣����Ҫ����
                GameConnection.Instance.onSendMsgFailed(this.lastSendMsg);
            }
        }
    }

    private void SendMsgCallback(IAsyncResult sendRes)
    {
        bool isSuccess = false;
        try
        {
            Socket _socket = (Socket)sendRes.AsyncState;

            SocketError errorCode = SocketError.SocketError;
            int nSendByte = _socket.EndSend(sendRes, out errorCode);
            //ClientLog.LogError("_socket.EndSend!! nSendByte:" + nSendByte);
            if (nSendByte <= 0)
            {
                ClientLog.LogError("send msg failed!" + ";_SocketError=" + _SocketError + ";  time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            }
            else 
            {
                isSuccess = true;
            }

            ClientLog.LogWarning("SendMsgCallback isSuccess=" + isSuccess + ";errorCode=" + errorCode + ";  time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
        }
        catch (SocketException se)
        {
            ClientLog.LogError("StartSendMsg SocketException!" +
                ";SocketException.ErrorCode=" + se.ErrorCode +
                "; SocketException.ToString=" + se.ToString() + ";  time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
        }
        catch (Exception ex)
        {
            ClientLog.LogError("SendMsgCallBack error:" + ex.ToString() + ";_SocketError=" + _SocketError + ";  time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
        }
        finally
        {
            if (!isSuccess)
            {
                //�����쳣����Ҫ����
                GameConnection.Instance.onSendMsgFailed(this.lastSendMsg);
            }
        }
    }

}