package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 伙伴配置表
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetFriendTemplateVO extends TemplateObject {

	/** 是否需要解锁，0免费，1需要解锁 */
	@ExcelCellBinding(offset = 1)
	protected int needUnlock;

	/** 解锁方式花费列表 */
	@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "2;3;4")
	protected List<Integer> unlockCostList;


	public int getNeedUnlock() {
		return this.needUnlock;
	}

	public void setNeedUnlock(int needUnlock) {
		if (needUnlock > 1 || needUnlock < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[是否需要解锁，0免费，1需要解锁]needUnlock的值不合法，应为0至1之间");
		}
		this.needUnlock = needUnlock;
	}
	
	public List<Integer> getUnlockCostList() {
		return this.unlockCostList;
	}

	public void setUnlockCostList(List<Integer> unlockCostList) {
		if (unlockCostList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[解锁方式花费列表]unlockCostList不可以为空");
		}	
		this.unlockCostList = unlockCostList;
	}
	

	@Override
	public String toString() {
		return "PetFriendTemplateVO[needUnlock=" + needUnlock + ",unlockCostList=" + unlockCostList + ",]";

	}
}