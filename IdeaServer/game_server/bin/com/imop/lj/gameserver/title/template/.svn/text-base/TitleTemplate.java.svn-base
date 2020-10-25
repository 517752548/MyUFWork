package com.imop.lj.gameserver.title.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.item.template.EquipItemAttribute;
import com.imop.lj.gameserver.pet.template.PetPropTemplate;
import com.imop.lj.gameserver.role.properties.PropertyType;
import com.imop.lj.gameserver.title.TitleDef;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by zhangzhe on 15/12/16.
 */
@ExcelRowBinding
public class TitleTemplate extends TitleTemplateVO {
    protected List<EquipItemAttribute> validAddPropList = new ArrayList<EquipItemAttribute>();

    @Override
    public void check() throws TemplateConfigException {
        for (EquipItemAttribute eqAttr : this.getBasePropList()) {
            if (eqAttr.getPropKey() <= 0) {
                continue;
            }
            int key = eqAttr.getPropKey();
            boolean isAProp = PetPropTemplate.isValidPropKey(key, PropertyType.PET_PROP_A);
            boolean isBProp = PetPropTemplate.isValidPropKey(key, PropertyType.PET_PROP_B);
            if (!isAProp && !isBProp) {
                throw new TemplateConfigException(this.sheetName, this.id, "TITLE属性key不存在！key=" + key);
            }
            validAddPropList.add(eqAttr);
        }
        
        if (TitleDef.TitleTemplateType.indexOf(getId()) == null) {
        	throw new TemplateConfigException(this.sheetName, this.id, "title未定义！id=" + getId());
        }
    }

    public List<EquipItemAttribute> getValidAddPropList() {
        return validAddPropList;
    }

}
