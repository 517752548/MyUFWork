package com.imop.lj.gm.model.log;

import java.util.List;

public class DropItemLog extends BaseLog {
	private int from_reason;
	private int drop_id;
	private int template_id;
	private String item_name;
	private String from_detail_reason;
	public String getItem_name() {
		return item_name;
	}
	public void setItem_name(String item_name) {
		this.item_name = item_name;
	}
	public String getFrom_detail_reason() {
		return from_detail_reason;
	}
	public void setFrom_detail_reason(String from_detail_reason) {
		this.from_detail_reason = from_detail_reason;
	}
	public int getFrom_reason() {
		return from_reason;
	}
	public void setFrom_reason(int from_reason) {
		this.from_reason = from_reason;
	}
	public int getDrop_id() {
		return drop_id;
	}
	public void setDrop_id(int drop_id) {
		this.drop_id = drop_id;
	}
	public int getTemplate_id() {
		return template_id;
	}
	public void setTemplate_id(int template_id) {
		this.template_id = template_id;
	}
	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(this.from_reason);
		list.add(this.drop_id);
		list.add(this.template_id);
		list.add(this.item_name);
		list.add(this.from_detail_reason);
		return list;
	}
//	from_reason
//	drop_id
//	template_id
//	item_name
//	from_detail_reason
}
