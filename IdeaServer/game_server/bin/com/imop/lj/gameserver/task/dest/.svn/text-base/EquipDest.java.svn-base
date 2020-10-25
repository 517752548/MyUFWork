package com.imop.lj.gameserver.task.dest;

import java.util.List;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.feature.EquipFeature;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.TaskDef.DestType;

public class EquipDest extends AbstractQuestDestination {
	private int num;
	private int color;
	private int grade;
	
	public EquipDest(int questId, int num, int color, int grade) {
		super(questId);
		this.num = num;
		this.color = color;
		this.grade = grade;
	}

	@Override
	public DestType getDestType() {
		return DestType.EQUIP_NUM_X_COLOR_Y_GRADE_Z;
	}

	@Override
	public int getRequiredNum() {
		return 1;
	}

	@Override
	public Object getInstKey() {
		return "EQUIP_NUM_" + this.num + "_COLOR_"+ this.color +"_GRADE_" + this.grade;
	}

	@SuppressWarnings("rawtypes")
	@Override
	public boolean evaluate(AbstractTask task) {
		if (!(task.getOwner() instanceof Human)) {
			return false;
		}
		
		int hadNum = 0;
		Human human = (Human)task.getOwner();
		List<Item> equipList = human.getInventory().getBagByPet(human.getPetManager().getLeader().getUUID()).getAllEquips();
		
		for (Item item : equipList) {
			if (item.getFeature() instanceof EquipFeature) {
				EquipFeature feature = (EquipFeature) item.getFeature();
				//颜色和阶数满足要求就+1
				if (feature.getColor().getIndex() >= getColor() &&
						feature.getGrade().getIndex() >= getGrade()) {
					hadNum++;
					if (hadNum >= getNum()) {
						return true;
					}
				}
			}
		}
		
		return false;
	}

	public int getNum() {
		return num;
	}

	public int getColor() {
		return color;
	}

	public int getGrade() {
		return grade;
	}

	/**
	 * 验证参数是否正确
	 */
	public static void check(int num, int color, int grade) throws TemplateConfigException{
		if (num <= 0) {
			throw new TemplateConfigException("任务表", grade, "装备数量不能小于或等于0");
		}
	}
}
