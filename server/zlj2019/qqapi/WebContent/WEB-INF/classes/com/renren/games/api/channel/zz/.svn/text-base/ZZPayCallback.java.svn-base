package com.renren.games.api.channel.zz;

import com.renren.games.api.core.Globals;
import com.renren.games.api.db.model.QueryOrderEntity;
import com.renren.games.api.enums.QueryOrderState;
import com.renren.games.api.util.MD5Util;
import com.renren.games.api.util.TimeUtil;
import com.sun.org.apache.xerces.internal.impl.dv.util.Base64;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.*;

/**
 * Created by wyn on 16/5/9.
 */
public class ZZPayCallback extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        doPost(req,res);
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        System.out.println("zzcallbackurl:"+GetParamValues(req));
        String result = req.getParameter("result");
        String money = req.getParameter("money");
        String channelOrderId= req.getParameter("channelOrderId");
        String orderNo = req.getParameter("orderNo");
        String time = req.getParameter("time");
        String sign = req.getParameter("signature").trim();

        String mobile = "13810981652";  //固定参数
        String email = "sun.yaping@gamedo.com.cn"; //固定参数
        String needsign = mobile+email+orderNo;
        String osign = org.apache.commons.codec.binary.Base64.encodeBase64String(org.apache.commons.codec.digest.DigestUtils.md5(needsign)).trim();
        System.out.println("zzpayback"+mobile+email+orderNo+":"+osign+":"+sign);
//        if((result != null) && result.equals("0") && (sign!=null) && sign.equals(osign)){
        //说是不需要判断result
        if((sign!=null) && sign.equals(osign)){
            QueryOrderEntity c =Globals.getDaoService().getQueryOrderDao().get(Long.parseLong(channelOrderId));

            //订单是空的
            if(c!=null && c.getStatus()==QueryOrderState.INIT_ORDER.getIndex() ){
                c.setStatus(QueryOrderState.HAD_PAY.getIndex());
                c.setPay_channel("zz");
                c.setPay_time(TimeUtil.s_now());
                c.setGame_points(money);
                c.setOrderid(channelOrderId);
                Globals.getDaoService().getQueryOrderDao().update(c);
                Globals.getTelnetService().sendPayBack(c);
            }else
            {
                System.out.println(channelOrderId);
            }
        }
        String RETURN = "SUCCESS";
        res.getWriter().print(RETURN); //返回给第三方服务器


    }
    private String GetParamValues(HttpServletRequest req) {
        Enumeration pNames=req.getParameterNames();
        List<String> lkeys = new ArrayList<String>();
        String paramValues = "";
        while(pNames.hasMoreElements()){
            String key=(String)pNames.nextElement();
            lkeys.add(key);
        }
        sortParamNames(lkeys);
        for (String param:lkeys){
//            if(param.equals("sign"))
//            {
//                continue;
//            }
//            if(param.equals("sign_return"))
//            {
//                continue;
//            }
            String paramValue = req.getParameter(param);
            if(paramValue!=null){
                paramValues += param+"="+paramValue+"&";
            }
        }
        paramValues = paramValues.substring(0,paramValues.length()-1);
        return paramValues;
    }
    public void sortParamNames(List<String> paramNames) {
        Collections.sort(paramNames, new Comparator<String>() {
            public int compare(String str1, String str2) {
                return str1.compareTo(str2);
            }
        });
    }
}

