package com.imop.lj.gameserver.localscribe;

import java.text.MessageFormat;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.gameserver.common.Globals;

/**
 * 更新场景操作
 * 
 */
public class LocalScribedAllLeftBondOperation implements IIoOperation {
	
	private long leftBond;
	
	private long leftItemBond;
	
	private long eternalCostMoney;
	/**
	 * 类参数构造器
	 * 
	 * @param sceneObj
	 */
	public LocalScribedAllLeftBondOperation() {
		
	}

	@Override
	public int doIo() {
		long start=Globals.getTimeService().now();
		leftBond = Globals.getDaoService().getHumanDao().getAllLeftBond();
		leftItemBond = Globals.getDaoService().getHumanDao().getAllLeftItemBond();
		eternalCostMoney = Globals.getDaoService().getHumanDao().getAllEternalCostMoneyBond();
		long end=Globals.getTimeService().now();
		// 记录日志
		if (Loggers.timeEventTaskLogger.isInfoEnabled()) {
			String content = "任务：{0}:执行所需时间:{1}ms";
			Loggers.timeEventTaskLogger.warn(MessageFormat.format(content,"SendScribedLogTask",end-start+""));
		}
		return IIoOperation.STAGE_IO_DONE;
	}

	@Override
	public int doStart() {
		return IIoOperation.STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		Globals.getLocalScribeService().sendScribeGameGoldRemainReport(leftBond, leftItemBond , eternalCostMoney);
		return IIoOperation.STAGE_STOP_DONE;
	}
}
