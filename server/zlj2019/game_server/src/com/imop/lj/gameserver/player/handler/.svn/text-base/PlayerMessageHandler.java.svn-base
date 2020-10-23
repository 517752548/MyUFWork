package com.imop.lj.gameserver.player.handler;

import org.slf4j.Logger;

import com.imop.lj.common.constants.DisconnectReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.LoginTypeEnum;
import com.imop.lj.common.model.human.HumanInfo;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.i18n.LangService;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.async.QueryHumanInfoCallback;
import com.imop.lj.gameserver.human.manager.HumanInitManager;
import com.imop.lj.gameserver.player.OnlinePlayerService;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.PlayerExitReason;
import com.imop.lj.gameserver.player.PlayerSelection;
import com.imop.lj.gameserver.player.PlayerState;
import com.imop.lj.gameserver.player.async.GenerateOrderIdOperation;
import com.imop.lj.gameserver.player.async.ReportPlayerOperation;
import com.imop.lj.gameserver.player.async.YingLongChargeCallBack;
import com.imop.lj.gameserver.player.model.CreatePetInfo;
import com.imop.lj.gameserver.player.model.RoleInfo;
import com.imop.lj.gameserver.player.msg.CGAccountActivationcode;
import com.imop.lj.gameserver.player.msg.CGChargeGenOrderid;
import com.imop.lj.gameserver.player.msg.CGCheckSmsCheckcode;
import com.imop.lj.gameserver.player.msg.CGCreateRole;
import com.imop.lj.gameserver.player.msg.CGEnterScene;
import com.imop.lj.gameserver.player.msg.CGGetSmsCheckcode;
import com.imop.lj.gameserver.player.msg.CGGetSmsCheckcodeReward;
import com.imop.lj.gameserver.player.msg.CGIosAndroidCharge;
import com.imop.lj.gameserver.player.msg.CGIoschargeCheck;
import com.imop.lj.gameserver.player.msg.CGPlayerChargeDiamond;
import com.imop.lj.gameserver.player.msg.CGPlayerCookieLogin;
import com.imop.lj.gameserver.player.msg.CGPlayerEnter;
import com.imop.lj.gameserver.player.msg.CGPlayerLogin;
import com.imop.lj.gameserver.player.msg.CGPlayerQueryAccount;
import com.imop.lj.gameserver.player.msg.CGPlayerTokenLogin;
import com.imop.lj.gameserver.player.msg.CGReportPlayer;
import com.imop.lj.gameserver.player.msg.CGRoleRandomName;
import com.imop.lj.gameserver.player.msg.CGRoleTemplate;
import com.imop.lj.gameserver.player.msg.CGSmsCheckcodePanel;
import com.imop.lj.gameserver.player.msg.GCNotifyException;
import com.imop.lj.gameserver.player.msg.GCRelogin;
import com.imop.lj.gameserver.player.msg.GCRoleTemplate;
import com.imop.lj.gameserver.player.msg.PlayerCheckNeedGiveRewardMsg;
import com.imop.lj.gameserver.player.msg.PlayerOfflineMessage;
import com.imop.lj.gameserver.player.msg.UpdateOnPlayerLoginMsg;
import com.imop.lj.gameserver.scene.PlayerEnterSceneCallback;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * 玩家消息处理器，处理玩家登录、换线、换地图等消息，主线程中调用
 *
 */
public class PlayerMessageHandler {

	protected OnlinePlayerService onlinePlayerService;

	private Logger logoutLogger = Loggers.logoutLogger;

	protected LangService langService;

	protected PlayerMessageHandler(OnlinePlayerService playerManager,LangService langService) {
		this.onlinePlayerService = playerManager;
		this.langService = langService;
	}

	/**
	 * 玩家主动下线时调用此方法
	 *
	 * @param player
	 */
	public void handlePlayerCloseSession(final Player player) {
		if (player != null) {
			final IMessage offlineMsg = new PlayerOfflineMessage(player);
//			final IMessage offlineMsg = new SysInternalMessage() {
//				@Override
//				public void execute() {
//					if (player.getState() != PlayerState.logouting) {
//						logoutLogger.info(player.getClientIp() + "8、Player logout offlineMsg.execute " +
//								" player passportId" + player.getPassportId() +
//								" player state" + player.getState().name() );
//						Globals.getOnlinePlayerService().offlinePlayer(player, player.exitReason == null ? PlayerExitReason.LOGOUT : player.exitReason);
//					}else{
//						logoutLogger.info(player.getClientIp() + "7、Player logout offlineMsg.execute " +
//								" player passportId" + player.getPassportId() +
//								" player state" + player.getState().name() );
//					}
//				}
//			};
//			System.out.println(offlineMsg);
			logoutLogger.info(player.getClientIp() + "6、Player logout PlayerMessageHandler.handlePlayerCloseSession Globals.getMessageProcessor().put(offlineMsg)" +
					" player passportId" + player.getPassportId());
			Globals.getMessageProcessor().put(offlineMsg);
		}else{
			logoutLogger.info("5、Player logout PlayerMessageHandler.handlePlayerCloseSession player is null");
		}
	}

