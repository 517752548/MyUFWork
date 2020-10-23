package com.imop.lj.gameserver.offlinedata;

import java.util.Map;
import java.util.Map.Entry;

import net.sf.json.JSONArray;

import com.google.common.collect.Maps;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.pet.Pet;

/**
 * 武将离线数据管理
 * 
 */
public class PetSnapManager {
	private UserSnap userSnap;
	
	/** 所有宠物 petID,Snap*/
	private Map<Long, PetBattleSnap> petMap = Maps.newHashMap();
	
	public PetSnapManager(UserSnap userSnap) {
		this.userSnap = userSnap;
	}

	/**
	 * 重新创建武将数据
	 * 
	 * @param human
	 */
	public void rebuild(Human human) {
		if(human == null){
			return ;
		}
		
		petMap.clear();
		
		for(Pet pet : human.getPetManager().getAllPet()){
			PetBattleSnap pbs = new PetBattleSnap();
			pbs.init(pet);
			this.petMap.put(pet.getUUID(), pbs);
		}
		this.userSnap.setModified();
	}

	/**
	 * 通过JSON初始化
	 * 
	 * @param armies
	 */
	public void fromJson(String armies) {
		if (armies == null || armies.isEmpty()) {
			return;
		}
		
		JSONArray jsonArr = JSONArray.fromObject(armies);
		if (jsonArr == null || jsonArr.isEmpty()) {
			return;
		}
		
		petMap.clear();
		
		for (int i = 0; i < jsonArr.size(); i++) {
			PetBattleSnap snap = PetBattleSnap.fromJson(jsonArr.getString(i));
			if (snap != null) {
				this.petMap.put(snap.getPetId(), snap);
			}
		}
	}

	/**
	 * 转换为JSON
	 * 
	 * @return
	 */
	public String toJson() {
		JSONArray array = new JSONArray();
		for(Entry<Long,PetBattleSnap> entry : petMap.entrySet()){
			array.add(entry.getValue().toJson(false));
		}
		return array.toString();
	}
	
	
//	/**
//	 * 更换出战宠物（点击出战、休息时调用）
//	 * @param pet
//	 */
//	public void onChangeFightPet(Pet pet) {
//		if(pet == null || pet.getOwner() == null){
//			return ;
//		}
//		rebuild(pet.getOwner());
//	}

	/**
	 * 当修改武将时
	 * 
	 * @param pet
	 */
	public void onUpdatePet(Pet pet) {
		if(pet == null){
			return ;
		}
		if(this.petMap.containsKey(pet.getUUID())){
			this.petMap.get(pet.getUUID()).init(pet);
		}
		this.userSnap.setModified();
	}
	
	public PetBattleSnap getLeader() {
		for(Entry<Long,PetBattleSnap> snap : this.petMap.entrySet()){
			if(snap.getValue().isLeader()){
				return snap.getValue() ;
			}
		}
		return null;
	}

//	public PetBattleSnap getFightPet() {
//		for(Entry<Long,PetBattleSnap> snap : this.petMap.entrySet()){
//			if(snap.getValue().isFightPet()){
//				return snap.getValue() ;
//			}
//		}
//		return null;
//	}
	
	public void onAddPet(Pet pet) {
		if(pet == null){
			return ;
		}
		if(!this.petMap.containsKey(pet.getUUID())){
			return;
		}
		PetBattleSnap pbs = new PetBattleSnap();
		pbs.init(pet);
		petMap.put(pet.getUUID(), pbs);
		this.userSnap.setModified();
	}
	
	public void onSaveOrUpdatePet(Pet pet) {
		if(pet == null){
			return ;
		}
		if(this.petMap.containsKey(pet.getUUID())){
			this.petMap.get(pet.getUUID()).init(pet);
			this.userSnap.setModified();
			return;
		}
		PetBattleSnap pbs = new PetBattleSnap();
		pbs.init(pet);
		petMap.put(pet.getUUID(), pbs);
		this.userSnap.setModified();
	}
	
	public void onDeletePet(Pet pet) {
		if(pet == null){
			return ;
		}
		petMap.remove(pet.getUUID());
	}

	public Map<Long, PetBattleSnap> getPetMap() {
		return petMap;
	}
	
	public PetBattleSnap getPetById(long petId) {
		return petMap.get(petId);
	}
}
