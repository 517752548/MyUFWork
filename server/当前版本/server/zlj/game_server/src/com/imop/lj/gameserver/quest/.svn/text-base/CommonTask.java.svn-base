package com.imop.lj.gameserver.quest;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.CommonTaskEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.quest.msg.GCQuestUpdate;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;

/**
 * 普通任务对象
 * @author yu.zhao
 *
 */
public class CommonTask extends AbstractTask<Human> implements PersistanceObject<String, CommonTaskEntity> {
	
	/** 此实例是否在db中 */
	private boolean isInDb;	
	/** 生命期 */
	private final LifeCycle lifeCycle; 

	public CommonTask(Human owner, QuestTemplate template) {
		super(owner, template);
		lifeCycle = new LifeCycleImpl(this);
	}

	@Override
	public void updateStatusImpl(TaskStatus taskStatus) {
		this.setModified();
	}
	
	@Override
	public boolean onAcceptTaskImpl() {
		//检查任务列表
		Globals.getCommonTaskService().checkAfterAcceptTask(getOwner(), this);
		return true;
	}
	
	@Override
	protected boolean onFinishTaskImpl() {
		//加入完成的任务集合
		getOwner().getCommonTaskManager().addFinishedTask(getQuestId());
		//发消息通知前台，任务完成
		getOwner().sendMessage(new GCQuestUpdate(buildQuestInfo()));
		
		//初始化阶段不进行check
		if (!getOwner().getCommonTaskManager().isInit()) {
			//检查任务列表
			Globals.getCommonTaskService().checkAfterFinishTask(getOwner(), getQuestId());
		}
		//功能开启
		Globals.getFuncService().onFinishQuest(getOwner(), getQuestId());
		//新手引导
		Globals.getGuideService().onFinishQuest(getOwner(), getQuestId());
		return true;
	}
	
	@Override
	protected void onUpdateRecordMap() {
		// 存库
		this.setModified();
		// 通知前台，任务变化
		getOwner().sendMessage(new GCQuestUpdate(buildQuestInfo()));
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
		return "CommonTask#" + this.getDbId();
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
	public CommonTaskEntity toEntity() {
		CommonTaskEntity entity = new CommonTaskEntity();
		entity.setId(getId());
		entity.setCharId(getCharId());
		entity.setQuestId(getQuestId());
		entity.setQuestTypeId(getQuestType().getIndex());
		entity.setStatus(getStatus().getIndex());
		entity.setStartTime(getStartTime());
		entity.setLastUpdateTime(getLastUpdateTime());
		entity.setProps(recordMapToJsonStr());
		return entity;
	}

	@Override
	public void fromEntity(CommonTaskEntity entity) {
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

	public void updateForGM(QuestTemplate tpl, TaskStatus ts) {
		this.template = tpl;
		this.status = ts;
		this.setModified();
	}
	
}
