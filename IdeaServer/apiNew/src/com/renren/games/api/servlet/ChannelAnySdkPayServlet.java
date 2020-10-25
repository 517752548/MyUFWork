package com.renren.games.api.servlet;

import com.renren.games.api.channel.anysdk.PayNotify;
import com.renren.games.api.core.Globals;
import com.renren.games.api.db.model.QueryOrderEntity;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.*;

/**
 * Created by wyn on 16/3/9.
 */
public class ChannelAnySdkPayServlet extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        doPost(req,res);
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        PayNotify payNotify = new PayNotify();
        String originSign = req.getParameter("sign");
        String paramValues = GetParamValues(req);
        payNotify.setPrivateKey("0B520D38840577CBEFE970A7E433030F");

        System.out.println("参考签名值: " + originSign + "\n");
        System.out.println("待签字符串: " + paramValues + "\n");
        System.out.println("计算得到的签名值: " + payNotify.getSign(paramValues) + "\n");
        if (payNotify.checkSign(paramValues, originSign)){
            System.out.println("验证签名成功\n");
            String pay_status= req.getParameter("pay_status");
            if(!"1".equals(pay_status))
            {
                res.getWriter().write("ok");
                return;
            }
            String orderid = req.getParameter("order_id");
            QueryOrderEntity c = Globals.getDaoService().getQueryOrderDao().getChargeOrderEntityByOrderId(orderid);
            if(c==null){
                c = new QueryOrderEntity();
                String amount = req.getParameter("amount");
                c.setUserid(req.getParameter("game_user_id"));
                c.setAmount(amount);
                c.setItem_id(req.getParameter("product_id"));
                c.setGame_points(Integer.parseInt(amount.substring(0,amount.indexOf(".")))*10+"");
                c.setOrderid(orderid);
                c.setStatus(1);
                c.setPay_channel(req.getParameter("channel_number"));
                Globals.getDaoService().getQueryOrderDao().save(c);
            }
      } else {
            System.out.println("验证签名失败");
        }

        res.getWriter().write("ok");

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
                paramValues += paramValue;
            }
        }

        return paramValues;
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
    public void sortParamNames(List<String> paramNames) {
        Collections.sort(paramNames, new Comparator<String>() {
            public int compare(String str1, String str2) {
                return str1.compareTo(str2);
            }
            });
        }
}
