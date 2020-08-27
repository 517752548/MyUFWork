using System.Collections.Generic;
using BetaFramework;

public class RepOnLinePacket : SerializablePacket
{
    public int code;
    public Dictionary<string, Dictionary<string, object>> data;
}

public class RepOnLineBackPacket : SerializablePacket
{
    public int code;
    public RepOnLineData data;
}

public class RepOnLineData
{
    public int itemType;
    public int itemId;
    public int number;
    public bool status;
}

public class RepChangeOnLinePacket : SerializablePacket
{
    public int code;
    public bool status;
    public Dictionary<string, Dictionary<string, object>> data;
}