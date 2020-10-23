<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
<script type="text/javascript" src="jslib/jquery.js"></script>
<script type="text/javascript">
$().ready(function(){
	   if("${currency}"==""){
		   $("#option0").attr("selected","selected");
	   }else{
		   $("#option${currency}").attr("selected","selected");
	   }
});
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
</script>
</head>
<body>
<c:if test="${cmd eq true}">
	<script type="text/javascript">
		alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
		window.location="worldGift.do?action=init";
	</script>
</c:if>
<c:if test="${cmd eq false}">
	<script type="text/javascript">
		alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
	</script>
</c:if>
<c:if test="${prizeIdErr eq true}">
	<script type="text/javascript">
		alert("<%=lang.readGm(GMLangConstants.PRIZE_FMT)%>");
	</script>
</c:if>

<div id="man_zone">
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>  
<a class="link" href="worldGift.do?action=init"><%=lang.readGm(GMLangConstants.WORLD_GIFT)%></a>>><%=lang.readGm(GMLangConstants.NEW_ADD)%></div>
<br/>
<c:choose>
<c:when test="${error_msg ne null}">
<span id="error_msg" class="error_msg">${error_msg}</span>
</c:when>
</c:choose>
<br/>

<div style="clear: both;"></div>
<form method="post" name="form1" action="worldGift.do?action=addWorldGift" onsubmit="return is_ok();">
<table name='tab_1' class="detail" style="width:50%;" cellspacing="0"
	cellpadding="0" border="0">
	<tbody>
		<tr>
			<td colspan="4" class="header"><%=lang.readGm(GMLangConstants.PRIZE)%></td>
		</tr>
        <tr>
			<th class="label"><%= lang.readGm(GMLangConstants.WORLD_GIFT_ID)%>
			(<%= lang.readGm(GMLangConstants.PRIZE_FMT)%>)</th>
			<td ><input id="giftId" name="giftId" value="${giftId}"/></td>
			<th class="label"><%= lang.readGm(GMLangConstants.WORLD_GIFT_NAME)%></th>
			<td ><input id="giftName" name="giftName" value="${giftName}"/></td>
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
			<td colspan="3"><textarea id="item" cols="80" rows="5" name="item" >${item}</textarea></td>
		</tr>
		<tr>
			<td colspan="4"  class="bottom"><input class="butcom"
				id="submit" type="submit"
				value="<%= lang.readGm(GMLangConstants.COMMON_SUBMIT)%>" /> <span
				style="padding: 10px;" /><input id="reset" type="reset" class="butcom"
				value="<%= lang.readGm(GMLangConstants.RESET)%>" />
            <span
				style="padding: 10px;" /><input id="return" type="button" class="butcom"
				value="<%= lang.readGm(GMLangConstants.RETURN)%>"  onclick="javaScript:window.location='worldGift.do?action=init';"/>
           </td>
		</tr>
	</tbody>
</table>
</form>
</div>
<script type="text/javascript">

function is_ok(){
	
	var giftId =$.trim($("#giftId").val());
	if(is_null(giftId)==true){
		alert("<%= lang.readGm(GMLangConstants.PRIZE_ID_NOT_NULL)%>");
		$("#giftId").focus();
		return false;
	}
	if(giftId.length>9){
		alert('<%= lang.readGm(GMLangConstants.TOO_LONG)%>');
		$("#giftId").focus();
		return false;
	}
	if(is_int(giftId)==false){
		alert("<%= lang.readGm(GMLangConstants.PRIZE_ID_IS_INT)%>");
		$("#giftId").focus();
		return false;
	}
	var giftName = $.trim($("#giftName").val());
	if(is_null(giftName)==true){
		alert("<%= lang.readGm(GMLangConstants.PRIZE_NAME_NOT_NULL)%>");
		$("#giftName").focus();
		return false;
	}
	var coinNum= $.trim($("#coinNum").val());
	if(is_null(coinNum)==false){
		var pattern=/^([0-9]+)$/;
		if(!pattern.test(coinNum)){
			alert("<%= lang.readGm(GMLangConstants.COIN_NUM_WRONG)%>");
			return false;
		}
		var  coinType = $.trim($("#currency").val());
		if(coinType==2){
			if(coinNum<=0||coinNum>${goldNumLimit}){
				alert("<%= lang.readGm(GMLangConstants.GOLD_NUM_WRONG)%>");
				return false;
			}
		}else if(coinNum<=0||coinNum>${currencyNumLimit}){
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
				if(itId[1]<=0||itId[1]>${itemNumLimit}){
					alert("<%= lang.readGm(GMLangConstants.ITEM_NUM_WRONG)%>");
					isOk = false;
					break;
				}
				
				if(isContain(itemArray.toString(),itId[0])){
					alert(itId[0]+":<%= lang.readGm(GMLangConstants.ECHO)%>");
					isOk = false;
					break;
				}
				itemArray.push(itId[0]);
			}
	   }
	}
	if(!isOk){
		return false;
    }

	 //同步后台数据校验
	if(!asynDataCheck()){
		return false;
	}
	return true;
}

//校验异步数据
function asynDataCheck(){
	var giftId =$.trim($("#giftId").val());
	var item= $.trim($("#item").val());
	var flag = true;
	 $.ajaxSettings.async= false;
	 $.post("worldGift.do?action=checkData",{giftId:giftId,item:item},function(info){
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