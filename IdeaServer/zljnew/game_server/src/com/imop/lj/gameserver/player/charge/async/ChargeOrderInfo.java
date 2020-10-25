package com.imop.lj.gameserver.player.charge.async;

import net.sf.json.JSONObject;

import com.imop.lj.common.LogReasons.ChargeLogReason;
import com.imop.lj.common.LogReasons.MoneyLogReason;

public class ChargeOrderInfo {

	/** ID */
	private String id;
	/** 用户ID*/
	private long user_id;
	/**  */
	private String user_name;
	/** 扣除后用户账户余额*/
	private int balance;
	/**订单ID*/
	private String orderId;
	/**该笔兑换平台数量*/
	private double amount;
	/**币种类型*/
	private String currency;
	/** 套餐id */
	private String item_id;
	/**游戏币 */
	private String gamepoints;
	/** 充值兑换类型 ios， game； 直冲GAME, ios充值IOS */
	private String type;
	/**  设备型号  */
	private String device_type;
	/** 设备版本号  */
	private String device_version;
	/** 苹果终端号 */
	private String udid;
	/** 游戏大区id */
	private String areaid;
	/** 游戏服务器信息 */
	private String serverid;
	/** mac信息 */
	private String device_id;
	/** 游戏唯一code */
	private String game_code;
	/** 游戏唯一域名  */
	private String game_domain;
	/** 游戏服以为域名 */
	private String game_server_domain;
	/** 角色id */
	private String char_id;
	/** 角色名 */
	private String char_name;
	/** 添加时间 */
	private String add_time;
	/** 消耗时间 */
	private String expend_time;
	/** 延迟获取时间 */
	private String delay_time;
	/** 终端类型  */
	private String terminal;
	/** 备注信息  */
	private String remark;
	/** 渠道编号 */
	private String pay_channel;
	/** 子渠道编号  */
	private String sub_channel;
	/** 兑换类型（目前为expend或ios）*/
	private String chargeType;
	/**游戏中要增加对应的货币*/
	private int addBond;
	/**增加后以后剩余货币*/
	private int bondAfter;
	/**增加前以后剩余货币*/
	private int bondBefore;
	

	public ChargeOrderInfo(){

	}

	public ChargeOrderInfo(long user_id, int balance, double amount, String orderId, String currency, String chargeType, String pay_channel, String sub_channel) {
		this.user_id = user_id;
		this.balance = balance;
		this.amount = amount;
		this.orderId = orderId;
		this.currency = currency;
		this.chargeType = chargeType;
		this.pay_channel = pay_channel;
		this.sub_channel = sub_channel;
	}

	/** 用户ID*/
	public long getUser_id() {
		return user_id;
	}

	/** 用户ID*/
	public void setUser_id(long user_id) {
		this.user_id = user_id;
	}

	/** 扣除后用户账户余额*/
	public int getBalance() {
		return balance;
	}

	/** 扣除后用户账户余额*/
	public void setBalance(int balance) {
		this.balance = balance;
	}

	public double getAmount() {
		return amount;
	}

	/**该笔兑换平台数量，并转换成int型*/
//	public int getMMAmount() {
//		int mmCost = Math.round((float) this.amount);
//		if(mmCost <= 0){
//			return 0;
//		}
//		return mmCost;
//	}

	/**该笔兑换平台数量*/
	public void setAmount(double amount) {
		this.amount = amount;
	}

	/**游戏点数*/
	public String getGamepoints() {
		return gamepoints;
	}
	/**游戏点数*/
	public void setGamepoints(String gamepoints) {
		this.gamepoints = gamepoints;
	}

	/**订单ID*/
	public String getOrderId() {
		return orderId;
	}

	/**订单ID*/
	public void setOrderId(String orderId) {
		this.orderId = orderId;
	}

	/**币种类型*/
	public String getCurrency() {
		return currency;
	}

	/**币种类型*/
	public void setCurrency(String currency) {
		this.currency = currency;
	}

	/***消耗类型*/
	public String getChargeType() {
		return chargeType;
	}

	/***消耗类型*/
	public void setChargeType(String chargeType) {
		this.chargeType = chargeType;
	}

	/**渠道*/
	public String getPay_channel() {
		return pay_channel;
	}

	/**渠道*/
	public void setPay_channel(String pay_channel) {
		this.pay_channel = pay_channel;
	}

	/**子渠道*/
	public String getSub_channel() {
		return sub_channel;
	}

	/**子渠道*/
	public void setSub_channel(String sub_channel) {
		this.sub_channel = sub_channel;
	}

	/**增加后以后剩余货币*/
	public int getBondAfter() {
		return bondAfter;
	}

	/**增加后以后剩余货币*/
	public void setBondAfter(int bondAfter) {
		this.bondAfter = bondAfter;
	}

	/**增加前以后剩余货币*/
	public int getBondBefore() {
		return bondBefore;
	}

	/**增加前以后剩余货币*/
	public void setBondBefore(int bondBefore) {
		this.bondBefore = bondBefore;
	}

