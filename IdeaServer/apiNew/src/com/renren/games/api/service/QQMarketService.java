package com.renren.games.api.service;

import com.renren.games.api.core.Globals;

/**
 * 集市任务
 * 
 * @author yuanbo.gao
 * 
 */
public class QQMarketService {
	public static final String cmd_check = "check";
	public static final String cmd_check_award = "check_award";
	public static final String cmd_award = "award";

	public QQMarketService() {

	}

	/**
	 * 第一、四步只有NOT_FINISHED、CREATE_AWARD和GET_AWARD三个状态，初始化为NOT_FINISHED状态，
	 * 如果任务集市没有发送此步骤cmd，则一直是NOT_FINISHED状态，
	 * 任务集市平台会发送cmd为award，直接改变状态CREATE_AWARD。
	 * 
	 * 第一步
	 * 
	 * @param appid
	 * @param openid
	 * @param cmd
	 * @param payitem
	 * @param contractid
	 * @param billno
	 * @return
	 */
	public String step(int step,String appid, String openid, String cmd, String payitem, String contractid, String billno, String uuid) {
		String result = Globals.getDaoService().getTransactionHelper().modifyQQMarketStatus(openid, appid, step, cmd, contractid, billno, payitem,uuid);
		return result;
	}
	
	/**
	 * 获得集市奖励
	 * 
	 * @param appid
	 * @param openid
	 * @param uuid
	 * @return
	 */
	public String getMarketAward(String appid, String openid,String uuid){
		String result = Globals.getDaoService().getTransactionHelper().getQQMarketAward(openid, appid,  uuid);
		return result;
	}
	
	/**
	 * 
	 * 修改第2、3步骤任务状态
	 * 
	 * @param appid
	 * @param openid
	 * @param uuid
	 * @param step
	 * @return
	 */
	public String finishQQMarketTask(String appid, String openid,String uuid,int step){
		String result = Globals.getDaoService().getTransactionHelper().finishQQMarketTask(openid, appid, step, uuid);
		return result;
	}
}


















