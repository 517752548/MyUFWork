package com.imop.lj.gm.page;

import java.io.CharArrayWriter;
import java.io.PrintWriter;

import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpServletResponseWrapper;

/**
 * GM平台系统重写Response类
 *
 * @author lin fan
 */
public class PagerResponse extends HttpServletResponseWrapper {

	/** 数组输出流*/
    private CharArrayWriter caw = new CharArrayWriter();

    /** 得到Response*/
    public PagerResponse(HttpServletResponse response) {
        super(response);
    }

    @Override
    public PrintWriter getWriter() {
        return new PrintWriter(caw);
    }

    public String getServletOutput() {
        return caw.toString();
    }

    @Override
    public void setCharacterEncoding(java.lang.String charset) {
        super.setCharacterEncoding(charset);
    }
}
