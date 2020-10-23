package com.imop.lj.gameserver.exam.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.exam.handler.ExamHandlerFactory;

/**
 * 申请答题
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGExamApply extends CGMessage{
	
	/** 申请的科举类型 */
	private int examType;
	
	public CGExamApply (){
	}
	
	public CGExamApply (
			int examType ){
			this.examType = examType;
	}
	
	@Override
	protected boolean readImpl() {

	// 申请的科举类型
	int _examType = readInteger();
	//end



			this.examType = _examType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 申请的科举类型
	writeInteger(examType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_EXAM_APPLY;
	}
	
	@Override
	public String getTypeName() {
		return "CG_EXAM_APPLY";
	}

	public int getExamType(){
		return examType;
	}
		
	public void setExamType(int examType){
		this.examType = examType;
	}


	@Override
	public void execute() {
		ExamHandlerFactory.getHandler().handleExamApply(this.getSession().getPlayer(), this);
	}
}