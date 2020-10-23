package com.imop.lj.gameserver.goodactivity.msg.sysmsg;

import java.util.Calendar;
import java.util.Map;

import net.sf.json.JSONObject;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef;
import com.imop.lj.gameserver.goodactivity.template.PresetGoodActivityTemplate;

public class GmGoodActivityStartSysMsg extends SysInternalMessage {
	private long startTime;
	
	public GmGoodActivityStartSysMsg(long startTime){
		this.startTime = startTime;
	}
	
	@Override
	public void execute() {
		Map<Integer, PresetGoodActivityTemplate> map = Globals.getTemplateCacheService().getAll(PresetGoodActivityTemplate.class);
		if(map == null || map.isEmpty()){
			return;
		}
		
		for(PresetGoodActivityTemplate tmpl : map.values()){
			JSONObject json = new JSONObject();
			// 开始时间
			long startTime = this.startTime + tmpl.getDelayTime() * 24 * 60 * 60 * 1000;
			
			// 计算结束时间
			long endTime = startTime + tmpl.getDuration() - 1;
			Calendar end = Calendar.getInstance();
			end.setTimeInMillis(endTime);
			
			end.set(Calendar.HOUR_OF_DAY, 23);
			end.set(Calendar.MINUTE, 59);
			end.set(Calendar.SECOND, 59);
			end.set(Calendar.MILLISECOND, 0);
			
			endTime = end.getTimeInMillis();
			
			// 拼JSON
			json.put(GoodActivityDef.GOOD_ACTIVITY_ID_KEY, -1);
			json.put(GoodActivityDef.GOOD_ACTIVITY_ACTIVITY_TPL_ID_KEY, tmpl.getActivityTplId());
			json.put(GoodActivityDef.GOOD_ACTIVITY_USEABLE_KEY, tmpl.getActivityUsable());
			json.put(GoodActivityDef.GOOD_ACTIVITY_START_TIME_KEY, startTime);
			json.put(GoodActivityDef.GOOD_ACTIVITY_END_TIME_KEY, endTime);
			json.put(GoodActivityDef.GOOD_ACTIVITY_NAME_KEY, tmpl.getActivityName());
			json.put(GoodActivityDef.GOOD_ACTIVITY_DESC_KEY, tmpl.getActivityDesc());
			json.put(GoodActivityDef.GOOD_ACTIVITY_NAME_ICON_KEY, tmpl.getNameIcon());
			json.put( GoodActivityDef.GOOD_ACTIVITY_TITLE_ICON_KEY, tmpl.getTatleIcon());
			
			Globals.getGoodActivityService().gmCreateOrUpdateGoodActivity(json.toString());
		}
	}

}
