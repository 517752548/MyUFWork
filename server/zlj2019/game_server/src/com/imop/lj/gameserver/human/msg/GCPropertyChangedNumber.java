package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 用于发送数值类型的属性改变消息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPropertyChangedNumber extends GCMessage{
	
	/** 角色类型 */
	private short roleType;
	/** 角色UUID */
	private long roleUUID;
	/** 所有变化的属性 */
	private com.imop.lj.core.util.KeyValuePair<Integer,Integer>[] properties;

	public GCPropertyChangedNumber (){
	}
	
	public GCPropertyChangedNumber (
			short roleType,
			long roleUUID,
			com.imop.lj.core.util.KeyValuePair<Integer,Integer>[] properties ){
			this.roleType = roleType;
			this.roleUUID = roleUUID;
			this.properties = properties;
	}

	@Override
	protected boolean readImpl() {

	// 角色类型
	short _roleType = readShort();
	//end


	// 角色UUID
	long _roleUUID = readLong();
	//end


	// 所有变化的属性
	int propertiesSize = readUnsignedShort();
	com.imop.lj.core.util.KeyValuePair<Integer,Integer>[] _properties  = com.imop.lj.core.util.KeyValuePair.newKeyValuePairArray(propertiesSize);
	int propertiesIndex = 0;
	for(propertiesIndex=0; propertiesIndex<propertiesSize; propertiesIndex++){
		_properties[propertiesIndex] = new com.imop.lj.core.util.KeyValuePair<Integer,Integer>();
	// 属性索引
	int _properties_key = readInteger();
	//end
	_properties[propertiesIndex].setKey (_properties_key);

	// 属性值
	int _properties_value = readInteger();
	//end
	_properties[propertiesIndex].setValue (_properties_value);
	}
	//end



		this.roleType = _roleType;
		this.roleUUID = _roleUUID;
		this.properties = _properties;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 角色类型
	writeShort(roleType);


	// 角色UUID
	writeLong(roleUUID);


	// 所有变化的属性
	writeShort(properties.length);
	int propertiesIndex = 0;
	int propertiesSize = properties.length;
	for(propertiesIndex=0; propertiesIndex<propertiesSize; propertiesIndex++){

	int properties_key = properties[propertiesIndex].getKey();

	// 属性索引
	writeInteger(properties_key);

	int properties_value = properties[propertiesIndex].getValue();

	// 属性值
	writeInteger(properties_value);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PROPERTY_CHANGED_NUMBER;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PROPERTY_CHANGED_NUMBER";
	}

	public short getRoleType(){
		return roleType;
	}
		
	public void setRoleType(short roleType){
		this.roleType = roleType;
	}

	public long getRoleUUID(){
		return roleUUID;
	}
		
	public void setRoleUUID(long roleUUID){
		this.roleUUID = roleUUID;
	}

	public com.imop.lj.core.util.KeyValuePair<Integer,Integer>[] getProperties(){
		return properties;
	}

	public void setProperties(com.imop.lj.core.util.KeyValuePair<Integer,Integer>[] properties){
		this.properties = properties;
	}	
}