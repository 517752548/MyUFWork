package com.imop.lj.gameserver.corps.model;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.LogReasons.CorpsLogReason;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.db.model.CorpsEntity;
import com.imop.lj.db.model.CorpsMemberEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsMemberState;
import com.imop.lj.gameserver.corps.CorpsDef.MemberJob;
import com.imop.lj.gameserver.corps.manager.CorpsMemberApplyManager;
import com.imop.lj.gameserver.corps.manager.CorpsMemberManager;
import com.imop.lj.gameserver.corps.manager.CorpsStorage;
import com.imop.lj.gameserver.corps.template.CorpsUpgradeTemplate;
import com.imop.lj.gameserver.map.model.CorpsMainMap;

import net.sf.json.JSONArray;

/**
 * 军团
 * 
 * @author xiaowei.liu
 * 
 */
/**
 * @author Administrator
 *
 */
public class Corps implements PersistanceObject<Long, CorpsEntity> {
	/** 军团ID */
	private long id;
	/** 国家 */
	private int country;
	/** 国家 */
	private String name;
	/** 军团级别 */
	private int level;
	/** 当前经验 */
	private long currExp;
	/** 当前帮派资金 */
	private long currFund;
	/** 当前成员数量 */
	private int currMemNum;
	/**军团QQ*/
	private String qq;
	/** 公告 */
	private String notice;
	/** 会长 */
	private long president;
	/** 会长名 */
	private String presidentName;
	/** 创建者 */
	private long creater;
	/** 创建时间 */
	private long createDate;
	/** 能否改名，合服时被改名的标记 */
	private int canRename;
	
	/** 副会长id，可为0 */
	private long viceChairman;

	/**
	 * 军团排名
	 */
	private int rank;

	/** 此实例是否在db中 */
	private boolean isInDb;

	/** 生命期 */
	private final LifeCycle lifeCycle;

	/**已加入军团的成员管理*/
	private CorpsMemberManager corpsMemberManager = new CorpsMemberManager();
	
	/**已申请成员*/
	private CorpsMemberApplyManager corpsMemberApplyManager = new CorpsMemberApplyManager(this);
	
	/**军团事件*/
	private LinkedList<CorpsEvent> corpsEventList = Lists.newLinkedList();
	
	/**军团仓库*/
	private CorpsStorage storage;
	
	/** 军团主城地图 */
	private CorpsMainMap mainMap;
	
	/** 帮派解散时间 */
	private Long disbandConfirmDate = -1L;
	
	/** 帮派升级时间 */
//	private Long upgradeConfirmDate = -1L;
	
	/** 帮派维护费用通知次数*/
	private int delinquentNum = 0;
	
	/** 本周帮派boss最高进度*/
	private int weekBossLevel;
	
	/** 本周帮派boss最高进度录像*/
	private String weekBossLevelReplay;
	
	/** 本周帮派boss最少回合数*/
	private int weekBossRound;
	
	/** 本周帮派boss挑战次数*/
	private int weekBossCount;
	
	/** 本周挑战帮派boss时间*/
	private long weekBossUpdateTime;
	
	/** Map<建筑类型,CorpsBuildData(字段和升级时间)> */
	private Map<Integer, CorpsBuildData> buildingMap = Maps.newHashMap();

	public Corps() {
		this.lifeCycle = new LifeCycleImpl(this);
		storage = new CorpsStorage(this);
	}

	/**
	 * 激活
	 */
	public void activate() {
		this.lifeCycle.activate();
	}

