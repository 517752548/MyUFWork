package com.renren.games.api.runable;

import net.sf.json.JSONObject;

import com.renren.games.api.core.Globals;
import com.renren.games.api.core.Loggers;
import com.renren.games.api.db.model.QQTaskMarketEntity;
import com.renren.games.api.db.model.QQUserInfoEntity;
import com.renren.games.api.db.po.QQTaskMarket;
import com.renren.games.api.util.CommonUtil;
import com.renren.games.api.util.JsonUtils;

public class SaveQQUserInfoRunable extends ApiCallable {

	private String openid;

	private JSONObject getInfoJo;

	private String uuid;

	public SaveQQUserInfoRunable(String openid, JSONObject getInfoJo, String uuid) {
		this.openid = openid;
		this.getInfoJo = getInfoJo;
		this.uuid = uuid;
	}

	@Override
	public String execute() {
		String result = "";
		try {
			long now = System.currentTimeMillis();
			QQUserInfoEntity userInfoEntity = Globals.getDaoService().getQqUserInfoDao().get(openid);
			if (userInfoEntity != null) {
				userInfoEntity.setLastLoginDate(now);

				JSONObject jo = JSONObject.fromObject(getInfoJo.toString());
				String nickName = JsonUtils.getString(jo, "nickname");
				String tempNick = CommonUtil.deleteVaildWord(nickName);
				jo.put("nickname", tempNick);

				userInfoEntity.setParams(jo.toString());

				// 判断锁定时间
				if (userInfoEntity.getLocked() != 0) {
					long lockEndTime = userInfoEntity.getLockEndTime();
					if (lockEndTime < now) {
						userInfoEntity.setLocked(0);
						userInfoEntity.setLockEndTime(0);
						userInfoEntity.setLockReason("");
					}
				}

				// 判断禁言时间
				if (userInfoEntity.getForbidTalked() != 0) {
					long forbidTalkTime = userInfoEntity.getForbidTalkTime();
					if (forbidTalkTime < now) {
						userInfoEntity.setForbidTalked(0);
						userInfoEntity.setForbidTalkTime(0);
						userInfoEntity.setForbidTalkReason("");
					}
				}
			} else {
				userInfoEntity = new QQUserInfoEntity();
				userInfoEntity.setId(openid);
				userInfoEntity.setAppid(Globals.getQqConfig().getAppid());
				userInfoEntity.setLastLoginDate(now);
				userInfoEntity.setCreateDate(now);

				JSONObject jo = JSONObject.fromObject(getInfoJo.toString());
				String nickName = JsonUtils.getString(jo, "nickname");
				String tempNick = CommonUtil.deleteVaildWord(nickName);
				jo.put("nickname", tempNick);

				userInfoEntity.setParams(jo.toString());
			}
			Globals.getDaoService().getQqUserInfoDao().saveOrUpdate(userInfoEntity);

			String marketId = Globals.getQqConfig().getAppid() + "_" + openid;
			
			QQTaskMarket taskMarket = Globals.getQqCacheService().getQQTaskMarket(marketId);
			
			if (taskMarket != null) {
				getInfoJo.put("markettask", 1);
				getInfoJo.put("contractid", taskMarket.getContractid());
			}else{
				QQTaskMarketEntity entity = Globals.getDaoService().getQqTaskMarketDao().get(marketId);
				if (entity != null) {
					getInfoJo.put("markettask", 1);
					getInfoJo.put("contractid", entity.getContractid());
				}
			}

			// 如果用户是锁定状态
			if (userInfoEntity.getLocked() != 0) {
				getInfoJo.put("locked", userInfoEntity.getLocked());
				getInfoJo.put("lockendtime", userInfoEntity.getLockEndTime());
				getInfoJo.put("lockreason", userInfoEntity.getLockReason());
			}

			// 如果用户是禁言状态
			if (userInfoEntity.getForbidTalked() != 0) {
				getInfoJo.put("forbidtalked", userInfoEntity.getLocked());
				getInfoJo.put("forbidtalktime", userInfoEntity.getLockEndTime());
				getInfoJo.put("forbidtalkreason", userInfoEntity.getLockReason());
			}
			getInfoJo.put("openid", openid);
		} catch (Exception e) {
			Loggers.loginLogger.error(uuid + "[system error]Exception ", e);
		}

		result = getInfoJo.toString();

		return result;
	}
}
