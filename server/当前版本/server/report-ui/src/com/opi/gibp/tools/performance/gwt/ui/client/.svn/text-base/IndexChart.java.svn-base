package com.opi.gibp.tools.performance.gwt.ui.client;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.google.gwt.core.client.EntryPoint;
import com.google.gwt.core.client.GWT;
import com.google.gwt.user.client.Window;
import com.google.gwt.user.client.rpc.AsyncCallback;
import com.google.gwt.user.client.ui.RootPanel;
import com.opi.gibp.tools.performance.gwt.ui.client.model.MainContentPanel;
import com.opi.gibp.tools.performance.gwt.ui.client.model.MainSearchPanel;
import com.opi.gibp.tools.performance.gwt.ui.client.model.SvcList;
import com.opi.gibp.tools.performance.gwt.ui.client.service.AjaxDataService;
import com.opi.gibp.tools.performance.gwt.ui.client.service.AjaxDataServiceAsync;
import com.opi.gibp.tools.performance.gwt.ui.client.service.SSOService;
import com.opi.gibp.tools.performance.gwt.ui.client.service.SSOServiceAsync;

/**
 * Entry point classes define <code>onModuleLoad()</code>.
 */
public class IndexChart implements EntryPoint {
	
	private AjaxDataServiceAsync dataSvr = GWT.create(AjaxDataService.class);
	private SSOServiceAsync ssoService = GWT.create(SSOService.class);
	private static String ssoMailURL = "";
	
	public void onModuleLoad() {
		build();
//		ssoService.getSsoMailURL(new AsyncCallback<String>() {
//
//			@Override
//			public void onFailure(Throwable caught) {
//				Window.alert(caught.getLocalizedMessage());
//			}
//
//			@Override
//			public void onSuccess(String result) {
//				ssoMailURL = result  ;
//				loginAndDisplay();
//			}
//		});
		
		
	}



	private void loginAndDisplay() {
		ssoService.checkLogin(new AsyncCallback<String>() {

			@Override
			public void onFailure(Throwable caught) {
				Window.alert(caught.getLocalizedMessage());
				Window.open(ssoMailURL, "_self", "");
			}

			@Override
			public void onSuccess(String result) {
				if("isLogin".equals(result)){
					build();
				}else if("needLogin".equals(result)){
					Window.open(ssoMailURL, "_self", "");
				}else{
					Window.open(ssoMailURL, "_self", "");
				}
			}
		});
	}



	/**
	 * Administrator
	 */
	private void build() {

		if(dataSvr == null){
			dataSvr = GWT.create(AjaxDataService.class);
		}
		
		Map<String,Object> condMap = new HashMap<String, Object>();
		dataSvr.getGameSvrsByCond(condMap, new AsyncCallback<List<SvcList>>() {

			@Override
			public void onFailure(Throwable caught) {
				Window.alert(caught.getLocalizedMessage());
			}

			@Override
			public void onSuccess(List<SvcList> result) {
				MainSearchPanel mainSearchPanel = new MainSearchPanel(result);
				RootPanel mainSearchRoot = RootPanel.get().get("Div-main-search-content");
				
				MainContentPanel mainContentPanel = new MainContentPanel();
				RootPanel mainContentRoot = RootPanel.get().get("Div-main-content");
				
				mainSearchRoot.add(mainSearchPanel);
				mainContentRoot.add(mainContentPanel);
//				rootPanel.add(mainContentPanel);
			}
		});
		
	}
}
