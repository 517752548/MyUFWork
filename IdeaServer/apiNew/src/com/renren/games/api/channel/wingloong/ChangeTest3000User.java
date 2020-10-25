package com.renren.games.api.channel.wingloong;

import com.renren.games.api.servlet.LocalLoginServlet;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

/**
 * Created by wyn on 16/5/24.
 */
public class ChangeTest3000User extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        doPost(req,res);
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        String userid = req.getParameter("userid");
        if(userid!=null && userid.length()>0){
            LocalLoginServlet.setTestUser(userid);

        }
    }
}
