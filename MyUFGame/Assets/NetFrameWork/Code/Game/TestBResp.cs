using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBResp : Resp {

    public override int GetProtocol()
    {
        return NetProtocols.TEST_B;
    }

    public override void Deserialize(DataStream reader)
    {
        base.Deserialize(reader);
        System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
        byte[] message = reader.GetTotalByte();
        string back =  encoding.GetString(message);
        //string back = reader.ReadString();
        Debug.LogError(back);

    }
}
