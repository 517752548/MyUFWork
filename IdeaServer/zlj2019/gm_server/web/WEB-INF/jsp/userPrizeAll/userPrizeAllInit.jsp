<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/logCommon.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>mop</title>
<script type="text/javascript">
   $().ready(function(){
	   if("${reason}"==""){
		   $("#option-1").attr("selected","selected");
	   }else{
		   $("#option${reason}").attr("selected","selected");
	   }
	   var exist="${fail}";
	   if(exist=="false"){
		   window.location="userPrizeAll.do?action=init";
	   }
   });
  function goTo(i){
	  var passportId = $("#passportId").val();
	  var reason=$("#reason").val();
	  var date = $("#date").val();
	  var startTime=$("#startTime").val();
	  var endTime=$("#endTime").val();
	  window.location.href="userPrizeAll.do?action=init&currentPage="+i+"&passportId="+passportId+"&reason="+reason+"&startTime="+startTime+"&endTime="+endTime+"&date="+date;	
  }
  function search(){
	  var passportId = $("#passportId").val();
	  var reason=$("#reason").val();
	  var date = $("#date").val();
	  var startTime=$("#startTime").val();
	  var endTime=$("#endTime").val();
	  window.location.href="userPrizeAll.do?action=init&passportId="+passportId+"&reason="+reason+"&startTime="+startTime+"&endTime="+endTime+"&date="+date;	
  }
  function del(id){
	  var con= confirm("<%=lang.readGm(GMLangConstants.CONFRIM_DEL)%>?");
		if(con){
			var currentPage = $("#curPage").val();
			var date = $("#date").val();
			var startTime=$("#startTime").val();
			var endTime=$("#endTime").val();
			$.post("userPrizeAll.do?action=delUserPrize",{id:id},function(){
		        alert("<%=lang.readGm(GMLangConstants.DEL_SUCCESS)%>");
		        window.location="userPrizeAll.do?action=init&currentPage="+currentPage+"&startTime="+startTime+"&endTime="+endTime+"&date="+date;	
			  });	
		}
  }
  function selAll(but,name){
		var sel=$("#"+but+"").attr("checked");
		if(sel){
			$("#"+but+"").attr("checked",true);
			var checks=document.getElementsByName(name);
			for(var i=0;i<checks.length;i++){
				checks[i].checked=true;
			}
		}else{
			$("#"+but+"").attr("checked",false);
			var checks=document.getElementsByName(name);
			for(var i=0;i<checks.length;i++){
				checks[i].checked=false;
			}
		}		
	}
	function delChosen()
	{
		 var con= confirm("<%=lang.readGm(GMLangConstants.CONFRIM_DEL)%>?");
			if(con){
				var currentPage = $("#curPage").val();
				var date = $("#date").val();
				var startTime=$("#startTime").val();
				var endTime=$("#endTime").val();
				var ids = "";
				var checks=document.getElementsByName("prize");
				for(var i=0;i<checks.length;i++){
					if(checks[i].checked==false){
						continue;
					}else{
						ids += checks[i].value+"_";
					}
				}
				$.post("userPrizeAll.do?action=delUserPrize",{ids:ids},function(){
			        alert("<%=lang.readGm(GMLangConstants.DEL_SUCCESS)%>");
			        window.location="userPrizeAll.do?action=init&currentPage="+currentPage+"&startTime="+startTime+"&endTime="+endTime+"&date="+date;	
				});	
			}
	}
</script>
</head>
<body>
<div id="man_zone">
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>  
	<%=lang.readGm(GMLangConstants.GM_USER_PRIZE)%></div>
<div id="nav">
<ul>
	<li id="man_nav_1" 	class="bg_image_onclick" >
		<%=lang.readGm(GMLangConstants.USER_ID)%>
    </li>
</ul>
</div>
<div id="sub_info">&nbsp;&nbsp;<input id="passportId" type="text" class="limitWidth"  value="${passportId}"/>
<span>
<input id="date" type="text" class="limitWidth" value="${date}" /> <img
	id="dateImg" src="jslib/jscalendar/img.gif" /> <script
	type="text/javascript" language="javascript">
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

</script></span>
<span><%=lang.readGm(GMLangConstants.PRIZE_TYPE)%>:
<select id="reason">
<option id="option-1"  value="-1"><%= lang.readGm(GMLangConstants.REASON_ALL)%></option>
<% Map reasons= Mask.getMap("rolePrizeReason");
		for(Iterator i=reasons.keySet().iterator();i.hasNext();){
			int key=(Integer)i.next();
			Integer value=(Integer)reasons.get(key);
		%>
	<option id="option<%=key%>"  value="<%=key%>"><%= lang.readGm(value)%></option>
	<%}%>