	/**
	 * 加载本商会成员
	 * 
	 * @return 成功返回NULL,失败返回失败描述
	 */
	public String loadCorpsMember() {
		List<CorpsMemberEntity> memList = Globals.getDaoService().getCorpsMemberDao().loadAllCorpsMemberByCorpsId(this.id);
		if (memList == null || memList.isEmpty()) {
			Loggers.corpsLogger.error("Corps.loadCorpsMember : corpsId = "	+ this.id + "memList is empty!!!");
			return "memList is empty";
		}

		// 加载军团成员
		for (CorpsMemberEntity memEntity : memList) {
			CorpsMember mem = new CorpsMember(this);
			mem.fromEntity(memEntity);
			mem.setCorps(this);
			if (mem.getState() == CorpsMemberState.NORMAL) {
				// 添加到军团成员列表
				//mem.setJob(MemberJob.MEMBER);
				this.corpsMemberManager.addCorpsMember(mem);
			} else if (mem.getState() == CorpsMemberState.WAIT_APPLY) {
				// 添加到申请列表
				mem.setJob(MemberJob.NONE);
				this.addApplyCorpsMember(mem);
			}
			
			//激活
			mem.activate();
		}

		if (this.corpsMemberManager.size() == 0) {
			// 成员列表为空
			return "memList is empty";
		}

		// 是否有团长
		CorpsMember chairman = this.corpsMemberManager.getCorpsMemberByRoleId(this.president);
		if (chairman == null) {
			Loggers.corpsLogger.error("Corps.loadCorpsMember : corpsId = " + this.id + ", presidentId = " + this.president + " does no exist!!!");
			return "president does not exist";
		} else {
			chairman.setJob(MemberJob.PRESIDENT);
		}

		this.corpsMemberManager.sortCorpsMember();
		return null;
	}

	/**
	 * 添加军团成员
	 * 
	 * @param mem
	 * @return
	 */
	public boolean addCorpsMember(CorpsMember mem) {
		if(!this.corpsMemberManager.addCorpsMember(mem)){
			return false;
		}

		// 添加到CorpsService中
		Globals.getCorpsService().addJoinCorpsMap(mem);
		return true;
	}
	
	/**
	 * 给军团增加经验通过成员
	 * 
	 * @param exp
	 */
	public void addExpByMember(long exp){
//		//记录成员累加经验
//		if(exp >= Long.MAX_VALUE - this.memberExp){
//			this.memberExp = Long.MAX_VALUE;
//		}else{
//			this.memberExp += exp;
//		}
//		
//		//增加军团经验
//		this.addExp(exp);
	}
	
	/**
	 * 给军团增加经验通过军团
	 * 
	 * @param exp
	 */
	public void addExpByCorps(long exp){
		CorpsUpgradeTemplate tpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getCorpsUpgradeTplByLevel(this.level);
		if(tpl == null){
			return;
		}
		if(exp >= Long.MAX_VALUE - this.currExp){
			this.currExp = Long.MAX_VALUE;
		}else if(this.currExp >= tpl.getUpgradeExp()){
			return;
		}else if(this.currExp < tpl.getUpgradeExp()){
			this.currExp += exp;
		}
		this.setModified();
		
	}

	/**
	 * 帮派增加资金
	 * @param fund
	 */
	public void addFund(long fund){
		CorpsUpgradeTemplate tpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getCorpsUpgradeTplByLevel(this.level);
		if(tpl == null){
			return;
		}
		if(fund >= Long.MAX_VALUE - this.currFund){
			this.currFund = Long.MAX_VALUE;
		}
		this.currFund += fund;
		
		this.setModified();
	}
	

	/**
	 * 当前容量
	 * 
	 * @return
	 */
	public int capacity() {
		CorpsUpgradeTemplate temp = Globals.getTemplateCacheService().get(this.level, CorpsUpgradeTemplate.class);
		if(temp == null){
			return 0;
		}

		return temp.getMaxMemberNum();
	}

	/**
	 * 是否人数已满
	 * 
	 * @return
	 */
	public boolean isEnough() {
		CorpsUpgradeTemplate temp = Globals.getTemplateCacheService().get(
				this.level, CorpsUpgradeTemplate.class);
		if (temp == null) {
			return true;
		}

		return this.corpsMemberManager.size() >= temp.getMaxMemberNum();
	}

	/**
	 * 添加申请列表
	 * 
	 * @param mem
	 */
	public boolean addApplyCorpsMember(CorpsMember mem) {
		boolean succ = Globals.getCorpsService().addApplyList(mem);
		if (succ) {
			return this.corpsMemberApplyManager.addApplyCorpsMember(mem);
		} else {
			return false;
		}
	}

