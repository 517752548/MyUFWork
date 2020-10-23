package com.imop.lj.gameserver.across.msg;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.sys.ScheduledMessage;
import com.imop.lj.gameserver.common.Globals;

public class SchedulePingWorldServer extends ScheduledMessage{
	
	public SchedulePingWorldServer(long createTime) {
		super(createTime);	
	}

	@Override
	public void execute() {
		if(Globals.getConfig().getWorldServerConfig().isTurnOn() && Globals.getConfig().getWorldServerConfig().getServerType() == SharedConstants.GameServer_type){
			if(Globals.getWorldServerSession() != null){
				//判断worldServerSession是不是已经连接
				if(!Globals.getWorldServerSession().isConnected()){
					Loggers.gameLogger.info("YYYYYYYYYYYYYYYYYYYYYYYYYYYYYgameserver's worldServerSession is tryReConnecting..");
					Globals.getWorldServerSession().tryReConnect();
				}else{
					Globals.getWorldServerSession().sendMessage(new GWServerRegister(Integer.parseInt(Globals.getConfig().getServerId())));
					Loggers.gameLogger.info("gameserver's worldServerSession is Connected.");
				}
			}else{
				Loggers.gameLogger.warn("YYYYYYYYYYYYYYYYYYYYYYYYYYYYYgameserver's worldServerSession is null");
			}
		}
	}
}
