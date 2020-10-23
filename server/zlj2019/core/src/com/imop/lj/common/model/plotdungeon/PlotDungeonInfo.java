package com.imop.lj.common.model.plotdungeon;

public class PlotDungeonInfo {

	private int plotDungeonType;
	private int plotDungeonChapter;
	private int plotDungeonStatus;
	
	public int getPlotDungeonType() {
		return plotDungeonType;
	}
	public void setPlotDungeonType(int plotDungeonType) {
		this.plotDungeonType = plotDungeonType;
	}
	
	public int getPlotDungeonChapter() {
		return plotDungeonChapter;
	}
	public void setPlotDungeonChapter(int plotDungeonChapter) {
		this.plotDungeonChapter = plotDungeonChapter;
	}
	public int getPlotDungeonStatus() {
		return plotDungeonStatus;
	}
	public void setPlotDungeonStatus(int plotDungeonStatus) {
		this.plotDungeonStatus = plotDungeonStatus;
	}
	@Override
	public String toString() {
		return "PlotDungeonInfo [plotDungeonType=" + plotDungeonType + ", plotDungeonChapter=" + plotDungeonChapter
				+ ", plotDungeonStatus=" + plotDungeonStatus + "]";
	}
	
}
