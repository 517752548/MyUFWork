package com.imop.lj.gameserver.task.dest;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.TaskDef.DestType;

public class EquipStarDest extends AbstractQuestDestination {
	private int num;
	private int star;
	
	public EquipStarDest(int questId, int num, int star) {
		super(questId);
		this.num = num;
		this.star = star;
	}

	@Override
	public DestType getDestType() {
		return DestType.EQUIPSTAR_NUM_X_STAR_Y;
	}

	@Override
	public int getRequiredNum() {
		return 1;
	}

	@Override
	public Object getInstKey() {
		return "EQUIPSTAR_NUM_" + this.num + "_STAR_"+ this.star;
	}

	@SuppressWarnings("rawtypes")
	@Override
	public boolean evaluate(AbstractTask task) {
		if (!(task.getOwner() instanceof Human)) {
			return false;
		}
		
		Human human = (Human)task.getOwner();
		
		int count = 0;
		human.getPetManager().getLeader().getEquipStars();
		for (Integer star : human.getPetManager().getLeader().getEquipStars().values()) {
			if (star >= getStar()) {
				count++;
			}
		}
		
		if (count >= getNum()) {
			return true;
		} else {
			return false;
		}
		
	}

	public int getNum() {
		return num;
	}

	public int getStar() {
		return star;
	}

	/**
	 * 验证参数是否正确
	 */
	public static void check(int num, int star) throws TemplateConfigException{
		if (num <= 0) {
			throw new TemplateConfigException("任务表", 0, "装备位升星 数量不能小于或等于0");
		}
		if (star <= 0) {
			throw new TemplateConfigException("任务表", 0, "装备位升星 星数不能小于或等于0");
		}
		
	}
}
