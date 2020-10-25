package test;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.concurrent.Callable;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;

import net.sf.json.JSONObject;

import org.junit.Test;

import com.renren.games.api.core.config.ApiConfig;
import com.renren.games.api.util.CommonUtil;
import com.renren.games.api.util.JsonUtils;
import com.renren.games.api.util.MD5Util;
import com.renren.games.api.util.QQMarketUtil;
import com.renren.games.qqapi.ApiRequestHelper;

public class TestQQApi {

	private String domain = "http://127.0.0.1:8080/qqapi/";

	// 登录
	private String QQAreaLoginUrl = "api/qq/qqAreaLogin";

	// 充值前需要调用的接口
	private String QQBuyGoodsUrl = "api/qq/qqBuyGoods";
	
	// 服务器订单兑换接口
	private String QQRechargeUrl = "api/qq/qqRecharge";

	// 查询qq玩家vip情况
	private String QQIsVip = "api/qq/qqIsVip";

	// 恺英充值确认接口
	private String KaiYingChargeUrl = "api/qq/kaiYingCharge";
	
	// 发微博接口
	private String QQAddTUrl = "api/qq/qqAddT";
	
	
	private String QQGetInvkey = "api/qq/qqGetInvkey";
	
	private String QQIsLogin = "api/qq/qqIsLogin";
	
	private String QQMarket = "api/qq/qqMarket";
	
	private String QQGetMarketAward = "api/qq/qqGetMarketAward";
	
	private String QQFinishMarketTask = "api/qq/qqFinishMarketTask";
	
	private String QQGetPubacctBalance = "api/qq/qqGetPubacctBalance";
	
	private ApiRequestHelper helper = new ApiRequestHelper(domain);
	
	/**
	 * 请求订单
	 * 
	 * @throws Exception
	 */
	public void testQQRecharge()throws Exception {
		String localkey = "f9a7531a561645fdff1a01e152a46522";
		Map<String, String> params = new HashMap<String, String>();

		params.put("pf", "qzone");
		params.put("openid", "07230EA42BC5D8ACFAC5D6BB28F8D9EF");
		params.put("openkey", "0F1F126DBBA8B4DFB65F066B5DAF9B00");
		params.put("seqid", "9633381ef0aacb473bd858d0482942c1");
		params.put("charid", "1");
		
		System.out.println(helper.api(QQRechargeUrl, params, localkey));
	}
	
	/**
	 * 多线程请求订单
	 * 
	 * @throws Exception
	 */
	
	public void testAllQQRecharge()throws Exception {
		int openIdNum = 100;
		int requestNum = 20;
		
		String localkey = "f9a7531a561645fdff1a01e152a46522";
		
		
		List<Future<String>> futures = new ArrayList<Future<String>>(20);
		ExecutorService pool = Executors.newFixedThreadPool(100);
		for(int i = 0; i < openIdNum; i ++){
			for(int j = 0 ; j < requestNum;j++){
				Map<String, String> params = new HashMap<String, String>();

				params.put("pf", "qzone");
				params.put("openid", "07230EA42BC5D8ACFAC5D6BB28F8D9EF");
				params.put("openkey", "0F1F126DBBA8B4DFB65F066B5DAF9B00");
				params.put("seqid", "9633381ef0aacb473bd858d0482942c1");
				params.put("charid", i + "");
				RequestRunner call = new RequestRunner(QQRechargeUrl, params, localkey);
				futures.add(pool.submit(call));
			}
		}


		long begin = System.currentTimeMillis();
		Set<Integer> set = new HashSet<Integer>();
		while (true) {
			Thread.sleep(50);
			set.clear();
			for (int i = 0; i < futures.size(); i++) {
				Future<String> future = futures.get(i);
				if (!future.isDone()) {
					set.add(i);
				}
			}
			if (set.isEmpty()) {
				break;
			}
			long end = System.currentTimeMillis();
			System.out.println("[Executing] : " + (end - begin) + "ms.left:" + set.size());
		}
		long end1 = System.currentTimeMillis();
		System.out.println("[Execute Done] : " + (end1 - begin) + "ms.");
		int count = 0;
		for(int i = 0 ; i < futures.size(); i++){
			JSONObject loginJo = JSONObject.fromObject(futures.get(i).get());
			// 如果不含有"ret"值返回错误
			int loginRet = JsonUtils.getInt(loginJo, ApiConfig.QQ_RESPONSE_KEY_RET);
			if (loginRet == 0) {
				count ++ ;
				System.out.println(futures.get(i).get());
			}
		}
		System.out.println(count);
	}
	
