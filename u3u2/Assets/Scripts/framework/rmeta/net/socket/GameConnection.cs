using System;
using app.net;
using app.config;
using app.zone;
using UnityEngine;

public enum ConnectionState
{
    init,

    need_connect,
    connecting,
    connected,
    connect_timeout,

    need_reconnect,
    reconnect_doing,
    reconnect_success,
    reconnect_timeout,

    login_success,
}

public class GameConnection : IBackToLogin
{
    //最多重连次数
    private static int MAX_RECONNECT_TIMES = 3;

    /**单例对象*/
    private static GameConnection _instance;
    /**socket 对象*/
    private SocketClient socketClient;
    /**是否成功登陆过*/
    private bool _hasConnected;
    //3秒连接一次
    private int interval = 3000;
    public int Interval
    {
        get { return interval; }
    }
    //重连次数，计数用
    private int count = 0;
    public int Count
    {
        get { return count; }
        set { count = value; }
    }
    //定时连接用的timer
    private RTimer lastTimer;
    public RTimer LastTimer
    {
        get { return lastTimer; }
        set { lastTimer = value; }
    }

    private ConnectionState connState = ConnectionState.init;
    public ConnectionState ConnState
    {
        get { return connState; }
    }

    private BaseMessage lastFailMsg;
    public BaseMessage LastFailMsg
    {
        get { return lastFailMsg; }
        set { lastFailMsg = value; }
    }

    private void updateConnState(ConnectionState connState)
    {
        this.connState = connState;
        ClientLog.LogWarning("GameConnection ConnectionState=" + this.connState);
    }

    private GameConnection()
    {
    }

