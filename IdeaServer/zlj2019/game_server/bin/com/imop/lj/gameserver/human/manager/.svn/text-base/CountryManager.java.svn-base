package com.imop.lj.gameserver.human.manager;

import net.sf.json.JSONObject;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.human.Country;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;

/**
 * 国家管理
 * 
 * @author xiaowei.liu
 * 
 */
public class CountryManager implements JsonPropDataHolder {
	public static final String COUNTRY_KEY = "country";
	private Human owner;
	private Country country = Country.WU;
	
	
	public CountryManager(Human human) {
		this.owner = human;
	}

	@Override
	public String toJsonProp() {
		JSONObject obj = new JSONObject();
		obj.put(COUNTRY_KEY, country.getIndex());
		return obj.toString();
	}

	@Override
	public void loadJsonProp(String value) {
		if(value == null || value.isEmpty()){
			Loggers.countryLogger.error("CountryManager.loadJsonProp country info is empty!!! humanId = " + owner.getUUID());
			return;
		}
		
		JSONObject obj = JSONObject.fromObject(value);
		if(obj == null || obj.isEmpty()){
			Loggers.countryLogger.error("CountryManager.loadJsonProp country info is empty!!! humanId = " + owner.getUUID());
		}
		
		int countryId = JsonUtils.getInt(obj, COUNTRY_KEY);
		country = Country.valueOf(countryId);
		country = country == null ? Country.WU : country;
	}

	/**
	 * 推荐国家
	 * 
	 * @param country
	 */
	public boolean recommendCountry(Country country) {
		if(this.hasCountry()){
			return false;
		}
		
		this.country = country;
		owner.setModified();
		return true;
	}
	
	public boolean hasCountry(){
		return owner.getCountryType() == Country.WEI || owner.getCountryType() == Country.SHU || owner.getCountryType() == Country.WU;
	}

	public Country getCountry() {
		return country;
	}
}
