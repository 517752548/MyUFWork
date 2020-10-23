package com.imop.lj.gm.page;

import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;

/**
 * GM平台系统<br>
 * 分页接口
 *
 * @author linfan 2009-10-12
 */
public interface IPaginationHelper {

	/**
	 * 得到分页对象
	 * @return
	 */
    public Pager getPager();

    /**
	 * 设置分页对象
	 * @return
	 */
    public void setPager(Pager pager);

    /**
     * 处理待分页的数据
     * @param session
     * @param query
     */
    public void process(Session session, Query query);

    /**
     * 处理待分页的数据
     * @param session
     * @param query
     */
	public List<Object> processList(Object[] ob);



}