	public void handlePlayerLogin(Player player, CGPlayerLogin cgPlayerLogin) {
		String account = cgPlayerLogin.getAccount();
		String password = cgPlayerLogin.getPassword();
		String source = cgPlayerLogin.getSource();
		// 验证用户名和密码不能为空
		if (account == null || account.equals("")) {
			return;
		}
		if (password == null || password.equals("")) {
			return;
		}

		if (Globals.getOnlinePlayerService().isFull()) {
			// 服务器人满了
			player.sendMessage(new GCNotifyException(DisconnectReason.ENTER_SERVER_FAIL.code, langService.readSysLang(LangConstants.LOGIN_ERROR_SERVER_FULL)));
			player.exitReason = PlayerExitReason.SERVER_IS_FULL;
			player.disconnect();
			Loggers.loginLogger.info("GS#PlayerMessageHandler.handlePlayerLogin 900:"
					+ "account:" + account + ";"
					+ "password:" + "" + ";"
					+ "source:"+ source + ";"
					);
			return;
		}

		//XXX 有可能重复登陆，导致passportid改变
		Human human = player.getHuman();
		if(human != null){
			player.sendMessage(new GCNotifyException(DisconnectReason.ENTER_SCENE_FAIL.code, langService.readSysLang(LangConstants.REPEAT_LOGIN)));
			player.exitReason = PlayerExitReason.SERVER_IS_FULL;
			player.disconnect();
			Loggers.loginLogger.info("GS#PlayerMessageHandler.handlePlayerLogin 901:"
					+ "account:" + account + ";"
					+ "password:" + "" + ";"
					+ "source:"+ source + ";"
					+ "exist passportId:" + human.getPlayer().getPassportId() + ";"
					+ "humanName:"+ human.getName() + ";"
					+ "PlayerName:"+ player.getPassportName() + ";"
					+ "roleUUID:"+ human.getCharId() + ";"
					);
			return;
		}
		//设置登陆方式
		player.setLoginType(LoginTypeEnum.USERPWD);
		Globals.getLoginLogicalProcessor().playerLogin(player, account, password, source);
	}

	public void handlePlayerCookieLogin(Player player, CGPlayerCookieLogin cgPlayerCookieLogin) {
		String cookieValue = cgPlayerCookieLogin.getCookieValue();

		String source = cgPlayerCookieLogin.getSource();

		// 验证cookie不能为空
		if (cookieValue == null || cookieValue.equals("")) {
			return;
		}

		if (Globals.getOnlinePlayerService().isFull()) {
			// 服务器人满了
			player.sendMessage(new GCNotifyException(DisconnectReason.ENTER_SERVER_FAIL.code, langService.readSysLang(LangConstants.LOGIN_ERROR_SERVER_FULL)));
			player.exitReason = PlayerExitReason.SERVER_IS_FULL;
			player.disconnect();
			Loggers.loginLogger.info("GS#PlayerMessageHandler.handlePlayerCookieLogin 900:"
					+ "cookieValue:" + cookieValue + ";"
					);
			return;
		}

		//XXX 有可能重复登陆，导致passportid改变
		Human human = player.getHuman();
		if(human != null){
			player.sendMessage(new GCNotifyException(DisconnectReason.ENTER_SCENE_FAIL.code, langService.readSysLang(LangConstants.REPEAT_LOGIN)));
			player.exitReason = PlayerExitReason.SERVER_IS_FULL;
			player.disconnect();
			Loggers.loginLogger.info("GS#PlayerMessageHandler.handlePlayerCookieLogin 901:"
					+ "cookieValue:" + cookieValue + ";"
					+ "exist passportId:" + human.getPlayer().getPassportId() + ";"
					+ "humanName:"+ human.getName() + ";"
					+ "PlayerName:"+ player.getPassportName() + ";"
					+ "roleUUID:"+ human.getCharId() + ";"
					);
			return;
		}

		//设置登陆方式
		player.setLoginType(LoginTypeEnum.COOKIE);
		Globals.getLoginLogicalProcessor().playerCookieLogin(player, cookieValue,source);
	}
	
	public void handlePlayerTokenLogin(Player player, CGPlayerTokenLogin cgPlayerTokenLogin) {
		String token = cgPlayerTokenLogin.getToken();
		String pid = cgPlayerTokenLogin.getPid();
		long rid = cgPlayerTokenLogin.getRid();
		String source = cgPlayerTokenLogin.getSource();

		// 参数验证
		if (token == null || token.equals("")
				|| pid == null || pid.equals("")
				|| rid <= 0) {
			return;
		}
		
		if (Globals.getOnlinePlayerService().isFull()) {
			// 服务器人满了
			player.sendMessage(new GCNotifyException(DisconnectReason.ENTER_SERVER_FAIL.code, langService.readSysLang(LangConstants.LOGIN_ERROR_SERVER_FULL)));
			player.exitReason = PlayerExitReason.SERVER_IS_FULL;
			player.disconnect();
			Loggers.loginLogger.info("GS#PlayerMessageHandler.handlePlayerCookieLogin 900:"
					+ "token:" + token + ";" + ";pid=" + pid + ";rid=" + rid);
			return;
		}

		//XXX 有可能重复登陆，导致passportid改变
		Human human = player.getHuman();
		if(human != null){
			player.sendMessage(new GCNotifyException(DisconnectReason.ENTER_SCENE_FAIL.code, langService.readSysLang(LangConstants.REPEAT_LOGIN)));
			player.exitReason = PlayerExitReason.SERVER_IS_FULL;
			player.disconnect();
			Loggers.loginLogger.info("GS#PlayerMessageHandler.handlePlayerCookieLogin 901:"
					+ "token:" + token + ";"
					+ "pid:" + pid + ";"
					+ "rid:" + rid + ";"
					+ "exist passportId:" + human.getPlayer().getPassportId() + ";"
					+ "humanName:"+ human.getName() + ";"
					+ "PlayerName:"+ player.getPassportName() + ";"
					+ "roleUUID:"+ human.getCharId() + ";"
					);
			return;
		}

		//设置登陆方式
		player.setLoginType(LoginTypeEnum.TOKEN);
		Globals.getLoginLogicalProcessor().playerTokenLogin(player, token, pid, rid, source);
	}

