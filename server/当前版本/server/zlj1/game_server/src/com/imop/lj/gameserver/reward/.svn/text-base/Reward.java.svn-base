package com.imop.lj.gameserver.reward;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.reward.RewardInfo;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.TipsUtil;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.reward.RewardDef.RewardAddedFromType;
import com.imop.lj.gameserver.reward.RewardDef.RewardAddedType;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;
import com.imop.lj.gameserver.reward.subreward.CurrencySubReward;
import com.imop.lj.gameserver.reward.subreward.ExpLeaderSubReward;
import com.imop.lj.gameserver.reward.subreward.ItemSubReward;

/**
 * 奖励对象
 * 
 * @author xiaowei.liu
 * 
 */
public class Reward {
	public static final String REWARD_UUID_KEY = "uuid";
	public static final String REWARD_INFO_KEY = "info";
	public static final String REASON_TYPE_KEY = "type";
	public static final String PARAMS_KEY = "params";
	public static final String REWARD_ADDED_KEY = "added";
	public static final String REWARD_ADDED_FROM_KEY = "addedfrom";
	public static final String REWARD_ADDED_CONTENT_KEY = "addedCon";
	public static final String REWARD_ADDED_TYPE_KEY = "addedType";
	public static final String REWARD_ADDED_VALUE_KEY = "addedValue";
	
	/** 奖励唯一标识 */
	private String uuid;
	/** 子奖励集合 */
	private Map<Integer, ISubReward> subRewardMap;
	/** 加成Map {加成来源：{加成类型：加成值}}*/
	private Map<RewardAddedFromType, Map<RewardAddedType, Integer>> amendMap;
	/** 奖励来源 */
	protected RewardReasonType reasonType;
	/** 目前存储内容：奖励模板,需要存储的log内容，合并奖励对象uuid集合(此属性只有在合并是才会生成) */
	private String params;

	Reward() {
		uuid = "";
		subRewardMap = new LinkedHashMap<Integer, ISubReward>();
		reasonType = RewardReasonType.NULL_REWARD;
		params = "";
	}

	/**
	 * 奖励是否为空
	 * 
	 * @return
	 */
	public boolean isNull() {
		if (this.reasonType == null || reasonType == RewardReasonType.NULL_REWARD) {
			return true;
		}
		return false;
	}

	/**
	 * 获取指定货币的数量
	 * 
	 * @param currency
	 * @return
	 */
	public int getCurrencyNum(Currency currency){
		ISubReward subReward = subRewardMap.get(RewardType.REWARD_CURRENCY.getIndex());
		if(subReward == null){
			return 0;
		}
		
		if(!(subReward instanceof CurrencySubReward)){
			return 0;
		}
		
		CurrencySubReward currencyReward = (CurrencySubReward)subReward;
		return currencyReward.getCurrencyNum(currency);
	}
	
	/**
	 * 是否有指定品质的物品
	 * 
	 * @param rarityId
	 * @return
	 */
	public boolean hasRarityItem(int rarityId) {
		ISubReward subReward = subRewardMap.get(RewardType.REWARD_ITEM.getIndex());
		if(subReward == null){
			return false;
		}
		
		if(!(subReward instanceof ItemSubReward)){
			return false;
		}
		
		ItemSubReward itemReward = (ItemSubReward)subReward;
		return itemReward.hasRarityItem(rarityId);
	}
	
	/**
	 * 是否包含道具奖励
	 * @return
	 */
	public boolean hasItem() {
		ISubReward subReward = subRewardMap.get(RewardType.REWARD_ITEM.getIndex());
		if(subReward == null){
			return false;
		}
		
		if(!(subReward instanceof ItemSubReward)){
			return false;
		}
		
		ItemSubReward itemReward = (ItemSubReward)subReward;
		return !itemReward.getItemData().isEmpty();
	}
	
	/**
	 * 获取道具数据
	 * @return
	 */
	public Map<Integer, Integer> getItemMap() {
		ISubReward subReward = subRewardMap.get(RewardType.REWARD_ITEM.getIndex());
		if(subReward == null){
			return null;
		}
		
		if(!(subReward instanceof ItemSubReward)){
			return null;
		}
		
		ItemSubReward itemReward = (ItemSubReward)subReward;
		return itemReward.getItemData();
	}

