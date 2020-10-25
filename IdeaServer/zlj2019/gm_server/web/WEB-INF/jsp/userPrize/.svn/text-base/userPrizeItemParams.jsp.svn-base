<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title></title>
</head>
<script type="text/javascript">
	
</script>

<body>
<div id="man_zone">
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>>><%= lang.readGm(GMLangConstants.ACT_AND_NOTICE) %>>><%= lang.readGm(GMLangConstants.ITEM_CREATE_TITLE) %>
</div>
<br/>
<c:choose>
<c:when test="${error_msg ne null}">
<span id="error_msg" class="error_msg">${error_msg}</span>
</c:when>
</c:choose>
<br/>
<div class="nofloat"/>
<form action="userPrize.do?action=addUserItemWithParams" method="post">
<input type="hidden" id="attrAStr" name="attrAStr" value=""/>
<input type="hidden" id="attrBStr" name="attrBStr" value=""/>
<table cellspacing="" class="welcome" style="width: 90%;margin-left: 2em;" cellpadding="20" >
	<tr>
		<td colspan="4" class="header"><%=lang.readGm(GMLangConstants.ITEM_CREATE_TITLE)%></td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.PRIZE_REASON)%></td>
        <td>
		<select id="reason" name="reason">
			<% Map reasons = Mask.getMap("rolePrizeReason1");
				for(Iterator<Integer> i= reasons.keySet().iterator();i.hasNext();){
				int key = i.next();
				Integer value=(Integer)reasons.get(key);
			%>
			<option id="option<%=key%>"  value="<%=key%>"><%= lang.readGm(value)%></option>
			<%}%>
		</select>
		</td>
        <td class="label"><%=lang.readGm(GMLangConstants.USER_PRIZE_NAME)%></td>
        <td> <input id="userPrizeName" name="userPrizeName"/></td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.ITEM_CHARID)%></td>
		<td><input type="text" id="roleId" name="roleId" onkeypress="if((event.keyCode<48 || event.keyCode>57))event.returnValue=false"/></td>
		<td class="label"><%=lang.readGm(GMLangConstants.USER_ID)%></td>
		<td><input type="text" id="passportId" name="passportId" onkeypress="if((event.keyCode<48 || event.keyCode>57))event.returnValue=false"/></td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.ITEM_TEMPLATE_ID)%></td>
		<td><input type="text" id="templateId" name="templateId" onkeypress="if((event.keyCode<48 || event.keyCode>57))event.returnValue=false"/></td>
	
		<td class="label"><%=lang.readGm(GMLangConstants.ITEM_CREATE_NUM)%></td>
		<td><input type="text" id="itemCount" name="itemCount" onkeypress="if((event.keyCode<48 || event.keyCode>57))event.returnValue=false"/>
		</td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.ITEM_ENHANCE_LEVEL)%></td>
		<td><input type="text" id="enhanceLevel" name="enhanceLevel" onkeypress="if((event.keyCode<48 || event.keyCode>57))event.returnValue=false"/>
		</td>
		<td class="label"><%=lang.readGm(GMLangConstants.ITEM_FUMO_LEVEL)%></td>
		<td><input type="text" id="fumoLevel" name="fumoLevel" onkeypress="if((event.keyCode<48 || event.keyCode>57))event.returnValue=false"/>
		</td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.ITEM_HOLE_NUM)%></td>
		<td><input type="text" id="holeCount" name="holeCount" onkeypress="if((event.keyCode<48 || event.keyCode>57))event.returnValue=false"/>
		</td>
		<td class="label"><%=lang.readGm(GMLangConstants.ITEM_SKILL_ID)%></td>
		<td><input type="text" id="skillId" name="skillId" onkeypress="if((event.keyCode<48 || event.keyCode>57))event.returnValue=false"/></td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.ITEM_A_ATTR_PROP)%></td>
		<td colspan="3">
			<table class="ATable" id="attrATable" style="width: 100%;">
				<tr>
					<td colspan="3" >
					<span onclick="selAllA('AAttrPropSelect','attr1')">
						<input type="checkbox" id="AAttrPropSelect"/><%=lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%>
					</span>
					</td>
				</tr>
				<c:forEach items="${dataMap['itemAAttrs']}" var="attrA">
				<tr>
					<td colspan="1">
			 		<input type="checkbox" id=a${attrA.key} name="attr1" value="${attrA.key}"/>${attrA.value}
			 		&nbsp;&nbsp;:&nbsp;&nbsp;
			 		</td>
			 		<td colspan="2">
			 			<input type="text" id=a${attrA.key} name="attr1" 
			 			onkeyup="return validateMax(this, value)"/>
			   		</td>
			   	</tr>
	            </c:forEach>
	        </table>
		</td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.ITEM_B_ATTR_PROP)%></td>
		<td colspan="3">
			<table class="BTable" id="attrBTable" style="width: 100%;">
				<tr>
					<td colspan="3">
					<span onclick="selAllB('BAttrPropSelect','attr2')">
						<input type="checkbox" id="BAttrPropSelect" /><%=lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%>
					</span>
					</td>
				</tr>
				<c:forEach items="${dataMap['itemBAttrs']}" var="attrB">
				<tr>
					<td colspan="1">
				   	<input type="checkbox" id=b${attrB.key} name="attr2" value="${attrB.key}" />${attrB.value}
				   	&nbsp;&nbsp;:&nbsp;&nbsp;
				   	</td>
				   	<td colspan="2">
				    <input type="text" id=b${attrB.key} name="inputattr2" 
				    	onkeyup="return validateMax(this, value)"/>
				    </td>
			   </tr>
	            </c:forEach>
	        </table>
		</td>
	</tr>
