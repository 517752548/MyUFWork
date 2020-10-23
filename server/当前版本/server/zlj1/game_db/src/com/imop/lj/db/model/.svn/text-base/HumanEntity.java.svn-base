package com.imop.lj.db.model;

import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * 数据库实体类：角色信息
 *
 */
@Entity
@Table(name = "t_character_info")
@Comment(content="数据库实体类：角色信息")
public class HumanEntity implements BaseEntity<Long> {
	/** */
	private static final long serialVersionUID = 1L;
	/** 玩家角色ID 主键 */
	@Comment(content="玩家角色ID 主键 ")
	private long id;
	/** 玩家账号ID */
	@Comment(content="玩家账号ID ")
	private String passportId;
	/** 玩家的名字 */
	@Comment(content="玩家的名字 ")
	private String name;
	/** 玩家的头像 */
	@Comment(content="玩家的头像 ")
	private int photo;
	/** 创建时间 */
	@Comment(content="创建时间 ")
	private Timestamp createTime;
	/** 是否已经被删除 */
	@Comment(content="是否已经被删除 ")
	private int deleted;
	/** 删除日期 */
	@Comment(content="删除日期 ")
	private Timestamp deleteTime;
	/** 上次登陆时间 */
	@Comment(content="上次登陆时间 ")
	private Timestamp lastLoginTime;
	/** 上次登出时间 */
	@Comment(content="上次登出时间 ")
	private Timestamp lastLogoutTime;
	/** 上次登陆IP */
	@Comment(content="上次登陆IP")
	private String lastLoginIp;
	/** 累计在线时长(分钟) */
	@Comment(content="累计在线时长(分钟)")
	private int totalMinute;
	/** 在线状态 */
	@Comment(content="在线状态")
	private int onlineStatus;
	/** 空闲时间 */
	@Comment(content="空闲时间")
	private int idleTime;
	/** 当日充值数额 */
	@Comment(content="当日充值数额")
	private int todayCharge;
	/** 总充值数额 */
	@Comment(content="总充值数额")
	private int totalCharge;
	/** 最后充值时间 */
	@Comment(content="最后充值时间")
	private Timestamp lastChargeTime;
	/** 最后成为某级别vip的时间 */
	@Comment(content="最后成为某级别vip的时间")
	private Timestamp lastVipTime;
	/** 玩家等级 */
	@Comment(content="玩家等级")
	private int level;
	/** 玩家经验值 */
	@Comment(content="玩家经验值")
	private long exp;
	/** 债券数量 */
	@Comment(content="债券数量")
	private long bond;
	/** 系统赠送债券数量 */
	@Comment(content="系统赠送债券数量")
	private long sysBond;
	/** 礼券数量 */
	@Comment(content="礼券数量")
	private long giftBond;
	/** 铜钱数量 */
	@Comment(content="银票数量")
	private long gold;
	@Comment(content="银子数量")
	private long gold2;
	
	/** 场景id */
	@Comment(content="场景id")
	private int sceneId;
	/** 最近一次的城市场景id */
	@Comment(content="最近一次的城市场景id")
	private int lastCitySceneId;
	
	/** 国家 */
	@Comment(content="国家")
	private int country;
	/** 开启背包格数 */
	@Comment(content="开启仓库次数（页数）")
	private int hadOpenPrimBagNum;
	/** 其他属性信息 */
	@Comment(content="其他属性信息")
	private String props;
	
	/** 关卡信息 */
	@Comment(content="关卡信息")
	private String missionPack;
	
	/** 体力 */
	@Comment(content="体力")
	private int power;
	/** 最后一次给体力时间 */
	@Comment(content="最后一次给体力时间")
	private long lastGivePowerTime;
	
	@Comment(content="技能点")
	private int skillPoint;
	@Comment(content="最后一次给技能点时间")
	private long lastGiveSkillPointTime;
	
	@Comment(content="活力值")
	private int energy;
	
	@Comment(content="红包钱")
	private int redEnvelope;
	
	/** cd队列信息 */
	@Comment(content="cd队列信息")
	private String cdQueuePack;
	
