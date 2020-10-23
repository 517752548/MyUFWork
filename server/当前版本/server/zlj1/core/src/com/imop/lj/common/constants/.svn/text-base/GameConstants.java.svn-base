package com.imop.lj.common.constants;

import com.imop.lj.core.config.Config;

/**
 * 游戏全局参数定义，在resource/script/constants.js中填写。 注：所有常量使用本类定义
 */
public class GameConstants implements Config {
    /**
     * 确认对话框 OK 按钮返回值
     */
    public static final String OPTION_OK = "ok";
    /**
     * 确认对话框 Cancel 按钮返回值
     */
    public static final String OPTION_CANCEL = "cancel";

    /**
     * 最大队员数量
     */
    public static final int MAX_HUMAN_NUM = 5;

    @Override
    public boolean getIsDebug() {
        return false;
    }

    @Override
    public String getVersion() {
        return null;
    }

    @Override
    public void validate() {
        // if (offlineDelayTime <= 0) {
        // throw new
        // ConfigException("constants.js中，offlineDelayTime下线延迟时间不能小于等于0");
        // }
        // if (givebackMoneyRate <= 0 || givebackMoneyRate >= 100) {
        // throw new
        // ConfigException("constants.js中，givebackMoneyRate小于0或者大于100");
        // }
    }


    /**
     * 初始地图id
     */
    private int initMapId = 1;

    /**
     * 地图文件后缀名
     */
    private String mapFileType = ".map";

    /**
     * 判断是否在范围内的偏移量(半径)
     */
    private int pointInAreaOffset = 5;


    // 公告速度
    private short defaultNoticeSpeed = 50;

    private String openGameDate = "2012-1-1";

    //人物模型的宽度
    private int modelWidth = 200;
    //人物模型的高度
    private int modelHeight = 100;

    /**
     * 默认屏幕宽高
     */
    private int screenWidth = 960;
    private int screenHeight = 640;

    /**
     * 玩家或武将的等级上限
     */
    private int levelMax = 100;

    /**
     * 宠物的等级上限(悟性)
     */
    private int petLevelMax = 120;
    /**
     * 宠物的悟性经验批量次数(悟性)
     */
    private int petPerceptTimesByBatch = 50;
    /**
     * 宠物的悟性等级上限(悟性)
     */
    private int petPerceptLevelMax = 20;
    /**
     * 宠物的悟性小暴击倍率(悟性)
     */
    private int petPerceptSmallCrit = 10;
    /**
     * 宠物出战的寿命最小值
     */
    private int petFightLifeMin = 10;

    /**
     * 主将技能最大格子数
     */
    private int petLeaderSkillMaxPos = 3;
    
    /**
     * 池子初始值
     */
    private int initHpPool = 100000;
    private int initMpPool = 100000;
    private int initLifePool = 100000;

    /**
     * 池子最大值
     */
    private int maxHpPool = 100000;
    private int maxMpPool = 100000;
    private int maxLifePool = 100000;

    /**
     * 战斗相关参数
     */
    /**
     * 防御状态受到伤害值
     */
    private int battleDefenceHurt = 1;
    /**
     * 暴击伤害倍数
     */
    private double battleCritHurtCoef = 2.0D;
    /**
     * 暴击系数0
     */
    private double battleCritCoef0 = 0.02D;

    /**
     * 战斗等级差系数
     */
    private double battleLevelCoef = 0.02d;

    /**
     * 逃跑基础成功概率
     */
    public double battleEscapeProbBase = 0.5d;
    /**
     * 逃跑每次累加概率
     */
    public double battleEscapeProbAdd = 0.1d;

    /**
     * 战斗实力系数1
     */
    public double battleZDSL1 = 5.0d;
    /**
     * 战斗实力系数2
     */
    public double battleZDSL2 = 2.0d;
    /**
     * 防御状态受到伤害值百分比,扩大1000倍
     */
    public int battleDefenceHurtScale = 50;
     /**
     * 消耗自身hp,mp的最小值
     */
    public int battleCostOwnerMin = 10;
    /**
     * buff 叠加层数初始值
     */
    public int buffOverlapInitValue = 1;
    

    /**
     * 一级属性系数
     */
    public double battleAProp1 = 3.0d;

    //物理防御系数	18
    public double battlePhyDef = 18.0d;
    //物理命中系数	21.4286
    public double battlePhyHit = 21.4286d;
    //物理闪避系数	21.4286
    public double battlePhyDod = 21.4286d;
    //物理暴击系数	15
    public double battlePhyCri = 15.0d;
    //物理抗暴系数	22.5
    public double battlePhyAntCri = 22.5d;
    //法术防御系数	18
    public double battleMagDef = 18.0d;
    //法术命中系数	21.4286
    public double battleMagHit = 21.4286d;
    //法术闪避系数	21.4286
    public double battleMagDod = 21.4286d;
    //法术暴击系数	15
    public double battleMagCri = 15.0d;
    //法术抗暴系数	22.5
    public double battleMagAntCri = 22.5d;

    //免伤	0.5
    public double battleMS = 0.5d;
    //闪避	0.7
    public double battleDodgy = 0.7d;
    //抗暴	0.8
    public double battleAntiCrit = 0.8d;
    //击飞血量百分比参数
    public double battleDeadFly = 0.1d;

    /**
     * 战斗后，hp、mp、life最小值
     */
    public int battleLeftMin = 1;
    /**
     * 怒气上限
     */
    public int battleSpMax = 100;
    /**
     * 每次受到伤害增加怒气
     */
    public int battleAddSp = 10;

    //pvp等待对方响应时间
    private int battlePvpWaitTime = 90000;
    
    /** 玩家在地图遇怪的最小等级要求 */
    private int mapMeetMonsterLevelLimit = 10;

    /**
     * 世界聊天的最小间隔，单位：秒
     */
    private int worldChat = 5;
    /**
     * 地图聊天的最小间隔，单位秒
     */
    private int mapChat = 5;
    /**
     * 军团聊天的最小间隔，单位秒
     */
    private int guildChat = 5;
    /**
     * 队伍聊天的最小间隔，单位秒
     */
    private int teamChat = 5;
    /**
     * 组队聊天的最小间隔，单位秒
     */
    private int commonTeamChat = 60;

    /**
     * 私聊的最小间隔，单位：秒
     */
    private int generalChat = 5;

    /**
     * 世界聊天消耗活力值
     */
    private int worldChatCostEnergy = 50;
    /** 玩家活力值最大值*/
    private int energyMax = 1000;

    /**
     * 主将初始的品质
     */
    private int leaderDefaultQualityId = 2;

    /**
     * 给玩家发GCPing的间隔时间
     */
    private long gcPingInterval = 30 * 1000;

    /**
     * sessionIdleTime，600秒
     */
    private int sessionIdleTime = 600;

    /**
     * 主将每升一级增加的可分配点数
     */
    private int leaderLevelUpAddPoint = 3;
    /**
     * 宠物每升一级增加的可分配点数
     */
    private int petLevelUpAddPoint = 3;

    /**
     * 体力（军令）相关
     */
    private int sysGivePowerNum = 1;
    private int sysHumanPowerMax = 200;// 系统恢复体力最大值
    private int sysPowerBuyMax = 800;// 系统体力最大上限
    private int sysBuyPowerNum = 10;// 一次购买体力的数量

    
    /**
     * 双倍经验点相关
     */
    private int sysGiveDoublePointNum = 200;
    private int useGiveDoublePointNum = 50;
    private int sysGiveDoublePointMax = 2000;
    private int expMultiplyNum = 2; // 挂机经验几倍的配置,2-代表是2倍
    
    /** 帮派boss相关*/
    
    private int corpsBossMaxRewardNum = 1;//帮派成员本周获得击杀帮派boss奖励次数
    private int showBossRankSize = 10; //帮派boss排行榜显示条数
    private int bossRankRewardSize = 10; //帮派boss发奖人数
    private int showBossCountRankSize = 10; //帮派boss挑战次数排行榜显示条数
    private int bossCountRankRewardSize = 10; // 帮派boss挑战次数发奖人数
    private int corpsBossMinCorpsLevel = 1; //帮派boss帮派最低等级
    private int corpsBossMemberMinLevel = 40; //帮派boss队员最低等级要求
    private int corpsBossMinMemberNum = 1; //帮派boss队员最少数量
    private int chapterByCorpsBoss = 5; //帮派boss每一章的层数
    private int corpsBossMinJoinTime = 1 * 1000; //加入帮派时间
    private int corpsBossRefreshDayOfWeek = 6; //帮派boss刷新排行榜星期,7代表星期日
    private int corpsBossRefreshDayOfHour = 23; //帮派boss刷新排行榜锁定开始小时数,23代表从23点开始后的一个小时内不允许打
    private int corpsBossRankRewardTimeId = 1048; //帮派boss刷新排行榜时间Id
    private int corpsBossShowRankOnTimeSwtich = 1; //1-立即显示,0-否
    
    /** 封妖相关 */
    private int demonRefreshMaxNum = 10;//一张地图内,小妖最大刷新数量
    private int demonKingRefreshMaxNum = 5;//一张地图内,魔王最大刷新数量
    private int demonExistenceTime = 30 * 60 * 1000;//小妖存在时间,30分钟,毫秒
    private int demonKingExistenceTime = 30 * 60 * 1000;//魔王存在时间,30分钟,毫秒
    private int demonMinMemberNum = 1;//小妖挑战人数,单人或组队均可
    private int demonKingMinMemberNum = 1;//魔王挑战人数,至少3人组队
    private double demonKingProb = 1.0d; //藏宝图开除魔王的概率
    public int demonNoticeId = 23;//广播
    
    /** 混世魔王相关*/
    public int devilNoticeId = 24;//广播
    private int devilRefreshMaxNum = 5;//一张地图内,魔王最大刷新数量
    private int devilExistenceTime = 30 * 60 * 1000;//混世魔王存在时间,30分钟,毫秒
    private int devilMinMemberNum = 1;//混世魔王挑战人数,至少3人组队
    
    /** 限时活动相关*/
    private int timeLimitMinLevel = 20; //限时活动玩家最低等级
    private double timeLimitPushPlayerProb = 0.5; //限时活动推送在线玩家比例
    private int timeLimitPushPlayerMaxNum = 1000; //限时活动推送在线玩家最大人数
    private int timeLimitPushTaskNum = 1; //限时活动推送任务数量
    private long timeLimitExistenceTime = 5 * 60 * 1000; // 限时活动限时,5分钟,毫秒
    private int questionNumOfTimeLimitExamination = 10; //限时答题题目数
    private int cwLiBaoItemId = 20033; //限时答题,答对10题获得奖励物品Id
    public int timeLimitExamNoticeId = 25;//限时答题广播
    public int timeLimitMonsterNoticeId = 26;//限时杀怪广播
    public int timeLimitNpcNoticeId = 27;//限时挑战Npc广播
    public int timeLimitOpenNoticeId = 28;//限时挑战Npc广播
    
    
    /** 帮派修炼相关*/
    private int cultivateCostCurrencyTypeId = 2; //银票
    private int cultivateCostCurrencyNum = 20000; //修炼1次消耗银票
    private int cultivateAddExpNum = 10; //修炼1次获得经验
    private int cultivateUpgradeMinLevel = 6;//修炼等级达到6,需要加入帮派才能开启后续的修炼等级
    private int cultivateUpgradeMinJoinTime = 24 * 60 * 60 * 1000; //入当前帮派24小时以上,才可以修炼,毫秒
    private int cultivateBatchNum = 10; //修炼批量的次数
    
    
    
    
    /** 帮派辅助技能相关*/
    private int assistCostCurrencyTypeId = 2; //银票
    private int assistUpgradeMinLevel = 0; //辅助等级最小等级
    private int assistUpgradeMaxLevel = 100; // 辅助等级最大等级
    private int assitCritCoef1 = 60;
    private int assitCritCoef2 = 600;
    private int assistMakeItemMinLevel = 10;// 制作技能等级最小等级
    
    /** 红包相关*/
    private int corpsRedEnvelopeMaxNum = 100; //帮派内红包最大数量
    private int redEnvelopeMaxNum = 10; //帮派发红包可打开的最大数量
    private double openRedEnvelopeMinProb = 0.3; //拆帮派红包站红包总额的最小百分比
    private double openRedEnvelopeMaxProb = 0.5; // 拆帮派红包站红包总额的最大百分比
    private double chargeCountToRedEnvelopeRate = 0.2; //玩家每次充值后，系统额外发放充值金额 * 该比例
    private long redEnvelopeMin = 1000; //红包最小值
    private long redEnvelopeMax = 9999999; //红包最大值
    private int gotBonusRepeatlyFlag = 1; //自己可以领取红包多次的开关,1-打开,0-关闭
    private int redEnvelopeMaxExistTime = 1 * 1000; //一周
    
    //分配物品
    private int allocateCorpsWarActivityNum = 1;// 分配帮派竞赛活动仓库中的数量
    private int allocateCorpsWarJinItemId = 20166;
    private int allocateCorpsWarYinItemId = 20167;
    private int allocateCorpsWarTongItemId = 20168;
    private int allocateCorpsWarJinRewardId = 2106;// 分配帮派竞赛活动金宝箱奖励Id
    private int allocateCorpsWarYinRewardId = 2107;// 分配帮派竞赛活动银宝箱奖励Id
    private int allocateCorpsWarTongRewardId = 2108;// 分配帮派竞赛活动铜宝箱奖励Id
    
    /** 剧情副本相关*/
    private int chapterByPlotDungeon = 5; //剧情副本每一章的层数
    
    /** 围剿魔族副本相关*/
    private int siegeDemonNormalMinMemNum = 1;
    private int siegeDemonHardMinMemNum = 1;
    private int siegeDemonNormalMinLevel = 35;
    private int siegeDemonHardMinLevel = 35;
    private int siegeDemonNormalAssistRewardId = 1001;//普通助战奖励
    private int siegeDemonHardAssistRewardId = 1001;//困难助战奖励
    private int siegeDemonNormalFinalRewardId = 1001;//普通通关奖励
    private int siegeDemonHardFinalRewardId = 1001;//困难通关奖励
    
    
    
    /**
     * 增加登录天数的timeEventId
     */
    private int addLoginDaysTimeEventId = 1001;

    /**
     * 关卡消耗军令数量
     */
    private int costTokenNum = 1;
    /**
     * 关卡扫荡一轮时间 3分钟
     */
    private long cleanMissionRoundTime = 10 * 1000;
    /**
     * 关卡挂机一轮需要元宝数
     */
    private int cleanMissionRoundBond = 3;

    /**
     * 副本扫荡一个敌人的时间 1分钟
     */
    private long cleanRaidRoundTime = 10 * 1000;
    /**
     * 副本扫荡一个敌人需要元宝数
     */
    private int cleanRaidRoundBond = 1;
    /**
     * 购买副本次数的参数
     */
    private int buyRaidTimesCoef = 50;
    /**
     * 推荐国家奖励
     */
    private int recommendRewardId = 1001;
    /**
     * 副本掉落奖励广播
     */
    private int raidBroadcastOpenBoxId = 27;
    /**
     * 副本掉落奖励广播开箱子道具的品质
     */
    private int openBoxItemRarityId = 3;
    /**
     * 副本掉落奖励广播
     */
    private int raidBroadcastBattleId = 28;
    /**
     * 副本掉落奖励广播----玩家在手动战斗过程中
     */
    private int humanBattleItemRarityId = 3;

    /**
     * 武将属性相关
     */
    /**
     * 拥有宠物最大个数
     */
    public int petMaxOwnPetNum = 50;
    /**
     * 拥有伙伴最大个数
     */
    public int petMaxOwnFriendNum = 20;
    /**
     * 拥有骑宠最大个数
     */
    public int petMaxOwnHorseNum = 8;
    /**
     * 骑宠出战最低忠诚度
     */
    public int PetHorseFightLoyMin = 10;
    /**
     * 骑宠初始忠诚度
     */
    public int PetHorseInitLoy = 100;
    /**
     * 骑宠初始亲密度
     */
    public int PetHorseInitClo = 100;
    
    /**
     * 骑宠加成系数
     */
    public double petHorseAddCoef = 0.5d;

    /**
     * 宠物变异加成1
     */
    public int petGeneAdd1 = 100;

    /**
     * 宠物变异概率
     */
    public double petGeneProb = 0.01f;

    /**
     * 捕捉宠物成功概率
     */
    public double petCatchProb = 0.5f;

    /**
     * 宠物初始寿命
     */
    public int petInitLife = 1000;
    /**
     * 宠物战斗消耗生命
     */
    public int petBattleCostLife = 1;
    /**
     * 宠物战斗消耗生命，死亡时
     */
    public int petBattleCostLifeOnDead = 10;

    /**
     * 宠物技能等级上限
     */
    public int petSkillLevelMax = 10;
    /**
     * 宠物天赋技能数量上限
     */
    public int petTalentSkillNumMax = 15;
    /**
     * 宠物普通技能数量上限
     */
    public int petNormalSkillNumMax = 15;
    /**
     * 宠物被捕捉时，天赋技能数量上限
     */
    public int petTalentSkillNumMaxOnCaught = 15;
    /**
     * 宠物洗天赋技能需要的道具Id
     */
    public int petTalentSkillResetItemId = 20001;
    /**
     * 宠物洗天赋技能需要的道具数量
     */
    public int petTalentSkillResetItemNum = 5;

    /**
     * 宠物炼化类型 1 炼化
     */
    private int petArtificeArtificeType = 1;
    /**
     * 宠物炼化类型 2 提升
     */
    private int petImproveArtificeType = 2;

    /**
     * 批量变异的次数
     */
    private int petVariationBatchNum = 10;

    /**
     * 伙伴解锁方式1时间毫秒，7天
     */
    private long petFriendUnlock1Time = 604800000L;
    /**
     * 伙伴解锁方式2时间毫秒，30天
     */
    private long petFriendUnlock2Time = 2592000000L;

    /**
     * 重置属性点消耗道具Id
     */
    private int petResetPointItemId = 10001;
    /**
     * 重置属性点消耗道具数量
     */
    private int petResetPointItemNum = 1;

    /**
     * 力量转力量攻击比例
     */
    public double strengthToAttackRate = 1.0;
    /**
     * 力量转力量防御比例
     */
    public double strengthToDefenseRate = 0.7;

    /**
     * 敏捷转速度比例
     */
    public double agilityToSpeedRate = 1.0;

    /**
     * 智力转智力攻击比例
     */
    public double intellectToAttackRate = 1.0;
    /**
     * 智力转智力防御比例
     */
    public double intellectToDefenseRate = 0.7;

    /**
     * 生命转血量比例
     */
    public double liftToHpRate = 1.0;

    /**
     * 闪避上限
     */
    public int dodgy = 90;
    /**
     * 暴击上限
     */
    public int fatal = 90;
    /**
     * 格挡上限
     */
    public int bolck = 90;
    /**
     * 抗暴上限
     */
    public int unfatal = 90;
    /**
     * 破击上限
     */
    public int unblock = 90;
    /**
     * 伤害率上限
     */
    public int hurt = 500;
    /**
     * 免伤率上限
     */
    public int avoidHurt = 100;

