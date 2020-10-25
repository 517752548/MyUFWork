package com.imop.lj.gameserver.human.manager;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

import net.sf.json.JSONArray;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.RoleDataHolder;
import com.imop.lj.gameserver.func.AbstractFunc;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;

/**
 * 玩家功能管理器
 * 策略：功能只增不减
 * 
 * @author yu.zhao
 *
 */
public class HumanFuncManager implements JsonPropDataHolder, RoleDataHolder {
	/** 所属玩家 */
	private Human owner;
	/** 已开启的功能集合 */
	private Set<FuncTypeEnum> openedFuncSet;
	/** 功能状态对象map */
	private Map<FuncTypeEnum, AbstractFunc> funcMap;
	
	public HumanFuncManager(Human human) {
		this.owner = human;
		openedFuncSet = new HashSet<FuncTypeEnum>();
		funcMap = new HashMap<FuncTypeEnum, AbstractFunc>();
	}
	
	/**
	 * 是否开启了某功能
	 * @param funcType
	 * @return
	 */
	public boolean hasOpenedFunc(FuncTypeEnum funcType) {
		return openedFuncSet.contains(funcType);
	}
	
	/**
	 * 开启一个新的功能
	 * @param funcType
	 */
	public boolean addFunc(FuncTypeEnum funcType) {
		if (hasOpenedFunc(funcType)) {
			return false;
		}
		openedFuncSet.add(funcType);
		// 创建新的功能按钮对象
		funcMap.put(funcType, funcType.getFuncFactory().createNewFunc(owner));
		owner.setModified();
		return true;
	}
	
	/**
	 * 获取一个功能对象
	 * @param funcType
	 * @return
	 */
	public AbstractFunc getFunc(FuncTypeEnum funcType) {
		return funcMap.get(funcType);
	}
	
	/**
	 * 获取功能对象Map
	 * @return
	 */
	public Map<FuncTypeEnum, AbstractFunc> getFuncMap() {
		return funcMap;
	}
	
	public Human getOwner() {
		return owner;
	}
	
	public Set<FuncTypeEnum> getOpenedFuncSet() {
		return openedFuncSet;
	}
	
	/**
	 * 清除玩家的所有功能，GM命令使用，其他地方不能调用
	 */
	public void clearAll() {
		openedFuncSet.clear();
	}

	@Override
	public String toJsonProp() {
		JSONArray jsonArr = new JSONArray();
		for (FuncTypeEnum funcType : openedFuncSet) {
			jsonArr.add(funcType.getIndex());
		}
		return jsonArr.toString();
	}

	@Override
	public void loadJsonProp(String value) {
		if (value == null || value.equalsIgnoreCase("")) {
			return;
		}
		JSONArray jsonArr = JSONArray.fromObject(value);
		if (jsonArr.isEmpty()) {
			return;
		}
		for (int i = 0; i < jsonArr.size(); i++) {
			FuncTypeEnum funcType = FuncTypeEnum.valueOf(jsonArr.getInt(i));
			if (null == funcType) {
				// 记录错误日志，可能是删除了某功能造成的非法数据 
				Loggers.humanLogger.error("#HumanFuncManager#loadJsonProp#funcType is null!funcTypeIndex=" + jsonArr.getInt(i));
				continue;
			}
			// 已开的功能直接算开启，不再校验条件
			addFunc(funcType);
		}
	}

	@Override
	public void checkAfterRoleLoad() {
		// 将默认功能给玩家开启
		Globals.getFuncService().openNeedOpenFuncOnLogin(owner);
		// 按钮状态为初始状态，在给前台发消息后才会改变状态，在FuncService.sendFuncListOnLogin方法中更新
	}

	@Override
	public void checkBeforeRoleEnter() {
		
	}

}
