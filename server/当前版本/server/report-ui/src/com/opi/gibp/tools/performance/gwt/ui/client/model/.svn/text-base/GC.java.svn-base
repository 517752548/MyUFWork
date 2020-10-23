package com.opi.gibp.tools.performance.gwt.ui.client.model;

import java.util.List;

//import com.caucho.quercus.lib.date.DateTime;
import com.google.gwt.i18n.client.DateTimeFormat;
import com.google.gwt.user.client.Window;
import com.gwtext.client.util.Format;
import com.opi.gibp.tools.performance.gwt.ui.client.PanelConstants;
import com.rednels.ofcgwt.client.model.ChartData;
import com.rednels.ofcgwt.client.model.Text;
import com.rednels.ofcgwt.client.model.axis.YAxis;
import com.rednels.ofcgwt.client.model.elements.LineChart;
import com.rednels.ofcgwt.client.model.elements.dot.Dot;

public class GC extends PerformanceChartPanel {
	
	public GC(String title, String panelStyle, String cdStyle) {
		super(title, panelStyle, cdStyle);
	}
	
	

	@SuppressWarnings({ "rawtypes" })
	@Override
	protected void setData(List queryData,ChartData cd) {
		
		List<Performance> perfList = (List<Performance>) queryData;
		LineChart lc_ygc = new LineChart();
		LineChart lc_fgc = new LineChart();
		
		/** set style of each line **/
		lc_ygc.setColour(PanelConstants.LC_MAX_COLOR);
		lc_ygc.setText("YGC");
		lc_ygc.setWidth(PanelConstants.LINE_WIDTH);
		
		lc_fgc.setColour(PanelConstants.LC_AVG_COLOR);
		lc_fgc.setText("FGC");
		lc_fgc.setWidth(PanelConstants.LINE_WIDTH);
		
		long gc_max = PanelConstants.MIN_YAXIS_MAX;
		long pre_fgc = 0;
		long pre_ygc = 0;
		boolean first = true;
		for( int i = perfList.size()-1 ; i >= 0 ; i-- ){
			Performance perf = perfList.get(i);
			long ygcValue = 0;
			long fgcValue = 0;
			
			if(first){
				ygcValue = 0;
				fgcValue = 0;

				pre_fgc = perf.getFgc_count();
				pre_ygc = perf.getYgc_count();
				first = false;
			}else{
				
				ygcValue = perf.getYgc_count() - pre_ygc > 0 ? perf.getYgc_count() - pre_ygc : 0;
				fgcValue = perf.getFgc_count() - pre_fgc > 0 ? perf.getFgc_count() - pre_fgc : 0;
				
			}
			
			Dot ygcDot = new Dot(ygcValue);
			ygcDot.setColour(PanelConstants.LC_MAX_COLOR);
			ygcDot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			ygcDot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
			ygcDot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"YGC:" + ygcValue+
					"<br>USERS:" + perf.getUsers());
			lc_ygc.addDots(ygcDot);
			
			Dot fgcDot = new Dot(fgcValue);
			fgcDot.setColour(PanelConstants.LC_AVG_COLOR);
			fgcDot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			fgcDot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
			fgcDot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"FGC:" + fgcValue +
					"<br>USERS:" + perf.getUsers() );
			lc_fgc.addDots(fgcDot);
			
			
			gc_max = gc_max > perf.getYgc_count() - pre_ygc? gc_max : perf.getYgc_count() - pre_ygc;
			gc_max = gc_max > perf.getFgc_count() - pre_fgc? gc_max : perf.getFgc_count() - pre_fgc;
			