	/** 声望 */
	@Comment(content="声望")
	private int honor;
	
	/** 记录实际消耗物品*/
	@Comment(content="记录实际消耗物品")
	private long eternalCostMoney;
	
	@Comment(content="能否改名，合服时被改名的标记")
	private int canRename;
	
	@Comment(content="所属服务器Id，如1001")
	private int serverId;
	
	@Comment(content="本周充值数额")
	private int weekCharge;
	
	@Comment(content="本月充值数额")
	private int monthCharge;
	
	@Comment(content="token登录参数1，unix时间戳")
	private long tokenParam1;
	@Comment(content="token登录参数2，随机字符串")
	private String tokenParam2;
	
	@Comment(content="玩家所在地图id")
	private int mapId;
	@Comment(content="玩家x坐标（像素）")
	private int x;
	@Comment(content="玩家y坐标（像素）")
	private int y;
	
	@Comment(content="备用玩家所在地图id")
	private int backMapId;
	@Comment(content="备用玩家x坐标（像素）")
	private int backX;
	@Comment(content="备用玩家y坐标（像素）")
	private int backY;
	
	@Comment(content="最后一次战斗id")
	private int lastBattleId;
	@Comment(content="最后一次战斗开始时间")
	private long lastBattleTime;
	@Comment(content="最后一次战斗结束时间")
	private long lastBattleEndTime;
	
	@Comment(content="自动战斗默认行为")
	private int autoFightAction;
	@Comment(content="自动战斗宠物默认行为")
	private int petAutoFightAction;
	
	@Comment(content="酒馆等级")
	private int pubLevel;
	@Comment(content="酒馆经验值")
	private long pubExp;
	
	@Comment(content="心法等级")
	private int mainSkillLevel;
	
	@Comment(content="当前心法类型")
	private int mainSkillType;
	
	@Comment(content="升级时间戳")
	private int levelUpTimeStamp;
	
	@Comment(content="采矿等级")
	private int mineLevel;
	
	@Comment(content="最后一次给双倍经验值时间")
	private long lastGiveDoublePointTime;
	
	@Id
	@Override
	public Long getId() {
		return id;
	}

	@Override
	public void setId(Long id) {
		this.id = id;
	}

	@Column
	public String getPassportId() {
		return passportId;
	}

	public void setPassportId(String passportId) {
		this.passportId = passportId;
	}

	public void setName(String name) {
		this.name = name;
	}

