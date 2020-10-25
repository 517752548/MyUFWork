package com.imop.lj.gameserver.activity.template;

import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.template.BeanFieldNumber;

@ExcelRowBinding
public class ActivityFunctionTemplate {
	/**  活动图标 */
	@ExcelCellBinding(offset = 14)
	@BeanFieldNumber(number = 1)
	private int activtyType;

	/** 参数1 */
	@ExcelCellBinding(offset = 15)
	@BeanFieldNumber(number = 2)
	private int param1;

	/** 参数2 */
	@ExcelCellBinding(offset = 16)
	@BeanFieldNumber(number = 3)
	private int param2;

	/** 参数3 */
	@ExcelCellBinding(offset = 17)
	@BeanFieldNumber(number = 4)
	private int param3;

	/** 参数4 */
	@ExcelCellBinding(offset = 18)
	@BeanFieldNumber(number = 5)
	private int param4;

	/** 参数5 */
	@ExcelCellBinding(offset = 19)
	@BeanFieldNumber(number = 6)
	private int param5;

	public int getActivtyType() {
		return activtyType;
	}

	public void setActivtyType(int activtyType) {
		this.activtyType = activtyType;
	}

	public int getParam1() {
		return param1;
	}

	public void setParam1(int param1) {
		this.param1 = param1;
	}

	public int getParam2() {
		return param2;
	}

	public void setParam2(int param2) {
		this.param2 = param2;
	}

	public int getParam3() {
		return param3;
	}

	public void setParam3(int param3) {
		this.param3 = param3;
	}

	public int getParam4() {
		return param4;
	}

	public void setParam4(int param4) {
		this.param4 = param4;
	}

	public int getParam5() {
		return param5;
	}

	public void setParam5(int param5) {
		this.param5 = param5;
	}
}
