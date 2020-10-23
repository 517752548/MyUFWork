package com.imop.lj.gm.page;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

/**
 * GM平台系统<br>
 * 分页JavaBean
 *
 * @author linfan
 */
@SuppressWarnings("serial")
public class Pager implements Serializable {

	/** 当前页 */
	private int currentPage;

	/** 每页数据size */
	private int pageSize;

    /** 结果集中总的记录数*/
	private int resultCount;

	/** 展示页标签数*/
	private int displayPageTagSize;

	/** 展示页标签List*/
	private List<Integer> displayPageTagList = new ArrayList<Integer>();

	/** 分页标志*/
	private boolean isPagenation = false;

	/**
	 * 取得当前页码
	 *
	 * @return 当前页码
	 */
	public int getCurrentPage() {
		return currentPage;
	}

	/**
	 * 设置当前页码
	 *
	 * @param currentPage
	 *            当前页码
	 */
	public void setCurrentPage(int currentPage) {
		this.currentPage = currentPage;
	}


	/**
	 * 取得每页显示的记录数
	 *
	 * @return 每页显示的记录数
	 */
	public int getPageSize() {
		return pageSize;
	}

	/**
	 * 设置每页显示的记录数
	 *
	 * @param pageSize
	 *            每页显示的记录数
	 */
	public void setPageSize(int pageSize) {
		this.pageSize = pageSize;
	}

	/**
	 * 取得结果集中总的记录数
	 *
	 * @return 结果集中总的记录数
	 */
	public int getResultCount() {
		return resultCount;
	}

	/**
	 * 设置结果集中总的记录数
	 *
	 * @param resultCount
	 *            结果集中总的记录数
	 */
	public void setResultCount(int resultCount) {
		this.resultCount = resultCount;
	}

	/**
	 * 取得从结果集中取记录的起点
	 *
	 * @return 结果集中取记录的起点
	 */
	public int getStartPos() {
		return (this.currentPage - 1) * pageSize;
	}

	/**
	 * 计算显示的页号集合
	 */
	public void calculateDisplayPageTagList() {
		int midPage = displayPageTagSize / 2;
		List<Integer> pageNo = new ArrayList<Integer>();
        if (currentPage - midPage <= 0) {
			for (int i = 1; i <= displayPageTagSize; i++) {
					pageNo.add(i);
				}
			}
		 else {
			for (int i = currentPage - midPage; i <= currentPage + midPage; i++) {
				pageNo.add(i);
			}
		}
		this.setDisplayPageTagList(pageNo);
	}

	/**
	 * 设置要显示的页号数
	 *
	 * @param displayPageTagSize
	 *            要显示的页号数
	 */
	public void setDisplayPageTagSize(int displayPageTagSize) {
		this.displayPageTagSize = displayPageTagSize;
	}

	public int getDisplayPageTagSize() {
		return displayPageTagSize;
	}

	public List<Integer> getDisplayPageTagList() {
		return displayPageTagList;
	}

	public void setDisplayPageTagList(List<Integer> displayPageTagList) {
		this.displayPageTagList = displayPageTagList;
	}

	/**
	 * 是否分页
	 *
	 * @return 要分页,返回真;反之,返回假.
	 */
	public boolean isPagenation() {
		return isPagenation;
	}

	/**
	 * 设置是否分页.
	 *
	 * @param isPagenation
	 *            是否分页.真,表示要分页;假,表示不分页.
	 */
	public void setPagenation(boolean isPagenation) {
		this.isPagenation = isPagenation;
	}
}
