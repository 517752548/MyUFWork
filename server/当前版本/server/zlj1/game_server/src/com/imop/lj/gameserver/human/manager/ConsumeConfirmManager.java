package com.imop.lj.gameserver.human.manager;

import java.util.HashMap;
import java.util.Map;

import net.sf.json.JSONObject;

import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;

public class ConsumeConfirmManager implements JsonPropDataHolder {

	/** 所属玩家角色 */
	private Human owner;
	/** 所有消费提示类型 Map<提示类型，是否选中不提示1选中不提示0没选中>**/
	private Map<Integer, Integer> confirmMap;

	public Map<Integer, Integer> getConfirmMap() {
		return confirmMap;
	}

	public void setConfirmMap(Map<Integer, Integer> confirmMap) {
		this.confirmMap = confirmMap;
		owner.onModified();
	}

	public ConsumeConfirmManager(Human owner) {
		this.owner = owner;
		this.confirmMap = new HashMap<Integer, Integer>();

	}

//	public ConsumeConfirmInfo[] getListConfirm() {
//		List<ConsumeConfirmInfo> infoList = new ArrayList<ConsumeConfirmInfo>();
//		for (Integer id : this.confirmMap.keySet()) {
//			int key = id - 1;
//
//			ConsumeConfirm confirm = ConsumeConfirm.valueOf(id);
//			if (confirm != null) {
//				ConsumeConfirmInfo info = new ConsumeConfirmInfo();
//				// this.listConfirmMap[id] =this.confirmMap.get(id);
//
//				info.setConsumeType(id);
//				info.setIsShow(this.confirmMap.get(id));
//				Integer langId = confirm.getNameKey();
//				String content = Globals.getLangService().readSysLang(langId);
//				info.setConsumeName(content);
//				infoList.add(info);
//			}
//		}
//		return infoList.toArray(new ConsumeConfirmInfo[0]);
//	}

	// public List<ConsumeConfirmInfo> getListConfirmMap() {
	//
	//
	// for (Integer id : this.confirmMap.keySet())
	// {
	// //this.listConfirmMap[id] =this.confirmMap.get(id);
	// ConsumeConfirmInfo info = new ConsumeConfirmInfo();
	// info.setConsumeType(id);
	// info.setIsShow(this.confirmMap.get(id));
	// ConsumeConfirm confirm = ConsumeConfirm.valueOf(id);
	// Integer langId = confirm.getNameKey();
	// String content = Globals.getLangService().readSysLang(langId);
	// info.setConsumeName(content);
	// listConfirm.add(info);
	// }
	// return listConfirm;
	// }

	public Human getOwner() {
		return owner;
	}

	public void setOwner(Human owner) {
		this.owner = owner;
	}

	/** 通过map的key 得到值 ****/
	public int getConfirmStatus(ConsumeConfirm consumeConfirm) {
		if(consumeConfirm == null){
			return 0;
		}
		if(consumeConfirm.isCanChange){
			if (null == confirmMap){
				return 0;
			}
			if(this.confirmMap.containsKey(consumeConfirm.index)){
				return this.confirmMap.get(consumeConfirm.getIndex());
			}else{
				return 0;
			}
		}else{
			return 0;
		}
	}

	/** 通过map的key 设置值 ****/
	public void setConfirmStatus(ConsumeConfirm consumeConfirm, boolean flag) {
		if(consumeConfirm == null){
			return;
		}
		if(consumeConfirm.isCanChange){
			this.confirmMap.put(consumeConfirm.getIndex(), (flag ? 1 : 0));
			owner.onModified();
		}
	}

//	public void setConfirmStatusByKey(int key, boolean flag) {
//		this.confirmMap.put(key, (flag ? 1 : 0));
//		owner.onModified();
//	}

	/**
	 * 将当前对象转换为 JSON 字符串
	 * 
	 * @return
	 */
	@Override
	public String toJsonProp() {
		JSONObject jsonObj = new JSONObject();
		if (null == confirmMap) {
			return jsonObj.toString();
		}

		for (Integer arrayId : confirmMap.keySet()) {
			jsonObj.put(arrayId, confirmMap.get(arrayId));
		}
		return jsonObj.toString();
	}

	/**
	 * 从 JSON 字符串中还原对象
	 * 
	 * @param jsonStr
	 */
	@Override
	public void loadJsonProp(String jsonStr) {
		if (jsonStr == null || jsonStr.equals("") || jsonStr.equals("0")) {
			return;
		}
		JSONObject arrayInfoJsonObj = JSONObject.fromObject(jsonStr);
		if (arrayInfoJsonObj == null || arrayInfoJsonObj.isEmpty()) {
			for (ConsumeConfirm consumeConfirm : ConsumeConfirm.values()) {
				if (consumeConfirm.isCanChange) {
					confirmMap.put(consumeConfirm.getIndex(), 0);
				}
			}
		}

		for (ConsumeConfirm consumeConfirm : ConsumeConfirm.values()) {
			if (consumeConfirm.isCanChange) {
				// 改为 玩家每次登陆进来后，都默认不提示
				int isConfirm = 1;//int isConfirm = JsonUtils.getInt(arrayInfoJsonObj, consumeConfirm.getIndex());
				confirmMap.put(consumeConfirm.getIndex(), isConfirm);
			}
		}
	}
}














