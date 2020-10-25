package com.imop.lj.gameserver.common;

import java.util.ArrayList;
import java.util.List;

/**
 * 分页工具类
 * 
 * @author xiaowei.liu
 * 
 */
public class PageUtil {
	/**
	 * 获取分页结果
	 * 
	 * @param <T>
	 * @param sourceList
	 * @param page
	 * @param numPerPage
	 * @return
	 */
	public static <T> PageResult<T> getPageResult(List<T> sourceList, int page,	int numPerPage) {
		int size = sourceList.size();		
		if(size == 0){
			return new PageResult<T>();
		}
		
		//最大页
		int maxPage = (size - 1) / numPerPage + 1;
		//当前页
		page = page > maxPage ? maxPage : page;
		page = page < 1 ? 1 : page;
		
		//起始下标
		int begin = (page - 1) * numPerPage;
		//结束下标
		int end = begin + numPerPage - 1;
		end = end > (size - 1) ? size - 1 : end;
		
		List<T> result = new ArrayList<T>();
		for(int i = begin ; i <= end; i++){
			result.add(sourceList.get(i));
		}
		
		PageResult<T> pr = new PageResult<T>();
		pr.setResultList(result);
		pr.setCurrPage(page);
		pr.setMaxPage(maxPage);
		
		return pr;
	}

	/**
	 * 查询结果
	 * 
	 * @author xiaowei.liu
	 * 
	 * @param <T>
	 */
	public static class PageResult<T> {
		/** 分页结果 */
		private List<T> resultList;
		/** 当前页 */
		private int currPage;
		/** 最大页 */
		private int maxPage;

		public PageResult(){
			this.resultList = new ArrayList<T>();
			this.currPage = 0;
			this.maxPage = 0;
		}
		
		public List<T> getResultList() {
			return resultList;
		}

		public void setResultList(List<T> resultList) {
			this.resultList = resultList;
		}

		public int getCurrPage() {
			return currPage;
		}

		public void setCurrPage(int currPage) {
			this.currPage = currPage;
		}

		public int getMaxPage() {
			return maxPage;
		}

		public void setMaxPage(int maxPage) {
			this.maxPage = maxPage;
		}

	}
}
