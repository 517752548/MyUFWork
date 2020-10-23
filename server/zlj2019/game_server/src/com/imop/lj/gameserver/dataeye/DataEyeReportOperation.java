package com.imop.lj.gameserver.dataeye;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalBindUUIDIoOperation;
import com.imop.lj.gameserver.dataeye.DataEyeDef.DataEyeReportType;
import com.imop.lj.gameserver.player.Player;

public class DataEyeReportOperation implements LocalBindUUIDIoOperation {
	private Player player;
	private DataEyeReportType reportType;
	private Object param;
	
	public DataEyeReportOperation(Player player, DataEyeReportType reportType, Object param) {
		this.player = player;
		this.reportType = reportType;
		this.param = param;
	}
	
	@Override
	public int doStart() {
		return STAGE_START_DONE;
	}

	@Override
	public int doIo() {
		try {
			if (player == null) {
				Loggers.localLogger.warn("DataEyeReportOperation player is null!" + 
						";reportType=" + reportType + ";param=" + param);
				return STAGE_STOP_DONE;
			}
			
			Globals.getDataEyeService().doReport(player, reportType, param);
			
		} catch (Exception e) {
			e.printStackTrace();
			Loggers.localLogger.error("ReyunReportOperation Exception!", e);
		}
		//直接结束，不需要doStop
		return STAGE_STOP_DONE;
	}

	@Override
	public int doStop() {
		return STAGE_STOP_DONE;
	}

	@Override
	public long getBindUUID() {
		return player.getRoleUUID();
	}

}
