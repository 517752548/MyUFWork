package com.imop.lj.gm.model.log;

import java.util.List;

/**
 * 聊天日志
 * @author zhiyuan.luo
 *
 */
public class ChatLog extends BaseLog {
    private int scope;
    private String recCharName;
    private String content;

	public int getScope() {
		return scope;
	}

	public void setScope(int scope) {
		this.scope = scope;
	}

	public String getRecCharName() {
		return recCharName;
	}

	public void setRecCharName(String recCharName) {
		this.recCharName = recCharName;
	}

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List toList() {
		List list = super.toList();
		list.add(scope);
		list.add(recCharName);
		list.add(content);
		return list;
	}
}