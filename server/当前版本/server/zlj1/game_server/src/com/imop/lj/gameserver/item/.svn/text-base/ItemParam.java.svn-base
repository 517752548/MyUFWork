package com.imop.lj.gameserver.item;

import java.util.Collection;
import java.util.HashMap;
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
//	/** 绑定情况 */
//	private BindStatus bind;
	private String params;

	public ItemParam(int tmplId, int count) {
		super();
		this.templateId = tmplId;
		this.count = count;
//		this.bind = bind;
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

//	public Bindable.BindStatus getBind() {
//		return bind;
//	}
//
//	public void setBind(Bindable.BindStatus bind) {
//		this.bind = bind;
//	}

//	/**
//	 * 根据道具模板id，和绑定状态生成一个唯一的long型key
//	 *
//	 * @return
//	 */
//	public long getKeyByTmplIdAndBind() {
//		return Item.genKeyByTmplIdAndBind(templateId, bind);
//	}

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
		Map<Integer, ItemParam> merged = new HashMap<Integer, ItemParam>();
		for (ItemParam param : params) {
			int tmplId = param.getTemplateId();
			int key = param.getTemplateId();
			ItemParam existed = merged.get(key);
			if (existed == null) {
				existed = new ItemParam(tmplId, 0);
				merged.put(key, existed);
			}
			existed.setCount(existed.getCount() + param.getCount());
		}
		return merged.values();
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
//		if (bind == null) {
//			if (other.bind != null)
//				return false;
//		} else if (!bind.equals(other.bind))
//			return false;
		if (count != other.count)
			return false;
		if (templateId != other.templateId)
			return false;
		return true;
	}

	@Override
	public String toString() {
		return "ItemParam [count=" + count + ", tmplId=" + this.getTemplateId() + "]";
	}

//	public static enum MergeMode {
//		/** 区分绑定状态 */
//		CONSIDER_BIND,
//		/** 不区分绑定状态 */
//		IGNORE_BIND;
//	}

}
