using System;
using System.IO;
namespace app.net
{

/**
 * 创建角色
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCreateRole :BaseMessage
{
	
	/** 角色名字 */
	private string name;
	/** 选择的主将模板Id */
	private int templateId;
	
	public CGCreateRole ()
	{
	}
	
	public CGCreateRole (
			string name,
			int templateId )
	{
			this.name = name;
			this.templateId = templateId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 角色名字
	WriteString(name);
	// 选择的主将模板Id
	WriteInt(templateId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CREATE_ROLE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}