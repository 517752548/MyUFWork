package com.imop.lj.gameserver.common;

import java.text.MessageFormat;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.model.CurrencyInfo;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.item.ItemDef.Rarity;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.pet.PetDef.PetQuality;
import com.imop.lj.gameserver.reward.Reward;

public class TipsUtil {
	public final static String CONNECT_STR1 = "，";
	public final static String CONNECT_STR2 = "*";
	public final static String CONNECT_STR3 = "+";
	public final static int ROLE_LINK_EVENT = 1;
	
	public final static String ITEM_LINK_PATTERN = "<color=\"{0}\"><a href=\"event:2-{1}\"><u>{2}</u></a></color>";
	public final static String ITEM_PATTERN = "{0}*{1}";
	public final static String ITEM_LINK_BY_TEMPID_PATTERN = "<color=\"{0}\"><a href=\"event:4-{1}\"><u>{2}</u></a></color>";
	public final static int FUNC_LINK_KEY = 103;

	/**
	 * 获得礼包的描述字符串
	 * 
	 * @param reward
	 * @return
	 */
	public static String getRewardString(Reward reward) {
		return reward.getRewardString();
	}

	/**
	 * 获得奖励中道具的描述字符串
	 * 
	 * @param reward
	 * @return
	 */
	public static String getRewardItemString(Reward reward) {
		return reward.getRewardItemString();
	}
	
	/**
	 * 去掉最后一个连接符
	 * @param strRaw
	 * @param connStr
	 * @return
	 */
	public static String trimLastConnStr(String strRaw, String connStr) {
		String str = strRaw;
		if (strRaw.length() > 0) {
			int lastIndex = strRaw.lastIndexOf(connStr);
			if ((lastIndex + connStr.length()) == strRaw.length()) {
				str = strRaw.substring(0, lastIndex);
			}
		}
		return str;
	}
	
	/**
	 * 获取指定颜色的字符串
	 * 
	 * @param str
	 * @param color
	 * @return
	 */
	public static String getStrByColor(String str, String color) {
		String pattern = Globals.getLangService().readSysLang(LangConstants.NAME_PATTERN);
		return MessageFormat.format(pattern, color, str);
	}

	/**
	 * 获取连接
	 * 
	 * @param key
	 * @param value
	 * @param color
	 * @return
	 */
	public static String getLinkByKeyAndValueAndColor(Integer event , String key, String value, String color){
		String pattern = Globals.getLangService().readSysLang(LangConstants.LINK_PATTERN);
		return MessageFormat.format(pattern, color, value);
	}
	/**
	 * 获取带颜色的货币名称和数量
	 * 
	 * @param temp
	 * @return
	 */
	public static String getNameNumByCurrencyTemplate(CurrencyInfo temp) {
		if(temp == null){
			return "";
		}
		Currency currency = Currency.valueOf(temp.getCurrencyType());
		if(currency == null){
			return "";
		}
		String pattern = Globals.getLangService().readSysLang(LangConstants.NAME_PATTERN);
		String name = Globals.getLangService().readSysLang(currency.getNameKey());
		
		PetQuality quality = PetQuality.WHITE;
//		if(Currency.BLUE_HUFU.getIndex() == temp.getCurrencyType()){
//			quality = PetQuality.BLUE;
//		}else if(Currency.PURPLE_HUFU.getIndex() == temp.getCurrencyType()){
//			quality = PetQuality.PURPLE;
//		}else if(Currency.GOLDED_HUFU.getIndex() == temp.getCurrencyType()){
//			quality = PetQuality.GOLDEN;
//		}else{
//			quality = PetQuality.WHITE;
//		}
		
		name = MessageFormat.format(pattern, quality.getColor(), name);
		String num = MessageFormat.format(pattern, quality.getColor(), Long.toString(temp.getNum()));
		return name + " " + num;
	}
	
	/**
	 * 获取带颜色的货币数量和货币
	 * 
	 * @param temp
	 * @return
	 */
	public static String getNumNameByCurrencyTemplate(CurrencyInfo temp) {
		if(temp == null){
			return "";
		}
		Currency currency = Currency.valueOf(temp.getCurrencyType());
		if(currency == null){
			return "";
		}
		String pattern = Globals.getLangService().readSysLang(LangConstants.NAME_PATTERN);
		String name = Globals.getLangService().readSysLang(currency.getNameKey());
		
		String color = "";
//		if(Currency.BLUE_HUFU.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.BLUE.color;
//		}else if(Currency.PURPLE_HUFU.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.PURPLE.color;
//		}else if(Currency.GOLDED_HUFU.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.GOLDEN.color;
//		}else if(Currency.ORANGE_HUFU.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.ORANGE.color;
//		}else if(Currency.HERO_SOUL.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.GOLDEN.color;
//		}else if(Currency.SWORD_SOUL.getIndex() == temp.getCurrencyType()){
//			// 通用剑气没有对应的品质
//			color = "#66FFFF";
//		}else if(Currency.SWORD_SOUL1.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.WHITE.color;
//		}else if(Currency.SWORD_SOUL2.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.GREEN.color;
//		}else if(Currency.SWORD_SOUL3.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.BLUE.color;
//		}else if(Currency.SWORD_SOUL4.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.PURPLE.color;
//		}else if(Currency.SWORD_SOUL5.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.GOLDEN.color;
//		}else if(Currency.SWORD_SOUL6.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.ORANGE.color;
//		}else if(Currency.SWORD_SOUL7.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.RED.color;
//		}else{
			color = PetQuality.WHITE.color;
//		}
		
		name = MessageFormat.format(pattern, color, name);
		String num = MessageFormat.format(pattern, color, Long.toString(temp.getNum()));
		return num + " " + name;
	}
	