	/**
	 * 生成奖励信息
	 * 
	 * @return
	 */
	public RewardInfo toRewardInfo() {
		RewardInfo rewardInfo = new RewardInfo();
		JSONObject obj = new JSONObject();
		JSONArray array = new JSONArray();
		for(Entry<Integer, ISubReward> entry : this.subRewardMap.entrySet()){
			JSONObject temp = new JSONObject();
			temp.put(RewardKeyDefine.REWARD_TYPE_KEY, entry.getKey());
			temp.put(RewardKeyDefine.REWARD_CONTENT_KEY, entry.getValue().getMsgString());
			array.add(temp);
		}
		obj.put(RewardKeyDefine.REWARD_INFO_KEY, array.toString());
		
		// 添加奖励加成
		obj.put(RewardKeyDefine.REWARD_ADDED_INFO_KEY, getRewardAddedStr());
		rewardInfo.setRewardStr(obj.toString());
		return rewardInfo;
	}
	
	private String getRewardAddedStr(){
		if(this.amendMap == null || this.amendMap.isEmpty()){
			return "";
		}
		
		JSONArray array = new JSONArray();
		for(Entry<RewardAddedFromType, Map<RewardAddedType, Integer>> entry : this.amendMap.entrySet()){
			RewardAddedFromType from = entry.getKey();
			Map<RewardAddedType, Integer> map = entry.getValue();
			if(map.isEmpty()){
				continue;
			}
			
			JSONObject obj = new JSONObject();
			JSONArray addedArray = new JSONArray();
			for(Entry<RewardAddedType, Integer> addedEntry : map.entrySet()){
				JSONObject addedObj = new JSONObject();
				addedObj.put(RewardKeyDefine.REWARD_ADDED_TYPE_KEY, addedEntry.getKey().getIndex());
				addedObj.put(RewardKeyDefine.REWARD_ADDED_VALUE_KEY, addedEntry.getValue());
				addedArray.add(addedObj.toString());
			}
			obj.put(RewardKeyDefine.REWARD_ADDED_FROM_KEY, from.getIndex());
			obj.put(RewardKeyDefine.REWARD_ADDED_CONTENT_KEY, addedArray.toString());
			array.add(obj);
		}
		return array.toString();
	}

	public List<RewardParam> getRewardParamList(){
		List<RewardParam> list = new ArrayList<RewardParam>();
		for(ISubReward subReward : this.subRewardMap.values()){
			list.addAll(subReward.toRewardParamList());
		}
		return list;
	}
	
	/**
	 * 转化为JSON字符串
	 * 
	 * @return
	 */
	public String toJsonObj() {
		JSONObject obj = new JSONObject();
		List<RewardParam> list = this.getRewardParamList();
		JSONArray array = new JSONArray();
		for(RewardParam param : list){
			array.add(param.toJson());
		}
		obj.put(REWARD_UUID_KEY, uuid);
		obj.put(REWARD_INFO_KEY, array.toString());
		obj.put(REASON_TYPE_KEY, reasonType.getIndex());
		obj.put(PARAMS_KEY, params);
		
		obj.put(REWARD_ADDED_KEY, rewardAddedToJson());
		return obj.toString();
	}
	
	public String rewardAddedToJson(){
		if(this.amendMap == null || this.amendMap.isEmpty()){
			return "";
		}
		
		JSONArray array = new JSONArray();
		for(Entry<RewardAddedFromType, Map<RewardAddedType, Integer>> entry : this.amendMap.entrySet()){
			RewardAddedFromType from = entry.getKey();
			Map<RewardAddedType, Integer> map = entry.getValue();
			if(map.isEmpty()){
				continue;
			}
			
			JSONObject obj = new JSONObject();
			JSONArray addedArray = new JSONArray();
			for(Entry<RewardAddedType, Integer> addedEntry : map.entrySet()){
				JSONObject addedObj = new JSONObject();
				addedObj.put(REWARD_ADDED_TYPE_KEY, addedEntry.getKey().getIndex());
				addedObj.put(REWARD_ADDED_VALUE_KEY, addedEntry.getValue());
				addedArray.add(addedObj.toString());
			}
			obj.put(REWARD_ADDED_FROM_KEY, from.getIndex());
			obj.put(REWARD_ADDED_CONTENT_KEY, addedArray.toString());
			array.add(obj);
		}
		return array.toString();
	}

