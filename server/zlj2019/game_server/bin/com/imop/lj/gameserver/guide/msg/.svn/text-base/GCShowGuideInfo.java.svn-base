package com.imop.lj.gameserver.guide.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 显示新手引导
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCShowGuideInfo extends GCMessage{
	
	/** 引导类型id */
	private int guideTypeId;
	/** 引导步骤json串 */
	private String guideStepStr;

	public GCShowGuideInfo (){
	}
	
	public GCShowGuideInfo (
			int guideTypeId,
			String guideStepStr ){
			this.guideTypeId = guideTypeId;
			this.guideStepStr = guideStepStr;
	}

	@Override
	protected boolean readImpl() {

	// 引导类型id
	int _guideTypeId = readInteger();
	//end


	// 引导步骤json串
	String _guideStepStr = readString();
	//end



		this.guideTypeId = _guideTypeId;
		this.guideStepStr = _guideStepStr;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 引导类型id
	writeInteger(guideTypeId);


	// 引导步骤json串
	writeString(guideStepStr);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_SHOW_GUIDE_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_SHOW_GUIDE_INFO";
	}

	public int getGuideTypeId(){
		return guideTypeId;
	}
		
	public void setGuideTypeId(int guideTypeId){
		this.guideTypeId = guideTypeId;
	}

	public String getGuideStepStr(){
		return guideStepStr;
	}
		
	public void setGuideStepStr(String guideStepStr){
		this.guideStepStr = guideStepStr;
	}
}