	public void testQQIsLogin() throws Exception {
		//http://s3.app1101346127.qqopenapp.com/?seqid=4c2c98c36de27c332a8ec51bb48f9770&openid=2FA88E3B8D80522FF95C3395144AC205&openkey=BCD3F91AD5A39324E43DD4F601ED1A39&platform=website&pf=website&serverid=3&pfkey=0d49056b9dc775c7db0c839d9bce4211&s=0.16194215510040522&&sName=%E6%B5%8B%E8%AF%95%E6%9C%8D
		// String localkey = MD5Util.createMD5String("EPrNgH7bBKgEU40q");
		// System.out.println(localkey);
		String localkey = "f9a7531a561645fdff1a01e152a46522";
		Map<String, String> params = new HashMap<String, String>();

		params.put("pf", "qzone");
		params.put("openid", "2FA88E3B8D80522FF95C3395144AC205");
		params.put("openkey", "C1AD1AD247235BDE7E16AABE7E1212D5");

		String source = "openid" + "=" + "07230EA42BC5D8ACFAC5D6BB28F8D9EF" + "openkey" + "=" + "0F1F126DBBA8B4DFB65F066B5DAF9B00" + "pf" + "="
				+ "qzone" + "seqid" + "=" + "12345678" + localkey;
		String createsign = MD5Util.createMD5String(source);

		String sign = CommonUtil.makeSing(params, localkey);

		if (createsign.equals(sign)) {
			System.out.println(true);
		}
		System.out.println(helper.api(QQIsLogin, params, localkey));
	}
	
	public void testQQAreaLogin() throws Exception {
		//http://s3.app1101346127.qqopenapp.com/?seqid=4c2c98c36de27c332a8ec51bb48f9770&openid=2FA88E3B8D80522FF95C3395144AC205&openkey=BCD3F91AD5A39324E43DD4F601ED1A39&platform=website&pf=website&serverid=3&pfkey=0d49056b9dc775c7db0c839d9bce4211&s=0.16194215510040522&&sName=%E6%B5%8B%E8%AF%95%E6%9C%8D
		// String localkey = MD5Util.createMD5String("EPrNgH7bBKgEU40q");
		// System.out.println(localkey);
		String localkey = "f9a7531a561645fdff1a01e152a46522";
		Map<String, String> params = new HashMap<String, String>();

		params.put("pf", "qzone");
		params.put("openid", "2FA88E3B8D80522FF95C3395144AC205");
		params.put("openkey", "E817F5BEEF49F271D12FA31E5974121E");
		params.put("seqid", "53a9953c91a98fec33a7ce115341160f");
//		params.put("iopenid", "2FA88E3B8D80522FF95C3395144AC204");
//		params.put("invkey", "1234567890");
//		params.put("itime", "1234567890");

		String source = "openid" + "=" + "07230EA42BC5D8ACFAC5D6BB28F8D9EF" + "openkey" + "=" + "0F1F126DBBA8B4DFB65F066B5DAF9B00" + "pf" + "="
				+ "qzone" + "seqid" + "=" + "12345678" + localkey;
		String createsign = MD5Util.createMD5String(source);

		String sign = CommonUtil.makeSing(params, localkey);

		if (createsign.equals(sign)) {
			System.out.println(true);
		}
		System.out.println(helper.api(QQAreaLoginUrl, params, localkey));
	}
	
	
	public void testQQGetInvkey() throws Exception {
		//http://s3.app1101346127.qqopenapp.com/?seqid=4c2c98c36de27c332a8ec51bb48f9770&openid=2FA88E3B8D80522FF95C3395144AC205&openkey=BCD3F91AD5A39324E43DD4F601ED1A39&platform=website&pf=website&serverid=3&pfkey=0d49056b9dc775c7db0c839d9bce4211&s=0.16194215510040522&&sName=%E6%B5%8B%E8%AF%95%E6%9C%8D
		// String localkey = MD5Util.createMD5String("EPrNgH7bBKgEU40q");
		// System.out.println(localkey);
		String localkey = "f9a7531a561645fdff1a01e152a46522";
		Map<String, String> params = new HashMap<String, String>();

		params.put("pf", "website");
		params.put("openid", "2FA88E3B8D80522FF95C3395144AC204");
		params.put("openkey", "BCD3F91AD5A39324E43DD4F601ED1A39");

		String source = "openid" + "=" + "07230EA42BC5D8ACFAC5D6BB28F8D9EF" + "openkey" + "=" + "0F1F126DBBA8B4DFB65F066B5DAF9B00" + "pf" + "="
				+ "qzone" + "seqid" + "=" + "12345678" + localkey;
		String createsign = MD5Util.createMD5String(source);

		String sign = CommonUtil.makeSing(params, localkey);

		if (createsign.equals(sign)) {
			System.out.println(true);
		}
		System.out.println(helper.api(QQGetInvkey, params, localkey));
	}

