package com.imop.lj.tools.serverstatus.datagen;

import com.imop.lj.common.constants.ServerTypes;
import com.imop.lj.tools.serverstatus.AgentServerStatus;
import com.imop.lj.tools.serverstatus.DbsServerStatus;
import com.imop.lj.tools.serverstatus.GameServerStatus;
import com.imop.lj.tools.serverstatus.LoginServerStatus;
import com.imop.lj.tools.serverstatus.StatusInfo;
import com.imop.lj.tools.serverstatus.WorldServerStatus;

/**
 *状态信息创建器
 *
 * @author <a href="mailto:yong.fang@opi-corp.com">fang yong<a>
 *
 */
public class StatusInfoCreator {

	/**
	 * 根据服务器类型创建服务器状态
	 *
	 * @param serverType
	 * @return
	 */
	public static StatusInfo createStatusInfo(String serverType) {
		int serverIntType = Integer.parseInt(serverType);
		switch (serverIntType) {
		case ServerTypes.DBS:
			return new DbsServerStatus();
		case ServerTypes.GAME:
			return new GameServerStatus();
		case ServerTypes.LOGIN:
			return new LoginServerStatus();
		case ServerTypes.WORLD:
			return new WorldServerStatus();
		case ServerTypes.AGENT:
			return new AgentServerStatus();
		default:
			return null;

		}
	}
}
