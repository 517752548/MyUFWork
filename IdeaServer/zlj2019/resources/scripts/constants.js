/**绿野仙踪奖励系数*/
config.wizardRaidRewardCoef1 = 54000;
	//绿野仙踪奖励系数2
config.wizardRaidRewardCoef2 = 1500;
	//绿野仙踪奖励系数-等级段
config.wizardRaidRewardLevel = 10;


/**酒馆最大等级*/
config.pubMaxLevel = 5;
//酒馆任务手动刷新的道具Id
config.pubTaskRefreshManulItemId=10131;
//酒馆任务手动刷新的银票数量
config.pubTaskRefreshManulGold = 10000;
//酒馆任务手动刷新的金子数量
config.pubTaskRefreshManulBond = 10; 
//酒馆任务手动刷新的金子货币类型ID
config.pubTaskRefreshManulBondTypeId = 1;

/** 松木令物品ID*/
config.songmulingItemId = 20307;
/** 玉木令物品ID*/
config.yumulingItemId = 20308;

/** 玩家或武将的等级上限 */
config.levelMax = 100;
/** 宠物变异概率 */
config.petGeneProb = 1;
/** 宠物洗天赋技能需要的道具Id */
config.petTalentSkillResetItemId = 10034;
/** 神兽洗天赋技能需要的道具Id */
config.bestPetTalentSkillResetItemId = 10158;
/** 宠物洗天赋技能需要的道具数量 */
config.petTalentSkillResetItemNum = 1;


/*** 重置属性点消耗道具Id     */
    config.petResetPointItemId = 10067;
/*** 重置属性点消耗道具数量  */
    config.petResetPointItemNum = 1;


/**宠物爆资质成长值下限*/
	config.petGrowthColor=5;
/**宠物爆资质上限系数 */
	config.petOverColor=0.1;
	/**普通宠物资质条数最大数量*/
	config.petColorNormalMaxCount=1;
	/**神兽资质条数最大数量*/
	config.petColorBestMaxCount=2;
	/**普通宠物爆资质出现概率1条*/
	config.petColorNormalRate1=0.01;
	/**神兽爆资质出现概率1条*/
	config.petColorBestRate1=0.05;
	/**神兽爆资质出现概率2条*/
	config.petColorBestRate2=0.02;



/** 防御状态受到伤害值 */
config.battleDefenceHurt = 1;
/** 暴击伤害倍数 */
config.battleCritHurtCoef = 2.0;
/** 暴击系数0 */
config.battleCritCoef0 = 0.02;

/** 战斗等级差系数 */
config.battleLevelCoef = 0.02;

/** 逃跑基础成功概率 */
config.battleEscapeProbBase = 0.5;
/** 逃跑每次累加概率 */
config.battleEscapeProbAdd = 0.1;

/** 战斗实力系数1 */
config.battleZDSL1 = 4.0;
/** 战斗实力系数2 */
config.battleZDSL2 = 2.0;
/** 防御状态受到伤害值百分比,扩大1000倍*/
config.battleDefenceHurtScale = 500;

/** 一级属性系数 */
config.battleAProp1 = 3.0;

//物理防御系数	10.8
config.battlePhyDef = 10.8;
//物理命中系数	4.285714
config.battlePhyHit = 4.285714;
//物理闪避系数	12.85714
config.battlePhyDod = 12.85714;
//物理暴击系数	9
config.battlePhyCri = 9;
//物理抗暴系数	13.5
config.battlePhyAntCri = 13.5;
//法术防御系数	10.8
config.battleMagDef = 10.8;
//法术命中系数	4.285714
config.battleMagHit = 4.285714;
//法术闪避系数	12.85714
config.battleMagDod = 12.85714;
//法术暴击系数	9
config.battleMagCri = 9;
//法术抗暴系数	13.5
config.battleMagAntCri = 13.5;

//免伤	0.5
config.battleMS = 0.5;
//闪避	0.7
config.battleDodgy = 0.7;
//抗暴	0.8
config.battleAntiCrit = 0.8;


