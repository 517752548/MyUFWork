package com.imop.lj.gameserver.onlinegift;

import net.sf.json.JSONObject;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;

public abstract class AbstractOnlineGiftManager<T> implements JsonPropDataHolder {
	public static final String CURR_RECEIVE_ID = "currReceiveId";
	public static final String START_TIME = "startTime";
	
	protected Human owner;
	protected int currReceiveId;
	protected long startTime;
	
	public AbstractOnlineGiftManager(Human human){
		owner = human;
	}
	
	public void load(){
		if(currReceiveId < 1){
			this.initGift();
		}
	}
	
	@Override
	public String toJsonProp() {
		JSONObject obj = new JSONObject();
		obj.put(CURR_RECEIVE_ID, this.currReceiveId);
		obj.put(START_TIME, this.startTime);
		return obj.toString();
	}
	
	public void initGift(){
		this.currReceiveId = 1;
		this.startTime = Globals.getTimeService().now();
		this.owner.setModified();
	}
	
	public abstract long getCd();
	
	public boolean isOpening(){
		return this.getCurrReceiveOnlineGiftTemplate() != null;
	}
	
	
	public abstract T getCurrReceiveOnlineGiftTemplate();
	
	@Override
	public void loadJsonProp(String value) {
		if(value == null || value.isEmpty()){
			this.initGift();
			return;
		}
		
		JSONObject obj = JSONObject.fromObject(value);
		if(obj == null || obj.isEmpty()){
			this.initGift();
			return;
		}
		
		currReceiveId = JsonUtils.getInt(obj, CURR_RECEIVE_ID);
		startTime = JsonUtils.getLong(obj, START_TIME);
		
		if(currReceiveId < 1){
			this.initGift();
		}
	}

	public void next(){
		this.currReceiveId ++;
		this.startTime = Globals.getTimeService().now();
		this.owner.setModified();
	}
	
	public int getCurrReceiveId() {
		return currReceiveId;
	}

	public void setCurrReceiveId(int currReceiveId) {
		this.currReceiveId = currReceiveId;
	}

	public long getStartTime() {
		return startTime;
	}

	public void setStartTime(long startTime) {
		this.startTime = startTime;
	}

	public Human getOwner() {
		return owner;
	}

}
