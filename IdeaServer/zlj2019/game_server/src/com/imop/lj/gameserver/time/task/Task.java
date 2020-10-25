package com.imop.lj.gameserver.time.task;


import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

public abstract class Task implements Comparator<Task>{
	protected long exeTime;

	protected String name;

	protected long nextExeTime;

	public long getExeTime() {
		return exeTime;
	}

	public void setExeTime(long exeTime) {
		this.exeTime = exeTime;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public long getNextExeTime() {
		return nextExeTime;
	}

	public void setNextExeTime(long nextExeTime) {
		this.nextExeTime = nextExeTime;
	}

	public int compare(Task task0,Task task1){
		return (int)(task0.getExeTime() - task1.getExeTime());
	}

	public abstract void execute();

	public abstract Task getNextTask();

	@Override
	public String toString(){
		return "name=" + this.name
				+"exeTime=" + this.exeTime
				+"nextExeTime=" + this.nextExeTime
				;
	}

	public static void main(String[] args){
		List<String> aa = new ArrayList<String>(5);
		for(int i = 0 ; i < 10;i++){
			aa.add(i+ "");
		}

		System.out.println(aa);
	}
}
