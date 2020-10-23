package com.imop.lj.gameserver.item.feature;

import java.util.HashMap;
import java.util.Map;

import net.sf.json.JSONObject;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.equip.EquipAttrManager;
import com.imop.lj.gameserver.equip.EquipHoleManager;
import com.imop.lj.gameserver.equip.template.CraftEquipCostTemplate;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.Grade;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.ItemDef.Rarity;
import com.imop.lj.gameserver.item.template.EquipItemAttribute;
import com.imop.lj.gameserver.item.template.EquipItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.PetLeader;
import com.imop.lj.gameserver.pet.template.PetPropTemplate;
import com.imop.lj.gameserver.role.Role;

/**
 * 装备的属性抽象定义 装备包括：武器、身上装备、宝物、饰品
 * 
 */
public abstract class AbstractEquipFeature extends AbstractAttrFeature implements IEquipSuit {
	public static final String COLOR = "co";
	public static final String GRADE = "gr";
	public static final String DURA = "du";
	public static final String ATTR = "at";
	public static final String HOLE = "ho";
	public static final String HOLE_MAX = "hm";
	
	public static final String ATTR_BASE = "ab";
	public static final String ATTR_BASE_ADD = "aba";
	public static final String ATTR_BIND = "abd";
	public static final String SCORE = "sc";
	
	public static final String TEMPLATEID = "ti";
	
	/** 颜色 */
	protected Rarity color = Rarity.WHITE;
	/** 阶数 */
	protected Grade grade = Grade.ONE;
	/** 当前耐久度 */
	protected int curDura;
	
	protected int itemTemplateId;
	
	/** 属性管理器 */
	protected EquipAttrManager attrManager;
	
	/** 装备孔管理器 */
	protected EquipHoleManager holeManager;
	
	public AbstractEquipFeature(Item item) {
		super(item);
		this.item = item;
		this.attrManager = new EquipAttrManager(this);
		this.holeManager = new EquipHoleManager(this);
	}
	
	@Override
	public void onGMCreate(int[] attrA, int[] attrB, Object...param) {
		onCreateByParams(attrA, attrB, param);
	}
	
	@Override
	public void onCreateByParams(int[] attrA, int[] attrB, Object...param) {
		initTemplateID();
		//如果不是固定属性装备，则按照参数生成
		if (!getEquipItemTemplate().isFixedEquip()) {
			CraftEquipCostTemplate costTpl = null;
			//参数1，打造消耗模板
			if (param.length >= 1 && (param[0] instanceof CraftEquipCostTemplate)) {
				costTpl = (CraftEquipCostTemplate) param[0];
			}
			//参数2，阶数
			if (param.length >= 2 && param[1] instanceof Grade) {
				this.grade = (Grade) param[1];
			}
			int[] p3 = null;
			//参数3，材料数量数组
			if (param.length >= 3 && param[2] instanceof int[]) {
				p3 = (int[])param[2];
			}
			
			this.curDura = getEquipItemTemplate().getDurability();
			this.attrManager.onCreate(costTpl, p3);
			this.holeManager.init();
		} else {
			//固定属性的装备，直接按配置表生成
			onCreate();
		}
	}
	
	private void initTemplateID() {
		if (this.item != null && this.item.getTemplateId() > 0) {
			itemTemplateId = this.item.getTemplateId();
		}
	}
	
	@Override
	public void onCreate() {
		initTemplateID();
		//非固定装备，如果直接给的话，按照配置表的颜色和阶数来，记录警告日志
		if (!getEquipItemTemplate().isFixedEquip()) {
			Loggers.equipLogger.warn("call create NOT fixed attr equip!tplId=" + getEquipItemTemplate().getId());
		}
		this.color = getEquipItemTemplate().getRarity();
		this.grade = getEquipItemTemplate().getGrade();
		this.curDura = getEquipItemTemplate().getDurability();
		this.attrManager.onCreate(null, null);
		this.holeManager.init();
	}
	
	@Override
	public Map<Integer, Float> getPropAmends(int propType) {
		Map<Integer, Float> map = new HashMap<Integer, Float>();
		//基础属性
		EquipItemAttribute baseE = getAttrManager().getBaseAttr();
		if (PetPropTemplate.isValidPropKey(baseE.getPropKey(), propType)) {
			Globals.getEquipService().calPropMap(map, baseE.getPropKeyIndex(propType), baseE.getPropValue());
		}
		
		// 附加属性
		for (EquipItemAttribute e : getAttrManager().getAddAttrList()) {
			if (PetPropTemplate.isValidPropKey(e.getPropKey(), propType)) {
				Globals.getEquipService().calPropMap(map, e.getPropKeyIndex(propType), e.getPropValue());
			}
		}
		
		//绑定属性
		EquipItemAttribute bindE = getAttrManager().getBindAttr();
		if (PetPropTemplate.isValidPropKey(bindE.getPropKey(), propType)) {
			Globals.getEquipService().calPropMap(map, bindE.getPropKeyIndex(propType), bindE.getPropValue());
		}
		
		return map;
	}
	
