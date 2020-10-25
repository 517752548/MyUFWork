package com.renren.games.api.runable;

import com.renren.games.api.core.Globals;
import com.renren.games.api.core.Loggers;
import com.renren.games.api.core.config.ApiConfig;
import com.renren.games.api.db.model.QQOrderBasicEntity;

/**
 * 储存订单前信息
 * 
 * @author yuanbo.gao
 * 
 */
public class SaveQQOrderBasicRunable extends ApiCallable {

	private String openid;

	private String openkey;

	private String pf;

	private String pfkey;

	private String billToken;

	private String buyGoodsJo;

	private long charId;

	private String uuid;

	public SaveQQOrderBasicRunable(String openid, String openkey, String pf, String pfkey, String billToken, String buyGoodsJo, long charId,
			String uuid) {
		this.openid = openid;
		this.openkey = openkey;
		this.pf = pf;
		this.pfkey = pfkey;
		this.billToken = billToken;
		this.buyGoodsJo = buyGoodsJo;
		this.charId = charId;
		this.uuid = uuid;
	}

	@Override
	public String execute() {
		String result = "";
		try {
			QQOrderBasicEntity qqOrderBasicEntity = new QQOrderBasicEntity();
			qqOrderBasicEntity.setId(Globals.getQqPlatformService().createQQBillInfoKey(openid, billToken));
			qqOrderBasicEntity.setOpenid(openid);
			qqOrderBasicEntity.setOpenkey(openkey);
			qqOrderBasicEntity.setPf(pf);
			qqOrderBasicEntity.setPfkey(pfkey);
			qqOrderBasicEntity.setBillToken(billToken);
			qqOrderBasicEntity.setCreateDate(System.currentTimeMillis());
			qqOrderBasicEntity.setAppid(Globals.getQqConfig().getAppid());
			qqOrderBasicEntity.setCharId(charId);
			Globals.getDaoService().getQqOrderBasicDao().saveOrUpdate(qqOrderBasicEntity);
			result = this.buyGoodsJo.toString();
		} catch (Exception e) {
			Loggers.chargeLogger.error(uuid + "[system error]Exception", e);
			result = ApiConfig.getResponseInfo(9999, "[system error]");
		}
		return result;
	}

	@Override
	public String toString() {
		return "SaveQQOrderBasicRunable [openid=" + openid + ", openkey=" + openkey + ", pf=" + pf + ", pfkey=" + pfkey + ", billToken=" + billToken
				+ ", buyGoodsJo=" + buyGoodsJo + "]";
	}
}
