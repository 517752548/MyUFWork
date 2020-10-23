/// <summary>
/// 超链接类型定义
/// </summary>
public class LinkTypeDef
{
    //找怪,类型：101，参数依次为：怪物所在地图id
    public const int FindMonster = 101;
    //找NPC,类型：102，参数依次为：怪物所在地图id，npcid
    public const int FindNPC = 102;
    //链接到功能，类型：103，参数为：功能id
    public const int LinkToFunc = 103;
    //到地图上的某个位置使用物品，类型：104，参数为：地图id,道具模板id,[道具uuid]
    public const int UseItem = 104;
    //挂机
    public const int GuaJI = 105;



    //申请入队，类型:1001,参数依次为：队伍id
    public const int ShenQingRuDui = 1001;


}
