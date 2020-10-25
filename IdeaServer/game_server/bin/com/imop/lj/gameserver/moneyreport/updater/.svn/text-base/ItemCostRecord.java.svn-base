package com.imop.lj.gameserver.moneyreport.updater;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.ItemCostRecordEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.scene.CommonScene;

public class ItemCostRecord implements PersistanceObject<Long, ItemCostRecordEntity> {
	
	/** 主键 */
	private Long id;
	
	/**	玩家ID*/
	private long charId;
	
	/**	模版ID*/
	private int templateId;
	
	/**道具个数*/
	private int itemNum;
	
	/**物品总价*/
	private long totalCost;
	
	/**物品实际消耗*/
	private long actualCost;
	
	/**免费的个数*/
	private int freeNum;
	
	// 此实例是否在db中 
	private boolean isInDb;	
	
	//公共场景
	private CommonScene commonScene;
	 
	// 生命期 
	private final LifeCycle lifeCycle; 
	
	public ItemCostRecord() {
		this.commonScene = Globals.getSceneService().getCommonScene();
		lifeCycle = new LifeCycleImpl(this);
		lifeCycle.activate();
		setInDb(false);
	}

	@Override
	public void setDbId(Long id) {
		this.id = id;
	}

	@Override
	public Long getDbId() {
		return this.id;
	}

	@Override
	public String getGUID() {
		return "ItemCostRecord#"+this.id;
	}

	@Override
	public boolean isInDb() {
		return isInDb;
	}

	@Override
	public void setInDb(boolean inDb) {
		this.isInDb = inDb;
	}

	@Override
	public LifeCycle getLifeCycle() {
		return lifeCycle;
	}

	@Override
	public void setModified() {
		if (this.lifeCycle.isActive()) {
			commonScene.getCommonDataUpdater().addUpdate(lifeCycle);
		}
	}
	
	/**
	 * 实例被删除,触发删除机制
	 */
	protected void onDelete() {
		this.lifeCycle.destroy();
		this.commonScene.getCommonDataUpdater().addDelete(lifeCycle);
	}
	
	/**
	 * 删除奖励
	 */
	public void delete() {
		onDelete();
	}
	
	/***
	 * 激活属性
	 */
	public void active() {
		getLifeCycle().activate();
	}

	@Override
	public void fromEntity(ItemCostRecordEntity entity) {
		setId(entity.getId());
		setCharId(entity.getCharId());
		setTemplateId(entity.getTemplateId());
		setItemNum(entity.getItemNum());
		setTotalCost(entity.getTotalCost());
		setActualCost(entity.getActualCost());
		setFreeNum(entity.getFreeNum());
		setInDb(true);
	}

	@Override
	public ItemCostRecordEntity toEntity() {
		ItemCostRecordEntity entity = new ItemCostRecordEntity();
		entity.setId(getDbId());
		entity.setCharId(getCharId());
		entity.setTemplateId(getTemplateId());
		entity.setItemNum(getItemNum());
		entity.setTotalCost(getTotalCost());
		entity.setActualCost(getActualCost());
		entity.setFreeNum(getFreeNum());
		return entity;
	}
	
	
	@Override
	public long getCharId() {
		return this.charId;
	}


	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public int getTemplateId() {
		return templateId;
	}

	public void setTemplateId(int templateId) {
		this.templateId = templateId;
	}

	public int getItemNum() {
		return itemNum;
	}

	public void setItemNum(int itemNum) {
		this.itemNum = itemNum;
	}

	public long getTotalCost() {
		return totalCost;
	}

	public void setTotalCost(long totalCost) {
		this.totalCost = totalCost;
		this.setModified();
	}

	public long getActualCost() {
		return actualCost;
	}

	public void setActualCost(long actualCost) {
		this.actualCost = actualCost;
		this.setModified();
	}

	public int getFreeNum() {
		return freeNum;
	}

	public void setFreeNum(int freeNum) {
		this.freeNum = freeNum;
		this.setModified();
	}

	public CommonScene getCommonScene() {
		return commonScene;
	}

	public void setCommonScene(CommonScene commonScene) {
		this.commonScene = commonScene;
	}

	public void setCharId(long charId) {
		this.charId = charId;
	}

	@Override
	public String toString() {
		return "ItemCostRecord [id=" + id + ", charId=" + charId + ", templateId=" + templateId + ", itemNum=" + itemNum + ", totalCost=" + totalCost
				+ ", actualCost=" + actualCost + ", freeNum=" + freeNum + "]";
	}
}
