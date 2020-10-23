
/// <summary>
/// 常量定义
/// </summary>
public class ClientConstantDef
{
    //默认物品图标
    public const string DEFAULT_ITEM_ICON = "10029";
    //界面每一层的z值范围
    public const int PER_LAYER_Z_DEPTH = 0;
    //武将装备包道具数量
    public const int PET_MAX_EQUIP_NUM = 9;
    //主角装备位数量
    public const int ROLE_EQUIPGRID_MAXNUM = 13;
    //可以镶嵌宝石的装备位的最大位置
    public const int CAN_HAS_GEM_EQUIP_POSITION = 11;
    //武将最高星级6星
    public const int PET_MAX_STAR = 6;
    //武将配置表参数基数
    public const float PET_DIV_BASE = 1000.00f;
    //排行榜最大人数
    public const int PAIHANGBANG_MAX_MEMBER = 100;
    //战斗背景音乐名称
    public const string BATTLE_BG_MUSIC_NAME = "battleBgMusic";
    //登陆背景音乐名称
    public const string LOGIN_BG_MUSIC_NAME = "denglu_music";
    //点击按钮的音乐名称
    public const string BUTTON_CLICK_MUSIC_NAME = "buttonclick";
    //点击地面的特效的名称
    public const string CLICK_GROUND_EFFECT_NAME = "common_dianji";
    //自动寻路的范围半径
    public const int AutoQuestWalkRadius = 15;
    //自动寻路动画 名称
    public const string ZIDONG_XUNLU_EFFECT_NAME = "common_xunlu";
    //挂机
    public const string GUAJI_EFFECT_NAME = "common_guaji";

    //运粮人
    public const string YUNLIANGREN = "yunliangren";
    //时装男
    public const string SHIZHUANG_NAN = "shizhuang_nan";
    //时装女
    public const string SHIZHUANG_NV = "shizhuang_nv";

    public const int CHAT_BUBBLE_SHOW_TIME_MS = 3000;

    public static string GetSkillCostTypeName(int costType)
    {
        switch (costType)
        {
            case 1:
                return "魔法";
            case 2:
                return "怒气";
            case 3:
                return "寿命";
        }
        
        return "未定义";
    }
}

public enum ResultType
{
    NULL,
    SUCCESS,
    FAIL
}

public abstract class FormationDef
{
    // 阵型位置最大数
    public const int MAX_POSITON_NUM = 5;

    // 最多队伍数量
    public const int MAX_GROUP_NUM = 3;

    //// 前军最大人数
    //public const int MAX_FRONT_NUM = 6;
    //// 中军最大人数
    //public const int MAX_MIDDLE_NUM = 6;
    //// 后军最大人数
    //public const int MAX_BACK_NUM = 6;

    //// 最大上阵人数
    //public const int MAX_IN_NUM = 6;

    //public static PositionType getPositionType(int index)
    //{
    //    return (PositionType)index;
    //}
}

public enum PositionType
{
    /** 空位置 */
    NULL,
    /** 前 */
    FRONT,
    /** 中 */
    MIDDLE,
    /** 后 */
    BACK,
}

/// <summary>
/// 人物头顶状态
/// </summary>
public enum HeadFlag
{
    NONE,///默认
    FA_MU,///伐木
    CAI_YAO,///采药
    CAI_KUANG,///采矿
    SHOU_LIE,///狩猎
    ZHAN_DOU,///战斗
}

public enum FunctionID
{
    NONE,
    /** 使用后获取固定货币，绑定元宝，体力，阅历，声望*/
    GIVE_MONEY,
    /** 主将经验卡 */
    MAIN_PET_EXP_CARD,
    /** 副将经验卡 */
    OTHER_PET_EXP_CARD,
    /** 武将招募卡 */
    PET_HIRE_CARD,
    /** 礼包 */
    GIFE_PECK,
    /**VIP卡*/
    VIP_CARD,
    /** 激活活动坐骑 */
    GIVE_ACTIVITY_HORSE,
    /**等级材料包*/
    LEVEL_MATERIAL_PACK,
    /** 激活钱庄*/
    BANK_ACTIVITY,
    /**消耗钥匙使用物品*/
    COST_KEY_USE_ITEM,

    /** 宝图道具使用(坐标限制,到达指定地点后扣除道具) TODO 具体效果还没做 */
    FIND_PLACE_COST_ITEM,
    /** 任务中要求在指定地点使用的道具 */
    QUEST_AT_PLACE_USED,

    /** 战斗内嗑药 */
    FIGHT_DRUGS,

    /** 增加池子数值 */
    PROP_POOL_ADD,

