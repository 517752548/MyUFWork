package com.imop.lj.gameserver.human;

import java.awt.Point;
import java.sql.Timestamp;
import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.LogReasons.OnlineTimeLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.common.constants.TerminalTypeEnum;
import com.imop.lj.common.model.ScenePlayerInfo;
import com.imop.lj.common.model.map.MapPlayerInfo;
import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.core.util.KeyValuePair;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.db.model.HumanEntity;
import com.imop.lj.gameserver.behavior.BehaviorManager;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.behavior.bindid.BindIdBehaviorManager;
import com.imop.lj.gameserver.cache.service.TemplateCacheService;
import com.imop.lj.gameserver.cd.CdManager;
import com.imop.lj.gameserver.chat.ChatManager;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.RoleDataHolder;
import com.imop.lj.gameserver.common.event.GiveMoneyEvent;
import com.imop.lj.gameserver.common.event.LoginDaysAddEvent;
import com.imop.lj.gameserver.common.event.NotEnoughMoneyEvent;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTaskExecutor;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTaskExecutorImpl;
import com.imop.lj.gameserver.common.i18n.LangService;
import com.imop.lj.gameserver.common.msg.GCMessage;
import com.imop.lj.gameserver.common.msg.GCShowOptionDlg;
import com.imop.lj.gameserver.corpsassist.CorpsAssistManager;
import com.imop.lj.gameserver.corpscultivate.CorpsCultivateManager;
import com.imop.lj.gameserver.corpstask.CorpsTaskManager;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.currency.CurrencyProcessor;
import com.imop.lj.gameserver.day7target.Day7TaskChecker;
import com.imop.lj.gameserver.day7target.Day7TaskManager;
import com.imop.lj.gameserver.foragetask.ForageTaskManager;
import com.imop.lj.gameserver.guide.GuideManager;
import com.imop.lj.gameserver.human.manager.BattleManager;
import com.imop.lj.gameserver.human.manager.ConsumeConfirmManager;
import com.imop.lj.gameserver.human.manager.HumanFuncManager;
import com.imop.lj.gameserver.human.manager.HumanInitManager;
import com.imop.lj.gameserver.human.manager.HumanPropertyManager;
import com.imop.lj.gameserver.human.manager.SmsCheckCodeManager;
import com.imop.lj.gameserver.human.msg.GCLoginDays;
import com.imop.lj.gameserver.item.Inventory;
import com.imop.lj.gameserver.lifeskill.MineManager;
import com.imop.lj.gameserver.mail.MailBox;
import com.imop.lj.gameserver.mall.MallManager;
import com.imop.lj.gameserver.map.MapDef;
import com.imop.lj.gameserver.map.model.AbstractGameMap;
import com.imop.lj.gameserver.map.msg.MapMsgBuilder;
import com.imop.lj.gameserver.moneyreport.CurrencyCostDetail;
import com.imop.lj.gameserver.mysteryshop.MysteryShopManager;
import com.imop.lj.gameserver.offlinereward.OfflineRewardManager;
import com.imop.lj.gameserver.onlinegift.OnlineGiftManager;
import com.imop.lj.gameserver.onlinegift.SpecOnlineGiftManager;
import com.imop.lj.gameserver.overman.OvermanOnlineChecker;
import com.imop.lj.gameserver.pet.PetDef;
import com.imop.lj.gameserver.pet.PetDef.JobType;
import com.imop.lj.gameserver.pet.PetDef.PetQuality;
import com.imop.lj.gameserver.pet.PetDef.Sex;
import com.imop.lj.gameserver.pet.PetManager;
import com.imop.lj.gameserver.pet.template.PetTemplate;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.StaticHandlelHolder;
import com.imop.lj.gameserver.player.msg.AddLoginDaysMessage;
import com.imop.lj.gameserver.player.msg.GCUpdateToken;
import com.imop.lj.gameserver.plotdungeon.EasyPlotDungeonManager;
import com.imop.lj.gameserver.plotdungeon.HardPlotDungeonManager;
import com.imop.lj.gameserver.promote.PromoteManager;
import com.imop.lj.gameserver.pubtask.PubTaskManager;
import com.imop.lj.gameserver.quest.CommonTaskManager;
import com.imop.lj.gameserver.relation.RelationManager;
import com.imop.lj.gameserver.role.Role;
import com.imop.lj.gameserver.role.RoleFinalProps;
import com.imop.lj.gameserver.role.RoleTypes;
import com.imop.lj.gameserver.role.properties.RoleBaseIntProperties;
import com.imop.lj.gameserver.role.properties.RoleBaseStrProperties;
import com.imop.lj.gameserver.scene.Scene;
import com.imop.lj.gameserver.scene.SceneTypeEnum;
import com.imop.lj.gameserver.scene.template.SceneTemplate;
import com.imop.lj.gameserver.siegedemontask.SiegeDemonHardTaskManager;
import com.imop.lj.gameserver.siegedemontask.SiegeDemonNormalTaskManager;
import com.imop.lj.gameserver.task.ITaskOwner;
import com.imop.lj.gameserver.task.TaskListener;
import com.imop.lj.gameserver.team.model.Team;
import com.imop.lj.gameserver.thesweeneytask.TheSweeneyTaskManager;
import com.imop.lj.gameserver.timeevent.TimeQueueService;
import com.imop.lj.gameserver.timeevent.template.SysPowerGiveTimeTemplate;
import com.imop.lj.gameserver.timelimit.TimeLimitManager;
import com.imop.lj.gameserver.timelimit.monster.TimeLimitMonsterManager;
import com.imop.lj.gameserver.timelimit.npc.TimeLimitNpcManager;
import com.imop.lj.gameserver.tower.TowerManager;
import com.imop.lj.gameserver.treasuremap.TreasureMapManager;
import com.imop.lj.gameserver.util.FixedSizeQueue;
import com.imop.lj.gameserver.util.MapUtil;
import com.imop.lj.gameserver.vip.VipExpireProcesser;
import com.imop.lj.gameserver.wing.WingManager;
import com.imop.lj.gameserver.wizardraid.WizardRaidSingleChecker;

import net.sf.json.JSONObject;

/**
 * 人物角色
 */
public class Human extends Role implements PersistanceObject<Long, HumanEntity>, RoleDataHolder, ITaskOwner {
    private int popId;
    private int leagueSite;
    private int leagueId;
    private long roleUUID;
    private boolean isInDb;

    /**
     * 角色所属玩家
     */
    private Player player;

    /**
     * 物品
     */
    private Inventory inventory;

    /**
     * 初始化管理器
     */
    private HumanInitManager initManager;

    /**
     * 属性管理器
     */
    private HumanPropertyManager propertyManager;

    /**
     * 生命期
     */
    private final LifeCycle lifeCycle;

    /**
     * 消息控制
     */
    private HumanMessageControl messageControl;

    /**
     * 所属场景
     */
    protected Scene scene;

    /**
     * 在线状态
     */
    private int onlineStatus;
    /**
     * 武将管理器
     */
    private PetManager petManager;


    /**
     * 提示信息管理器
     */
    private ConsumeConfirmManager consumeConfirmManager;

    /**
     * 行为管理器
     */
    private BehaviorManager behaviorManager;

    /**
     * 玩家状态保存器
     */
    private final StaticHandlelHolder staticHandlelHolder;

    /**
     * 普通任务管理器
     */
    private CommonTaskManager commonTaskManager;

    /**
     * 关系管理器
     */
    private RelationManager relationManager;

    /**
     * 冷却队列管理器
     */
    private CdManager cdManager;

    /**
     * 绑定Id的行为管理器
     */
    private BindIdBehaviorManager bindIdBehaviorManager;

    /**
     * 在线礼包管理器
     */
    private OnlineGiftManager onlineGiftManager;

    /**
     * 邮箱
     */
    private MailBox mailbox;

    /**
     * 离线奖励
     */
    private OfflineRewardManager offlineRewardManager;

    /**
     * 功能管理
     */
    private HumanFuncManager funcManager;

    /**
     * 神秘商店管理
     */
    private MysteryShopManager mysteryShopManager;
    
    /**
     * 限时活动管理
     */
    private TimeLimitManager timeLimitManager;
    
    /**
     * 通天塔管理
     */
    private TowerManager towerManager;
    
    /**
     * 帮派修炼技能管理
     */
    private CorpsCultivateManager corpsCultivateManager;
    
    /**
     * 帮派辅助技能管理
     */
    private CorpsAssistManager corpsAssistManager;
    
    /**
     * 简单剧情副本管理
     */
    private EasyPlotDungeonManager easyPlotDungeonManager;
    
    /**
     * 精英剧情副本管理
     */
    private HardPlotDungeonManager hardPlotDungeonManager;

    /**
     * 商城管理
     */
    private MallManager mallManager;

    private int prizeNum;

    /**
     * 手机验证
     */
    private SmsCheckCodeManager smsCheckCodeManager;

    /**
     * 聊天管理器
     */
    private ChatManager chatManager;

    /**
     * 特殊在线礼包
     */
    private SpecOnlineGiftManager specOnlineGiftManager;

    /**
     * 玩家当前所在位置格子，只在内存中保存
     */
    private int tileX;
    private int tileY;

    /**
     * 人物移动次数，切换地图，或者结束战斗时，设置这个变量=0，每次移动时修改，移动次数越多，遇敌概率越大
     */
    private int moves;
    /**
     * 人物下次要移动的步数，用于判断是否遇敌
     */
    private int nextMoves;
    
    /**
     * 任务移动的临时数据，保存最近3次的移动数据，校验作弊用
     */
    private FixedSizeQueue<MoveInfo> moveInfoQueue = new FixedSizeQueue<MoveInfo>(SharedConstants.MOVE_INFO_QUEUE_SIZE);
    
    /**
     * 出于效率考虑，将一段时间内的移动消息攒起来再发送
     */
    private List<MapPlayerInfo> locInfoList = new ArrayList<MapPlayerInfo>();
    /**
     * 上次发送LocationInfo的时间
     */
    private long lastSendLocInfoTime;

    /**
     * 任务监听器
     */
    private TaskListener<Human> taskListener;

    /**
     * 酒馆任务管理器
     */
    private PubTaskManager pubTaskManager;

    /**
     * 采矿管理
     */
    private MineManager mineManager;

    /**
     * 心跳任务处理器
     */
    protected HeartbeatTaskExecutor hbTaskExecutor;

    /**
     * 除暴安良任务管理器
     */
    private TheSweeneyTaskManager theSweeneyTaskManager;

    /**
     * 藏宝图任务管理器
     */
    private TreasureMapManager treasureMapManager;

	
	/**护送粮草任务管理器 */
	private ForageTaskManager forageTaskManager;
	
	/**翅膀管理器*/
	private WingManager wingManager;
	
    /**
     * 帮派任务管理器
     */
    private CorpsTaskManager corpsTaskManager;
    
    /**
     * 限时杀怪管理器
     */
    private TimeLimitMonsterManager timeLimitMonsterManager;
    
    /**
     * 限时挑战Npc管理器
     */
    private TimeLimitNpcManager timeLimitNpcManager;
    
    /** 新手引导管理器 */
	private GuideManager guideManager;

	/** 玩家加入humanCacheService的时间 */
	private long lastCachedTime;
	
	/** 七日目标任务管理 */
	private Day7TaskManager day7TaskManager;
	
	/** 魔族围剿普通任务管理 */
	private SiegeDemonNormalTaskManager siegeDemonNormalTaskManager;
	/** 魔族围剿困难任务管理 */
	private SiegeDemonHardTaskManager siegeDemonHardTaskManager;
	
	/** 战斗数据管理器 */
	private BattleManager battleManager;
	
	/** 玩家提升管理器*/
	private PromoteManager promoteManager;
	
	/**
	 * 获取当前终端类型
	 *
	 * @return
	 *
	 */
	public TerminalTypeEnum getCurrTerminalType() {
		if (this.player == null) {
			return TerminalTypeEnum.WEB;
		} else {
			return this.player.getCurrTerminalType();
		}
	}

    public void onInit(TemplateCacheService templateService, LangService langService) {
        // TODO 初始化各个管理器模块
        this.behaviorManager.init(templateService);
        this.bindIdBehaviorManager.init(templateService);
    }

