
namespace app.role
{
    public class RoleBaseStrProperties
    {
        /** 基础对象型属性索引开始值 */
	    private static int _BEGIN = 600;

	    /** 基础对象型属性索引结束值 */
	    public static int _END = _BEGIN;

        /// <summary>
        /// @Comment(content = "当前经验值")
        /// @Type(Long.class)
        /// </summary>
        public static readonly int EXP = ++_END;//601

        /// <summary>
        /// @Comment(content = "下一等级所需经验值")
        /// @Type(Long.class)
        /// </summary>
        public static readonly int LEVEL_UP_NEED_EXP = ++_END;//602

        /// <summary>银票
        /// @Comment(content = "因为int最大值为10Y,货币有可能超过10Y所以使用Long型")
        /// @Type(Long.class)
        /// </summary>
        public static readonly int GOLD = ++_END;//603

        /// <summary>
        /// @Comment(content = "名称")
        /// @Type(Long.class)
        /// </summary>
        public static readonly int NAME = ++_END;//604

        /// <summary>金子
        /// @Comment(content = "HUMAN元宝玩家充值RMB兑换的货币")
        /// @Type(Long.class)
        /// </summary>
        public static readonly int BOUD = ++_END;//605

        /// <summary>
        /// @Comment(content = "HUMAN绑定元宝系统赠送的可以替代元宝的货币")
        /// @Type(Long.class)
        /// </summary>
        public static readonly int SYS_BOND = ++_END;//606

        /// <summary>
        /// @Comment(content = "HUMAN元宝+绑定元宝数")
        /// @Type(Long.class)
        /// </summary>
        public static readonly int ALL_BOND = ++_END;//607

        /// <summary>
        /// @Comment(content = "军令")
        /// @Type(Long.class)
        /// </summary>
        public static readonly int POWER = ++_END; //608

        /// <summary>
        /// @Comment(content = "礼券")金票
        /// @Type(Long.class)
        /// </summary>
        public static readonly int GIFT_BOND = ++_END; //609

        /// <summary>
        /// @Comment(content = "声望")
        /// @Type(Long.class)
        /// </summary>
        public static readonly int HONOR = ++_END; //610
        
        /// <summary>
        /// @Comment(content = "技能点")
	    /// @Type(Long.class)
        /// </summary>
        public static readonly int SKILL_POINT = ++_END; //611

        /// <summary>
        ///@Comment(content = "最近一次移动时间")
        /// @Type(Long.class)
        /// </summary>
        public static readonly int LAST_MOVE_TIME = ++_END; //612

        /// <summary>
        /// @Comment(content = "悟性经验值")
        /// @Type(Long.class)
        /// </summary>
        public static readonly int PERCEPT_EXP = ++_END;//613
	
        /// <summary>
        /// @Comment(content = "酒馆经验值")
	    /// @Type(Long.class)
        /// </summary>
        /// <param name="?"></param>
        public static readonly int PUB_EXP = ++_END;//614

        /// <summary>
        /// @Comment(content = "我的帮派id")
        /// @Type(Long.class)
        /// </summary>
        /// <param name="?"></param>
        public static readonly int MY_CORP_ID = ++_END;//615
        /// <summary>
        /// 银子。
        /// </summary>
        public static readonly int GOLD_2 = ++_END;//616
        /// <summary>
        /// "升级时间戳",客户端不用
        /// </summary>
	    public static readonly int LEVEL_UP_TIME = ++_END; //617
        /// <summary>
        /// 活力值
        /// </summary>
        public static readonly int HUOLI = ++_END;//618
        /// <summary>
        /// 称号名称
        /// </summary>
        public static readonly int Chenghao_Name = ++_END;// 619; //619

        /// <summary>
        /// 骑宠 悟性经验
        /// </summary>
        public static readonly int PET_HORSE_PERCEPT_EXP = ++_END;//620

        /// <summary>
        /// 帮派礼金
        /// </summary>
        public static readonly int BANGPAI_LIJIN = ++_END;//621

        /// <summary>
        ///  @Comment(content = "免费挂机点")
        ///@Type(Long.class)
        /// </summary>
        public static readonly int GUA_JI_POINT = ++_END;//622

        /// <summary>
        /// @Comment(content = "充值挂机点")
        ///@Type(Long.class)
        /// </summary>
        public static readonly int GUA_JI_POINT2 = ++_END;//623

        /** 基础整型属性的个数 */
        public static readonly int _SIZE = _END - _BEGIN + 1;

	    public static readonly int TYPE = PropertyType.BASE_ROLE_PROPS_STR;
        /// <summary>
        /// 判断key是否属于当前属性段
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsKeyStrProperty(int key)
        {
            if (key > _BEGIN && key <= _END)
            {
                return true;
            }
            return false;
        }
    }
}