    /**
     * 宠物爆资质成长值下限
     */
    public int petGrowthColor = 5;
    /**
     * 宠物爆资质上限系数
     */
    public double petOverColor = 0.1d;
    /**
     * 普通宠物资质条数最大数量
     */
    public int petColorNormalMaxCount = 1;
    /**
     * 神兽资质条数最大数量
     */
    public int petColorBestMaxCount = 2;
    /**
     * 普通宠物爆资质出现概率1条
     */
    public double petColorNormalRate1 = 0.9d;
    /**
     * 神兽爆资质出现概率1条
     */
    public double petColorBestRate1 = 0.9d;
    /**
     * 神兽爆资质出现概率2条
     */
    public double petColorBestRate2 = 0.9d;


    // 奖励相关
    /**
     * 经验倍数上限
     */
    private double expAmendUpper = 5;
    /**
     * 金币倍数上限
     */
    private double goldAmendUpper = 5;

    // 战斗相关
    /**
     * 前军伤害率
     */
    private double frontHurtRate = -0.4;
    /**
     * 前军初始怒气
     */
    private int frontInitAnger = 50;
    /**
     * 中军初始怒气
     */
    private int middleInitAnger = 50;
    /**
     * 后军初始怒气
     */
    private int backInitAnger = 50;

    /**
     * 战斗内置cd相关
     */
    private int battleCd = 3 * 1000;

    /**
     * 随机最大基数,默认10w
     */
    private int randomBase = 100000;

    /** 邮件相关 */
    /**
     * 非保存的邮件,过期时间,过期后自动删除 14天
     */
    private int mailInInboxExpiredTime = 2 * 7 * 24;
    /**
     * 收件箱中的邮件最大数量
     */
    private int mailInBoxMaxCount = 100;
    /**
     * 发件箱中的邮件最大数量
     */
    private int mailSendedBoxMaxCount = 100;
    /**
     * 保存邮箱中的邮件最大数量
     */
    private int mailSaveBoxMaxCount = 10;
    /**
     * 每页的邮件数量
     */ //这里不分页了一律改成最大邮件数量
    private int mailNumPerPage = 100;
    /**
     * 每页的邮件数量-移动端
     */ //这里不分页了一律改成最大邮件数量
    private int mailNumPerPageMobile = 100;

    /** 竞技场 */
    /**
     * 竞技场战斗冷却cd
     */
    private long arenaBattleCd = 5 * 60 * 1000;
    /**
     * 竞技场终结连胜公告，连胜数
     */
    private int arenaNoticeEndConWinNum = 10;
    /**
     * 竞技场 终结连胜公告Id
     */
    private int arenaEndConWinNoticeId = 9;
    /**
     * 竞技场 打败第一名公告Id
     */
    private int arenaWinFirstNoticeId = 10;

    /** 竞技场排名偏移量 */
    private int arenaRankOffset = 5000;
    /** 竞技场排名奖励最多人数 */
    private int arenaRankRewardMax = 500;
    /** 竞技场消除冷却时间消耗货币数量 */
    private int arenaKillCdCost = 10000;
    /** 竞技场购买一次增加挑战次数 */
    private int arenaBuyAddTimes = 5;
    
    /** 竞技场机器人-宠物id */
    private int arenaRobotPetId = 210001;
    /** 竞技场机器人-伙伴id */
    private int arenaRobotFriendId1 = 2001;
    private int arenaRobotFriendId2 = 2002;
    private int arenaRobotFriendId3 = 2003;
    private int arenaRobotFriendId4 = 2004;
    
    /**
     * VIP相关
     */

    // 首次开启VIP奖励
    private int firstOpenVipReward = 1500003;
    // 充值元宝与经验的转换比例
    private int chargeDiamondToExp = 1;
    // 成长值衰减
    private int growthValueReduce = 5;
    // 开通VIP广播
    private int openVipBroadcastId = 50;
    
    //人民币到元宝的兑换比例
    private int chargeRmbToBondCoef = 10;
    
    private String chargeChannelCode = "com.gamedo.tianshuqitanshouyouban";
    
    /**
     * 装备相关
     */
    // 装备强化CD
    private long enhanceCd = 5 * 60 * 1000;
    // 定向洗练消耗
    private int directedWashCost = 5;
    // 武器技能洗练消耗
    private int weaponSkillWashCost = 100;
    // 批量洗练次数
    private int batchWashNum = 10;
    // 宝石最低级别
    private int gemMinLevel = 1;
    // 宝石最高级别
    private int gemMaxLevel = 9;
    // 打孔消耗物品ID
    private int holedItemId = 1;
    // 打孔消耗货币类型
    private int holedCurrencyTypeId = 2;
    // 宝石合成基数
    private int gemCompositeNum = 2;
    /**
     * 红宝石(1级) 后续是+1，共 {@link GameConstants#gemMaxLevel}-1次
     */
    private int redGemId = 80001;
    /**
     * 绿宝石(1级) 后续是+1，共 {@link GameConstants#gemMaxLevel}-1次
     */
    private int greenGemId = 80010;
    /**
     * 蓝宝石(1级) 后续是+1，共 {@link GameConstants#gemMaxLevel}-1次
     */
    private int blueGemId = 80019;
    /**
     * 紫宝石(1级) 后续是+1，共 {@link GameConstants#gemMaxLevel}-1次
     */
    private int purpleGemId = 80028;
    /**
     * 黄宝石(1级) 后续是+1，共 {@link GameConstants#gemMaxLevel}-1次
     */
    private int yellowGemId = 80037;
    /**
     * 宝石合成计算百分比基数
     */
    public int gemSynthesisBaseNum = 1000;

    // 附魔等级限制
    private int fomuEquipLevelLimit = 80;
    // 批量附魔次数
    private int batchFomuNum = 10;
    // 附魔等级上限
    private int fumoLevelUpper = 20;
    // 宝石自动合成级别下限
    private int gemAotuCompositeLevelLowwer = 4;
    // 宝石自动合成级别上限
    private int gemAotuCompositeLevelUpper = 12;
    // 宝石合成下限
    private int gemCanBeSynthesisLowestLevel = 2;
    // 宝石合成上限
    private int gemCanBeSynthesisHighestLevel = 9;
    // 宝石合成基数下限
    private int gemCanBeSynthesisLowestBase = 3;
    // 宝石合成基数上限
    private int gemCanBeSynthesisHighestBase = 5;


    /**
     * 关系
     */
    /**
     * 关系每页显示的数量
     */
    private int relationNumPerPage = 100;//不分页，简单修改将页大小改为好友上限
    /**
     * 推荐好友数量
     */
    private int relationRecommendFriendNum = 9;
    /**
     * 好友数量上限
     */
    public int friendMaxNum = 100;
    /**
     * 黑名单数量上限
     */
    public int blackListMaxNum = 100;
    /**
     * 小助手提示数量限制
     */
    private int popTipsRelationLimitNum = 30;

    /**
     * 小贴士
     */
    public int popTipsGetEquipId = 1;
    public int popTipsMainBagFullId = 1;
    public int popTipsGiftLevelId = 1;
    public int popTipsOpenMindId = 1;
    public int popTipsNotEnoughGoldId = 1;
    public int popTipsNotEnoughPowerId = 1;
    public int popTipsApplyCorpsPresidentId = 1;
    public int popTipsMoneytreeUpgradeId = 1;
    public int popTipsRecommendFriendId = 1;

    /**
     * 战斗力相关
     */
    /**
     * 等级
     */
    public double fightPowerCoefLevel = 50;
    /**
     * 力量/智力攻击力
     */
    public double fightPowerCoefAttack = 0.5;
    /**
     * 力量防御
     */
    public double fightPowerCoefDefenceStrengh = 0.2;
    /**
     * 智力防御
     */
    public double fightPowerCoefDefenceIntellect = 0.1;
    public double fightPowerCoefSpeed = 0.25;
    public double fightPowerCoefHP = 0.1;
    public double fightPowerCoefHit = 1.0;
    public double fightPowerCoefDodgy = 1.0;
    public double fightPowerCoefFatal = 1.0;
    public double fightPowerCoefUnfatal = 1.0;
    public double fightPowerCoefBlock = 1.0;
    public double fightPowerCoefUnblock = 1.0;
    /**
     * 援护
     */
    public double fightPowerCoefRecourse = 1.0;
    /**
     * 合击
     */
    public double fightPowerCoefJoint = 1.0;
    public double fightPowerCoefHurt = 1.0;
    public double fightPowerCoefAvoidHurt = 1.0;
    public int fightPowerCoefPercent = 10;

    /**
     * 人物技能战斗力等级
     */
    public double fightPowerCoefHumanSkillLevel = 20;
    /**
     * 宠物普通技能战斗力等级
     */
    public double fightPowerCoefPetNormalSkillLevel = 20;
    /**
     * 宠物天赋技能战斗力等级
     */
    public double fightPowerCoefPetTalentSkillLevel = 50;
    /**
     * 宠物变异类型评分
     */
    public int petScoreGeneType = 500;


    /**
     * 首充奖励Id
     */
    public int firstChargeRewardId = 1;

    /**
     * 玩家开启交易行的最小等级
     */
    public int humanLevelOnOpenTrade = 1;
    /**
     * 交易行的商品数量上限(每种,不计算堆叠)
     */
    public int maxTradeNumByType = 1000;
    /**
     * 每个玩家摊位的商品数量
     */
    public int humanBoothSize = 10;
    /**
     * 商品过期时长(day)
     */
    public int shelfLife = 3;
    /**
     * 上架装备最小等级
     */
    public int tradeEquipLowestLevel = 31;
    /**
     * 上架装备最低品级
     */
    public int tradeEquipLowestColor = 3;
    /**
     * 卖出商品时扣税 / 1000
     */
    public int costTaxForTrade = 100;
    /**
     * 一般商品售价范围 / 1000
     */
    public int normalItemSellPriceRange = 500;
    /**
     * 商品查询每页显示数量
     */
    public int tradeNumPerPage = 8;
    /**
     * 商品类计算百分比基数
     */
    public int tradeBaseNum = 1000;

    /**
     * 科举相关
     */
    //乡试题目数
    private int questionNumOfProvincialExamination = 20;
    //科举开始时间
    private long examStartTime = 1800000;
    //科举结束时间
    private long examEndTime = 84600000;

    /**
     * 物品相关
     */
    // 临时背包物品有效期
    private long tempBagItemValidPeriod = 48 * 60 * 60 * 1000;
    /**
     * 背包开格子需要的道具Id
     */
    private int openBagItemTplId = 100001;
    /**
     * 背包开格子需要的道具数量
     */
    private int openBagNeedItemNum = 10;
    /**
     * 背包开格一次开的格子数
     */
    private int openBagNum = 10;

    /**
     * 定时更新可领取礼包数量的周期 5分钟
     */
    private int updatePrizeNumPeriod = 5 * 60 * 1000;

    /**
     * 神秘商店
     */
    private int treasureNoteTemplateId = 1;
    private int treasureNoteTemplateNum = 1;
    /**
     * CD时间
     */
    private long mysteryShopCd = 2 * 60 * 60 * 1000;
    private long msBondFlushPrice = 10;
    private long msHighlevelBondFlushPrice = 100;
    private int msLogMaxNum = 15;
    private int mysteryShopBuyPurpleItemNoticeId = 26;

    /**
     * 刷新系数
     */
    private int msRefereshCoef = 2;
    private int msShowNum = 6;
    /**
     * 商城
     */
    private String mallPosterGroup = "1,2";
    private int singlePurchaseQuantityMax = 999;

    /**
     * 精彩活动新开启天数，1天
     */
    private int goodAcitivtyNewTime = 1 * 86400 * 1000;
    /**
     * 精彩活动最近天数，2天
     */
    private int goodAcitivtyRecentTime = 2 * 86400 * 1000;

    /**
     * 关卡低于世界等级时的经验加成*scale
     */
    private int missionWorldLevelExpAdd = 300;

    /**
     * 概率类数据的比例
     */
    private int scale = 1000;

    /**
     * 手机号长度，11位
     */
    private int phoneNumLength = 11;
    /**
     * qq号长度最小值，5位
     */
    private int qqNumLengthMin = 5;
    /**
     * qq号长度最大值，12位
     */
    private int qqNumLengthMax = 12;
    /**
     * 验证码长度最小值
     */
    private int checkCodeLengthMin = 1;
    /**
     * 验证码长度最大值
     */
    private int checkCodeLengthMax = 10;
    /**
     * 手机验证奖励Id
     */
    private int smsCheckCodeRewardId = 100;
    /**
     * qq续期openkey的时间，10分钟，也是检查返利的时间
     */
    private int qqIsLoginPeriodTime = 600 * 1000;

    /**
     * qq相关
     */
    /**
     * 黄钻新手奖励Id
     */
    private int qqVipNewerRewardId = 1001;
    /**
     * 豪华黄钻每日额外奖励Id
     */
    private int qqVipHighDayRewardId = 1001;
    /**
     * 年费黄钻每日额外奖励Id
     */
    private int qqVipYearDayRewardId = 1001;
    /**
     * 每日邀请好友奖励Id
     */
    private int qqInviteDayRewardId = 1001;
    /**
     * app评分奖励Id
     */
    private int qqAppScoreRewardId = 1001;
    /**
     * app评分奖励cd时间，毫秒
     */
    private int qqAppScoreCdTime = 3600 * 1000;
    /**
     * app图片链接
     */
    private String qqAppPicUrl = "http://i.gtimg.cn/open/app_icon/01/34/61/27//1101346127_100.png";

    /**
     * 防刷设置
     */
    // 发送邮件所需最低战力
    private int theMinPowerForSendMail = 0;
    // 进行各种聊天所需最低战力
    private int theMinPowerForChat = 0;
    // 修改军团公告的最小等级
    private int theMinLevelForChangeCorpsNotice = 2;
    // 每天最大私聊人数，-1不判断人数
    private int maxPrivateChatRoleNumPerDay = 50;

    /**
     * 环任务最大环数
     */
    private int loopMaxNum = 50;
    /**
     * 环奖励---5环一个奖励
     */
    private int loopRewardNum = 5;
    /**
     * 环奖励---立即完成一个环任务需要消耗的元宝值
     */
    private int finishOneConsumeBond = 10;
    /**
     * 环任务立即完成一个任务消耗道具
     */
    private int finishOneConsumeItemId = 1000;

    /** */
    /**
     * 战报播放速度要求等级
     */
    private int battleReportSpeed2XLevel = 60;
    private int battleReportSpeed3XLevel = 101;
    
    private int battleReportSpeedX = 3;

    /**
     * 酒馆最大等级
     */
    public int pubMaxLevel = 2;
    /**
     * 酒馆初始等级
     */
    public int pubInitLevel = 1;
    /**
     * 酒馆任务一次刷新的任务数
     */
    public int pubTaskRefreshNum = 3;

    /**
     * 酒馆任务手动刷新的道具Id
     */
    public int pubTaskRefreshManulItemId = 10001;
    /**
     * 酒馆任务手动刷新的银票数量
     */
    public int pubTaskRefreshManulGold = 100;
    /**
     * 酒馆任务手动刷新的金子数量
     */
    public int pubTaskRefreshManulBond = 10; 
    /**
     * 酒馆任务手动刷新的金子货币类型ID
     */
    public int pubTaskRefreshManulBondTypeId = 1;

    /**
     * 松木令物品ID
     */
    public int songmulingItemId = 10001;
    /**
     * 玉木令物品ID
     */
    public int yumulingItemId = 10002;

    /**
     * 除暴安良任务一次刷新的任务数
     */
    public int TheSweeneyTaskRefreshNum = 1;

    /**
     * 藏宝图任务一次刷新的任务数
     */
    public int TreasureMapRefreshNum = 1;


    /**
     * 护送粮草
     */
    /**
     * 护送粮草最低等级要求
     */
    public int forageTaskMinLevel = 30;

    /**
     * 护送粮草任务手动刷新的道具Id
     */
    public int forageTaskRefreshManulItemId = 10001;

    /**
     * 护送粮草手动刷新道具数量
     */
    public int forageTaskRefreshManulItemNum = 1;

    /**
     * 护送粮草每次可完成次数
     */
    public int forageTaskCanDoNum = 3;

    /**
     * 护送粮草战斗失败最多次数
     */
    public int forageTaskBattleFailMaxNum = 5;

    /**
     * 宠物岛
     */
    /**
     * 宠物岛刷宠物延迟时间，毫秒
     */
    public int petIslandOffsetTime = 1800000;
    /**
     * 宠物岛刷宠物间隔时间，毫秒
     */
    public int petIslandPeriodTime = 3600000;
    /**
     * 宠物岛刷宠物随机时间，前后n毫秒
     */
    public int petIslandDeltaTime = 300000;

    //宠物岛广播
    public int petIslandGoodPetShowNoticeId = 20;
    public int petIslandGoodPetCaughtNoticeId = 21;
    public int petIslandGoodPetLeaveNoticeId = 22;
    
    /***
     * 活力值相关
     */
    /**
     * 最大活力值
     */
    public int maxActivityNum = 1000;
    /**
     * 推荐日常的随机值(对应scale)
     */
    public int recommendActivityProb = 1000;
    /**
     * 推荐日常的活跃度奖励倍数
     */
    public int recommendActivityMultiple = 2;
    /**
     * 推荐日常的活力值奖励倍数
     */
    public int recommendEnergyMultiple = 2;
    /**
     * 活动ui的推荐及节日校验时间点timeEventId
     */
    private int specialActivityCheckTimeEventId = 1001;

    /**
     * 军团相关
     */
    /**
     * 玩家申请军团上限
     */
    private int maxPlayerApplytNum = 10;
    /**
     * 军团接受玩家申请上限
     */
    private int maxCorpsReceiveApplyNum = 20;
    /**
     * 每页军团数量
     */
    private int numPerPage = 9;
    /**
     * 每页军团数量--移动端
     */
    private int numPerPageMobile = 5;
    /**
     * 军团名字长度
     */
    private int corpsNameLength = 6;
    /**
     * 创建军团所需金币
     */
    private int createCorpsNeedGold = 1000000;
    /**
     * 初始化捐献  修改为0
     */
    private int initDonate = 0;
    /**
     * 军团QQ长度
     */
    private int qqLength = 12;
    /**
     * 军团公告长度
     */
    private int corpsNoticeLength = 200;
    /**
     * 元宝转成贡献
     */
    private int bondToContributionRate = 50;
    /**
     * 捐献转化成经验
     */
    private int contributionToExpRate = 10;
    /**
     * 军团事件上限
     */
    private int corpsEventMaxSize = 20;
    /**
     * 申请团长限制时间
     */
    private long applyPresidentLimitTime = 3 * 24 * 60 * 60 * 1000;
    /**
     * 申请团长贡献限制
     */
    private double applyPresidentLimitContribution = 1.1;
    /**
     * 军团仓库容量
     */
    private int corpsStorageCapacity = 500;
    /**
     * 经验转换率
     */
    private double expConverterRate = 0.05;
    /**
     * 解散帮派延迟时间
     */
    private long disbandDelayTime = 24 * 60 * 60 * 1000;
    /**
     * 系统弹劾触发警告时间  day
     */
    private int impeachCheckAlertDays = 10;
    /**
     * 系统弹劾触发时间  day
     */
    private int impeachCheckDays = 11;
    /**
     * 系统弹劾帮众选拔的最小在线时间  day
     */
    private int impeachValidDay = 3;
    /**
     * 玩家一键申请随机数量
     */
    private int randomQuickApplytNum = 5;
    /**
     * 帮贡转换帮派经验比例
     */
    private double contriConvertExpRate = 20;
    /**
     * 最大帮派维护费用通知次数
     */
    private int maxDelinquentNum = 3;
    /**
     * 帮主放大系数
     */
    private double presidentCoef = 2d;
    /**
     * 副帮主放大系数
     */
    private double viceChairmanCoef = 1.5d;
    /**
     * 精英放大系数
     */
    private double eliteCoef = 1.2d;
    /**
     * 初始化帮贡
     */
    private int initContribution = 0;
    /**
     * 军团等级上限
     */
    private int corpsLevelLimit = 5;


