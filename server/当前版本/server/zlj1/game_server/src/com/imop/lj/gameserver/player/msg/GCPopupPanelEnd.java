package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 通知客户端登录需要弹出的面板已经都发完了，前台可以开始处理了
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPopupPanelEnd extends GCMessage{
	

	public GCPopupPanelEnd (){
	}
	

	@Override
	protected boolean readImpl() {


		return true;
	}
	
	@Override
	protected boolean writeImpl() {

		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_POPUP_PANEL_END;
	}
	
	@Override
	public String getTypeName() {
		return "GC_POPUP_PANEL_END";
	}
}