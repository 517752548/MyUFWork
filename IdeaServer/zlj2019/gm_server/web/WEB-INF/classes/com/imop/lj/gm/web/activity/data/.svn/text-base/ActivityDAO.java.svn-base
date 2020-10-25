package com.imop.lj.gm.web.activity.data;

import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;

import com.imop.lj.gm.dao.ParamGenericDAO;

public class ActivityDAO extends ParamGenericDAO {
	/**
	 * 查询所有活动没给奖的活动
	 */
	@SuppressWarnings("unchecked")
	public List<ActivityDataEntity> getAllActivityList() {
		return (List<ActivityDataEntity>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List<ActivityDataEntity> doCall(Session session) {
						Query query = session.getNamedQuery("getAllActivityList");
						List<ActivityDataEntity> activityDataEntityList = query.list();
						return activityDataEntityList;
					}
				});
	}
	
	/**
	 * 查询所有活动
	 */
	@SuppressWarnings("unchecked")
	public List<ActivityDataEntity> getAllActivityListAll() {
		return (List<ActivityDataEntity>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						Query query = session.getNamedQuery("getAllActivityListAll");
						List<ActivityDataEntity> activityDataEntityList = null;
						if(query!=null){
							getPagerUtil().process(session, query);
							activityDataEntityList=query.list();
						}
						return activityDataEntityList;
					}
				});
	}
	
	/**
	 * 查询发奖状态表
	 */
	@SuppressWarnings("unchecked")
	public List<ActivityGivePrizeEntity> getActivityGivePrizeEntityList() {
		return (List<ActivityGivePrizeEntity>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List<ActivityGivePrizeEntity> doCall(Session session) {
						Query query = session.getNamedQuery("getAllActivityPrizeGiveListAll");
						List<ActivityGivePrizeEntity> activityDataEntityList = query.list();
						return activityDataEntityList;
					}
				});
	}
	
	/**
	 * 查询发奖状态表
	 */
	public ActivityGivePrizeEntity getActivityGivePrizeEntity() {
		List<ActivityGivePrizeEntity> list = getActivityGivePrizeEntityList();
		return list.get(0);
	}
	
	
	/***
	 * 设置当前页
	 */
	public void setCurrnetPage(int currentPage){
		getPagerUtil().getPager().setCurrentPage(currentPage);
	}
	
	/***
	 * 设置当前页
	 */
	public int getCurrnetPage(){
		return getPagerUtil().getPager().getCurrentPage();
	}
}
