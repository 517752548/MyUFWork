
namespace app.role
{
    public class RoleBaseIntProperties
    {
        /** 基础整型属性索引开始值 */
	    public static int _BEGIN = 500;

	    /** 基础整型属性索引结束值 */
	    public static int _END = _BEGIN;

        /// <summary>
        /// @Comment(content = "等级")
        /// @Type(Integer.class)
        /// </summary>
        public static readonly int LEVEL = ++_END;// 501

        /// <summary>
        /// @Comment(content = "PET是否是主将1为主将0非主将")
        /// @Type(Integer.class)
        /// </summary>
        public static readonly int PET_TYPE = ++_END;// 502

        /// <summary>
        /// @Comment(content = "PET模板ID")
        /// @Type(Integer.class)
        /// </summary>
        public static readonly int TEMPLET_ID = ++_END;// 503

        /// <summary>
        /// @Comment(content = "HUMAN的VIP等级")
        /// @Type(Integer.class)
        /// </summary>
        public static readonly int VIP_LEVEL = ++_END;//504

        /// <summary>
        /// @Comment(content = "HUMAN头像")
        /// @Type(Integer.class)
        /// </summary>
        public static readonly int PHOTO = ++_END;//505

        /// <summary>
        /// @Comment(content = "HUMAN场景Id")
        /// @Type(Integer.class)
        /// </summary>
        public static readonly int SCENE_ID = ++_END;//506

        /// <summary>
        /// @Comment(content = "HUMAN国家ID")
        /// @Type(Integer.class)
        /// </summary>
        public static readonly int COUNTRY_ID = ++_END;//507

        /// <summary>
        /// @Comment(content = "开启的背包个数")
        /// @Type(Integer.class)
        /// </summary>
        public static readonly int HAD_OPEN_PRIM_BAG_NUM = ++_END;//508

        /// <summary>
        /// @Comment(content = "主背包总数")
        /// @Type(Integer.class)
        /// </summary>
        public static readonly int PRIM_BAG_NUM = ++_END;//509

        /// <summary>
        /// @Comment(content = "临时背包总数")
        /// @Type(Integer.class)
        /// </summary>
        public static readonly int TEMP_BAG_NUM = ++_END;//510

        /// <summary>
        /// @Comment(content = "vip经验")
        /// @Type(Integer.class)
        /// </summary>
        public static readonly int VIP_EXP = ++_END;//511

        /// <summary>
        /// @Comment(content = "最近一次场景Id")
        /// @Type(Integer.class)
        /// </summary>
        public static readonly int LAST_CITY_SCENE_ID = ++_END;//512

        /// <summary>
        /// @Comment(content = "战斗力")
        /// @Type(Integer.class)
        /// </summary>
        public static readonly int FIGHT_POWER = ++_END;//513

        /// <summary>
        /// @Comment(content = "性别")
        /// @Type(Integer.class)
        /// </summary>
        public static readonly int SEX = ++_END;//514

        /// <summary>
        /// @Comment(content = "职业")
        /// @Type(Integer.class)
        /// </summary>
        public static readonly int JOB_TYPE = ++_END;//515

        /// <summary>
        /// @Comment(content = "VIP状态")
        /// @Type(Integer.class)
        /// </summary>
        public static readonly int VIP_STATE = ++_END;//516

        /// <summary>
        /// @Comment(content="当前可拥有武将数量")
        /// @Type(Integer.class)
        /// </summary>
        public static readonly int FORMATION_OWN_PET_NUM = ++_END; //517

        /// <summary>
        /// @Comment(content="武将星级")
        /// @Type(Integer.class)
        /// </summary>
        public static readonly int STAR = ++_END; //518

        /// <summary>
        /// @Comment(content="武将品质（阶数）")
        /// @Type(Integer.class)
        /// </summary>
        public static readonly int COLOR = ++_END; //519
	    /// <summary>
	    /// @Comment(content="地图Id")
	    /// @Type(Integer.class)
	    /// </summary>
	    /// <param name="?"></param>

	    public static readonly int MAP_ID = ++_END; //520
	    /// <summary>
	    /// @Comment(content="坐标X，像素位置")
	    /// @Type(Integer.class)
	    /// </summary>
	    /// <param name="?"></param>
	
	    public static readonly int X = ++_END; //521
	    /// <summary>
	    /// @Comment(content="坐标Y，像素位置")
	    /// @Type(Integer.class)
	    /// </summary>
	    /// <param name="?"></param>
	
	    public static readonly int Y = ++_END; //522
	    /// <summary>
	    /// @Comment(content="自动战斗默认行为")
	    /// @Type(Integer.class)
	    /// </summary>
	    /// <param name="?"></param>
	
	    public static readonly int AUTO_FIGHT_ACTION = ++_END; //523
	    /// <summary>
	    /// @Comment(content="自动战斗宠物默认行为")
	    /// @Type(Integer.class)
	    /// </summary>
	    /// <param name="?"></param>
	
	    public static readonly int PET_AUTO_FIGHT_ACTION = ++_END; //524
	    /// <summary>
	    /// @Comment(content="一级属性可分配点数")
	    /// @Type(Integer.class)
	    /// </summary>
	    /// <param name="?"></param>
	
