package com.opi.gibp.tools.performance.gwt.ui.client.service;

import com.google.gwt.user.client.rpc.AsyncCallback;

public interface SSOServiceAsync {
	void checkLogin(AsyncCallback<String> callback);

	void getSsoMailURL(AsyncCallback<String> callback);
	
}