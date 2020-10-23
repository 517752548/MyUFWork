package com.opi.gibp.tools.performance.gwt.ui.client.model;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import com.gwtext.client.util.Format;
import com.opi.gibp.tools.performance.gwt.ui.client.PanelConstants;
import com.rednels.ofcgwt.client.model.ChartData;
import com.rednels.ofcgwt.client.model.Text;
import com.rednels.ofcgwt.client.model.axis.XAxis;
import com.rednels.ofcgwt.client.model.axis.YAxis;
import com.rednels.ofcgwt.client.model.elements.Element;
import com.rednels.ofcgwt.client.model.elements.LineChart;
import com.rednels.ofcgwt.client.model.elements.Shape;
import com.rednels.ofcgwt.client.model.elements.dot.BaseDot;
import com.rednels.ofcgwt.client.model.elements.dot.Dot;

/**
 * @author wenping.jiang
 *	网络延迟
 */
public class Ping extends ChartPanel {

	/** ping时间统计区间 */
	static final int[] PING_INTERVAL = new int[] { 10, 50, 100, 500, 1000,
			5000, 10000, Integer.MAX_VALUE };
	
	public Ping(String title, String panelStyle, String cdStyle) {
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
		List<PingPerformance> perfList = (List<PingPerformance>) queryData;
		LineChart lc_msg0 = new LineChart();
		LineChart lc_msg13 = new LineChart();
		LineChart lc_msg48 = new LineChart();
		
		/** set style of each line **/
		lc_msg0.setColour(PanelConstants.LC_MAX_COLOR);
		lc_msg0.setText("PINGG0");
		lc_msg0.setWidth(PanelConstants.LINE_WIDTH);
		
		lc_msg13.setColour(PanelConstants.LC_AVG_COLOR);
		lc_msg13.setText("PING1-3");
		lc_msg13.setWidth(PanelConstants.LINE_WIDTH);
		
		lc_msg48.setColour(PanelConstants.LC_MIN_COLOR);
		lc_msg48.setText("PING4-8");
		lc_msg48.setWidth(PanelConstants.LINE_WIDTH);
		float db_max = PanelConstants.MIN_YAXIS_MAX;
		for( int i = perfList.size()-1 ; i >= 0 ; i-- ){
			PingPerformance perf = perfList.get(i);
			
			Dot msg0Dot = new Dot(perf.getPingaver_0());
			msg0Dot.setColour(PanelConstants.LC_MAX_COLOR);
			msg0Dot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			msg0Dot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
			msg0Dot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"PING0:" + perf.getPingaver_0() + "<br>" 
					+ "MAX:" + perf.getPingAverMaxCount() );
			lc_msg0.addDots(msg0Dot);

			
			long msg13 = perf.getPingaver_1() + perf.getPingaver_2() + perf.getPingaver_3();
			Dot msg13Dot = new Dot(msg13);
			msg13Dot.setColour(PanelConstants.LC_AVG_COLOR);
			msg13Dot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			msg13Dot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
			msg13Dot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"PING1-3:" + msg13 + "<br>"
					+ "MAX:" + perf.getPingAverMaxCount() );
			lc_msg13.addDots(msg13Dot);
			
