package com.imop.lj.gameserver.item;

import java.util.Map;
import java.util.Set;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.equip.template.CraftEquipMaterialTemplate;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;

/**
 * 检查玩家是否有可打造装备
 *
 */
public class CraftEquipNoticeChecker {

//	/** 检查道具是否过期的时间间隔，5分钟 */
//	private static final long CHECK_EXPIRED_SPAN = 5 * TimeUtils.MIN;
//	private boolean isCanceled;
	private Human owner;
	
	private boolean canCraft;

	public CraftEquipNoticeChecker(Human owner) {
		this.owner = owner;
	}

//	@Override
//	public void run() {
//		if (isCanceled) {
//			return;
//		}
//		
//		checkCanCraft();
//	}

	public void checkCanCraft() {
		if (owner == null || owner.getInventory() == null || owner.getInventory().getPrimBag() == null) {
			return;
		}
		
		boolean old = canCraft;
		Set<Integer> equipIdSet = Globals.getTemplateCacheService().getCraftTemplateCache().getCraftEquipIdSet(owner.getSex(), owner.getJobType(), owner.getLevel());
		if (equipIdSet == null || equipIdSet.isEmpty()) {
			return;
		}

		boolean flag = true;
		for (Integer equipId : equipIdSet) {
			Map<Integer, CraftEquipMaterialTemplate> materialMap = Globals.getTemplateCacheService().getCraftTemplateCache().getEquipMaterialMap().get(equipId);
			if (materialMap != null && !materialMap.isEmpty()) {
				for (CraftEquipMaterialTemplate mTpl : materialMap.values()) {
					flag &= owner.getInventory().hasItemByTmplId(mTpl.getMaterialID(), mTpl.getMaterialNum());
					if (!flag) {
						break;
					}
				}
			}
			//某一件装备的材料全够，则跳出循环
			if (flag) {
				break;
			}
		}
		
		canCraft = flag;
		if (old != canCraft) {
			//通知玩家打造功能变化
			Globals.getFuncService().onFuncChanged(owner, FuncTypeEnum.CRAFT);
		}
	}

//	@Override
//	public long getRunTimeSpan() {
//		return CHECK_EXPIRED_SPAN;
//	}
//
//	@Override
//	public void cancel() {
//		isCanceled = true;
//	}

	public boolean isCanCraft() {
		return canCraft;
	}

	public void setCanCraft(boolean canCraft) {
		this.canCraft = canCraft;
	}

}