    public Human() {
        super(RoleTypes.HUMAN);
        this.hbTaskExecutor = new HeartbeatTaskExecutorImpl();
        this.hbTaskExecutor.submit(new WizardRaidSingleChecker(this));
        this.hbTaskExecutor.submit(new OvermanOnlineChecker(this));
        this.hbTaskExecutor.submit(new VipExpireProcesser(this));
        this.hbTaskExecutor.submit(new Day7TaskChecker(this));

        this.lifeCycle = new LifeCycleImpl(this);
        this.initManager = new HumanInitManager(this);
        this.cdManager = new CdManager(this, Globals.getCdService());
        this.messageControl = new HumanMessageControl(this);
        this.propertyManager = new HumanPropertyManager(this);
        this.petManager = new PetManager(this);
        this.consumeConfirmManager = new ConsumeConfirmManager(this);
        this.staticHandlelHolder = new StaticHandlelHolder();
        this.behaviorManager = new BehaviorManager(this);
        this.relationManager = new RelationManager(this);
        this.cdManager = new CdManager(this, Globals.getCdService());
        this.bindIdBehaviorManager = new BindIdBehaviorManager(this);
        this.onlineGiftManager = new OnlineGiftManager(this);
        this.mailbox = new MailBox(this);
        this.offlineRewardManager = new OfflineRewardManager(this);
        this.funcManager = new HumanFuncManager(this);
        this.mysteryShopManager = new MysteryShopManager(this);
        this.timeLimitManager = new TimeLimitManager(this);
        this.towerManager = new TowerManager(this);
        this.corpsCultivateManager = new CorpsCultivateManager(this);
        this.corpsAssistManager = new CorpsAssistManager(this);
        this.easyPlotDungeonManager = new EasyPlotDungeonManager(this);
        this.hardPlotDungeonManager = new HardPlotDungeonManager(this);
        this.mallManager = new MallManager(this);
        this.smsCheckCodeManager = new SmsCheckCodeManager(this);
        this.chatManager = new ChatManager(this);
        this.specOnlineGiftManager = new SpecOnlineGiftManager(this);
        
        //XXX 任务管理器需要放到taskListener前面
        this.commonTaskManager = new CommonTaskManager(this);
        this.pubTaskManager = new PubTaskManager(this);
        this.theSweeneyTaskManager = new TheSweeneyTaskManager(this);
        this.treasureMapManager = new TreasureMapManager(this);
        this.forageTaskManager = new ForageTaskManager(this);
        this.corpsTaskManager = new CorpsTaskManager(this);
        this.timeLimitMonsterManager = new TimeLimitMonsterManager(this);
        this.timeLimitNpcManager = new TimeLimitNpcManager(this);
        this.day7TaskManager = new Day7TaskManager(this);
        this.siegeDemonNormalTaskManager = new SiegeDemonNormalTaskManager(this);
        this.siegeDemonHardTaskManager = new SiegeDemonHardTaskManager(this);
        //！！！这个前面放任务管理器！！！
        this.taskListener = new TaskListener<Human>(this);
        
        this.mineManager = new MineManager(this);
		this.wingManager = new WingManager(this);

		this.guideManager = new GuideManager(this);
		this.battleManager = new BattleManager(this);
		this.promoteManager = new PromoteManager(this);
    }

    public HumanMessageControl getMessageControl() {
        return messageControl;
    }

    /**
     * 记录退出时间和在线时长
     */
    public void logLogout() {
        // TODO 修改退出时间，在线时间
        Timestamp _now = new Timestamp(Globals.getTimeService().now());
        this.setLastLogoutTime(_now);

        this.setOnlineStatus(0);
        long _onlineTime = 0;
        Timestamp _loginTime = this.getLastLoginTime();
        Timestamp _logoutTime = this.getLastLogoutTime();
        if (_loginTime != null && _logoutTime != null) {
            _onlineTime = _logoutTime.getTime() - _loginTime.getTime();
        }
        this.setTotalMinute(this.getTotalMinute() + (int) (_onlineTime / (1000 * 60)));
        // 发送快照到日志服务器 玩家退出日志
        // Globals.getPlayerLogService().sendExitLog(this, player.exitReason);
        // 发送在线时长日志
        if (_loginTime != null && _logoutTime != null) {
            try {
                Globals.getLogService().sendOnlineTimeLog(this, OnlineTimeLogReason.DEFAULT, null, player.getTodayOnlineTime(),
                        this.getTotalMinute(), this.getLastLoginTime().getTime(), this.getLastLogoutTime().getTime());
            } catch (Exception e) {
                Loggers.charLogger.error(LogUtils.buildLogInfoStr(this.getUUID() + "", "记录玩家在线时长日志时出错"), e);
            }
        }
    }

    public String getName() {
        return this.baseStrProperties.getString(RoleBaseStrProperties.NAME);
    }

    public void setName(String name) {
        this.baseStrProperties.setString(RoleBaseStrProperties.NAME, name);
        this.onModified();
    }

    public int getPopId() {
        return popId;
    }

    public void setPopId(int popId) {
        this.popId = popId;
    }

    public int getLeagueSite() {
        return leagueSite;
    }

    public void setLeagueSite(int leagueSite) {
        this.leagueSite = leagueSite;
    }

    public int getLeagueId() {
        return leagueId;
    }

    public void setLeagueId(int leagueId) {
        this.leagueId = leagueId;
    }

    @Override
    public void setDbId(Long id) {
        this.roleUUID = id;

    }

    @Override
    public Long getDbId() {
        return this.roleUUID;
    }

    public long getUUID() {
        return roleUUID;
    }

    @Override
    public String getGUID() {
        return "human#" + getUUID();
    }

    @Override
    public boolean isInDb() {
        return isInDb;
    }

    @Override
    public void setInDb(boolean inDb) {
        this.isInDb = inDb;

    }

    @Override
    public long getCharId() {
        return roleUUID;
    }

    public String getPassportId() {
        return player.getPassportId();
    }

    public String getPassportName() {
        return player.getPassportName();
    }

    @Override
    public HumanEntity toEntity() {
        // TODO toEntity
        HumanEntity entity = new HumanEntity();
        entity.setPassportId(this.player.getPassportId());
        entity.setName(this.getName());
        if (this.getCreateTime() == 0) {
            entity.setCreateTime(new Timestamp(Globals.getTimeService().now()));
        } else {
            entity.setCreateTime(new Timestamp(this.getCreateTime()));
        }
        entity.setId(this.getUUID());
        entity.setPhoto(this.getPhoto());
        entity.setGold(this.getGold());
        entity.setGold2(this.getGold2());
        entity.setBond(this.getBond());
        entity.setSysBond(this.getSysBond());
        entity.setGiftBond(this.getGiftBond());

        entity.setLevel(this.getLevel());
        entity.setExp(this.getExp());
        entity.setLastLoginTime(this.getLastLoginTime());
        entity.setLastLogoutTime(this.getLastLogoutTime());
        entity.setLastLoginIp(this.getLastLoginIp());
        entity.setTotalMinute(this.getTotalMinute());
        entity.setOnlineStatus(this.getOnlineStatus());
        entity.setTodayCharge(this.getTodayCharge());
        entity.setTotalCharge(this.getTotalCharge());
        entity.setLastChargeTime(this.getLastChargeTime());
        entity.setLastVipTime(this.getLastVipTime());
        entity.setSceneId(this.getSceneId());
        entity.setLastCitySceneId(this.getLastCitySceneId());
        entity.setCountry(this.getCountry());
        entity.setIdleTime(this.getCacheFlag());
        entity.setEternalCostMoney(this.getEternalCostMoney());
        // 设置军令
        entity.setPower((int) this.getPower());
        // 设置声望
        entity.setHonor((int) this.getHonor());

        //设置活力值
        entity.setEnergy((int) this.getEnergy());
        //设置红包钱
        entity.setRedEnvelope((int) this.getRedEnvelope());

        // 设置最后一次给军令时间
        entity.setLastGivePowerTime(this.getLastGivePowerTime());
        entity.setLastGiveDoublePointTime(this.getLastGiveDoublePointTime());
        entity.setSkillPoint((int) this.getSkillPoint());
        entity.setLastGiveSkillPointTime(this.getLastGiveSkillPointTime());
        entity.setCdQueuePack(this.getCdManager().toJsonProp());

        //设置仓库开格数量
        entity.setHadOpenPrimBagNum(this.getStoreOpenNum());

        // 能否修改名字
        entity.setCanRename(this.getCanRename());
        // 所属服务器Id
        entity.setServerId(this.getServerId());

        entity.setWeekCharge(this.getWeekCharge());
        entity.setMonthCharge(this.getMonthCharge());

        entity.setTokenParam1(this.getTokenParam1());
        entity.setTokenParam2(this.getTokenParam2());

        entity.setMapId(this.getMapId());
        entity.setX(this.getX());
        entity.setY(this.getY());

        entity.setBackMapId(this.getBackMapId());
        entity.setBackX(this.getBackX());
        entity.setBackY(this.getBackY());

        entity.setLastBattleId(this.getLastBattleId());
        entity.setLastBattleTime(this.getLastBattleTime());
        entity.setLastBattleEndTime(this.getLastBattleEndTime());

        entity.setAutoFightAction(this.getAutoFightAction());
        entity.setPetAutoFightAction(this.getPetAutoFightAction());

        entity.setPubLevel(this.getPubLevel());
        entity.setPubExp(this.getPubExp());

        entity.setMainSkillLevel(this.getMainSkillLevel());
        entity.setMainSkillType(this.getRunningMainSkillTypeId());
//        entity.setMainSkillType((Integer) (this.getRunningMainSkillType() == null ? this.getJobType().getDefaultMainSkillType() : this.getRunningMainSkillType().index));

        entity.setMineLevel(this.getMineLevel());

        // props数据
        JSONObject json = new JSONObject();
        json.put(HumanPropAttr.BEHAVIOR.toString(), this.getBehaviorManager().toJsonProp());
        json.put(HumanPropAttr.CONSUME_CONFIRM.toString(), this.getConsumeConfirmManager().toJsonProp());
        json.put(HumanPropAttr.BINDID_BEHAVIOR.toString(), this.getBindIdBehaviorManager().toJsonProp());
        json.put(HumanPropAttr.FUNC.toString(), this.funcManager.toJsonProp());
        json.put(HumanPropAttr.ONLINE_GIFT.toString(), this.onlineGiftManager.toJsonProp());
        json.put(HumanPropAttr.MALL.toString(), this.mallManager.toJsonProp());
        json.put(HumanPropAttr.CHAT, this.chatManager.toJsonProp());
        json.put(HumanPropAttr.PUB_TASK.toString(), this.pubTaskManager.toJsonProp());
        json.put(HumanPropAttr.MINE.toString(), this.mineManager.toJsonProp());
        json.put(HumanPropAttr.FORAGE.toString(), this.forageTaskManager.toJsonProp());
        json.put(HumanPropAttr.GUIDE.toString(), this.guideManager.toJsonProp());
        json.put(HumanPropAttr.MYSTERY_SHOP.toString(), this.mysteryShopManager.toJsonProp());
        json.put(HumanPropAttr.TIME_LIMIT.toString(), this.timeLimitManager.toJsonProp());
        json.put(HumanPropAttr.TOWER.toString(), this.towerManager.toJsonProp());
        json.put(HumanPropAttr.CORPS_CULTIVATE.toString(), this.corpsCultivateManager.toJsonProp());
        json.put(HumanPropAttr.CORPS_ASSIST.toString(), this.corpsAssistManager.toJsonProp());
        json.put(HumanPropAttr.EASY_PLOT_DUNGEON.toString(), this.easyPlotDungeonManager.toJsonProp());
        json.put(HumanPropAttr.HARD_PLOT_DUNGEON.toString(), this.hardPlotDungeonManager.toJsonProp());
        json.put(HumanPropAttr.BATTLE.toString(), this.getBattleManager().toJsonProp());

        entity.setProps(json.toString());

        return entity;
    }

    @Override
    public void fromEntity(HumanEntity entity) {
        this.getInitManager().loadHuman(entity);
    }

    @Override
    public LifeCycle getLifeCycle() {
        return lifeCycle;
    }

    @Override
    public void setModified() {
        if (this.lifeCycle.isActive()) {
        	player.getDataUpdater().addUpdate(lifeCycle);
        }
    }

    public Player getPlayer() {
        return player;
    }

    public void setPlayer(Player player) {
    	if (!HumanCacheService.isOpen() || 
    			(HumanCacheService.isOpen() && player != null)) {
    		this.player = player;
    	}
    }

    @Override
    public void sendMessage(GCMessage msg) {
        if (msg != null && player != null) {
            player.sendMessage(msg);
        }
    }

    /**
     * 可以获得建筑等级和科技等级
     *
     * @return
     */
    public HumanPropertyManager getPropertyManager() {
        return propertyManager;
    }

    @Override
    public void onModified() {
        this.setModified();
    }

    @Override
    protected List<KeyValuePair<Integer, Integer>> changedNum() {
        // 保存数值类属性变化
        List<KeyValuePair<Integer, Integer>> intNumChanged = new ArrayList<KeyValuePair<Integer, Integer>>();

        // 处理 一二级属性
        if (this.getPropertyManager().isChanged()) {
            KeyValuePair<Integer, Integer>[] _numChanged = this.getPropertyManager().getChanged(); // float
            for (KeyValuePair<Integer, Integer> pair : _numChanged) {
                intNumChanged.add(new KeyValuePair<Integer, Integer>(pair.getKey(), pair.getValue()));
            }
        }

        // 处理 baseIntProps
        if (this.baseIntProperties.isChanged()) {
            KeyValuePair<Integer, Integer>[] changes = this.baseIntProperties.getChanged();
            for (KeyValuePair<Integer, Integer> pair : changes) {
                intNumChanged.add(pair);
            }
        }

        return intNumChanged;
    }

    @Override
    public void checkAfterRoleLoad() {
        this.petManager.checkAfterRoleLoad();
        this.inventory.checkAfterRoleLoad();
        this.commonTaskManager.checkAfterRoleLoad();

		this.mailbox.checkAfterRoleLoad();
		this.offlineRewardManager.checkAfterRoleLoad();
		this.funcManager.checkAfterRoleLoad();
		this.pubTaskManager.checkAfterRoleLoad();
		this.mineManager.checkAfterRoleLoad();
		this.theSweeneyTaskManager.checkAfterRoleLoad();
		this.treasureMapManager.checkAfterRoleLoad();
		this.forageTaskManager.checkAfterRoleLoad();
		this.wingManager.checkAfterRoleLoad();
		this.corpsTaskManager.checkAfterRoleLoad();
		this.timeLimitMonsterManager.checkAfterRoleLoad();
		this.timeLimitNpcManager.checkAfterRoleLoad();
		this.day7TaskManager.checkAfterRoleLoad();
		this.siegeDemonNormalTaskManager.checkAfterRoleLoad();
		this.siegeDemonHardTaskManager.checkAfterRoleLoad();
		this.battleManager.checkAfterRoleLoad();
	}