</select>
<span><%=lang.readGm(GMLangConstants.START_TIME)%>: <input
	id="startTime" name="startTime" value="${startTime}" class="time_gap" />
<img id="startTimeImg" src="jslib/jscalendar/img.gif" /> <script
	type="text/javascript" language="javascript">
$('#startTimeImg').timepicker({
    defaultTime: new Date()
});
</script> <%=lang.readGm(GMLangConstants.END_TIME)%>: <input id="endTime"
	name="endTime" value="${endTime}" class="time_gap" /> <img
	id="endTimeImg" src="jslib/jscalendar/img.gif" /> <script
	type="text/javascript" language="javascript">
$('#endTimeImg').timepicker({
    defaultTime: new Date()
});
</script> </span> 
<input id="search" type="button"  style="margin-left: 1em;" value="<%= lang.readGm(GMLangConstants.COMMON_SEARCH)%>" onClick="javaScript:search();"/>
<input id="deleteSelected" type="button"  style="margin-left: 1em;" value="<%= lang.readGm(GMLangConstants.DELETE_CHOSEN)%>" onClick="javaScript:delChosen();"/>
</div>
<div class="nofloat" />
<table name='tab_1' class="detail"  cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
		<tr>
		 <th><span onclick="selAll('allPrize','prize')" ><%=lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%>
		<input type="checkbox" id="allPrize" />
		</span> </th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.ID)%></th>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.USER_PRIZE_NAME)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.USER_ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.GM_PRIZE_CHAR_ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.C_MONEY)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.ITEM)%></th>
	     <th>&nbsp;<%=lang.readGm(GMLangConstants.GM_PRIZE_ITEM_PARAMS)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.PRIZE_REASON)%></th>
	     <th>&nbsp;<%=lang.readGm(GMLangConstants.PRIZE_TIME)%></th>
	     <th>&nbsp;<%=lang.readGm(GMLangConstants.GM_PRIZE_EXPIRE_TIME)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.GET_STATUS)%></th>
		 <c:if test="${DBType eq 1}">
         	<th>&nbsp;<%=lang.readGm(GMLangConstants.COMMON_OPERATION)%>
			<img class="pointer" title="<%=lang.readGm(GMLangConstants.NEW_ADD)%>" src="images/add.gif" onclick="javaScript:window.location='userPrizeAll.do?action=addUserPrizeInit'"/>
			</th>
		</c:if>
		</tr>
     <c:forEach items="${userPrizelist}" var="userPrizeVo">
        <tr>
		 <td>&nbsp;<input type="checkbox" name="prize" value="${userPrizeVo.userPrize.id}"></td>
		 <td>&nbsp;${userPrizeVo.userPrize.id}</td>
         <td>&nbsp;${userPrizeVo.userPrize.userPrizeName}</td>
		 <td>&nbsp;${userPrizeVo.userPrize.passportId}</td>
		 <td>&nbsp;${userPrizeVo.userPrize.charId}</td>
         <td>&nbsp;${userPrizeVo.formatCoin}</td>
         <td>&nbsp;${userPrizeVo.formatItem}</td>
         <td>&nbsp;${userPrizeVo.userPrize.itemParams}</td>
 		 <td>&nbsp;
 		 	<c:forEach items="${dataMap['rolePrizeReason']}" var="rolePrizeReason" >
             		<c:if test="${rolePrizeReason.key eq userPrizeVo.userPrize.type}"><c:out value="${language.readGm(rolePrizeReason.value)}" /></c:if>
         	</c:forEach>
		 </td>
		 <td>&nbsp;<fmt:formatDate pattern="yyyy-MM-dd HH:mm" value="${userPrizeVo.userPrize.createTime}" /></td>
		  <td>&nbsp;<fmt:formatDate pattern="yyyy-MM-dd HH:mm" value="${userPrizeVo.userPrize.expireTime}" /></td>
         <td>&nbsp;
			<c:choose>
				<c:when test="${userPrizeVo.userPrize.status eq 0}">
					<%=lang.readGm(GMLangConstants.NO_GET)%>
				</c:when>
				<c:when test="${userPrizeVo.userPrize.status eq 1}">
					<%=lang.readGm(GMLangConstants.GETED)%>
				</c:when>
			</c:choose>
        </td>
		<c:if test="${DBType eq 1}">
			 <td> 
				<img class="pointer" title="<%=lang.readGm(GMLangConstants.COMMON_DELETE)%>"  src="images/b_drop.png" onclick="javaScript:del('${userPrizeVo.userPrize.id}');"/>
	         </td>
		 </c:if> 	
		</tr>
     </c:forEach>
     <tr>
    <td height="30" colspan="13" style="border-bottom: 0px;width: 100%;">
     <div id="num_style"></data></div>
    </td>
  </tr>
   </tbody>
</table>
</body>
</html>