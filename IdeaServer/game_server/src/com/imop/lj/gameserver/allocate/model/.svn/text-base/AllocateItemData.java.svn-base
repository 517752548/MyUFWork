package com.imop.lj.gameserver.allocate.model;

import com.imop.lj.gameserver.human.JsonPropDataHolder;
import com.renren.games.api.util.JsonUtils;

import net.sf.json.JSONObject;

public class AllocateItemData  implements JsonPropDataHolder {
	
	public static final String ITEM_ID_KEY = "itemId";
	public static final String NUM_KEY = "num";
	
	//总的道具id
	private int itemId;
	//总的道具数量
	private int num;
	
	
	public AllocateItemData(int itemId, int num) {
		this.itemId = itemId;
		this.num = num;
	}


	public int getItemId() {
		return itemId;
	}


	public void setItemId(int itemId) {
		this.itemId = itemId;
	}


	public int getNum() {
		return num;
	}


	public void setNum(int num) {
		this.num = num;
	}


	@Override
	public String toString() {
		return "AllocateItemData [itemId=" + itemId + ", num=" + num + "]";
	}


	@Override
	public String toJsonProp() {
		JSONObject obj = new JSONObject();
		obj.put(ITEM_ID_KEY, itemId);
		obj.put(NUM_KEY, num);
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
		
		this.itemId = JsonUtils.getInt(obj, ITEM_ID_KEY);
		this.num = JsonUtils.getInt(obj, NUM_KEY);
		
	}
	
	public static AllocateItemData fromJson(String str){
		JSONObject obj = JSONObject.fromObject(str);
		int itemId = JsonUtils.getInt(obj, ITEM_ID_KEY);
		int num = JsonUtils.getInt(obj, NUM_KEY);

		return new AllocateItemData(itemId, num);
	}
	
	
	
	
	
	

}
