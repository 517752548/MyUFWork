<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title></title>
<script type="text/javascript">
function list_sub_nav(Id,sortname){
	$("li[id^='man_nav']").each(function(){
    	  $(this).attr("class","bg_image");
     });
   if($("#"+Id).attr("class")=="bg_image"){
	   $("#"+Id).attr("class","bg_image_onclick");
   }
   showInnerText(Id);
}

function showInnerText(Id){
    var switchId = parseInt(Id.substring(8));
	var showText = "";
	switch(switchId){
	    case 1:
		   break;
	}
}

function search(){
	window.location.href="shopmall.do?action=init"
}
function goTo(i){
    var url=window.location.toString().split("&");
	window.location.href=url[0]+'&currentPage='+i;
}
function jumpTo(){
	var pno=$("#pno").val();
	if(is_int(pno)==false){
	alert('<%= lang.readGm(GMLangConstants.INTERVAL_NOT_NEG)%>');
		$("#pno").focus();
		return false;
	}
	goTo(pno);
}

function setSellTime(type,itemId)
{
	var confirmMsg = "";
	
	if(type == "onsell"){
		confrimMsg = "<%=lang.readGm(GMLangConstants.CONFIRM_SETONSELLTIME)%>?";
	}
	else if(type == "offsell"){
		confrimMsg = "<%=lang.readGm(GMLangConstants.CONFIRM_SETOFFSELLTIME)%>?";
	}
	else if(type == "nowonsell"){
		confrimMsg = "<%=lang.readGm(GMLangConstants.CONFIRM_NOW_ONSELL)%>?";
	}
	else if(type == "nowoffsell"){
		confrimMsg = "<%=lang.readGm(GMLangConstants.CONFIRM_NOW_OFFSELL)%>?";
	}
	else{
		return;
	}
	var con = confirm(confrimMsg);
	if(con){
		var currentPage = $("#curPage").val();

		var sellTime = $("#"+itemId).val();

		$.post("shopmall.do?action=setSellState",{type:type,itemId:itemId,sellTime:sellTime,},function(data){
			alert(data);
	        window.location="shopmall.do?action=init&currentPage="+currentPage;	
		});	
	}
}
</script>
</head>
<body>

<div id="man_zone">

<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>&gt;&gt;
<%= lang.readGm(GMLangConstants.ACT_AND_NOTICE) %>&gt;&gt;
<%= lang.readGm(GMLangConstants.ITEM_ONSELL) %>
</div>

<table class="detail"  cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
		<tr>
			<th><%=lang.readGm(GMLangConstants.COMMON_SERVER)%></th>
			<th><%=lang.readGm(GMLangConstants.ITEM_ID)%></th>
			<th><%=lang.readGm(GMLangConstants.ITEM_NAME)%></th>
			<th><%=lang.readGm(GMLangConstants.LAST_UPDATETIME)%></th>
			<th><%=lang.readGm(GMLangConstants.NUM)%></th>
			<th><%=lang.readGm(GMLangConstants.NOW_STATE)%></th>
			<th><%=lang.readGm(GMLangConstants.ONOFFSELLTIME)%></th>
			<th colspan="2"><%=lang.readGm(GMLangConstants.ORDER)%></th>
			<th colspan="2"><%=lang.readGm(GMLangConstants.COMMON_OPERATION)%></th>
		</tr>
		<c:forEach items="${shopmallList}" var="shopmall">
			<tr>
				<td>&nbsp;${serverName}</td>
				<td>&nbsp;${shopmall.id}</td>
				<td>&nbsp;${shopmall.name}</td>
				<td>&nbsp;<fmt:formatDate pattern="yyyy-MM-dd HH:mm:ss" value="${shopmall.updateTime}" /></td>
				<td>&nbsp;
					<c:choose>
					    <c:when test="${shopmall.count < 0}">
			            	<%=lang.readGm(GMLangConstants.NOTCONTROL)%>
			            </c:when>
			           	<c:otherwise>
			           		${shopmall.count}
	          		 	</c:otherwise>
			         </c:choose>
				</td>
				<td>&nbsp;
					<c:choose>
					    <c:when test="${shopmall.sell eq 1}">
			            	<%=lang.readGm(GMLangConstants.OFFSELL_STATE)%>
			            </c:when>
			            <c:when test="${shopmall.sell eq 2}">
			           		<%=lang.readGm(GMLangConstants.ONSELL_STATE)%>
			           	</c:when>
			           	<c:otherwise>
			           		${shopmall.sell}
	          		 	</c:otherwise>
			         </c:choose>
         		</td>
				<td>&nbsp;
					<span>
					<input id="${shopmall.id}" type="text" class="limitWidth" /> 
					</span>
				</td>
				<td>&nbsp;
					<input  class="butcom" type="button" onclick="setSellTime('onsell',${shopmall.id});" value="<%=lang.readGm(GMLangConstants.ONSELL_ORDER)%>"/>
				</td>
				<td>&nbsp;
					<input  class="butcom" type="button" onclick="setSellTime('offsell',${shopmall.id});" value="<%=lang.readGm(GMLangConstants.OFFSELL_ORDER)%>"/>
				</td>
				<td>&nbsp;
					<input  class="butcom" type="button" onclick="setSellTime('nowonsell',${shopmall.id});" value="<%=lang.readGm(GMLangConstants.NOW_ONSELL)%>"/>
				</td>
				<td>&nbsp;
					<input  class="butcom" type="button" onclick="setSellTime('nowoffsell',${shopmall.id});" value="<%=lang.readGm(GMLangConstants.NOW_OFFSELL)%>"/>
				</td>
			</tr>
		</c:forEach>
    <tr>
	   <td id="num_style" height="30" colspan="25" style="border-bottom: 0px;text-align:right;">
	     </data>
	   	</td>
  </tr>
	</tbody>
</table>
</div>
<script type="text/javascript" language="javascript">
var list = document.getElementsByTagName("input");
for(var i=0;i<list.length && list[i];i++){
	if(list[i].type == "text"){
		Calendar.setup(
			    {
			      inputField  :  list[i].id,         // ID of the input field
			      ifFormat    :  "%Y-%m-%d %H:%M",       // format of the input field
			      showsTime   :  false,
			      timeFormat  :  "24",
			      button   : "dateImg"     // ID of the button
			    }
		);
	}
}

</script>
</body>
</html>