	/**
	 * 获取装备模版
	 * 
	 * @return
	 */
	public EquipItemTemplate getEquipItemTemplate() {
		if(this.item != null && this.item.getTemplateId()>0){
			ItemTemplate temp = Globals.getTemplateCacheService().get(this.item.getTemplateId(), ItemTemplate.class);
			if(this.itemTemplateId != this.item.getTemplateId()){
				initTemplateID();
			}
			return (EquipItemTemplate)temp;
		}
		return (EquipItemTemplate)Globals.getTemplateCacheService().get(itemTemplateId, ItemTemplate.class);
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
		//非固定属性装备，按照数据库中的来
		if (!getEquipItemTemplate().isFixedEquip()) {
			int colorId = JsonUtils.getInt(obj, COLOR);
			int gradeId = JsonUtils.getInt(obj, GRADE);
			this.color = Rarity.valueOf(colorId);
			this.grade = Grade.valueOf(gradeId);
			if (this.color == null || this.grade == null) {
				Loggers.itemLogger.error("ERROR!AbstractEquipFeature color or grade is null! props = " + props + "humanid = " + this.item.getOwner().getUUID());
				return;
			}
		} else {
			//固定属性装备，直接读配置表
			this.color = getEquipItemTemplate().getRarity();
			this.grade = getEquipItemTemplate().getGrade();
		}
		this.curDura = JsonUtils.getInt(obj, DURA);
		this.attrManager.loadJsonProp(JsonUtils.getString(obj, ATTR));
		this.holeManager.loadJsonProp(JsonUtils.getString(obj, HOLE));
		this.holeManager.init();
	}
	
	@Override
	public String toProps(boolean isShow) {
		JSONObject obj = new JSONObject();
		obj.put(COLOR, getColor().getIndex());
		obj.put(GRADE, getGrade().getIndex());
		obj.put(DURA, getCurDura());
		if (isShow) {
			//这里是仅给前端显示用的
			obj.put(ATTR, getAttrManager().getAddAttrJsonStr());
			obj.put(ATTR_BASE, getAttrManager().getBaseAttr().toJson());
			obj.put(ATTR_BASE_ADD, getAttrManager().getBaseAttrExtraAdd());
			obj.put(SCORE, getEquipScore());
			
			//绑定属性
			obj.put(ATTR_BIND, "");
			//绑定状态下显示绑定属性
			if (getItem().isBind()) {
				obj.put(ATTR_BIND, getAttrManager().getBindAttr().toJson());
			}
			//孔数最大值
			obj.put(HOLE_MAX, getHoleManager().getMaxHoleNum());
		} else {
			obj.put(ATTR, getAttrManager().toJsonProp());
		}
		obj.put(TEMPLATEID, getItemTemplateId());
		//当前孔数据
		obj.put(HOLE, getHoleManager().toJsonProp());
		return obj.toString();
	}

	@Override
	public <T extends Role> boolean canPuton(T role, boolean notify) {
		//如果不是pet类型，即武将类型
		if (!(role instanceof Pet)) {
			return false;
		}
		
		Pet pet = (Pet)role;
		EquipItemTemplate equipTemp = this.getEquipItemTemplate();
		//级别是否足够
		if (equipTemp.getLevel() > pet.getLevel()) {
			if (notify) {
				pet.getOwner().sendErrorMessage(LangConstants.ITEM_USEFAIL_LEVEL);
			}
			return false;
		}
		
		//职业、性别限制是否合适
		if (!equipTemp.canPutOn(pet)) {
			if (notify) {
				pet.getOwner().sendErrorMessage(LangConstants.JOB_CAN_NOT_PUT_ON);
			}
			return false;
		}
		
		//属性要求是否满足
		if (!equipTemp.canPutOnAttrLimit(pet)) {
			if (notify) {
				pet.getOwner().sendErrorMessage(LangConstants.ATTR_CAN_NOT_PUT_ON);
			}
			return false;
		}
		
		return true;
	}
	
	public EquipAttrManager getAttrManager() {
		return attrManager;
	}
	
	public EquipHoleManager getHoleManager() {
		return holeManager;
	}

	public Position getPosition() {
		if (null != this.item) {
			return this.item.getPosition();
		}
		return Position.NULL;
	}
	
	public boolean isLeaderWear() {
		if (this.item.getWearerId() > 0 &&
				this.item.getOwner() != null && 
				this.item.getOwner().getPetManager() != null &&
				this.item.getOwner().getPetManager().getLeader() != null) {
			return this.item.getWearerId() == this.item.getOwner().getPetManager().getLeader().getUUID();
		}
		return false;
	}
	
	public PetLeader getWearLeader() {
		if (isLeaderWear()) {
			return this.item.getOwner().getPetManager().getLeader();
		}
		return null;
	}

	public Rarity getColor() {
		return color;
	}

	public void setColor(Rarity color) {
		if (color != null) {
			this.color = color;
		}
	}
	
	public Grade getGrade() {
		return grade;
	}
	
	public void setGrade(Grade grade) {
		this.grade = grade;
	}

	public int getCurDura() {
		return curDura;
	}

	public int getItemTemplateId() {
		return itemTemplateId;
	}

	public void setItemTemplateId(int itemTemplateId) {
		this.itemTemplateId = itemTemplateId;
	}

	/**
	 * 获取装备的评分
	 * @return
	 */
	public int getEquipScore() {
		return Globals.getEquipService().calcEquipScore(this);
	}
	
	/**
	 * 复制属性
	 * @param source
	 */
	public void copy(AbstractEquipFeature source) {
		this.color = source.getColor();
		this.grade = source.getGrade();
		this.curDura = source.getCurDura();
		this.itemTemplateId = source.getItemTemplateId();
		this.attrManager.copy(source.getAttrManager());
		this.holeManager.copy(source.getHoleManager());
	}
}