	/**
	 * 客户段请求角色模板 简单的消息，不涉及逻辑，就在这里直接处理了
	 *
	 * @param player
	 * @param cgRoleTemplate
	 */
	public void handleRoleTemplate(Player player, CGRoleTemplate cgRoleTemplate) {
		if (null == player) {
			return;
		}

		//FIXME
		CreatePetInfo[] createPetInfos = Globals.getTemplateCacheService().getPetTemplateCache().getCreatePetInfos();
		// 生成消息
		GCRoleTemplate gcRoleTemplate = new GCRoleTemplate();
		gcRoleTemplate.setCreatePetInfoList(createPetInfos);
		
		// 如果玩家角色列表为空且帐号未激活，则激活帐号
		gcRoleTemplate.setActivity(player.isActivity() ? 1 : 0);
		
		player.sendMessage(gcRoleTemplate);
		Globals.getLoginLogicalProcessor().getRoleRandomName(player,1);
		
//		// 发kaiying的新手日志
//		Globals.getQQKaiYingLogService().sendGuideLog(player, KaiyingLogGuideCat.LOAD, KaiyingLogGuideLoadStep.SHOW_CREATE_ROLE.getIndex());
	}

	public void handleCreateRole(Player player, CGCreateRole msg) {
		// 获得角色名称
		String roleName = msg.getName();
		// 获得秘书模板Id
		int templateId = msg.getTemplateId();

		RoleInfo role = new RoleInfo();
		// 用户平台id
		role.setPassportId(player.getPassportId());
		// 角色名称
		role.setName(roleName);

		PlayerSelection selection = new PlayerSelection();
		selection.setPetTemplateId(templateId);
		role.setSelection(selection);

		// 角色未激活
		if(!player.isActivity()){
			player.sendErrorMessage(LangConstants.ACCOUNT_NOT_ACTIVITED);
			return;
		}
		Globals.getLoginLogicalProcessor().createRole(player, role, selection);

		// if (msg.getAddAttention()) {
		// // 添加关注
		// Globals.getSynLocalService().addAttention(player.getPassportName());
		// }
	}

	/**
	 * 选择角色,由于默认肯定是一个角色,所以命名为PlayerEnter,实际就是SelectRole
	 *
	 * @param player
	 * @param cgPlayerEnter
	 */
	public void handlePlayerEnter(final Player player, CGPlayerEnter cgPlayerEnter) {
		player.init();// 初始化必要管理器
		long roleUUID = cgPlayerEnter.getRoleUUID();

		{
			Player existPlayer = Globals.getOnlinePlayerService().getPlayerByPassportId(player.getPassportId());
			// 玩家已在线
			if (existPlayer != null) {

				// 踢掉当前在线玩家，通知当前登录玩家稍后重试
				if (existPlayer.getState() != PlayerState.logouting) {

					existPlayer.sendMessage(new GCNotifyException(DisconnectReason.LOGIN_ON_ANOTHER_CLIENT.code, langService.readSysLang(LangConstants.LOGIN_ONLINE_ERROR)));
					existPlayer.exitReason = PlayerExitReason.MULTI_LOGIN;
					existPlayer.disconnect();

					player.sendMessage(new GCNotifyException(DisconnectReason.LOGIN_ON_ANOTHER_CLIENT.code, langService.readSysLang(LangConstants.LOGIN_ONLINE_ERROR)));
					player.exitReason = PlayerExitReason.MULTI_LOGIN;
					player.disconnect();

					logoutLogger.info("PlayerMessageHandler.handlePlayerEnter player passportID:" + existPlayer.getPassportId() + "NotifyException" + DisconnectReason.LOGIN_ON_ANOTHER_CLIENT.code);
					return;
				}else{
					player.sendMessage(new GCNotifyException(DisconnectReason.LOGIN_ON_ANOTHER_CLIENT.code, langService.readSysLang(LangConstants.LOGIN_ONLINE_ERROR)));
					player.exitReason = PlayerExitReason.MULTI_LOGIN;
					player.disconnect();
					logoutLogger.info("==================existPlayer " + existPlayer.getState());
				}
			}
		}

		{
			Player existPlayer = Globals.getOnlinePlayerService().getPlayer(roleUUID);
			// 玩家已在线
			if (existPlayer != null) {

				// 踢掉当前在线玩家，通知当前登录玩家稍后重试
				if (existPlayer.getState() != PlayerState.logouting) {

					existPlayer.sendMessage(new GCNotifyException(DisconnectReason.LOGIN_ON_ANOTHER_CLIENT.code, langService.readSysLang(LangConstants.LOGIN_ONLINE_ERROR)));
					existPlayer.exitReason = PlayerExitReason.MULTI_LOGIN;
					GameClientSession session = existPlayer.getSession();
					//XXX 可能会出现Player没有session的情况
					if(session != null){
						existPlayer.disconnect();
					}else{
						Globals.getOnlinePlayerService().forceKickOutPlayer(roleUUID);
					}

					player.sendMessage(new GCNotifyException(DisconnectReason.LOGIN_ON_ANOTHER_CLIENT.code, langService.readSysLang(LangConstants.LOGIN_ONLINE_ERROR)));
					player.exitReason = PlayerExitReason.MULTI_LOGIN;
					player.disconnect();
					logoutLogger.info("PlayerMessageHandler.handlePlayerEnter player roleUUID:" + roleUUID + "NotifyException" + DisconnectReason.LOGIN_ON_ANOTHER_CLIENT.code);
					return;
				}
			}
		}


		// 人数已经满,不能进入服务器,断开连接
		if (!onlinePlayerService.onPlayerEnterServer(player, roleUUID)) {
			Loggers.gameLogger.warn("player " + player.getPassportId() + " can't enter server");
			player.sendMessage(new GCNotifyException(DisconnectReason.ENTER_SERVER_FAIL.code, langService.readSysLang(LangConstants.LOGIN_ERROR_SERVER_FULL)));
			player.exitReason = PlayerExitReason.SERVER_ERROR;
			player.disconnect();

			logoutLogger.info("PlayerMessageHandler.handlePlayerEnter player passportID:" + player.getPassportId() + "NotifyException" + DisconnectReason.ENTER_SERVER_FAIL.code);
			return;
		}
		Globals.getLoginLogicalProcessor().selectRole(player, roleUUID);
	}

