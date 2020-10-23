package com.imop.lj.logserver.droptable;

import java.util.TimerTask;

import com.imop.lj.logserver.createtable.ITableCreator;

public class DropTableTask extends TimerTask {
	private ITableCreator tableCreator;
	
	public DropTableTask(ITableCreator tableCreator){
		this.tableCreator = tableCreator;
	}
	
	@Override
	public void run() {
		tableCreator.dropTable();
	}

}
