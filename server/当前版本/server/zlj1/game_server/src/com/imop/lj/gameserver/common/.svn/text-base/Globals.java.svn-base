package com.imop.lj.gameserver.common;

import java.io.File;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.Collection;
import java.util.HashSet;
import java.util.Set;

import com.imop.lj.common.constants.GameConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.common.model.GameServerStatus;
import com.imop.lj.common.model.template.DirtyWordsTemplate;
import com.imop.lj.common.model.template.DirtyWordsTemplateVO;
import com.imop.lj.common.model.template.NameDirtyWordsTemplate;
import com.imop.lj.core.async.AsyncService;
import com.imop.lj.core.client.NIOClient;
import com.imop.lj.core.config.ConfigUtil;
import com.imop.lj.core.config.ServerConfig;
import com.imop.lj.core.local.LocalService;
import com.imop.lj.core.local.LocalService.AsyncLocalService;
import com.imop.lj.core.local.LocalService.SynLocalService;
import com.imop.lj.core.msg.DataType;
import com.imop.lj.core.msg.recognizer.BaseMessageRecognizer;
import com.imop.lj.core.orm.DBService;
import com.imop.lj.core.schedule.ScheduleService;
import com.imop.lj.core.schedule.ScheduleServiceImpl;
import com.imop.lj.core.server.IMessageProcessor;
import com.imop.lj.core.server.MessageDispatcher;
import com.imop.lj.core.session.OnlineSessionService;
import com.imop.lj.core.time.SystemTimeService;
import com.imop.lj.core.time.TimeService;
import com.imop.lj.core.util.MD5Util;
import com.imop.lj.core.util.ServerVersion;
import com.imop.lj.core.uuid.UUIDService;
import com.imop.lj.core.uuid.UUIDServiceImpl;
import com.imop.lj.core.uuid.UUIDType;
import com.imop.lj.db.model.DbVersion;
import com.imop.lj.db.model.msg.EntityTypeFactory;
import com.imop.lj.gameserver.GameServer;
import com.imop.lj.gameserver.across.GameServerToWorldServerIoHandler;
import com.imop.lj.gameserver.across.ServerClientConnectionCallback;
import com.imop.lj.gameserver.across.WorldServerSession;
import com.imop.lj.gameserver.across.msg.WGMessageRecognizer;
import com.imop.lj.gameserver.acrossserver.WGlobals;
import com.imop.lj.gameserver.activity.ActivityService;
import com.imop.lj.gameserver.activityui.ActivityUIService;
import com.imop.lj.gameserver.allocate.AllocateActivityStorageService;
import com.imop.lj.gameserver.arena.ArenaService;
import com.imop.lj.gameserver.battle.BattleService;
import com.imop.lj.gameserver.battle.FightUnitService;
import com.imop.lj.gameserver.battle.UnitService;
import com.imop.lj.gameserver.battle.pvp.PvpService;
import com.imop.lj.gameserver.battlereport.BattleReportService;
import com.imop.lj.gameserver.broadcast.BroadcastService;
import com.imop.lj.gameserver.cache.BaseModelCache;
import com.imop.lj.gameserver.cache.service.TemplateCacheService;
import com.imop.lj.gameserver.cd.CdService;
import com.imop.lj.gameserver.cdkeygift.CDKeyService;
import com.imop.lj.gameserver.charge.ChargeLogicalProcessor;
import com.imop.lj.gameserver.charge.ChargePrizeService;
import com.imop.lj.gameserver.charge.IpadChargeService;
import com.imop.lj.gameserver.chat.ChatService;
import com.imop.lj.gameserver.chat.WordFilterService;
import com.imop.lj.gameserver.chat.impl.WordFilterServiceImpl;
import com.imop.lj.gameserver.command.CommandProcessorService;
import com.imop.lj.gameserver.common.config.GameServerConfig;
import com.imop.lj.gameserver.common.db.AsyncServiceImpl;
import com.imop.lj.gameserver.common.db.GameDaoService;
import com.imop.lj.gameserver.common.i18n.LangService;
import com.imop.lj.gameserver.common.i18n.LangServiceImpl;
import com.imop.lj.gameserver.common.log.LogService;
import com.imop.lj.gameserver.common.service.NoticeTipsInfoService;
import com.imop.lj.gameserver.common.service.SystemNoticeService;
import com.imop.lj.gameserver.common.timer.MilliHeartbeatTimer;
import com.imop.lj.gameserver.constant.ConstantService;
import com.imop.lj.gameserver.corps.CorpsService;
import com.imop.lj.gameserver.corpsassist.CorpsAssistService;
import com.imop.lj.gameserver.corpsboss.CorpsBossService;
import com.imop.lj.gameserver.corpscultivate.CorpsCultivateService;
import com.imop.lj.gameserver.corpstask.CorpsTaskService;
import com.imop.lj.gameserver.corpswar.CorpsWarService;
import com.imop.lj.gameserver.dataeye.DataEyeService;
import com.imop.lj.gameserver.day7target.Day7TargetService;
import com.imop.lj.gameserver.devilincarnate.DevilIncarnateService;
import com.imop.lj.gameserver.dirtywords.DirtyFilterNetService;
import com.imop.lj.gameserver.equip.EquipService;
import com.imop.lj.gameserver.exam.ExamService;
import com.imop.lj.gameserver.exp.service.ExpService;
import com.imop.lj.gameserver.foragetask.ForageTaskService;
import com.imop.lj.gameserver.func.FuncService;
import com.imop.lj.gameserver.goodactivity.GoodActivityService;
import com.imop.lj.gameserver.guide.GuideService;
import com.imop.lj.gameserver.human.HumanAssistantService;
import com.imop.lj.gameserver.human.HumanCacheService;
import com.imop.lj.gameserver.human.HumanPosService;
import com.imop.lj.gameserver.human.HumanService;
import com.imop.lj.gameserver.human.event.EventService;
import com.imop.lj.gameserver.humanskill.HumanSkillService;
import com.imop.lj.gameserver.item.ItemService;
import com.imop.lj.gameserver.lifeskill.MineService;
import com.imop.lj.gameserver.localscribe.LocalScribeService;
import com.imop.lj.gameserver.logserver.LogServerService;
import com.imop.lj.gameserver.mail.service.MailService;
import com.imop.lj.gameserver.mail.service.SysMailService;
import com.imop.lj.gameserver.mall.MallService;
import com.imop.lj.gameserver.map.MapService;
import com.imop.lj.gameserver.map.PetIslandService;
import com.imop.lj.gameserver.marry.MarryService;
import com.imop.lj.gameserver.moduledata.ModuleDataService;
import com.imop.lj.gameserver.moneyreport.MoneyReportService;
import com.imop.lj.gameserver.mysteryshop.MysteryShopService;
import com.imop.lj.gameserver.npc.NpcService;
import com.imop.lj.gameserver.nvn.NvnService;
import com.imop.lj.gameserver.offlinedata.OfflineDataService;
import com.imop.lj.gameserver.offlinereward.OfflineRewardService;
import com.imop.lj.gameserver.onlinegift.OnlineGiftService;
import com.imop.lj.gameserver.otherplatform.OtherplatformConstants;
import com.imop.lj.gameserver.overman.OvermanService;
import com.imop.lj.gameserver.page.PageingDataService;
import com.imop.lj.gameserver.pet.PetService;
import com.imop.lj.gameserver.pet.PetSkillService;
import com.imop.lj.gameserver.player.LoginLogicalProcessor;
import com.imop.lj.gameserver.player.OnlinePlayerService;
import com.imop.lj.gameserver.player.auth.DBUserAuthImpl;
import com.imop.lj.gameserver.player.auth.LocalUserAuthImpl;
import com.imop.lj.gameserver.player.auth.TokenUserAuthImpl;
import com.imop.lj.gameserver.player.auth.UserAuth;
import com.imop.lj.gameserver.plotdungeon.PlotDungeonService;
import com.imop.lj.gameserver.prize.PrizeService;
import com.imop.lj.gameserver.probe.ProbeService;
import com.imop.lj.gameserver.promote.PromoteService;
import com.imop.lj.gameserver.pubtask.PubTaskService;
import com.imop.lj.gameserver.quest.CommonTaskService;
import com.imop.lj.gameserver.rank.RankService;
import com.imop.lj.gameserver.redenvelope.RedEnvelopeService;
import com.imop.lj.gameserver.relation.RelationService;
import com.imop.lj.gameserver.reward.GradeRewardService;
import com.imop.lj.gameserver.reward.RewardService;
import com.imop.lj.gameserver.reyun.ReyunService;
import com.imop.lj.gameserver.role.properties.amend.AmendService;
import com.imop.lj.gameserver.sample.SampleService;
import com.imop.lj.gameserver.scene.SceneService;
import com.imop.lj.gameserver.sealdemon.SealDemonService;
import com.imop.lj.gameserver.show.ShowService;
import com.imop.lj.gameserver.siegedemon.SiegeDemonService;
import com.imop.lj.gameserver.siegedemontask.SiegeDemonTaskService;
import com.imop.lj.gameserver.startup.GameExecutorService;
import com.imop.lj.gameserver.startup.GameMessageProcessor;
import com.imop.lj.gameserver.startup.MinaGameClientSession;
import com.imop.lj.gameserver.status.ServerStatusService;
import com.imop.lj.gameserver.status.service.CheckSessionService;
import com.imop.lj.gameserver.team.TeamService;
import com.imop.lj.gameserver.teampvp.TeamPvpService;
import com.imop.lj.gameserver.thesweeneytask.TheSweeneyTaskService;
import com.imop.lj.gameserver.time.task.TaskService;
import com.imop.lj.gameserver.timeevent.TimeQueueService;
import com.imop.lj.gameserver.timeevent.msg.SysTimeEventServiceStart;
import com.imop.lj.gameserver.timelimit.TimeLimitService;
import com.imop.lj.gameserver.timelimit.monster.TimeLimitMonsterTaskService;
import com.imop.lj.gameserver.timelimit.npc.TimeLimitNpcTaskService;
import com.imop.lj.gameserver.title.TitleService;
import com.imop.lj.gameserver.tower.TowerService;
import com.imop.lj.gameserver.trade.TradeService;
import com.imop.lj.gameserver.treasuremap.TreasureMapService;
import com.imop.lj.gameserver.util.MapUtil;
import com.imop.lj.gameserver.vip.VipService;
import com.imop.lj.gameserver.wallow.WallowLogicalProcessor;
import com.imop.lj.gameserver.wallow.WallowService;
import com.imop.lj.gameserver.wing.WingService;
import com.imop.lj.gameserver.wizardraid.WizardRaidService;
import com.imop.lj.probe.PIProbeCollector;
import com.imop.lj.server.common.ServerType;
import com.renren.games.qqapi.ApiRequestHelper;

