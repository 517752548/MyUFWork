package com.renren.games.api.filter;

import java.io.IOException;

import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.http.HttpServletResponse;

import com.renren.games.api.core.ApiRuntime;

/**
 * 判断api服务器是否开启
 * 
 * @author yuanbo.gao
 *
 */
public class RuntimeFilter implements Filter {
	public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) throws IOException, ServletException {

//		HttpServletRequest req = (HttpServletRequest) request;
		HttpServletResponse res = (HttpServletResponse) response;

//		HttpSession session = req.getSession();
		if(ApiRuntime.isOpen()){
			chain.doFilter(request, response);
		}else{
			res.getWriter().print("{\"ret\":4,\"msg\":\"api server is not opened\"}");
//			res.sendRedirect("notopen.jsp");
		}
	}

	@Override
	public void destroy() {
		
	}

	@Override
	public void init(FilterConfig arg0) throws ServletException {
		
	}
}
