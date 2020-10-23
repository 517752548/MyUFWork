package com.imop.lj.gameserver.page;

import com.imop.lj.common.constants.TerminalTypeEnum;

public class PageNumForEach {
	private static final PageNumForEach pageNumForEach = new PageNumForEach();
	private PageNumForEach(){}
	/*
	 * 获得PageNumForEach类
	 */
	public static PageNumForEach getPageNumForEachInstance(){
		return pageNumForEach;
	}
	/*
	 * 获得每页显示数目
	 * terminalTypeEnum终端类型
	 * pageDataEnum 种类(例如 排行榜 SORTLEVEL)
	 */
	public int getPageNumForEachNums(PageDataEnum pageDataEnum,TerminalTypeEnum terminalTypeEnum){
		int pageNumForEach = 0;
		switch (pageDataEnum){
//		case PAGEDATA_SHOP_SOUAL:
//			switch (terminalTypeEnum) {
//			case ANDROID:
//			case IPHONE:
//				pageNumForEach = Globals.getGameConstants().getShopSouralIphonePageNum();
//				break;
//			case IPAD:
//				pageNumForEach = Globals.getGameConstants().getShopSouralIpadPageNum();
//				break;
//			case WEB:
//				pageNumForEach = Globals.getGameConstants().getShopSouralWebPageNum();
//				break;
//			default:
//				pageNumForEach = Globals.getGameConstants().getShopSouralWebPageNum();
//				break;
//			}
//			break;
//		case COMMERCE:
//			switch (terminalTypeEnum) {
//			case ANDROID:
//			case IPHONE:
//				pageNumForEach = Globals.getGameConstants().getCommerceIphonePageNum();
//				break;
//			case IPAD:
//				pageNumForEach = Globals.getGameConstants().getCommerceIpadPageNum();
//				break;
//			case WEB:
//				pageNumForEach = Globals.getGameConstants().getCommerceWebPageNum();
//				break;
//			default:
//				pageNumForEach = Globals.getGameConstants().getCommerceWebPageNum();
//				break;
//			}
//			break;
//		case SORTLEVEL:
//			switch (terminalTypeEnum) {
//			case ANDROID:
//			case IPHONE:
//				pageNumForEach = Globals.getGameConstants().getIphonePageNum();
//				break;
//			case IPAD:
//				pageNumForEach = Globals.getGameConstants().getPadPageNum();
//				break;
//			case WEB:
//				pageNumForEach = Globals.getGameConstants().getWebPageNum();
//				break;
//			default:
//				pageNumForEach = Globals.getGameConstants().getWebPageNum();
//				break;
//			}
//			break;
//		case FLOWERSTOP:
//			switch (terminalTypeEnum) {
//			case ANDROID:
//			case IPHONE:
//				pageNumForEach = Globals.getGameConstants().getFlowersLogTopIphone();
//				break;
//			case IPAD:
//				pageNumForEach = Globals.getGameConstants().getFlowersLogTopIpad();
//				break;
//			case WEB:
//				pageNumForEach = Globals.getGameConstants().getFlowersLogTopWeb();
//				break;
//			default:
//				pageNumForEach = Globals.getGameConstants().getFlowersLogTopWeb();
//				break;
//			}
//			break;
//		case FLOWERSPAGEING:
//			switch (terminalTypeEnum) {
//			case ANDROID:
//			case IPHONE:
//				pageNumForEach = Globals.getGameConstants().getFlowersLogIphone();
//				break;
//			case IPAD:
//				pageNumForEach = Globals.getGameConstants().getFlowersLogIpad();
//				break;
//			case WEB:
//				pageNumForEach = Globals.getGameConstants().getFlowersLogWeb();
//				break;
//			default:
//				pageNumForEach = Globals.getGameConstants().getFlowersLogWeb();
//				break;
//			}
//			break;
		default:
			break;
		}
		return pageNumForEach;
	}
}
