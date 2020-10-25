package com.imop.lj.gm.autolog.model;
import java.util.List;
import com.imop.lj.gm.model.log.BaseLog;
/**
 * This is an auto generated source,please don't modify it.
 */
 
public class ItemCostRecordLog extends BaseLog{

	//原始免费的个数
    private long originalFreeNum;
	//原始道具个数
    private long originalItemNum;
	//原始物品总价值
    private long originalTotalCost;
	//原始实际花费金钱
    private long originalActualCost;
	//修改后免费的个数
    private long freeNum;
	//修改后道具个数
    private long itemNum;
	//修改后物品总价值
    private long totalCost;
	//修改后实际花费金钱
    private long actualCost;

	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(originalFreeNum);
		list.add(originalItemNum);
		list.add(originalTotalCost);
		list.add(originalActualCost);
		list.add(freeNum);
		list.add(itemNum);
		list.add(totalCost);
		list.add(actualCost);
		return list;
	}
	
	public long getOriginalFreeNum() {
		return originalFreeNum;
	}
	public long getOriginalItemNum() {
		return originalItemNum;
	}
	public long getOriginalTotalCost() {
		return originalTotalCost;
	}
	public long getOriginalActualCost() {
		return originalActualCost;
	}
	public long getFreeNum() {
		return freeNum;
	}
	public long getItemNum() {
		return itemNum;
	}
	public long getTotalCost() {
		return totalCost;
	}
	public long getActualCost() {
		return actualCost;
	}
        
	public void setOriginalFreeNum(long originalFreeNum) {
		this.originalFreeNum = originalFreeNum;
	}
	public void setOriginalItemNum(long originalItemNum) {
		this.originalItemNum = originalItemNum;
	}
	public void setOriginalTotalCost(long originalTotalCost) {
		this.originalTotalCost = originalTotalCost;
	}
	public void setOriginalActualCost(long originalActualCost) {
		this.originalActualCost = originalActualCost;
	}
	public void setFreeNum(long freeNum) {
		this.freeNum = freeNum;
	}
	public void setItemNum(long itemNum) {
		this.itemNum = itemNum;
	}
	public void setTotalCost(long totalCost) {
		this.totalCost = totalCost;
	}
	public void setActualCost(long actualCost) {
		this.actualCost = actualCost;
	}

}