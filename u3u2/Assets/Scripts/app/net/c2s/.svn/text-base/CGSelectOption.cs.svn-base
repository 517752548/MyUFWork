using System;
using System.IO;
namespace app.net
{

/**
 * 选择确认对话框 ok 或 cancel 选项
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGSelectOption :BaseMessage
{
	
	/** 操作标识 */
	private string tag;
	/** 如果没有提示框默认是0，是否选中不提示框1选中1不选中 */
	private int isSelected;
	/** 选项值,选择确认返回1，选择取消返回0 */
	private int seletctedValue;
	
	public CGSelectOption ()
	{
	}
	
	public CGSelectOption (
			string tag,
			int isSelected,
			int seletctedValue )
	{
			this.tag = tag;
			this.isSelected = isSelected;
			this.seletctedValue = seletctedValue;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 操作标识
	WriteString(tag);
	// 如果没有提示框默认是0，是否选中不提示框1选中1不选中
	WriteInt(isSelected);
	// 选项值,选择确认返回1，选择取消返回0
	WriteInt(seletctedValue);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_SELECT_OPTION;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}