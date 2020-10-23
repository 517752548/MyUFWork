package com.imop.lj.gameserver.offlinedata;

import java.util.Map;
import java.util.Map.Entry;

import net.sf.json.JSONObject;

import com.google.common.collect.Maps;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.container.PetEquipBag;
import com.imop.lj.gameserver.item.feature.EquipFeature;
import com.imop.lj.gameserver.item.feature.ItemFeature;
import com.imop.lj.gameserver.item.template.EquipItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;

public class EquipRelatedManager {
	private static final String EQUIP_KEY = "eq";
	private static final String STAR_KEY = "st";
//	private static final String GEM_KEY = "ge";
	
	private static final String ITEM_ID_KEY = "tid";
	private static final String ITEM_FEATURE_KEY = "ft";
	
	private UserSnap owner;

	/** Map<装备位，装备属性> */
	private Map<Position, EquipFeature> equipMap = Maps.newHashMap();
	
	/** 武将装备位星级<装备位，星级> */
	private Map<Position, Integer> starMap = Maps.newHashMap();
	
//	/** 武将装备位已镶嵌的宝石<装备位，List<已镶嵌的宝石>> */
//	private Map<Position, List<GemItemTemplate>> gemMap = Maps.newHashMap();
	
	public EquipRelatedManager(UserSnap userSnap) {
		this.owner = userSnap;
	}
	
	public UserSnap getOwner() {
		return owner;
	}

	public void rebuildAll(Human human) {
		if (human == null || human.getPetManager() == null ||
				human.getPetManager().getLeader() == null) {
			return;
		}
		
		//构建装备
		rebuildEquip(human);
		
		//构建装备位星级
		rebuildStar(human);
		
//		//构建宝石
//		rebuildGem(human);
	}
	
	public void rebuildEquip(Human human) {
		if (human == null || human.getPetManager() == null ||
				human.getPetManager().getLeader() == null) {
			return;
		}
		
		PetEquipBag bag = human.getInventory().getBagByPet(human.getPetManager().getLeader().getUUID());
		
		equipMap.clear();
		for (Item item : bag.getAllItems()) {
			ItemFeature feature = item.getFeature();
			if (!(feature instanceof EquipFeature)) {
				continue;
			}
			
			//拷贝ItemFeature数据
			EquipFeature equipFeature = new EquipFeature(Item.newEmptyVirtualInstance(item.getTemplate()));
			equipFeature.copy((EquipFeature)feature);
			
			//放入map
			equipMap.put(equipFeature.getPosition(), equipFeature);
		}
	}
	
	public void rebuildStar(Human human) {
		if (human == null || human.getPetManager() == null ||
				human.getPetManager().getLeader() == null) {
			return;
		}
		
		starMap.clear();
		Position[] pArr = Position.values();
		for (int i = 0; i < pArr.length; i++) {
			Position p = pArr[i];
			int star = human.getPetManager().getLeader().getEquipStars(p);
			
			//放入mpa
			starMap.put(p, star);
		}
	}
	
//	public void rebuildGem(Human human) {
//		if (human == null || human.getPetManager() == null ||
//				human.getPetManager().getLeader() == null) {
//			return;
//		}
//		
//		PetGemBag gemBag = human.getInventory().getGemBagByPet(human.getPetManager().getLeader().getUUID());
//		Position[] pArr = Position.values();
//		int holeNum = Globals.getTemplateCacheService().getAll(GemOpenTemplate.class).size();
//		gemMap.clear();
//		for (int i = 0; i < pArr.length; i++) {
//			Position pos = pArr[i];
//			for (int j = 1; j <= holeNum; j++) {
//				//宝石不是按顺序镶嵌的，可跳着来
//				if (gemBag.hasGem(pos, j)) {
//					//这里只加镶嵌了的宝石
//					GemItemTemplate tpl = (GemItemTemplate)gemBag.getGem(pos, j).getTemplate();
//					//加入map
//					addGemMap(pos, tpl);
//				}
//			}
//		}
//	}
	
//	private void addGemMap(Position pos, GemItemTemplate tpl) {
//		List<GemItemTemplate> lt = gemMap.get(pos);
//		if (lt == null) {
//			lt = new ArrayList<GemItemTemplate>();
//			gemMap.put(pos, lt);
//		}
//		lt.add(tpl);
//	}
	
	private String equipToProps(boolean isShow) {
		JSONObject json = new JSONObject();
		for (Entry<Position, EquipFeature> entry : equipMap.entrySet()) {
			JSONObject subJson = new JSONObject();
			subJson.put(ITEM_ID_KEY, entry.getValue().getItemTemplateId());
			subJson.put(ITEM_FEATURE_KEY, entry.getValue().toProps(isShow));
			json.put(entry.getKey().getIndex(), subJson);
			
		}
		return json.toString();
	}
	
