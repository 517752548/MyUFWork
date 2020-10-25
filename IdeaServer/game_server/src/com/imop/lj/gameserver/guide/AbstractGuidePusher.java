package com.imop.lj.gameserver.guide;

import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.guide.GuideDef.GuideType;
import com.imop.lj.gameserver.guide.msg.GCFuncHasGuide;
import com.imop.lj.gameserver.guide.msg.GCShowGuideInfo;
import com.imop.lj.gameserver.human.Human;

public abstract class AbstractGuidePusher implements IGuidePusher {

	protected GuideType guideType;
	
	public AbstractGuidePusher(GuideType guideType) {
		this.guideType = guideType;
	}
	
	public GuideType getGuideType() {
		return guideType;
	}

	/**
	 * 是否已经完成了该新手引导
	 * @param human
	 * @return
	 */
	public boolean isFinishedGuide(Human human) {
		if (human != null && human.getGuideManager() != null) {
			return human.getGuideManager().isFinishedGuide(guideType);
		}
		return false;
	}
	
	/**
	 * 通用的获取新手引导消息的方法
	 * @return
	 */
	public GCShowGuideInfo getGuideInfoMsg(Human human) {
		// 通用的方法，根据guideType获取新手引导消息
		GCShowGuideInfo gcShowGuideInfo = new GCShowGuideInfo();
		gcShowGuideInfo.setGuideTypeId(getGuideType().getIndex());
		gcShowGuideInfo.setGuideStepStr("");
		return gcShowGuideInfo;
	}
	
	/**
	 * 通用的记录玩家已完成该新手引导，并给前台发该新手引导的详细消息
	 */
	public void sendGuideInfo(Human human) {
		if (!checkCond(human)) {
			return;
		}
		
		// 完成新手引导
		human.getGuideManager().addFinishedGuide(guideType);
		
		// 发新手引导消息给玩家
		human.sendMessage(getGuideInfoMsg(human));
		
//		// 发kaiying的新手日志 TODO
//		Globals.getQQKaiYingLogService().sendGuideLog(human.getPlayer(), KaiyingLogGuideCat.GUIDE, guideType.getIndex());
	}
	
	/**
	 * 通知前台某功能有新手引导了，前台需要在对应的功能上添加引导箭头
	 */
	public void sendHasGuide(Human human) {
		if (!checkCond(human)) {
			return;
		}
		
		// 发消息通知前台某功能模块有新手引导
		FuncTypeEnum funcType = guideType.getFuncType();
		if (null != funcType) {
			human.sendMessage(new GCFuncHasGuide(funcType.getIndex()));
		}
	}
}
