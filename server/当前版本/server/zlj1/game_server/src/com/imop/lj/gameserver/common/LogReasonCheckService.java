package com.imop.lj.gameserver.common;

import java.util.HashSet;
import java.util.Set;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons;
import com.imop.lj.common.LogReasons.ILogReason;
import com.imop.lj.common.constants.Loggers;

/**
 * LogReason 检测
 * 
 * @author xiaowei.liu
 * 
 */
public class LogReasonCheckService implements InitializeRequired {

	@Override
	public void init() {
		boolean hasError = false;
		for(Class<?> clazz : LogReasons.class.getClasses()){
			if(!clazz.isEnum()){
				continue;
			}
			
			Set<Integer> set = new HashSet<Integer>();
			for(Object obj : clazz.getEnumConstants()){
				if(!(obj instanceof ILogReason)){
					continue;
				}
				
				ILogReason logReason = (ILogReason)obj;
				int reason = logReason.getReason();
				if(set.contains(reason)){
					hasError = true;
					Loggers.gameLogger.error(clazz.getName() + " reason = " + reason + "重复");
				}else{
					set.add(reason);
				}
			}
		}
		
		if(hasError){
			throw new RuntimeException("#LogReasonCheckService#LogReasons 下标重复");
		}
	}

}