	/**
	 *
	 * 进入地图
	 *
	 * @see HumanInitManager#noticeHuman
	 * @param player
	 * @param cgEnterScene
	 */
	public void handleEnterScene(final Player player, CGEnterScene cgEnterScene) {
		player.setState(PlayerState.entering);

		Human humanCache = Globals.getHumanCacheService().getHuman(player.getCharId());
		//有缓存，且当前player身上的human不是缓存的human则替换
		if (humanCache != null && humanCache != player.getHuman()) {
			long rid = player.getHuman().getUUID();
			player.setHuman(humanCache);
			humanCache.setPlayer(player);
			Loggers.loginLogger.warn("#PlayerMessageHandler#handleEnterScene#119humanCache replace human!pid=" + player.getPassportId() + 
					";roleId=" + humanCache.getUUID() + ";rid=" + rid + ";state=" + player.getState());
		}
		
		// 人数出现错误,不能进入场景,断开连接
		if (!Globals.getSceneService().onPlayerEnterScene(player, new PlayerEnterSceneCallback() {
			/**
			 * 玩家登录时，进入场景后的回调
			 * 此回调是在[主线程]做的，所以最好将需要处理的内容封装一个消息，放入玩家消息列表中
			 *
			 */
			@Override
			public void afterEnterScene(final Player player) {
				// 玩家进入场景后的通知消息
				if (player != null && player.getHuman() != null && player.isOnline()) {
					// 如果是qq平台，则检查未完成的充值订单
//					if (Globals.isQQPlatform()) {
//						player.putMessage(new SysInternalMessage() {
//							@Override
//							public void execute() {
////								// 检查充值订单
////								Globals.getQQService().checkQQChargeOrder(player);
////								// 检查集市任务奖励
////								Globals.getQQService().requestApiMarketTaskAward(player.getHuman());
//							}
//						});
//					} else {
						// 直冲充值检查
						if (Globals.getServerConfig().isZhichongFlag() && Globals.getServerConfig().isTurnOnLocalInterface()) {
							player.putMessage(new SysInternalMessage() {
								@Override
								public void execute() {
									Globals.getChargeLogicalProcessor().iosAndroidCharge(player);
								}
							});
						}
//					}
					
					// 登录时的更新操作，在玩家消息队列中进行
					player.putMessage(new UpdateOnPlayerLoginMsg(player.getHuman()));
					
					// ！！！玩家是否有未领取奖励，需要登录弹出面板的处理都加在下面这个消息里面！！！
					player.putMessage(new PlayerCheckNeedGiveRewardMsg(player.getHuman()));
					
					// 给玩家发系统邮件
					Globals.getSysMailService().sendSysMailOnLogin(player.getRoleUUID());
					
				}
			}

		})) {
			Loggers.gameLogger.warn("player " + player.getPassportName() + " can't enter scene, targetSceneId :" + player.getTargetSceneId());
			player.sendMessage(new GCNotifyException(DisconnectReason.ENTER_SCENE_FAIL.code, ""));
			player.exitReason = PlayerExitReason.SERVER_ERROR;
			player.disconnect();
			return;
		}
		// GCEnterScene scene = new GCEnterScene();
		// player.sendMessage(scene);
	}

	/**
	 * 玩家充值消息
	 *
	 * @param player
	 * @param cgPlayerChargeGold
	 */
	public void handlePlayerChargeDiamond(Player player, CGPlayerChargeDiamond cgPlayerChargeDiamond) {
		if (!Globals.getServerConfig().isTurnOnLocalInterface()) {
			player.sendSystemMessage(LangConstants.LOCAL_TURN_OFF);
			return;
		}
		int mmCost = cgPlayerChargeDiamond.getMmCost();
		Globals.getChargeLogicalProcessor().chargeGold(player, mmCost);
	}

	/**
	 * 玩家账户查询
	 *
	 * @param player
	 * @param cgPlayerQueryAccount
	 */
	public void handlePlayerQueryAccount(Player player, CGPlayerQueryAccount cgPlayerQueryAccount) {
//		Globals.getChargeLogicalProcessor().queryPlayerAccount(player);
		
		GCRelogin msg = new GCRelogin();
		player.sendMessage(msg);
		
		for (int j = 0 ; j <  10; j++) {
			for (int i = 0; i < 1000; i++) {
				player.sendMessage(msg);
				System.out.println("i="+i+";j="+j);
			}
			
//			try {
//				Thread.currentThread().sleep(MathUtils.random(50, 100));
//			} catch (InterruptedException e) {
//				// TODO Auto-generated catch block
//				e.printStackTrace();
//			}
		}
	}