    /**扣除宝图*/
    PROTREASURE_MAP_COST,

    /**翅膀*/
    GIVE_WING_CARD,
    /** 骑宠招募卡 */
    PET_HORSE_HIRE_CARD,
    /** 称号 */
    TITLE_CARD,
    /**双倍经验丹*/
    GIVE_DOUBLE_POINT,
    /** 技能熟练度*/
    SKILL_PROFICIENCY,
    /** 宠物技能栏*/
    PET_SKILL_BAR,
    /** 宠物资质丹*/
    PET_PROP_ITEM,
    /** 骑宠属性*/
    PET_HORSE_PROP
}

public sealed class 
CurrencyTypeDef
{
    /// <summary>
    /// 按钮上的货币，有时会显示成物品图标
    /// </summary>
    public const int ITEM = 999;
    /// <summary>
    /// 金子。
    /// </summary>
    public const int BOND = 1;
    /// <summary>
    /// 银票。
    /// </summary>
    public const int GOLD = 2;
    /** 系统赠送绑定元宝，绑定元宝可以替代礼券(GIFT_BOND)，消耗元宝(BOND)，优先消耗绑定元宝(SYS_BOND)，再消耗元宝(BOND) */
    public const int SYS_BOND = 3;
    /** 军令 */
    public const int POWER = 4;
    /// <summary>
    /// 金票。
    /// </summary>
    public const int GIFT_BOND = 5;
    /** 声望*/
    public const int HONOR = 6;
    /** 技能点 TODO 需要5分钟给一次，类似体力 */
    public const int SKILL_POINT = 7;
    /// <summary>
    /// 银子。
    /// </summary>
    public const int GOLD_2 = 8;
    /// <summary>
    /// 活力
    /// </summary>
    public const int HUOLI = 9;
    /// <summary>
    /// 帮派资金
    /// </summary>
    public const int BANGPAI_ZIJIN = 10;
    /// <summary>
    /// 免费挂机点数
    /// </summary>
    public const int GUA_JI_POINT1 = 11;
    /// <summary>
    /// 充值挂机点数
    /// </summary>
    public const int GUA_JI_POINT2 = 12;

///////客户端自定义的，用于解析奖励、获得对应的图标////////////////////////
    /// <summary>
    /// 帮贡
    /// </summary>
    public const int BANGGONG = 101;
    /// <summary>
    /// 酒馆经验
    /// </summary>
    public const int JIUGUAN_EXP = 102;
    /// <summary>
    /// 宠物经验
    /// </summary>
    public const int PET_EXP = 103;
    /// <summary>
    /// 帮派经验
    /// </summary>
    public const int CORP_EXP = 104;
    /// <summary>
    /// 骑宠经验
    /// </summary>
    public const int RIDE_EXP = 105;
///////客户端自定义的，用于解析奖励、获得对应的图标////////////////////////

    public static string GetCurrencyName(int currencyKey)
    {
        string str = "货币";
        switch (currencyKey)
        {
            case BOND:
                str = "金子";
                break;
            case GOLD:
                str = "银票";
                break;
            case SYS_BOND:
                str = "绑定金子";
                break;
            case POWER:
                str = "军令";
                break;
            case GIFT_BOND:
                str = "金票";
                break;
            case HONOR:
                str = "荣誉";
                break;
            case SKILL_POINT:
                str = "技能经验";
                break;
            case GOLD_2:
                str = "银子";
                break;
            case HUOLI:
                str = "活力";
                break;
            case BANGGONG:
                str = "帮贡";
                break;
            case JIUGUAN_EXP:
                str = "酒馆经验";
                break;
            case PET_EXP:
                str = "宠物经验";
                break;
            case CORP_EXP:
                str = "帮派经验";
                break;
            case RIDE_EXP:
                str = "骑宠经验";
                break;
        }
        return str;
    }

    public static string GetCurrencyIcon(int currencyKey)
    {
        switch (currencyKey)
        {
            case BOND:
                return "jinding";
            case GIFT_BOND:
                return "jinpiao";
            case GOLD:
                return "yinpiao";
            case GOLD_2:
                return "yinding";
            case SKILL_POINT:
                return "exp2";
            case HONOR:
                return "rongyu";
            case BANGPAI_ZIJIN:
                return "corpGold";
            case BANGGONG:
                return "banggong";
            case SYS_BOND:
                return "jinding";
            case JIUGUAN_EXP:
                return "jiuguanEXP";
            case PET_EXP:
                return "petEXP";
            case CORP_EXP:
                return "corpEXP";
            case RIDE_EXP:
                return "rideEXP";
        }
        return "";
    }

}