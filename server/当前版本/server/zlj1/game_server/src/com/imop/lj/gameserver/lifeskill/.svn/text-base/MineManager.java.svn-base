package com.imop.lj.gameserver.lifeskill;

import java.util.Map;
import java.util.Map.Entry;

import net.sf.json.JSONArray;

import com.google.common.collect.Maps;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.RoleDataHolder;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;
import com.imop.lj.gameserver.lifeskill.template.LifeSkillMinePitTemplate;

/**
 * 挖矿管理器
 * @author Administrator
 *
 */
public class MineManager implements JsonPropDataHolder, RoleDataHolder{
	
	private Human human;
	
	private Map<Integer,MinePit> pitMap = Maps.newHashMap();
	
	
	public MineManager(Human human) {
		super();
		this.human = human;
	}
	
	/**
	 * 加入未进行初始化的矿点
	 * 
	 * 用于登陆，升级时检测
	 */
	private void rebuild(){
		Map<Integer, LifeSkillMinePitTemplate> lsmpt = Globals.getTemplateCacheService().getAll(LifeSkillMinePitTemplate.class);
		boolean flag = false;
		for(Entry<Integer, LifeSkillMinePitTemplate> entry : lsmpt.entrySet()){
			if(this.human.getMineLevel() >= entry.getValue().getOpenNeedMineLevel() 
					&& !pitMap.containsKey(entry.getKey())){
				flag = true;
				pitMap.put(entry.getKey(),new MinePit(entry.getKey()));
			}
		}
		if(flag){
			this.human.setModified();
		}
	}
	
	/**
	 * 得到玩家的采矿信息
	 * @return
	 */
	public Map<Integer, MinePit> getPitMap() {
		return pitMap;
	}

	@Override
	public String toJsonProp() {
		JSONArray json = new JSONArray();
		for (MinePit pit : pitMap.values()) {
			json.add(pit.toJsonProp());
		}
		return json.toString();
	}

	@Override
	public void loadJsonProp(String value) {
		if (value == null || value.isEmpty()) {
			return ;
		}
		
		JSONArray json = JSONArray.fromObject(value);
		if (json.isEmpty()) {
			return ;
		}
		
		for (int i = 0; i < json.size(); i++) {
			String j = json.getString(i);
			MinePit mainPit = MinePit.fromJson(j);
			pitMap.put(mainPit.getId(), mainPit);
		}
	}

	@Override
	public void checkAfterRoleLoad() {
		rebuild();
	}

	@Override
	public void checkBeforeRoleEnter() {
		return;
	}

}
