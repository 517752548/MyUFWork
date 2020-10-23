package com.imop.lj.gameserver.goodactivity.msg;

import java.util.List;

import com.imop.lj.common.model.goodactivity.GoodActivityInfo;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;

public class GoodActivityMsgBuilder {

	public static GCGoodActivityList buildGCGoodActivityList(FuncTypeEnum func, List<GoodActivityInfo> activityInfoList) {
		GCGoodActivityList msg = new GCGoodActivityList(func.getIndex(), activityInfoList.toArray(new GoodActivityInfo[0]));
		return msg;
	}
	
	public static GCGoodActivityUpdate buildGCGoodActivityUpdate(FuncTypeEnum func, GoodActivityInfo activityInfo) {
		return new GCGoodActivityUpdate(func.getIndex(), activityInfo);
	}
}
