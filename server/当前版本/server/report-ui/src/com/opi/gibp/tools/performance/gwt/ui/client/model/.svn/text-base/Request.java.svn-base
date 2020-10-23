package com.opi.gibp.tools.performance.gwt.ui.client.model;

import java.util.List;

import com.gwtext.client.util.Format;
import com.opi.gibp.tools.performance.gwt.ui.client.PanelConstants;
import com.rednels.ofcgwt.client.model.ChartData;
import com.rednels.ofcgwt.client.model.Text;
import com.rednels.ofcgwt.client.model.axis.YAxis;
import com.rednels.ofcgwt.client.model.elements.LineChart;
import com.rednels.ofcgwt.client.model.elements.dot.Dot;

public class Request extends PerformanceChartPanel {

	public Request(String title, String panelStyle, String cdStyle) {
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
	
	@SuppressWarnings("rawtypes")
	@Override
	protected void setData(List queryData,ChartData cd) {
		
		List<Performance> perfList = (List<Performance>) queryData;
		LineChart lc_reach = new LineChart();
		LineChart lc_ok = new LineChart();
		LineChart lc_flop = new LineChart();
		
		lc_reach.setColour(PanelConstants.LC_MAX_COLOR);
		lc_reach.setText("REQ-REACH");
		lc_reach.setWidth(PanelConstants.LINE_WIDTH);
		
		lc_ok.setColour(PanelConstants.LC_AVG_COLOR);
		lc_ok.setText("REQ-OK");
		lc_ok.setWidth(PanelConstants.LINE_WIDTH);

		lc_flop.setColour(PanelConstants.LC_MIN_COLOR);
		lc_flop.setText("REQ-FLOP");
		lc_flop.setWidth(PanelConstants.LINE_WIDTH);
		
		long max = PanelConstants.MIN_YAXIS_MAX;
		
		for( int i = perfList.size()-1 ; i >= 0 ; i-- ){
			Performance perf = perfList.get(i);
			
			Dot reachDot = new Dot(perf.getReq_reach());
			reachDot.setColour(PanelConstants.LC_MAX_COLOR);
			reachDot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			reachDot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
			reachDot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"REACH:" + perf.getReq_reach() +
					"<br>USERS:" + perf.getUsers() );
			lc_reach.addDots(reachDot);

			Dot okDot = new Dot(perf.getReq_ok());
			okDot.setColour(PanelConstants.LC_AVG_COLOR);
			okDot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			okDot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
			okDot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"OK:" + perf.getReq_ok() + "" +
					"<br>USERS:" + perf.getUsers() );
			lc_ok.addDots(okDot);
			
			Dot flopDot = new Dot(perf.getReq_flop());
			flopDot.setColour(PanelConstants.LC_MIN_COLOR);
			flopDot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			flopDot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
			flopDot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"FLOP:" + perf.getReq_flop()  +
					"<br>USERS:" + perf.getUsers() );
			lc_flop.addDots(flopDot);
			
			max = max > perf.getReq_reach() ? max : perf.getReq_reach();
			
		}
		
		YAxis ya = new YAxis();
		ya.setMin(0);
		ya.setMax(max);
		cd.setYAxis(ya);
		cd.setYLegend(new Text("REQUEST","font-size: 14px; font-family: Verdana; text-align: center;"));
		
		cd.addElements(lc_reach);
		cd.addElements(lc_ok);
		cd.addElements(lc_flop);
		
		super.setData(queryData,cd);
	}
	
}