    /**
     * 小信封最大信息数量
     */
    private int noticeTipsMaxSize = 20;

    /**
     * 队伍
     */
    /**
     * 申请列表上限
     */
    private int teamMaxApplyNum = 20;
    /**
     * 申请失效时间，10分钟
     */
    private int teamApplyExpiredTime = 600000;
    /**
     * 显示队伍列表上限
     */
    private int teamShowMaxNum = 20;
    /**
     * 组队喊话的广播模板Id
     */
    private int teamChatJoinTplId = 16;

    /**
     * 绿野仙踪
     */
    private int wizardRaidFreeTimes = 5;
    private int wizardRaidEnterItemId = 10001;
    private int wizardRaidEnterItemNum = 1;
    /**
     * 变南瓜的时间，毫秒
     */
    private int wizardRaidPumpkinTime = 60000;
    /**
     * boos怪物刷出来，需要杀死多少只其他怪物
     */
    private int wizardRaidBossCond = 2;
    /**
     * 最少n人才能进入副本
     */
    private int wizardRaidMinMemNum = 1;
    /**
     * 在副本内最长时间，毫秒
     */
    private int wizardRaidMaxTime = 3600000;
    //绿野仙踪奖励系数1
    private int wizardRaidRewardCoef1 = 54000;
	//绿野仙踪奖励系数2
    private int wizardRaidRewardCoef2 = 1500;
	//绿野仙踪奖励系数-等级段
    private int wizardRaidRewardLevel = 10;
    
    //科举奖励系数1
    private int examRewardCoef1 = 1750;
    //科举奖励系数2
    private int examRewardCoef2 = 10;
    //科举奖励系数3
    private int examRewardCoef3 = 50;

    /**
     * 帮派竞赛
     */
    /**
     * 帮派竞赛队员最低等级要求
     */
    private int corpsWarMemberMinLevel = 1;
    /**
     * 帮派竞赛队员最少数量
     */
    private int corpsWarMinMemberNum = 1;
    /**
     * 帮派竞赛军团最低等级
     */
    private int corpsWarMinCorpsLevel = 1;
    /**
     * 帮派竞赛队员加入军团最少时间，毫秒
     */
    private long corpsWarMinJoinTime = 8000;
    /**
     * 帮派竞赛队员初始积分
     */
    private int corpsWarInitScore = 100;
    /**
     * 帮派竞赛战斗一局每人分数
     */
    private int corpsWarFightScore = 10;
    /**
     * 帮派竞赛至少参加n场战斗才算有效玩家
     */
    private int corpsWarFightMinNum = 1;
    
    /**
	 * 结婚系统
	 */
	/** 结婚等级*/
	private int marryGrade = 40;
	/** 结婚费用*/
	private long marryCost = 13140;
	/** 强制离婚费用*/
	private long forceFireMarry = 3000000;
	/** 结婚奖励*/
	private int marryRewardId = 1001;

    /**
     * 师徒相关
     **/
    private int overman_min_overman_level = 65; //师傅的级别必须大于65
    private int overman_max_lowerman_count = 3; // 最大的徒弟数量
    private int overman_min_lowerman_level = 20;
    private int overman_max_lowerman_level = 50;
    private int overman_over_lowerman = 60; //徒弟出师的等级
    private int overman_current_force_fire_currency_number = 5000;
    private int overman_overman_reward = 1039; //拜师的时候给师傅送到礼包
    private int overman_lowerman_reward = 1039; //拜师的时候给徒弟的礼包.
    private int overman_finish_lowerman_reward = 1039; //出师的时候给徒弟发送的礼包
    /**
     * 师徒解散关系CD
     */
    private long overman_disbandDelayTime = 24 * 60 * 60 * 1000;
    
    /**
	 * nvn联赛 
	 */
	//最低人数要求
	private int nvnTeamMemberNumMin = 1;
	//初始积分
	private int nvnInitScore = 1000;
	//胜利基准积分
	private int nvnWinScoreBase = 15;
	//失败基准积分
	private int nvnLossScoreBase = 10;
	//轮空积分
	private int nvnNoMatchScore = 15;
	//nvn战斗结束时计算积分公式用到的
	private double nvnBattleScoreCoef1 = 100.0d;
	private double nvnBattleScoreMin1 = 0.5d;
	private double nvnBattleScoreMax1 = 1.5d;
	private double nvnBattleScoreCoef2 = 100.0d;
	private double nvnBattleScoreMin2 = 0.5d;
	private double nvnBattleScoreMax2 = 1.5d;
	//nvn广播
	private int nvnReadyNoticeId = 17;
	private int nvnStartNoticeId = 18;
	private int nvnEndNoticeId = 19;
	/**
	 * 翅膀系统
	 */
	//装备翅膀任务最低等级
	private int wingPlayerMinLevel = 50;
	//翅膀初始阶数
	private int wingInitLevel = 1;
	//升阶失败1次增加的祝福值
	private int wingFailAddBlessPoint = 1;
	//增加1点祝福值提高的概率，放大1000
	private int wingBlessAddCoef = 10;
	//翅膀升阶上限
	private int wingMaxLevel = 10;

	/**
	 * 新手引导常量
	 */
	//穿戴装备任务Id
	private int guideUseEquipQuestId = 10002;
	//宠物出战任务Id
	private int guidePetFightQuestId = 10003;
	//等级奖励的等级
	private int guideLevelRewardLevel = 10;
	//任务引导到第几个任务
	private int guideQuestId = 10004;
	//宠物洗天赋技能任务Id
	private int guidePetTalentQuestId = 10070;
	//打造任务Id
	private int guideCraftQuestId = 10155;
	
	//道具最大叠加数上限
	private int itemMaxOverlapNum = 9999;
	

	public int getWingHumanMinLevel() {
		return wingPlayerMinLevel;
	}

	public void setWingHumanMinLevel(int wingHumanMinLevel) {
		this.wingPlayerMinLevel = wingHumanMinLevel;
	}

	public int getWingInitLevel() {
		return wingInitLevel;
	}

	public void setWingInitLevel(int wingInitLevel) {
		this.wingInitLevel = wingInitLevel;
	}

	public int getWingFailAddBlessPoint() {
		return wingFailAddBlessPoint;
	}

	public void setWingFailAddBlessPoint(int wingFailAddBlessPoint) {
		this.wingFailAddBlessPoint = wingFailAddBlessPoint;
	}

	public int getWingBlessAddCoef() {
		return wingBlessAddCoef;
	}

	public void setWingBlessAddCoef(int wingBlessAddCoef) {
		this.wingBlessAddCoef = wingBlessAddCoef;
	}

	public int getWingMaxLevel() {
		return wingMaxLevel;
	}

	public void setWingMaxLevel(int wingMaxLevel) {
		this.wingMaxLevel = wingMaxLevel;
	}

	public int getOverman_finish_lowerman_reward() {
        return overman_finish_lowerman_reward;
    }

    public void setOverman_finish_lowerman_reward(int overman_finish_lowerman_reward) {
        this.overman_finish_lowerman_reward = overman_finish_lowerman_reward;
    }

    public int getOverman_lowerman_reward() {
        return overman_lowerman_reward;
    }

    public void setOverman_lowerman_reward(int overman_lowerman_reward) {
        this.overman_lowerman_reward = overman_lowerman_reward;
    }

    public int getOverman_overman_reward() {
        return overman_overman_reward;
    }

    public void setOverman_overman_reward(int overman_overman_reward) {
        this.overman_overman_reward = overman_overman_reward;
    }


    public int getOverman_min_overman_level() {
        return overman_min_overman_level;
    }

    public void setOverman_min_overman_level(int overman_min_overman_level) {
        this.overman_min_overman_level = overman_min_overman_level;
    }

    public int getOverman_max_lowerman_count() {
        return overman_max_lowerman_count;
    }

    public void setOverman_max_lowerman_count(int overman_max_lowerman_count) {
        this.overman_max_lowerman_count = overman_max_lowerman_count;
    }

    public int getOverman_min_lowerman_level() {
        return overman_min_lowerman_level;
    }

    public void setOverman_min_lowerman_level(int overman_min_lowerman_level) {
        this.overman_min_lowerman_level = overman_min_lowerman_level;
    }

    public int getOverman_max_lowerman_level() {
        return overman_max_lowerman_level;
    }

    public void setOverman_max_lowerman_level(int overman_max_lowerman_level) {
        this.overman_max_lowerman_level = overman_max_lowerman_level;
    }

    public int getOverman_over_lowerman() {
        return overman_over_lowerman;
    }

    public void setOverman_over_lowerman(int overman_over_lowerman) {
        this.overman_over_lowerman = overman_over_lowerman;
    }

    public int getOverman_current_force_fire_currency_number() {
        return overman_current_force_fire_currency_number;
    }

    public void setOverman_current_force_fire_currency_number(int overman_current_force_fire_currency_number) {
        this.overman_current_force_fire_currency_number = overman_current_force_fire_currency_number;
    }

    public int getNoticeTipsMaxSize() {
        return noticeTipsMaxSize;
    }

    public void setNoticeTipsMaxSize(int noticeTipsMaxSize) {
        this.noticeTipsMaxSize = noticeTipsMaxSize;
    }

    public int getWorldChat() {
        return worldChat;
    }

    /**
     * 设置世界聊天的最小间隔, 单位: 秒
     *
     * @param worldChat
     */
    public void setWorldChat(int worldChat) {
        this.worldChat = worldChat;
    }

    public int getGeneralChat() {
        return generalChat;
    }

    public void setGeneralChat(int generalChat) {
        this.generalChat = generalChat;
    }

    public int getSysGivePowerNum() {
        return sysGivePowerNum;
    }

    public void setSysGivePowerNum(int sysGivePowerNum) {
        this.sysGivePowerNum = sysGivePowerNum;
    }

    public int getSysHumanPowerMax() {
        return sysHumanPowerMax;
    }

    public void setSysHumanPowerMax(int sysHumanPowerMax) {
        this.sysHumanPowerMax = sysHumanPowerMax;
    }

    public int getSysPowerBuyMax() {
        return sysPowerBuyMax;
    }

    public void setSysPowerBuyMax(int sysPowerBuyMax) {
        this.sysPowerBuyMax = sysPowerBuyMax;
    }

    public long getCleanMissionRoundTime() {
        return cleanMissionRoundTime;
    }

    public void setCleanMissionRoundTime(long cleanMissionRoundTime) {
        this.cleanMissionRoundTime = cleanMissionRoundTime;
    }

    public int getCleanMissionRoundBond() {
        return cleanMissionRoundBond;
    }

    public void setCleanMissionRoundBond(int cleanMissionRoundBond) {
        this.cleanMissionRoundBond = cleanMissionRoundBond;
    }

    public int getBattleCd() {
        return battleCd;
    }

    public void setBattleCd(int battleCd) {
        this.battleCd = battleCd;
    }

    public int getCostTokenNum() {
        return costTokenNum;
    }

    public void setCostTokenNum(int costTokenNum) {
        this.costTokenNum = costTokenNum;
    }

    public double getStrengthToAttackRate() {
        return strengthToAttackRate;
    }

    public void setStrengthToAttackRate(double strengthToAttackRate) {
        this.strengthToAttackRate = strengthToAttackRate;
    }

    public double getStrengthToDefenseRate() {
        return strengthToDefenseRate;
    }

    public void setStrengthToDefenseRate(double strengthToDefenseRate) {
        this.strengthToDefenseRate = strengthToDefenseRate;
    }

    public double getAgilityToSpeedRate() {
        return agilityToSpeedRate;
    }

    public void setAgilityToSpeedRate(double agilityToSpeedRate) {
        this.agilityToSpeedRate = agilityToSpeedRate;
    }

    public double getIntellectToAttackRate() {
        return intellectToAttackRate;
    }

    public void setIntellectToAttackRate(double intellectToAttackRate) {
        this.intellectToAttackRate = intellectToAttackRate;
    }

    public double getIntellectToDefenseRate() {
        return intellectToDefenseRate;
    }

    public void setIntellectToDefenseRate(double intellectToDefenseRate) {
        this.intellectToDefenseRate = intellectToDefenseRate;
    }

    public double getLiftToHpRate() {
        return liftToHpRate;
    }

    public void setLiftToHpRate(double liftToHpRate) {
        this.liftToHpRate = liftToHpRate;
    }

    public int getDodgy() {
        return dodgy;
    }

    public void setDodgy(int dodgy) {
        this.dodgy = dodgy;
    }

    public int getFatal() {
        return fatal;
    }

    public void setFatal(int fatal) {
        this.fatal = fatal;
    }

    public int getBolck() {
        return bolck;
    }

    public void setBolck(int bolck) {
        this.bolck = bolck;
    }

    public int getUnfatal() {
        return unfatal;
    }

    public void setUnfatal(int unfatal) {
        this.unfatal = unfatal;
    }

    public int getUnblock() {
        return unblock;
    }

    public void setUnblock(int unblock) {
        this.unblock = unblock;
    }

    public int getHurt() {
        return hurt;
    }

    public void setHurt(int hurt) {
        this.hurt = hurt;
    }

    public int getAvoidHurt() {
        return avoidHurt;
    }

    public void setAvoidHurt(int avoidHurt) {
        this.avoidHurt = avoidHurt;
    }

    public int getBuyRaidTimesCoef() {
        return buyRaidTimesCoef;
    }

    public void setBuyRaidTimesCoef(int buyRaidTimesCoef) {
        this.buyRaidTimesCoef = buyRaidTimesCoef;
    }

    public int getCleanRaidRoundBond() {
        return cleanRaidRoundBond;
    }

    public void setCleanRaidRoundBond(int cleanRaidRoundBond) {
        this.cleanRaidRoundBond = cleanRaidRoundBond;
    }

    public long getCleanRaidRoundTime() {
        return cleanRaidRoundTime;
    }

    public void setCleanRaidRoundTime(long cleanRaidRoundTime) {
        this.cleanRaidRoundTime = cleanRaidRoundTime;
    }


    public int getRandomBase() {
        return randomBase;
    }

    public void setRandomBase(int randomBase) {
        this.randomBase = randomBase;
    }


    public int getMailInInboxExpiredTime() {
        return mailInInboxExpiredTime;
    }

    public void setMailInInboxExpiredTime(int mailInInboxExpiredTime) {
        this.mailInInboxExpiredTime = mailInInboxExpiredTime;
    }

    public int getMailInBoxMaxCount() {
        return mailInBoxMaxCount;
    }

    public void setMailInBoxMaxCount(int mailInBoxMaxCount) {
        this.mailInBoxMaxCount = mailInBoxMaxCount;
    }

    public int getMailSendedBoxMaxCount() {
        return mailSendedBoxMaxCount;
    }

    public void setMailSendedBoxMaxCount(int mailSendedBoxMaxCount) {
        this.mailSendedBoxMaxCount = mailSendedBoxMaxCount;
    }

    public int getMailSaveBoxMaxCount() {
        return mailSaveBoxMaxCount;
    }

    public void setMailSaveBoxMaxCount(int mailSaveBoxMaxCount) {
        this.mailSaveBoxMaxCount = mailSaveBoxMaxCount;
    }

    public int getMailNumPerPage() {
        return mailNumPerPage;
    }

    public void setMailNumPerPage(int mailNumPerPage) {
        this.mailNumPerPage = mailNumPerPage;
    }

    public long getArenaBattleCd() {
        return arenaBattleCd;
    }

    public void setArenaBattleCd(long arenaBattleCd) {
        this.arenaBattleCd = arenaBattleCd;
    }

    public int getLevelMax() {
        return levelMax;
    }

    public void setLevelMax(int levelMax) {
        this.levelMax = levelMax;
    }

    public int getArenaNoticeEndConWinNum() {
        return arenaNoticeEndConWinNum;
    }

    public void setArenaNoticeEndConWinNum(int arenaNoticeEndConWinNum) {
        this.arenaNoticeEndConWinNum = arenaNoticeEndConWinNum;
    }

    public int getArenaEndConWinNoticeId() {
        return arenaEndConWinNoticeId;
    }

    public void setArenaEndConWinNoticeId(int arenaEndConWinNoticeId) {
        this.arenaEndConWinNoticeId = arenaEndConWinNoticeId;
    }

    public int getArenaWinFirstNoticeId() {
        return arenaWinFirstNoticeId;
    }

    public void setArenaWinFirstNoticeId(int arenaWinFirstNoticeId) {
        this.arenaWinFirstNoticeId = arenaWinFirstNoticeId;
    }

    public int getRecommendRewardId() {
        return recommendRewardId;
    }

    public void setRecommendRewardId(int recommendRewardId) {
        this.recommendRewardId = recommendRewardId;
    }


    public int getRelationNumPerPage() {
        return relationNumPerPage;
    }

    public void setRelationNumPerPage(int relationNumPerPage) {
        this.relationNumPerPage = relationNumPerPage;
    }

    public int getRelationRecommendFriendNum() {
        return relationRecommendFriendNum;
    }

    public void setRelationRecommendFriendNum(int relationRecommendFriendNum) {
        this.relationRecommendFriendNum = relationRecommendFriendNum;
    }

    public long getEnhanceCd() {
        return enhanceCd;
    }

    public void setEnhanceCd(long enhanceCd) {
        this.enhanceCd = enhanceCd;
    }

    public int getDirectedWashCost() {
        return directedWashCost;
    }

    public void setDirectedWashCost(int directedWashCost) {
        this.directedWashCost = directedWashCost;
    }

    public int getWeaponSkillWashCost() {
        return weaponSkillWashCost;
    }

    public void setWeaponSkillWashCost(int weaponSkillWashCost) {
        this.weaponSkillWashCost = weaponSkillWashCost;
    }

    public int getBatchWashNum() {
        return batchWashNum;
    }

    public void setBatchWashNum(int batchWashNum) {
        this.batchWashNum = batchWashNum;
    }

    public int getGemMaxLevel() {
        return gemMaxLevel;
    }

    public void setGemMaxLevel(int gemMaxLevel) {
        this.gemMaxLevel = gemMaxLevel;
    }

    public int getHoledItemId() {
        return holedItemId;
    }

    public void setHoledItemId(int holedItemId) {
        this.holedItemId = holedItemId;
    }

    public int getHoledCurrencyTypeId() {
        return holedCurrencyTypeId;
    }

    public void setHoledCurrencyTypeId(int holedCurrencyTypeId) {
        this.holedCurrencyTypeId = holedCurrencyTypeId;
    }

    public int getGemCompositeNum() {
        return gemCompositeNum;
    }

    public void setGemCompositeNum(int gemCompositeNum) {
        this.gemCompositeNum = gemCompositeNum;
    }

    public int getFomuEquipLevelLimit() {
        return fomuEquipLevelLimit;
    }

    public void setFomuEquipLevelLimit(int fomuEquipLevelLimit) {
        this.fomuEquipLevelLimit = fomuEquipLevelLimit;
    }

    public int getBatchFomuNum() {
        return batchFomuNum;
    }

