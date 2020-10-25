package com.imop.lj.gameserver.pet;

import java.util.HashMap;
import java.util.Map;
import java.util.Map.Entry;

import net.sf.json.JSONObject;

import com.imop.lj.common.constants.FlagType;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.db.model.PetEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.msg.GCPopFlag;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.pet.template.PetLevelTemplate;
import com.imop.lj.gameserver.role.properties.RoleBaseIntProperties;
import com.imop.lj.gameserver.role.properties.RolePropertyManager;

/**
 * 主将对象
 * @author yu.zhao
 *
 */
public class PetLeader extends Pet {

	/** 武将装备位星级<装备位,星级> */
	protected Map<Position, Integer> equipStars = new HashMap<Position, Integer>();
	
	public PetLeader() {
		super();
	}
	
	@Override
	public void init() {
		if (this.owner != null) {
			this.owner.updateTemplateRelatedAttr(getTemplateId());
		}
	}
	
	@Override
	public void fromEntity(PetEntity entity) {
		super.fromEntity(entity);
		
		this.setEquipStars(entity.getEquipStars());
	}
	
	@Override
	public PetEntity toEntity() {
		PetEntity entity = super.toEntity();
		entity.setEquipStars(this.getEquipStarsJson());
		
		return entity;
	}
	
	/**
	 * 获取装备位星级
	 * @return
	 */
	public int getEquipStars(Position position) {
		if(equipStars.containsKey(position)){
			return equipStars.get(position) ;
		}
		return 0;
	}
	
	/**
	 * 更新装备星级
	 * @param position
	 * @param starNum
	 * @return 
	 */
	public boolean upgradeEquipStar(Position position, Integer starNum) {
		if (position.isCanUpStar()) {
			equipStars.put(position, starNum);
			this.setModified();
			return true;
		} else {
			return false;
		}
	}
	
	private String getEquipStarsJson(){
		JSONObject json = new JSONObject();
		for(Entry<Position,Integer> entry : equipStars.entrySet()){
			json.put(entry.getKey().getIndex(), entry.getValue());
		}
		return json.toString();
	}
	
	private void setEquipStars(String equipStarsStr) {
		if(equipStarsStr==null||equipStarsStr.isEmpty()){
			return ;
		}
		JSONObject jsObject = JSONObject.fromObject(equipStarsStr);
		if (jsObject == null || jsObject.isNullObject() || jsObject.isEmpty()) {
			return;
		}
		
		Position[] pArr = Position.values();
		for (int i = 0; i < pArr.length; i++) {
			Position pos = pArr[i];
			if (pos != Position.NULL && pos.isCanUpStar() 
					&& jsObject.containsKey(String.valueOf(pos.getIndex()))) {
				equipStars.put(pos, JsonUtils.getInt(jsObject, String.valueOf(pos.getIndex())));
			}
		}
	}
	
	@Override
	public String getName() {
		if (getOwner() != null) {
			return getOwner().getName();
		} else {
			return null;
		}
	}
	
	@Override
	public void setName(String name) {
		return;
	}
	
	@Override
	public void setLevel(int level) {
		this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.LEVEL, level);
		long upgradeExp = Globals.getTemplateCacheService().get(this.getLevel(), PetLevelTemplate.class).getMainExp();
		this.setLevelUpNeedExp(upgradeExp);
		this.setModified();
	}
	
	/**
	 * 升级后更新可分配点数
	 */
	public void onUpgradeLevel(int levels) {
		//升级后，增加可分配属性点数
		int addPoint = Globals.getGameConstants().getLeaderLevelUpAddPoint(); 
		//更新点数
		setLeftPoint(getLeftPoint() + addPoint * levels);
		getOwner().sendMessage(new GCPopFlag(FlagType.OFF.getIndex()));
		
		//属性更新，升级需要补满hp、mp、life
		getPropertyManager().updatePropertyFull(RolePropertyManager.PROP_FROM_MARK_GROWTH);
		
		getOwner().sendMessage(new GCPopFlag(FlagType.ON.getIndex()));
	}

	public Map<Position, Integer> getEquipStars() {
		return equipStars;
	}
	
}