    /**
     * 玩家登录后的体力相关处理 1、扫荡扣体力 2、恢复体力
     */
    public void checkPowerRelated() {
//		// 关卡挂机处理，即先扣体力，再执行下面的给玩家加体力，这样玩家不会损失体力 
//		Globals.getCleanMissionService().checkCleanMission(this, true, false);
//		// 副本挂机的处理
//		Globals.getCleanRaidService().checkCleanRaid(this, true, false);

        // 重置玩家体力值
        Timestamp _lastLogoutTime = this.getLastLogoutTime();
        if (_lastLogoutTime != null) {
            long lastGivePowerTime = getLastGivePowerTime();
            long now = Globals.getTimeService().now();
            TimeQueueService timeQueueService = Globals.getTimeQueueService();

            // 补充体力
            SysPowerGiveTimeTemplate sysPowerGiveTimeTemplate = Globals.getTemplateCacheService().get(SharedConstants.CONFIG_TEMPLATE_DEFAULT_ID,
                    SysPowerGiveTimeTemplate.class);
            int amountPower = 0;
            for (int timeEventId : sysPowerGiveTimeTemplate.getTimeEventIds()) {
                long compareTime = timeQueueService.getLastRealTime(timeEventId);
                int reachTimes = TimeUtils.getSpecTimeCountBetween(lastGivePowerTime, now, compareTime);
                if (reachTimes > 0) {
                    amountPower += reachTimes * Globals.getGameConstants().getSysGivePowerNum();
                }
            }
            if (amountPower > 0) {
                String detailReason = MoneyLogReason.RECOVER_POWER.getReasonText();
                detailReason = MessageFormat.format(detailReason, amountPower);
                this.recoverPower(amountPower, false, MoneyLogReason.RECOVER_POWER, detailReason);
            }
        }
    }
    
    @Override
    public void checkBeforeRoleEnter() {
//		this.missionManager.checkBeforeRoleEnter();
//		this.raidManager.checkBeforeRoleEnter();
//		this.enemyArmyManager.checkBeforeRoleEnter();
//		this.cleanMissionManager.checkBeforeRoleEnter();
//		this.heroMissionManager.checkBeforeRoleEnter();
//		this.swordTowerManager.checkBeforeRoleEnter();
    }

    public HumanInitManager getInitManager() {
        return initManager;
    }

    /**
     * 记录登录时间
     *
     * @param time
     * @param ip
     */
    public void logLogin(long time, String ip) {
        if (time > 0) {
            this.setLastLoginTime(new Timestamp(time));
            this.setOnlineStatus(1);
            if (this.getPlayer() != null) {
                this.getPlayer().setLastLoginTime(new Timestamp(time));
            }
        }
        this.setLastLoginIp(ip);
    }

    /**
     * 在数据加载完之后的登陆
     *
     * @param isFirstLogin
     */
    public void onLogin(boolean isFirstLogin) {
        // 是否是玩家第一登录游戏
        if (isFirstLogin) {
            // 发送新手物品
            Globals.getHumanAssistantService().giveFirstLoginGifts(this);

            Globals.getHumanAssistantService().initHuman(this);

            //给初始的称号
            final long charId = this.getCharId();
            Globals.getSceneService().getCommonScene().putMessage(new SysInternalMessage() {
				@Override
				public void execute() {
					Globals.getTitleService().initHumanTitle(charId);
				}
            });
            
        }

        // 每次登陆后，更新玩家离线数据，因为配置表中的属性值可能修改，所以登陆后都调用一次更新
        Globals.getOfflineDataService().sendRebuildUserSnapMsg(this);

        // 登录后，往玩家消息队列中放入增加登录天数的消息
        player.putMessage(new AddLoginDaysMessage(getUUID()));

        //XXX 下面方法的setModify都去掉了，这里是主线程，不能存库，因为HumanCacheService中可能也在存库。玩家登录后有很多其他setModify，利用他们存库即可
        // 记录登陆时间和ip
        logLogin(Globals.getTimeService().now(), getPlayer().getSession().getIp());

        //客户端更新token
        updateToken();
    }

    /**
     * 检查玩家是否足够指定货币，如果替补货币为NULL/null则只检查主货币，主货币不可以为NULL/null
     *
     * @param amount       数量，>=0才有效，==0时永远返回true
     * @param mainCurrency 主货币类型
     * @param needNotify   是否需要通知，如果为true则当返回false时会提示，您的xxx（主货币名称）不足
     * @return 如果主货币够amount返回true，主货币不够看替补货币够不够除现有主货币外剩下的，够也返回true，加起来都不够返回false，
     * 参数无效也会返回false
     */
    public boolean hasEnoughMoney(long amount, Currency mainCurrency, boolean needNotify) {
        boolean flag = false;
        if (amount <= 0)
            return flag;
        switch (mainCurrency) {
            case GIFT_BOND:
                flag = hasEnoughGiftBond(amount, needNotify);
                break;
            case BOND:
            case SYS_BOND:
                flag = CurrencyProcessor.instance.hasEnoughMoney(this, amount, Currency.SYS_BOND, Currency.BOND, needNotify);
                break;
//		case POWER:
//			flag = CurrencyProcessor.instance.hasEnoughMoney(this, amount, Currency.POWER, null, needNotify);
//			break;
            //银票是否足够，不够用银子顶替
            case GOLD:
                flag = CurrencyProcessor.instance.hasEnoughMoney(this, amount, Currency.GOLD, Currency.GOLD2, needNotify);
                break;
            case ENERGY:
            	flag = CurrencyProcessor.instance.hasEnoughMoney(this, amount, Currency.ENERGY, null, needNotify);
            	break;
            case RED_ENVELOPE:
            	flag = CurrencyProcessor.instance.hasEnoughMoney(this, amount, Currency.RED_ENVELOPE, null, needNotify);
            	break;
            default:
                flag = CurrencyProcessor.instance.hasEnoughMoney(this, amount, mainCurrency, null, needNotify);
                break;
        }
        if (!flag) {
            // 货币不足的事件触发
            Globals.getEventService().fireEvent(new NotEnoughMoneyEvent(this, mainCurrency, amount));
        }
        return flag;
    }

    /**
     * 获取指定类型货币数量， 其中：元宝和内币=元宝+内币，礼券=元宝+内币+礼券，不考虑溢出
     *
     * @param currency
     * @return
     */
    public long getAllMoney(Currency currency) {
        switch (currency) {
            case GIFT_BOND:
                long giftBond = this.getMoney(Currency.GIFT_BOND);
                long sysBond = this.getMoney(Currency.SYS_BOND);
                long bond = this.getMoney(Currency.BOND);
                return giftBond + sysBond + bond;
            case BOND:
            case SYS_BOND:
                long _sysBond = this.getMoney(Currency.SYS_BOND);
                long _bond = this.getMoney(Currency.BOND);
                return _sysBond + _bond;
            default:
                return this.getMoney(currency);
        }
    }

    /**
     * 项目中，用于消耗礼券，消耗礼券比较特殊，需要对三种货币进行消耗
     *
     * @param amount
     * @return
     */
    protected boolean hasEnoughGiftBond(long amount, boolean needNotify) {
        if (amount <= 0) {
            return false;
        }

        long mainCurrAmount = getMoney(Currency.GIFT_BOND);
        if (mainCurrAmount >= amount) {
            // 礼券就足够了
            return true;
        } else {
            // 礼券不够用元宝使用还缺多少钱
            long lack = amount - mainCurrAmount;
            boolean flag = CurrencyProcessor.instance.hasEnoughMoney(this, lack, Currency.SYS_BOND, Currency.BOND, false);
            if (!flag) {
                if (needNotify) {
                    this.sendSystemMessage(LangConstants.COMMON_NOT_ENOUGH, Globals.getLangService().readSysLang(Currency.GIFT_BOND.getNameKey()));
                }
            }
            return flag;
        }
    }

    /**
     * 获得消耗细节
     *
     * @param amount
     * @param mainCurrency
     * @return
     */
    public CurrencyCostDetail getCurrencyCostDetail(long amount, Currency mainCurrency) {
        if (amount <= 0) {
            return null;
        }
        switch (mainCurrency) {
            case GIFT_BOND:
                return CurrencyProcessor.instance.getCurrencyCostDetail(this, amount, Currency.GIFT_BOND, Currency.SYS_BOND, Currency.BOND);
            case BOND:
            case SYS_BOND:
                return CurrencyProcessor.instance.getCurrencyCostDetail(this, amount, Currency.SYS_BOND, Currency.BOND, null);
            case GOLD:
                return CurrencyProcessor.instance.getCurrencyCostDetail(this, amount, Currency.GOLD, Currency.GOLD2, null);
            default:
                return null;
        }
    }

    /**
     * 扣钱
     *
     * @param amount       扣得数量，>0才有效
     * @param mainCurrency 主货币类型，不为NULL/null才有效
     * @param needNotify   是否在该函数内通知玩家货币改变，为true时信息格式为"您花费了xx（货币单位）用于xx"， false时不在本函数内提示
     * @param usageLangId  用途多语言Id,如果needNotify为true，这里提供的用途会被加载提示信息“用于”后面
     * @param reason       扣钱的原因
     * @param detailReason 详细原因，通常为null，扩展使用
     * @param reportItemId 向平台汇报贵重物品消耗时的itemTemplateId，非物品的消耗时使用-1
     * @return 扣钱成功返回true, 否则返回false, 失败可能是钱已经超出了最大限额, 参数不合法等
     */
    public boolean costMoney(long amount, Currency mainCurrency, boolean needNotify, Integer usageLangId, MoneyLogReason reason,
                             String detailReason, int reportItemId) {
        if (amount <= 0)
            return false;
        switch (mainCurrency) {
            case GIFT_BOND:
                return CurrencyProcessor.instance.costMoney(this, amount, Currency.GIFT_BOND, Currency.SYS_BOND, Currency.BOND, needNotify, usageLangId, reason,
                        detailReason, reportItemId);
            // XXX band和sysbond不能与其他货币使用，强制转换成先使用绑定金币再使用金币
            case BOND:
            case SYS_BOND:
                return CurrencyProcessor.instance.costMoney(this, amount, Currency.SYS_BOND, Currency.BOND, null, needNotify, usageLangId, reason,
                        detailReason, reportItemId);
//		case POWER:
//			return CurrencyProcessor.instance.costMoney(this, amount, mainCurrency, null, null, needNotify, usageLangId, reason, detailReason, reportItemId);
            //银票可用银子顶替
            case GOLD:
                return CurrencyProcessor.instance.costMoney(this, amount, Currency.GOLD, Currency.GOLD2, null, needNotify, usageLangId, reason,
                        detailReason, reportItemId);
            case ENERGY:
            	return CurrencyProcessor.instance.costMoney(this, amount, Currency.ENERGY, null, null, needNotify, usageLangId, reason,
            			detailReason, reportItemId);
            case RED_ENVELOPE:
            	return CurrencyProcessor.instance.costMoney(this, amount, Currency.RED_ENVELOPE, null, null, needNotify, usageLangId, reason,
            			detailReason, reportItemId);
            default:
                return CurrencyProcessor.instance.costMoney(this, amount, mainCurrency, null, null, needNotify, usageLangId, reason, detailReason, reportItemId);
        }
    }

//	/**
//	 * 
//	 * @param amount
//	 * @param mainCurrency
//	 * @param needNotify
//	 * @param usageLangId
//	 * @param reason
//	 * @param detailReason
//	 * @param reportItemId
//	 * @return
//	 */
//	public boolean costEnoughGiftBond(long amount, boolean needNotify, Integer usageLangId, MoneyLogReason reason,
//			String detailReason, int reportItemId) {
//		if (amount <= 0){
//			return false;
//		}
//		boolean flag = this.hasEnoughGiftBond(amount, needNotify);
//		if(!flag){
//			return false;
//		}
//		
//		long mainCurrAmount = getMoney(Currency.GIFT_BOND);
//		if (mainCurrAmount >= amount) {
//			// 礼券就足够了,只扣除礼券
//			return CurrencyProcessor.instance.costMoney(this, amount, Currency.GIFT_BOND, null, null, needNotify, usageLangId, reason,
//					detailReason, reportItemId);
//		} else {
//			// 礼券不够用元宝使用还缺多少钱
//			long lack = amount - mainCurrAmount;
//			
//			//先扣除礼券
//			if(mainCurrAmount > 0){
//				CurrencyProcessor.instance.costMoney(this, mainCurrAmount, Currency.GIFT_BOND, null, null, needNotify, usageLangId, reason,
//						detailReason, reportItemId);
//			}
//			//扣除 绑定元宝和元宝
//			return CurrencyProcessor.instance.costMoney(this, lack, Currency.SYS_BOND, Currency.BOND, null, needNotify, usageLangId, reason,
//					detailReason, reportItemId);
//		}
//	}


    /**
     * 获取某类型货币的原始数量
     * 注意：这里面不能把货币叠加
     *
     * @param currency
     * @return
     */
    public long getMoney(Currency currency) {
        if (currency == null || currency == Currency.NULL) {
            throw new IllegalArgumentException(String.format("查询货币参数有误：mainCurrency=%s", currency));
        }

        int propIndex = currency.getPropIndex();
        return this.getBaseStrProperties().getLong(propIndex);
    }

