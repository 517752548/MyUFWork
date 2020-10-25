package com.imop.lj.gameserver.common.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.common.handler.CommonHandlerFactory;

/**
 * 选择确认小信封
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGClickNoticeTipsInfo extends CGMessage{
	
	/** 操作标识 */
	private String tag;
	/** 选项值 */
	private String value;
	
	public CGClickNoticeTipsInfo (){
	}
	
	public CGClickNoticeTipsInfo (
			String tag,
			String value ){
			this.tag = tag;
			this.value = value;
	}
	
	@Override
	protected boolean readImpl() {

	// 操作标识
	String _tag = readString();
	//end


	// 选项值
	String _value = readString();
	//end



			this.tag = _tag;
			this.value = _value;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 操作标识
	writeString(tag);


	// 选项值
	writeString(value);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CLICK_NOTICE_TIPS_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CLICK_NOTICE_TIPS_INFO";
	}

	public String getTag(){
		return tag;
	}
		
	public void setTag(String tag){
		this.tag = tag;
	}

	public String getValue(){
		return value;
	}
		
	public void setValue(String value){
		this.value = value;
	}


	@Override
	public void execute() {
		CommonHandlerFactory.getHandler().handleClickNoticeTipsInfo(this.getSession().getPlayer(), this);
	}
}