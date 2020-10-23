<%@ taglib uri="http://www.springframework.org/tags" prefix="spring" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/functions" prefix="fn" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="fmt" %>
<%@ page import="org.springframework.web.context.support.WebApplicationContextUtils" %>
<%@ page import="org.springframework.web.context.WebApplicationContext" %>
<%@ page import="com.imop.lj.gm.service.xls.ExcelLangManagerService" %>
<%@ page import="com.imop.lj.gm.service.xls.XlsItemLoadService" %>
<%@ page import="com.imop.lj.gm.service.job.JobManageService" %>
<%@ page import="com.imop.lj.gm.utils.LangUtils" %>
<%@ page import="com.imop.lj.gm.constants.Mask" %>
<%@ page import="java.util.*" %>
<%@ page import="java.text.SimpleDateFormat" %>
<%@ page import="com.imop.lj.gm.constants.GMLangConstants" %>
<%@ page import="com.imop.lj.gm.constants.SystemConstants" %>
<%
	WebApplicationContext wac = WebApplicationContextUtils.getRequiredWebApplicationContext(this.getServletContext());
    ExcelLangManagerService lang = (ExcelLangManagerService) (wac.getBean("excelLangManagerService"));
    XlsItemLoadService xls = (XlsItemLoadService) (wac.getBean("xlsItemLoadService"));
    HashMap <String, Map<String, String>>  xlsData = xls.getXlsData();
    pageContext.setAttribute("xlsData",xlsData);
    pageContext.setAttribute("language",lang);
	@SuppressWarnings("unchecked")
    Map<String, Map>  m = Mask.getData();
    pageContext.setAttribute("dataMap",m);
    pageContext.setAttribute("lan",LangUtils.getLanguage());
%>
<link rel="stylesheet" type="text/css" href="jslib/jscalendar/calendar.css"  />
<link rel="stylesheet" type="text/css" href="css/${lan}/common_new_standard.css"  />
<script type="text/javascript" src="js/client_validate.js"></script>
<script type="text/javascript" src="jslib/jquery.js"></script>
<script type="text/javascript" src="jslib/jscalendar/calendar.js"></script>
<script type="text/javascript" src="jslib/jscalendar/calendar-zh.js"></script>
<script type="text/javascript" src="jslib/jscalendar/calendar-setup.js"></script>

