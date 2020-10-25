package com.imop.lj.gm.page;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;

import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.context.WebApplicationContext;
import org.springframework.web.context.support.WebApplicationContextUtils;

import com.imop.lj.gm.utils.CharsetUtil;


/**
 * GM平台系统<br>
 * 分页过滤器
 *
 * @author lin fan
 */
public class PagerFilter implements Filter {

	/** 容器上下文实体*/
    private WebApplicationContext wac;

    /**分页实体*/
    private Pager pager;

    /**
     * 继承于Filter接口的方法,获取页面传来的分页数据.
     */
    public void doFilter(ServletRequest request, ServletResponse res,
        FilterChain filterChain) throws IOException, ServletException {
        IPaginationHelper pagerUtil =
            ((PaginationHelperScrollableImpl) wac.getBean("pagerUtil"));
        this.pager = pagerUtil.getPager();
        String currentPage = request.getParameter("currentPage");
        String pageSize = request.getParameter("pageSize");
        String displayPage = request.getParameter("displayPage");

        if ((currentPage == null) || "".equals(currentPage)
            || "undefined".equals(currentPage)) {
            pager.setCurrentPage(1);
        } else {
            pager.setCurrentPage(Integer.parseInt(currentPage));
        }
        if ((displayPage == null) || "".equals(displayPage)
            || "undefined".equals(displayPage)) {
            pager.setDisplayPageTagSize(5);
        } else {
            pager.setCurrentPage(Integer.parseInt(displayPage));
        }
        if ((pageSize == null) || "".equals(pageSize)
            || "undefined".equals(pageSize)) {
            pager.setPageSize(20);
        } else {
            pager.setPageSize(Integer.parseInt(pageSize));
        }

        pager.setPagenation(true);

        HttpServletResponse response = (HttpServletResponse) res;
        PagerResponse pagerResponse = new PagerResponse(response);
        filterChain.doFilter(request, pagerResponse);
        appendData(response, pagerResponse);
    }

    /**
     * 在Response后面,追加分页数据,以传到页面.
     *
     * @param response 页面请求的响应
     * @param pagerResponse 分页数据的响应
     * @throws IOException IO异常
     * @throws ServletException Servlet异常
     */
    public void appendData(HttpServletResponse response,
        PagerResponse pagerResponse) throws IOException, ServletException {
    	response.setHeader("content-type", "text/html;charset=utf-8");
//        PrintWriter out = response.getOutputStream();
        String originalStr = pagerResponse.getServletOutput();
        int rowsIndex = originalStr.indexOf("</data>");

        if ((pager.getDisplayPageTagList() != null) && (rowsIndex != -1)) {
            String beforeStr = originalStr.substring(0, rowsIndex);
            String afterStr = originalStr.substring(rowsIndex);
            String  newStr = beforeStr+"\n<data>";
            List<Integer> displayPageTagList = pager.getDisplayPageTagList();
            newStr+= " <span id='pageBut' class='pageBut'><a href='#' name='pageTag' onclick='goTo(1)' >首页</a>";
            if(pager.getCurrentPage()>1){
            	newStr+= "<a href='#' name='pageTag' onclick='goTo("+ (pager.getCurrentPage()-1) +")'>前一页</a>";
            }
            for(int i=0;i<displayPageTagList.size();i++){
            	    if(displayPageTagList.get(i)==pager.getCurrentPage()){
            	    	newStr+="<a id='curPage' href='#' onclick='goTo("+displayPageTagList.get(i)+");' value='"+displayPageTagList.get(i)+"'><span class='curPage'>"+displayPageTagList.get(i)+"</span></a>";
            	    }else{
            	    	newStr+="<a  href='#' onclick='goTo("+displayPageTagList.get(i)+");' name='pageTag' >"+displayPageTagList.get(i)+"</a>";
            	    }
             }
            newStr+= "<a href='#' name='pageTag' onclick='goTo("+ (pager.getCurrentPage()+1) +")'>后一页</a>";
            newStr+="<span>转到</span>&nbsp;" +
            "<input type='text' id='pno' class='pno'/>&nbsp;<img height='21' width='15'onclick='jumpTo();' src='images/return.gif'/>";
            newStr += afterStr;
            response.getOutputStream().write(newStr.trim().getBytes(CharsetUtil.UTF8_CHARSET));
//            out.println(newStr.trim());
        } else {
        	response.getOutputStream().write(originalStr.trim().getBytes(CharsetUtil.UTF8_CHARSET));
//            System.out.println(originalStr.trim());
        }

    }

    public void destroy() {
    }

    /**
     * @param filterConfig
     * 初始化容器上下文
     */
    public void init(FilterConfig arg0) throws ServletException {
        wac =
            WebApplicationContextUtils.getRequiredWebApplicationContext(arg0
                .getServletContext());
    }
}
