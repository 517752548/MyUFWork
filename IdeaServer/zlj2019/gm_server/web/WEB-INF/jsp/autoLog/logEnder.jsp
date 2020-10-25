<%@ page import="com.imop.lj.gm.autolog.GMAutoLogConstants" %>
		<table class="detail" cellspacing="0" cellpadding="0"
			border="0" width="100%">
			<tbody>
				<tr>
					<% String logType = (String)request.getAttribute("logType"); %>
					<% List<String> title = GMAutoLogConstants.getHeaderByLogname(logType);
						if (title != null) {
							   for(int i = 0;i<title.size();i++)
							   {
								   if(i==2)
								   {
									%>
								   <th>&nbsp;<a id="timeSort"  class="link pointer" onclick="javaScript:sort();" title="<%=lang.readGm(GMLangConstants.ASC)%>"><%=title.get(i)%>
								   <img id="sortImg" style="width: 12px;height: 12px;" src="images/nav_down.gif" /></a></th>
								    <%
								   } else{
							%>
							<th>&nbsp;<%=title.get(i)%></th>
							<%
									}
							   }
					  }
					%>
				</tr>
				<c:forEach items="${logList}" var="log">
					<tr>
						<c:forEach items="${log.list()}" var="temp" varStatus="status">
							<c:choose>	
								<c:when test="${status.count eq 2}">
									<td>&nbsp;
										<c:forEach items="${logTypes}" var="_logType">
							             	<c:if test="${_logType.key eq temp}"><c:out value="${_logType.value}" /></c:if>
						         		</c:forEach>
					         		</td>
								</c:when>
								
								<c:when test="${status.count eq 6}">
									<td>&nbsp;<a	href="user.do?action=init&searchType=userId&searchValue=${temp}"
										class="link">${temp}</a></td>
								</c:when>
								
								<c:when test="${status.count eq 8}">
									<td>&nbsp;<a	href="role.do?action=init&searchType=roleId&searchValue=${temp}"
										class="link">${temp}</a></td>
								</c:when>
								
								<c:when test="${status.count eq 11}">
									<td>&nbsp;
										<%--<c:choose>--%>
										    <%--<c:when test="${temp eq 0}">--%>
								            	<%--<%=lang.readGm(GMLangConstants.ALLIANCE_LESS)%>--%>
								            <%--</c:when>--%>
								            <%--<c:when test="${temp eq 1}">--%>
								           		<%--<%=lang.readGm(GMLangConstants.ALLIANCE_SHU)%>--%>
								           	<%--</c:when>--%>
								           	<%--<c:when test="${temp eq 2}">--%>
								            	<%--<%=lang.readGm(GMLangConstants.ALLIANCE_WEI)%>--%>
								            <%--</c:when>--%>
								            <%--<c:when test="${temp eq 3}">--%>
								           		<%--<%=lang.readGm(GMLangConstants.ALLIANCE_WU)%>--%>
								           	<%--</c:when>--%>
								           	<%--<c:otherwise>--%>
								           		<%--${temp}--%>
						          		 	<%--</c:otherwise>--%>
			    						 <%--</c:choose>--%>
					         		</td>
								</c:when>
								
								<c:when test="${status.count eq 13}">
									<td>&nbsp;
										<c:forEach items="${logReasons}" var="LogReason" >
						             		<c:if test="${LogReason.key eq temp}"><c:out value="${LogReason.value}" />
						             		<c:set var="canFindReason" value="true"/></c:if>
						         		</c:forEach>
										<c:if test="${canFindReason ne true}" >
											${temp}
										</c:if>
									</td>
								</c:when>
								
								<c:otherwise>
									<td>&nbsp;${temp}</td>
								</c:otherwise>
							</c:choose>
						</c:forEach>
					</tr>
				</c:forEach>
				<tr>
		   <td id="num_style" height="30" colspan="35" style="border-bottom: 0px;text-align:right;">
		     </data>
		    </td>
				</tr>
			</tbody>
		</table>
	</body>
</html>