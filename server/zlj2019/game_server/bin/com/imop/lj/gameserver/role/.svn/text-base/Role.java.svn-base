package com.imop.lj.gameserver.role;

import java.util.List;

import com.imop.lj.common.HeartBeatAble;
import com.imop.lj.core.util.KeyValuePair;
import com.imop.lj.gameserver.common.msg.GCMessage;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.msg.GCPropertyChangedNumber;
import com.imop.lj.gameserver.human.msg.GCPropertyChangedString;
import com.imop.lj.gameserver.role.properties.PropertyType;
import com.imop.lj.gameserver.role.properties.RoleBaseIntProperties;
import com.imop.lj.gameserver.role.properties.RoleBaseStrProperties;
import com.imop.lj.gameserver.role.properties.RolePropertyManager;

public abstract class Role implements HeartBeatAble {

	/** 角色类型 */
	protected short roleType;
	/** 角色的属性定义：角色在游戏过程中对客户端不可见的属性 */
	protected final RoleFinalProps finalProps = new RoleFinalProps();
	/** 基础属性：整型 */
	protected final RoleBaseIntProperties baseIntProperties;
	/** 基础属性：对象型 */
	protected final RoleBaseStrProperties baseStrProperties;

	public Role(short roleType) {
		this.roleType = roleType;
		baseIntProperties = new RoleBaseIntProperties();
		baseStrProperties = new RoleBaseStrProperties();
	}

	public void setRoleType(short roleType) {
		this.roleType = roleType;
	}

	public short getRoleType() {
		return roleType;
	}

	@Override
	public void heartBeat() {

	}
	
	public abstract Human getOwner();

	/**
	 * 重置所有属性的修改标识
	 * 
	 * @param reset
	 */
	public void resetChange() {
		this.getPropertyManager().resetChanged();
		this.finalProps.resetChanged();
		this.baseIntProperties.resetChanged();
		this.baseStrProperties.resetChanged();
	}

	/**
	 * 将所有属性设置为改变状态
	 */
	public void change(){
		this.getPropertyManager().change();
		this.finalProps.change();
		this.baseIntProperties.change();
		this.baseStrProperties.change();
	}
	
	/**
	 * @return
	 */
	public int getLevel() {
		return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.LEVEL);
	}

	/**
	 * @param level
	 */
	public void setLevel(int level) {
		this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.LEVEL, level);
		this.onModified();
	}

	/**
	 * 获取下次升级经验值
	 * 
	 * @return
	 */
	public long getLevelUpNeedExp() {
		return this.baseStrProperties.getLong(RoleBaseStrProperties.LEVEL_UP_NEED_EXP);
	}

	public RoleBaseIntProperties getBaseIntProperties() {
		return baseIntProperties;
	}

	public RoleBaseStrProperties getBaseStrProperties() {
		return baseStrProperties;
	}

	/**
	 * 将有改动的数值数据发送到客户端
	 * 
	 * @param reset
	 *            如果reset标识为true,则会在快照完成后重置更新状态
	 */

	public void snapChangedProperty(boolean reset) {
		// 如果 LevelA,LevelB,DynamicNumProp,DynamicOtherProp 均无变化，则返回NULL
		if (!this.getPropertyManager().isChanged() && !this.baseIntProperties.isChanged() && !this.baseStrProperties.isChanged()) {
			return;
		}
		// 保存数值类属性变化
		List<KeyValuePair<Integer, Integer>> _numChanged = changedNum();
		// 保存字符串类属性变化
		KeyValuePair<Integer, String>[] _strChanged = changedStr();

		KeyValuePair<Integer, Integer>[] empty = KeyValuePair.newKeyValuePairArray(0);

		if (_numChanged != null && !_numChanged.isEmpty()) {
			sendMessage(new GCPropertyChangedNumber(getRoleType(), this.getUUID(), _numChanged.toArray(empty)));
		}

		if (_strChanged != null && _strChanged.length > 0) {
			sendMessage(new GCPropertyChangedString(getRoleType(), this.getUUID(), _strChanged));
		}

		if (reset) {
			resetChange();
		}
	}
	
	protected KeyValuePair<Integer, String>[] changedStr() {
		// 保存字符串类属性变化
		KeyValuePair<Integer, String>[] _strChanged = null;
		// 处理 baseStrProps
		if (this.baseStrProperties.isChanged()) {
			Object[] _dOtherPropsChangedValues = this.baseStrProperties.getChanged(); // Object
			int[] _indexs = (int[]) _dOtherPropsChangedValues[0];
			Object[] _values = (Object[]) _dOtherPropsChangedValues[1];
			_strChanged = KeyValuePair.newKeyValuePairArray(_indexs.length);
			for (int i = 0; i < _indexs.length; i++) {
				_strChanged[i] = new KeyValuePair<Integer, String>(PropertyType.genPropertyKey(_indexs[i], PropertyType.BASE_ROLE_PROPS_STR),
						_values[i].toString());
			}
		}
		return _strChanged;
	}

	abstract public long getUUID();

	/**
	 * 向前端发送消息
	 * 
	 * @see Human#sendMessage(GCMessage)
	 */
	abstract protected void sendMessage(GCMessage msg);

	/**
	 * 角色的属性管理器
	 * 
	 * @return
	 */
	abstract public RolePropertyManager<?, ?> getPropertyManager();

	/**
	 * 当属性被修改时调用
	 */
	abstract protected void onModified();

	abstract protected List<KeyValuePair<Integer, Integer>> changedNum();

}
