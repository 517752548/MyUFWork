package com.imop.lj.robot.test;

import com.imop.lj.common.constants.Loggers;
import org.slf4j.Logger;

/**
 * Created by wyn on 15/12/25.
 */
public class test {
    private static final org.slf4j.Logger logger = Loggers.gameLogger;
//    private static final Logger = Loggers

    public static void main(String[] args) {

        System.out.println("Hello World1");
        long l1 = 111;
        Long l2 = new Long(111);
        if(l1==l2){
            System.out.println("l:==");
        }else{
            System.out.println("l:!=");
        }
        String s1 = "a";
        String s2 = new String("a");
        if(s1==s2){
            System.out.println("s:==");
        }else{
            System.out.println("s:!=");
        }
    }
}