	/**
	 * 加入军团
	 * 
	 * @param mem
	 * @return
	 */
	public boolean join(CorpsMember mem) {
		// 删除申请
		CorpsMember joinMem = this.corpsMemberApplyManager.remove(mem.getRoleId());
		if (joinMem == null) {
			return false;
		}
		// 转换状态
		joinMem.onJoin();

		// 删除申请
		Globals.getCorpsService().deleteApplyCorpsMemberInfo(mem.getRoleId(), this.id);
		
		// 加入
		this.addCorpsMember(mem);
		
		// 设置在线状态
		if(Globals.getOnlinePlayerService().isRoleOnline(mem.getRoleId())){
			mem.setOnline(true);
		}else{
			mem.setOnline(false);
		}

		joinMem.setModified();
		return true;
	}
	
	/**
	 * 退出军团
	 * 
	 * @param mem
	 * @return
	 */
	public boolean exit(CorpsMember mem){
		CorpsMember exitMem = this.corpsMemberManager.remove(mem.getRoleId());
		if (exitMem == null) {
			return false;
		}
		exitMem.setJob(MemberJob.NONE);
		exitMem.setState(CorpsMemberState.NONE);
		
		//删除申请
		this.corpsMemberApplyManager.remove(mem.getRoleId());
		
		Globals.getCorpsService().deleteApplyCorpsMemberInfo(mem.getRoleId(), this.id);
		
		//删除引用
		Globals.getCorpsService().deleteJoinCorpsMemberInfo(mem.getRoleId());
		
		exitMem.onDelete();
		return true;
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
		return "Corps#" + this.id;
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
		return this.id;
	}

	/* (non-Javadoc)
	 * @see com.imop.lj.core.object.PersistanceObject#toEntity()
	 */
	@Override
	public CorpsEntity toEntity() {
		CorpsEntity entity = new CorpsEntity();

		/** 军团ID */
		entity.setId(this.id);
		/** 名字 */
		entity.setName(this.name);
		/** 军团级别 */
		entity.setLevel(this.level);
		/** 当前帮派经验 */
		entity.setCurrExp(this.currExp);
		/** 当前帮派资金 */
		entity.setCurrFund(this.currFund);
		/** 当前成员数量*/
		entity.setCurrMemNum(this.currMemNum);
		/** 公告 */
		entity.setNotice(this.notice);
		/** 会长 */
		entity.setPresident(this.president);
		/** 会长名 */
		entity.setPresidentName(this.presidentName);
		/** 创建者 */
		entity.setCreater(this.creater);
		/** 创建时间 */
		entity.setCreateDate(this.createDate);
		/** 仓库信息 */
		entity.setStoragePack(this.storage.toJSON());
		/** 能否改名，合服时被改名的标记 */
		entity.setCanRename(this.canRename);
		/** 帮派确认解散时间 */
		entity.setDisbandConfrimDate(this.disbandConfirmDate);
		/** 帮派确认升级时间 */
//		entity.setUpgradeConfrimDate(this.upgradeConfirmDate);
		/** 帮派维护费用通知次数*/
		entity.setDelinquentNum(this.delinquentNum);
		/** 本周帮派boss最高进度*/
		entity.setWeekBossLevel(this.weekBossLevel);
		/** 本周帮派boss最高进度录像*/
		entity.setWeekBossLevelReplay(this.weekBossLevelReplay);
		/** 本周帮派boss最少回合数*/
		entity.setWeekBossRound(this.weekBossRound);
		/** 本周帮派boss挑战次数*/
		entity.setWeekBossCount(this.weekBossCount);
		/** 本周挑战帮派boss时间*/
		entity.setWeekBossUpdateTime(this.weekBossUpdateTime);
		/** 帮派建筑信息*/
		entity.setBuildInfo(buildingMapToJson());
		return entity;
	}

