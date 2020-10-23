package com.imop.lj.gameserver.plotdungeon;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;

import net.sf.json.JSONObject;

public abstract class AbstractPlotDungeonManager<T> implements JsonPropDataHolder{
	
	public static final String PLOT_CHAPTER_LEVEL_KEY = "pLevel";
	public static final String LASTUPDATETIME_KEY = "time";
	
	protected Human owner;
	protected int plotLevel;
	protected long lastUpdateTime;

	public AbstractPlotDungeonManager(Human owner) {
		this.owner = owner;
	}

	public Human getOwner() {
		return owner;
	}

	public void setOwner(Human owner) {
		this.owner = owner;
	}

	public int getPlotLevel() {
		return plotLevel;
	}

	public void setPlotLevel(int plotLevel) {
		this.plotLevel = plotLevel;
	}

	public long getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(long lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}
	
	@Override
	public String toJsonProp() {
		JSONObject obj = new JSONObject();
		obj.put(PLOT_CHAPTER_LEVEL_KEY, this.plotLevel);
		obj.put(LASTUPDATETIME_KEY, this.lastUpdateTime);
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
		
		plotLevel = JsonUtils.getInt(obj, PLOT_CHAPTER_LEVEL_KEY);
		lastUpdateTime = JsonUtils.getLong(obj, LASTUPDATETIME_KEY);
	}
	
	
}
