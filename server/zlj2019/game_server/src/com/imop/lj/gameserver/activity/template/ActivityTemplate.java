package com.imop.lj.gameserver.activity.template;

import java.util.Calendar;
import java.util.HashSet;
import java.util.Set;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.template.TimeEventTemplate;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.activity.function.AbstractActivityMessage;
import com.imop.lj.gameserver.activity.function.ActivityDef.ActivitySysMessageType;
import com.imop.lj.gameserver.activity.function.ActivityDef.ActivityType;
import com.imop.lj.gameserver.activity.function.ActivityFunction;
import com.imop.lj.gameserver.activity.function.ExamActivityFunction;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corpswar.activity.CorpsWarEndMessage;
import com.imop.lj.gameserver.corpswar.activity.CorpsWarNoticeMessage;
import com.imop.lj.gameserver.corpswar.activity.CorpsWarReadyMessage;
import com.imop.lj.gameserver.corpswar.activity.CorpsWarStartMessage;
import com.imop.lj.gameserver.exam.ExamDef.ExamType;
import com.imop.lj.gameserver.exam.activity.ExamEndMessage;
import com.imop.lj.gameserver.exam.activity.ExamNoticeMessage;
import com.imop.lj.gameserver.exam.activity.ExamReadyMessage;
import com.imop.lj.gameserver.exam.activity.ExamStartMessage;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.map.activity.PetIslandEndMessage;
import com.imop.lj.gameserver.map.activity.PetIslandNoticeMessage;
import com.imop.lj.gameserver.map.activity.PetIslandReadyMessage;
import com.imop.lj.gameserver.map.activity.PetIslandStartMessage;
import com.imop.lj.gameserver.nvn.activity.NvnEndMessage;
import com.imop.lj.gameserver.nvn.activity.NvnNoticeMessage;
import com.imop.lj.gameserver.nvn.activity.NvnReadyMessage;
import com.imop.lj.gameserver.nvn.activity.NvnStartMessage;

/**
 * 活动信息模板
 */
@ExcelRowBinding
public class ActivityTemplate extends ActivityTemplateVO {

	private AbstractActivityMessage noticeMessage;
	private AbstractActivityMessage readyMessage;
	private AbstractActivityMessage startMessage;
	private AbstractActivityMessage endMessage;

	private ActivityFunction activityFunction;

	private Calendar noticeTimeCalendar;
	private Calendar readyTimeCalendar;
	private Calendar startTimeCalendar;
	private Calendar endTimeCalendar;
	
	/** 活动对应的功能类型 */
	private FuncTypeEnum funcType;

	private Set<Integer> weekLimitSet = new HashSet<Integer>();
	