import net.sf.json.JSONArray;


/**
 * 各种全局的业务管理器、公共服务实例的持有者，负责各种管理器的初始化和实例的获取
 */
public class Globals {
    /**
     * 服务器配置信息
     */
    private static GameServerConfig config;

    private static TimeService timeService;

    /**
     * 在线玩家管理器
     */
    private static OnlinePlayerService onlinePlayerService;
    /**
     * 主消息处理器，运行在主线程中，处理玩家登陆退出以及服务器内部消息
     */
    private static MessageDispatcher<GameMessageProcessor> messageProcessor;

    /**
     * 定时任务管理器
     */
    private static ScheduleService scheduleService;

    /**
     * 会话管理器
     */
    private static OnlineSessionService<MinaGameClientSession> sessionService;

    /**
     * 系统线程池服务
     */
    private static GameExecutorService executorService;

    private static GameServerStatus serverStatus;

    private static ServerStatusService serverStatusService;

    /**
     * 异步操作管理器
     */
    private static AsyncService asyncService;

    /**
     * 登陆逻辑处理器
     */
    private static LoginLogicalProcessor loginLogicalProcessor;

    /**
     * 平台接口服务
     */
    private static LocalService localService;

//	/** 脏话过滤器 */
//	private static DirtFilterService dirtFilterService;
    /**
     * 多语言管理器
     */
    private static LangService langService;
    /**
     * 全局事件管理器
     */
    private static EventService eventService;
    // /** 模板数据管理器 */
    // private static TemplateService templateService;
    /**
     * 数据访问对象管理器
     */
    private static GameDaoService daoService;

    private static SceneService sceneService;

    private static UUIDService uuidService;

    private static CdService cdService;
    /**
     * 通过logserver记录日志的服务
     */
    private static LogService logService;

    /**
     * 全局常量数据
     */
    private static GameConstants gameConstants;
    /**
     * 道具模板生成实例管理器
     */
    private static ItemService itemService;

    /**
     * 聊天不良信息过滤服务
     */
    private static WordFilterService wordFilterService;

    /**
     * 模块数据存储服务
     */
    private static ModuleDataService moduleDataService;
    /**
     * 聊天管理器
     */
    private static ChatService chatService;
    /**
     * 定时事件服务
     */
    private static TimeQueueService timeQueueService;
    /**
     * 性能采集管理
     */
    private static ProbeService probeService;
    /**
     * 充值业务逻辑
     */
    private static ChargeLogicalProcessor chargeLogicalProcessor;
    /**
     * Ipad 充值业务
     */
    private static IpadChargeService ipadChargeService;
    /**
     * 充值服务
     */
    private static ChargePrizeService chargePrizeService;
    /**
     * 角色辅助管理器
     */
    private static HumanAssistantService humanAssistantService;
    /**
     * 属性修正服务
     */
    private static AmendService amendService;
    /**
     * 防沉迷服务
     */
    private static WallowService wallowService;
    /**
     * local新汇报服务
     */
    private static LocalScribeService localScribeService;
    /**
     * 任务管理器
     */
    private static TaskService taskService;
    /**
     * 缓存所有模板数据
     */
    private static TemplateCacheService templateCacheService;
    private static BaseModelCache baseModelCache;

