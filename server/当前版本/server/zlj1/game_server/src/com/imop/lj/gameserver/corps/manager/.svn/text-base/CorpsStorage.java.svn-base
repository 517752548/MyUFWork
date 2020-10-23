package com.imop.lj.gameserver.corps.manager;

import java.text.MessageFormat;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Set;

import net.sf.json.JSONArray;

import com.google.common.collect.Lists;
import com.imop.lj.common.LogReasons.CorpsLogReason;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.corps.model.CorpsStorageItem;
import com.imop.lj.gameserver.item.template.ItemTemplate;

/**
 * 军团仓库
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsStorage {
	private Corps corps;
	private List<CorpsStorageItem> itemList = Lists.newArrayList();

	public CorpsStorage(Corps corps){
		this.corps = corps;
	}
	/**
	 * 通过JSON初始化军团仓库
	 * 
	 * @param json
	 */
	public boolean initCorpsStorage(String json) {
		//记录启动时的仓库数据
		String reason = CorpsLogReason.CORPS_STARTUP_INIT_STORAGE.getReasonText();
		String text = MessageFormat.format(reason, json);
		Globals.getCorpsService().sendCorpsLog(null, CorpsLogReason.CORPS_STARTUP_INIT_STORAGE, text, corps, null, null);
		
		if(json == null || json.isEmpty()){
			return false;
		}
		
		JSONArray array = JSONArray.fromObject(json);
		if(array == null || array.isEmpty()){
			return false;
		}
		
		int length = array.getInt(0);
		length = length > Globals.getGameConstants().getCorpsStorageCapacity() ? Globals.getGameConstants().getCorpsStorageCapacity() : length;
		
		for(int i=1; i<= length; i++){
			CorpsStorageItem item = CorpsStorageItem.createCorpsStorageItem(array.getString(i));
			if(item != null){
				this.itemList.add(item);
			}
		}
		return true;
		
	}

	/**
	 * 转换为JSON
	 * 
	 * @return
	 */
	public String toJSON() {
		JSONArray array = new JSONArray();
		array.add(this.itemList.size());
		for(CorpsStorageItem item : this.itemList){
			array.add(item.toJson());
		}
		return array.toString();
	}

	/**
	 * 添加物品（可部分添加）
	 * 
	 * @param itemList
	 * @return 未成功添加的部分
	 */
	public List<CorpsStorageItem> addItem(List<CorpsStorageItem> itemList) {
		if(itemList == null || itemList.isEmpty()){
			return null;
		}
		Iterator<CorpsStorageItem> it = itemList.iterator();
		while(it.hasNext()){
			if(this.isFull()){
				break;
			}
			
			CorpsStorageItem item = it.next();
			CorpsStorageItem addItem = item.copySelf();
			if(!this.canAdd(addItem)){
				break;
			}
			
			this.itemList.add(addItem);
			it.remove();
		}
		
		this.corps.setModified();
		//如果有溢出的物品
		if(!itemList.isEmpty()){
			StringBuffer sb = new StringBuffer();
			for(CorpsStorageItem item : itemList){
				sb.append(item.getItemTempId());
				sb.append(",");
				sb.append(item.getNum());
				sb.append("|");
			}
			Loggers.corpsLogger.error("CorpsStorage.addItem overflow item = " + sb.toString());
		}
		return itemList;
	}

	/**
	 * 是否可以添加
	 * 
	 * @param item
	 * @return
	 */
	public boolean canAdd(CorpsStorageItem item){	
		if (Globals.getTemplateCacheService().get(item.getItemTempId(),	ItemTemplate.class) == null) {
			return false;
		}

		if (item.getNum() <= 0) {
			return false;
		}
		return true;
	}
	/**
	 * 删除物品(必须全部成功)
	 */
	public boolean deleteItem(List<CorpsStorageItem> itemList) {
		//参数列表中不允许有重复下标
		Set<Integer> set = new HashSet<Integer>();
		for(CorpsStorageItem item : itemList){
			if(set.contains(item.getIndex())){
				return false;
			}else{
				set.add(item.getIndex());
			}
			
			if(!this.canDelete(item)){
				return false;
			}
		}
		
		for(CorpsStorageItem item : itemList){
			CorpsStorageItem temp = this.itemList.get(item.getIndex());
			if(!temp.reduceNum(item.getNum())){
				this.corps.setModified();
				return false;
			}
		}
		
		//去掉为0的物品
		Iterator<CorpsStorageItem> it = this.itemList.iterator();
		while(it.hasNext()){
			CorpsStorageItem removeItem = it.next();
			if(removeItem.getNum() <= 0){
				it.remove();
			}
		}
		
		this.corps.setModified();
		return true;
	}
	
	/**
	 * 检查索引
	 * 
	 * @param item
	 * @return
	 */
	public boolean canDelete(CorpsStorageItem item){
		if(item.getIndex() < 0 || item.getIndex() >= itemList.size()){
			//下标越界
			return false;
		}
		
		CorpsStorageItem temp = this.itemList.get(item.getIndex());
		if(temp.getNum() < item.getNum()){
			//数量不足
			return false;
		}
		
		if(temp.getItemTempId() != item.getItemTempId()){
			//物品各类不符合
			return false;
		}
		
		return true;
	}

	/**
	 * 是否已满
	 * 
	 * @return
	 */
	public boolean isFull() {
		return this.itemList.size() >= Globals.getGameConstants().getCorpsStorageCapacity();
	}
	
	public List<CorpsStorageItem> getItemList() {
		return itemList;
	}

}
