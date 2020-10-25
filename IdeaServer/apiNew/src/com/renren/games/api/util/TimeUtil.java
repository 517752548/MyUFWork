package com.renren.games.api.util;

import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * Created by wyn on 16/5/6.
 */
public class TimeUtil {
    public static String s_now (){
        SimpleDateFormat sf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
       return  sf.format(new Date());
    }
    public static void main(String[] args){
        System.out.println(TimeUtil.s_now());
    }
}
