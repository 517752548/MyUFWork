package test;

//import com.sun.deploy.net.URLEncoder;
import org.apache.commons.codec.binary.Base64;
import org.junit.Test;

import com.renren.games.api.util.MD5Util;
import sun.security.provider.MD5;

import javax.crypto.Mac;
import javax.crypto.spec.SecretKeySpec;
import java.net.URLDecoder;
import java.security.InvalidKeyException;
import java.security.NoSuchAlgorithmException;


public class TestHttp {

	@Test
	public void test() throws NoSuchAlgorithmException, InvalidKeyException {
//		try {
//			for(int i = 0 ; i < 100000;i++){
//				long begin = System.currentTimeMillis();
//				String response = HttpUtil.getUrl("http://bus.rrgdata.com/ane/login_ane.html?detaildevicetype=iPod4,1&uuid2=5eefc1cefe07c9ce95957e081934ea61&f=925004401&apptype=ios&jailbroken=true&domain=tx.lstx.renren.com&uuid1=0e0de7fab9a24fdb911305af1ae9568d&connecttype=wifi&gameid=lstx5&devicetype=iPod%20touch&deviceversion=4.2.1&appid=game111&versionid=1.0.0&userid=userid&roleid=roleid&rrfastloginid=f9b3e5e945141903a0273c5480cfe1e6&idfv=9C9906E6-889B-4F22-BE0E-7FF8841FF185&idfa=09FEAB0A-713F-4DC7-8838-C357FFA25CEA");
//				long end = System.currentTimeMillis();
//				System.out.println(i + ":" + response + " execute :" + (end - begin) + "ms.");
//				
//			}	
//		} catch (Exception e) {
//			e.printStackTrace();
//		}
		
//		JSONArray js = new JSONArray();
//		int size=1;
//		for(int i = 0 ; i < size ; i++){
//			JSONObject jo = new JSONObject();
//			jo.put("serverId", 1001);
//			jo.put("telnetIp", "127.0.0.1");
//			jo.put("telnetPort", 7001);
//			js.add(jo);
//		}
//		System.out.println(js.toString());
//		String a = "1101346127" + "2FA88E3B8D80522FF95C3395144AC205" + "10000" + "-APPDJSX19116-20140512-1732383482" + "irrPNM84b+gPhsqZOzZGKrScNeU=" + "1399887158" + "7EI60hny4iAs03RN";
//		System.out.println(MD5Util.createMD5String(a));
////		System.out.println(MD5Util.createMD5String("5960ac6d5598f7ea26274490f21206e2#45e0ed5ab73f14431b39a99a6bb85d9f"));
//		String n = "13810981652sun.yaping@gamedo.com.cnff80808153b2b7230154a42d1be80b59";
////		org.apache.commons.codec.digest.DigestUtils.md5();
//
//		String rn = org.apache.commons.codec.binary.Base64.encodeBase64String(org.apache.commons.codec.digest.DigestUtils.md5(n));
//
//		System.out.println(rn);
		String key = "TxpyNmPKH1RjIPgVvXM6cQ==";

//		String signingKey = "";
		String data = "appId=2882303761517468811&session=Y3g7mIHQrOtHiHYP&uid=31191606";

//		System.out.println(bytesToHexString(rawHmac));

	}

}
