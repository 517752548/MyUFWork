package com.imop.lj.gameserver.guide.pusher;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.exam.ExamDef.ExamType;
import com.imop.lj.gameserver.exam.bean.Exam;
import com.imop.lj.gameserver.guide.AbstractGuidePusher;
import com.imop.lj.gameserver.guide.GuideDef.GuideType;
import com.imop.lj.gameserver.human.Human;

public class ExamGuidePusher extends AbstractGuidePusher {
	
	public ExamGuidePusher() {
		super(GuideType.EXAM);
	}

	@Override
	public boolean checkCond(Human human) {
		if (isFinishedGuide(human)) {
			return false;
		}
		
		// 当前是否开启了对应的功能按钮
		if (!Globals.getFuncService().hasOpenedFunc(human, getGuideType().getFuncType())) {
			return false;
		}
		
		//当前是否开启了科举活动
		Exam exam = new Exam(ExamType.PROVINCIAL);
		return exam.isOpening(human);
	}

}
