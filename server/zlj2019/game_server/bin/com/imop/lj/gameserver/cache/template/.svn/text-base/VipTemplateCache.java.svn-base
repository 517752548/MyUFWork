package com.imop.lj.gameserver.cache.template;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.template.VipItemTemplate;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.exp.model.ExpConfigInfo;
import com.imop.lj.gameserver.vip.VipDef;
import com.imop.lj.gameserver.vip.VipDef.VipFuncTypeEnum;
import com.imop.lj.gameserver.vip.VipDef.VipLevel;
import com.imop.lj.gameserver.vip.template.VipConfigTemplate;
import com.imop.lj.gameserver.vip.template.VipUpgradeTemplate;

/**
 * VIP模版配置缓存
 * 
 * @author xiaowei.liu
 * 
 */
public class VipTemplateCache implements InitializeRequired {
	/** 模板 */
	protected TemplateService templateService;
	
	/**升级配置*/
	protected ExpConfigInfo vipExpConfigInfo;

	/** 权限控制 */
	private Map<Integer, Map<VipFuncTypeEnum, VipItemTemplate>> privilegeMap;
	
	/** 战斗加速需要的vip等级 */
	private int battleSpeedupVipLevel;
	
	public VipTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		this.initvipExpConfigInfo();
		this.initPrivilegeMap();
		
		this.checkPrivilegeMap();

	}

	/**
	 * 初始化VIP升级配置
	 */
	private void initvipExpConfigInfo(){
		Map<Integer, Long> expMap = new HashMap<Integer, Long>();
		for(VipUpgradeTemplate tmpl : this.templateService.getAll(VipUpgradeTemplate.class).values()) {
			expMap.put(tmpl.getId(), tmpl.getRequireExp());
		}
		vipExpConfigInfo = Globals.getExpService().createExpConfig(expMap, true, VipDef.VipMaxLevel);
		if(vipExpConfigInfo == null){
			throw new TemplateConfigException("VIP升级配置", 0, "VIP升级配置错误");
		}
	}
	
	/**
	 * 初始化权限Map
	 */
	private void initPrivilegeMap(){
		this.privilegeMap = new HashMap<Integer, Map<VipFuncTypeEnum, VipItemTemplate>>();
		
		for (VipConfigTemplate tmpl : this.templateService.getAll(VipConfigTemplate.class).values()) {
			for (int i = 0; i < tmpl.getVipItemList().size(); i++) {
				VipItemTemplate item = tmpl.getVipItemList().get(i);
				
				// 获取指定VipLevel的权限Map
				VipLevel vipLevel = VipLevel.values()[i];
				Map<VipFuncTypeEnum, VipItemTemplate> typeMap = this.privilegeMap.get(vipLevel.getIndex());
				if (typeMap == null) {
					typeMap = new HashMap<VipFuncTypeEnum, VipItemTemplate>();
					this.privilegeMap.put(vipLevel.getIndex(), typeMap);
				}
				
				typeMap.put(tmpl.getVipFuncTypeEnum(), item);
			}
		}
	}
	
	public void checkPrivilegeMap() {
		for (VipLevel vl : VipLevel.values()) {
			Map<VipFuncTypeEnum, VipItemTemplate> typeMap = this.privilegeMap.get(vl.getIndex());
			if (typeMap == null) {
				throw new TemplateConfigException("VIP权限配置", 0, "VIP 等级 = "
						+ vl.getIndex() + "没有配置权限");
			}

			for (VipFuncTypeEnum type : VipFuncTypeEnum.values()) {
				if (typeMap.get(type) == null) {
					throw new TemplateConfigException("VIP权限配置", 0, "VIP 等级 = "
							+ vl.getIndex() + ", Vip type = " + type + " 没有配置");
				}
			}
			
			//生成战斗加速需要的最小vip等级
			if (battleSpeedupVipLevel == 0 &&
					typeMap.get(VipFuncTypeEnum.BATTLE_SPEEDUP) != null &&
					typeMap.get(VipFuncTypeEnum.BATTLE_SPEEDUP).isOpen()) {
				battleSpeedupVipLevel = vl.getIndex();
			}
		}
	}
	
	/**
	 * 根据Vip类型和级别获取当前权限配置
	 * 
	 * @param vipLevel
	 * @param type
	 * @return
	 */
	public VipItemTemplate getVipItemTemplateByTypeAndLevel(int vipLevel, VipFuncTypeEnum type){
		Map<VipFuncTypeEnum, VipItemTemplate> typeMap = this.privilegeMap.get(vipLevel);
		if (typeMap == null) {
			return null;
		}

		return typeMap.get(type);
	}
	
	/**
	 * 检查指定级别是否具有指定功能权限
	 * 
	 * @param vipLevel
	 * @param type
	 * @return
	 */
	public boolean checkVipRule(int vipLevel, VipFuncTypeEnum type){
		VipItemTemplate tmpl = this.getVipItemTemplateByTypeAndLevel(vipLevel, type);
		if (tmpl == null) {
			return false;
		} else {
			return tmpl.isOpen();
		}
	}
	
	/**
	 * 获取指定级别指定功能的参数
	 * 
	 * @param vipLevel
	 * @param type
	 * @return
	 */
	public int getCountForVipTypeEnumOnOpen(int vipLevel, VipFuncTypeEnum type) {
		VipItemTemplate tmpl = this.getVipItemTemplateByTypeAndLevel(vipLevel, type);
		if (tmpl == null) {
			return 0;
		} else {
			return tmpl.getNum();
		}
	}
	
	/**
	 * 获得vip经验配置对象
	 * 
	 * @return
	 */
	public ExpConfigInfo getVipExpConfigInfo() {
		return vipExpConfigInfo;
	}

	public int getBattleSpeedupVipLevel() {
		return battleSpeedupVipLevel;
	}

}
