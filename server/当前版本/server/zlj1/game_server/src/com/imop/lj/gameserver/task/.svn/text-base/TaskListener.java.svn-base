package com.imop.lj.gameserver.task;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.task.TaskDef.DestType;
import com.imop.lj.gameserver.task.TaskDef.NumRecordType;
import com.imop.lj.gameserver.task.dest.ColletionItemDest;
import com.imop.lj.gameserver.task.dest.EquipDest;
import com.imop.lj.gameserver.task.dest.EquipGemDest;
import com.imop.lj.gameserver.task.dest.EquipStarDest;
import com.imop.lj.gameserver.task.dest.IQuestDestination;
import com.imop.lj.gameserver.task.dest.LeaderLevelADest;
import com.imop.lj.gameserver.task.dest.LeaderMindALevelXDest;
import com.imop.lj.gameserver.task.dest.LeaderMindLevelADest;
import com.imop.lj.gameserver.task.dest.NumRecordDest;
import com.imop.lj.gameserver.task.dest.SkillEffectEmbedDest;
import com.imop.lj.gameserver.team.model.Team;

@SuppressWarnings({ "rawtypes", "unchecked" })
public class TaskListener<T extends ITaskOwner> {
	private T owner;
	/** 所有的任务管理器 */
	private List<AbstractTaskManager> managerList = new ArrayList<AbstractTaskManager>();
	
	public TaskListener(T owner) {
		this.owner = owner;
		initAllManager();
	}
	
	private void addTaskManager(AbstractTaskManager atm) {
		if (atm != null) {
			managerList.add(atm);
		} else {
			Loggers.humanLogger.error("some task manager is null!");
		}
	}
	
	private List<AbstractTaskManager> getManagerList() {
		return this.managerList;
	}
	
	private void initAllManager() {
		//XXX 新增的任务管理器从来这里加进去即可
		if (owner instanceof Human) {
			addTaskManager(((Human)owner).getCommonTaskManager());
			addTaskManager(((Human)owner).getPubTaskManager());
			addTaskManager(((Human)owner).getTheSweeneyTaskManager());
			addTaskManager(((Human)owner).getTreasureMapManager());
			addTaskManager(((Human)owner).getForageTaskManager());
			addTaskManager(((Human)owner).getCorpsTaskManager());
			addTaskManager(((Human)owner).getTimeLimitMonsterManager());
			addTaskManager(((Human)owner).getTimeLimitNpcManager());
			addTaskManager(((Human)owner).getDay7TaskManager());
			addTaskManager(((Human)owner).getSiegeDemonNormalTaskManager());
			addTaskManager(((Human)owner).getSiegeDemonHardTaskManager());
			
		} else if (owner instanceof Team) {
			addTaskManager(((Team)owner).getTaskManager());
		}
	}
	
	public T getOwner() {
		return owner;
	}

	public void noneDest(NumRecordType type) {

	}
	
	public void onNumRecordDest(NumRecordType type, int targetId, int num) {
		if (num == 0) {
			return;
		}
		for (AbstractTaskManager atm : getManagerList()) {
			//TODO 这里可能会根据不同的manager，确认该目标类型 是否其关注的，如果不是，则直接跳过
			
			List<AbstractTask> taskList = atm.getDoingTaskList();
			for (AbstractTask task : taskList) {
				onNumRecordDest(task, type, targetId, num);
			}
		}
	}
	
	private void onNumRecordDest(AbstractTask task, NumRecordType type, int targetId,
			int num) {
		List<IQuestDestination> dests = task.getTemplate().getQuestDestList();
		for (IQuestDestination dest : dests) {
			if (dest.getDestType() != DestType.NUM_RECORD) {
				continue;
			}
			// 计数类型
			NumRecordDest desc = (NumRecordDest)dest;
			if (desc.getType() != type) {
				//记数类型与此完成目标无关
				continue;
			}
			
			// 目标Id，如果目标Id为0，则表示对该类型的任意目标Id都计数，不为0则需要判断目标Id是否一致
			if (desc.getTargetId() != 0 && 
					desc.getTargetId() != targetId) {
				//记数类型与此完成目标无关
				continue;
			}
			
			for (int i = 0; i < num; i++) {
				task.increaseOne(DestType.NUM_RECORD, dest.getInstKey());
				if (task.hasFinished() || task.canFinishTask()) {
					break;
				}
			}
		}
	}

