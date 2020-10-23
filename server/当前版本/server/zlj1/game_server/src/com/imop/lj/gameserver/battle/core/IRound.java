package com.imop.lj.gameserver.battle.core;

import com.imop.lj.gameserver.battle.core.BattleDef.RoundStatus;
import com.imop.lj.gameserver.battle.report.IReportRecord;

/**
 * 回合接口
 * 
 * @author yuanbo.gao
 * 
 */
public interface IRound {
	/** 初始化回合对象 */
	public void initialize(IBattle paramIBattle, IFightConfig paramFightConfig);
	
	/** 回合开始 */
	public void start();

	/** 获得当前行动对象 */
	public IAction getCurrent();

	/** 是否在回合中 */
	public boolean inProgress();

	/** 返回回合状态 */
	public RoundStatus getStatus();

	/** 下一个行动 */
	public void next();

	/** 返回战斗上下文对象 */
	public Context getContext();

	/** 返回report对象 */
	public IReportRecord getReportRecord();
	
	/**返回每回合最大行动数*/
	int getMaxAction();
	
	/** 获取轮数 */
	int getRound();
	
	public int getPerformTime();

	public void addPerformTime(int time);
	
	public IBattle getBattle();
	
	public void removeFightUnitFromSequence(FightUnit fu);
//	public void onEscape(SideType who);
	
//	/** 获取进攻或防御方坐骑 */
//	FightUnit getHorse(boolean isAttacker);
}