	    public static readonly int LEFT_POINT = ++_END; //525
	    /// <summary>
	    /// @Comment(content="成长率品质，宠物")
	    /// @Type(Integer.class)
	    /// </summary>
	    /// <param name="?"></param>
	
	    public static readonly int GROWTH_COLOR = ++_END; //526
	    /// <summary>
	    /// @Comment(content="是否出战中，宠物")
	    /// @Type(Integer.class)
	    /// </summary>
	    /// <param name="?"></param>
	
	    public static readonly int IS_FIGHT = ++_END; //527
	    /// <summary>
	    /// @Comment(content="变异类型，宠物")
	    /// @Type(Integer.class)
	    /// </summary>
	    /// <param name="?"></param>
	
	    public static readonly int GENE_TYPE = ++_END; //528
	    /// <summary>
	    /// @Comment(content="寿命，宠物")
	    /// @Type(Integer.class)
	    /// </summary>
	    /// <param name="?"></param>
	
	    public static readonly int LIFE = ++_END; //529

        /// <summary>
        /// @Comment(content = "悟性等级")
        /// </summary>
        /// <param name="?"></param>
        public static readonly int PERCEPT_LEVEL = ++_END;// 530
	
	    /// <summary>
	    /// @Comment(content = "酒馆等级")
	    /// </summary>
	    /// <param name="?"></param>
        public static readonly int PUB_LEVEL = ++_END;// 531

        /// <summary>
        /// @Comment(content = "心法等级")
        /// </summary>
        /// <param name="?"></param>
	    public static readonly int MAINSKILL_LEVEL = ++_END;// 532
	
        /// <summary>
        /// @Comment(content = "当前心法类型")
        /// </summary>
        /// <param name="?"></param>
        public static readonly int MAINSKILL_TYPE = ++_END;// 533

        /// <summary>
        /// @Comment(content = "是否有帮派")
        /// </summary>
        /// <param name="?"></param>
        public static readonly int HAS_CORPS = ++_END;// 534

        /// <summary>
        /// @Comment(content = "帮派经验buff")
        /// </summary>
        /// <param name="?"></param>
        public static readonly int CORPS_EXP_BUFF = ++_END;// 535

        /// <summary>
        /// @Comment(content = "帮派金币buff")
        /// </summary>
        /// <param name="?"></param>
        public static readonly int CORPS_GOLD_BUFF = ++_END;// 536

        /// <summary>
        /// @Comment(content = "当前帮贡")
        /// </summary>
        /// <param name="?"></param>
        public static readonly int CURRENT_CORPS_CONTRIBUTION = ++_END;// 537

        /// <summary>
        /// @Comment(content = "历史总帮贡")
        /// </summary>
        /// <param name="?"></param>
        public static readonly int TOTAL_CORPS_CONTRIBUTION = ++_END;// 538

        /// <summary>
        /// @Comment(content = "宠物评分")
        /// </summary>
        /// <param name="?"></param>
        public static readonly int PET_SCORE = ++_END;// 539

        /// <summary>
        /// @Comment(content = "采矿等级")
        /// </summary>
        /// <param name="?"></param>
        public static readonly int CAIKUANG_LEVEL = ++_END;// 540

        /// <summary>
        /// @Comment(content = "称号")
        /// @Type(Integer.class)
        /// </summary>
        public static readonly int DIS_TITLE = ++_END;// 541
        /// <summary>
        /// 称号模板id
        /// </summary>
        public static readonly int Chenghao_TITLE = ++_END; //542
        /// <summary>
        /// 骑宠悟性等级
        /// </summary>
        public static readonly int PET_HORSE_PERCEPT_LEVEL = ++_END;// 543

        /// <summary>
        /// 成长率品质，骑宠
        /// </summary>
        public static readonly int PET_HORSE_GROWTH_COLOR = ++_END; //544
	    /// <summary>
        /// 仓库开启格子次数（页数）
        /// </summary>
	    public static readonly int STORE_OPEN_NUM = ++_END;//545
	    /// <summary>
        /// 帮派等级
        /// </summary>
	    public static readonly int CORPS_LEVEL = ++_END; //546
	    /// <summary>
        /// 帮派朱雀堂等级
        /// </summary>
	    public static readonly int CORPS_BUILDING_ZQ_LEVEL = ++_END; //547
	    /// <summary>
        /// 帮派侍剑堂等级
        /// </summary>
	    public static readonly int CORPS_BUILDING_SJ_LEVEL = ++_END; //548
	    /// <summary>
        /// 宠物技能栏数量
        /// </summary>
	    public static readonly int PET_SKILL_BAR_NUM = ++_END;//549
	    /// <summary>
        /// 绑定状态，0绑定，1非绑定
        /// </summary>
	    public static readonly int PET_BIND = ++_END;//550
        /// <summary>
        /// 骑宠变异
        /// </summary>
        public static readonly int PET_HORSE_GENE_TYPE = ++_END;//551
        
        /** 基础整型属性的个数 */
        public static readonly int _SIZE = _END - _BEGIN + 1;

	    public static readonly int TYPE = PropertyType.BASE_ROLE_PROPS_INT;

        /// <summary>
        /// 判断key是否属于当前属性段
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsKeyIntProperty(int key)
        {
            if (key > _BEGIN && key <= _END)
            {
                return true;
            }
            return false;
        }
    }
}
