package com.renren.games.api.servlet;

import com.renren.games.api.core.Globals;
import com.renren.games.api.core.Loggers;
import com.renren.games.api.db.model.QueryOrderEntity;
import com.renren.games.api.enums.QueryOrderState;
import com.renren.games.api.util.CommonUtil;
import com.renren.games.api.util.TimeUtil;
import net.sf.json.JSONObject;
import org.slf4j.Logger;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

/**
 * Created by wyn on 16/5/6.
 */
public class LocalGenerateOrderServlet extends HttpServlet {
    private Logger logger = Loggers.chargeLogger;
    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        doPost(req,res);
    }

    /*
    http://local.wingloong.com:7081/u.generateorder.php?
    currenttime=20160506181016&format=JSON&userid=21&userName=test21&roleid=288516249174934505
    &charName=%E6%BF%AE%E9%98%B3%E5%98%89%E7%90%AA&deviceType=null&deviceVersion=null
    &ip=127.0.0.1&macInfo=null&udid=null&terminal=android&areaid=1&serverid=9010
    &domain=s1.csj.renren.com&gamecode=csj&platformid=renren.com
    &timestamp=1462529416&sig=c7373707b1ed72e6bd2c913e78af2fa1
     */
    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        String uid = req.getParameter("userid");
        String roleid=req.getParameter("roleid");
        String serverid = req.getParameter("serverid");
        QueryOrderEntity co = new QueryOrderEntity();
        co.setUserid(uid);
        co.setAdd_time(TimeUtil.s_now());
        co.setChar_id(roleid);
        co.setGame_server_domain(serverid); // 玩家的服务器id
        co.setStatus(QueryOrderState.INIT_ORDER.getIndex());
        Globals.getDaoService().getQueryOrderDao().save(co);
        JSONObject js = new JSONObject();
        js.put("ret",0);
        js.put("gameOrderId",co.getId());
        CommonUtil.writeResponseResult(res,js.toString(),uid,logger);
    }
}
