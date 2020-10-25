package com.imop.lj.gameserver.reward.subreward;

import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.TipsUtil;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.reward.ISubReward;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef.RewardAddedType;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;
import com.imop.lj.gameserver.reward.RewardKeyDefine;
import com.imop.lj.gameserver.reward.RewardParam;
import com.imop.lj.gameserver.reward.template.RewardTemplate;

/**
 * 货币类型奖励
 * 
 * @author xiaowei.liu
 * 
 */
public class CurrencySubReward extends AbstractSubReward {
	private Map<Currency, Integer> map = new LinkedHashMap<Currency, Integer>();
	
	public CurrencySubReward(Reward reward) {
		super(reward, RewardType.REWARD_CURRENCY);
	}
	
	/**
	 * 获取指定类型货币数量
	 * 
	 * @param currency
	 * @return
	 */
	public int getCurrencyNum(Currency currency){
		Integer num = this.map.get(currency);
		if(num == null){
			return 0;
		}else{
			return num;
		}
	}
	
	/**
	 * 创建货币类型奖励参数
	 * 
	 * @param currencyId
	 * @param num
	 * @return
	 */
	public static RewardParam createRewardParam(int currencyId, int num){
		RewardParam param = new RewardParam();
		param.setRewardType(RewardType.REWARD_CURRENCY);
		param.setParam1(currencyId);
		param.setParam2(num);
		return param;
	}
	
	@Override
	public boolean addReward(RewardParam param) {
		if(!this.checkParam(param)){
			return false;
		}
		
		Currency currency = Currency.valueOf(param.getParam1());
		int amount = param.getParam2();
		
		Integer curr = map.get(currency);
		if(curr == null){
			curr = 0;
		}
		
		if(curr > Integer.MAX_VALUE - amount){
			curr = Integer.MAX_VALUE;
		}else{
			curr += amount;
		}
		map.put(currency, curr);
		return true;
	}

	@Override
	public List<RewardParam> toRewardParamList() {
		List<RewardParam> list = new ArrayList<RewardParam>();
		for(Entry<Currency, Integer> entry : map.entrySet()){
			RewardParam param = new RewardParam();
			param.setRewardType(RewardType.REWARD_CURRENCY);
			param.setParam1(entry.getKey().getIndex());
			param.setParam2(entry.getValue());
			list.add(param);
		}
		return list;
	}

	@Override
	public boolean giveReward(Human human, boolean needNotify) {
		for(Entry<Currency, Integer> entry : map.entrySet()){
			boolean flag = human.giveMoney(entry.getValue(), entry.getKey(), needNotify, reward.getReasonType().getMoneyLogReason(), reward.getParams());
			if (!flag) {
				// 记录警告日志，玩家没有得到对应的奖励
				Loggers.rewardLogger.warn("#CurrencySubReward#giveReward#giveMoney return false!humanId=" + 
						human.getUUID() + ";reward reason=" + reward.getReasonType() + ";reward=" + reward.getRewardString());
			}
		}
		return true;
	}


	@Override
	public ISubReward createEmptySubReward(Reward reward) {
		return new CurrencySubReward(reward);
	}

	@Override
	public boolean checkParam(RewardParam param) {
		int currencyId = param.getParam1();
		Currency currency = Currency.valueOf(currencyId);

		// 非法货币
		if (currency == null || currency == Currency.NULL) {
			return false;
		}

		int amount = param.getParam2();

		// TODO 以后要对奖励上限进行配置，目前只校验货币数值合法性，如果数量小于等于0返回非法
		if (amount <= 0) {
			return false;
		}

		return true;
	}

	@Override
	public String checkTemplate(RewardTemplate tmpl) {
		int currencyId = tmpl.getParam1();
		Currency currency = Currency.valueOf(currencyId);

		// 非法货币
		if (currency == null || currency == Currency.NULL) {
			return "货币类型 = " + currencyId + " 非法";
		}

		int amount = tmpl.getParam2();

		// TODO 以后要对奖励上限进行配置，目前只校验货币数值合法性，如果数量小于等于0返回非法
		if (amount <= 0) {
			return "货币数量 <= 0， 值 = " + amount;
		}

		return null;

	}

	@Override
	public String getRewardString() {
		StringBuffer sb = new StringBuffer();
		int size = this.map.size();
		int i = 0;
		for(Entry<Currency, Integer> entry : this.map.entrySet()){
			Currency currency = entry.getKey();
			int amount = entry.getValue();
			
			sb.append(Globals.getLangService().readSysLang(currency.getNameKey()));
			sb.append(TipsUtil.CONNECT_STR3);
			sb.append(amount);
			
			if(i < size - 1){
				sb.append(TipsUtil.CONNECT_STR1);
			}
			i++;
		}
		return sb.toString();
	}

	@Override
	public String getMsgString() {
		JSONArray array = new JSONArray();
		for(Entry<Currency, Integer> entry : this.map.entrySet()){
			JSONObject obj = new JSONObject();
			obj.put(RewardKeyDefine.CURRENCY_TYPE_KEY, entry.getKey().getIndex());
			obj.put(RewardKeyDefine.CURRENCY_VALUE_KEY, entry.getValue());
			array.add(obj);
		}
		return array.toString();
	}

	@Override
	public void amend(Map<RewardAddedType, Integer> amendMap) {
		if (amendMap == null || amendMap.isEmpty()) {
			return;
		}

		Integer goldAmend = amendMap.get(RewardAddedType.GOLD);
		if (goldAmend == null || goldAmend <= 0) {
			return;
		}

		Integer gold = map.get(Currency.GOLD);
		if (gold == null) {
			return;
		}

		double goldAdded = 1 + (double)goldAmend / Globals.getGameConstants().getScale();
		goldAdded = goldAdded > Globals.getGameConstants().getGoldAmendUpper() ? Globals.getGameConstants().getGoldAmendUpper() : goldAdded;
		
		gold = (int) (gold * goldAdded);
		this.map.put(Currency.GOLD, gold);
	}

	@Override
	public boolean giveCorpsReward(Corps corps, boolean needNotify) {
		return false;
	}

}