			long msg48 = perf.getPingaver_4() + perf.getPingaver_5() + perf.getPingaver_6() + perf.getPingaver_7();
			Dot msg48Dot = new Dot(msg48);
			msg48Dot.setColour(PanelConstants.LC_MIN_COLOR);
			msg48Dot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
			msg48Dot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
			msg48Dot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern)+"<br>" +
					"PING4-8:" + msg48 + "<br>"
					+ "MAX:" + perf.getPingAverMaxCount() );
			lc_msg48.addDots(msg48Dot);
			
			db_max = db_max > perf.getPingaver_0() ? db_max : perf.getPingaver_0();
			db_max = db_max > msg13 ? db_max : msg13;
			db_max = db_max > msg48 ? db_max : msg48;
		}
		
		/** set Axis **/
		YAxis ya = new YAxis();
		ya.setMax(db_max);
		cd.setYAxis(ya);
		cd.setYLegend(new Text("COUNT","font-size: 14px; font-family: Verdana; text-align: center;"));
		/** Add Elements to ChartData  **/
		cd.addElements(lc_msg0);
		cd.addElements(lc_msg13);
		cd.addElements(lc_msg48);
		
		XAxis xa = cd.getXAxis();
		xa.setMax(queryData.size());
		xa.setMin(0);
		cd.setXAxis(xa);
		setDataYOrder(queryData,cd);
	}

	protected void setDataYOrder(List queryData, ChartData cd) {
		List<PingPerformance> perfList = (List<PingPerformance>) queryData;
		LineChart lc_user = new LineChart();
		lc_user.setRightAxis(true);
		lc_user.setColour(PanelConstants.LC_USER_COLOR);
		lc_user.setWidth(PanelConstants.LINE_WIDTH);
		lc_user.setText("PING_AVER_TIME");
		
		long max_count = 0 ; 
		for( int i = perfList.size() - 1 ; i > 0 ; i -- ){
			PingPerformance perf = perfList.get(i);	
			if(perf.getSvrid() == null){
				BaseDot userDot = new Dot( 0 );
				userDot.setColour(PanelConstants.LC_NO_DATA);
				userDot.setSize(PanelConstants.LINE_CHART_DOT_SIZE + 2);
				userDot.setHaloSize(0);
				userDot.setTooltip( "<h1>No Data Record!!</h1>" +"<br>" +
						"<br>PING_AVER_TIME:"+ 0  );
				lc_user.addDots(userDot);
			}else{
				Dot userDot = new Dot(perf.getAvertime());
				userDot.setColour(PanelConstants.LC_USER_COLOR);
				userDot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
				userDot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
				userDot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern) +"<br>" 
						+ "PING_AVER_TIME:" + perf.getAvertime() );
				
				lc_user.addDots(userDot);
			
			}
			max_count = (long) (max_count > perf.getAvertime() ? max_count : perf.getAvertime());
		}
		
		YAxis yaR = new YAxis();
		yaR.setMax(max_count);
		yaR.setMin(0);
		cd.setYAxisRight(yaR);
		cd.addElements(lc_user);
		
		cd.setXLegend(new Text("TIME","font-size: 14px; font-family: Verdana; text-align: center;"));
		cd.setYRightLegend(new Text("PING_AVER_TIME","font-size: 14px; font-family: Verdana; text-align: center;"));
//		setToolTip(cd);
		super.setData(queryData, cd);
		createXLabel(cd.getXAxis(), queryData);
		fillShape(cd);
		refresh();
	}
	
	/**
	 * @param cd
	 * 填充没有数据的形状
	 */
	private void fillShape(ChartData cd){
		Collection<Element> elements = cd.getElements();
		for (Element e : elements) {
			if(e instanceof LineChart){
				//获取上面的所有点
				LineChart line = (LineChart) e;
				List<Object> values = line.getValues();
				//寻找上面的点
				for(int i = 0; i < values.size(); i++){
					BaseDot dot = (BaseDot) values.get(i);
					if(canShape(dot)){
						
						if((i + 1) < values.size()){
							int j = i + 1;
							for(; j < values.size(); j++){
								BaseDot dot2 = (BaseDot) values.get(j);
								if(!canShape(dot2)){
									break;
								}
							}
							if(j < values.size()){
								BaseDot dot3 = (BaseDot) values.get(j);
								Shape shape = new Shape();
								shape.addPoint(i, 0);
								shape.addPoint(i, cd.getYAxis().getMax().longValue());
								shape.addPoint(j, cd.getYAxis().getMax().longValue());
								shape.addPoint(j, 0);
								shape.setColour(PanelConstants.LC_NO_DATA_FILL_SHAPE);
								shape.setAlpha(PanelConstants.LC_NO_DATA_FILL_SHAPE_ALPHA);
								cd.addElements(shape);
								i = j -1;
							}
						}
					}
				}
			}
		}
	}
	
	/**
	 * @param dot
	 * @return
	 * 该点是否是填充的点，是否需要shape
	 */
	public boolean canShape(BaseDot dot){
		return dot.getColour().equals(PanelConstants.LC_NO_DATA);
	}
	/**
	 * @param xaxis
	 * @param queryData
	 * 创建x轴标签
	 */
	protected void createXLabel(XAxis xaxis, List queryData){

		long min = xaxis.getMin().longValue();
		long step = xaxis.getSteps().longValue();
		long max = xaxis.getMax().longValue();
		List<String> labels = new ArrayList<String>(); 
		long start = (max - min);
		for(long i = (max - min); i >= 0; i--){
			if((i - start) % step == 0){
				int index = (int) (i - 1);
				if(index < 0){
					index = 0;
				}
				PingPerformance perf = (PingPerformance) queryData.get(index);	
				labels.add(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern));
			}else{
				labels.add("");
			}
		}
		xaxis.setLabels(labels);
		xaxis.getLabels().setSteps((int) step);
		xaxis.setSteps(step);
	}
}
