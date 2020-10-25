package com.imop.lj.gameserver.task.dest;

import java.util.Collection;
import java.util.List;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.gameserver.common.container.Bag.BagType;
import com.imop.lj.gameserver.equip.EquipHoleInfo;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.feature.EquipFeature;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.TaskDef.DestType;

public class EquipGemDest extends AbstractQuestDestination {
	private int num;
	private int level;
	
	public EquipGemDest(int questId, int num, int level) {
		super(questId);
		this.num = num;
		this.level = level;
	}

	@Override
	public DestType getDestType() {
		return DestType.EQUIP_GEM_NUM_X_LEVEL_Y;
	}

	@Override
	public int getRequiredNum() {
		return 1;
	}

	@Override
	public Object getInstKey() {
		return "EQUIP_GEM_NUM_" + this.num + "_LEVEL_"+ this.level;
	}

	@SuppressWarnings("rawtypes")
	@Override
	public boolean evaluate(AbstractTask task) {
		if (!(task.getOwner() instanceof Human)) {
			return false;
		}
		
		//只遍历穿着的装备
		int hadNum = 0;
		Human human = (Human)task.getOwner();
		Collection<Item> equipList = human.getInventory().getBagByType(BagType.PET_EQUIP, human.getPetManager().getLeader().getUUID()).getAll();
		for (Item item : equipList) {
			if (item != null && item.isEquipment() && (item.getFeature() instanceof EquipFeature)) {
				EquipFeature feature = (EquipFeature) item.getFeature();
				List<EquipHoleInfo> hList = feature.getHoleManager().getHoleList();
				for (EquipHoleInfo hInfo : hList) {
					if (hInfo.getGemItemId() > 0 && hInfo.getGemTpl() != null) {
						//等级满足要求就+1
						if (hInfo.getGemTpl().getGemLevel() >= getLevel()) {
							hadNum++;
							if (hadNum >= getNum()) {
								return true;
							}
						}
					}
				}
			}
		}
		
		return false;
	}

	public int getNum() {
		return num;
	}

	public int getLevel() {
		return level;
	}

	/**
	 * 验证参数是否正确
	 */
	public static void check(int num, int level) throws TemplateConfigException{
		if (num <= 0) {
			throw new TemplateConfigException("任务表", 0, "装备数量不能小于或等于0");
		}
	}
}
