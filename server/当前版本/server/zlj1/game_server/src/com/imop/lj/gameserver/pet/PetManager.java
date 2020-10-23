package com.imop.lj.gameserver.pet;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.imop.lj.common.HeartBeatListener;
import com.imop.lj.core.util.Assert;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.RoleDataHolder;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;
import com.imop.lj.gameserver.pet.PetDef.PetState;

/**
 * 玩家的武将管理器
 *
 */
public class PetManager implements RoleDataHolder, JsonPropDataHolder, HeartBeatListener {
	/**
	 * 所有武将集合包括主将、宠物、伙伴
	 */
	private Map<Long, Pet> allPets = new HashMap<Long, Pet>();
	
	/** 仅宠物的集合 */
	private Set<Long> petOnlySet = new HashSet<Long>();
	
	/** 仅伙伴的集合 */
	private Set<Long> friendOnlySet = new HashSet<Long>();
	
	/** 仅骑宠的集合 */
	private Set<Long> horseOnlySet = new HashSet<Long>();
	
	/** 主将 */
	private PetLeader leader;
//	/** 出战中的宠物Id，可为0 */
//	private long fightPetId;
	
//	/** 出战中的骑宠Id，可为0 */
//	private long ridingHorseId;
	
	/** 主人 */
	private Human owner;
	
	public PetManager(Human owner) {
		Assert.isTrue(owner != null);
		this.owner = owner;
	}
	
	public Human getOwner() {
		return owner;
	}
	
	public void addPet(Pet pet) {
		if (pet.isLeader()) {
			this.leader = (PetLeader)pet;
		} else if (pet.isPet()) {
			petOnlySet.add(pet.getUUID());
		} else if (pet.isFriend()) {
			friendOnlySet.add(pet.getUUID());
		} else if (pet.isHorse()) {
			horseOnlySet.add(pet.getUUID());
		}
		allPets.put(pet.getUUID(), pet);
		
	}
	
	public void removePet(Pet pet) {
		if (pet.isLeader()) {
			return;
		} else if (pet.isPet()) {
			petOnlySet.remove(pet.getUUID());
		} else if (pet.isFriend()) {
			friendOnlySet.remove(pet.getUUID());
		} else if (pet.isHorse()) {
			horseOnlySet.remove(pet.getUUID());
		}
		allPets.remove(pet.getUUID());
	}
	
	private void activeAllPets() {
		//武将的加成需考虑骑宠的部分转换加成,即先初始化骑宠,否则骑宠的加成会无效果.
		Iterator<Long> it = horseOnlySet.iterator();
		while(it.hasNext()){
			long horseId = (long)it.next();
			Pet petHorse = getPetByUuid(horseId);
			petHorse.initPropsAndActive();
		}
		
		for (Pet pet : allPets.values()) {
			//骑宠在上面已经处理过了
			if(pet.isHorse()){
				continue;
			}
			//加载主将时，校验并开启符合条件但未开启的技能
			if (pet.isLeader()) {
				Globals.getHumanSkillService().checkAndOpenNewSubSkill(pet.getOwner(), true);
			}
			pet.initPropsAndActive();
		}
	}
	
	public void updateProperty(int effectMask) {
		for (Pet pet : allPets.values()) {
			pet.getPropertyManager().updateProperty(effectMask);
		}
	}
	
	public List<Pet> getAllPet() {
		List<Pet> lst = new ArrayList<Pet>();
		lst.addAll(allPets.values());
		return lst;
	}
	
	public PetLeader getLeader() {
		return this.leader;
	}
	
//	/**
//	 * 获取出战中的宠物
//	 * @return
//	 */
//	public Pet getFightPet() {
//		if (this.fightPetId > 0) {
//			return getPetByUuid(this.fightPetId);
//		}
//		return null;
//	}
//	
//	public void setFightPetId(long fightPetId) {
//		this.fightPetId = fightPetId;
//	}
	
//	/**
//	 * 获取出战中的骑宠的模板Id，没有则为0
//	 * @return
//	 */
//	public int getRidingHorseTplId() {
//		int tplId = 0;
//		Pet pet = getRidingHorse();
//		if (pet != null) {
//			tplId = pet.getTemplateId();
//		}
//		return tplId;
//	}
//	/**
//	 * 获取出战中的骑宠
//	 * @return
//	 */
//	public Pet getRidingHorse() {
//		if (this.ridingHorseId > 0) {
//			return getPetByUuid(this.ridingHorseId);
//		}
//		return null;
//	}
//	
//	public void setRidingHorseId(long horseId) {
//		this.ridingHorseId = horseId;
//	}
	
	/**
	 * 获取拥有宠物的数量
	 * @return
	 */
	public int getOwnPetNum() {
		return petOnlySet.size();
	}
	
	public Set<Long> getPetPetIdList() {
		return petOnlySet;
	}
	
	/**
	 * 获取拥有伙伴的数量
	 * @return
	 */
	public int getOwnFriendNum() {
		return friendOnlySet.size();
	}
	
	/**
	 * 获取拥有的骑宠数量
	 * @return
	 */
	public int getOwnHorseNum() {
		return horseOnlySet.size();
	}
	
	public void load() {
		PetDbManager.getInstance().loadAllPetFromDB(this);
		
//		//设置角色形象为主将形象
//		this.owner.setPhoto(1);
	}
	
	/**
	 * 根据武将uuid获得武将
	 * @param uuid
	 * @return
	 */
	public Pet getPetByUuid(long uuid) {
		return this.allPets.get(uuid);
	}
	
	/**
	 * 根据武将UUID获得正常状态武将
	 * 
	 * @param uuid
	 * @return
	 */
	public Pet getNormalPetByUUID(long uuid){
		Pet pet = this.getPetByUuid(uuid);
		if(pet == null){
			return null;
		}
		
		if(pet.getPetState() == PetState.NORMAL.getIndex()){
			return pet;
		}else{
			return null;
		}
	}
	
	/**
	 * 根据模版ID获得武将
	 * 
	 * @param tempId
	 * @return
	 */
	public Pet getPetByTempId(int tempId){
		for(Pet pet : allPets.values()){
			if(pet.getTemplateId() == tempId){
				return pet;
			}
		}
		
		return null;
	}
	
	public boolean isLeader (long uuid) {
		return this.leader.getUUID() == uuid;
	}
	
	@Override
	public void checkBeforeRoleEnter() {
		
	}

	@Override
	public void loadJsonProp(String value) {
	}

	@Override
	public String toJsonProp() {
		return null;
	}

	@Override
	public void onHeartBeat() {
	}
	
	@Override
	public void checkAfterRoleLoad() {
		activeAllPets();
	}
}
