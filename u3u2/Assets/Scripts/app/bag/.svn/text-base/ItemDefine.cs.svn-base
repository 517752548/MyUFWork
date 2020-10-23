using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ItemDefine
{

    public class BagId
    {
        /// <summary>
        /// 主背包
        /// </summary>
        public const int MAIN_BAG = 1;

        /// <summary>
        /// 武将装备包
        /// </summary>
        public const int PET_BAG = 3;

        /// <summary>
        /// 仓库 包
        /// </summary>
        public const int CANGKU_BAG = 5;

        /// <summary>
        /// 仙符背包
        /// </summary>
        public const int XIANFU_BAG = 6;
    }

    /// <summary>
    /// 装备穿戴的类型
    /// </summary>
    public class ItemWearTypeDefine
    {
        public const int Human = 1;
        public const int Pet = 2;
        public const int Horse = 3;
    }

    /// <summary>
    /// 物品的类型
    /// </summary>
    public class ItemTypeDefine
    {
        /** 空类型 */
        //public const int NULL = 0;
        /** 装备 */
        public const int EQUIP = 1;
        //卷轴
        public const int REEL = 2;
        //灵魂石
        public const int SOUL_STONE = 3;
        //消耗品
        public const int CONSUMABLE = 4;
        //礼包
        public const int GIFT = 5;
        //技能书
        public const int SKILL_BOOK = 6;
        //宝石
        public const int GEM = 7;
        //仙符道具
        public const int XIANFU_ITEM = 8;
        //藏宝图
        public const int CANGBAOTU = 9;
        //仙符经验石
        public const int XIANFU_EXP_ITEM = 10;
        //人物技能书
        public const int LEADER_SKILL_BOOK = 11;
        //生活技能书
        public const int SHENGHUO_SKILL_BOOK = 38;
        //骑宠技能书
        public const int QICHONG_SKILL_BOOK = 39;
        /** 灵犀仙葫，礼包类消耗品，单独定义类型，需要特殊处理 */
		public const int XIANHU_LINGXI=50;

        public static string GetItemTypeName(int itemtype)
        {
            string itemtypename = LangConstant.ITEMTYPE;
            switch (itemtype)
            {
                case EQUIP:
                    itemtypename = LangConstant.WEAPON;
                    break;
                case REEL:
                    itemtypename = LangConstant.JUANZHOU;
                    break;
                case SOUL_STONE:
                    itemtypename = LangConstant.LINGHUNSHI;
                    break;
                case CONSUMABLE:
                    itemtypename = LangConstant.XIAOHAOPIN;
                    break;
                case GIFT:
                    itemtypename = LangConstant.LIBAO;
                    break;
                case SKILL_BOOK:
                    itemtypename = LangConstant.JINENGSHU;
                    break;
                case GEM:
                    itemtypename = LangConstant.BAOSHI;
                    break;
                case CANGBAOTU:
                    itemtypename = LangConstant.CANGBAOTU;
                    break;
                case XIANFU_ITEM:
                    itemtypename = LangConstant.XIANFU;
                    break;
                case XIANFU_EXP_ITEM:
                    itemtypename = LangConstant.XIANFUJINGYANSHI;
                    break;
                case LEADER_SKILL_BOOK:
                    itemtypename = LangConstant.JINENGSHU;
                    break;
                case XIANHU_LINGXI:
                    itemtypename = LangConstant.XIANHU;
                    break;
            }
            return itemtypename;
        }
    }

    /// <summary>
    /// 物品的阶数
    /// </summary>
    public class ItemGradeDefine
    {
        /** 破碎 */
        public const int ONE = 1;
        /** 普通 */
        public const int TWO = 2;
        /** 优秀 */
        public const int THREE = 3;
        /** 完美 */
        public const int FOUR = 4;
        /** 光芒 */
        public const int FIVE = 5;


        /// 获得装备的阶数名称
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static string GetItemGradeName(int grade)
        {
            string strname = "";
            switch (grade)
            {
                case ONE:
                    strname = LangConstant.POSUI;
                    break;
                case TWO:
                    strname = LangConstant.PUTONG;
                    break;
                case THREE:
                    strname = LangConstant.YOUXIU;
                    break;
                case FOUR:
                    strname = LangConstant.WANMEI;
                    break;
                case FIVE:
                    strname = LangConstant.GUANGMANG;
                    break;
                default:
                    break;
            }
            strname = strname + LangConstant.DE;
            return strname;
        }

    }

    /// <summary>
    /// 装备位 定义
    /// </summary>
    public class ItemPositionDefine
    {
        /** 空 */
        public const int NULL = 0;
        /** 武器 */
        public const int WEAPON = 1;

        /** 头盔 */
        public const int HEAD = 2;
        /** 护肩 */
        public const int SHOULDER = 3;
        /** 披风 */
        public const int CLOAK = 4;
        /** 胸甲 */
        public const int BREAST = 5;
        /** 护腕 */
        public const int WRISTER = 6;
        /** 戒指 */
        public const int RING = 7;
        /** 项链 */
        public const int NECKLACE = 8;
        /** 腰带 */
        public const int BELT = 9;
        /** 裤子 */
        public const int PANTS = 10;
        /** 鞋子 */
        public const int BOOT = 11;

        /** 翅膀 */
        public const int WING = 12;
        /** 时装 */
        public const int FASHION = 13;
        /// <summary>
        /// 获得装备的部位名称
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static string GetEquipPositionName(int position)
        {
            string strname = LangConstant.BUWEI;
            switch (position)
            {
                    /** 空 */
                case ItemPositionDefine.NULL:
                    strname = LangConstant.KONG;
                    break;
                    /** 武器 */
                case ItemPositionDefine.WEAPON:
                    strname = LangConstant.WEAPON;
                    break;
                    /** 头盔 */
                case ItemPositionDefine.HEAD:
                    strname = LangConstant.TOUKUI;
                    break;
                    /** 护肩 */
                case ItemPositionDefine.SHOULDER:
                    strname = LangConstant.HUJIAN;
                    break;
                    /** 披风 */
                case ItemPositionDefine.CLOAK:
                    strname = LangConstant.PIFENG;
                    break;
                    /** 胸甲 */
                case ItemPositionDefine.BREAST:
                    strname = LangConstant.XIONGJIA;
                    break;
                    /** 护腕 */
                case ItemPositionDefine.WRISTER:
                    strname = LangConstant.HUWAN;
                    break;
                    /** 戒指 */
                case ItemPositionDefine.RING:
                    strname = LangConstant.JIEZHI;
                    break;
                    /** 项链 */
                case ItemPositionDefine.NECKLACE:
                    strname = LangConstant.XIANGLIAN;
                    break;
                    /** 腰带 */
                case ItemPositionDefine.BELT:
                    strname = LangConstant.YAODAI;
                    break;
                    /** 裤子 */
                case ItemPositionDefine.PANTS:
                    strname = LangConstant.KUZI;
                    break;
                    /** 鞋子 */
                case ItemPositionDefine.BOOT:
                    strname = LangConstant.XIEZI;
                    break;
                    /** 翅膀 */
                case ItemPositionDefine.WING:
                    strname = LangConstant.CHIBANG;
                    break;
                    /** 时装 */
                case ItemPositionDefine.FASHION:
                    strname = LangConstant.SHIZHUANG;
                    break;
                default:
                    break;
            }
            return strname;
        }

    }
        
    
    /// <summary>
    /// 物品属性json中key的定义
    /// </summary>
    public class ItemPropKey
    {
        /// <summary>
        /// 颜色
        /// </summary>
        public const string COLOR = "co";
        /// <summary>
        /// 阶数
        /// </summary>
	    public const string GRADE = "gr";
        /// <summary>
        /// 耐久度 分子
        /// </summary>
	    public const string DURA = "du";
        /// <summary>
        /// 评分
        /// </summary>
        public const string SCORE = "sc";
        /// <summary>
        /// 基础属性
        /// </summary>
        public const string ATTR_BASE = "ab";
        /// <summary>
        /// 基础属性附加值
        /// </summary>
        public const string ATTR_BASE_ADD = "aba";
        /// <summary>
        /// 绑定属性
        /// </summary>
        public const string ATTR_BIND = "abd";
        /// <summary>
        /// 附加属性
        /// </summary>
	    public const string ATTR = "at";
        /// <summary>
        /// 属性key
        /// </summary>
        public const string PK = "k";
        /// <summary>
        /// 属性值
        /// </summary>
        public const string PV = "b";
        /// <summary>
        /// 模板id
        /// </summary>
        public const string TemplateID = "tid";
        /// <summary>
        /// 模板id
        /// </summary>
        public const string Feature = "ft";
        /// <summary>
        /// 地图id
        /// </summary>
        public const string MapId = "mapid";
        /// <summary>
        /// 地图X
        /// </summary>
        public const string Mapx = "mapx";
        /// <summary>
        /// 地图Y
        /// </summary>
        public const string Mapy = "mapy";
        /// <summary>
        /// 仙符等级
        /// </summary>
        public const string LevelKey = "lv";
        /// <summary>
        /// 仙符经验
        /// </summary>
        public const string ExpKey = "exp";
        /// <summary>
        /// 宝石孔的key
        /// </summary>
        public const string HOLE = "ho";
        /// <summary>
        /// 宝石孔列表
        /// </summary>
        public const string HOLE_LIST = "hl";
        /// <summary>
        /// 宝石最大的孔数
        /// </summary>
        public const string HOLE_MAX = "hm";
        /// <summary>
        /// 孔上的宝石 模板id
        /// </summary>
        public const string GEM_ITEM_ID = "gid";
    }

    public class BaoShiListElem
    {
        public int color;
        public int gemItemTplId;
    }

    /// <summary>
    /// 宝石的类型
    /// </summary>
    public class BaoShiType
    {
        /** 粉红色*/
        public const int HONG = 1;
        /** 淡紫色*/
        public const int ZI = 2;
        /** 天蓝色*/
        public const int LAN = 3;
        /** 鹅黄色*/
        public const int HUANG = 4;

        ///** 红宝石 */
        //public const int HONG = 1;
        ///** 绿宝石 */
        //public const int LV = 2;
        ///** 蓝宝石 */
        //public const int LAN = 3;
        ///** 紫宝石 */
        //public const int ZI = 4;
        ///** 黄宝石 */
        //public const int HUANG = 5;
        /// <summary>
        /// 获得宝石类型名称
        /// </summary>
        /// <param name="baoshiType"></param>
        /// <returns></returns>
        public static string GetBaoShiNameByType(int baoshiType)
        {
            string baoshiname = LangConstant.BAOSHI;
            switch (baoshiType)
            {
                case BaoShiType.HONG:
                    baoshiname = LangConstant.HONGBAOSHI;
                    break;
                case BaoShiType.ZI:
                    baoshiname = LangConstant.ZIBAOSHI;
                    break;
                case BaoShiType.LAN:
                    baoshiname = LangConstant.LANBAOSHI;
                    break;
                case BaoShiType.HUANG:
                    baoshiname = LangConstant.HUANGBAOSHI;
                    break;
            }
            return baoshiname;
        }
        /// <summary>
        /// 获得宝石种类
        /// </summary>
        /// <returns></returns>
        public static int GetBaoShiMaxType()
        {
            return HUANG;
        }

    }

    public class RoleInfoPropKey
    {

        public const string roleId = "roleId";
       

	    public const string roleName = "roleName";
        

	    public const string roleLevel = "roleLevel";
        

        public const string roleTplId = "roleTplId";
        

        public const string roleFightPower = "roleFightPower";
        

        public const string roleFightPetId = "roleFightPetId";
        

	    public const string roleCorpsId = "roleCorpsId";
        

        public const string roleCorpsName = "roleCorpsName";
        /// <summary>
        /// 装备
        /// </summary>
        public const string equip = "eq";
        /// <summary>
        /// 星级
        /// </summary>
        public const string start = "st";
        /// <summary>
        /// 宝石位
        /// </summary>
        public const string gem = "ge";

    }

    public class PetInfoPropKey
    {
        public const string petId = "petId";
        public const string humanId = "humanId";
        public const string name = "name";
        public const string tempId = "tempId";
        public const string level = "level";
        public const string typeId = "typeId";
        public const string propAMap = "propAMap";
        public const string propBMap = "propBMap";
        public const string score = "score";
        public const string fightPower = "fightPower";
        public const string levelUpTimestamp = "levelUpTimestamp";
        public const string perceptLevel = "perceptLevel";
        public const string growthColor = "growthColor";
        public const string gene = "gene";
        public const string apropAdd = "apropAdd";
        public const string skillMap = "skillMap";
    }

}

