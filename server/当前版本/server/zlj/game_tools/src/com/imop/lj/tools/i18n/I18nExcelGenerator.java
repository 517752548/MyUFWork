package com.imop.lj.tools.i18n;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.lang.reflect.Array;
import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.lang.reflect.Modifier;
import java.net.URL;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;

import org.apache.commons.collections.map.MultiKeyMap;
import org.apache.log4j.Logger;
import org.apache.poi.hssf.usermodel.HSSFCell;
import org.apache.poi.hssf.usermodel.HSSFCellStyle;
import org.apache.poi.hssf.usermodel.HSSFFont;
import org.apache.poi.hssf.usermodel.HSSFRow;
import org.apache.poi.hssf.usermodel.HSSFSheet;
import org.apache.poi.hssf.usermodel.HSSFWorkbook;
import org.apache.poi.poifs.filesystem.POIFSFileSystem;

import com.imop.lj.common.exception.ConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.template.BeanFieldNumber;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.LangModel;
import com.imop.lj.core.template.TemplateObject;

public class I18nExcelGenerator {

	/** 日志 */
	private static final Logger logger = Logger.getLogger(SysLangGenerator.class);

	/** 指定多个值的时候，用来分隔的字符串 */
	private static final String OBJATTRIBUTE_SPLIT = ",";
	private static final String COLLECTION_SPLIT = ";";

	private static final String path_resource = "../resources/scripts/";

	private static final String CONFIG_DIR = "excel/";

	private static final String TEMPLATE_PATH = CONFIG_DIR + "templates.xml";

	/** 相对路径 */
	private static final String SYS_LANG_PATN = "..\\resources\\i18n\\en_US\\";

	public static final Map<Class<?>, Field[]> classFields = new HashMap<Class<?>, Field[]>();

	/** Map<文件名称,map<页码,List<LangModel>> */
	private Map<String, Map<String, List<LangModel>>> langMap = new HashMap<String, Map<String, List<LangModel>>>();

	private MultiKeyMap keMap = new MultiKeyMap();

	public I18nExcelGenerator() {

	}

	public void doAssemble(Object obj, Class<?> clazz, int templateId, int sheetNum, String fileName) throws Exception {
		Class<?> superClazz = clazz.getSuperclass();
		// 如果父类是一个绑定类，那么先处理
		if (superClazz != null && superClazz.isAnnotationPresent(ExcelRowBinding.class)) {
			doAssemble(obj, superClazz, templateId, sheetNum, fileName);
		}
		Field[] fields = null;
		if (classFields.containsKey(clazz)) {
			fields = classFields.get(clazz);
		} else {
			fields = clazz.getDeclaredFields();
			Field.setAccessible(fields, true);
			classFields.put(clazz, fields);
		}
		for (int i = 0; i < fields.length; i++) {
			if ((fields[i].getModifiers() & Modifier.STATIC) != 0) {
				continue;
			} else if (fields[i].isAnnotationPresent(ExcelCellBinding.class)) {
				ExcelCellBinding binding = fields[i].getAnnotation(ExcelCellBinding.class);
				// Class<?> fieldType = fields[i].getType();
				// Object fValue = getFieldValue(fields[i], fieldType, binding.offset());

				// 多语言id对应模板列
				int langIdOffset = binding.offset();
				if (fields[i].getName().endsWith("LangId")) {
					Field langIdField = fields[i];
					String langName = fields[i].getName().substring(0, fields[i].getName().lastIndexOf("LangId"));
					// 查找对应多语言字段
					int langOffset = 0;
					Field langField = null;
					for (int j = 0; j < fields.length; j++) {
						// 查找对应多语言字段
						if (fields[j].getName().equals(langName)) {
							if (fields[j].isAnnotationPresent(ExcelCellBinding.class)) {
								langField = fields[j];
								ExcelCellBinding _binding = fields[j].getAnnotation(ExcelCellBinding.class);
								// //多语言对应模板列
								langOffset = _binding.offset();
								break;
							}
						}
					}
					this.recordMap(fileName, sheetNum, templateId, langIdField, langField, langIdOffset, langOffset, obj);
				}
				// 处理本身是绑定的字段
			} else if (fields[i].isAnnotationPresent(ExcelRowBinding.class)) {
				Class<?> fieldType = fields[i].getType();
				Object subObject = (Object) fields[i].get(obj);
				doAssemble(subObject, fieldType, templateId, sheetNum, fileName);
			} else if (fields[i].isAnnotationPresent(ExcelCollectionMapping.class)) {
				this.insertCollection(fields[i], obj, templateId, sheetNum, fileName);
			}
		}
	}