	/**游戏中要增加对应的货币*/
	public void setAddBond(int addBond) {
		this.addBond = addBond;
	}

	/**游戏中要增加对应的货币*/
	public int getAddBond() {
		return addBond;
	}

	/**游戏终端名称*/
	public String getTerminal() {
		return terminal;
	}

	/**游戏终端名称*/
	public void setTerminal(String terminal) {
		this.terminal = terminal;
	}

	public String getId() {
		return id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public String getUser_name() {
		return user_name;
	}

	public void setUser_name(String user_name) {
		this.user_name = user_name;
	}

	public String getItem_id() {
		return item_id;
	}

	public void setItem_id(String item_id) {
		this.item_id = item_id;
	}

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public String getDevice_type() {
		return device_type;
	}

	public void setDevice_type(String device_type) {
		this.device_type = device_type;
	}

	public String getDevice_version() {
		return device_version;
	}

	public void setDevice_version(String device_version) {
		this.device_version = device_version;
	}

	public String getUdid() {
		return udid;
	}

	public void setUdid(String udid) {
		this.udid = udid;
	}

	public String getAreaid() {
		return areaid;
	}

	public void setAreaid(String areaid) {
		this.areaid = areaid;
	}

	public String getServerid() {
		return serverid;
	}

	public void setServerid(String serverid) {
		this.serverid = serverid;
	}

	public String getDevice_id() {
		return device_id;
	}

	public void setDevice_id(String device_id) {
		this.device_id = device_id;
	}

	public String getGame_code() {
		return game_code;
	}

	public void setGame_code(String game_code) {
		this.game_code = game_code;
	}

	public String getGame_domain() {
		return game_domain;
	}

	public void setGame_domain(String game_domain) {
		this.game_domain = game_domain;
	}

	public String getGame_server_domain() {
		return game_server_domain;
	}

	public void setGame_server_domain(String game_server_domain) {
		this.game_server_domain = game_server_domain;
	}

	public String getChar_id() {
		return char_id;
	}

	public void setChar_id(String char_id) {
		this.char_id = char_id;
	}

	public String getChar_name() {
		return char_name;
	}

	public void setChar_name(String char_name) {
		this.char_name = char_name;
	}

	public String getAdd_time() {
		return add_time;
	}

	public void setAdd_time(String add_time) {
		this.add_time = add_time;
	}

	public String getExpend_time() {
		return expend_time;
	}

	public void setExpend_time(String expend_time) {
		this.expend_time = expend_time;
	}

	public String getDelay_time() {
		return delay_time;
	}

	public void setDelay_time(String delay_time) {
		this.delay_time = delay_time;
	}

	public String getRemark() {
		return remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}

	/**
	 * 只对直冲有效
	 * @return
	 */
	public MoneyLogReason getMoneyLogReason(){
		if("web".equalsIgnoreCase(this.terminal)){
			return MoneyLogReason.PC_RECHARGE;
		}else if("android".equalsIgnoreCase(this.terminal)){
			return MoneyLogReason.ANDROID_RECHARGE;
		}else if("ios".equalsIgnoreCase(this.terminal)){
			return MoneyLogReason.IOS_RECHARGE;
		}else{
			return MoneyLogReason.OTHER_RECHARGE;
		}
	}

	/**
	 * 只对直冲有效
	 * @return
	 */
	public ChargeLogReason getChargeLogReason(){
		if("web".equalsIgnoreCase(this.terminal)){
			return ChargeLogReason.PC_RECHARGE_SUCCESS;
		}else if("android".equalsIgnoreCase(this.terminal)){
			return ChargeLogReason.ANDROID_RECHARGE_SUCCESS;
		}else if("ios".equalsIgnoreCase(this.terminal)){
			return ChargeLogReason.IOS_RECHARGE_SUCCESS;
		}else{
			return ChargeLogReason.OTHER_RECHARGE_SUCCESS;
		}
	}

	public String getChannel(){
		String channel = this.pay_channel;
		if(this.sub_channel != null && !"".equalsIgnoreCase(this.sub_channel)){
			channel = channel + "/" + this.sub_channel;
		}
		return channel;
	}

	@Override
	public String toString() {
		JSONObject json = new JSONObject();
		json.put("user_id", user_id);
		json.put("balance", balance);
		json.put("amount", amount);
		json.put("orderId", orderId == null ? "":orderId);
		json.put("currency", currency == null ? "":currency);
		json.put("chargeType", chargeType == null ? "":chargeType);
		json.put("pay_channel", pay_channel == null ? "":pay_channel);
		json.put("sub_channel", sub_channel == null ? "":sub_channel);
		json.put("terminal", terminal == null ? "":terminal);
//		json.put("addBond", addBond);
//		json.put("bondAfter", bondAfter);
//		json.put("bondBefore", bondBefore);
		return json.toString();
	}

//	public static void main(String[] args){
//		JSONObject json = new JSONObject();
//		json.put("user_id", null);
//		System.out.println(json.toString());
//	}
}