	/**
	 * 获取带颜色的货币数量和货币
	 * 
	 * @param temp
	 * @return
	 */
	public static String getNumNameByCurrencyTemplate(CurrencyInfo temp, boolean enough) {
		if(temp == null){
			return "";
		}
		Currency currency = Currency.valueOf(temp.getCurrencyType());
		if(currency == null){
			return "";
		}
		String pattern = Globals.getLangService().readSysLang(LangConstants.NAME_PATTERN);
		String name = Globals.getLangService().readSysLang(currency.getNameKey());
		
		String color = "";
//		if(Currency.BLUE_HUFU.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.BLUE.color;
//		}else if(Currency.PURPLE_HUFU.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.PURPLE.color;
//		}else if(Currency.GOLDED_HUFU.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.GOLDEN.color;
//		}else if(Currency.ORANGE_HUFU.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.ORANGE.color;
//		}else if(Currency.HERO_SOUL.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.GOLDEN.color;
//		}else if(Currency.SWORD_SOUL.getIndex() == temp.getCurrencyType()){
//			// 通用剑气没有对应的品质
//			color = "#66FFFF";
//		}else if(Currency.SWORD_SOUL1.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.WHITE.color;
//		}else if(Currency.SWORD_SOUL2.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.GREEN.color;
//		}else if(Currency.SWORD_SOUL3.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.BLUE.color;
//		}else if(Currency.SWORD_SOUL4.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.PURPLE.color;
//		}else if(Currency.SWORD_SOUL5.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.GOLDEN.color;
//		}else if(Currency.SWORD_SOUL6.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.ORANGE.color;
//		}else if(Currency.SWORD_SOUL7.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.RED.color;
//		}else{
			color = PetQuality.WHITE.color;
//		}
		
		name = MessageFormat.format(pattern, color, name);
		String num = "";
		if(enough){
			num = MessageFormat.format(pattern, PetQuality.GREEN.color, Long.toString(temp.getNum()));
		}else{
			num = MessageFormat.format(pattern, PetQuality.ORANGE.color, Long.toString(temp.getNum()));
		}
		return num + " " + name;
	}
	
	/**
	 * 获取带颜色的货币数量和货币
	 * 
	 * @param temp
	 * @return
	 */
	public static String getNameByCurrencyTemplate(Currency currency) {
		if(currency == null){
			return "";
		}
		
		String pattern = Globals.getLangService().readSysLang(LangConstants.NAME_PATTERN);
		String name = Globals.getLangService().readSysLang(currency.getNameKey());
		
		String color = "";
//		if(Currency.BLUE_HUFU.getIndex() == currency.index){
//			color = PetQuality.BLUE.color;
//		}else if(Currency.PURPLE_HUFU.getIndex() == currency.index){
//			color = PetQuality.PURPLE.color;
//		}else if(Currency.GOLDED_HUFU.getIndex() == currency.index){
//			color = PetQuality.GOLDEN.color;
//		}else if(Currency.ORANGE_HUFU.getIndex() == currency.index){
//			color = PetQuality.ORANGE.color;
//		}else if(Currency.HERO_SOUL.getIndex() == currency.index){
//			color = PetQuality.GOLDEN.color;
//		}else if(Currency.SWORD_SOUL.getIndex() == currency.index){
//			// 通用剑气没有对应的品质
//			color = "#66FFFF";
//		}else if(Currency.SWORD_SOUL1.getIndex() == currency.index){
//			color = PetQuality.WHITE.color;
//		}else if(Currency.SWORD_SOUL2.getIndex() == currency.index){
//			color = PetQuality.GREEN.color;
//		}else if(Currency.SWORD_SOUL3.getIndex() == currency.index){
//			color = PetQuality.BLUE.color;
//		}else if(Currency.SWORD_SOUL4.getIndex() == currency.index){
//			color = PetQuality.PURPLE.color;
//		}else if(Currency.SWORD_SOUL5.getIndex() == currency.index){
//			color = PetQuality.GOLDEN.color;
//		}else if(Currency.SWORD_SOUL6.getIndex() == currency.index){
//			color = PetQuality.ORANGE.color;
//		}else if(Currency.SWORD_SOUL7.getIndex() == currency.index){
//			color = PetQuality.RED.color;
//		}else{
			color = PetQuality.WHITE.color;
//		}
		
		name = MessageFormat.format(pattern, color, name);
		return name;
	}
	
