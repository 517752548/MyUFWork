package com.opi.gibp.tools.performance.gwt.ui.server;

import java.io.IOException;
import java.net.URLDecoder;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.apache.commons.codec.digest.DigestUtils;

import com.opi.gibp.tools.performance.constants.ServerConstants;
import com.opi.gibp.tools.performance.gwt.ui.server.model.SSOConfig;
import com.opi.gibp.tools.performance.gwt.ui.server.model.SSOUser;
import com.opi.gibp.tools.performance.utils.HttpUtil;
import com.opi.gibp.tools.performance.utils.db.DbHelper;



public class SSOLoginServlet extends HttpServlet {

	@Override
	protected void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		doPost(request, response);
	}

	@Override
	protected void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		HttpSession session = request.getSession();
		
		String method = request.getParameter("method");
		if("token".equals(method)){
			
			String token = request.getParameter("token");
			SSOConfig config  = SSOConfigManager.getInstance().getConfig();
			String hash = DigestUtils.md5Hex(token + config.getAppSecret());
			Map<String,String> paramMap = new HashMap<String, String>();
			paramMap.put("token", token);
			paramMap.put("hash", hash);
			
			String authResult = HttpUtil.postUrl(config.getSsoAuthURL(), paramMap, 10);
			Map<String, String> resultMap = parseQueryStrToParams(authResult);
			
			if("1".equals(resultMap.get("success"))){
				//验证成功，则查库看是否存在该用户，如果有，则获取，没有，则将用户入库，并提示没有权限
				SSOUser user = null;
				String username = resultMap.get("username");
				
				String selectSQL = "select * from t_user where user='" + username + "'";
				List<SSOUser> userList = null;
				try {
					userList = DbHelper.Select(selectSQL, "com.opi.gibp.tools.performance.gwt.ui.server.model.SSOUser");
					if(userList!=null && userList.size()>0){
						user = userList.get(0);
					}else{
						String insertSQL = "insert into t_user(user,gameids) values('" + username + "','')";
						DbHelper.Insert2(insertSQL);
						user = new SSOUser();
						user.setUser(username);
						user.setGameids("");
					}
				} catch (Exception e) {
//					e.printStackTrace();
				}
				
				session.setMaxInactiveInterval(60 * 30);
				session.setAttribute(ServerConstants.SSO_LOGINUSER, user);
				response.sendRedirect(request.getRequestURI() + "/../../");
			}else{
				//如果验证失败,则直接继续请求
				response.getWriter().print(URLDecoder.decode(authResult));
				response.getWriter().flush();
			}
		}
	}


	private Map<String,String> parseQueryStrToParams(String query){
		String[] params = query.split("&");  
		Map<String, String> map = new HashMap<String, String>();  
		for (String param : params)  
		{  
			try{
			    String name = param.split("=")[0];  
			    String value = URLDecoder.decode(param.split("=")[1],"UTF-8");  
			    map.put(name, value);
			}catch (Exception e) {
//				e.printStackTrace();
			}
		}  
		return map;  
	}
	

}
