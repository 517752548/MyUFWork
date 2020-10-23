package com.imop.lj.gameserver.battle.report;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.imop.lj.gameserver.battlereport.BattleReportDefine;

public class RecordContent {
	private List<ReportItem> reports;
	private String owner;
	private int skillId;
	private boolean isDoubleAttack;
	
	public RecordContent(String owner, int skillId, List<ReportItem> reports) {
		this.owner = owner;
		this.skillId = skillId;
		this.reports = new ArrayList<ReportItem>();
		this.reports.addAll(reports);
	}
	
	public String toJsonStr() {
		return null;
	}
	
	public void addReports(ReportItem item) {
		this.reports.add(item);
	}
	
	public void addAllReports(List<ReportItem> itemList) {
		this.reports.addAll(itemList);
	}
	
	public Object toMap() {
		Map<Integer,Object> js = new HashMap<Integer,Object>();
		if (!reports.isEmpty()) {
			js.put(BattleReportDefine.RECORD_CONTENT_OWNER, this.owner);
			js.put(BattleReportDefine.RECORD_CONTENT_SKILLID, this.skillId);
			js.put(BattleReportDefine.REPORT_CONTENT_DOUBLE_ATTACK, Boolean.valueOf(this.isDoubleAttack));

			List<Object> jsreports = new ArrayList<Object>();
			Set<Object> effectIdList = new LinkedHashSet<Object>();
			List<Object> isEmbedList = new ArrayList<Object>();
			for (ReportItem item : reports) {
				jsreports.add(item.toMap());
				if (item.getEffectId() > 0) {
					effectIdList.add(item.getEffectId());
					isEmbedList.add(Boolean.valueOf(item.isEmbedEffect()));
				}
			}
			js.put(BattleReportDefine.RECORD_CONTENT_ITEMLIST, jsreports);
			js.put(BattleReportDefine.RECORD_CONTENT_ITEMLIST_EFFECTID, effectIdList);
			js.put(BattleReportDefine.RECORD_CONTENT_ITEMLIST_EFFECT_ISEMBED, isEmbedList);
			
		}
		return js;
	}
	
	public List<ReportItem> getReports() {
		return reports;
	}

	public void setReports(List<ReportItem> reports) {
		this.reports = reports;
	}

	public String getOwner() {
		return owner;
	}

	public void setOwner(String owner) {
		this.owner = owner;
	}

	public int getSkillId() {
		return skillId;
	}

	public void setSkillId(int skillId) {
		this.skillId = skillId;
	}
	
	public boolean isDoubleAttack() {
		return isDoubleAttack;
	}

	public void setDoubleAttack(boolean isDoubleAttack) {
		this.isDoubleAttack = isDoubleAttack;
	}

	@Override
	public String toString() {
		return "RecordContent [reports=" + reports + ", owner=" + owner + ", skillId=" + skillId + ", isDoubleAttack="
				+ isDoubleAttack + "]";
	}

}