    private static ExpService expService;

    /**
     * 分页管理器
     */
    private static PageingDataService pageingDataService;

    /**
     * 关系服务
     */
    private static RelationService relationService;

    /**
     * 玩家离线数据服务
     */
    private static OfflineDataService offlineDataService;

    /**
     * 武将服务
     */
    private static PetService petService;

    /**
     * 武将技能等服务
     */
    private static PetSkillService petSkillService;
    
    /**
     * 活动服务
     */
    private static ActivityService activityService;

    /**
     * 奖励服务
     */
    private static RewardService rewardService;
    /**
     * 评分奖励服务
     */
    private static GradeRewardService gradeRewardSerice;

    /**
     * 邮件服务
     */
    private static MailService mailService;
    /**
     * 全服邮件服务
     */
    private static SysMailService sysMailService;

    /**
     * 广播服务
     */
    private static BroadcastService broadcastService;

    /**
     * 在线礼包服务
     */
    private static OnlineGiftService onlineGiftService;

    /**
     * 离线奖励服务
     */
    private static OfflineRewardService offlineRewardService;

    /**
     * 功能服务
     */
    private static FuncService funcService;

    /**
     * 前台的常量服务
     */
    private static ConstantService constantService;

    /**
     * 奖励服务
     */
    private static PrizeService prizeService;

    /**
     * 神秘商店服务
     */
    private static MysteryShopService mysteryShopService;

    /**
     * 精彩活动服务
     */
    private static GoodActivityService goodActivityService;

    /**
     * 商城服务
     */
    private static MallService mallService;

    /**
     * 财报服务
     */
    private static MoneyReportService moneyReportService;

    /**
     * 脏语言过滤服务
     */
    private static DirtyFilterNetService dirFilterNetService;

    private static SystemNoticeService noticeService;

    private static HumanService humanService;

    /**
     * 采样服务
     */
    private static SampleService sampleService;

    /**
     * 定时检测非法session服务
     */
    private static CheckSessionService checkSessionService;

    /**
     * 自带logserver服务
     */
    private static LogServerService logServerService;

    /**
     * api
     */
    private static ApiRequestHelper apiRequestHelper;

    /**
     * 其他平台的配置文件
     */
    private static OtherplatformConstants otherplatformConstants;

    /**
     * GS与WS的会话
     */
    private static WorldServerSession worldServerSession;

    /**
     * cdkeyservice
     */
    private static CDKeyService cdKeyService;

    /**
     * commandProcessorService
     */
    private static CommandProcessorService commandProcessorService;

    /**
     * 合法的服务器Id集合，名称格式为 1001
     */
    private static Set<Integer> serverIdSet = new HashSet<Integer>();

    /**
     * 日志原因检测
     */
    private static LogReasonCheckService logReasonCheckService;

    private static UserAuth tokenUserAuth;

    /**
     * 数据汇报平台服务
     */
    private static DataEyeService dataEyeService;

    /**
     * 地图服务
     */
    private static MapService mapService;

    /**
     * 战报服务
     */
    private static BattleReportService battleReportService;
    /**
     * 战斗对象转化管理器
     */
    private static UnitService unitService;
    /**
     * 战斗管理器
     */
    private static BattleService battleService;
    /**
     * 战斗单位服务
     */
    private static FightUnitService fightUnitService;

    /**
     * npc服务
     */
    private static NpcService npcService;

    /**
     * 普通任务服务
     */
    private static CommonTaskService commonTaskService;

    /**
     * 装备服务
     */
    private static EquipService equipService;

    /**
     * 酒馆任务服务
     */
    private static PubTaskService pubTaskService;

    /**
     * 科举服务
     */
    private static ExamService examService;

    /**
     * 人物技能心法服务
     */
    private static HumanSkillService humanSkillService;

    /**
     * pvp服务
     */
    private static PvpService pvpService;

    /**
     * 交易行服务
     */
    private static TradeService tradeService;

    /**
     * 小信封提醒服务
     */
    private static NoticeTipsInfoService noticeTipsInfoService;

    /**
     * 宠物岛服务
     */
    private static PetIslandService petIslandService;
    
    /** 
     * 野外封妖服务
     */
    private static SealDemonService sealDemonService;
    
    /** 
     * 混世魔王服务
     */
    private static DevilIncarnateService devilIncarnateService;
    
    /** 
     * 限时活动服务
     */
    private static TimeLimitService timeLimitService;
    
    /** 
     * 限时杀怪服务
     */
    private static TimeLimitMonsterTaskService timeLimitMonsterTaskService;
    
    /** 
     * 限时挑战Npc服务
     */
    private static TimeLimitNpcTaskService timeLimitNpcTaskService;

    /**
     * 军团服务
     */
    private static CorpsService corpsService;
    
    /**
     * 剧情副本
     */
    private static PlotDungeonService plotDungeonService;
    
    /** 
     * 帮派修炼服务
     * */
    private static CorpsCultivateService corpsCultivateService;
    
    /** 
     * 帮派修炼服务
     * */
    private static CorpsAssistService corpsAssistService;
    
    /** 
     * 帮派红包服务
     * */
    private static RedEnvelopeService redEnvelopeService;
    
    /** 
     * 分配活动仓库服务
     * */
    private static AllocateActivityStorageService allocateActivityStorageService;

    /**
     * 活动UI服务
     */
    private static ActivityUIService activityUIService;

    /**
     * 组队服务
     */
    private static TeamService teamService;

    /**
     * 排行榜服务
     */
    private static RankService rankService;

    /**
     * 绿野仙踪服务
     */
    private static WizardRaidService wizardRaidService;

    /**
     * 绿野仙踪服务
     */
    private static MineService mineService;
    ;

    /**
     * 热云汇报服务
     */
    private static ReyunService reyunService;

    /**
     * 除暴安良任务服务
     */
    private static TheSweeneyTaskService theSweeneyTaskService;

    /**
     * 藏宝图服务
     */
    private static TreasureMapService treasureMapService;

    /**
     * 称号服务
     */
    private static TitleService titleService;

    /**
     * 护送粮草服务
     */
    private static ForageTaskService forageTaskService;

    /**
     * 组队pvp服务
     */
    private static TeamPvpService teamPvpService;

    /**
     * 军团战服务
     */
    private static CorpsWarService corpsWarService;

    /**
     * 师徒服务
     */
    private static OvermanService overmanService;
    
    /**
     * nvn联赛服务
     */
    private static NvnService nvnService;
    
    /**
     * 结婚服务
     */
    private static MarryService marryService;
    
    /**
     * 翅膀
     */
    private static WingService wingService;
    
