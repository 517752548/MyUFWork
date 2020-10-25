package com.imop.lj.gameserver.scene.template;

import java.util.Map;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

/**
 * 城市模版
 *
 * @author haijiang.jin
 *
 */
@ExcelRowBinding
public class SceneTemplate extends SceneTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		// 获取场景模版字典
		Map<Integer, SceneTemplate> sceneTplMap = this.templateService.getAll(SceneTemplate.class);

		if ((sceneTplMap == null) ||
			(sceneTplMap.size() <= 0)) {
			throw new TemplateConfigException("区域配置", 0, "template data is empty");
		}

		// 检查 X, Y 坐标
//		this.checkPosXY(sceneTplMap);
	}

//	/**
//	 * 检查 X, Y 坐标是否有重叠
//	 *
//	 * @param sceneTplMap
//	 */
//	private void checkPosXY(Map<Integer, SceneTemplate> sceneTplMap)
//		throws TemplateConfigException {
//		if (sceneTplMap == null) {
//			return;
//		}
//
//		SceneTemplate[] sceneTplArray;
//
//		// 创建场景模版数组
//		sceneTplArray = new SceneTemplate[sceneTplMap.size()];
//		sceneTplArray = sceneTplMap.values().toArray(sceneTplArray);
//
//		for (int i = 0; i < sceneTplArray.length; i++) {
//			// 获取场景模版 i
//			SceneTemplate sceneTpl_i = sceneTplArray[i];
//			// 获取模版 Id
//			int currTplId = sceneTpl_i.getId();
//
//			for (int j = i + 1; j < sceneTplArray.length; j++) {
//				// 获取场景模版 j
//				SceneTemplate sceneTpl_j = sceneTplArray[j];
//				// 获取场景模版 j Id
//				int tpljId = sceneTpl_j.getId();
//
//				if ((sceneTpl_i.getX() == sceneTpl_j.getX()) &&
//					(sceneTpl_i.getY() == sceneTpl_j.getY())) {
//					// 如果 X, Y 坐标重叠, 则抛出异常
//					throw new TemplateConfigException("区域配置", currTplId,
//						String.format("position ( X, Y ) is overlap! Id0 = %d, Id1 = %d", currTplId, tpljId));
//				}
//			}
//		}
//	}
}
