package com.imop.lj.gameserver.title.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.title.handler.TitleHandlerFactory;

/**
 * 隐藏称号
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGDisTitle extends CGMessage{
	
	/** 是否隐藏称号 0隐藏,1显示称号 */
	private int distitle;
	
	public CGDisTitle (){
	}
	
	public CGDisTitle (
			int distitle ){
			this.distitle = distitle;
	}
	
	@Override
	protected boolean readImpl() {

	// 是否隐藏称号 0隐藏,1显示称号
	int _distitle = readInteger();
	//end



			this.distitle = _distitle;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 是否隐藏称号 0隐藏,1显示称号
	writeInteger(distitle);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_DIS_TITLE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_DIS_TITLE";
	}

	public int getDistitle(){
		return distitle;
	}
		
	public void setDistitle(int distitle){
		this.distitle = distitle;
	}


	@Override
	public void execute() {
		TitleHandlerFactory.getHandler().handleDisTitle(this.getSession().getPlayer(), this);
	}
}