    /**
     * 竞技场服务
     */
    private static ArenaService arenaService;
    
    /**
     * 帮派任务服务
     */
    private static CorpsTaskService corpsTaskService;
    
    /** 新手引导服务 */
	private static GuideService guideService;
	
	/** 提升服务 */
	private static PromoteService promoteService;
	
	/** vip服务 */
	private static VipService vipService;
	
	/** 通天塔服务 */
	private static TowerService towerService;
	
	/** 帮派boss服务 */
	private static CorpsBossService corpsBossService;
	
	/** 展示服务 */
	private static ShowService showService;

	private static HumanCacheService humanCacheService;

	/** 七日目标服务 */
	private static Day7TargetService day7TargetService;
	
	/** 玩家位置数据同步服务 */
	private static HumanPosService humanPosService;
	
	/** 围剿魔族任务服务 */
	private static SiegeDemonTaskService siegeDemonTaskService;
	
	/** 围剿魔族服务 */
	private static SiegeDemonService siegeDemonService;
	
    /**
     * 服务器启动时调用，初始化所有管理器实例
     *
     * @param cfg
     * @throws Exception
     * @see GameServer
     */
    public static void init(GameServerConfig cfg) throws Exception {
        // 优先验证日志原因是否正确
        logReasonCheckService = new LogReasonCheckService();
        logReasonCheckService.init();

        config = cfg;
        initProbeCollector(config);
        gameConstants = initGameConstants();
        otherplatformConstants = initOtherplatformConstants();

        //首先初始化worldserver独有配置文件
        if (config.getWorldServerConfig().getServerType() == SharedConstants.AcrossServer_type) {
            Loggers.gameLogger.info("WGlobals.init()");
            WGlobals.init();

            //初始化worldserver的消息处理器
            messageProcessor = WGlobals.getMessageServerProcessor();
        } else {
            messageProcessor = buildMessageProcessor();
        }

        timeService = new SystemTimeService(true);
        MilliHeartbeatTimer.setTimeService(timeService);
        DataType.registerEntityClass(EntityTypeFactory.ITEMINFO);

        amendService = new AmendService();
        sessionService = new OnlineSessionService<MinaGameClientSession>();
        onlinePlayerService = new OnlinePlayerService(cfg.getMaxOnlineUsers());

        langService = LangServiceImpl.buildLangService(cfg);

        // 初始化logServer
        logServerService = new LogServerService();
        if (config.getSelfLogServer()) {
            logServerService.init();
        }

        // api初始化
        apiRequestHelper = new ApiRequestHelper(config.getApiRequestDomain());

        // 初始化data eye数据汇报平台
		dataEyeService = new DataEyeService();
		dataEyeService.init();
        reyunService = new ReyunService();
        reyunService.init();
        
        MapUtil.initMask();
        
        // XXX templateservice需要itemservice做支持
        itemService = new ItemService();
        itemService.init();
        // XXX templateCacheService会调用，所以在templateCacheService前初始化
        expService = new ExpService();

        // XXX 要将tempalteService传进模板缓存管理器中
        templateCacheService = new TemplateCacheService(
                cfg.getScriptDirFullPath(), cfg.isEncryptResource());
        templateCacheService.init();

        //地图数据初始化
        mapService = new MapService(cfg.getMapDirFullPath());
        mapService.init();

        //check地图的点
        mapService.checkMapPointRelated();

        //战斗服务
        unitService = new UnitService();
        battleService = new BattleService();

        // 战斗单位
        fightUnitService = new FightUnitService();
        fightUnitService.init();

        scheduleService = new ScheduleServiceImpl(messageProcessor, timeService);
        timeQueueService = new TimeQueueService();
        timeQueueService.init();
        executorService = new GameExecutorService();

        // 如果服务器
        if (config.getWorldServerConfig().isTurnOn() && config.getWorldServerConfig().getServerType() == SharedConstants.GameServer_type) {
            Loggers.gameLogger.info("buildWorldServerSession()");
            worldServerSession = buildWorldServerSession(config, executorService, messageProcessor, onlinePlayerService);
        }

        localService = new LocalService(cfg, cfg.getLocalKey());

        serverStatusService = new ServerStatusService();
        serverStatus = buildGameServerStatus(config);
        daoService = new GameDaoService(cfg);
        // 同步
        asyncService = new AsyncServiceImpl(10, 10, 10, 10, 10, 10, messageProcessor);

        UserAuth userAuth = buildUserAuth();
        loginLogicalProcessor = new LoginLogicalProcessor(userAuth,
                langService.getSysLangSerivce());

        tokenUserAuth = new TokenUserAuthImpl(daoService.getUserInfoDao(), langService.getSysLangSerivce());

        logService = new LogService(config.getLogConfig().getLogServerIp(),
                config.getLogConfig().getLogServerPort(),
                Integer.parseInt(config.getRegionId()), Integer.parseInt(config
                .getServerId()));
        uuidService = buildUUIDService(daoService.getDBService(), cfg);

        wordFilterService = new WordFilterServiceImpl();
//		moduleDataService = new ModuleDataService();
//		moduleDataService.init();
        // 如果是gameServer，则初始化本服合法的服务器集合
        if (config.getWorldServerConfig().getServerType() == SharedConstants.GameServer_type) {
            initServers(daoService);
        }

        //战报服务
        battleReportService = new BattleReportService(asyncService,
                timeService, scheduleService, config);

        chargeLogicalProcessor = new ChargeLogicalProcessor();
        chargeLogicalProcessor.init();

        cdService = new CdService();
        cdService.init();

        chatService = new ChatService();
        chatService.init();

        baseModelCache = new BaseModelCache();
        baseModelCache.init();

        sceneService = new SceneService(onlinePlayerService, uuidService,
                daoService);
        sceneService.init();

        eventService = buildEventService();

        humanAssistantService = new HumanAssistantService();
        humanAssistantService.init();

        wallowService = new WallowService(scheduleService,
                new WallowLogicalProcessor(), langService, onlinePlayerService);

        probeService = new ProbeService();

        taskService = new TaskService();
        taskService.init();

        // local新汇报服务
        localScribeService = new LocalScribeService();
        if (Globals.getServerConfig().isScribeOnTurn()) {
            localScribeService.start();
        }

        // 脏语言过滤服务
        dirFilterNetService = new DirtyFilterNetService(langService.getSysLangSerivce());
        dirFilterNetService.init();

        // 财报服务
        moneyReportService = new MoneyReportService();
        moneyReportService.init();

        // 活动服务
        activityService = new ActivityService();
        activityService.init();

        // 玩家离线数据服务
        offlineDataService = new OfflineDataService();
        offlineDataService.init();

        // 分页服务
        pageingDataService = new PageingDataService();
        pageingDataService.init();

        //玩家缓存服务
        humanCacheService = new HumanCacheService();

        // 关系服务
        relationService = new RelationService();

        // 武将服务
        petService = new PetService();
        petService.init();
        
        petSkillService = new PetSkillService();
        petSkillService.init();

        // 奖励服务
        rewardService = new RewardService();
        gradeRewardSerice = new GradeRewardService();

        // 邮件服务
        mailService = new MailService();
        mailService.init();
        // 全服邮件服务
        sysMailService = new SysMailService();
        sysMailService.init();

        // 广播服务
        broadcastService = new BroadcastService();

        // 在线礼包服务
        onlineGiftService = new OnlineGiftService();
        onlineGiftService.init();

        // 离线奖励服务
        offlineRewardService = new OfflineRewardService();

        // 功能服务
        funcService = new FuncService();
        funcService.init();

        //奖励服务
        prizeService = new PrizeService(scheduleService);
        prizeService.init();

        // 神秘商店服务
        mysteryShopService = new MysteryShopService();
        mysteryShopService.init();

        // 给前台的常量服务
        constantService = new ConstantService();
        constantService.init();

        // 精彩活动服务
        goodActivityService = new GoodActivityService();
        goodActivityService.init();

        // 商城服务
        mallService = new MallService();
        mallService.init();

        // 采样服务
        sampleService = new SampleService();
        sampleService.init();

        noticeService = new SystemNoticeService();
        noticeService.init();

        humanService = new HumanService();

        // 检查非法session的服务
        checkSessionService = new CheckSessionService();

        cdKeyService = new CDKeyService();
        cdKeyService.init();

        commandProcessorService = new CommandProcessorService();
        commandProcessorService.init();

        //npc服务
        npcService = new NpcService();
        //普通任务
        commonTaskService = new CommonTaskService();

        //七日目标服务
 		day7TargetService = new Day7TargetService();
 		day7TargetService.init();
 		
 		//围剿魔族任务服务
 		siegeDemonTaskService = new SiegeDemonTaskService();
 		siegeDemonTaskService.init();
 		
 		//围剿魔族服务
 		siegeDemonService = new SiegeDemonService();
 		siegeDemonService.init();
 		
        //装备服务
        equipService = new EquipService();
        equipService.init();

        //酒馆任务服务
        pubTaskService = new PubTaskService();

        //科举服务
        examService = new ExamService();
        examService.init();

        //人物技能心法服务
        humanSkillService = new HumanSkillService();
        humanSkillService.init();

        //pvp服务
        pvpService = new PvpService();

        //交易行服务
        tradeService = new TradeService();
        tradeService.init();

        //小信封
        noticeTipsInfoService = new NoticeTipsInfoService();

        //宠物岛
        petIslandService = new PetIslandService();
        //野外封妖
        sealDemonService = new SealDemonService();
        //混世魔王
        devilIncarnateService = new DevilIncarnateService();
        
        //限时活动
        timeLimitService = new TimeLimitService();
        
        //限时杀怪任务
        timeLimitMonsterTaskService = new TimeLimitMonsterTaskService();
        
        //限时挑战Npc任务
        timeLimitNpcTaskService = new TimeLimitNpcTaskService();

        // 军团服务
        corpsService = new CorpsService();
        corpsService.init();
        
        plotDungeonService = new PlotDungeonService();
        plotDungeonService.init();

        corpsCultivateService = new CorpsCultivateService();
        corpsCultivateService.init();
        
        corpsAssistService = new CorpsAssistService();
        corpsAssistService.init();
        
        redEnvelopeService = new RedEnvelopeService();
        redEnvelopeService.init();
        
        allocateActivityStorageService = new AllocateActivityStorageService();
        allocateActivityStorageService.init();
        
        // 活动UI服务
        activityUIService = new ActivityUIService();
        activityUIService.init();

        //队伍
        teamService = new TeamService();
        teamService.init();

        //组队pvp
        teamPvpService = new TeamPvpService();
        teamPvpService.init();

        // 排行榜
        rankService = new RankService();
        rankService.init();

        //绿野仙踪
        wizardRaidService = new WizardRaidService();

        //生活技能-采矿服务
        mineService = new MineService();
        mineService.init();


        //除暴安良任务服务
        theSweeneyTaskService = new TheSweeneyTaskService();

        //藏宝图服务
        treasureMapService = new TreasureMapService();

        //称号服务
        titleService = new TitleService();
        titleService.init();

        //护送粮草任务
        forageTaskService = new ForageTaskService();

        //军团战服务
        corpsWarService = new CorpsWarService();
        corpsWarService.init();

        //师徒服务
        overmanService = new OvermanService();
        overmanService.init();
        
        //nvn联赛
        nvnService = new NvnService();
        nvnService.init();
        
        //结婚服务
        marryService = new MarryService();
        marryService.init();
        
        //翅膀服务
        wingService = new WingService();
        wingService.init();
        
        //竞技场
        arenaService = new ArenaService();
        arenaService.init();
        
        corpsTaskService = new CorpsTaskService();
        corpsTaskService.init();
        
        //新手引导服务
 		guideService = new GuideService();
 		guideService.init();
 		
 		//提升服务
 		promoteService = new PromoteService();
 		promoteService.init();
 		
 		//通天塔服务
 		towerService = new TowerService();
 		towerService.init();

 		//vip服务
 		vipService = new VipService();
 		vipService.init();

 		//展示服务
 		showService = new ShowService();
 		
 		//帮派boss服务
 		corpsBossService = new CorpsBossService();
 		corpsBossService.init();
 		
 		//玩家位置同步服务
 		humanPosService = new HumanPosService();
 		
 		
        // ***********在此之前初始化************
        Globals.checkAfterInit();

        /** 跨服Globals初始化 */
        if (config.getWorldServerConfig().getServerType() == SharedConstants.AcrossServer_type) {
            Loggers.gameLogger.info("WGlobals.init()");
            WGlobals.start();
        }
    }