    public void setBatchFomuNum(int batchFomuNum) {
        this.batchFomuNum = batchFomuNum;
    }

    public int getFumoLevelUpper() {
        return fumoLevelUpper;
    }

    public void setFumoLevelUpper(int fumoLevelUpper) {
        this.fumoLevelUpper = fumoLevelUpper;
    }

    public int getGemAotuCompositeLevelLowwer() {
        return gemAotuCompositeLevelLowwer;
    }

    public void setGemAotuCompositeLevelLowwer(int gemAotuCompositeLevelLowwer) {
        this.gemAotuCompositeLevelLowwer = gemAotuCompositeLevelLowwer;
    }

    public int getGemAotuCompositeLevelUpper() {
        return gemAotuCompositeLevelUpper;
    }

    public void setGemAotuCompositeLevelUpper(int gemAotuCompositeLevelUpper) {
        this.gemAotuCompositeLevelUpper = gemAotuCompositeLevelUpper;
    }

    public int getGemMinLevel() {
        return gemMinLevel;
    }

    public void setGemMinLevel(int gemMinLevel) {
        this.gemMinLevel = gemMinLevel;
    }

    public int getPopTipsGetEquipId() {
        return popTipsGetEquipId;
    }

    public void setPopTipsGetEquipId(int popTipsGetEquipId) {
        this.popTipsGetEquipId = popTipsGetEquipId;
    }

    public int getPopTipsMainBagFullId() {
        return popTipsMainBagFullId;
    }

    public void setPopTipsMainBagFullId(int popTipsMainBagFullId) {
        this.popTipsMainBagFullId = popTipsMainBagFullId;
    }

    public int getPopTipsGiftLevelId() {
        return popTipsGiftLevelId;
    }

    public void setPopTipsGiftLevelId(int popTipsGiftLevelId) {
        this.popTipsGiftLevelId = popTipsGiftLevelId;
    }

    public int getPopTipsOpenMindId() {
        return popTipsOpenMindId;
    }

    public void setPopTipsOpenMindId(int popTipsOpenMindId) {
        this.popTipsOpenMindId = popTipsOpenMindId;
    }

    public int getPopTipsNotEnoughGoldId() {
        return popTipsNotEnoughGoldId;
    }

    public void setPopTipsNotEnoughGoldId(int popTipsNotEnoughGoldId) {
        this.popTipsNotEnoughGoldId = popTipsNotEnoughGoldId;
    }

    public int getPopTipsNotEnoughPowerId() {
        return popTipsNotEnoughPowerId;
    }

    public void setPopTipsNotEnoughPowerId(int popTipsNotEnoughPowerId) {
        this.popTipsNotEnoughPowerId = popTipsNotEnoughPowerId;
    }

    public int getPopTipsApplyCorpsPresidentId() {
        return popTipsApplyCorpsPresidentId;
    }

    public void setPopTipsApplyCorpsPresidentId(int popTipsApplyCorpsPresidentId) {
        this.popTipsApplyCorpsPresidentId = popTipsApplyCorpsPresidentId;
    }

    public int getPopTipsMoneytreeUpgradeId() {
        return popTipsMoneytreeUpgradeId;
    }

    public void setPopTipsMoneytreeUpgradeId(int popTipsMoneytreeUpgradeId) {
        this.popTipsMoneytreeUpgradeId = popTipsMoneytreeUpgradeId;
    }

    public int getPopTipsRecommendFriendId() {
        return popTipsRecommendFriendId;
    }

    public void setPopTipsRecommendFriendId(int popTipsRecommendFriendId) {
        this.popTipsRecommendFriendId = popTipsRecommendFriendId;
    }

    public double getFightPowerCoefLevel() {
        return fightPowerCoefLevel;
    }

    public void setFightPowerCoefLevel(double fightPowerCoefLevel) {
        this.fightPowerCoefLevel = fightPowerCoefLevel;
    }

    public double getFightPowerCoefAttack() {
        return fightPowerCoefAttack;
    }

    public void setFightPowerCoefAttack(double fightPowerCoefAttack) {
        this.fightPowerCoefAttack = fightPowerCoefAttack;
    }

    public double getFightPowerCoefDefenceStrengh() {
        return fightPowerCoefDefenceStrengh;
    }

    public void setFightPowerCoefDefenceStrengh(
            double fightPowerCoefDefenceStrengh) {
        this.fightPowerCoefDefenceStrengh = fightPowerCoefDefenceStrengh;
    }

    public double getFightPowerCoefDefenceIntellect() {
        return fightPowerCoefDefenceIntellect;
    }

    public void setFightPowerCoefDefenceIntellect(
            double fightPowerCoefDefenceIntellect) {
        this.fightPowerCoefDefenceIntellect = fightPowerCoefDefenceIntellect;
    }

    public double getFightPowerCoefSpeed() {
        return fightPowerCoefSpeed;
    }

    public void setFightPowerCoefSpeed(double fightPowerCoefSpeed) {
        this.fightPowerCoefSpeed = fightPowerCoefSpeed;
    }

    public double getFightPowerCoefHP() {
        return fightPowerCoefHP;
    }

    public void setFightPowerCoefHP(double fightPowerCoefHP) {
        this.fightPowerCoefHP = fightPowerCoefHP;
    }

    public double getFightPowerCoefHit() {
        return fightPowerCoefHit;
    }

    public void setFightPowerCoefHit(double fightPowerCoefHit) {
        this.fightPowerCoefHit = fightPowerCoefHit;
    }

    public double getFightPowerCoefDodgy() {
        return fightPowerCoefDodgy;
    }

    public void setFightPowerCoefDodgy(double fightPowerCoefDodgy) {
        this.fightPowerCoefDodgy = fightPowerCoefDodgy;
    }

    public double getFightPowerCoefFatal() {
        return fightPowerCoefFatal;
    }

    public void setFightPowerCoefFatal(double fightPowerCoefFatal) {
        this.fightPowerCoefFatal = fightPowerCoefFatal;
    }

    public double getFightPowerCoefUnfatal() {
        return fightPowerCoefUnfatal;
    }

    public void setFightPowerCoefUnfatal(double fightPowerCoefUnfatal) {
        this.fightPowerCoefUnfatal = fightPowerCoefUnfatal;
    }

    public double getFightPowerCoefBlock() {
        return fightPowerCoefBlock;
    }

    public void setFightPowerCoefBlock(double fightPowerCoefBlock) {
        this.fightPowerCoefBlock = fightPowerCoefBlock;
    }

    public double getFightPowerCoefUnblock() {
        return fightPowerCoefUnblock;
    }

    public void setFightPowerCoefUnblock(double fightPowerCoefUnblock) {
        this.fightPowerCoefUnblock = fightPowerCoefUnblock;
    }

    public double getFightPowerCoefRecourse() {
        return fightPowerCoefRecourse;
    }

    public void setFightPowerCoefRecourse(double fightPowerCoefRecourse) {
        this.fightPowerCoefRecourse = fightPowerCoefRecourse;
    }

    public double getFightPowerCoefJoint() {
        return fightPowerCoefJoint;
    }

    public void setFightPowerCoefJoint(double fightPowerCoefJoint) {
        this.fightPowerCoefJoint = fightPowerCoefJoint;
    }

    public double getFightPowerCoefHurt() {
        return fightPowerCoefHurt;
    }

    public void setFightPowerCoefHurt(double fightPowerCoefHurt) {
        this.fightPowerCoefHurt = fightPowerCoefHurt;
    }

    public double getFightPowerCoefAvoidHurt() {
        return fightPowerCoefAvoidHurt;
    }

    public void setFightPowerCoefAvoidHurt(double fightPowerCoefAvoidHurt) {
        this.fightPowerCoefAvoidHurt = fightPowerCoefAvoidHurt;
    }

    public int getLeaderDefaultQualityId() {
        return leaderDefaultQualityId;
    }

    public void setLeaderDefaultQualityId(int leaderDefaultQualityId) {
        this.leaderDefaultQualityId = leaderDefaultQualityId;
    }

    public int getFightPowerCoefPercent() {
        return fightPowerCoefPercent;
    }

    public void setFightPowerCoefPercent(int fightPowerCoefPercent) {
        this.fightPowerCoefPercent = fightPowerCoefPercent;
    }

    public double getExpAmendUpper() {
        return expAmendUpper;
    }

    public void setExpAmendUpper(double expAmendUpper) {
        this.expAmendUpper = expAmendUpper;
    }

    public double getGoldAmendUpper() {
        return goldAmendUpper;
    }

    public void setGoldAmendUpper(double goldAmendUpper) {
        this.goldAmendUpper = goldAmendUpper;
    }

    public double getFrontHurtRate() {
        return frontHurtRate;
    }

    public void setFrontHurtRate(double frontHurtRate) {
        this.frontHurtRate = frontHurtRate;
    }

    public int getFrontInitAnger() {
        return frontInitAnger;
    }

    public void setFrontInitAnger(int frontInitAnger) {
        this.frontInitAnger = frontInitAnger;
    }

    public int getMiddleInitAnger() {
        return middleInitAnger;
    }

    public void setMiddleInitAnger(int middleInitAnger) {
        this.middleInitAnger = middleInitAnger;
    }

    public int getBackInitAnger() {
        return backInitAnger;
    }

    public void setBackInitAnger(int backInitAnger) {
        this.backInitAnger = backInitAnger;
    }

    public int getFirstChargeRewardId() {
        return firstChargeRewardId;
    }

    public void setFirstChargeRewardId(int firstChargeRewardId) {
        this.firstChargeRewardId = firstChargeRewardId;
    }

    public int getAddLoginDaysTimeEventId() {
        return addLoginDaysTimeEventId;
    }

    public void setAddLoginDaysTimeEventId(int addLoginDaysTimeEventId) {
        this.addLoginDaysTimeEventId = addLoginDaysTimeEventId;
    }

    public int getFriendMaxNum() {
        return friendMaxNum;
    }

    public void setFriendMaxNum(int friendMaxNum) {
        this.friendMaxNum = friendMaxNum;
    }

    public int getBlackListMaxNum() {
        return blackListMaxNum;
    }

    public void setBlackListMaxNum(int blackListMaxNum) {
        this.blackListMaxNum = blackListMaxNum;
    }

    public int getMapChat() {
        return mapChat;
    }

    public void setMapChat(int mapChat) {
        this.mapChat = mapChat;
    }

    public int getGuildChat() {
        return guildChat;
    }

    public void setGuildChat(int guildChat) {
        this.guildChat = guildChat;
    }

    public int getFirstOpenVipReward() {
        return firstOpenVipReward;
    }

    public void setFirstOpenVipReward(int firstOpenVipReward) {
        this.firstOpenVipReward = firstOpenVipReward;
    }

    public int getChargeDiamondToExp() {
        return chargeDiamondToExp;
    }

    public void setChargeDiamondToExp(int chargeDiamondToExp) {
        this.chargeDiamondToExp = chargeDiamondToExp;
    }

    public int getGrowthValueReduce() {
        return growthValueReduce;
    }

    public void setGrowthValueReduce(int growthValueReduce) {
        this.growthValueReduce = growthValueReduce;
    }


    public long getTempBagItemValidPeriod() {
        return tempBagItemValidPeriod;
    }

    public void setTempBagItemValidPeriod(long tempBagItemValidPeriod) {
        this.tempBagItemValidPeriod = tempBagItemValidPeriod;
    }

    public int getOpenBagItemTplId() {
        return openBagItemTplId;
    }

    public void setOpenBagItemTplId(int openBagItemTplId) {
        this.openBagItemTplId = openBagItemTplId;
    }

    public int getOpenBagNeedItemNum() {
        return openBagNeedItemNum;
    }

    public void setOpenBagNeedItemNum(int openBagNeedItemNum) {
        this.openBagNeedItemNum = openBagNeedItemNum;
    }

    public int getOpenBagNum() {
        return openBagNum;
    }

    public void setOpenBagNum(int openBagNum) {
        this.openBagNum = openBagNum;
    }

    public int getUpdatePrizeNumPeriod() {
        return updatePrizeNumPeriod;
    }

    public void setUpdatePrizeNumPeriod(int updatePrizeNumPeriod) {
        this.updatePrizeNumPeriod = updatePrizeNumPeriod;
    }

    public int getTreasureNoteTemplateId() {
        return treasureNoteTemplateId;
    }

    public void setTreasureNoteTemplateId(int treasureNoteTemplateId) {
        this.treasureNoteTemplateId = treasureNoteTemplateId;
    }

    public long getMysteryShopCd() {
        return mysteryShopCd;
    }

    public void setMysteryShopCd(long mysteryShopCd) {
        this.mysteryShopCd = mysteryShopCd;
    }

    public long getMsBondFlushPrice() {
        return msBondFlushPrice;
    }

    public void setMsBondFlushPrice(long msBondFlushPrice) {
        this.msBondFlushPrice = msBondFlushPrice;
    }

    public long getMsHighlevelBondFlushPrice() {
        return msHighlevelBondFlushPrice;
    }

    public void setMsHighlevelBondFlushPrice(long msHighlevelBondFlushPrice) {
        this.msHighlevelBondFlushPrice = msHighlevelBondFlushPrice;
    }

    public int getTreasureNoteTemplateNum() {
        return treasureNoteTemplateNum;
    }

    public void setTreasureNoteTemplateNum(int treasureNoteTemplateNum) {
        this.treasureNoteTemplateNum = treasureNoteTemplateNum;
    }

    public int getMsLogMaxNum() {
        return msLogMaxNum;
    }

    public void setMsLogMaxNum(int msLogMaxNum) {
        this.msLogMaxNum = msLogMaxNum;
    }

    public int getSysBuyPowerNum() {
        return sysBuyPowerNum;
    }

    public void setSysBuyPowerNum(int sysBuyPowerNum) {
        this.sysBuyPowerNum = sysBuyPowerNum;
    }

    public String getMallPosterGroup() {
        return mallPosterGroup;
    }

    public void setMallPosterGroup(String mallPosterGroup) {
        this.mallPosterGroup = mallPosterGroup;
    }

    public int getMysteryShopBuyPurpleItemNoticeId() {
        return mysteryShopBuyPurpleItemNoticeId;
    }

    public void setMysteryShopBuyPurpleItemNoticeId(
            int mysteryShopBuyPurpleItemNoticeId) {
        this.mysteryShopBuyPurpleItemNoticeId = mysteryShopBuyPurpleItemNoticeId;
    }

    public int getSinglePurchaseQuantityMax() {
        return singlePurchaseQuantityMax;
    }

    public void setSinglePurchaseQuantityMax(int singlePurchaseQuantityMax) {
        this.singlePurchaseQuantityMax = singlePurchaseQuantityMax;
    }

    public int getMailNumPerPageMobile() {
        return mailNumPerPageMobile;
    }

    public void setMailNumPerPageMobile(int mailNumPerPageMobile) {
        this.mailNumPerPageMobile = mailNumPerPageMobile;
    }

    public short getDefaultNoticeSpeed() {
        return defaultNoticeSpeed;
    }

    public void setDefaultNoticeSpeed(short defaultNoticeSpeed) {
        this.defaultNoticeSpeed = defaultNoticeSpeed;
    }

    public int getRaidBroadcastOpenBoxId() {
        return raidBroadcastOpenBoxId;
    }

    public int getRaidBroadcastBattleId() {
        return raidBroadcastBattleId;
    }

    public int getOpenBoxItemRarityId() {
        return openBoxItemRarityId;
    }

    public int getHumanBattleItemRarityId() {
        return humanBattleItemRarityId;
    }

    public int getPopTipsRelationLimitNum() {
        return popTipsRelationLimitNum;
    }


    public void setRaidBroadcastOpenBoxId(int raidBroadcastOpenBoxId) {
        this.raidBroadcastOpenBoxId = raidBroadcastOpenBoxId;
    }

    public void setOpenBoxItemRarityId(int openBoxItemRarityId) {
        this.openBoxItemRarityId = openBoxItemRarityId;
    }

    public void setRaidBroadcastBattleId(int raidBroadcastBattleId) {
        this.raidBroadcastBattleId = raidBroadcastBattleId;
    }

    public void setHumanBattleItemRarityId(int humanBattleItemRarityId) {
        this.humanBattleItemRarityId = humanBattleItemRarityId;
    }

    public void setPopTipsRelationLimitNum(int popTipsRelationLimitNum) {
        this.popTipsRelationLimitNum = popTipsRelationLimitNum;
    }

    public String getOpenGameDate() {
        return openGameDate;
    }

    public void setOpenGameDate(String openGameDate) {
        this.openGameDate = openGameDate;
    }

    public int getPhoneNumLength() {
        return phoneNumLength;
    }

    public void setPhoneNumLength(int phoneNumLength) {
        this.phoneNumLength = phoneNumLength;
    }

    public int getQqNumLengthMin() {
        return qqNumLengthMin;
    }

    public void setQqNumLengthMin(int qqNumLengthMin) {
        this.qqNumLengthMin = qqNumLengthMin;
    }

    public int getQqNumLengthMax() {
        return qqNumLengthMax;
    }

    public void setQqNumLengthMax(int qqNumLengthMax) {
        this.qqNumLengthMax = qqNumLengthMax;
    }

    public int getCheckCodeLengthMin() {
        return checkCodeLengthMin;
    }

    public void setCheckCodeLengthMin(int checkCodeLengthMin) {
        this.checkCodeLengthMin = checkCodeLengthMin;
    }

    public int getCheckCodeLengthMax() {
        return checkCodeLengthMax;
    }

    public void setCheckCodeLengthMax(int checkCodeLengthMax) {
        this.checkCodeLengthMax = checkCodeLengthMax;
    }

    public int getSmsCheckCodeRewardId() {
        return smsCheckCodeRewardId;
    }

    public void setSmsCheckCodeRewardId(int smsCheckCodeRewardId) {
        this.smsCheckCodeRewardId = smsCheckCodeRewardId;
    }

    public int getQqVipNewerRewardId() {
        return qqVipNewerRewardId;
    }

    public void setQqVipNewerRewardId(int qqVipNewerRewardId) {
        this.qqVipNewerRewardId = qqVipNewerRewardId;
    }

    public int getQqVipHighDayRewardId() {
        return qqVipHighDayRewardId;
    }

    public void setQqVipHighDayRewardId(int qqVipHighDayRewardId) {
        this.qqVipHighDayRewardId = qqVipHighDayRewardId;
    }

    public int getQqVipYearDayRewardId() {
        return qqVipYearDayRewardId;
    }

    public void setQqVipYearDayRewardId(int qqVipYearDayRewardId) {
        this.qqVipYearDayRewardId = qqVipYearDayRewardId;
    }

    public long getGcPingInterval() {
        return gcPingInterval;
    }

    public void setGcPingInterval(long gcPingInterval) {
        this.gcPingInterval = gcPingInterval;
    }

    public int getSessionIdleTime() {
        return sessionIdleTime;
    }

    public void setSessionIdleTime(int sessionIdleTime) {
        this.sessionIdleTime = sessionIdleTime;
    }

    public int getTheMinPowerForSendMail() {
        return theMinPowerForSendMail;
    }

    public void setTheMinPowerForSendMail(int theMinPowerForSendMail) {
        this.theMinPowerForSendMail = theMinPowerForSendMail;
    }

    public int getTheMinPowerForChat() {
        return theMinPowerForChat;
    }

    public void setTheMinPowerForChat(int theMinPowerForChat) {
        this.theMinPowerForChat = theMinPowerForChat;
    }

