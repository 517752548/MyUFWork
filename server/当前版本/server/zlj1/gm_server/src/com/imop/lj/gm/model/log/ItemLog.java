package com.imop.lj.gm.model.log;

import java.util.List;

public class ItemLog extends BaseLog {
    private int bagId;
    private int bagIndex;
    private int templateId;
    private String instUUID;
    private int delta;
    private int resultCount;
    private String itemGenId;
    private byte[] itemData;



	public int getBagId() {
		return bagId;
	}



	public void setBagId(int bagId) {
		this.bagId = bagId;
	}



	public int getBagIndex() {
		return bagIndex;
	}



	public void setBagIndex(int bagIndex) {
		this.bagIndex = bagIndex;
	}



	public int getTemplateId() {
		return templateId;
	}



	public void setTemplateId(int templateId) {
		this.templateId = templateId;
	}



	public String getInstUUID() {
		return instUUID;
	}



	public void setInstUUID(String instUUID) {
		this.instUUID = instUUID;
	}



	public int getDelta() {
		return delta;
	}



	public void setDelta(int delta) {
		this.delta = delta;
	}



	public int getResultCount() {
		return resultCount;
	}



	public void setResultCount(int resultCount) {
		this.resultCount = resultCount;
	}



	public String getItemGenId() {
		return itemGenId;
	}



	public void setItemGenId(String itemGenId) {
		this.itemGenId = itemGenId;
	}



	public byte[] getItemData() {
		return itemData;
	}



	public void setItemData(byte[] itemData) {
		this.itemData = itemData;
	}



	@SuppressWarnings("unchecked")
	@Override
	public List toList() {
		List list = super.toList();
		list.add(bagId);
		list.add(bagIndex);
		list.add(templateId);
		list.add(instUUID);
		list.add(delta);
		list.add(resultCount);
		list.add(itemGenId);
		return list;
	}

}