package com.imop.lj.gm.page;

import java.util.ArrayList;
import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;

/**
 * GM平台系统
 *
 * @author lin fan 2009-10-12
 */
public class PaginationHelperScrollableImpl implements IPaginationHelper {

	/** 分页实体*/
	private Pager pager;

	/** Session*/
	private Session session;

	/** 默认最大记录*/
	private String maxResults ;

	/**
	 * 分页处理方法
	 * @param query
	 *
	 */
	public void process(Session session, Query query) {
		if ((pager != null) && pager.isPagenation()) {
			setSession(session);
			pager.calculateDisplayPageTagList();
			query.setFirstResult(pager.getStartPos());
			query.setMaxResults(pager.getPageSize());
		}
	}

	public Pager getPager() {
		return pager;
	}

	public void setPager(Pager pager) {
		this.pager = pager;
	}

	public Session getSession() {
		return session;
	}

	public void setSession(Session session) {
		this.session = session;
	}

	public String getMaxResults() {
		return maxResults;
	}

	public void setMaxResults(String maxResults) {
		this.maxResults = maxResults;
	}

	@Override
	public List<Object> processList(Object[] ob) {
		List<Object> list = new ArrayList<Object>();
		if ((pager != null) && pager.isPagenation()&&(ob!=null)) {
			pager.calculateDisplayPageTagList();
			int statPos = pager.getStartPos();
			int maxResults = pager.getPageSize();
			if(statPos>=ob.length){
				return list;
			}
			int len=ob.length;
			if(len>statPos+maxResults){
				len=statPos+maxResults;
			}
			for(int i=statPos;i<len; i++){

				list.add(ob[i]);
			}
		}
		return list;

	}



}
