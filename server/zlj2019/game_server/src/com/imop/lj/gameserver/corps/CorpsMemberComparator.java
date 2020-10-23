package com.imop.lj.gameserver.corps;

import java.util.Comparator;

import com.imop.lj.gameserver.corps.CorpsDef.MemberJob;
import com.imop.lj.gameserver.corps.model.CorpsMember;

/**
 * 军团成员比较器
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsMemberComparator implements Comparator<CorpsMember> {

	@Override
	public int compare(CorpsMember o1, CorpsMember o2) {
		if(o1.getJob() == MemberJob.PRESIDENT){
			return -1;
		}
		
		if(o2.getJob() == MemberJob.PRESIDENT){
			return 1;
		}
		
		long result = o2.getTotalContribution() - o1.getTotalContribution();
		if(result > 0){
			return 1;
		}else if(result == 0){
			return 0;
		}else{
			return -1;
		}
	}

}
