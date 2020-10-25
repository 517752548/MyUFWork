package com.imop.lj.gameserver.equip;

import java.util.ArrayList;
import java.util.List;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.equip.template.CraftEquipCostTemplate;
import com.imop.lj.gameserver.human.JsonPropDataHolder;
import com.imop.lj.gameserver.item.feature.AbstractEquipFeature;
import com.imop.lj.gameserver.item.template.EquipItemAttribute;

/**
 * 装备属性管理，附加属性
 * 
 */
public class EquipAttrManager implements JsonPropDataHolder {
	public static final String ADD_ATTR = "ad";
	public static final String BIND_ATTR = "bi";
	
	/** 所属装备 */
	private AbstractEquipFeature feature;

	/** 基础属性，从配置表读取 */
	private EquipItemAttribute baseAttr = new EquipItemAttribute();
	/** 附加属性 */
	private List<EquipItemAttribute> addAttrList = new ArrayList<EquipItemAttribute>();
	/** 绑定属性，生成装备时随出来，装备变为绑定状态后，前台显示，未绑定时，前台显示问号 */
	private EquipItemAttribute bindAttr = new EquipItemAttribute();
	
	public EquipAttrManager(AbstractEquipFeature feature) {
		this.feature = feature;
	}
	
	/**
	 * 根据颜色和阶数创建一件装备
	 */
	public void onCreate(CraftEquipCostTemplate costTpl, int[] itemNumArr) {
		Globals.getEquipService().onCreateEquip(feature, costTpl, itemNumArr);
	}
	
	private void init() {
		//如果是固定属性的装备，则直接根据配置表得出
		if (isFixedAttr()) {
			//初始化附加属性
			EquipHelper.genFixedAttrEquip(feature);
		} else {
			//初始化基础属性，基础属性直接根据配置表计算得出
			setBaseAttr(EquipHelper.genBaseAttr(feature.getEquipItemTemplate(), feature.getGrade()));
		}
	}
	
	/**
	 * 获取基础属性的附加值
	 * 目前只有装备升星值
	 * @return
	 */
	public int getBaseAttrExtraAdd() {
		int add = 0;
		//穿着的装备
		if (feature.getWearLeader() != null) {
			//星级加成
			add = (int)Globals.getEquipService().calcEquipPosStarAddProp(feature.getWearLeader(), 
					feature.getPosition(), getBaseAttr().getPropValue());
		}
		return add;
	}
	
	public String getAddAttrJsonStr() {
		JSONArray array = new JSONArray();
		for(EquipItemAttribute e : this.addAttrList) {
			array.add(e.toJson());
		}
		return array.toString();
	}
	
	@Override
	public String toJsonProp() {
		JSONObject json = new JSONObject();
		
		JSONArray array = new JSONArray();
		//非固定装备，属性是生成的，所以要解析；固定装备直接读配置表
		if (!isFixedAttr()) {
			//解析附加属性
			for(EquipItemAttribute e : this.addAttrList) {
				array.add(e.toJson());
			}
		}
		//附加属性
		json.put(ADD_ATTR, array);
		//绑定属性
		json.put(BIND_ATTR, this.bindAttr.toJson());
		
		return json.toString();
	}
	
	@Override
	public void loadJsonProp(String value) {
		//初始化
		this.init();
		//固定属性的装备，不用解析，直接从配置表得出
		if (isFixedAttr()) {
			return;
		}
		
		if (value == null || value.isEmpty()) {
			Loggers.itemLogger.error("EquipAttrManager.loadJsonProp value = null, humanId = " + feature.getItem().getOwner().getUUID());
			return;
		}
		
		JSONObject json = JSONObject.fromObject(value);
		if (json == null || json.isNullObject() || json.isEmpty()) {
			Loggers.itemLogger.error("EquipAttributeManager.loadJsonProp json=null, humanId = " + feature.getItem().getOwner().getUUID());
			return;
		}
		
		//附加属性
		JSONArray array = JsonUtils.getJSONArray(json, ADD_ATTR);
		if (array != null) {
			int size = array.size();
			for (int i = 0; i < size; i++) {
				String str = array.getString(i);
				EquipItemAttribute e = EquipItemAttribute.fromJson(str);
				if (e != null) {
					this.addAttrList.add(e);
				} else {
					Loggers.itemLogger.error("EquipAttributeManager some json str is invalid!humanId = " + feature.getItem().getOwner().getUUID());
				}
			}
		} else {
			//非固定装备，附加属性不应该为空
			Loggers.itemLogger.error("EquipAttributeManager.loadJsonProp array = null, humanId = " + feature.getItem().getOwner().getUUID());
		}
		
		//绑定属性
		String bindStr = JsonUtils.getString(json, BIND_ATTR);
		if (bindStr != null && !bindStr.isEmpty()) {
			EquipItemAttribute bindAttr = EquipItemAttribute.fromJson(bindStr);
			if (bindAttr != null) {
				this.setBindAttr(bindAttr);
			} else {
				Loggers.itemLogger.error("EquipAttributeManager.loadJsonProp bindAttr is null, humanId = " + feature.getItem().getOwner().getUUID());
			}
		}
	}
	
	/**
	 * 设置当前附加属性
	 * 
	 * @param list
	 */
	public void replaceAddAttr(List<EquipItemAttribute> list) {
		if (list == null) {
			return;
		}
		
		this.addAttrList.clear();
		if (!list.isEmpty()) {
			this.addAttrList.addAll(list);
		}
		this.feature.getItem().setModified();
	}

	public AbstractEquipFeature getFeature() {
		return feature;
	}

	public List<EquipItemAttribute> getAddAttrList() {
		return addAttrList;
	}
	
	public boolean isFixedAttr() {
		return feature.getEquipItemTemplate().isFixedEquip();
	}

	public EquipItemAttribute getBaseAttr() {
		return baseAttr;
	}
	
	public void setBaseAttr(EquipItemAttribute baseAttr) {
		this.baseAttr = baseAttr;
	}

	public int getAddAttrNum() {
		return addAttrList.size();
	}
	
	public EquipItemAttribute getBindAttr() {
		return bindAttr;
	}

	public void setBindAttr(EquipItemAttribute bindAttr) {
		if (bindAttr != null) {
			this.bindAttr = bindAttr;
		}
	}

	/**
	 * 复制属性
	 * @param source
	 */
	public void copy(EquipAttrManager source) {
		//基础属性
		this.baseAttr.setPropKey(source.getBaseAttr().getPropKey());
		this.baseAttr.setPropValue(source.getBaseAttr().getPropValue());
		//绑定属性
		this.bindAttr.setPropKey(source.getBindAttr().getPropKey());
		this.bindAttr.setPropValue(source.getBindAttr().getPropValue());
		//附加属性
		for (EquipItemAttribute ea : source.getAddAttrList()) {
			EquipItemAttribute thisEA = new EquipItemAttribute(ea.getPropKey(), ea.getPropValue());
			this.addAttrList.add(thisEA);
		}
	}
}
