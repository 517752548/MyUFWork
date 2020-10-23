/**
 * 
 */
package com.opi.gibp.tools.performance.gwt.ui.client.model;

import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.google.gwt.core.client.GWT;
import com.google.gwt.user.client.Window;
import com.google.gwt.user.client.rpc.AsyncCallback;
import com.google.gwt.user.client.ui.RootPanel;
import com.google.gwt.user.client.ui.VerticalPanel;
import com.gwtext.client.core.EventObject;
import com.gwtext.client.data.FieldDef;
import com.gwtext.client.data.Record;
import com.gwtext.client.data.RecordDef;
import com.gwtext.client.data.SimpleStore;
import com.gwtext.client.data.Store;
import com.gwtext.client.data.StringFieldDef;
import com.gwtext.client.widgets.Button;
import com.gwtext.client.widgets.DatePicker;
import com.gwtext.client.widgets.MessageBox;
import com.gwtext.client.widgets.Panel;
import com.gwtext.client.widgets.QuickTipsConfig;
import com.gwtext.client.widgets.Toolbar;
import com.gwtext.client.widgets.ToolbarButton;
import com.gwtext.client.widgets.event.ButtonListenerAdapter;
import com.gwtext.client.widgets.event.DatePickerListenerAdapter;
import com.gwtext.client.widgets.form.ComboBox;
import com.gwtext.client.widgets.form.DateField;
import com.gwtext.client.widgets.form.event.ComboBoxListenerAdapter;
import com.gwtext.client.widgets.layout.HorizontalLayout;
import com.opi.gibp.tools.performance.gwt.ui.client.Constans;
import com.opi.gibp.tools.performance.gwt.ui.client.service.AjaxDataService;
import com.opi.gibp.tools.performance.gwt.ui.client.service.AjaxDataServiceAsync;
import com.opi.gibp.tools.performance.gwt.ui.client.service.PerfService;
import com.opi.gibp.tools.performance.gwt.ui.client.service.PerfServiceAsync;
import com.opi.gibp.tools.performance.gwt.ui.client.service.PingService;
import com.opi.gibp.tools.performance.gwt.ui.client.service.PingServiceAsync;

/**
 * @author Administrator
 * 搜索设置 pannel
 */
public class MainSearchPanel extends VerticalPanel {
	// Search Async service
	private PerfServiceAsync perfSvc = GWT.create(PerfService.class);
	private AjaxDataServiceAsync ajaxSvc = GWT.create(AjaxDataService.class);
	private PingServiceAsync pingSvc = GWT.create(PingService.class);
	
	private Panel basicSearchPanel = null;
	private Store svrStore = null;
	private Store svcStore = null;
	private ComboBox cbServer = null;
	private ComboBox cbServerC = null;
	private Button searchBtn = null;
//	private Checkbox advanceCheckBox = null;
	private Toolbar basicToolBar = null;
	private ToolbarButton advanceSearchBtn = null;
	private QuickTipsConfig basicToolBtnTipsConfig = null;
	private QuickTipsConfig advanceToolBtnTipsConfig = null;
	
	private Panel advancdSearchPanel = null;
	private DateField  dfBegin = null;
	private DateField dfEnd = null;
	
