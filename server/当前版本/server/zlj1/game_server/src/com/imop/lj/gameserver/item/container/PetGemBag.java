package com.imop.lj.gameserver.item.container;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import com.imop.lj.common.LogReasons.ItemGenLogReason;
import com.imop.lj.common.LogReasons.ReasonDesc;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.RoleConstants;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.role.Role;

public class PetGemBag extends AbstractGemBag {

	public PetGemBag(Human owner, Role wearer) {
		super(owner, wearer, BagType.PET_GEM, RoleConstants.PET_GEM_BAG_CAPACITY);
	}
	
	/**
	 * 0-9 10-19 ..
	 */
	@Override
	public void init() {
		
		Integer times = 0;
		
		for(Position p : INDEX2POS){
			ArrayList<Integer> list = new ArrayList<Integer>();
			for(int i = 0; i<PetGemBag.subCapacity; i++){
				list.add(times * PetGemBag.subCapacity + i);
			}
			times ++ ;
			POS2INDEXMAP.put(p, list);
		}
	}
	
	
	public List<Item> getItemsByPosition(Position p){
		return super.getItemsByPosition(p);
	}
	
	public Position[] getPosition(){
		return PetGemBag.INDEX2POS;
	}
	
	public boolean hasGem(int index){
		if(index<0 || index >= RoleConstants.PET_GEM_BAG_CAPACITY){
			return false;
		}
		if(items[index] == null || items[index].isEmpty()){
			return false;
		}
		return true;
	}
	
	public boolean hasGem(Position p, Integer gemPosition){
		Integer subIndex = getSubIndexByGemPosition(gemPosition);
		if(!POS2INDEXMAP.containsKey(p)){
			return false;
		}
		if(subIndex<0 && subIndex>=subCapacity){
			return false ;
		}
		return hasGem(POS2INDEXMAP.get(p).get(subIndex));
	}
	
	public Item getGem(Position p, Integer gemPosition){
		Integer subIndex = getSubIndexByGemPosition(gemPosition);
		if(hasGem(p,gemPosition)){
			return items[POS2INDEXMAP.get(p).get(subIndex)];
		}
		return null;
	}
	/**
	 * 根据装备位和宝石位返回真实index
	 * @param p 1-11 Position
	 * @param gemPosition 1-10 subCapacity
	 * @return -1没有这个位置
	 */
	public static Integer getGemRealIndex(Position p, Integer gemPosition){
		Integer subIndex = getSubIndexByGemPosition(gemPosition);
		if(!POS2INDEXMAP.containsKey(p)){
			return -1;
		}
		if(subIndex<0 && subIndex>=subCapacity){
			return -1;
		}
		if(hasIndex(POS2INDEXMAP.get(p).get(subIndex))){
			return POS2INDEXMAP.get(p).get(subIndex);
		}
		return -1;
	}
	
	public static boolean hasIndex(Integer index){
		if(index<0 || index >= RoleConstants.PET_GEM_BAG_CAPACITY){
			return false;
		}
		return true;
	}
	private static Integer getSubIndexByGemPosition(Integer gemPosition){
		return gemPosition - 1 ;
	}
	/**
	 * 加一块宝石在身上的制定位置，to,对应位置的空格  这个方法只用与主将
	 * @param to
	 * @param T
	 * @param temp
	 * @param string 
	 * @param costItemForSetGem 
	 */
	public void addGem(Item to, ItemTemplate temp, ItemGenLogReason reason, String detailReason) {
		Item newItem = Globals.getItemService().newActivatedInstance(this.getOwner(), temp, to.getBagType(), to.getIndex(),1);
		newItem.setWearerId(this.getOwner().getPetManager().getLeader().getUUID());
		newItem.setModified();
		this.putItem(newItem);
//		this.getOwner().sendMessage(newItem.getUpdateMsgAndResetModify());
		newItem.updateItemWithCache();
		String genKey = "";
		try {
			do {
				// 记录道具产生日志
				genKey = KeyUtil.UUIDKey();
				Globals.getLogService().sendItemGenLog(owner, reason, detailReason, temp.getId(), temp.getName(), 1, 0, "", genKey);
				// 增加物品增加原因到reasonDetail
				String countChangeReason = " [genReason:" + reason.getClass().getField(reason.name()).getAnnotation(ReasonDesc.class).value() + "] ";
				detailReason = detailReason == null ? countChangeReason : detailReason + countChangeReason;
			} while (false);
		} catch (Exception e) {
			Loggers.itemLogger.error(LogUtils.buildLogInfoStr(owner.getUUID() + "", "记录向宝石包中在指定位置添加宝石日志时出错"), e);
		}
	}

	@Override
	public String toString() {
		return "PetGemBag [wearer=" + wearer + ", items=" + Arrays.toString(items) + ", owner=" + owner + ", bagType="
				+ bagType + "]";
	}
}
