package com.imop.lj.gm.model.log;

import java.util.List;

public class RelationLog extends BaseLog {
//	relation_type
//	target_char_id
//	target_char_name
	private int relation_type;
	private long target_char_id;
	private String target_char_name;
	public int getRelation_type() {
		return relation_type;
	}
	public void setRelation_type(int relation_type) {
		this.relation_type = relation_type;
	}
	public long getTarget_char_id() {
		return target_char_id;
	}
	public void setTarget_char_id(long target_char_id) {
		this.target_char_id = target_char_id;
	}
	public String getTarget_char_name() {
		return target_char_name;
	}
	public void setTarget_char_name(String target_char_name) {
		this.target_char_name = target_char_name;
	}
	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(this.relation_type);
		list.add(this.target_char_id);
		list.add(this.target_char_name);
		return list;
	}
//	relation_type
//	target_char_id
//	target_char_name
}