	/**
	 * 请求随机角色名
	 *
	 * CodeGenerator
	 */
	public void handleRoleRandomName(Player player, CGRoleRandomName cgRoleRandomName) {
		Globals.getLoginLogicalProcessor().getRoleRandomName(player,cgRoleRandomName.getSex());
	}

//	/**
//	 * 校验ipad的充值是否成功
//	 *
//	 * @param player
//	 * @param cgChargeIpadCheck
//	 */
//	public void handleChargeIpadCheck(Player player, CGChargeIpadCheck cgChargeIpadCheck) {
//		if (player == null) {
//			return;
//		}
//
//		Human human = player.getHuman();
//		if (human == null) {
//			return;
//		}
//
//		if (cgChargeIpadCheck == null) {
//			return;
//		}
//
//		if(player.getCurrTerminalType() != TerminalTypeEnum.IPAD && player.getCurrTerminalType() != TerminalTypeEnum.IPHONE){
//			human.sendMessage(LangConstants.IOS_CHARGE_CHECK_FAIL);
//			return;
//		}
//
//		Globals.getChargeLogicalProcessor().chargeIpadCheck(player, cgChargeIpadCheck.getChargeData());
//	}
//
//	/**
//	 * 请求查看充值的档位
//	 *
//	 * @param player
//	 * @param cgChargeKinds
//	 */
//	public void handleChargeKinds(Player player, CGChargeKinds cgChargeKinds) {
//
//		// 判断是否是充值黑名单
//		if (player == null) {
//			return;
//		}
//
//		Human human = player.getHuman();
//		if (human == null) {
//			return;
//		}
//		if("buy".equalsIgnoreCase(Globals.getServerConfig().getAppleStoreType())){
//			PlayerCheckBlackListOperation _chargOper = new PlayerCheckBlackListOperation(player.getRoleUUID());
//			Globals.getAsyncService().createOperationAndExecuteAtOnce(_chargOper, player.getRoleUUID());
//		}else if("sandbox".equalsIgnoreCase(Globals.getServerConfig().getAppleStoreType())){
//			TerminalTypeEnum terminalTypeEnum = player.getCurrTerminalType();
//			switch(terminalTypeEnum){
//			case IPHONE:
//			case IPAD:
//				GCChargeKinds gcChargeKinds = new GCChargeKinds();
//				gcChargeKinds.setChargeKinds(Globals.getIpadChargeService().getDefaultIPadCharges(player.getAppid()));
//				human.sendMessage(gcChargeKinds);
//
//				GCChargeKindsDetail gcChargeKindsDetail = new GCChargeKindsDetail();
//				List<IpadChargeTemplate> templateList = Globals.getIpadChargeService().getIpadChargeTemplateByAppid(player.getAppid());
//				List<IosChargeInfo> iosChargeInfoList = new ArrayList<IosChargeInfo>();
//				for(IpadChargeTemplate tmp : templateList){
//					IosChargeInfo iosChargeInfo = new IosChargeInfo();
//					iosChargeInfo.setCostRMB(tmp.getCostRMB());
//					iosChargeInfo.setDesc(tmp.getDesc());
//					iosChargeInfo.setIcon(tmp.getIcon());
//					iosChargeInfo.setName(tmp.getName());
//					iosChargeInfo.setProductId(tmp.getProductId());
//					iosChargeInfoList.add(iosChargeInfo);
//				}
//				Collections.sort(iosChargeInfoList, new ChargeKindSorter());
//				gcChargeKindsDetail.setIosChargeInfoDataList(iosChargeInfoList.toArray(new IosChargeInfo[0]));
//				human.sendMessage(gcChargeKindsDetail);
//				break;
//			default:
//				break;
//			}
//		}
//	}
//
//	private static class ChargeKindSorter implements Comparator<IosChargeInfo> {
//		/**
//		 * 按照花费货币数量从小到大排序
//		 */
//		@Override
//		public int compare(IosChargeInfo o1, IosChargeInfo o2) {
//			return o1.getCostRMB() - o2.getCostRMB();
//		}
//	}
//
//
//
//	/**
//	 * 添加关注
//	 * @param player
//	 * @param cgAddAttention
//	 */
//	public void handleAddAttention(Player player,CGAddAttention cgAddAttention)
//	{
//		if (Globals.getServerConfig().isTurnOnLocalInterface() &&
//				(cgAddAttention.getAddAttentionTicket() != null) &&
//			   !(cgAddAttention.getAddAttentionTicket().equals(""))) {
//				// 异步添加关注
//				AddAttentionOperation attentionOp = new AddAttentionOperation(
//						player,
//						cgAddAttention.getAddAttentionTicket());
//				Globals.getAsyncService().createOperationAndExecuteAtOnce(attentionOp);
//		}
//	}
	
