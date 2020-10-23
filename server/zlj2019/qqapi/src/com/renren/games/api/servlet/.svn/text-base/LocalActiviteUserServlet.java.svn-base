package com.renren.games.api.servlet;

import com.renren.games.api.core.Globals;
import com.renren.games.api.core.Loggers;
import com.renren.games.api.db.model.TCDKeyEntity;
import com.renren.games.api.util.CommonUtil;
import org.slf4j.Logger;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;

/**
 * Created by wyn on 16/2/29.
 */
public class LocalActiviteUserServlet extends HttpServlet {
    private Logger logger = Loggers.activiteUserLogger;

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        doPost(req,res);
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        String userid = req.getParameter("userid");
        String activitecode = req.getParameter("activationcode");
        String re = "fail:-1";
        if(activitecode==null){
            CommonUtil.writeResponseResult(res,re,userid,logger);
            return ;
        }
        TCDKeyEntity t1 = Globals.getDaoService().getTCDKeyDao().get(activitecode);
        if(t1==null){
            CommonUtil.writeResponseResult(res,re,userid,logger);
            return ;
        }
        if(!("-1").equals(t1.getUserid())){
            re ="fail:-2";
            CommonUtil.writeResponseResult(res,re,userid,logger);
            return;
        }
        List<TCDKeyEntity> t2list = Globals.getDaoService().getTCDKeyDao().getTCDKeyByCDTypeUser(userid,t1.getCdtype());
        if(t2list !=null && t2list.size()>0){
            re = "fail:-3";
            CommonUtil.writeResponseResult(res,re,userid,logger);
            return ;
        }
        t1.setUserid(userid);
        Globals.getDaoService().getTCDKeyDao().update(t1);
        re = "ok:"+t1.getItemid();
        CommonUtil.writeResponseResult(res,re,userid,logger);
        return ;

    }
}
