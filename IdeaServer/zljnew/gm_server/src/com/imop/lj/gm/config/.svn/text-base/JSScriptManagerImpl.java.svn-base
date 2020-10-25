package com.imop.lj.gm.config;

import java.io.File;
import java.io.IOException;
import java.util.List;
import java.util.Map;

import javax.script.Bindings;
import javax.script.ScriptEngine;
import javax.script.ScriptEngineFactory;
import javax.script.ScriptEngineManager;
import javax.script.ScriptException;
import javax.script.SimpleBindings;

import org.apache.commons.io.FileUtils;

/**
 * JS脚本执行管理器
 *
 *
 *
 */
public class JSScriptManagerImpl implements IScriptEngine {

	private final String charset;

	private final ScriptEngine engine;

	/**
	 * @param charset
	 *            脚本默认的字符编码
	 */
	public JSScriptManagerImpl(String charset) {
		this.charset = charset;
		ScriptEngineManager factory = new ScriptEngineManager();
		
		List<ScriptEngineFactory> factories = factory.getEngineFactories();
		for(int i=0;i<factories.size();i++){
			ScriptEngineFactory s = factories.get(i);
			System.out.println(s.getEngineName());
		}
		engine = factory.getEngineByName("JavaScript");
		System.out.println("script1:"+engine.getClass().getName());
	}

	/**
	 * @param charset
	 *            如果为空,则使用JSScriptMangerImpl的charset
	 * @exception RuntimeException
	 */
	@Override
	public Object runScript(Map<String, Object> binding, String scriptFile,
			String charset) {
		String content = null;
		try {
			Bindings _bindings = new SimpleBindings(binding);
			content = FileUtils.readFileToString(new File(scriptFile),
					charset != null ? charset : this.charset);
			return engine.eval(content, _bindings);
		} catch (IOException e) {
			throw new RuntimeException(e);
		} catch (ScriptException se) {
			throw new RuntimeException(se);
		}
	}

	/**
	 *
	 * @exception RuntimeException
	 */
	@Override
	public Object runScript(Map<String, Object> binding, String scriptContent) {
		try {
			if (binding == null || binding.isEmpty()) {
				return engine.eval(scriptContent);
			} else {
				Bindings _bindings = new SimpleBindings(binding);
				return engine.eval(scriptContent, _bindings);
			}
		} catch (ScriptException se) {
			throw new RuntimeException(se);
		}
	}

}