	/**
	 * 初始化obj中的Collection属性；
	 *
	 * @param field
	 * @param obj
	 * @param row
	 * @throws ScriptRuleException
	 */
	@SuppressWarnings("unchecked")
	private void insertCollection(Field field, Object obj, int templateId, int sheetNum, String fileName) {
		ExcelCollectionMapping ecm = field.getAnnotation(ExcelCollectionMapping.class);
		Class<?> fieldType = field.getType();
		try {

			for (Class<?> tmp : field.getType().getInterfaces()) {
				if (tmp == List.class || tmp == Set.class || tmp == Map.class) {
					fieldType = tmp;
				}
			}
			if (fieldType == List.class) {
				List<Object> fieldValue = (List<Object>) field.get(obj);
				this.insertSetOrList(fieldValue, ecm, templateId, sheetNum, fileName);
			} else if (fieldType == Set.class) {
				Set<Object> fieldValue = (Set<Object>) field.get(obj);
				this.insertSetOrList(fieldValue, ecm, templateId, sheetNum, fileName);
			} else if (fieldType == Map.class) {
				// TODO 没弄明白map怎么回事，所以按异常处理
				throw new ConfigException("Unsupported field type :" + fieldType);
			} else if (fieldType.isArray()) {
				Object fieldValue = (Object) field.get(obj);
				this.getArray(fieldValue, fieldType, ecm, templateId, sheetNum, fileName);
			} else {
				throw new ConfigException("Unsupported field type :" + fieldType);
			}
		} catch (Exception e) {
			throw new ConfigException(e);
		}
	}

	private void insertSetOrList(Collection<Object> col, ExcelCollectionMapping ecm, int templateId, int sheetNum, String fileName) throws Exception {
		Class<?> element_cl = ecm.clazz();
		String cn = ecm.collectionNumber();
		String[] cns = cn.split(COLLECTION_SPLIT);
		for (int i = 0; i < cns.length; i++) {
			String[] strs = cns[i].split(OBJATTRIBUTE_SPLIT);
			Object[] os = col.toArray(new Object[0]);
			Object o = os[i];
			if (element_cl.isAnnotationPresent(ExcelRowBinding.class))
				this.getElementObject(o, element_cl, strs, templateId, sheetNum, fileName); // 处理自定义类的情况
			else {// 处理基本类型
				if (strs.length > 1)
					throw new ConfigException(String.format("cell's number greater than 1 on row(%d)", 0));
				// o = this.getFieldValue(null, element_cl, new Integer(strs[0]));
			}
			// col.add(o);
		}
	}

	private void getArray(Object fieldValue, Class<?> fieldType, ExcelCollectionMapping ecm, int templateId, int sheetNum, String fileName) throws Exception {
		Class<?> element_cl = fieldType.getComponentType();
		String cn = ecm.collectionNumber();
		String[] cns = cn.split(COLLECTION_SPLIT);
		// Object arr = Array.newInstance(element_cl, cns.length);
		for (int i = 0; i < cns.length; i++) {
			String[] strs = cns[i].split(OBJATTRIBUTE_SPLIT);
			Object o = Array.get(fieldValue, i);
			if (element_cl.isAnnotationPresent(ExcelRowBinding.class))
				this.getElementObject(o, element_cl, strs, templateId, sheetNum, fileName); // 处理自定义类的情况
			else {// 处理基本类型
				if (strs.length > 1)
					throw new ConfigException("cell's number greater than 1");
				// o = this.getFieldValue(null, element_cl, new Integer(strs[0]));
			}
			// Array.set(arr, i, o);
		}

	}

