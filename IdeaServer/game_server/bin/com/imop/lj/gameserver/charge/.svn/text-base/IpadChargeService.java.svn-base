package com.imop.lj.gameserver.charge;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.charge.template.IpadChargeTemplate;
import com.imop.lj.gameserver.charge.template.IpadChargeTplTemplate;

/**
 *
 * ipad充值相关配置服务管理器
 *
 * @author fanghua.cui
 *
 */
public class IpadChargeService implements InitializeRequired {

	private Map<String, List<String>> idsMap = new HashMap<String, List<String>>();

	private Map<String, JSONArray> idsInfoMap = new HashMap<String, JSONArray>();

	// private static final String defaultAppType = "com.imop.game.sz";

	private TemplateService templateService;

	// key:productId value:IpadChargeTemplate
	private Map<String, Map<String,IpadChargeTemplate>> allGiftFixedItemTemplates = new HashMap<String, Map<String,IpadChargeTemplate>>();

	public IpadChargeService(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		Map<Integer, IpadChargeTemplate> allTemplates = templateService.getAll(IpadChargeTemplate.class);

		if (allTemplates != null && allTemplates.size() > 0) {

			IpadChargeTemplate[] templates = allTemplates.values().toArray(new IpadChargeTemplate[allTemplates.size()]);

			for (int i = 0; i < templates.length; i++) {
				String appid = templates[i].getAppid();

				if (idsMap.get(appid) == null) {
					List<String> ids = new ArrayList<String>();
					ids.add(templates[i].getProductId());
					idsMap.put(appid, ids);
				} else {
					idsMap.get(appid).add(templates[i].getProductId());
				}
				if (allGiftFixedItemTemplates.get(appid) == null) {
					Map<String,IpadChargeTemplate> templatesMap = new LinkedHashMap<String,IpadChargeTemplate>();
					templatesMap.put(templates[i].getProductId(), templates[i]);
					allGiftFixedItemTemplates.put(appid, templatesMap);
				}else {
					allGiftFixedItemTemplates.get(appid).put(templates[i].getProductId(), templates[i]);
				}

				JSONObject info = new JSONObject();
				info.put("id", templates[i].getProductId());
				info.put("name", templates[i].getName());
				info.put("coins", templates[i].getCoins());
				info.put("amount", templates[i].getAmount() + "");
				if (idsInfoMap.get(appid) == null) {
					JSONArray infos = new JSONArray();
					idsInfoMap.put(appid, infos);
					infos.add(info);
				}else{
					JSONArray infos = idsInfoMap.get(appid);
					infos.add(info);
				}
			}
		}
	}

	public String[] getDefaultIPadCharges(String appid) {
//		System.out.println(appid);
//		System.out.println(idsMap);
		List<String> charges = idsMap.get(appid);
		if(charges == null){
			// XXX 新增
			List<IpadChargeTemplate> list = getIPadChargesWithTpl(appid);
			if (list != null && list.size() > 0) {
				String[] ret = new String[list.size()];
				int i = 0;
				for (IpadChargeTemplate info : list) {
					ret[i++] = info.getProductId();
				}
				return ret;
			}

			return new String[0];
		}
		return idsMap.get(appid).toArray(new String[idsMap.get(appid).size()]);
	}

	/**
	 * 在已有的配置文件中找不到相应的appid时，按照规则生成一套充值档位列表
	 * @param appid
	 * @return
	 */
	public List<IpadChargeTemplate> getIPadChargesWithTpl(String appid) {
		List<IpadChargeTemplate> infoList = new ArrayList<IpadChargeTemplate>();
		Map<Integer, IpadChargeTplTemplate> tplMap = templateService.getAll(IpadChargeTplTemplate.class);
		String dot = ".";
		if (null != appid && appid.contains(dot) &&
				tplMap != null && tplMap.size() > 0) {
			String[] tmp = appid.split("\\"+dot);
			if (tmp.length > 1) {// . 后必须有值
				String productIdPrefix = tmp[tmp.length-1];
				for (IpadChargeTplTemplate tpl : tplMap.values()) {
					// 拼出充值档位id
					String productId = productIdPrefix + dot + tpl.getProductIdPostfix();

					IpadChargeTemplate info = new IpadChargeTemplate();
					info.setProductId(productId);
					info.setAppid(appid);
					info.setName(tpl.getName());
					info.setDesc(tpl.getDesc());
					info.setIcon(tpl.getIcon());
					info.setCostRMB(tpl.getCostRMB());
					info.setCoins(tpl.getCoins());
					info.setAreaId(tpl.getAreaId());
					info.setAppType(tpl.getAppType());
					info.setAmount(tpl.getAmount());

					infoList.add(info);
				}
			}
		}
		return infoList;
	}

	public String getItemTable(String appid) {
//		System.out.println(appid);
//		System.out.println(idsMap);
		JSONArray a = idsInfoMap.get(appid);
		if(a == null){
			//XXX 新增自动生成模板
			List<IpadChargeTemplate> list = getIPadChargesWithTpl(appid);
			if (list != null && list.size() > 0) {
				JSONArray infos = new JSONArray();
				for (IpadChargeTemplate tpl : list) {
					JSONObject info = new JSONObject();
					info.put("id", tpl.getProductId());
					info.put("name", tpl.getName());
					info.put("coins", tpl.getCoins());
					info.put("amount", tpl.getAmount() + "");
					infos.add(info);
				}
				return infos.toString();
			}

			return "";
		}
		return idsInfoMap.get(appid).toString();
	}

	/**
	 * 根据档位获取对应的模板
	 *
	 * @param productId
	 * @return
	 */
	public IpadChargeTemplate getIpadChargeTemplate(String appid,String productId) {
		Map<String,IpadChargeTemplate> tmpMap = allGiftFixedItemTemplates.get(appid);
		if(tmpMap == null){
			//XXX 新增自动生成模板
			List<IpadChargeTemplate> list = getIPadChargesWithTpl(appid);
			if (list != null && list.size() > 0) {
				for (IpadChargeTemplate tpl : list) {
					if (tpl.getProductId().equalsIgnoreCase(productId)) {
						return tpl;
					}
				}
			}

			return null;
		}
		IpadChargeTemplate tmp = tmpMap.get(productId);
		return tmp;
	}

	/**
	 * 根据档位获取对应的模板
	 *
	 * @param productId
	 * @return
	 */
	public List<IpadChargeTemplate> getIpadChargeTemplateByAppid(String appid) {
		Map<String,IpadChargeTemplate> templateMap = allGiftFixedItemTemplates.get(appid);
		List<IpadChargeTemplate> list = new ArrayList<IpadChargeTemplate>();
		if(templateMap == null){
			// XXX 新增
			return getIPadChargesWithTpl(appid);
		}
		list.addAll(templateMap.values());
		return list;
	}

//	public String[] getIPadCharges(String appType) {
//		List<String> ids = idsMap.get(appType);
//
//		if (ids == null) {
//			return new String[0];
//		} else {
//			return ids.toArray(new String[ids.size()]);
//		}
//
//	}
}
