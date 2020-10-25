package com.imop.lj.gameserver.player.msg;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.msg.GCPing;
import com.imop.lj.gameserver.human.Human;

/**
 * 检查玩家是否有未领取的奖励消息，会弹出奖励面板
 * 注意：最后需要通知前台，所有登录需要弹出的面板已经发完，然后前台开始处理，这个消息必须在最后发
 * 
 * @author yu.zhao
 *
 */
public class PlayerCheckNeedGiveRewardMsg extends SysInternalMessage {

	private Human human;
	
	public PlayerCheckNeedGiveRewardMsg(Human human) {
		this.human = human;
	}
	
	@Override
	public void execute() {
		// 挂机检查，体力恢复检查
		human.checkPowerRelated();
		// 检查奖励
		checkReward();
		// 检查弹出面板
		checkPopPanel();
		// 防沉迷提示
		checkWallowNotice();
		//发给客户端服务器时间
		sendServerTime();
		//登录弹出面板
		loginPopPanel();
		// 所有登录弹出面板结束
		allPopPanelEnd();
	}
	
	// 检查奖励
	private void checkReward() {
		// 离线奖励中，登录自动给的奖励
		Globals.getOfflineRewardService().giveAutoSendOfflineReward(human);
//		// 每日首充，登陆做离线未领奖励发邮件
//		Globals.getEverydayChargeGiftService().onLogin(human);
//		// 演武--登陆计算离线经验
//		Globals.getPracticeService().onPlayerLogin(human.getCharId());
//		// 宝石迷阵，登录时检查是否需要给精力
//		Globals.getGemMazeService().isOver0Clock(human);
		
		//登录自动给所有骑宠
		//Globals.getPetService().testGiveAllHorse(human);
	}
	
	/**
	 * 检查玩家登录时需要弹出的面板
	 */
	private void checkPopPanel() {
//		// 选择国家面板
//		Globals.getCountryService().onRoleEnter(human);
//		// 关卡检查是否有未领取的奖励面板
//		Globals.getMissionService().checkNeedGiveReward(human);
//		// 副本检查是否有未领取的奖励面板
//		Globals.getRaidService().checkNeedGiveReward(human);
//		// 检查经典战役是否有未领取的奖励
//		Globals.getClassicBattleService().checkNeedGiveReward(human);
		
		//检查战斗
		Globals.getBattleService().onPlayerLogin(human);
		Globals.getPvpService().onPlayerLogin(human);
		Globals.getTeamService().onPlayerLogin(human);
		
		//检查绿野仙踪进度
		Globals.getWizardRaidService().onPlayerLogin(human);
		//军团战检查
		Globals.getCorpsWarService().onPlayerLogin(human);
		//nvn联赛检查
		Globals.getNvnService().onPlayerLogin(human);
	}
	
	private void sendServerTime() {
		human.sendMessage(new GCPing(Globals.getTimeService().now()));
	}
	
	/**
	 * 通知前台弹出面板的消息都已经结束
	 */
	private void allPopPanelEnd() {
		human.sendMessage(new GCPopupPanelEnd());
	}
	
	/**
	 * 防沉迷弹框提示
	 */
	private void checkWallowNotice() {
		if (human != null && human.getPlayer() != null) {
			if (human.getPlayer().isWallowPlayer()) {
				human.sendMessage(new GCWallowLoginNotice(
						Globals.getLangService().readSysLang(LangConstants.WALLOW_PLAYER_LOGIN_NOTICE)));
			}
		}
	}

	/**
	 * 登录弹出面板逻辑
	 */
	private void loginPopPanel() {
		Globals.getDay7TargetService().loginPopPanel(human);
	}
}
