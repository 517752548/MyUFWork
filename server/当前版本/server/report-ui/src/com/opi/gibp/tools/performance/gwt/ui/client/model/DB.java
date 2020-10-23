package com.opi.gibp.tools.performance.gwt.ui.client.model;

import java.util.List;

import com.gwtext.client.util.Format;
import com.opi.gibp.tools.performance.gwt.ui.client.PanelConstants;
import com.rednels.ofcgwt.client.model.ChartData;
import com.rednels.ofcgwt.client.model.Text;
import com.rednels.ofcgwt.client.model.axis.YAxis;
import com.rednels.ofcgwt.client.model.elements.LineChart;
import com.rednels.ofcgwt.client.model.elements.dot.Dot;

public class DB extends PerformanceChartPanel {

	public DB(String title, String panelStyle, String cdStyle) {
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
	
	/* (non-Javadoc)
	 * @see com.opi.gibp.tools.performance.gwt.ui.client.model.PerformanceChartPanel#setData(java.util.List, com.rednels.ofcgwt.client.model.ChartData)
	 */
	@SuppressWarnings({ "rawtypes" })
	@Override
	protected void setData(List queryData,ChartData cd) {
		
		List<Performance> perfList = (List<Performance>) queryData;
		LineChart lc_db0 = new LineChart();
		LineChart lc_db13 = new LineChart();
		LineChart lc_db48 = new LineChart();
		
		/** set style of each line **/
		lc_db0.setColour(PanelConstants.LC_MAX_COLOR);
		lc_db0.setText("DB0");
		lc_db0.setWidth(PanelConstants.LINE_WIDTH);
		
		lc_db13.setColour(PanelConstants.LC_AVG_COLOR);
		lc_db13.setText("DB13");	
		lc_db13.setWidth(PanelConstants.LINE_WIDTH);
		
		lc_db48.setColour(PanelConstants.LC_MIN_COLOR);
		lc_db48.setText("DB48");
		lc_db48.setWidth(PanelConstants.LINE_WIDTH);
		
		float db_max = PanelConstants.MIN_YAXIS_MAX;
		for( int i = perfList.size()-1 ; i >= 0 ; i-- ){
			Performance perf = perfList.get(i);
			
			Dot db0Dot = new Dot(perf.getDb_0());
			db0Dot.setColour(PanelConstants.LC_MAX_COLOR);
			db0Dot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			db0Dot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
			db0Dot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"DB0:" + perf.getDb_0() +
					"<br>USERS:" + perf.getUsers());
			
			lc_db0.addDots(db0Dot);
			
			
			long db13 = perf.getDb_1() + perf.getDb_2() + perf.getDb_3();
			Dot db13Dot = new Dot(db13);
			db13Dot.setColour(PanelConstants.LC_AVG_COLOR);
			db13Dot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			db13Dot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
			db13Dot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"DB13:" + db13 +
					"<br>USERS:" + perf.getUsers() );
			lc_db13.addDots(db13Dot);
			
			long db48 = perf.getDb_4() + perf.getDb_5() + perf.getDb_6() + perf.getDb_7() + perf.getDb_8();
			Dot db48Dot = new Dot(db48);
			db48Dot.setColour(PanelConstants.LC_MIN_COLOR);
			db48Dot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			db48Dot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
			db48Dot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"DB48:" + db48+
					"<br>USERS:" + perf.getUsers());
			lc_db48.addDots(db48Dot);
			
			db_max = db_max > perf.getDb_0() ? db_max : perf.getDb_0();
			db_max = db_max > db13 ? db_max : db13;
			db_max = db_max > db48 ? db_max : db48;
		}
		
		/** set Axis **/
		YAxis ya = new YAxis();
		ya.setMax(db_max);
		cd.setYAxis(ya);
		cd.setYLegend(new Text("DB","font-size: 14px; font-family: Verdana; text-align: center;"));
		/** Add Elements to ChartData  **/
		cd.addElements(lc_db0);
		cd.addElements(lc_db13);
		cd.addElements(lc_db48);
		
		super.setData(queryData,cd);
	}

	
}
