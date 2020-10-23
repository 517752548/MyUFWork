package com.imop.lj.gameserver.battle.report;

import java.util.HashMap;
import java.util.Map;
import java.util.Map.Entry;

import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battlereport.BattleReportDefine;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.skill.template.SkillEffectTemplate;

public class ReportItem {
	/** 目标 */
	private String target;
	
	/** 目标属性值 */
	private Map<Integer, Object> attrMap = new HashMap<Integer, Object>();
	/** 目标buff */
	private Map<Integer, Object> buffMap = new HashMap<Integer, Object>();
	/** 行为数据Map */
	private Map<Integer, Object> actionMap = new HashMap<Integer, Object>();
	
//	/** 错误信息 XXX 调试用 */
//	private List<String> errMsgList = new ArrayList<String>();
	private String errMsg = "";
	
	/** 效果Id */
	private int effectId;
	
	public static ReportItem valueOf(FightUnit unit, IEffect sourceEffect) {
		ReportItem result = new ReportItem(unit.getIdentifier());
		if (sourceEffect != null) {
			result.setEffectId(sourceEffect.getEffectTpl().getId());
		}
		return result;
	}
	
	public ReportItem(String target) {
		this.target = target;
	}
	
	public Object getAttr(Integer key) {
		return attrMap.get(key);
	}
	
	public void updateAttr(Integer key, Object value) {
		this.attrMap.put(key, value);
	}
	
	public Object getBuff(Integer key) {
		return buffMap.get(key);
	}
	
	public void updateBuff(Integer key, Object value) {
		this.buffMap.put(key, value);
	}
	
	public void setBuffMap(Map<Integer, Object> buffMap) {
		this.buffMap = buffMap;
	}
	
	public Object getAction(Integer key) {
		return this.actionMap.get(key);
	}

	public void updateAction(Integer key, Object value) {
		this.actionMap.put(key, value);
	}
	
	public String getTarget() {
		return target;
	}

	public void setTarget(String target) {
		this.target = target;
	}
	
//	public List<String> getErrMsgList() {
//		return errMsgList;
//	}
//
//	public void addErrMsg(String msg){
//		this.errMsgList.add(msg);
//	}
	
	public String getErrMsg() {
		return errMsg;
	}

	public void setErrMsg(String errMsg) {
		this.errMsg = errMsg;
	}

	public int getEffectId() {
		return effectId;
	}

	public void setEffectId(int effectId) {
		this.effectId = effectId;
	}
	
	public boolean isEmbedEffect() {
		if (this.effectId > 0) {
			SkillEffectTemplate tpl = Globals.getTemplateCacheService().get(this.effectId, SkillEffectTemplate.class);
			if (tpl != null) {
				return tpl.isEmbedSkillEffect();
			}
		}
		return false;
	}

	public Object toMap() {
		Map<Integer, Object> js = new HashMap<Integer,Object>();
		js.put(BattleReportDefine.REPORT_ITEM_TARGET, this.target);
		
		if (!attrMap.isEmpty()) {
			for (Entry<Integer, Object> entry : attrMap.entrySet()) {
				js.put(entry.getKey(), entry.getValue());
			}
		}
		if (!buffMap.isEmpty()) {
			for (Entry<Integer, Object> entry : buffMap.entrySet()) {
				js.put(entry.getKey(), entry.getValue());
			}
		}
		if (!actionMap.isEmpty()) {
			for (Entry<Integer, Object> entry : actionMap.entrySet()) {
				js.put(entry.getKey(), entry.getValue());
			}
		}
		if (!errMsg.isEmpty()) {
			js.put(BattleReportDefine.BATTLE_ERROR, this.errMsg);
		}
		return js;
	}

}
