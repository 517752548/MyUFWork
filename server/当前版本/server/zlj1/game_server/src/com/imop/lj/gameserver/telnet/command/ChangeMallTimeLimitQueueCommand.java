package com.imop.lj.gameserver.telnet.command;

import java.text.ParseException;
import java.util.LinkedList;
import java.util.Map;

import net.sf.json.JSONObject;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.mall.msg.ChangeMallTimeLimitQueuMessage;

public class ChangeMallTimeLimitQueueCommand extends LoginedTelnetCommand {

	public ChangeMallTimeLimitQueueCommand() {
		super("changeMall");
	}

	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {
		String _param = getCommandParam(command);
		if (_param.length() == 0) {
			sendError(session, "No param");
			return;
		}

		JSONObject _json = JSONObject.fromObject(_param);
		String startTimeStr = _json.getString("startTime");
		String queueStr = _json.getString("queue");
		
		if(startTimeStr == null || startTimeStr.isEmpty()){
			sendError(session, "开始时间配置错误 msg = " + _json.toString());
			return;
		}
		
		if(queueStr == null || queueStr.isEmpty()){
			sendError(session, "队列配置错误 msg = " + _json.toString());
			return;
		}
		
		try {
			long startTime = TimeUtils.getYMDHMTime(startTimeStr);
			String[] items = queueStr.split(",");
			
			LinkedList<Integer> queue = new LinkedList<Integer>();
			for(String str : items){
				queue.add(Integer.parseInt(str));
			}
			
			if(queue.isEmpty()){
				sendError(session, "队列为空 msg = " + _json.toString());
				return;
			}
			
			String result = Globals.getMallService().checkStartAndQueue(startTime, queueStr, queue);
			if(result != null){
				sendError(session, result);
				return;
			}
			ChangeMallTimeLimitQueuMessage msg = new ChangeMallTimeLimitQueuMessage(startTime, queueStr, queue);
			Globals.getSceneService().getCommonScene().putMessage(msg);
			
			sendMessage(session, "请稍后刷新，查看操作结果");
		} catch (ParseException e) {
			sendError(session, e.getMessage());
		}
	}

}
