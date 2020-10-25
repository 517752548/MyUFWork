package com.imop.lj.gameserver.foragetask;

import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.db.model.ForageTaskEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.RoleDataHolder;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.AbstractTaskManager;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;

import net.sf.json.JSONArray;

/**
 * 护送粮草任务数据管理
 *
 */
public class ForageTaskManager extends AbstractTaskManager<Human> implements RoleDataHolder, JsonPropDataHolder {
	/** 当前进行的任务，进行中或已放弃 */
	private ForageTask curTask;
	/** 备选任务列表，key是任务模板Id */
	private Map<Integer, BackupForageTask> backupMap = new LinkedHashMap<Integer, BackupForageTask>();
	
	public ForageTaskManager(Human owner) {
		super(owner);
	}
	
	/**
	 * 登录时加载所有的任务数据
	 */
	public void load() {
		long charId = owner.getUUID();
		List<ForageTaskEntity> entityList = Globals.getDaoService().getForageTaskDao().loadEntityByCharId(charId);
		for (ForageTaskEntity entity : entityList) {
			QuestTemplate template = Globals.getTemplateCacheService().get(entity.getQuestId(), QuestTemplate.class);
			if (null == template) {
				// 记录错误日志，对应的任务已被删除
				Loggers.questLogger.error("#ForageTaskManager#load#ERROR!questTpl is null!questId=" + entity.getQuestId());
				continue;
			}
			ForageTask task = new ForageTask(owner, template);
			task.fromEntity(entity);
			if (task.isDoing()) {
				//更新当前任务
				updateCurTask(task);
				//当前任务只有一个
				break;
			}
		}
	}
	
	private void updateCurTask(ForageTask task) {
		curTask = task;
	}
	
	@Override
	public String toJsonProp() {
		JSONArray jsonArr = new JSONArray();
		for (Integer k : backupMap.keySet()) {
			jsonArr.add(backupMap.get(k).toJson());
		}
		return jsonArr.toString();
	}

	@Override
	public void loadJsonProp(String value) {
		if (value == null || value.equalsIgnoreCase("")) {
			return;
		}
		JSONArray jsonArr = JSONArray.fromObject(value);
		if (jsonArr.isEmpty()) {
			return;
		}
		
		for (int i = 0; i < jsonArr.size(); i++) {
			String strBackup = jsonArr.getString(i);
			//枚举是否存在
			if (strBackup == null || strBackup.isEmpty()) {
				Loggers.humanLogger.error("#ForageTaskManager#loadJsonProp#task status not exist!humanId=" 
						+ getOwner().getCharId() + ";value=" + value);
				continue;
			}
			
			BackupForageTask bpt = new BackupForageTask();
			bpt.fromJsonStr(strBackup);
			if (Globals.getTemplateCacheService().get(bpt.getQuestId(), QuestTemplate.class) == null) {
				Loggers.humanLogger.error("#ForageTaskManager#loadJsonProp#BackupForageTask not exist!humanId=" 
						+ getOwner().getCharId() + ";value=" + value);
				continue;
			}
			
			//加入map
			addBackupTask(bpt);
		}
	}
	
	private void addBackupTask(BackupForageTask bpt) {
		backupMap.put(bpt.getQuestId(), bpt);
	}
	
	@Override
	public void checkAfterRoleLoad() {
		//登录的时候不需要刷新任务，打开任务面板的时候再刷新
	}

	@Override
	public void checkBeforeRoleEnter() {
		return;
	}

	@SuppressWarnings("rawtypes")
	@Override
	public List<AbstractTask> getDoingTaskList() {
		List<AbstractTask> ret = new ArrayList<AbstractTask>();
		if (isDoing()) {
			ret.add(getCurTask());
		}
		return ret;
	}
	
	@Override
	public boolean canAcceptSpecialCheck(int questId) {
		boolean flag = Globals.getForageTaskService().canAcceptTask(getOwner(), questId);
		return flag;
	}
	
	/**
	 * 任务是否已完成
	 * @param questId
	 * @return
	 */
	@Override
	public boolean isFinished(int questId) {
		return false;
	}
	
	/**
	 * 任务是否进行中
	 * @param questId
	 * @return
	 */
	public boolean isDoing() {
		return this.curTask != null && this.curTask.isDoing();
	}

	public ForageTask getCurTask() {
		return curTask;
	}

	public void setCurTask(ForageTask curTask) {
		this.curTask = curTask;
	}
	
	public BackupForageTask getBackupForageTask(int questId) {
		return backupMap.get(questId);
	}

	public Map<Integer, BackupForageTask> getBackupMap() {
		return backupMap;
	}

	public void setBackupMap(Map<Integer, BackupForageTask> backupMap) {
		this.backupMap = backupMap;
	}
	
	public void clearCurTask() {
		this.curTask = null;
	}

	public void clearTask() {
		this.curTask = null;
		this.backupMap.clear();
	}
	
	@Override
	public Map<Integer,Integer> getTaskRewardByEmemyArmy(int ememyArmyId) {
		Map<Integer, Integer> map = Maps.newHashMap();
		//只有接了但未完成的任务，才算数，可完成的任务就不再获得奖励了
		if (curTask != null && 
				curTask.getStatus() == TaskStatus.ACCEPTED) {
			if(curTask.getTemplate().hasTaskEnemyArmy(ememyArmyId)){
				map.put(curTask.getQuestId(), curTask.getTemplate().getTaskDropRewardId());
			}
		}
		return map;
	}
}
