package com.imop.lj.gameserver.mysteryshop;

import net.sf.json.JSONObject;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.mysteryshop.MysteryShopDef.BuyState;

/**
 * 神秘商店物品信息
 * 
 * @author xiaowei.liu
 * 
 */
public class MSItem {
	public static final String ID_KEY = "id";
	public static final String STATE_KEY = "state";
	private int id;
	private BuyState state;

	public MSItem(int id, BuyState state) {
		this.id = id;
		this.state = state;
	}

	public static MSItem fromJson(String str) {
		JSONObject obj = JSONObject.fromObject(str);
		int id = JsonUtils.getInt(obj, ID_KEY);
		int stateId = JsonUtils.getInt(obj, STATE_KEY);

		return new MSItem(id, BuyState.valueOf(stateId));
	}

	public String toJson() {
		JSONObject obj = new JSONObject();
		obj.put(ID_KEY, this.id);
		obj.put(STATE_KEY, state == null ? 0 : state.getIndex());
		return obj.toString();
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public BuyState getState() {
		return state;
	}

	public void setState(BuyState state) {
		this.state = state;
	}

}