	/**
 	* 举报
 	*
 	* CodeGenerator
 	*/
	public void handleReportPlayer(final Player player, final CGReportPlayer cgReportPlayer) {
		if (!Globals.getServerConfig().isTurnOnLocalInterface()) {
			return;
		}
 		//被举报玩家的角色名称
		final String targetCharName = cgReportPlayer.getCharName();
		//查询被举报玩家的humanInfo信息
		Globals.getHumanService().doQueryHumanInfo(cgReportPlayer.getCharId(), new QueryHumanInfoCallback(){

			@Override
			public void afterQueryComplete(HumanInfo humanInfo) {
				ReportPlayerOperation reportPlayerOperation= new ReportPlayerOperation();
				//给各个变量赋值
				reportPlayerOperation.setPlayer(player);
				reportPlayerOperation.setTargetCharName(targetCharName);
				reportPlayerOperation.setTargetHuman(humanInfo);
				reportPlayerOperation.setChatText(cgReportPlayer.getChatText());
				reportPlayerOperation.setScope(cgReportPlayer.getScope());
				reportPlayerOperation.setToken(cgReportPlayer.getToken());
				Globals.getAsyncService().createOperationAndExecuteAtOnce(reportPlayerOperation, player.getRoleUUID());
			}
		});

	}
	
	/**
 	* 激活帐号
 	* 
 	* CodeGenerator
 	*/
	public void handleAccountActivationcode(Player player, CGAccountActivationcode cgAccountActivationcode) {
//		// 帐号已激活
//		if(player.isActivity()){
//			player.sendErrorMessage(LangConstants.ACCOUNT_ACTIVITED);
//			return;
//		}
//		if (!Globals.getServerConfig().isTurnOnLocalInterface()) {
//			Loggers.playerLogger.error("#PlayerMessageHandler#handleAccountActivationcode#isTurnOnLocalInterface is false!charId="+ player.getCharId());
//			return;
//		}
//		AccountActivityOperation accountActivityOperation = new AccountActivityOperation(player, cgAccountActivationcode.getActivationCode());
//		Globals.getAsyncService().createOperationAndExecuteAtOnce(accountActivityOperation, player.getRoleUUID());
	}

//	/**
// 	* 91IOS充值
// 	*
// 	* CodeGenerator
// 	*/
//	public void handle91IosCharge(Player player, CG91IosCharge cg91IosCharge) {
//
//		String chargeData = cg91IosCharge.getChargeData();
//		String checkData = cg91IosCharge.getCheckData();
//
//		if (player == null) {
//			return;
//		}
//
//		Human human = player.getHuman();
//		if (human == null) {
//			return;
//		}
//
//		if(player.getCurrTerminalType() != TerminalTypeEnum.IPAD && player.getCurrTerminalType() != TerminalTypeEnum.IPHONE && !(Globals.getConfig().getAuthType() == SharedConstants.AUTH_TYPE_91)){
//			human.sendMessage(LangConstants.IOS_CHARGE_91_CHECK_FAIL);
//			Loggers.playerLogger.error("handle91IosCharge :"
//					+ (player.getCurrTerminalType() != TerminalTypeEnum.IPAD) + ";"
//					+ (player.getCurrTerminalType() != TerminalTypeEnum.IPHONE) + ";"
//					+ (Globals.getConfig().getAuthType() == SharedConstants.AUTH_TYPE_91) + ";"
//					);
//			return;
//		}
//		Globals.getChargeLogicalProcessor().chargeIos91Check(player, chargeData,checkData);
//	}

	/**
 	* IOS和android直冲查询
 	*
 	* CodeGenerator
 	*/
	public void handleIosAndroidCharge(Player player, CGIosAndroidCharge cgIosAndroidCharge) {
		if (player == null) {
			return;
		}

		Human human = player.getHuman();
		if (human == null) {
			return;
		}

		if (cgIosAndroidCharge == null) {
			return;
		}

//		if(player.getCurrTerminalType() != TerminalTypeEnum.ANDROID){
//			//TODO 目前只支持android
//			human.sendMessage(LangConstants.IOS_ANDROID_CHARGE_CHECK_FAIL);
//			return;
//		}

		Globals.getChargeLogicalProcessor().iosAndroidCharge(player);
	}
	
	/**
	 * 获取验证码
	 * @param player
	 * @param cgGetSmsCheckcode
	 */
	public void handleGetSmsCheckcode(Player player, CGGetSmsCheckcode cgGetSmsCheckcode) {
//		if (!Globals.getServerConfig().isTurnOnLocalInterface()) {
//			return;
//		}
//		// 非空验证
//		if (player == null || player.getHuman() == null) {
//			return;
//		}
////		// 功能是否开启
////		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.SMS_CHECKCODE)) {
////			Loggers.playerLogger.error("#PlayerMessageHandler#handleGetSmsCheckcode#func not open!passportId=" + player.getPassportId());
////			return;
////		}
//		// 是否领取过奖励，如果已经领取过，则不能再进行操作
//		if (!player.getHuman().getBehaviorManager().canDo(BehaviorTypeEnum.SMS_CHECKCODE_REWARD)) {
//			// 奖励已经领取过，非法操作
//			Loggers.playerLogger.error("#PlayerMessageHandler#handleGetSmsCheckcode#behavior cando return false!passportId=" + player.getPassportId());
//			return;
//		}
//		// 是否有验证成功的数据，如果没有，则不需要再验证
//		if (player.getHuman().getSmsCheckCodeManager().hasValidData()) {
//			Loggers.playerLogger.error("#PlayerMessageHandler#handleGetSmsCheckcode#hasValidData return true!passportId=" + player.getPassportId());
//			return;
//		}
//		
//		// 手机号
//		String phoneNum = getValidPhoneNum(cgGetSmsCheckcode.getPhoneNum(), player, "handleGetSmsCheckcode");
//		if (null == phoneNum) {
//			player.sendErrorMessage(LangConstants.SMS_CHECKCODE_INVALIDE_PHONE_NUM);
//			return;
//		}
//		
//		Globals.getAsyncService().createOperationAndExecuteAtOnce(new SendSmsCheckCodeOperation(player, phoneNum));
	}
	
