package com.imop.lj.gameserver.vip;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.VipEntity;
import com.imop.lj.gameserver.common.Globals;

/**
 * VIP
 * 
 * @author xiaowei.liu
 * 
 */
public class Vip implements PersistanceObject<Long, VipEntity> {
	/** 角色ID */
	private long roleId;
	/** VIP等级 */
	private int level;
	/** VIP当前经验 */
	private long exp;
	
	/** 过期时间 */
	private long expireTime;
	/** 临时vip等级 */
	private int tmpLevel;
	
	/** 类型 */
	private int vType;
	/** 最后一次更新时间 */
	private long lastUpdateTime;

	/** 此实例是否在db中 */
	private boolean inDb;
	/** 生命期 */
	private final LifeCycle lifeCycle;
	
	public Vip() {
		this.lifeCycle = new LifeCycleImpl(this);
	}
	
	@Override
	public void setDbId(Long id) {
		this.roleId = id;		
	}

	@Override
	public Long getDbId() {
		return this.roleId;
	}

	@Override
	public String getGUID() {
		return "VIP#" + this.roleId;
	}

	@Override
	public boolean isInDb() {
		return inDb;
	}

	@Override
	public void setInDb(boolean inDb) {
		this.inDb = inDb;
	}

	@Override
	public long getCharId() {
		return this.roleId;
	}

	@Override
	public VipEntity toEntity() {
		VipEntity entity = new VipEntity();
		entity.setRoleId(this.roleId);
		entity.setLevel(this.level);
		entity.setExp(this.exp);
		entity.setvType(this.vType);
		entity.setExpireTime(this.expireTime);
		entity.setLastUpdateTime(this.lastUpdateTime);
		return entity;
	}

	@Override
	public void fromEntity(VipEntity entity) {
		this.roleId = entity.getRoleId();
		this.level = entity.getLevel();
		this.exp = entity.getExp();
		this.vType = entity.getvType();
		this.expireTime = entity.getExpireTime();
		this.lastUpdateTime = entity.getLastUpdateTime();
		
		this.setInDb(true);
		this.active();
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
	 * 激活此对象，并初始化属性 此方法在玩家登录加载完数据
	 */
	public void active() {
		getLifeCycle().activate();
	}
	
	/**
	 * 当删除时
	 */
	public void onDelete() {
		this.lifeCycle.destroy();
		Globals.getSceneService().getCommonScene().getCommonDataUpdater().addDelete(lifeCycle);
	}
	
	public long getRoleId() {
		return roleId;
	}

	public void setRoleId(long roleId) {
		this.roleId = roleId;
		this.setModified();
	}

	public int getLevel() {
		return level;
	}

	public void setLevel(int level) {
		this.level = level;
		this.setModified();
	}

	public long getExp() {
		return exp;
	}

	public void setExp(long exp) {
		this.exp = exp;
		this.setModified();
	}

	public long getExpireTime() {
		return expireTime;
	}

	public void setExpireTime(long expireTime) {
		this.expireTime = expireTime;
		this.setModified();
	}

	public int getvType() {
		return vType;
	}

	public void setvType(int vType) {
		this.vType = vType;
	}

	public long getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(long lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}

	public int getTmpLevel() {
		return tmpLevel;
	}

	public void setTmpLevel(int tmpLevel) {
		this.tmpLevel = tmpLevel;
	}

	public String toLog() {
		StringBuffer sb = new StringBuffer();
		sb.append("level=");
		sb.append(level);
		
		sb.append(",exp=");
		sb.append(exp);
		
		sb.append(",expireTim=");
		sb.append(expireTime);
		
		sb.append(",tmpLevel=");
		sb.append(tmpLevel);
		
		sb.append(",vType=");
		sb.append(vType);
		
		sb.append(",lastUpdateTime=");
		sb.append(lastUpdateTime);
		
		return sb.toString();
	}
}
