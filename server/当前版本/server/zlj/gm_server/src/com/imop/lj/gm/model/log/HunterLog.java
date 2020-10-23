package com.imop.lj.gm.model.log;

import java.util.List;

public class HunterLog extends BaseLog {
//	hunter_index
//	is_open
//	is_vip
	private int hunter_index;
	private int is_open;
	private int is_vip;
	public int getHunter_index() {
		return hunter_index;
	}
	public void setHunter_index(int hunter_index) {
		this.hunter_index = hunter_index;
	}
	public int getIs_open() {
		return is_open;
	}
	public void setIs_open(int is_open) {
		this.is_open = is_open;
	}
	public int getIs_vip() {
		return is_vip;
	}
	public void setIs_vip(int is_vip) {
		this.is_vip = is_vip;
	}
	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(this.hunter_index);
		list.add(this.is_open);
		list.add(this.is_vip);
		return list;
	}
}