	private void equipFromProps(String str) {
		if (str == null || str.isEmpty()) {
			return;
		}
		JSONObject json = JSONObject.fromObject(str);
		if (json == null || json.isEmpty()) {
			return;
		}
		
		Position[] pArr = Position.values();
		for (int i = 0; i < pArr.length; i++) {
			Position p = pArr[i];
			JSONObject subJson = JsonUtils.getJSONObject(json, p.getIndex());
			if (subJson != null && !subJson.isEmpty()) {
				int tplId = JsonUtils.getInt(subJson, ITEM_ID_KEY);
				String fStr = JsonUtils.getString(subJson, ITEM_FEATURE_KEY);
				ItemTemplate tpl = Globals.getTemplateCacheService().get(tplId, ItemTemplate.class);
				if (tpl == null) {
					Loggers.offlineDataLogger.error("item not exist!tplId=" + tplId + ";humanId=" + getOwner().getCharId());
					continue;
				}
				
				EquipFeature ef = new EquipFeature(Item.newEmptyVirtualInstance(tpl));
				ef.fromPros(fStr);
				
				//放入map
				equipMap.put(p, ef);
			}
		}
	}
	
	private String starToProps() {
		JSONObject json = new JSONObject();
		for (Entry<Position, Integer> entry : starMap.entrySet()) {
			json.put(entry.getKey().getIndex(), entry.getValue());
		}
		return json.toString();
	}
	
	private void starFromProps(String str) {
		if (str == null || str.isEmpty()) {
			return;
		}
		JSONObject json = JSONObject.fromObject(str);
		if (json == null || json.isEmpty()) {
			return;
		}
		
		Position[] pArr = Position.values();
		for (int i = 0; i < pArr.length; i++) {
			Position p = pArr[i];
			int star = JsonUtils.getInt(json, p.getIndex());
			starMap.put(p, star);
		}
	}
	
//	private String gemToProps() {
//		JSONObject json = new JSONObject();
//		for (Entry<Position, List<GemItemTemplate>> entry : gemMap.entrySet()) {
//			List<GemItemTemplate> lst = entry.getValue();
//			JSONArray arrJson = new JSONArray();
//			for (GemItemTemplate tpl : lst) {
//				arrJson.add(tpl.getId());
//			}
//			json.put(entry.getKey().getIndex(), arrJson);
//		}
//		return json.toString();
//	}
	
//	private void gemFromProps(String str) {
//		if (str == null || str.isEmpty()) {
//			return;
//		}
//		JSONObject json = JSONObject.fromObject(str);
//		if (json == null || json.isEmpty()) {
//			return;
//		}
//		
//		Position[] pArr = Position.values();
//		for (int i = 0; i < pArr.length; i++) {
//			Position p = pArr[i];
//			JSONArray arrJson = JsonUtils.getJSONArray(json, p.getIndex());
//			if (arrJson != null && !arrJson.isEmpty()) {
//				List<GemItemTemplate> lst = new ArrayList<GemItemTemplate>();
//				for (int j = 0; j < arrJson.size(); j++) {
//					int tplId = arrJson.getInt(j);
//					ItemTemplate tpl = Globals.getTemplateCacheService().get(tplId, ItemTemplate.class);
//					if (tpl == null) {
//						Loggers.offlineDataLogger.error("item not exist!tplId=" + tplId + ";humanId=" + getOwner().getCharId());
//						continue;
//					}
//					if (!tpl.isGem() || !(tpl instanceof GemItemTemplate)) {
//						Loggers.offlineDataLogger.error("item not a gem!tplId=" + tplId + ";humanId=" + getOwner().getCharId());
//						continue;
//					}
//					lst.add((GemItemTemplate)tpl);
//				}
//				
//				//放入map
//				gemMap.put(p, lst);
//			}
//		}
//	}
	
	public String toProps(boolean isShow) {
		JSONObject json = new JSONObject();
		json.put(EQUIP_KEY, equipToProps(isShow));
		json.put(STAR_KEY, starToProps());
//		json.put(GEM_KEY, gemToProps());
		return json.toString();
	}
	
	public void fromProps(String str) {
		if (str == null || str.isEmpty()) {
			return;
		}
		JSONObject json = JSONObject.fromObject(str);
		if (json == null || json.isEmpty()) {
			return;
		}
		
		equipFromProps(JsonUtils.getString(json, EQUIP_KEY));
		starFromProps(JsonUtils.getString(json, STAR_KEY));
//		gemFromProps(JsonUtils.getString(json, GEM_KEY));
	}
	
	/**
	 * 获取主将武器模板
	 * @return
	 */
	public EquipItemTemplate getLeaderWeaponTpl() {
		EquipFeature ef = this.equipMap.get(Position.WEAPON);
		if (ef != null) {
			return ef.getEquipItemTemplate();
		}
		return null;
	}
}
