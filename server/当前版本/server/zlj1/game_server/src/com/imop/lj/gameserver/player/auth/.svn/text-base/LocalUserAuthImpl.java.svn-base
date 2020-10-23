package com.imop.lj.gameserver.player.auth;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.WallowConstants;
import com.imop.lj.core.i18n.SysLangService;
import com.imop.lj.core.util.Assert;
import com.imop.lj.db.dao.UserInfoDao;
import com.imop.lj.db.model.UserInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.async.PlayerLocalHelper;
import com.imop.platform.local.response.LoginResponse;
import com.imop.platform.local.response.QuickLoginResponse;
import com.imop.platform.local.type.LoginType;


/**
 * 使用Mop Local平台进行用户登录校验
 *
 *
 */
public class LocalUserAuthImpl implements UserAuth {

	private UserInfoDao userInfoDao;

	private SysLangService langService;


	public LocalUserAuthImpl(UserInfoDao userInfoDao, SysLangService langService) {
		Assert.notNull(userInfoDao);
		Assert.notNull(langService);
		this.userInfoDao = userInfoDao;
		this.langService = langService;
	}

	@Override
	public AuthResult auth(Player player, String userName, String password, String ip,String source) {
		return auth(player, userName, password, ip, LoginType.ReturnCookie,source);
	}

	@Override
	public AuthResult auth(Player player, String cookieValue, String ip) {
		return auth(player, cookieValue, "", ip, LoginType.UserCookieLogin,"web");
	}

	private AuthResult auth(Player player, String userName, String password, String ip, LoginType loginType,String source) {
		AuthResult result = new AuthResult();
		try{
			if (!Globals.getServerConfig().isTurnOnLocalInterface()) {
				result.success = false;
				result.message = Globals.getLangService().readSysLang(LangConstants.LOCAL_TURN_OFF);
				return result;
			}

			Loggers.loginLogger.info("GS#LocalUserAuthImpl.auth aa :"
					+ "UserName:"+ userName + ";"
					+ "ip:"+ ip + ";"
					+ "password:" + password + ";"
					+ "source:"+ source + ";"
					+ "loginType:"+ loginType + ";"
					);

			//cookie登录，password传channelName
			if (loginType == LoginType.UserCookieLogin) {
				password = player.getChannelName();
			}
			
			// 请求local接口
			LoginResponse response = Globals.getSynLocalService().validateUser(userName,
					password, ip, loginType, PlayerLocalHelper.createGameLoginReportLoginIn(player));

			Loggers.loginLogger.info("GS#LocalUserAuthImpl.auth bb :"
					+ "UserName:"+ userName + ";"
					+ "ip:"+ ip + ";"
					+ "password:" + password + ";"
					+ "source:"+ source + ";"
					+ "loginType:"+ loginType + ";"
					);
			if (response.isSuccess()) {
				Loggers.loginLogger.info("GS#LocalUserAuthImpl.auth 1 :"
						+ "UserId:" + response.getUserId() + ";"
						+ "UserName:"+ response.getUserName() + ";"
						+ "ip:"+ ip + ";"
						+ "isAntiIndulge:" + response.isAntiIndulge() + ";"
						+ "source:"+ source + ";"
						);
				String passportId = response.getUserId() + "";
				//TODO 映射表
//				long quickPassportId = quickPassportDao.getQuickPassportId(passportId);
//				long bandPassportId = -1;
//				boolean isQuickLoginAccount = false;
//				boolean isReadyBandQuickLogin = false;
//				if(quickPassportId != -1){
//					bandPassportId = passportId;
//					passportId = quickPassportId;
//					isQuickLoginAccount = true;
//					isReadyBandQuickLogin = true;
//				}
				UserInfo userInfo = getUserInfoByPassportId(passportId,
						response.getUserName(), ip, response.isAntiIndulge(),source);
				result.success = true;
				result.userInfo = userInfo;
				//XXX 标记用户时quick登录，quick登录用户不做防沉迷处理
//				result.userInfo.setQuickLoginAccount(isQuickLoginAccount);
//				result.userInfo.setReadyBandQuickLogin(isReadyBandQuickLogin);
//				result.userInfo.setBandPassportId(bandPassportId);

				if(loginType== LoginType.UserCookieLogin){
					result.userInfo.setCookieValue(userName);
				}else if(loginType== LoginType.ReturnCookie){
					result.userInfo.setCookieValue(response.getCookie());
				}else{
					result.userInfo.setCookieValue("");
				}

				result.localAccOnlineTime = Globals.getSynLocalService().queryOnlineTime(passportId);

			} else {
				Loggers.loginLogger.info("GS#LocalUserAuthImpl.auth 2 :"
						+ "UserId:" + response.getUserId() + ";"
						+ "UserName:"+ response.getUserName() + ";"
						+ "ip:"+ ip + ";"
						+ "isAntiIndulge:" + response.isAntiIndulge() + ";"
						+ "source:"+ source + ";"
						);
				result.success = false;
				result.message = getErrorInfo(response.getErrorCode());
			}
		}catch(Exception e){
			e.printStackTrace();
			result.success = false;
			result.message = getErrorInfo(-1);
		}


		return result;
	}

