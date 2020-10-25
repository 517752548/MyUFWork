package com.imop.lj.gameserver.timelimit.monster;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.TimeLimitMonsterEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;
import com.imop.lj.gameserver.timelimit.msg.GCTlMonsterUpdate;

/**
 * 帮派对象
 *
 */
public class TimeLimitMonster extends AbstractTask<Human> implements PersistanceObject<String, TimeLimitMonsterEntity> {
	
	/** 此实例是否在db中 */
	private boolean isInDb;
	/** 生命期 */
	private final LifeCycle lifeCycle;

	public TimeLimitMonster(Human owner, QuestTemplate template) {
		super(owner, template);
		lifeCycle = new LifeCycleImpl(this);
	}

	@Override
	public void updateStatusImpl(TaskStatus taskStatus) {
		this.setModified();
	}
	
	@Override
	public boolean onAcceptTaskImpl() {
		boolean flag = Globals.getTimeLimitMonsterTaskService().onAcceptTaskImpl(getOwner(), this);
		return flag;
	}
	
	@Override
	protected boolean onFinishTaskImpl() {
		boolean flag = Globals.getTimeLimitMonsterTaskService().onFinishTaskImpl(getOwner());
		return flag;
	}
	
	@Override
	public boolean onGiveupTaskImpl() {
		boolean flag = Globals.getTimeLimitMonsterTaskService().onGiveupTaskImpl(getOwner());
		return flag;
	}
	
	@Override
	protected void onUpdateRecordMap() {
		// 存库
		this.setModified();
		// 通知前台，任务变化
		getOwner().sendMessage(new GCTlMonsterUpdate(buildQuestInfo()));
		return;
	}

	@Override
	public void setDbId(String id) {
		this.setId(id);
	}

	@Override
	public String getDbId() {
		return getId();
	}

	@Override
	public String getGUID() {
		return "CorpsTask#" + this.getDbId();
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
		if (getOwner() != null) {
			return getOwner().getUUID();
		} else {
			return 0;
		}
	}

	@Override
	public TimeLimitMonsterEntity toEntity() {
		TimeLimitMonsterEntity entity = new TimeLimitMonsterEntity();
		entity.setId(getId());
		entity.setCharId(getCharId());
		entity.setQuestId(getQuestId());
		entity.setStatus(getStatus().getIndex());
		entity.setStartTime(getStartTime());
		entity.setLastUpdateTime(getLastUpdateTime());
		entity.setProps(recordMapToJsonStr());
		return entity;
	}

	@Override
	public void fromEntity(TimeLimitMonsterEntity entity) {
		setId(entity.getId());
		setStatus(TaskStatus.indexOf(entity.getStatus()));
		setStartTime(entity.getStartTime());
		setLastUpdateTime(entity.getLastUpdateTime());
		recordMapFromJsonStr(entity.getProps());
		
		setInDb(true);
		active();
	}

	@Override
	public LifeCycle getLifeCycle() {
		return lifeCycle;
	}

	@Override
	public void setModified() {
		if (getOwner() != null) {
			this.lifeCycle.checkModifiable();
			if (this.lifeCycle.isActive()) {
				getOwner().getPlayer().getDataUpdater().addUpdate(lifeCycle);
			}
		}
	}
	
	/**
	 * 激活
	 */
	public void active() {
		getLifeCycle().activate();
	}
}