	@Override
	public void fromEntity(CorpsEntity entity) {
		this.isInDb = true;

		/** 军团ID */
		this.id = entity.getId();
		/** 名字 */
		this.name = entity.getName();
		/** 军团级别 */
		this.level = entity.getLevel();
		/** 帮派当前经验 */
		this.currExp = entity.getCurrExp();
		/** 帮派当前资金 */
		this.currFund = entity.getCurrFund();
		/** 当前成员数量*/
		this.currMemNum = entity.getCurrMemNum();
		/** 公告 */
		this.notice = entity.getNotice();
		/** 会长 */
		this.president = entity.getPresident();
		/** 会长名 */
		this.presidentName = entity.getPresidentName();
		/** 创建者 */
		this.creater = entity.getCreater();
		/** 创建时间 */
		this.createDate = entity.getCreateDate();
		/** 初始化仓库 */
		this.storage.initCorpsStorage(entity.getStoragePack());
		/** 能否改名，合服时被改名的标记 */
		this.canRename = entity.getCanRename();
		/** 帮派确认解散时间 */
		this.disbandConfirmDate = entity.getDisbandConfrimDate();
		/** 帮派确认升级时间*/
//		this.upgradeConfirmDate = entity.getUpgradeConfrimDate();
		/** 帮派维护费用通知次数*/
		this.delinquentNum = entity.getDelinquentNum();
		/** 本周帮派boss最高进度*/
		this.weekBossLevel = entity.getWeekBossLevel();
		/** 本周帮派boss最高进度录像*/
		this.weekBossLevelReplay = entity.getWeekBossLevelReplay();
		/** 本周帮派boss最少回合数*/
		this.weekBossRound = entity.getWeekBossRound();
		/** 本周帮派boss挑战次数*/
		this.weekBossCount = entity.getWeekBossCount();
		/** 本周挑战帮派boss时间*/
		this.weekBossUpdateTime = entity.getWeekBossUpdateTime();
		/** 帮派建筑信息*/
		this.buildingMapFromJson(entity.getBuildInfo());
	}

	@Override
	public LifeCycle getLifeCycle() {
		return this.lifeCycle;
	}

	@Override
	public void setModified() {
		if (this.lifeCycle.isActive()) {
			Globals.getSceneService().getCommonScene().getCommonDataUpdater().addUpdate(lifeCycle);
		}

	}
	
	/**
	 * 军团当前成员数量
	 * 
	 * @return
	 */
	public int size(){
		return this.corpsMemberManager.size();
	}

	/**
	 * 解散
	 */
	public void onDisband(){
		this.onDelete();
		// 删除军团相关信息
		Globals.getCorpsService().deleteCorpsInfo(this);
		//删除军团所有成员
		this.corpsMemberManager.clear();
		//删除所有申请
		this.corpsMemberApplyManager.clear();
	}

	/**
	 * 删除
	 */
	public void onDelete() {
		this.lifeCycle.destroy();
		Globals.getSceneService().getCommonScene().getCommonDataUpdater().addDelete(lifeCycle);
	}
	
	/**
	 * 添加军团事件
	 * 
	 * @param event
	 */
	public void addEvent(CorpsEvent event){
		int size = this.corpsEventList.size();
		if(size >= Globals.getGameConstants().getCorpsEventMaxSize()){
			this.corpsEventList.removeLast();
			this.corpsEventList.addFirst(event);
		}else{
			this.corpsEventList.addFirst(event);
		}
		
		//广播军团事件
		Globals.getCorpsService().broadcastCorpsEvent(this, event);
		
		// 军团事件
		String reason = CorpsLogReason.CORPS_EVENT.getReasonText();
		String text = MessageFormat.format(reason, event.getTips());
		Globals.getCorpsService().sendCorpsLog(null, CorpsLogReason.CORPS_EVENT, text, this, null, null);
	}