    /**
     * 初始化性能采集
     *
     * @param gameServerConfig
     */
    private static void initProbeCollector(ServerConfig gameServerConfig) {
        // 初始化
        PIProbeCollector.init(gameServerConfig.getProbeConfig(),
                gameServerConfig.getServerDomain(),
                gameServerConfig.getServerIndex(), ServerType.GAME);
        // 启动
        PIProbeCollector.start();
    }

    private static UserAuth buildUserAuth() {
        if (config.getAuthType() == SharedConstants.AUTH_TYPE_INTERFACE) {
            return new LocalUserAuthImpl(daoService.getUserInfoDao(),
                    langService.getSysLangSerivce());
        }
        // 默认登录方式
        return new DBUserAuthImpl(daoService.getUserInfoDao());
    }

    /**
     * 初始化dirty words
     *
     * @return
     */
    @SuppressWarnings({"unchecked", "rawtypes"})
    private static String[] initDirtWords(Class clazz) {
        Collection<DirtyWordsTemplateVO> words = templateCacheService.getAll(
                clazz).values();
        int len = words.size();
        String[] dirty = new String[len];
        int i = 0;
        for (DirtyWordsTemplateVO tmpl : words) {
            dirty[i] = tmpl.getDirtyWords();
            i++;
        }
        return dirty;
    }

