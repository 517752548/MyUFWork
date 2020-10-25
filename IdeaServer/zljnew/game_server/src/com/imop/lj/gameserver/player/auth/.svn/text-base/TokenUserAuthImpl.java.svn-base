package com.imop.lj.gameserver.player.auth;

import java.util.List;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.i18n.SysLangService;
import com.imop.lj.core.util.Assert;
import com.imop.lj.db.dao.UserInfoDao;
import com.imop.lj.db.model.HumanEntity;
import com.imop.lj.db.model.UserInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;


/**
 * 使用token进行用户登录校验
 *
 *
 */
public class TokenUserAuthImpl implements UserAuth {

	private UserInfoDao userInfoDao;

	private SysLangService langService;


	public TokenUserAuthImpl(UserInfoDao userInfoDao, SysLangService langService) {
		Assert.notNull(userInfoDao);
		Assert.notNull(langService);
		this.userInfoDao = userInfoDao;
		this.langService = langService;
	}
	
	@Override
	public AuthResult auth(Player player, String token, String pid, long rid) {
		AuthResult result = new AuthResult();
		try{
			
			Loggers.loginLogger.info("GS#TokenUserAuthImpl.auth aa :"
					+ "token:"+ token + ";"
					+ "pid:"+ pid + ";"
					+ "rid:" + rid + ";"
					+ "source:"+ player.getSource() + ";"
					);

			int failFlag = 0;
			
			//验证token是否正确
			boolean isSuccess = false;
			UserInfo userInfo = userInfoDao.get(pid);
			if (null != userInfo) {
				//验证roleId
				List<HumanEntity> humanList = Globals.getDaoService().getHumanDao().queryHumanByUUID(rid);
				if (humanList != null && humanList.size() > 0) {
					HumanEntity human = humanList.get(0);
					//passportId和roleId是否匹配
					if (human.getPassportId().equalsIgnoreCase(pid)) {
						//验证token
						String humanToken = Globals.genToken(human.getPassportId(), human.getId(), 
								human.getTokenParam1(), human.getTokenParam2());
						if (!humanToken.equals("") && 
								humanToken.equalsIgnoreCase(token)) {
							isSuccess = true;
						} else {
							//记录错误日志，token验证失败
							Loggers.loginLogger.warn("GS#TokenUserAuthImpl.auth ac :"
									+ "token:"+ token + ";"
									+ "pid:"+ pid + ";"
									+ "rid:" + rid + ";"
									+ "source:"+ player.getSource() + ";"
									+ ";humanToken=" + humanToken
									);
							failFlag = 4;
						}
					} else {
						failFlag = 3;
					}
				} else {
					failFlag = 2;
				}
			} else {
				failFlag = 1;
			}
			
			if (isSuccess) {
				result.success = true;
				result.userInfo = userInfo;
			} else {
				result.success = false;
				result.message = getErrorInfo();
				
				//记录错误日志，token验证失败
				Loggers.loginLogger.warn("GS#TokenUserAuthImpl.auth ab :"
						+ "token:"+ token + ";"
						+ "pid:"+ pid + ";"
						+ "rid:" + rid + ";"
						+ "source:"+ player.getSource() + ";"
						+ ";token valid failed!failFlag=" + failFlag
						);
			}
		}catch(Exception e){
			e.printStackTrace();
			Loggers.loginLogger.error(e.getMessage());
			result.success = false;
			result.message = getErrorInfo();
		}

		return result;
	}

	private String getErrorInfo() {
		return langService.read(LangConstants.LOCAL_LOGIN_TOKEN_AUTH_FAIL);
	}

	@Override
	public AuthResult quickAuth(String ip,String udid, String fValue, String source) {
		throw new UnsupportedOperationException();
		
//		AuthResult result = new AuthResult();
//		if (!Globals.getServerConfig().isTurnOnLocalInterface()) {
//			result.success = false;
//			result.message = Globals.getLangService().readSysLang(LangConstants.LOCAL_TURN_OFF);
//			return result;
//		}
//		// 请求local接口
//		QuickLoginResponse response = Globals.getSynLocalService().iosQuickLogin(ip, udid, fValue);
//
//		if (response.isSuccess()) {
//			Loggers.loginLogger.info("GS#LocalUserAuthImpl.quickAuth 1 :"
//					+ "UserId:" + response.getUserid() + ";"
//					+ "UserName:"+ response.getUsername() + ";"
//					+ "ip:"+ ip + ";"
//					+ "isWallow:" + response.isWallow() + ";"
//					+ "isInfofull:" + response.isInfofull() + ";"
//					+ "source:"+ source + ";"
//					);
//			String passportId = response.getUserid() + "";
//			UserInfo userInfo = getUserInfoByPassportId(passportId,
//					response.getUsername(), ip, response.isWallow(),source);
//			result.success = true;
//			result.userInfo = userInfo;
//			result.localAccOnlineTime = Globals.getSynLocalService().queryOnlineTime(passportId);
//			//XXX 标记用户时quick登录，quick登录用户不做防沉迷处理
////			result.userInfo.setQuickLoginAccount(true);
//			//XXX 是否使用的是快速登录接口
////			result.userInfo.setQuickLogin(true);
//
//		} else {
//			result.success = false;
//			result.message = getErrorInfo(response.getErrorCode());
//		}
//		return result;
	}

	@Override
	public AuthResult auth(Player player, String userName, String password, String ip,String source) {
		throw new UnsupportedOperationException();
//		return auth(player, userName, password, ip, LoginType.ReturnCookie,source);
	}

	@Override
	public AuthResult auth(Player player, String cookieValue, String ip) {
		throw new UnsupportedOperationException();
//		return auth(player, cookieValue, "", ip, LoginType.UserCookieLogin,"web");
	}

}
