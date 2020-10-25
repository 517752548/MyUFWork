package com.imop.lj.gameserver.allocate.model;

import com.imop.lj.gameserver.human.JsonPropDataHolder;
import com.renren.games.api.util.JsonUtils;

import net.sf.json.JSONObject;

public class AllocateMemberData implements JsonPropDataHolder {
	
	public static final String PLAYER_ID_KEY = "pId";
	public static final String PLAYER_NAME_KEY = "pName";
	public static final String SCORE_KEY = "score";
	public static final String PLAYER_LEVEL_KEY = "pLevel";
	public static final String PLAYER_POWER_KEY = "pPower";
	public static final String CORPS_JOB_KEY = "cJob";
	public static final String ITEM_ID_KEY = "itemId";
	public static final String NUM_KEY = "num";
	
	//玩家id
	private long roleId;
	//玩家姓名
	private String playerName;
	//玩家积分
	private int score;
	//玩家等级
	private int playerLevel;
	//玩家战力
	private int playerPower;
	//玩家帮派职务
	private int corpsJob;
	//玩家已被分配的物品Id
	private int itemId;
	//玩家已被分配的物品的数量
	private int num;
	
	
	
	public AllocateMemberData(long roleId, String playerName, int score, int playerLevel, int playerPower, int corpsJob,
			int itemId, int num) {
		this.roleId = roleId;
		this.playerName = playerName;
		this.score = score;
		this.playerLevel = playerLevel;
		this.playerPower = playerPower;
		this.corpsJob = corpsJob;
		this.itemId = itemId;
		this.num = num;
	}
	public long getRoleId() {
		return roleId;
	}
	public void setRoleId(long roleId) {
		this.roleId = roleId;
	}
	public String getPlayerName() {
		return playerName;
	}
	public void setPlayerName(String playerName) {
		this.playerName = playerName;
	}
	public int getScore() {
		return score;
	}
	public void setScore(int score) {
		this.score = score;
	}
	public int getPlayerLevel() {
		return playerLevel;
	}
	public void setPlayerLevel(int playerLevel) {
		this.playerLevel = playerLevel;
	}
	public int getPlayerPower() {
		return playerPower;
	}
	public void setPlayerPower(int playerPower) {
		this.playerPower = playerPower;
	}
	public int getCorpsJob() {
		return corpsJob;
	}
	public void setCorpsJob(int corpsJob) {
		this.corpsJob = corpsJob;
	}
	
	public int getItemId() {
		return itemId;
	}
	public void setItemId(int itemId) {
		this.itemId = itemId;
	}
	public int getNum() {
		return num;
	}
	public void setNum(int num) {
		this.num = num;
	}
	
	
	@Override
	public String toString() {
		return "AllocateMemberData [roleId=" + roleId + ", playerName=" + playerName + ", score=" + score
				+ ", playerLevel=" + playerLevel + ", playerPower=" + playerPower + ", corpsJob=" + corpsJob
				+ ", itemId=" + itemId + ", num=" + num + "]";
	}
	
	@Override
	public String toJsonProp() {
		JSONObject obj = new JSONObject();
		obj.put(PLAYER_ID_KEY, roleId);
		obj.put(PLAYER_NAME_KEY, playerName);
		obj.put(SCORE_KEY, score);
		obj.put(PLAYER_LEVEL_KEY, playerLevel);
		obj.put(PLAYER_POWER_KEY, playerPower);
		obj.put(CORPS_JOB_KEY, corpsJob);
		obj.put(ITEM_ID_KEY, itemId);
		obj.put(NUM_KEY, num);
		return obj.toString();
	}
	
	@Override
	public void loadJsonProp(String value) {
		if(value == null || value.isEmpty()){
			return;
		}
		
		JSONObject obj = JSONObject.fromObject(value);
		if(obj == null || obj.isEmpty()){
			return;
		}
		
		this.roleId = JsonUtils.getLong(obj, PLAYER_ID_KEY);
		this.playerName = JsonUtils.getString(obj, PLAYER_NAME_KEY);
		this.score = JsonUtils.getInt(obj, SCORE_KEY);
		this.playerLevel = JsonUtils.getInt(obj, PLAYER_LEVEL_KEY);
		this.playerPower = JsonUtils.getInt(obj, PLAYER_POWER_KEY);
		this.corpsJob = JsonUtils.getInt(obj, CORPS_JOB_KEY);
		this.itemId = JsonUtils.getInt(obj, ITEM_ID_KEY);
		this.num = JsonUtils.getInt(obj, NUM_KEY);
	}
	
	
	public static AllocateMemberData fromJson(String str){
		JSONObject obj = JSONObject.fromObject(str);
		long roleId = JsonUtils.getLong(obj, PLAYER_ID_KEY);
		String playerName = JsonUtils.getString(obj, PLAYER_NAME_KEY);
		int score = JsonUtils.getInt(obj, SCORE_KEY);
		int playerLevel = JsonUtils.getInt(obj, PLAYER_LEVEL_KEY);
		int playerPower = JsonUtils.getInt(obj, PLAYER_POWER_KEY);
		int corpsJob = JsonUtils.getInt(obj, CORPS_JOB_KEY);
		int itemId = JsonUtils.getInt(obj, ITEM_ID_KEY);
		int num = JsonUtils.getInt(obj, NUM_KEY);

		return new AllocateMemberData(roleId, playerName, score, playerLevel,
				playerPower, corpsJob, itemId,num);
	}

}