	/**
	 * 根据Excel表格，组装集合（Map、List、Set）中的一个元素；
	 *
	 * @param clazz
	 *            集合中元素的Class对象
	 * @param strs
	 *            对应的excel表格号，如{7,8,9}
	 * @param row
	 * @return
	 */
	private void getElementObject(Object fieldValue, Class<?> clazz, String[] strs, int templateId, int sheetNum, String fileName) {
		try {
			Field[] fields = null;
			if (classFields.containsKey(clazz)) {
				fields = classFields.get(clazz);
			} else {
				fields = clazz.getDeclaredFields();
				Field.setAccessible(fields, true);
				classFields.put(clazz, fields);
			}

			Map<Integer, Field> refFields = new HashMap<Integer, Field>();
			for (Field field : fields) {
				if (field.isAnnotationPresent(BeanFieldNumber.class)) {
					refFields.put(field.getAnnotation(BeanFieldNumber.class).number(), field);
				}
			}

			for (int i = 0; i < strs.length; i++) {
				int number = Integer.parseInt(strs[i]);
				// Object fValue;
				Field field = refFields.get(i + 1);

				if (field == null) {
					continue;
				}

				if (field.getName().endsWith("LangId")) {
					Field langIdField = field;
					int langIdOffset = number;
					String langName = langIdField.getName().substring(0, langIdField.getName().lastIndexOf("LangId"));
					// 查找对应多语言字段
					int langOffset = 0;
					Field langField = null;
					for (int j = 0; j < fields.length; j++) {
						langOffset = Integer.parseInt(strs[j]);
						// 查找对应多语言字段
						if (fields[j].getName().equals(langName)) {
							if (fields[j].isAnnotationPresent(BeanFieldNumber.class)) {
								langField = fields[j];
								break;
							}
						}
					}
					this.recordMap(fileName, sheetNum, templateId, langIdField, langField, langIdOffset, langOffset, fieldValue);
				}
			}
		} catch (Exception e) {
			throw new ConfigException(e);
		}
	}

	public void recordMap(String fileName, int sheetNum, int templateId, Field langIdField, Field langField, int langIdOffset, int langOffset, Object object)
			throws IllegalArgumentException, IllegalAccessException {
		if (langField == null) {
			System.out.println("error");
		}

		Map<String, List<LangModel>> map1 = this.langMap.get(fileName);
		if (map1 == null) {
			map1 = new HashMap<String, List<LangModel>>();
			this.langMap.put(fileName, map1);
		}
		List<LangModel> list = map1.get(sheetNum + "");
		if (list == null) {
			list = new ArrayList<LangModel>();
			map1.put(sheetNum + "", list);
		}
		// 生成langId 为 templateId字符串+offse三位字符串
		String langIdOffsetStr = langIdOffset + "";
		if (langIdOffset < 10) {
			langIdOffsetStr = "00" + langIdOffset;
		} else if (langIdOffset < 100) {
			langIdOffsetStr = "0" + langIdOffset;
		}
		String langIdStr = templateId + "" + langIdOffsetStr;
		LangModel langModel = new LangModel();
		langModel.setLangId(langIdStr);
		langModel.setValue(langField.get(object) == null ? "" : langField.get(object).toString().trim());
		langModel.setLangValue("");
		list.add(langModel);

		keMap.put(fileName, sheetNum + "", langIdStr, langModel);

		StringBuilder sb = new StringBuilder();
		sb.append("fileName:" + fileName + ";");
		sb.append("sheetNum:" + sheetNum + ";");
		sb.append("templateId:" + templateId + ";");
		sb.append("langIdOffset:" + langIdOffset + ";");
		sb.append("langOffset:" + langOffset + ";");
		sb.append("langField:" + langField.get(object) + ";");

		System.out.println(sb);
	}

