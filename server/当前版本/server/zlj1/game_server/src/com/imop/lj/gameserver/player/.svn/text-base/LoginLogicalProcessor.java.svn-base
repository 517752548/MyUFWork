package com.imop.lj.gameserver.player;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.RoleConstants;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.common.service.DirtFilterService.WordCheckType;
import com.imop.lj.core.i18n.SysLangService;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.core.util.ErrorsUtil;
import com.imop.lj.core.util.MathUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.async.CreateRoleOperation;
import com.imop.lj.gameserver.player.async.LoadPlayerAccountOperation;
import com.imop.lj.gameserver.player.async.LoadPlayerRoleOperation;
import com.imop.lj.gameserver.player.async.PlayerCookieLoginOperation;
import com.imop.lj.gameserver.player.async.PlayerLoginOperation;
import com.imop.lj.gameserver.player.async.PlayerRolesLoad;
import com.imop.lj.gameserver.player.async.PlayerTokenLoginOperation;
import com.imop.lj.gameserver.player.auth.AuthPlatform;
import com.imop.lj.gameserver.player.auth.UserAuth;
import com.imop.lj.gameserver.player.model.RoleInfo;
import com.imop.lj.gameserver.player.msg.GCFailedMsg;
import com.imop.lj.gameserver.player.msg.GCRoleList;
import com.imop.lj.gameserver.player.msg.GCRoleRandomName;
import com.imop.lj.gameserver.role.template.RoleNameFemaleMingTemplate;
import com.imop.lj.gameserver.role.template.RoleNameMaleMingTemplate;
import com.imop.lj.gameserver.role.template.RoleNameXingTemplate;

/**
 * 处理玩家登录，创建角色，选择角色等相关逻辑
 *
 */
public class LoginLogicalProcessor {

	private UserAuth userAuth;

	private SysLangService langService;

	public LoginLogicalProcessor(UserAuth userAuth, SysLangService langManager) {
		this.userAuth = userAuth;
		this.langService = langManager;
	}

	/**
	 * 处理使用用户名和密码登录
	 *
	 * @param player
	 * @param account
	 * @param password
	 */
	public void playerLogin(Player player, String account, String password, String source) {
		// 在PlayerCookieLoginOperation 之前设置source，为了登录验证时，串local登录参数
		player.setSource(source);
		UserAuth thisUserAuth = userAuth;
		//XXX 换平台
		if(null != player.getAuthPlatform()){
			thisUserAuth = AuthPlatform.buildOtherPlatform(player);
		}
		PlayerLoginOperation _loadTask = new PlayerLoginOperation(player, account, password, source, thisUserAuth, langService);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(_loadTask);
	}

	/**
	 * 处理使用cookie登录
	 *
	 * @param player
	 * @param account
	 * @param password
	 */
	public void playerCookieLogin(Player player, String cookieValue, String source) {
		// 在PlayerCookieLoginOperation 之前设置source，为了登录验证时，串local登录参数
		player.setSource(source);
		UserAuth thisUserAuth = userAuth;
		//XXX 换平台
		if(null != player.getAuthPlatform()){
			thisUserAuth = AuthPlatform.buildOtherPlatform(player);
		}
		PlayerCookieLoginOperation _loadTask = new PlayerCookieLoginOperation(player, cookieValue, thisUserAuth, langService);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(_loadTask);
	}
	
	
	public void playerTokenLogin(Player player, String token, String pid, long rid, String source) {
		// 在PlayerCookieLoginOperation 之前设置source，为了登录验证时，串local登录参数
		player.setSource(source);
		
		PlayerTokenLoginOperation _loadTask = new PlayerTokenLoginOperation(player, token, pid, rid, Globals.getTokenUserAuthImpl(), langService);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(_loadTask);
	}

//	/**
//	 * 处理使用cookie登录
//	 *
//	 * @param player
//	 * @param account
//	 * @param password
//	 */
//	public void playerIosQuickLogin(Player player, String udid,String fValue,String source) {
//		PlayerIosQuickLoginOperation _loadTask = new PlayerIosQuickLoginOperation(player, udid,fValue,source, userAuth, langService);
//		Globals.getAsyncService().createOperationAndExecuteAtOnce(_loadTask);
//	}

//	/**
//	 * 绑定quick账号
//	 * @param player
//	 * @param account
//	 * @param password
//	 */
//	public void playerBandIosQuickLoginAccount(Player player, String account, String password) {
//		PlayerBandIosQuickLoginAuthAccountOperation operation = new PlayerBandIosQuickLoginAuthAccountOperation(player,account,password ,new BandIosQuickLoginCallback() {
//			@Override
//			public void afterCheckComplete(Player player, long bandPassportId,String accountName) {
//				if (player == null) {
//					return;
//				}
//				if (player.getHuman() == null) {
//					return;
//				}
//
//				PlayerBandIosQuickLoginAccountOperation operation = new PlayerBandIosQuickLoginAccountOperation(player,bandPassportId,accountName);
//				Globals.getAsyncService().createOperationAndExecuteAtOnce(operation,player.getRoleUUID());
//			}
//		});
//		Globals.getAsyncService().createOperationAndExecuteAtOnce(operation,player.getRoleUUID());
//	}

