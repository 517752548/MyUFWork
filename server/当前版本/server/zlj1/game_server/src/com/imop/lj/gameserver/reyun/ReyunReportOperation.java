package com.imop.lj.gameserver.reyun;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.HttpUtil;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalBindUUIDIoOperation;

import net.sf.json.JSONObject;

public class ReyunReportOperation implements LocalBindUUIDIoOperation {
	private long charId;
	private String urlPf;
	
	private List<JSONObject> jsonList = new ArrayList<JSONObject>();
	
	public ReyunReportOperation(long charId, String urlPf, List<JSONObject> jsonList) {
		this.charId = charId;
		this.urlPf = urlPf;
		this.jsonList = jsonList;
	}
	
	@Override
	public int doStart() {
		return STAGE_START_DONE;
	}

	@Override
	public int doIo() {
		try {
			String requestUrl = Globals.getServerConfig().getReyunServer() + urlPf;
			
			if (Loggers.localLogger.isDebugEnabled()) {
				Loggers.localLogger.debug("ReyunReportOperation jsonList=" + jsonList);
			}
			
			//循环列表汇报
			for (JSONObject json : jsonList) {
				String ret = HttpUtil.postUrlJson(requestUrl, json.toString());
				
				if (Loggers.localLogger.isDebugEnabled()) {
					Loggers.localLogger.debug("ReyunReportOperation ret=" + ret);
				}
			}
			
		} catch (IOException e) {
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
		return charId;
	}

}
