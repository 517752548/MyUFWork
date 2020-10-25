/**
 *
 */
package com.imop.lj.gameserver.startup;

import java.io.File;
import java.io.IOException;

import org.apache.commons.io.FileUtils;

import com.imop.lj.gameserver.common.config.GameServerConfig;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.check.BaseVersionCheck;
import com.imop.lj.core.util.ServerVersion;

/**
 * Game Server服务器版本检测
 *
  *
 *
 */
public class GameServerVersionCheck extends BaseVersionCheck<GameServerConfig> {

	public GameServerVersionCheck(GameServerConfig config) {
		super(config, Loggers.gameLogger);
	}

	/*
	 * (non-Javadoc)
	 *
	 * @see com.mop.lzr.worldserver.service.check.ICheck#check()
	 */
	@Override
	public boolean check() {
		//XXX 去掉签名验证
		if(!config.getIsDebug()){
			return true;
		}
		
		if(config.getIsDebug()){
			return true;
		}
		if (!super.check()) {
			return false;
		}
		final String _serverVersion = ServerVersion.getServerVersion();
		boolean _match = true;
		do {
			String _resourceVersion = null;
			try {
				_resourceVersion = FileUtils.readFileToString(new File(config
						.getBaseResourceDir()
						+ File.separator + "version"));
			} catch (IOException e) {
				logger.error("#GS.WorldServerVersionCheck.check", e);
			}
			if (_resourceVersion == null) {
				_match = false;
				break;
			}
			_resourceVersion = _resourceVersion.trim();
			// 检查资源的版本号
			_match = _resourceVersion.equals(config.getResourceVersion());
			logVersionCheck("resourceVersoin", _resourceVersion,
					"resourceConfigVersion", config.getResourceVersion(),
					_match);
			if (!_match) {
				break;
			}
			// 检查资源的版本号是否与主版本号一致
			_match = ServerVersion.isMainVersionMatch(_serverVersion,
					_resourceVersion);
			logVersionCheck("resourceVersoin", _resourceVersion,
					"serverVersion", _serverVersion, _match);
			if (!_match) {
				break;
			}
		} while (false);
		return _match;
	}
}
