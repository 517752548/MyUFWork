package com.renren.games.api.servlet;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Random;

import com.renren.games.api.channel.anysdk.*;
import com.renren.games.api.core.Globals;
import com.renren.games.api.db.po.ChannelLogin;
import com.renren.games.api.util.MD5Util;
import net.sf.json.JSONArray;
import net.sf.json.JSONObject;
import net.sf.json.util.JSONBuilder;

/**
 * Created by wyn on 16/3/9.
 */
public class ChannelAnySdkOauthLoginServlet extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        doPost(req,res);
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
//        res.getWriter().write("ChannelAnySdkOauthLoginServlet");
        Login l = new Login();
        String result = l.check(req);
        if(result.equals("")){
            sendToClient(res,"paramerer error");
            return ;
        }
        System.out.print("result"+result);
        /**
        {
         "status":"ok",
         "data":{"errCode":200,"errMsg":"success","data":{"user_id":"12055"}},
         "common":{"channel":"999999","user_sdk":"simsdk","uid":"12055","server_id":"1","plugin_id":""},
         "ext":""
         }
        **/
        JSONObject json = JSONObject.fromObject(result);
        if(json==null){
            sendToClient(res,"paramerer error");
            return ;
        }

        String userid = json.getJSONObject("common").getString("uid");
        String username="";
        String channel = json.getJSONObject("common").getString("channel");
        String key = MD5Util.createMD5String(channel+userid+System.currentTimeMillis());
        ChannelLogin channelLogin = new ChannelLogin();
        channelLogin.setUserid(userid);
        channelLogin.setUsername(username);
        channelLogin.setChannelid(channel);
        Globals.getChannelLoginService().putChannelLogin(key,channelLogin);

        JSONObject putext = new JSONObject();
        putext.put("sessionID",key);
        json.put("ext",putext);
        System.out.println("cookielogin:"+json.toString());
        sendToClient(res,json.toString());
    }
    private void sendToClient( HttpServletResponse response, String content ) {
        response.setContentType( "text/plain;charset=utf-8");
        try{
            PrintWriter writer = response.getWriter();
            writer.write( content );
            writer.flush();
        } catch( Exception e ) {
            e.printStackTrace();
        }
    }
}
