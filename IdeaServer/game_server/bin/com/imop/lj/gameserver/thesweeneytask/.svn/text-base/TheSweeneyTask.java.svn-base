package com.imop.lj.gameserver.thesweeneytask;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.TheSweeneyTaskEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;
import com.imop.lj.gameserver.thesweeneytask.msg.GCThesweeneytaskUpdate;

/**
 * 除暴安良任务对象
 * @author maogen.feng
 *
 */
public class TheSweeneyTask extends AbstractTask<Human> implements PersistanceObject<String, TheSweeneyTaskEntity> {
	
	/** 此实例是否在db中 */
	private boolean isInDb;
	/** 生命期 */
	private final LifeCycle lifeCycle;

	public TheSweeneyTask(Human owner, QuestTemplate template) {
		super(owner, template);
		lifeCycle = new LifeCycleImpl(this);
	}

	@Override
	public void updateStatusImpl(TaskStatus taskStatus) {
		this.setModified();
	}
	
	@Override
	public boolean onAcceptTaskImpl() {
		boolean flag = Globals.getTheSweeneyTaskService().onAcceptTask(getOwner(), this);
		return flag;
	}
	
	@Override
	protected boolean onFinishTaskImpl() {
		boolean flag = Globals.getTheSweeneyTaskService().onFinishTask(getOwner());
		return flag;
	}
	
	@Override
	public boolean onGiveupTaskImpl() {
		boolean flag = Globals.getTheSweeneyTaskService().onGiveupTask(getOwner());
		return flag;
	}
	
	@Override
	protected void onUpdateRecordMap() {
		// 存库
		this.setModified();
		// 通知前台，任务变化
		getOwner().sendMessage(new GCThesweeneytaskUpdate(buildQuestInfo()));
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
		return "TheSweeneyTask#" + this.getDbId();
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
	public TheSweeneyTaskEntity toEntity() {
		TheSweeneyTaskEntity entity = new TheSweeneyTaskEntity();
		entity.setId(getId());
		entity.setCharId(getCharId());
		entity.setQuestId(getQuestId());
		entity.setStatus(getStatus().getIndex());
		entity.setStartTime(getStartTime());
		entity.setLastUpdateTime(getLastUpdateTime());
		entity.setProps(recordMapToJsonStr());
		entity.setQuestTypeId(getQuestType().getIndex());
		return entity;
	}

	@Override
	public void fromEntity(TheSweeneyTaskEntity entity) {
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
