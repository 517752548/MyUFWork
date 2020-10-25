package com.imop.lj.gameserver.activity.function;

import com.imop.lj.gameserver.exam.ExamDef.ExamType;
import com.imop.lj.gameserver.human.Human;

public class ExamActivityFunction implements ActivityFunction {

	private ExamType examType;
	
	public ExamActivityFunction(ExamType examType) {
		this.examType = examType;
	}

	@Override
	public void onClick(Human human) {
		
	}

	public ExamType getExamType() {
		return examType;
	}

	public void setExamType(ExamType examType) {
		this.examType = examType;
	}

}
