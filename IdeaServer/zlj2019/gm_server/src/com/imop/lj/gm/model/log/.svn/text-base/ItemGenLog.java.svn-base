package com.imop.lj.gm.model.log;

import java.util.List;

/**
 * 物品产生日志
 * @author zhiyuan.luo
 *
 */
public class ItemGenLog extends BaseLog {
    private int templateId;
    private String itemName;
    private int count;
    private int bind;
    private long deadline;
    private String properties;
    private String itemGenId;



	public int getTemplateId() {
		return templateId;
	}



	public void setTemplateId(int templateId) {
		this.templateId = templateId;
	}



	public int getCount() {
		return count;
	}



	public void setCount(int count) {
		this.count = count;
	}



	public int getBind() {
		return bind;
	}



	public void setBind(int bind) {
		this.bind = bind;
	}



	public long getDeadline() {
		return deadline;
	}



	public void setDeadline(long deadline) {
		this.deadline = deadline;
	}



	public String getProperties() {
		return properties;
	}



	public void setProperties(String properties) {
		this.properties = properties;
	}



	public String getItemGenId() {
		return itemGenId;
	}



	public void setItemGenId(String itemGenId) {
		this.itemGenId = itemGenId;
	}





	public String getItemName() {
		return itemName;
	}



	public void setItemName(String itemName) {
		this.itemName = itemName;
	}



	@SuppressWarnings("unchecked")
	@Override
	public List toList() {
		List list = super.toList();
		list.add(templateId);
		list.add(itemName);
		list.add(count);
		list.add(itemGenId);
		return list;
	}
}