	private UserInfo getUserInfoByPassportId(String passportId, String name,
			String ip, boolean wallow,String source) {
		try {
			int wallowFlag = wallow ? WallowConstants.WALLOW_FLAG_ON
					: WallowConstants.WALLOW_FLAG_OFF;
			UserInfo userInfo = userInfoDao.get(passportId);
			if (userInfo == null) {
				userInfo = UserInfo.getDefaultUserInfo();
				userInfo.setId(passportId);
				userInfo.setName(name);
				userInfo.setLastLoginIp(ip);
				userInfo.setWallowFlag(wallowFlag);
				userInfo.setSource(source);
				
				//如果系统允许创建debug用户并且程序是debug版本，将新建的用户创建成debug用户
//				if(Globals.getConfig().isAccountRoleDebug() && (Globals.getConfig().getIsDebug())){
//				if(Globals.getConfig().isAccountRoleDebug()){
//					userInfo.setRole(SharedConstants.ACCOUNT_ROLE_DEBUG);
//				}
				
				userInfoDao.save(userInfo);
			}
			userInfo.setWallowFlag(wallowFlag);
			return userInfo;
		} catch (Exception e) {
			e.printStackTrace();
			Loggers.loginLogger.error("login.getUserInfoByPassportId exception!e=", e);
			return null;
		}
	}

	/**
	 * 解析平台返回的错误代码
	 *
	 * @param errorCode 平台返回的错误代码
	 * @return 解析出的错误信息
	 */
	private String getErrorInfo(int errorCode) {
		Integer _langKey = null;
		switch (errorCode) {
		case 1:
			_langKey = LangConstants.LOCAL_LOGIN_SIGN_AUTH_FAIL;
			break;
		case 2:
			_langKey = LangConstants.LOCAL_LOGIN_TIMESTAMP_EXPIRSE;
			break;
		case 3:
			_langKey = LangConstants.LOCAL_LOGIN_PARAM_FORMAT_ERROR;
			break;
		case 4:
			_langKey = LangConstants.LOCAL_LOGIN_PASS_ERR;
			break;
		case 5:
			_langKey = LangConstants.LOCAL_LOGIN_ACCOUNT_BLOCK;
			break;
		case 6:
			_langKey = LangConstants.LOCAL_LOGIN_PASS_PROTECT_ERR;
			break;
		case 7:
			_langKey = LangConstants.LOCAL_LOGIN_COOKIE_AUTH_FAIL;
			break;
		case 8:
			_langKey = LangConstants.LOCAL_LOGIN_TOKEN_AUTH_FAIL;
			break;
		case 9:
			_langKey = LangConstants.LOCAL_LOGIN_REGION_AUTH_FAIL;
			break;
		default:
			_langKey = LangConstants.LOGIN_UNKOWN_ERROR;
			break;
		}
		return langService.read(_langKey);
	}

	@Override
	public AuthResult quickAuth(String ip,String udid, String fValue, String source) {
		AuthResult result = new AuthResult();
		if (!Globals.getServerConfig().isTurnOnLocalInterface()) {
			result.success = false;
			result.message = Globals.getLangService().readSysLang(LangConstants.LOCAL_TURN_OFF);
			return result;
		}
		// 请求local接口
		QuickLoginResponse response = Globals.getSynLocalService().iosQuickLogin(ip, udid, fValue);

		if (response.isSuccess()) {
			Loggers.loginLogger.info("GS#LocalUserAuthImpl.quickAuth 1 :"
					+ "UserId:" + response.getUserid() + ";"
					+ "UserName:"+ response.getUsername() + ";"
					+ "ip:"+ ip + ";"
					+ "isWallow:" + response.isWallow() + ";"
					+ "isInfofull:" + response.isInfofull() + ";"
					+ "source:"+ source + ";"
					);
			String passportId = response.getUserid() + "";
			UserInfo userInfo = getUserInfoByPassportId(passportId,
					response.getUsername(), ip, response.isWallow(),source);
			result.success = true;
			result.userInfo = userInfo;
			result.localAccOnlineTime = Globals.getSynLocalService().queryOnlineTime(passportId);
			//XXX 标记用户时quick登录，quick登录用户不做防沉迷处理
//			result.userInfo.setQuickLoginAccount(true);
			//XXX 是否使用的是快速登录接口
//			result.userInfo.setQuickLogin(true);

		} else {
			result.success = false;
			result.message = getErrorInfo(response.getErrorCode());
		}
		return result;
	}

	@Override
	public AuthResult auth(Player player, String token, String pid, long rid) {
		throw new UnsupportedOperationException();
	}
}
