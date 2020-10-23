package com.imop.lj.gameserver.xianhu.model;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.XianhuEntity;
import com.imop.lj.gameserver.common.Globals;

/**
 * 仙葫玩家数据对象
 * @author yu.zhao
 *
 */
public class Xianhu implements PersistanceObject<Long, XianhuEntity> {
	/** 主键 */
	private long id;
	
	/** 所属角色 */
	private long charId;
	
	/** 祈福仙葫日次数 */
	private int normalCount;
	/** 祈福仙葫日次数 最后一次更新时间 */
	private long normalLastTime;
	
	/** 灵犀祈福日次数 */
	private int lingxiDayCount;
	/** 祈福仙葫日次数 最后一次更新时间 */
	private long lingxiDayLastTime;
	
	/** 灵犀祈福周次数 */
	private int lingxiWeekCount;
	/** 祈福仙葫周次数 最后一次更新时间 */
	private long lingxiWeekLastTime;
	
	/** 此实例是否在db中 */
	private boolean isInDb;
	/** 生命期 */
	private final LifeCycle lifeCycle;
	
	public Xianhu() {
		lifeCycle = new LifeCycleImpl(this);
	}

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public long getRoleId() {
		return charId;
	}

	public void setRoleId(long roleId) {
		this.charId = roleId;
	}

	public int getNormalCount() {
		return normalCount;
	}

	public void setNormalCount(int normalCount) {
		this.normalCount = normalCount;
	}

	public long getNormalLastTime() {
		return normalLastTime;
	}

	public void setNormalLastTime(long normalLastTime) {
		this.normalLastTime = normalLastTime;
	}

	public int getLingxiDayCount() {
		return lingxiDayCount;
	}

	public void setLingxiDayCount(int lingxiDayCount) {
		this.lingxiDayCount = lingxiDayCount;
	}

	public long getLingxiDayLastTime() {
		return lingxiDayLastTime;
	}

	public void setLingxiDayLastTime(long lingxiDayLastTime) {
		this.lingxiDayLastTime = lingxiDayLastTime;
	}

	public int getLingxiWeekCount() {
		return lingxiWeekCount;
	}

	public void setLingxiWeekCount(int lingxiWeekCount) {
		this.lingxiWeekCount = lingxiWeekCount;
	}

	public long getLingxiWeekLastTime() {
		return lingxiWeekLastTime;
	}

	public void setLingxiWeekLastTime(long lingxiWeekLastTime) {
		this.lingxiWeekLastTime = lingxiWeekLastTime;
	}

	@Override
	public void setDbId(Long id) {
		this.setId(id);
	}

	@Override
	public Long getDbId() {
		return getId();
	}

	@Override
	public String getGUID() {
		return "Xianhu#" + this.getId();
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
		return getRoleId();
	}

	@Override
	public XianhuEntity toEntity() {
		XianhuEntity entity = new XianhuEntity();
		entity.setId(getId());
		entity.setCharId(getRoleId());
		entity.setNormalCount(getNormalCount());
		entity.setNormalLastTime(getNormalLastTime());
		entity.setLingxiDayCount(getLingxiDayCount());
		entity.setLingxiDayLastTime(getLingxiDayLastTime());
		entity.setLingxiWeekCount(getLingxiWeekCount());
		entity.setLingxiWeekLastTime(getLingxiWeekLastTime());
		
		return entity;
	}

	@Override
	public void fromEntity(XianhuEntity entity) {
		setId(entity.getId());
		setRoleId(entity.getCharId());
		setNormalCount(entity.getNormalCount());
		setNormalLastTime(entity.getNormalLastTime());
		setLingxiDayCount(entity.getLingxiDayCount());
		setLingxiDayLastTime(entity.getLingxiDayLastTime());
		setLingxiWeekCount(entity.getLingxiWeekCount());
		setLingxiWeekLastTime(entity.getLingxiWeekLastTime());
		
		setInDb(true);
		active();
	}

	@Override
	public LifeCycle getLifeCycle() {
		return lifeCycle;
	}

	@Override
	public void setModified() {
		if (this.lifeCycle.isActive()) {
			Globals.getSceneService().getCommonScene().getCommonDataUpdater().addUpdate(lifeCycle);
		}
	}
	
	/**
	 * 激活
	 */
	public void active() {
		this.lifeCycle.activate();
	}

	/**
	 * 删除
	 */
	public void onDelete() {
		this.lifeCycle.destroy();
		Globals.getSceneService().getCommonScene().getCommonDataUpdater().addDelete(lifeCycle);
	}
	
}
