package com.renren.games.api.servlet;

import com.renren.games.api.channel.anysdk.Login;
import com.renren.games.api.core.Globals;
import com.renren.games.api.db.model.TCDKeyEntity;
import com.renren.games.api.db.po.ChannelLogin;
import com.renren.games.api.util.MD5Util;
import com.renren.games.api.util.RandomUtil;
import net.sf.json.JSONObject;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;

/**
 * Created by wyn on 16/3/9.
 */
public class ChannelTCDkeyServlet extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        doPost(req,res);
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        String tkey = "7,8,9,10";
        Integer eachneedcreate = 1000;
        String keys[] = tkey.split(",");
        for (int i=0;i<keys.length;i++){
            createtcdkey(eachneedcreate,keys[i]);
        }
    }

    private void createtcdkey(int allcount,String type){
        int i=0;
        while (i<allcount){
            createnewtcdkey(type);
            i++;
        }
    }
    private void createnewtcdkey(String type){
        String key = getKey();
        TCDKeyEntity tcdKeyEntity = Globals.getDaoService().getTCDKeyDao().get(key);
        if(tcdKeyEntity==null){
            tcdKeyEntity = new TCDKeyEntity();
            tcdKeyEntity.setId(key);
            tcdKeyEntity.setCdtype(type);
            Globals.getDaoService().getTCDKeyDao().save(tcdKeyEntity);
        }else
        {
            createnewtcdkey(type);
        }
    }

    private String getKey(){
        String value =""+ System.currentTimeMillis()+ RandomUtil.nextEntireInt(10000000,999999999);
        return MD5Util.createMD5String(value).substring(0,8);
    }
}
