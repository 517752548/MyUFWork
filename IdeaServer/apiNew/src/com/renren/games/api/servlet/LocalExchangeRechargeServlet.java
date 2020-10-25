package com.renren.games.api.servlet;

import com.renren.games.api.core.Globals;
import com.renren.games.api.core.Loggers;
import com.renren.games.api.db.model.QueryOrderEntity;
import com.renren.games.api.enums.QueryOrderState;
import com.renren.games.api.util.CommonUtil;
import com.renren.games.api.util.TimeUtil;
import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import org.slf4j.Logger;

/**
 * Created by wyn on 16/2/29.
 */
public class LocalExchangeRechargeServlet extends HttpServlet{
    private Logger logger = Loggers.chargeLogger;


    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        doPost(req,res);
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        String userid = req.getParameter("userid");
        String pids = req.getParameter("pids");
//        String serverid = req.getParameter("serverid");
        List<QueryOrderEntity> exchangeList = getAllExchangeList(pids, userid);
        JSONArray j = new JSONArray();
        Entity2JSON(exchangeList,j);
        JSONObject js = new JSONObject();
        js.put("ret",0);
        js.put("recharge",j);
        CommonUtil.writeResponseResult(res,js.toString(),userid,logger);
    }

    private void Entity2JSON(List<QueryOrderEntity> exchangeList, JSONArray j) {
        if(exchangeList==null || exchangeList.size()==0){
            return;
        }
        for (int i=0;i<exchangeList.size();i++){
            JSONObject o = new JSONObject();
            QueryOrderEntity c = exchangeList.get(i);
            o.put("id",c.getId());
            o.put("user_id",c.getUserid());
            o.put("user_name",c.getUsername());
            o.put("order_id",c.getId());
            o.put("amount",0);
            o.put("currency",c.getCurrency());
            o.put("item_id",c.getItem_id());
            o.put("game_points",c.getGame_points());
            o.put("type",c.getType());
            o.put("udid",c.getUdid());
            o.put("device_id",c.getDevice_id());
            o.put("game_code",c.getGame_code());
            o.put("game_domain",c.getGame_domain());
            o.put("game_server_domain",c.getGame_server_domain());
            o.put("char_id",c.getChar_id());
            o.put("char_name",c.getChar_name());
            o.put("add_time",c.getAdd_time());
            o.put("expend_time",c.getPay_time());
            o.put("delay_time",c.getTransfer_time());
            o.put("terminal",c.getTerminal());
            o.put("remark",c.getRemark());
            o.put("chargetype",c.getChargetype());
            o.put("pay_channel",c.getPay_channel());
            o.put("sub_channel",c.getSub_channel());
            j.add(o);
        }
    }


    private List<QueryOrderEntity> getAllExchangeList(String pids, String userid) {
        List<QueryOrderEntity> l = new ArrayList<QueryOrderEntity>();
        String[] pid = pids.split(",");
        if(pid==null){
            return l;
        }
        for (int i=0;i<pid.length;i++){
            Long id = Long.parseLong(pid[i]);
            QueryOrderEntity tcharge = Globals.getDaoService().getQueryOrderDao().getChargeOrderEntityById(id);
            if(tcharge==null){
                continue;
            }
            if(l.contains(tcharge)){
                continue;
            }
            if(tcharge.getStatus()== QueryOrderState.FINISH.getIndex()){
                continue;
            }
            l.add(tcharge);
            tcharge.setTransfer_time(TimeUtil.s_now());
            tcharge.setStatus(QueryOrderState.FINISH.getIndex());  //已经完成兑换
            Globals.getDaoService().getQueryOrderDao().update(tcharge);
        }
        return l;
    }



}