	/**
	 * 玩家选择角色
	 *
	 * @param player
	 * @param roleUUID
	 */
	public void selectRole(final Player player, final long roleUUID) {
		// 正常登录，设置为加载角色列表 状态
		player.setState(PlayerState.loading);
		
		//XXX 这里要从场景线程来触发，因为humanCache都是场景线程触发的，这样会等场景线程处理完了玩家离开场景，就能够取到缓存了
		IMessage msg = new SysInternalMessage() {
			@Override
			public void execute() {
				//XXX 修改为先从缓存中查看是否存在human，如果有，则直接用这个human，不再重新从db中加载了
				LoadPlayerRoleOperation _loadTask = new LoadPlayerRoleOperation(player, roleUUID);
				//check has human cache
				Human human = Globals.getHumanCacheService().getHuman(roleUUID);
				if (human != null) {
					//设置loadTask的humanCache，在下面的异步加载完毕后调用loadTask.doStop
					_loadTask.setHumanCache(human);
					
					//加载player设置permission
					LoadPlayerAccountOperation op = new LoadPlayerAccountOperation(player, roleUUID, _loadTask);
					Globals.getAsyncService().createOperationAndExecuteAtOnce(op);
					//记录日志
					Loggers.loginLogger.info("#LoginLogicalProcessor#selectRole 119humanCache pid=" 
							+ player.getPassportId() + ";ip=" + player.getClientIp() + ";state=" + player.getState());
				} else {
					//异步加载角色列表
					Globals.getAsyncService().createOperationAndExecuteAtOnce(_loadTask);
				}
			}
		};
		
		Globals.getSceneService().getCommonScene().putMessage(msg);
	}
	
	/**
	 * 检查玩家能否创建角色，每个服务器Id只能创建一个角色
	 * @param player
	 * @return
	 */
	public boolean canCreateRole(Player player, List<RoleInfo> roles) {
		int count = 0;
		// 检查是否达到角色数上限
		for (RoleInfo role : roles) {
			if (role.getServerId() == player.getFromServerId()) {
				count++;
			}
		}
		if (count < SharedConstants.MAX_ROLE_PER_PLAYER) {
			return true;
		}
		return false;
	}

	/**
	 * 处理玩家创建角色
	 *
	 * @param player
	 * @param role
	 */
	public void createRole(Player player, RoleInfo role, PlayerSelection selection) {
		if (player.isCreatingRole()) {
			Loggers.gameLogger.error(
					ErrorsUtil.error(
							"Duplicate.create.role", 
							"#PlayerMessageHandler.handleCreateRole", 
							String.format("playerId = %d", player.getRoleUUID())
							));
			player.sendErrorMessage(LangConstants.DUPLICATE_CREATE_ROLE);
			return;
		}
		
		// 检查是否达到角色数上限
		if (!canCreateRole(player, player.getRoles())) {
			player.sendErrorMessage(langService.read(LangConstants.NULL_ROLE_NAME));
			return;
		}

		String name = role.getName();

		if (name == null || name.equals("")) {
			player.sendErrorMessage(Globals.getLangService().getSysLangSerivce().read(LangConstants.DUPLICATE_ROLE_NAME));
			return;
		}

		// 判断姓名是否合法
		String _checkInputError = Globals.getDirtFilterService().checkInput(WordCheckType.NAME, name, LangConstants.GAME_INPUT_TYPE_CHARACTER_NAME,
				SharedConstants.MIN_NAME_LENGTH_ENG, SharedConstants.MAX_NAME_LENGTH_ENG, false);

		if (_checkInputError != null) {
			GCFailedMsg msg = new GCFailedMsg();
			msg.setErrMsg(_checkInputError);
			player.sendMessage(msg);
			return;
		}

		// 判断玩家姓名是否重复
		if (Globals.getOnlinePlayerService().loadPlayerByName(name) != null) {
			player.sendErrorMessage(Globals.getLangService().getSysLangSerivce().read(LangConstants.DUPLICATE_ROLE_NAME));
			return;
		}
//		// 判断武将选项的合法性
//		if (!Globals.getTemplateCacheService().getPetTemplateCache().checkSelectPetTemplateId(role.getSelection().getPetTemplateId())) {
//			player.sendErrorMessage(Globals.getLangService().getSysLangSerivce().read(LangConstants.PET_TEMPLATE_IS_NOT_EXIST));
//			return;
//		}
		
		player.setCreatingRole(true);
		
		// 所有判断都在状态更新之前,否则状态混乱
		player.setState(PlayerState.creatingrole);

		// 异步保存到DBS
		CreateRoleOperation _createTask = new CreateRoleOperation(player, role);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(_createTask);
	}

