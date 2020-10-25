package com.imop.lj.gameserver.tower;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;

import net.sf.json.JSONObject;

/**
 * 通天塔管理器
 *
 */
public class TowerManager implements JsonPropDataHolder{
	
	public static final String CUR_TOWER_LEVEL = "curTowerLevel";
	
	private Human owner;
	private int curTowerLevel;

	public TowerManager(Human owner) {
		this.owner = owner;
	} 
	
	@Override
	public String toJsonProp() {
		JSONObject obj = new JSONObject();
		obj.put(CUR_TOWER_LEVEL, curTowerLevel);
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
		
		this.curTowerLevel = JsonUtils.getInt(obj, CUR_TOWER_LEVEL);
	}

	public int getCurTowerLevel() {
		return curTowerLevel;
	}

	public void setCurTowerLevel(int curTowerLevel) {
		if(!Globals.getTowerService().isValidTowerLevel(curTowerLevel)){
			return;
		}else{
			this.curTowerLevel = curTowerLevel;
		}
		
	}

	public Human getOwner() {
		return owner;
	}
	


}
