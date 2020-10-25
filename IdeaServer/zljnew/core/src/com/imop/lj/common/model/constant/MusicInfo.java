package com.imop.lj.common.model.constant;

import com.imop.lj.common.model.KeyValueInfo;

public class MusicInfo {
	private int moduleId;
	private KeyValueInfo[] keyValueList;

	public int getModuleId() {
		return moduleId;
	}

	public void setModuleId(int moduleId) {
		this.moduleId = moduleId;
	}

	public KeyValueInfo[] getKeyValueList() {
		return keyValueList;
	}

	public void setKeyValueList(KeyValueInfo[] keyValueList) {
		this.keyValueList = keyValueList;
	}

}
