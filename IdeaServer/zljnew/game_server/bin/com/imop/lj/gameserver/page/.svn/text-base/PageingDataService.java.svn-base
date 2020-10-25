package com.imop.lj.gameserver.page;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.TerminalTypeEnum;
/*
 * 1:getPageNumForEach 获取每页要显示的内容数目
 * 2:getShowoffPagingDataList  获得要求显示的数目内容(例如 排行榜 SORTLEVEL 200进帮,显示50  全显示不用调用)
 * 3:getTotalPageNum 得到总页数
 * 4:getSortOrCommercePage 排行榜,商会用 原因从0开始,其他从1开始(规定新加的从1开始,从1开始不用调用此方法)
 * 5:getCurrenrtPageNum 获取当前页页码值
 * 6:getSubPagingDataList 分页显示每页内容
 */
public class PageingDataService implements InitializeRequired{
	public PageingDataService(){}
	@Override
	public void init() {
		// TODO Auto-generated method stub
		
	}
	/*
	 * 获得总页数
	 * pagingSourceList 分页源信息
	 * pageNumForEach 每页显示数
	 * totalNum  总显示数目,没有限制时传0
	 * 返回值 totalPage可能等于0没有数据
	 */
	public int getTotalPageNum(List<? extends Object> pagingSourceList,int pageNumForEach) {
		int totalPage = 0;
		if(pagingSourceList == null){
			return totalPage;
		}
		int totalNums = pagingSourceList.size();
		if (totalNums % pageNumForEach != 0) {
			totalPage = totalNums / pageNumForEach + 1;
		} else {
			totalPage = totalNums / pageNumForEach;
		}
		//返回分页信息
		return totalPage;
	}
	/*
	 * 分页显示每页内容
	 * pagingSourceList 分页源信息
	 * terminalTypeEnum 终端类型
	 * currentPage  当前页从1开始
	 * pageNum 总页数
	 * totalNum  总显示数目,没有限制时传0
	 * 返回值 可能没有数据,要判断list.size()>0
	 */
	public List<? extends Object> getSubPagingDataList(List<? extends Object> pagingSourceList, int pageNumForEach, int currentPage) {
		//分页显示信息
		List<Object> currentPageList = new ArrayList<Object>();	
		if(pagingSourceList == null){
			return currentPageList;
		}
		int pageIndex = currentPage-1;
		if(pageIndex < 0 ){
			return currentPageList;
		}
		int startNum = pageIndex * pageNumForEach;
		int endNum = (pageIndex + 1) * pageNumForEach;
		if(endNum > pagingSourceList.size()){
			endNum = pagingSourceList.size();
		}
		currentPageList = getSubDataList(pagingSourceList,startNum,endNum);
		//返回分页信息
		return currentPageList;
	}
	/*
	 * 获得当前页页码值
	 * totalPage 总页码
	 * currentPage 当前页
	 */
	public int getCurrenrtPageNum(int totalPage,int currentPage){
		totalPage = totalPage < 1 ? 1 : totalPage;
		currentPage = currentPage < 1 ? 1 : (currentPage > totalPage ? totalPage : currentPage);
		return currentPage;
	}
	/*
	 * 获得要求显示的数目内容
	 * pagingSourceList 源信息
	 * pageDataEnum 种类 (例如 排行榜 SORTLEVEL 200进帮,显示50)
	 */
	public List<? extends Object> getShowoffPagingDataList(List<? extends Object> pagingSourceList,PageDataEnum pageDataEnum) {
		List<Object> currentPageList = new ArrayList<Object>();	
		if(pagingSourceList == null){
			return currentPageList;
		}
		//显示数目  默认是排行的
		int showoffPageingData = ShowOffPageNums.getShowOffPageNumsInstance().getShowOffNums(pageDataEnum);
		if(showoffPageingData>pagingSourceList.size()){
			showoffPageingData = pagingSourceList.size();
		}
		currentPageList = getSubDataList(pagingSourceList,0,showoffPageingData);
		//返回要显示的内容信息
		return currentPageList;
	}
	/*
	 * 获取分页显示,每页显示数据的数目
	 * terminalTypeEnum终端类型
	 * pageDataEnum 种类(例如 排行榜 SORTLEVEL)
	 */
	public int getPageNumForEach(PageDataEnum pageDataEnum,TerminalTypeEnum terminalTypeEnum){
		return PageNumForEach.getPageNumForEachInstance().getPageNumForEachNums(pageDataEnum, terminalTypeEnum);
	}
	/*
	 * 排行榜,商会用 原因从0开始,其他从1开始
	 */
	public int getSortOrCommercePage(int pageNum){
		return pageNum+1;
	}
	//分页具体信息
	private List<Object> getSubDataList(List<? extends Object> pagingSourceList,int start,int end){
		int startNum = start;
		int endNum = end;
		List<Object> currentPageList = new ArrayList<Object>();
		if(end > pagingSourceList.size()){
			return currentPageList;
		}
		if(startNum < 0){
			return currentPageList;
		}
		for(int i=startNum; i< endNum; i++){
			currentPageList.add(pagingSourceList.get(i));
		}
		return currentPageList;
	}
}
