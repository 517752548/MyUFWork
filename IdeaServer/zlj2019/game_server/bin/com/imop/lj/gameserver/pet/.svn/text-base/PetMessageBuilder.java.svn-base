package com.imop.lj.gameserver.pet;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.model.pet.PetInfo;
import com.imop.lj.common.model.pet.PetSoulLinkInfo;
import com.imop.lj.common.model.pet.ShortcutInfo;
import com.imop.lj.common.model.pet.SkillEffectInfo;
import com.imop.lj.common.model.pet.SkillInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.ItemDef;
import com.imop.lj.gameserver.offlinedata.UserOfflineData;
import com.imop.lj.gameserver.offlinedata.UserPetData;
import com.imop.lj.gameserver.offlinedata.UserPetHorseData;
import com.imop.lj.gameserver.pet.PetDef.PetState;
import com.imop.lj.gameserver.pet.PetDef.PetType;
import com.imop.lj.gameserver.pet.msg.GCAddPet;
import com.imop.lj.gameserver.pet.msg.GCPetCurPropUpdate;
import com.imop.lj.gameserver.pet.msg.GCPetHorseCurPropUpdate;
import com.imop.lj.gameserver.pet.msg.GCPetHorseSoulLinkPet;
import com.imop.lj.gameserver.pet.msg.GCPetInfo;
import com.imop.lj.gameserver.pet.msg.GCPetList;
import com.imop.lj.gameserver.pet.msg.GCPetPoolUpdate;
import com.imop.lj.gameserver.pet.msg.GCPetSkillEffectUpdate;
import com.imop.lj.gameserver.pet.prop.PetAProperty;

/**
 * 武将消息构建
 * 
 */
public class PetMessageBuilder {
	/**
	 * 获取武将列表
	 * 
	 * @param human
	 * @return
	 */
	public static GCPetList getGCPetList(Human human) {
		GCPetList petList = new GCPetList();
		List<PetInfo> tempList = new ArrayList<PetInfo>();
		for(Pet pet : human.getPetManager().getAllPet()){
			if(pet.getPetState() != PetState.NORMAL.getIndex()){
				continue;
			}
			
			PetInfo info = createPetInfoFromPet(human, pet);
			tempList.add(info);
		}
		
		PetInfo[] array = new PetInfo[tempList.size()];
		tempList.toArray(array);
		petList.setPetInfoList(array);
		return petList;
	}
	
	public static GCPetHorseSoulLinkPet getGCPetSoulLinkList(Human human){
		GCPetHorseSoulLinkPet petList = new GCPetHorseSoulLinkPet();
		List<PetSoulLinkInfo> tempList = new ArrayList<PetSoulLinkInfo>();
		for(Pet pet : human.getPetManager().getAllPet()){
			if(pet.getPetState() != PetState.NORMAL.getIndex()){
				continue;
			}
			if(pet.getPetType() != PetType.PET){
				continue;
			}
			
			PetSoulLinkInfo info = new PetSoulLinkInfo();
			info.setPetId(pet.getUUID());
			info.setSoulLinkPetHorseId(Globals.getPetService().getSoulPetHorseByPetId(human.getCharId(), pet.getUUID()));
			tempList.add(info);
		}
		
		PetSoulLinkInfo[] array = new PetSoulLinkInfo[tempList.size()];
		tempList.toArray(array);
		petList.setPetSoulLinkInfoList(array);
		return petList;
	}
	
	/**
	 * 创建添加武将协议
	 * @param human
	 * @param pet
	 * 
	 * @return
	 */
	public static GCAddPet createGCAddPet(Human human, Pet pet){
		GCAddPet resp = new GCAddPet();
		resp.setPetInfo(createPetInfoFromPet(human, pet));
		return resp;
	}
	
	public static GCPetInfo buildGCPetInfoMsg(Human human, Pet pet) {
		PetInfo info = createPetInfoFromPet(human, pet);
		return new GCPetInfo(info);
	}
	