	public CorpsUpgradeTemplate getCorpsUpgradeTemplate(){
		return Globals.getTemplateCacheService().get(this.level, CorpsUpgradeTemplate.class);
	}
	
	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
		this.setModified();
	}

	public int getCountry() {
		return country;
	}

	public void setCountry(int country) {
		this.country = country;
		this.setModified();
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
		this.setModified();
	}

	public int getLevel() {
		return level;
	}

	public void setLevel(int level) {
		if(this.level + 1 > Globals.getGameConstants().getCorpsLevelLimit()){
			this.level = Globals.getGameConstants().getCorpsLevelLimit();
		}else{
			this.level = level;
		}
		this.setModified();
	}

	public long getCurrExp() {
		return currExp;
	}

	public void setCurrExp(long currExp) {
		this.currExp = currExp;
		this.setModified();
	}

	public String getNotice() {
		return notice;
	}

	public void setNotice(String notice) {
		this.notice = notice;
		this.setModified();
	}

	public long getPresident() {
		return president;
	}

	public void setPresident(long president) {
		this.president = president;
		this.setModified();
	}

	public String getPresidentName() {
		return presidentName;
	}

	public void setPresidentName(String presidentName) {
		this.presidentName = presidentName;
		this.setModified();
	}

	public long getCreater() {
		return creater;
	}

	public void setCreater(long creater) {
		this.creater = creater;
		this.setModified();
	}

	public long getCreateDate() {
		return createDate;
	}

	public void setCreateDate(long createDate) {
		this.createDate = createDate;
		this.setModified();
	}

	public int getRank() {
		return rank;
	}

	public void setRank(int rank) {
		this.rank = rank;
	}

	public CorpsMemberManager getCorpsMemberManager() {
		return corpsMemberManager;
	}

	public CorpsMemberApplyManager getCorpsMemberApplyManager() {
		return corpsMemberApplyManager;
	}

	public LinkedList<CorpsEvent> getCorpsEventList() {
		return corpsEventList;
	}

	public CorpsStorage getStorage() {
		return storage;
	}

	public void setStorage(CorpsStorage storage) {
		this.storage = storage;
		this.setModified();
	}

	public String getQq() {
		return qq;
	}

	public void setQq(String qq) {
		this.qq = qq;
		this.setModified();
	}

	public int getCanRename() {
		return canRename;
	}

	public void setCanRename(int canRename) {
		this.canRename = canRename;
	}

	public CorpsMainMap getMainMap() {
		return mainMap;
	}

	public void setMainMap(CorpsMainMap mainMap) {
		this.mainMap = mainMap;
	}

	/**
	 * 判断对应职位还有位置没
	 * @param job
	 * @return
	 */
	public boolean hasEnoughJobSpace(MemberJob job){
		
		if(job == null || this.getCorpsUpgradeTemplate() == null || this.getCorpsMemberManager() == null){
			return false;
		}
		
		if(this.getCorpsUpgradeTemplate().getMaxMemberNum() <= this.getCorpsMemberManager().size()){
			return false;
		}
		
		if(job == MemberJob.MEMBER){
			return true;
		}
		
		if(job == MemberJob.PRESIDENT || job == MemberJob.NONE){
			return false;
		}
		
		Integer maxNum = 0;
		
		if(job == MemberJob.VICE_CHAIRMAN){
			maxNum = this.getCorpsUpgradeTemplate().getViceChairmanNum();
		}
		
		if(job == MemberJob.ELITE){
			maxNum = this.getCorpsUpgradeTemplate().getEliteNum();
		}
		
		Integer count = 0;
		for(CorpsMember cm : this.getCorpsMemberManager().getCorpsMemberList()){
			if(cm.getJob() == job){
				count ++ ;
			}
		}
		
		if(maxNum > count){
			return true;
		}
		
		return false;
	}

	public Long getDisbandConfirmDate() {
		return disbandConfirmDate;
	}

	public void setDisbandConfirmDate(Long disbandConfirmDate) {
		this.disbandConfirmDate = disbandConfirmDate;
		this.setModified();
	}
	