    public static String[] getDirtyWordsArr() {
        return initDirtWords(DirtyWordsTemplate.class);
    }

    public static String[] getNameDrityWordsArr() {
        return initDirtWords(NameDirtyWordsTemplate.class);
    }


    /**
     * 初始化全局的游戏参数
     */
    private static GameConstants initGameConstants() {
        File file = new File(config.getScriptDirFullPath() + File.separator
                + "constants.js");
        URL url = null;
        try {
            url = file.toURI().toURL();
        } catch (MalformedURLException e) {
            e.printStackTrace();
        }
        return ConfigUtil.buildConfig(GameConstants.class, url);
    }

    private static OtherplatformConstants initOtherplatformConstants() {
        ClassLoader classLoader = Thread.currentThread().getContextClassLoader();
        URL url = classLoader.getResource("otherplatformConstants.cfg.js");
        return ConfigUtil.buildConfig(OtherplatformConstants.class, url);
    }

    private static void checkAfterInit() {
        //templateCacheService.checkAfterInit();
        overmanService.checkAfterInit();
    }

    public static TimeService getTimeService() {
        return timeService;
    }

    /**
     * @return
     */
    public static GameMessageProcessor getMessageProcessor() {
        return messageProcessor.getMainProcessor();
    }

    /**
     * 获得会话服务器实例
     */
    public static OnlineSessionService<MinaGameClientSession> getSessionService() {
        return sessionService;
    }

    /**
     * 获得在线玩家管理器实例
     */
    public static OnlinePlayerService getOnlinePlayerService() {
        return onlinePlayerService;
    }

    /**
     * game world 启动时调用的方法
     */
    public static void start() {

        // 关卡服务启动（因涉及数据库操作，所以放在start里）
        Globals.getMessageProcessor().put(new SysTimeEventServiceStart());

        // 战报服务启动（建表）
        battleReportService.start();

        // 防沉迷
        wallowService.start();
    }

    public static ScheduleService getScheduleService() {
        return scheduleService;
    }

    /**
     * 构建UUID管理器
     *
     * @param serverConfig
     * @return
     */
    private static UUIDService buildUUIDService(DBService dbServices,
                                                ServerConfig serverConfig) {
        UUIDType[] _types = new UUIDType[]{UUIDType.HUMAN, UUIDType.PET, UUIDType.SCENE,
                UUIDType.OFFLINEREWARD, UUIDType.SYSMAIL, UUIDType.GOOD_ACTIVITY, UUIDType.GOOD_ACTIVITY_USER,
                UUIDType.MONEY_REPORT_ITEM_COST, UUIDType.TRADE, UUIDType.CORPS_MEMBER, UUIDType.CORPS, UUIDType.CORPSWAR_RANK,
                UUIDType.NVN_RANK, UUIDType.CORPSBOSS_RANK, UUIDType.CORPSBOSS_COUNT_RANK, UUIDType.ALLOCATE_ACTIVITY_STORAGE, 
        };
        return new UUIDServiceImpl(_types, dbServices,
                Integer.parseInt(serverConfig.getRegionId()),
                Integer.parseInt(serverConfig.getServerGroupId()),
                serverConfig.getServerIndex());
    }

    /**
     * 构建事件管理器
     *
     * @return
     */
    private static EventService buildEventService() {
        EventService _em = new EventService();
        _em.init();
        return _em;
    }

    /**
     * 获取数据更新服务
     *
     * @return
     */
    public static final EventService getEventService() {
        return eventService;
    }

    /**
     * @return
     */
    public static GameExecutorService getExecutorService() {
        return executorService;
    }

    public static ServerStatusService getServerStatusService() {
        return serverStatusService;
    }

    private static GameServerStatus buildGameServerStatus(
            GameServerConfig serverConfig) {
        GameServerStatus serverStatus = new GameServerStatus();

        serverStatus.setServerIndex(serverConfig.getServerIndex());
        serverStatus.setServerId(serverConfig.getServerId());
        serverStatus.setServerName(serverConfig.getServerName());
        serverStatus.setIp(serverConfig.getServerHost());
        serverStatus.setPort(serverConfig.getPorts());
        serverStatus.setVersion(ServerVersion.getServerVersion());

        return serverStatus;
    }

    /**
     * @return
     */
    public static GameServerConfig getServerConfig() {
        return config;
    }

    public static AsyncService getAsyncService() {
        return asyncService;
    }

    /**
     * 构建消息处理器,分拆不同类型的消息到不同的消息处理器
     *
     * @return
     */
    private static MessageDispatcher<GameMessageProcessor> buildMessageProcessor() {
        // 主消息处理器，处理登录、聊天等没有IO操作的请求
        GameMessageProcessor mainMessageProcessor = new GameMessageProcessor();
        // 消息分发器，将收到的消息转发到不同的消息处理器
        MessageDispatcher<GameMessageProcessor> msgDispatcher = new MessageDispatcher<GameMessageProcessor>(
                mainMessageProcessor);
        return msgDispatcher;
    }

    public static LoginLogicalProcessor getLoginLogicalProcessor() {
        return loginLogicalProcessor;
    }

//	public static DirtFilterService getDirtFilterService() {
//		return dirtFilterService;
//	}

    // public static TemplateService getTemplateService() {
    // return templateService;
    // }

//	/**
//	 * 构建外部系统消息Handler
//	 * 
//	 * @return
//	 */
//	public static ExtMessageHandler buildExtMessageHandler() {
//		IExtResponseContext _context = new ExtResponseContext();
//		ExtMessageHandler _handler = new ExtMessageHandler(_context);
//		// _handler.register(new HttpQueryNameAction());
//		return _handler;
//	}

    public static GameDaoService getDaoService() {
        return daoService;
    }

    public static GameServerStatus getServerStatus() {
        return serverStatus;
    }

    /**
     * 获得异步local服务
     *
     * @return
     */
    public static AsyncLocalService getAsyncLocalService() {
        return localService.getAsyncLocalService();
    }

    /**
     * 获得同步local服务
     *
     * @return
     */
    public static SynLocalService getSynLocalService() {
        return localService.getSynLocalService();
    }

    /**
     * 获得场景管理器实例
     */
    public static SceneService getSceneService() {
        return sceneService;
    }

    public static LangService getLangService() {
        return langService;
    }

    public static GameConstants getGameConstants() {
        return gameConstants;
    }

    public static LogService getLogService() {
        return logService;
    }

    public static CdService getCdService() {
        return cdService;
    }

    public static UUIDService getUUIDService() {
        return uuidService;
    }

    public static ItemService getItemService() {
        return itemService;
    }

//	public static BattleReportService getBattleReportService() {
//		return battleReportService;
//	}