	List<String> uniqGameIDList = null;
	List<String> uniqGameSvrList = null;
	List<String> uniqGameSvcList = null;
	List<Object[]> svrStoreDataList = null;
	List<Object[]> svcStoreDataList = null;
	public MainSearchPanel(List<SvcList> perfList) {
		
		basicSearchPanel = new Panel();
		basicSearchPanel.setLayout(new HorizontalLayout(5));
		
		advancdSearchPanel = new Panel();
		advancdSearchPanel.setTitle("Advanced Search");
		advancdSearchPanel.setLayout(new HorizontalLayout(15));
		
		uniqGameIDList = new ArrayList<String>();
		uniqGameSvcList = new ArrayList<String>();
		uniqGameSvrList = new ArrayList<String>();

		svrStoreDataList = new ArrayList<Object[]>();
		svcStoreDataList = new ArrayList<Object[]>();

		setSearchData(perfList);

		// After oracle initiation complete, build the server SuggestBox
		svrStore = new SimpleStore(new String[] { "server", "serverName" },
				svrStoreDataList.toArray(new Object[0][]));
		// svrStore.load();
		cbServer = new ComboBox();
		cbServer.setStore(svrStore);
		cbServer.setDisplayField("serverName");
		cbServer.setValueField("server");
		cbServer.setMode(ComboBox.LOCAL);
		cbServer.setTriggerAction(ComboBox.ALL);
		cbServer.setForceSelection(true);
		cbServer.setMinChars(1);
		cbServer.setEmptyText("服务器");
		cbServer.setLoadingText("正在查询中");

		svcStore = new SimpleStore(
				new String[] { "svc" },
				new Object[][] {});// svcStoreDataList.toArray(new
									// Object[0][]));
		// // svcStore.load();

		cbServerC = new ComboBox();
		cbServerC.setStore(svcStore);
		cbServerC.setDisplayField("svc");
		cbServerC.setValueField("svc");
		cbServerC.setMode(ComboBox.LOCAL);
		cbServerC.setTriggerAction(ComboBox.ALL);
		cbServerC.setForceSelection(true);
		cbServerC.setMinChars(1);
		cbServerC.setEmptyText("服务");
		cbServerC.setLoadingText("服务器服务查询中");
		// cbServerC.setForceSelection(true);
		
		searchBtn = new Button("查询");
		searchBtn.setIconCls("");
		
		
//		advanceCheckBox = new Checkbox();
//		advanceCheckBox.setBoxLabel("高级查找");
//		advanceCheckBox.setWidth(200);
//		advanceCheckBox.setChecked(false);
		
		basicToolBar = new Toolbar();
		
		advanceSearchBtn = new ToolbarButton("高级查找");
		advanceSearchBtn.setEnableToggle(true);
		advanceSearchBtn.setPressed(true);

		basicToolBtnTipsConfig = new QuickTipsConfig();
		basicToolBtnTipsConfig.setText("默认查找最近24小时内的数据");
		basicToolBtnTipsConfig.setTitle("默认查找");
		
		advanceToolBtnTipsConfig = new QuickTipsConfig();
		advanceToolBtnTipsConfig.setText("编辑其他查询条件进行数据查询");
		advanceToolBtnTipsConfig.setTitle("高级查找");
		
		
		dfBegin = new DateField("dfBegin", "Y-m-d");
		dfBegin.setEmptyText("选择开始日期");
		dfBegin.setReadOnly(true);
		dfBegin.setAutoWidth(true);
		
		dfEnd = new DateField("dfEnd","Y-m-d");
		dfEnd.setEmptyText("选择结束日期");
		dfEnd.setReadOnly(true);
		dfEnd.setAllowBlank(true);
		dfEnd.setAutoWidth(true);
		
		//Build the Components' Listener
		buildListeners();
		
		//Construct the Panels
		buildPanel();

		setSize("800px", "70px");
		setBorderWidth(0);
	}

	private void buildPanel() {
		basicSearchPanel.add(cbServer);
		basicSearchPanel.add(cbServerC);
		basicSearchPanel.add(searchBtn);
//		basicSearchPanel.add(advanceCheckBox);
		
		basicToolBar.addButton(advanceSearchBtn);
		basicToolBar.addSeparator();
		basicSearchPanel.setTopToolbar(basicToolBar);
		basicSearchPanel.setBodyBorder(true);
		
//		advanceCheckBox.setChecked(true);
		
		advancdSearchPanel.add(dfBegin);
		advancdSearchPanel.add(dfEnd);
		advancdSearchPanel.setVisible(true);
		advancdSearchPanel.setBodyBorder(true);
		
		
		add(basicSearchPanel);
		add(advancdSearchPanel);
	}

