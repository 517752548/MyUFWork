package com.imop.lj.gameserver.common.listener;

import com.imop.lj.core.event.IEventListener;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.OpenFuncEvent;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;

public class OpenFuncListener implements IEventListener<OpenFuncEvent> {

	@Override
	public void fireEvent(OpenFuncEvent event) {
		Human human = event.getInfo();
		FuncTypeEnum funcType = event.getFuncType();
		
		Globals.getPetService().onOpenFunc(human, funcType);
		Globals.getPubTaskService().onOpenFunc(human, funcType);
		Globals.getForageTaskService().onOpenFunc(human, funcType);
		Globals.getCorpsTaskService().onOpenFunc(human, funcType);
		
		//新手引导
		Globals.getGuideService().onOpenFunc(human, funcType);
	}
}
