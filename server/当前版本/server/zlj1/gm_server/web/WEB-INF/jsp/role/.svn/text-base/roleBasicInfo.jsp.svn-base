<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ page import="com.imop.lj.db.model.HumanEntity"%>
<%
	HumanEntity humanEntity= (HumanEntity)request.getAttribute("humanEntity");
%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title></title>

<script type="text/javascript">
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
	
	function modifyCurrency(currencyName,roleId){
		var currencyValue = document.getElementById(currencyName).value;
		var con= confirm("<%=lang.readGm(GMLangConstants.CONFRIM_MODIFY)%>?");
		if(con){
			$.post("role.do?action=modifyCurrency",{currencyName:currencyName,currencyValue:currencyValue,roleId:roleId},function(info){
				alert("<%=lang.readGm(GMLangConstants.ITEM_WAIT_FLUSH)%>");
				window.location="role.do?action=roleBasicInfo&id=${humanEntity.id}";
			  });
		}
	}
</script>
</head>

<body>
	<div id="man_zone">

	<div class="topnav">
		<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>&gt;&gt;
		<%= lang.readGm(GMLangConstants.GAME_WORLD_MANAGE) %>&gt;&gt;
		<a  href="role.do?action=init" class="link"><%=lang.readGm(GMLangConstants.ROLE_MANAGE)%></a>&gt;&gt;
		<%=lang.readGm(GMLangConstants.C_BASIC_INFO)%>
	</div>

		<div id="nav">
		<ul>
			<li id="man_nav_1"
				class="bg_image_onclick" ><%=lang.readGm(GMLangConstants.C_BASIC_INFO)%></li>

			<!-- <li id="man_nav_2"
				onclick="javaScript:window.location='role.do?action=rolePet&id=${humanEntity.id}';"
				class="bg_image"><%=lang.readGm(GMLangConstants.PET)%></li> -->

		    <li id="man_nav_3"
				onclick="javaScript:window.location='role.do?action=roleItem&id=${humanEntity.id}';"
				class="bg_image"><%=lang.readGm(GMLangConstants.ITEM)%></li>
		</ul>
		</div>

		<div id="sub_info">
		</div>

		<div class="nofloat" />

		<table id='tab_3' class="detail roleBasicInfo no_bottom" cellspacing="0"
			cellpadding="0" border="0">
			<tbody>
				<tr>
					<th colspan="6" align="center">&nbsp;<%=lang.readGm(GMLangConstants.CHANGE_CURRENCY)%></th>
				</tr>
				<tr>
					<td>&nbsp;创建时间</td>
					<td>${humanEntity.createTime}</td>
					<td>

					</td>
				</tr>
                <tr>
                    <td>&nbsp;上次登陆时间</td>
                    <td>${humanEntity.lastLoginTime}</td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td>&nbsp;上次登出时间</td>
                    <td>${humanEntity.lastLogoutTime}</td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td>&nbsp;登陆IP</td>
                    <td>${humanEntity.lastLoginIp}</td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td>&nbsp;累计在线时长(分钟)</td>
                    <td>${humanEntity.totalMinute}</td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td>&nbsp;当日充值数额</td>
                    <td>${humanEntity.todayCharge}</td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td>&nbsp;总充值数额</td>
                    <td>${humanEntity.totalCharge}</td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td>&nbsp;最后充值时间</td>
                    <td>${humanEntity.lastChargeTime}</td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td>&nbsp;最后成为某级别vip的时间</td>
                    <td>${humanEntity.lastVipTime}</td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td>&nbsp;玩家等级</td>
                    <td>${humanEntity.level}</td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td>&nbsp;玩家经验</td>
                    <td>${humanEntity.exp}</td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td>&nbsp;开启背包格数</td>
                    <td>${humanEntity.hadOpenPrimBagNum}</td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td>&nbsp;技能点</td>
                    <td>${humanEntity.skillPoint}</td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td>&nbsp;心法等级</td>
                    <td>${humanEntity.mainSkillLevel}</td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td>&nbsp;当前心法类型</td>
                    <td>${humanEntity.mainSkillType}</td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td>&nbsp;采矿等级</td>
                    <td>${humanEntity.mineLevel}</td>
                    <td>

                    </td>
                </tr>
                <!-- 绑定元宝 -->
				<tr>
					<td>&nbsp;<%=lang.readGm(GMLangConstants.CURRENCY_SYS_BOND)%></td>
					<td>${humanEntity.sysBond}</td>
					<td>
						<input type="text" name="sysBond" id="sysBond" value="${humanEntity.sysBond}"/>
					    <input type="button" name="button" id="button" onclick="modifyCurrency('sysBond','${humanEntity.id}');"
					    value="<%=lang.readGm(GMLangConstants.BROSORURL_SAVE)%>"/>
				    </td>
				</tr>
				<!-- 礼券 -->
				<tr>
					<td>&nbsp;<%=lang.readGm(GMLangConstants.CURRENCY_GIFT_BOND)%></td>
					<td>${humanEntity.giftBond}</td>
					<td>
						<input type="text" name="giftBond" id="giftBond" value="${humanEntity.giftBond}"/>
					    <input type="button" name="button" id="button" onclick="modifyCurrency('giftBond','${humanEntity.id}');"
					    value="<%=lang.readGm(GMLangConstants.BROSORURL_SAVE)%>"/>
				    </td>
				</tr>
				
				<!-- 金币 -->
				<tr>
					<td>&nbsp;<%=lang.readGm(GMLangConstants.LJ_GOLD)%></td>
					<td>${humanEntity.gold}</td>
					<td>
						<input type="text" name="gold" id="gold" value="${humanEntity.gold}"/>
					    <input type="button" name="button" id="button" onclick="modifyCurrency('gold','${humanEntity.id}');"
					    value="<%=lang.readGm(GMLangConstants.BROSORURL_SAVE)%>"/>
				    </td>
				</tr>
				
				<!-- 蓝色虎符 -->

				<!-- 军令 -->
				<tr>
					<td>&nbsp;<%=lang.readGm(GMLangConstants.CURRENCY_POWER)%></td>
					<td>${humanEntity.power}</td>
					<td>
						<input type="text" name="power" id="power" value="${humanEntity.power}"/>
					    <input type="button" name="button" id="button" onclick="modifyCurrency('power','${humanEntity.id}');"
					    value="<%=lang.readGm(GMLangConstants.BROSORURL_SAVE)%>"/>
				    </td>
				</tr>
				

				
				<!-- 声望 -->
				<tr>
					<td>&nbsp;<%=lang.readGm(GMLangConstants.CURRENCY_LJ_HONOR)%></td>
					<td>${humanEntity.honor}</td>
					<td>
						<input type="text" name="honor" id="honor" value="${humanEntity.honor}"/>
					    <input type="button" name="button" id="button" onclick="modifyCurrency('honor','${humanEntity.id}');"
					    value="<%=lang.readGm(GMLangConstants.BROSORURL_SAVE)%>"/>
				    </td>
				</tr>
				

			</tbody>
		</table>

		</div>
		</div>
	</body>
</html>