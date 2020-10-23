package com.imop.lj.gameserver.player.auth;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.db.dao.UserInfoDao;
import com.imop.lj.db.model.UserInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;

/**
 * 使用数据库进行的用户验证,用于开发测试阶段
 *
 *
 */
public class DBUserAuthImpl implements UserAuth {
	private final UserInfoDao userInfoDao;

	public DBUserAuthImpl(UserInfoDao userInfoDao) {
		if (userInfoDao == null) {
			throw new IllegalArgumentException(
					"The userInfoDao must not be null.");
		}
		this.userInfoDao = userInfoDao;
	}

	@Override
	public AuthResult auth(Player player, String userName, String password, String ip,String source) {
		AuthResult _result = new AuthResult();
		try {

			final UserInfo _userInfo = this.userInfoDao.getUserByName(userName,
					password);
			if (_userInfo != null) {
				_result.success = true;
				_result.userInfo = _userInfo;
			} else {
				_result.success = false;
				_result.message = Globals.getLangService().readSysLang(
						LangConstants.LOGIN_VALIDATE_ERROR);
			}
		} catch (Exception e) {
			Loggers.loginLogger
					.error(String
							.format("Login DBSServer Network break! User %s from %s cannot login!",
									userName, ip), e);
		}
		return _result;
	}

	@Override
	public AuthResult auth(Player player, String cookieValue, String ip) {
		throw new UnsupportedOperationException();
	}

	@Override
	public AuthResult quickAuth(String ip,String udid, String fValue, String source) {
		throw new UnsupportedOperationException();
	}

	@Override
	public AuthResult auth(Player player, String token, String pid, long rid) {
		throw new UnsupportedOperationException();
	}
}
