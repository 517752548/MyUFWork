<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
</head>
<body>
<form action="regionSYN.do?action=synchronize" method="post">
<div id="man_zone">
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>>><%= lang.readGm(GMLangConstants.COMMON_REGION)%><%= lang.readGm(GMLangConstants.SYN)%>
</div>
<br/>
<c:choose>
<c:when test="${error_msg ne null}">
<span id="error_msg" class="error_msg">${error_msg}</span>
</c:when>
</c:choose>

<br/>
<div class="nofloat" />
<table cellspacing="" class="welcome" style="width: 40%;margin-left: 1em;" cellpadding="20" >
	<tr>
		<td colspan="2" class="header"><%= lang.readGm(GMLangConstants.COMMON_REGION)%><%= lang.readGm(GMLangConstants.SYN)%></td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.SYN)%><%=lang.readGm(GMLangConstants.CONTENT)%></td>
		<td>

			<input id="content1" name="content" type="checkbox" value="1"><%=lang.readGm(GMLangConstants.WEL_TIME_NOTICE)%>&nbsp;&nbsp;
			<!-- <input id="content2" name="content" type="checkbox" value="2"><%=lang.readGm(GMLangConstants.GAME)%><%=lang.readGm(GMLangConstants.NOTICE) %>&nbsp;&nbsp; -->
			<input id="content3" name="content" type="checkbox" value="3"><%=lang.readGm(GMLangConstants.PRIZE)%>&nbsp;&nbsp;
			<!-- 
			<input id="content4" name="content" type="checkbox" value="4"><%=lang.readGm(GMLangConstants.ACTIVITY)%>&nbsp;&nbsp;
			 -->
		</td>
	</tr>
	<tr>
		<td class="label"><%= lang.readGm(GMLangConstants.COMMON_REGION)%><%= lang.readGm(GMLangConstants.SYN)%></td>
		<td><c:forEach items="${s1List}" var="dbServer">
				  <input id="rId" name="rId" type="checkbox" value="${dbServer.regionId}"/>
				   ${dbServer.regionName}
            </c:forEach>
		</td>
	</tr>
	 <tr>
			<td class="label red"><%= lang.readGm(GMLangConstants.ATTENTIONS)%>:</td>
			<td class="label red"><%= lang.readGm(GMLangConstants.REGION_SYN_S1)%></td>
		</tr>    
    <tr>
		<td class="label"><%=lang.readGm(GMLangConstants.COMMON_OPERATION)%></td>
		<td>
		<input class="butcom" type="button" id="selectAllContent" onclick="javascript:selectContent();"
           value="<%=lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%><%=lang.readGm(GMLangConstants.CONTENT)%>"/>	&nbsp;&nbsp;
		<input class="butcom" type="button" id="selectAll" onclick="javascript:hh();"
           value="<%=lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%><%=lang.readGm(GMLangConstants.COMMON_REGION)%>"/>
        <input id="subBut"  class="butcom" type="submit" onclick="return is_ok();" value="<%=lang.readGm(GMLangConstants.SYN)%>"/></td>
	</tr>
</table>

</div>
</form>
<script type="text/javascript">
     function hh(){
       var selAll = $("#selectAll").attr("selAll");
       if(selAll=="false"){
            $("input[name=rId]").each(function(){
                 $(this).attr("checked",false);
              });
            $("#selectAll").attr("selAll","true");
            $("#selectAll").val("<%=lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%><%=lang.readGm(GMLangConstants.COMMON_REGION)%>");  
        }else{
      	  $("input[name=rId]").each(function(){
                $(this).attr("checked",true);
             });
      	    $("#selectAll").attr("selAll","false");
      	    $("#selectAll").val("<%=lang.readGm(GMLangConstants.COMMON_SElECT_NONE)%><%=lang.readGm(GMLangConstants.COMMON_REGION)%>");  
          }
       }

     function selectContent(){
         var selectAllContent = $("#selectAllContent").attr("selectAllContent");
         if(selectAllContent=="false"){
              $("input[name=content]").each(function(){
                   $(this).attr("checked",false);
                });
              $("#selectAllContent").attr("selectAllContent","true");
              $("#selectAllContent").val("<%=lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%><%=lang.readGm(GMLangConstants.CONTENT)%>");  
          }else{
        	  $("input[name=content]").each(function(){
                  $(this).attr("checked",true);
               });
        	    $("#selectAllContent").attr("selectAllContent","false");
        	    $("#selectAllContent").val("<%=lang.readGm(GMLangConstants.COMMON_SElECT_NONE)%><%=lang.readGm(GMLangConstants.CONTENT)%>");  
            }
         }
     
     function is_ok(){
         //内容
    	 var content="";
 		 $("input[name=content]").each(function(){
               var contentChecked = $(this).attr("checked");
               if(contentChecked==true){
            	   content+=$(this).val();
                 }
           });
 		if(content==""){
 			alert('<%=lang.readGm(GMLangConstants.CMD_NCONTENT_ALERT)%>');
			    return false;
		      }
 		//服务器
 		var svr="";
 		 $("input[name=rId]").each(function(){
               var svrChecked = $(this).attr("checked");
               if(svrChecked==true){
             	  svr+=$(this).val();
                 }
           });
 		if(svr==""){
 			alert('<%=lang.readGm(GMLangConstants.CMD_NSERVER_ALERT)%>');
			    return false;
		   }
	    //$("#subBut").attr("disabled",true); 
		return true;
	}
</script>

</body>
</html>