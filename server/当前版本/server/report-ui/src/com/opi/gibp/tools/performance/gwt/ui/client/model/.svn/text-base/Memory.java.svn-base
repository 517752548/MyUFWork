package com.opi.gibp.tools.performance.gwt.ui.client.model;

import java.util.List;

import com.gwtext.client.util.Format;
import com.opi.gibp.tools.performance.gwt.ui.client.PanelConstants;
import com.rednels.ofcgwt.client.model.ChartData;
import com.rednels.ofcgwt.client.model.Text;
import com.rednels.ofcgwt.client.model.axis.YAxis;
import com.rednels.ofcgwt.client.model.elements.LineChart;
import com.rednels.ofcgwt.client.model.elements.ScatterChart;
import com.rednels.ofcgwt.client.model.elements.ScatterChart.ScatterStyle;
import com.rednels.ofcgwt.client.model.elements.dot.Dot;

public class Memory extends PerformanceChartPanel {
	
	
	public Memory(String title, String panelStyle, String cdStyle) {
		super(title, panelStyle, cdStyle);
		// TODO Auto-generated constructor stub
	}
	

	@SuppressWarnings("rawtypes")
	public void setData(List queryData){
		if(queryData == null || queryData.size() == 0){
			return;
		}
		
		ChartData cd = new ChartData(getTitle(), getCdStyle());
		setData(queryData, cd);
	}
	
	@SuppressWarnings("rawtypes")
	@Override
	protected void setData(List queryData,ChartData cd) {
		
		List<Performance> perfList = (List<Performance>) queryData;
		LineChart lc_max = new LineChart();
		LineChart lc_avg = new LineChart();
		
		
		lc_max.setColour(PanelConstants.LC_MAX_COLOR);
		lc_max.setText("MEM-TOTAL");
		lc_max.setWidth(PanelConstants.LINE_WIDTH);

		lc_avg.setColour(PanelConstants.LC_AVG_COLOR);
		lc_avg.setText("MEM-AVG");
		lc_avg.setWidth(PanelConstants.LINE_WIDTH);
		
		long max = PanelConstants.MIN_YAXIS_MAX;
		
		for( int i = perfList.size()-1 ; i >= 0 ; i-- ){
			Performance perf = perfList.get(i);
			
			Dot maxDot = new Dot(perf.getMem_total());
			maxDot.setColour(PanelConstants.LC_MAX_COLOR);
			maxDot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			maxDot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
			maxDot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"TOTAL:" + perf.getMem_total() +
					"<br>USERS:" + perf.getUsers());
			lc_max.addDots(maxDot);
			
			Dot avgDot = new Dot(perf.getMem_usage());
			avgDot.setColour(PanelConstants.LC_AVG_COLOR);
			avgDot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			avgDot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
			
			avgDot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"USED:" + perf.getMem_usage() + "<br>" +
					"USERS:" + perf.getUsers() );
			
			lc_avg.addDots(avgDot);
			
			max = max > perf.getMem_total() ? max : perf.getMem_total();
			
		}
		
		YAxis ya = new YAxis();
//		ya.setMin(0);
		ya.setMax(max);
		cd.setYAxis(ya);
		cd.setYLegend(new Text("MEMORY","font-size: 14px; font-family: Verdana; text-align: center;"));
		cd.addElements(lc_max);
		cd.addElements(lc_avg);
		super.setData(queryData,cd);
	}

}