	/**
	 * 玩家登录时的接口方法
	 *
	 * @param player
	 * @return
	 */
	public boolean loadCharacters(Player player, boolean isForwardEnter, long charId) {
		// 正常登录，设置为加载角色列表 状态
		player.setState(PlayerState.loadingrolelist);
		// 异步加载角色列表
		PlayerRolesLoad _loadTask = new PlayerRolesLoad(player, isForwardEnter, charId);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(_loadTask);
		return true;
	}

	/**
	 * 结束异步加载角色列表流程 ： 加载完成后续处理
	 *
	 * . 如果是第一次创建角色，则直接进入游戏 . 如果不是，则发送列表给客户端
	 *
	 * @param player
	 */
	public void onCharsLoad(Player player, boolean isForwardEnter, long charId) {
		// XXX 目前前台写死的就用第一个角色，所以这里处理就给客户端返回一个角色
		List<RoleInfo> roleList = player.getRoles();
		List<RoleInfo> clientRole = new ArrayList<RoleInfo>();
		if (roleList != null && !roleList.isEmpty()) {
			// 找命中的角色，如果没找到，就会返回前台空，然后创建角色
			RoleInfo bingoRole = null;
			// qq平台通过服直接进入，所以需要按服务器Id匹配进入角色
			if (Globals.getServerConfig().getIsDebug()) {// 增加debug情况，测试用
				for (RoleInfo roleInfo : roleList) {
					// fromServerId做了容错，非法时为本服的serverId，所以如果玩家该服有角色就会走到这里
					if (roleInfo.getServerId() == player.getFromServerId()) {
						bingoRole = roleInfo;
						break;
					}
				}
			} else { 
				// 默认取第一个角色，sql是按创建时间排序的，即最早创建的
				clientRole.add(roleList.get(0));
				if (charId > 0) {
					for (RoleInfo roleInfo : roleList) {
						if (roleInfo.getRoleUUID() == charId) {
							bingoRole = roleInfo;
							break;
						}
					}
				}
			}
			
			if (bingoRole != null) {
				clientRole.clear();
				clientRole.add(bingoRole);
			}
		}
		
		player.setState(PlayerState.waitingselectrole);
		
//		//XXX 测试消息用
//		String passportId = player.getPassportId() + ";playergetPassportIdplayergetPassportIdplayergetPassportIdplayergetPassportIdplayergetPassportIdplayergetPassportIdplayergetPassportIdplayergetPassportIdplayergetPassportIdplayergetPassportIdplayergetPassportIdplayergetPassportId";
		
		GCRoleList roleListMsg = new GCRoleList(clientRole.toArray(new RoleInfo[0]), 0, player.getPassportId());
		player.sendMessage(roleListMsg);
		
		if(Loggers.loginLogger.isInfoEnabled()){
			if(roleList == null || roleList.size() <= 0){
				Loggers.localLogger.info("LoginLogicalProcessor.onCharsLoad charId = " + charId + ", role list is empty");
			}
		}
	}

	/**
	 * 获取随机角色名
	 *
	 * @return
	 */
	public void getRoleRandomName(Player player, int sex) {
		String name = randomName(sex);
		
		GCRoleRandomName gcRoleRandomName = new GCRoleRandomName();
		gcRoleRandomName.setName(name);
		player.sendMessage(gcRoleRandomName);
	}
	
	public String randomName(int sex) {
		String name = "";
		Map<Integer, RoleNameXingTemplate> xingTpl = Globals.getTemplateCacheService()
				.getAll(RoleNameXingTemplate.class);
		int xingId = MathUtils.random(1, xingTpl.size());
		
		// 如果性别参数错误，就当男性玩家处理
		if (sex == RoleConstants.FEMALE) {
			Map<Integer, RoleNameFemaleMingTemplate> mingTpl = Globals.getTemplateCacheService()
					.getAll(RoleNameFemaleMingTemplate.class);
			int mingId = MathUtils.random(1, mingTpl.size());
			name = xingTpl.get(xingId).getWord() + mingTpl.get(mingId).getWord();
		} else {
			Map<Integer, RoleNameMaleMingTemplate> mingTpl = Globals.getTemplateCacheService()
					.getAll(RoleNameMaleMingTemplate.class);
			int mingId = MathUtils.random(1, mingTpl.size());
			name = xingTpl.get(xingId).getWord() + mingTpl.get(mingId).getWord();
		}
		return name;
	}
	
}