    /**
     * 获取可以给货币的数量，上限-当前值
     *
     * @param currency
     * @return
     */
    public long getCanGiveMoneyNum(Currency currency) {
        long canGive = 0;
        switch (currency) {
            // 元宝、绑定元宝，他们的和不能超过int最大值
            case BOND:
            case SYS_BOND:
                long _allDiamondBefore = this.getAllBond();
                canGive = Integer.MAX_VALUE - _allDiamondBefore;
                break;

            // 金币，不能超过long最大值
            case GOLD:
                canGive = Long.MAX_VALUE - this.getGold();
                break;
            case GOLD2:
                canGive = Long.MAX_VALUE - this.getGold2();
                break;

            // 体力，指定的上限值
            case POWER:
                long _allPowerBefore = this.getPower();
                canGive = Globals.getGameConstants().getSysPowerBuyMax() - _allPowerBefore;
                break;
            // 礼券、声望等，不能超过int最大值
            case GIFT_BOND:
            case HONOR:
            case SKILL_POINT:
                long _value = this.getBaseStrProperties().getLong(currency.getPropIndex());
                canGive = Integer.MAX_VALUE - _value;
                break;
            case ENERGY:
                long energyValue = this.getBaseStrProperties().getLong(currency.getPropIndex());
                canGive = Globals.getGameConstants().getEnergyMax() - energyValue;
                break;
            case RED_ENVELOPE:
            	long redEnvelope = this.getBaseStrProperties().getLong(currency.getPropIndex());
            	canGive = Globals.getGameConstants().getRedEnvelopeMax() - redEnvelope;
            	break;

            default:
                canGive = Long.MAX_VALUE - this.getBaseStrProperties().getLong(currency.getPropIndex());
        }

        return canGive;
    }

    public boolean canGiveMoney(long amount, Currency currency) {
        if (amount <= 0) {
            return false;
        }

        long canGiveNum = getCanGiveMoneyNum(currency);
        // 如果可给货币数量小于等于0，则不能再给了
        if (canGiveNum <= 0) {
            return false;
        }
        return true;
    }

    /**
     * 给钱
     *
     * @param amount       改变数量，>0才有效
     * @param currency     货币类型，注明：bond和sys_bond类型会统一修改成加sys_bond,因充值影响的bond元宝统一使用
     *                     CurrencyProcessor.instance.giveMoney方法。
     * @param needNotify   是否在该函数内通知玩家货币改变，为true时信息格式为"您获得xx（货币单位）"， false时不在本函数内提示
     * @param reason       给钱原因
     * @param detailReason 详细原因，通常为null，扩展使用
     * @return 给钱成功返回true, 否则返回false, 失败可能是钱已经超出了最大限额, 参数不合法等
     */
    public boolean giveMoney(long amount, Currency currency, boolean needNotify, MoneyLogReason reason, String detailReason) {
        if (!this.canGiveMoney(amount, currency)) {
            return false;
        }

        boolean flag = false;
        switch (currency) {
            case BOND:
            case SYS_BOND:
                flag = CurrencyProcessor.instance.giveMoney(this, amount, Currency.SYS_BOND, needNotify, reason, detailReason, true);
                break;
            case GOLD:
                flag = CurrencyProcessor.instance.giveMoney(this, amount, Currency.GOLD, needNotify, reason, detailReason, true);
                break;
            case POWER:
                flag = this.givePower((int) amount, needNotify, reason, detailReason);
                break;
            case ENERGY:
            	flag = CurrencyProcessor.instance.giveMoney(this, amount, Currency.ENERGY, needNotify, reason, detailReason, true);
            	break;
            case RED_ENVELOPE:
            	flag = CurrencyProcessor.instance.giveMoney(this, amount, Currency.RED_ENVELOPE, needNotify, reason, detailReason, true);
            	break;

            default:
                flag = CurrencyProcessor.instance.giveMoney(this, amount, currency, needNotify, reason, detailReason, true);
                break;
        }
        if (flag) {
            // 调用获得货币的事件监听器
            Globals.getEventService().fireEvent(new GiveMoneyEvent(this, currency, amount));
        }
        return flag;
    }

    /**
     * 玩家获得体力值 1、每半小时恢复5点体力 （需判断是否达到上限200点，达到后体力不再随时间增长） 2、玩家购买体力 （不能超过体力最大值，例如玩家体力790点，此时可以购买体力，但体力仅为最大值800点。如果玩家体力已经是800点，则提示玩家“体力已达最大值，无法购买”）
     * 3、定时活动赠送，每天12:00-13:00,18:00-19:00；玩家上线主界面会出现赠送体力活动按钮，玩家点击即可获得20点体力。 （数值可配置，领取后该按钮即消失，不可超过最大值。如果玩家体力已经是800点，则提示玩家“体力已达最大值，无法领取”） 4、突发事件答题获得体力
     * （不能超过体力最大值，无需提示） 5、谈判和精英谈判失败返还体力 （不能超过体力最大值，无需提示）
     *
     * @param amount       获得体力值数量
     * @param needNotify   是否在该函数内通知玩家货币改变，为true时信息格式为"您获得xx（货币单位）"， false时不在本函数内提示
     * @param reason       获得体力原因
     * @param detailReason 详细原因
     */
    private boolean givePower(int amount, boolean needNotify, MoneyLogReason reason, String detailReason) {
        int addPower = 0;
        // 计算增加以后的体力值
        int afterPower = (int) this.getPower() + amount;
        // 如果当前体力值小于系统体力上限，只增加到体力的上限，其他不给增加
        if (afterPower >= Globals.getGameConstants().getSysPowerBuyMax()) {
            addPower = Globals.getGameConstants().getSysPowerBuyMax() - (int) this.getPower();
        } else {
            addPower = amount;
        }
        if (addPower > 0) {
            return CurrencyProcessor.instance.giveMoney(this, addPower, Currency.POWER, needNotify, reason, detailReason, true);
        } else {
            this.sendErrorMessage(LangConstants.POWER_IS_MAX);
            return false;
        }
    }
    
//	/**
//	 * 宝石迷阵增加精力
//	 * @param amount
//	 * @param needNotify
//	 * @param reason
//	 * @param detailReason
//	 * @return
//	 */
//	private boolean giveGemMazeEnergy(int amount, boolean needNotify, MoneyLogReason reason, String detailReason) {
//		int addEnergy = 0;
//		// 计算增加以后的精力值
//		int afterEnergy = (int)this.getGemMazeEnergy() + amount;
//		// 如果当前精力值小于系统精力上限，只增加到精力的上限，其他不给增加
//		if (afterEnergy >= Globals.getGameConstants().getGemMaxEnergy()) {
//			addEnergy = Globals.getGameConstants().getGemMaxEnergy() - (int)this.getGemMazeEnergy();
//		} else {
//			addEnergy = amount;
//		}
//		if (addEnergy > 0) {
//			return CurrencyProcessor.instance.giveMoney(this, addEnergy, Currency.GEM_MAZE_ENERGY, needNotify, reason, detailReason, true);
//		} else {
//			this.sendErrorMessage(LangConstants.GEM_MAZE_ENERGY_IS_MAX);
//			return false;
//		}
//	}

    /**
     * 玩家获得体力值 1、每半小时恢复5点体力 （需判断是否达到上限200点，达到后体力不再随时间增长） 2、玩家购买体力 （不能超过体力最大值，例如玩家体力790点，此时可以购买体力，但体力仅为最大值800点。如果玩家体力已经是800点，则提示玩家“体力已达最大值，无法购买”）
     * 3、定时活动赠送，每天12:00-13:00,18:00-19:00；玩家上线主界面会出现赠送体力活动按钮，玩家点击即可获得20点体力。 （数值可配置，领取后该按钮即消失，不可超过最大值。如果玩家体力已经是800点，则提示玩家“体力已达最大值，无法领取”） 4、突发事件答题获得体力
     * （不能超过体力最大值，无需提示） 5、谈判和精英谈判失败返还体力 （不能超过体力最大值，无需提示）
     *
     * @param amount       获得体力值数量
     * @param needNotify   是否在该函数内通知玩家货币改变，为true时信息格式为"您获得xx（货币单位）"， false时不在本函数内提示
     * @param reason       获得体力原因
     * @param detailReason 详细原因
     */
    public boolean recoverPower(int amount, boolean needNotify, MoneyLogReason reason, String detailReason) {
        int addPower = 0;
        // 更新最后一次给体力时间
        setLastGivePowerTime(Globals.getTimeService().now());
        // 获得当前体力值
        if (this.getPower() >= Globals.getGameConstants().getSysHumanPowerMax()) {
            // 如果当前体力大于系统体力值上限，代表用户购买了体力
            return false;
        } else {
            // 计算增加以后的体力值
            int afterPower = (int) this.getPower() + amount;
            // 如果当前体力值小于系统体力上限，只增加到体力的上限，其他不给增加
            if (afterPower >= Globals.getGameConstants().getSysHumanPowerMax()) {
                addPower = Globals.getGameConstants().getSysHumanPowerMax() - (int) this.getPower();
            } else {
                addPower = amount;
            }
            return CurrencyProcessor.instance.giveMoney(this, addPower, Currency.POWER, needNotify, reason, detailReason, true);
        }
    }
    
    /**
     * 设置最后一次登录时间
     *
     * @param lastLoginTime
     */
    public void setLastLoginTime(Timestamp lastLoginTime) {
        this.finalProps.setObject(RoleFinalProps.LAST_LOGIN, lastLoginTime);
//        this.setModified();
    }

    /**
     * 得到最后一次登录时间
     *
     * @return
     */
    public Timestamp getLastLoginTime() {
        return (Timestamp) this.finalProps.getObject(RoleFinalProps.LAST_LOGIN);
    }

    /**
     * 设置最后一次登出时间
     *
     * @param lastLogoutTime
     */
    public void setLastLogoutTime(Timestamp lastLogoutTime) {
        this.finalProps.setObject(RoleFinalProps.LAST_LOGOUT, lastLogoutTime);
    }

    /**
     * 得到最后一次登出时间
     *
     * @return
     */
    public Timestamp getLastLogoutTime() {
        return (Timestamp) this.finalProps.getObject(RoleFinalProps.LAST_LOGOUT);
    }


    /**
     * 记录最后一次升级时间点
     *
     * @param levelUpTimestamp
     */
    public void setLevelUpTimestamp(Long levelUpTimestamp) {
        this.baseStrProperties.setLong(RoleBaseStrProperties.LEVEL_UP_TIME, levelUpTimestamp);
        this.setModified();
    }

    /**
     * 返回最后一次升级时间点
     *
     * @return
     */
    public Long getLevelUpTimestamp() {
        return this.baseStrProperties.getLong(RoleBaseStrProperties.LEVEL_UP_TIME);
    }


    /**
     * 玩家是否在线的状态
     *
     * @return
     */
    public int getOnlineStatus() {
        return onlineStatus;
    }

    public void setOnlineStatus(int onlineStatus) {
        this.onlineStatus = onlineStatus;
    }

    /**
     * 得到最后一次登录ip
     *
     * @return
     */
    public String getLastLoginIp() {
        return (String) this.finalProps.getObject(RoleFinalProps.LAST_IP);
    }

    /**
     * 设置最后一次登录IP
     *
     * @param lastLoginIp
     */
    public void setLastLoginIp(String lastLoginIp) {
        this.finalProps.setString(RoleFinalProps.LAST_IP, lastLoginIp);
//        this.setModified();
    }

    public long getCreateTime() {
        return this.finalProps.getLong(RoleFinalProps.CREATE_TIME);
    }

    public void setCreateTime(long time) {
        this.finalProps.setLong(RoleFinalProps.CREATE_TIME, time);
        this.setModified();
    }

    public long getGold() {
        return baseStrProperties.getLong(RoleBaseStrProperties.GOLD);
    }

    public void setGold(long gold) {
        this.baseStrProperties.setLong(RoleBaseStrProperties.GOLD, gold);
        this.setModified();
    }

    public long getGold2() {
        return baseStrProperties.getLong(RoleBaseStrProperties.GOLD2);
    }

    public void setGold2(long gold2) {
        this.baseStrProperties.setLong(RoleBaseStrProperties.GOLD2, gold2);
        this.setModified();
    }

    /**
     * 充值时，更新玩家累计充值、今日充值、最后一次充值时间等充值相关的数据
     *
     * @param chargeDiamond
     */
    public void onCharge(int chargeDiamond) {
        // 参数检查
        if (chargeDiamond <= 0) {
            // 记录错误日志
            Loggers.humanLogger.error("#Human#onCharge#chargeDiamond is invalide!chargeDiamond=" +
                    chargeDiamond + ";passportId=" + getPassportId() + ";humanId=" + getCharId());
            return;
        }

        // 更新累计充值
        setTotalCharge(getTotalCharge() + chargeDiamond);

        long now = Globals.getTimeService().now();
        long lastChargeTime = 0;
        if (getLastChargeTime() != null) {
            lastChargeTime = getLastChargeTime().getTime();
        }

        // 更新今日充值
        if (TimeUtils.isSameDay(lastChargeTime, now)) {
            setTodayCharge(getTodayCharge() + chargeDiamond);
        } else {
            setTodayCharge(chargeDiamond);
        }

        // 更新本周充值
        if (TimeUtils.isInSameWeek(lastChargeTime, now)) {
            setWeekCharge(getWeekCharge() + chargeDiamond);
        } else {
            setWeekCharge(chargeDiamond);
        }

        // 更新本月充值
        if (TimeUtils.isInSameMonth(lastChargeTime, now)) {
            setMonthCharge(getMonthCharge() + chargeDiamond);
        } else {
            setMonthCharge(chargeDiamond);
        }

        // 更新最后一次充值时间
        setLastChargeTime(new Timestamp(now));
        this.setModified();
    }