	public void testLogin() throws InterruptedException, ExecutionException {
		int openIdNum = 5000;
		int loginNum = 2;
		// String localkey ="f9a7531a561645fdff1a01e152a46522";
		// 创建1000个号，每个号登录100次，用100个线程池登录
		List<String> openIdList = new ArrayList<String>();
		// 创建1000个号
		for (int i = 0; i < openIdNum; i++) {
			openIdList.add(MD5Util.createMD5String(i + "").toUpperCase());
		}
		List<Future<String>> futures = new ArrayList<Future<String>>(20);
		ExecutorService pool = Executors.newFixedThreadPool(100);
		for (int i = 0; i < openIdNum; i++) {
			LoginRunner call = new LoginRunner(openIdList.get(i));
			for (int j = 0; j < loginNum; j++) {
				futures.add(pool.submit(call));
			}
		}

		long begin = System.currentTimeMillis();
		Set<Integer> set = new HashSet<Integer>();
		while (true) {
			Thread.sleep(50);
			set.clear();
			for (int i = 0; i < futures.size(); i++) {
				Future<String> future = futures.get(i);
				if (!future.isDone()) {
					set.add(i);
				}
			}
			if (set.isEmpty()) {
				break;
			}
			long end = System.currentTimeMillis();
			System.out.println("[Executing] : " + (end - begin) + "ms.left:" + set.size());
		}
		long end1 = System.currentTimeMillis();
		System.out.println("[Execute Done] : " + (end1 - begin) + "ms.");
	}

	public void testQQIsVip() throws Exception {
		// String localkey = MD5Util.createMD5String("EPrNgH7bBKgEU40q");
		// System.out.println(localkey);
		String localkey = "f9a7531a561645fdff1a01e152a46522";
		Map<String, String> params = new HashMap<String, String>();

		params.put("pf", "website");
		params.put("openid", "2FA88E3B8D80522FF95C3395144AC205");
		params.put("openkey", "BCD3F91AD5A39324E43DD4F601ED1A39");
		params.put("seqid", "9633381ef0aacb473bd858d0482942c1");

		String source = "openid" + "=" + "07230EA42BC5D8ACFAC5D6BB28F8D9EF" + "openkey" + "=" + "0F1F126DBBA8B4DFB65F066B5DAF9B00" + "pf" + "="
				+ "qzone" + "seqid" + "=" + "12345678" + localkey;
		String createsign = MD5Util.createMD5String(source);

		String sign = CommonUtil.makeSing(params, localkey);

		if (createsign.equals(sign)) {
			System.out.println(true);
		}
		System.out.println(helper.api(QQIsVip, params, localkey));
	}
	
