<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/logCommon.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>mop</title>
<script type="text/javascript">
$().ready(function(){
	$("input[name='logType']:first").attr("checked",true);
});

  function search(){
	  $("input[name='logType']:first").attr("checked",true);
	}
 
 
</script>
</head>
<body>
<form  method="post" action="genLog.do?action=genLog"
	onsubmit="return is_ok()">
<div id="man_zone">
<div id="nav">
<ul>
	<li id="man_nav_1" 	class="bg_image_onclick" >
		<%=lang.readGm(GMLangConstants.GEN_SEARCH)%>
  </li>
</ul>
</div>
<div id="sub_info">
<span id="show_text">&nbsp;&nbsp;<img
	src="images/hi.gif" />&nbsp;
<a href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>  
<a href="role.do?action=init&searchType=userId&searchValue=${roleId}" class="link"><%= lang.readGm(GMLangConstants.ROLE_MANAGE)%></a>
>><%= lang.readGm(GMLangConstants.ROLE_ID)%>:${roleId}
</span>
<span><%=lang.readGm(GMLangConstants.DATE)%>:
<input id="date" type="text" class="limitWidth" value="${date}"/>
<img id="dateImg" src="jslib/jscalendar/img.gif" />
<script type="text/javascript" language="javascript">
Calendar.setup(
	    {
	      inputField  : "date",         // ID of the input field
	      ifFormat    :  "%Y-%m-%d",       // format of the input field
	      showsTime   :  false,
	      timeFormat  :  "24",
	      onClose  :  function (cal){
		              if(cal.date>new Date()){
		            	  alert("<%=lang.readGm(GMLangConstants.DATE_ERR)%>");
			             }
	    	          cal.hide();
                     },
	      button   : "dateImg"     // ID of the button
	    }
    );

</script>
</span>
<input id="search" type="button"  style="margin-left: 1em;" value="<%= lang.readGm(GMLangConstants.COMMON_SEARCH)%>" onClick="javaScript:search();"/>
</div>
<div style="clear: both;" />

<table name='tab_1' class="detail"  cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
    <tr><td>
     <c:forEach items="${dataMap['logTypeSearch']}" var="logType" varStatus="count">
      <input  value="${logType.key}"  name="logType" type="radio">${language.readGm(logType.value)}
      <c:if test="${count.index%15 eq 15}"></br></c:if>
     </c:forEach>
    </td> 
    </tr>
    <tr>
    <td height="30" style="border-bottom: 0px;width: 100%;">
     <input  type="submit" value="<%=lang.readGm(GMLangConstants.COMMON_SEARCH)%>" >
    </td>
  </tr>
   </tbody>
</table>
</form>
<script type="text/javascript">
function is_ok(){
	if(is_null($("#roleID").val())==true){
		alert('<%= lang.readGm(GMLangConstants.ROLEID_NOT_NULL)%>');
		$("#roleID").focus();
		return false;
	}
	if(is_null($("#startTime").val())==true){
		alert('<%= lang.readGm(GMLangConstants.STARTTIME_NOT_NULL)%>');
		$("#startTime").focus();
		return false;
	}
	if(is_null($("#endTime").val())==true){
		alert('<%= lang.readGm(GMLangConstants.ENDTIME_NOT_NULL)%>');
		$("#endTime").focus();
		return false;
	}
	if($("#endTime").val()<=$("#startTime").val()){
		alert('<%= lang.readGm(GMLangConstants.END_MORE_START)%>');
		$("#endTime").focus();
		return false;
	}
	//日期差不能超过7天
	var start1=$("#startTime").val();
	var end1=$("#endTime").val();
	var start2=start1.split("-");
	var y=start2[0];
	if(start2[1].charAt(0)=='0'){
		start2[1]=start2[1].charAt(1);
	}
	var m=parseInt(start2[1]);
	if(start2[2].charAt(0)=='0'){
		start2[2]=start2[2].charAt(1);
	}
	var d=parseInt(start2[2]);
	var end2=end1.split("-");
	var yy=end2[0];
	if(end2[1].charAt(0)=='0'){
		end2[1]=end2[1].charAt(1);
	}
	var mm=parseInt(end2[1]);
	if(end2[2].charAt(0)=='0'){
		end2[2]=end2[2].charAt(1);
	}
	var dd=parseInt(end2[2]);
	var dt1=new Date(y,m-1,d);		//月用0-11代表
	var dt2=new Date(yy,mm-1,dd);
	var num=Math.floor((dt2-dt1)/(3600*24*1000));
	if(num>7){
		alert("<%=lang.readGm(GMLangConstants.DATE_LESS_SEVEN) %>");
		form1.end.focus();
		return false;
	}

	var ser_cont = 0;
    $("input[name='logType']").each(function(){
		var s_checked= $(this).attr("checked");
		if(s_checked){
			ser_cont=+1;
		}
      });
    if(ser_cont==0){
    	alert("<%= lang.readGm(GMLangConstants.CHOOSE_LOG_TYPE)%>");
    	return false;
     }
	return true;
}
</script>
</body>
</html>