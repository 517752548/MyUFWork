package com.imop.lj.gameserver.allocate.model;

import java.util.Map;
import java.util.Map.Entry;

import com.google.common.collect.Maps;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.item.template.ItemTemplate;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

public class AllocateActivityStorageData{
	
	public static final String MEMBER_LIST = "memberList";
	public static final String ITEM_LIST = "itemList";

	/** Map<玩家Id, 分配成员信息>*/
	private Map<Long, AllocateMemberData> allocateMemberMap = Maps.newHashMap();;
	/** Map<道具Id, 分配道具信息>*/
	private Map<Integer, AllocateItemData> allocateItemMap = Maps.newHashMap();
	
	
	public Map<Long, AllocateMemberData> getAllocateMemberMap() {
		return allocateMemberMap;
	}
	public void setAllocateMemberMap(Map<Long, AllocateMemberData> allocateMemberMap) {
		for(Entry<Long, AllocateMemberData> entry : allocateMemberMap.entrySet()){
			this.allocateMemberMap.put(entry.getKey(), entry.getValue());	
		}
		
	}
	public Map<Integer, AllocateItemData> getAllocateItemMap() {
		return allocateItemMap;
	}
	public void setAllocateItemMap(Map<Integer, AllocateItemData> allocateItemMap) {
		for(Entry<Integer, AllocateItemData> entry : allocateItemMap.entrySet()){
			this.allocateItemMap.put(entry.getKey(), entry.getValue());	
		}
	};
	
	public String toJson() {
		JSONObject obj = new JSONObject();
		//玩家情况
		JSONArray arrMember = new JSONArray();
		for(AllocateMemberData data : allocateMemberMap.values()){
			arrMember.add(data.toJsonProp());
		}
		obj.put(MEMBER_LIST, arrMember.toString());
		
		//总道具情况
		JSONArray arrItem = new JSONArray();
		for(AllocateItemData data : allocateItemMap.values()){
			arrItem.add(data.toJsonProp());
		}
		obj.put(ITEM_LIST, arrItem.toString());
		return obj.toString();
	}
	
	
	public AllocateActivityStorageData fromJson(String value) {
		if(value == null || value.isEmpty()){
			return null;
		}
		
		JSONObject obj = JSONObject.fromObject(value);
		if(obj == null || obj.isEmpty()){
			return null;
		}
		
		AllocateActivityStorageData data = new AllocateActivityStorageData();
		
		//玩家情况
		String memberStr = obj.getString(MEMBER_LIST);
		if(memberStr == null || memberStr.isEmpty()){
			return null;
		}
		JSONArray arrMember = JSONArray.fromObject(memberStr);
		if(arrMember == null || arrMember.isEmpty()){
			return null;
		}
		
		for(int i=0; i<arrMember.size(); i++){
			String json = arrMember.getString(i);
			AllocateMemberData memberData = AllocateMemberData.fromJson(json);
			data.allocateMemberMap.put(memberData.getRoleId(), memberData);
		}
		
		//总道具情况
		String itemStr = obj.getString(ITEM_LIST);
		if(itemStr == null || itemStr.isEmpty()){
			return null;
		}
		JSONArray arrItem = JSONArray.fromObject(itemStr);
		if(arrMember == null || arrMember.isEmpty()){
			return null;
		}
		if(arrItem == null || arrItem.isEmpty()){
			return null;
		}
		
		for(int i=0; i<arrItem.size(); i++){
			String json = arrItem.getString(i);
			AllocateItemData itemData = AllocateItemData.fromJson(json);
			data.allocateItemMap.put(itemData.getItemId(), itemData);
		}
		
		return data;
	}
	@Override
	public String toString() {
		return "AllocateActivityStorageData [getAllocateMemberMap()=" + getAllocateMemberMap()
				+ ", getAllocateItemMap()=" + getAllocateItemMap() + ", toJson()=" + toJson() + "]";
	}
	
	 
	
	
}
