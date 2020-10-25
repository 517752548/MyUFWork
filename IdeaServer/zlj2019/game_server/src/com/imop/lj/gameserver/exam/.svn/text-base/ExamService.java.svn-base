package com.imop.lj.gameserver.exam;

import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.exam.ExamDef.ExamType;
import com.imop.lj.gameserver.exam.bean.AbstractExam;
import com.imop.lj.gameserver.exam.bean.Exam;
import com.imop.lj.gameserver.exam.bean.ExamTimeLimit;
import com.imop.lj.gameserver.human.Human;

public class ExamService implements InitializeRequired {
	
	/** Map<玩家Id,Map<科举类型, 答题信息>>*/
	protected  Map<Long, Map<ExamType, AbstractExam>> examMap = Maps.newHashMap();
	
	/**科举类型*/
	protected  ExamDef.ExamType runningExamType;
	
	@Override
	public void init() {
		refreshExam("init");
	}
	
	public Map<Long, Map<ExamType, AbstractExam>> getExamMap(){
		return this.examMap;
	}
	
	/**
	 * 科举申请
	 * @param human
	 * @param examType
	 */
	public void examApply(Human human, Integer examType) {
		AbstractExam exam = null;
		ExamType type = ExamType.valueOf(examType);
		if(type == null){
			return;
		}
		switch (type) {
		//乡试
		case PROVINCIAL:
			exam = new Exam(ExamType.PROVINCIAL);
			break;
		//限时答题
		case TIMELIMIT:
			exam = new ExamTimeLimit(ExamType.TIMELIMIT);
			break;
		default:
			break;
		}
		
		exam.examApply(human, examType);
		
	}
	
	/**
	 * 处理提交答案
	 * @param human
	 * @param examType
	 * @param choseAnswer
	 */
	public void examChoseAnswer(Human human, Integer examType, Integer choseAnswer) {
		AbstractExam exam = null;
		ExamType type = ExamType.valueOf(examType);
		if(type == null){
			return;
		}
		switch (type) {
		//乡试
		case PROVINCIAL:
			exam = new Exam(ExamType.PROVINCIAL);
			break;
		//限时答题
		case TIMELIMIT:
			exam = new ExamTimeLimit(ExamType.TIMELIMIT);
			break;
		default:
			break;
		}
		
		exam.examChoseAnswer(human, examType, choseAnswer);
	}
	
	/**
	 * 使用特殊道具答题
	 * @param human
	 * @param examType
	 * @param itemId
	 */
	public void examUseItem(Human human, Integer examType, Integer itemId) {
		
		AbstractExam exam = null;
		ExamType type = ExamType.valueOf(examType);
		if(type == null){
			return;
		}
		switch (type) {
		//乡试
		case PROVINCIAL:
			exam = new Exam(ExamType.PROVINCIAL);
			break;
		//限时答题
		case TIMELIMIT:
			exam = new ExamTimeLimit(ExamType.TIMELIMIT);
			break;
		default:
			break;
		}
		
		exam.examUseItem(human, examType, itemId);
	}
	
	public void refreshExam(String source) {
		//初始化数据
		runningExamType = ExamType.PROVINCIAL;
		examMap.clear();
		
		Loggers.examLogger.info("refreshExam source=" + source);
	}
}