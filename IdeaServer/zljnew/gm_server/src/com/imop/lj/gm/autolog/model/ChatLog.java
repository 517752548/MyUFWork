package com.imop.lj.gm.autolog.model;
import java.util.List;
import com.imop.lj.gm.model.log.BaseLog;
/**
 * This is an auto generated source,please don't modify it.
 */
 
public class ChatLog extends BaseLog{

	//聊天范围
    private int scope;
	//如果为私聊，则记录私聊消息的接收玩家角色名称,否则该字段无意义
    private String recCharName;
	//聊天的内容
    private String content;

	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(scope);
		list.add(recCharName);
		list.add(content);
		return list;
	}
	
	public int getScope() {
		return scope;
	}
	public String getRecCharName() {
		return recCharName;
	}
	public String getContent() {
		return content;
	}
        
	public void setScope(int scope) {
		this.scope = scope;
	}
	public void setRecCharName(String recCharName) {
		this.recCharName = recCharName;
	}
	public void setContent(String content) {
		this.content = content;
	}

}