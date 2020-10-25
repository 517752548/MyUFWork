package com.imop.lj.gameserver.mall;

import java.util.HashMap;
import java.util.Map;
import java.util.Map.Entry;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;
import com.imop.lj.gameserver.offlinedata.KeyValue;

/**
 * 商城管理
 * 
 * @author xiaowei.liu
 * 
 */
public class MallManager implements JsonPropDataHolder {
	public static final String QUEUE_UUID_KEY = "queueUUID";
	public static final String BUY_NUM_MAP_KEY = "buyNumMap";
	
	private Human owner;
	private String queueUUID;
	private Map<Integer, Integer> map;

	public MallManager(Human human) {
		this.owner = human;
		map = new HashMap<Integer, Integer>();
	}

	public void reset(String uuid){
		this.queueUUID = uuid;
		this.map.clear();
		this.owner.setModified();
	}
	
	@Override
	public String toJsonProp() {
		JSONObject obj = new JSONObject();
		obj.put(QUEUE_UUID_KEY, this.queueUUID);
		JSONArray array = new JSONArray();
		for(Entry<Integer, Integer> entry : map.entrySet()){
			KeyValue kv = new KeyValue(entry.getKey(), (float)(entry.getValue().intValue()));
			array.add(kv.toJson());
		}
		obj.put(BUY_NUM_MAP_KEY, array.toString());
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
		
		this.queueUUID = JsonUtils.getString(obj, QUEUE_UUID_KEY);
		String arrayStr = JsonUtils.getString(obj, BUY_NUM_MAP_KEY);
		JSONArray array = JSONArray.fromObject(arrayStr);
		if(array == null || array.isEmpty()){
			return;
		}
		
		for (int i = 0; i < array.size(); i++) {
			String str = array.getString(i);
			KeyValue kv = KeyValue.fromJson(str);
			if(kv != null){
				this.map.put(kv.getKey(), (int)kv.getValue());
			}
		}
	}
	
	/**
	 * 获取指定队列，指定物品的购买数量，如果UUID跟当前ID不一致，则重置当前商城数据
	 * @param uuid
	 * @param tmplId
	 * @return
	 */
	public int getNum(String uuid, int tmplId){
		if(!uuid.equals(this.queueUUID)){
			this.reset(uuid);
			return 0;
		}else{
			Integer num = this.map.get(tmplId);
			if(num == null){
				return 0;
			}else{
				return num;
			}
		}		
	}
	
	/**
	 * 增加购买次数，如果没有则不增加
	 * 
	 * @param uuid
	 * @param tmplId
	 */
	public void increaseNum(String uuid, int tmplId, int count){
		if(!uuid.equals(this.queueUUID)){
			return;
		}
		
		Integer num = this.map.get(tmplId);
		if(num == null){
			this.map.put(tmplId, count);
		}else{
			num += count;
			this.map.put(tmplId,  num);
		}
		
		this.owner.setModified();
	}

	
	
	public String getQueueUUID() {
		return queueUUID;
	}

	public void setQueueUUID(String queueUUID) {
		this.queueUUID = queueUUID;
	}

	public Map<Integer, Integer> getMap() {
		return map;
	}

	public void setMap(Map<Integer, Integer> map) {
		this.map = map;
	}
}
