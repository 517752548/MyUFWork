package com.imop.lj.gameserver.guide.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.guide.handler.GuideHandlerFactory;

/**
 * 完成新手引导，一些特殊的地方需要前台主动发完成才算完成，如欢迎的新手、vip体验卡的新手
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFinishGuide extends CGMessage{
	
	/** 新手引导类型id */
	private int guideTypeId;
	
	public CGFinishGuide (){
	}
	
	public CGFinishGuide (
			int guideTypeId ){
			this.guideTypeId = guideTypeId;
	}
	
	@Override
	protected boolean readImpl() {

	// 新手引导类型id
	int _guideTypeId = readInteger();
	//end



			this.guideTypeId = _guideTypeId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 新手引导类型id
	writeInteger(guideTypeId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_FINISH_GUIDE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_FINISH_GUIDE";
	}

	public int getGuideTypeId(){
		return guideTypeId;
	}
		
	public void setGuideTypeId(int guideTypeId){
		this.guideTypeId = guideTypeId;
	}


	@Override
	public void execute() {
		GuideHandlerFactory.getHandler().handleFinishGuide(this.getSession().getPlayer(), this);
	}
}