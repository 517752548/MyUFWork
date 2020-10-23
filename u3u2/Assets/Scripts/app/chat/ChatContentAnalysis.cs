using System;

/// <summary>
/// 聊天内容解析,聊天内容使用json结构
/// 聊天内容中的表情、道具、宠物等输入后，若在中间修改，则修改出前面的还可以正常显示，后面的全部当纯文本显示
/// </summary>
public class ChatContentAnalysis
{
    
    public static bool Parse(string exhibitionStr)
    {
        string[] exhiArr = exhibitionStr.Split(ChatContentBase.SPLIT_SUB);
        try
        {
            switch (int.Parse(exhiArr[0]))
            {
                case ChatContentType.PET:
                    if (exhiArr.Length == 5 && int.Parse(exhiArr[0]) != 0 && int.Parse(exhiArr[3]) != 0)
                    {
                        return true;
                    }
                    break;
                case ChatContentType.ITEM:
                    if (exhiArr.Length == 6 && int.Parse(exhiArr[0]) != 0 && int.Parse(exhiArr[3]) != 0 && int.Parse(exhiArr[4]) != 0)
                    {
                        return true;
                    }
                    break;
                case ChatContentType.FUNC:
                    if (exhiArr.Length == 3 && int.Parse(exhiArr[0]) != 0 && int.Parse(exhiArr[1]) != 0)
                    {
                        return true;
                    }
                    break;
                case ChatContentType.SHENQING_RUDUI:
                    if (exhiArr.Length == 3 && int.Parse(exhiArr[0]) != 0 && int.Parse(exhiArr[1]) != 0)
                    {
                        return true;
                    }
                    break;
                case ChatContentType.JIAWEI_HAOYOU:
                    if (exhiArr.Length == 3 && int.Parse(exhiArr[0]) != 0 && !string.IsNullOrEmpty(exhiArr[1]))
                    {
                        return true;
                    }
                    break;
                case ChatContentType.ROLE:
                    if (exhiArr.Length == 3 && int.Parse(exhiArr[0]) != 0 && !string.IsNullOrEmpty(exhiArr[1]))
                    {
                        return true;
                    }
                    break;
                default:
                    return false;
                    break;
            }
        }
        catch (Exception e)
        {
            return false;
        }
        return false;
    }
}

/// <summary>
/// 聊天内容类型
/// </summary>
public class ChatContentType
{
    //纯文本
    public const int TEXT = 1;
    //宠物
    public const int PET = 2;
    //物品
    public const int ITEM = 3;
    //有功能id的
    public const int FUNC = 4;
    //申请入队
    public const int SHENQING_RUDUI = 5;
    //加为好友
    public const int JIAWEI_HAOYOU = 6;
    //人物名称
    public const int ROLE = 7;
}
    
/// <summary>
/// 内容基类
/// </summary>
public class ChatContentBase
{
    /// <summary>
    /// 表情字符串格式：#001，长度为4
    /// </summary>
    public const int FACE_CHAT_NUM = 4;
    public const char FACE_PREFIX = '#';
    public const char SPLIT_MAIN = '$';
    public const char SPLIT_SUB = '|';
    /// <summary>
    /// 表情帧率
    /// </summary>
    public const int FACE_FRAME_RATE = 3;

    public string content;

    public virtual string toString()
    {
        return SPLIT_MAIN + ChatContentType.TEXT + SPLIT_SUB + content + SPLIT_MAIN;
    }

    public virtual void setText(string text)
    {
        content = text;
    }
}
/// <summary>
/// 表情内容类
/// </summary>
public class ChatContentFace : ChatContentBase
{
    public string faceid;
    public virtual string toString()
    {
        //return SPLIT_MAIN + "" + ChatContentType.FACE + "" + SPLIT_SUB + faceid + SPLIT_MAIN;
        return "";
    }
    public override void setText(string text)
    {
        content = text;
        string[] arr = content.Split(SPLIT_SUB);
        faceid = arr[1];
    }
}
/// <summary>
/// 物品内容类
/// </summary>
public class ChatContentItem : ChatContentBase
{
    public string roleId;
    public string itemUUID;
    public int itemTplID;
    public int itemQuality;
    public string itemName;

    public virtual string toString()
    {
        return SPLIT_MAIN.ToString() + ChatContentType.ITEM
            + SPLIT_SUB.ToString() + roleId
            + SPLIT_SUB.ToString() + itemUUID
            + SPLIT_SUB.ToString() + itemTplID
            + SPLIT_SUB.ToString() + itemQuality
            + SPLIT_SUB.ToString() + itemName
            + SPLIT_MAIN.ToString();
    }

    public override void setText(string text)
    {
        content = text;
        string[] arr = content.Split(SPLIT_SUB);
        roleId = arr[1];
        itemUUID = arr[2];
        itemTplID = int.Parse(arr[3]);
        itemQuality = int.Parse(arr[4]);
        itemName = arr[5];
    }

}
/// <summary>
/// 宠物内容类
/// </summary>
public class ChatContentPet : ChatContentBase
{
    public string roleId;
    public string petUUID;
    public int petTplID;
    public string petName;

    public virtual string toString()
    {
        return SPLIT_MAIN.ToString() + ChatContentType.PET
            + SPLIT_SUB.ToString() + roleId
            + SPLIT_SUB.ToString() + petUUID
            + SPLIT_SUB.ToString() + petTplID
            + SPLIT_SUB.ToString() + petName
            + SPLIT_MAIN.ToString();
    }

    public override void setText(string text)
    {
        content = text;
        string[] arr = content.Split(SPLIT_SUB);
        roleId = arr[1];
        petUUID = arr[2];
        petTplID = int.Parse(arr[3]);
        petName = arr[4];
    }
}
/// <summary>
/// 功能内容类
/// </summary>
public class ChatContentFunc : ChatContentBase
{
    public int funcID;
    public string funcName;

    public virtual string toString()
    {
        return SPLIT_MAIN + "" + ChatContentType.FUNC
            + SPLIT_SUB + "" + funcID
            + SPLIT_SUB + "【" + funcName + "】"
            + SPLIT_MAIN;
    }

    public override void setText(string text)
    {
        content = text;
        string[] arr = content.Split(SPLIT_SUB);
        funcID = int.Parse(arr[1]);
        funcName = arr[2];
    }
}