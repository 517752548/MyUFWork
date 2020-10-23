/**
 * 
 */
package com.opi.gibp.tools.performance.gwt.ui.client.service;

import java.util.List;
import java.util.Map;

import com.google.gwt.user.client.rpc.RemoteService;
import com.google.gwt.user.client.rpc.RemoteServiceRelativePath;
import com.opi.gibp.tools.performance.gwt.ui.client.model.SvcList;

/**
 * @author Administrator
 *
 */
@RemoteServiceRelativePath("initPanel")
public interface AjaxDataService extends RemoteService {
	public List<SvcList> getGameSvrsByCond(Map<String,Object> condMap); 
}
