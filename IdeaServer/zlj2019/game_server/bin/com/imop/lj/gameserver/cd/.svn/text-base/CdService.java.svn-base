package com.imop.lj.gameserver.cd;

import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.core.annotation.SyncOper;
import com.imop.lj.gameserver.cd.template.CdOpenCondTemplate;
import com.imop.lj.gameserver.common.Globals;

/**
 * 冷却队列服务
 *
 * @author haijiang.jin
 *
 */
public class CdService {
	/**
	 * 冷却队列开启条件字典:
	 * Map<Cd 类型, Map<Cd 索引, Cd开启配置模版>>
	 *
	 */
	private static Map<CdTypeEnum, Map<Integer, CdOpenCondTemplate>>
		_cdOpenCondMap = Maps.newEnumMap(CdTypeEnum.class);

	/**
	 * 类参数构造器
	 *
	 * @param tmplServ
	 */
	public CdService() {
		
	}

	/**
	 * 初始化
	 *
	 */
	@SyncOper
	public void init() {
		// 获取冷却队列开启条件模版列表
		Map<Integer, CdOpenCondTemplate> tmplMap = Globals.getTemplateCacheService().getAll(CdOpenCondTemplate.class);

		for (CdOpenCondTemplate tmpl : tmplMap.values()) {
			// 获取冷却队列类型
			CdTypeEnum cdType = CdTypeEnum.valueOf(tmpl.getCdTypeId());
			// 获取冷却队列索引
			int cdIndex = tmpl.getCdIndex();

			// 获取内置字典
			Map<Integer, CdOpenCondTemplate> innerMap = _cdOpenCondMap.get(cdType);

			if (innerMap == null) {
				innerMap = Maps.newHashMap();
				_cdOpenCondMap.put(cdType, innerMap);
			}
			innerMap.put(cdIndex, tmpl);
		}

		for (CdTypeEnum cdType : CdTypeEnum.values()) {
			if (_cdOpenCondMap.get(cdType) == null) {
//				throw new RuntimeException("未配置 Cd 类型开启条件! CdType = " + cdType.getIndex());
			}
		}
	}

	/**
	 * 获取冷却队列开启条件
	 *
	 * @param cdType
	 * @param cdIndex
	 * @return
	 */
	public CdOpenCondTemplate getCdOpenCondTemplate(CdTypeEnum cdType, int cdIndex) {
		// 获取内置字典
		Map<Integer, CdOpenCondTemplate>
			innerMap = _cdOpenCondMap.get(cdType);

		if (innerMap == null) {
			return null;
		}

		return innerMap.get(cdIndex + 1);
	}

	/**
	 * 获取增加冷却队列所需金币
	 *
	 * @param cdType
	 * @param cdIndex
	 * @return
	 */
	public int getAddCdNeedGold(CdTypeEnum cdType, int cdIndex) {
		// 获取内置字典
		Map<Integer, CdOpenCondTemplate>
			innerMap = _cdOpenCondMap.get(cdType);

		if (innerMap == null) {
			return 0;
		}

		CdOpenCondTemplate tmpl = innerMap.get(cdIndex + 1);

		if (tmpl == null) {
			return 0;
		}

		return tmpl.getAddCdNeedGold();
	}
}
