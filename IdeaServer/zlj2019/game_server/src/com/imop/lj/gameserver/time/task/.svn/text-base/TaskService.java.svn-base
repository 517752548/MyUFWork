package com.imop.lj.gameserver.time.task;

import java.util.ArrayList;
import java.util.List;

public class TaskService {
	private List<Task> taskList;
	/** 场景心跳 */
	private TaskThread taskScheduler;

	public TaskService(){
		taskList = new ArrayList<Task>();
	}

	public void init(){

	}

	public List<Task> getTaskList() {
		return taskList;
	}

	public boolean addTask(Task task){
		//TODO 排序
		return taskList.add(task);
	}

	public void start(){
		taskScheduler = new TaskThread();
		taskScheduler.start();
	}
}
