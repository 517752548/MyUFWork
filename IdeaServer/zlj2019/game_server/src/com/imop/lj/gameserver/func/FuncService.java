package com.imop.lj.gameserver.func;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.model.human.FuncShowInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.OpenFuncEvent;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.func.template.FuncOpenTemplate;
import com.imop.lj.gameserver.func.template.FuncTemplate;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.msg.GCFuncList;
import com.imop.lj.gameserver.human.msg.GCFuncUpdate;
import com.imop.lj.gameserver.offlinedata.UserSnap;

/**
 * 功能服务
 * @author yu.zhao
 *
 */
public class FuncService implements InitializeRequired {
	
	public FuncService() {
		
	}
	
	@Override
	public void init() {
		
	}
	
	/**
	 * 玩家是否开启了某功能
	 * 
	 * @param human
	 * @param funcType
	 * @return
	 */
	public boolean hasOpenedFunc(Human human, FuncTypeEnum funcType) {
		if (human == null || human.getFuncManager() == null) {
			return false;
		}
		
		return human.getFuncManager().hasOpenedFunc(funcType);
	}
	
	/**
	 * 玩家是否开启了某功能，从离线数据判断
	 * 
	 * @param userSnapId
	 * @param funcType
	 * @return
	 */
	public boolean hasOpenedFunc(long userSnapId, FuncTypeEnum funcType){
		UserSnap snap = Globals.getOfflineDataService().getUserSnap(userSnapId);
		if(snap == null){
			return false;
		}
		
		return snap.getFuncArray().contains(funcType.getIndex());
	}
	
	/**
	 * 玩家登录时，发功能按钮消息列表，并更新玩家当前按钮的状态
	 * 
	 * @param human
	 */
	public void sendFuncListOnLogin(Human human) {
		if (human == null || human.getFuncManager() == null) {
			return;
		}
		
		List<FuncShowInfo> funcInfoList = new ArrayList<FuncShowInfo>();
		Map<FuncTypeEnum, AbstractFunc> funcMap = human.getFuncManager().getFuncMap();
		for (AbstractFunc func : funcMap.values()) {
			// 如果这里要调用一下init，需要跟前台一致，前台也需要先清除一下当前的按钮，然后再按发的列表处理 XXX
			FuncTemplate funcTpl = Globals.getTemplateCacheService().get(func.getFuncType().getIndex(), FuncTemplate.class);
			if (funcTpl.hasBtn()) {
				// 加入列表
				funcInfoList.add(buildFuncShowInfo(func));
				// 按钮状态消息构建好后，需要更新一下按钮当前状态
				func.onChanged();
			}
		}
		
		// 给玩家发功能按钮列表消息
		human.sendMessage(new GCFuncList(funcInfoList.toArray(new FuncShowInfo[0])));
	}
	
	/**
	 * 按钮状态变化时，给玩家发单个按钮更新的消息
	 * 
	 * @param human
	 * @param funcType
	 */
	public void onFuncChanged(Human human, FuncTypeEnum funcType) {
		onFuncChanged(human, funcType, false);
		
		//XXX 精彩活动拆成了两个funcId，所以这里特殊处理下，外面就只调用原来的就可以
		if (funcType == FuncTypeEnum.GOOD_ACTIVITY) {
			onFuncChanged(human, FuncTypeEnum.GOOD_ACTIVITY2, false);
		}
	}
	
	/**
	 * 功能按钮变化时，给前台发消息
	 * @param human
	 * @param funcType
	 * @param isFirstOpen 是否首次开启功能
	 */
	protected void onFuncChanged(Human human, FuncTypeEnum funcType, boolean isFirstOpen) {
		if (human == null || human.getFuncManager() == null || funcType == null) {
			return;
		}
		AbstractFunc func = human.getFuncManager().getFunc(funcType);
		if (null == func) {
			return;
		}
		FuncTemplate funcTpl = Globals.getTemplateCacheService().get(func.getFuncType().getIndex(), FuncTemplate.class);
		boolean isChanged = func.onChanged();
		// 如果按钮状态发生了变化，且该功能有按钮，则给前台发消息
		if (isChanged && funcTpl.hasBtn()) {
			FuncShowInfo funcInfo = buildFuncShowInfo(func);
			// 是否第一次开启
			funcInfo.setIsFirstOpen(isFirstOpen ? 1 : 0);
			// 给玩家发按钮更新的消息
			human.sendMessage(new GCFuncUpdate(funcInfo));
		}
	}
	
	/**
	 * 完成任务后，开启新的功能
	 * @param human
	 * @param questId
	 */
	public void onFinishQuest(Human human, int questId) {
		if (human == null || human.getFuncManager() == null) {
			return;
		}
		
		// 是否有新的功能需要开启
		Set<FuncOpenTemplate> limitOpenedFuncTplSet = Globals.getTemplateCacheService().getFuncTemplateCache().getOpenedFuncListByQuest(questId);
		openFuncByTplList(human, limitOpenedFuncTplSet);
	}
	
