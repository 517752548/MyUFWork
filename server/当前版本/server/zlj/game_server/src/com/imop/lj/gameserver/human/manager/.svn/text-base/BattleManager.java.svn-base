package com.imop.lj.gameserver.human.manager;

import net.sf.json.JSONObject;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.db.RoleDataHolder;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;

public class BattleManager implements JsonPropDataHolder, RoleDataHolder{
	
	private static String SPEED_KEY = "sp";
	
	/** 所属玩家 */
	private Human owner;
	/** 加速倍数 */
	private int speed;
	
	public BattleManager(Human human) {
		this.owner = human;
		this.speed = SharedConstants.REPORT_SPEED_DEFAULT;
	}

	public Human getOwner() {
		return owner;
	}

	public int getSpeed() {
		return speed;
	}

	public void setSpeed(int speed) {
		this.speed = speed;
		if (this.speed == 0) {
			this.speed = SharedConstants.REPORT_SPEED_DEFAULT;
		}
	}

	@Override
	public void checkAfterRoleLoad() {
		
	}

	@Override
	public void checkBeforeRoleEnter() {
		
	}

	@Override
	public String toJsonProp() {
		JSONObject json = new JSONObject();
		json.put(SPEED_KEY, getSpeed());
		return json.toString();
	}

	@Override
	public void loadJsonProp(String value) {
		if (value == null || value.isEmpty()) {
			return;
		}
		
		JSONObject json = JSONObject.fromObject(value);
		if (json == null || json.isNullObject() || json.isEmpty()) {
			return;
		}
		
		int speed = JsonUtils.getInt(json, SPEED_KEY);
		setSpeed(speed);
	}
}
