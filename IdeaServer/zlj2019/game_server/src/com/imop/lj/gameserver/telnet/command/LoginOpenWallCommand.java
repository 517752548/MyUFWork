package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.gameserver.common.Globals;

/**
 * 设置登陆墙打开/关闭
 *
 * @author qianwp
 *
 */
public class LoginOpenWallCommand extends LoginedTelnetCommand {

	public LoginOpenWallCommand() {
		super("LoginWall");
	}

	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {
		String _param = "";
		if (params.get("enable") == null) {
			_param = "false";// 命令不带参数，则默认表示关闭登陆墙
		} else {
			_param = params.get("enable");
		}

		if (_param.trim().equals("true")) {
			Globals.getServerConfig().setLoginWallEnabled(true);
			Globals.getServerStatus().setLoginWallEnabled(true);
		} else if (_param.trim().equals("false")) {
			Globals.getServerConfig().setLoginWallEnabled(false);
			Globals.getServerStatus().setLoginWallEnabled(false);
		}



	}

}
