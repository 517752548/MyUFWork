package com.imop.lj.gameserver.guide;

import java.util.HashSet;
import java.util.List;
import java.util.Set;

import net.sf.json.JSONArray;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.RoleDataHolder;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.guide.GuideDef.GuideType;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;

/**
 * 新手引导管理器
 * @author yu.zhao
 *
 */
public class GuideManager implements RoleDataHolder, JsonPropDataHolder{
	
	private Human owner;
	
	/** 已完成的新手引导模块 */
	private Set<GuideType> finishedGuideSet = new HashSet<GuideType>();
	
	/** 内存数据，玩家已完成新手引导的功能模块集合，登录时初始化 */
	private Set<FuncTypeEnum> finishedGuideFuncSet = new HashSet<FuncTypeEnum>();
	
	public GuideManager(Human owner) {
		this.owner = owner;
	}
	
	public Human getOwner() {
		return owner;
	}

	/**
	 * 是否完成了某新手引导
	 * @param guideType
	 * @return
	 */
	public boolean isFinishedGuide(GuideType guideType) {
		return finishedGuideSet.contains(guideType);
	}
	
	/**
	 * 添加已完成的新手引导
	 * @param guideType
	 * @return
	 */
	public boolean addFinishedGuide(GuideType guideType) {
		boolean flag = finishedGuideSet.add(guideType);
		if (flag) {
			Globals.getGuideService().sendFinishedGuideFuncOnFinishGuide(owner, guideType);
			owner.setModified();
		}
		return flag;
	}

	public Set<FuncTypeEnum> getFinishedGuideFuncSet() {
		return finishedGuideFuncSet;
	}

	/**
	 * 更新已完成的新手引导对应的功能模块列表
	 * @param finishedGuideFuncList
	 */
	public void updateFinishedGuideFuncSet(List<FuncTypeEnum> finishedGuideFuncList) {
		if (finishedGuideFuncList != null && !finishedGuideFuncList.isEmpty()) {
			this.finishedGuideFuncSet.addAll(finishedGuideFuncList);
		}
	}
	
	/**
	 * 添加一个已完成新手引导的功能模块
	 * @param funcType
	 * @return
	 */
	public boolean addFinishedGuideFuncSet(FuncTypeEnum funcType) {
		return this.finishedGuideFuncSet.add(funcType);
	}
	
	/**
	 * gm命令使用，清除所有新手引导
	 */
	public void clearAllGuide() {
		finishedGuideSet.clear();
		finishedGuideFuncSet.clear();
		owner.setModified();
	}

	@Override
	public String toJsonProp() {
		JSONArray jsonArr = new JSONArray();
		for (GuideType guideType : finishedGuideSet) {
			jsonArr.add(guideType.getIndex());
		}
		return jsonArr.toString();
	}

	@Override
	public void loadJsonProp(String value) {
		if (value == null || value.equalsIgnoreCase("")) {
			return;
		}
		JSONArray jsonArr = JSONArray.fromObject(value);
		if (jsonArr == null || jsonArr.isEmpty()) {
			return;
		}
		for (int i = 0; i < jsonArr.size(); i++) {
			GuideType guideType = GuideType.valueOf(jsonArr.getInt(i));
			if (null == guideType) {
				// 非法数据
				Loggers.humanLogger.error("#GuideManager#loadJsonProp#guideType is null!guideTypeId=" + 
						jsonArr.getInt(i) + ";humanId=" + owner.getUUID());
				continue;
			}
			// 加入已完成集合
			finishedGuideSet.add(guideType);
		}
	}

	@Override
	public void checkAfterRoleLoad() {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void checkBeforeRoleEnter() {
		// TODO Auto-generated method stub
		
	}
	
}
