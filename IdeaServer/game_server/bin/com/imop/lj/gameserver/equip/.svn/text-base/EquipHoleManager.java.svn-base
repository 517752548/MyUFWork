package com.imop.lj.gameserver.equip;

import java.util.ArrayList;
import java.util.List;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.JsonPropDataHolder;
import com.imop.lj.gameserver.item.ItemDef.GemType;
import com.imop.lj.gameserver.item.feature.AbstractEquipFeature;

/**
 * 装备孔管理器，含镶嵌的宝石
 * @author yu.zhao
 *
 */
public class EquipHoleManager implements JsonPropDataHolder {
	public static final String HOLE_LIST = "hl";
	
	/** 所属装备 */
	private AbstractEquipFeature feature;
	
	//最大孔数，内存数据，通过配置计算得出
	private int maxHoleNum;
	
	/** 孔数据，含已开孔和镶嵌宝石数据 */
	private List<EquipHoleInfo> holeList = new ArrayList<EquipHoleInfo>();
	
	public EquipHoleManager(AbstractEquipFeature feature) {
		this.feature = feature;
	}
	
	public void init() {
		//初始化最大孔数
		int holeNum = Globals.getTemplateCacheService().getEquipTemplateCache().getMaxHoleNum(this.feature.getColor(), 
				this.feature.getEquipItemTemplate().getLevel());
		if (holeNum >= 0) {
			setMaxHoleNum(holeNum);
		}
	}
	
	public AbstractEquipFeature getFeature() {
		return feature;
	}

	public int getMaxHoleNum() {
		return maxHoleNum;
	}

	public void setMaxHoleNum(int maxHoleNum) {
		this.maxHoleNum = maxHoleNum;
	}

	public List<EquipHoleInfo> getHoleList() {
		return holeList;
	}
	
	public int getCurHoleNum() {
		return this.holeList.size();
	}

	@Override
	public String toJsonProp() {
		JSONObject json = new JSONObject();
		
		JSONArray jsonArr = new JSONArray();
		for (int i = 0; i < holeList.size(); i++) {
			jsonArr.add(holeList.get(i).toJsonProp());
		}
		
		json.put(HOLE_LIST, jsonArr);
		return json.toString();
	}

	@Override
	public void loadJsonProp(String value) {
		if (value == null || value.isEmpty()) {
			return;
		}
		JSONObject json = JSONObject.fromObject(value);
		if (json == null || json.isNullObject() || json.isEmpty()) {
			return;
		}
		
		JSONArray jsonArr = JsonUtils.getJSONArray(json, HOLE_LIST);
		if (jsonArr == null || jsonArr.isEmpty()) {
			return;
		}
		
		for (int i = 0; i < jsonArr.size(); i++) {
			String holeStr = jsonArr.getString(i);
			EquipHoleInfo info = new EquipHoleInfo();
			info.loadJsonProp(holeStr);
			if (info.getColor() != null && info.getColor() != GemType.NULL) {
				this.holeList.add(info);
			}
		}
		
	}
	
	public void copy(EquipHoleManager source) {
		//孔列表
		for (EquipHoleInfo sInfo : source.getHoleList()) {
			EquipHoleInfo info = new EquipHoleInfo();
			info.setColor(sInfo.getColor());
			info.setGemItemId(sInfo.getGemItemId());
			this.holeList.add(info);
		}
		
		//孔数
		this.maxHoleNum = source.getMaxHoleNum();
	}
	
}
