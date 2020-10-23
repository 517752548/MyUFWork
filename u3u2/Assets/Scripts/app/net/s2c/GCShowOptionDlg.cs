
using System;
namespace app.net
{
/**
 * 显示确认对话框
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCShowOptionDlg :BaseMessage
{
	/** 窗口标题,如果是空字符窜没有提示信息 */
	private string title;
	/** 窗口内容 */
	private string content;
	/** 操作标识，标示此操作是否合法 */
	private string tag;
	/** 默认是不再提示,如果是空字符窜表示没有提示框选项 */
	private string confirmText;
	/** 默认是确定,如果是空字符窜表示没有此确认按钮 */
	private string okText;
	/** 默认是取消,如果是空字符窜表示没有此取消按钮 */
	private string cancelText;

	public GCShowOptionDlg ()
	{
	}

	protected override void ReadImpl()
	{
	// 窗口标题,如果是空字符窜没有提示信息
	string _title = ReadString();
	// 窗口内容
	string _content = ReadString();
	// 操作标识，标示此操作是否合法
	string _tag = ReadString();
	// 默认是不再提示,如果是空字符窜表示没有提示框选项
	string _confirmText = ReadString();
	// 默认是确定,如果是空字符窜表示没有此确认按钮
	string _okText = ReadString();
	// 默认是取消,如果是空字符窜表示没有此取消按钮
	string _cancelText = ReadString();


		this.title = _title;
		this.content = _content;
		this.tag = _tag;
		this.confirmText = _confirmText;
		this.okText = _okText;
		this.cancelText = _cancelText;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_SHOW_OPTION_DLG;
	}
	
	public override string getEventType()
	{
		return CommonGCHandler.GCShowOptionDlgEvent;
	}
	

	public string getTitle(){
		return title;
	}
		

	public string getContent(){
		return content;
	}
		

	public string getTag(){
		return tag;
	}
		

	public string getConfirmText(){
		return confirmText;
	}
		

	public string getOkText(){
		return okText;
	}
		

	public string getCancelText(){
		return cancelText;
	}
		

}
}