    public int getTheMinLevelForChangeCorpsNotice() {
        return theMinLevelForChangeCorpsNotice;
    }

    public void setTheMinLevelForChangeCorpsNotice(
            int theMinLevelForChangeCorpsNotice) {
        this.theMinLevelForChangeCorpsNotice = theMinLevelForChangeCorpsNotice;
    }

    public int getQqInviteDayRewardId() {
        return qqInviteDayRewardId;
    }

    public void setQqInviteDayRewardId(int qqInviteDayRewardId) {
        this.qqInviteDayRewardId = qqInviteDayRewardId;
    }

    public int getQqAppScoreRewardId() {
        return qqAppScoreRewardId;
    }

    public void setQqAppScoreRewardId(int qqAppScoreRewardId) {
        this.qqAppScoreRewardId = qqAppScoreRewardId;
    }

    public int getQqAppScoreCdTime() {
        return qqAppScoreCdTime;
    }

    public void setQqAppScoreCdTime(int qqAppScoreCdTime) {
        this.qqAppScoreCdTime = qqAppScoreCdTime;
    }

    public String getQqAppPicUrl() {
        return qqAppPicUrl;
    }

    public void setQqAppPicUrl(String qqAppPicUrl) {
        this.qqAppPicUrl = qqAppPicUrl;
    }

    public int getLoopMaxNum() {
        return loopMaxNum;
    }

    public void setLoopMaxNum(int loopMaxNum) {
        this.loopMaxNum = loopMaxNum;
    }

    public int getLoopRewardNum() {
        return loopRewardNum;
    }

    public void setLoopRewardNum(int loopRewardNum) {
        this.loopRewardNum = loopRewardNum;
    }

    public int getFinishOneConsumeBond() {
        return finishOneConsumeBond;
    }

    public void setFinishOneConsumeBond(int finishOneConsumeBond) {
        this.finishOneConsumeBond = finishOneConsumeBond;
    }

    public int getQqIsLoginPeriodTime() {
        return qqIsLoginPeriodTime;
    }

    public void setQqIsLoginPeriodTime(int qqIsLoginPeriodTime) {
        this.qqIsLoginPeriodTime = qqIsLoginPeriodTime;
    }

    public int getMaxPrivateChatRoleNumPerDay() {
        return maxPrivateChatRoleNumPerDay;
    }

    public void setMaxPrivateChatRoleNumPerDay(int maxPrivateChatRoleNumPerDay) {
        this.maxPrivateChatRoleNumPerDay = maxPrivateChatRoleNumPerDay;
    }

    public int getOpenVipBroadcastId() {
        return openVipBroadcastId;
    }

    public void setOpenVipBroadcastId(int openVipBroadcastId) {
        this.openVipBroadcastId = openVipBroadcastId;
    }

    public int getFinishOneConsumeItemId() {
        return finishOneConsumeItemId;
    }

    public void setFinishOneConsumeItemId(int finishOneConsumeItemId) {
        this.finishOneConsumeItemId = finishOneConsumeItemId;
    }

    public int getBattleReportSpeed2XLevel() {
        return battleReportSpeed2XLevel;
    }

    public void setBattleReportSpeed2XLevel(int battleReportSpeed2XLevel) {
        this.battleReportSpeed2XLevel = battleReportSpeed2XLevel;
    }

    public int getBattleReportSpeed3XLevel() {
        return battleReportSpeed3XLevel;
    }

    public void setBattleReportSpeed3XLevel(int battleReportSpeed3XLevel) {
        this.battleReportSpeed3XLevel = battleReportSpeed3XLevel;
    }

    public int getModelWidth() {
        return modelWidth;
    }

    public void setModelWidth(int modelWidth) {
        this.modelWidth = modelWidth;
    }

    public int getModelHeight() {
        return modelHeight;
    }

    public void setModelHeight(int modelHeight) {
        this.modelHeight = modelHeight;
    }

    public int getInitMapId() {
        return initMapId;
    }

    public void setInitMapId(int initMapId) {
        this.initMapId = initMapId;
    }

    public int getMissionWorldLevelExpAdd() {
        return missionWorldLevelExpAdd;
    }

    public void setMissionWorldLevelExpAdd(int missionWorldLevelExpAdd) {
        this.missionWorldLevelExpAdd = missionWorldLevelExpAdd;
    }

    public int getScale() {
        return scale;
    }

    public void setScale(int scale) {
        this.scale = scale;
    }

    public int getGoodAcitivtyNewTime() {
        return goodAcitivtyNewTime;
    }

    public void setGoodAcitivtyNewTime(int goodAcitivtyNewTime) {
        this.goodAcitivtyNewTime = goodAcitivtyNewTime;
    }

    public int getGoodAcitivtyRecentTime() {
        return goodAcitivtyRecentTime;
    }

    public void setGoodAcitivtyRecentTime(int goodAcitivtyRecentTime) {
        this.goodAcitivtyRecentTime = goodAcitivtyRecentTime;
    }

    public String getMapFileType() {
        return mapFileType;
    }

    public void setMapFileType(String mapFileType) {
        this.mapFileType = mapFileType;
    }

    public int getScreenWidth() {
        return screenWidth;
    }

    public void setScreenWidth(int screenWidth) {
        this.screenWidth = screenWidth;
    }

    public int getScreenHeight() {
        return screenHeight;
    }

    public void setScreenHeight(int screenHeight) {
        this.screenHeight = screenHeight;
    }

    public int getLeaderLevelUpAddPoint() {
        return leaderLevelUpAddPoint;
    }

    public void setLeaderLevelUpAddPoint(int leaderLevelUpAddPoint) {
        this.leaderLevelUpAddPoint = leaderLevelUpAddPoint;
    }

    public int getPetLevelUpAddPoint() {
        return petLevelUpAddPoint;
    }

    public void setPetLevelUpAddPoint(int petLevelUpAddPoint) {
        this.petLevelUpAddPoint = petLevelUpAddPoint;
    }

    public int getPetGeneAdd1() {
        return petGeneAdd1;
    }

    public void setPetGeneAdd1(int petGeneAdd1) {
        this.petGeneAdd1 = petGeneAdd1;
    }

    public int getPetMaxOwnPetNum() {
        return petMaxOwnPetNum;
    }

    public void setPetMaxOwnPetNum(int petMaxOwnPetNum) {
        this.petMaxOwnPetNum = petMaxOwnPetNum;
    }

    public int getPetMaxOwnFriendNum() {
        return petMaxOwnFriendNum;
    }

    public void setPetMaxOwnFriendNum(int petMaxOwnFriendNum) {
        this.petMaxOwnFriendNum = petMaxOwnFriendNum;
    }

    public double getPetGeneProb() {
        return petGeneProb;
    }

    public void setPetGeneProb(double petGeneProb) {
        this.petGeneProb = petGeneProb;
    }

    public double getPetCatchProb() {
        return petCatchProb;
    }

    public void setPetCatchProb(double petCatchProb) {
        this.petCatchProb = petCatchProb;
    }

    public int getPetBattleCostLife() {
        return petBattleCostLife;
    }

    public void setPetBattleCostLife(int petBattleCostLife) {
        this.petBattleCostLife = petBattleCostLife;
    }

    public int getPetBattleCostLifeOnDead() {
        return petBattleCostLifeOnDead;
    }

    public void setPetBattleCostLifeOnDead(int petBattleCostLifeOnDead) {
        this.petBattleCostLifeOnDead = petBattleCostLifeOnDead;
    }

    public int getPetInitLife() {
        return petInitLife;
    }

    public void setPetInitLife(int petInitLife) {
        this.petInitLife = petInitLife;
    }

    public int getPetSkillLevelMax() {
        return petSkillLevelMax;
    }

    public void setPetSkillLevelMax(int petSkillLevelMax) {
        this.petSkillLevelMax = petSkillLevelMax;
    }

    public int getPetTalentSkillNumMax() {
        return petTalentSkillNumMax;
    }

    public void setPetTalentSkillNumMax(int petTalentSkillNumMax) {
        this.petTalentSkillNumMax = petTalentSkillNumMax;
    }

    public int getPetNormalSkillNumMax() {
        return petNormalSkillNumMax;
    }

    public void setPetNormalSkillNumMax(int petNormalSkillNumMax) {
        this.petNormalSkillNumMax = petNormalSkillNumMax;
    }

    public int getPetTalentSkillNumMaxOnCaught() {
        return petTalentSkillNumMaxOnCaught;
    }

    public void setPetTalentSkillNumMaxOnCaught(int petTalentSkillNumMaxOnCaught) {
        this.petTalentSkillNumMaxOnCaught = petTalentSkillNumMaxOnCaught;
    }

    public int getPetTalentSkillResetItemId() {
        return petTalentSkillResetItemId;
    }

    public void setPetTalentSkillResetItemId(int petTalentSkillResetItemId) {
        this.petTalentSkillResetItemId = petTalentSkillResetItemId;
    }

    public int getPetTalentSkillResetItemNum() {
        return petTalentSkillResetItemNum;
    }

    public void setPetTalentSkillResetItemNum(int petTalentSkillResetItemNum) {
        this.petTalentSkillResetItemNum = petTalentSkillResetItemNum;
    }

    public int getPetArtificeArtificeType() {
        return petArtificeArtificeType;
    }

    public int getPetImproveArtificeType() {
        return petImproveArtificeType;
    }

    public int getPetLevelMax() {
        return petLevelMax;
    }

    public int getPetPerceptTimesByBatch() {
        return petPerceptTimesByBatch;
    }

    public int getPetPerceptLevelMax() {
        return petPerceptLevelMax;
    }

    public int getPetPerceptSmallCrit() {
        return petPerceptSmallCrit;
    }

    public int getPubMaxLevel() {
        return pubMaxLevel;
    }

    public void setPubMaxLevel(int pubMaxLevel) {
        this.pubMaxLevel = pubMaxLevel;
    }

    public int getPubTaskRefreshNum() {
        return pubTaskRefreshNum;
    }

    public void setPubTaskRefreshNum(int pubTaskRefreshNum) {
        this.pubTaskRefreshNum = pubTaskRefreshNum;
    }

    public int getQuestionNumOfProvincialExamination() {
        return questionNumOfProvincialExamination;
    }

    public int getPubInitLevel() {
        return pubInitLevel;
    }

    public void setPubInitLevel(int pubInitLevel) {
        this.pubInitLevel = pubInitLevel;
    }

    public void setPetLevelMax(int petLevelMax) {
        this.petLevelMax = petLevelMax;
    }

    public void setPetPerceptTimesByBatch(int petPerceptTimesByBatch) {
        this.petPerceptTimesByBatch = petPerceptTimesByBatch;
    }

    public void setPetPerceptLevelMax(int petPerceptLevelMax) {
        this.petPerceptLevelMax = petPerceptLevelMax;
    }

    public void setPetPerceptSmallCrit(int petPerceptSmallCrit) {
        this.petPerceptSmallCrit = petPerceptSmallCrit;
    }

    public void setPetArtificeArtificeType(int petArtificeArtificeType) {
        this.petArtificeArtificeType = petArtificeArtificeType;
    }

    public void setPetImproveArtificeType(int petImproveArtificeType) {
        this.petImproveArtificeType = petImproveArtificeType;
    }

    public void setQuestionNumOfProvincialExamination(
            int questionNumOfProvincialExamination) {
        this.questionNumOfProvincialExamination = questionNumOfProvincialExamination;
    }

    public int getSongmulingItemId() {
        return songmulingItemId;
    }

    public void setSongmulingItemId(int songmulingItemId) {
        this.songmulingItemId = songmulingItemId;
    }

    public int getYumulingItemId() {
        return yumulingItemId;
    }

    public void setYumulingItemId(int yumulingItemId) {
        this.yumulingItemId = yumulingItemId;
    }

    public int getBattleDefenceHurt() {
        return battleDefenceHurt;
    }

    public void setBattleDefenceHurt(int battleDefenceHurt) {
        this.battleDefenceHurt = battleDefenceHurt;
    }

    public double getBattleCritHurtCoef() {
        return battleCritHurtCoef;
    }

    public void setBattleCritHurtCoef(double battleCritHurtCoef) {
        this.battleCritHurtCoef = battleCritHurtCoef;
    }

    public double getBattleCritCoef0() {
        return battleCritCoef0;
    }

    public void setBattleCritCoef0(double battleCritCoef0) {
        this.battleCritCoef0 = battleCritCoef0;
    }

    public double getBattleLevelCoef() {
        return battleLevelCoef;
    }

    public void setBattleLevelCoef(double battleLevelCoef) {
        this.battleLevelCoef = battleLevelCoef;
    }

    public int getShelfLife() {
        return shelfLife;
    }

    public void setShelfLife(int shelfLife) {
        this.shelfLife = shelfLife;
    }

    public int getHumanLevelOnOpenTrade() {
        return humanLevelOnOpenTrade;
    }

    public void setHumanLevelOnOpenTrade(int humanLevelOnOpenTrade) {
        this.humanLevelOnOpenTrade = humanLevelOnOpenTrade;
    }

    public int getMaxTradeNumByType() {
        return maxTradeNumByType;
    }

    public void setMaxTradeNumByType(int maxTradeNumByType) {
        this.maxTradeNumByType = maxTradeNumByType;
    }

    public int getHumanBoothSize() {
        return humanBoothSize;
    }

    public void setHumanBoothSize(int humanBoothSize) {
        this.humanBoothSize = humanBoothSize;
    }

    public int getTradeEquipLowestLevel() {
        return tradeEquipLowestLevel;
    }

    public void setTradeEquipLowestLevel(int tradeEquipLowestLevel) {
        this.tradeEquipLowestLevel = tradeEquipLowestLevel;
    }

    public int getTradeEquipLowestColor() {
        return tradeEquipLowestColor;
    }

    public void setTradeEquipLowestColor(int tradeEquipLowestColor) {
        this.tradeEquipLowestColor = tradeEquipLowestColor;
    }

    public int getCostTaxForTrade() {
        return costTaxForTrade;
    }

    public void setCostTaxForTrade(int costTaxForTrade) {
        this.costTaxForTrade = costTaxForTrade;
    }

    public int getNormalItemSellPriceRange() {
        return normalItemSellPriceRange;
    }

    public void setNormalItemSellPriceRange(int normalItemSellPriceRange) {
        this.normalItemSellPriceRange = normalItemSellPriceRange;
    }

    public int getTradeNumPerPage() {
        return tradeNumPerPage;
    }

    public void setTradeNumPerPage(int tradeNumPerPage) {
        this.tradeNumPerPage = tradeNumPerPage;
    }

    public int getPetIslandOffsetTime() {
        return petIslandOffsetTime;
    }

    public void setPetIslandOffsetTime(int petIslandOffsetTime) {
        this.petIslandOffsetTime = petIslandOffsetTime;
    }

    public int getPetIslandPeriodTime() {
        return petIslandPeriodTime;
    }

    public void setPetIslandPeriodTime(int petIslandPeriodTime) {
        this.petIslandPeriodTime = petIslandPeriodTime;
    }

    public int getPetIslandDeltaTime() {
        return petIslandDeltaTime;
    }

    public void setPetIslandDeltaTime(int petIslandDeltaTime) {
        this.petIslandDeltaTime = petIslandDeltaTime;
    }

    public int getTradeBaseNum() {
        return tradeBaseNum;
    }

    public void setTradeBaseNum(int tradeBaseNum) {
        this.tradeBaseNum = tradeBaseNum;
    }

    public int getMaxPlayerApplytNum() {
        return maxPlayerApplytNum;
    }

    public void setMaxPlayerApplytNum(int maxPlayerApplytNum) {
        this.maxPlayerApplytNum = maxPlayerApplytNum;
    }

    public int getMaxCorpsReceiveApplyNum() {
        return maxCorpsReceiveApplyNum;
    }

    public void setMaxCorpsReceiveApplyNum(int maxCorpsReceiveApplyNum) {
        this.maxCorpsReceiveApplyNum = maxCorpsReceiveApplyNum;
    }

    public int getNumPerPage() {
        return numPerPage;
    }

    public void setNumPerPage(int numPerPage) {
        this.numPerPage = numPerPage;
    }

    public int getNumPerPageMobile() {
        return numPerPageMobile;
    }

    public void setNumPerPageMobile(int numPerPageMobile) {
        this.numPerPageMobile = numPerPageMobile;
    }

    public int getCorpsNameLength() {
        return corpsNameLength;
    }

    public void setCorpsNameLength(int corpsNameLength) {
        this.corpsNameLength = corpsNameLength;
    }

    public int getCreateCorpsNeedGold() {
        return createCorpsNeedGold;
    }

    public void setCreateCorpsNeedGold(int createCorpsNeedGold) {
        this.createCorpsNeedGold = createCorpsNeedGold;
    }

    public int getInitContribution() {
        return initContribution;
    }

    public void setInitContribution(int initContribution) {
        this.initContribution = initContribution;
    }

    public int getInitDonate() {
        return initDonate;
    }

    public void setInitDonate(int initDonate) {
        this.initDonate = initDonate;
    }

    public int getQqLength() {
        return qqLength;
    }

    public void setQqLength(int qqLength) {
        this.qqLength = qqLength;
    }

    public int getCorpsNoticeLength() {
        return corpsNoticeLength;
    }

    public void setCorpsNoticeLength(int corpsNoticeLength) {
        this.corpsNoticeLength = corpsNoticeLength;
    }

    public int getBondToContributionRate() {
        return bondToContributionRate;
    }

    public void setBondToContributionRate(int bondToContributionRate) {
        this.bondToContributionRate = bondToContributionRate;
    }

    public int getContributionToExpRate() {
        return contributionToExpRate;
    }

    public void setContributionToExpRate(int contributionToExpRate) {
        this.contributionToExpRate = contributionToExpRate;
    }

    public int getCorpsEventMaxSize() {
        return corpsEventMaxSize;
    }

    public void setCorpsEventMaxSize(int corpsEventMaxSize) {
        this.corpsEventMaxSize = corpsEventMaxSize;
    }

    public long getApplyPresidentLimitTime() {
        return applyPresidentLimitTime;
    }

    public void setApplyPresidentLimitTime(long applyPresidentLimitTime) {
        this.applyPresidentLimitTime = applyPresidentLimitTime;
    }

    public double getApplyPresidentLimitContribution() {
        return applyPresidentLimitContribution;
    }

    public void setApplyPresidentLimitContribution(
            double applyPresidentLimitContribution) {
        this.applyPresidentLimitContribution = applyPresidentLimitContribution;
    }

    public int getCorpsStorageCapacity() {
        return corpsStorageCapacity;
    }

    public void setCorpsStorageCapacity(int corpsStorageCapacity) {
        this.corpsStorageCapacity = corpsStorageCapacity;
    }

    public double getExpConverterRate() {
        return expConverterRate;
    }

    public void setExpConverterRate(double expConverterRate) {
        this.expConverterRate = expConverterRate;
    }

    public int getMaxActivityNum() {
        return maxActivityNum;
    }

    public void setMaxActivityNum(int maxActivityNum) {
        this.maxActivityNum = maxActivityNum;
    }

    public int getRecommendActivityProb() {
        return recommendActivityProb;
    }

    public void setRecommendActivityProb(int recommendActivityProb) {
        this.recommendActivityProb = recommendActivityProb;
    }

    public int getRecommendActivityMultiple() {
        return recommendActivityMultiple;
    }

