package com.imop.lj.gameserver.corps.model;

import net.sf.json.JSONObject;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.item.template.ItemTemplate;

/**
 * 军团仓库物品
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsStorageItem {
	public static final String ITEM_TEMP_ID = "1";
	public static final String NUM_KEY = "2";

	/** 物品模版ID */
	private int itemTempId;
	/** 物品数量 */
	private int num;
	/** 物品下标，仅做为删除时参数 */
	private int index;

	private CorpsStorageItem() {
	};

	/**
	 * 通过JSON创建对象实例
	 * 
	 * @param json
	 * @return
	 */
	public static CorpsStorageItem createCorpsStorageItem(String json) {
		if(json == null || json.isEmpty()){
			return null;
		}
		
		JSONObject obj = JSONObject.fromObject(json);
		if(obj == null || obj.isEmpty()){
			return null;
		}
		
		CorpsStorageItem item = new CorpsStorageItem();
		item.itemTempId = JsonUtils.getInt(obj, ITEM_TEMP_ID);
		item.num = JsonUtils.getInt(obj, NUM_KEY);
		
		return item;
	}

	/**
	 * 转换为JSON
	 * 
	 * @return
	 */
	public String toJson() {
		JSONObject obj = new JSONObject();
		obj.put(ITEM_TEMP_ID, this.itemTempId);
		obj.put(NUM_KEY, this.num);
		return obj.toString();
	}

	/**
	 * 生成需要添加的物品
	 * 
	 * @param itemTempId
	 * @param num
	 * @return
	 */
	public static CorpsStorageItem createAddItem(int itemTempId, int num) {
		if (Globals.getTemplateCacheService().get(itemTempId,
				ItemTemplate.class) == null) {
			return null;
		}

		if (num <= 0) {
			return null;
		}

		CorpsStorageItem item = new CorpsStorageItem();
		item.itemTempId = itemTempId;
		item.num = num;
		return item;
	}

	/**
	 * 生成需要删除的物品
	 * 
	 * @param itemTempId
	 * @param num
	 * @return
	 */
	public static CorpsStorageItem createDeleteItem(int itemTempId, int num,
			int index) {
		if (Globals.getTemplateCacheService().get(itemTempId, ItemTemplate.class) == null) {
			return null;
		}

		if (num <= 0) {
			return null;
		}

		CorpsStorageItem item = new CorpsStorageItem();
		item.itemTempId = itemTempId;
		item.num = num;
		item.index = index;
		return item;
	}

	/**
	 * 减数量
	 * 
	 * @param num
	 * @return
	 */
	public boolean reduceNum(int num) {
		if(num <= 0){
			return false;
		}
		
		if (this.num < num) {
			return false;
		}

		this.num -= num;
		return true;
	}

	public CorpsStorageItem copySelf() {
		CorpsStorageItem item = new CorpsStorageItem();
		item.itemTempId = this.itemTempId;
		item.num = this.num;
		item.index = this.index;
		return item;
	}

	public int getItemTempId() {
		return itemTempId;
	}

	public int getNum() {
		return num;
	}

	public int getIndex() {
		return index;
	}
}
