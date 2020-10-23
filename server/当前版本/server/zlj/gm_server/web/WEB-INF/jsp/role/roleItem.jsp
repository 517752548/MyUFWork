<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/logCommon.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title></title>
<script type="text/javascript"><!--
Request = {
		QueryString : function(key){
		var svalue = window.location.search.match(new RegExp("[\?\&]"+key+"=([^\&]*)(\&?)","i"));
		return svalue ? svalue[1] : svalue;
	}
	};
$().ready(function(){
  $("table[name^='tab']").each(function(){
	  	  $(this).hide();
   });
  $("table[name^='tab_1']").each(function(){
	  	  $(this).show();
   });
});
function list_sub_nav(id,sortname){
	$("li[id^='man_nav']").each(function(){
    	  $(this).attr("class","bg_image");
     });
   if($("#"+id).attr("class")=="bg_image"){
	   $("#"+id).attr("class","bg_image_onclick");
   }
   showInnerText(id);
}

function showInnerText(id){
    var switchId = parseInt(id.substring(8));
	var showText = "";
	switch(switchId){
	    case 1:
		   $("#searchType").val("roleId");
		   break;
	    case 2:
		   $("#searchType").val("userId");
		   break;
	}
}
function switchTab(id){
	$("h2[id^='tab']").each(function(){
    	  $(this).attr("class","tab");
     });
   if($("#"+id).attr("class")=="tab"){
	   $("#"+id).attr("class","selected tab");
   }
   $("table[name^='tab']").each(function(){
	  	  $(this).hide();
	});
   $("table[name^='"+id+"']").each(function(){
	  	  $(this).show();
   });
}
function searchItem(){
    var name= $("#searchItemName").val();
//    var bagType = Request.QueryString("bagType");
   // window.location.href="role.do?action=roleItem&id=${id}&name="+name+"&bagType="+bagType;
    window.location.href="role.do?action=roleItem&id=${id}&name="+name;
}
function selectAll(){
	 var selectAll= $("#selectAll").attr("checked");
	 if(selectAll==true){
      $("input[name^='item']").each(function(){
 			$(this).attr("checked",true);
        });
	 }else{
		 $("input[name^='item']").each(function(){
	 			$(this).attr("checked",false);
	        });
	 }
}
function delectItems(){
   var con= confirm("<%=lang.readGm(GMLangConstants.ITEM_ALERT)%>?");
   var itemIds ="";
   if(con){
	  $("input[name^='item'][@checked]").each(function(){
		  itemIds=itemIds+$(this).attr("id")+",";
      });
	}
}
function goTo(i){
    var name= $("#searchItemName").val();
    var bagType = Request.QueryString("bagType");
    window.location="role.do?action=roleItem&id=${id}&name="+name+"&currentPage="+i+"&bagType="+bagType;
   }

--></script>
</head>
<body>
<div id="man_zone">
	<div class="topnav">
		<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>&gt;&gt; 
		<%= lang.readGm(GMLangConstants.GAME_LOG) %>&gt;&gt; 
		<a  href="role.do?action=init" class="link"><%=lang.readGm(GMLangConstants.ROLE_MANAGE)%></a>&gt;&gt;
		<%=lang.readGm(GMLangConstants.ITEM)%>
	</div>

		<div id="nav">
<ul>
	<li id="man_nav_1"
		onclick="javaScript:window.location='role.do?action=roleBasicInfo&id=${id}';"
		class="bg_image" ><%=lang.readGm(GMLangConstants.C_BASIC_INFO)%></li>
	<!-- <li id="man_nav_2" 	onclick="javaScript:window.location='role.do?action=rolePet&id=${id}';"
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.PET)%>')"
		class="bg_image"><%=lang.readGm(GMLangConstants.PET)%></li> -->
   <li id="man_nav_3" 
		class="bg_image_onclick"><%=lang.readGm(GMLangConstants.ITEM)%></li>
</ul>
		</div>
		
		<div id="sub_info">&nbsp;&nbsp;
			<span>
				<%=lang.readGm(GMLangConstants.ITEM_NAME)%>：
				<input id="searchItemName" type="text" value="${searchName}" />&nbsp;&nbsp;
				<input type="button" class="butcom" value="<%=lang.readGm(GMLangConstants.COMMON_SEARCH)%>" onclick="searchItem()"/>
			</span>
		</div>

<table id='tab_1' class="detail" width="1100px" cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
		<tr>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.ITEM_ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.ITEM_NAME)%></th>
 		 <th>&nbsp;<%=lang.readGm(GMLangConstants.ROLE_ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.NUM)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.WEAR_ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.ITEM_TEMPLATE_ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.POSITION)%></th>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.COMMON_OPERATION)%></th>
		</tr>
     <c:forEach items="${items}" var="item">
        <tr>
          <!--<td>&nbsp;<a class="link pointer" href="role.do?action=itemBasicInfo&role_id=${id}&item_id=${item.id}&bagType=${bagType}">${item.id}</a></td>
          --><td>&nbsp;<a class="link pointer" href="role.do?action=itemBasicInfo&role_id=${id}&item_id=${item.id}">${item.id}</a></td>
          <td>&nbsp;
	          <c:forEach items="${xlsData['items']}" var="m" >
	             <c:if test="${m.key eq item.templateId}"><c:out value="${m.value}" /></c:if>
	          </c:forEach>
         </td>
		 <td >&nbsp;${item.charId}</td>
         <td>&nbsp;${item.overlap}</td>
         <td>&nbsp;
 		 	 ${item.wearerId}
 		 </td>
         <td>&nbsp;
           ${item.templateId}
         </td>
         <td>&nbsp;
         <c:forEach items="${dataMap['bagType']}" var="bag" >
             	<c:if test="${bag.key eq item.bagId}"><c:out value="${language.readGm(bag.value)}" /></c:if>
         </c:forEach>
        </td>
		 <td>&nbsp;<img src="images/b_edit.png" /></td>
		</tr>
     </c:forEach>
		<tr>
			<td height="30" colspan="9" style="border-bottom: 0px;">
			<div id="num_style">
             </data>
             </div></td>
		</tr>
	</tbody>
</table>
</div>
</div>
</body>
</html>