	public void testQQAddT() throws Exception {
		// String localkey = MD5Util.createMD5String("EPrNgH7bBKgEU40q");
		// System.out.println(localkey);
		String localkey = "f9a7531a561645fdff1a01e152a46522";
		Map<String, String> params = new HashMap<String, String>();

		params.put("pf", "qzone");
		params.put("openid", "2FA88E3B8D80522FF95C3395144AC205");
		params.put("openkey", "168578048E85D3BA81CD9EC60857FC6C");
		params.put("content", "测试");
		params.put("clientip", "60.125.10.55:5004");

		String source = "openid" + "=" + "07230EA42BC5D8ACFAC5D6BB28F8D9EF" + "openkey" + "=" + "0F1F126DBBA8B4DFB65F066B5DAF9B00" + "pf" + "="
				+ "qzone" + "seqid" + "=" + "12345678" + localkey;
		String createsign = MD5Util.createMD5String(source);

		String sign = CommonUtil.makeSing(params, localkey);

		if (createsign.equals(sign)) {
			System.out.println(true);
		}
		System.out.println(helper.api(QQAddTUrl, params, localkey));
	}

	public void testQQBuyGoods() throws Exception {
		// String localkey = MD5Util.createMD5String("EPrNgH7bBKgEU40q");
		// System.out.println(localkey);
		String localkey = "f9a7531a561645fdff1a01e152a46522";

		Map<String, String> params = new HashMap<String, String>();

		params.put("pf", "qzone");
		params.put("openid", "07230EA42BC5D8ACFAC5D6BB28F8D9EF");
		params.put("openkey", "0F1F126DBBA8B4DFB65F066B5DAF9B00");
		params.put("pfkey", "2d1e48cfc64b248a2258ecdd19832955");
		params.put("ts", Long.toString(System.currentTimeMillis() / 1000));
		params.put("payitem", "s1_7_qzone_11_569428275932169194_2001*1000*2");

		params.put("goodsmeta", "游戏卡*可获得1000元宝");
		params.put("goodsurl", "http://qzonestyle.gtimg.cn/qzonestyle/act/qzone_app_img/app613_613_75.png");
		params.put("zoneid", "0");
		params.put("charid", "569428275932169193");

		// String source = "openid" + "=" + "07230EA42BC5D8ACFAC5D6BB28F8D9EF" +
		// "openkey" + "=" + "0F1F126DBBA8B4DFB65F066B5DAF9B00" + "pf" + "="
		// + "qzone" + "seqid" + "=" + "12345678" + localkey;
		// String createsign = MD5Util.createMD5String(source);
		//
		// String sign = CommonUtil.makeSing(params, localkey);
		//
		// if(createsign.equals(sign)){
		// System.out.println(true);
		// }
		// String url = helper.createUrl(QQBuyGoodsUrl, params, localkey);
		// System.out.println(url);
		System.out.println(helper.api(QQBuyGoodsUrl, params, localkey));
	}

	public void testKaiYingCharge() throws Exception {
		// String localkey = MD5Util.createMD5String("EPrNgH7bBKgEU40q");
		// System.out.println(localkey);
		String localkey = "f9a7531a561645fdff1a01e152a46522";

		Map<String, String> params = new HashMap<String, String>();

		params.put("openid", "07230EA42BC5D8ACFAC5D6BB28F8D9EF");
		params.put("appid", "1101346127");
		params.put("ts", Long.toString(System.currentTimeMillis() / 1000));
		params.put("payitem", "s1_7_pengyou_11_569428275932169194_2001*1000*2");
		params.put("token", "4021A324754CCD7EA01836261D0AFF7207622");
		params.put("billno", "-APPDJT18700-20120210-1428215572");
		params.put("version", "v3");
		params.put("zoneid", "0");
		params.put("providetype", "0");
		params.put("amt", "80");
//		params.put("payamt_coins", "20");
		params.put("pubacct_payamt_coins", "10");
		params.put("sig", "irrPNM84b+gPh*qZOzZGKrScNeU==");

		String appid = params.get("appid");
		String openid = params.get("openid");
		String amt = params.get("amt");
		String billno = params.get("billno");
		String sig = params.get("sig");
		String ts = params.get("ts");

		String signSource = appid + openid + amt + billno + sig + ts;
		String createSign = MD5Util.createMD5String(signSource + "7EI60hny4iAs03RN");

		params.put("kingnet_sign", createSign);
		params.put("addition", "QQCOIN#13854351484579953017469066|10|20|1201|pay");
		// String source = "openid" + "=" + "07230EA42BC5D8ACFAC5D6BB28F8D9EF" +
		// "openkey" + "=" + "0F1F126DBBA8B4DFB65F066B5DAF9B00" + "pf" + "="
		// + "qzone" + "seqid" + "=" + "12345678" + localkey;
		// String createsign = MD5Util.createMD5String(source);
		//
		// String sign = CommonUtil.makeSing(params, localkey);
		//
		// if(createsign.equals(sign)){
		// System.out.println(true);
		// }
		// String url = helper.createUrl(QQBuyGoodsUrl, params, localkey);
		// System.out.println(url);
		System.out.println(helper.api(KaiYingChargeUrl, params, localkey));
	}
	
