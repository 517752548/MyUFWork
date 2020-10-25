package com.imop.lj.gameserver.exam.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.exam.handler.ExamHandlerFactory;

/**
 * 选择选项
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGExamChose extends CGMessage{
	
	/** 申请的科举类型 */
	private int examType;
	/** 选择的答案 */
	private int choseAnswer;
	
	public CGExamChose (){
	}
	
	public CGExamChose (
			int examType,
			int choseAnswer ){
			this.examType = examType;
			this.choseAnswer = choseAnswer;
	}
	
	@Override
	protected boolean readImpl() {

	// 申请的科举类型
	int _examType = readInteger();
	//end


	// 选择的答案
	int _choseAnswer = readInteger();
	//end



			this.examType = _examType;
			this.choseAnswer = _choseAnswer;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 申请的科举类型
	writeInteger(examType);


	// 选择的答案
	writeInteger(choseAnswer);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_EXAM_CHOSE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_EXAM_CHOSE";
	}

	public int getExamType(){
		return examType;
	}
		
	public void setExamType(int examType){
		this.examType = examType;
	}

	public int getChoseAnswer(){
		return choseAnswer;
	}
		
	public void setChoseAnswer(int choseAnswer){
		this.choseAnswer = choseAnswer;
	}


	@Override
	public void execute() {
		ExamHandlerFactory.getHandler().handleExamChose(this.getSession().getPlayer(), this);
	}
}