	@Column
	public String getName() {
		return name;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getPhoto() {
		return photo;
	}

	public void setPhoto(int photo) {
		this.photo = photo;
	}

	@Column
	public Timestamp getCreateTime() {
		return createTime;
	}

	public void setCreateTime(Timestamp createTime) {
		this.createTime = createTime;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getDeleted() {
		return deleted;
	}

	public void setDeleted(int deleted) {
		this.deleted = deleted;
	}

	public Timestamp getDeleteTime() {
		return deleteTime;
	}

	@Column
	public void setDeleteTime(Timestamp deleteTime) {
		this.deleteTime = deleteTime;
	}

	@Column
	public Timestamp getLastLoginTime() {
		return lastLoginTime;
	}

	public void setLastLoginTime(Timestamp lastLoginTime) {
		this.lastLoginTime = lastLoginTime;
	}

	@Column
	public Timestamp getLastLogoutTime() {
		return lastLogoutTime;
	}

	public void setLastLogoutTime(Timestamp lastLogoutTime) {
		this.lastLogoutTime = lastLogoutTime;
	}

	@Column
	public String getLastLoginIp() {
		return lastLoginIp;
	}

	public void setLastLoginIp(String lastLoginIp) {
		this.lastLoginIp = lastLoginIp;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getTotalMinute() {
		return totalMinute;
	}

	public void setTotalMinute(int totalMinute) {
		this.totalMinute = totalMinute;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getOnlineStatus() {
		return onlineStatus;
	}

	public void setOnlineStatus(int onlineStatus) {
		this.onlineStatus = onlineStatus;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getIdleTime() {
		return idleTime;
	}

	public void setIdleTime(int idleTime) {
		this.idleTime = idleTime;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getTodayCharge() {
		return todayCharge;
	}

	public void setTodayCharge(int todayCharge) {
		this.todayCharge = todayCharge;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getTotalCharge() {
		return totalCharge;
	}

	public void setTotalCharge(int totalCharge) {
		this.totalCharge = totalCharge;
	}

	@Column
	public Timestamp getLastChargeTime() {
		return lastChargeTime;
	}

	public void setLastChargeTime(Timestamp lastChargeTime) {
		this.lastChargeTime = lastChargeTime;
	}

	@Column
	public Timestamp getLastVipTime() {
		return lastVipTime;
	}

	public void setLastVipTime(Timestamp lastVipTime) {
		this.lastVipTime = lastVipTime;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getLevel() {
		return level;
	}

	public void setLevel(int level) {
		this.level = level;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getBond() {
		return bond;
	}

	public void setBond(long bond) {
		this.bond = bond;
	}
	
	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getGold() {
		return gold;
	}

	public void setGold(long gold) {
		this.gold = gold;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getGold2() {
		return gold2;
	}

	public void setGold2(long gold2) {
		this.gold2 = gold2;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getSysBond() {
		return sysBond;
	}

	public void setSysBond(long sysBond) {
		this.sysBond = sysBond;
	}
	
	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getGiftBond() {
		return giftBond;
	}
	
	public void setGiftBond(long giftBond) {
		this.giftBond = giftBond;
	}
	
	@Column(columnDefinition = " int default 0", nullable = false)
	public int getSceneId() {
		return sceneId;
	}

	public void setSceneId(int sceneId) {
		this.sceneId = sceneId;
	}
	
	@Column(columnDefinition = " int default 0", nullable = false)
	public int getLastCitySceneId() {
		return lastCitySceneId;
	}

	public void setLastCitySceneId(int lastCitySceneId) {
		this.lastCitySceneId = lastCitySceneId;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getCountry() {
		return country;
	}

	public void setCountry(int country) {
		this.country = country;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getHadOpenPrimBagNum() {
		return hadOpenPrimBagNum;
	}

	public void setHadOpenPrimBagNum(int hadOpenPrimBagNum) {
		this.hadOpenPrimBagNum = hadOpenPrimBagNum;
	}
	
	@Column(columnDefinition = "LONGTEXT")
	public String getProps() {
		return props;
	}

	public void setProps(String props) {
		this.props = props;
	}

	@Column(columnDefinition = "TEXT")
	public String getMissionPack() {
		return missionPack;
	}

	public void setMissionPack(String missionPack) {
		this.missionPack = missionPack;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getPower() {
		return power;
	}

	public void setPower(int power) {
		this.power = power;
	}
	
	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getLastGivePowerTime() {
		return lastGivePowerTime;
	}

	public void setLastGivePowerTime(long lastGivePowerTime) {
		this.lastGivePowerTime = lastGivePowerTime;
	}
	
	@Column(columnDefinition = " int default 0", nullable = false)
	public int getSkillPoint() {
		return skillPoint;
	}

	public void setSkillPoint(int skillPoint) {
		this.skillPoint = skillPoint;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getEnergy() {
		return energy;
	}

	public void setEnergy(int energy) {
		this.energy = energy;
	}
	
	@Column(columnDefinition = " int default 0", nullable = false)
	public int getRedEnvelope() {
		return redEnvelope;
	}

	public void setRedEnvelope(int redEnvelope) {
		this.redEnvelope = redEnvelope;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getLastGiveSkillPointTime() {
		return lastGiveSkillPointTime;
	}

	public void setLastGiveSkillPointTime(long lastGiveSkillPointTime) {
		this.lastGiveSkillPointTime = lastGiveSkillPointTime;
	}

	@Column(columnDefinition = "LONGTEXT")
	public String getCdQueuePack() {
		return cdQueuePack;
	}

	public void setCdQueuePack(String cdQueuePack) {
		this.cdQueuePack = cdQueuePack;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getHonor() {
		return honor;
	}

	public void setHonor(int honor) {
		this.honor = honor;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getEternalCostMoney() {
		return eternalCostMoney;
	}

	public void setEternalCostMoney(long eternalCostMoney) {
		this.eternalCostMoney = eternalCostMoney;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getCanRename() {
		return canRename;
	}

	public void setCanRename(int canRename) {
		this.canRename = canRename;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getServerId() {
		return serverId;
	}

	public void setServerId(int serverId) {
		this.serverId = serverId;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getWeekCharge() {
		return weekCharge;
	}

	public void setWeekCharge(int weekCharge) {
		this.weekCharge = weekCharge;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getMonthCharge() {
		return monthCharge;
	}

	public void setMonthCharge(int monthCharge) {
		this.monthCharge = monthCharge;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getTokenParam1() {
		return tokenParam1;
	}

	public void setTokenParam1(long tokenParam1) {
		this.tokenParam1 = tokenParam1;
	}

	@Column(columnDefinition = " varchar(64) default ''", nullable = true)
	public String getTokenParam2() {
		return tokenParam2;
	}

	public void setTokenParam2(String tokenParam2) {
		this.tokenParam2 = tokenParam2;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getExp() {
		return exp;
	}

	public void setExp(long exp) {
		this.exp = exp;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getMapId() {
		return mapId;
	}

	public void setMapId(int mapId) {
		this.mapId = mapId;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getX() {
		return x;
	}

	public void setX(int x) {
		this.x = x;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getY() {
		return y;
	}

	public void setY(int y) {
		this.y = y;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getLastBattleId() {
		return lastBattleId;
	}

	public void setLastBattleId(int lastBattleId) {
		this.lastBattleId = lastBattleId;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getLastBattleTime() {
		return lastBattleTime;
	}

	public void setLastBattleTime(long lastBattleTime) {
		this.lastBattleTime = lastBattleTime;
	}
	
	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getLastBattleEndTime() {
		return lastBattleEndTime;
	}

	public void setLastBattleEndTime(long lastBattleEndTime) {
		this.lastBattleEndTime = lastBattleEndTime;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getAutoFightAction() {
		return autoFightAction;
	}

	public void setAutoFightAction(int autoFightAction) {
		this.autoFightAction = autoFightAction;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getPetAutoFightAction() {
		return petAutoFightAction;
	}

	public void setPetAutoFightAction(int petAutoFightAction) {
		this.petAutoFightAction = petAutoFightAction;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getPubLevel() {
		return pubLevel;
	}

	public void setPubLevel(int pubLevel) {
		this.pubLevel = pubLevel;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getPubExp() {
		return pubExp;
	}

	public void setPubExp(long pubExp) {
		this.pubExp = pubExp;
	}
	
	@Column(columnDefinition = " int(11) default 1", nullable = false)
	public int getMainSkillLevel() {
		return mainSkillLevel;
	}

	public void setMainSkillLevel(int mainSkillLevel) {
		this.mainSkillLevel = mainSkillLevel;
	}
	
	
	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getMainSkillType() {
		return mainSkillType;
	}

	public void setMainSkillType(int mainSkillType) {
		this.mainSkillType = mainSkillType;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public int getLevelUpTimeStamp() {
		return levelUpTimeStamp;
	}

	public void setLevelUpTimeStamp(int levelUpTimeStamp) {
		this.levelUpTimeStamp = levelUpTimeStamp;
	}
	
	@Column(columnDefinition = " int(11) default 1", nullable = false)
	public int getMineLevel() {
		return mineLevel;
	}

	public void setMineLevel(int mineLevel) {
		this.mineLevel = mineLevel;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getBackMapId() {
		return backMapId;
	}

	public void setBackMapId(int backMapId) {
		this.backMapId = backMapId;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getBackX() {
		return backX;
	}

	public void setBackX(int backX) {
		this.backX = backX;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getBackY() {
		return backY;
	}

	public void setBackY(int backY) {
		this.backY = backY;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getLastGiveDoublePointTime() {
		return lastGiveDoublePointTime;
	}

	public void setLastGiveDoublePointTime(long lastGiveDoublePointTime) {
		this.lastGiveDoublePointTime = lastGiveDoublePointTime;
	}
	
}