	/**
	 * 通过关卡后，开启新的功能
	 * @param human
	 * @param missionId
	 */
	public void onPassMission(Human human, int missionId) {
		if (human == null || human.getFuncManager() == null) {
			return;
		}
		
		// 是否有新的功能需要开启
		Set<FuncOpenTemplate> limitOpenedFuncTplSet = Globals.getTemplateCacheService().getFuncTemplateCache().getOpenedFuncListByMission(missionId);
		openFuncByTplList(human, limitOpenedFuncTplSet);
	}
	
	/**
	 * 升级后，开启新的功能
	 * @param human
	 */
	public void onLevelUp(Human human) {
		if (human == null || human.getFuncManager() == null) {
			return;
		}
		
		int level = human.getLevel();
		// 是否有新的功能需要开启
		Set<FuncOpenTemplate> limitOpenedFuncTplSet = Globals.getTemplateCacheService().getFuncTemplateCache().getOpenedFuncListByLevel(level);
		openFuncByTplList(human, limitOpenedFuncTplSet);
	}
	
	/**
	 * vip变化，开启新的功能
	 * @param human
	 * @param chargeDiamond
	 */
	public void onVipChanged(Human human) {
		if (human == null || human.getPlayer() == null) {
			return;
		}
		
		int vipLevel = Globals.getVipService().getCurVipLevel(human.getUUID());
		// 是否有新的功能需要开启
		Set<FuncOpenTemplate> limitOpenedFuncTplSet = Globals.getTemplateCacheService().getFuncTemplateCache().getOpenedFuncListByVipLevel(vipLevel);
		openFuncByTplList(human, limitOpenedFuncTplSet);
	}
	
	public void onPveFightEnd(Human human, int enemyArmyId) {
		if (human == null || human.getFuncManager() == null) {
			return;
		}
		
		// 是否有新的功能需要开启
		Set<FuncOpenTemplate> limitOpenedFuncTplSet = Globals.getTemplateCacheService().getFuncTemplateCache().getOpenedFuncListByEnemyArmyId(enemyArmyId);
		openFuncByTplList(human, limitOpenedFuncTplSet);
	}
	
	/**
	 * 按照模板列表开启相应的功能
	 * @param human
	 * @param limitOpenedFuncTplSet
	 */
	protected void openFuncByTplList(Human human, Set<FuncOpenTemplate> limitOpenedFuncTplSet) {
		if (null == limitOpenedFuncTplSet || limitOpenedFuncTplSet.isEmpty()) {
			return;
		}
		
		// 遍历功能模板列表
		for (FuncOpenTemplate funcOpenTpl : limitOpenedFuncTplSet) {
			// 检查玩家是否达到开启该功能的条件 
			if (!checkOpenCond(human, funcOpenTpl)) {
				// 不满足功能开启的限制条件，不能开启
				continue;
			}
			
			// 开启新功能
			FuncTypeEnum funcType = FuncTypeEnum.valueOf(funcOpenTpl.getId());
			// 这里单个发消息，因为功能按钮一次不会开太多，所以先这样，如果有太多的再改为发list
			openNewFunc(human, funcType, true);
		}
	}
	
	/**
	 * 根据功能开启模板判断玩家能否开启该功能
	 * @param human
	 * @param funcOpenTpl
	 * @return
	 */
	protected boolean checkOpenCond(Human human, FuncOpenTemplate funcOpenTpl) {
		boolean flag = false;
		boolean questFlag = true;
		boolean missionFlag = true;
		boolean levelFlag = true;
		boolean vipLevelFlag = true;
		boolean enemyArmyFlag = true;
		
		// 任务限制
		int limitQuestId = funcOpenTpl.getLimitQuestId();
		if (limitQuestId > 0) {
			if (human.getCommonTaskManager() != null) {
				questFlag = human.getCommonTaskManager().isFinished(limitQuestId);
			} else {
				questFlag = false;
			}
		}
		
//		// 关卡限制
//		int limitMissionId = funcOpenTpl.getLimitMissionId();
//		if (limitMissionId > 0) {
//			missionFlag = Globals.getMissionService().isPassMissionEnemy(human, limitMissionId);
//		}
		
		// 等级限制
		if (funcOpenTpl.getLimitLevel() > 0) {
			levelFlag = human.getLevel() >= funcOpenTpl.getLimitLevel();
		}
		
		// vip等级限制
		if (funcOpenTpl.getLimitVipLevel() > 0) {
			vipLevelFlag = Globals.getVipService().getCurVipLevel(human.getUUID()) >= funcOpenTpl.getLimitVipLevel();
		}
		
//		// enemyArmy限制
//		int limitEnemyArmyId = funcOpenTpl.getLimitEnemyArmyId();
//		if (limitEnemyArmyId > 0) {
//			enemyArmyFlag = human.getEnemyArmyManager().isEnemyArmyDefeated(limitEnemyArmyId);
//		}
		
		// 各个条件是否是否 或 的关系
		if (funcOpenTpl.isOr()) {
			flag = questFlag | missionFlag | levelFlag | vipLevelFlag | enemyArmyFlag;
		} else {
			flag = questFlag & missionFlag & levelFlag & vipLevelFlag & enemyArmyFlag;
		}
		
		return flag;
	}
	