	/**
	 * 生成奖励对象
	 * 
	 * @param json
	 * @return
	 */
	public static Reward fromJsonStr(String json) {
		if(json == null || json.isEmpty()){
			return new Reward();
		}
		
		JSONObject obj = JSONObject.fromObject(json);
		if(obj == null || obj.isEmpty()){
			return new Reward();
		}
		
		String rewardInfo = JsonUtils.getString(obj, REWARD_INFO_KEY);
		if(rewardInfo == null || rewardInfo.isEmpty()){
			return new Reward();
		}
		
		JSONArray array = JSONArray.fromObject(rewardInfo);
		if(array == null || array.isEmpty()){
			return new Reward();
		}
		
		// 构建奖励
		String uuid = JsonUtils.getString(obj, REWARD_UUID_KEY);
		String params = JsonUtils.getString(obj, PARAMS_KEY);
		int type = JsonUtils.getInt(obj, REASON_TYPE_KEY);
		RewardReasonType reasonType = RewardReasonType.valueOf(type);
		if(reasonType == null || reasonType == RewardReasonType.NULL_REWARD){
			return new Reward();
		}
		
		boolean error = false;
		List<RewardParam> list = new ArrayList<RewardParam>();
		for (int i = 0; i < array.size(); i++) {
			String str = array.getString(i);
			RewardParam param = RewardParam.fromJson(str);
			if(param != null){
				list.add(param);
			}else{
				error = true;
			}
		}
		
		Reward reward = new Reward();
		reward.setReasonType(reasonType);
		reward.setUuid(uuid);
		reward.setParams(params);
		if(!reward.initReward(list)){
			error = true;
		}
		
		if(error){
			// 如果加载过程中发生了错误则记日志
			Loggers.rewardLogger.error("Reward.fromJsonStr error, json = " + json);
		}
		
		reward.addedFromJson(JsonUtils.getString(obj, REWARD_ADDED_KEY));
		return reward;
	}
	
	public void addedFromJson(String json){
		if(json == null || json.isEmpty()){
			return;
		}
			
		JSONArray array = JSONArray.fromObject(json);
		if(array == null || array.isEmpty()){
			return;
		}
		
		Map<RewardAddedFromType, Map<RewardAddedType, Integer>> map = new HashMap<RewardAddedFromType, Map<RewardAddedType,Integer>>();
		for (int i = 0; i < array.size(); i++) {
			String str = array.getString(i);
			JSONObject obj = JSONObject.fromObject(str);
			int from = JsonUtils.getInt(obj, REWARD_ADDED_FROM_KEY);
			RewardAddedFromType fromType = RewardAddedFromType.valueOf(from);
			if(fromType == null){
				continue;
			}
			
			JSONArray addedArray = JSONArray.fromObject(JsonUtils.getString(obj, REWARD_ADDED_CONTENT_KEY));
			Map<RewardAddedType, Integer> addedMap = new HashMap<RewardAddedType, Integer>();
			for(int j = 0; j < addedArray.size(); j++){
				String item = addedArray.getString(j);
				JSONObject itemObj = JSONObject.fromObject(item);
				if(itemObj == null || itemObj.isEmpty()){
					continue;
				}
				
				RewardAddedType addedType = RewardAddedType.valueOf(JsonUtils.getInt(itemObj, REWARD_ADDED_TYPE_KEY));
				if(addedType == null){
					continue;
				}
				int value = JsonUtils.getInt(itemObj, REWARD_ADDED_VALUE_KEY);
				
				addedMap.put(addedType, value);
			}
			
			if(!addedMap.isEmpty()){
				map.put(fromType, addedMap);
			}
		}
		
		this.amendMap = map;
	}
	
	/**
	 * 获得礼包的描述字符串
	 * 
	 * @param reward
	 * @return
	 */
	public String getRewardString(){
		StringBuilder sb = new StringBuilder();
		int size = this.subRewardMap.size();
		int i = 0;
		for(ISubReward subReward : this.subRewardMap.values()){
			sb.append(subReward.getRewardString());
			if(i < size - 1){
				sb.append(TipsUtil.CONNECT_STR1);
			}
			i++;
		}
		return sb.toString();
	}
	
	public String getRewardItemString(){
		ISubReward subReward = subRewardMap.get(RewardType.REWARD_ITEM.getIndex());
		if(subReward == null){
			return "";
		}
		
		if(!(subReward instanceof ItemSubReward)){
			return "";
		}
		
		ItemSubReward itemReward = (ItemSubReward)subReward;
		return itemReward.getRewardString();
	}
	
