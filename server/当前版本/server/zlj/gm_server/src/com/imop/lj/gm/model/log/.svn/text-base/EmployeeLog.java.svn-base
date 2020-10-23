package com.imop.lj.gm.model.log;

import java.util.List;

public class EmployeeLog extends BaseLog {
	 private long employee_id;
     private int count_delta;
     private int count_result;

	public long getEmployee_id() {
		return employee_id;
	}

	public void setEmployee_id(long employee_id) {
		this.employee_id = employee_id;
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
		list.add(employee_id);
		list.add(count_delta);
		list.add(count_result);


		return list;
	}

}