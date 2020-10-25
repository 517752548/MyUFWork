package com.renren.games.api.channel.yj;

import com.renren.games.api.core.Globals;
import com.renren.games.api.db.po.ChannelLogin;
import com.renren.games.api.util.MD5Util;
import net.sf.json.JSONObject;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.net.URLEncoder;

/**
 * Created by wyn on 16/5/10.
 */
public class YJLoginCallback extends HttpServlet {
    private String CHECK_LOGIN_URL = "http://sync.1sdk.cn/login/check.html";
    private final int LOGIN_RESULT_SUCCESS = 0;
    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        doPost(req,res);
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        String app = req.getParameter("app");
        String sdk = req.getParameter("sdk");
        String uin = req.getParameter("uin");
        String sess = req.getParameter("sess");

        StringBuilder sb = new StringBuilder();
        sb.append(CHECK_LOGIN_URL);
        sb.append("?app=");
        sb.append(app);
        sb.append("&sdk=");
        sb.append(sdk);
        sb.append("&uin=");
        sb.append(URLEncoder.encode(uin, "UTF-8"));
        sb.append("&sess=");
        sb.append(URLEncoder.encode(sess, "UTF-8"));
        try {
            JSONObject js = new JSONObject();
            HTTPHelper.SimpleHTTPResult ret = HTTPHelper.simpleInvoke ("GET", sb.toString(), null, null);
            if (ret.code != 200) {

                return;
            }
            if (ret.data == null || ret.data.length == 0) {
                js.put("result","error");
                res.getWriter().println(js.toString());
                return;
            } else {
                String r = new String (ret.data);
                Integer i = new Integer(r);
                if (i == LOGIN_RESULT_SUCCESS) {
                    String key = MD5Util.createMD5String(sdk+uin+System.currentTimeMillis());

                    js.put("result","success");
                    js.put("sid",key);
                    ChannelLogin channelLogin = new ChannelLogin();
                    channelLogin.setUserid(uin);
                    channelLogin.setUsername(uin);
                    channelLogin.setChannelid(sdk);
                    Globals.getChannelLoginService().putChannelLogin(key,channelLogin);
                    res.getWriter().print(js.toString());
                } else {
                    js.put("result","error");
                    res.getWriter().println(js.toString());
                }
                return;
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
