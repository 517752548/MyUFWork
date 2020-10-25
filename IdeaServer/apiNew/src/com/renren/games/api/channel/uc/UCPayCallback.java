package com.renren.games.api.channel.uc;

import com.renren.games.api.core.Globals;
import com.renren.games.api.db.model.QueryOrderEntity;
import com.renren.games.api.enums.QueryOrderState;
import com.renren.games.api.util.TimeUtil;
import net.sf.json.JSONObject;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

/**
 * Created by wyn on 16/5/12.
 */
public class UCPayCallback extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        doPost(req,res);
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        String ver = req.getParameter("ver");
        String data = req.getParameter("data");
        String sign = req.getParameter("sign");

        JSONObject js = JSONObject.fromObject(data);
        String amount = (String)js.get("amount");
        Integer iamount = Integer.parseInt(amount);
        String orderStatus = (String)js.get("orderStatus");
        String orderid = (String)js.get("orderid");
        String channelOrderId  = (String)js.get("orderId");
        if(orderStatus!=null && orderStatus.equals("S")){
            QueryOrderEntity query = Globals.getDaoService().getQueryOrderDao().get(Long.parseLong(orderid));
            if(query!=null && query.getStatus()== QueryOrderState.INIT_ORDER.getIndex()){
                query.setStatus(QueryOrderState.HAD_PAY.getIndex());
                query.setPay_channel("uc");
                query.setPay_time(TimeUtil.s_now());
                query.setGame_points(iamount*100+""); //uc 的单位是元
                query.setOrderid(channelOrderId);
                Globals.getDaoService().getQueryOrderDao().update(query);
                Globals.getTelnetService().sendPayBack(query);
            }
        }
    }
}
