package com.opi.gibp.tools.performance.gwt.ui.client.model;

import java.util.List;

import com.gwtext.client.util.Format;
import com.opi.gibp.tools.performance.gwt.ui.client.PanelConstants;
import com.rednels.ofcgwt.client.model.ChartData;
import com.rednels.ofcgwt.client.model.Text;
import com.rednels.ofcgwt.client.model.axis.YAxis;
import com.rednels.ofcgwt.client.model.elements.LineChart;
import com.rednels.ofcgwt.client.model.elements.dot.Dot;

@SuppressWarnings("unchecked")
public class CPU extends PerformanceChartPanel {
	public CPU(String title,String panelStyle, String style) {
		super(title, panelStyle , style);
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
		LineChart lc_max = new LineChart();
		LineChart lc_avg = new LineChart();
		
		/** set style of each line **/
		lc_max.setColour(PanelConstants.LC_MAX_COLOR);
		lc_max.setText("CPU-MAX");
		lc_max.setWidth(PanelConstants.LINE_WIDTH);
		
		lc_avg.setColour(PanelConstants.LC_AVG_COLOR);
		lc_avg.setText("CPU-AVG");
		lc_avg.setWidth(PanelConstants.LINE_WIDTH);
		
		
		float cpu_max = PanelConstants.MIN_YAXIS_MAX;
		for( int i = perfList.size()-1 ; i >= 0 ; i-- ){
			Performance perf = perfList.get(i);
			
			Dot maxDot = new Dot(perf.getCpu_max());
			maxDot.setColour(PanelConstants.LC_MAX_COLOR);
			maxDot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			maxDot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
			
			//修正小数点（保留三位小数）
			int maxLength = Float.toString(perf.getCpu_max()).length();
			maxLength = maxLength > 5 ? 5 : maxLength; 
			
			maxDot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"MAX:" + Float.toString(perf.getCpu_max()).substring(0, maxLength) +
					"<br>USERS:" + perf.getUsers() );
			lc_max.addDots(maxDot);
			
			Dot avgDot = new Dot(perf.getCpu_avg());
			avgDot.setColour(PanelConstants.LC_AVG_COLOR);
			avgDot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			avgDot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
			
			//修正小数点（保留三位小数）
			int avgLength = Float.toString(perf.getCpu_avg()).length();
			avgLength = avgLength > 5 ? 5 : avgLength;
			avgDot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"AVG:" + Float.toString(perf.getCpu_avg()).substring(0,avgLength) +
					"<br><h1>USERS:" + perf.getUsers() +"</h1>");
			lc_avg.addDots(avgDot);
			
			cpu_max = cpu_max > perf.getCpu_max() ? cpu_max : perf.getCpu_max();
			
		}
		
		/** set Axis **/
		YAxis ya = new YAxis();
		ya.setMax(cpu_max);
		cd.setYAxis(ya);
		cd.setYLegend(new Text("CPU","font-size: 14px; font-family: Verdana; text-align: center;"));
		
		/** Add Elements to ChartData  **/
		cd.addElements(lc_max);
		cd.addElements(lc_avg);
		
		super.setData(queryData,cd);
	}
	
	
	
	
	
//	@SuppressWarnings("rawtypes")
//	public void setData(List queryData){
//		if(queryData == null || queryData.size() == 0){
//			return;
//		}
//		ChartData cd = new ChartData(getTitle(), getCdStyle());
//		setData(queryData, cd);
//	}
//	
//	@SuppressWarnings({ "rawtypes" })
//	@Override
//	protected void setData(List queryData,ChartData cd) {
//		
//		List<Performance> perfList = (List<Performance>) queryData;
//		LineChart lc_max = new LineChart();
//		LineChart lc_avg = new LineChart();
//		
//		/** set style of each line **/
//		lc_max.setColour(PanelConstants.LC_MAX_COLOR);
//		lc_max.setDotSize(PanelConstants.LINE_CHART_DOT_SIZE);
//		lc_max.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
//		lc_max.setText("CPU-MAX");
//		lc_max.setTooltip("MAX : #val#");
//		
//		lc_avg.setColour(PanelConstants.LC_AVG_COLOR);
//		lc_avg.setDotSize(PanelConstants.LINE_CHART_DOT_SIZE);
//		lc_avg.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
//		lc_avg.setText("CPU-AVG");
//		lc_avg.setTooltip("AVG : #val#");
//		
//		float cpu_max = 100;
//		for( int i = perfList.size()-1 ; i >= 0 ; i-- ){
//			Performance perf = perfList.get(i);
//			
//			lc_max.addValues(perf.getCpu_max());
//			lc_avg.addValues(perf.getCpu_avg());
//			
//			cpu_max = cpu_max > perf.getCpu_max() ? cpu_max : perf.getCpu_max();
//		}
//		
//		/** set Axis **/
//		YAxis ya = new YAxis();
//		ya.setMax(cpu_max);
//		cd.setYAxis(ya);
//		
//		/** Add Elements to ChartData  **/
//		cd.addElements(lc_max);
//		cd.addElements(lc_avg);
//		
//		super.setData(queryData,cd);
//	}


}