	private static class LangModelSorter implements Comparator<LangModel> {
		/**
		 * 商会排序，按经验值，即exp
		 */
		@Override
		public int compare(LangModel o1, LangModel o2) {
			return o1.getLangId().compareTo(o2.getLangId());
		}
	}

	public void createLangExcel() {
		// 读取原来多语言文件
		this.readLangExcel();
		// 覆盖多语言文件
		this.createExcel();
	}

	public void readLangExcel() {
		// TODO 先读取对应多语言文件
		for (Entry<String, Map<String, List<LangModel>>> entry : this.langMap.entrySet()) {
			String fileName = entry.getKey();
			String path = SYS_LANG_PATN + "lang_" + fileName;
			File file = new File(path);
			if (!file.exists()) {
				continue;
			}
			InputStream fout = null;
			try {
				fout = new FileInputStream(path);
				HSSFWorkbook wb = null;
				wb = new HSSFWorkbook(new POIFSFileSystem(fout));
				for (Entry<String, List<LangModel>> subEntry : entry.getValue().entrySet()) {
					String sheetName = subEntry.getKey();
					int index = wb.getSheetIndex(sheetName);
					if (index == -1) {
						continue;
					}
					HSSFSheet sheet = wb.getSheetAt(index);
					for (int i = 0; i <= sheet.getLastRowNum(); i++) {
						HSSFRow row = sheet.getRow(i);
						String id = PoiUtils.getStringValue(row.getCell(0));
						String langValue = PoiUtils.getStringValue(row.getCell(2));

						LangModel langModel = (LangModel) keMap.get(fileName, sheetName, id);
						if (langModel == null) {
							throw new ConfigException("langModel is null");
						}
						langModel.setLangValue(langValue == null ? "" : langValue);
					}
				}
			} catch (Exception e) {
				logger.error("Unknown Exception", e);
			} finally {
				if (fout != null) {
					try {
						fout.close();
					} catch (IOException e) {
						logger.error("IOException", e);
					}
				}
			}
		}

		System.out.println();

	}

	public void createExcel() {
		for (Entry<String, Map<String, List<LangModel>>> entry : this.langMap.entrySet()) {
			OutputStream fout = null;
			try {
				String fileName = entry.getKey();
				String path = SYS_LANG_PATN + "lang_" + fileName;
				HSSFWorkbook wb = new HSSFWorkbook();
				for (Entry<String, List<LangModel>> subEntry : entry.getValue().entrySet()) {
					String sheetName = subEntry.getKey();
					HSSFSheet sheet = wb.createSheet(sheetName);
					HSSFCellStyle cellStyle = wb.createCellStyle();
					cellStyle.setAlignment((short) 2);
					HSSFFont cellFont = wb.createFont();
					cellFont.setFontName("宋体");
					cellFont.setFontHeightInPoints((short) 12);
					cellStyle.setFont(cellFont);
					cellStyle.setAlignment((short) 0);
					sheet.setColumnWidth(1, 10000);
					sheet.setColumnWidth(2, 10000);

					List<LangModel> longModelList = subEntry.getValue();

					Collections.sort(longModelList, new LangModelSorter());

					for (int row = 0; row < longModelList.size(); row++) {
						LangModel langModel = longModelList.get(row);
						HSSFRow rowValue = sheet.createRow(row);
						HSSFCell id = rowValue.createCell(0);
						id.setCellStyle(cellStyle);
						id.setCellType(HSSFCell.CELL_TYPE_STRING);
						id.setCellValue(langModel.getLangId() + "");
						HSSFCell value = rowValue.createCell(1);
						value.setCellStyle(cellStyle);
						value.setCellType(HSSFCell.CELL_TYPE_STRING);
						value.setCellValue(langModel.getValue());

						HSSFCell langValue = rowValue.createCell(2);
						langValue.setCellStyle(cellStyle);
						langValue.setCellType(HSSFCell.CELL_TYPE_STRING);
						langValue.setCellValue(langModel.getLangValue());
					}
				}

				fout = new FileOutputStream(path);
				wb.write(fout);
				fout.flush();
			} catch (Exception e) {
				logger.error("Unknown Exception", e);
			} finally {
				if (fout != null) {
					try {
						fout.close();
					} catch (IOException e) {
						logger.error("IOException", e);
					}
				}
			}
		}
	}

