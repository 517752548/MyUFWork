package com.imop.lj.gameserver.task.dest;

import java.util.Collection;

import com.imop.lj.common.LogReasons.ItemGenLogReason;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.TaskDef.DestType;
import com.imop.lj.gameserver.task.TaskDef.NumRecordType;

/**
 * 记数类目标
 * 
 */
public class NumRecordDest extends AbstractQuestDestination implements IMeetFixedMapMonsterDest{
	private NumRecordType type;
	private int targetId;
	private int requiredNum;
	
	private int mapId;
	private int meetMonsterPlanId;

	public NumRecordDest(int questId, NumRecordType type, int targetId, int num, int mapId, int meetMonsterPlanId) {
		super(questId);
		this.type = type;
		this.targetId = targetId;
		this.requiredNum = num;
		
		this.mapId = mapId;
		this.meetMonsterPlanId = meetMonsterPlanId;
	}
	
	/**
	 * 2014-05-19 环任务需求，完成次数重新生成，增加
	 * @param finishNum
	 */
	public void rebuildFinishNum(int finishNum) {
		this.requiredNum = finishNum;
	}

	@Override
	public DestType getDestType() {
		return DestType.NUM_RECORD;
	}

	@Override
	public int getRequiredNum() {
		return requiredNum;
	}
	
	@Override
	public Object getInstKey() {
		return "NUM_RECORD_" + this.type + "_TARGETID_" + this.targetId;
	}
	
	@SuppressWarnings("rawtypes")
	@Override
	public boolean evaluate(AbstractTask task) {
		int count = 0;
		count = task.getCount(getDestType(), getInstKey());
		
		if (count >= getRequiredNum()) {
			return true;
		} else {
			return false;
		}
	}

	public NumRecordType getType() {
		return type;
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
	public boolean init(AbstractTask task) {
		if (task != null && task.getOwnerHuman() != null && 
				getType() == NumRecordType.MAP_USE_ITEM) {
			int itemId = getTargetId();
			int itemNum = getRequiredNum();
			
			//XXX 这里不再判断给道具失败，因为如果背包满了会发邮件，所以就认为成功了
			Collection<Item> bagRet = task.getOwnerHuman().getInventory().addItem(itemId, itemNum, ItemGenLogReason.QUEST_ACCEPT_GIVE_ITEM, 
					LogUtils.genReasonText(ItemGenLogReason.QUEST_ACCEPT_GIVE_ITEM, getQuestId()), true, false);
			if (bagRet == null || bagRet.isEmpty()) {
				task.getOwnerHuman().sendErrorMessage(LangConstants.BAG_FULL_ITEM_SEND_MAIL_CONTENT);
			}
			return true;
		}
		return true;
	}
	
	@SuppressWarnings("rawtypes")
	@Override
	public boolean onFinishTask(AbstractTask task) {
		//收集物品的任务目标，需要扣除道具
		if (task != null && task.getOwnerHuman() != null && 
				getType() == NumRecordType.MAP_COLLECTION) {
			int itemId = getTargetId();
			int itemNum = getRequiredNum();
			
			//扣道具
			Collection<Item> res = task.getOwnerHuman().getInventory().removeItem(itemId, itemNum, 
					ItemLogReason.QUEST_FINISH_REMOVE_ITEM, 
					LogUtils.genReasonText(ItemLogReason.QUEST_FINISH_REMOVE_ITEM, getQuestId()), true);
			if (res == null || res.isEmpty()) {
				Loggers.questLogger.error("finish collection quest but remove item failed!humanId=" + 
						task.getOwnerHuman().getUUID() + ";questId=" + getQuestId());
				return false;
			}
			return true;
		}
		return true;
	}
}
