using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ServerConstantDef
{
    /// <summary>
    /// 宠物最高悟性
    /// </summary>
    public const string PET_MAX_WUXING = "1027";

    /// <summary>
    /// 创建帮派需要的银票
    /// </summary>
    public const string CREATE_CORP_COST_GOLD = "1028";

    //武将最高品质11
    public const string PET_MAX_QUALITY_ID = "1029";
    //武将初始技能等级1
    public const string PET_INIT_SKILL_LEVEL = "1030";
    //宠物 每级加点的数量3
    public const string JIADIAN_PER_LEVEL_PET = "1031";
    //武将 每级加点的数量3
    public const string JIADIAN_PER_LEVEL_ROLE = "1032";
    //玩家最高级100
    public const string PLAYER_MAX_LEVEL = "1033";
    //装备升星的最大星数13
    public const string EQUIP_MAX_STAR_NUM = "1034";
    //每个装备位可以拥有的最大宝石数量10
    public const string MAX_GEM_NUM_PERGRID = "1035";
    //宝石的最大等级9
    public const string MAX_GEM_LEVEL = "1036";

    //松木令
    public const string EXAM_ITEM1 = "2001";
    //玉木灵
    public const string EXAM_ITEM2 = "2002";

    //普通宠物天赋技能所需道具Id
    public const string PET_TALENT_ITEMID = "2003";
    //天赋技能所需道具数量
    public const string PET_TALENT_ITEMNUM = "2004";
    //限时答题 奖励物品
    public const string XIANSHIDATI_REWARD_ITEM = "2005";
    //神兽天赋技能所需道具Id
    public const string PET_TALENT_SHENSHOU_ITEMID = "2006";
    //骑宠天赋技能道具id
    public const string PET_HORSE_TALENT_ITEMID = "2007";
    //骑宠神兽天赋技能道具id
    public const string PET_HORSE_TALENT_SHENSHOU_ITEMID = "2008";
    //酒馆刷新消耗物品模板id
    public const string PUB_TASK_REFRESH_ITEMID = "3001";
    //酒馆刷新消耗银票数量
    public const string PUB_TASK_REFRESH_GOLD_NUM = "3002";
    //洗点消耗物品模板id
    public const string RESET_POINT_ITEMID = "3010";
    //学池最大值
    public const string POOL_HP_MAX = "3020";
    //蓝池最大值
    public const string POOL_MP_MAX = "3021";
    //寿命池最大值
    public const string POOL_LIFE_MAX = "3022";
    //怒气最大值
    public const string SP_MAX = "3030";
    //可出战宠物的最低寿命值。
    public const string BATTLE_PET_LIFE_MIN = "3050";
    /** 护送粮草任务手动刷新的道具Id */
    public const string FORAGE_TASK_REFRESH_ITEMID = "3060";
    /** 护送粮草手动刷新道具数量 */
    public const string FORAGE_TASK_REFRESH_ITEMNUM= "3061";

    /** 解除师徒关系的银票花费 */
    public const string JIECHU_SHITU_COST = "3070";
    /// <summary>
    /// 师傅的等级要求
    /// </summary>
    public const string OVERMAN_MIN_OVERMAN_LEVEL = "3071";// 65级
    /// <summary>
    /// 徒弟的等级下限
    /// </summary>
    public const string OVERMAN_MIN_LOWERMAN_LEVEL = "3072";//20级
    /// <summary>
    /// 徒弟的等级上限
    /// </summary>
    public const string OVERMAN_MAX_LOWERMAN_LEVEL = "3073";//50级
    /// <summary>
    /// 出师时要求徒弟的等级
    /// </summary>
    public const string OVERMAN_OVER_OVERMAN = "3074";// 60级
    /// <summary>
    /// 结婚队长花费
    /// </summary>
    public const string MARRY_COST = "3075";
    /// <summary>
    /// 强制离婚花费
    /// </summary>
    public const string MARRY_FORCE_FIRE = "3076";
    /// <summary>
    /// 结婚等级限制
    /// </summary>
    public const string JIEHUN_LEVEL = "3077";//40;
    /// <summary>
    /// 绿野仙踪 进入消耗的道具id
    /// </summary>
    public const string WIZARD_RAID_ENTER_ITEMID = "4001";
    
    /// <summary>
    /// 活动-推荐的活跃值系数
    /// </summary>
    public const string ACTIVITYUI_RECOMMOND_COEF = "4010";


    /// <summary>
    /// 帮派福利于职位的相关系数
    /// </summary>
    public const string PRESIDENT_BENIFIT_COEF = "5001";
    public const string VICECHAIRMAN_BENIFIT_COEF = "5002";
    public const string ELITE_BENIFIT_COEF = "5003";
    /// <summary>
    /// 结束任务引导的任务id
    /// </summary>
    public const string GUIDE_QUESTID="6000";
    /// <summary>
    /// 最大vip等级
    /// </summary>
    public const string VIP_MAX_LEVEL = "6100";

    /// <summary>
    /// 活力值
    /// </summary>
    public const string HUOLI_KEY = "6200";

    /// <summary>
    /// 修炼技能消耗银票
    /// </summary>
    public const string XIULIANJINENG_COST_MONEY = "6300";

    /// <summary>
    /// 快速战斗的速度
    /// </summary>
    public const string BATTLE_SPEEDUP_X = "6301";

    /// <summary>
    /// 酒馆满星货币数量
    /// </summary>
    public const string PUB_TASK_MANXING_GOLD_NUM = "6302";

    /// <summary>
    /// 酒馆满星货币ID
    /// </summary>
    public const string PUB_TASK_MANXING_GOLD_ID = "6303";

    /// <summary>
    /// 魔族副本-普通开启等级
    /// </summary>
    public const string MOZU_PUTONG_OPENLEVEL = "6304";

    /// <summary>
    /// 魔族副本-困难开启等级
    /// </summary>
    public const string MOZU_KUNNAN_OPENLEVEL = "6305";

    /// <summary>
    /// 提升熟练度道具Id
    /// </summary>
    public const string TI_SHENG_SHULIAN_DU_ID = "6306";

    /// <summary>
    /// 提升熟练度数量
    /// </summary>
    public const string TI_SHENG_SHULIAN_DU_NUM = "6307";

    /// <summary>
    /// 扩展技能栏道具id
    /// </summary>
    public const string KUO_ZHAN_JI_NENG_LAN_ID = "6308";

    /// <summary>
    /// 领悟技能消耗寿命
    /// </summary>
    public const string PET_LING_WU_JI_NENG_SHOU_MING = "6309";
    /// <summary>
    /// 骑宠领悟技能消耗寿命
    /// </summary>
    public const string PET_HORSE_LING_WU_JI_NENG_SHOU_MING = "6400";
    /// <summary>
    /// 镶嵌宝石 第一个道具 的成功率，小数,需要*100
    /// </summary>
    public const string GEM_UP_PROB1 = "6401";
    /// <summary>
    /// 镶嵌宝石 第二个道具 的成功率，小数,需要*100
    /// </summary>
    public const string GEM_UP_PROB2 ="6402";
    /// <summary>
    /// 摘除宝石 第一个道具 的成功率，小数,需要*100
    /// </summary>
    public const string GEM_DOWN_PROB1="6403";
    /// <summary>
    /// 摘除宝石 第二个道具 的成功率，小数,需要*100
    /// </summary>
    public const string GEM_DOWN_PROB2="6404";
    /// <summary>
    /// 镶嵌和摘除宝石的时候，有概率降级，降的等级数
    /// </summary>
    public const string GEM_LEVEL_COEF="6405";
    /// <summary>
    /// 挂机点计算系数
    /// </summary>
    public const string GUAJI_DIAN_XI_SHU = "6501";
    /// <summary>
    /// 免费挂机点上限
    /// </summary>
    public const string GUAJI_DIAN_MIANFEI_MAX = "6502";
    /// <summary>
    /// 生活技能CD采集进度条走的时间
    /// </summary>
    public const string SHENGHUO_CD = "6503";
    /// <summary>
    /// 生活技能消耗MP
    /// </summary>
    public const string SHENGHUO_MP = "6504";
    /// <summary>
    /// 资源点采集范围
    /// </summary>
    public const string ZIYUAN_FANWEI = "6505";
    
    /// <summary>
    /// 宠物悟性批量提升的次数，50次
    /// </summary>
    public const string PET_PERCEPT_TIMES = "6601";
    /// <summary>
    /// 祈福仙葫消耗，每次固定消耗，消耗金子
    /// </summary>
    public const string XIANHU_QIFU_COST = "6701";
    /// <summary>
    /// 祝福仙葫消耗，消耗=次数*单位消耗，消耗银子
    /// </summary>
    public const string XIANHU_ZHUFU_COST = "6702";
    /// <summary>
    /// 骑宠忠诚度上限
    /// </summary>
    public const string PET_HORSE_ZHONG_CHENG_MAX = "6703";
    /// <summary>
    /// 骑宠亲密度上限
    /// </summary>
    public const string PET_HORSE_QIN_MI_MAX = "6704";
    /// <summary>
    /// 兑换挂机点货币类型,如2 - 银票
    /// </summary>
    public const string GUA_JI_DIAN_HUO_BI_TYPE = "6705";
    /// <summary>
    /// 兑换挂机点数量
    /// </summary>
    public const string GUA_JI_DIAN_DUI_HUAN_NUM = "6706";

}
