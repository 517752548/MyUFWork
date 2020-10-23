package com.imop.lj.gm.autolog.model;
import java.util.List;
import com.imop.lj.gm.model.log.BaseLog;
/**
 * This is an auto generated source,please don't modify it.
 */
 
public class TaskLog extends BaseLog{

	//任务id
    private int task_id;

	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(task_id);
		return list;
	}
	
	public int getTask_id() {
		return task_id;
	}
        
	public void setTask_id(int task_id) {
		this.task_id = task_id;
	}

}