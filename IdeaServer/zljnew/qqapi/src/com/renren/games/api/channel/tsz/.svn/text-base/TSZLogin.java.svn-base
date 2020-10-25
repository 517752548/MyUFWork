package com.renren.games.api.channel.tsz;

import com.renren.games.api.core.Loggers;
import com.renren.games.api.util.CommonUtil;
import com.renren.games.api.util.HttpUtil;
import net.sf.json.JSONObject;
import org.slf4j.Logger;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

/**
 * Created by wyn on 16/5/12.
 */
public class TSZLogin extends HttpServlet {
    private Logger logger = Loggers.loginLogger;
    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        doPost(req,res);
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        String accessToken = req.getParameter("at");
        String url = "https://openapi.360.cn/user/me?access_token="+accessToken;
        String sr = HttpUtil.getUrl(url);
        String re = "";
        JSONObject js = new JSONObject();
        if(sr==null || sr.trim().length()==0){
            js.put("result","0");
            CommonUtil.writeResponseResult(res,js.toString(),accessToken,"",logger);
            return;
        }
        CommonUtil.writeResponseResult(res,sr,accessToken,"",logger);
    }
}
