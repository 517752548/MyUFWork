package com.imop.lj.filter;

import java.io.IOException;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;

import com.imop.lj.gm.autolog.GMAutoLogConstants;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.constants.Mask;
import com.imop.lj.gm.page.PagerResponse;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.CharsetUtil;

public class WEBAutoLogFilter implements Filter {

	@Override
	public void doFilter(ServletRequest arg0, ServletResponse arg1,
			FilterChain arg2) throws ServletException, IOException {

		HttpServletRequest request = (HttpServletRequest) arg0;
		HttpServletResponse response = (HttpServletResponse) arg1;
		PagerResponse pagerResponse = new PagerResponse(response);
		arg2.doFilter(request, pagerResponse);
		docheck(request, pagerResponse, response);
	}
	
	@SuppressWarnings("unchecked")
	private void docheck(HttpServletRequest request,
			PagerResponse pagerResponse, HttpServletResponse response)
			throws IOException {
		String logType = (String) request.getAttribute("logType");
		if (StringUtils.isBlank(logType)) {
			return;
		}
		List logs = (List) request.getAttribute("logList");
		if (logs == null) {
			return;
		}
		appendData(request, response, pagerResponse, logType);
	}
	/**
	 * 为通用log类中不同log添加jsp代码
	 * @param request
	 * @param response
	 * @param pagerResponse
	 * @param logType
	 * @throws IOException
	 */
	@SuppressWarnings("unchecked")
	private void appendData(HttpServletRequest request,
			HttpServletResponse response, PagerResponse pagerResponse,
			String logType) throws IOException {
//		PrintWriter out = response.getWriter();
		String originalStr = pagerResponse.getServletOutput();
		System.out.println(originalStr);
		int rowsIndex = originalStr.indexOf("</logparam>");
		int gotoIndex1 = originalStr.indexOf("//Mark1");
		int gotoIndex2 = originalStr.indexOf("//Mark2");
		int searchIndex1 = originalStr.indexOf("//Mark3");
		int searchIndex2 = originalStr.indexOf("//Mark4");
		String beforeParamStr =  -1==rowsIndex?"":originalStr.substring(0, rowsIndex);
		String beforeGotoStr = -1==gotoIndex1?"":originalStr.substring(rowsIndex, gotoIndex1);
		String afterGotoStr = -1==gotoIndex1?"":originalStr.substring(gotoIndex1, gotoIndex2);
		String beforeSearchStr = -1==gotoIndex2?"":originalStr
				.substring(gotoIndex2, searchIndex1);
		String afterSearchStr = searchIndex1==-1?"":originalStr.substring(searchIndex1,
				searchIndex2);
		String remainSearch = searchIndex2==-1?"":originalStr.substring(searchIndex2);
		String newStr = beforeParamStr + "<logparam>";
		// 用于js的var语句
		String parameterString = "";
		// 用于js URL的'&xxx=xxx'语句
		String urlString = "";
		// 用于搜索的input语句
		String inputString = "";

		//新建 js函数
		StringBuilder searchSb = new StringBuilder();
		searchSb.append("<script type='text/javascript'>");
		
		//当前页
		String currentPage = request.getParameter("currentPage");
        int currentPageSize = 0;
        if ((currentPage == null) || "".equals(currentPage)
            || "undefined".equals(currentPage)) {
        	currentPageSize =1;
        } else {
        	currentPageSize= Integer.parseInt(currentPage);
        }    
        searchSb.append("function serchCurrencyPage(){return "+currentPageSize+";}");
		
		ExcelLangManagerService lang = new ExcelLangManagerService();
		switch (GMAutoLogConstants.getIndexByLogName(logType)) {
		// item_log 物品监控日志
		case 8:
			String itemTemplateId = (String) request.getParameter("itemTemplateId");
			if (itemTemplateId == null) {
				itemTemplateId = "";
			}
			
			inputString = "&nbsp;&nbsp;<span>"+lang.readGm(GMLangConstants.TEMPLATE_ID)+"<input id=\"itemTemplateId\" type=\"text\" class=\"limitWidth\" value=\""+itemTemplateId+"\"/></span>";
//			parameterString = "var itemTemplateId = $(\"#itemTemplateId\").val();";
//			urlString = "+\"&itemTemplateId=\"+itemTemplateId;";			
			searchSb.append("function serchSb(){var opporationValue = document.getElementById('itemTemplateId').value;var opporationType = '&itemTemplateId='+opporationValue;return opporationType;}");	
			break;
		// money_log 金钱日志
		case 10:
			String ge = (String) request.getParameter("ge");
			inputString = "&nbsp;&nbsp;<span>" + lang.readGm(GMLangConstants.MONEYTYPE) + "："
					+ "<select id=\"moneyType\">";
			Map moneyTypes = Mask.getMap("currency");
			for (Iterator i = moneyTypes.keySet().iterator(); i.hasNext();) {
				int key = (Integer) i.next();
				Integer value = (Integer) moneyTypes.get(key);
				inputString += "<option id=\"moption" + key + "\" value=\""
						+ key + "\">" + lang.readGm(value) + "</option>";
			}
			inputString += "</select>";
			ge=ge==null?"":ge;
			inputString +="&nbsp;&nbsp;数值>=<input id=\"ge\" type=\"text\" class=\"limitWidth\" value=\""+ge+"\" />&nbsp;&nbsp;";
//			inputString +="<input id=\"selectNumber\" type=\"button\" class=\"butcom\" style=\"margin-left: 1em;\" value=\""+lang.readGm(GMLangConstants.COMMON_SEARCH)+"\" onclick='javaScript:searchs()'/></span>"; 
			searchSb.append("function serchSb(){var moneyType = document.getElementById('moneyType').value;var opporationValue = document.getElementById('ge').value;var opporationType = '&moneyType='+moneyType+'&ge='+opporationValue;return opporationType;}");
			break;
		// task_log 任务日志
		case 28:
			String taskID = request.getParameter("taskID");
			if (taskID == null) {
				taskID = "";
			}
			inputString = "&nbsp;&nbsp;<span>"+lang.readGm(GMLangConstants.TASK_ID)+"<input id=\"taskID\" type=\"text\" class=\"limitWidth\" value=\""+taskID+"\"/></span>";		
			searchSb.append("function serchSb(){var opporationValue = document.getElementById('taskID').value;var opporationType = '&taskID='+opporationValue;return opporationType;}");
			break;
		// chat_log 聊天日志
		case 4:
			inputString = "&nbsp;&nbsp;<span>" + lang.readGm(GMLangConstants.SCOPE) + "："
			+ "<select id=\"scope\" onchange='searchs()'>";
			Map scopes = Mask.getMap("chatLogScope");
			for (Iterator i = scopes.keySet().iterator(); i.hasNext();) {
				int key = (Integer) i.next();
				Integer value = (Integer) scopes.get(key);
				inputString += "<option id=\"soption" + key + "\" value=\""
						+ key + "\">" + lang.readGm(value) + "</option>";
			}
			inputString += "</select></span>";
			
			searchSb.append("function serchSb(){var opporationValue = document.getElementById('scope').value;var opporationType = '&scope='+opporationValue;return opporationType;}");
			break;
		// item_gen_log 物品产生日志
		case 7:
			String itemTemplateGenId = (String) request.getParameter("itemTemplateGenId");
			if (itemTemplateGenId == null) {
				itemTemplateGenId = "";
			}
			
			inputString = "&nbsp;&nbsp;<span>"+lang.readGm(GMLangConstants.TEMPLATE_ID)+"<input id=\"itemTemplateGenId\" type=\"text\" class=\"limitWidth\" value=\""+itemTemplateGenId+"\"/></span>";		
			searchSb.append("function serchSb(){var opporationValue = document.getElementById('itemTemplateGenId').value;var opporationType = '&itemTemplateGenId='+opporationValue;return opporationType;}");	
			break;
//		// prize_log 奖励日志
//		case 13:
//			inputString = "&nbsp;&nbsp;<span>" + lang.readGm(GMLangConstants.AWARD_TYPE) + "："
//					+ "<select id=\"prizeType\" onchange='searchs()'>";
//			Map prizeTypes = Mask.getMap("prizeType");
//			for (Iterator i = prizeTypes.keySet().iterator(); i.hasNext();) {
//				int key = (Integer) i.next();
//				Integer value = (Integer) prizeTypes.get(key);
//				inputString += "<option id=\"moption" + key + "\" value=\""
//						+ key + "\">" + lang.readGm(value) + "</option>";
//			}
//			inputString += "</select></span>";	
//			searchSb.append("function serchSb(){var opporationValue = document.getElementById('prizeType').value;var opporationType = '&prizeType='+opporationValue;return opporationType;}");		
////			parameterString = "var prizeType = $(\"#prizeType\").val();";
////			urlString += "+\"&prizeType=\"+prizeType;";
//			break;

		default:
			searchSb.append("function serchSb(){return;}");
			break;
		}
		
		//新建js函数尾
		searchSb.append("</script>");
		inputString +="<input id=\"select\" type=\"button\" class=\"butcom\" style=\"margin-left: 1em;\" value=\""+lang.readGm(GMLangConstants.COMMON_SEARCH)+"\" onclick='javaScript:searchs()'/></span>"; 
		
		newStr += inputString;
		newStr += beforeGotoStr;
		newStr += parameterString;
		newStr += afterGotoStr;
		newStr += urlString;
		newStr += beforeSearchStr;
		newStr += parameterString;
		newStr += afterSearchStr;
		newStr += urlString;
		newStr += remainSearch;
		newStr += searchSb.toString();
		response.getOutputStream().write(newStr.trim().getBytes(CharsetUtil.UTF8_CHARSET));
	}

	@Override
	public void init(FilterConfig arg0) throws ServletException {

	}

	@Override
	public void destroy() {
	}

}
