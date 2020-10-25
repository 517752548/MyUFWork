package com.imop.lj.gameserver.player.auth;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.WallowConstants;
import com.imop.lj.core.i18n.SysLangService;
import com.imop.lj.db.dao.UserInfoDao;
import com.imop.lj.db.model.UserInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;


public class QQAuthImpl implements UserAuth {
	
//	/**
//	 * 渠道id
//	 */
//	private String channelCode;
//	/**
//	 * F值
//	 */
//	private String fValue;
	
	public QQAuthImpl(String channelCode,String fValue) {
//		this.channelCode = channelCode;
//		this.fValue = fValue;
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
		String openid = "";//player.getQqDataManager().getOpenId();
		return qqAuthByOtherPlatform(player,ip, openid, source);
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
		return qqAuthByOtherPlatform(player,ip, cookieValue, player.getSource());
	}
	
	protected AuthResult qqAuthByOtherPlatform(Player player,String ip, String cookieValue , String source){
		AuthResult result = new AuthResult();
//		if (!Globals.isQQPlatform()) {
			result.success = false;
			result.message = Globals.getLangService().readSysLang(LangConstants.LOCAL_TURN_OFF);
			// 记录错误日志
			Loggers.loginLogger.error("#QQAuthImpl#auth#isQQPlatform is false!openid=" + cookieValue + ";source=" + source);
			return result;
//		}
		
//		try{
//			String openid = player.getQqDataManager().getOpenId();
//			String openkey = player.getQqDataManager().getOpenKey();
//			String seqid = player.getQqDataManager().getSeqId();
//			String pf = player.getQqDataManager().getPf();
//			String pfkey = player.getQqDataManager().getPfKey();
//			
//			// cookie中是openid，校验一下openid，其他参数简单校验
//			String openidCookie = cookieValue;
//			if (!openid.equals(openidCookie) || 
//					openid.equalsIgnoreCase("") || 
//					openkey.equalsIgnoreCase("") ||
//					seqid.equalsIgnoreCase("") ||
//					pf.equalsIgnoreCase("") ||
//					pfkey.equalsIgnoreCase("")) {
//				// 参数初步校验失败
//				result.success = false;
//				result.message = Globals.getLangService().readSysLang(LangConstants.LOCAL_LOGIN_PARAM_FORMAT_ERROR);
//				// 记录错误日志
//				Loggers.loginLogger.error("#QQAuthImpl#auth#source is invalide!openid=" + openid + ";source=" + source);
//				return result;
//			}
//			// 是否有邀请相关参数
//			boolean hasInviteParam = player.getQqDataManager().hasInviteParam();
//			
//			// 访问api验证
//			Map<String, String> params = Globals.getQQService().buildApiRequestCommonParam(player);
//			params.put(QQDef.QQ_API_PARAM_KEY_SEQID, seqid);
//			// 如果带有邀请参数，则传给api
//			if (hasInviteParam) {
//				params.put(QQDef.QQ_API_PARAM_KEY_IOPENID, player.getQqDataManager().getIopenid());
//				params.put(QQDef.QQ_API_PARAM_KEY_INVKEY, player.getQqDataManager().getInvkey());
//				params.put(QQDef.QQ_API_PARAM_KEY_ITIME, player.getQqDataManager().getItime());
//				// 打个日志
//				Loggers.loginLogger.info("#QQAuthImpl#auth#hasInviteParam.openid=" + openid + ";source=" + source + ";params=" + params);
//			}
//			
//			String retStr = Globals.getApiRequestHelper().api(Globals.getOtherplatformConstants().getQqAreaLoginUrl(), 
//					params, Globals.getOtherplatformConstants().getApiLocalkey());
//			JSONObject retJsonObj = JSONObject.fromObject(retStr);
//			if (null == retJsonObj || retJsonObj.isNullObject() || retJsonObj.isEmpty() || 
//					!retJsonObj.containsKey(QQDef.QQ_RET_KEY_RET)) {
//				// api参数解析失败
//				result.success = false;
//				result.message = Globals.getLangService().readSysLang(LangConstants.LOCAL_LOGIN_COOKIE_AUTH_FAIL);
//				// 记录错误日志
//				Loggers.loginLogger.error("#QQAuthImpl#auth#json is invalide!openid=" + openid + ";source=" + source + ";retStr=" + retStr);
//				return result;
//			}
//			//{"ret":0,"is_lost":0,"nickname":"Peter","gender":"男","country":"中国","province":"广东","city":"深圳","figureurl":"http://imgcache.qq.com/qzone_v4/client/userinfo_icon/1236153759.gif","is_yellow_vip":1,"is_yellow_year_vip":1,"yellow_vip_level":7,"is_yellow_high_vip":0}
//			int ret = retJsonObj.getInt(QQDef.QQ_RET_KEY_RET);
//			if (ret == QQDef.QQ_RET_OK_CODE) {// 成功
//				// 记录成功日志
//				Loggers.loginLogger.info("GS#QQAuthImpl.auth 1 :" 
//						+ "openid:" + openid + ";openkey:"+ openkey + ";seqid:" + seqid 
//						+ ";pf:" + pf + ";pfkey:" + pfkey + ";ip:"+ ip + ";retStr=" + retStr);
//				
//				String passportId = openid;//passportId就是openid
//				boolean isWallow = false;//qq暂时没有防沉迷
//				UserInfo userInfo = getUserInfoByPassportId(passportId,
//						passportId, ip, isWallow, source);
//				result.success = true;
//				result.userInfo = userInfo;
//				result.userInfo.setCookieValue(openid);
//				
//				// 设置玩家的qq相关数据
//				player.qqLoginRetExplain(retJsonObj);
//				
//				// 记录一个数据库的日志，主要是被邀请信息，方便查log
//				if (hasInviteParam) {
//					String beInvitedlogParam = player.getQqDataManager().getBeInviteLoginLog();
//					Globals.getLogService().sendBehaviorLog(null, BehaviorLogReason.QQ_BEINVITED_LOGIN, beInvitedlogParam, 
//							0, 0, 0, 0, 0);
//				}
//			} else {
//				result.success = false;
//				result.message = getErrorInfo(ret);
//				// 记录错误日志
//				Loggers.loginLogger.error("#QQAuthImpl#auth#json is invalide!openid=" + openid + ";source=" + source + ";retStr=" + retStr);
//			}
//		}catch(Exception e){
//			// 记录错误日志
//			Loggers.loginLogger.error("#QQAuthImpl#auth#Exception!openid=" + cookieValue + ";source=" + source, e);
//			e.printStackTrace();
//			result.success = false;
//			result.message = getErrorInfo(-1);
//		}
//		return result;
	}
	
	private UserInfo getUserInfoByPassportId(String passportId, String name,
			String ip, boolean wallow,String source) {
		UserInfoDao userInfoDao = Globals.getDaoService().getUserInfoDao();
		try {
			int wallowFlag = WallowConstants.WALLOW_FLAG_OFF;//qq暂时没有防沉迷
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
		// TODO 需要修改为qq的
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
