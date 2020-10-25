package com.imop.lj.gameserver.battlereport.async;

import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.util.List;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.BattleProcess;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.BattleIIoOperation;

/**
 * 保存战报到文件的IoOperation
 * @author yue.yan
 *
 */
public class SaveBattleReportToFileOperation implements BattleIIoOperation  {

	/** 战报id */
	private long id;
	/** 战报数据 */
	private List<String> data;
	
	public SaveBattleReportToFileOperation(long id, List<String> data) {
		this.id = id;
		this.data = data;
	}
	
	@Override
	public int doStart() {
		return STAGE_START_DONE;
	}
	
	@Override
	public int doIo() {
		try {
			String dataStr = BattleProcess.makeReportStr(data);
			
			if (dataStr != null && !dataStr.isEmpty()) {
				OutputStreamWriter writer = new OutputStreamWriter(new FileOutputStream(
						Globals.getBattleReportService().getBattleReportFilePath(id)), "utf-8");
				writer.write(dataStr);
				writer.close();
			} else {
				Loggers.battleReportLogger.error("dataStr is null or empty!");
			}
		} catch (IOException e) {
			Loggers.battleReportLogger.error("", e);
		} 
		return STAGE_IO_DONE;
	}

	@Override
	public int doStop() {
		return STAGE_STOP_DONE;
	}
}
