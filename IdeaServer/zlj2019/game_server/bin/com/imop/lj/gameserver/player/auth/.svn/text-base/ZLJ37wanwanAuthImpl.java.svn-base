package com.imop.lj.gameserver.player.auth;

import java.text.MessageFormat;

import net.sf.json.JSONObject;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.WallowConstants;
import com.imop.lj.core.i18n.SysLangService;
import com.imop.lj.core.util.HttpUtil;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.core.util.MD5Util;
import com.imop.lj.db.dao.UserInfoDao;
import com.imop.lj.db.model.UserInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.async.PlayerLocalHelper;
import com.imop.platform.local.response.ChannelUserLoginResponse;


public class ZLJ37wanwanAuthImpl implements UserAuth {
	
	/**
	 * 渠道id
	 */
	private String channelCode;
	/**
	 * F值
	 */
	private String fValue;
	
	public ZLJ37wanwanAuthImpl(String channelCode,String fValue) {
		this.channelCode = channelCode;
		this.fValue = fValue;
	}

	/**
	 * CGPlayerLogin协议使用
	 * 
	 * @param userName 对应渠道channelUserId
	 * @param ip 登陆ip
	 * 
	 */
	@Override
	public AuthResult auth(Player player, String userName, String password, String ip,String source) {
		return zlj37wanwanAuthByOtherPlatform(player,ip, userName, source);
	}

	/**
	 * CGPlayerCookieLogin
	 * 
	 * @param cookieValue 对应渠道t
	 * @param ip 登陆ip
	 * 
	 */
	@Override
	public AuthResult auth(Player player,String cookieValue, String ip) {
		return zlj37wanwanAuthByOtherPlatform(player,ip, cookieValue, player.getSource());
	}
	
	protected AuthResult zlj37wanwanAuthByOtherPlatform(Player player,String ip, String cookieValue , String source){
		AuthResult result = new AuthResult();
		if (!Globals.getServerConfig().isTurnOnLocalInterface()) {
			result.success = false;
			result.message = Globals.getLangService().readSysLang(LangConstants.LOCAL_TURN_OFF);
			return result;
		}
		
		try{
			String ticket=cookieValue;
			long now = Globals.getTimeService().now();
			String timestamp = now / 1000 + "";
//			String gamecode = Globals.getConfig().getGameId();
			String gamecode = "zlj";
			String signContent = gamecode + player.getChannelName() + Globals.getConfig().getServerId() + ticket + timestamp + Globals.getConfig().getZlj37wanwanConfig().getLocalkey();
			String sign = MD5Util.createMD5String(signContent);
			Loggers.loginLogger.info("[" + sign + "][zlj37wanwanAuthByOtherPlatform]signContent:" + signContent);
			 
			String domain = Globals.getConfig().getZlj37wanwanConfig().getUrl();
			String url = "{0}?gamecode={1}&channelname={2}&serverid={3}&ticket={4}&timestamp={5}&sign={6}";
			
			String createUrl = MessageFormat.format(url,domain, gamecode, player.getChannelName(), Globals.getConfig().getServerId(), ticket,timestamp,sign);
			Loggers.loginLogger.info("[" + sign + "][zlj37wanwanAuthByOtherPlatform]createUrl:" + createUrl);
			
			String responsContent = HttpUtil.getUrl(createUrl);
			Loggers.loginLogger.info("[" + sign + "][zlj37wanwanAuthByOtherPlatform]responsContent:" + responsContent);
			
			JSONObject obj = JSONObject.fromObject(responsContent);
			if (!obj.containsKey("success")) {
				result.success = false;
				result.message = getErrorInfo(LangConstants.LOCAL_LOGIN_PASS_ERR);
				return result;
			}
			
			
			String resultData = JsonUtils.getString(obj, "data");
			JSONObject jsUserInfo = JSONObject.fromObject(resultData);
			
			String channelUserId = JsonUtils.getString(jsUserInfo, "userId");
			
			int fcm = JsonUtils.getInt(jsUserInfo, "fcm");
		
			ChannelUserLoginResponse response = null;
			if(null != fValue && !"".equalsIgnoreCase(fValue)){
				response = Globals.getSynLocalService().channelUserLogin(ip, channelCode, channelUserId, fValue,PlayerLocalHelper.createGameLoginReportLoginIn(player));
			}else{
				response = Globals.getSynLocalService().channelUserLogin(ip, channelCode, channelUserId);
			}
			
			if (response.isSuccess()) {
				Loggers.loginLogger.info("GS#LocalUserAuthImpl.auth 1 :" 
						+ "UserId:" + response.getUserid() + ";"
						+ "UserName:"+ response.getUsername() + ";"
						+ "ip:"+ ip + ";"
						);
				String passportId = response.getUserid();
				boolean isWallow = (fcm == 1 ? true : false);
				UserInfo userInfo = getUserInfoByPassportId(passportId,
						response.getUsername(), ip, isWallow,source);
				result.success = true;
				result.userInfo = userInfo;
				result.userInfo.setCookieValue(response.getCookie());
				
				result.localAccOnlineTime = Globals.getSynLocalService().queryOnlineTime(passportId);
				
			} else {
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
		UserInfoDao userInfoDao = Globals.getDaoService().getUserInfoDao();
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
				userInfoDao.save(userInfo);
			}
			userInfo.setWallowFlag(wallowFlag);
			return userInfo;
		} catch (Exception e) {
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
		SysLangService langService = Globals.getLangService().getSysLangSerivce();
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
	public AuthResult quickAuth(String ip, String udid, String fValue, String source) {
		throw new UnsupportedOperationException();
	}

	@Override
	public AuthResult auth(Player player, String token, String pid, long rid) {
		throw new UnsupportedOperationException();
	}
}
