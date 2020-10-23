
using app.net;
using System;
using UnityEngine;

/**
 * 消息接收类
 */
public class SocketMsgReceiver : MonoBehaviour
{
    private bool flag = true;
    private int MaxNum = 50;

    private bool tmpFlag;

    private static SocketMsgReceiver _instance;
    public static SocketMsgReceiver Ins
    {
        get
        {
            if (_instance == null)
            {
                //_instance = new SocketMsgReceiver();
                _instance = GameObject.Find("ScriptsRoot").GetComponent<SocketMsgReceiver>();
                if (_instance == null)
                {
                    _instance = GameObject.Find("ScriptsRoot").AddComponent<SocketMsgReceiver>();
                }
            }
            return _instance;
        }
    }


    // Update is called once per frame
    public void Update()
    {
        GameConnection.Instance.checkOnUpdate();

        handlerGCMsg();
    }

    private void handlerGCMsg()
    {
        //try
        //{
            if (flag)
            {
                int i = 0;
                for (; i < MaxNum; i++)
                {
                    BaseMessage msg = GameConnection.Instance.getMsg();
                    if (null != msg)
                    {
                        try
                        {
                            MessageReciver.handleReviceMessage(msg);
                        }
                        catch (Exception e)
                        {
                            ClientLog.LogError("handlerGCMsg Exception!e=" + e.ToString());
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        //}
        //catch (Exception e)
        //{
        //    ClientLog.LogError("handlerGCMsg Exception!e=" + e.ToString());
        //    flag = false;
        //}
    }

}
