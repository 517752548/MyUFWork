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
   function selectAll(){
	   var sel=$("#selBut").attr("checked");
	   if(sel){
         $("input[name='serverId']").each(function(){
			$(this).attr("checked",true);
          });
	   }else{
		   $("input[name='serverId']").each(function(){
				$(this).attr("checked",false);
	       });
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
<a class="link" href="userPrize.do?action=init"><%=lang.readGm(GMLangConstants.GM_USER_PRIZE)%></a>>><%=lang.readGm(GMLangConstants.NEW_ADD)%></div>
<div style="clear: both;"></div>
<form  method="post" name="form1"
	action="userPrize.do?action=addUserPrize" onsubmit="return true;">
<table name='tab_1' class="detail" style="width:50%;" cellspacing="0"
	cellpadding="0" border="0">
	<tbody>
		<tr>
			<td colspan="4" class="header"><%=lang.readGm(GMLangConstants.GM_USER_PRIZE)%></td>
		</tr>
		<tr>
			<td class="label"><%=lang.readGm(GMLangConstants.PRIZE_REASON)%></td>
            <td>
			<select id="reason" name="reason">
				<% Map reasons= Mask.getMap("rolePrizeReason1");
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
			<td class="label"><%= lang.readGm(GMLangConstants.MUSER_PRIZE_FMT)%>
			</td>
			<td colspan="3"><textarea id="passportIds" cols="80" rows="5" name="passportIds"></textarea></td>
		</tr>
		<tr>
			<td class="label"><%= lang.readGm(GMLangConstants.PRIZE_COIN)%>
			</td>
			<td colspan="3">
				<c:forEach items="${currencys}" var="currency">
					${currency.name}
					<input id="currency${currency.id}" name="currency${currency.id}" onblur="check_currency(id, value)" />
					上限<input type="text" id="currency${currency.id}Limit" name="currency${currency.id}Limit" value="${currency.maxValue}" readonly="readonly"/>
					<br/>
				</c:forEach>
			</td>
			
		</tr>
		<tr>
			<td class="label"><%= lang.readGm(GMLangConstants.ITEM_FMT)%>
			</td>
			<td colspan="3" ><textarea id="item" cols="80" rows="5" name="item"></textarea></td>
		</tr>
		<tr>
			<td colspan="4"  class="bottom">
				<input class="butcom" id="submit" type="submit"	value="<%= lang.readGm(GMLangConstants.COMMON_SUBMIT)%>" /> 
				<span style="padding: 10px;" />
				<input id="reset" type="reset" class="butcom" value="<%= lang.readGm(GMLangConstants.RESET)%>" />
            	<span style="padding: 10px;" />
            	<input id="return" type="button" class="butcom"	value="<%= lang.readGm(GMLangConstants.RETURN)%>"  onclick="javaScript:window.location='userPrize.do?action=init';"/>
           </td>
		</tr>
	</tbody>
</table>
</form>
</div>
<script type="text/javascript">
function check_currency(currencyId, value){
	if(value<=0){
		return;	
	}
	var limitId = currencyId + "Limit";
	var maxValue = $("#"+limitId).attr("value");
	if(parseInt(value, 10) > parseInt(maxValue, 10)){
		alert("货币数量超过上限");
		$("#"+currencyId).attr("value","");
	}
}
function is_ok(){
	var userPrizeName = $.trim($("#userPrizeName").val());
	if(is_null(userPrizeName)==true){
		alert('<%= lang.readGm(GMLangConstants.USER_PRIZE_NAME_NOT_NULL)%>');
		$("#userPrizeName").focus();
		return false;
	}
	var str=$.trim($("#passportIds").val());
	if(is_null(str)==true){
		alert('<%= lang.readGm(GMLangConstants.USERID_NOT_NULL)%>');
		$("#passportIds").focus();
		return false;
	}
	var chararr = str.split(";");
	var flag = true;
	for(var i=0;i<chararr.length;i++){
		var tmp=chararr[i];
		var pattern=/^[0-9]{1,10}=.+$/;
		if(!pattern.test(tmp)){
			alert(chararr[i]+"<%= lang.readGm(GMLangConstants.USERID_WRONG)%>");
			flag = false;
			return false;
		}
	}
	if(!flag){
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
	return true;
}
//校验同步数据
function asynDataCheck(){
	var item= $.trim($("#item").val());
	var passportIds=$.trim($("#passportIds").val());
	var flag =true;
	 $.ajaxSettings.async= false;
	 $.post("userPrize.do?action=checkData",{item:item,passportIds:passportIds},function(info){
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