	/**
	 * 通过Pet创建PetInfo
	 * @param human
	 * @param pet
	 * 
	 * @return
	 */
	public static PetInfo createPetInfoFromPet(Human human, Pet pet) {
		PetInfo info = new PetInfo();
		if(pet == null){
			return info;
		}
		info.setPetId(pet.getUUID());
		info.setTplId(pet.getTemplateId());
		info.setLevel(pet.getLevel());
		info.setExp(pet.getExp());
		info.setStar(pet.getStar());
		info.setColorId(pet.getColor());
		info.setPetType(pet.getPetType().getIndex());
		
		List<SkillInfo> sl = new ArrayList<SkillInfo>();
		List<PetSkillInfo> sc = pet.getSkillList();
		for (PetSkillInfo s : sc) {
			sl.add(buildSkillInfo(s));
		}
		info.setSkillList(sl.toArray(new SkillInfo[0]));
		
		info.setAPropAddArr(getPetAPropAddArr(pet));
		info.setAEquipStar(getAEquipStar(pet));
		
		info.setTrainPropArr(getPetTrainPropArr(pet));
		info.setTrainTmpPropArr(getPetTrainTmpPropArr(pet));

		//增加宠物培养属性上限值
		info.setTrainMax(Globals.getPetService().getPetTrainPropMax(pet));
		
		info.setPropItemIndex(getPropItemIndex(pet));
		
		info.setPetScore(pet.getPetScore());
		info.setPetSkillBarNum(pet.getSkillBarNum());
		//快捷技能栏
		List<ShortcutInfo> shortcutInfos = new ArrayList<ShortcutInfo>();
		for(PetSkillShortcutInfo pssi : pet.getSkillShortcutMap().values()){
			shortcutInfos.add(buildShortcutInfo(pssi));
		}
		info.setShortcutList(shortcutInfos.toArray(new ShortcutInfo[0]));
		
		//灵魂链接骑宠Id
		if(human!= null && pet.getPetType() == PetType.PET){
			info.setSoulLinkPetHorseId(Globals.getPetService().getSoulPetHorseByPetId(human.getCharId(), pet.getUUID()));
		}else{
			info.setSoulLinkPetHorseId(0L);
		}
		
		return info;
	}
	
	public static int[] getPetAPropAddArr(Pet pet) {
		int[] aPropAddArr = new int[PetAProperty._END];
		for (int i = 0; i < PetAProperty._END; i++) {
			aPropAddArr[i] = pet.getAddAProp(i + 1);
		}
		return aPropAddArr;
	}
	
	public static int[] getAEquipStar(Pet pet) {
		int[] aEquipStar = new int[ItemDef.Position.values().length];
		if (pet.isLeader()) {
			PetLeader pl = (PetLeader)pet;
			int i = 0;
			for(ItemDef.Position p : ItemDef.Position.values()){
				aEquipStar[i] = pl.getEquipStars(p);
				i++;
			}
		}
		return aEquipStar;
	}
	
	public static int[] getPropItemIndex(Pet pet){
		int[] arr = new int[PetAProperty._END / 2];
		if (pet.isPet()) {
			PetPet pp = (PetPet)pet;
			for (int i = 0; i < PetAProperty._END / 2; i++) {
				arr[i] = pp.getPropItemIndex(PetAProperty._END / 2 + i + 1);
			}
		}
		if (pet.isHorse()) {
			PetHorse pp = (PetHorse)pet;
			for (int i = 0; i < PetAProperty._END / 2; i++) {
				arr[i] = pp.getPropItemIndex(PetAProperty._END / 2 + i + 1);
			}
		}
		return arr;
	}
	
	public static int[] getPetTrainPropArr(Pet pet) {
		int[] arr = new int[PetAProperty._END / 2];
		if (pet.isPet()) {
			PetPet pp = (PetPet)pet;
			for (int i = 0; i < PetAProperty._END / 2; i++) {
				arr[i] = pp.getTrainAddProp(i + 1);
			}
		}
		if(pet.isHorse()){
			PetHorse ph =(PetHorse)pet;
			for (int i = 0; i < PetAProperty._END / 2; i++) {
				arr[i] = ph.getTrainAddProp(i + 1);
			}
		}
		return arr;
	}
	
