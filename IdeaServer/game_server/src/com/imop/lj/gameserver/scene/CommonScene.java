package com.imop.lj.gameserver.scene;

import com.imop.lj.common.constants.CommonErrorLogInfo;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.persistance.AbstractSceneDataUpdater;
import com.imop.lj.core.util.ErrorsUtil;
import com.imop.lj.gameserver.battle.BattleExpiredChecker;
import com.imop.lj.gameserver.battle.pvp.PvpExpiredChecker;
import com.imop.lj.gameserver.broadcast.BroadcastHeartBeatChecker;
import com.imop.lj.gameserver.broadcast.WorldChatHeartBeatChecker;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTaskExecutorImpl;
import com.imop.lj.gameserver.corps.ClearCorpsWeekContributionChecker;
import com.imop.lj.gameserver.corps.ImpeachPresidentChecker;
import com.imop.lj.gameserver.corps.UpgradeCorpsChecker;
import com.imop.lj.gameserver.goodactivity.GoodActivityHeartBeatChecker;
import com.imop.lj.gameserver.mail.SysMailExpiredProcessor;
import com.imop.lj.gameserver.mall.MallProcesser;
import com.imop.lj.gameserver.map.PetIslandChecker;
import com.imop.lj.gameserver.map.SealDemonAndDevilChecker;
import com.imop.lj.gameserver.marry.MarryCheck;
import com.imop.lj.gameserver.overman.OvermanCheck;
import com.imop.lj.gameserver.player.OnlinePlayerService;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.redenvelope.RedEnvelopeChecker;
import com.imop.lj.gameserver.scene.template.SceneTemplate;
import com.imop.lj.gameserver.team.TeamBattleChecker;
import com.imop.lj.gameserver.team.TeamMemberChecker;
import com.imop.lj.gameserver.teampvp.TeamPvpBattleChecker;
import com.imop.lj.gameserver.title.TitleCheck;
import com.imop.lj.gameserver.trade.OverDueTradeChecker;
import com.imop.lj.gameserver.wizardraid.WizardRaidTeamChecker;
import com.imop.lj.gameserver.xianhu.XianhuCurRankChecker;

import net.sf.json.JSONArray;

/***
 * 公共场景
 *
 */
public class CommonScene extends Scene {
	/** 场景数据更新器 */
	private CommonDataUpdater commonDataUpdater;
	
	public CommonScene(SceneTemplate sceneTpl, OnlinePlayerService onlinePlayerService) {
		super(sceneTpl, onlinePlayerService);
		commonDataUpdater = new CommonDataUpdater();
		hbTaskExecutor = new HeartbeatTaskExecutorImpl();
		// 增加全服邮件过期的检测
		hbTaskExecutor.submit(new SysMailExpiredProcessor());
		hbTaskExecutor.submit(new SceneCheckTickTask(this));
		// 增加商城定时处理
		hbTaskExecutor.submit(new MallProcesser());
		// 精彩活动定时检测
		hbTaskExecutor.submit(new GoodActivityHeartBeatChecker());
		// 广播的定时检测
		hbTaskExecutor.submit(new BroadcastHeartBeatChecker());
		//检查过期的PVE战斗
		hbTaskExecutor.submit(new BattleExpiredChecker());
		//检查过期的PVP战斗
		hbTaskExecutor.submit(new PvpExpiredChecker());
		//检查过期的trade
		hbTaskExecutor.submit(new OverDueTradeChecker());
		//检查过期的红包
		hbTaskExecutor.submit(new RedEnvelopeChecker());
		//宠物岛刷怪检测
		hbTaskExecutor.submit(new PetIslandChecker());
		//野外封妖和混世魔王怪物超时检测
		hbTaskExecutor.submit(new SealDemonAndDevilChecker());
		//军团弹劾检测
		hbTaskExecutor.submit(new ImpeachPresidentChecker());
		//检查组队中离线的队员
		hbTaskExecutor.submit(new TeamMemberChecker());
		//检查组队中的战斗
		hbTaskExecutor.submit(new TeamBattleChecker());
		//检查组队pvp中的战斗
		hbTaskExecutor.submit(new TeamPvpBattleChecker());
		//绿野仙踪副本刷新检测
		hbTaskExecutor.submit(new WizardRaidTeamChecker());
		//师徒强制接触关系
		hbTaskExecutor.submit(new OvermanCheck());
		//结婚
		hbTaskExecutor.submit(new MarryCheck());
		//称号
		hbTaskExecutor.submit(new TitleCheck());
		//帮派升级完成检测
		hbTaskExecutor.submit(new UpgradeCorpsChecker());
		//帮派周帮贡清零检测
		hbTaskExecutor.submit(new ClearCorpsWeekContributionChecker());
		//世界聊天定时检查
		hbTaskExecutor.submit(new WorldChatHeartBeatChecker());
		//仙葫今日本周排名
		hbTaskExecutor.submit(new XianhuCurRankChecker());
		
	}

	@Override
	protected String toEntityProperties() {
		JSONArray ja = new JSONArray();
		return ja.toString();
	}

	@Override
	protected void fromEntityProperties(String props) {
	}
	
	@Override
	public boolean onPlayerEnter(Player player) {
		return false;
	}
	
	@Override
	public void tick() {
		super.processMsg();
		this.heartBeat();
	}
	
	/**
	 * 更新数据
	 */
	private void updateData() {
		try {
			this.commonDataUpdater.update();
		} catch (Exception e) {
			if (Loggers.updateLogger.isErrorEnabled()) {
				Loggers.updateLogger.error(ErrorsUtil.error(
						CommonErrorLogInfo.INVALID_STATE,
						"#GS.ServiceBuilder.CommonScene", ""), e);
			}
		}
	}
	
	@Override
	public void heartBeat() {
		this.updateData();
		hbTaskExecutor.onHeartBeat();
		
		sceneHeartbeat();
		Globals.getHumanCacheService().heartBeat();
	}
	
	/**
	 * 获取场景数据更新器
	 * @return
	 */
	public CommonDataUpdater getCommonDataUpdater(){
		return commonDataUpdater;
	}

	@Override
	public AbstractSceneDataUpdater getSceneDataUpdater() {
		return commonDataUpdater;
	}
	
	protected void sceneHeartbeat() {
		Globals.getPvpService().heartBeat();
		Globals.getTeamService().getTeamBattleLogic().heartBeat();
		Globals.getTeamPvpService().heartBeat();
		Globals.getNvnService().heartBeat();
	}
	
}
