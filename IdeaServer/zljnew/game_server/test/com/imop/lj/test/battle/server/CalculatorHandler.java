package com.imop.lj.test.battle.server;

import javax.script.ScriptEngine;
import javax.script.ScriptEngineManager;
import javax.script.ScriptException;

import org.apache.mina.core.service.IoHandlerAdapter;
import org.apache.mina.core.session.IoSession;

public class CalculatorHandler extends IoHandlerAdapter { 

    private ScriptEngine jsEngine = null; 

    public CalculatorHandler() { 
        ScriptEngineManager sfm = new ScriptEngineManager(); 
        jsEngine = sfm.getEngineByName("JavaScript"); 
        if (jsEngine == null) { 
            throw new RuntimeException("找不到 JavaScript 引擎。"); 
        } 
    } 

    public void exceptionCaught(IoSession session, Throwable cause) 
        throws Exception { 
    } 

    public void messageReceived(IoSession session, Object message) 
        throws Exception { 
        String expression = message.toString(); 
        if ("quit".equalsIgnoreCase(expression.trim())) { 
            session.close(true); 
            return; 
        } 
        try { 
            Object result = jsEngine.eval(expression); 
            session.write(result.toString()); 
        } catch (ScriptException e) { 
            session.write("Wrong expression, try again."); 
        } 
    } 
 }