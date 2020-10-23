package com.opi.gibp.tools.performance.gwt.ui.client.model;

import java.util.List;

import com.gwtext.client.util.Format;
import com.opi.gibp.tools.performance.gwt.ui.client.PanelConstants;
import com.rednels.ofcgwt.client.model.ChartData;
import com.rednels.ofcgwt.client.model.Text;
import com.rednels.ofcgwt.client.model.axis.YAxis;
import com.rednels.ofcgwt.client.model.elements.LineChart;
import com.rednels.ofcgwt.client.model.elements.dot.Dot;

public class Messages extends PerformanceChartPanel {

	public Messages(String title, String panelStyle, String cdStyle) {
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
		LineChart lc_msg0 = new LineChart();
		LineChart lc_msg13 = new LineChart();
		LineChart lc_msg48 = new LineChart();
		
		/** set style of each line **/
		lc_msg0.setColour(PanelConstants.LC_MAX_COLOR);
		lc_msg0.setText("MSG0");
		lc_msg0.setWidth(PanelConstants.LINE_WIDTH);
		
		lc_msg13.setColour(PanelConstants.LC_AVG_COLOR);
		lc_msg13.setText("MSG13");
		lc_msg13.setWidth(PanelConstants.LINE_WIDTH);
		
		lc_msg48.setColour(PanelConstants.LC_MIN_COLOR);
		lc_msg48.setText("MSG48");
		lc_msg48.setWidth(PanelConstants.LINE_WIDTH);
		
		float db_max = PanelConstants.MIN_YAXIS_MAX;
		for( int i = perfList.size()-1 ; i >= 0 ; i-- ){
			Performance perf = perfList.get(i);
			
			Dot msg0Dot = new Dot(perf.getMsg_0());
			msg0Dot.setColour(PanelConstants.LC_MAX_COLOR);
			msg0Dot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			msg0Dot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
			msg0Dot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"MSG0:" + perf.getMsg_0() + "<br>" +
					"USERS:" + perf.getUsers() );
			lc_msg0.addDots(msg0Dot);

			
			long msg13 = perf.getMsg_1() + perf.getMsg_2() + perf.getMsg_3();
			Dot msg13Dot = new Dot(msg13);
			msg13Dot.setColour(PanelConstants.LC_AVG_COLOR);
			msg13Dot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			msg13Dot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
			msg13Dot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"MSG13:" + msg13 +
					"<br>USERS:" + perf.getUsers());
			lc_msg13.addDots(msg13Dot);
			
			long msg48 = perf.getMsg_4() + perf.getMsg_5() + perf.getMsg_6() + perf.getMsg_7() + perf.getMsg_8();
			Dot msg48Dot = new Dot(msg48);
			msg48Dot.setColour(PanelConstants.LC_MIN_COLOR);
			msg48Dot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			msg48Dot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
			msg48Dot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"MSG48:" + msg48 + 
					"<br>USERS:" + perf.getUsers());
			lc_msg48.addDots(msg48Dot);
			
			db_max = db_max > perf.getMsg_0() ? db_max : perf.getMsg_0();
			db_max = db_max > msg13 ? db_max : msg13;
			db_max = db_max > msg48 ? db_max : msg48;
		}
		
		/** set Axis **/
		YAxis ya = new YAxis();
		ya.setMax(db_max);
		cd.setYAxis(ya);
		cd.setYLegend(new Text("MESSAGES","font-size: 14px; font-family: Verdana; text-align: center;"));
		/** Add Elements to ChartData  **/
		cd.addElements(lc_msg0);
		cd.addElements(lc_msg13);
		cd.addElements(lc_msg48);
		
		super.setData(queryData,cd);
	}

}
