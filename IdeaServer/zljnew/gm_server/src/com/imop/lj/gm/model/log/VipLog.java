package com.imop.lj.gm.model.log;

import java.util.List;

public class VipLog extends BaseLog {
//	old_vip_level
//	new_vip_level
//	charge
//	old_total_charge
//	new_total_charge
	private int old_vip_level;
	private int new_vip_level;
	private int charge;
	private int old_total_charge;
	private int new_total_charge;
	public int getOld_vip_level() {
		return old_vip_level;
	}
	public void setOld_vip_level(int old_vip_level) {
		this.old_vip_level = old_vip_level;
	}
	public int getNew_vip_level() {
		return new_vip_level;
	}
	public void setNew_vip_level(int new_vip_level) {
		this.new_vip_level = new_vip_level;
	}
	public int getCharge() {
		return charge;
	}
	public void setCharge(int charge) {
		this.charge = charge;
	}
	public int getOld_total_charge() {
		return old_total_charge;
	}
	public void setOld_total_charge(int old_total_charge) {
		this.old_total_charge = old_total_charge;
	}
	public int getNew_total_charge() {
		return new_total_charge;
	}
	public void setNew_total_charge(int new_total_charge) {
		this.new_total_charge = new_total_charge;
	}
	@SuppressWarnings("unchecked")
	@Override
	public List toList() {
		List list = super.toList();
		list.add(this.old_vip_level);
		list.add(this.new_vip_level);
		list.add(this.charge);
		list.add(this.old_total_charge);
		list.add(this.new_total_charge);
		return list;
	}
//	old_vip_level
//	new_vip_level
//	charge
//	old_total_charge
//	new_total_charge
}
