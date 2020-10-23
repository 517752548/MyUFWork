package com.imop.lj.gameserver.human.manager;

import net.sf.json.JSONObject;

import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;

/**
 * 面板管理器
 *
 * @author haijiang.jin
 *
 */
public class PanelManager implements JsonPropDataHolder{

	/** 玩家角色 */
	private Human owner = null;

	/** 模板用户配置 */
	private JSONObject panelConfig;

	public PanelManager(Human owner){
		this.owner = owner;
		panelConfig = new JSONObject();
	}

	@Override
	public String toJsonProp() {
		return panelConfig.toString();
	}

	/**
	 * 读取可招募武将列表数据
	 *
	 * @param panelConfigPack
	 */
	@Override
	public void loadJsonProp(String panelConfigPack) {
		JSONObject panelConfig = JSONObject.fromObject(panelConfigPack);
		if (!panelConfig.isNullObject())
			this.panelConfig = panelConfig;
	}

	public void load() {

	}
}
