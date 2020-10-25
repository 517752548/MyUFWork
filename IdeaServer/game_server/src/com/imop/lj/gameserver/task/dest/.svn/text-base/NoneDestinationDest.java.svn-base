package com.imop.lj.gameserver.task.dest;

import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.TaskDef.DestType;
import com.imop.lj.gameserver.task.TaskDef.NumRecordType;

/**
 * 直接完成不需要任何条件
 * 
 */
public class NoneDestinationDest extends AbstractQuestDestination {

	private NumRecordType type;

	public NoneDestinationDest(int questId, NumRecordType type) {
		super(questId);
		this.type = type;
	}

	@Override
	public DestType getDestType() {
		return DestType.NULL;
	}

	@Override
	public Object getInstKey() {
		return "NullDestinationDest";
	}

	@Override
	public int getRequiredNum() {
		return 0;
	}
	
	@SuppressWarnings("rawtypes")
	@Override
	public boolean evaluate(AbstractTask task) {
		return true;
	}
	
	public NumRecordType getType() {
		return type;
	}
}