	/**
	 * 验证验证码
	 * @param player
	 * @param cgCheckSmsCheckcode
	 */
	public void handleCheckSmsCheckcode(Player player, CGCheckSmsCheckcode cgCheckSmsCheckcode) {
//		if (!Globals.getServerConfig().isTurnOnLocalInterface()) {
//			return;
//		}
//		// 非空验证
//		if (player == null || player.getHuman() == null) {
//			return;
//		}
////		// 功能是否开启
////		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.SMS_CHECKCODE)) {
////			Loggers.playerLogger.error("#PlayerMessageHandler#handleCheckSmsCheckcode#func not open!passportId=" + player.getPassportId());
////			return;
////		}
//		// 是否领取过奖励，如果已经领取过，则不能再进行操作
//		if (!player.getHuman().getBehaviorManager().canDo(BehaviorTypeEnum.SMS_CHECKCODE_REWARD)) {
//			// 奖励已经领取过，非法操作
//			Loggers.playerLogger.error("#PlayerMessageHandler#handleCheckSmsCheckcode#behavior cando return false!passportId=" + player.getPassportId());
//			return;
//		}
//		// 是否有验证成功的数据，如果没有，则不需要再验证
//		if (player.getHuman().getSmsCheckCodeManager().hasValidData()) {
//			Loggers.playerLogger.error("#PlayerMessageHandler#handleCheckSmsCheckcode#hasValidData return true!passportId=" + player.getPassportId());
//			return;
//		}
//		
//		// 手机号
//		String phoneNum = getValidPhoneNum(cgCheckSmsCheckcode.getPhoneNum(), player, "handleCheckSmsCheckcode");
//		if (null == phoneNum) {
//			player.sendErrorMessage(LangConstants.SMS_CHECKCODE_INVALIDE_PHONE_NUM);
//			return;
//		}
//		// qq号
//		String qqNum = getValidQQNum(cgCheckSmsCheckcode.getQqNum(), player, "handleCheckSmsCheckcode");
//		if (null == qqNum) {
//			player.sendErrorMessage(LangConstants.SMS_CHECKCODE_INVALIDE_QQ_NUM);
//			return;
//		}
//		// 验证码，只做长度检测
//		String checkCode = cgCheckSmsCheckcode.getCheckCode();
//		if (checkCode == null || 
//				checkCode.length() < Globals.getGameConstants().getCheckCodeLengthMin() ||
//				checkCode.length() > Globals.getGameConstants().getCheckCodeLengthMax()) {
//			player.sendErrorMessage(LangConstants.SMS_CHECKCODE_INVALIDE_CHECKCODE);
//			return;
//		}
//		
//		Globals.getAsyncService().createOperationAndExecuteAtOnce(new CheckSmsCheckCodeOperation(player, qqNum, phoneNum, checkCode));
	}
	
	/**
	 * 领取手机验证奖励
	 * @param player
	 * @param cgGetSmsCheckcodeReward
	 */
	public void handleGetSmsCheckcodeReward(Player player, CGGetSmsCheckcodeReward cgGetSmsCheckcodeReward) {
//		// 非空验证
//		if (player == null || player.getHuman() == null) {
//			return;
//		}
////		// 功能是否开启
////		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.SMS_CHECKCODE)) {
////			Loggers.playerLogger.error("#PlayerMessageHandler#handleGetSmsCheckcodeReward#func not open!passportId=" + player.getPassportId());
////			return;
////		}
//		
//		Human human = player.getHuman();
//		
//		// 是否领取过奖励
//		if (!human.getBehaviorManager().canDo(BehaviorTypeEnum.SMS_CHECKCODE_REWARD)) {
//			// 奖励已经领取过，非法操作
//			Loggers.playerLogger.error("#PlayerMessageHandler#handleGetSmsCheckcodeReward#behavior cando return false!passportId=" + player.getPassportId());
//			return;
//		}
//		
//		// 是否有验证成功的数据，如果没有，则不能领奖
//		if (!human.getSmsCheckCodeManager().hasValidData()) {
//			Loggers.playerLogger.error("#PlayerMessageHandler#handleGetSmsCheckcodeReward#hasValidData return false!passportId=" + player.getPassportId());
//			return;
//		}
//		
//		// 领奖行为记录
//		boolean behaviorFlag = human.getBehaviorManager().doBehavior(BehaviorTypeEnum.SMS_CHECKCODE_REWARD);
//		if (!behaviorFlag) {
//			Loggers.playerLogger.error("#PlayerMessageHandler#handleGetSmsCheckcodeReward#behaviorFlag return false!passportId=" + player.getPassportId());
//			return;
//		}
////		// 功能按钮变化
////		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.SMS_CHECKCODE);
//		
//		// 给奖励
//		Reward reward = Globals.getRewardService().createReward(human.getCharId(), Globals.getGameConstants().getSmsCheckCodeRewardId(), "handleGetSmsCheckcodeReward");
//		boolean giveRewardFlag = Globals.getRewardService().giveReward(human, reward, true);
//		if (!giveRewardFlag) {
//			Loggers.playerLogger.error("#PlayerMessageHandler#handleGetSmsCheckcodeReward#giveRewardFlag return false!passportId=" + player.getPassportId());
//		} else {
//			Loggers.playerLogger.info("#PlayerMessageHandler#handleGetSmsCheckcodeReward#give reward ok!passportId=" + player.getPassportId());
//		}
	}
	
