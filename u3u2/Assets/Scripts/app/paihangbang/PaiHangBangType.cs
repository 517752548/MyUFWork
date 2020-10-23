
public class PaiHangBangType
{
    //1个人等级排行
    public const int ROLE_LEVEL=1;
    //2个人战力排行
    public const int ROLE_ZHANLI=2;
    //3个人宠物评分
    public const int PET_PINGFEN=3;
    //4侠客职业战力排行
    public const int XIAKE_ZHANLI=4;
    //5刺客职业战力排行
    public const int CIKE_ZHANLI = 5;
    //6术士职业战力排行
    public const int SHUSHI_ZHANLI = 6;
    //7修真职业战力排行
    public const int XIUZHEN_ZHANLI = 7;
    //8竞技场
    public const int JINGJICHANG = 8;
    //9nvn联赛
    public const int NVSNLIANSAI = 9;
    //帮派Boss进度
    public const int BANGPAI_BOSS_JINDU = 10;
    //帮派Boss次数
    public const int BANGPAI_BOSS_CISHU = 11;

    //祈福仙葫(今日)
    public const int QIFU_XIANHU_JINRI = 12;
    //祈福仙葫(昨日)
    public const int QIFU_XIANHU_ZUORI = 13;
    //灵犀仙葫(今日)
    public const int LINGXI_XIANHU_JINRI = 14;
    //灵犀仙葫(今日)
    public const int LINGXI_XIANHU_ZUORI = 15;
    //灵犀仙葫(本周)
    public const int LINGXI_XIANHU_THISWEEK = 16;
    //灵犀仙葫(上周)
    public const int LINGXI_XIANHU_LASTWEEK = 17;

}

/**
 * 仙葫排行榜类型
 */
public enum XianhuRankType
{
    NONE,
    /** 祈福仙葫，今日 1*/
    QIFU_XIANHU_JINRI,
    /** 祈福仙葫，昨日 2*/
    QIFU_XIANHU_ZUORI,
    /** 灵犀祈福，今日 3*/
    LINGXI_XIANHU_JINRI,
    /** 灵犀祈福，昨日 4*/
    LINGXI_XIANHU_ZUORI,
    /** 灵犀祈福，本周 5*/
    LINGXI_XIANHU_THISWEEK,
    /** 灵犀祈福，上周 6*/
    LINGXI_XIANHU_LASTWEEK
}