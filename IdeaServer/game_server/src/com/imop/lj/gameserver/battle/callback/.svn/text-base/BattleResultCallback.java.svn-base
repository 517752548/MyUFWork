package com.imop.lj.gameserver.battle.callback;

import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.report.BattleReport;
import com.imop.lj.gameserver.battle.report.BattleReportAddition;

/**
 * 战斗结果回调
 * 可以继承此方法，加入各业务的处理逻辑
 *
 */
public abstract class BattleResultCallback {
	
	/** 战报附加信息对象，主要保存奖励、文字描述等战斗外的额外信息 */
	protected BattleReportAddition battleReportAddition;

	/**
	 * 获取战报附加信息对象
	 * @return
	 */
	public abstract BattleReportAddition getBattleReportAddition();
	
	/**
	 * 回调处理
	 * @param result
	 */
	public abstract void onResult(BattleReport battleReport);
	
	/**
	 * 是否需要保存战报
	 * @return
	 */
	public abstract boolean needSaveReport();
	
	/**
	 * 是否可以直接察看结果
	 * @return
	 */
	public abstract boolean canGotoResult();
	
	/**
	 * 是否发送战报
	 * @return
	 */
	public abstract boolean needSendReport();
	
	/**
	 * 战斗类型
	 * @return
	 */
	public abstract BattleType getType();
	
	/**
	 * 战斗背景图
	 * @return
	 */
	public abstract int getBattleBackground();
	
	/**
	 * 返回类型
	 * @return
	 */
	public abstract int getToBackType();
	
}