    /**
     * 获取字符过滤服务
     *
     * @return
     */
    public static WordFilterService getWordFilterService() {
        return wordFilterService;
    }

    /**
     * 获取聊天服务
     *
     * @return
     */
    public static ChatService getChatService() {
        return chatService;
    }

    public static TimeQueueService getTimeQueueService() {
        return timeQueueService;
    }

    public static ProbeService getProbeService() {
        return probeService;
    }

    public static ChargeLogicalProcessor getChargeLogicalProcessor() {
        return chargeLogicalProcessor;
    }

    /**
     * 获取 Ipad 充值服务管理器
     *
     * @return
     */
    public static IpadChargeService getIpadChargeService() {
        return ipadChargeService;
    }

    public static ChargePrizeService getChargePrizeService() {
        return chargePrizeService;
    }

    public static LocalService getLocalService() {
        return localService;
    }

    public static UUIDService getUuidService() {
        return uuidService;
    }

    public static GradeRewardService getGradeRewardSerice() {
        return gradeRewardSerice;
    }

    public static MysteryShopService getMysteryShopService() {
        return mysteryShopService;
    }

    /**
     * 得到Human辅助的服务
     *
     * @return
     */
    public static HumanAssistantService getHumanAssistantService() {
        return humanAssistantService;
    }

    public static AmendService getAmendService() {
        return amendService;
    }

    /**
     * 防沉迷
     *
     * @return
     */
    public static WallowService getWallowService() {
        return wallowService;
    }

    public static GameServerConfig getConfig() {
        return config;
    }

    public static LocalScribeService getLocalScribeService() {
        return localScribeService;
    }

    public static TaskService getTaskService() {
        return taskService;
    }

    public static TemplateCacheService getTemplateCacheService() {
        return templateCacheService;
    }


    public static BaseModelCache getBaseModelCache() {
        return baseModelCache;
    }

    /**
     * 经验服务
     *
     * @return
     */
    public static ExpService getExpService() {
        return expService;
    }

    /**
     * 获取分页服务
     */
    public static PageingDataService getPageingDataService() {
        return pageingDataService;
    }


    /**
     * 获取关系服务
     *
     * @return
     */
    public static RelationService getRelationService() {
        return relationService;
    }

    /**
     * 获取玩家离线数据服务
     *
     * @return
     */
    public static OfflineDataService getOfflineDataService() {
        return offlineDataService;
    }

    /**
     * 获取武将服务
     *
     * @return
     */
    public static PetService getPetService() {
        return petService;
    }
    
    /**
     * 获取武将技能等服务
     * @return
     */
    public static PetSkillService getPetSkillService() {
    	return petSkillService;
    }

    /**
     * 获取奖励服务
     *
     * @return
     */
    public static RewardService getRewardService() {
        return rewardService;
    }

    /**
     * 获取评分奖励服务
     *
     * @return
     */
    public static GradeRewardService getGradeRewardService() {
        return gradeRewardSerice;
    }

    /**
     * 邮件系统
     *
     * @return
     */
    public static MailService getMailService() {
        return mailService;
    }

    /**
     * 获取全服邮件服务
     *
     * @return
     */
    public static SysMailService getSysMailService() {
        return sysMailService;
    }


    /**
     * 获取活动服务
     *
     * @return
     */
    public static ActivityService getActivityService() {
        return activityService;
    }

    /**
     * 获取广播服务
     *
     * @return
     */
    public static BroadcastService getBroadcastService() {
        return broadcastService;
    }


    /**
     * 获取在线礼包 服务
     *
     * @return
     */
    public static OnlineGiftService getOnlineGiftService() {
        return onlineGiftService;
    }

    /**
     * 获取离线奖励服务
     *
     * @return
     */
    public static OfflineRewardService getOfflineRewardService() {
        return offlineRewardService;
    }


    /**
     * 获取功能服务
     *
     * @return
     */
    public static FuncService getFuncService() {
        return funcService;
    }

    /**
     * 获取奖励服务
     *
     * @return
     */
    public static PrizeService getPrizeService() {
        return prizeService;
    }

    /**
     * 获取给前台的常量服务
     *
     * @return
     */
    public static ConstantService getConstantService() {
        return constantService;
    }

    /**
     * 获取精彩活动服务
     *
     * @return
     */
    public static GoodActivityService getGoodActivityService() {
        return goodActivityService;
    }

    /**
     * 获取商城服务
     *
     * @return
     */
    public static MallService getMallService() {
        return mallService;
    }


    public static DirtyFilterNetService getDirtFilterService() {
        return dirFilterNetService;
    }


    /**
     * 财报服务
     *
     * @return
     */
    public static MoneyReportService getMoneyReportService() {
        return moneyReportService;
    }


    public static SampleService getSampleService() {
        return sampleService;
    }


    public static SystemNoticeService getNoticeService() {
        return noticeService;
    }

    public static HumanService getHumanService() {
        return humanService;
    }


    /***
     * 检查非法Session服务
     *
     * @return
     */
    public static CheckSessionService getCheckSessionService() {
        return checkSessionService;
    }

    /**
     * 获取自带的logserver服务
     *
     * @return
     */
    public static LogServerService getLogServerService() {
        return logServerService;
    }

    /**
     * 获取api请求helper
     *
     * @return
     */
    public static ApiRequestHelper getApiRequestHelper() {
        return apiRequestHelper;
    }

    public static OtherplatformConstants getOtherplatformConstants() {
        return otherplatformConstants;
    }

    public static ModuleDataService getModuleDataService() {
        return moduleDataService;
    }

    public static void setModuleDataService(ModuleDataService moduleDataService) {
        Globals.moduleDataService = moduleDataService;
    }

    public static CDKeyService getCDKeyService() {
        return cdKeyService;
    }

    public static CommandProcessorService getCommandProcessorService() {
        return commandProcessorService;
    }

    /**
     * 获取数据汇报平台服务
     *
     * @return
     */
    public static DataEyeService getDataEyeService() {
        return dataEyeService;
    }

    /**
     * 获取服务器域名的前缀，如域名为s1.zlj.renren.com，则返回s1
     *
     * @return
     */
    public static String getServerNamePrefix() {
        String prefix = "";
        String domain = Globals.getServerConfig().getServerDomain();
        if (domain != null && !domain.equalsIgnoreCase("") && domain.contains(".")) {
            String[] arr = domain.split("\\.");
            prefix = arr[0];
        }
        return prefix;
    }

    /**
     * 构建与World Server的会话
     *
     * @return
     */
    public static WorldServerSession buildWorldServerSession(GameServerConfig gameServerConfig, GameExecutorService executorService,
                                                             IMessageProcessor messageProcessor, OnlinePlayerService onlineService) {
        BaseMessageRecognizer msgRecognizer = new WGMessageRecognizer();
        GameServerToWorldServerIoHandler _handler = new GameServerToWorldServerIoHandler();
        NIOClient _client = new NIOClient("World Server", Globals.getConfig().getWorldServerConfig().getIp(), Globals.getConfig().getWorldServerConfig()
                .getPort(), executorService.getMaintainsExcecutor(), messageProcessor, msgRecognizer, _handler, new ServerClientConnectionCallback());
        // 设置为不自动重连
        _client.getConnection().setReconnectOff();
        return new WorldServerSession(_client);
    }