			pre_fgc = perf.getFgc_count();
			pre_ygc = perf.getYgc_count();
			
		}		
		
		/** set Axis **/
		YAxis ya = new YAxis();
		ya.setMax(gc_max);
		cd.setYAxis(ya);
		
		/** Add Elements to ChartData  **/
		cd.addElements(lc_ygc);
		cd.addElements(lc_fgc);
		
		super.setData(queryData,cd);
	}



	@Override
	protected void fixYAxis() {
		ChartData _cd = getCd();
		YAxis ya = _cd.getYAxis();
		long max_ya = 10;
		long min_ya = 0;
		try{
			max_ya = ya.getMax().longValue() > max_ya ? ya.getMax().longValue() : max_ya;
			min_ya = ya.getMin().longValue() ;
		}catch (Exception e) {
		}
		max_ya = (long) ( max_ya * 1.2f );
		long step_ya = (long) (( max_ya - min_ya ) / PanelConstants.Y_AXIS_STEPS  );
		ya.setMax( max_ya );
		ya.setMin( min_ya );
		ya.setSteps( step_ya );
		_cd.setYAxis(ya);
	}
	
	
	
//	/* (non-Javadoc)
//	 * @see com.opi.gibp.tools.performance.gwt.ui.client.model.ChartPanel#setData(java.util.List)
//	 */
//	@SuppressWarnings("rawtypes")
//	@Override
//	public void setData(List queryData) {
//
//		if(queryData == null || queryData.size() == 0){
//			return;
//		}
//		ChartData cd = new ChartData(getTitle(), getCdStyle());
//		setData(queryData, cd);
//		
//	}
//
//	@SuppressWarnings("rawtypes")
//	@Override
//	protected void setData(List queryData, ChartData cd) {
//
//		List<Performance> perfList = (List<Performance>) queryData;
//		LineChart lc_ygc = new LineChart();
//		LineChart lc_fgc = new LineChart();
//		
//		/** set style of each line **/
//		lc_ygc.setColour(PanelConstants.LC_MAX_COLOR);
//		lc_ygc.setDotSize(PanelConstants.LINE_CHART_DOT_SIZE);
//		lc_ygc.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
//		lc_ygc.setTooltip("YGC : #val#");
//		lc_ygc.setText("YGC");
//		
//		lc_fgc.setColour(PanelConstants.LC_AVG_COLOR);
//		lc_fgc.setDotSize(PanelConstants.LINE_CHART_DOT_SIZE);
//		lc_fgc.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
//		lc_fgc.setTooltip("FGC : #val#");
//		lc_fgc.setText("FGC");
//		
//		long gc_max = 100;
//		long pre_fgc = 0;
//		long pre_ygc = 0;
//		boolean first = true;
//		for( int i = perfList.size()-1 ; i >= 0 ; i-- ){
//			Performance perf = perfList.get(i);
//			
//			if(first){
//				lc_ygc.addValues(0);//perf.getYgc_count());
//				lc_fgc.addValues(0);//perf.getFgc_count());
//
//				pre_fgc = perf.getFgc_count();
//				pre_ygc = perf.getYgc_count();
//				first = false;
//			}else{
//				
//				lc_ygc.addValues(perf.getYgc_count() - pre_ygc > 0 ? perf.getYgc_count() - pre_ygc : 0);
//				lc_fgc.addValues(perf.getFgc_count() - pre_fgc > 0 ? perf.getFgc_count() - pre_fgc : 0);
//				
//			}
//
//			gc_max = gc_max > perf.getYgc_count() - pre_ygc? gc_max : perf.getYgc_count() - pre_ygc;
//			gc_max = gc_max > perf.getFgc_count() - pre_fgc? gc_max : perf.getFgc_count() - pre_fgc;
//			
//			pre_fgc = perf.getFgc_count();
//			pre_ygc = perf.getYgc_count();
//			
//		}
//		
//		/** set Axis **/
//		YAxis ya = new YAxis();
//		ya.setMax(gc_max);
//		cd.setYAxis(ya);
//		
//		/** Add Elements to ChartData  **/
//		cd.addElements(lc_ygc);
//		cd.addElements(lc_fgc);
//		
//		super.setData(queryData, cd);
//	}
	
	

}
