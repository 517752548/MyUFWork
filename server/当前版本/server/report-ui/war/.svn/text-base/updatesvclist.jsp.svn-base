<%@page import="java.text.SimpleDateFormat"%>
<%@page import="java.text.DateFormat"%>
<%@page import="java.util.Date"%>
<%@page import="com.opi.gibp.tools.performance.utils.db.DbHelper"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>

<%
	String TABLE_SUFFIX = request.getParameter("table");

	if(TABLE_SUFFIX == null || "".equals(TABLE_SUFFIX)){
		DateFormat formatter = new SimpleDateFormat("yyyyMM");
		Date currentDate = new Date();
		TABLE_SUFFIX = "_" + formatter.format(currentDate);
	}
	
	String insertSvcListSQL = "INSERT INTO svclist(gameid,svrid,svcid,svc_type) ";
	String selectCond = "SELECT DISTINCT gameid,svrid,svcid,svc_type FROM perf" + TABLE_SUFFIX 
	+ " WHERE CONCAT(gameid,'##',svrid,'##',svcid,'##',svc_type) NOT IN " 
	+ "(SELECT CONCAT(gameid,'##',svrid,'##',svcid,'##',svc_type) FROM svclist)";
	
	String _SQL = insertSvcListSQL + selectCond;

	out.println(_SQL + "<br/><br/>");
	try{
		DbHelper.UpdataBySQL(_SQL);
		
		out.println("SUCCESS!!!");
			
	}catch(Exception e){
		out.println("请确认是否存在后缀为_" + TABLE_SUFFIX + "的表." );
		out.print(e.toString());
	}
%>

<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>update</title>
</head>
<body>

</body>
</html>