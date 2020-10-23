package com.imop.lj.tools.excel;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

import org.jdom.Element;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.exception.ConfigException;
import com.imop.lj.core.encrypt.XorDecryptedInputStream;
import com.imop.lj.core.template.TemplateConfig;
import com.imop.lj.core.util.JdomUtils;
import com.imop.lj.core.util.StringUtils;

public class ExcelXorBackTools {

	private String resourceFolder;

	private List<TemplateConfig> templateConfigs;

	private static final String path_resource = "./resources/scripts/";

	private static final String CONFIG_DIR = "excel/";

	private static final String TEMPLATE_PATH = CONFIG_DIR + "templates.xml";

	/** 相对路径 */
	private static final String SYS_LANG_PATN = "./resources/or_scripts/";

	public ExcelXorBackTools(String resourceFolder) {
		this.resourceFolder = resourceFolder;
	}

	public void init(URL cfgPath) {
		loadConfig(cfgPath);
		InputStream is = null;
		BufferedInputStream in = null;

		FileOutputStream os = null;
		BufferedOutputStream out = null;
		String fileName = null;
		for (TemplateConfig cfg : templateConfigs) {
			Loggers.templateLogger.info(cfg.toString());
			try {
				fileName = cfg.getFileName();
				if (fileName == null) {
					continue;
				}
				Loggers.templateLogger.info("loading template " + fileName);
				String xlsPath = resourceFolder + File.separator + cfg.getFileName();
				String targetFileName = SYS_LANG_PATN + File.separator + cfg.getFileName();

				is = new XorDecryptedInputStream(xlsPath);
				in = new BufferedInputStream(is);
				os = new FileOutputStream(targetFileName);
				out = new BufferedOutputStream(os);

				byte[] b = new byte[1024*5];
				int len;
				while((len = in.read(b)) != -1){
					out.write(b, 0, len);
				}
				out.flush();
				is.close();
				in.close();
				os.close();
				out.close();
			} catch (Exception e) {
				e.printStackTrace();
				throw new ConfigException(
						"Errors occurs while parsing xls file:" + fileName, e);
			} finally {
				if (is != null) {
					try {
						is.close();
						in.close();
						os.close();
						out.close();
					} catch (IOException e) {
						e.printStackTrace();
					}
				}
			}
		}
	}

	private void loadConfig(URL cfgPath) {
		Element root = JdomUtils.getRootElemet(cfgPath);
		templateConfigs = new ArrayList<TemplateConfig>();
		List<Element> fileElements = root.getChildren();
		for (Element fileElement : fileElements) {
			String fileName = fileElement.getAttributeValue("name");
			String parserClassName = fileElement.getAttributeValue("parser");
			List<Element> sheetElements = fileElement.getChildren();
			Class<?>[] fileSheetClasses = new Class<?>[sheetElements.size()];
			for (int i = 0; i < sheetElements.size(); i++) {
				Element sheet = sheetElements.get(i);
				String className = sheet.getAttributeValue("class");
				if (StringUtils.isEmpty(className)) {
					fileSheetClasses[i] = null;
					continue;
				}
				try {
					Class<?> clazz = Class.forName(className);
					fileSheetClasses[i] = clazz;
				} catch (ClassNotFoundException e) {
					Loggers.templateLogger.error("", e);
					throw new ConfigException(e);
				}
			}
			TemplateConfig templateConfig = new TemplateConfig(fileName,
					fileSheetClasses);
			if (parserClassName != null
					&& (parserClassName = parserClassName.trim()).length() > 0) {
				templateConfig.setParserClassName(parserClassName);
			}
			templateConfigs.add(templateConfig);
		}
	}

	public static void main(String[] args) throws Exception {
		ExcelXorBackTools generator = new ExcelXorBackTools(ExcelXorBackTools.path_resource);

		ClassLoader classLoader = Thread.currentThread().getContextClassLoader();
		URL url = classLoader.getResource(ExcelXorBackTools.TEMPLATE_PATH);
		generator.init(url);

		System.out.println();
	}
}
