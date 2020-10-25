package com.imop.lj.gameserver.xianhu;

import java.util.List;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public class XianhuDef {
	/** 排名人数 */
	public static int RankNum = 100;
	/** 排名时间Id 23:50:00 */
	public static int RankTimeEventId = 2122;
	/** 每周日排行周榜 */
	public static int RankWeekNum = 7;
	
	/**
	 * 仙葫排行榜类型
	 *
	 */
	public static enum XianhuRankType implements IndexedEnum {
		/** 祈福仙葫，今日 */
		NORMAL_TODAY(1, LangConstants.XIANHU_NAME_NORMAL_TODAY),
		/** 祈福仙葫，昨日 */
		NORMAL_YESTODAY(2, LangConstants.XIANHU_NAME_NORMAL_YESTODAY),
		
		/** 灵犀祈福，今日 */
		LINGXI_TODAY(3, LangConstants.XIANHU_NAME_LINGXI_TODAY),
		/** 灵犀祈福，昨日 */
		LINGXI_YESTODAY(4, LangConstants.XIANHU_NAME_LINGXI_YESTODAY),
		
		/** 灵犀祈福，本周 */
		LINGXI_WEEK(5, LangConstants.XIANHU_NAME_LINGXI_WEEK),
		/** 灵犀祈福，上周 */
		LINGXI_LASTWEEK(6, LangConstants.XIANHU_NAME_LINGXI_LASTWEEK),
		
		;

		private XianhuRankType(int index, Integer langId) {
			this.index = index;
			this.langId = langId;
		}

		public final int index;
		private Integer langId;
		
		@Override
		public int getIndex() {
			return index;
		}

		private static final List<XianhuRankType> values = IndexedEnumUtil
				.toIndexes(XianhuRankType.values());

		public static XianhuRankType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
		
		public Integer getLangId() {
			return this.langId;
		}
	}
	
	
	
}
