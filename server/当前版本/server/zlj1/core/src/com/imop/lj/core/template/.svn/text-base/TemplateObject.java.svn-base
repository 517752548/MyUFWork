package com.imop.lj.core.template;

import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.exception.ConfigException;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.annotation.ExcelRowBinding;


@ExcelRowBinding
public abstract class TemplateObject {

	public static int NULL_ID = 0;

	@ExcelCellBinding(offset = 0)
	protected int id;

	protected String sheetName;

	protected String excelName;
	
	protected TemplateService templateService;
	
	protected Logger templateLogger = Loggers.templateLogger;

	/**
	 * sheet对应id
	 */
	protected int sheetNum;

	public final int getId() {
		return id;
	}

	public final void setId(int id) {
		this.id = id;
	}

	/**
	 * <pre>
	 * 在{@link TemplateService}加载完所有的模板对象之后调用，主要用于检查各个模板
	 * 表配置是否正确，如果不正确，应抛出{@link ConfigException}类型的异常，并在异常
	 * 消息中记录详细的出错信息
	 * </pre>
	 * @throws TemplateConfigException TODO
	 */
	public abstract void check() throws TemplateConfigException;

	/**
	 * <pre>
	 * 在{@link TemplateService}加载完所有的模板对象之后调用，主要用于构建各个模板
	 * 对象之间的依赖关系
	 * </pre>
	 * @throws Exception
	 */
	public void patchUp() throws Exception {
	}

	/**
	 * 返回此模板的名字，可以写的更详细一点，哪个文件的那个页签
	 *
	 * @return
	 */
	public String getSheetName() {
		return this.sheetName;
	}

	/**
	 * 设置此模版所对应的 Excel 页签名称
	 *
	 * @param value
	 */
	public void setSheetName(String value) {
		this.sheetName = value;
	}

	/**
	 * 对应Excel标签序列
	 * @return
	 */
	public int getSheetNum() {
		return sheetNum;
	}

	/**
	 * 对应Excel标签序列
	 * @return
	 */
	public void setSheetNum(int sheetNum) {
		this.sheetNum = sheetNum;
	}

	/**
	 * 对应Excel文件名称
	 * @return
	 */
	public String getExcelName() {
		return excelName;
	}

	/**
	 * 对应Excel文件名称
	 * @return
	 */
	public void setExcelName(String excelName) {
		this.excelName = excelName;
	}

	public TemplateService getTemplateService() {
		return templateService;
	}

	public void setTemplateService(TemplateService templateService) {
		this.templateService = templateService;
	}
}
