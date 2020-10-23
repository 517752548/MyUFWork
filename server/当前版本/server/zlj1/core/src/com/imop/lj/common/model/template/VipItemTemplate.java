package com.imop.lj.common.model.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.template.BeanFieldNumber;

/**
 * VIP项配置
 * 
 * @author xiaowei.liu
 * 
 */
@ExcelRowBinding
public class VipItemTemplate {
	@BeanFieldNumber(number = 1)
	private boolean open;
	@BeanFieldNumber(number = 2)
	private int num;

	public boolean isOpen() {
		return open;
	}

	public void setOpen(boolean open) {
		this.open = open;
	}

	public int getNum() {
		return num;
	}

	public void setNum(int num) {
		this.num = num;
	}

}
