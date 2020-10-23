package com.imop.lj.gameserver.human.manager;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.KeyValuePair;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.role.properties.HumanAProperty;
import com.imop.lj.gameserver.role.properties.PropertyType;
import com.imop.lj.gameserver.role.properties.RolePropertyManager;

/**
 * 玩家角色的属性管理器
 *
 */
public class HumanPropertyManager extends RolePropertyManager<Human,Integer>{

	/** 建筑的升级级别 */
	protected HumanAProperty buildProperty;

	public HumanPropertyManager(Human role) {
		super(role,2);
		buildProperty = new HumanAProperty();
	}


	/**
	 * 获得建筑等级的值,发消息使用
	 */
	@Override
	public KeyValuePair<Integer, Integer>[] getChanged() {
		if (propChangeSet.isEmpty()) {
			return null;
		}
		boolean _aPropChange = propChangeSet.get(RolePropertyManager.CHANGE_INDEX_APROP);
		int _length = 0;
		if (_aPropChange) {
			_length += HumanAProperty._SIZE;
		}

		KeyValuePair<Integer, Integer>[] valuePairs = KeyValuePair.newKeyValuePairArray(_length);
		int i = 0;
		if (_aPropChange) {
			for (KeyValuePair<Integer, Integer> valuePair : this.buildProperty.getIndexValuePairs()) {
				valuePairs[i] = valuePair;
				//给客户端的属性id是根据属性类型计算得出的
				valuePairs[i].setKey(PropertyType.genPropertyKey(valuePairs[i].getKey(), PropertyType.HUMAN_PROP_A));
				i++;
			}
		}
		return valuePairs;
	}

	@Override
	protected boolean updateAProperty(Human role, int effectMask) {
		boolean _changed = false;
		if (buildProperty.isChanged()) {
			_changed = true;
			buildProperty.resetChanged();
		}
		if (_changed) {
			role.setModified();
			return true;
		}
		return false;
	}

	@Override
	protected boolean updateBProperty(Human role, int effectMask) {
		Loggers.humanLogger.error("Human has not Level B property.");
		return false;
	}

	@Override
	public void updateProperty(int effectMask) {
		if (this.updateAProperty(owner, effectMask)) {
			effectMask |= RolePropertyManager.PROP_FROM_MARK_APROPERTY;
			propChangeSet.set(RolePropertyManager.CHANGE_INDEX_APROP);
		}
	}

	/**
	 * 返回建筑等级
	 * @param buildingIdx
	 * @return
	 */
	public int getBuildLevel(int buildingIdx)
	{
		return this.buildProperty.get(buildingIdx);
	}

	/**
	 * 设置建筑等级
	 *
	 * @param buildingIndex
	 * @param addedPoint
	 */
	public void setBuildLevel(int buildingIndex, int level) {
		this.buildProperty.set(buildingIndex, level);
	}

	/**
	 * @param buildingIndex
	 * @param increament
	 */
	public void addBuildingLevel(int buildingIndex, int increament) {
		if (increament > 0) {
			int orgLevel = this.buildProperty.get(buildingIndex);
			this.buildProperty.set(buildingIndex, orgLevel + increament);
		}
	}
}
