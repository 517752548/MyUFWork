package com.opi.gibp.tools.performance.gwt.ui.client.model;

import java.util.List;

import com.google.gwt.user.client.Window;
import com.gwtext.client.widgets.Panel;
import com.opi.gibp.tools.performance.gwt.ui.client.PanelConstants;
import com.rednels.ofcgwt.client.ChartWidget;
import com.rednels.ofcgwt.client.model.ChartData;
import com.rednels.ofcgwt.client.model.axis.XAxis;
import com.rednels.ofcgwt.client.model.axis.YAxis;

@SuppressWarnings("unchecked")
public abstract class ChartPanel extends Panel {
	
	private ChartWidget _chart;
	private ChartData _cd;
	private String title;
	private String cdStyle;
	
	public ChartPanel(String title , String panelStyle , String cdStyle){
		
		_chart = new ChartWidget();
		
		_cd = new ChartData( title , cdStyle );
		this.cdStyle = cdStyle;
		
		
		_chart.setSize("800", "450");
		
		fixYAxis();
		fixYAxisRight();
		fixXAxis();
		
		refresh();
		setTitle(title);
		add(_chart);
		super.setStyle(panelStyle);
		
	}
	
	public ChartWidget getChart() {
		return _chart;
	}

	public void setChart(ChartWidget chart) {
		this._chart = chart;
	}

	public ChartData getCd() {
		return _cd;
	}

	public void setCd(ChartData cd) {
		this._cd = cd;
	}
	
	public String getTitle() {
		return title;
	}
	@Override
	public void setTitle(String title) {
		this.title = title;
		super.setTitle(title);
	}

	public String getCdStyle() {
		return cdStyle;
	}

	public void setCdStyle(String style) {
		this.cdStyle = style;
	}

	
	@SuppressWarnings("rawtypes")
	public abstract void setData(List queryData);
	
	/**
	 * 重新利用queryData中的数据，对Chart中的显示数据进行刷新
	 * @param queryData 
	 */
	@SuppressWarnings("rawtypes")
	protected  void setData(List queryData,ChartData cd){
		
		setCd(cd);		
		
		fixYAxis();
		fixYAxisRight();
		fixXAxis();

		refresh();
	}



	protected void fixXAxis() {
		XAxis xa = _cd.getXAxis();
		long max_xa = PanelConstants.LINE_DOT_COUNT; 
		long min_xa = 0; 
		
		try{
			max_xa = xa.getMax().longValue()>PanelConstants.LINE_DOT_COUNT?xa.getMax().longValue():PanelConstants.LINE_DOT_COUNT;
			min_xa = xa.getMin().longValue()>0?xa.getMin().longValue():0;
		}catch (Exception e) {
		}
		
		long step_xa = (long)( ( max_xa - min_xa ) / PanelConstants.X_AXIS_STEPS );
		xa.setSteps(step_xa);
		xa.setMax(max_xa);
		xa.setMin(min_xa);
		_cd.setXAxis(xa);
	}

	protected void fixYAxisRight() {
		YAxis ya_r = _cd.getYAxisRight();
		if(ya_r == null){// ofcgwt 在处理右Y轴时未对不存在的Y轴进行new，在这里处理一下，以防止后续空指针
			ya_r = new YAxis();
		}
		long max_ya_r = PanelConstants.MIN_YAXIS_MAX;
		long min_ya_r = 0l;
		try{
			max_ya_r = ya_r.getMax().longValue() > max_ya_r ? ya_r.getMax().longValue() : max_ya_r;
			min_ya_r = ya_r.getMin().longValue();
		}catch (Exception e) {
		}
		max_ya_r = (long)( max_ya_r  *  1.2f );
		long step_ya_r = (long)( ( max_ya_r - min_ya_r ) / PanelConstants.Y_AXIS_STEPS );
		ya_r.setMax((long) max_ya_r );
		ya_r.setMin( min_ya_r );
		ya_r.setSteps( step_ya_r );
		_cd.setYAxisRight(ya_r);
	}

	protected void fixYAxis() {
		YAxis ya = _cd.getYAxis();
		long max_ya = PanelConstants.MIN_YAXIS_MAX;
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


	protected void refresh() {
		if(_chart == null || _cd == null){
			throw new NullPointerException("No Chart was found in " + this + ",please make sure " +
					" you're using a new ChartPanel correctly");
		}
		
//		if(!_chart.isCacheFixEnabled()){
//			_chart.setCacheFixEnabled(true);
//		}
		_chart.setJsonData(_cd.toString());
	}
	
}