/**
 * 绿野仙踪
 */
config.wizardRaidFreeTimes = 2;
config.wizardRaidEnterItemId = 10066;
config.wizardRaidEnterItemNum = 1;

/** 变南瓜的时间，毫秒 */
config.wizardRaidPumpkinTime = 180000;

/** boos怪物刷出来，需要杀死多少只其他怪物 */
config.wizardRaidBossCond = 10;

/** 最少n人才能进入副本 */
config.wizardRaidMinMemNum = 2;

/** 在副本内最长时间，毫秒 */
config.wizardRaidMaxTime = 900000;


/**
     * 帮派竞赛
     */
    /**
     * 帮派竞赛队员最低等级要求
     */
    config.corpsWarMemberMinLevel = 10;
    /**
     * 帮派竞赛队员最少数量
     */
    config.corpsWarMinMemberNum = 1;
    /**
     * 帮派竞赛军团最低等级
     */
    config.corpsWarMinCorpsLevel = 1;
    /**
     * 帮派竞赛队员加入军团最少时间，毫秒
     */
    config.corpsWarMinJoinTime = 600000;
    /**
     * 帮派竞赛队员初始积分
     */
    config.corpsWarInitScore = 100;
    /**
     * 帮派竞赛战斗一局每人分数
     */
    config.corpsWarFightScore = 10;
    /**
     * 帮派竞赛至少参加n场战斗才算有效玩家
     */
    config.corpsWarFightMinNum = 1;

 /**
	 * 结婚系统
	 */
	/** 结婚等级*/
	config.marryGrade = 20;
	/** 结婚费用*/
	config.marryCost = 13140;
	/** 强制离婚费用*/
	config.forceFireMarry = 3000000;
	/** 结婚奖励*/
	config.marryRewardId = 1422;

    /**
     * 师徒相关
     **/
    config.overman_min_overman_level = 50; //师傅的级别必须大于65
    config.overman_max_lowerman_count = 3; // 最大的徒弟数量
    config.overman_min_lowerman_level = 10;
    config.overman_max_lowerman_level = 40;
    config.overman_over_lowerman = 50; //徒弟出师的等级
    config.overman_current_force_fire_currency_number = 5000;
    config.overman_overman_reward = 2006; //拜师的时候给师傅送到礼包
    config.overman_lowerman_reward = 2007; //拜师的时候给徒弟的礼包.
    config.overman_finish_lowerman_reward = 2008; //出师的时候给徒弟发送的礼包


/**
	 * nvn联赛 
	 */
	//最低人数要求
	config.nvnTeamMemberNumMin = 2;
	//初始积分
	config.nvnInitScore = 1000;
	//胜利基准积分
	config.nvnWinScoreBase = 15;
	//失败基准积分
	config.nvnLossScoreBase = 10;
	//轮空积分
	config.nvnNoMatchScore = 15;
	//nvn战斗结束时计算积分公式用到的
	config.nvnBattleScoreCoef1 = 100.0;
	config.nvnBattleScoreMin1 = 0.5;
	config.nvnBattleScoreMax1 = 1.5;
	config.nvnBattleScoreCoef2 = 100.0;
	config.nvnBattleScoreMin2 = 0.5;
	config.nvnBattleScoreMax2 = 1.5;

