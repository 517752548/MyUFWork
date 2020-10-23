package com.imop.lj.gameserver.vip;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.VipLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.db.model.VipEntity;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.PlayerChargeDiamondEvent;
import com.imop.lj.gameserver.common.event.VipStateChangeEvent;
import com.imop.lj.gameserver.exp.model.ExpConfigInfo;
import com.imop.lj.gameserver.exp.model.ExpResultInfo;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.msg.GCVipInfo;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.vip.VipDef.VipFuncTypeEnum;
import com.imop.lj.gameserver.vip.VipDef.VipLevel;
import com.imop.lj.gameserver.vip.VipDef.VipTypeEnum;
import com.imop.lj.gameserver.vip.template.VipUpgradeTemplate;

public class VipService implements InitializeRequired {
	/**
	 * 所有VIP Map
	 */
	protected Map<Long, Vip> vipMap;
	
	public VipService() {
		
	}

	@Override
	public void init() {
		vipMap = new HashMap<Long, Vip>();
		List<VipEntity> vipList = Globals.getDaoService().getVipDao().loadAllEntity();
		for (VipEntity entity : vipList) {
			Vip vip = new Vip();
			vip.fromEntity(entity);
			vipMap.put(vip.getRoleId(), vip);
		}
	}
	
	/**
	 * 通过roleId获取VIP
	 * 
	 * @param roleId
	 * @return
	 */
	protected Vip getVipByRoleId(long roleId) {
		return this.vipMap.get(roleId);
	}
	
	protected Vip getOrCreateVip(long roleId) {
		Vip vip = this.vipMap.get(roleId);
		if (vip == null) {
			vip = new Vip();
			vip.setRoleId(roleId);
			vip.active();
			vip.setModified();
			vipMap.put(vip.getRoleId(), vip);
		}
		return vip;
	}
	
	/**
	 * 检查某玩家是否具有指定VIP功能
	 * 
	 * @param human
	 * @param vipFuncTypeEnum
	 * @return
	 */
	public boolean checkVipRule(long roleId, VipFuncTypeEnum vipFuncTypeEnum) {
		Vip vip = getVipByRoleId(roleId);
		if (vip != null) {
			return Globals.getTemplateCacheService().getVipTemplateCache().checkVipRule(getCurVipLevel(vip), vipFuncTypeEnum);
		}
		return false;
	}
	
	/**
	 * 获取指定VIP功能的操作次数，若VIP未开启，则返回0
	 * 
	 * @param human
	 * @param vipTypeEnum
	 * @return
	 */
	public int getAddCountByVip(Human human, VipFuncTypeEnum vipFuncTypeEnum) {
		Vip vip = getVipByRoleId(human.getUUID());
		if (vip != null) {
			return Globals.getTemplateCacheService().getVipTemplateCache().getCountForVipTypeEnumOnOpen(getCurVipLevel(vip), vipFuncTypeEnum);
		}
		return 0;
	}
	
	/**
	 * 获取指定VIP功能的操作次数，若VIP未开启，则返回0
	 * 
	 * @param roleId
	 * @param vipTypeEnum
	 * @return
	 */
	public int getAddCountByVip(long roleId, VipFuncTypeEnum vipFuncTypeEnum) {
		Vip vip = getVipByRoleId(roleId);
		if (vip != null) {
			return Globals.getTemplateCacheService().getVipTemplateCache().getCountForVipTypeEnumOnOpen(getCurVipLevel(vip), vipFuncTypeEnum);
		}
		return 0;
	}
	
	/**
	 * 定时检查临时vip是否过期
	 * @param human
	 */
	public void checkVipExpire(Human human) {
		Vip vip = getVipByRoleId(human.getUUID());
		if (vip == null) {
			return;
		}
		//没有临时vip，不用check过期
		if (vip.getTmpLevel() <= 0) {
			return;
		}
		
		//临时vip过期
		if (vip.getExpireTime() <= Globals.getTimeService().now()) {
			//清空临时等级
			vip.setTmpLevel(0);
			//存库
			vip.setModified();
			
			//vip级别变化的事件监听
			Globals.getEventService().fireEvent(new VipStateChangeEvent(vip));
			
			//通知客户端
			noticeVipInfo(human, vip);
		}
	}
	