	public void onUpdateLevel(Human human, int level) {
		for (AbstractTaskManager atm : getManagerList()) {
			List<AbstractTask> taskList = atm.getDoingTaskList();
			for (AbstractTask task : taskList) {
				onUpdateLevel(task, level);
			}
		}
	}
	
	private void onUpdateLevel(AbstractTask task, int level) {
		List<IQuestDestination> dests = task.getTemplate().getQuestDestList();
		for (IQuestDestination dest : dests) {
			if (dest.getDestType() != DestType.LEADER_LEVEL_A) {
				continue;
			}
			
			LeaderLevelADest tdesc = (LeaderLevelADest) dest;
			if (level >= tdesc.getLeaderLevel()) {
				task.increaseOne(DestType.LEADER_LEVEL_A, dest.getInstKey());
			}
		}
	}
	
	public void onCollectItem(Human human, int itemTplId, int num) {
		for (AbstractTaskManager atm : getManagerList()) {
			//TODO 这里可能会根据不同的manager，确认该目标类型 是否其关注的，如果不是，则直接跳过
			
			List<AbstractTask> taskList = atm.getDoingTaskList();
			for (AbstractTask task : taskList) {
				onCollectItem(task, itemTplId, num);
			}
		}
	}
	
	private void onCollectItem(AbstractTask task, int itemTplId, int num) {
		List<IQuestDestination> dests = task.getTemplate().getQuestDestList();
		for (IQuestDestination dest : dests) {
			if (dest.getDestType() != DestType.COLLECTION_ITEM) {
				continue;
			}
			
			ColletionItemDest tdesc = (ColletionItemDest) dest;
			if (itemTplId == tdesc.getTargetId()) {
				task.increaseOne(DestType.COLLECTION_ITEM, dest.getInstKey());
			}
		}
	}
	
	public void onUpdateMindLevel(Human human, int mindLevel) {
		for (AbstractTaskManager atm : getManagerList()) {
			List<AbstractTask> taskList = atm.getDoingTaskList();
			for (AbstractTask task : taskList) {
				onUpdateMindLevel(task, mindLevel);
			}
		}
	}
	
	private void onUpdateMindLevel(AbstractTask task, int mindLevel) {
		List<IQuestDestination> dests = task.getTemplate().getQuestDestList();
		for (IQuestDestination dest : dests) {
			if (dest.getDestType() != DestType.LEADER_MIND_LEVEL_A) {
				continue;
			}
			
			LeaderMindLevelADest tdesc = (LeaderMindLevelADest) dest;
			if (mindLevel >= tdesc.getNeedMindLevel()) {
				task.increaseOne(DestType.LEADER_MIND_LEVEL_A, dest.getInstKey());
			}
		}
	}
	
	public void onUpdateMindSkillLevel(Human human, int mindSkillLevel) {
		for (AbstractTaskManager atm : getManagerList()) {
			List<AbstractTask> taskList = atm.getDoingTaskList();
			for (AbstractTask task : taskList) {
				onUpdateMindSkillLevel(task, mindSkillLevel);
			}
		}
	}
	
	private void onUpdateMindSkillLevel(AbstractTask task, int mindSkillLevel) {
		List<IQuestDestination> dests = task.getTemplate().getQuestDestList();
		for (IQuestDestination dest : dests) {
			if (dest.getDestType() != DestType.LEADER_MIND_A_LEVEL_X) {
				continue;
			}
			
			LeaderMindALevelXDest tdesc = (LeaderMindALevelXDest) dest;
			if (mindSkillLevel >= tdesc.getNeedLevel()) {
				task.increaseOne(DestType.LEADER_MIND_A_LEVEL_X, dest.getInstKey());
			}
		}
	}
	
