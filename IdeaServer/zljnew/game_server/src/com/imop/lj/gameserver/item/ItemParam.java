package com.imop.lj.gameserver.item;

import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * 道具参数，各系统向道具系统发请求时使用
 *
 *
 */
public class ItemParam {
	/** 模板ID */
	private int templateId;
	/** 数量 */
	private int count;
	/** 是否绑定 */
	private boolean isBind;
	
	private String params;

	public ItemParam(int tmplId, int count, boolean isBind) {
		super();
		this.templateId = tmplId;
		this.count = count;
		this.isBind = isBind;
	}

	public int getTemplateId() {
		return templateId;
	}

	public void setTemplateId(int tmplId) {
		this.templateId = tmplId;
	}

	public int getCount() {
		return count;
	}

	public void setCount(int count) {
		this.count = count;
	}

	public boolean isBind() {
		return isBind;
	}

	public void setBind(boolean isBind) {
		this.isBind = isBind;
	}

	public String getParams() {
		return params;
	}

	public void setParams(String params) {
		this.params = params;
	}

	/**
	 * 将输入中具有相同ItemId和Bind的ItemParam合并为
	 *
	 * @param params
	 *            要个并的ItemParam
	 * @param mode
	 *            合并模式
	 * @return
	 */
	public static Collection<ItemParam> mergeByTmplId(Collection<ItemParam> params) {
		Map<Integer, ItemParam> merged1 = new HashMap<Integer, ItemParam>();
		Map<Integer, ItemParam> merged2 = new HashMap<Integer, ItemParam>();
		for (ItemParam param : params) {
			int tmplId = param.getTemplateId();
			int key = param.getTemplateId();
			//绑定和非绑定的分开放
			if (param.isBind()) {
				ItemParam existed1 = merged1.get(key);
				if (existed1 == null) {
					existed1 = new ItemParam(tmplId, 0, param.isBind());
					merged1.put(key, existed1);
				}
				existed1.setCount(existed1.getCount() + param.getCount());
			} else {
				ItemParam existed2 = merged2.get(key);
				if (existed2 == null) {
					existed2 = new ItemParam(tmplId, 0, param.isBind());
					merged2.put(key, existed2);
				}
				existed2.setCount(existed2.getCount() + param.getCount());
			}
		}
		List<ItemParam> ret = new ArrayList<ItemParam>();
		ret.addAll(merged1.values());
		ret.addAll(merged2.values());
		return ret;
	}

	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
//		result = prime * result + ((bind == null) ? 0 : bind.hashCode());
		result = prime * result + count;
		result = prime * result + templateId;
		return result;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		ItemParam other = (ItemParam) obj;
		if (isBind != other.isBind)
			return false;
		if (count != other.count)
			return false;
		if (templateId != other.templateId)
			return false;
		return true;
	}

	@Override
	public String toString() {
		return "ItemParam [templateId=" + templateId + ", count=" + count
				+ ", isBind=" + isBind + ", params=" + params + "]";
	}

}
