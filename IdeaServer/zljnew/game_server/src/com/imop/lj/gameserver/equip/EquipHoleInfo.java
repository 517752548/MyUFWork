package com.imop.lj.gameserver.equip;

import net.sf.json.JSONObject;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.JsonPropDataHolder;
import com.imop.lj.gameserver.item.ItemDef.GemType;
import com.imop.lj.gameserver.item.template.GemItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;

public class EquipHoleInfo implements JsonPropDataHolder {
	public static final String COLOR = "co";
	public static final String GEM_ITEM_ID = "gid";
	
	/** 孔颜色 */
	private GemType color = GemType.NULL;
	/** 镶嵌的宝石道具id */
	private int gemItemId;
	
	public GemType getColor() {
		return color;
	}
	
	public void setColor(GemType color) {
		this.color = color;
	}
	
	/**
	 * 获取宝石模板
	 * @return
	 */
	public GemItemTemplate getGemTpl() {
		if (this.gemItemId > 0) {
			ItemTemplate itemTpl = Globals.getTemplateCacheService().get(gemItemId, ItemTemplate.class);
			if (itemTpl != null && 
					itemTpl.isGem() && 
					(itemTpl instanceof GemItemTemplate)) {
				return (GemItemTemplate) itemTpl;
			}
		}
		return null;
	}
	
	public int getGemItemId() {
		return gemItemId;
	}
	
	public void setGemItemId(int gemItemId) {
		this.gemItemId = gemItemId;
	}
	
	@Override
	public String toJsonProp() {
		JSONObject json = new JSONObject();
		json.put(COLOR, this.color.getIndex());
		json.put(GEM_ITEM_ID, this.gemItemId);
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
		
		//颜色
		int cid = JsonUtils.getInt(json, COLOR);
		if (GemType.valueOf(cid) == null) {
			return;
		}
		setColor(GemType.valueOf(cid));
		
		//宝石id
		int itemId = JsonUtils.getInt(json, GEM_ITEM_ID);
		if (itemId > 0) {
			ItemTemplate itemTpl = Globals.getTemplateCacheService().get(itemId, ItemTemplate.class);
			if (itemTpl == null || !itemTpl.isGem()) {
				return;
			}
			setGemItemId(itemId);
		}
	}
	
}