	public void onEmbedSkillEffect(Human human, int color, int level) {
		for (AbstractTaskManager atm : getManagerList()) {
			List<AbstractTask> taskList = atm.getDoingTaskList();
			for (AbstractTask task : taskList) {
				onEmbedSkillEffect(task, color, level);
			}
		}
	}
	
	private void onEmbedSkillEffect(AbstractTask task, int color, int level) {
		List<IQuestDestination> dests = task.getTemplate().getQuestDestList();
		for (IQuestDestination dest : dests) {
			if (dest.getDestType() != DestType.SKILL_EFFECT_EMBED_NUM_X_COLOR_Y_LEVEL_Z) {
				continue;
			}
			
			SkillEffectEmbedDest tdesc = (SkillEffectEmbedDest) dest;
			if (color >= tdesc.getColor() && level >= tdesc.getLevel()) {
				task.increaseOne(DestType.SKILL_EFFECT_EMBED_NUM_X_COLOR_Y_LEVEL_Z, dest.getInstKey());
			}
		}
	}
	
	public void onEquipUpdate(Human human, int color, int grade) {
		for (AbstractTaskManager atm : getManagerList()) {
			List<AbstractTask> taskList = atm.getDoingTaskList();
			for (AbstractTask task : taskList) {
				onEquipUpdate(task, color, grade);
			}
		}
	}
	
	private void onEquipUpdate(AbstractTask task, int color, int grade) {
		List<IQuestDestination> dests = task.getTemplate().getQuestDestList();
		for (IQuestDestination dest : dests) {
			if (dest.getDestType() != DestType.EQUIP_NUM_X_COLOR_Y_GRADE_Z) {
				continue;
			}
			
			EquipDest tdesc = (EquipDest) dest;
			if (color >= tdesc.getColor() && grade >= tdesc.getGrade()) {
				task.increaseOne(DestType.EQUIP_NUM_X_COLOR_Y_GRADE_Z, dest.getInstKey());
			}
		}
	}
	
	public void onEquipStarUpdate(Human human, int star) {
		for (AbstractTaskManager atm : getManagerList()) {
			List<AbstractTask> taskList = atm.getDoingTaskList();
			for (AbstractTask task : taskList) {
				onEquipStarUpdate(task, star);
			}
		}
	}
	
	private void onEquipStarUpdate(AbstractTask task, int star) {
		List<IQuestDestination> dests = task.getTemplate().getQuestDestList();
		for (IQuestDestination dest : dests) {
			if (dest.getDestType() != DestType.EQUIPSTAR_NUM_X_STAR_Y) {
				continue;
			}
			
			EquipStarDest tdesc = (EquipStarDest) dest;
			if (star >= tdesc.getStar()) {
				task.increaseOne(DestType.EQUIPSTAR_NUM_X_STAR_Y, dest.getInstKey());
			}
		}
	}
	
	public void onEquipGemUpdate(Human human, int level) {
		for (AbstractTaskManager atm : getManagerList()) {
			List<AbstractTask> taskList = atm.getDoingTaskList();
			for (AbstractTask task : taskList) {
				onEquipGemUpdate(task, level);
			}
		}
	}
	
	private void onEquipGemUpdate(AbstractTask task, int level) {
		List<IQuestDestination> dests = task.getTemplate().getQuestDestList();
		for (IQuestDestination dest : dests) {
			if (dest.getDestType() != DestType.EQUIP_GEM_NUM_X_LEVEL_Y) {
				continue;
			}
			
			EquipGemDest tdesc = (EquipGemDest) dest;
			if (level >= tdesc.getLevel()) {
				task.increaseOne(DestType.EQUIP_GEM_NUM_X_LEVEL_Y, dest.getInstKey());
			}
		}
	}
}