	public void onPlayerChargeDiamond(long roleId, int chargeDiamond, boolean isGM) {
		//增加经验
		if (chargeDiamond <= 0) {
			//非法，不应该走到这里
			Loggers.vipOperatingLogger.error("VipService#onPlayerChargeDiamondToFreeze chargeDiamond = " + chargeDiamond);
			return;
		}
		
		Vip vip = getOrCreateVip(roleId);
		long exp = chargeDiamond * Globals.getGameConstants().getChargeDiamondToExp();
		
		ExpConfigInfo info = Globals.getTemplateCacheService().getVipTemplateCache().getVipExpConfigInfo();
		ExpResultInfo result = Globals.getExpService().addExp(info, vip.getLevel(), vip.getExp(), exp);

		//设置数据
		vip.setLevel(result.getLevel());
		vip.setExp(result.getCurrencyExp());
		
		//更新数据库
		vip.setModified();
		
		//vip级别变化的事件监听
		if (result.isChangeLevel()) {
			Globals.getEventService().fireEvent(new VipStateChangeEvent(vip));
		}
		
		//通知客户端
		if (Globals.getTeamService().isPlayerOnline(roleId)) {
			noticeVipInfo(Globals.getOnlinePlayerService().getPlayer(roleId).getHuman(), vip);
			//记录日志
			if (!isGM) {
				Globals.getLogService().sendVipLog(Globals.getOnlinePlayerService().getPlayer(roleId).getHuman(), 
						VipLogReason.CHARGE, VipLogReason.CHARGE.getReasonText(), vip.getCharId(), exp, 0, 0, "", vip.toLog());
			}
		} else {
			//记录日志
			if (!isGM) {
				Globals.getLogService().sendVipLog(Globals.getOnlinePlayerService().getPlayer(roleId).getHuman(), 
						VipLogReason.CHARGE, VipLogReason.CHARGE.getReasonText(), vip.getCharId(), exp, 0, 0, "", vip.toLog());
			}
		}
	}
	
	public int getCurVipLevel(long roleId) {
		Vip vip = getVipByRoleId(roleId);
		if (vip != null) {
			return getCurVipLevel(vip);
		}
		return 0;
	}
	
	protected int getCurVipLevel(Vip vip) {
		int level = vip.getLevel();
		if (isTmpVip(vip)) {
			level = vip.getTmpLevel();
		}
		return level;
	}
	
	public boolean isVipLevelMax(Vip vip) {
		return getCurVipLevel(vip) >= VipDef.VipMaxLevel;
	}
	
	protected boolean isTmpVip(Vip vip) {
		return vip.getTmpLevel() > vip.getLevel() && 
				vip.getTmpLevel() > 0 && 
				vip.getExpireTime() > Globals.getTimeService().now();
	}
	
	public void noticeVipInfo(Human human, Vip vip) {
		GCVipInfo msg = new GCVipInfo();
		msg.setExp((int)vip.getExp());
		msg.setLevel(vip.getLevel());
		//是否充过钱
		msg.setIsCharge(human.getTotalCharge() > 0 ? 1 : 0);
		//每日奖励是否可领取
		msg.setCanGetDayReward(canGetVipDayReward(human, false) ? 1 : 0);
		
		//体验vip
		if (isTmpVip(vip)) {
			msg.setTmpLevel(vip.getTmpLevel());
			msg.setVType(VipTypeEnum.EXPERIENCE.getIndex());
			msg.setLeftTime(vip.getExpireTime() - Globals.getTimeService().now());
		}
		
		//通知客户端
		human.sendMessage(msg);
	}
	
	public void onLogin(Human human) {
		Vip vip = getVipByRoleId(human.getUUID());
		if (vip == null) {
			//不是vip，单独构建消息
			GCVipInfo msg = new GCVipInfo();
			msg.setIsCharge(human.getTotalCharge() > 0 ? 1 : 0);
			human.sendMessage(msg);
			return;
		}
		
		noticeVipInfo(human, vip);
	}
	
	protected boolean canGetVipDayReward(Human human, boolean needNotify) {
		int vipLevel = getCurVipLevel(human.getUUID());
		if (vipLevel <= 0) {
			return false;
		}
		
		VipUpgradeTemplate tpl = Globals.getTemplateCacheService().get(vipLevel, VipUpgradeTemplate.class);
		if (tpl == null || tpl.getDayRewardId() <= 0) {
			return false;
		}
		
		//是否已经领取今日奖励
		if (!human.getBehaviorManager().canDo(BehaviorTypeEnum.VIP_DAY_REWARD)) {
			if (needNotify) {
				human.sendErrorMessage(LangConstants.REWARD_HAS_RECEIVED);
			}
			return false;
		}
		return true;
	}
	
