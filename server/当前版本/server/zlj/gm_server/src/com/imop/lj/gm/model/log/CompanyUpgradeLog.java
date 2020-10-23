package com.imop.lj.gm.model.log;

import java.util.List;

public class CompanyUpgradeLog extends BaseLog {
	 private int from_level;
     private int to_level;
     private int branch_num_limit;


	public int getFrom_level() {
		return from_level;
	}


	public void setFrom_level(int from_level) {
		this.from_level = from_level;
	}


	public int getTo_level() {
		return to_level;
	}


	public void setTo_level(int to_level) {
		this.to_level = to_level;
	}


	public int getBranch_num_limit() {
		return branch_num_limit;
	}


	public void setBranch_num_limit(int branch_num_limit) {
		this.branch_num_limit = branch_num_limit;
	}


	@SuppressWarnings("unchecked")
	@Override
	public List toList() {
		List list = super.toList();
		list.add(from_level);
		list.add(to_level);
		list.add(branch_num_limit);


		return list;
	}

}