    public void setLastChargeTime(Timestamp lastChargeTime) {
        this.finalProps.setObject(RoleFinalProps.LAST_CHARGE_TIME, lastChargeTime);
        this.setModified();
    }

    public Timestamp getLastChargeTime() {
        return (Timestamp) this.finalProps.getObject(RoleFinalProps.LAST_CHARGE_TIME);
    }

    /**
     * 得到最后一次到达vip等级的时间
     *
     * @return
     */
    public Timestamp getLastVipTime() {
        return (Timestamp) this.finalProps.getObject(RoleFinalProps.LAST_VIP_TIME);
    }

    /**
     * 设置最后一次到达vip等级的时间
     *
     * @param lastVipTime
     */
    public void setLastVipTime(Timestamp lastVipTime) {
        this.finalProps.setObject(RoleFinalProps.LAST_VIP_TIME, lastVipTime);
        this.setModified();
    }

    public int getPhoto() {
        return baseIntProperties.getPropertyValue(RoleBaseIntProperties.PHOTO);
    }

    public void setPhoto(int photo) {
        baseIntProperties.setPropertyValue(RoleBaseIntProperties.PHOTO, photo);
        this.setModified();
    }

    /**
     * 获取模型Id，前台显示用的
     *
     * @return
     */
    public String getModelId() {
        String modelId = "";
        if (getPetManager() != null &&
                getPetManager().getLeader() != null &&
                getPetManager().getLeader().getTemplate() != null) {
            modelId = getPetManager().getLeader().getTemplate().getModelId();
        }
        return modelId;
    }

    public void updateTemplateRelatedAttr(int leaderTplId) {
        this.setSex(leaderTplId);
        this.setJobType(leaderTplId);
        //this.setxinfa(1);
    }

    /**
     * 获取玩家性别
     *
     * @return
     */
    public Sex getSex() {
    	Sex sex = Sex.FEMALE;
    	if (getPetManager() != null && getPetManager().getLeader() != null && 
    			getPetManager().getLeader().getTemplate() != null) {
			sex = getPetManager().getLeader().getTemplate().getSex();
		}
        return sex;
    }

    public void setSex(int leaderTplId) {
//        PetTemplate petTpl = Globals.getTemplateCacheService().get(leaderTplId, PetTemplate.class);
//        if (null == petTpl) {
//            Loggers.humanLogger.error("#Human#setSex#PetTemplate is null!tplId=" + leaderTplId);
//            return;
//        }
//        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.SEX, petTpl.getSexId());
    }

    /**
     * 获取玩家的职业类型
     *
     * @return 如果是非法数据则可能返回null
     */
    public JobType getJobType() {
        return JobType.valueOf(this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.JOB_TYPE));
    }

    public void setJobType(int leaderTplId) {
        PetTemplate petTpl = Globals.getTemplateCacheService().get(leaderTplId, PetTemplate.class);
        if (null == petTpl) {
            Loggers.humanLogger.error("#Human#setJobType#PetTemplate is null!tplId=" + leaderTplId);
            return;
        }
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.JOB_TYPE, petTpl.getJobId());
    }

    /**
     * 获取玩家（主将）模板Id
     *
     * @return
     */
    public int getTplId() {
        int tplId = 0;
        if (this.getPetManager() != null &&
                this.getPetManager().getLeader() != null &&
                this.getPetManager().getLeader().getTemplate() != null) {
            tplId = this.getPetManager().getLeader().getTemplate().getId();
        }
        return tplId;
    }

    public void setSysBond(long sysbond) {
        this.baseStrProperties.setLong(RoleBaseStrProperties.SYS_BOND, sysbond);
        long bond = this.getBond();
        this.baseStrProperties.setLong(RoleBaseStrProperties.ALL_BOND, sysbond + bond);
        this.setModified();
    }

    public long getSysBond() {
        return this.baseStrProperties.getLong(RoleBaseStrProperties.SYS_BOND);
    }

    public void setBond(long bond) {
        this.baseStrProperties.setLong(RoleBaseStrProperties.BOUD, bond);
        long sysBond = this.getSysBond();
        this.baseStrProperties.setLong(RoleBaseStrProperties.ALL_BOND, bond + sysBond);
        this.setModified();
    }

    public long getBond() {
        return this.baseStrProperties.getLong(RoleBaseStrProperties.BOUD);
    }

    /**
     * 获取当天的总充值数量
     *
     * @return
     */
    public int getTodayCharge() {
        long now = Globals.getTimeService().now();
        long lastChargeTime = 0;
        if (getLastChargeTime() != null) {
            lastChargeTime = getLastChargeTime().getTime();
        }
        if (!TimeUtils.isSameDay(lastChargeTime, now)) {
            return 0;
        }
        return this.finalProps.getInt(RoleFinalProps.TODAY_CHARGE);
    }

    /**
     * 设置当天的总充值数量
     *
     * @param value
     */
    public void setTodayCharge(int value) {
        this.finalProps.setInt(RoleFinalProps.TODAY_CHARGE, value);
        this.onModified();
    }

    /**
     * 获取总充值数量
     *
     * @return
     */
    public int getTotalCharge() {
        return this.finalProps.getInt(RoleFinalProps.TOTAL_CHARGE);
    }

    /**
     * 设置本周的总充值数量
     *
     * @param value
     */
    public void setWeekCharge(int value) {
        this.finalProps.setInt(RoleFinalProps.WEEK_CHARGE, value);
        this.onModified();
    }

    /**
     * 获取本周总充值数量
     *
     * @return
     */
    public int getWeekCharge() {
        return this.finalProps.getInt(RoleFinalProps.WEEK_CHARGE);
    }

    /**
     * 设置本月的总充值数量
     *
     * @param value
     */
    public void setMonthCharge(int value) {
        this.finalProps.setInt(RoleFinalProps.MONTH_CHARGE, value);
        this.onModified();
    }

    /**
     * 获取本月充值数量
     *
     * @return
     */
    public int getMonthCharge() {
        return this.finalProps.getInt(RoleFinalProps.MONTH_CHARGE);
    }

    /**
     * 设置总充值数量
     *
     * @param value
     */
    public void setTotalCharge(int value) {
        this.finalProps.setInt(RoleFinalProps.TOTAL_CHARGE, value);
        this.onModified();
    }

    /**
     * 获取能否改名的标记
     *
     * @return
     */
    public int getCanRename() {
        return this.finalProps.getInt(RoleFinalProps.CAN_RENAME);
    }

    public void setCanRename(int value) {
        this.finalProps.setInt(RoleFinalProps.CAN_RENAME, value);
        this.onModified();
    }

    /**
     * 获取角色所属服务器Id
     *
     * @return
     */
    public int getServerId() {
        return this.finalProps.getInt(RoleFinalProps.SERVERID);
    }

    public void setServerId(int value) {
        this.finalProps.setInt(RoleFinalProps.SERVERID, value);
        this.onModified();
    }


    /**
     * 获得总在线时长 (分钟)
     *
     * @return
     */
    public int getTotalMinute() {
        return this.finalProps.getInt(RoleFinalProps.TOTAL_MINUTE);
    }

    /**
     * 设置总在线时长
     *
     * @param totalOnlineMinute
     */
    public void setTotalMinute(int totalOnlineMinute) {
        this.finalProps.setInt(RoleFinalProps.TOTAL_MINUTE, totalOnlineMinute);
    }

    /**
     * 获得vip等级
     *
     * @return value
     */
    public int getVipLevel() {
        return Globals.getVipService().getCurVipLevel(getUUID());
    }

    /**
     * 设置vip级别
     *
     * @param value
     */
    public void setVipLevel(int value) {
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.VIP_LEVEL, value);
    }

    public void initInventory() {
        inventory = new Inventory(this);
    }

    /**
     * 获取已开启的背包个数
     */
    public int getHadOpenPrimBagNum() {
        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.HAD_OPEN_PRIM_BAG_NUM);
    }

    /**
     * 设置开启的背包个数
     */
    public void setHadOpenPrimBagNum(int hadOpenPrimBagNum) {
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.HAD_OPEN_PRIM_BAG_NUM, hadOpenPrimBagNum);
        this.onModified();
    }

    /**
     * 获取主背包总数
     */
    public int getPrimBagNum() {
        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.PRIM_BAG_NUM);
    }

    /**
     * 设置主背包总数
     */
    public void setPrimBagNum(int primBagNum) {
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.PRIM_BAG_NUM, primBagNum);
    }

    /**
     * 获取临时背包总数
     */
    public int getTempBagNum() {
        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.TEMP_BAG_NUM);
    }

    /**
     * 设置临时背包总数
     */
    public void setTempBagNum(int tempBagNum) {
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.TEMP_BAG_NUM, tempBagNum);
    }
    
