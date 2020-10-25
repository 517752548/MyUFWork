package com.imop.lj.gameserver.mysteryshop;

import java.util.ArrayList;
import java.util.List;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;
import com.imop.lj.gameserver.mysteryshop.MysteryShopDef.BuyState;
import com.imop.lj.gameserver.mysteryshop.template.MysteryShopItemTemplate;

/**
 * 神秘商店管理器
 * 
 * @author xiaowei.liu
 * 
 */
public class MysteryShopManager implements JsonPropDataHolder {
	public static final String LAST_FLUSH_TIME = "lastFlushTime";
	public static final String ITEM_LIST = "itemList";
	
	private Human owner;
	private long lastFlushTime;
	private List<MSItem> itemList = new ArrayList<MSItem>();
	
	public MysteryShopManager(Human human){
		this.owner = human;
	}
	
	@Override
	public String toJsonProp() {
		JSONObject obj = new JSONObject();
		obj.put(LAST_FLUSH_TIME, lastFlushTime);
		JSONArray array = new JSONArray();
		for(MSItem msItem : itemList){
			array.add(msItem.toJson());
		}
		obj.put(ITEM_LIST, array.toString());
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
		
		this.lastFlushTime = JsonUtils.getLong(obj, LAST_FLUSH_TIME);
		String str = obj.getString(ITEM_LIST);
		if(str == null || str.isEmpty()){
			return;
		}
		
		JSONArray array = JSONArray.fromObject(str);
		if(array == null || array.isEmpty()){
			return;
		}
		
		for(int i=0; i<array.size(); i++){
			String json = array.getString(i);
			MSItem msItem = MSItem.fromJson(json);
			if(Globals.getTemplateCacheService().get(msItem.getId(), MysteryShopItemTemplate.class) != null){
				this.itemList.add(msItem);
			}else{
				Loggers.mysteryShopLogger.error("MysteryShopManager.loadJsonProp msItemId = " + msItem.getId() + ", MysteryShopItemTemplate does not exist, may be delete an this version");
			}
		}
	}
	
	public MSItem getMSItem(int msItemId){
		for(MSItem msItem : this.itemList){
			if(msItem.getId() == msItemId){
				return msItem;
			}
		}
		
		return null;
	}
	
	public void updateItemList(List<MysteryShopItemTemplate> list){
		this.itemList.clear();
		for(MysteryShopItemTemplate tmpl : list){
			MSItem msItem = new MSItem(tmpl.getId(), BuyState.WAIT_BUY);
			this.itemList.add(msItem);
		}
	}
	
	public long getLastFlushTime() {
		return lastFlushTime;
	}

	public void setLastFlushTime(long lastFlushTime) {
		this.lastFlushTime = lastFlushTime;
	}

	public List<MSItem> getItemList() {
		return itemList;
	}

	public void setItemList(List<MSItem> itemList) {
		this.itemList = itemList;
	}

	public Human getOwner() {
		return owner;
	}

}
