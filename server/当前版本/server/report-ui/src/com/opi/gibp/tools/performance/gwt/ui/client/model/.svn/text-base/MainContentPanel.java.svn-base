/**
 * 
 */
package com.opi.gibp.tools.performance.gwt.ui.client.model;

import java.util.ArrayList;
import java.util.List;

import com.google.gwt.user.client.Window;
import com.gwtext.client.widgets.Component;
import com.gwtext.client.widgets.TabPanel;

/**
 * @author Administrator
 *	主界面显示panel
 */
public class MainContentPanel extends TabPanel{
	
	/**
	 * 性能panel
	 */
	private List<PerformanceChartPanel> panelList = null;
	
	private ChartPanel pingPanel = null;
	
	public MainContentPanel(){
		
		//TODO Add Other Image

		String panelSize = "width:800px;height:450px";
		String chartDataStyle = "font-size: 14px; font-family: Verdana; text-align: center;";
	
		
 		panelList = new ArrayList<PerformanceChartPanel>();
 		panelList.add(new CPU("CPU",panelSize, chartDataStyle));
 		panelList.add(new Bytes("BYTES", panelSize, chartDataStyle));
 		panelList.add(new GC("GC", panelSize, chartDataStyle));
 		panelList.add(new Memory("MEMORY", panelSize, chartDataStyle));
 		panelList.add(new Request("REQUEST", panelSize, chartDataStyle));
 		panelList.add(new DB("DB", panelSize, chartDataStyle));
 		panelList.add(new Messages("MESSAGE", panelSize, chartDataStyle));
 		panelList.add(new RPCS("RPC", panelSize, chartDataStyle));
 		pingPanel = new Ping("PING", panelSize, chartDataStyle);
 		
 		for(int i = 0 ; i < panelList.size() ; i++){
 			
 			Component panel = panelList.get(i);
 			add(panel);
 			
 		}
 		add(pingPanel);
 		setActiveTab(0);
	}

	
	
	public void setData(List<Performance> data){
		for(int i = 0 ; i < panelList.size() ; i++){
			try{
				PerformanceChartPanel pcp = panelList.get(i);
	//			pcp.getChart().setSize("300", "300");
				pcp.setData(data);
			}catch (Exception e) {
				e.printStackTrace();
				Window.alert(e.toString());
//				Window.alert(e.getMessage());
//				Window.alert(e.getLocalizedMessage());
			}
		}
	}
	
	/**
	 * @param data
	 * 设置ping数据
	 */
	public void setPingData(List<PingPerformance> data){
		pingPanel.setData(data);
	}
}
