package com.imop.lj.gameserver.human.manager;

import net.sf.json.JSONObject;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;

/**
 * 行为记录管理器
 *
 */
public class SoundManager implements JsonPropDataHolder {

	/** 玩家角色 */
	private Human owner = null;

	private int isClosed;

	private final String soundKey = "sound";

	/**
	 * 类参数构造器
	 *
	 * @param human
	 * @throws IllegalArgumentException
	 *             if human == null
	 *
	 */
	public SoundManager(Human human) {
		this.owner = human;
	}

	public int getIsClosed() {
		return isClosed;
	}

	public void setIsClosed(int isClosed) {
		this.isClosed = isClosed;
		this.owner.setModified();
	}

	@Override
	public String toJsonProp() {
		JSONObject json = new JSONObject();
		json.put(soundKey, isClosed);
		return json.toString();
	}

	@Override
	public void loadJsonProp(String value) {
		if (value == null || value.length() <= 0) {
			return;
		}

		JSONObject json = JSONObject.fromObject(value);

		if (json.size() <= 0) {
			return;
		}
		this.isClosed = JsonUtils.getInt(json, soundKey);
	}
}
