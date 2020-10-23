package com.opi.gibp.tools.performance.gwt.ui.client.model;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

import com.google.gwt.user.client.Window;
import com.gwtext.client.util.Format;
import com.opi.gibp.tools.performance.gwt.ui.client.PanelConstants;
import com.rednels.ofcgwt.client.model.ChartData;
import com.rednels.ofcgwt.client.model.Text;
import com.rednels.ofcgwt.client.model.ToolTip;
import com.rednels.ofcgwt.client.model.axis.XAxis;
import com.rednels.ofcgwt.client.model.axis.YAxis;
import com.rednels.ofcgwt.client.model.elements.AreaChart;
import com.rednels.ofcgwt.client.model.elements.Element;
import com.rednels.ofcgwt.client.model.elements.LineChart;
import com.rednels.ofcgwt.client.model.elements.Shape;
import com.rednels.ofcgwt.client.model.elements.dot.BaseDot;
import com.rednels.ofcgwt.client.model.elements.dot.Dot;

@SuppressWarnings("unchecked")
public class PerformanceChartPanel extends ChartPanel {

	
	public PerformanceChartPanel(String title, String panelStyle, String cdStyle) {
		super(title, panelStyle, cdStyle);
//		setAutoHeight(true);
		fixXAxis();
	}

	@SuppressWarnings("rawtypes")
	@Override
	public void setData(List queryData) {
		if(queryData == null || queryData.size() == 0){
			return;
		}
		ChartData cd = new ChartData(getTitle(), getCdStyle());
		setData(queryData, cd);
		
	}

	/* (non-Javadoc)
	 * @see com.opi.gibp.tools.performance.gwt.ui.client.model.ChartPanel#setData(java.util.List, com.rednels.ofcgwt.client.model.ChartData)
	 */
	@SuppressWarnings("rawtypes")
	@Override
	protected void setData(List queryData, ChartData cd) {
		
		List<Performance> perfList = (List<Performance>) queryData;
		LineChart lc_user = new LineChart();
		lc_user.setRightAxis(true);
		lc_user.setColour(PanelConstants.LC_USER_COLOR);
		lc_user.setWidth(PanelConstants.LINE_WIDTH);
		lc_user.setText("USER");
		
		long max_user = PanelConstants.MIN_YAXIS_MAX ; 
		List<Shape> shapeList = new ArrayList<Shape>();
		for( int i = perfList.size() - 1 ; i >= 0 ; i -- ){
			Performance perf = perfList.get(i);	

			if(perf.getSvrid() == null){
				
				BaseDot userDot = new Dot( 0 );
				userDot.setColour(PanelConstants.LC_NO_DATA);
				userDot.setSize(PanelConstants.LINE_CHART_DOT_SIZE + 2);
				userDot.setHaloSize(0);
				userDot.setTooltip( "<h1>No Data Record!!</h1>" +"<br>" +
						"<br>USERS:"+ 0  );
				lc_user.addDots(userDot);
				
			}else{
				
				BaseDot userDot = new Dot(perf.getUsers());
				userDot.setColour(PanelConstants.LC_USER_COLOR);
				userDot.setSize(PanelConstants.LINE_CHART_DOT_SIZE);
				userDot.setHaloSize(PanelConstants.LINE_CHART_HALO_DOT_SIZE);
				userDot.setTooltip(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern) +"<br>" +
						"<br>USERS:"+ perf.getUsers()  );
				
				lc_user.addDots(userDot);
			}

			max_user = max_user > perf.getUsers() ? max_user : perf.getUsers();
		}
		
		YAxis yaR = new YAxis();
		yaR.setMax(max_user);
		yaR.setMin(0);
		
		cd.setYAxisRight(yaR);
		
		cd.addElements(lc_user);
		
		cd.setXLegend(new Text("TIME","font-size: 14px; font-family: Verdana; text-align: center;"));
		cd.setYRightLegend(new Text("USERS","font-size: 14px; font-family: Verdana; text-align: center;"));
		
//		setToolTip(cd);
		
		XAxis xa = cd.getXAxis();
		xa.setMax(queryData.size());
		xa.setMin(0);
		cd.setXAxis(xa);
		
		super.setData(queryData, cd);
		//这里进行创建x轴的标签
		createXLabel(xa,queryData);
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
	private void setToolTip(ChartData cd) {
		ToolTip t = new ToolTip();
		t.setMouse(ToolTip.MouseStyle.NORMAL);
		t.setShadow(false);
		t.setStroke(5);
		t.setColour("#6E604F");
		t.setBackgroundcolour("#BDB396");
		t.setTitlestyle("{font-size:14px;color:#CC2A43;align:right;}");
		t.setBodystyle("{font-size: 14px; font-family: Verdana; align: right;}");
		cd.setTooltipStyle(t);
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
//		Window.alert("min:" + min + "step:" + step + "max:" + max);
//		System.out.println("min:" + min + "step:" + step + "max:" + max);
		
		long start = (max - min);
		for(long i = (max - min); i >= 0; i--){
			if((i - start) % step == 0){
				int index = (int) (i - 1);
				if(index < 0){
					index = 0;
				}
				Performance perf = (Performance) queryData.get(index);	
				labels.add(Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern));
//				Window.alert("i:" + i + "time:" + Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern));
//				System.out.println("i:" + i + "time:" + Format.date(perf.getTs_end().toGMTString(),PanelConstants.dateTimePattern));
			}else{
				labels.add("");
			}
		}
		xaxis.setLabels(labels);
		xaxis.getLabels().setSteps((int) step);
		xaxis.setSteps(step);
	}
}
