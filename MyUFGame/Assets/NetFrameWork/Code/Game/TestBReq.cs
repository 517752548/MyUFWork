using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBReq : Request
{
    private string info = "";
    public override int GetProtocol()
    {
        return NetProtocols.TEST_B;
    }

    public TestBReq(string info)
    {
        this.info = info;
    }

    public override void Deserialize(DataStream reader)
    {
        base.Deserialize(reader);
        
    }

    public override void Serialize(DataStream writer)
    {
        base.Serialize(writer);
        writer.WriteString32(info);
    }
}
