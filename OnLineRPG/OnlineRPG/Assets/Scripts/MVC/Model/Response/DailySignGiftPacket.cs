using System.Collections;
using System.Collections.Generic;
using BetaFramework;
public class RepDailySignGiftPacket : SerializablePacket
{
    public int code;
    public RepDailySignGiftData data;
}
public class RepClamDailySignGiftPacket : SerializablePacket
{
    public int code;
}
public class RepDailySignGiftData
{
    public int Id;
    public int Rid;
    public Dictionary<string,int> Config;
}