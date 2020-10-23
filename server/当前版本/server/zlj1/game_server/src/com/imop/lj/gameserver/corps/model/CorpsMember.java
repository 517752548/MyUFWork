package com.imop.lj.gameserver.corps.model;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.db.model.CorpsMemberEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsMemberState;
import com.imop.lj.gameserver.corps.CorpsDef.MemberAfterBattleStatus;
import com.imop.lj.gameserver.corps.CorpsDef.MemberJob;
import com.imop.lj.gameserver.corps.CorpsMsgBuilder;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.pet.PetDef;
import com.imop.lj.gameserver.pet.PetDef.JobType;
import com.imop.lj.gameserver.pet.PetDef.Sex;
import com.imop.lj.gameserver.player.Player;

/**
 * 军团成员
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsMember implements PersistanceObject<Long, CorpsMemberEntity> {
	/** 主键 */
	private long id;
	/** 玩家ID */
	private long roleId;
	/** 成员名称 */
	private String name;
	/** 成员級別 */
	private int level;
	/** 军团ID */
	private long corpsId;
	/** 职位 */
	private MemberJob job;
	
	//这部分保留，以后可能会有捐献
	/** 当天捐献 */
	private long todayDonate;
	/** 总捐献 */
	private long totalDonate;
	/** 用以判定是否为隔天操作 */
	private long donateDate;
	
	
	/** 经验 */
	private long toCorpsExp;
	/** 加入时间 */
	private long joinDate;
	/** 登出时间 */
	private long logoutTime;
	/** 军团成员状态 */
	private CorpsMemberState state = CorpsMemberState.NONE;
	/** 是否在线 */
	private boolean online;
	/** 此实例是否在db中 */
	private boolean isInDb;
	/** 生命期 */
	private final LifeCycle lifeCycle;
	
	//新加入字段:
	
	/** 本周贡献 */
	private int weekContribution;
	/** 总贡献 */
	private int totalContribution;
	/** 用以判定是否为本周内操作 */
	private long contributeDate;
	/** 上周帮贡,用以兑换帮派福利 */
	private int lastWeekContribution;
	/** 领取福利日期 ,用以判断一周领取一次*/
	private long benifitDate;
	
	/** 职业 */
	private JobType petJob;
	/** 性别 */
	private Sex sex;

	/**
	 * 所属军团
	 */
	private Corps corps;
	
	/** 帮派成员队伍战斗结束后，需要变为的状态 */
	private MemberAfterBattleStatus afterBattleStatus;

	public CorpsMember(Corps corps) {
		this.lifeCycle = new LifeCycleImpl(this);
		this.corps = corps;
	}

	@Override
	public void setDbId(Long id) {
		this.id = id;
	}

	@Override
	public Long getDbId() {
		return this.id;
	}

	@Override
	public String getGUID() {
		return "CorpsMember#" + this.id;
	}

	@Override
	public boolean isInDb() {
		return this.isInDb;
	}

	@Override
	public void setInDb(boolean inDb) {
		this.isInDb = inDb;
	}

	@Override
	public long getCharId() {
		return this.roleId;
	}

	/**
	 * 激活
	 */
	public void activate() {
		this.lifeCycle.activate();
	}
	
	@Override
	public CorpsMemberEntity toEntity() {
		CorpsMemberEntity entity = new CorpsMemberEntity();
		/** 主键 */
		entity.setId(this.id);
		/** 玩家ID */
		entity.setRoleId(this.roleId);
		/** 成员名称 */
		entity.setName(this.name);
		/** 成员级别 */
		entity.setLevel(this.level);
		/** 军团ID */
		entity.setCorpsId(this.corpsId);
		/** 当天捐献 */
		entity.setTodayDonate(this.todayDonate);
		/** 总捐献 */
		entity.setTotalDonate(this.totalDonate);
		/** 捐献时间 */
		entity.setDonateDate(this.donateDate);
		/** 经验 */
		entity.setToCorpsExp(this.toCorpsExp);
		/** 加入时间 */
		entity.setJoinDate(this.joinDate);
		/** 登出时间 */
		entity.setLogoutTime(this.logoutTime);
		
		/** 本周帮贡 */
		entity.setWeekyContribution(this.weekContribution);
		/** 总帮贡 */
		entity.setTotalContribution(this.totalContribution);
		/** 贡献时间 */
		entity.setContributeDate(this.contributeDate);
		/** 上周帮贡 */
		entity.setLastWeekContribution(lastWeekContribution);
		/** 领取福利时间 */
		entity.setBenifitDate(benifitDate);
		/** 职务*/
		entity.setMemJob(this.job.getIndex());
		/** 职业*/
		entity.setPetJob(this.petJob.getIndex());
		/** 性别*/
		entity.setSex(this.sex.getIndex());
		
		/** 军团成员状态 */
		entity.setCorpsMemState(this.state.getIndex());
		return entity;
	}

	@Override
	public void fromEntity(CorpsMemberEntity entity) {
		this.isInDb = true;

		/** 主键 */
		this.id = entity.getId();
		/** 玩家ID */
		this.roleId = entity.getRoleId();
		/** 成员名称 */
		this.name = entity.getName();
		/** 成员级别 */
		this.level = entity.getLevel();
		/** 军团ID */
		this.corpsId = entity.getCorpsId();
		/** 当天捐献 */
		this.todayDonate = entity.getTodayDonate();
		/** 总捐献 */
		this.totalDonate = entity.getTotalDonate();
		/** 捐献时间 */
		this.donateDate = entity.getDonateDate();
		/** 经验 */
		this.toCorpsExp = entity.getToCorpsExp();
		/** 加入时间 */
		this.joinDate = entity.getJoinDate();
		/** 登出时间 */
		this.logoutTime = entity.getLogoutTime();
		
		/** 本周帮贡 */
		this.weekContribution = entity.getWeekyContribution();
		/** 总帮贡 */
		this.totalContribution = entity.getTotalContribution();
		/** 捐献时间 */
		this.contributeDate = entity.getContributeDate();
		/** 上周帮贡 */
		this.lastWeekContribution = entity.getLastWeekContribution();
		/** 领取福利时间 */
		this.benifitDate = entity.getBenifitDate();
		/** 职务*/
		this.job = MemberJob.valueOf(entity.getMemJob()) == null?MemberJob.NONE:MemberJob.valueOf(entity.getMemJob());
		/** 职业*/
		this.petJob = PetDef.JobType.valueOf(entity.getPetJob());
		/** 性别*/
		this.sex = Sex.valueOf(entity.getSex());

		/** 军团成员状态 */
		this.state = CorpsMemberState.valueOf(entity.getCorpsMemState());
	}

	@Override
	public LifeCycle getLifeCycle() {
		return this.lifeCycle;
	}

	@Override
	public void setModified() {
		this.lifeCycle.checkModifiable();
		if (this.lifeCycle.isActive()) {
			Globals.getSceneService().getCommonScene().getCommonDataUpdater().addUpdate(lifeCycle);
		}

	}

	/**
	 * 当删除时
	 */
	public void onDelete() {
		this.lifeCycle.destroy();
		Globals.getSceneService().getCommonScene().getCommonDataUpdater().addDelete(lifeCycle);
	}

	/**
	 * 当加入军团时
	 */
	public void onJoin() {
		this.joinDate = Globals.getTimeService().now();
		this.job = MemberJob.MEMBER;
		this.state = CorpsMemberState.NORMAL;
	}

	/**
	 * 捐献元宝
	 * 
	 * @param contribution
	 */
	public void donateBond(int bond) {
		long contribution = (long)bond * Globals.getGameConstants().getBondToContributionRate();
		// 累加总捐献
		if(contribution > Long.MAX_VALUE - this.totalDonate){
			this.totalDonate = Long.MAX_VALUE;
		}else{
			this.totalDonate = this.totalDonate + contribution;
		}

		// 转化为经验
		long exp = contribution
				* Globals.getGameConstants().getContributionToExpRate();

		// 累加总经验
		this.toCorpsExp = this.toCorpsExp + exp;

		// 当前捐献
		long currTime = Globals.getTimeService().now();
		if (TimeUtils.isSameDay(this.donateDate, currTime)) {
			if(contribution > Long.MAX_VALUE - this.todayDonate){
				this.todayDonate = Long.MAX_VALUE;
			}else{
				this.todayDonate = this.todayDonate + contribution;
			}
		} else {
			this.todayDonate = contribution;
		}

		this.donateDate = currTime;
		
		this.corps.addExpByMember(exp);
		this.setModified();
	}
	
	/**
	 * 捐献经验
	 * 
	 * @param contribution
	 */
	public void donateExp(int exp) {		
		//转化为捐献
		int contribution = exp / Globals.getGameConstants().getContributionToExpRate();
		// 累加总捐献
		if(contribution > Long.MAX_VALUE - this.totalDonate){
			this.totalDonate = Long.MAX_VALUE;
		}else{
			this.totalDonate = this.totalDonate + contribution;
		}

		// 累加总经验
		if(contribution > Long.MAX_VALUE - this.toCorpsExp){
			this.toCorpsExp = Long.MAX_VALUE;
		}else{
			this.toCorpsExp = this.toCorpsExp + exp;
		}

		// 当前捐献
		long currTime = Globals.getTimeService().now();
		if (TimeUtils.isSameDay(this.donateDate, currTime)) {
			if(contribution > Long.MAX_VALUE - this.todayDonate){
				this.todayDonate = Long.MAX_VALUE;
			}else{
				this.todayDonate = this.todayDonate + contribution;
			}
		} else {
			this.todayDonate = contribution;
		}

		this.donateDate = currTime;
		
		this.corps.addExpByMember(exp);
		this.setModified();
	}
	
	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
		this.setModified();
	}

	public long getRoleId() {
		return roleId;
	}

	public void setRoleId(long roleId) {
		this.roleId = roleId;
		this.setModified();
	}

	public long getCorpsId() {
		return corpsId;
	}

	public void setCorpsId(long corpsId) {
		this.corpsId = corpsId;
		this.setModified();
	}

	public MemberJob getJob() {
		return job;
	}

	public void setJob(MemberJob job) {
		MemberJob oldJob = this.job;
        this.job = job;
        this.setModified();

        //如果是副帮主，则重置一下
        if (job == MemberJob.VICE_CHAIRMAN) {
            getCorps().setViceChairman(getCharId());
        }

        //玩家在线则发送修改信息
        Player player = Globals.getOnlinePlayerService().getPlayer(this.roleId);
        if(player != null){
            if(player.getHuman() != null){
                player.getHuman().sendMessage(CorpsMsgBuilder.createGCCorpsMemberInfo(player.getHuman(),this));
            }
        }

        //职位变化可能会引起功能按钮变化
		Globals.getCorpsService().onMemberJobChanged(getCorps(), oldJob, job);
        //修改称号 TODO

	}

	public String getName() {
		return name;
	}

	public Integer getLevel() {
		UserSnap snap = Globals.getOfflineDataService()
				.getUserSnap(this.roleId);
		if (snap != null) {
			return snap.getLevel();
		}
		return 1;
	}

	public long getTodayDonate() {
		long now = Globals.getTimeService().now();
		if (!TimeUtils.isSameDay(this.donateDate, now)) {
			this.donateDate = now;
			this.todayDonate = 0;
			this.setModified();
		}
		return todayDonate;
	}

	public void setTodayDonate(long todayDonate) {
		this.todayDonate = todayDonate;
	}

	public void setTodayDonate(Integer todayDonate) {
		this.todayDonate = todayDonate;
		this.setModified();
	}

	public long getTotalDonate() {
		return totalDonate;
	}

	public void setTotalDonate(long totalDonate) {
		this.totalDonate = totalDonate;
		this.setModified();
	}

	public long getDonateDate() {
		return donateDate;
	}

	public void setDonateDate(long donateDate) {
		this.donateDate = donateDate;
		this.setModified();
	}

	public long getToCorpsExp() {
		return toCorpsExp;
	}

	public void setToCorpsExp(long toCorpsExp) {
		this.toCorpsExp = toCorpsExp;
		this.setModified();
	}

	public long getJoinDate() {
		return joinDate;
	}

	public void setJoinDate(long joinDate) {
		this.joinDate = joinDate;
		this.setModified();
	}

	public long getLogoutTime() {
		return logoutTime;
	}

	public void setLogoutTime(long logoutTime) {
		this.logoutTime = logoutTime;
		this.setModified();
	}

	public CorpsMemberState getState() {
		return state;
	}

	public void setState(CorpsMemberState state) {
		this.state = state;
		this.setModified();
	}

	public Corps getCorps() {
		return corps;
	}

	public void setCorps(Corps corps) {
		this.corps = corps;
	}

	public void setName(String name) {
		this.name = name;
		this.setModified();
	}

	public void setLevel(int level) {
		this.level = level;
	}

	public boolean isOnline() {
		return online;
	}

	public void setOnline(boolean online) {
		this.online = online;
	}

	public Integer getWeekContribution() {
		long now = Globals.getTimeService().now();
		if (!TimeUtils.isInSameWeek(this.contributeDate, now)) {
			this.contributeDate = now;
			this.weekContribution = 0;
			this.setModified();
		}
		return weekContribution;
	}

	public void setWeekContribution(Integer weekContribution) {
		this.weekContribution = weekContribution;
		this.setModified();
	}

	public Integer getTotalContribution() {
		return totalContribution;
	}

	public void setTotalContribution(Integer totalContribution) {
		this.totalContribution = totalContribution;
		this.setModified();
	}

	public long getContributeDate() {
		return contributeDate;
	}

	public void setContributeDate(long contributeDate) {
		this.contributeDate = contributeDate;
		this.setModified();
	}
	
	public int getLastWeekContribution() {
		long now = Globals.getTimeService().now();
		if (!TimeUtils.isInSameWeek(this.contributeDate, now)) {
			this.contributeDate = now;
			this.lastWeekContribution = weekContribution;
			this.setModified();
		}
		return lastWeekContribution;
	}

	public void setLastWeekContribution(int lastWeekContribution) {
		this.lastWeekContribution = lastWeekContribution;
		this.setModified();
	}
	
	public long getBenifitDate() {
		return benifitDate;
	}

	public void setBenifitDate(long benifitDate) {
		this.benifitDate = benifitDate;
		this.setModified();
	}

	public JobType getPetJob() {
		return petJob;
	}

	public void setPetJob(JobType petJob) {
		this.petJob = petJob;
		this.setModified();
	}

	public Sex getSex() {
		return sex;
	}

	public void setSex(Sex sex) {
		this.sex = sex;
	}
	
	public int getTplId() {
		return Globals.getOfflineDataService().getUserTplId(roleId);
	}

	public MemberAfterBattleStatus getAfterBattleStatus() {
		return afterBattleStatus;
	}

	public void setAfterBattleStatus(MemberAfterBattleStatus afterBattleStatus) {
		this.afterBattleStatus = afterBattleStatus;
	}

}
