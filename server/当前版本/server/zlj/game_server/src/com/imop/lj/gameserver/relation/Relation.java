package com.imop.lj.gameserver.relation;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.RelationEntity;
import com.imop.lj.gameserver.human.Human;

/**
 * 玩家关系对象
 * @author yu.zhao
 *
 */
public class Relation implements PersistanceObject<String, RelationEntity>, InitializeRequired {
	/** 数据库唯一行ID */
	private String UUID;
	
	/** 主人 */
	private Human owner;
	
	/** 主人ID */
	private long charId;
	/** 目标玩家ID */
	private long targetCharId;
	/** 关系类型 */
	private RelationTypeEnum relationType = RelationTypeEnum.NONE;
	/** 创建时间 */
	private long createTime;
	
	/** 是否已经在数据库中 */
	private boolean inDb;
	/** 生命期 */
	private final LifeCycle lifeCycle;
	
	public Relation(Human owner) {
		this.owner = owner;
		this.lifeCycle = new LifeCycleImpl(this);
	}
	
	@Override
	public void init() {
		
	}
	
	public long getTargetCharId() {
		return targetCharId;
	}

	public void setTargetCharId(long targetCharId) {
		this.targetCharId = targetCharId;
		setModified();
	}

	public RelationTypeEnum getRelationType() {
		return relationType;
	}

	public void setRelationType(RelationTypeEnum relationType) {
		this.relationType = relationType;
		setModified();
	}

	public long getCreateTime() {
		return createTime;
	}

	public void setCreateTime(long createTime) {
		this.createTime = createTime;
		setModified();
	}

	public Human getOwner() {
		return owner;
	}
	
	public void setOwner(Human owner) {
		this.owner = owner;
		setModified();
	}
	
	@Override
	public boolean equals(Object obj) {
		if (this == obj) {
			return true;
		}
		if (null == obj) {
			return false;
		}
		if (getClass() != obj.getClass()) {
			return false;
		}
		Relation other = (Relation) obj;
		if (other.getCharId() != getCharId() || 
				other.getTargetCharId() != getTargetCharId()) {
			return false;
		}
		return true;
	}

	@Override
	public void setDbId(String id) {
		this.UUID = id;
	}

	@Override
	public String getDbId() {
		return UUID;
	}

	@Override
	public String getGUID() {
		return "relation#" + this.UUID;
	}

	@Override
	public boolean isInDb() {
		return this.inDb;
	}

	@Override
	public void setInDb(boolean inDb) {
		this.inDb = inDb;
	}

	@Override
	public long getCharId() {
		return this.charId;
	}
	
	public void setCharId(long charId) {
		this.charId = charId;
	}

	@Override
	public RelationEntity toEntity() {
		RelationEntity entity = new RelationEntity();
		entity.setId(getDbId());
		entity.setCharId(getCharId());
		entity.setTargetCharId(getTargetCharId());
		entity.setRelationType(getRelationType().getIndex());
		entity.setCreateTime(this.getCreateTime());
		return entity;
	}

	@Override
	public void fromEntity(RelationEntity entity) {
		this.UUID = entity.getId();
		this.charId = entity.getCharId();
		this.targetCharId = entity.getTargetCharId();
		this.relationType = RelationTypeEnum.valueOf(entity.getRelationType());
		this.createTime = entity.getCreateTime();
		this.setInDb(true);
	}

	@Override
	public LifeCycle getLifeCycle() {
		return lifeCycle;
	}
	
	/**
	 * 激活此关系
	 */
	public void active() {
		getLifeCycle().activate();
	}

	@Override
	public void setModified() {
		if (owner != null
				&& owner.getPlayer() != null) {
			// 为了防止发生一些错误的使用状况,暂时把此处的检查限制得很严格
			this.lifeCycle.checkModifiable();
			if (this.lifeCycle.isActive()) {
				// 生命期处于活动状态,则执行通知更新机制进行
				owner.getPlayer().getDataUpdater().addUpdate(lifeCycle);
			}
		}
	}
	
	/**
	 * 关系被删除回调处理
	 */
	public void onDelete() {
		if (owner != null) {
			// 为了防止发生一些错误的使用状况,暂时把此处的检查限制得很严格
			this.lifeCycle.destroy();
			owner.getPlayer().getDataUpdater().addDelete(lifeCycle);
		}
	}

}
