using System;
using System.IO;
namespace app.net
{

/**
 * 升阶翅膀
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGWingUpgrade :BaseMessage
{
	
	/** 翅膀模板Id */
	private int templateId;
	/** 升阶方式 1手动2自动 */
	private int upgradeType;
	
	public CGWingUpgrade ()
	{
	}
	
	public CGWingUpgrade (
			int templateId,
			int upgradeType )
	{
			this.templateId = templateId;
			this.upgradeType = upgradeType;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 翅膀模板Id
	WriteInt(templateId);
	// 升阶方式 1手动2自动
	WriteInt(upgradeType);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_WING_UPGRADE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}