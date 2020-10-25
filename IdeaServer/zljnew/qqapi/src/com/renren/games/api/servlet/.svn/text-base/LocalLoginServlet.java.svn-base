package com.renren.games.api.servlet;

import cn.uc.g.sdk.cp.model.SessionInfo;
import cn.uc.g.sdk.cp.service.SDKServerService;
import com.renren.games.api.core.Globals;
import com.renren.games.api.core.Loggers;
import com.renren.games.api.db.model.TUserInfoEntity;
import com.renren.games.api.db.po.ChannelLogin;
import com.renren.games.api.util.CommonUtil;
import com.renren.games.api.util.HttpUtil;
import net.sf.json.JSONObject;
import org.slf4j.Logger;

import javax.crypto.Mac;
import javax.crypto.spec.SecretKeySpec;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.sql.Timestamp;

/**
 * Created by wyn on 16/2/29.
 */
public class LocalLoginServlet extends HttpServlet {
    private Logger logger = Loggers.loginLogger;
    public static String TEST_RETURNID="105475";
    public static long TESTUSERTIME = System.currentTimeMillis();
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        this.doGet(request, response);
    }

    //"ok:".$userid.":".$username.":".$is_young.":1"
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String logintype =  request.getParameter("logintype");
        if("1".equals(logintype) || "4".equals(logintype)){
            dologinusernamepassword(request,response);
        }else if("2".equals(logintype)){
            dologinusernamecookie(request,response);
        }

    }
    private void defaultchannel(HttpServletRequest request, HttpServletResponse response) throws IOException {
        String cookie = request.getParameter("username");
        ChannelLogin channelLogin = Globals.getChannelLoginService().getChannelLogin(cookie);
        String re = "fail:3";
        if(channelLogin==null){
            CommonUtil.writeResponseResult(response,re,cookie,"",logger);
            return;
        }
        Globals.getChannelLoginService().remove(cookie);
        String channeluserid = channelLogin.getChannelid()+"_"+channelLogin.getUserid();
        TUserInfoEntity user = Globals.getDaoService().getTUserInfoDao().getTUserInfoByName(channeluserid);
        if(user==null){
            user = new TUserInfoEntity();
            user.setName(channeluserid);
            user.setCreateTime(new Timestamp(System.currentTimeMillis()));
            Globals.getDaoService().getTUserInfoDao().save(user);

        }
        user.setLastLoginTime(new Timestamp(System.currentTimeMillis()));
        Globals.getDaoService().getTUserInfoDao().update(user);
        re = "ok:"+user.getId()+":"+user.getName()+":-1:1";
        CommonUtil.writeResponseResult(response,re,cookie,"",logger);
    }
    private void uclogin(HttpServletRequest request,HttpServletResponse response)throws IOException{
        String cookie = request.getParameter("username");
        System.out.println("nnnnnnnnnnn"+cookie);
        String re = "fail:3";
        try
        {
            SessionInfo sidInfo = SDKServerService.verifySession(cookie);
            if(sidInfo==null){
                re = "fail:3";
                CommonUtil.writeResponseResult(response,re,cookie,"",logger);
                return;
            }
            String channeluserid = "uc"+"_"+sidInfo.getAccountId();
            TUserInfoEntity user = Globals.getDaoService().getTUserInfoDao().getTUserInfoByName(channeluserid);
            if(user==null){
                user = new TUserInfoEntity();
                user.setName(channeluserid);
                user.setCreateTime(new Timestamp(System.currentTimeMillis()));
                Globals.getDaoService().getTUserInfoDao().save(user);
            }
            user.setLastLoginTime(new Timestamp(System.currentTimeMillis()));
            Globals.getDaoService().getTUserInfoDao().update(user);
            re = "ok:"+user.getId()+":"+user.getName()+":-1:1";
            CommonUtil.writeResponseResult(response,re,cookie,"",logger);
        }catch(Exception e){
            logger.error(e.getMessage());
            re = "fail:4";
            CommonUtil.writeResponseResult(response,re,cookie,logger);
            return;
        }

    }
    private void zzlogin(HttpServletRequest request,HttpServletResponse response)throws IOException{
        String cookie = request.getParameter("username");
        String re = "fail:3";
        try
        {
            if(cookie==null || cookie.trim().length()==0){
                re = "fail:3";
                CommonUtil.writeResponseResult(response,re,cookie,"",logger);
                return;
            }
            String channeluserid = "zz"+"_"+cookie;
            TUserInfoEntity user = Globals.getDaoService().getTUserInfoDao().getTUserInfoByName(channeluserid);
            if(user==null){
                user = new TUserInfoEntity();
                user.setName(channeluserid);
                user.setCreateTime(new Timestamp(System.currentTimeMillis()));
                Globals.getDaoService().getTUserInfoDao().save(user);
            }
            user.setLastLoginTime(new Timestamp(System.currentTimeMillis()));
            Globals.getDaoService().getTUserInfoDao().update(user);
            re = "ok:"+user.getId()+":"+user.getName()+":-1:1";
            CommonUtil.writeResponseResult(response,re,cookie,"",logger);
        }catch(Exception e){
            logger.error(e.getMessage());
            re = "fail:4";
            CommonUtil.writeResponseResult(response,re,cookie,logger);
            return;
        }

    }
    private void dologinusernamecookie(HttpServletRequest request,HttpServletResponse response) throws  ServletException,IOException {
        String sourcepwd = request.getParameter("psw");
        if(sourcepwd!=null){
            sourcepwd = sourcepwd.toLowerCase();
        }
        if(sourcepwd!=null){
            switch (sourcepwd) {
                case "100255":
                    uclogin(request,response);
                    break;
                case "zz":
                    zzlogin(request,response);
                    break;
                case "360":
                    tszlogin(request,response);
                    break;
                case "uc":
                    uclogin(request,response);
                    break;
                case "mi":
                    milogin(request,response);
                    break;
                default:
                    defaultchannel(request,response);
                    break;
            }
        }
    }
    private void milogin(HttpServletRequest request,HttpServletResponse response)throws IOException{
        String cookie = request.getParameter("username");
        String re = "fail:3";
        try
        {
            if(cookie==null || cookie.trim().length()==0){
                re = "fail:3";
                CommonUtil.writeResponseResult(response,re,cookie,"",logger);
                return;
            }

            String[] scookie = cookie.split("\\|");
            System.out.println("sss:"+scookie[0]);
            System.out.println("sss:"+scookie[1]);
            String appid ="2882303761517468811";
            String url = "http://mis.migc.xiaomi.com/api/biz/service/verifySession.do?";
            String par = "appId="+appid+"&session="+scookie[0]+"&uid="+scookie[1];
            url += par + "&signature="+misign(par);
            String urlmessage = HttpUtil.getUrl(url);
            JSONObject js = JSONObject.fromObject(urlmessage);
            System.out.println("xiaomicheckurl"+url+":"+urlmessage+":"+par);

            if(js==null || !js.containsKey("errcode") || !(((Integer)js.get("errcode"))==200)){
                re = "fail:3";
                CommonUtil.writeResponseResult(response,re,cookie,"",logger);
                return ;
            }
            String channeluserid = "mi"+"_"+scookie[1];
            TUserInfoEntity user = Globals.getDaoService().getTUserInfoDao().getTUserInfoByName(channeluserid);
            if(user==null){
                user = new TUserInfoEntity();
                user.setName(channeluserid);
                user.setCreateTime(new Timestamp(System.currentTimeMillis()));
                Globals.getDaoService().getTUserInfoDao().save(user);
            }
            user.setLastLoginTime(new Timestamp(System.currentTimeMillis()));
            Globals.getDaoService().getTUserInfoDao().update(user);
            re = "ok:"+user.getId()+":"+user.getName()+":-1:1";
            CommonUtil.writeResponseResult(response,re,cookie,"",logger);
        }catch(Exception e){
            logger.error(e.getMessage());
            re = "fail:4";
            CommonUtil.writeResponseResult(response,re,cookie,logger);
            return;
        }

    }
    private void tszlogin(HttpServletRequest request, HttpServletResponse response)throws IOException {
        String cookie = request.getParameter("username");
        String re = "fail:3";
        String url = "https://openapi.360.cn/user/me?access_token="+cookie;
        String sr = HttpUtil.getUrl(url);
        try
        {
            if(sr==null || sr.trim().length()==0){
                re = "fail:3";
                CommonUtil.writeResponseResult(response,re,cookie,"",logger);
                return;
            }
            JSONObject js = JSONObject.fromObject(sr);
            String uid = (String)js.get("id");
            if(uid==null || uid.length()==0){
                re = "fail:3";
                CommonUtil.writeResponseResult(response,re,cookie,"",logger);
                return;
            }
            String channeluserid = "tsz"+"_"+uid;
            TUserInfoEntity user = Globals.getDaoService().getTUserInfoDao().getTUserInfoByName(channeluserid);
            if(user==null){
                user = new TUserInfoEntity();
                user.setName(channeluserid);
                user.setCreateTime(new Timestamp(System.currentTimeMillis()));
                Globals.getDaoService().getTUserInfoDao().save(user);
            }
            user.setLastLoginTime(new Timestamp(System.currentTimeMillis()));
            Globals.getDaoService().getTUserInfoDao().update(user);
            re = "ok:"+user.getId()+":"+user.getName()+":-1:1";
            CommonUtil.writeResponseResult(response,re,cookie,"",logger);
        }catch(Exception e){
            logger.error(e.getMessage());
            re = "fail:4";
            CommonUtil.writeResponseResult(response,re,cookie,logger);
            return;
        }
    }

    private void dologinusernamepassword(HttpServletRequest request,HttpServletResponse response)throws ServletException, IOException{

        String useraccount = request.getParameter("username");
        String userpw = request.getParameter("psw");
        String serverid = request.getParameter("serverid");
        String re = "fail:3";
//        if(!"1001".equals(serverid) && !serverid.startsWith("9")){
//            if(!"test3000".equals(useraccount)){
//                re = "fail:5";
//                CommonUtil.writeResponseResult(response,re,useraccount,"",logger);
//                return;
//            }
//        }
        TUserInfoEntity user = Globals.getDaoService().getTUserInfoDao().getTUserInfoByName(useraccount);
        if(user==null){
            CommonUtil.writeResponseResult(response,re,useraccount,"",logger);
            return;
        }
        user.setLastLoginTime(new Timestamp(System.currentTimeMillis()));
        Globals.getDaoService().getTUserInfoDao().update(user);
        if(user.getPassword().equals(userpw)){
            if(useraccount.equals("test3000") && System.currentTimeMillis()-TESTUSERTIME<3600000){
                re = "ok:"+TEST_RETURNID+":"+user.getName()+":-1:1";
            }else{
                re = "ok:"+user.getId()+":"+user.getName()+":-1:1";
            }

        }else
        {
            re = "fail:4";
        }
        CommonUtil.writeResponseResult(response,re,useraccount,"",logger);
        return;

    }
    public String misign(String data){
        try {
            String key = "TxpyNmPKH1RjIPgVvXM6cQ==";
            String HMAC_SHA1 = "HmacSHA1";
            SecretKeySpec signingKey = new SecretKeySpec(key.getBytes(), HMAC_SHA1);
            Mac mac = Mac.getInstance(HMAC_SHA1);
            mac.init(signingKey);
            byte[] rawHmac = mac.doFinal(data.getBytes());
            return bytesToHexString(rawHmac);
        }
        catch(Exception e){
            return "{}";
        }
    }
    public String bytesToHexString(byte[] src){
        StringBuilder stringBuilder = new StringBuilder("");
        if (src == null || src.length <= 0) {
            return null;
        }
        for (int i = 0; i < src.length; i++) {
            int v = src[i] & 0xFF;
            String hv = Integer.toHexString(v);
            if (hv.length() < 2) {
                stringBuilder.append(0);
            }
            stringBuilder.append(hv);
        }
        return stringBuilder.toString();
    }
    public static void setTestUser(String userid){
        TEST_RETURNID = userid;
        TESTUSERTIME = System.currentTimeMillis();
    }
}
