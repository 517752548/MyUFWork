using System.Collections;
using System.Collections.Generic;
using System.Net;
using BetaFramework;
using UnityEngine;

public class NetText : MonoBehaviour
{
    private string url = "121.40.165.18";

    private string url2 = "127.0.0.1";
    // Start is called before the first frame update
    void Start()
    {
        SocketHelper.GetInstance().Connect(url2,8800, () =>
        {
            Debug.LogError("连接成功");
            Debug.LogError("发送消息");
            SocketHelper.GetInstance().SendMessage(new Datareq());
        }, () =>
        {
            Debug.LogError("连接失败");
        });
    }
    
}


public class Datareq : Request
{
    private string data = "121213123";
    public override void Serialize(DataStream writer)
    {
        writer.WriteSInt32(GetProtocol());
        writer.WriteRaw(("abcdefg".ToBytes()));
        //writer.WriteByte(("abcdefg".ToBytes()));
    }
}