	@Override
	public void check() throws TemplateConfigException {

		if (this.funcTypeId != 0) {
			funcType = FuncTypeEnum.valueOf(funcTypeId);
			if (funcType == null) {
				throw new TemplateConfigException(getSheetName(), getId(), String.format("功能类型id%d非法", this.funcTypeId));
			}
		}

		// 时间参数检测
		if(this.noticeActivityTimeEventId != 0){
			TimeEventTemplate noticeTimeTmpl = templateService.get(this.noticeActivityTimeEventId, TimeEventTemplate.class);
			if(noticeTimeTmpl == null){
				throw new TemplateConfigException(getSheetName(), getId(), String.format("提醒时间%d非法", this.noticeActivityTimeEventId));
			}
			this.noticeTimeCalendar = noticeTimeTmpl.getTriggerTimePoint();
		}

		if(this.readyActivityTimeEventId != 0){
			TimeEventTemplate readyTimeTmpl = templateService.get(this.readyActivityTimeEventId, TimeEventTemplate.class);
			if(readyTimeTmpl == null){
				throw new TemplateConfigException(getSheetName(), getId(), String.format("准备时间%d非法", this.readyActivityTimeEventId));
			}
			this.readyTimeCalendar = readyTimeTmpl.getTriggerTimePoint();
		}

		TimeEventTemplate startTimeTmpl = templateService.get(this.startActivityTimeEventId, TimeEventTemplate.class);
		if(startTimeTmpl == null){
			throw new TemplateConfigException(getSheetName(), getId(), String.format("开始时间%d非法", this.startActivityTimeEventId));
		}
		this.startTimeCalendar = startTimeTmpl.getTriggerTimePoint();

		TimeEventTemplate endTimeTmpl = templateService.get(this.endActivityTimeEventId, TimeEventTemplate.class);
		if(endTimeTmpl == null){
			throw new TemplateConfigException(getSheetName(), getId(), String.format("结束时间%d非法", this.endActivityTimeEventId));
		}
		this.endTimeCalendar = endTimeTmpl.getTriggerTimePoint();

		//检测活动函数
		ActivityType activity = ActivityType.valueOf(this.activityFunctionTemplate.getActivtyType());
		if(activity == null){
			throw new TemplateConfigException(getSheetName(), getId(), String.format("活动函数%d非法", this.activityFunctionTemplate.getActivtyType()));
		}

		//检测各个阶段系统消息参数
		for (int i = 0; i < this.activityMessageTemplateList.size(); i++) {
			ActivityMessageTemplate activityTemplate = this.activityMessageTemplateList.get(i);
			ActivitySysMessageType functionType = ActivitySysMessageType.valueOf(activityTemplate.getType());
			if(functionType == null){
				throw new TemplateConfigException(getSheetName(), getId(), String.format("各个阶段系统消息类型错误", activityTemplate.getType()));
			}
		}
		
		//检查周几限制是否合法
		if (getWeekLimitStr() != null && !getWeekLimitStr().isEmpty()) {
			String[] wArr = getWeekLimitStr().split(",");
			for (int i = 0; i < wArr.length; i++) {
				Integer weekDay = Integer.parseInt(wArr[i]);
				if (weekDay == null || weekDay < 1 || weekDay > 7) {
					throw new TemplateConfigException(getSheetName(), getId(), String.format("周几限制含有非法日期，必须为1-7", getWeekLimitStr()));
				}
				weekLimitSet.add(weekDay);
			}
		}

		this.buildActivity();
	}

	private void buildActivity() {
		for (int i = 0; i < this.activityMessageTemplateList.size(); i++) {
			ActivityMessageTemplate activityTemplate = this.activityMessageTemplateList.get(i);
			ActivitySysMessageType functionType = ActivitySysMessageType.valueOf(activityTemplate.getType());
			AbstractActivityMessage activityMessage;
			switch (functionType) {
			
			//科举答题
			case EXAM_NOTICE_FUNC:
				activityMessage = new ExamNoticeMessage(this);
				break;
			case EXAM_READY_FUNC:
				activityMessage = new ExamReadyMessage(this);
				break;
			case EXAM_START_FUNC:
				activityMessage = new ExamStartMessage(this);
				break;
			case EXAM_END_FUNC:
				activityMessage = new ExamEndMessage(this);
				break;
		
			//宠物岛
			case PETISLAND_NOTICE_FUNC:
				activityMessage = new PetIslandNoticeMessage(this);
				break;
			case PETISLAND_READY_FUNC:
				activityMessage = new PetIslandReadyMessage(this);
				break;
			case PETISLAND_START_FUNC:
				activityMessage = new PetIslandStartMessage(this);
				break;
			case PETISLAND_END_FUNC:
				activityMessage = new PetIslandEndMessage(this);
				break;
				
			//帮派战
			case CORPSWAR_NOTICE_FUNC:
				activityMessage = new CorpsWarNoticeMessage(this);
				break;
			case CORPSWAR_READY_FUNC:
				activityMessage = new CorpsWarReadyMessage(this);
				break;
			case CORPSWAR_START_FUNC:
				activityMessage = new CorpsWarStartMessage(this);
				break;
			case CORPSWAR_END_FUNC:
				activityMessage = new CorpsWarEndMessage(this);
				break;
				
			//nvn联赛
			case NVN_NOTICE_FUNC:
				activityMessage = new NvnNoticeMessage(this);
				break;
			case NVN_READY_FUNC:
				activityMessage = new NvnReadyMessage(this);
				break;
			case NVN_START_FUNC:
				activityMessage = new NvnStartMessage(this);
				break;
			case NVN_END_FUNC:
				activityMessage = new NvnEndMessage(this);
				break;
				
			default:
				activityMessage = null;
				break;
			}

			switch (i) {
			case 0:
				activityMessage.setStartCalendar(noticeTimeCalendar);
				noticeMessage = activityMessage;
				break;
			case 1:
				activityMessage.setStartCalendar(readyTimeCalendar);
				readyMessage = activityMessage;
				break;
			case 2:
				activityMessage.setStartCalendar(startTimeCalendar);
				startMessage = activityMessage;
				break;
			case 3:
				activityMessage.setStartCalendar(endTimeCalendar);
				endMessage = activityMessage;
				break;
			default:
				continue;
			}
		}

		ActivityType activity = ActivityType.valueOf(this.activityFunctionTemplate.getActivtyType());
		switch (activity) {
		//XXX 不同活动的特殊处理
		case EXAM:
			//不同类型的科举
			ExamType et = ExamType.valueOf(this.activityFunctionTemplate.getParam1());
			this.activityFunction = new ExamActivityFunction(et);
			break;
		case PET_ISLAND:
			break;
		case CORPS_WAR:
			break;
		case NVN:
			break;
			
		default:
			break;
		}

		Loggers.gameLogger.debug(this + "");
	}

