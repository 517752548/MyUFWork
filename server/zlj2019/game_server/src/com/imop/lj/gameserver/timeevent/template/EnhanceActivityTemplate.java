package com.imop.lj.gameserver.timeevent.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.template.TimeEventTemplate;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.broadcast.template.BroadcastTemplate;


/**
 * 强化活动配置
 * 
 * @author xiaowei.liu
 * 
 */
@ExcelRowBinding
public class EnhanceActivityTemplate extends EnhanceActivityTemplateVO implements Comparable<EnhanceActivityTemplate>{
//	private TimeModel startTime;
//	private TimeModel endTime;
//	private WeekModel fixedWeek;
//	private EnhanceActivityTypeTemplate type;
	
	@Override
	public void patchUp() throws Exception {
//		TimeEventTemplate start = templateService.get(this.startTimeId, TimeEventTemplate.class);
//		TimeEventTemplate end = templateService.get(this.endTimeId, TimeEventTemplate.class);
//		this.startTime = TimeModel.valueof(start == null ? "" : start.getTriggerTime());
//		this.endTime = TimeModel.valueof(end == null ? "" : end.getTriggerTime());
//		this.type = templateService.get(this.activityTypeId, EnhanceActivityTypeTemplate.class);
//		this.fixedWeek = WeekModel.valueof(this.fixedWeekStr); 
	}



	@Override
	public void check() throws TemplateConfigException {
//		if(this.startTime == null){
//			throw new TemplateConfigException(sheetName, this.id, "起始时间配置错误 startTime = " + this.startTimeId);
//		}
//		
//		if(this.endTime == null){
//			throw new TemplateConfigException(sheetName, this.id, "结束时间配置错误 endTime = " + this.endTimeId);
//		}
//		
//		if(this.endTime.le(startTime.getHour(), startTime.getMinute(), startTime.getSecond())){
//			throw new TemplateConfigException(sheetName, this.id, "结束时间<=开始时间");
//		}
//		
//		if(this.fixedWeek == null || this.fixedWeek.isEmpty()){
//			throw new TemplateConfigException(sheetName, this.id, "指定星期配置错误 fixedWeed = " + this.fixedWeekStr);
//		}
//		
//		if(type == null){
//			throw new TemplateConfigException(sheetName, this.id, "活动类型配置错误 activityTypeId = " + this.activityTypeId);
//		}
//		
//		if(this.broadcastId > 0){
//			if(templateService.get(this.broadcastId, BroadcastTemplate.class) == null){
//				throw new TemplateConfigException(sheetName, this.id, "公告ID大于0，但对应公告不存在");
//			}
//		}
	}

//	public TimeModel getStartTime() {
//		return startTime;
//	}
//
//	public TimeModel getEndTime() {
//		return endTime;
//	}
//
//	public WeekModel getFixedWeek() {
//		return fixedWeek;
//	}
//
//	public EnhanceActivityTypeTemplate getType() {
//		return type;
//	}



	@Override
	public int compareTo(EnhanceActivityTemplate o) {
		return 0;
//		return this.startTime.gt(o.getStartTime().getHour(), o.getStartTime().getMinute(), o.getStartTime().getSecond()) ? 1 : -1;
	}

}
