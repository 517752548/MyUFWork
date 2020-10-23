package com.imop.lj.gameserver.offlinereward;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.core.util.Assert;
import com.imop.lj.core.uuid.UUIDType;
import com.imop.lj.db.model.OfflineRewardEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.offlinereward.OfflineRewardDef.OfflineRewardType;
import com.imop.lj.gameserver.reward.Reward;

/**
 * 玩家离线奖励对象
 * @author yu.zhao
 *
 */
public class OfflineReward implements PersistanceObject<Long, OfflineRewardEntity> {
	/** 离线奖励的唯一Id */
	private Long id;

	/** 所有者 */
	private Human owner;
	/** 玩家Id */
	private long charId;
	/** 奖励类型 */
	private OfflineRewardType offlineRewardType;
	/** 奖励 */
	private Reward reward;
	/** 属性 */
	private String props;
	/** 创建时间 */
	private long createTime;

	/** 此实例是否在db中 */
	private boolean isInDb;
	/** 邮件的生命期的状态 */
	private final LifeCycle lifeCycle;

	private OfflineReward(Human owner) {
		lifeCycle = new LifeCycleImpl(this);
		this.owner = owner;
	}

	/**
	 * 创建不绑定所有者的奖励，创建时默认是未激活状态，即不会出现在游戏世界中，也不会对应数据库中的记录
	 * 
	 * @return
	 */
	public static OfflineReward newDeactivedInstanceWithoutOwner() {
		OfflineReward offlineReward = new OfflineReward(null);
		offlineReward.lifeCycle.deactivate();
		offlineReward.setId(Globals.getUUIDService().getNextUUID(UUIDType.OFFLINEREWARD));
		offlineReward.setCreateTime(Globals.getTimeService().now());
		return offlineReward;
	}
	
	/**
	 * 创建一个激活的邮件对象,例如从库中读取
	 * 
	 * @param owner
	 * @return
	 */
	public static OfflineReward newActivatedInstance(Human owner) {
		Assert.notNull(owner);
		OfflineReward offlineReward = new OfflineReward(owner);
		offlineReward.setCharId(owner.getCharId());
		offlineReward.setId(Globals.getUUIDService().getNextUUID(UUIDType.OFFLINEREWARD));
		offlineReward.setCreateTime(Globals.getTimeService().now());
		offlineReward.lifeCycle.activate();
		return offlineReward;
	}

	/**
	 * 从OfflineRewardEntity生成一个OfflineReward实例
	 * 
	 * @param entity
	 * @return
	 */
	public static OfflineReward buildFromItemEntity(OfflineRewardEntity entity, Human owner) {
		OfflineReward reward = new OfflineReward(owner);
		reward.fromEntity(entity);
		return reward;
	}
	
	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public Human getOwner() {
		return owner;
	}

	public void setOwner(Human owner) {
		this.owner = owner;
	}

	public OfflineRewardType getOfflineRewardType() {
		return offlineRewardType;
	}

	public void setOfflineRewardType(OfflineRewardType offlineRewardType) {
		this.offlineRewardType = offlineRewardType;
	}

	public Reward getReward() {
		return reward;
	}

	public void setReward(Reward reward) {
		this.reward = reward;
	}

	public String getProps() {
		return props;
	}

	public void setProps(String props) {
		this.props = props;
	}

	public long getCreateTime() {
		return createTime;
	}

	public void setCreateTime(long createTime) {
		this.createTime = createTime;
	}

	public void setCharId(long charId) {
		this.charId = charId;
	}

	@Override
	public void fromEntity(OfflineRewardEntity entity) {
		this.setDbId(entity.getId());
		this.setCharId(entity.getCharId());
		this.setOfflineRewardType(OfflineRewardType.valueOf(entity.getRewardType()));
		this.setReward(Reward.fromJsonStr(entity.getRewards()));
		this.setProps(entity.getProps());
		this.setCreateTime(entity.getCreateTime());
		this.setInDb(true);
	}
	
	@Override
	public OfflineRewardEntity toEntity() {
		OfflineRewardEntity rewardEntity = new OfflineRewardEntity();
		rewardEntity.setId(getDbId());
		rewardEntity.setCharId(getCharId());
		rewardEntity.setRewardType(getOfflineRewardType().getIndex());
		rewardEntity.setRewards(getReward().toJsonObj().toString());
		rewardEntity.setProps(getProps());
		rewardEntity.setCreateTime(getCreateTime());
		return rewardEntity;
	}

	@Override
	public long getCharId() {
		return charId;
	}

	@Override
	public String getGUID() {
		return "OfflineRewardEntity#" + this.id;
	}

	@Override
	public Long getDbId() {
		return this.id;
	}

	@Override
	public void setDbId(Long id) {
		this.id = id;
	}

	@Override
	public LifeCycle getLifeCycle() {
		return lifeCycle;
	}

	@Override
	public boolean isInDb() {
		return isInDb;
	}

	@Override
	public void setInDb(boolean inDb) {
		this.isInDb = inDb;
	}

	@Override
	public void setModified() {
		if (owner != null) {
			// 为了防止发生一些错误的使用状况,暂时把此处的检查限制得很严格
			this.lifeCycle.checkModifiable();
			if (this.lifeCycle.isActive()) {
				// 邮件的生命期处于活动状态,则执行通知更新机制进行
				this.getOwner().getPlayer().getDataUpdater().addUpdate(this.getLifeCycle());
			}
		}
	}

	/**
	 * 删除奖励
	 */
	public void onDelete() {
		this.lifeCycle.destroy();
		if (Loggers.offlineRewardLogger.isDebugEnabled()) {
			Loggers.offlineRewardLogger.debug(String.format("delete offlineReward=%s ", this.getId()));
		}
		this.getOwner().getPlayer().getDataUpdater().addDelete(this.getLifeCycle());
	}
	
	@Override
	public boolean equals(Object obj) {
		if (this == obj) {
			return true;
		}
		if (obj == null) {
			return false;
		}
		if (getClass() != obj.getClass()) {
			return false;
		}
		OfflineReward other = (OfflineReward) obj;
		if (!getId().equals(other.getId())) {
			return false;
		}
		return true;
	}
	
	@Override
	public String toString() {
		return "OfflineReward [id=" + id + ", charId=" + charId
				+ ", offlineRewardType=" + offlineRewardType + ", reward="
				+ reward + ", props=" + props + ", createTime=" + createTime
				+ ", isInDb=" + isInDb + "]";
	}

}
