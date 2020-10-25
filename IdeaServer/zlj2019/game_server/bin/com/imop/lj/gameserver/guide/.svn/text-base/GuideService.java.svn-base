package com.imop.lj.gameserver.guide;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.guide.GuideDef.GuideType;
import com.imop.lj.gameserver.guide.msg.GCFinishedGuideByFunc;
import com.imop.lj.gameserver.guide.msg.GCFinishedGuideListByFunc;
import com.imop.lj.gameserver.guide.msg.GCFuncHasGuideList;
import com.imop.lj.gameserver.human.Human;

/**
 * 新手引导服务
 */
public class GuideService implements InitializeRequired {
	
	/** 新手引导pusher对象map，相当于每个引导对应的pusher都是单例 */
	protected Map<GuideType, AbstractGuidePusher> allPusherMap = new HashMap<GuideDef.GuideType, AbstractGuidePusher>();
	
	/** 功能模块对应的新手引导列表 */
	protected Map<FuncTypeEnum, List<GuideType>> funcGuideMap = new HashMap<FuncTypeEnum, List<GuideType>>();
	
	public GuideService() {
		
	}
	
	public void init() {
		GuideType[] guideTypeArr = GuideType.values();
		for (int i = 0; i < guideTypeArr.length; i++) {
			GuideType guideType = guideTypeArr[i];
			allPusherMap.put(guideType, guideType.getGuidePuserFactory().createGuidePusher());
			
			FuncTypeEnum funcType = guideType.getFuncType();
			if (null != funcType) {
				List<GuideType> funcGuideList = funcGuideMap.get(funcType);
				if (null == funcGuideList) {
					funcGuideList = new ArrayList<GuideType>();
					funcGuideMap.put(funcType, funcGuideList);
				}
				funcGuideList.add(guideType);
			}
		}
	}
	
	protected AbstractGuidePusher getGuidePusher(GuideType guideType) {
		return allPusherMap.get(guideType);
	}
	
	protected List<GuideType> getGuideTypeListByFuncType(FuncTypeEnum funcType) {
		return funcGuideMap.get(funcType);
	}
	
	/**
	 * 完成某新手引导，一些特殊的情况下由前台触发完成新手引导
	 * @param human
	 * @param guideType
	 */
	public void finishGuide(Human human, GuideType guideType) {
		if (human == null || guideType == null || human.getGuideManager() == null) {
			return;
		}
		
		human.getGuideManager().addFinishedGuide(guideType);
		
//		// 发kaiying的新手日志 TODO
//		Globals.getQQKaiYingLogService().sendGuideLog(human.getPlayer(), KaiyingLogGuideCat.GUIDE, guideType.getIndex());
	}
	
	//////////////////与功能模块相关的处理，主要是告知前台哪些功能模块的新手引导都完成了，这样前台在打开对应界面的时候就不再请求新手引导了////////////////////
	
	/**
	 * 获取玩家已完成的新手引导对应的功能列表
	 */
	public List<FuncTypeEnum> getFinishedGuideByFunc(Human human) {
		List<FuncTypeEnum> finishedFuncList = new ArrayList<FuncTypeEnum>();
		if (human != null && human.getGuideManager() != null) {
			for (Map.Entry<FuncTypeEnum, List<GuideType>> entry : funcGuideMap.entrySet()) {
				FuncTypeEnum funcType = entry.getKey();
				List<GuideType> guideTypeList = entry.getValue();
				boolean finishedAllFlag = true;
				for (GuideType guideType : guideTypeList) {
					if (!human.getGuideManager().isFinishedGuide(guideType)) {
						finishedAllFlag = false;
						break;
					}
				}
				if (finishedAllFlag) {
					finishedFuncList.add(funcType);
				}
			}
		}
		return finishedFuncList;
	}
	
	/**
	 * 登录时给玩家发已完成的新手引导功能模块列表
	 * @param human
	 */
	protected void sendFinishedGuideFuncListOnLogin(Human human) {
		// 发已完成的新手引导的功能模块列表，发消息
		List<FuncTypeEnum> finishedFuncList = getFinishedGuideByFunc(human);
		// 更新玩家已完成新手引导的功能模块列表
		human.getGuideManager().updateFinishedGuideFuncSet(finishedFuncList);
		
		int[] funcTypeIdArr = new int[finishedFuncList.size()];
		int i = 0;
		for (FuncTypeEnum funcType : finishedFuncList) {
			funcTypeIdArr[i++] = funcType.getIndex();
		}
		// 发消息
		human.sendMessage(new GCFinishedGuideListByFunc(funcTypeIdArr));
	}
	
	/**
	 * 完成一个新手引导后，玩家可能对应的功能模块的新手全完成了，需要通知前台
	 * @param human
	 * @param guideType
	 */
	public void sendFinishedGuideFuncOnFinishGuide(Human human, GuideType guideType) {
		FuncTypeEnum funcType = guideType.getFuncType();
		if (funcType == null) {
			return;
		}
		
		List<GuideType> guideTypeList = getGuideTypeListByFuncType(funcType);
		boolean finishedAllFlag = true;
		for (GuideType gt : guideTypeList) {
			if (!human.getGuideManager().isFinishedGuide(gt)) {
				finishedAllFlag = false;
				break;
			}
		}
		if (finishedAllFlag) {
			// 玩家该功能模块的新手已全部完成
			human.getGuideManager().addFinishedGuideFuncSet(funcType);
			// 给玩家发消息
			human.sendMessage(new GCFinishedGuideByFunc(funcType.getIndex()));
		}
	}
	
