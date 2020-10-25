package com.imop.lj.gameserver.func;

import com.imop.lj.gameserver.human.Human;

public interface IFuncFactory {
	
	public AbstractFunc createNewFunc(Human owner);
	
}
