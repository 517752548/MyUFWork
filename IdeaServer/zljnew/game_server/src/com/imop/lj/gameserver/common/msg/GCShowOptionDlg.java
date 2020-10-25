package com.imop.lj.gameserver.common.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 显示确认对话框
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCShowOptionDlg extends GCMessage{
	
	/** 窗口标题,如果是空字符窜没有提示信息 */
	private String title;
	/** 窗口内容 */
	private String content;
	/** 操作标识，标示此操作是否合法 */
	private String tag;
	/** 默认是不再提示,如果是空字符窜表示没有提示框选项 */
	private String confirmText;
	/** 默认是确定,如果是空字符窜表示没有此确认按钮 */
	private String okText;
	/** 默认是取消,如果是空字符窜表示没有此取消按钮 */
	private String cancelText;

	public GCShowOptionDlg (){
	}
	
	public GCShowOptionDlg (
			String title,
			String content,
			String tag,
			String confirmText,
			String okText,
			String cancelText ){
			this.title = title;
			this.content = content;
			this.tag = tag;
			this.confirmText = confirmText;
			this.okText = okText;
			this.cancelText = cancelText;
	}

	@Override
	protected boolean readImpl() {

	// 窗口标题,如果是空字符窜没有提示信息
	String _title = readString();
	//end


	// 窗口内容
	String _content = readString();
	//end


	// 操作标识，标示此操作是否合法
	String _tag = readString();
	//end


	// 默认是不再提示,如果是空字符窜表示没有提示框选项
	String _confirmText = readString();
	//end


	// 默认是确定,如果是空字符窜表示没有此确认按钮
	String _okText = readString();
	//end


	// 默认是取消,如果是空字符窜表示没有此取消按钮
	String _cancelText = readString();
	//end



		this.title = _title;
		this.content = _content;
		this.tag = _tag;
		this.confirmText = _confirmText;
		this.okText = _okText;
		this.cancelText = _cancelText;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 窗口标题,如果是空字符窜没有提示信息
	writeString(title);


	// 窗口内容
	writeString(content);


	// 操作标识，标示此操作是否合法
	writeString(tag);


	// 默认是不再提示,如果是空字符窜表示没有提示框选项
	writeString(confirmText);


	// 默认是确定,如果是空字符窜表示没有此确认按钮
	writeString(okText);


	// 默认是取消,如果是空字符窜表示没有此取消按钮
	writeString(cancelText);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_SHOW_OPTION_DLG;
	}
	
	@Override
	public String getTypeName() {
		return "GC_SHOW_OPTION_DLG";
	}

	public String getTitle(){
		return title;
	}
		
	public void setTitle(String title){
		this.title = title;
	}

	public String getContent(){
		return content;
	}
		
	public void setContent(String content){
		this.content = content;
	}

	public String getTag(){
		return tag;
	}
		
	public void setTag(String tag){
		this.tag = tag;
	}

	public String getConfirmText(){
		return confirmText;
	}
		
	public void setConfirmText(String confirmText){
		this.confirmText = confirmText;
	}

	public String getOkText(){
		return okText;
	}
		
	public void setOkText(String okText){
		this.okText = okText;
	}

	public String getCancelText(){
		return cancelText;
	}
		
	public void setCancelText(String cancelText){
		this.cancelText = cancelText;
	}
}