    public void setRecommendActivityMultiple(int recommendActivityMultiple) {
        this.recommendActivityMultiple = recommendActivityMultiple;
    }

    public int getRecommendEnergyMultiple() {
		return recommendEnergyMultiple;
	}

	public void setRecommendEnergyMultiple(int recommendEnergyMultiple) {
		this.recommendEnergyMultiple = recommendEnergyMultiple;
	}

	public int getSpecialActivityCheckTimeEventId() {
        return specialActivityCheckTimeEventId;
    }

    public void setSpecialActivityCheckTimeEventId(
            int specialActivityCheckTimeEventId) {
        this.specialActivityCheckTimeEventId = specialActivityCheckTimeEventId;
    }

    public double getBattleEscapeProbBase() {
        return battleEscapeProbBase;
    }

    public void setBattleEscapeProbBase(double battleEscapeProbBase) {
        this.battleEscapeProbBase = battleEscapeProbBase;
    }

    public double getBattleEscapeProbAdd() {
        return battleEscapeProbAdd;
    }

    public void setBattleEscapeProbAdd(double battleEscapeProbAdd) {
        this.battleEscapeProbAdd = battleEscapeProbAdd;
    }

    public int getPointInAreaOffset() {
        return pointInAreaOffset;
    }

    public void setPointInAreaOffset(int pointInAreaOffset) {
        this.pointInAreaOffset = pointInAreaOffset;
    }

    public int getCorpsLevelLimit() {
        return corpsLevelLimit;
    }

    public void setCorpsLevelLimit(int corpsLevelLimit) {
        this.corpsLevelLimit = corpsLevelLimit;
    }

    public long getDisbandDelayTime() {
        return disbandDelayTime;
    }

    public void setDisbandDelayTime(long disbandDelayTime) {
        this.disbandDelayTime = disbandDelayTime;
    }

    public int getImpeachCheckDays() {
        return impeachCheckDays;
    }

    public void setImpeachCheckDays(int impeachCheckDays) {
        this.impeachCheckDays = impeachCheckDays;
    }

    public int getImpeachValidDay() {
        return impeachValidDay;
    }

    public void setImpeachValidDay(int impeachValidDay) {
        this.impeachValidDay = impeachValidDay;
    }

    public int getImpeachCheckAlertDays() {
        return impeachCheckAlertDays;
    }

    public void setImpeachCheckAlertDays(int impeachCheckAlertDays) {
        this.impeachCheckAlertDays = impeachCheckAlertDays;
    }

    public int getRandomQuickApplytNum() {
        return randomQuickApplytNum;
    }

    public void setRandomQuickApplytNum(int randomQuickApplytNum) {
        this.randomQuickApplytNum = randomQuickApplytNum;
    }

    public int getGemCanBeSynthesisLowestLevel() {
        return gemCanBeSynthesisLowestLevel;
    }

    public void setGemCanBeSynthesisLowestLevel(int gemCanBeSynthesisLowestLevel) {
        this.gemCanBeSynthesisLowestLevel = gemCanBeSynthesisLowestLevel;
    }

    public int getGemCanBeSynthesisHighestLevel() {
        return gemCanBeSynthesisHighestLevel;
    }

    public void setGemCanBeSynthesisHighestLevel(int gemCanBeSynthesisHighestLevel) {
        this.gemCanBeSynthesisHighestLevel = gemCanBeSynthesisHighestLevel;
    }

    public int getTeamMaxApplyNum() {
        return teamMaxApplyNum;
    }

    public void setTeamMaxApplyNum(int teamMaxApplyNum) {
        this.teamMaxApplyNum = teamMaxApplyNum;
    }

    public int getTeamApplyExpiredTime() {
        return teamApplyExpiredTime;
    }

    public void setTeamApplyExpiredTime(int teamApplyExpiredTime) {
        this.teamApplyExpiredTime = teamApplyExpiredTime;
    }

    public int getTeamShowMaxNum() {
        return teamShowMaxNum;
    }

    public void setTeamShowMaxNum(int teamShowMaxNum) {
        this.teamShowMaxNum = teamShowMaxNum;
    }

    public int getTeamChatJoinTplId() {
        return teamChatJoinTplId;
    }

    public void setTeamChatJoinTplId(int teamChatJoinTplId) {
        this.teamChatJoinTplId = teamChatJoinTplId;
    }

    public double getFightPowerCoefHumanSkillLevel() {
        return fightPowerCoefHumanSkillLevel;
    }

    public void setFightPowerCoefHumanSkillLevel(
            double fightPowerCoefHumanSkillLevel) {
        this.fightPowerCoefHumanSkillLevel = fightPowerCoefHumanSkillLevel;
    }

    public double getFightPowerCoefPetNormalSkillLevel() {
        return fightPowerCoefPetNormalSkillLevel;
    }

    public void setFightPowerCoefPetNormalSkillLevel(
            double fightPowerCoefPetNormalSkillLevel) {
        this.fightPowerCoefPetNormalSkillLevel = fightPowerCoefPetNormalSkillLevel;
    }

    public double getFightPowerCoefPetTalentSkillLevel() {
        return fightPowerCoefPetTalentSkillLevel;
    }

    public void setFightPowerCoefPetTalentSkillLevel(
            double fightPowerCoefPetTalentSkillLevel) {
        this.fightPowerCoefPetTalentSkillLevel = fightPowerCoefPetTalentSkillLevel;
    }

    public int getPetScoreGeneType() {
        return petScoreGeneType;
    }

    public void setPetScoreGeneType(int petScoreGeneType) {
        this.petScoreGeneType = petScoreGeneType;
    }

    public int getWizardRaidFreeTimes() {
        return wizardRaidFreeTimes;
    }

    public void setWizardRaidFreeTimes(int wizardRaidFreeTimes) {
        this.wizardRaidFreeTimes = wizardRaidFreeTimes;
    }

    public int getWizardRaidEnterItemId() {
        return wizardRaidEnterItemId;
    }

    public void setWizardRaidEnterItemId(int wizardRaidEnterItemId) {
        this.wizardRaidEnterItemId = wizardRaidEnterItemId;
    }

    public int getWizardRaidEnterItemNum() {
        return wizardRaidEnterItemNum;
    }

    public void setWizardRaidEnterItemNum(int wizardRaidEnterItemNum) {
        this.wizardRaidEnterItemNum = wizardRaidEnterItemNum;
    }


    public int getTeamChat() {
        return teamChat;
    }

    public void setTeamChat(int teamChat) {
        this.teamChat = teamChat;
    }

    public int getCommonTeamChat() {
        return commonTeamChat;
    }

    public void setCommonTeamChat(int commonTeamChat) {
        this.commonTeamChat = commonTeamChat;
    }

    public int getWorldChatCostEnergy() {
        return worldChatCostEnergy;
    }

    public void setWorldChatCostEnergy(int worldChatCostEnergy) {
        this.worldChatCostEnergy = worldChatCostEnergy;
    }

    public int getPetMaxOwnHorseNum() {
        return petMaxOwnHorseNum;
    }

    public void setPetMaxOwnHorseNum(int petMaxOwnHorseNum) {
        this.petMaxOwnHorseNum = petMaxOwnHorseNum;
    }

    public int getInitHpPool() {
        return initHpPool;
    }

    public void setInitHpPool(int initHpPool) {
        this.initHpPool = initHpPool;
    }

    public int getInitMpPool() {
        return initMpPool;
    }

    public void setInitMpPool(int initMpPool) {
        this.initMpPool = initMpPool;
    }

    public long getPetFriendUnlock1Time() {
        return petFriendUnlock1Time;
    }

    public void setPetFriendUnlock1Time(long petFriendUnlock1Time) {
        this.petFriendUnlock1Time = petFriendUnlock1Time;
    }

    public long getPetFriendUnlock2Time() {
        return petFriendUnlock2Time;
    }

    public void setPetFriendUnlock2Time(long petFriendUnlock2Time) {
        this.petFriendUnlock2Time = petFriendUnlock2Time;
    }

    public int getPetVariationBatchNum() {
        return petVariationBatchNum;
    }

    public void setPetVariationBatchNum(int petVariationBatchNum) {
        this.petVariationBatchNum = petVariationBatchNum;
    }

    public double getBattleZDSL1() {
        return battleZDSL1;
    }

    public void setBattleZDSL1(double battleZDSL1) {
        this.battleZDSL1 = battleZDSL1;
    }

    public double getBattleZDSL2() {
        return battleZDSL2;
    }

    public void setBattleZDSL2(double battleZDSL2) {
        this.battleZDSL2 = battleZDSL2;
    }

    public double getBattleAProp1() {
        return battleAProp1;
    }

    public void setBattleAProp1(double battleAProp1) {
        this.battleAProp1 = battleAProp1;
    }

    public static String getOptionOk() {
        return OPTION_OK;
    }

    public static String getOptionCancel() {
        return OPTION_CANCEL;
    }

    public static int getMaxHumanNum() {
        return MAX_HUMAN_NUM;
    }

    public double getBattlePhyDef() {
        return battlePhyDef;
    }

    public void setBattlePhyDef(double battlePhyDef) {
        this.battlePhyDef = battlePhyDef;
    }

    public double getBattlePhyHit() {
        return battlePhyHit;
    }

    public void setBattlePhyHit(double battlePhyHit) {
        this.battlePhyHit = battlePhyHit;
    }

    public double getBattlePhyDod() {
        return battlePhyDod;
    }

    public void setBattlePhyDod(double battlePhyDod) {
        this.battlePhyDod = battlePhyDod;
    }

    public double getBattlePhyCri() {
        return battlePhyCri;
    }

    public void setBattlePhyCri(double battlePhyCri) {
        this.battlePhyCri = battlePhyCri;
    }

    public double getBattlePhyAntCri() {
        return battlePhyAntCri;
    }

    public void setBattlePhyAntCri(double battlePhyAntCri) {
        this.battlePhyAntCri = battlePhyAntCri;
    }

    public double getBattleMagDef() {
        return battleMagDef;
    }

    public void setBattleMagDef(double battleMagDef) {
        this.battleMagDef = battleMagDef;
    }

    public double getBattleMagHit() {
        return battleMagHit;
    }

    public void setBattleMagHit(double battleMagHit) {
        this.battleMagHit = battleMagHit;
    }

    public double getBattleMagDod() {
        return battleMagDod;
    }

    public void setBattleMagDod(double battleMagDod) {
        this.battleMagDod = battleMagDod;
    }

    public double getBattleMagCri() {
        return battleMagCri;
    }

    public void setBattleMagCri(double battleMagCri) {
        this.battleMagCri = battleMagCri;
    }

    public double getBattleMagAntCri() {
        return battleMagAntCri;
    }

    public void setBattleMagAntCri(double battleMagAntCri) {
        this.battleMagAntCri = battleMagAntCri;
    }

    public double getBattleMS() {
        return battleMS;
    }

    public void setBattleMS(double battleMS) {
        this.battleMS = battleMS;
    }

    public double getBattleDodgy() {
        return battleDodgy;
    }

    public void setBattleDodgy(double battleDodgy) {
        this.battleDodgy = battleDodgy;
    }

    public double getBattleAntiCrit() {
        return battleAntiCrit;
    }

    public void setBattleAntiCrit(double battleAntiCrit) {
        this.battleAntiCrit = battleAntiCrit;
    }

    public double getBattleDeadFly() {
        return battleDeadFly;
    }

    public void setBattleDeadFly(double battleDeadFly) {
        this.battleDeadFly = battleDeadFly;
    }

    public int getBattleLeftMin() {
        return battleLeftMin;
    }

    public void setBattleLeftMin(int battleLeftMin) {
        this.battleLeftMin = battleLeftMin;
    }

    public int getBattleSpMax() {
        return battleSpMax;
    }

    public void setBattleSpMax(int battleSpMax) {
        this.battleSpMax = battleSpMax;
    }

    public int getBattleAddSp() {
        return battleAddSp;
    }

    public void setBattleAddSp(int battleAddSp) {
        this.battleAddSp = battleAddSp;
    }

    public int getInitLifePool() {
        return initLifePool;
    }

    public void setInitLifePool(int initLifePool) {
        this.initLifePool = initLifePool;
    }

    public int getPetFightLifeMin() {
        return petFightLifeMin;
    }

    public void setPetFightLifeMin(int petFightLifeMin) {
        this.petFightLifeMin = petFightLifeMin;
    }

    public int getMaxHpPool() {
        return maxHpPool;
    }

    public void setMaxHpPool(int maxHpPool) {
        this.maxHpPool = maxHpPool;
    }

    public int getMaxMpPool() {
        return maxMpPool;
    }

    public void setMaxMpPool(int maxMpPool) {
        this.maxMpPool = maxMpPool;
    }

    public int getMaxLifePool() {
        return maxLifePool;
    }

    public void setMaxLifePool(int maxLifePool) {
        this.maxLifePool = maxLifePool;
    }

    public int getPubTaskRefreshManulItemId() {
        return pubTaskRefreshManulItemId;
    }

    public void setPubTaskRefreshManulItemId(int pubTaskRefreshManulItemId) {
        this.pubTaskRefreshManulItemId = pubTaskRefreshManulItemId;
    }

    public int getPubTaskRefreshManulGold() {
        return pubTaskRefreshManulGold;
    }

    public void setPubTaskRefreshManulGold(int pubTaskRefreshManulGold) {
        this.pubTaskRefreshManulGold = pubTaskRefreshManulGold;
    }

    public int getPetResetPointItemId() {
        return petResetPointItemId;
    }

    public void setPetResetPointItemId(int petResetPointItemId) {
        this.petResetPointItemId = petResetPointItemId;
    }

    public int getPetResetPointItemNum() {
        return petResetPointItemNum;
    }

    public void setPetResetPointItemNum(int petResetPointItemNum) {
        this.petResetPointItemNum = petResetPointItemNum;
    }

    public int getWizardRaidPumpkinTime() {
        return wizardRaidPumpkinTime;
    }

    public void setWizardRaidPumpkinTime(int wizardRaidPumpkinTime) {
        this.wizardRaidPumpkinTime = wizardRaidPumpkinTime;
    }

    public int getWizardRaidBossCond() {
        return wizardRaidBossCond;
    }

    public void setWizardRaidBossCond(int wizardRaidBossCond) {
        this.wizardRaidBossCond = wizardRaidBossCond;
    }

    public int getWizardRaidMinMemNum() {
        return wizardRaidMinMemNum;
    }

    public void setWizardRaidMinMemNum(int wizardRaidMinMemNum) {
        this.wizardRaidMinMemNum = wizardRaidMinMemNum;
    }

    public int getWizardRaidMaxTime() {
        return wizardRaidMaxTime;
    }

    public void setWizardRaidMaxTime(int wizardRaidMaxTime) {
        this.wizardRaidMaxTime = wizardRaidMaxTime;
    }

    public int getTheSweeneyTaskRefreshNum() {
        return TheSweeneyTaskRefreshNum;
    }

    public void setTheSweeneyTaskRefreshNum(int theSweeneyTaskRefreshNum) {
        TheSweeneyTaskRefreshNum = theSweeneyTaskRefreshNum;
    }

    public int getTreasureMapRefreshNum() {
        return TreasureMapRefreshNum;
    }

    public void setTreasureMapRefreshNum(int treasureMapRefreshNum) {
        TreasureMapRefreshNum = treasureMapRefreshNum;
    }

    public int getPetGrowthColor() {
        return petGrowthColor;
    }

    public void setPetGrowthColor(int petGrowthColor) {
        this.petGrowthColor = petGrowthColor;
    }

    public double getPetOverColor() {
        return petOverColor;
    }

    public void setPetOverColor(double petOverColor) {
        this.petOverColor = petOverColor;
    }

    public int getPetColorNormalMaxCount() {
        return petColorNormalMaxCount;
    }

    public void setPetColorNormalMaxCount(int petColorNormalMaxCount) {
        this.petColorNormalMaxCount = petColorNormalMaxCount;
    }

    public int getPetColorBestMaxCount() {
        return petColorBestMaxCount;
    }

    public void setPetColorBestMaxCount(int petColorBestMaxCount) {
        this.petColorBestMaxCount = petColorBestMaxCount;
    }

    public double getPetColorNormalRate1() {
        return petColorNormalRate1;
    }

    public void setPetColorNormalRate1(double petColorNormalRate1) {
        this.petColorNormalRate1 = petColorNormalRate1;
    }

    public double getPetColorBestRate1() {
        return petColorBestRate1;
    }

    public void setPetColorBestRate1(double petColorBestRate1) {
        this.petColorBestRate1 = petColorBestRate1;
    }

    public double getPetColorBestRate2() {
        return petColorBestRate2;
    }

    public void setPetColorBestRate2(double petColorBestRate2) {
        this.petColorBestRate2 = petColorBestRate2;
    }

    public int getCorpsWarMemberMinLevel() {
        return corpsWarMemberMinLevel;
    }

    public int getRedGemId() {
        return redGemId;
    }

    public void setCorpsWarMemberMinLevel(int corpsWarMemberMinLevel) {
        this.corpsWarMemberMinLevel = corpsWarMemberMinLevel;
    }

    public int getCorpsWarMinMemberNum() {
        return corpsWarMinMemberNum;
    }

    public void setCorpsWarMinMemberNum(int corpsWarMinMemberNum) {
        this.corpsWarMinMemberNum = corpsWarMinMemberNum;
    }

    public int getCorpsWarMinCorpsLevel() {
        return corpsWarMinCorpsLevel;
    }

    public void setCorpsWarMinCorpsLevel(int corpsWarMinCorpsLevel) {
        this.corpsWarMinCorpsLevel = corpsWarMinCorpsLevel;
    }

    public long getCorpsWarMinJoinTime() {
        return corpsWarMinJoinTime;
    }

    public void setCorpsWarMinJoinTime(long corpsWarMinJoinTime) {
        this.corpsWarMinJoinTime = corpsWarMinJoinTime;
    }

    public int getCorpsWarInitScore() {
        return corpsWarInitScore;
    }

    public void setCorpsWarInitScore(int corpsWarInitScore) {
        this.corpsWarInitScore = corpsWarInitScore;
    }

    public int getCorpsWarFightScore() {
        return corpsWarFightScore;
    }

    public void setCorpsWarFightScore(int corpsWarFightScore) {
        this.corpsWarFightScore = corpsWarFightScore;
    }

    public void setRedGemId(int redGemId) {
        this.redGemId = redGemId;
    }

    public int getGreenGemId() {
        return greenGemId;
    }

    public void setGreenGemId(int greenGemId) {
        this.greenGemId = greenGemId;
    }

    public int getBlueGemId() {
        return blueGemId;
    }

    public void setBlueGemId(int blueGemId) {
        this.blueGemId = blueGemId;
    }

    public int getPurpleGemId() {
        return purpleGemId;
    }

    public void setPurpleGemId(int purpleGemId) {
        this.purpleGemId = purpleGemId;
    }

    public int getYellowGemId() {
        return yellowGemId;
    }

    public void setYellowGemId(int yellowGemId) {
        this.yellowGemId = yellowGemId;
    }

    public int getGemSynthesisBaseNum() {
        return gemSynthesisBaseNum;
    }

    public void setGemSynthesisBaseNum(int gemSynthesisBaseNum) {
        this.gemSynthesisBaseNum = gemSynthesisBaseNum;
    }

    public int getGemCanBeSynthesisLowestBase() {
        return gemCanBeSynthesisLowestBase;
    }

