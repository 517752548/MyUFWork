package com.imop.lj.gameserver.pubtask;

import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

import net.sf.json.JSONArray;

import com.google.common.collect.Maps;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.db.model.PubTaskEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.RoleDataHolder;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.AbstractTaskManager;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;

/**
 * 酒馆任务数据管理
 * @author yu.zhao
 *
 */
public class PubTaskManager extends AbstractTaskManager<Human> implements RoleDataHolder, JsonPropDataHolder {
	/** 当前进行的任务，进行中或已放弃 */
	private PubTask curTask;
	/** 备选任务列表，key是任务模板Id */
	private Map<Integer, BackupPubTask> backupMap = new LinkedHashMap<Integer, BackupPubTask>();
	
	public PubTaskManager(Human owner) {
		super(owner);
	}
	
	/**
	 * 登录时加载所有的任务数据
	 */
	public void load() {
		long charId = owner.getUUID();
		List<PubTaskEntity> entityList = Globals.getDaoService().getPubTaskDao().loadEntityByCharId(charId);
		for (PubTaskEntity entity : entityList) {
			QuestTemplate template = Globals.getTemplateCacheService().get(entity.getQuestId(), QuestTemplate.class);
			if (null == template) {
				// 记录错误日志，对应的任务已被删除
				Loggers.questLogger.error("#PubTaskManager#load#ERROR!questTpl is null!questId=" + entity.getQuestId());
				continue;
			}
			PubTask task = new PubTask(owner, template);
			task.fromEntity(entity);
			if (task.isDoing()) {
				//更新当前任务
				updateCurTask(task);
				//当前任务只有一个
				break;
			}
		}
	}
	
	private void updateCurTask(PubTask task) {
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
				Loggers.humanLogger.error("#PubTaskManager#loadJsonProp#task status not exist!humanId=" 
						+ getOwner().getCharId() + ";value=" + value);
				continue;
			}
			
			BackupPubTask bpt = new BackupPubTask();
			bpt.fromJsonStr(strBackup);
			if (Globals.getTemplateCacheService().get(bpt.getQuestId(), QuestTemplate.class) == null) {
				Loggers.humanLogger.error("#PubTaskManager#loadJsonProp#BackupPubTask not exist!humanId=" 
						+ getOwner().getCharId() + ";value=" + value);
				continue;
			}
			
			//加入map
			addBackupTask(bpt);
		}
	}
	
	private void addBackupTask(BackupPubTask bpt) {
		backupMap.put(bpt.getQuestId(), bpt);
	}
	
	@Override
	public void checkAfterRoleLoad() {
		//检查是否需要刷新任务
		Globals.getPubTaskService().refreshTaskAuto(getOwner());
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
		boolean flag = Globals.getPubTaskService().canAcceptTask(getOwner(), questId);
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

	public PubTask getCurTask() {
		return curTask;
	}

	public void setCurTask(PubTask curTask) {
		this.curTask = curTask;
	}
	
	public BackupPubTask getBackupPubTask(int questId) {
		return backupMap.get(questId);
	}

	public Map<Integer, BackupPubTask> getBackupMap() {
		return backupMap;
	}

	public void setBackupMap(Map<Integer, BackupPubTask> backupMap) {
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
