package com.imop.lj.gameserver.dirtywords;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.IKeyWordsFilter;
import com.imop.lj.gameserver.common.Globals;

public class WorldsDirtyNetCallBack implements WordsDirtyNetOperationCallBack {
	private DirtyWordsTypeEnum dirtyWorldsTypeEnum;
	
	public WorldsDirtyNetCallBack(DirtyWordsTypeEnum dirtyWorldsTypeEnum){
		this.dirtyWorldsTypeEnum = dirtyWorldsTypeEnum;
	}
	
	@Override
	public void afterCheckComplete(IKeyWordsFilter filter) {
		Loggers.dirtyWordsLogger.info("DirFilterNetService.WorldsDirtyNetCallBack.afterCheckComplete() dirtyWorldsTypeEnum="
				+ dirtyWorldsTypeEnum.getIndex());
		// 更新过滤器
		Globals.getDirtFilterService().updateFilter(filter, dirtyWorldsTypeEnum);
	}
}