    /**
    * 获得单例
    */
    public static GameConnection Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameConnection();
            }
            return _instance;
        }
    }

    public bool HasConnected
    {
        get { return _hasConnected; }
        set { _hasConnected = value; }
    }

    /**
        * 建立链接
        */
    public void connect(string serverIp, string port)
    {
        socketClient = new SocketClient(serverIp, port);
        //状态变为 连接中
        updateConnState(ConnectionState.connecting);
        socketClient.TryConnect();
    }

    public void reConnect(string serverIp, string port)
    {
        socketClient.createSocket(serverIp, port);
        //状态变为 重连中
        updateConnState(ConnectionState.reconnect_doing);
        socketClient.TryConnect();
    }

    /**
        * 获取 socket 是否链接
        */
    public bool IsConnected()
    {
        return socketClient != null && socketClient.IsConnected();
    }

    /**
        * 发送消息
        */
    public void sendMessage(BaseMessage msg)
    {
        socketClient.SendMessage(msg);
    }

    public BaseMessage getMsg()
    {
        if (socketClient != null)
        {
            return socketClient.DequeueMsg();
        }
        return null;
    }

    public BaseMessage[] getAllMsg()
    {
        if (socketClient != null)
        {
            return socketClient.getAllMsg();
        }
        return null;
    }

    public bool isInited()
    {
        return socketClient != null;
    }

    public bool isConnecting()
    {
        return ConnState == ConnectionState.connecting;
    }

    public bool isNeedReconnect()
    {
        return ConnState == ConnectionState.need_reconnect;
    }

    public bool isNeedConnect()
    {
        return connState == ConnectionState.need_connect;
    }

    private bool isNativeConnected()
    {
        return connState == ConnectionState.connected;
    }

    public bool isReconnectDoing()
    {
        return ConnState == ConnectionState.reconnect_doing;
    }

    public bool isReconnectSuccess()
    {
        return ConnState == ConnectionState.reconnect_success;
    }

    public bool isReconnectTimeout()
    {
        return ConnState == ConnectionState.reconnect_timeout;
    }

    public bool isConnectTimeout()
    {
        return connState == ConnectionState.connect_timeout;
    }

    public bool isLoginSuccess()
    {
        return ConnState == ConnectionState.login_success;
    }

    public void onConnFailed(string source)
    {
        //记录错误日志，连接失败的来源
        ClientLog.LogWarning("onConnFailed source=" + source +
            ";lastSendMsg=" + LastFailMsg +
            ";ConnState=" + ConnState);

        //连接中，或连接超时
        if (isConnecting() || isConnectTimeout() ||
            isNativeConnected())//connected时断开是因为重新登录，服务器踢人
        {
            //这种情况是第一次登陆就失败，此时重连还是使用connect，不使用reConnect
            updateConnState(ConnectionState.need_connect);
        }
        else if (!isReconnectDoing() && !isNeedReconnect())
        {
            //如果未处于 需要重连 或 重连中 状态，则置为 需要重连 状态
            updateConnState(ConnectionState.need_reconnect);
        }
        else
        {
            ClientLog.LogWarning("onConnFailed but no handler!ConnState=" + ConnState);
        }
    }

    public void onConnSuccess()
    {
        if (isConnecting())
        {
            updateConnState(ConnectionState.connected);

            //派发连接完成的回调事件，发CGPlayerLogin消息
            EventCore.dispathRMetaEventByParms(GlobalConstDefine.ConnServerSuccess, null);
        }
    }

    public void onReconnSuccess()
    {
        if (isReconnectDoing())
        {
            updateConnState(ConnectionState.reconnect_success);

            //派发连接完成的回调事件，发CGPlayerTokenLogin消息
            EventCore.dispathRMetaEventByParms(GlobalConstDefine.ReConnServerSuccess, null);
        }
    }

    private void resetData()
    {
        //计时器清零
        if (LastTimer != null)
        {
            LastTimer.stop();
            LastTimer = null;
        }
        //重连计数清零
        Count = 0;
    }

    public void onServerKick(GCNotifyException errormsg)
    {
        switch (errormsg.getCode())
        {
            //TODO 服务器主动踢人，需要退出到登录界面 FIXME
            case 1007://GM踢人
            case 1010://token登录验证失败
                //只响应pop层事件
                //LayerConfig.ChangeUICameraEventMask(LayerConfig.Layer_Pop);
                RMetaEventHandler retryHandler = delegate (RMetaEvent @event)
                {
                    ClientLog.LogError("#GameConnection#exitGame");
                    Application.Quit();
                };
                ConnectFailView.Instance.PopView();
                ////踢掉用户，到登录状态
                //bool flag = StateManager.Ins.changeState(StateDef.login);
                //if (!flag)
                //{
                //    ClientLog.LogError("#GameConnection#onServerKick#force to login panel failed!");
                //}
                //ClientLog.LogError("force to login panel!errorCode=" + errorCode + ";changeStateFlag=" + flag);
                break;
            case 1009:
                if (!string.IsNullOrEmpty(errormsg.getErrMsg()))
                {
                    ZoneBubbleManager.ins.BubbleSysMsg(errormsg.getErrMsg());
                }
                break;
            case 1005://服务器人满
                if (!string.IsNullOrEmpty(errormsg.getErrMsg()))
                {
                    ZoneBubbleManager.ins.BubbleSysMsg(errormsg.getErrMsg());
                }
                break;
            default:
                onConnFailed("onServerKick");
                break;
        }
    }

    public void onBackToLogin()
    {
        connState = ConnectionState.init;
        if (socketClient != null)
        {
            socketClient.Close();
            socketClient = null;
        }
        count = 0;
        if (lastTimer != null)
        {
            lastTimer.stop();
            lastTimer = null;
        }

        //恢复事件响应层
        //LayerConfig.ResetUICameraEventMask();
        //弹出框都消失掉
        ConnectingView.Instance.hide();
        ConnectFailView.Instance.hide();
    }

    public void onSendMsgFailed(BaseMessage lastSendMsg)
    {
        ClientLog.LogWarning("onSendMsgFailed");

        if (null != lastSendMsg)
        {
            LastFailMsg = lastSendMsg;
        }

        onConnFailed("onSendMsgFailed");
    }

    public void onReceiveMsgFailed()
    {
        ClientLog.LogWarning("onReceiveMsgFailed");
        onConnFailed("onReceiveMsgFailed");
    }

    /// <summary>
    /// 登录成功的状态更新
    /// 收到服务器GCUpdateToken后调用
    /// </summary>
    public void onLoginSuccess()
    {
        if (!isLoginSuccess())
        {
            updateConnState(ConnectionState.login_success);

            resetData();
        }
    }

    /// <summary>
    /// 重新登录全部完毕，发送上一次失败的消息给服务器
    /// 收到服务器GCEnterScene后调用
    /// </summary>
    public void onReloginFinished()
    {
        ClientLog.LogWarning("onReloginFinished");
        //恢复事件响应层
        //LayerConfig.ResetUICameraEventMask();
        //连接成功，取消连接中的显示
        ConnectingView.Instance.hide();

        //最后一次发送失败的消息，继续发
        if (canSendMsgAfterRelogin(LastFailMsg))
        {
            //sendMessage(LastFailMsg);
        }
        LastFailMsg = null;
    }

    private bool canSendMsgAfterRelogin(BaseMessage lastFailMsg = null)
    {
        bool flag = false;
        if (lastFailMsg != null &&
                lastFailMsg.GetType() != typeof(CGPlayerLogin) &&
                lastFailMsg.GetType() != typeof(CGPlayerTokenLogin))
        {
            flag = true;
        }

        ClientLog.LogWarning("lastFailMsg=" + lastFailMsg + "; flag=" + flag);
        return flag;
    }

    private void onReconnTimeout()
    {
        if (!isReconnectTimeout())
        {
            updateConnState(ConnectionState.reconnect_timeout);

            resetData();
        }
    }

    private void onConnTimeout()
    {
        if (!isConnectTimeout())
        {
            updateConnState(ConnectionState.connect_timeout);

            resetData();
        }
    }

    public void checkOnUpdate()
    {
        if (!isInited() || isLoginSuccess())
        {
            return;
        }

        //需要重连，且timer还没启动，则启动
        if ((isNeedConnect() || isNeedReconnect()) &&
            LastTimer == null)
        {
            //只响应pop层事件
            //LayerConfig.ChangeUICameraEventMask(LayerConfig.Layer_Pop);
            //显示连接中
            ConnectingView.Instance.preLoadUI();

            //立即重连，如果使用timer，则会延迟3秒再重连
            checkReConn(null);
        }
    }

    /// <summary>
    /// 定时检查重连
    /// </summary>
    /// <param name="rtimer"></param>
    private void checkReConn(RTimer rtimer)
    {
        try
        {
            if (isLoginSuccess())
            {
                return;
            }

            if (Count >= MAX_RECONNECT_TIMES)
            {
                if (isReconnectDoing() || isNeedReconnect())
                {
                    onReconnTimeout();
                }
                else if (isConnecting() || isNeedConnect())
                {
                    onConnTimeout();
                }

                //重连超时，显示连接失败面板
                ConnectingView.Instance.hide();
                ConnectFailView.Instance.PopView();
                return;
            }

            LastTimer = TimerManager.Ins.createTimer(Interval, Interval, null, checkReConn);
            LastTimer.start();

            Count++;
            ClientLog.LogWarning("try re-connect..." + Count);

            //如果是第一次连接失败，则调用connect，如果是游戏中断线则调用reConnnect
            if (isReconnectDoing() || isNeedReconnect())
            {
                //reConnect(ClientConfig.Ins.SocketServerIP, ClientConfig.Ins.SocketServerPort);
                reConnect(ServerConfig.instance.gameServer, ServerConfig.instance.gamePort);
            }
            else if (isConnecting() || isNeedConnect())
            {
                //connect(ClientConfig.Ins.SocketServerIP, ClientConfig.Ins.SocketServerPort);
                connect(ServerConfig.instance.gameServer, ServerConfig.instance.gamePort);
            }
        }
        catch (Exception e)
        {
            ClientLog.LogError("checkReConn Exception!e=" + e.ToString());
        }
    }

    public void onClickRetry()
    {
        onConnFailed("#GameConnection#onClickRetry");
    }
}