//    /**
//     * 获取仓库总数
//     */
//    public int getStoreBagNum() {
//        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.STORE_BAG_NUM);
//    }
//
//    /**
//     * 设置仓库总数
//     */
//    public void setStoreBagNum(int storeBagNum) {
//        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.STORE_BAG_NUM, storeBagNum);
//    }
    
    /**
     * 获取仓库开启格子次数（页数）
     */
    public int getStoreOpenNum() {
        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.STORE_OPEN_NUM);
    }

    /**
     * 设置仓库开启格子次数（页数）
     */
    public void setStoreOpenNum(int storeOpenNum) {
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.STORE_OPEN_NUM, storeOpenNum);
    }

    /**
     * 取当前拥有的武将最大数量
     *
     * @return
     */
    public int getFormationOwnMaxPet() {
        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.FORMATION_OWN_PET_NUM);
    }

    /**
     * 设置可拥有武将最大数量--军衔初始化设置
     *
     * @param maxNum
     */
    public void setFormationOwnMaxPet(int maxNum) {
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.FORMATION_OWN_PET_NUM, maxNum);
        this.setModified();
    }

    /**
     * 获取玩家当前场景Id对应的场景类型
     *
     * @return 可能返回null
     */
    public SceneTypeEnum getSceneType() {
        SceneTypeEnum sceneTypeEnum = null;
        SceneTemplate sceneTpl = Globals.getTemplateCacheService().get(getSceneId(), SceneTemplate.class);
        if (null != sceneTpl) {
            sceneTypeEnum = SceneTypeEnum.valueOf(sceneTpl.getDistTypeId());
        }
        return sceneTypeEnum;
    }

    /**
     * 获取玩家当前的场景Id
     *
     * @return
     */
    public int getSceneId() {
        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.SCENE_ID);
    }

    /**
     * 设置当前的场景Id，如果新的场景Id是城市场景，则更新最近一次的城市场景Id
     *
     * @param sceneId
     */
    public void setSceneId(int sceneId) {
        if (Loggers.humanLogger.isDebugEnabled()) {
            Loggers.humanLogger.debug("#Human#setSceneId#sceneId=" + sceneId + ";humanId=" + getUUID());
        }
        // 如果新的场景Id是城市Id，则更新最近的城市场景Id
        if (Globals.getSceneService().isCityId(sceneId)) {
            if (Loggers.humanLogger.isDebugEnabled()) {
                Loggers.humanLogger.debug("#Human#setSceneId#setLastCitySceneId=" + sceneId + ";humanId=" + getUUID());
            }
            setLastCitySceneId(sceneId);
        }
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.SCENE_ID, sceneId);
        this.setModified();
    }

    /**
     * 最近一次的城市场景Id，登录或从活动场景退出时，需要用到此Id
     * 因为玩家参加活动时，会进入活动场景，但登陆的时候必须回到城市场景，所以新加此字段记录
     *
     * @return
     */
    public int getLastCitySceneId() {
        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.LAST_CITY_SCENE_ID);
    }

    /**
     * 设置玩家最近一次的城市场景Id，在{@link #setSceneId}方法中调用
     *
     * @param sceneId
     */
    public void setLastCitySceneId(int sceneId) {
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.LAST_CITY_SCENE_ID, sceneId);
        this.setModified();
    }

    @Override
    public int getLevel() {
        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.LEVEL);
    }

    @Override
    public void setLevel(int level) {
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.LEVEL, level);
        this.onModified();
    }

    public Country getCountryType() {
        Country country = Country.valueOf(getCountry());
        if (null == country) {
            country = Country.NO_COUNTRY;
        }
        return country;
    }

    /**
     * XXX 该字段用于记录log是否合法
     * @return
     */
    public int getCountry() {
        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.COUNTRY_ID);
    }

    public void setCountry(int country) {
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.COUNTRY_ID, country);
        this.onModified();
    }

    /**
     * 获取VIP状态
     *
     * @return
     */
    public int getVipState() {
        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.VIP_STATE);
    }

    public void setVipState(int vipState) {
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.VIP_STATE, vipState);
    }

    /**
     * 军衔俸禄领取时间
     *
     * @return
     */
    public long getArmyTitleSalaryTime() {
        return this.finalProps.getLong(RoleFinalProps.ARMY_TITLE_SALARY_TIME);
    }

    public void setArmyTitleSalaryTime(long time) {
        this.finalProps.setLong(RoleFinalProps.ARMY_TITLE_SALARY_TIME, time);
        this.setModified();
    }

    public Inventory getInventory() {
        return inventory;
    }

    public long getAllBond() {
        return baseStrProperties.getLong(RoleBaseStrProperties.ALL_BOND);
    }

    public void setAllBond(long allBond) {
        this.baseStrProperties.setLong(RoleBaseStrProperties.ALL_BOND, allBond);
    }

    public void resetAllBand() {
        long sysBond = this.getSysBond();
        long bond = this.getBond();
        this.baseStrProperties.setLong(RoleBaseStrProperties.ALL_BOND, sysBond + bond);
    }

    public String getCookieValue() {
        Player player = this.getPlayer();
        if (player == null) {
            return null;
        }
        return player.getCookieValue();
    }

    public void setScene(Scene scene) {
        this.scene = scene;
    }

    public Scene getScene() {
        return scene;
    }

    /**
     * 武将管理器
     *
     * @return
     */
    public PetManager getPetManager() {
        return petManager;
    }


    /**
     * 确认框管理器
     *
     * @return
     */
    public ConsumeConfirmManager getConsumeConfirmManager() {
        return consumeConfirmManager;
    }


    /**
     * 关系管理器
     *
     * @return
     */
    public RelationManager getRelationManager() {
        return relationManager;
    }

    /**
     * 行为管理器
     *
     * @return
     */
    public BehaviorManager getBehaviorManager() {
        return behaviorManager;
    }

    /**
     * 获取冷却队列管理器
     *
     * @return
     */
    public CdManager getCdManager() {
        return this.cdManager;
    }

    /**
     * 获取绑定Id的行为管理器
     *
     * @return
     */
    public BindIdBehaviorManager getBindIdBehaviorManager() {
        return this.bindIdBehaviorManager;
    }

    /**
     * 对话框操作管理器
     *
     * @return
     */
    public StaticHandlelHolder getStaticHandlelHolder() {
        return staticHandlelHolder;
    }

    /**
     * 获取冷却队列操作次数重置时间, 返回值为整点小时数
     *
     * @return
     */
    public int getCdOpCountResetTime() {
        return this.finalProps.getInt(RoleFinalProps.CD_OP_COUNT_RESET_TIME);
    }


    /**
     * 获得军令
     *
     * @return value
     */
    public long getPower() {
        return this.baseStrProperties.getLong(RoleBaseStrProperties.POWER);
    }

    /**
     * 设置军令
     *
     * @param value
     */
    public void setPower(long value) {
        this.baseStrProperties.setLong(RoleBaseStrProperties.POWER, value);
        this.onModified();
    }
    
    /**
     * 获得技能点数
     *
     * @return
     */
    public long getSkillPoint() {
        return this.baseStrProperties.getLong(RoleBaseStrProperties.SKILL_POINT);
    }

    /**
     * 设置技能点数
     *
     * @param value
     */
    public void setSkillPoint(long value) {
        this.baseStrProperties.setLong(RoleBaseStrProperties.SKILL_POINT, value);
        this.onModified();
    }

    /**
     * 获取声望
     *
     * @return
     */
    public long getHonor() {
        return this.baseStrProperties.getLong(RoleBaseStrProperties.HONOR);
    }

    /**
     * 设置声望
     *
     * @param value
     */
    public void setHonor(long value) {
        this.baseStrProperties.setLong(RoleBaseStrProperties.HONOR, value);
        this.onModified();
    }

    /**
     * 获取礼券
     *
     * @return
     */
    public long getGiftBond() {
        return this.baseStrProperties.getLong(RoleBaseStrProperties.GIFT_BOND);
    }

    /**
     * 设置礼券
     *
     * @param value
     */
    public void setGiftBond(long value) {
        this.baseStrProperties.setLong(RoleBaseStrProperties.GIFT_BOND, value);
        this.onModified();
    }

    /**
     * 获取活力值
     *
     * @return
     */
    public long getEnergy() {
        return this.baseStrProperties.getLong(RoleBaseStrProperties.ENERGY);
    }

    /**
     * 设置活力值
     *
     * @param value
     */
    public void setEnergy(long value) {
        this.baseStrProperties.setLong(RoleBaseStrProperties.ENERGY, value);
        this.onModified();
    }
    
    /**
     * 获取红包钱
     *
     * @return
     */
    public long getRedEnvelope() {
    	return this.baseStrProperties.getLong(RoleBaseStrProperties.RED_ENVELOPE);
    }
    
    /**
     * 设置红包钱
     *
     * @param value
     */
    public void setRedEnvelope(long value) {
    	this.baseStrProperties.setLong(RoleBaseStrProperties.RED_ENVELOPE, value);
    	this.onModified();
    }

    public long getEternalCostMoney() {
        return this.finalProps.getLong(RoleFinalProps.ETERNAL_COST_MONEY);
    }

    public void setEternalCostMoney(long value) {
        this.finalProps.setLong(RoleFinalProps.ETERNAL_COST_MONEY, value);
        this.onModified();
    }

    public MailBox getMailbox() {
        return mailbox;
    }
    
	/**
     * 获得最后一次给军令时间
     *
     * @return
     */
    public long getLastGivePowerTime() {
        return this.finalProps.getLong(RoleFinalProps.LAST_GIVE_POWER_TIME);
    }

    /**
     * 设置最后一次给军令时间
     *
     * @param value
     */
    public void setLastGivePowerTime(long value) {
        this.finalProps.setLong(RoleFinalProps.LAST_GIVE_POWER_TIME, value);
        this.setModified();
    }
    
    /**
     * 获得最后一次给双倍经验点时间
     *
     * @return
     */
    public long getLastGiveDoublePointTime() {
    	return this.finalProps.getLong(RoleFinalProps.LAST_GIVE_DOUBLE_POINT_TIME);
    }
    
    /**
     * 设置最后一次给双倍经验点时间
     *
     * @param value
     */
    public void setLastGiveDoublePointTime(long value) {
    	this.finalProps.setLong(RoleFinalProps.LAST_GIVE_DOUBLE_POINT_TIME, value);
    	this.setModified();
    }

    /**
     * 获取最后一次获得技能点数的时间
     *
     * @return
     */
    public long getLastGiveSkillPointTime() {
        return this.finalProps.getLong(RoleFinalProps.LAST_GIVE_SKILL_POINT_TIME);
    }

    /**
     * 设置最后一次获得技能点数的时间
     *
     * @param value
     */
    public void setLastGiveSkillPointTime(long value) {
        this.finalProps.setLong(RoleFinalProps.LAST_GIVE_SKILL_POINT_TIME, value);
        this.setModified();
    }

    /**
     * 获取token登录参数1,
     *
     * @return
     */
    public long getTokenParam1() {
        return this.finalProps.getLong(RoleFinalProps.TOKEN_PARAM1);
    }

    public void setTokenParam1(long value) {
        this.finalProps.setLong(RoleFinalProps.TOKEN_PARAM1, value);
//        this.setModified();
    }

    /**
     * 获取token登录参数2
     *
     * @return
     */
    public String getTokenParam2() {
        return this.finalProps.getString(RoleFinalProps.TOKEN_PARAM2);
    }

    public void setTokenParam2(String value) {
        this.finalProps.setString(RoleFinalProps.TOKEN_PARAM2, value);
//        this.setModified();
    }

    private void updateToken() {
        long now = Globals.getTimeService().now();
        String guid = KeyUtil.UUIDKey();
        setTokenParam1(now);
        setTokenParam2(guid);

        String token = getMD5Token();
        //给客户端发消息，更新token
        sendMessage(new GCUpdateToken(getPassportId(), getUUID(), token));

        Loggers.loginLogger.info("#Player#updateToken#p1=" + getTokenParam1() +
                ";p2=" + getTokenParam2() +
                ";token=" + token);
    }

    private String getMD5Token() {
        return Globals.genToken(getPassportId(), getUUID(), getTokenParam1(), getTokenParam2());
    }

    /**
     * 构建玩家场景信息
     *
     * @return
     */
    public String buildScenePlayerJsonStr() {
        ScenePlayerInfo scenePlayerInfo = new ScenePlayerInfo();
        // 构建场景中显示的玩家信息
        scenePlayerInfo.setUuid(this.getUUID());
        scenePlayerInfo.setRoleName(this.getName());
        scenePlayerInfo.setLevel(this.getLevel());
        scenePlayerInfo.setPic(this.getPhoto());
        scenePlayerInfo.setLeaderQuality(this.getLeaderQualityId());
        scenePlayerInfo.setX(this.getX());
        scenePlayerInfo.setY(this.getY());

//		// 坐骑图片
//		scenePlayerInfo.setBaobaoPic(Globals.getHorseService().getCurrentHorsePic(this));
        // 国家-new
        scenePlayerInfo.setCountry(this.getCountry());
//		// 军衔
//		scenePlayerInfo.setMilitaryRank(getMilitaryRank());

        // TODO 假数据-- 暂时没有
        List<Integer> titleIdList = new ArrayList<Integer>();
        titleIdList.add(1);
        titleIdList.add(2);
        scenePlayerInfo.setTitleIdList(titleIdList);
        scenePlayerInfo.setPetPic(1);
//		// 战甲avatar
//		scenePlayerInfo.setArmourAvatar(Globals.getArmourService().getArmour(this));
//		scenePlayerInfo.setArmourHunAvatar(Globals.getArmourService().getArmourHun(this));
//		
//		// qq信息
//		scenePlayerInfo.setYellowVipLevel(player.getQqDataManager().getYellowVipLevel());
//		scenePlayerInfo.setIsYellowVip(player.getQqDataManager().getIsYellowVip());
//		scenePlayerInfo.setIsYellowYearVip(player.getQqDataManager().getIsYellowYearVip());
//		scenePlayerInfo.setIsYellowHighVip(player.getQqDataManager().getIsYellowHighVip());
//		// 打坐
//		scenePlayerInfo.setIsPractice(player.getHuman().getPracticeManager().isOnPractice()? 1 : 0);
        return scenePlayerInfo.toJsonStr();
    }

    /**
     * 发送确认对话框消息, 客户端接收到该消息后会显示一个含有确定和取消按钮的提示框
     *
     * @param tag
     * @param hasOptionDialog 是否有“不再提示”勾选框，true有，false没有
     * @param langId
     * @param params
     */
    public void sendOptionDialogMessage(String tag, boolean hasOptionDialog, Integer langId, Object... params) {
        // 获取语言服务
        LangService langServ = Globals.getLangService();

        // 提示内容
        String optionContent = langServ.readSysLang(langId, params);

        GCShowOptionDlg optionDlg = new GCShowOptionDlg();
        optionDlg.setTitle("");
        optionDlg.setContent(optionContent);
        // 确定按钮文本
        optionDlg.setOkText(langServ.readSysLang(LangConstants.CONFIRM_OK_TEXT));
        // 取消按钮文本
        optionDlg.setCancelText(langServ.readSysLang(LangConstants.CONFIRM_CANCEL_TEXT));
        if (hasOptionDialog) {
            optionDlg.setConfirmText(langServ.readSysLang(LangConstants.CONFIRM_CONFIRM_TEXT));
        } else {
            optionDlg.setConfirmText("");
        }
        optionDlg.setTag(tag);
        this.sendMessage(optionDlg);
    }

    /**
     * 发送确认对话框消息, 客户端接收到该消息后会显示一个含有确定和取消按钮的提示框
     *
     * @param tag         标记
     * @param title       标题
     * @param okText      确定按钮文本内容
     * @param cancelText  取消按钮文本内容
     * @param confirmText 提示框文本内容
     * @param langId      内容多语言
     * @param params      内容参数
     */
    public void sendOptionDialogMessage(String tag, String title, String okText, String cancelText, String confirmText, Integer langId,
                                        Object... params) {
        // 获取语言服务
        LangService langServ = Globals.getLangService();

        // 提示内容
        String optionContent = langServ.readSysLang(langId, params);

        GCShowOptionDlg optionDlg = new GCShowOptionDlg();
        // 标题
        optionDlg.setTitle(title);
        // 内容
        optionDlg.setContent(optionContent);
        // 确定按钮文本
        optionDlg.setOkText(okText);
        // 取消按钮文本
        optionDlg.setCancelText(cancelText);
        optionDlg.setConfirmText(confirmText);
        optionDlg.setTag(tag);
        this.sendMessage(optionDlg);
    }

    /**
     * 是否选中不提示框1选中0不选中
     *
     * @param value
     */
    public void setConsumeConfirm(ConsumeConfirm consumeConfirm, boolean value) {
        this.getConsumeConfirmManager().setConfirmStatus(consumeConfirm, value);
        this.onModified();
    }

    /**
     * 是否选中"不再提示框"1选中，0不选中
     *
     * @return
     */
    public boolean getConsumeConfirm(ConsumeConfirm consumeConfirm) {
        //XXX FIXME 先去掉二次确认,都按已选中 不再提示 来
        return true;
//		return (this.getConsumeConfirmManager().getConfirmStatus(consumeConfirm) == 1);
    }

    /**
     * 错误提示，3秒消失
     *
     * @param content
     */
    public void sendErrorMessage(String content) {
        if (player != null) {
            player.sendErrorMessage(content);
        }
    }

    /**
     * 错误提示，3秒消失
     *
     * @param key
     */
    public void sendErrorMessage(Integer key) {
        if (player != null) {
            player.sendErrorMessage(key);
        }
    }

    /**
     * 错误提示，3秒消失
     *
     * @param key
     * @param params
     */
    public void sendErrorMessage(Integer key, Object... params) {
        if (player != null) {
            player.sendErrorMessage(key, params);
        }
    }

