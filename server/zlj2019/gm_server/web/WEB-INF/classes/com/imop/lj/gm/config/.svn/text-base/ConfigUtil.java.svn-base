package com.imop.lj.gm.config;

import java.io.IOException;
import java.io.InputStreamReader;
import java.io.Reader;
import java.net.URL;
import java.util.HashMap;
import java.util.Map;

import org.apache.commons.io.IOUtils;
import org.slf4j.Logger;

/**
 * 配置相关的工具类
 *
 *
 */
public class ConfigUtil {

	private static final Logger logger = org.slf4j.LoggerFactory.getLogger(ConfigUtil.class);

	/**
	 * 根据指定的配置类型<tt>configClass</tt>从<tt>configURL</tt>中加载配置
	 *
	 * @param <T>
	 * @param configClass
	 *            配置的类型
	 * @param configURL
	 *            配置文件的URL,文件内容是一个以JavaScript编写的配置脚本
	 * @return 从configURL加载的配置对象
	 * @exception RuntimeException
	 *                从configClass构造对象失败时抛出此异常
	 * @exception IllegalArgumentException
	 *                配置验证失败时抛出此异常
	 * @exception IllegalStateException
	 *                从configUrl中加载内容失败时抛出此异常
	 */
	@SuppressWarnings("unchecked")
	public static <T extends IConfig> T buildConfig(Object o, URL configURL) {
		if (o == null) {
			throw new IllegalArgumentException("configClass is null");
		}
		if (configURL == null) {
			throw new IllegalArgumentException("configURL is null");
		}
		if(logger.isInfoEnabled()){
			logger.info("Load config ["+o.getClass()+"] from ["+configURL+"]");
		}
		T _config = null;
		try {
			_config = (T) o;
		} catch (Exception e1) {
			throw new RuntimeException(e1);
		}
		IScriptEngine _jsEngine = new JSScriptManagerImpl("UTF-8");
		Map<String, Object> _bindings = new HashMap<String, Object>();
		_bindings.put("config", _config);
		Reader _r = null;
		String _scriptContent = null;
		try {
			_r = new InputStreamReader(configURL.openStream(), "UTF-8");
			_scriptContent = IOUtils.toString(_r);
		} catch (IOException e) {
			throw new IllegalStateException("Can't load config from url [" + configURL + "]");
		} finally {
			IOUtils.closeQuietly(_r); 
		}
//		_scriptContent ="config.isDebugMode = 1;";
		_jsEngine.runScript(_bindings, _scriptContent);
		_config.validate();
		return _config;

	}
}
