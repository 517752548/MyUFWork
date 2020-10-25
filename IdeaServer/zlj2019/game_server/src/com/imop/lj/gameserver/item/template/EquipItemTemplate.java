package com.imop.lj.gameserver.item.template;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.item.AttrDesc;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.Grade;
import com.imop.lj.gameserver.item.ItemDef.IdentityType;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.feature.EquipFeature;
import com.imop.lj.gameserver.item.feature.ItemFeature;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.PetDef.JobType;
import com.imop.lj.gameserver.pet.PetDef.Sex;
import com.imop.lj.gameserver.pet.template.PetPropTemplate;
import com.imop.lj.gameserver.role.properties.PropertyType;

/**
 * 装备道具模板
 */
@ExcelRowBinding
public class EquipItemTemplate extends EquipItemTemplateVO {
	protected Position position;
	protected Grade grade;
	
	/** 基础属性 */
	protected EquipItemAttribute baseProp;
	
	/** 附加属性，固定装备使用 */
	protected List<EquipItemAttribute> validAddPropList = new ArrayList<EquipItemAttribute>();
	
	protected boolean isPropLimitA;
	protected int propLimitIndex;
	
	@Override
	public void patchUp() {
		super.patchUp();
		//所属大类为装备
		this.idendityType = IdentityType.EQUIP;
		
		//装备位置
		this.position = Position.valueOf(this.positionId);
		//阶数
		this.grade = Grade.valueOf(this.gradeId);
		
		//基础属性
		this.baseProp = this.basePropList.get(0);
	}
	
	@Override
	public void check() throws TemplateConfigException {
		//位置是否定义
		if (position == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "positionId不存在！positionId=" + this.positionId);
		}
		//阶数Id是否定义
		if (grade == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "gradeId不存在！positionId=" + this.gradeId);
		}
		
		//属性要求
		if (this.propLimit > 0 && this.propValueLimit > 0) {
			boolean isAPropLimit = PetPropTemplate.isValidPropKey(this.propLimit, PropertyType.PET_PROP_A);
			boolean isBPropLimit = PetPropTemplate.isValidPropKey(this.propLimit, PropertyType.PET_PROP_B);
			if (!isAPropLimit && !isBPropLimit) {
				throw new TemplateConfigException(this.sheetName, this.id, "属性要求 属性key不存在！key=" + this.propLimit);
			}
			this.isPropLimitA = isAPropLimit;
			if (isPropLimitA) {
				propLimitIndex = this.propLimit - PropertyType.genPropertyKey(0, PropertyType.PET_PROP_A);
			} else {
				propLimitIndex = this.propLimit - PropertyType.genPropertyKey(0, PropertyType.PET_PROP_B);
			}
		}
		
		// 基础属性
		if(this.baseProp == null){
			throw new TemplateConfigException(sheetName, this.id, "基础属性 配置错误");
		}
		
		//基础属性只能是二级属性
		int keyBase = baseProp.getPropKey();
