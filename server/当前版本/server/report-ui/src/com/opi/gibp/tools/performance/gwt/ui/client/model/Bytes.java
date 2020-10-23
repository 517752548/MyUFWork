package com.opi.gibp.tools.performance.gwt.ui.client.model;

import java.util.List;

import com.gwtext.client.util.Format;
import com.opi.gibp.tools.performance.gwt.ui.client.PanelConstants;
import com.rednels.ofcgwt.client.model.ChartData;
import com.rednels.ofcgwt.client.model.Text;
import com.rednels.ofcgwt.client.model.axis.YAxis;
import com.rednels.ofcgwt.client.model.elements.LineChart;
import com.rednels.ofcgwt.client.model.elements.dot.BaseDot;
import com.rednels.ofcgwt.client.model.elements.dot.Dot;

@SuppressWarnings("unchecked")
public class Bytes extends PerformanceChartPanel {

	public Bytes(String title,String panelStyle , String cdStyle) {
		
		super(title, panelStyle , cdStyle);
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
		LineChart lc_in = new LineChart();
		LineChart lc_out = new LineChart();
		
		/** set style of each line **/
		lc_in.setColour(PanelConstants.LC_MAX_COLOR);
		lc_in.setText("BYTES-IN");
		lc_in.setWidth(PanelConstants.LINE_WIDTH);
		
		lc_out.setColour(PanelConstants.LC_AVG_COLOR);
		lc_out.setText("BYTES-OUT");
		lc_out.setWidth(PanelConstants.LINE_WIDTH);
		
		
		float bytes_max = PanelConstants.MIN_YAXIS_MAX;
		for( int i = perfList.size()-1 ; i >= 0 ; i-- ){
			Performance perf = perfList.get(i);
			
			BaseDot inDot = new Dot(perf.getBytes_in());
			inDot.setColour(PanelConstants.LC_MAX_COLOR);
			inDot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			inDot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
			inDot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"IN:" + perf.getBytes_in() + "B" +
					"<br>USERS:" + perf.getUsers());
			lc_in.addDots(inDot);
			
			BaseDot outDot = new Dot(perf.getBytes_out());
			outDot.setColour(PanelConstants.LC_AVG_COLOR);
			outDot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			outDot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);

			outDot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"OUT:" + perf.getBytes_out() + "B" +
					"<br>USERS:" + perf.getUsers());
			lc_out.addDots(outDot);
			
			
			bytes_max = bytes_max > perf.getBytes_in() ? bytes_max : perf.getBytes_in();
			bytes_max = bytes_max > perf.getBytes_out() ? bytes_max : perf.getBytes_out();

		}
		
		/** set Axis **/
		YAxis ya = new YAxis();
		ya.setMax(bytes_max);
		cd.setYAxis(ya);
		cd.setYLegend(new Text("BYTES","font-size: 14px; font-family: Verdana; text-align: center;"));
		/** Add Elements to ChartData  **/
		cd.addElements(lc_in);
		cd.addElements(lc_out);
		
		super.setData(queryData,cd);
	}
	
	
	
//	@SuppressWarnings("rawtypes")
//	public void setData(List queryData){
//		if(queryData == null || queryData.size() == 0){
//			return;
//		}
//		
//		ChartData cd = new ChartData(getTitle(), getCdStyle());
//		setData(queryData, cd);
//	}
//	
//	@SuppressWarnings("rawtypes")
//	@Override
//	protected void setData(List queryData,ChartData cd) {
//		
//		List<Performance> perfList = (List<Performance>) queryData;
//		LineChart lc_in = new LineChart();
//		LineChart lc_out = new LineChart();
//
//		lc_in.setColour(PanelConstants.LC_MAX_COLOR);
//		lc_in.setDotSize(PanelConstants.LINE_CHART_DOT_SIZE);
//		lc_in.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
//		lc_in.setTooltip("IN : #val# ");
//		lc_in.setText(" BYTES-IN ");
//		
//		lc_out.setColour(PanelConstants.LC_AVG_COLOR);
//		lc_out.setDotSize(PanelConstants.LINE_CHART_DOT_SIZE);
//		lc_out.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
//		lc_out.setTooltip("OUT : #val# ");
//		lc_out.setText(" BYTES-OUT ");
//		long max = 100;
//		
//		for( int i = perfList.size()-1 ; i >= 0 ; i-- ){
//			Performance perf = perfList.get(i);
//			
//			lc_in.addValues(perf.getBytes_in());
//			lc_out.addValues(perf.getBytes_out());
//			
//			long tmp = perf.getBytes_in()>perf.getBytes_out()?perf.getBytes_in():perf.getBytes_out();
//			max = max > tmp ? max : tmp;
//			
//		}
//		
//		YAxis ya = new YAxis();
//		ya.setMin(0);
//		ya.setMax(max);
//		cd.setYAxis(ya);
//		
//		cd.addElements(lc_in);
//		cd.addElements(lc_out);
//		super.setData(queryData,cd);
//	}

	
	
}
