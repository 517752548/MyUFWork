package com.imop.lj.gameserver.offlinedata;

import net.sf.json.JSONObject;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.JsonPropDataHolder;

/**
 * 离线护航管理器
 * 
 * @author xiaowei.liu
 * 
 */
public class EscortSnapManager implements JsonPropDataHolder {
	public final String COUNT_KEY = "1";
	public final String LAST_OPE_TIME_KEY = "2";
	
	private UserSnap snap;
	private int count = 0;
	private long lastOpeTime;
	
	public EscortSnapManager(UserSnap snap){
		this.snap = snap;
	}
	
	@Override
	public String toJsonProp() {
		JSONObject obj = new JSONObject();
		obj.put(COUNT_KEY, count);
		obj.put(LAST_OPE_TIME_KEY, lastOpeTime);
		return obj.toString();
	}

	@Override
	public void loadJsonProp(String value) {
		if(value == null || value.isEmpty()){
			return;
		}
		
		JSONObject obj = JSONObject.fromObject(value);
		if(obj == null || obj.isEmpty()){
			return;
		}
		
		this.count = JsonUtils.getInt(obj, COUNT_KEY);
		this.lastOpeTime = JsonUtils.getLong(obj, LAST_OPE_TIME_KEY);
	}
	
	/**
	 * 当前使用次数
	 * 
	 * @return
	 */
	public int getCount(){
		this.flush();
		return this.count;
	}
	
	public boolean canDo(){
		return false;
//		this.flush();
//		return this.count < Globals.getGameConstants().getEscortMaxHelpCount();
	}
	
	public void doBehavior(){
		this.count ++;
		this.snap.setModified();
	}
	
	protected void flush(){
		long now = Globals.getTimeService().now();
		if(TimeUtils.isSameDay(now, this.lastOpeTime)){
			return;
		}
		
		this.count = 0;
		this.lastOpeTime = now;
		snap.setModified();
	}
}