	public static int[] getPetTrainTmpPropArr(Pet pet) {
		int[] arr = new int[PetAProperty._END / 2];
		if (pet.isPet()) {
			PetPet pp = (PetPet)pet;
			for (int i = 0; i < PetAProperty._END / 2; i++) {
				arr[i] = pp.getLastTrainTempByKey(i + 1);
			}
		}
		if (pet.isHorse()) {
			PetHorse ph = (PetHorse)pet;
			for (int i = 0; i < PetAProperty._END / 2; i++) {
				arr[i] = ph.getLastTrainTempByKey(i + 1);
			}
		}
		return arr;
	}
	
	/**
	 * 创建消息用的武将技能信息
	 * @param psi
	 * @return
	 */
	public static SkillInfo buildSkillInfo(PetSkillInfo psi) {
		SkillInfo info = new SkillInfo();
		info.setLevel(psi.getLevel());
		info.setSkillId(psi.getSkillId());
		info.setSkillCost(Globals.getBattleService().getSkillCostValue(psi.getSkillId(), psi.getLevel()));
		
		//技能镶嵌效果列表
		List<SkillEffectInfo> lst = buildSkillEffectInfoList(psi);
		info.setEmbedSkillEffectList(lst.toArray(new SkillEffectInfo[0]));
		
		info.setLayer(psi.getLayer());
		info.setProficiency(psi.getProficiency());
		
		return info;
	}
	
	public static ShortcutInfo buildShortcutInfo(PetSkillShortcutInfo pssi){
		ShortcutInfo info = new ShortcutInfo();
		info.setSkillId(pssi.getSkillId());
		info.setShortcutIndex(pssi.getIndex());
		return info;
	}
	
	public static List<SkillEffectInfo> buildSkillEffectInfoList(PetSkillInfo psi) {
		//技能镶嵌效果列表
		List<SkillEffectInfo> lst = new ArrayList<SkillEffectInfo>();
		List<PetSkillEffectInfo> eLst = psi.getEmbedEffectList();
		for (PetSkillEffectInfo e : eLst) {
			SkillEffectInfo eInfo = new SkillEffectInfo();
			eInfo.setEffectItemId(e.getEffectItemTplId());
			eInfo.setLevel(e.getEffectLevel());
			eInfo.setExp(e.getEffectExp());
			lst.add(eInfo);
		}
		return lst;
	}
	
	public static GCPetCurPropUpdate buildGCPetCurPropUpdate(long roleId, long petId) {
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(roleId);
		UserPetData petData = offlineData.getPetData(petId);
		GCPetCurPropUpdate msg = new GCPetCurPropUpdate();
		//宠物
		if(petData != null){
			msg.setPetId(petId);
			msg.setHp((int)petData.getHp());
			msg.setMp((int)petData.getMp());
			msg.setLife((int)petData.getLife());
			msg.setSp((int)petData.getSp());
		}
		return msg;
	}
	
	public static GCPetHorseCurPropUpdate buildGCPetHorseCurPropUpdate(long roleId, long petId) {
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(roleId);
		UserPetHorseData petHorseData = offlineData.getPetHorseData(petId);
		GCPetHorseCurPropUpdate horseMsg = new GCPetHorseCurPropUpdate();
		if(petHorseData != null){
			horseMsg.setPetId(petId);
			horseMsg.setLoy((int)petHorseData.getLoy());
			horseMsg.setClo((int)petHorseData.getClo());
			horseMsg.setLife((int)petHorseData.getLife());
			horseMsg.setDeadline(petHorseData.getDeadline());
		}
		return horseMsg;
	}
	
	public static GCPetPoolUpdate buildGCPetPoolUpdate(long roleId) {
		GCPetPoolUpdate msg = new GCPetPoolUpdate();
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(roleId);
		msg.setHpPool(offlineData.getHpPool());
		msg.setMpPool(offlineData.getMpPool());
		msg.setLifePool(offlineData.getLifePool());
		return msg;
	}

	public static GCPetSkillEffectUpdate buildGCPetSkillEffectUpdate(PetSkillInfo info) {
		GCPetSkillEffectUpdate msg = new GCPetSkillEffectUpdate();
		msg.setSkillId(info.getSkillId());
		
		//技能镶嵌效果列表
		List<SkillEffectInfo> lst = buildSkillEffectInfoList(info);
		msg.setEmbedSkillEffectList(lst.toArray(new SkillEffectInfo[0]));
		
		return msg;
	}
}