    public static WorldServerSession getWorldServerSession() {
        return worldServerSession;
    }

    /**
     * 当前服务器是否WorldServer
     *
     * @return
     */
    public static boolean isWorldServer() {
        return getServerConfig().getWorldServerConfig().getServerType() == SharedConstants.AcrossServer_type;
    }

    /**
     * 初始化服务器名称集合，合服后多有多条数据，该集合中是本服合法的服务器名
     *
     * @param daoService
     */
    protected static void initServers(GameDaoService daoService) {
        DbVersion dbVersion = daoService.getDbVersionDao().loadDbVersion();
        String serverIds = dbVersion.getServerIds();
        JSONArray serverIdArr = JSONArray.fromObject(serverIds);
        for (int i = 0; i < serverIdArr.size(); i++) {
            int serverId = serverIdArr.getInt(i);
            if (serverId > 0) {
                serverIdSet.add(serverId);
            }
        }
        // 至少有本服Id
        serverIdSet.add(config.getServerIdInt());
    }

    /**
     * 指定的服务器名是否合法的服务器
     *
     * @param serverId
     * @return
     */
    public static boolean isValidServerId(int serverId) {
        return serverIdSet.contains(serverId);
    }

    /**
     * 获取合法的服务器Id集合
     *
     * @return
     */
    public static Set<Integer> getServerIdSet() {
        return serverIdSet;
    }

    public static UserAuth getTokenUserAuthImpl() {
        return tokenUserAuth;
    }

    /**
     * 生成token字符串，如果有参数不合法，则返回空字符串
     *
     * @param pid
     * @param rid
     * @param p1
     * @param p2
     * @return
     */
    public static String genToken(String pid, long rid, long p1, String p2) {
        if (pid != null && !pid.equals("") &&
                rid > 0 &&
                p1 > 0 &&
                p2 != null && !p2.equals("")) {
            return MD5Util.createMD5String(pid + "_" + rid + "_" + p1 + "_" + p2);
        }
        return "";
    }

    public static MapService getMapService() {
        return mapService;
    }

    public static UnitService getUnitService() {
        return unitService;
    }

    public static BattleService getBattleService() {
        return battleService;
    }

    public static BattleReportService getBattleReportService() {
        return battleReportService;
    }

    public static FightUnitService getFightUnitService() {
        return fightUnitService;
    }

    public static NpcService getNpcService() {
        return npcService;
    }

    public static CommonTaskService getCommonTaskService() {
        return commonTaskService;
    }

    public static EquipService getEquipService() {
        return equipService;
    }

    public static PubTaskService getPubTaskService() {
        return pubTaskService;
    }

    public static ExamService getExamService() {
        return examService;
    }

    public static HumanSkillService getHumanSkillService() {
        return humanSkillService;
    }

    public static TradeService getTradeService() {
        return tradeService;
    }

    public static PvpService getPvpService() {
        return pvpService;
    }

    public static NoticeTipsInfoService getNoticeTipsInfoService() {
        return noticeTipsInfoService;
    }

    public static PetIslandService getPetIslandService() {
        return petIslandService;
    }
    
    public static SealDemonService getSealDemonService() {
		return sealDemonService;
	}

	public static DevilIncarnateService getDevilIncarnateService() {
		return devilIncarnateService;
	}
	
	public static TimeLimitService getTimeLimitService() {
		return timeLimitService;
	}
	
	public static TimeLimitMonsterTaskService getTimeLimitMonsterTaskService() {
		return timeLimitMonsterTaskService;
	}
	
	public static TimeLimitNpcTaskService getTimeLimitNpcTaskService() {
		return timeLimitNpcTaskService;
	}

	public static TheSweeneyTaskService getTheSweeneyTaskService() {
        return theSweeneyTaskService;
    }

    public static TreasureMapService getTreasureMapService() {
        return treasureMapService;
    }

    public static TitleService getTitleService() {
        return titleService;
    }

    public static OvermanService getOvermanService() {
        return overmanService;
    }

    /**
     * 获取军团服务
     *
     * @return
     */
    public static CorpsService getCorpsService() {
        return corpsService;
    }
    
    public static PlotDungeonService getPlotDungeonService() {
		return plotDungeonService;
	}

	public static CorpsCultivateService getCorpsCultivateService() {
		return corpsCultivateService;
	}

	public static CorpsAssistService getCorpsAssistService() {
		return corpsAssistService;
	}
	
	public static AllocateActivityStorageService getAllocateActivityStorageService() {
		return allocateActivityStorageService;
	}

	public static RedEnvelopeService getRedEnvelopeService() {
		return redEnvelopeService;
	}

	public static ActivityUIService getActivityUIService() {
        return activityUIService;
    }

    public static TeamService getTeamService() {
        return teamService;
    }

    public static RankService getRankService() {
        return rankService;
    }

    public static WizardRaidService getWizardRaidService() {
        return wizardRaidService;
    }

    public static MineService getMineService() {
        return mineService;
    }

    public static ReyunService getReyunService() {
        return reyunService;
    }

    public static ForageTaskService getForageTaskService() {
        return forageTaskService;
    }

    public static TeamPvpService getTeamPvpService() {
        return teamPvpService;
    }

    public static CorpsWarService getCorpsWarService() {
        return corpsWarService;
    }
    
    public static NvnService getNvnService() {
    	return nvnService;
    }

	public static MarryService getMarryService() {
		return marryService;
	}

	public static WingService getWingService() {
		return wingService;
	}
	
	public static ArenaService getArenaService() {
		return arenaService;
	}

	public static CorpsTaskService getCorpsTaskService() {
		return corpsTaskService;
	}
	
	/**
	 * 获取新手引导服务
	 * @return
	 */
	public static GuideService getGuideService() {
		return guideService;
	}
	
	public static PromoteService getPromoteService() {
		return promoteService;
	}

	public static VipService getVipService() {
		return vipService;
	}
	
	public static TowerService getTowerService(){
		return towerService;
	}
	
	public static CorpsBossService getCorpsBossService(){
		return corpsBossService;
	}
	
	public static ShowService getShowService() {
		return showService;
	}
	
	public static HumanCacheService getHumanCacheService() {
		return humanCacheService;
	}
	
	public static Day7TargetService getDay7TargetService() {
		return day7TargetService;
	}
	
	public static HumanPosService getHumanPosService() {
		return humanPosService;
	}

	public static SiegeDemonTaskService getSiegeDemonTaskService() {
		return siegeDemonTaskService;
	}

	public static SiegeDemonService getSiegeDemonService() {
		return siegeDemonService;
	}
}
