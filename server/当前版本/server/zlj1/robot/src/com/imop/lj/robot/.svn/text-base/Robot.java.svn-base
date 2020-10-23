package com.imop.lj.robot;

import com.imop.lj.core.client.NIOClient;
import com.imop.lj.core.handler.BaseMessageHandler;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.recognizer.BaseMessageRecognizer;
import com.imop.lj.core.server.IMessageProcessor;
import com.imop.lj.core.server.QueueMessageProcessor;
import com.imop.lj.core.session.MinaSession;
import com.imop.lj.core.util.Assert;
import com.imop.lj.core.util.RandomUtil;
import com.imop.lj.gameserver.player.model.CreatePetInfo;
import com.imop.lj.gameserver.player.model.RoleInfo;
import com.imop.lj.gameserver.player.msg.*;
import com.imop.lj.robot.manager.BagManager;
import com.imop.lj.robot.msg.RobotClientSessionClosedMsg;
import com.imop.lj.robot.msg.RobotClientSessionOpenedMsg;
import com.imop.lj.robot.startup.IRobotClientSession;
import com.imop.lj.robot.startup.RobotClientIoHandler;
import com.imop.lj.robot.startup.RobotClientMsgHandler;
import com.imop.lj.robot.startup.RobotClientMsgRecognizer;
import com.imop.lj.robot.strategy.IRobotStrategy;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class Robot {

	/** robot相关的日志 */
	public static final Logger robotLogger = LoggerFactory.getLogger("tr.robot");

	private String userName;
	public static final String RobotTitle = "test";
	private String password = "1";

	private int pid;

	private String serverIp;

	private int port;

	private RobotState state;

	private long uuid;

	private int allianceId;

	private List<IRobotStrategy> strategyList;

	private NIOClient nioclient;

	/** 玩家与GameServer的会话 */
	private IRobotClientSession session;
	/** 背包管理器 */
	private BagManager bagManager;
//	/** 邮件管理器 */
//	private MailManager mailManager;
//	/** 武将管理器 */
//	private SecretaryManager petManager;
//	/** 分公司管理器 */
//	private BranchManager branchManager;
//
//	/** 好友管理器 */
//	private RelationManager relationManager;
//	/** 护送管理器 */
//	private EscortManager escortManager;

	public Robot(String userName,String password,int pid, String serverIp ,int port)
	{
		this.userName = userName;
		this.password = password;
		this.pid = pid;
		this.serverIp = serverIp;
		this.port = port;
		this.strategyList = new ArrayList<IRobotStrategy>();
//		mailManager = new MailManager(this);
		this.state = RobotState.init;
		bagManager = new BagManager(this);
//		mailManager = new MailManager(this);
//		petManager = new SecretaryManager(this);
//		branchManager = new BranchManager(this);
//		relationManager = new RelationManager(this);
//		escortManager = new EscortManager(this);
	}

	/**
	 * 启动连接
	 */
	public void start()
	{
		nioclient = buildConnection();
		nioclient.getMessageProcessor().start();
		nioclient.open();
	}

	/**
	 * 销毁连接
	 */
	public void destory()
	{
		if (this.nioclient != null) {
			this.nioclient.getMessageProcessor().stop();
			this.nioclient.close();
			this.nioclient = null;
			
			System.out.println("call destory.");
		}
	}

	/**
	 * 是否连接
	 * @return
	 */
	public boolean isConnected()
	{
		if (this.session != null) {
			return this.session.isConnected();
		}
		return false;
	}

	public NIOClient buildConnection()
	{
		BaseMessageHandler _messageHandler = new BaseMessageHandler();

		_messageHandler.registerHandler(new RobotClientMsgHandler());


		IMessageProcessor _messageProcessor = new QueueMessageProcessor(_messageHandler);
		BaseMessageRecognizer _recognizer = new RobotClientMsgRecognizer();
		RobotClientIoHandler _ioHandler = new RobotClientIoHandler();
		ExecutorService _executorService = Executors.newSingleThreadExecutor();
		NIOClient _client = new NIOClient("Game Server",
											this.serverIp,
											this.port,
											_executorService,
											_messageProcessor,
											_recognizer,
											_ioHandler,
											this.new ConnectionCallback());
		return _client;
	}

	/**
	 * 获取机器人执行策略
	 *
	 * @param index
	 * @return
	 */
	public IRobotStrategy getStrategy(int index) {
		if (index >= 0 && index < this.strategyList.size()) {
			return this.strategyList.get(index);
		} else {
			return null;
		}
	}

	/**
	 * 添加机器人执行策略
	 *
	 * @param strategy
	 */
	public void addRobotStrategy(IRobotStrategy strategy) {
		this.strategyList.add(strategy);
	}

	public List<IRobotStrategy> getStrategyList() {
		return strategyList;
	}

	public String getPassportId() {
		return RobotTitle + pid;
	}
	
	public String getUserName() {
		return this.userName;
	}

	public int getPid() {
		return pid;
	}

	public String getServerIp() {
		return serverIp;
	}

	public int getPort() {
		return port;
	}

	public RobotState getState() {
		return state;
	}

	public int getAllianceId() {
		return allianceId;
	}

	public long getUuid() {
		return uuid;
	}

	public void setState(RobotState state) {
		this.state = state;
	}

	public void setSession(IRobotClientSession session) {
		this.session = session;
	}

	public IRobotClientSession getSession()
	{
		return this.session;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	/**
	 *
	 * 发送消息
	 * @param msg
	 */
	public void sendMessage(IMessage msg) {
		Assert.notNull(msg);
		if (session != null) {
			session.write(msg);
		}
	}


	private class ConnectionCallback implements NIOClient.ConnectionCallback
	{
		@Override
		public void onOpen(NIOClient client, IMessage msg) {
			RobotClientSessionOpenedMsg message = (RobotClientSessionOpenedMsg)msg;
			RobotManager.getInstance().addRobot(message.getSession().getIoSession(),Robot.this);
			Robot.this.setSession(message.getSession());
			message.getSession().setRobot(Robot.this);
			Robot.this.setState(RobotState.connected);
			RobotManager.getInstance().addRobot((MinaSession)message.getSession(), Robot.this);

			// 连接服务器端成功之后, 发送握手消息
			Robot.this.doLogin();
		}

		@Override
		public void onClose(NIOClient client, IMessage msg) {
			RobotClientSessionClosedMsg message = (RobotClientSessionClosedMsg)msg;
			RobotManager.getInstance().removeRobot(message.getSession().getIoSession());
			Robot robot = RobotManager.getInstance().removeRobot((MinaSession)message.getSession());
			message.getSession().setRobot(null);
			if(robot != null)
			{
				RobotManager.getInstance().removeRobot(robot);
				robot.setState(RobotState.logout);
				robot.setSession(null);
				// XXX test 
				robot.destory();
			} else {
				System.out.println("robot is null onClose!");
			}
		}
	}

	public void doLogin()
	{
		//TODO
		this.state = RobotState.login;
//		CGPlayerLogin loginMsg = new CGPlayerLogin();
//		loginMsg.setAccount(this.passportId);
//		loginMsg.setPassword(this.password);
//		loginMsg.setSource("{\"clientVersion\":\"local\",\"deviceVersion\":\"null\",\"source\":\"ipad\",\"clientLanguage\":\"CN\",\"appid\":null,\"deviceID\":\"null\",\"deviceType\":\"null\"}");
//		sendMessage(loginMsg);
		
		//{\"clientVersion\":\"local\",\"channelName\":\"37wanwan\",\"otherPlatformLogin\":\"\",\"deviceID\":\"-1\",\"source\":\"-1\",\"deviceType\":\"-1\",\"clientLanguage\":\"CN\",\"deviceVersion\":\"-1\"}

//		CGPlayerCookieLogin msg = new CGPlayerCookieLogin();
//		msg.setCookieValue("fc0cd8cba33a93e34c3875107840bb01");
//		msg.setSource("{\"clientVersion\":\"local\",\"channelName\":\"37wanwan\",\"otherPlatformLogin\":\"\",\"deviceID\":\"-1\",\"source\":\"-1\",\"deviceType\":\"-1\",\"clientLanguage\":\"CN\",\"deviceVersion\":\"-1\"}");
		CGPlayerLogin msg = new CGPlayerLogin();
		msg.setAccount(this.userName);
		msg.setPassword(this.password);
		msg.setSource("{\"clientVersion\":\"local\",\"deviceVersion\":\"null\",\"source\":\"android\",\"clientLanguage\":\"CN\",\"appid\":null,\"deviceID\":\"null\",\"deviceType\":\"null\"}");
		sendMessage(msg);

//		CGIosQuickLogin loginMsg = new CGIosQuickLogin();
//		loginMsg.setFValue("");
//		loginMsg.setUdid("9fc4449a7803f6e1564c39f07a3275f5f62bc3c6");
//		loginMsg.setSource("{\"clientVersion\":\"local\",\"deviceVersion\":\"null\",\"source\":\"ipad\",\"clientLanguage\":\"CN\",\"appid\":null,\"deviceID\":\"null\",\"deviceType\":\"null\"}");
//		sendMessage(loginMsg);
	}

	public void doQueryRoleTemplate() {
		CGRoleTemplate cgRoleTemplate = new CGRoleTemplate();
		this.sendMessage(cgRoleTemplate);
	}

	public void doCreateRole(int tradeTypeInfoId,int templateId)
	{
		CGCreateRole cgCreateRole = new CGCreateRole();
		cgCreateRole.setName("rob" + 12);
		cgCreateRole.setTemplateId(templateId);
		this.sendMessage(cgCreateRole);
	}
	
	public void doCreateRole(Robot robot, int tradeTypeInfoId,int templateId)
	{
		CGCreateRole cgCreateRole = new CGCreateRole();
		//XXX 这里不直接用test1这样的名字，因为test是过滤词。。。
		cgCreateRole.setName("robot" + robot.getUserName().split("test")[1]);
		cgCreateRole.setTemplateId(templateId);
		this.sendMessage(cgCreateRole);
	}

	public void doSelectRoleAndEnterGame(long roleUUID)
	{
		this.state = RobotState.entergame;
		CGPlayerEnter cgPlayerEnter = new CGPlayerEnter();
		cgPlayerEnter.setRoleUUID(roleUUID);
		this.sendMessage(cgPlayerEnter);
	}

	public void handleGCRoleList(Robot robot,RoleInfo[] roleInfos, int index)
	{
		if(roleInfos.length == 0)
		{
			robot.doQueryRoleTemplate();
		}
		else
		{
			long roleUUID = roleInfos[index].getRoleUUID();
			robot.doSelectRoleAndEnterGame(roleUUID);
		}
	}

//	public void handleGCHumanDetailInfo(HumanInfo humanInfo) {
//		uuid = humanInfo.getUUID();
////		allianceId = humanInfo.getAllianceId();
//	}

	public void handleGcRoleTemplate(Robot robot,CreatePetInfo[] createPetInfos) {
		//XXX
		int tradeTypeInfoId = 1;
		// 随机一个模板
		int templateId = createPetInfos[RandomUtil.nextEntireInt(0, createPetInfos.length - 1)].getPetTemplateId();
//		String userName = "小明";
		robot.doCreateRole(robot,tradeTypeInfoId, templateId);
//		int petTmplIndex = MathUtils.random(0, templates.length - 1);
//		int jobTmplIndex = MathUtils.random(0, jobs.length - 1);
//
//		CustomPetTemplate petTmpl = templates[petTmplIndex];
//		CustomPetJobTemplate jobTmpl = jobs[jobTmplIndex];
//
//		int templateId = petTmpl.getId();
//		int hair = petTmpl.getHairs()[0];
//		int feature = petTmpl.getFeatures()[0];
//		int allianceId = petTmpl.getAlliance();
//		int job = jobTmpl.getId();
//
//		robot.doCreateRole(templateId, hair, feature, job, allianceId);
	}


	public void handleGCSceneInfo(Robot robot) {
		CGEnterScene cgEnterScene = new CGEnterScene();
		robot.sendMessage(cgEnterScene);
	}

//	/**
//	 * 处理显示场景列表消息
//	 *
//	 * @param robot
//	 * @param sceneList
//	 */
//	public void handleGCShowSceneList(Robot robot, GCShowSceneList sceneList) {
//		if (robot == null || sceneList == null) {
//			return;
//		}
//
//		SceneInfo[] siArray = sceneList.getSceneList();
//
//		if (siArray != null) {
//			for (SceneInfo si : siArray) {
//				System.out.print(String.format(
//					"{ Scene: { id: %d, name: %s, typeId: %d, image: %s, isAvailable: %d }}",
//					si.getId(), si.getName(), si.getTypeId(), si.getImage(), si.getAvailable() ? 1 : 0
//				));
//			}
//		}
//	}


	public void doEnterScene() {
		this.state = RobotState.gaming;

		for (int i = 0; i < this.strategyList.size(); i++) {
			// 获取机器人执行策略
			IRobotStrategy strategy = this.getStrategy(i);

			if (strategy == null) {
				return;
			}

			// 创建机器人行为
			RobotAction action = new RobotAction(strategy);
			// 获取第一次执行的时间延迟
			int delay = strategy.getDelay();
			// 获取循环执行时的时间间隔
			int period = strategy.getPeriod();

			if (strategy.isRepeatable()) {
				// 循环执行机器人操作
				RobotManager.getInstance().scheduleWithFixedDelay(this, action, delay, period);
			} else/* if (!strategy.isLoopExecute()) */{
				// 仅执行一次机器人操作
				RobotManager.getInstance().scheduleOnce(this, action, delay);
			}
		}
	}

	public BagManager getBagManager() {
		return bagManager;
	}

//	public MailManager getMailManager() {
//		return mailManager;
//	}
//
//	public SecretaryManager getPetManager() {
//		return petManager;
//	}
//
//	public BranchManager getBranchManager() {
//		return branchManager;
//	}
//	public RelationManager getRelationManager() {
//		return relationManager;
//	}
//
//	public EscortManager getEscortManager() {
//		return escortManager;
//	}
}