	/**
	 * 开启需要开启的功能，玩家登录时调用
	 * @param human
	 */
	public void openNeedOpenFuncOnLogin(Human human) {
		// 将默认功能给玩家开启
//		Set<FuncTypeEnum> defaultOpenedFuncSet = Globals.getTemplateCacheService().getFuncTemplateCache().getDefaultOpenedFuncSet();
//		for (FuncTypeEnum funcType : defaultOpenedFuncSet) {
//			openNewFunc(human, funcType, false);
//		}
		// 检查其他功能按钮，可能配置表改过，玩家之前达到过条件，所以需要再都检测一遍
		FuncTypeEnum[] funcArr = FuncTypeEnum.values();
		for (int i = 0; i < funcArr.length; i++) {
			FuncTypeEnum funcType = funcArr[i];
			FuncOpenTemplate funcOpenTpl = Globals.getTemplateCacheService().get(funcType.getIndex(), FuncOpenTemplate.class);
			// 检查玩家是否达到开启该功能的条件 
			if (!checkOpenCond(human, funcOpenTpl)) {
				// 不满足功能开启的限制条件，不能开启
				continue;
			}
			openNewFunc(human, funcType, false);
		}
	}
	
	/**
	 * 开启一个新功能
	 * @param human
	 * @param funcType
	 */
	protected void openNewFunc(Human human, FuncTypeEnum funcType, boolean needNotify) {
		if (human.getFuncManager().addFunc(funcType)) {
			// 如果成功添加该功能，则调用按钮更新的方法，给前台发消息
			if (needNotify) {
				onFuncChanged(human, funcType, true);
			}
			
			// 开启一个新功能时的监听
			Globals.getEventService().fireEvent(new OpenFuncEvent(human, funcType));
		}
	}
	
	/**
	 * 根据功能对象构建功能显示对象
	 * 
	 * @param func
	 * @return
	 */
	protected FuncShowInfo buildFuncShowInfo(AbstractFunc func) {
		FuncShowInfo funcInfo = new FuncShowInfo();
		funcInfo.setFuncType(func.getFuncType().getIndex());
		funcInfo.setIsOpened(func.canOpen() ? 1 : 0);
		funcInfo.setShowNum(func.getShowNum());
		funcInfo.setCountDownTime(func.getCountDownTime());
		
		FuncTemplate funcTpl = Globals.getTemplateCacheService().get(func.getFuncType().getIndex(), FuncTemplate.class);
		funcInfo.setOwnerFuncType(funcTpl.getOwnerFuncType());
		funcInfo.setName(funcTpl.getName());
		funcInfo.setDesc(funcTpl.getDesc());
		funcInfo.setPosition(funcTpl.getPosition());
		funcInfo.setOrder(funcTpl.getOrder());
		funcInfo.setIcon(func.getIcon());
		funcInfo.setTotalCountDownTime(func.getMaxCountDownTime());
		funcInfo.setMenuDesc(func.getMenuDesc() );
		funcInfo.setGroupID(funcTpl.getGroupId());
		// 有特效时，显示特效对应的名字
		if (func.canShowEffect() && funcTpl.hasEffect()) {
			funcInfo.setEffect(funcTpl.getEffect());
			funcInfo.setName(funcTpl.getEffectName());
		}
		return funcInfo;
	}
	
	/////////gm命令相关//////////
	
	/**
	 * gm开启一个功能
	 */
	public void gmOpenFunc(Human human, FuncTypeEnum funcType) {
		openNewFunc(human, funcType, true);
	}
	
	/**
	 * gm开启所有功能
	 * @param human
	 */
	public void gmOpenAllFunc(Human human) {
		for (FuncTypeEnum funcType : FuncTypeEnum.values()) {
			gmOpenFunc(human, funcType);
		}
	}
	
	/**
	 * gm清除所有功能，只保留默认开启的功能
	 * @param human
	 */
	public void gmClearFunc(Human human) {
		Set<FuncTypeEnum> curSet = new HashSet<FuncTypeEnum>(human.getFuncManager().getOpenedFuncSet());
		human.getFuncManager().clearAll();
		// 旧功能消失
		for (FuncTypeEnum funcType : curSet) {
			onFuncChanged(human, funcType);
		}
		// 默认功能开启
		Set<FuncTypeEnum> defaultOpenedFuncSet = Globals.getTemplateCacheService().getFuncTemplateCache().getDefaultOpenedFuncSet();
		for (FuncTypeEnum funcType : defaultOpenedFuncSet) {
			gmOpenFunc(human, funcType);
		}
	}
	
}
