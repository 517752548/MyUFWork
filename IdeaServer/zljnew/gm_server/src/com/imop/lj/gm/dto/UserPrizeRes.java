package com.imop.lj.gm.dto;


/**
 * GM补偿上传结果对象
 *
 * @author <a href="mailto:fan.lin@opi-corp.com">lin fan<a>
 *
 */

public class UserPrizeRes {

	/** 上传结果 */
	private String result;

	/** 数据库服务器Id */
	private String dbId;

	/** 玩家账号Id=玩家名称 */
	private String userIdAndName;

	/** 补偿类型 */
	private int type;

	/** 奖励金钱 */
	private String coin;

	/** 奖励物品 */
	private String item;

	/** 奖励宠物 */
	private String pet;

	/** 补偿名称 */
	private String userPrizeName;
	
	/** 补偿道具属性	 */
	private String itemParams;

	public String getUserPrizeName() {
		return userPrizeName;
	}

	public void setUserPrizeName(String userPrizeName) {
		this.userPrizeName = userPrizeName;
	}

	public String getResult() {
		return result;
	}

	public void setResult(String result) {
		this.result = result;
	}

	public String getDbId() {
		return dbId;
	}

	public void setDbId(String dbId) {
		this.dbId = dbId;
	}

	public String getUserIdAndName() {
		return userIdAndName;
	}

	public void setUserIdAndName(String userIdAndName) {
		this.userIdAndName = userIdAndName;
	}

	public int getType() {
		return type;
	}

	public void setType(int type) {
		this.type = type;
	}

	public String getCoin() {
		return coin;
	}

	public void setCoin(String coin) {
		this.coin = coin;
	}

	public String getItem() {
		return item;
	}

	public void setItem(String item) {
		this.item = item;
	}

	public String getPet() {
		return pet;
	}

	public void setPet(String pet) {
		this.pet = pet;
	}

	public String getItemParams() {
		return itemParams;
	}

	public void setItemParams(String itemParams) {
		this.itemParams = itemParams;
	}

}