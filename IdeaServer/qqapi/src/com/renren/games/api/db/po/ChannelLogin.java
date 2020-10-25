package com.renren.games.api.db.po;

/**
 * Created by wyn on 16/3/10.
 */
public class ChannelLogin {
    private String userid;
    private String username;
    private String channelid;

    public String getUserid() {
        return userid;
    }

    public void setUserid(String userid) {
        this.userid = userid;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getChannelid() {
        return channelid;
    }

    public void setChannelid(String channelid) {
        this.channelid = channelid;
    }
}
