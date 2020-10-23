package com.imop.lj.gameserver.func;

import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;

public interface IFunc {

	FuncTypeEnum getFuncType();
	
	boolean onChanged();
	
	boolean canOpen();
	
	boolean canShowEffect();
	
	int getShowNum();
	
	long getCountDownTime();
	
	String getIcon();
	
	long getMaxCountDownTime();
	
	String getMenuDesc();
	
}
