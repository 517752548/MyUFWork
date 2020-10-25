package com.imop.lj.common.model;

import java.util.List;

import net.sf.json.JSONObject;

public class ScenePlayerInfo {
	
	private static int UUID_KEY 		= 1;
	private static int ROLENAME_KEY 	= 2;
	private static int LEVEL_KEY 		= 3;
	private static int PIC_KEY 			= 4;
	private static int TITLEIDLIST_KEY 	= 5;
	private static int MILITARYRANK_KEY = 6;
	private static int PETPIC_KEY 		= 7;
	private static int BAOBAOPIC_KEY 	= 8;
	private static int X_KEY 			= 9;
	private static int Y_KEY 			= 10;
	private static int LEADER_QUALITY_KEY=11;
	private static int COUNTRY			=12;
	private static int ARMOUR_AVATAR 	= 13;
	private static int ARMOUR_HUN_AVATAR = 14;
	
	private static int QQ_INFO_YELLOW_VIP_LEVEL = 15;
	private static int QQ_INFO_IS_YELLOW_VIP = 16;
	private static int QQ_INFO_IS_YELLOW_YEAR_VIP = 17;
	private static int QQ_INFO_IS_YELLOW_HIGH_VIP = 18;
	
	private static int PRACTICE_DOING = 19;
	

	/** 角色id */
	private long uuid;
	
	/** 角色名 */
	private String roleName;
	
	/** 等级 */
	private int level;
	
	/** 头像id */
	private int pic;
	
	/** 主将品质 */
	private int leaderQuality;
	
	/** 称号id列表 */
	private List<Integer> titleIdList;
	
	/** 军衔 */
	private int militaryRank;
	
	/** 骑宠图片id */
	private int petPic;
	
	/** 宝宝id */
	private int baobaoPic;
	
	/** x坐标 */
	private int x;
	
	/** y坐标 */
	private int y;
	
	/** 国家 */
	private int country;
	
	/** 战甲avatarid */
	private int armourAvatar;
	/** 战甲甲魂  */
	private int armourHunAvatar;
	
	/** qq信息 **/
	/** 黄钻等级 */
	private int yellowVipLevel;
	/** 是否黄钻用户 */
	private int isYellowVip;
	/** 是否黄钻年费用户 */
	private int isYellowYearVip;
	/** 是否豪华版黄钻用户 */
	private int isYellowHighVip;
	/** 是否打坐，1打坐，0没打坐 */
	private int isPractice = 0;
	
	public ScenePlayerInfo() {
		
	}

	public long getUuid() {
		return uuid;
	}

	public void setUuid(long uuid) {
		this.uuid = uuid;
	}

	public String getRoleName() {
		return roleName;
	}

	public void setRoleName(String roleName) {
		this.roleName = roleName;
	}

	public int getLevel() {
		return level;
	}

	public void setLevel(int level) {
		this.level = level;
	}

	public int getPic() {
		return pic;
	}

	public void setPic(int pic) {
		this.pic = pic;
	}

	public int getMilitaryRank() {
		return militaryRank;
	}

	public void setMilitaryRank(int militaryRank) {
		this.militaryRank = militaryRank;
	}

	public int getPetPic() {
		return petPic;
	}

	public void setPetPic(int petPic) {
		this.petPic = petPic;
	}

	public int getBaobaoPic() {
		return baobaoPic;
	}

	public void setBaobaoPic(int baobaoPic) {
		this.baobaoPic = baobaoPic;
	}

	public List<Integer> getTitleIdList() {
		return titleIdList;
	}

	public void setTitleIdList(List<Integer> titleIdList) {
		this.titleIdList = titleIdList;
	}

	public int getX() {
		return x;
	}

	public void setX(int x) {
		this.x = x;
	}

	public int getY() {
		return y;
	}

	public void setY(int y) {
		this.y = y;
	}
	
	public int getLeaderQuality() {
		return leaderQuality;
	}

	public void setLeaderQuality(int leaderQuality) {
		this.leaderQuality = leaderQuality;
	}

