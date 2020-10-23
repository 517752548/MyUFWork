package com.opi.gibp.tools.performance.gwt.ui.client.model;

import java.util.List;

import com.gwtext.client.util.Format;
import com.opi.gibp.tools.performance.gwt.ui.client.PanelConstants;
import com.rednels.ofcgwt.client.model.ChartData;
import com.rednels.ofcgwt.client.model.Text;
import com.rednels.ofcgwt.client.model.axis.YAxis;
import com.rednels.ofcgwt.client.model.elements.LineChart;
import com.rednels.ofcgwt.client.model.elements.dot.Dot;

public class RPCS extends PerformanceChartPanel {

	public RPCS(String title, String panelStyle, String cdStyle) {
		super(title, panelStyle, cdStyle);
	}

	@SuppressWarnings("rawtypes")
	public void setData(List queryData){
		if(queryData == null || queryData.size() == 0){
			return;
		}
		ChartData cd = new ChartData(getTitle(), getCdStyle());
		setData(queryData, cd);
	}
	
	@SuppressWarnings({ "rawtypes" })
	@Override
	protected void setData(List queryData,ChartData cd) {
		
		List<Performance> perfList = (List<Performance>) queryData;
		LineChart lc_rpc0 = new LineChart();
		LineChart lc_rpc13 = new LineChart();
		LineChart lc_rpc48 = new LineChart();
		
		/** set style of each line **/
		lc_rpc0.setColour(PanelConstants.LC_MAX_COLOR);
		lc_rpc0.setText("RPC0");
		lc_rpc0.setWidth(PanelConstants.LINE_WIDTH);
		
		lc_rpc13.setColour(PanelConstants.LC_AVG_COLOR);
		lc_rpc13.setText("RPC13");
		lc_rpc13.setWidth(PanelConstants.LINE_WIDTH);
		
		lc_rpc48.setColour(PanelConstants.LC_MIN_COLOR);
		lc_rpc48.setText("RPC48");
		lc_rpc48.setWidth(PanelConstants.LINE_WIDTH);
		
		float rpc_max = PanelConstants.MIN_YAXIS_MAX;
		for( int i = perfList.size()-1 ; i >= 0 ; i-- ){
			Performance perf = perfList.get(i);
			
			Dot rpc0Dot = new Dot(perf.getRpc_0());
			rpc0Dot.setColour(PanelConstants.LC_MAX_COLOR);
			rpc0Dot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			rpc0Dot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
			rpc0Dot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"RPC0:" + perf.getRpc_0()  +
					"<br>USERS:" + perf.getUsers() );
			lc_rpc0.addDots(rpc0Dot);
			
			long rpc13 = perf.getRpc_1() + perf.getRpc_2() + perf.getRpc_3();
			Dot rpc13Dot = new Dot(rpc13);
			rpc13Dot.setColour(PanelConstants.LC_AVG_COLOR);
			rpc13Dot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			rpc13Dot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
			rpc13Dot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"RPC13:" + rpc13 +
					"<br>USERS:" + perf.getUsers());
			lc_rpc13.addDots(rpc13Dot);
			
			long rpc48 = perf.getRpc_4() + perf.getRpc_5() + perf.getRpc_6() + perf.getRpc_7() + perf.getRpc_8();
			Dot rpc48Dot = new Dot(rpc48);
			rpc48Dot.setColour(PanelConstants.LC_MIN_COLOR);
			rpc48Dot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			rpc48Dot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
			rpc48Dot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"RPC48:" + rpc48 +
					"<br>USERS:" + perf.getUsers());
			lc_rpc48.addDots(rpc48Dot);
			
			rpc_max = rpc_max > perf.getRpc_0() ? rpc_max : perf.getRpc_0();
			rpc_max = rpc_max > rpc13 ? rpc_max : rpc13;
			rpc_max = rpc_max > rpc48 ? rpc_max : rpc48;
		}
		
		/** set Axis **/
		YAxis ya = new YAxis();
		ya.setMax(rpc_max);
		cd.setYAxis(ya);
		cd.setYLegend(new Text("RPCS","font-size: 14px; font-family: Verdana; text-align: center;"));
		/** Add Elements to ChartData  **/
		cd.addElements(lc_rpc0);
		cd.addElements(lc_rpc13);
		cd.addElements(lc_rpc48);
		
		super.setData(queryData,cd);
	}
}
