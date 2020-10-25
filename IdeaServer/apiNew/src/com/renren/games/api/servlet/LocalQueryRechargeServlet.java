package com.renren.games.api.servlet;

import com.renren.games.api.core.Globals;
import com.renren.games.api.core.Loggers;
import com.renren.games.api.db.model.QueryOrderEntity;
import com.renren.games.api.util.CommonUtil;
import net.sf.json.JSONArray;
import net.sf.json.JSONObject;
import org.slf4j.Logger;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.List;

/**
 * Created by wyn on 16/2/29.
 */
public class LocalQueryRechargeServlet extends HttpServlet{
    private Logger logger = Loggers.chargeLogger;
    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        doPost(req,res);
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        String userid = req.getParameter("userid"); //角色id
        String serverid = req.getParameter("serverid");
        List<QueryOrderEntity> queryOrderList = Globals.getDaoService().getQueryOrderDao().getChargeOrderListByCharId(userid);
        sendToClient(queryOrderList,res,userid);
    }
    private void sendToClient(List<QueryOrderEntity> tlist, HttpServletResponse res, String userid) throws IOException {
        if(tlist==null){
            return ;
        }

        JSONArray j = new JSONArray();
        for (int i=0;i<tlist.size();i++){
            QueryOrderEntity c = tlist.get(i);
            JSONObject o = new JSONObject();
            o.put("id",c.getId());
            o.put("user_id",c.getUserid());
            o.put("user_name",c.getUsername());
            o.put("order_id",c.getOrderid());
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
            j.add(o);
        }
        JSONObject t1 = new JSONObject();
        t1.put("ret",0);
        t1.put("recharge",j);
        CommonUtil.writeResponseResult(res,t1.toString(),userid,logger);
    }
}