/**
     * 上架装备最小等级*/
    config.tradeEquipLowestLevel = 20;
    /**
     * 上架装备最低品级*/
    config.tradeEquipLowestColor = 3;
    /**
	 * 帮派 
	 */
    //帮贡转换帮派经验比例
    config.contriConvertExpRate = 20;
    //最大帮派维护费用通知次数
    config.maxDelinquentNum = 3;
    //帮主福利放大系数
    config.presidentCoef = 2.0;
    //副帮主福利放大系数
    config.viceChairmanCoef= 1.5;
    //精英福利放大系数
    config.eliteCoef = 1.2;
    //玩家申请军团上限
    config.maxPlayerApplytNum = 10;
    //军团接受玩家申请上限
    config.maxCorpsReceiveApplyNum = 20;
    //每页军团数量
    config.numPerPage = 8;
    
    //骑宠
    /**
     * 骑宠出战最低忠诚度
     */
    config.PetHorseFightLoyMin = 10;
    /**
     * 骑宠初始忠诚度
     */
    config.PetHorseInitLoy = 100;
    /**
     * 骑宠初始亲密度
     */
    config.PetHorseInitClo = 100;
    
    /**
     * 骑宠加成系数
     */
    config.petHorseAddCoef = 0.25;


	/**
     * 护送粮草任务手动刷新的道具Id
     */
    config.forageTaskRefreshManulItemId = 10068;
	/**
     * 护送粮草手动刷新道具数量
     */
    config.forageTaskRefreshManulItemNum = 1;
    //双倍经验点相关
    config.sysGiveDoublePointNum = 200; // 每天凌晨给的双倍点
    config.sysGiveDoublePointMax = 2000; // 最大双倍点数
    config.useGiveDoublePointNum = 100; // 使用双倍丹道具给的双倍点
    config.expMultiplyNum = 5; // 挂机经验几倍的配置,2-代表是2倍

	//帮派boss相关
    config.corpsBossMaxRewardNum = 1;//帮派成员本周获得击杀帮派boss奖励次数
    config.showBossRankSize = 10; //帮派boss排行榜显示条数
    config.bossRankRewardSize = 10; //帮派boss发奖人数
    config.showBossCountRankSize = 10; //帮派boss挑战次数排行榜显示条数
    config.bossCountRankRewardSize = 10; // 帮派boss挑战次数发奖人数
    config.corpsBossMinCorpsLevel = 1; //帮派boss帮派最低等级
    config.corpsBossMemberMinLevel = 40; //帮派boss队员最低等级要求
    config.corpsBossMinMemberNum = 3; //帮派boss队员最少数量
    config.chapterByCorpsBoss = 5; //帮派boss每一章的层数
    config.corpsBossMinJoinTime =7 * 24 * 60 * 60 * 1000; //加入帮派的最小时间毫秒
    config.corpsBossRefreshDayOfWeek = 7; //帮派boss刷新排行榜星期,7代表星期日
    config.corpsBossRefreshDayOfHour = 23; //帮派boss刷新排行榜锁定开始小时数,23代表从23点开始后的一个小时内不允许打
    config.corpsBossRankRewardTimeId = 1048; //帮派boss刷新排行榜时间Id
    config.corpsBossShowRankOnTimeSwtich = 0; //1-立即显示排行榜,0-否

    /** 封妖相关 */
    config.demonRefreshMaxNum = 10;//一张地图内,小妖最大刷新数量
    config.demonKingRefreshMaxNum = 3;//一张地图内,魔王最大刷新数量
    config.demonExistenceTime = 30 * 60 * 1000;//小妖存在时间,30分钟,毫秒
    config.demonKingExistenceTime = 30 * 60 * 1000;//魔王存在时间,30分钟,毫秒
    config.demonMinMemberNum = 1;//小妖挑战人数,单人或组队均可
    config.demonKingMinMemberNum = 3;//魔王挑战人数,至少3人组队
    config.demonKingProb = 0.5; //藏宝图开除魔王的概率
    config.demonNoticeId = 23;//广播
    
    /** 混世魔王相关*/
    config.devilNoticeId = 24;//广播
    config.devilRefreshMaxNum = 3;//一张地图内,魔王最大刷新数量
    config.devilExistenceTime = 30 * 60 * 1000;//混世魔王存在时间,30分钟,毫秒
    config.devilMinMemberNum = 3;//混世魔王挑战人数,至少3人组队

    /** 玩家活力值最大值*/
    config.energyMax = 1000;

    /** 限时活动相关*/
    config.timeLimitMinLevel = 20; //限时活动玩家最低等级
    config.timeLimitPushPlayerProb = 1; //限时活动推送在线玩家比例
    config.timeLimitPushPlayerMaxNum = 1000; //限时活动推送在线玩家最大人数
    config.timeLimitPushTaskNum = 1; //限时活动推送任务数量
    config.timeLimitExistenceTime = 50 * 60 * 1000; // 限时活动限时,5分钟,毫秒
    config.questionNumOfTimeLimitExamination = 10; //限时答题题目数
    config.cwLiBaoItemId = 20033; //限时答题,答对10题获得奖励物品Id
    config.timeLimitExamNoticeId = 25;//限时答题广播
    config.timeLimitMonsterNoticeId = 26;//限时杀怪广播
    config.timeLimitNpcNoticeId = 27;//限时挑战Npc广播

	/** 玩家在地图遇怪的最小等级要求 */
    config.mapMeetMonsterLevelLimit = 10;

    /** 帮派修炼相关*/
   config.cultivateCostCurrencyTypeId = 2; //银票
   config.cultivateCostCurrencyNum = 20000; //修炼1次消耗银票
   config.cultivateAddExpNum = 10; //修炼1次获得经验
   config.cultivateUpgradeMinLevel = 6;//修炼等级达到6,需要加入帮派才能开启后续的修炼等级
   config.cultivateUpgradeMinJoinTime = 24 * 60 * 60 * 1000; //入当前帮派24小时以上,才可以修炼,毫秒
   config.cultivateBatchNum = 10; //修炼批量的次数
    
    
    
    
    /** 帮派辅助技能相关*/
   config.assistCostCurrencyTypeId = 2; //银票
   config.assistUpgradeMinLevel = 0; //辅助等级最小等级
   config.assistUpgradeMaxLevel = 100; // 辅助等级最大等级
   config.assitCritCoef1 = 60;
   config.assitCritCoef2 = 600;
   config.assistMakeItemMinLevel = 10;// 制作技能等级最小等级

       /** 红包相关*/
    config.corpsRedEnvelopeMaxNum = 100; //帮派内红包最大数量
    config.redEnvelopeMaxNum = 10; //帮派发红包可打开的最大数量
    config.openRedEnvelopeMinProb = 0.2; //拆帮派红包站红包总额的最小百分比
    config.openRedEnvelopeMaxProb = 0.4; // 拆帮派红包站红包总额的最大百分比
    config.chargeCountToRedEnvelopeRate = 0.2; //玩家每次充值后，系统额外发放充值金额 * 该比例
    config.redEnvelopeMin = 1000; //红包最小值
    config.redEnvelopeMax = 9999999; //红包最大值
    config.gotBonusRepeatlyFlag = 0; //自己可以领取红包多次的开关,1-打开,0-关闭
    config.redEnvelopeMaxExistTime = 7 * 24 * 60 * 60 * 1000; //一周

    /** 分配物品相关*/
   config.allocateCorpsWarActivityNum = 1;// 分配帮派竞赛活动仓库中的数量
   config.allocateCorpsWarJinItemId = 20166;
   config.allocateCorpsWarYinItemId = 20167;
   config.allocateCorpsWarTongItemId = 20168;
   config.allocateCorpsWarJinRewardId = 2106;// 分配帮派竞赛活动金宝箱奖励Id
   config.allocateCorpsWarYinRewardId = 2107;// 分配帮派竞赛活动银宝箱奖励Id
   config.allocateCorpsWarTongRewardId = 2108;// 分配帮派竞赛活动铜宝箱奖励Id

   /**
	 * 新手引导常量
	 */
	//穿戴装备任务Id
	config.guideUseEquipQuestId = 10002;
	//宠物出战任务Id
	config.guidePetFightQuestId = 10003;
	//等级奖励的等级
	config.guideLevelRewardLevel = 10;
	config.guideLevelRewardLevel = 10;
	//添加好友的等级
	config.addFriendLevel = 5;
	//任务引导到第几个任务
	config.guideQuestId = 10004;
	//宠物洗天赋技能任务Id
	config.guidePetTalentQuestId = 10070;

	//技能熟练度升级 任务Id
	config.guideSubSkillProQuestId = 10010;
	//心法升级 任务Id
	config.guideMindLevelupQuestId = 10011;
	//技能升级 任务Id
	config.guideSkillLevelupQuestId = 1022;

	//战斗加速功能要求的等级
	config.battleReportSpeed2XLevel = 60;
	//战斗加速的速度
	config.battleReportSpeedX = 3;

	/** 围剿魔族副本相关*/
    config.siegeDemonNormalMinMemNum = 1;
    config.siegeDemonHardMinMemNum = 1;
    config.siegeDemonNormalMinLevel = 40;
    config.siegeDemonHardMinLevel = 40;
    config.siegeDemonNormalAssistRewardId = 2773;//普通助战奖励
    config.siegeDemonHardAssistRewardId = 2774;//困难助战奖励
    config.siegeDemonNormalFinalRewardId = 20312;//普通通关奖励
    config.siegeDemonHardFinalRewardId = 20313;//困难通关奖励

    /**
	 * 心法技能
	 */
	//提升技能等级满足默认层数
	config.subSkillMinUpgradeLayer = 8;
	//技能等级最大层数
	config.subSkillMaxLayer = 10;
	//技能升级所需技能书数量
	config.subSkillUpgradeBookNum = 1;
	//技能等级最大等级
	config.subSkillMaxLevel= 10;
	
	//技能快捷栏最小最小索引值
	config.subSKillMinShortcutIndex = 0;
	//技能快捷栏最大数量
	config.subSkillMaxShortcutNum = 6;
	//提升技能熟练度道具Id
	config.addProficiencyItemId = 20189;
	//使用技能熟练度道具数量
	config.useAddProficiencyItemNum = 1;
	//增加技能熟练度数量
	config.addProficiencyNum = 50;

	/**
     * 宠物默认技能栏数量
     */
    config.petDefaultSkillBarNum = 5;
    config.petMaxSkillBarNum = 10;// 宠物技能栏最大数量
    config.skillBarNumItemId = 20256;//扩充宠物技能栏道具Id
    config.addSkillBarNum = 1; //扩充宠物技能栏数量
    config.petTalentSkillResetLifeNum = 10;//宠物洗天赋技能需要的寿命数量
    config.petTalentSkillNumMaxOnReset = 1; //成功无洗天赋技能时,天赋技能数量上限
    config.petUpPerceptLevelAddTalentSkillRate = 20;//宠物悟性等级提升可增加成功率,扩大100倍
    config.petPropItemCoef1 = 2.0;//资质丹加成系数1
    config.petPropItemCoef2 = 3.0;//资质丹加成系数2
    config.petAffinationMod = 10000; //宠物还童次数最大值
    /**
     * 骑宠洗天赋技能需要的道具数量
     */
    config.petHorseTalentSkillResetItemNum = 5;
    config.petHorseTalentSkillResetLifeNum = 10;//骑宠洗天赋技能需要的寿命数量
    config.petHorseTalentSkillNumMaxOnReset = 1; //成功无洗天赋技能时,天赋技能数量上限
    config.petHorseUpPerceptLevelAddTalentSkillRate = 100;//骑宠悟性等级提升可增加成功率,扩大100倍
    config.petHorsePropItemCoef1 = 2.0; //资质丹加成系数1
    config.petHorsePropItemCoef2 = 3.0; //资质丹加成系数2
    config.petHorseAffinationMod = 10000; //宠物还童次数最大值


	/**
     * 骑宠
     */
    config.petHorseTalentSkillResetItemId = 10159; //骑宠洗天赋技能需要的道具Id
    config.bestPetHorseTalentSkillResetItemId = 10160; //神兽骑宠洗天赋技能需要的道具Id
    
	/**
	 * 仙葫
	 */
	//祝福仙葫开启消耗银子系数
	config.xianhuZhufuCostCoef = 10;
	//祝福仙葫奖励Id
	config.xianhuZhufuRewardId = 2700;
	//祝福祈福仙葫显示奖励Id
	config.xianhuShowRewardId = 27001;
	
	//祈福仙葫开启消耗金子数
	config.xianhuQifuCostBond = 1;
	//祈福仙葫奖励Id
	config.xianhuQifuRewardId = 2701;
	//祈福仙葫每日最大次数
	config.xianhuQifuMaxNum = 9999;
	//祈福仙葫每10次额外奖励次数定义
	config.xianhuQifuExtra1Num = 10;
	//祈福仙葫每50次额外奖励次数定义
	config.xianhuQifuExtra2Num = 50;
	//富贵仙葫奖励id
	config.xianhuFuguiRewardId = 2702;
	//至尊仙葫奖励id
	config.xianhuZhizunRewardId = 2703;
	//富贵仙葫显示奖励id
	config.xianhuFuguiShowRewardId = 27021;
	//至尊仙葫显示奖励id
	config.xianhuZhizunShowRewardId = 27031;

	/**
	 * 挂机
	 */
	 //挂机点计算公式折扣
	config.guaJiProb = 1.0;
	//免费挂机点上限
	config.guaJiPointMaxNum= 1000;

	/**
	 * 生活技能
	 */
	//技能等级最大层数
	config.lifeSkillMaxLayer = 8;
	//技能升级所需技能书数量
	config.lifeSkillUpgradeBookNum = 1;
	//技能等级最大等级
	config.lifeSkillMaxLevel= 6;
	//生活技能消耗时间,10秒
	config.lifeSkillCostCD = 10 * 1000;
	//生活技能消耗MP
	config.lifeSkillCostMP = 10;
	//增加技能熟练度数量
	config.addLifeProficiencyNum = 1;
	//生活技能判断是否在范围内的偏移量(半径)
	config.lifePointInAreaOffset = 4;

	/**
     * 骑宠初始忠诚度
     */
    config.PetHorseInitLoy = 100;
    //骑宠最大忠诚度
    config.petHorseMaxLoy = 100;
    //骑宠出战最低忠诚度
    config.PetHorseFightLoyMin = 10;
    //骑宠出战战斗胜利增加忠诚度
    config.petHorseFightWinAddLoy = 10;
    //骑宠出战战斗失败减少忠诚度
    config.petHorseFightLossMiusLoy = 20;
    /**
     * 骑宠初始亲密度
     */
    config.PetHorseInitClo = 60;
    //骑宠最大亲密度
    config.petHorseMaxClo = 100;
    //骑宠出战战斗胜利增加亲密度
    config.petHorseFightWinAddClo = 10;
    //骑宠出战战斗失败减少亲密度
    config.petHorseFightLossMiusClo = 20;
    //非骑乘状态每达到N小时，降低XX点
    config.petHorseNotFightHour = 1;
    //非骑乘状态每达到N小时，降低XX点
    config.petHorseNotFightMinusClo = 15;
    //续租最小时间,毫秒
    config.petHorseReletTime = 1 * 60 * 60 * 1000;

    //计算类经验系数1
    config.calculateExpCoef1 = 10;
    //计算类经验系数2
    config.calculateExpCoef2 = 5;
    //计算类经验系数3
    config.calculateExpCoef3 = 100;
    
    //酒馆经验系数
    config.pubExpCoef = 20;
    //科举经验系数
    config.examExpCoef = 20;
    //绿野仙踪boss经验系数
    config.wizardRaidBossExpCoef = 12;
    //绿野仙踪副本经验系数
    config.wizardRaidExpCoef = 4;
    //封印小妖经验系数
    config.sealDemonExpCoef = 10;
    //跑环任务经验系数
    config.ringExpCoef = 20;
    
    //酒馆计算奖励Id
    config.calculateExpPubRewardId = 1239;
    //封印小妖计算奖励Id
    config.calculateExpSealDemonRewardId = 1372;