	/**
	 * 从属于某功能的新手引导信息，通过该方法获取
	 */
	public void showGuideInfoByFuncType(Human human, FuncTypeEnum funcType) {
		if (human == null || funcType == null) {
			return;
		}
		
		List<GuideType> guideTypeList = getGuideTypeListByFuncType(funcType);
		if (guideTypeList != null && !guideTypeList.isEmpty()) {
			for (GuideType guideType : guideTypeList) {
				sendGuideInfo(human, guideType);
			}
		}
	}
	
	///////////////////不从属于某功能的，单独由对应的地方调用的显示新手引导信息的方法/////////////////
	
	/**
	 * 登录时的操作
	 */
	public void onPlayerLogin(Human human) {
		// 发已完成的新手引导的功能模块列表
		sendFinishedGuideFuncListOnLogin(human);
		
		// 发登录的新手引导
		sendGuideInfo(human, GuideType.WELCOME);
		
		// 发有新手引导的功能模块列表
		sendHasGuideByFuncOnLogin(human);
	}
	
	/**
	 * 完成任务时会触发的新手引导
	 * @param human
	 */
	protected void sendGuideInfoOnFinishQuest(Human human) {
		sendGuideInfo(human, GuideType.USE_EQUIP);
		sendGuideInfo(human, GuideType.PET_FIGHT);
		
		sendGuideInfo(human, GuideType.SUB_SKILL_PROFICIENCY);
		sendGuideInfo(human, GuideType.MIND_LEVELUP);
		sendGuideInfo(human, GuideType.SKILL_LEVELUP);
	}
	
	/**
	 * 给前台发送新手引导信息，里面会根据条件判断是否要发
	 * @param human
	 * @param guideType
	 */
	protected void sendGuideInfo(Human human, GuideType guideType) {
		AbstractGuidePusher guidePusher = getGuidePusher(guideType);
		if (null == guidePusher) {
			return;
		}
		guidePusher.sendGuideInfo(human);
	}
	
	///////////////////通知前台某功能出现新手引导了/////////////////
	
	/**
	 * 完成任务需要做的操作，目前只有主线任务监听
	 */
	public void onFinishQuest(Human human, int questId) {
		
		// 完成任务后直接出发新手引导的
		sendGuideInfoOnFinishQuest(human);
	}
	
	/**
	 * 升级时触发的新手引导
	 * @param human
	 */
	public void onLevelUp(Human human) {
		sendGuideInfo(human, GuideType.LEVEL_REWARD);
		sendGuideInfo(human, GuideType.ADD_FRIEND);
	}
	
	/**
	 * 第一次pve战斗的新手引导
	 * @param human
	 */
	public void onStartPveBattle(Human human) {
		sendGuideInfo(human, GuideType.FIRST_BATTLE);
	}
	
	/**
	 * 功能开启的时候触发的新手引导
	 * @param human
	 * @param funcType
	 */
	public void onOpenFunc(Human human, FuncTypeEnum funcType) {
		if (funcGuideMap.get(funcType) != null) {
			for (GuideType guideType : funcGuideMap.get(funcType)) {
				if (guideType.isFuncOpenGuide()) {
					sendHasGuide(human, guideType);
				}
			}
		}
	}
	
	/**
	 * 添加武将时触发的新手引导
	 * @param human
	 */
	public void onAddPet(Human human) {
//		sendHasGuide(human, GuideType.PET_ADD_FIRST);
//		sendHasGuide(human, GuideType.PET_ADD_SECOND);
	}
	
	/**
	 * 登录时通知前台哪些功能模块有新手引导了
	 * @param human
	 */
	protected void sendHasGuideByFuncOnLogin(Human human) {
		List<FuncTypeEnum> hasGuideFuncList = new ArrayList<FuncTypeEnum>();
		// 针对绑定功能Id的新手引导，查找是否有需要显示的
		for (Map.Entry<FuncTypeEnum, List<GuideType>> entry : funcGuideMap.entrySet()) {
			FuncTypeEnum funcType = entry.getKey();
			List<GuideType> guideTypeList = entry.getValue();
			boolean hasGuideFlag = false;
			for (GuideType guideType : guideTypeList) {
				AbstractGuidePusher guidePusher = getGuidePusher(guideType);
				if (null == guidePusher) {
					continue;
				}
				// 玩家满足发送新手引导的条件
				if (guidePusher.checkCond(human)) {
					hasGuideFlag = true;
					break;
				}
			}
			if (hasGuideFlag) {
				hasGuideFuncList.add(funcType);
			}
		}
		
		// 给前台发消息
		int[] funcTypeIdArr = new int[hasGuideFuncList.size()];
		int i = 0;
		for (FuncTypeEnum funcType : hasGuideFuncList) {
			funcTypeIdArr[i++] = funcType.getIndex();
		}
		human.sendMessage(new GCFuncHasGuideList(funcTypeIdArr));
	}
	
	protected void sendHasGuide(Human human, GuideType guideType) {
		AbstractGuidePusher guidePusher = getGuidePusher(guideType);
		if (null == guidePusher) {
			return;
		}
		guidePusher.sendHasGuide(human);
	}
	
	/**
	 * gm强制显示某新手引导
	 * @param human
	 * @param guideType
	 */
	public void gmShowGuideInfo(Human human, GuideType guideType) {
		AbstractGuidePusher guidePusher = getGuidePusher(guideType);
		if (null == guidePusher) {
			return;
		}
		
		// 完成新手引导
		human.getGuideManager().addFinishedGuide(guideType);
		
		// 发新手引导消息给玩家
		human.sendMessage(guidePusher.getGuideInfoMsg(human));
	}
}