//	/**
//	 * 显示状态变化 
//	 */
//	public void sendShowAttrChange(){
//		GCSetShowAttrChangeState resp = new GCSetShowAttrChangeState();
////		resp.setState(ResultType.SUCC.getIndex());
//		this.sendMessage(resp);
//	}
//	
//	/**
//	 * 关闭显示状态变化
//	 */
//	public void sendCloseAttrChange(){
//		GCSetShowAttrChangeState resp = new GCSetShowAttrChangeState();
////		resp.setState(ResultType.FAIL.getIndex());
//		this.sendMessage(resp);
//	}

    /**
     * 聊天框出现的基本系统提示
     *
     * @param content
     * @return
     */
    public void sendSystemMessage(String content) {
        if (player != null) {
            player.sendSystemMessage(content);
        }
    }

    /**
     * 聊天框出现的基本系统提示
     *
     * @param key
     */
    public void sendSystemMessage(Integer key) {
        if (player != null) {
            player.sendSystemMessage(key);
        }
    }

    /**
     * 聊天框出现的基本系统提示
     *
     * @param key
     * @param params
     */
    public void sendSystemMessage(Integer key, Object... params) {
        if (player != null) {
            player.sendSystemMessage(key, params);
        }
    }

    /**
     * 聊天通告类
     *
     * @param content
     * @return
     */
    public void sendChatMessage(String content) {
        if (player != null) {
            player.sendChatMessage(content);
        }
    }

    /**
     * 聊天通告类
     *
     * @param key
     */
    public void sendChatMessage(Integer key) {
        if (player != null) {
            player.sendChatMessage(key);
        }
    }

    /**
     * 聊天通告类
     *
     * @param key
     * @param params
     */
    public void sendChatMessage(Integer key, Object... params) {
        if (player != null) {
            player.sendChatMessage(key, params);
        }
    }

    /**
     * 屏幕中央出现的系统通告,滚屏
     *
     * @param content
     * @return
     */
    public void sendNoticeMessage(String content) {
        if (player != null) {
            player.sendNoticeMessage(content);
        }
    }

    /**
     * 屏幕中央出现的系统通告,滚屏
     *
     * @param key
     */
    public void sendNoticeMessage(Integer key) {
        if (player != null) {
            player.sendNoticeMessage(key);
        }
    }

    /**
     * 屏幕中央出现的系统通告,滚屏
     *
     * @param key
     * @param params
     */
    public void sendNoticeMessage(Integer key, Object... params) {
        if (player != null) {
            player.sendNoticeMessage(key, params);
        }
    }

    /**
     * 弹窗确定
     *
     * @param content
     * @return
     */
    public void sendBoxMessage(String content) {
        if (player != null) {
            player.sendBoxMessage(content);
        }
    }

    /**
     * 弹窗确定
     *
     * @param key
     */
    public void sendBoxMessage(Integer key) {
        if (player != null) {
            player.sendBoxMessage(key);
        }
    }

    /**
     * 弹窗确定
     *
     * @param key
     * @param params
     */
    public void sendBoxMessage(Integer key, Object... params) {
        if (player != null) {
            player.sendBoxMessage(key, params);
        }
    }

    /**
     * 普通任务管理器
     *
     * @return
     */
    public CommonTaskManager getCommonTaskManager() {
        return commonTaskManager;
    }

    /**
     * 返回是不是正在做的任务
     * 如果以后有新的任务管理器，需要在这里加上
     *
     * @param taskId
     * @return
     */
    public boolean isDoingTask(Integer taskId) {
        if (taskId <= 0) {
            return false;
        }
        return commonTaskManager.isDoing(taskId);
    }

    //	/**
//	 * 国家
//	 * 
//	 * @return
//	 */
//	public CountryManager getCountryManager() {
//		return countryManager;
//	}
//	
    public OnlineGiftManager getOnlineGiftManager() {
        return this.onlineGiftManager;
    }

    public MysteryShopManager getMysteryShopManager() {
        return mysteryShopManager;
    }
    
    public TimeLimitManager getTimeLimitManager() {
		return timeLimitManager;
	}

	public TowerManager getTowerManager(){
    	return towerManager;
    }

    public MallManager getMallManager() {
        return mallManager;
    }
    
    public CorpsCultivateManager getCorpsCultivateManager() {
		return corpsCultivateManager;
	}

	public CorpsAssistManager getCorpsAssistManager() {
		return corpsAssistManager;
	}
	
	public EasyPlotDungeonManager getEasyPlotDungeonManager() {
		return easyPlotDungeonManager;
	}

	public HardPlotDungeonManager getHardPlotDungeonManager() {
		return hardPlotDungeonManager;
	}
	
	public PromoteManager getPromoteManager() {
		return promoteManager;
	}

	/**
     * 获取战斗力
     *
     * @return
     */
    public int getFightPower() {
        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.FIGHT_POWER);
    }

    /**
     * 设置战斗力
     *
     * @param power
     */
    public void setFightPower(int power) {
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.FIGHT_POWER, power);
        this.setModified();
    }

    /**
     * 计算并更新玩家总战斗力
     */
    public void updateFightPower() {
//		int old = getFightPower();
//		// 根据玩家阵型上的武将，计算其战斗力总和
//		int totalFightPower = 0;
//		long[] formationArr = this.getFormationManager().getFormationArray();
//		for (int i = 0; i < formationArr.length; i++) {
//			long petId = formationArr[i];
//			Pet pet = this.getPetManager().getNormalPetByUUID(petId);
//			if (pet == null) {
//				continue;
//			}
//			totalFightPower += pet.getFightPower();
//		}
//		
//		// 心法提升
//		totalFightPower += Globals.getMindService().getMindAddFightPower(getLastOpenedMindId());
//		
//		// 军衔，累加
//		totalFightPower += Globals.getArmyTitleService().getArmyTitleAddFightPower(getMilitaryRank());
//		
//		// 坐骑的战斗力，不累加，需要判断当前是否骑乘
//		if (getHorseManager() != null && getHorseManager().getHorse() != null) {
//			if (getHorseManager().getHorse().isHorseRiding()) {
//				totalFightPower += getHorseManager().getHorse().getHorseStarTemplate().getCapacity();
//			}
//		}
//		
//		// 更新
//		setFightPower(totalFightPower);
//		// 通知前台
//		snapChangedProperty(true);
//		
//		if (totalFightPower != old) {
//			// 战力变化事件监听
//			Globals.getEventService().fireEvent(new FightPowerChangeEvent(this, old, totalFightPower));
//		}
    }

    /**
     * 获取主将品质
     *
     * @return
     */
    public PetQuality getLeaderQuality() {
        PetQuality quality = PetQuality.WHITE;
        if (null != PetQuality.valueOf(getLeaderQualityId())) {
            quality = PetQuality.valueOf(getLeaderQualityId());
        }
        return quality;
    }

    /**
     * 获取主将品质Id
     *
     * @return
     */
    public int getLeaderQualityId() {
        if (getPetManager().getLeader() != null) {
            return getPetManager().getLeader().getColor();
        }
        return 0;
    }

    /**
     * 累计登录天数（通过行为管理器记录）
     *
     * @return
     */
    public boolean addLoginDays() {
        if (getBehaviorManager() == null) {
            return false;
        }
        long now = Globals.getTimeService().now();
        long lastOpTime = getBehaviorManager().getLastOpTime(BehaviorTypeEnum.TOTAL_LOGIN_DAYS);
        // 如果最后一次登录时间小于今天，则计数+1
        if (lastOpTime < TimeUtils.getBeginOfDay(now)) {
            boolean flag = getBehaviorManager().doBehavior(BehaviorTypeEnum.TOTAL_LOGIN_DAYS);
            if (flag) {
                // 登录天数增加的事件监听
                Globals.getEventService().fireEvent(new LoginDaysAddEvent(this));
            }
            //发消息通知前台
            sendMessage(new GCLoginDays(getTotalLoginDays()));
            return flag;
        }
        return false;
    }

    /**
     * 获取玩家总登录天数（通过行为管理器获取）
     *
     * @return
     */
    public int getTotalLoginDays() {
        int days = 0;
        if (getBehaviorManager() != null) {
            days = getBehaviorManager().getCount(BehaviorTypeEnum.TOTAL_LOGIN_DAYS);
        }
        return days;
    }

    @Override
    public void heartBeat() {
        this.hbTaskExecutor.onHeartBeat();
        mailbox.onHeartBeat();
        offlineRewardManager.onHeartBeat();
        timeLimitManager.onHeatBeat();
        
        //XXX 道具的尽量放在后边，前面的可能有道具变化，这里会发道具更新列表消息
        inventory.onHeartBeat();
        //同步位置信息
        sendLocationInfo();
    }

    public long getRoleUUID() {
        return roleUUID;
    }

    /**
     * 获取离线奖励管理器
     *
     * @return
     */
    public OfflineRewardManager getOfflineRewardManager() {
        return offlineRewardManager;
    }

    /**
     * 获取功能管理器
     *
     * @return
     */
    public HumanFuncManager getFuncManager() {
        return funcManager;
    }

    public PubTaskManager getPubTaskManager() {
        return pubTaskManager;
    }

    public TheSweeneyTaskManager getTheSweeneyTaskManager() {
        return theSweeneyTaskManager;
    }


    public TreasureMapManager getTreasureMapManager() {
        return treasureMapManager;
    }
	
	public ForageTaskManager getForageTaskManager() {
		return forageTaskManager;
	}
	
    public CorpsTaskManager getCorpsTaskManager() {
        return corpsTaskManager;
    }
    
    public TimeLimitMonsterManager getTimeLimitMonsterManager() {
		return timeLimitMonsterManager;
	}

	public TimeLimitNpcManager getTimeLimitNpcManager() {
		return timeLimitNpcManager;
	}
	
	public Day7TaskManager getDay7TaskManager() {
		return day7TaskManager;
	}
	
	public SiegeDemonNormalTaskManager getSiegeDemonNormalTaskManager() {
		return siegeDemonNormalTaskManager;
	}

	public SiegeDemonHardTaskManager getSiegeDemonHardTaskManager() {
		return siegeDemonHardTaskManager;
	}

	public BattleManager getBattleManager() {
		return battleManager;
	}

	@Override
    public Human getOwner() {
        return this;
    }


    public int getPrizeNum() {
        return prizeNum;
    }

    public void setPrizeNum(int prizeNum) {
        this.prizeNum = prizeNum;
    }


    /**
     * 获取手机验证管理器
     *
     * @return
     */
    public SmsCheckCodeManager getSmsCheckCodeManager() {
        return smsCheckCodeManager;
    }