	/**
	 * 获取带颜色的货币数量和货币
	 * 
	 * @param temp
	 * @return
	 */
	public static String getNumNameSpecByCurrencyTemplate(CurrencyInfo temp) {
		if(temp == null){
			return "";
		}
		Currency currency = Currency.valueOf(temp.getCurrencyType());
		if(currency == null){
			return "";
		}
		String pattern = Globals.getLangService().readSysLang(LangConstants.NAME_PATTERN);
		String name = Globals.getLangService().readSysLang(currency.getNameKey());
		
		String color = "";
//		if(Currency.BLUE_HUFU.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.BLUE.color;
//		}else if(Currency.PURPLE_HUFU.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.PURPLE.color;
//		}else if(Currency.GOLDED_HUFU.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.GOLDEN.color;
//		}else if(Currency.ORANGE_HUFU.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.ORANGE.color;
//		}else if(Currency.HERO_SOUL.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.GOLDEN.color;
//		}else if(Currency.SWORD_SOUL.getIndex() == temp.getCurrencyType()){
//			// 通用剑气没有对应的品质
//			color = "#66FFFF";
//		}else if(Currency.SWORD_SOUL1.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.WHITE.color;
//		}else if(Currency.SWORD_SOUL2.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.GREEN.color;
//		}else if(Currency.SWORD_SOUL3.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.BLUE.color;
//		}else if(Currency.SWORD_SOUL4.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.PURPLE.color;
//		}else if(Currency.SWORD_SOUL5.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.GOLDEN.color;
//		}else if(Currency.SWORD_SOUL6.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.ORANGE.color;
//		}else if(Currency.SWORD_SOUL7.getIndex() == temp.getCurrencyType()){
//			color = PetQuality.RED.color;
//		}else{
			color = PetQuality.WHITE.color;
//		}
		
		name = MessageFormat.format(pattern, color, name);
		String num = MessageFormat.format(pattern, color, Long.toString(temp.getNum()));
		return num + "【" + name+ "】";
	}
	
	/**
	 * 获取玩家名字链接
	 * 
	 * @param roleId
	 * @return
	 */
	public static String getRoleLinkStr(long humanId){
		UserSnap snap = Globals.getOfflineDataService().getUserSnap(humanId);
		if(snap == null){
			return "";
		}
		
		String name = snap.getName();
		//人名默认是绿色
		PetQuality pq = PetQuality.GREEN;
		name = TipsUtil.getLinkByKeyAndValueAndColor(ROLE_LINK_EVENT, snap.getCharId() + "", snap.getName(), pq.getColor());
		return name;
	}
	
	public static String getNameStrWithDefaultColor(String name) {
		return getStrByColor(name, PetQuality.GREEN.getColor());
	}
	
	/**
	 * 根据模版ID获取物品链接
	 * 
	 * @param uuid
	 * @param itemId
	 * @param num
	 * @return
	 */
	public static String getItemLinkStr(String uuid, int itemId, int num){
		ItemTemplate it = Globals.getTemplateCacheService().get(itemId, ItemTemplate.class);
		String name = "";
		String color = Rarity.WHITE.getColor();
		if(it != null){
			if(num == 0){
				name = it.getName();
			}else{
				name = MessageFormat.format(ITEM_PATTERN, it.getName(), num);
			}
			color = it.getRarity().getColor();
		}
		
		return MessageFormat.format(ITEM_LINK_PATTERN, color, uuid, name);
	}
	
	public static String getItemLinkStrByTempId(int itemId, int num){
		ItemTemplate it = Globals.getTemplateCacheService().get(itemId, ItemTemplate.class);
		String name = "";
		String color = Rarity.WHITE.getColor();
		if(it != null){
			if(num == 0){
				name = it.getName();
			}else{
				name = MessageFormat.format(ITEM_PATTERN, it.getName(), num);
			}
			color = it.getRarity().getColor();
		}
		
		return MessageFormat.format(ITEM_LINK_BY_TEMPID_PATTERN, color, String.valueOf(itemId), name);
	}
	
	/**
	 * 根据模版ID获取名字
	 * 
	 * @param tempId
	 * @return
	 */
	public static String getItemNameById(int tempId) {
		ItemTemplate it = Globals.getTemplateCacheService().get(tempId,
				ItemTemplate.class);
		if (it == null) {
			return "";
		}

		return getStrByColor(it.getName(), it.getRarity().getColor());
	}
	
	public static String getItemNameByTemp(ItemTemplate it){
		if(it == null){
			return "";
		}
		
		return getStrByColor(it.getName(), it.getRarity().getColor());
	}
	
	public static String getTipsByLangId(int langId, Object... objs){
		String pattern = Globals.getLangService().readSysLang(langId);
		if(pattern == null){
			return "";
		}
		
		return MessageFormat.format(pattern, objs);
	}
}