	/**
	 * 初始化奖励，在添加新的奖励时，会删除旧的，即所有奖励一次性添加
	 * 
	 * @param params
	 * @return
	 */
	public boolean initReward(List<RewardParam> params){
		Map<Integer, ISubReward> map = new LinkedHashMap<Integer, ISubReward>();
		//添加奖励
		for(RewardParam param : params){
			RewardType type = param.getRewardType();
			if(type == null){
				return false;
			}
			
			ISubReward subReward = map.get(type.getIndex());
			if(subReward == null){
				subReward = type.getSubReward().createEmptySubReward(this);
				map.put(type.getIndex(), subReward);
			}
			
			if(!subReward.addReward(param)){
				return false;
			}
		}
		
		// 所有都成功则替换当前奖励Map
		this.subRewardMap = map;
		return true;
	}

	/**
	 * 给个人奖励
	 * 
	 * @param human
	 * @param notify
	 * @return 给奖励失败返回false
	 */
	public boolean giveReward(Human human, boolean notify) {
		// 检查是否能全部给奖励
		boolean canGive = true;
		for(Entry<Integer, ISubReward> entry : this.subRewardMap.entrySet()){
			ISubReward subReward = entry.getValue();
			if(!subReward.canGiveReward(human, notify)){
				canGive = false;
				break;
			}
		}
		
		if(!canGive){
			return false;
		}
		
		for(Entry<Integer, ISubReward> entry : this.subRewardMap.entrySet()){
			ISubReward subReward = entry.getValue();
			if(!subReward.giveReward(human, notify)){
				// 仅仅记个日志，不做回滚处理
				Loggers.rewardLogger.error("#Reward#giveReward#subReward.giveReward return false!humanId=" + 
						human.getUUID() + ";subReward=" + subReward + ";reward uuid=" + uuid);
			}
		}
		
		return true;
	}
	
	/**
	 * 给个人奖励
	 * 
	 * @param corps
	 * @param notify
	 * @return
	 */
	public boolean giveCorpsReward(long corpsId, boolean notify) {
		Corps corps = Globals.getCorpsService().getCorpsById(corpsId);
		if(corps == null){
			return false;
		}
		for(Entry<Integer, ISubReward> entry : this.subRewardMap.entrySet()){
			ISubReward subReward = entry.getValue();
			if(!subReward.giveCorpsReward(corps, notify)){
				// TODO 仅仅记个日志，不做回滚处理
				Loggers.rewardLogger.error("#Reward#giveReward#subReward.giveCorpsReward return false!corpsId=" + 
						corps.getId() + ";subReward=" + subReward + ";reward uuid=" + uuid);
			}
		}
		
		return true;
	}
	
	/**
	 * 修正奖励
	 * 
	 * @param amendMap
	 */
	public void amend(Map<RewardAddedType, Integer> amendMap){
		for(ISubReward subReward : this.subRewardMap.values()){
			subReward.amend(amendMap);
		}
	}
	
	public void setReasonType(RewardReasonType reasonType) {
		this.reasonType = reasonType;
	}

	public RewardReasonType getReasonType() {
		return reasonType;
	}

	public String getParams() {
		return params;
	}

	public void setParams(String params) {
		this.params = params;
	}

	public void setUuid(String uuid) {
		this.uuid = uuid;
	}

	public String getUuid() {
		return uuid;
	}

	public Map<RewardAddedFromType, Map<RewardAddedType, Integer>> getAmendMap() {
		return amendMap;
	}

	public void setAmendMap(Map<RewardAddedFromType, Map<RewardAddedType, Integer>> amendMap) {
		this.amendMap = amendMap;
	}
	
	/**
	 * 获取reward中的exp值
	 * @return
	 */
	public int getRewardExp() {
		int exp = 0;
		ISubReward subReward = subRewardMap.get(RewardType.REWARD_LEADER_EXP.getIndex());
		if(subReward == null){
			return exp;
		}
		
		if(!(subReward instanceof ExpLeaderSubReward)){
			return exp;
		}
		
		ExpLeaderSubReward expReward = (ExpLeaderSubReward)subReward;
		exp = expReward.getExp();
		return exp;
	}
}
