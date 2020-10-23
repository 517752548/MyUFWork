package com.imop.lj.gameserver.goodactivity.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateFileParser;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.template.TemplateService;
import org.apache.poi.hssf.usermodel.HSSFRow;
import org.apache.poi.hssf.usermodel.HSSFSheet;
import org.apache.poi.hssf.usermodel.HSSFWorkbook;
import org.apache.poi.poifs.filesystem.POIFSFileSystem;

import java.io.InputStream;
import java.util.HashMap;
import java.util.Map;

/**
 * 
 * 在同一个sheet页可以生成多种道具类型的模板
 * 
 */
public class GoodActivityTargetTemplateFileParser extends TemplateFileParser {

//	/** 身份类型所在列 */
//	private static final int ID_TYPE_COLUMN = 1;
	
	private Class<?>[] clazzes = new Class<?>[SHEET_NUM];

	private int index = 0;
	/** 表sheet个数 */
	private static final int SHEET_NUM = 11;// TODO 增加表时需要修改
	
	public GoodActivityTargetTemplateFileParser() {
		super();
		// TODO 增加表时往后边加
		clazzes[index++] = GoodActivityTargetTemplate.class;
		clazzes[index++] = GoodActivityNormalTotalChargeTargetTemplate.class;
		clazzes[index++] = GoodActivityDayTotalChargeTargetTemplate.class;
		clazzes[index++] = GoodActivityTotalChargeBuyTargetTemplate.class;
		clazzes[index++] = GoodActivityLevelUpTargetTemplate.class;
		clazzes[index++] = GoodActivityVipLevelTargetTemplate.class;
		clazzes[index++] = GoodActivityTotalCostTargetTemplate.class;
		clazzes[index++] = GoodActivityEveryCostTargetTemplate.class;
		clazzes[index++] = GoodActivitySevenDayLoginTargetTemplate.class;
		clazzes[index++] = GoodActivityBuyMoneyTargetTemplate.class;
		clazzes[index++] = GoodActivityLevelMoneyTargetTemplate.class;

	}

	/**
	 * 
	 * 解析一个Excel文件，加载该文件表示的所有TemplateObject对象到templateObjects；
	 * 
	 * @param classes
	 *            不使用该参数 由本类私有clazzes决定
	 * @param templateObjects
	 * @throws Exception
	 */
	@Override
	public void parseXlsFile(Class<?>[] classes, Map<Class<?>, Map<Integer, TemplateObject>> templateObjects, InputStream is, String fileName,
			TemplateService templateService) throws Exception {
		HSSFWorkbook wb = new HSSFWorkbook(new POIFSFileSystem(is));
		// 第一个sheet是活动基础配置，跳过
		for(int i = 1 ; i < SHEET_NUM ; i ++){
			HSSFSheet sheet = wb.getSheetAt(i);
			
			Map<Integer, TemplateObject> curSheetObjects = parseXlsSheet(sheet, i, fileName, templateService);
			Map<Integer, TemplateObject> existCurClazzMap = templateObjects.get(clazzes[0]);
			
			// 检查不同类型的道具id是否有重复
			for (Integer curId : curSheetObjects.keySet()) {
				if (existCurClazzMap != null && existCurClazzMap.containsKey(curId)) {
					throw new TemplateConfigException(sheet.getSheetName(), curId, String.format("id重复:%d", curId));
				}
			}
			
			if (existCurClazzMap != null) {
				existCurClazzMap.putAll(curSheetObjects);
			} else {
				templateObjects.put(clazzes[0], curSheetObjects);
			}
		}
	}

	/**
	 * 重载上面方法的目的：为了对应item模板与其他模板规则不一致的情况 解析Excel文件中的一个Sheet，返回以<id,数据对象>为键值对的Map
	 * classes类型要等到读到row时才能确定
	 * 
	 * @param sheet
	 * 
	 * @return
	 * @throws IllegalAccessException
	 * @throws InstantiationException
	 */
	private Map<Integer, TemplateObject> parseXlsSheet(HSSFSheet sheet, int sheetNum, String excelFileName, TemplateService templateService)
			throws InstantiationException, IllegalAccessException {
		Map<Integer, TemplateObject> map = new HashMap<Integer, TemplateObject>();
		for (int i = 1; i < Short.MAX_VALUE; i++) {
			HSSFRow row = sheet.getRow(i);
			if (isEmpty(row)) {
				// 遇到空行就结束
				break;
			}
			// 读每个row之前，要先判断item的"物品身份类型"，来决定模板对象obj的真实类型
			GoodActivityTargetTemplate obj = null;
//			HSSFCell cell = row.getCell(ID_TYPE_COLUMN);
//			int gaId = PoiUtils.getIntValue(cell);
			
//			HSSFCell idCell = row.getCell(0);
//			int templId = PoiUtils.getIntValue(idCell);
			
			// 第n个sheet就按照对应的clazzes数组中的解析
			obj = (GoodActivityTargetTemplate) clazzes[sheetNum].newInstance();
			obj.setTemplateService(templateService);
			
//			GoodActivityBaseTemplate baseTpl = Globals.getTemplateCacheService().get(gaId, GoodActivityBaseTemplate.class);
//			GoodActivityType idType = GoodActivityType.valueOf(baseTpl.getGoodActivityType());
//			if (obj.getGoodActivityType() != idType) {
//				throw new TemplateConfigException(GoodActivityTargetTemplate.SHEET_NAME, templId, "活动Id与类型不匹配！活动Id=" + gaId);
//			}
			
			obj.setSheetNum(sheetNum);
			obj.setSheetName(sheet.getSheetName());
			obj.setExcelName(excelFileName);
			
			this.parseXlsRow(obj, row);
			if (map.containsKey(obj.getId())) {
				throw new TemplateConfigException(sheet.getSheetName(), obj.getId(), String.format("id重复:%d", obj.getId()));
			}
			map.put(obj.getId(), obj);
		}
		return map;
	}

	@Override
	public Class<?>[] getLimitClazzes() {
		return this.clazzes;
	}
}
