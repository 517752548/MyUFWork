
using System;
namespace app.net
{
/**
 * 用于发送数值类型的属性改变消息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPropertyChangedNumber :BaseMessage
{
	/** 角色类型 */
	private short roleType;
	/** 角色UUID */
	private long roleUUID;
	/** 所有变化的属性 */
	private KeyValuePairIntData[] properties;

	public GCPropertyChangedNumber ()
	{
	}

	protected override void ReadImpl()
	{
	// 角色类型
	short _roleType = ReadShort();
	// 角色UUID
	long _roleUUID = ReadLong();

	// 所有变化的属性
	int propertiesSize = ReadShort();
	KeyValuePairIntData[] _properties = new KeyValuePairIntData[propertiesSize];
	int propertiesIndex = 0;
	KeyValuePairIntData _propertiesTmp = null;
	for(propertiesIndex=0; propertiesIndex<propertiesSize; propertiesIndex++){
		_propertiesTmp = new KeyValuePairIntData();
		_properties[propertiesIndex] = _propertiesTmp;
	// 属性索引
	int _properties_key = ReadInt();	_propertiesTmp.key = _properties_key;
		// 属性值
	int _properties_value = ReadInt();	_propertiesTmp.value = _properties_value;
		}
	//end



		this.roleType = _roleType;
		this.roleUUID = _roleUUID;
		this.properties = _properties;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PROPERTY_CHANGED_NUMBER;
	}
	
	public override string getEventType()
	{
		return HumanGCHandler.GCPropertyChangedNumberEvent;
	}
	

	public short getRoleType(){
		return roleType;
	}
		

	public long getRoleUUID(){
		return roleUUID;
	}
		

	public KeyValuePairIntData[] getProperties(){
		return properties;
	}


}
}