<!-- 	<tr> -->
<%-- 		<td class="serverLabe"><%=lang.readGm(GMLangConstants.COMMON_SERVER)%></td> --%>
<!-- 		<td> -->
<%-- 			<c:forEach items="${serverList}" var="s"> --%>
<%-- 			   <input id="sId" name="sId" type="checkbox" value="${s.id}"/> --%>
<%-- 				${s.dbServerName} --%>
<%--                 </c:forEach>  --%>
<!-- 		</td> -->
<!-- 	</tr> -->
    <tr>
		<td class="oplabel"><%=lang.readGm(GMLangConstants.COMMON_OPERATION)%></td>
		<td colspan="3">
<!-- 		<input class="butcom" type="button" id="selectAll" onclick="javascript:hh();" -->
<%--            value="<%=lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%><%=lang.readGm(GMLangConstants.COMMON_SERVER)%>"/> --%>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input class="butcom" type="submit" onclick="return is_ok();" value="<%=lang.readGm(GMLangConstants.COMMON_SUBMIT)%>"/>
        </td>
	</tr>
</table>
</form>
</div>

<script type="text/javascript">
     function hh(){
       var selAll = $("#selectAll").attr("selAll");
       if(selAll=="false"){
            $("input[name=sId]").each(function(){
                 $(this).attr("checked",false);
              });
            $("#selectAll").attr("selAll","true");
            $("#selectAll").val("<%=lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%><%=lang.readGm(GMLangConstants.COMMON_SERVER)%>");  
        }else{
      	  $("input[name=sId]").each(function(){
                $(this).attr("checked",true);
             });
      	    $("#selectAll").attr("selAll","false");
      	    $("#selectAll").val("<%=lang.readGm(GMLangConstants.COMMON_SElECT_NONE)%><%=lang.readGm(GMLangConstants.COMMON_SERVER)%>");  
          }
       }
   
     function is_ok(){
 		//角色id
 		if(is_null($("#roleId").val())){
 			alert('<%=lang.readGm(GMLangConstants.ROLEID_NOT_NULL)%>');
 			return false;
 		}
 		//templateId
 		if(is_null($("#templateId").val())){
 			alert('<%=lang.readGm(GMLangConstants.ITEM_TEMPLATE_NOT_NULL)%>');
 			return false;
 		}
 		//itemCount
 		if(is_null($("#itemCount").val()) || $("#itemCount").val() <= 0){
 			alert('<%=lang.readGm(GMLangConstants.ITEM_COUNT_NOT_NULL)%>');
 			return false;
 		}
 		
 		//服务器
//  		var svr="";
// 		 $("input[name=sId]").each(function(){
//                var svrChecked = $(this).attr("checked");
//                if(svrChecked==true){
//              	  svr+=$(this).val();
//                  }
//            });
//  		if(svr==""){
<%--  			alert('<%=lang.readGm(GMLangConstants.CMD_NSERVER_ALERT)%>'); --%>
// 			    return false;
// 		}
 		// 生成属性a串
 		var attrAStr = "";
 		var attrValue = 0;
 		var tableInputs = document.getElementById("attrATable").getElementsByTagName("input");
 		for(var i = 0; i< tableInputs.length; i++) {
 			if( tableInputs[i].type == "checkbox" && tableInputs[i].checked ) {
 				if(attrAStr.length > 0) {
 	 				attrAStr+=",";
 	 			}
 				attrAStr += tableInputs[i].value+","+tableInputs[i+1].value;
 			}
		}
 		document.getElementById("attrAStr").value = attrAStr;
 		
 		// 生成属性a和属性b的串
 		var attrBStr = "";
 		var tableBInputs = document.getElementById("attrBTable").getElementsByTagName("input");
 		for(var i = 0; i< tableBInputs.length; i++) {
 			if( tableBInputs[i].type == "checkbox" && tableBInputs[i].checked ) {
 				if(attrBStr.length > 0) {
 	 				attrBStr+=",";
 	 			}
 				attrBStr+=tableBInputs[i].value+","+tableBInputs[i+1].value;
 			}
		}
 		document.getElementById("attrBStr").value = attrBStr;
 		
		return true;
	}
     
    function selAllA(but,name) {
    	var selectAll= $("#"+but+"").attr("checked");
	   	if(selectAll==true) {
	   		$("input[name^='attr1']").each(function(){
	   			$(this).attr("checked",true);
	   			});
	   	 } else {
	   		$("input[name^='attr1']").each(function(){
	   	 		$(this).attr("checked",false);
	   	       });
	   	 }
   }
   
   function selAllB(but,name) {
	   var selectAll= $("#"+but+"").attr("checked");
       if(selectAll==true){
    	   $("input[name^='attr2']").each(function(){
      			$(this).attr("checked",true);
             });
     	 }else{
     		 $("input[name^='attr2']").each(function(){
     	 			$(this).attr("checked",false);
     	        });
     	 }
    }
   
   function validateMax(e, number) {
	   if(is_int(number)==false) {
		   alert('<%= lang.readGm(GMLangConstants.USERID_IS_NUM)%>');
		   e.focus();
		   return false;
	   }
	   if(number > 2100000000) {
		   alert('<%= lang.readGm(GMLangConstants.ADD_PRIZE_MAX_TOO_MUCH)%>');
		   e.focus();
		   return false;
	   }
		return true;	   
   }
</script>

</body>


</html>