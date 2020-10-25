package com.imop.lj.gameserver.chat;

import java.util.HashSet;
import java.util.Set;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;

public class ChatManager implements JsonPropDataHolder {
	public static final String LAST_CHAT_TIME_KEY = "1";
	public static final String CHAT_ROLE_SET_KEY = "2";
	private Human human;

	/** 最后一次聊天时间 */
	private long lastChatTime;
	/** 聊天角色列表 */
	private Set<Long> chatRoleSet = new HashSet<Long>();

	public ChatManager(Human human) {
		this.human = human;
	}

	@Override
	public String toJsonProp() {
		JSONObject obj = new JSONObject();
		obj.put(LAST_CHAT_TIME_KEY, this.lastChatTime);
		JSONArray array = new JSONArray();
		for (Long roleId : chatRoleSet) {
			array.add(roleId);
		}

		obj.put(CHAT_ROLE_SET_KEY, array.toString());
		return obj.toString();
	}

	@Override
	public void loadJsonProp(String value) {
		if (value == null || value.isEmpty()) {
			return;
		}

		JSONObject obj = JSONObject.fromObject(value);
		if (obj == null || obj.isEmpty()) {
			return;
		}

		this.lastChatTime = JsonUtils.getLong(obj, LAST_CHAT_TIME_KEY);
		String arrayStr = JsonUtils.getString(obj, CHAT_ROLE_SET_KEY);

		if (arrayStr != null && !arrayStr.isEmpty()) {
			JSONArray array = JSONArray.fromObject(arrayStr);
			if (array != null && !array.isEmpty()) {
				for (int i = 0; i < array.size(); i++) {
					long roleId = array.getLong(i);
					this.chatRoleSet.add(roleId);
				}
			}
		}
	}

	/**
	 * 如果当前聊天时间与最后一次聊天时间不在同一天，则重置
	 */
	public void flush() {
		if (TimeUtils.isSameDay(this.lastChatTime, Globals.getTimeService().now())) {
			return;
		}

		this.lastChatTime = Globals.getTimeService().now();
		this.chatRoleSet.clear();
		this.human.setModified();
	}

	public Set<Long> getChatRoleSet() {
		return chatRoleSet;
	}

	public void setChatRoleSet(Set<Long> chatRoleSet) {
		this.chatRoleSet = chatRoleSet;
	}

	public long getLastChatTime() {
		return lastChatTime;
	}

	public void setLastChatTime(long lastChatTime) {
		this.lastChatTime = lastChatTime;
	}

}
