package com.imop.lj.gameserver.battle.core;

import com.imop.lj.gameserver.battle.report.IReportRecord;

/**
 * 行动对象接口
 * 
 * @author yuanbo.gao
 * 
 */
public interface IAction {
	/** 初始化行动对象 */
	public void initialize(IRound paramIRound, IFightConfig paramFightConfig);

	/** 执行 */
	public void execute();

	/** 获得上下文对象 */
	public Context getContext();

	/** 获得report对象 */
	public IReportRecord getReportRecord();
	
	public int getActionTime();
	
	public void addActionTime(int add);
	
	public int getActionTimeMin();
	
	public void addActionTimeMin(int add);
}
