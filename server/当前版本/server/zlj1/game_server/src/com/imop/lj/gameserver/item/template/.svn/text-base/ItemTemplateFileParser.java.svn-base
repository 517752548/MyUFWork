package com.imop.lj.gameserver.item.template;

import java.io.InputStream;
import java.util.HashMap;
import java.util.Map;

import org.apache.poi.hssf.usermodel.HSSFCell;
import org.apache.poi.hssf.usermodel.HSSFRow;
import org.apache.poi.hssf.usermodel.HSSFSheet;
import org.apache.poi.hssf.usermodel.HSSFWorkbook;
import org.apache.poi.poifs.filesystem.POIFSFileSystem;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateFileParser;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.core.util.PoiUtils;
import com.imop.lj.gameserver.item.ItemDef;

/**
 * 
 * 在同一个sheet页可以生成多种道具类型的模板
 * 
 */
public class ItemTemplateFileParser extends TemplateFileParser {

	/** 身份类型所在列 */
	private static final int IDENDITY_TYPE_COLUMN = 6;
	/** 物品表sheet个数*/
	private static int SHEET_NUM = 8;
	
	private Class<?>[] clazzes = new Class<?>[SHEET_NUM + 1];

	public ItemTemplateFileParser() {
		super();
		clazzes[0] = ItemTemplate.class;
		clazzes[1] = NormalItemTemplate.class;
		clazzes[2] = ConsumeItemTemplate.class;
		clazzes[3] = EquipItemTemplate.class;
		clazzes[4] = PetSkillBookItemTemplate.class;
		clazzes[5] = GemItemTemplate.class;
		clazzes[6] = NormalItemTemplate.class;
		clazzes[7] = SkillEffectItemTemplate.class;
		clazzes[8] = LeaderSkillBookTemplate.class;
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
		for(int i = 0 ; i < SHEET_NUM ; i ++){
			HSSFSheet sheet = wb.getSheetAt(i);
			Map<Integer, TemplateObject> curSheetObjects = parseXlsSheet(sheet, 0, fileName, templateService);
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
			ItemTemplate obj = null;
			HSSFCell cell = row.getCell(IDENDITY_TYPE_COLUMN);
			int equipType = PoiUtils.getIntValue(cell);
			ItemDef.IdentityType idType = ItemDef.IdentityType.valueOf(equipType);
			HSSFCell idCell = row.getCell(0);
			int templId = PoiUtils.getIntValue(idCell);
			// 身份类型不可以不填
			if (idType == null || idType == ItemDef.IdentityType.NULL) {
				throw new TemplateConfigException(ItemTemplate.SHEET_NAME, templId, "错误的道具身份类型 typeId=" + equipType);
			}
			switch (idType) {
			case NORMAL:
				// 普通
				obj = (ItemTemplate) clazzes[1].newInstance();
				break;
			case CONSUMABLE:
				// 消耗品
				obj = (ItemTemplate) clazzes[2].newInstance();
				break;
			case EQUIP:
				// 装备
				obj = (ItemTemplate) clazzes[3].newInstance();
				break;
			case PET_SKILL_BOOK:
				// 宠物技能书
				obj = (ItemTemplate) clazzes[4].newInstance();
				break;
			case GEM:
				// 宝石
				obj = (ItemTemplate) clazzes[5].newInstance();
				break;
				//仙符道具
			case SKILL_EFFECT_ITEM:
				obj = (ItemTemplate) clazzes[7].newInstance();
				break;
				//人物技能书
			case LEADER_SKILL_BOOK:
				obj = (ItemTemplate) clazzes[8].newInstance();
				break;
			default:
				throw new TemplateConfigException(ItemTemplate.SHEET_NAME, templId, "错误的道具身份类型 typeId=" + equipType);
			}
//			if (obj == null)
//				break;
			obj.setTemplateService(templateService);
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
