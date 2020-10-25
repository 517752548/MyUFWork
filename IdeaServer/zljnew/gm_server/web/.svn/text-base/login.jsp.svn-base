<%@ page contentType="text/html;charset=utf-8" language="java" %>
<%@ include file="common/taglibs.jsp"%>
<form action="login.htm?action=validateUser" method="POST">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td align="center" valign="middle">
	
	<table width="504" border="0" cellpadding="0" cellspacing="0" class="adlog_table" style="margin-bottom:100px">
      <tr>
        <td width="16" height="97"><img src="images/adlogin_lt.png" width="16" height="97"></td>
        <td align="center" background="images/adlogin_mt.png"><img src="images/adlogin_logo.gif" width="436" height="97"></td>
        <td width="15" height="97"><img src="images/adlogin_rt.png" width="15" height="97"></td>
      </tr>
      <tr class="adlog_mbg">
        <td height="135" colspan="3" align="center" valign="top">
		<table width="70%" border="0" cellpadding="0" cellspacing="0" class="adlog_table">
          <tr>
            <td width="29%" align="center"> <%= lang.readGm(GMLangConstants.CHOOSE)%><%= lang.readGm(GMLangConstants.COMMON_REGION)%>:</td>
            <td width="71%" height="40"> <select id="region_id"  name="region_id" onchange="switchRegion()" class="adlog_input">
					<c:forEach items="${regions}" var="region">
                      <c:choose>
                       <c:when test="${regionID eq region.key}">
                         <option id="regionOption_${region.key}" value="${region.key}" selected="selected">${region.value}</option>
                        </c:when>
                       <c:otherwise>
                          <option id="regionOption_${region.key}" value="${region.key}">${region.value}</option>
                       </c:otherwise>
                      </c:choose>
					</c:forEach>
				</select></td>
          </tr>
		  
		   <tr>
            <td align="center"><%= lang.readGm(GMLangConstants.COMMON_GM)%><%= lang.readGm(GMLangConstants.COMMON_NAME)%>：</td>
            <td height="30">
			<input name="username" type="text" maxlength="50" id="username"  class="adlog_input" />
			</td>
          </tr>
           <tr>
            <td align="center">  <%= lang.readGm(GMLangConstants.COMMON_GM)%>
					   <%= lang.readGm(GMLangConstants.COMMON_PASSWORD)%>：</td>
            <td height="30"><input name="password" type="password" id="password" class="adlog_input"  />
			</td>
          </tr>
           <tr>
            <td align="center"><%= lang.readGm(GMLangConstants.COMMON_SERVER)%>:</td>
            <td height="30"><select id="server_id" class="adlog_input"  name="server_id">
					<c:forEach 	items="${dbServerList}" var="dbServer">
                            <c:choose>
	                            <c:when test="${fn:contains(dbServer.id,'log')}">
	                            </c:when>
 								<c:otherwise>
 									<option id="${dbServer.id}" value="${dbServer.id}">${dbServer.dbServerName}-${dbServer.serverName}</option>
 								</c:otherwise>
							</c:choose>
					</c:forEach> </select>
			</td>
          </tr>
          <tr>
            <td height="55" colspan="2" align="center">
             <input type="submit" value="<%= lang.readGm(GMLangConstants.COMMON_LOGIN)%>" 
                       onclick="return ValidateUser();" class="adlog_submit"/>
			</td>
            </tr>
        </table>
		
		
		</td>
        </tr>
      <tr>
        <td width="16" height="10"><img src="images/adlogin_lb.gif" width="16" height="10"></td>
        <td bgcolor="#FFFFFF"></td>
        <td width="15" height="10"><img src="images/adlogin_rb.gif" width="15" height="10"></td>
      </tr>
    </table>
	</td>
  </tr>
</table>
</form>
<script type="text/javascript">
   function ValidateUser(){
	   if(is_null($("#username").val())){
          alert("<%=lang.readGm(GMLangConstants.JS_USERNAME_NOT_NULL)%>");
          return false;
		};
	   if(is_null($("#password").val())){
		   alert("<%=lang.readGm(GMLangConstants.JS_USEPW_NOT_NULL)%>");
	          return false;
		};
	   return true;
   }
</script>

