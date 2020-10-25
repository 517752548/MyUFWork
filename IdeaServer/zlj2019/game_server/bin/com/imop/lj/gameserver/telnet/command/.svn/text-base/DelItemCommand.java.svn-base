package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.item.msg.DelItemMessage;

public class DelItemCommand extends LoginedTelnetCommand {
	
	//物品唯一id
	private final static String ITEMID_KEY = "itemId";
	//物品背包类型
	private final static String BAGTYPE_KEY ="bagType";
	//背包索引
	private final static String BAGINDEX_KEY ="bagIndex";
	//数量
	private final static String NUM_KEY = "num";
	//角色uuid
	private final static String ROLEUUID_KEY = "roleUUID";
	//操作者uuid
	private final static String LOGINUSERSTR_KEY = "loginUserStr";
	
	public DelItemCommand(){
		super("DELITEM");
	}

	@Override
	protected void doExec(String command, Map<String, String> params, IoSession session) {
		String itemId = params.get(ITEMID_KEY);
		int bagType = Integer.parseInt(params.get(BAGTYPE_KEY));
		int bagIndex = Integer.parseInt(params.get(BAGINDEX_KEY));
		int num = Integer.parseInt(params.get(NUM_KEY));
		long roleUUID = Long.parseLong(params.get(ROLEUUID_KEY));
		String loginUserStr = params.get(LOGINUSERSTR_KEY);
		
		DelItemMessage msg = new DelItemMessage(itemId, bagType, bagIndex, num, roleUUID, loginUserStr);
		// 在公共场景中执行，避免多线程问题
		Globals.getSceneService().getCommonScene().putMessage(msg);
		
		sendError(session, "请稍后刷新，查看结果");
	}
}


































