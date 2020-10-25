package com.imop.lj.gameserver.pubtask;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.PubTaskEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.pubtask.msg.GCPubtaskUpdate;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;

/**
 * 酒馆任务对象
 * @author yu.zhao
 *
 */
public class PubTask extends AbstractTask<Human> implements PersistanceObject<String, PubTaskEntity> {
	
	/** 此实例是否在db中 */
	private boolean isInDb;
	/** 生命期 */
	private final LifeCycle lifeCycle;
	
	/** 任务星数 */
	private int star;

	public PubTask(Human owner, QuestTemplate template) {
		super(owner, template);
		lifeCycle = new LifeCycleImpl(this);
	}

	@Override
	public void updateStatusImpl(TaskStatus taskStatus) {
		this.setModified();
	}
	
	@Override
	public boolean onAcceptTaskImpl() {
		boolean flag = Globals.getPubTaskService().onAcceptTask(getOwner(), this);
		return flag;
	}
	
	@Override
	protected boolean onFinishTaskImpl() {
		boolean flag = Globals.getPubTaskService().onFinishTask(getOwner());
		return flag;
	}
	
	@Override
	public boolean onGiveupTaskImpl() {
		boolean flag = Globals.getPubTaskService().onGiveupTask(getOwner());
		return flag;
	}
	
	@Override
	protected void onUpdateRecordMap() {
		// 存库
		this.setModified();
		// 通知前台，任务变化
		getOwner().sendMessage(new GCPubtaskUpdate(buildQuestInfo()));
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
		return "PubTask#" + this.getDbId();
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
	public PubTaskEntity toEntity() {
		PubTaskEntity entity = new PubTaskEntity();
		entity.setId(getId());
		entity.setCharId(getCharId());
		entity.setQuestId(getQuestId());
		entity.setQuestStar(getStar());
		entity.setStatus(getStatus().getIndex());
		entity.setStartTime(getStartTime());
		entity.setLastUpdateTime(getLastUpdateTime());
		entity.setProps(recordMapToJsonStr());
		return entity;
	}

	@Override
	public void fromEntity(PubTaskEntity entity) {
		setId(entity.getId());
		setStar(entity.getQuestStar());
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

	public int getStar() {
		return star;
	}

	public void setStar(int star) {
		this.star = star;
	}

}
