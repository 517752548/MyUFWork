<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
</head>
<body>
<div id="man_zone">
<div class="topnav">
<a href="homePage.do?action=welcome"><%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>>>
<%=lang.readGm(GMLangConstants.TURNTABLE_ACTIVITY_DESC)%>

</div>

<div><font color="#ff0000" size=5><%=lang.readGm(GMLangConstants.QQ_MARKETTASK_DESC)%></font></div>

<table class="detail" cellspacing="0" cellpadding="0" border="0" >
	<tbody>
		<tr>
		<th width="5%"><%=lang.readGm(GMLangConstants.TASK_ID)%></th>
		 <th width="10%"><%=lang.readGm(GMLangConstants.DESCRIBE)%></th>
		 <th width="5%"><%=lang.readGm(GMLangConstants.QQ_MARKETTASK_ID)%></th>
		 <th width="10%"><%=lang.readGm(GMLangConstants.QQ_MARKETTASK_TARGET)%></th>
 		 <th width="10%"><%=lang.readGm(GMLangConstants.QQ_MARKETTASK_PARAM1)%></th>
 		  <th width="10%"><%=lang.readGm(GMLangConstants.QQ_MARKETTASK_PARAM2)%></th>
 		  <th width="10%"><%=lang.readGm(GMLangConstants.QQ_MARKETTASK_PARMA3)%></th>
		</tr>
    
    	<c:forEach items="${mobileActivityShow.targetList}" var="targetInfo">
    	
    		<tr>
    		<td rowspan=2>&nbsp;${targetInfo.cid}</td>
    		<td align="left">&nbsp;${targetInfo.ctarget.step2TargetDesc}</td>
	        <td>&nbsp;${targetInfo.ctarget.step2Id}</td>
	        <td>&nbsp;${targetInfo.ctarget.step2Target}</td>
	        <td>&nbsp;${targetInfo.ctarget.step2param1}</td>
	        <td>&nbsp;${targetInfo.ctarget.step2param2}</td>
	        <td>&nbsp;${targetInfo.ctarget.step2param3}</td>
			</tr>
			
			<tr>
	        <td align="left">&nbsp;${targetInfo.ctarget.step3TargetDesc}</td>
	        <td>&nbsp;${targetInfo.ctarget.step3Id}</td>
	        <td>&nbsp;${targetInfo.ctarget.step3Target}</td>
	        <td>&nbsp;${targetInfo.ctarget.step3param1}</td>
	        <td>&nbsp;${targetInfo.ctarget.step3param2}</td>
	        <td>&nbsp;${targetInfo.ctarget.step3param3}</td>
			</tr>
			
    	</c:forEach>
        
      <tr>
       <td height="30" colspan="30" style="border-bottom: 0px;">
     		<input  class="butcom" type="button" value="<%= lang.readGm(GMLangConstants.EDIT)%>" onClick="insertMobileActivity();"/></td>
    	</td>
      </tr>
    <tr>
    <td height="30" colspan="30" style="border-bottom: 0px;">
     <jsp:include page="../page.jsp"></jsp:include>
    </td>
  </tr>
   </tbody>
</table>
</div>
<script type="text/javascript">

    
function insertMobileActivity(){
	window.location.href="qqMarketTaskTarget.do?action=updateMobileActivity&id="+"${mobileActivityShow.id}";
}
function forceClose(id) {
	
}
</script>
</body>
</html>