package com.imop.lj.common.model.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.template.BeanFieldNumber;

/**
 * 键值对配置
 * 
 * @author xiaowei.liu
 * 
 */
@ExcelRowBinding
public class KeyValueTemplate {
	@BeanFieldNumber(number = 1)
	private int key;
	@BeanFieldNumber(number = 2)
	private int value;

	public int getKey() {
		return key;
	}

	public void setKey(int key) {
		this.key = key;
	}

	public int getValue() {
		return value;
	}

	public void setValue(int value) {
		this.value = value;
	}

}
