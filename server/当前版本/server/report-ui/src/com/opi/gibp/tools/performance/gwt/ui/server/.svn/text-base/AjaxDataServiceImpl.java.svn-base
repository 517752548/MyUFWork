/**
 * 
 */
package com.opi.gibp.tools.performance.gwt.ui.server;

import java.util.Iterator;
import java.util.List;
import java.util.Map;

import com.google.gwt.user.server.rpc.RemoteServiceServlet;
import com.opi.gibp.tools.performance.constants.ServerConstants;
import com.opi.gibp.tools.performance.gwt.ui.client.model.SvcList;
import com.opi.gibp.tools.performance.gwt.ui.client.service.AjaxDataService;
import com.opi.gibp.tools.performance.gwt.ui.server.model.SSOUser;
import com.opi.gibp.tools.performance.utils.db.DbHelper;

/**
 * @author Administrator
 *	服务器列表应用
 */
@SuppressWarnings("serial")
public class AjaxDataServiceImpl extends RemoteServiceServlet implements
		AjaxDataService {

	

	private String buildCondition(Map<String, Object> queryData) {
		
		
//		SSOUser user = (SSOUser) getThreadLocalRequest().getSession()
//								.getAttribute(ServerConstants.SSO_LOGINUSER);
		
		SSOUser user = SSOUser.getTestUser();
		
		String result = "";
		
		Iterator<String> keyIt = queryData.keySet().iterator();
		while(keyIt.hasNext()){
			String key = keyIt.next();
			if(key.contains("###")){
				//###处理List<DateTime>
				
			}else if(key.contains("???")){
				//???方便扩展
				
			}else if(key.contains("!!!")){
				
				
			}else if(key.contains("$$$")){
				//普通数字
				result += " and " + key + "=" + (String)queryData.get(key) + " ";
				
			}else{//字符字段 id=searchValue 
				result += " and " + key + "='" + (String)queryData.get(key) + "' ";
			}
			
		}
		
		//添加游戏权限划分
		result += " and gameid in('" + user.getGameids().replace(",", "','") + "')";
		
		result += " order by svrid asc , svc_type desc ,svcid desc";
		return result;
	}


	/* (non-Javadoc)
	 * @see com.opi.gibp.tools.performance.gwt.ui.client.AjaxDataService#getGameSvrsByCond(java.util.Map)
	 */
	@Override
	public List<SvcList> getGameSvrsByCond(Map<String, Object> condMap) {
		String sql = "select * from svclist where 1=1 ";
		String cond = buildCondition(condMap);
		sql += cond;
		System.out.println(sql);
		List<SvcList> gameSvrList = null;
		try{
			gameSvrList = DbHelper.Select(sql, "com.opi.gibp.tools.performance.gwt.ui.client.model.SvcList");
		}catch (Exception e) {
			e.printStackTrace();
		}
		
		return gameSvrList;
	}
}