//	public Long getUpgradeConfirmDate() {
//		return upgradeConfirmDate;
//	}
//
//	public void setUpgradeConfirmDate(Long upgradeConfirmDate) {
//		this.upgradeConfirmDate = upgradeConfirmDate;
//		this.setModified();
//	}

	public long getCurrFund() {
		return currFund;
	}

	public void setCurrFund(long currFund) {
		this.currFund = currFund;
		this.setModified();
	}
	
	public int getCurrMemNum() {
		return currMemNum;
	}

	public void setCurrMemNum(int currMemNum) {
		this.currMemNum = currMemNum;
		this.setModified();
	}

	public int getDelinquentNum() {
		return delinquentNum;
	}

	public void setDelinquentNum(int delinquentNum) {
		this.delinquentNum = delinquentNum;
	}
	
	public int getWeekBossLevel() {
		long now = Globals.getTimeService().now();
		if (!TimeUtils.isInSameWeek(this.weekBossUpdateTime, now)) {
			this.weekBossUpdateTime = now;
			this.weekBossLevel = 0;
		}
		return weekBossLevel;
	}

	public void setWeekBossLevel(int weekBossLevel) {
		this.weekBossLevel = weekBossLevel;
	}
	
	public String getWeekBossLevelReplay() {
		long now = Globals.getTimeService().now();
		if (!TimeUtils.isInSameWeek(this.weekBossUpdateTime, now)) {
			this.weekBossUpdateTime = now;
			this.weekBossLevelReplay = "";
		}
		return weekBossLevelReplay;
	}

	public void setWeekBossLevelReplay(String weekBossLevelReplay) {
		this.weekBossLevelReplay = weekBossLevelReplay;
	}

	public int getWeekBossRound() {
		long now = Globals.getTimeService().now();
		if (!TimeUtils.isInSameWeek(this.weekBossUpdateTime, now)) {
			this.weekBossUpdateTime = now;
			this.weekBossRound = 0;
		}
		return weekBossRound;
	}

	public void setWeekBossRound(int weekBossRound) {
		this.weekBossRound = weekBossRound;
	}

	public int getWeekBossCount() {
		long now = Globals.getTimeService().now();
		if (!TimeUtils.isInSameWeek(this.weekBossUpdateTime, now)) {
			this.weekBossUpdateTime = now;
			this.weekBossCount = 0;
		}
		return weekBossCount;
	}

	public void setWeekBossCount(int weekBossCount) {
		this.weekBossCount = weekBossCount;
	}

	public long getWeekBossUpdateTime() {
		return weekBossUpdateTime;
	}

	public void setWeekBossUpdateTime(long weekBossUpdateTime) {
		this.weekBossUpdateTime = weekBossUpdateTime;
	}

	/**
	 * 弹劾检查
	 */
	public void checkToImpeach(){
		if(this.getCorpsMemberManager() == null){
			return ;
		}
		List<CorpsMember> list = this.getCorpsMemberManager().getCorpsMemberList();
		if(list == null || list.size() <=0){
			return ;
		}
		
		CorpsMember chairman = this.corpsMemberManager.getCorpsMemberByRoleId(this.president);
		
		if (chairman == null) {
			Loggers.corpsLogger.error("Corps.loadCorpsMember : corpsId = " + this.id + ", presidentId = " + this.president + " does no exist!!!");
			//公会必须有会长,否则会有严重问题
			return;
		} 
		
		if(chairman.isOnline()){
			return;
		}
		
		//10天之前不弹劾
		if(TimeUtils.getSoFarWentDays(chairman.getLogoutTime(),Globals.getTimeService().now()) <= Globals.getGameConstants().getImpeachCheckAlertDays()){
			return;
		}
		
		//10 - 11天 发送警告邮件
		if(TimeUtils.getSoFarWentDays(chairman.getLogoutTime(),Globals.getTimeService().now()) >= Globals.getGameConstants().getImpeachCheckAlertDays()
				&& TimeUtils.getSoFarWentDays(chairman.getLogoutTime(),Globals.getTimeService().now()) < Globals.getGameConstants().getImpeachCheckDays()){
			
			return;
		}
		
		//开始弹劾
		
		//找到三天内上线的帮众
		List<CorpsMember> validList = new ArrayList<CorpsMember>();
		for(CorpsMember mem : list){
			if(mem.isOnline()){
				//在线的
				validList.add(mem);
			}
			if(TimeUtils.getSoFarWentDays(mem.getLogoutTime(),Globals.getTimeService().now()) <= Globals.getGameConstants().getImpeachValidDay()){
				//三天内上过线的
				validList.add(mem);
			}
		}
		
		if(validList.isEmpty()){
			//没有人能接替帮主,强行解散帮会
			Globals.getCorpsService().disbandCorpsByImpeach(this.id);
			return;
		}
		
		CorpsMember target = null;
		//副会长
		target = getLargestContributionMember(validList,MemberJob.VICE_CHAIRMAN);
		if(target != null){
			Globals.getCorpsService().transferPresidentByImpeach(chairman, target);
			return ;
		}
		
		//精英
		target = getLargestContributionMember(validList,MemberJob.ELITE);
		if(target != null){
			Globals.getCorpsService().transferPresidentByImpeach(chairman, target);
			return ;
		}
				
		//帮众
		target = getLargestContributionMember(validList,MemberJob.MEMBER);
		if(target != null){
			Globals.getCorpsService().transferPresidentByImpeach(chairman, target);
			return ;
		}
		
		if(target == null){
			//没有人能接替帮主,强行解散帮会
			Globals.getCorpsService().disbandCorpsByImpeach(this.id);
			return;
		}
	}
	/**
	 * 找到当前职位下 历史帮贡最大的人员(对本帮会的帮贡)
	 * @param job
	 * @return
	 */
	public CorpsMember getLargestContributionMember(List<CorpsMember> list, MemberJob job){
		Integer maxContribution = 0;
		CorpsMember target = null;
		for(CorpsMember mem : list){
			if(Globals.getCorpsService().checkJob(mem, job)){
				if(maxContribution < mem.getTotalContribution()){
					target = mem;
					maxContribution = mem.getTotalContribution();
				}
			}
		}
		return target;
	}
	
	/**
	 * 弹劾帮主
	 */
	public void impeachPresident(){
		
	}

	public long getViceChairman() {
		return viceChairman;
	}

	public void setViceChairman(long viceChairman) {
		this.viceChairman = viceChairman;
	}
	
	public String buildingMapToJson() {
		JSONArray jsonArr = new JSONArray();
		for (CorpsBuildData data : buildingMap.values()) {
			jsonArr.add(data.toJson());
		}
		return jsonArr.toString();
	}
	
	public void buildingMapFromJson(String jsonStr) {
		if (jsonStr == null || jsonStr.isEmpty()) {
			return;
		}
		
		JSONArray array = JSONArray.fromObject(jsonStr);
		if (array == null || array.isEmpty()) {
			return;
		}
		
		for (int i = 0; i < array.size(); i++) {
			CorpsBuildData data = CorpsBuildData.fromJson(array.getString(i));
			if (data != null) {
				buildingMap.put(data.getBuildType(), data);
			}
		}
	}
	
	public void addCorpsBuildingData(int type, CorpsBuildData data){
		this.buildingMap.put(type, data);
	}
	
	public Map<Integer, CorpsBuildData> getCorpsBuildingMap(){
		return this.buildingMap;
	}
	
	public CorpsBuildData getCorpsBuildingByType(int type){
		if(buildingMap.containsKey(type)){
			return buildingMap.get(type);
		}
		return null;
	}
	
	public Map<Integer, CorpsBuildData> getBuildingMap() {
		return buildingMap;
	}

	public void setBuildingMap(Map<Integer, CorpsBuildData> buildingMap) {
		for(Entry<Integer, CorpsBuildData> entry : buildingMap.entrySet()){
			this.buildingMap.put(entry.getKey(), entry.getValue());
		}
	}

	public void delCoprsBuildingMap(int type){
		this.buildingMap.remove(type);
	}
}
