package com.renren.games.api.channel;

import com.renren.games.api.channel.uc.UCChannel;

/**
 * Created by wyn on 16/3/1.
 */
public class ChannelProxy {
    public IChannel ucproxy ;

    private static ChannelProxy channelProxy;

    public static ChannelProxy getInstance(){
        if(channelProxy==null) {
            channelProxy = new ChannelProxy();
            channelProxy.init();
        }
        return channelProxy;
    }

    public void init(){
        ucproxy = new UCChannel();
        ucproxy.init();
    }

    public IChannel getChnnel(String channelCode){
        return ucproxy;
    }



}
