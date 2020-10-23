package com.imop.lj.gameserver.battlereport.async;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.BattleIIoOperation;

/**
 * 创建战报目录
 * @author yue.yan
 *
 */
public class CreateBattleReportDirOperation implements BattleIIoOperation  {

	@Override
	public int doStart() {
		return STAGE_START_DONE;
	}
	
	@Override
	public int doIo() {
		try{
			Globals.getBattleReportService().createTodayAndTomorrowDir();
		} catch(Exception e) {
			Loggers.battleReportLogger.error("", e);
		}
		return STAGE_STOP_DONE;
	}

	@Override
	public int doStop() {

		return STAGE_STOP_DONE;
	}

}
