package com.imop.lj.gm.autolog.model;
import java.util.List;
import com.imop.lj.gm.model.log.BaseLog;
/**
 * This is an auto generated source,please don't modify it.
 */
 
public class ItemLog extends BaseLog{

	//包裹id
    private int bagId;
	//在包裹中的位置索引
    private int bagIndex;
	//道具模板ID
    private int templateId;
	//道具实例ID
    private String instUUID;
	//变化值
    private int delta;
	//操作后的最终叠加数
    private int resultCount;
	//道具产生ID：对应ItemGenLog
    private String itemGenId;
	//道具大字段信息，用于在删除贵重道具时将道具二进制信息备份
    private byte[] itemData;

	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(bagId);
		list.add(bagIndex);
		list.add(templateId);
		list.add(instUUID);
		list.add(delta);
		list.add(resultCount);
		list.add(itemGenId);
		list.add(itemData);
		return list;
	}
	
	public int getBagId() {
		return bagId;
	}
	public int getBagIndex() {
		return bagIndex;
	}
	public int getTemplateId() {
		return templateId;
	}
	public String getInstUUID() {
		return instUUID;
	}
	public int getDelta() {
		return delta;
	}
	public int getResultCount() {
		return resultCount;
	}
	public String getItemGenId() {
		return itemGenId;
	}
	public byte[] getItemData() {
		return itemData;
	}
        
	public void setBagId(int bagId) {
		this.bagId = bagId;
	}
	public void setBagIndex(int bagIndex) {
		this.bagIndex = bagIndex;
	}
	public void setTemplateId(int templateId) {
		this.templateId = templateId;
	}
	public void setInstUUID(String instUUID) {
		this.instUUID = instUUID;
	}
	public void setDelta(int delta) {
		this.delta = delta;
	}
	public void setResultCount(int resultCount) {
		this.resultCount = resultCount;
	}
	public void setItemGenId(String itemGenId) {
		this.itemGenId = itemGenId;
	}
	public void setItemData(byte[] itemData) {
		this.itemData = itemData;
	}

}