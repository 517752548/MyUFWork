package com.imop.lj.gameserver.cache.template;

import java.util.Collections;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.model.item.CommonItem;
import com.imop.lj.core.template.TemplateService;

/**
 * 物品模版缓存
 * 
 * @author xiaowei.liu
 * 
 */
public class ItemTemplateCache implements InitializeRequired {
	
//	/** 策划模板，战甲套装的长度必须是3个 */
//	private final static int ARMOUR_SUIT_LIST_SIZE = 3;
//	private TemplateService service;
	
//	/**宝石{宝石类型：{宝石级别：宝石模版}} */
//	private Map<ItemType, Map<Integer, GemItemTemplate>> gemMap;
//	/** 宝石类型集合{宝石类型:按级别排好序的宝石模版列表 } */
//	private Map<ItemType, List<GemItemTemplate>> gemTypeMap;
//	/**宝物组Map{组ID：宝物列表}*/
//	private Map<Integer, List<TreasureItemTemplate>> treasureGroupMap;
	/** 
	 * 战甲 套装
	 * key 	: suitId
	 * value: List<Integer> itemIds;
	 */
	private Map<Integer, List<CommonItem>> armourSuitMap;
	
	public ItemTemplateCache(TemplateService service){
//		this.service = service;
	}
	@Override
	public void init() {
//		//初始化宝石模版
//		this.initGemMap();
//		//初始化宝石类型信息
//		this.initGemTypeMap();
//		//宝物组
//		this.initTreasureGroupMap();
//		// 战甲
//		this.initArmorSuitEquipTemplate();
	}
	
//	private void initGemMap(){
//		this.gemMap = new HashMap<ItemType, Map<Integer,GemItemTemplate>>();
//		for(ItemTemplate temp : service.getAll(ItemTemplate.class).values()){
//			if(!temp.isGem()){
//				continue;
//			}
//			
//			//按类型
//			Map<Integer, GemItemTemplate> levelMap = gemMap.get(temp.getItemType());
//			if(levelMap == null){
//				levelMap = new HashMap<Integer, GemItemTemplate>();
//				this.gemMap.put(temp.getItemType(), levelMap);
//			}
//			
//			GemItemTemplate gemTemp = (GemItemTemplate)temp;
//			levelMap.put(gemTemp.getLevel(), gemTemp);
//		}
//		
//		//检查
//		for(ItemTemplate temp : service.getAll(ItemTemplate.class).values()){
//			if(!temp.isGem()){
//				continue;
//			}
//			
//			GemItemTemplate gemTemp = (GemItemTemplate)temp;
//			if(gemTemp.getLevel() >= Globals.getGameConstants().getGemMaxLevel()){
//				continue;
//			}
//			
//			GemItemTemplate nextTemp = this.getGemItemTemplate(gemTemp.getItemType(), gemTemp.getLevel() + 1);
//			if(nextTemp == null){
//				throw new TemplateConfigException("宝石", gemTemp.getId(), "下一级宝石不存在");
//			}
//			
//			gemTemp.setNextLevelGemTemp(nextTemp);
//		}
//	}
//	
//	/**
//	 * 初始化宝石类型集合
//	 */
//	private void initGemTypeMap() {
//		this.gemTypeMap = new HashMap<ItemType, List<GemItemTemplate>>();
//		for(Entry<ItemType, Map<Integer, GemItemTemplate>> entry : this.gemMap.entrySet()){
//			ItemType it = entry.getKey();
//			Map<Integer, GemItemTemplate> levelMap  = entry.getValue();
//			List<GemItemTemplate> list = new ArrayList<GemItemTemplate>();
//			list.addAll(levelMap.values());
//			Collections.sort(list);
//			
//			this.gemTypeMap.put(it, list);
//		}
//	}
//	
//	/**
//	 * 初始化宝物组
//	 */
//	private void initTreasureGroupMap(){
//		this.treasureGroupMap = new HashMap<Integer, List<TreasureItemTemplate>>();
//		for(ItemTemplate temp : service.getAll(ItemTemplate.class).values()){
//			if(!(temp instanceof TreasureItemTemplate)){
//				continue;
//			}
//			
//			TreasureItemTemplate treasure = (TreasureItemTemplate) temp;
//			if(treasure.getGroupId() == 0){
//				continue;
//			}
//			
//			List<TreasureItemTemplate> list = this.treasureGroupMap.get(treasure.getGroupId());
//			if(list == null){
//				list = new ArrayList<TreasureItemTemplate>();
//				this.treasureGroupMap.put(treasure.getGroupId(), list);
//			}
//			
//			list.add(treasure);
//		}
//		
//		// 添加到宝物模版中
//		for(ItemTemplate temp : service.getAll(ItemTemplate.class).values()){
//			if(!(temp instanceof TreasureItemTemplate)){
//				continue;
//			}
//			
//			TreasureItemTemplate treasure = (TreasureItemTemplate) temp;
//			if(treasure.getGroupId() == 0){
//				continue;
//			}
//			
//			List<TreasureItemTemplate> list = this.treasureGroupMap.get(treasure.getGroupId());
//			for(TreasureItemTemplate treasureTemp : list){
//				if(temp.getId() != treasureTemp.getId()){
//					treasure.getConvertList().add(treasureTemp);
//				}
//			}
//		}
//
//		// 检查
//		for(ItemTemplate temp : service.getAll(ItemTemplate.class).values()){
//			if(!(temp instanceof TreasureItemTemplate)){
//				continue;
//			}
//			
//			TreasureItemTemplate treasure = (TreasureItemTemplate) temp;
//			if(treasure.getGroupId() == 0){
//				continue;
//			}
//			
//			if(treasure.getConvertList().size() != 3){
//				throw new TemplateConfigException(temp.getSheetName(), temp.getId(), "转换组数量错误");
//			}
//		}
//	}
//	
//	/**
//	 * 初始化战甲套装
//	 */
//	private void initArmorSuitEquipTemplate() {
//		
//		armourSuitMap = new HashMap<Integer, List<CommonItem>>();
//		
//		ArmourItemTemplate armourItemTemplate = null;
//		CommonItem commonItem = null;
//		for(ItemTemplate temp : service.getAll(ItemTemplate.class).values()){
//			if(!temp.isArmour()) {
//				continue;
//			}
//			armourItemTemplate = (ArmourItemTemplate)temp;
//			if(!armourItemTemplate.isArmour() || armourItemTemplate.getSetId() == 0) {
//				continue;
//			}
//			
//			List<CommonItem> suitList = armourSuitMap.get(armourItemTemplate.getSetId());
//			if(null == suitList) {
//				suitList = new ArrayList<CommonItem>();
//				armourSuitMap.put(armourItemTemplate.getSetId(), suitList);
//			}
//			commonItem = CommonItemHelper.createCommonItem(armourItemTemplate.getId());
//			if(null == commonItem) {
//				throw new TemplateConfigException(temp.getSheetName(), temp.getId(), "战甲套装配置未找到套装中的物品");
//			}
//			if(!suitList.contains(commonItem)) {
//				suitList.add(commonItem);
//			}
//			
//		}
//		// for check，检查套装的长度是不是3个物品组成
//		for(List<CommonItem> suitItemList : armourSuitMap.values()) {
//			if(suitItemList.size() == 0) {
//				throw new TemplateConfigException("物品表战甲配置错误！", 0, "战甲套装个数不能为0！");
//			}
//			if(suitItemList.size() != ARMOUR_SUIT_LIST_SIZE) {
//				throw new TemplateConfigException("物品表战甲配置错误！", 0, "战甲套装个数错误！");
//			}
//		}
//		
//		// 检查战甲套装是否有对应的套装
//		ArmourSuitAttrTemplate suitTemp = null;
//		for(int suitId : armourSuitMap.keySet()) {
//			suitTemp = templateService.get(suitId, ArmourSuitAttrTemplate.class);
//			if(null == suitTemp) {
//				throw new TemplateConfigException("物品表战甲配置错误！", suitId, "未找到对应的战甲套装配置！");
//			}
//		}
//	
//	}
//	
//	/**
//	 * 根据类型和等级查询宝石模版
//	 * 
//	 * @param type
//	 * @param gemLevel
//	 * @return
//	 */
//	private GemItemTemplate getGemItemTemplate(ItemType type, int gemLevel){
//		if(this.gemMap == null || this.gemMap.isEmpty()){
//			return null;
//		}
//		
//		Map<Integer, GemItemTemplate> levelMap = this.gemMap.get(type);
//		if(levelMap ==  null){
//			return null;
//		}
//		
//		return levelMap.get(gemLevel);
//	}
//	
//	public Map<ItemType, List<GemItemTemplate>> getGemTypeMap() {
//		return gemTypeMap;
//	}
	
	/**
	 * 通过套装id取套装的各个装备的模板id
	 * @param suitId
	 * @return
	 */
	public List<CommonItem> getArmourSuitList(int suitId) {
		if( armourSuitMap.containsKey(suitId)) {
			return Collections.unmodifiableList(armourSuitMap.get(suitId));
		}
		return Collections.emptyList();
	}
	
	public Map<Integer, List<CommonItem>> getArmourSuitMap() {
		return Collections.unmodifiableMap(armourSuitMap);
	}
	
}
