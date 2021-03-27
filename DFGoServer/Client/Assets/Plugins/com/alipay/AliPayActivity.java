package com.alipay;

import java.util.Map;

import com.alipay.sdk.app.AuthTask;
import com.alipay.sdk.app.PayTask;
import com.alipay.util.OrderInfoUtil2_0;
import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerActivity;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.os.Handler;
import android.os.Message;
import android.text.TextUtils;
import android.util.Log;
import android.view.View;


/**
 *  重要说明：
 *  
 *  本 Demo 只是为了方便直接向商户展示支付宝的整个支付流程，所以将加签过程直接放在客户端完成
 *  （包括 OrderInfoUtil2_0_HK 和 OrderInfoUtil2_0）。
 *
 *  在真实 App 中，私钥（如 RSA_PRIVATE 等）数据严禁放在客户端，同时加签过程务必要放在服务端完成，
 *  否则可能造成商户私密数据泄露或被盗用，造成不必要的资金损失，面临各种安全风险。
 *
 *  Warning:
 *
 *  For demonstration purpose, the assembling and signing of the request parameters are done on
 *  the client side in this demo application.
 *
 *  However, in practice, both assembling and signing must be carried out on the server side.
 */
public class AliPayActivity {
	
	/**
	 * 用于支付宝支付业务的入参 app_id。
	 */
	public static final String APPID = "2021002133645883";
	
	/**
	 * 用于支付宝账户登录授权业务的入参 pid。
	 */
	public static final String PID = "2021002134662151";

	/**
	 * 用于支付宝账户登录授权业务的入参 target_id。
	 */
	public static final String TARGET_ID = "";

	/**
	 *  pkcs8 格式的商户私钥。
	 *
	 * 	如下私钥，RSA2_PRIVATE 或者 RSA_PRIVATE 只需要填入一个，如果两个都设置了，本 Demo 将优先
	 * 	使用 RSA2_PRIVATE。RSA2_PRIVATE 可以保证商户交易在更加安全的环境下进行，建议商户使用
	 * 	RSA2_PRIVATE。
	 *
	 * 	建议使用支付宝提供的公私钥生成工具生成和获取 RSA2_PRIVATE。
	 * 	工具地址：https://doc.open.alipay.com/docs/doc.htm?treeId=291&articleId=106097&docType=1
	 */
	public static final String RSA2_PRIVATE = "MIIEogIBAAKCAQEAs5IeR051Ag2N3JfPR6utFarESNjp/bso3mnhX0NPJRnly4u2nxOREhdALGVaFzhzuDbLs8Y9l8FnkWTz1F5GgvaaAzarwoSCnQlv5mo6voXKb0v14d8t9x1R6++hiaUVsKNKSBUN/gPt6k1hjAWIcs/absYyGJnytJItqEvLmg1Qog05XhyKzzseW5FkW0Xd+LkwIYl+A+sFri5Xwuc4lMj6F9VdngH9QhbHCTiPtDdls2FeF6yRqjupyo38lFs1E3B5gxtYa8Ijb4/dhr3yXmny0OnZZ6yGaBPljTGfgtYpeL8GOZL+Q2+yY2u+keJIHb1KVw30lZYtpbHDqCyu2QIDAQABAoIBAFgvxTDtpebpMycHYuNmuyzt3VGNPXS/SnXX97dp/d9RlZndtkTvPgptYrWq3JCUx7fLKUTTcYIqmCs+McS0u9orMz2qxrVTkDWA4fR9bPYODHmWC13u1csLGiVNXL6VVU6XEq7NsD50PY4YjHRQb087JqHKMeYFDL2DIGsLNiUj3DVye+ofKo0rwgFmprkoTDvpU8Tup+fSJiescyv+JTsiCFYK8/nxd+WFI0ivICevvOrhBdTCd8t3LWAGPT9nIFFJ8Vxen4YzH7J1CP551jAmu3K5itlRBsuCKhm5+Bkw4p5W4nNK2gaMt89VCteBrM2CjvEPHF8G5H6xyUf46QECgYEA20a19wIQ+xBWlbPRnGu+0g5JZE1hukU51BwlOGchCL8eNOSBAKZiV8lxGkBy1GbYI3aabM7INDc/qSmd67x+qS85e+2fh5IAb8U5D70bDbR02NwBU5688CGtpV/a5EbYNw1XUHI0Rlmfr8XkKuy4vXyfb2S91kwBnbaMAJ0nw/kCgYEA0aURrrx0hHC55BPUvy4Hrwj5xOQJPxFv9oNnRHfptzWzprZQYMcwJfPc0FD3OxO45Uw7dIsrpP79vuMaMjB1VFRRDwRCZYlUFJSYTTT4GWxIWe9lb5QTEalQ3Y5eiSF3KOMJl4UyuONzjMSsJ+dV6BRiIwt2kImt/LFVqUIPOeECgYAttR6nH4Iko3I5AGO4JGmBZcL8qnitmFKGmVtU14J2TUhhpCQT25ryS6ZM35RQHCP/uHBWMABhiga2H1uw0PjiEVr9Lzoqy09V/Rl442VpRO16atnH8XXW5F5K86EwJmhZiWli9ntZEsOLo0d9fxy/OuQNF0XPDsbjdjLWyeuJGQKBgFlC70R2+SVq2btCtlKwRpVAPRiX/1fbFNDhIhcE934KX3OcLJ0IMnf2XQ5Vau68dv0qeCYnG24lI+UizQSRnWNKgzjhl2OkFSiuHCrDYt9wO14PkCDx6yyZ6tRqydWZaiL+iBb7n50ZOxm0o5hZ5znpc994AgOIm4v79X0bo2ABAoGAMfiVW1JFVINIhBO4NBxlTJKmT+XLB5jfE6es2q+SCOUWsU0ILVCjwN00nFMqjnnOWR9nCRGhHi6gzN18dChK9cPU9R5WdMwVtO/vznJgHq438uFlcD6UNm0K6K905Z5PKt/RXMtHZivO0VZRjr/YtNPaT+nSTJ2Ua27qWtiaZt4=";
	public static final String RSA_PRIVATE = "";
	
