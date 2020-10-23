package com.renren.games.api.channel.yj;

import com.renren.games.api.core.Globals;
import com.renren.games.api.db.model.QueryOrderEntity;
import com.renren.games.api.enums.QueryOrderState;
import com.renren.games.api.util.HttpUtil;
import com.renren.games.api.util.MD5Util;
import com.renren.games.api.util.TimeUtil;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.*;

/**
 * Created by wyn on 16/5/10.
 */
public class YJPayCallback extends HttpServlet {
    private String pubkey = "ZLVGFADEA8HN49FJ1W5HNRIRZGQI9259";
    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        doPost(req,res);
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        String app =req.getParameter("app");
        String cbi = req.getParameter("cbi");
        String st = req.getParameter("st");
        String sign = req.getParameter("sign");
        //st标示位,1标识成功,其余都是失败.
        System.out.println("re-1"+st);
        String fee = req.getParameter("fee");
        String orderid = req.getParameter("tcd");
        String needsign = GetParamValues(req)+pubkey;
        String checksign = MD5Util.createMD5String(needsign);
        System.out.println("checksign"+checksign+":"+sign);
        try{
        if(st!=null && st.equals("1") && checksign!=null && checksign.toLowerCase().equals(sign)) {
            Long lcbi = Long.parseLong(cbi);
            System.out.println("re"+lcbi);
            QueryOrderEntity query = Globals.getDaoService().getQueryOrderDao().get(lcbi);
            if(query!=null && query.getStatus()==QueryOrderState.INIT_ORDER.getIndex()){
                query.setPay_channel("YJ");
                query.setPay_time(TimeUtil.s_now());
                query.setGame_points(fee);
                query.setOrderid(orderid);
                query.setStatus(QueryOrderState.HAD_PAY.getIndex());
                Globals.getDaoService().getQueryOrderDao().update(query);
                Globals.getTelnetService().sendPayBack(query);

            }
        }
        }catch(Exception e){
            e.printStackTrace();
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
            if(param.equals("sign"))
            {
                continue;
            }
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