	public void testQQGetMultiInfo() throws Exception {
		//http://s3.app1101346127.qqopenapp.com/?seqid=4c2c98c36de27c332a8ec51bb48f9770&openid=2FA88E3B8D80522FF95C3395144AC205&openkey=BCD3F91AD5A39324E43DD4F601ED1A39&platform=website&pf=website&serverid=3&pfkey=0d49056b9dc775c7db0c839d9bce4211&s=0.16194215510040522&&sName=%E6%B5%8B%E8%AF%95%E6%9C%8D
		// String localkey = MD5Util.createMD5String("EPrNgH7bBKgEU40q");
		// System.out.println(localkey);
		String localkey = "f9a7531a561645fdff1a01e152a46522";
		Map<String, String> params = new HashMap<String, String>();

		params.put("pf", "qzone");
		params.put("openid", "2FA88E3B8D80522FF95C3395144AC205");
		params.put("openkey", "6B56E70E469A44BF6D7447DB42D0FB54");
		params.put("seqid", "9b9db11158b84d3e261e2bdf110f2753");
		params.put("iopenid", "4CE21BE8D749FC872C7120CAAAEC2DD2");
		params.put("invkey", "1234567890");
		params.put("itime", "1234567890");

		String source = "openid" + "=" + "07230EA42BC5D8ACFAC5D6BB28F8D9EF" + "openkey" + "=" + "0F1F126DBBA8B4DFB65F066B5DAF9B00" + "pf" + "="
				+ "qzone" + "seqid" + "=" + "12345678" + localkey;
		String createsign = MD5Util.createMD5String(source);

		String sign = CommonUtil.makeSing(params, localkey);

		if (createsign.equals(sign)) {
			System.out.println(true);
		}
		System.out.println(helper.api(QQAreaLoginUrl, params, localkey));
	}