	public int getCountry() {
		return country;
	}

	public void setCountry(int country) {
		this.country = country;
	}
	
	public int getArmourAvatar() {
		return armourAvatar;
	}

	public void setArmourAvatar(int armourAvatar) {
		this.armourAvatar = armourAvatar;
	}

	public int getArmourHunAvatar() {
		return armourHunAvatar;
	}

	public void setArmourHunAvatar(int armourHunAvatar) {
		this.armourHunAvatar = armourHunAvatar;
	}

	public int getYellowVipLevel() {
		return yellowVipLevel;
	}

	public void setYellowVipLevel(int yellowVipLevel) {
		this.yellowVipLevel = yellowVipLevel;
	}

	public int getIsYellowVip() {
		return isYellowVip;
	}

	public void setIsYellowVip(int isYellowVip) {
		this.isYellowVip = isYellowVip;
	}

	public int getIsYellowYearVip() {
		return isYellowYearVip;
	}

	public void setIsYellowYearVip(int isYellowYearVip) {
		this.isYellowYearVip = isYellowYearVip;
	}

	public int getIsYellowHighVip() {
		return isYellowHighVip;
	}

	public void setIsYellowHighVip(int isYellowHighVip) {
		this.isYellowHighVip = isYellowHighVip;
	}
	
	public int getIsPractice() {
		return isPractice;
	}

	public void setIsPractice(int isPractice) {
		this.isPractice = isPractice;
	}

	public String toJsonStr() {
		JSONObject jsonObj = new JSONObject();
		jsonObj.put(UUID_KEY, getUuid());
		jsonObj.put(ROLENAME_KEY, getRoleName());
		jsonObj.put(LEVEL_KEY, getLevel());
		jsonObj.put(PIC_KEY, getPic());
		jsonObj.put(LEADER_QUALITY_KEY, getLeaderQuality());
		jsonObj.put(TITLEIDLIST_KEY, getTitleIdList());
		jsonObj.put(MILITARYRANK_KEY, getMilitaryRank());
		jsonObj.put(PETPIC_KEY, getPetPic());
		jsonObj.put(BAOBAOPIC_KEY, getBaobaoPic());
		jsonObj.put(X_KEY, getX());
		jsonObj.put(Y_KEY, getY());
		jsonObj.put(COUNTRY, getCountry());
		jsonObj.put(ARMOUR_AVATAR, getArmourAvatar());
		jsonObj.put(ARMOUR_HUN_AVATAR, getArmourHunAvatar());
		// qq信息
		jsonObj.put(QQ_INFO_YELLOW_VIP_LEVEL, getYellowVipLevel());
		jsonObj.put(QQ_INFO_IS_YELLOW_VIP, getIsYellowVip());
		jsonObj.put(QQ_INFO_IS_YELLOW_YEAR_VIP, getIsYellowYearVip());
		jsonObj.put(QQ_INFO_IS_YELLOW_HIGH_VIP, getIsYellowHighVip());
		// 打坐
		jsonObj.put(PRACTICE_DOING, getIsPractice());
		
		return jsonObj.toString();
	}

	@Override
	public String toString() {
		return "ScenePlayerInfo [uuid=" + uuid + ", roleName=" + roleName
				+ ", level=" + level + ", pic=" + pic + ", leaderQuality="
				+ leaderQuality + ", titleIdList=" + titleIdList
				+ ", militaryRank=" + militaryRank + ", petPic=" + petPic
				+ ", baobaoPic=" + baobaoPic + ", x=" + x + ", y=" + y
				+ ", country=" + country + ", armourAvatar=" + armourAvatar
				+ ", armourHunAvatar=" + armourHunAvatar + ", yellowVipLevel="
				+ yellowVipLevel + ", isYellowVip=" + isYellowVip
				+ ", isYellowYearVip=" + isYellowYearVip + ", isYellowHighVip="
				+ isYellowHighVip 
				+ ", isPractice=" + isPractice 
				+ "]";
	}

}