    public void setGemCanBeSynthesisLowestBase(int gemCanBeSynthesisLowestBase) {
        this.gemCanBeSynthesisLowestBase = gemCanBeSynthesisLowestBase;
    }

    public int getGemCanBeSynthesisHighestBase() {
        return gemCanBeSynthesisHighestBase;
    }

    public void setGemCanBeSynthesisHighestBase(int gemCanBeSynthesisHighestBase) {
        this.gemCanBeSynthesisHighestBase = gemCanBeSynthesisHighestBase;
    }

    public int getForageTaskMinLevel() {
        return forageTaskMinLevel;
    }

    public void setForageTaskMinLevel(int forageTaskMinLevel) {
        this.forageTaskMinLevel = forageTaskMinLevel;
    }

    public int getForageTaskRefreshManulItemId() {
        return forageTaskRefreshManulItemId;
    }

    public void setForageTaskRefreshManulItemId(int forageTaskRefreshManulItemId) {
        this.forageTaskRefreshManulItemId = forageTaskRefreshManulItemId;
    }

    public int getForageTaskRefreshManulItemNum() {
        return forageTaskRefreshManulItemNum;
    }

    public void setForageTaskRefreshManulItemNum(int forageTaskRefreshManulItemNum) {
        this.forageTaskRefreshManulItemNum = forageTaskRefreshManulItemNum;
    }

    public int getForageTaskCanDoNum() {
        return forageTaskCanDoNum;
    }

    public void setForageTaskCanDoNum(int forageTaskCanDoNum) {
        this.forageTaskCanDoNum = forageTaskCanDoNum;
    }

    public int getForageTaskBattleFailMaxNum() {
        return forageTaskBattleFailMaxNum;
    }

    public void setForageTaskBattleFailMaxNum(int forageTaskBattleFailMaxNum) {
        this.forageTaskBattleFailMaxNum = forageTaskBattleFailMaxNum;
    }

    public int getCorpsWarFightMinNum() {
        return corpsWarFightMinNum;
    }

    public void setCorpsWarFightMinNum(int corpsWarFightMinNum) {
        this.corpsWarFightMinNum = corpsWarFightMinNum;
    }

	public int getNvnTeamMemberNumMin() {
		return nvnTeamMemberNumMin;
	}

	public void setNvnTeamMemberNumMin(int nvnTeamMemberNumMin) {
		this.nvnTeamMemberNumMin = nvnTeamMemberNumMin;
	}

	public int getNvnInitScore() {
		return nvnInitScore;
	}

	public void setNvnInitScore(int nvnInitScore) {
		this.nvnInitScore = nvnInitScore;
	}

	public int getNvnWinScoreBase() {
		return nvnWinScoreBase;
	}

	public void setNvnWinScoreBase(int nvnWinScoreBase) {
		this.nvnWinScoreBase = nvnWinScoreBase;
	}

	public int getNvnLossScoreBase() {
		return nvnLossScoreBase;
	}

	public void setNvnLossScoreBase(int nvnLossScoreBase) {
		this.nvnLossScoreBase = nvnLossScoreBase;
	}

	public int getNvnNoMatchScore() {
		return nvnNoMatchScore;
	}

	public void setNvnNoMatchScore(int nvnNoMatchScore) {
		this.nvnNoMatchScore = nvnNoMatchScore;
	}

	public double getNvnBattleScoreCoef1() {
		return nvnBattleScoreCoef1;
	}

	public void setNvnBattleScoreCoef1(double nvnBattleScoreCoef1) {
		this.nvnBattleScoreCoef1 = nvnBattleScoreCoef1;
	}

	public double getNvnBattleScoreMin1() {
		return nvnBattleScoreMin1;
	}

	public void setNvnBattleScoreMin1(double nvnBattleScoreMin1) {
		this.nvnBattleScoreMin1 = nvnBattleScoreMin1;
	}

	public double getNvnBattleScoreMax1() {
		return nvnBattleScoreMax1;
	}

	public void setNvnBattleScoreMax1(double nvnBattleScoreMax1) {
		this.nvnBattleScoreMax1 = nvnBattleScoreMax1;
	}

	public double getNvnBattleScoreCoef2() {
		return nvnBattleScoreCoef2;
	}

	public void setNvnBattleScoreCoef2(double nvnBattleScoreCoef2) {
		this.nvnBattleScoreCoef2 = nvnBattleScoreCoef2;
	}

	public double getNvnBattleScoreMin2() {
		return nvnBattleScoreMin2;
	}

	public void setNvnBattleScoreMin2(double nvnBattleScoreMin2) {
		this.nvnBattleScoreMin2 = nvnBattleScoreMin2;
	}

	public double getNvnBattleScoreMax2() {
		return nvnBattleScoreMax2;
	}

	public void setNvnBattleScoreMax2(double nvnBattleScoreMax2) {
		this.nvnBattleScoreMax2 = nvnBattleScoreMax2;
	}

	public int getMarryGrade() {
		return marryGrade;
	}

	public void setMarryGrade(int marryGrade) {
		this.marryGrade = marryGrade;
	}

	public long getMarryCost() {
		return marryCost;
	}

	public void setMarryCost(long marryCost) {
		this.marryCost = marryCost;
	}

	public long getForceFireMarry() {
		return forceFireMarry;
	}

	public void setForceFireMarry(long forceFireMarry) {
		this.forceFireMarry = forceFireMarry;
	}

	public int getMarryRewardId() {
		return marryRewardId;
	}

	public void setMarryRewardId(int marryRewardId) {
		this.marryRewardId = marryRewardId;
	}

	public int getArenaRankOffset() {
		return arenaRankOffset;
	}

	public void setArenaRankOffset(int arenaRankOffset) {
		this.arenaRankOffset = arenaRankOffset;
	}

	public int getArenaRankRewardMax() {
		return arenaRankRewardMax;
	}

	public void setArenaRankRewardMax(int arenaRankRewardMax) {
		this.arenaRankRewardMax = arenaRankRewardMax;
	}

	public int getArenaRobotPetId() {
		return arenaRobotPetId;
	}

	public void setArenaRobotPetId(int arenaRobotPetId) {
		this.arenaRobotPetId = arenaRobotPetId;
	}

	public int getArenaRobotFriendId1() {
		return arenaRobotFriendId1;
	}

	public void setArenaRobotFriendId1(int arenaRobotFriendId1) {
		this.arenaRobotFriendId1 = arenaRobotFriendId1;
	}

	public int getArenaRobotFriendId2() {
		return arenaRobotFriendId2;
	}

	public void setArenaRobotFriendId2(int arenaRobotFriendId2) {
		this.arenaRobotFriendId2 = arenaRobotFriendId2;
	}

	public int getArenaRobotFriendId3() {
		return arenaRobotFriendId3;
	}

	public void setArenaRobotFriendId3(int arenaRobotFriendId3) {
		this.arenaRobotFriendId3 = arenaRobotFriendId3;
	}

	public int getArenaRobotFriendId4() {
		return arenaRobotFriendId4;
	}

	public void setArenaRobotFriendId4(int arenaRobotFriendId4) {
		this.arenaRobotFriendId4 = arenaRobotFriendId4;
	}

	public int getArenaKillCdCost() {
		return arenaKillCdCost;
	}

	public void setArenaKillCdCost(int arenaKillCdCost) {
		this.arenaKillCdCost = arenaKillCdCost;
	}

	public int getArenaBuyAddTimes() {
		return arenaBuyAddTimes;
	}

	public void setArenaBuyAddTimes(int arenaBuyAddTimes) {
		this.arenaBuyAddTimes = arenaBuyAddTimes;
	}

	public int getNvnReadyNoticeId() {
		return nvnReadyNoticeId;
	}

	public void setNvnReadyNoticeId(int nvnReadyNoticeId) {
		this.nvnReadyNoticeId = nvnReadyNoticeId;
	}

	public int getNvnStartNoticeId() {
		return nvnStartNoticeId;
	}

	public void setNvnStartNoticeId(int nvnStartNoticeId) {
		this.nvnStartNoticeId = nvnStartNoticeId;
	}

	public int getNvnEndNoticeId() {
		return nvnEndNoticeId;
	}

	public void setNvnEndNoticeId(int nvnEndNoticeId) {
		this.nvnEndNoticeId = nvnEndNoticeId;
	}

	public int getPetIslandGoodPetShowNoticeId() {
		return petIslandGoodPetShowNoticeId;
	}

	public void setPetIslandGoodPetShowNoticeId(int petIslandGoodPetShowNoticeId) {
		this.petIslandGoodPetShowNoticeId = petIslandGoodPetShowNoticeId;
	}

	public int getPetIslandGoodPetCaughtNoticeId() {
		return petIslandGoodPetCaughtNoticeId;
	}

	public void setPetIslandGoodPetCaughtNoticeId(int petIslandGoodPetCaughtNoticeId) {
		this.petIslandGoodPetCaughtNoticeId = petIslandGoodPetCaughtNoticeId;
	}

	public int getPetIslandGoodPetLeaveNoticeId() {
		return petIslandGoodPetLeaveNoticeId;
	}

	public void setPetIslandGoodPetLeaveNoticeId(int petIslandGoodPetLeaveNoticeId) {
		this.petIslandGoodPetLeaveNoticeId = petIslandGoodPetLeaveNoticeId;
	}

	public double getContriConvertExpRate() {
		return contriConvertExpRate;
	}

	public void setContriConvertExpRate(double contriConvertExpRate) {
		this.contriConvertExpRate = contriConvertExpRate;
	}

	public int getWingPlayerMinLevel() {
		return wingPlayerMinLevel;
	}

	public void setWingPlayerMinLevel(int wingPlayerMinLevel) {
		this.wingPlayerMinLevel = wingPlayerMinLevel;
	}

	public int getMaxDelinquentNum() {
		return maxDelinquentNum;
	}

	public void setMaxDelinquentNum(int maxDelinquentNum) {
		this.maxDelinquentNum = maxDelinquentNum;
	}

	public double getPresidentCoef() {
		return presidentCoef;
	}

	public void setPresidentCoef(double presidentCoef) {
		this.presidentCoef = presidentCoef;
	}

	public double getViceChairmanCoef() {
		return viceChairmanCoef;
	}

	public void setViceChairmanCoef(double viceChairmanCoef) {
		this.viceChairmanCoef = viceChairmanCoef;
	}

	public double getEliteCoef() {
		return eliteCoef;
	}

	public void setEliteCoef(double eliteCoef) {
		this.eliteCoef = eliteCoef;
	}

	public int getGuideUseEquipQuestId() {
		return guideUseEquipQuestId;
	}

	public void setGuideUseEquipQuestId(int guideUseEquipQuestId) {
		this.guideUseEquipQuestId = guideUseEquipQuestId;
	}

	public int getGuidePetFightQuestId() {
		return guidePetFightQuestId;
	}

	public void setGuidePetFightQuestId(int guidePetFightQuestId) {
		this.guidePetFightQuestId = guidePetFightQuestId;
	}

	public int getGuideLevelRewardLevel() {
		return guideLevelRewardLevel;
	}

	public void setGuideLevelRewardLevel(int guideLevelRewardLevel) {
		this.guideLevelRewardLevel = guideLevelRewardLevel;
	}

	public long getExamStartTime() {
		return examStartTime;
	}

	public void setExamStartTime(long examStartTime) {
		this.examStartTime = examStartTime;
	}

	public long getExamEndTime() {
		return examEndTime;
	}

	public void setExamEndTime(long examEndTime) {
		this.examEndTime = examEndTime;
	}

	public int getPetHorseFightLoyMin() {
		return PetHorseFightLoyMin;
	}

	public void setPetHorseFightLoyMin(int petHorseFightLoyMin) {
		PetHorseFightLoyMin = petHorseFightLoyMin;
	}

	public int getPetHorseInitLoy() {
		return PetHorseInitLoy;
	}

	public void setPetHorseInitLoy(int petHorseInitLoy) {
		PetHorseInitLoy = petHorseInitLoy;
	}

	public int getPetHorseInitClo() {
		return PetHorseInitClo;
	}

	public void setPetHorseInitClo(int petHorseInitClo) {
		PetHorseInitClo = petHorseInitClo;
	}

	public double getPetHorseAddCoef() {
		return petHorseAddCoef;
	}

	public void setPetHorseAddCoef(double petHorseAddCoef) {
		this.petHorseAddCoef = petHorseAddCoef;
	}

	public int getGuideQuestId() {
		return guideQuestId;
	}

	public void setGuideQuestId(int guideQuestId) {
		this.guideQuestId = guideQuestId;
	}

	public long getOverman_disbandDelayTime() {
		return overman_disbandDelayTime;
	}

	public void setOverman_disbandDelayTime(long overman_disbandDelayTime) {
		this.overman_disbandDelayTime = overman_disbandDelayTime;
	}

	public int getBattlePvpWaitTime() {
		return battlePvpWaitTime;
	}

	public void setBattlePvpWaitTime(int battlePvpWaitTime) {
		this.battlePvpWaitTime = battlePvpWaitTime;
	}

	public int getWizardRaidRewardCoef1() {
		return wizardRaidRewardCoef1;
	}

	public void setWizardRaidRewardCoef1(int wizardRaidRewardCoef1) {
		this.wizardRaidRewardCoef1 = wizardRaidRewardCoef1;
	}

	public int getWizardRaidRewardCoef2() {
		return wizardRaidRewardCoef2;
	}

	public void setWizardRaidRewardCoef2(int wizardRaidRewardCoef2) {
		this.wizardRaidRewardCoef2 = wizardRaidRewardCoef2;
	}

	public int getWizardRaidRewardLevel() {
		return wizardRaidRewardLevel;
	}

	public void setWizardRaidRewardLevel(int wizardRaidRewardLevel) {
		this.wizardRaidRewardLevel = wizardRaidRewardLevel;
	}

	public int getExamRewardCoef1() {
		return examRewardCoef1;
	}

	public void setExamRewardCoef1(int examRewardCoef1) {
		this.examRewardCoef1 = examRewardCoef1;
	}

	public int getExamRewardCoef2() {
		return examRewardCoef2;
	}

	public void setExamRewardCoef2(int examRewardCoef2) {
		this.examRewardCoef2 = examRewardCoef2;
	}

	public int getExamRewardCoef3() {
		return examRewardCoef3;
	}

	public void setExamRewardCoef3(int examRewardCoef3) {
		this.examRewardCoef3 = examRewardCoef3;
	}

	public int getMsRefereshCoef() {
		return msRefereshCoef;
	}

	public void setMsRefereshCoef(int msRefereshCoef) {
		this.msRefereshCoef = msRefereshCoef;
	}

	public int getMsShowNum() {
		return msShowNum;
	}

	public void setMsShowNum(int msShowNum) {
		this.msShowNum = msShowNum;
	}

	public int getSysGiveDoublePointNum() {
		return sysGiveDoublePointNum;
	}

	public void setSysGiveDoublePointNum(int sysGiveDoublePointNum) {
		this.sysGiveDoublePointNum = sysGiveDoublePointNum;
	}

	public int getSysGiveDoublePointMax() {
		return sysGiveDoublePointMax;
	}

	public void setSysGiveDoublePointMax(int sysGiveDoublePointMax) {
		this.sysGiveDoublePointMax = sysGiveDoublePointMax;
	}

	public int getUseGiveDoublePointNum() {
		return useGiveDoublePointNum;
	}

	public void setUseGiveDoublePointNum(int useGiveDoublePointNum) {
		this.useGiveDoublePointNum = useGiveDoublePointNum;
	}

	public int getCorpsBossBaseRewardNum() {
		return corpsBossMaxRewardNum;
	}

	public void setCorpsBossBaseRewardNum(int corpsBossBaseRewardNum) {
		this.corpsBossMaxRewardNum = corpsBossBaseRewardNum;
	}

	public int getCorpsBossMaxRewardNum() {
		return corpsBossMaxRewardNum;
	}

	public void setCorpsBossMaxRewardNum(int corpsBossMaxRewardNum) {
		this.corpsBossMaxRewardNum = corpsBossMaxRewardNum;
	}

	public int getShowBossRankSize() {
		return showBossRankSize;
	}

	public void setShowBossRankSize(int showBossRankSize) {
		this.showBossRankSize = showBossRankSize;
	}

	public int getBossRankRewardSize() {
		return bossRankRewardSize;
	}

	public void setBossRankRewardSize(int bossRankRewardSize) {
		this.bossRankRewardSize = bossRankRewardSize;
	}

	public int getShowBossCountRankSize() {
		return showBossCountRankSize;
	}

	public void setShowBossCountRankSize(int showBossCountRankSize) {
		this.showBossCountRankSize = showBossCountRankSize;
	}

	public int getBossCountRankRewardSize() {
		return bossCountRankRewardSize;
	}

	public void setBossCountRankRewardSize(int bossCountRankRewardSize) {
		this.bossCountRankRewardSize = bossCountRankRewardSize;
	}

	public int getCorpsBossMinCorpsLevel() {
		return corpsBossMinCorpsLevel;
	}

	public void setCorpsBossMinCorpsLevel(int corpsBossMinCorpsLevel) {
		this.corpsBossMinCorpsLevel = corpsBossMinCorpsLevel;
	}

	public int getCorpsBossMemberMinLevel() {
		return corpsBossMemberMinLevel;
	}

	public void setCorpsBossMemberMinLevel(int corpsBossMemberMinLevel) {
		this.corpsBossMemberMinLevel = corpsBossMemberMinLevel;
	}

	public int getCorpsBossMinMemberNum() {
		return corpsBossMinMemberNum;
	}

	public void setCorpsBossMinMemberNum(int corpsBossMinMemberNum) {
		this.corpsBossMinMemberNum = corpsBossMinMemberNum;
	}

	public int getChapterByCorpsBoss() {
		return chapterByCorpsBoss;
	}

	public void setChapterByCorpsBoss(int chapterByCorpsBoss) {
		this.chapterByCorpsBoss = chapterByCorpsBoss;
	}

	public int getCorpsBossMinJoinTime() {
		return corpsBossMinJoinTime;
	}

	public void setCorpsBossMinJoinTime(int corpsBossMinJoinTime) {
		this.corpsBossMinJoinTime = corpsBossMinJoinTime;
	}

	public int getCorpsBossRefreshDayOfWeek() {
		return corpsBossRefreshDayOfWeek;
	}

	public void setCorpsBossRefreshDayOfWeek(int corpsBossRefreshDayOfWeek) {
		this.corpsBossRefreshDayOfWeek = corpsBossRefreshDayOfWeek;
	}

	public int getCorpsBossRefreshDayOfHour() {
		return corpsBossRefreshDayOfHour;
	}

	public void setCorpsBossRefreshDayOfHour(int corpsBossRefreshDayOfHour) {
		this.corpsBossRefreshDayOfHour = corpsBossRefreshDayOfHour;
	}

	public int getCorpsBossRankRewardTimeId() {
		return corpsBossRankRewardTimeId;
	}

	public void setCorpsBossRankRewardTimeId(int corpsBossRankRewardTimeId) {
		this.corpsBossRankRewardTimeId = corpsBossRankRewardTimeId;
	}

	public int getDemonRefreshMaxNum() {
		return demonRefreshMaxNum;
	}

	public void setDemonRefreshMaxNum(int demonRefreshMaxNum) {
		this.demonRefreshMaxNum = demonRefreshMaxNum;
	}

	public int getDemonKingRefreshMaxNum() {
		return demonKingRefreshMaxNum;
	}

