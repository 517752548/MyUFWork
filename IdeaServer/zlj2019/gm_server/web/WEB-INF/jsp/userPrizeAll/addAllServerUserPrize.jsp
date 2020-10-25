<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<%@ page import="com.imop.lj.gm.config.GmConfig"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
<script type="text/javascript" src="jslib/jquery.js"></script>
<script type="text/javascript">
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

   function hiCurrency(){
	   var selected = document.getElementById("currency");
	   var optionText = selected.options[selected.selectedIndex].text;
	   if("金币" == optionText){
		   document.getElementById("hiSpan").innerHTML= "";
	   } else {
		   document.getElementById("hiSpan").innerHTML= optionText;
	   }
   }
   
</script>
</head>
<body onload="hiCurrency()">
<c:if test="${fail eq true}">
	<script type="text/javascript">
		alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
	</script>
</c:if>
<c:if test="${exist eq true}">
	<script type="text/javascript">
		alert("<%=lang.readGm(GMLangConstants.USER_EXIST)%>");
	</script>
</c:if>

<div id="man_zone">
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>
<a class="link" href="userPrizeAll.do?action=init"><%=lang.readGm(GMLangConstants.GM_USER_PRIZE_ALL_SERVER)%></a>>><%=lang.readGm(GMLangConstants.NEW_ADD)%></div>
<div style="clear: both;"></div>
<form  method="post" name="form1" action="userPrizeAll.do?action=addUserPrize" onsubmit="return is_ok();">
<table name='tab_1' class="detail" style="width:50%;" cellspacing="0" cellpadding="0" border="0">
	<tbody>
		<tr>
			<td colspan="4" class="header"><%=lang.readGm(GMLangConstants.GM_USER_PRIZE)%></td>
		</tr>
		<tr>
			<td class="label"><%=lang.readGm(GMLangConstants.PRIZE_REASON)%></td>
            <td>
			<select id="reason" name="reason">
				<% Map reasons= Mask.getMap("rolePrizeAllServerReason");
					for(Iterator i=reasons.keySet().iterator();i.hasNext();){
					int key=(Integer)i.next();
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
			<td class="label"><%=lang.readGm(GMLangConstants.CMD_NSERVER_ALERT)%>
			<span onclick="selAll('allSId','sId')" ><%=lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%>
			<input type="checkbox" id="allSId" />
			</td>
			<td colspan="3"><span onclick="selectAll()" >
             <c:forEach items="${serverIds}" var="s">
			   <input id="sId" name="sId" type="checkbox" value="${s.id}"/>
				${s.dbServerName}
                </c:forEach> 
             </td>
		</tr>
		<tr>
			<td class="label"><%= lang.readGm(GMLangConstants.PRIZE_COIN)%>
			</td>
			<td colspan="3">
				<% Map currency1 = Mask.getMap("ljCurrency");
					for(Iterator i=currency1.keySet().iterator();i.hasNext();){
						int key=(Integer)i.next();
						if(key == -1){
							continue;
						}
						Integer value=(Integer)currency1.get(key);
				%>
				<%=lang.readGm(value) %>
				
				<input id="currency<%=key %>" name="currency<%=key %>"/><br/>
				
				<%
					}					
				%>
			</td>
		</tr>
		<tr>
			<td class="label"><%= lang.readGm(GMLangConstants.ITEM_FMT)%>
			</td>
			<td colspan="3" ><textarea id="item" cols="80" rows="5" name="item"></textarea></td>
		</tr>
		<tr>
			<td colspan="4"  class="bottom">
				<input class="butcom" id="submitBtn" name="submitBtn" type="submit" value="<%= lang.readGm(GMLangConstants.COMMON_SUBMIT)%>" /> 
				<span style="padding: 10px;" />
				<input id="reset" type="reset" class="butcom" value="<%= lang.readGm(GMLangConstants.RESET)%>" />
            	<span style="padding: 10px;" />
            	<input id="return" type="button" class="butcom"	value="<%= lang.readGm(GMLangConstants.RETURN)%>"  onclick="javaScript:window.location='userPrizeAll.do?action=init';"/>
           </td>
		</tr>
	</tbody>
</table>
</form>
</div>
<script type="text/javascript">
function is_ok(){
	
	var userPrizeName = $.trim($("#userPrizeName").val());
	if(is_null(userPrizeName)==true){
		alert('<%= lang.readGm(GMLangConstants.USER_PRIZE_NAME_NOT_NULL)%>');
		$("#userPrizeName").focus();
		return false;
	}
	//选择服务器
	var ser_cont = 0;
	var sIds="";
    $("input[name='sId']").each(function(){
		var s_checked= $(this).attr("checked");
		if(s_checked){
			sIds+=$(this).val()+",";
			ser_cont=+1;
		}
      });
    sIds=sIds.substr(0,sIds.length-1);
    $("#serIds").val(sIds);
    if(ser_cont==0){
    	alert("<%=lang.readGm(GMLangConstants.CMD_NSERVER_ALERT)%>");
    	return false;
     }
	var coinNum = $.trim($("#coinNum").val());
	if(is_null(coinNum)==false){
		var pattern=/^([0-9]+)$/;
		if(!pattern.test(coinNum)){
			alert("<%= lang.readGm(GMLangConstants.COIN_NUM_WRONG)%>");
			return false;
		}
		var  coinType = $.trim($("#currency").val());
		if(coinType==2){
			if(coinNum<=0||coinNum>${goldNum}){
				alert("<%= lang.readGm(GMLangConstants.GOLD_NUM_WRONG)%>");
				return false;
			}
		}else if(coinNum<=0||coinNum>${currencyNum}){
			alert("<%= lang.readGm(GMLangConstants.CURRENCY_NUM_WRONG)%>");
			return false;
		}
	}
	var item= $.trim($("#item").val());
	var isOk=true;
	if(is_null(item)==false){
		var arr=item.split(";");
		if(arr.length>100){
			alert("<%= lang.readGm(GMLangConstants.ITEM_NUM_LIMIT)%>");
			isOk = false;
		}
		var itemArray = new Array();
		for(var i=0;i<arr.length;i++){
			var tmp=$.trim(arr[i]);
			var pattern=/^[0-9]{1,10}=[0-9]{1,3}$/;
			if(tmp!=""){
				if(pattern.test(tmp)){
				}else{
					alert("<%= lang.readGm(GMLangConstants.ITEM_NUM_WRONG)%>");
					isOk = false;
					break;
				}
				var itId=tmp.split("=");
				if(itId[0].length>12){
					alert("<%= lang.readGm(GMLangConstants.ITEM_ID_WRONG)%>");
					isOk = false;
					break;
				}
				if(itId[1]<=0||itId[1]>${itemNum}){
					alert("<%= lang.readGm(GMLangConstants.ITEM_NUM_WRONG)%>");
					isOk = false;
					break;
				}
				if(isContain(itemArray.toString(),itId[0])){
					alert(itId[0]+":<%= lang.readGm(GMLangConstants.ECHO)%>");
					isOk = false;
					break;
				}
			}
	   }
	}
	if(!isOk){
		return false;
    }
	
	//同步后台数据校验
	if(!asynDataCheck()){
		return false;
	}else{
		alert("DATACHECK SUCCES");
	}
	 
	// 设置提交按钮不可点
	$("#submitBtn").attr("disabled",true);
	return true;
}
//校验同步数据
function asynDataCheck(){
	var item= $.trim($("#item").val());
	
	var flag =true;
	 $.ajaxSettings.async= false;
	 $.post("userPrizeAll.do?action=checkData",{item:item},function(info){
		 info = $.trim(info);
		 if(info!="ok"){
			 alert(info);
			 flag = false;
		 }
	 });
	$.ajaxSettings.async= true;
	return flag;
}
</script>
</body>
</html>