	private void buildListeners() {
		cbServer.addListener(new ComboBoxListenerAdapter() {
			public void onSelect(ComboBox comboBoxServer, Record record,
					int index) {
				// svcStore.filter("server", comboBoxServer.getValue());
				// refreshChartPanel();
				showSvcStoreAsnyc(comboBoxServer.getText());
				
				refreshChartPanel();
			}
		});

		cbServerC.addListener(new ComboBoxListenerAdapter() {
			public void onSelect(ComboBox comboBoxServerC, Record record,
					int index) {
				refreshChartPanel();
			}
		});
		searchBtn.addListener(new ButtonListenerAdapter() {
			public void onClick(Button button, EventObject e) {
				
				refreshChartPanel();
			}

		});
//		advanceCheckBox.addListener(new CheckboxListenerAdapter(){
//			public void onCheck(Checkbox field, boolean checked) {
//				advancdSearchPanel.setVisible(checked);
//		    }
//			
//		});
		advanceSearchBtn.addListener(new ButtonListenerAdapter(){
		    public void onToggle(Button button, boolean pressed) {
		    	if(pressed){
		    		advanceSearchBtn.setText("高级查找");
		    		advanceSearchBtn.setTooltip(advanceToolBtnTipsConfig);
		    	}else{
		    		advanceSearchBtn.setText("默认查找");
		    		advanceSearchBtn.setTooltip(basicToolBtnTipsConfig);
		    	}
		    	
		    	advancdSearchPanel.setVisible(pressed);
		    }
		});
		
		dfBegin.addListener(new DatePickerListenerAdapter(){
		    public void onSelect(DatePicker dataPicker, Date date) {
		    	searchBtn.setIconCls("refresh-button");
		    }
		});
		dfEnd.addListener(new DatePickerListenerAdapter(){
			public void onSelect(DatePicker dataPicker, Date date) {
				searchBtn.setIconCls("refresh-button");
		    }
		});
		
	}

	private void showSvcStoreAsnyc(final String text) {

		Map<String, Object> condMap = new HashMap<String, Object>();
		condMap.put("svrid", text);

		ajaxSvc.getGameSvrsByCond(condMap, new AsyncCallback<List<SvcList>>() {

			@Override
			public void onFailure(Throwable caught) {
				Window.alert(text + " : do not have any server type,please check!");
			}

			@Override
			public void onSuccess(List<SvcList> result) {
				List<String> gameSvcList = new ArrayList<String>();
				// remove the current datas from svcStore
				svcStore.removeAll();
//				Window.alert("gameSvcList.Size():" +  result.size());
				// add new Datas to svcStore
				RecordDef recDef = new RecordDef(
						new FieldDef[] { new StringFieldDef("svc") });

				Record[] svcTypeRecord = new Record[result.size()];
				int i = 0;
				for (SvcList svr : result) {
					if (!gameSvcList.contains(svr.getSvc_type() + "#"
							+ svr.getSvcid())) {
						gameSvcList.add(svr.getSvc_type() + "#"
								+ svr.getSvcid());

						Record rec = recDef.createRecord(new Object[] { svr
								.getSvc_type() + "#" + svr.getSvcid() });
						svcTypeRecord[i++] = rec;
//						Window.alert("add svcTypeRecord:" +  svr.getSvc_type()+"#" + svr.getSvcid() + "svcTypeRecord.size:" + svcTypeRecord.length);
					}
				}
				
				svcStore.insert(0, svcTypeRecord);
//				Window.alert("After svcStore insert svcTypeRecord: svcTypeRecord.size:" + svcTypeRecord.length );
				// Commit the data changes of svcStore, to re-attach to cbServerC
				svcStore.commitChanges();
//				Window.alert("After svcStore Commit changes:" );

			}
		});
	}

	public void setSearchData(List<SvcList> gameSvrList) {

		for (SvcList svr : gameSvrList) {
			if (!uniqGameIDList.contains(svr.getGameid() + ".imop.com")) {
				uniqGameIDList.add(svr.getGameid() + ".imop.com");
			}
			if (!uniqGameSvrList.contains(svr.getSvrid())) {
				uniqGameSvrList.add(svr.getSvrid());
				Object[] serverInfo = new Object[] { svr.getSvrid(),
						svr.getSvrid() };
				svrStoreDataList.add(serverInfo);
			}
			if (!uniqGameSvcList.contains(svr.getSvc_type() + "#"
					+ svr.getSvcid())) {
				uniqGameSvcList.add(svr.getSvc_type() + "#" + svr.getSvcid());
				// Object[] svcInfo = new Object[]{svcStoreDataList.size(),
				// svr.getSvrid(),svr.getSvc_type()+"#"+svr.getSvcid()};
				// svcStoreDataList.add(svcInfo);
			}
		}

	}