	/**
	 * 打开手机验证面板
	 * @param player
	 * @param cgSmsCheckcodePanel
	 */
	public void handleSmsCheckcodePanel(Player player, CGSmsCheckcodePanel cgSmsCheckcodePanel) {
//		// 非空验证
//		if (player == null || player.getHuman() == null) {
//			return;
//		}
////		// 功能是否开启
////		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.SMS_CHECKCODE)) {
////			Loggers.playerLogger.error("#PlayerMessageHandler#handleSmsCheckcodePanel#func not open!passportId=" + player.getPassportId());
////			return;
////		}
//		Human human = player.getHuman();
//		// 是否领取过奖励，如果已经领取过，则不能再进行操作
//		if (!human.getBehaviorManager().canDo(BehaviorTypeEnum.SMS_CHECKCODE_REWARD)) {
//			// 奖励已经领取过，非法操作
//			Loggers.playerLogger.error("#PlayerMessageHandler#handleSmsCheckcodePanel#behavior cando return false!passportId=" + player.getPassportId());
//			return;
//		}
//		
//		String phoneNum = human.getSmsCheckCodeManager().getPhoneNum();
//		String qqNum = human.getSmsCheckCodeManager().getQqNum();
//		
//		int result = human.getSmsCheckCodeManager().hasValidData() ? ResultTypes.SUCCESS.val : ResultTypes.FAIL.val;
//		RewardInfo rewardInfos = Globals.getRewardService().createRewardInfo(human.getCharId(), 
//				Globals.getGameConstants().getSmsCheckCodeRewardId(), "", null);
//		human.sendMessage(new GCSmsCheckcodePanel(result, qqNum, phoneNum, rewardInfos));
	}
	
	/**
	 * 验证手机号是否合法
	 * 注：仅验证11位数字，其他不做验证
	 * 
	 * @param phoneNumRaw
	 * @param player
	 * @param source
	 * @return
	 */
	protected String getValidPhoneNum(String phoneNumRaw, Player player, String source) {
		// 长度是否11位
		if (phoneNumRaw.length() != Globals.getGameConstants().getPhoneNumLength()) {
			return null;
		}
		
		Long phoneNumLong = 0L;
		// 类型转换是否成功
		try {
			phoneNumLong = Long.parseLong(phoneNumRaw); 
		} catch (Exception e) {
			Loggers.playerLogger.error("#PlayerMessageHandler#" + source + "#parse phone num fail!passportId=" + 
					player.getPassportId() + ";e=" + e.getMessage());
			e.printStackTrace();
		}
		if (null == phoneNumLong || phoneNumLong <= 0) {
			return null;
		}
		
		String phoneNum = phoneNumLong + "";
		// 转为long后，验证长度是否合法
		if (phoneNum.length() != Globals.getGameConstants().getPhoneNumLength()) {
			return null;
		}
		return phoneNum;
	}
	
	/**
	 * 检查qq号是否合法
	 * 注：进验证5~n位数字，其他不做验证
	 * @param qqNumRaw
	 * @param player
	 * @param source
	 * @return
	 */
	protected String getValidQQNum(String qqNumRaw, Player player, String source) {
		// 长度是否11位
		if (qqNumRaw.length() < Globals.getGameConstants().getQqNumLengthMin() ||
				qqNumRaw.length() > Globals.getGameConstants().getQqNumLengthMax()) {
			return null;
		}
		
		Long qqNumLong = 0L;
		// 类型转换是否成功
		try {
			qqNumLong = Long.parseLong(qqNumRaw); 
		} catch (Exception e) {
			Loggers.playerLogger.error("#PlayerMessageHandler#" + source + "#parse qq num fail!passportId=" + 
					player.getPassportId() + ";e=" + e.getMessage());
			e.printStackTrace();
		}
		if (null == qqNumLong || qqNumLong <= 0) {
			return null;
		}
		
		String qqNum = qqNumLong + "";
		// 转为long后，验证长度是否合法
		if (qqNum.length() < Globals.getGameConstants().getQqNumLengthMin() ||
				qqNum.length() > Globals.getGameConstants().getQqNumLengthMax()) {
			return null;
		}
		return qqNum;
	}
	
	/**
	 * 请求生成充值订单Id
	 * @param player
	 * @param cgChargeGenOrderid
	 */
	public void handleChargeGenOrderid(Player player, CGChargeGenOrderid cgChargeGenOrderid) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		String channelCode = cgChargeGenOrderid.getChannelCode();
		String channelExt = cgChargeGenOrderid.getChannelExt();
		
		if (channelCode == null || channelCode.isEmpty()) {
			channelCode = player.getChannelName();
		}
		
		GenerateOrderIdOperation operation = new GenerateOrderIdOperation(player.getRoleUUID(), channelCode, channelExt, new YingLongChargeCallBack());
		Globals.getAsyncService().createOperationAndExecuteAtOnce(operation, player.getRoleUUID());
	}
	
	/**
	 * ios充值校验
	 * @param player
	 * @param cgIoschargeCheck
	 */
	public void handleIoschargeCheck(Player player, CGIoschargeCheck cgIoschargeCheck) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		String token = cgIoschargeCheck.getToken();
		if (token == null || token.isEmpty()) {
			return;
		}
		
		Globals.getChargeLogicalProcessor().chargeIpadCheck(player, token);
	}
	
}


