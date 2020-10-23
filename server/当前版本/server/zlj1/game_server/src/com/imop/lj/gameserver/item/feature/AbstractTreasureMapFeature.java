package com.imop.lj.gameserver.item.feature;

import java.awt.Point;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.template.ConsumeItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;

import net.sf.json.JSONObject;

/**
 * 藏宝图道具的定义：地图ID、地图x坐标、地图y坐标
 * 
 */
public abstract class AbstractTreasureMapFeature extends ConsumableFeature {
	public static final String MAPID = "mapid";
	public static final String MAPX = "mapx";
	public static final String MAPY = "mapy";
	
	public static final String TEMPLATEID = "ti";

	/** 地图ID */
	protected int mapId;
	/** 地图中的x坐标 */
	protected int mapX;
	/** 地图中的y坐标*/
	protected int mapY;
	
	protected int itemTemplateId;
	
	public AbstractTreasureMapFeature(Item item) {
		super(item);
		this.item = item;
	}
	
	@Override
	public void onGMCreate(int[] attrA, int[] attrB, int...param) {
		onCreateByParams(attrA, attrB, param);
	}
	
	@Override
	public void onCreateByParams(int[] attrA, int[] attrB, int...param) {
		iniTemplateID();
		onCreate();
	}
	private void iniTemplateID(){
		if(this.item != null && this.item.getTemplateId()>0){
			itemTemplateId = this.item.getTemplateId();
		}
	}
	@Override
	public void onCreate() {
		iniTemplateID();
		
		this.mapId = Globals.getTreasureMapService().randMapId(); 
		Point treasureMap = Globals.getTreasureMapService().randMapPos(mapId);
		this.mapX = treasureMap.x;
		this.mapY = treasureMap.y;
		
	}
	
	/**
	 * 获取消耗品模版
	 * 
	 * @return
	 */
	public ConsumeItemTemplate getEquipItemTemplate() {
		if(this.item != null && this.item.getTemplateId()>0){
			ItemTemplate temp = Globals.getTemplateCacheService().get(this.item.getTemplateId(), ItemTemplate.class);
			if(this.itemTemplateId != this.item.getTemplateId()){
				iniTemplateID();
			}
			return (ConsumeItemTemplate)temp;
		}
		return (ConsumeItemTemplate)Globals.getTemplateCacheService().get(itemTemplateId, ItemTemplate.class);
	}
	
	@Override
	public void fromPros(String props) {
		if (props == null || props.isEmpty()) {
			Loggers.itemLogger.error("abstractEquipFeature fromProps , props = " + props + "humanid = " + this.item.getOwner().getUUID());
			return;
		}
		JSONObject obj = JSONObject.fromObject(props);
		if (obj == null || obj.isEmpty()) {
			Loggers.itemLogger.error("abstractEquipFeature fromProps , JsonObject,  props = " + props + "humanid = " + this.item.getOwner().getUUID());
			return;
		}
		//最先初始化templateId
		this.itemTemplateId = JsonUtils.getInt(obj, TEMPLATEID);
		this.mapId = JsonUtils.getInt(obj, MAPID);
		this.mapX = JsonUtils.getInt(obj, MAPX);
		this.mapY = JsonUtils.getInt(obj, MAPY);
		if (this.mapId == 0 || this.mapX == 0) {
			Loggers.itemLogger.error("ERROR!AbstractEquipFeature color or grade is null! props = " + props + "humanid = " + this.item.getOwner().getUUID());
			return;
		}
	}
	
	@Override
	public String toProps(boolean isShow) {
		JSONObject obj = new JSONObject();
		obj.put(MAPID, getMapId());
		obj.put(MAPX, getMapX());
		obj.put(MAPY, getMapY());
		
		obj.put(TEMPLATEID, getItemTemplateId());
		return obj.toString();
	}


	public int getItemTemplateId() {
		return itemTemplateId;
	}

	public void setItemTemplateId(int itemTemplateId) {
		this.itemTemplateId = itemTemplateId;
	}

	
	public int getMapId() {
		return mapId;
	}

	public int getMapX() {
		return mapX;
	}

	public int getMapY() {
		return mapY;
	}

}
