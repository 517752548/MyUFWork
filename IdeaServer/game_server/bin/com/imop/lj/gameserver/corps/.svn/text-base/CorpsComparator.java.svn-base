package com.imop.lj.gameserver.corps;

import java.util.Comparator;

import com.imop.lj.gameserver.corps.model.Corps;

/**
 * 军团排序比较器
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsComparator implements Comparator<Corps> {

	@Override
	public int compare(Corps o1, Corps o2) {
		int level = o2.getLevel() - o1.getLevel();
		if (level > 0) {
			return 1;
		}

		if (level < 0) {
			return -1;
		}

		long currExp = o2.getCurrExp() - o1.getCurrExp();
		if (currExp > 0) {
			return 1;
		} else if (currExp == 0) {
			return 0;
		} else {
			return -1;
		}
	}

}