//	/**
//	 * 当前军衔可以拥有的最大武将数量
//	 * 如果当前军衔为0，表示没有军衔，在配置的constant.js中取
//	 * @return
//	 */
//	public int getCanOwnePetMaxNum() {
//		return Globals.getGameConstants().getPetMaxOwnNum();
//	}

    public ChatManager getChatManager() {
        return chatManager;
    }

    
    public WingManager getWingManager() {
		return wingManager;
	}

	public SpecOnlineGiftManager getSpecOnlineGiftManager() {
        return specOnlineGiftManager;
    }

    /**
     * 获取玩家（领主）经验值
     */
    public long getExp() {
        return this.baseStrProperties.getLong(RoleBaseStrProperties.EXP);
    }

    /**
     * 设置玩家（领主）经验值
     */
    public void setExp(long exp) {
        this.baseStrProperties.setLong(RoleBaseStrProperties.EXP, exp);
        this.setModified();
    }

    /**
     * 获取酒馆等级
     *
     * @return
     */
    public int getPubLevel() {
        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.PUB_LEVEL);
    }

    /**
     * 设置酒馆等级
     *
     * @param level
     */
    public void setPubLevel(int level) {
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.PUB_LEVEL, level);
        this.setModified();
    }

    /**
     * 获取酒馆等级
     *
     * @return
     */
    public int getMineLevel() {
        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.MINE_LEVEL);
    }

    /**
     * 设置采矿等级
     *
     * @param level
     */
    public void setMineLevel(int level) {
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.MINE_LEVEL, level);
        this.setModified();
    }

    /**
     * 获取采矿经验
     *
     * @return
     */
    public long getPubExp() {
        return this.baseStrProperties.getLong(RoleBaseStrProperties.PUB_EXP);
    }

    /**
     * 设置酒馆经验
     *
     * @param exp
     */
    public void setPubExp(long exp) {
        this.baseStrProperties.setLong(RoleBaseStrProperties.PUB_EXP, exp);
        this.setModified();
    }

    /**
     * 获取自动战斗主将默认行为
     *
     * @return
     */
    public int getAutoFightAction() {
        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.AUTO_FIGHT_ACTION);
    }

    public void setAutoFightAction(int actionId) {
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.AUTO_FIGHT_ACTION, actionId);
        this.setModified();
    }

    /**
     * 获取是否显示玩家的称号 0不显示,1显示
     *
     * @return
     */
    public int getTitleDis() {

        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.DIS_TITLE);
    }

    public void setTitleDis(int distitle) {
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.DIS_TITLE, distitle);
//        this.setModified();
    }

    /**
     * 获取称号
     *
     * @return
     */
    public Integer getTitle() {

        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.TITLE);
    }

    public void setTitle(Integer titleid) {
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.TITLE, titleid);
//        this.setModified();
    }

    public String getTitleName() {
        return this.baseStrProperties.getString(RoleBaseStrProperties.TITLE_NAME);
    }

    public void setTitleName(String titleName){
        this.baseStrProperties.setString(RoleBaseStrProperties.TITLE_NAME,titleName);
//        this.setModified();
    }

    /**
     * 获取自动战斗宠物默认行为
     *
     * @return
     */
    public int getPetAutoFightAction() {
        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.PET_AUTO_FIGHT_ACTION);
    }

    public void setPetAutoFightAction(int actionId) {
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.PET_AUTO_FIGHT_ACTION, actionId);
        this.setModified();
    }

    /**
     * 玩家地图Id
     *
     * @return
     */
    public int getMapId() {
        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.MAP_ID);
    }

    public void setMapId(int mapId) {
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.MAP_ID, mapId);
        this.setModified();
    }

    /**
     * 玩家x坐标，tile位置
     *
     * @return
     */
    public int getTileX() {
        return tileX;
    }

    public void setTileX(int tileX) {
        this.tileX = tileX;
    }

    /**
     * 玩家y坐标，tile位置
     *
     * @return
     */
    public int getTileY() {
        return tileY;
    }

    public void setTileY(int tileY) {
        this.tileY = tileY;
    }

    /**
     * 玩家像素坐标x
     *
     * @return
     */
    public int getX() {
        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.X);
    }

    public void setX(int x) {
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.X, x);
        this.setModified();
    }

    /**
     * 玩家像素坐标y
     *
     * @return
     */
    public int getY() {
        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.Y);
    }

    public void setY(int y) {
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.Y, y);
        this.setModified();
    }

    /**
     * 备用玩家地图Id
     *
     * @return
     */
    public int getBackMapId() {
        return this.finalProps.getInt(RoleFinalProps.BACK_MAPID);
    }

    public void setBackMapId(int mapId) {
        this.finalProps.setInt(RoleFinalProps.BACK_MAPID, mapId);
        this.setModified();
    }

    /**
     * 备用玩家像素坐标x
     *
     * @return
     */
    public int getBackX() {
        return this.finalProps.getInt(RoleFinalProps.BACK_X);
    }

    public void setBackX(int x) {
        this.finalProps.setInt(RoleFinalProps.BACK_X, x);
        this.setModified();
    }

    /**
     * 备用玩家像素坐标y
     *
     * @return
     */
    public int getBackY() {
        return this.finalProps.getInt(RoleFinalProps.BACK_Y);
    }

    public void setBackY(int y) {
        this.finalProps.setInt(RoleFinalProps.BACK_Y, y);
        this.setModified();
    }


    public int getMoves() {
        return moves;
    }

    public void setMoves(int moves) {
        this.moves = moves;
    }

    public int getNextMoves() {
        return nextMoves;
    }

    public void setNextMoves(int nextMoves) {
        this.nextMoves = nextMoves;
    }

    /**
     * 最近一次移动的时间
     *
     * @return
     */
    public long getLastMoveTime() {
        return this.baseStrProperties.getLong(RoleBaseStrProperties.LAST_MOVE_TIME);
    }

    public void setLastMoveTime(long lastMoveTime) {
        this.baseStrProperties.setLong(RoleBaseStrProperties.LAST_MOVE_TIME, lastMoveTime);
        this.setModified();
    }

    /**
     * 玩家进入地图，更新数据
     *
     * @param gameMap
     */
    public void onEnterMap(AbstractGameMap gameMap, boolean isLogin, int initX, int initY) {
        int mapId = gameMap.getId();
        //当前正在此地图中，则直接返回不处理
        if (getMapId() == mapId) {
        	//登录时，设置第一次的移动数据
        	if (isLogin) {
        		addMoveInfo(new MoveInfo(getMapId(), Globals.getTimeService().now(), getX(), getY()));
        	}
            return;
        }

        //地图id
        setMapId(mapId);
        long now = Globals.getTimeService().now();
        if (!isLogin) {
        	//非登录时
            //位置
            setX(initX);
            setY(initY);
        
		    //非登录时，进入地图后，更新备用地图
		    if (gameMap.isEternal()) {
		        setBackMapId(mapId);
		        setBackX(getX());
		        setBackY(getY());
		        
		        //如果玩家是队长，则更新队伍备用地图
		        if (Globals.getTeamService().isTeamLeader(getCharId())) {
		        	Team team = Globals.getTeamService().getHumanTeam(getCharId());
					team.setBackMapId(getBackMapId());
					team.setBackX(getBackX());
					team.setBackY(getBackY());
		        }
		    }
        } else {
        	//登录时，如果登录的是备用地图，则当前点位置重置为备用点
        	if (getBackMapId() == mapId) {
        		setX(getBackX());
                setY(getBackY());
        	}
        }
        
        Point tilePoint = MapUtil.image2TileCoord(getX(), getY());
        setTileX(tilePoint.x);
        setTileY(tilePoint.y);

        //移动步数
        setMoves(0);
        setNextMoves(0);
        //最后一次移动时间
        setLastMoveTime(now);
        //设置移动数据
        addMoveInfo(new MoveInfo(getMapId(), now, getX(), getY()));
    }

    public void onLeaveMap() {
        //清除其他玩家变化数据列表
        locInfoList.clear();
        //TODO 其他需要在离开地图时处理的

    }

    /**
     * 位置变化时，设置移动步数
     *
     * @param x
     * @param y
     */
    public void onPositionChanging(int x, int y) {
        double distance = Math.sqrt(Math.abs(y - this.getY())
                * Math.abs(y - this.getY()) + Math.abs(x - this.getX())
                * Math.abs(x - this.getX()));

        double unit = 72;
        // double unit = 36;

        int move = (int) (distance / unit + 0.5);
        if (move < 1) {
            move = 1;
        }

        this.setNextMoves(move);
    }

    public void onPositionChanged() {
        //TODO 位置变化，打断一些状态，如采集，交易等

    }

    /**
     * 这里加了个数限制，最大MapDef.MAP_PLAYER_CHANGED_LIST_MAX 个
     * @param info
     */
    public void addLocationInfo(MapPlayerInfo info) {
    	if (locInfoList.size() < MapDef.MAP_PLAYER_CHANGED_LIST_MAX) {
    		locInfoList.add(info);
    	}
//		sendLocationInfo();
    }

    /**
     * 调用这个方法的外层需要自己控制，locInfoList的大小不要超过 MapDef.MAP_PLAYER_CHANGED_LIST_MAX 个
     * @param lst
     */
    public void addLocationInfoList(List<MapPlayerInfo> lst) {
        if (lst != null && !lst.isEmpty()) {
            locInfoList.addAll(lst);
//			sendLocationInfo();
        }
    }

    public void sendLocationInfo() {
    	Globals.getHumanPosService().sendLocationInfo(this);
    }
    
    /**
     * 立即给玩家发送缓存的地图人数数据
     */
    public void sendLocationInfoAtOnce() {
        if (!locInfoList.isEmpty()) {
            this.sendMessage(MapMsgBuilder.buildMapPlayerInfoList(getMapId(), locInfoList));
            locInfoList.clear();
            lastSendLocInfoTime = Globals.getTimeService().now();
        }
    }
    
    public int getCurLocInfoListSize() {
    	return this.locInfoList.size();
    }
    
    public long getLastSendLocInfoTime() {
    	return this.lastSendLocInfoTime;
    }

    /**
     * 玩家是否在战斗中
     *
     * @return
     */
    public boolean isInBattle() {
        return this.getLastBattleId() > 0;
    }

    /**
     * 获取最后一次战斗id
     *
     * @return
     */
    public int getLastBattleId() {
        return this.finalProps.getInt(RoleFinalProps.LAST_BATTLE_ID);
    }

    public void setLastBattleId(int battleId) {
        this.finalProps.setInt(RoleFinalProps.LAST_BATTLE_ID, battleId);
        this.setModified();
    }

    /**
     * 获取最后一次战斗开始时间
     *
     * @return
     */
    public long getLastBattleTime() {
        return this.finalProps.getLong(RoleFinalProps.LAST_BATTLE_TIME);
    }

    public void setLastBattleTime(long battleTime) {
        this.finalProps.setLong(RoleFinalProps.LAST_BATTLE_TIME, battleTime);
        this.setModified();
    }

    /**
     * 获取最后一次战斗结束时间
     *
     * @return
     */
    public long getLastBattleEndTime() {
        return this.finalProps.getLong(RoleFinalProps.LAST_BATTLE_END_TIME);
    }

    public void setLastBattleEndTime(long battleEndTime) {
        this.finalProps.setLong(RoleFinalProps.LAST_BATTLE_END_TIME, battleEndTime);
        this.setModified();
    }

    /**
     * 开始战斗时，更新玩家数据
     *
     * @param battleId
     */
    public void onStartBattle(int battleId) {
        setMoves(0);
        setNextMoves(0);

        setLastBattleId(battleId);
        setLastBattleTime(Globals.getTimeService().now());
    }

    /**
     * 战斗结束时更新玩家数据
     *
     * @param battleId
     */
    public void onBattleEnd(int battleId) {
        if (this.getLastBattleId() == battleId) {
            this.setLastBattleId(0);
            this.setLastBattleEndTime(Globals.getTimeService().now());
        } else {
            Loggers.humanLogger.error("wrong battle id!humanId=" + getCharId() +
                    ";humanBattleId=" + this.getLastBattleId() + ";battleId=" + battleId);
        }
    }

    /**
     * 获取玩家任务监听器
     *
     * @return
     */
    public TaskListener<Human> getTaskListener() {
        return taskListener;
    }

    /**
     * 获取心法等级
     *
     * @return
     */
    public int getMainSkillLevel() {
        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.MAINSKILL_LEVEL);
    }

    /**
     * 设置心法等级
     *
     * @param level
     */
    public void setMainSkillLevel(int level) {
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.MAINSKILL_LEVEL, level);
        this.setModified();
    }
    
    /**
     * 获取心法类型
     *
     * @return
     */
    public PetDef.MainSkillType getRunningMainSkillType() {
        PetDef.MainSkillType type = PetDef.MainSkillType.valueOf(getRunningMainSkillTypeId());
        if (type != null &&
        		this.getJobType() != null &&
        		this.getJobType().containsMainSkillType(type)) {
            return type;
        }
        return null;
    }
    
    public int getRunningMainSkillTypeId() {
    	return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.MAINSKILL_TYPE);
    }

    /**
     * 设置心法类型
     *
     * @param mainSkillTypeId
     */
    public void setRunningMainSkillType(int mainSkillTypeId) {
        //修改当前的运行状态
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.MAINSKILL_TYPE, mainSkillTypeId);
        this.setModified();
    }

    /**
     * 玩家是否处于任意战斗中
     *
     * @return
     */
    public boolean isInAnyBattle() {
        if (isInBattle()) {
            return true;
        }
        if (Globals.getPvpService().isPlayerInPvp(getCharId())) {
            return true;
        }
        if (Globals.getTeamService().isInTeamBattle(getCharId())) {
            return true;
        }
        if (Globals.getArenaService().isInBattle(getCharId())) {
        	return true;
        }
        return false;
    }
    
    /**
     * 玩家是否处于护送粮草中
     * @return
     */
    public boolean isDoingForageTask(){
    	if (getOwner().getForageTaskManager().isDoing()) {
			return true;
		}
    	return false;
    }

    /**
     * 获得当前帮贡值
     *
     * @return
     */
    public Integer getContribution() {
        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.CURRENT_CORPS_CONTRIBUTION);
    }

    /**
     * 设置帮贡，如果小于0 则为0
     *
     * @param target
     */
    public void setContribution(Integer target) {
        if (target < 0) {
            this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.CURRENT_CORPS_CONTRIBUTION, 0);
        }
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.CURRENT_CORPS_CONTRIBUTION, target);
        this.setModified();
    }

    /**
     * 获得历史总帮贡值
     *
     * @return
     */
    public Integer getTotalContribution() {
        return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.TOTAL_CORPS_CONTRIBUTION);
    }

    /**
     * 设置历史总帮贡，如果小于0 则为0
     *
     * @param target
     */
    public void setTotalContribution(Integer target) {
        if (target < 0) {
            this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.TOTAL_CORPS_CONTRIBUTION, 0);
        }
        this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.TOTAL_CORPS_CONTRIBUTION, target);
        this.setModified();
    }

    @Override
    public int getTeamMemberNum() {
        return Globals.getTeamService().getHumanTeamMemberNum(getCharId());
    }

    public MineManager getMineManager() {
        return mineManager;
    }

    public void addMoveInfo(MoveInfo info) {
    	this.moveInfoQueue.add(info);
    }
    
    public MoveInfo getMoveInfo(int index) {
    	return this.moveInfoQueue.get(index);
    }
    
    public boolean isMoveQueueEmpty() {
    	return this.moveInfoQueue.empty();
    }
    
    public int getMoveQueueSize() {
    	return this.moveInfoQueue.size();
    }
    
    /**
	 * 获取新手引导管理器
	 * @return
	 */
	public GuideManager getGuideManager() {
		return guideManager;
	}

	public long getLastCachedTime() {
		return lastCachedTime;
	}

	public void setLastCachedTime(long lastCachedTime) {
		this.lastCachedTime = lastCachedTime;
	}

	public int getCacheFlag() {
        return this.finalProps.getInt(RoleFinalProps.CACHE_FLAG);
    }

	public void updateCacheFlag() {
		int cacheFlag = getCacheFlag() == 0 ? 1 : 0;
		setCacheFlag(cacheFlag);
	}
	
    public void setCacheFlag(int cacheFlag) {
        this.finalProps.setInt(RoleFinalProps.CACHE_FLAG, cacheFlag);
        this.onModified();
    }
}
