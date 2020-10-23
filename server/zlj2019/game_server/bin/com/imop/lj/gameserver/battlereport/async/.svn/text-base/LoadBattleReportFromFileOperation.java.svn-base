package com.imop.lj.gameserver.battlereport.async;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.InputStreamReader;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.BattleIIoOperation;
import com.imop.lj.gameserver.human.Human;

/**
 * 从文件中读取战报数据的IoOperation
 * @author yue.yan
 *
 */
public class LoadBattleReportFromFileOperation implements BattleIIoOperation {

	/** 请求战报的玩家 */
	private Human human;
	/** 读取的战报id */
	private long id;
	/** 战报数据 */
	private String data;
//	/** 是否是团战 */
//	private boolean isTeamWar;
	/**战报读取完毕以后，前端返回场景id**/
	private int toBackType;
	
	public LoadBattleReportFromFileOperation(Human human, long id, boolean isTeamWar, int toBackType) {
		this.human = human;
		this.id = id;
//		this.isTeamWar = isTeamWar;
		this.toBackType = toBackType;
	}
	
	@Override
	public int doStart() {
		return STAGE_START_DONE;
	}
	
	@Override
	public int doIo() {
		try{
			// 获取战报文件名
			String fileName = Globals.getBattleReportService().getBattleReportFilePath(id);
			File fileObj = new File(fileName);

			if (!fileObj.exists()) {
				// 如果战报文件不存在, 直接退出
				Loggers.battleReportLogger.error(fileName + " file not exists");
				return STAGE_IO_DONE;
			}
			
			InputStreamReader reader = new InputStreamReader(new FileInputStream(fileObj), "utf-8");
			BufferedReader br = new BufferedReader(reader);
			StringBuilder sb = new StringBuilder();
			String s;
			while((s = br.readLine()) != null) {
				sb.append(s);
			}
			data = sb.toString();
			br.close();
			reader.close();
		} catch (Exception e) {
			Loggers.battleReportLogger.error("", e);
		}
		return STAGE_IO_DONE;
	}

	@Override
	public int doStop() {
		//如果查到，给客户端发消息
		if (data != null) {
//			if(isTeamWar) {
////				Globals.getBattleReportService().sendTeamWarReportMsg(human, data);	
//			} else {
//			}
			Globals.getBattleReportService().sendBattleReportMsg(human, data, id, true, false,this.toBackType, "");
			
		} else {
			//发错误消息
			human.sendSystemMessage(LangConstants.BATTLE_REPORT_ERR_LOAD_FAIL);
		}
		
		return STAGE_STOP_DONE;
	}

}