	private static final int SDK_PAY_FLAG = 1;
	private static final int SDK_AUTH_FLAG = 2;
	private static Activity activity;

	public void SetActivity(Activity _activity)
	{
		activity = _activity;
	}
	public static UnityListener listener;
	public void SetListener(UnityListener _listener){
		listener = _listener;
	};
	@SuppressLint("HandlerLeak")
	private Handler mHandler = new Handler() {
		@SuppressWarnings("unused")
		public void handleMessage(Message msg) {
			switch (msg.what) {
			case SDK_PAY_FLAG: {
				@SuppressWarnings("unchecked")
				PayResult payResult = new PayResult((Map<String, String>) msg.obj);
				/**
				 * 对于支付结果，请商户依赖服务端的异步通知结果。同步通知结果，仅作为支付结束的通知。
				 */
				String resultInfo = payResult.getResult();// 同步返回需要验证的信息
				String resultStatus = payResult.getResultStatus();
				// 判断resultStatus 为9000则代表支付成功
				if (TextUtils.equals(resultStatus, "9000")) {
					// 该笔订单是否真实支付成功，需要依赖服务端的异步通知。
					System.out.println("成功");
				} else {
					// 该笔订单真实的支付结果，需要依赖服务端的异步通知。
					System.out.println("缺少各种id3");
				}
				listener.Send(1,0,payResult.toString());
				break;
			}
			case SDK_AUTH_FLAG: {
				@SuppressWarnings("unchecked")
				AuthResult authResult = new AuthResult((Map<String, String>) msg.obj, true);
				String resultStatus = authResult.getResultStatus();

				// 判断resultStatus 为“9000”且result_code
				// 为“200”则代表授权成功，具体状态码代表含义可参考授权接口文档
				if (TextUtils.equals(resultStatus, "9000") && TextUtils.equals(authResult.getResultCode(), "200")) {
					// 获取alipay_open_id，调支付时作为参数extern_token 的value
					// 传入，则支付账户为该授权账户
					System.out.println("缺少各种id1");
				} else {
					// 其他状态值则为授权失败
					System.out.println("缺少各种id2");
				}
				break;
			}
			default:
				break;
			}
		};
	};


