package com.imop.lj.gameserver.mall.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 物品购买数量选择面板操作
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCBuyItemPanelOperate extends GCMessage{
	
	/** 1:关闭2：刷新 */
	private int opeType;

	public GCBuyItemPanelOperate (){
	}
	
	public GCBuyItemPanelOperate (
			int opeType ){
			this.opeType = opeType;
	}

	@Override
	protected boolean readImpl() {

	// 1:关闭2：刷新
	int _opeType = readInteger();
	//end



		this.opeType = _opeType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 1:关闭2：刷新
	writeInteger(opeType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_BUY_ITEM_PANEL_OPERATE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_BUY_ITEM_PANEL_OPERATE";
	}

	public int getOpeType(){
		return opeType;
	}
		
	public void setOpeType(int opeType){
		this.opeType = opeType;
	}
}