	public SysInternalMessage getNoticeFunction() {
		return noticeMessage;
	}

	public SysInternalMessage getReadyFunction() {
		return readyMessage;
	}

	public SysInternalMessage getStartFunction() {
		return startMessage;
	}

	public SysInternalMessage getEndFunction() {
		return endMessage;
	}

	public ActivityFunction getActivityFunction() {
		return activityFunction;
	}

	public Calendar getNoticeTimeCalendar() {
		return noticeTimeCalendar;
	}

	public Calendar getReadyTimeCalendar() {
		return readyTimeCalendar;
	}

	public Calendar getStartTimeCalendar() {
		return startTimeCalendar;
	}

	public Calendar getEndTimeCalendar() {
		return endTimeCalendar;
	}

	/**
	 * 获取活动对应的功能类型
	 * @return
	 */
	public FuncTypeEnum getFuncType() {
		return funcType;
	}

	public AbstractActivityMessage getNoticeMessage() {
		return noticeMessage;
	}

	public void setNoticeMessage(AbstractActivityMessage noticeMessage) {
		this.noticeMessage = noticeMessage;
	}

	public AbstractActivityMessage getReadyMessage() {
		return readyMessage;
	}

	public void setReadyMessage(AbstractActivityMessage readyMessage) {
		this.readyMessage = readyMessage;
	}

	public AbstractActivityMessage getStartMessage() {
		return startMessage;
	}

	public void setStartMessage(AbstractActivityMessage startMessage) {
		this.startMessage = startMessage;
	}

	public AbstractActivityMessage getEndMessage() {
		return endMessage;
	}

	public void setEndMessage(AbstractActivityMessage endMessage) {
		this.endMessage = endMessage;
	}

	public void setActivityFunction(ActivityFunction activityFunction) {
		this.activityFunction = activityFunction;
	}

	public void setNoticeTimeCalendar(Calendar noticeTimeCalendar) {
		this.noticeTimeCalendar = noticeTimeCalendar;
	}

	public void setReadyTimeCalendar(Calendar readyTimeCalendar) {
		this.readyTimeCalendar = readyTimeCalendar;
	}

	public void setStartTimeCalendar(Calendar startTimeCalendar) {
		this.startTimeCalendar = startTimeCalendar;
	}

	public void setEndTimeCalendar(Calendar endTimeCalendar) {
		this.endTimeCalendar = endTimeCalendar;
	}

	public void setFuncType(FuncTypeEnum funcType) {
		this.funcType = funcType;
	}
	
	public boolean isWeekLimitOK() {
		if (weekLimitSet.isEmpty()) {
			return true;
		}
		int curWeekDay = TimeUtils.getDayOfTheWeekNum(Globals.getTimeService().now());
		return weekLimitSet.contains(curWeekDay);
	}
	
}
