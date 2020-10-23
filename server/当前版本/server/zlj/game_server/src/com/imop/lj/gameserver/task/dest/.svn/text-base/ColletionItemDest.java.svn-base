package com.imop.lj.gameserver.task.dest;

import java.util.Collection;

import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.TaskDef.DestType;

/**
 * 收集A道具B个，完成任务时扣除
 * 
 */
public class ColletionItemDest extends AbstractQuestDestination implements IMeetFixedMapMonsterDest{
	private int targetId;
	private int requiredNum;
	
	private int mapId;
	private int meetMonsterPlanId;

	public ColletionItemDest(int questId, int targetId, int num, int mapId, int meetMonsterPlanId) {
		super(questId);
		this.targetId = targetId;
		this.requiredNum = num;
		
		this.mapId = mapId;
		this.meetMonsterPlanId = meetMonsterPlanId;
	}
	
	@Override
	public DestType getDestType() {
		return DestType.COLLECTION_ITEM;
	}

	@Override
	public int getRequiredNum() {
		return requiredNum;
	}
	
	@Override
	public Object getInstKey() {
		return "COLLECTION_ITEM_" + "_TARGETID_" + this.targetId;
	}
	
	@SuppressWarnings("rawtypes")
	@Override
	public boolean evaluate(AbstractTask task) {
		boolean hasFlag = false;
		if (task.getOwnerHuman() != null) {
			//玩家背包中是否有足够的道具
			Human human = task.getOwnerHuman();
			hasFlag = human.getInventory().hasItemByTmplId(getTargetId(), getRequiredNum());
		}
		return hasFlag;
	}

	public int getTargetId() {
		return targetId;
	}
	
	@Override
	public int getMapId() {
		return this.mapId;
	}
	
	@Override
	public int getMeetMonsterPlanId() {
		return meetMonsterPlanId;
	}
	
	@SuppressWarnings("rawtypes")
	@Override
	public boolean onFinishTask(AbstractTask task) {
		//收集物品的任务目标，需要扣除道具
		if (task != null && task.getOwnerHuman() != null) {
			//扣道具
			Collection<Item> res = task.getOwnerHuman().getInventory().removeItem(getTargetId(), getRequiredNum(), 
					ItemLogReason.QUEST_FINISH_REMOVE_ITEM, 
					LogUtils.genReasonText(ItemLogReason.QUEST_FINISH_REMOVE_ITEM, getQuestId()), true);
			if (res == null || res.isEmpty()) {
				Loggers.questLogger.error("#ColletionItemDest#finish collection quest but remove item failed!humanId=" + 
						task.getOwnerHuman().getUUID() + ";questId=" + getQuestId());
				//提示玩家任务道具不足
				task.getOwnerHuman().sendErrorMessage(LangConstants.QUEST_CAN_NOT_FINISH_NO_ITEM);
				return false;
			}
			return true;
		}
		return true;
	}

	@Override
	public boolean canStatusBack() {
		return true;
	}
	
	@SuppressWarnings("rawtypes")
	@Override
	public int getGotNum(AbstractTask task) {
		int num = 0;
		if (task.getOwnerHuman() != null) {
			//玩家背包中是否有足够的道具
			Human human = task.getOwnerHuman();
			num = human.getInventory().getItemCountByTmplId(getTargetId());
			if (num > getRequiredNum()) {
				//计数最大为需求数量
				num = getRequiredNum();
			}
		}
		return num;
	}
}