	/**
	 * 多人生成
	 * 
	 * @throws Exception
	 */
	public void testAllKaiYingCharge() throws Exception {
		// String localkey = MD5Util.createMD5String("EPrNgH7bBKgEU40q");
		// System.out.println(localkey);
		String localkey = "f9a7531a561645fdff1a01e152a46522";
		long baseCharId = 1l;

		String appid = "1101346127";

		long charNum = 50;
		long billNum = 10;
		List<Future<String>> futures = new ArrayList<Future<String>>(20);
		ExecutorService pool = Executors.newFixedThreadPool(100);
		for (int i = 0; i < charNum; i++) {
			long charid = baseCharId + i;
			String openid = MD5Util.createMD5String((baseCharId + i) + "").toUpperCase();
			for (int j = 0; j < billNum; j++) {
				String billtoken = MD5Util.createMD5String(openid + "" + j);

				Map<String, String> params = new HashMap<String, String>();

				params.put("openid", openid);
				params.put("appid", appid);
				params.put("ts", Long.toString(System.currentTimeMillis() / 1000));
				params.put("payitem", "s1_7_pengyou_11_" + charid + "_2001*1000*2");
				params.put("token", billtoken);
				params.put("billno", billtoken);
				params.put("version", "v3");
				params.put("zoneid", "0");
				params.put("providetype", "0");
				params.put("amt", "80");
				params.put("payamt_coins", "20");
				params.put("pubacct_payamt_coins", "10");
				params.put("sig", "VvKwcaMqUNpKhx0XfCvOqPRiAnU=");

				// String appid = params.get("appid");
				// String openid = params.get("openid");
				String amt = params.get("amt");
				String billno = params.get("billno");
				String sig = params.get("sig");
				String ts = params.get("ts");

				String signSource = appid + openid + amt + billno + sig + ts;
				String createSign = MD5Util.createMD5String(signSource + "7EI60hny4iAs03RN");

				params.put("kingnet_sign", createSign);
				params.put("addition", "QQCOIN#13854351484579953017469066|10|20|1201|pay");
				//提交10次
				for(int k = 0; k < 10; k ++){
					RequestRunner call = new RequestRunner(KaiYingChargeUrl, params, localkey);
					futures.add(pool.submit(call));
				}

//				System.out.println(helper.api(KaiYingChargeUrl, params, localkey));
			}
		}

		long begin = System.currentTimeMillis();
		Set<Integer> set = new HashSet<Integer>();
		while (true) {
			Thread.sleep(50);
			set.clear();
			for (int i = 0; i < futures.size(); i++) {
				Future<String> future = futures.get(i);
				if (!future.isDone()) {
					set.add(i);
				}
			}
			if (set.isEmpty()) {
				break;
			}
			long end = System.currentTimeMillis();
			System.out.println("[Executing] : " + (end - begin) + "ms.left:" + set.size());
		}
		long end1 = System.currentTimeMillis();
		System.out.println("[Execute Done] : " + (end1 - begin) + "ms.");
	}

	public void genSql() {
		long baseCharId = 1l;

		String appid = "1101346127";

		long charNum = 50;
		long billNum = 10;
		for (int i = 0; i < charNum; i++) {
			long charid = baseCharId + i;
			String openid = MD5Util.createMD5String((baseCharId + i) + "").toUpperCase();
			for (int j = 0; j < billNum; j++) {
				long now = System.currentTimeMillis();
				String billtoken = MD5Util.createMD5String(openid + "" + j);
				String id = "bill_" + openid + "_" + billtoken;

				String sql = "INSERT INTO `t_qqorder_basic_info` VALUES ('" + id + "', '" + appid + "', '" + billtoken + "', '" + charid + "', '"
						+ now + "', '" + openid + "', '" + openid + "', 'qzone', '" + openid + "');";
				System.out.println(sql);
			}
		}

		// 生成5000个订单
		// for(int i = 0 ; i < 5000;i++){
		// long now = System.currentTimeMillis();
		// String billtoken=MD5Util.createMD5String(now + "");
		//
		// }
	}

	class LoginRunner implements Callable<String> {

		private String openid;

		/** 绑定的场景 */
		public LoginRunner(String openid) {
			this.openid = openid;
		}

		@Override
		public String call() throws Exception {

			String localkey = "f9a7531a561645fdff1a01e152a46522";
			Map<String, String> params = new HashMap<String, String>();

			params.put("pf", "qzone");
			params.put("openid", this.openid);
			params.put("openkey", "0F1F126DBBA8B4DFB65F066B5DAF9B00");
			params.put("seqid", "9633381ef0aacb473bd858d0482942c1");

			// String source = "openid" + "=" +
			// "07230EA42BC5D8ACFAC5D6BB28F8D9EF" + "openkey" + "=" +
			// "0F1F126DBBA8B4DFB65F066B5DAF9B00" + "pf" + "="
			// + "qzone" + "seqid" + "=" + "12345678" + localkey;
			// String createsign = MD5Util.createMD5String(source);
			//
			// String sign = CommonUtil.makeSing(params, localkey);
			String result = helper.api(QQAreaLoginUrl, params, localkey);
			// System.out.println( "==========" + result);
			return result;

		}
	}

	class RequestRunner implements Callable<String> {

		private Map<String, String> params;
		private String url;
		private String localkey;

