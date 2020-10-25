package com.imop.lj.gm.model.log;

import java.util.List;

public class SecretaryLog extends BaseLog {
	private long sec_id;
    private int sec_level;
    private int count_delta;
    private int count_result;





	public long getSec_id() {
		return sec_id;
	}





	public void setSec_id(long sec_id) {
		this.sec_id = sec_id;
	}





	public int getSec_level() {
		return sec_level;
	}





	public void setSec_level(int sec_level) {
		this.sec_level = sec_level;
	}





	public int getCount_delta() {
		return count_delta;
	}





	public void setCount_delta(int count_delta) {
		this.count_delta = count_delta;
	}





	public int getCount_result() {
		return count_result;
	}





	public void setCount_result(int count_result) {
		this.count_result = count_result;
	}





	@SuppressWarnings("unchecked")
	@Override
	public List toList() {
		List list = super.toList();
		list.add(sec_id);
		list.add(sec_level);
		list.add(count_delta);
		list.add(count_result);

		return list;
	}

}