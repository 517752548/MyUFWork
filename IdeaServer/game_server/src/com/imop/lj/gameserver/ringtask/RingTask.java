package com.imop.lj.gameserver.ringtask;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.RingTaskEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.ringtask.msg.GCRingtaskUpdate;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;

/**
 * 跑环任务对象
 *
 */
public class RingTask extends AbstractTask<Human> implements PersistanceObject<String, RingTaskEntity> {
	
	/** 此实例是否在db中 */
	private boolean isInDb;
	/** 生命期 */
	private final LifeCycle lifeCycle;
	
	public RingTask(Human owner, QuestTemplate template) {
		super(owner, template);
		lifeCycle = new LifeCycleImpl(this);
	}

	@Override
	public void updateStatusImpl(TaskStatus taskStatus) {
		this.setModified();
	}
	
	@Override
	public boolean onAcceptTaskImpl() {
		boolean flag = Globals.getRingTaskService().onAcceptTaskImpl(getOwner(), this);
		return flag;
	}
	
	@Override
	protected boolean onFinishTaskImpl() {
		boolean flag = Globals.getRingTaskService().onFinishTaskImpl(getOwner());
		return flag;
	}
	
	@Override
	public boolean onGiveupTaskImpl() {
		boolean flag = Globals.getRingTaskService().onGiveupTaskImpl(getOwner());
		return flag;
	}
	
	@Override
	protected void onUpdateRecordMap() {
		// 存库
		this.setModified();
		// 通知前台，任务变化
		getOwner().sendMessage(new GCRingtaskUpdate(buildQuestInfo()));
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
		return "RingTask#" + this.getDbId();
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
	public RingTaskEntity toEntity() {
		RingTaskEntity entity = new RingTaskEntity();
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
	public void fromEntity(RingTaskEntity entity) {
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