	/**
	 * 支付宝支付业务示例
	 */
	public void payV2() {
		if (TextUtils.isEmpty(APPID) || (TextUtils.isEmpty(RSA2_PRIVATE) && TextUtils.isEmpty(RSA_PRIVATE))) {
			System.out.println("缺少各种id");
			return;
		}
	
		/*
		 * 这里只是为了方便直接向商户展示支付宝的整个支付流程；所以Demo中加签过程直接放在客户端完成；
		 * 真实App里，privateKey等数据严禁放在客户端，加签过程务必要放在服务端完成；
		 * 防止商户私密数据泄露，造成不必要的资金损失，及面临各种安全风险； 
		 * 
		 * orderInfo 的获取必须来自服务端；
		 */
        boolean rsa2 = (RSA2_PRIVATE.length() > 0);
		Map<String, String> params = OrderInfoUtil2_0.buildOrderParamMap(APPID, rsa2);
		String orderParam = OrderInfoUtil2_0.buildOrderParam(params);

		String privateKey = rsa2 ? RSA2_PRIVATE : RSA_PRIVATE;
		String sign = OrderInfoUtil2_0.getSign(params, privateKey, rsa2);
		final String orderInfo = orderParam + "&" + sign;
		
		final Runnable payRunnable = new Runnable() {

			@Override
			public void run() {
				PayTask alipay = new PayTask(activity);
				Map<String, String> result = alipay.payV2(orderInfo, true);
				Log.i("msp", result.toString());
				
				Message msg = new Message();
				msg.what = SDK_PAY_FLAG;
				msg.obj = result;
				mHandler.sendMessage(msg);
			}
		};

		// 必须异步调用
		Thread payThread = new Thread(payRunnable);
		payThread.start();
	}

	/**
	 * 支付宝账户授权业务示例
	 */
	public void authV2(View v) {
		if (TextUtils.isEmpty(PID) || TextUtils.isEmpty(APPID)
				|| (TextUtils.isEmpty(RSA2_PRIVATE) && TextUtils.isEmpty(RSA_PRIVATE))
				|| TextUtils.isEmpty(TARGET_ID)) {
			System.out.println("缺少各种id");
			return;
		}

		/*
		 * 这里只是为了方便直接向商户展示支付宝的整个支付流程；所以Demo中加签过程直接放在客户端完成；
		 * 真实App里，privateKey等数据严禁放在客户端，加签过程务必要放在服务端完成；
		 * 防止商户私密数据泄露，造成不必要的资金损失，及面临各种安全风险； 
		 * 
		 * authInfo 的获取必须来自服务端；
		 */
		boolean rsa2 = (RSA2_PRIVATE.length() > 0);
		Map<String, String> authInfoMap = OrderInfoUtil2_0.buildAuthInfoMap(PID, APPID, TARGET_ID, rsa2);
		String info = OrderInfoUtil2_0.buildOrderParam(authInfoMap);
		
		String privateKey = rsa2 ? RSA2_PRIVATE : RSA_PRIVATE;
		String sign = OrderInfoUtil2_0.getSign(authInfoMap, privateKey, rsa2);
		final String authInfo = info + "&" + sign;
		Runnable authRunnable = new Runnable() {

			@Override
			public void run() {
				// 构造AuthTask 对象
				AuthTask authTask = new AuthTask(activity);
				// 调用授权接口，获取授权结果
				Map<String, String> result = authTask.authV2(authInfo, true);

				Message msg = new Message();
				msg.what = SDK_AUTH_FLAG;
				msg.obj = result;
				mHandler.sendMessage(msg);
			}
		};

		// 必须异步调用
		Thread authThread = new Thread(authRunnable);
		authThread.start();
	}




}
