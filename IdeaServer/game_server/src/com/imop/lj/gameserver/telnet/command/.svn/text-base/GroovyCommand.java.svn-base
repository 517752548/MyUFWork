package com.imop.lj.gameserver.telnet.command;

import groovy.lang.Binding;
import groovy.lang.GroovyShell;

import java.util.Map;

import net.sf.json.JSONObject;

import org.apache.mina.core.session.IoSession;

public class GroovyCommand extends LoginedTelnetCommand {

	public void test() {

	}


	public static final String GLOBALS_PKG_NAME = "";
	public static final String RETURN_VARIABLE_NAME = "ret";

	private GroovyShell groovyShell;
	private Binding binding;

	public GroovyCommand() {
		super("groovy");
		binding = new Binding();
		ClassLoader classLoader = Thread.currentThread().getContextClassLoader();
		groovyShell = new GroovyShell(classLoader, binding);
	}

	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {

		String _param = getCommandParam(command);
		if (_param.length() == 0) {
			sendError(session, "No param");
			return;
		}

		JSONObject _json = JSONObject.fromObject(_param);

		if (_json.containsKey("cmdContent")) {
			String strCode= _json.getString("cmdContent");
			//处理命令
			String ret = execCode(strCode);
			System.out.println("groovy ret=" + ret);
			sendMessage(session, ret);
		}

	}

	public String execCode(String strCode) {
		String gs = GLOBALS_PKG_NAME + strCode;
		System.out.println("gs===" + gs);
		Object ret = groovyShell.evaluate(gs);
		return ret == null ? "" : ret.toString();
	}

}
