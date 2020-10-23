package com.imop.lj.tools.msg;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

/**
 * 协议对象
 *
 * @author jackflit
 */
public class MessageObject implements Comparable<MessageObject> {
	private String type;
	private String className;
	private String comment;
	private String module;
	private boolean hasListField;
	private boolean listMsg;
	/** 是否在玩家的消息队列中处理，只对WG类型的消息起作用 */
	private boolean playerQueue;
	/** 是否将消息放在好友线程中处理，只能GW类型的消息起作用 */
	private boolean friendQueue;
	/** 是否将消息放在公会线程中处理，只能GW类型的消息起作用 */
	private boolean guildQueue;
	/** 是否是压缩消息*/
	private boolean compress;

	private List<FieldObject> fields; // field;
	private List<FieldObject> subMsgs;
	private String handleMethodName;

	private boolean hasBytesField;
	
	private String fieldAsContent;
	
	private String fieldJavaReadContent;
	private String fieldJavaWriteContent;
	
	private String fieldCppContent;
	
	private String fieldLuaContent;
	
	private String fieldCsReadContent;
	private String fieldCsWriteContent;
	

	public boolean getHasBytesField() {
		return hasBytesField;
	}

	public void setHasBytesField(boolean hasBytesField) {
		this.hasBytesField = hasBytesField;
	}

	public MessageObject() {
		type = "CG_UNKNOW_MESSAGE";
		className = "UnknownMessage";
		fields = new ArrayList<FieldObject>();
		subMsgs = new ArrayList<FieldObject>();
		hasBytesField = false;
	}

	public void addField(FieldObject fld) {
		if (fld.getBytes()) {
			hasBytesField = true;
		}
		fields.add(fld);
	}

	public void addSubMsg(FieldObject fld) {
		subMsgs.add(fld);
	}

	public List<FieldObject> getFields() {
		return Collections.unmodifiableList(fields);
	}

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public String getClassName() {
		return className;
	}

	public void setClassName(String className) {
		this.className = className;
	}

	public String getComment() {
		return comment;
	}

	public void setComment(String comment) {
		this.comment = comment;
	}

	public String getModule() {
		return module;
	}

	public void setModule(String module) {
		this.module = module;
	}

	@Override
	public int compareTo(MessageObject arg0) {
		return type.compareTo(arg0.type);
	}

	public void setHasListField(boolean hasListField) {
		this.hasListField = hasListField;
	}

	public boolean getHasListField() {
		return hasListField;
	}

	public void setHandleMethodName(String handleMethodName) {
		this.handleMethodName = handleMethodName;
	}

	public String getHandleMethodName() {
		return handleMethodName;
	}

	public void setListMsg(boolean listMsg) {
		this.listMsg = listMsg;
	}

	public boolean getListMsg() {
		return listMsg;
	}

	public void setSubMsgs(List<FieldObject> subMsgs) {
		this.subMsgs = subMsgs;
	}

	public List<FieldObject> getSubMsgs() {
		return subMsgs;
	}

	/**
	 * @return
	 */
	public int getFieldSize() {
		return fields.size() + subMsgs.size();
	}

	public void setPlayerQueue(boolean playerQueue) {
		this.playerQueue = playerQueue;
	}

	public boolean isPlayerQueue() {
		return playerQueue;
	}

	public boolean isFriendQueue() {
		return friendQueue;
	}

	public boolean isGuildQueue() {
		return guildQueue;
	}

	public void setFriendQueue(boolean friendQueue) {
		this.friendQueue = friendQueue;
	}

	public void setGuildQueue(boolean guildQueue) {
		this.guildQueue = guildQueue;
	}
	
	public String getFieldAsContent() {
		return fieldAsContent;
	}

	public void setFieldAsContent(String fieldAsContent) {
		this.fieldAsContent = fieldAsContent;
	}
	
	public String getFieldJavaReadContent() {
		return fieldJavaReadContent;
	}

	public void setFieldJavaReadContent(String fieldJavaReadContent) {
		this.fieldJavaReadContent = fieldJavaReadContent;
	}

	public String getFieldJavaWriteContent() {
		return fieldJavaWriteContent;
	}

	public void setFieldJavaWriteContent(String fieldJavaWriteContent) {
		this.fieldJavaWriteContent = fieldJavaWriteContent;
	}

	public String getFieldCppContent() {
		return fieldCppContent;
	}

	public void setFieldCppContent(String fieldCppContent) {
		this.fieldCppContent = fieldCppContent;
	}

	public boolean isCompress() {
		return compress;
	}

	public void setCompress(boolean compress) {
		this.compress = compress;
	}
	
	public String getFieldLuaContent() {
		return fieldLuaContent;
	}

	public void setFieldLuaContent(String fieldLuaContent) {
		this.fieldLuaContent = fieldLuaContent;
	}

	public String getFieldCsReadContent() {
		return fieldCsReadContent;
	}

	public void setFieldCsReadContent(String fieldCsReadContent) {
		this.fieldCsReadContent = fieldCsReadContent;
	}

	public String getFieldCsWriteContent() {
		return fieldCsWriteContent;
	}

	public void setFieldCsWriteContent(String fieldCsWriteContent) {
		this.fieldCsWriteContent = fieldCsWriteContent;
	}

	@Override
	public String toString() {
		return "MessageObject [type=" + type + ", className=" + className + ", comment=" + comment + ", module=" + module + ", hasListField="
				+ hasListField + ", listMsg=" + listMsg + ", playerQueue=" + playerQueue + ", friendQueue=" + friendQueue + ", guildQueue="
				+ guildQueue + ", compress=" + compress + ", fields=" + fields + ", subMsgs=" + subMsgs + ", handleMethodName=" + handleMethodName
				+ ", hasBytesField=" + hasBytesField + ", fieldAsContent=" + fieldAsContent + ", fieldJavaReadContent=" + fieldJavaReadContent
				+ ", fieldJavaWriteContent=" + fieldJavaWriteContent + ", fieldCppContent=" + fieldCppContent + ", fieldLuaContent="
				+ fieldLuaContent + ", fieldCsReadContent=" + fieldCsReadContent + ", fieldCsWriteContent=" + fieldCsWriteContent + "]";
	}

}
