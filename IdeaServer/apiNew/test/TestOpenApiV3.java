import java.util.HashMap;
import java.util.UUID;

import qqsdk.com.qq.open.OpenApiV3;
import qqsdk.com.qq.open.OpensnsException;

/**
 * OpenAPI V3 SDK 示例代码
 * 
 * @version 3.0.0
 * @since jdk1.5
 * @author open.qq.com
 * @copyright © 2012, Tencent Corporation. All rights reserved.
 * @History: 3.0.0 | nemozhang | 2012-03-21 12:01:05 | initialization
 * 
 */

public class TestOpenApiV3 {
	public static void main(String args[]) {
		// 应用基本信息
		String appid = "1101336700";
		String appkey = "EPrNgH7bBKgEU40q";

		// 用户的OpenID/OpenKey
		String openid = "07230EA42BC5D8ACFAC5D6BB28F8D9EF";
		String openkey = "7B73300B599BB5D762CD3E6D5F776C3E";

		// OpenAPI的服务器IP
		// 最新的API服务器地址请参考wiki文档:
		// http://wiki.open.qq.com/wiki/API3.0%E6%96%87%E6%A1%A3
		String serverName = "119.147.19.43";

		// 所要访问的平台, pf的其他取值参考wiki文档:
		// http://wiki.open.qq.com/wiki/API3.0%E6%96%87%E6%A1%A3
		String pf = "qzone";

		OpenApiV3 sdk = new OpenApiV3(appid, appkey);
		sdk.setServerName(serverName);
		String uuid = UUID.randomUUID().toString();
//		long begin = System.currentTimeMillis();
		System.out.println("===========test GetUserInfo===========");
		testGetUserInfo(sdk, openid, openkey, pf,uuid);
//		long end = System.currentTimeMillis();
//		System.out.println(begin - end);
	}

	/**
	 * 测试调用UserInfo接口
	 * 
	 */
	public static void testGetUserInfo(OpenApiV3 sdk, String openid, String openkey, String pf,String uuid) {
		// 指定OpenApi Cgi名字
		String scriptName = "/v3/user/get_info";

		// 指定HTTP请求协议类型
		String protocol = "http";

		// 填充URL请求参数
		HashMap<String, String> params = new HashMap<String, String>();
		params.put("openid", openid);
		params.put("openkey", openkey);
		params.put("pf", pf);

		try {
			String resp = sdk.api(scriptName, params, protocol,uuid);
			System.out.println(resp);
		} catch (OpensnsException e) {
			System.out.printf("Request Failed. code:%d, msg:%s\n", e.getErrorCode(), e.getMessage());
			e.printStackTrace();
		}
	}
}