	/**
	 * 领取vip每日奖励
	 * @param human
	 */
	public void giveDayReward(Human human) {
		if (!canGetVipDayReward(human, true)) {
			return;
		}
		
		int vipLevel = getCurVipLevel(human.getUUID());
		VipUpgradeTemplate tpl = Globals.getTemplateCacheService().get(vipLevel, VipUpgradeTemplate.class);
		
		//是否已经领取今日奖励
		if (!human.getBehaviorManager().canDo(BehaviorTypeEnum.VIP_DAY_REWARD)) {
			human.sendErrorMessage(LangConstants.REWARD_HAS_RECEIVED);
			return;
		}
		
		//记录已领奖
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.VIP_DAY_REWARD);
		
		Reward reward = Globals.getRewardService().createReward(human.getUUID(), tpl.getDayRewardId(), "vip day");
		boolean flag = Globals.getRewardService().giveReward(human, reward, true);
		if (!flag) {
			Loggers.vipOperatingLogger.error("give vip day reward return false!humanId=" + human.getUUID() + ";vipLevel=" + vipLevel);
		}
		
		noticeVipInfo(human, getVipByRoleId(human.getUUID()));
	}
	
	public void useTmpVipCard(Human human, int tmpLevel, int dayNum) {
		VipLevel vl = VipLevel.valueOf(tmpLevel);
		if (vl == null || vl == VipLevel.VIP0) {
			return;
		}
		if (dayNum <= 0) {
			return;
		}
		
		onGiveTmpVip(human, tmpLevel, dayNum * TimeUtils.DAY);
	}
	
	protected void onGiveTmpVip(Human human, int tmpLevel, long validTime) {
		if (tmpLevel <= 0 || validTime <= 0) {
			return;
		}
		
		Vip vip = getOrCreateVip(human.getUUID());
		//临时vip
		vip.setTmpLevel(tmpLevel);
		vip.setExpireTime(Globals.getTimeService().now() + validTime);
		vip.setModified();
		
		//vip级别变化的事件监听
		Globals.getEventService().fireEvent(new VipStateChangeEvent(vip));
		
		//通知客户端
		noticeVipInfo(human, vip);
	}
	
	public void gmGiveTmpVip(Human human, int tmpLevel, int dayNum) {
		VipLevel vl = VipLevel.valueOf(tmpLevel);
		if (vl == null || vl == VipLevel.VIP0) {
			tmpLevel = VipLevel.VIP1.getIndex();
		}
		if (dayNum <= 0) {
			dayNum = 1;
		}
		
		onGiveTmpVip(human, tmpLevel, dayNum * TimeUtils.DAY);
	}
	
	/**
	 * GM增加VIP经验
	 * 
	 * @param human
	 * @param chargeDiamond
	 */
	public void onGmAddVipExp(final long roleId, final int gmExp) {
		if (!Globals.getOfflineDataService().hasUserSnapExist(roleId)) {
			Loggers.vipOperatingLogger.error("VipService.onGmAddVipExp roleId = " + roleId + ", gmExp = " + gmExp + ", user does not exist!!!");
			return;
		}
		
		if (Loggers.vipOperatingLogger.isWarnEnabled()) {
			Loggers.vipOperatingLogger.warn("VipService.onGmAddVipExp roleId = " + roleId + ", gmExp = " + gmExp + " start...");
		}
		
		//玩家在线，直接按充值的事件处理，比如精彩活动等可以监听，如果不在线，则只升vip
		if (Globals.getTeamService().isPlayerOnline(roleId)) {
			Globals.getEventService().fireEvent(new PlayerChargeDiamondEvent(Globals.getOnlinePlayerService().getPlayer(roleId).getHuman(), 
					gmExp, true));
		} else {
			onPlayerChargeDiamond(roleId, gmExp, true);
		}
		
		Vip vip = getVipByRoleId(roleId);
		
		String newData = vip.toLog();
		// 记日志
		Player player = Globals.getOnlinePlayerService().getPlayer(roleId);
		if (player == null || player.getHuman() == null){
			Globals.getLogService().sendVipLog(null, VipLogReason.GM_CHARGE, VipLogReason.GM_CHARGE.getReasonText(), vip.getCharId(), gmExp, 0, 0, "", newData);
		} else {
			Globals.getLogService().sendVipLog(player.getHuman(), VipLogReason.GM_CHARGE, VipLogReason.GM_CHARGE.getReasonText(), vip.getCharId(), gmExp, 0, 0, "", newData);
		}
		
		if(Loggers.vipOperatingLogger.isWarnEnabled()){
			Loggers.vipOperatingLogger.warn("VipService.onGmAddVipExp roleId = " + roleId + ", gmExp = " + gmExp + " end...");
		}
	}
	
}