		/** 绑定的场景 */
		public RequestRunner(String url,Map<String, String> params,String localkey) {
			this.params = params;
			this.url = url;
			this.localkey = localkey;
		}

		@Override
		public String call() throws Exception {
			// String source = "openid" + "=" +
			// "07230EA42BC5D8ACFAC5D6BB28F8D9EF" + "openkey" + "=" +
			// "0F1F126DBBA8B4DFB65F066B5DAF9B00" + "pf" + "="
			// + "qzone" + "seqid" + "=" + "12345678" + localkey;
			// String createsign = MD5Util.createMD5String(source);
			//
			// String sign = CommonUtil.makeSing(params, localkey);
			String result = helper.api(url, params, localkey);
			// System.out.println( "==========" + result);
			return result;
		}
	}
	
//	@Test
	public void testTaskMarket() throws Exception{
		String localkey = "f9a7531a561645fdff1a01e152a46522";
		
		HashMap<String, String> params = new HashMap<String, String>();
		
		params.put("appid", "1101346127");
		params.put("billno", "4BE1D6AE-5324-11E3-BC76-00163EB7F40B");
		
		params.put("step", "4");
		params.put("cmd", "award");
		
		params.put("contractid", "24885T320131118114134");
		params.put("openid", "000000000000000000000000025900A0");
		params.put("payitem", "1001");
		params.put("pf", "qzone");
		params.put("providetype", "2");
		params.put("ts", "1385089780");
		params.put("version", "V3");

		String appkey = "7EI60hny4iAs03RN&";

		String url_path = "/" + QQMarket;

		String method = "POST";

		String sig = QQMarketUtil.makeSig(method, url_path, params, appkey);
		
		params.put("sig", sig);
		
		String result = helper.api(QQMarket, params, localkey);
		
		System.out.println(result);
	}
	
	@Test
	public void testGetPubacctBalanceServlet() throws Exception{
		//http://s3.app1101346127.qqopenapp.com/?seqid=4c2c98c36de27c332a8ec51bb48f9770&openid=2FA88E3B8D80522FF95C3395144AC205&openkey=BCD3F91AD5A39324E43DD4F601ED1A39&platform=website&pf=website&serverid=3&pfkey=0d49056b9dc775c7db0c839d9bce4211&s=0.16194215510040522&&sName=%E6%B5%8B%E8%AF%95%E6%9C%8D
		// String localkey = MD5Util.createMD5String("EPrNgH7bBKgEU40q");
		// System.out.println(localkey);
		String localkey = "f9a7531a561645fdff1a01e152a46522";
		Map<String, String> params = new HashMap<String, String>();

		params.put("pf", "qzone");
		params.put("openid", "2FA88E3B8D80522FF95C3395144AC205");
		params.put("openkey", "3099BF9D943D25EB48DC76FE695B09F0");
		params.put("pfkey", "3099BF9D943D25EB48DC76FE695B09F0");

		String source = "openid" + "=" + "07230EA42BC5D8ACFAC5D6BB28F8D9EF" + "openkey" + "=" + "0F1F126DBBA8B4DFB65F066B5DAF9B00" + "pf" + "="
				+ "qzone" + "seqid" + "=" + "12345678" + localkey;
		String createsign = MD5Util.createMD5String(source);

		String sign = CommonUtil.makeSing(params, localkey);

		if (createsign.equals(sign)) {
			System.out.println(true);
		}
		System.out.println(helper.api(QQGetPubacctBalance, params, localkey));
	}
	
	public void testFinishMarketTask() throws Exception{
		String localkey = "f9a7531a561645fdff1a01e152a46522";
		
		HashMap<String, String> params = new HashMap<String, String>();
		params.put("openid", "000000000000000000000000025900A0");
		params.put("step", "4");

		System.out.println(helper.api(QQFinishMarketTask, params, localkey));
	}
	
	public void testGetMarketAward() throws Exception{
		String localkey = "f9a7531a561645fdff1a01e152a46522";
		
		HashMap<String, String> params = new HashMap<String, String>();
		params.put("openid", "000000000000000000000000025900A0");

		System.out.println(helper.api(QQGetMarketAward, params, localkey));
	}
}