//		boolean isAPropBase = PetPropTemplate.isValidPropKey(keyBase, PropertyType.PET_PROP_A);
		boolean isBPropBase = PetPropTemplate.isValidPropKey(keyBase, PropertyType.PET_PROP_B);
		if (!isBPropBase) {
			throw new TemplateConfigException(this.sheetName, this.id, "基础属性key不存在！key=" + keyBase);
		}
		
		//固定属性的装备，检查属性key是否存在
		if (isFixedEquip()) {
			for (EquipItemAttribute eqAttr : this.addPropList) {
				if (eqAttr.getPropKey() <= 0) {
					continue;
				}
				int key = eqAttr.getPropKey();
				boolean isAProp = PetPropTemplate.isValidPropKey(key, PropertyType.PET_PROP_A);
				boolean isBProp = PetPropTemplate.isValidPropKey(key, PropertyType.PET_PROP_B);
				if (!isAProp && !isBProp) {
					throw new TemplateConfigException(this.sheetName, this.id, "附加属性key不存在！key=" + key);
				}
				
				validAddPropList.add(eqAttr);
			}
		}else{
			//XXX 神器等不能打造，策划要求
//			//非固定属性装备，检查是否能够打造
//			if(null == templateService.get(this.getId(), CraftEquipTemplate.class)){
//				throw new TemplateConfigException(this.sheetName, this.id, "非固定属性装备必须能够打造！");
//			}
		}
		
		//职业限制
		if (getFirstJob() == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "职业限制非法！jobLimit=" + getJobLimit());
		}
	}
	
	@Override
	public Position getPosition() {
		return position;
	}
	
	@Override
	public ItemFeature initItemFeature(Item item) {
		EquipFeature feature = new EquipFeature(item);
		return feature;
	}

	@Override
	public boolean isConsumable() {
		return false;
	}

	@Override
	public boolean isEquipment() {
		return true;
	}
	
	@Override
	public AttrDesc[] getAllAttrs() {
		return new AttrDesc[0];
	}
	
	@Override
	public int getMaxOverlap() {
		//装备的最大叠加数就是1，因为每个装备的颜色和阶数都是随机的
		return 1;
	}

	/**
	 * 获取装备的阶数
	 * @return
	 */
	public Grade getGrade() {
		return grade;
	}

	/**
	 * 是否固定属性的装备
	 * @return
	 */
	public boolean isFixedEquip() {
		return this.isFixedAttr == 1;
	}
	
	@Override
	public boolean canPutOn(Pet pet) {
		JobType job = pet.getJobType();
		Sex sex = pet.getSex();
		if (job == null || sex == null) {
			return false;
		}
		
		boolean jobFlag = false;
		int jobId = job.getIndex();
		//职业要求
		if ((getJobLimit() & jobId) == jobId) {
			jobFlag = true;
		}
		if (!jobFlag) {
			return false;
		}
		
		//性别要求
		int sexId = sex.getIndex();
		if ((getSexLimit() & sexId) == sexId) {
			return true;
		}
		
		return false;
	}
	
	/**
	 * 属性要求是否满足
	 * @param pet
	 * @return
	 */
	public boolean canPutOnAttrLimit(Pet pet) {
		//没有属性限制
		if (!hasPropLimit()) {
			return true;
		}
		
		float propV = 0;
		if (this.isPropLimitA) {
			propV = pet.getPropertyManager().getAProperty(this.propLimitIndex);
		} else {
			propV = pet.getPropertyManager().getBProperty(this.propLimitIndex);
		}
		if (propV >= this.propValueLimit) {
			return true;
		}
		return false;
	}
	
	public boolean hasPropLimit() {
		return this.propLimit > 0 && this.propValueLimit > 0;
	}
	
	public List<EquipItemAttribute> getValidAddPropList() {
		return validAddPropList;
	}
	
	/**
	 * 获取职业限制的第一个职业
	 * @return
	 */
	public JobType getFirstJob() {
		JobType[] arr = JobType.values();
		for (int i = 0; i < arr.length; i++) {
			JobType job = arr[i];
			if ((job.getIndex() & getJobLimit()) == job.getIndex()) {
				return job;
			}
		}
		return null;
	}

	public EquipItemAttribute getBaseProp() {
		return baseProp;
	}

	@Override
	public boolean isGem() {
		return false;
	}
	
	public double getBasePropValueFinal() {
		return EffectHelper.int2Double(getBasePropValue());
	}
	
	public double getAddPropValueFinal() {
		return EffectHelper.int2Double(getAddPropValue());
	}
	
	public boolean hasBindAttr() {
		return this.getBindPropValue() > 0;
	}
	
	@Override
	public boolean isSkillEffectItem() {
		return false;
	}
	
	@Override
	public boolean canCompose() {
		return false;
	}
}