	public void setDemonKingRefreshMaxNum(int demonKingRefreshMaxNum) {
		this.demonKingRefreshMaxNum = demonKingRefreshMaxNum;
	}

	public int getDemonExistenceTime() {
		return demonExistenceTime;
	}

	public void setDemonExistenceTime(int demonExistenceTime) {
		this.demonExistenceTime = demonExistenceTime;
	}

	public int getDemonKingExistenceTime() {
		return demonKingExistenceTime;
	}

	public void setDemonKingExistenceTime(int demonKingExistenceTime) {
		this.demonKingExistenceTime = demonKingExistenceTime;
	}

	public int getDemonMinMemberNum() {
		return demonMinMemberNum;
	}

	public void setDemonMinMemberNum(int demonMinMemberNum) {
		this.demonMinMemberNum = demonMinMemberNum;
	}

	public int getDemonKingMinMemberNum() {
		return demonKingMinMemberNum;
	}

	public void setDemonKingMinMemberNum(int demonKingMinMemberNum) {
		this.demonKingMinMemberNum = demonKingMinMemberNum;
	}

	public double getDemonKingProb() {
		return demonKingProb;
	}

	public void setDemonKingProb(double demonKingProb) {
		this.demonKingProb = demonKingProb;
	}

	public int getDemonNoticeId() {
		return demonNoticeId;
	}

	public void setDemonNoticeId(int demonNoticeId) {
		this.demonNoticeId = demonNoticeId;
	}

	public int getDevilNoticeId() {
		return devilNoticeId;
	}

	public void setDevilNoticeId(int devilNoticeId) {
		this.devilNoticeId = devilNoticeId;
	}

	public int getCorpsBossShowRankOnTimeSwtich() {
		return corpsBossShowRankOnTimeSwtich;
	}

	public void setCorpsBossShowRankOnTimeSwtich(int corpsBossShowRankOnTimeSwtich) {
		this.corpsBossShowRankOnTimeSwtich = corpsBossShowRankOnTimeSwtich;
	}

	public int getDevilExistenceTime() {
		return devilExistenceTime;
	}

	public void setDevilExistenceTime(int devilExistenceTime) {
		this.devilExistenceTime = devilExistenceTime;
	}

	public int getDevilRefreshMaxNum() {
		return devilRefreshMaxNum;
	}

	public void setDevilRefreshMaxNum(int devilRefreshMaxNum) {
		this.devilRefreshMaxNum = devilRefreshMaxNum;
	}

	public int getDevilMinMemberNum() {
		return devilMinMemberNum;
	}

	public void setDevilMinMemberNum(int devilMinMemberNum) {
		this.devilMinMemberNum = devilMinMemberNum;
	}

	public int getEnergyMax() {
		return energyMax;
	}

	public void setEnergyMax(int energyMax) {
		this.energyMax = energyMax;
	}

	public int getPetLeaderSkillMaxPos() {
		return petLeaderSkillMaxPos;
	}

	public void setPetLeaderSkillMaxPos(int petLeaderSkillMaxPos) {
		this.petLeaderSkillMaxPos = petLeaderSkillMaxPos;
	}

	public int getTimeLimitMinLevel() {
		return timeLimitMinLevel;
	}

	public void setTimeLimitMinLevel(int timeLimitMinLevel) {
		this.timeLimitMinLevel = timeLimitMinLevel;
	}

	public double getTimeLimitPushPlayerProb() {
		return timeLimitPushPlayerProb;
	}

	public void setTimeLimitPushPlayerProb(double timeLimitPushPlayerProb) {
		this.timeLimitPushPlayerProb = timeLimitPushPlayerProb;
	}

	public int getTimeLimitPushTaskNum() {
		return timeLimitPushTaskNum;
	}

	public void setTimeLimitPushTaskNum(int timeLimitPushTaskNum) {
		this.timeLimitPushTaskNum = timeLimitPushTaskNum;
	}
	
	public long getTimeLimitExistenceTime() {
		return timeLimitExistenceTime;
	}

	public void setTimeLimitExistenceTime(long timeLimitExistenceTime) {
		this.timeLimitExistenceTime = timeLimitExistenceTime;
	}

	public int getTimeLimitPushPlayerMaxNum() {
		return timeLimitPushPlayerMaxNum;
	}

	public void setTimeLimitPushPlayerMaxNum(int timeLimitPushPlayerMaxNum) {
		this.timeLimitPushPlayerMaxNum = timeLimitPushPlayerMaxNum;
	}

	public int getQuestionNumOfTimeLimitExamination() {
		return questionNumOfTimeLimitExamination;
	}

	public void setQuestionNumOfTimeLimitExamination(int questionNumOfTimeLimitExamination) {
		this.questionNumOfTimeLimitExamination = questionNumOfTimeLimitExamination;
	}

	public int getCwLiBaoItemId() {
		return cwLiBaoItemId;
	}

	public void setCwLiBaoItemId(int cwLiBaoItemId) {
		this.cwLiBaoItemId = cwLiBaoItemId;
	}

	public int getTimeLimitExamNoticeId() {
		return timeLimitExamNoticeId;
	}

	public void setTimeLimitExamNoticeId(int timeLimitExamNoticeId) {
		this.timeLimitExamNoticeId = timeLimitExamNoticeId;
	}

	public int getTimeLimitMonsterNoticeId() {
		return timeLimitMonsterNoticeId;
	}

	public void setTimeLimitMonsterNoticeId(int timeLimitMonsterNoticeId) {
		this.timeLimitMonsterNoticeId = timeLimitMonsterNoticeId;
	}

	public int getTimeLimitNpcNoticeId() {
		return timeLimitNpcNoticeId;
	}

	public void setTimeLimitNpcNoticeId(int timeLimitNpcNoticeId) {
		this.timeLimitNpcNoticeId = timeLimitNpcNoticeId;
	}

	public int getCultivateCostCurrencyTypeId() {
		return cultivateCostCurrencyTypeId;
	}

	public void setCultivateCostCurrencyTypeId(int cultivateCostCurrencyTypeId) {
		this.cultivateCostCurrencyTypeId = cultivateCostCurrencyTypeId;
	}

	public int getCultivateCostCurrencyNum() {
		return cultivateCostCurrencyNum;
	}

	public void setCultivateCostCurrencyNum(int cultivateCostCurrencyNum) {
		this.cultivateCostCurrencyNum = cultivateCostCurrencyNum;
	}

	public int getCultivateAddExpNum() {
		return cultivateAddExpNum;
	}

	public void setCultivateAddExpNum(int cultivateAddExpNum) {
		this.cultivateAddExpNum = cultivateAddExpNum;
	}

	public int getCultivateUpgradeMinLevel() {
		return cultivateUpgradeMinLevel;
	}

	public void setCultivateUpgradeMinLevel(int cultivateUpgradeMinLevel) {
		this.cultivateUpgradeMinLevel = cultivateUpgradeMinLevel;
	}

	public int getCultivateUpgradeMinJoinTime() {
		return cultivateUpgradeMinJoinTime;
	}

	public void setCultivateUpgradeMinJoinTime(int cultivateUpgradeMinJoinTime) {
		this.cultivateUpgradeMinJoinTime = cultivateUpgradeMinJoinTime;
	}

	public int getAssistCostCurrencyTypeId() {
		return assistCostCurrencyTypeId;
	}

	public void setAssistCostCurrencyTypeId(int assistCostCurrencyTypeId) {
		this.assistCostCurrencyTypeId = assistCostCurrencyTypeId;
	}

	public int getMapMeetMonsterLevelLimit() {
		return mapMeetMonsterLevelLimit;
	}

	public void setMapMeetMonsterLevelLimit(int mapMeetMonsterLevelLimit) {
		this.mapMeetMonsterLevelLimit = mapMeetMonsterLevelLimit;
	}

	public int getCultivateBatchNum() {
		return cultivateBatchNum;
	}

	public void setCultivateBatchNum(int cultivateBatchNum) {
		this.cultivateBatchNum = cultivateBatchNum;
	}

	public int getAssistUpgradeMinLevel() {
		return assistUpgradeMinLevel;
	}

	public void setAssistUpgradeMinLevel(int assistUpgradeMinLevel) {
		this.assistUpgradeMinLevel = assistUpgradeMinLevel;
	}

	public int getAssistUpgradeMaxLevel() {
		return assistUpgradeMaxLevel;
	}

	public void setAssistUpgradeMaxLevel(int assistUpgradeMaxLevel) {
		this.assistUpgradeMaxLevel = assistUpgradeMaxLevel;
	}

	public int getAssitCritCoef1() {
		return assitCritCoef1;
	}

	public void setAssitCritCoef1(int assitCritCoef1) {
		this.assitCritCoef1 = assitCritCoef1;
	}

	public int getAssitCritCoef2() {
		return assitCritCoef2;
	}

	public void setAssitCritCoef2(int assitCritCoef2) {
		this.assitCritCoef2 = assitCritCoef2;
	}
	
	public int getChargeRmbToBondCoef() {
		return chargeRmbToBondCoef;
	}

	public void setChargeRmbToBondCoef(int chargeRmbToBondCoef) {
		this.chargeRmbToBondCoef = chargeRmbToBondCoef;
	}

	public int getAssistMakeItemMinLevel() {
		return assistMakeItemMinLevel;
	}

	public void setAssistMakeItemMinLevel(int assistMakeItemMinLevel) {
		this.assistMakeItemMinLevel = assistMakeItemMinLevel;
	}
	
	public int getCorpsRedEnvelopeMaxNum() {
		return corpsRedEnvelopeMaxNum;
	}

	public void setCorpsRedEnvelopeMaxNum(int corpsRedEnvelopeMaxNum) {
		this.corpsRedEnvelopeMaxNum = corpsRedEnvelopeMaxNum;
	}

	public int getRedEnvelopeMaxNum() {
		return redEnvelopeMaxNum;
	}

	public void setRedEnvelopeMaxNum(int redEnvelopeMaxNum) {
		this.redEnvelopeMaxNum = redEnvelopeMaxNum;
	}

	public double getOpenRedEnvelopeMinProb() {
		return openRedEnvelopeMinProb;
	}

	public void setOpenRedEnvelopeMinProb(double openRedEnvelopeMinProb) {
		this.openRedEnvelopeMinProb = openRedEnvelopeMinProb;
	}

	public double getOpenRedEnvelopeMaxProb() {
		return openRedEnvelopeMaxProb;
	}

	public void setOpenRedEnvelopeMaxProb(double openRedEnvelopeMaxProb) {
		this.openRedEnvelopeMaxProb = openRedEnvelopeMaxProb;
	}

	public double getChargeCountToRedEnvelopeRate() {
		return chargeCountToRedEnvelopeRate;
	}

	public void setChargeCountToRedEnvelopeRate(double chargeCountToRedEnvelopeRate) {
		this.chargeCountToRedEnvelopeRate = chargeCountToRedEnvelopeRate;
	}
	
	public long getRedEnvelopeMin() {
		return redEnvelopeMin;
	}

	public void setRedEnvelopeMin(long redEnvelopeMin) {
		this.redEnvelopeMin = redEnvelopeMin;
	}

	public long getRedEnvelopeMax() {
		return redEnvelopeMax;
	}

	public void setRedEnvelopeMax(long redEnvelopeMax) {
		this.redEnvelopeMax = redEnvelopeMax;
	}

	public int getGotBonusRepeatlyFlag() {
		return gotBonusRepeatlyFlag;
	}

	public void setGotBonusRepeatlyFlag(int gotBonusRepeatlyFlag) {
		this.gotBonusRepeatlyFlag = gotBonusRepeatlyFlag;
	}

	public int getRedEnvelopeMaxExistTime() {
		return redEnvelopeMaxExistTime;
	}

	public void setRedEnvelopeMaxExistTime(int redEnvelopeMaxExistTime) {
		this.redEnvelopeMaxExistTime = redEnvelopeMaxExistTime;
	}

	public int getAllocateCorpsWarActivityNum() {
		return allocateCorpsWarActivityNum;
	}

	public void setAllocateCorpsWarActivityNum(int allocateCorpsWarActivityNum) {
		this.allocateCorpsWarActivityNum = allocateCorpsWarActivityNum;
	}

	public int getAllocateCorpsWarJinRewardId() {
		return allocateCorpsWarJinRewardId;
	}

	public void setAllocateCorpsWarJinRewardId(int allocateCorpsWarJinRewardId) {
		this.allocateCorpsWarJinRewardId = allocateCorpsWarJinRewardId;
	}

	public int getAllocateCorpsWarYinRewardId() {
		return allocateCorpsWarYinRewardId;
	}

	public void setAllocateCorpsWarYinRewardId(int allocateCorpsWarYinRewardId) {
		this.allocateCorpsWarYinRewardId = allocateCorpsWarYinRewardId;
	}

	public int getAllocateCorpsWarTongRewardId() {
		return allocateCorpsWarTongRewardId;
	}

	public void setAllocateCorpsWarTongRewardId(int allocateCorpsWarTongRewardId) {
		this.allocateCorpsWarTongRewardId = allocateCorpsWarTongRewardId;
	}

	public int getAllocateCorpsWarJinItemId() {
		return allocateCorpsWarJinItemId;
	}

	public void setAllocateCorpsWarJinItemId(int allocateCorpsWarJinItemId) {
		this.allocateCorpsWarJinItemId = allocateCorpsWarJinItemId;
	}

	public int getAllocateCorpsWarYinItemId() {
		return allocateCorpsWarYinItemId;
	}

	public void setAllocateCorpsWarYinItemId(int allocateCorpsWarYinItemId) {
		this.allocateCorpsWarYinItemId = allocateCorpsWarYinItemId;
	}

	public int getAllocateCorpsWarTongItemId() {
		return allocateCorpsWarTongItemId;
	}

	public void setAllocateCorpsWarTongItemId(int allocateCorpsWarTongItemId) {
		this.allocateCorpsWarTongItemId = allocateCorpsWarTongItemId;
	}

	public int getChapterByPlotDungeon() {
		return chapterByPlotDungeon;
	}

	public void setChapterByPlotDungeon(int chapterByPlotDungeon) {
		this.chapterByPlotDungeon = chapterByPlotDungeon;
	}

	public int getExpMultiplyNum() {
		return expMultiplyNum;
	}

	public void setExpMultiplyNum(int expMultiplyNum) {
		this.expMultiplyNum = expMultiplyNum;
	}

	public int getGuidePetTalentQuestId() {
		return guidePetTalentQuestId;
	}

	public void setGuidePetTalentQuestId(int guidePetTalentQuestId) {
		this.guidePetTalentQuestId = guidePetTalentQuestId;
	}

	public int getGuideCraftQuestId() {
		return guideCraftQuestId;
	}

	public void setGuideCraftQuestId(int guideCraftQuestId) {
		this.guideCraftQuestId = guideCraftQuestId;
	}

	public int getBattleReportSpeedX() {
		return battleReportSpeedX;
	}

	public void setBattleReportSpeedX(int battleReportSpeedX) {
		this.battleReportSpeedX = battleReportSpeedX;
	}

	public int getPubTaskRefreshManulBond() {
		return pubTaskRefreshManulBond;
	}

	public void setPubTaskRefreshManulBond(int pubTaskRefreshManulBond) {
		this.pubTaskRefreshManulBond = pubTaskRefreshManulBond;
	}

	public int getPubTaskRefreshManulBondTypeId() {
		return pubTaskRefreshManulBondTypeId;
	}

	public void setPubTaskRefreshManulBondTypeId(int pubTaskRefreshManulBondTypeId) {
		this.pubTaskRefreshManulBondTypeId = pubTaskRefreshManulBondTypeId;
	}

	public int getTimeLimitOpenNoticeId() {
		return timeLimitOpenNoticeId;
	}

	public void setTimeLimitOpenNoticeId(int timeLimitOpenNoticeId) {
		this.timeLimitOpenNoticeId = timeLimitOpenNoticeId;
	}

	public String getChargeChannelCode() {
		return chargeChannelCode;
	}

	public void setChargeChannelCode(String chargeChannelCode) {
		this.chargeChannelCode = chargeChannelCode;
	}

	public int getBattleDefenceHurtScale() {
		return battleDefenceHurtScale;
	}

	public void setBattleDefenceHurtScale(int battleDefenceHurtScale) {
		this.battleDefenceHurtScale = battleDefenceHurtScale;
	}

	public int getBattleCostOwnerMin() {
		return battleCostOwnerMin;
	}

	public void setBattleCostOwnerMin(int battleCostOwnerMin) {
		this.battleCostOwnerMin = battleCostOwnerMin;
	}

	public int getBuffOverlapInitValue() {
		return buffOverlapInitValue;
	}

	public void setBuffOverlapInitValue(int buffOverlapInitValue) {
		this.buffOverlapInitValue = buffOverlapInitValue;
	}
	
	public int getSiegeDemonNormalFinalRewardId() {
		return siegeDemonNormalFinalRewardId;
	}

	public void setSiegeDemonNormalFinalRewardId(int siegeDemonNormalFinalRewardId) {
		this.siegeDemonNormalFinalRewardId = siegeDemonNormalFinalRewardId;
	}

	public int getSiegeDemonHardFinalRewardId() {
		return siegeDemonHardFinalRewardId;
	}

	public void setSiegeDemonHardFinalRewardId(int siegeDemonHardFinalRewardId) {
		this.siegeDemonHardFinalRewardId = siegeDemonHardFinalRewardId;
	}

	public int getSiegeDemonNormalMinMemNum() {
		return siegeDemonNormalMinMemNum;
	}

	public void setSiegeDemonNormalMinMemNum(int siegeDemonNormalMinMemNum) {
		this.siegeDemonNormalMinMemNum = siegeDemonNormalMinMemNum;
	}

	public int getSiegeDemonHardMinMemNum() {
		return siegeDemonHardMinMemNum;
	}

	public void setSiegeDemonHardMinMemNum(int siegeDemonHardMinMemNum) {
		this.siegeDemonHardMinMemNum = siegeDemonHardMinMemNum;
	}

	public int getSiegeDemonNormalMinLevel() {
		return siegeDemonNormalMinLevel;
	}

	public void setSiegeDemonNormalMinLevel(int siegeDemonNormalMinLevel) {
		this.siegeDemonNormalMinLevel = siegeDemonNormalMinLevel;
	}

	public int getSiegeDemonHardMinLevel() {
		return siegeDemonHardMinLevel;
	}

	public void setSiegeDemonHardMinLevel(int siegeDemonHardMinLevel) {
		this.siegeDemonHardMinLevel = siegeDemonHardMinLevel;
	}

	public int getSiegeDemonNormalAssistRewardId() {
		return siegeDemonNormalAssistRewardId;
	}

	public void setSiegeDemonNormalAssistRewardId(int siegeDemonNormalAssistRewardId) {
		this.siegeDemonNormalAssistRewardId = siegeDemonNormalAssistRewardId;
	}

	public int getSiegeDemonHardAssistRewardId() {
		return siegeDemonHardAssistRewardId;
	}

	public void setSiegeDemonHardAssistRewardId(int siegeDemonHardAssistRewardId) {
		this.siegeDemonHardAssistRewardId = siegeDemonHardAssistRewardId;
	}
	
	public int getItemMaxOverlapNum() {
		return itemMaxOverlapNum;
	}

	public void setItemMaxOverlapNum(int itemMaxOverlapNum) {
		this.itemMaxOverlapNum = itemMaxOverlapNum;
	}

}
