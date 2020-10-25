package com.renren.games.api.channel.tsz;

import com.renren.games.api.core.Globals;
import com.renren.games.api.db.model.QueryOrderEntity;
import com.renren.games.api.enums.QueryOrderState;
import com.renren.games.api.util.MD5Util;
import com.renren.games.api.util.TimeUtil;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.*;

/**
 * Created by wyn on 16/5/12.
 */
public class TSZPayCallback extends HttpServlet {
    private final String APPKEY = "5960ac6d5598f7ea26274490f21206e2";
    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        doPost(req,res);
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        String app_key = req.getParameter("app_key");
        String product_id = req.getParameter("product_id");
        String amount = req.getParameter("amount");
        String app_uid = req.getParameter("app_uid");
        String app_ext1 = req.getParameter("app_ext1");
        String app_ext2 = req.getParameter("app_ext2");
        String user_id = req.getParameter("user_id");
        String order_id = req.getParameter("order_id");
        String gateway_flag = req.getParameter("gateway_flag");
        String sign_type = req.getParameter("sign_type");
        String app_order_id = req.getParameter("app_order_id");
        String sign_return = req.getParameter("sign_return");
        String sign = req.getParameter("sign");
        res.getWriter().print("ok");
        String needsign = GetParamValues(req)+APPKEY;
        System.out.println("tsz"+needsign+":"+ MD5Util.createMD5String(needsign));
        if(gateway_flag!=null && gateway_flag.equals("success")){
            QueryOrderEntity queryOrder = Globals.getDaoService().getQueryOrderDao().get(Long.parseLong(app_order_id));
            if(queryOrder!=null && queryOrder.getStatus()== QueryOrderState.INIT_ORDER.getIndex()){
                queryOrder.setOrderid(order_id);
                queryOrder.setPay_channel("tsz");
                queryOrder.setPay_time(TimeUtil.s_now());
                queryOrder.setGame_points(amount);
                queryOrder.setStatus(QueryOrderState.HAD_PAY.getIndex());
                Globals.getDaoService().getQueryOrderDao().update(queryOrder);
                Globals.getTelnetService().sendPayBack(queryOrder);
            }
        }


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
            if(param.equals("sign_return"))
            {
                continue;
            }
            String paramValue = req.getParameter(param);
            if(paramValue!=null){
                paramValues += paramValue+"#";
            }
        }
//        paramValues = paramValues.substring(0,paramValues.length()-1);
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