	public void backRecordMap(String fileName, int sheetNum, int templateId, Field langIdField, Field langField, int langIdOffset, int langOffset, Object object)
			throws IllegalArgumentException, IllegalAccessException {

		String name = langField.getName();
		StringBuilder mNameBuilder = new StringBuilder();
		mNameBuilder.append("set");
		Class<?> fType = langField.getType();
		if ((fType == boolean.class || fType == Boolean.class) && name.startsWith("is")) {
			// boolean 值set方法不带is
			mNameBuilder.append(name.substring(2, 3).toUpperCase());
			mNameBuilder.append(name.substring(3));
		} else {
			mNameBuilder.append(name.substring(0, 1).toUpperCase());
			mNameBuilder.append(name.substring(1));
		}
		String methodName = mNameBuilder.toString();

		List<Method> methodList = new ArrayList<Method>();
		for (Class<?> clazz = object.getClass(); clazz != Object.class; clazz = clazz.getSuperclass()) {
			Method[] methods = clazz.getDeclaredMethods();
			for (Method method : methods) {
				methodList.add(method);

			}
		}

		Method[] methods = methodList.toArray(new Method[0]);
		Method.setAccessible(methods, true);

		Method setMethod = searchSetterMethod(methods, methodName, langField.getType());

		String langIdOffsetStr = langIdOffset + "";
		if (langIdOffset < 10) {
			langIdOffsetStr = "00" + langIdOffset;
		} else if (langIdOffset < 100) {
			langIdOffsetStr = "0" + langIdOffset;
		}

		LangModel langModel = (LangModel) keMap.get(fileName, sheetNum + "", langIdOffsetStr);

		if (setMethod == null) {
			System.out.println(methodName);
		}
		try {
			setMethod.invoke(object, langModel.getLangValue());
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	private static Method searchSetterMethod(Method[] methods, String name, Class<?> parameterType) {
		Method m = null;
		String internedName = name.intern();
		for (int i = 0; i < methods.length; i++) {
			m = methods[i];
			if (m.getName() == internedName && m.getParameterTypes().length == 1 && parameterType == m.getParameterTypes()[0])
				return m;
		}
		return null;
	}

	public static void main(String[] args) throws Exception {
		I18nExcelGenerator generator = new I18nExcelGenerator();

		ClassLoader classLoader = Thread.currentThread().getContextClassLoader();
		URL url = classLoader.getResource(I18nExcelGenerator.TEMPLATE_PATH);
		XorTemplateService templateService = new XorTemplateService(I18nExcelGenerator.path_resource, false);
		templateService.init(url);

		Map<Class<?>, Map<Integer, TemplateObject>> templateObjects = templateService.getAllClassTemplateMaps();
		for (Entry<Class<?>, Map<Integer, TemplateObject>> entry : templateObjects.entrySet()) {
			for (Entry<Integer, TemplateObject> subEntry : entry.getValue().entrySet()) {
				generator.doAssemble(subEntry.getValue(), entry.getKey(), subEntry.getKey(), subEntry.getValue().getSheetNum(), subEntry.getValue()
						.getExcelName());
			}
		}
		generator.createLangExcel();
		System.out.println();
	}
}
