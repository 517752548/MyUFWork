package com.imop.lj.gameserver.equip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.item.ItemDef.GemType;
import com.imop.lj.gameserver.pet.template.PetPropTemplate;
import com.imop.lj.gameserver.role.properties.PropertyType;

@ExcelRowBinding
public class GemForPropTemplate extends GemForPropTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		// TODO 自动生成的方法存根
//		if(!PetPropTemplate.isValidPropKey(this.getId(), PropertyType.PET_PROP_A) && !PetPropTemplate.isValidPropKey(this.getId(), PropertyType.PET_PROP_B)){
//			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "属性key值不存在");
//		}
		if(GemType.valueOf(this.getId()) == null){
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "宝石类型未在枚举中定义");
		}
		if(!isMatch()){
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "属性key值没有对应定义");
		}
	}
	
	private boolean isMatch(){
		if(!validKey(this.getWeapon())){
			return false;
		}
		if(!validKey(this.getBelt())){
			return false;
		}
		if(!validKey(this.getBoot())){
			return false;
		}
		if(!validKey(this.getBreast())){
			return false;
		}
		if(!validKey(this.getCloak())){
			return false;
		}
		if(!validKey(this.getHead())){
			return false;
		}
		if(!validKey(this.getNecklace())){
			return false;
		}
		if(!validKey(this.getPants())){
			return false;
		}
		if(!validKey(this.getRing())){
			return false;
		}
		if(!validKey(this.getShoulder())){
			return false;
		}
		if(!validKey(this.getWrister())){
			return false;
		}
		return true;
	}
	
	private boolean validKey(int key){
		return (PetPropTemplate.isValidPropKey(key, PropertyType.PET_PROP_A) || PetPropTemplate.isValidPropKey(key, PropertyType.PET_PROP_B) ) && null != templateService.get(key,GemForPropValueTemplate.class);
	}
}
