package com.renren.games.api.service;

import com.renren.games.api.db.po.ChannelLogin;
import com.renren.games.api.db.po.QQTaskMarket;
import com.renren.games.api.util.LRUMap;

/**
 * Created by wyn on 16/3/10.
 */
public class ChannelLoginService {
    LRUMap<String, ChannelLogin> taskMarket;

    public ChannelLoginService() {

        taskMarket = new LRUMap<String, ChannelLogin>(5000);
    }

    public void putChannelLogin(String key , ChannelLogin item){
        this.taskMarket.put(key, item);
    }

    public ChannelLogin getChannelLogin(String key){
        return this.taskMarket.get(key);
    }

    public void remove(String key){
        this.taskMarket.remove(key);
    }
}