	// @SuppressWarnings("deprecation")
	/**
	 * @param result
	 * 设置性能面板数据
	 */
	private void refreshChartData(List<Performance> result) {
		searchBtn.setIconCls("");
		
		if(result == null){
			return;
		}
		RootPanel rootPanel = RootPanel.get();
		MainContentPanel mainContentPanel = (MainContentPanel) rootPanel.get("Div-main-content").getWidget(0);// .asWidget();
		mainContentPanel.setData(result);
	}

	
	/**
	 * @param result
	 * 设置性能面板数据
	 */
	private void refreshPingChartData(List<PingPerformance> result) {
		searchBtn.setIconCls("");
		if(result == null){
			return;
		}
		RootPanel rootPanel = RootPanel.get();
		MainContentPanel mainContentPanel = (MainContentPanel) rootPanel.get("Div-main-content").getWidget(0);// .asWidget();
		mainContentPanel.setPingData(result);
	}
	
	/**
	 * TODO Administrator
	 */
	private void refreshChartPanel() {
		searchBtn.setIconCls("loading-button");
//		loadingHTML.setVisible(true);
		
		Map<String, Object> condMap = new HashMap<String, Object>();
		String svrid = cbServer.getText().trim();
		String svcid = cbServerC.getValueAsString().split("#")[1];
//		String tsEndDateStr = tsEndDate.getRawValue();
//		String tsDateRange = tsEndDateStr + " 00:00:00" + "###" + tsEndDateStr + " 23:59:59";
		
		
		condMap.put("svrid", svrid);
		condMap.put("svcid", svcid);
		if(advanceSearchBtn.isPressed()){//Advanced Search
			
			
			String strDfBegin = dfBegin.getRawValue() + " 00:00:00";
			String strDfEnd = dfEnd.getRawValue() + " 23:59:59";
			
			if(!strDfBegin.contains("-") || !strDfEnd.contains("-")){
				searchBtn.setIconCls("refresh-button");
				return;
			}
			if(strDfBegin.compareTo(strDfEnd)>0){
				MessageBox.alert("起始日期大于结束日期,请检查");
				searchBtn.setIconCls("refresh-button");
				return;
			}
			
			condMap.put(Constans.QUERY_DATE_KEY, strDfBegin + Constans.QUERY_DATE_SPLIT + strDfEnd);
			
			perfSvc.getStatMaxLineChartDatas(condMap, new AsyncCallback<List<Performance>>() {

				@Override
				public void onFailure(Throwable caught) {
					Window.alert("性能查询失败");
				}

				@Override
				public void onSuccess(List<Performance> result) {
					refreshChartData(result);
				}
			});
			
			pingSvc.getStatMaxLineChartDatas(condMap, 
					new AsyncCallback<List<PingPerformance>>(){
						@Override
						public void onFailure(Throwable caught) {
							caught.printStackTrace();
							Window.alert(caught.toString());
						}
		
						@Override
						public void onSuccess(List<PingPerformance> result) {
							refreshPingChartData(result);
						}
					}
			);
		}else{//Basic Search
			perfSvc.getLineChartDatas(condMap,
					new AsyncCallback<List<Performance>>() {
	
						@Override
						public void onSuccess(List<Performance> result) {
							refreshChartData(result);
						}
	
						@Override
						public void onFailure(Throwable caught) {
							caught.printStackTrace();
							Window.alert("查询失败");
						}
					}
			);
			
			pingSvc.getLineChartDatas(condMap, 
					new AsyncCallback<List<PingPerformance>>(){
						@Override
						public void onFailure(Throwable caught) {
							caught.printStackTrace();
							Window.alert("网络普通查询失败");
						}
		
						@Override
						public void onSuccess(List<PingPerformance> result) {
							refreshPingChartData(result);
						}
					}
			);
		}
	}


}
