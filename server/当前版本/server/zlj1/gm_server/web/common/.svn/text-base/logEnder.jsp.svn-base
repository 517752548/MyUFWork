<%@ page import="com.imop.lj.gm.constants.GMLogConstants" %>
		<table class="detail" cellspacing="0" cellpadding="0"
			border="0" width="100%">
			<tbody>
				<tr>
					<% String logType = (String)request.getAttribute("logType"); %>
					<% List<String> title = GMLogConstants.getHeaderByLogname(logType);
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
										    <%--<c:when test="${temp eq 1}">--%>
								            	<%--<%=lang.readGm(GMLangConstants.ALLIANCE_TONGMENTGUO)%>--%>
								            <%--</c:when>--%>
								            <%--<c:when test="${temp eq 2}">--%>
								           		<%--<%=lang.readGm(GMLangConstants.ALLIANCE_ZHOUXINGUO)%>--%>
								           	<%--</c:when>--%>
								           	<%--<c:when test="${temp eq 4}">--%>
								            	<%--<%=lang.readGm(GMLangConstants.ALLIANCE_GONGCHANGUOJI)%>--%>
								            <%--</c:when>--%>
								            <%--<c:when test="${temp eq 7}">--%>
								           		<%--<%=lang.readGm(GMLangConstants.ALLIANCE_QUANZHENYING)%>--%>
								           	<%--</c:when>--%>
								         <%--</c:choose>--%
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

								<c:when test="${status.count eq 14}">
									<td>&nbsp;
										<c:if test="${isMoney eq true}">
											<c:choose>
											    <c:when test="${temp eq 1}">
									            	<%=lang.readGm(GMLangConstants.MONEY_DIAMOND)%>
									            </c:when>
									              <c:when test="${temp eq 3}">
									            	<%=lang.readGm(GMLangConstants.MONEY_DIAMOND)%>
									            </c:when>
									             <c:when test="${temp eq 4}">
									            	<%=lang.readGm(GMLangConstants.HONOR)%>
									            </c:when>
									             <c:when test="${temp eq 5}">
									            	<%=lang.readGm(GMLangConstants.CURRENCY_EXP)%>
									            </c:when>
									             <c:when test="${temp eq 6}">
									            	<%=lang.readGm(GMLangConstants.POWER)%>
									            </c:when>
									            <c:when test="${temp eq 2}">
									           		<%=lang.readGm(GMLangConstants.MONEY_GOLD)%>
									           	</c:when>
								         	</c:choose>
										</c:if>
										<c:if test="${isChat eq true}">
											<c:forEach items="${dataMap['chatLogScope']}" var="chatLogScope" >
							             		<c:if test="${chatLogScope.key eq temp}">
							             			<c:out value="${language.readGm(chatLogScope.value)}"/>
							             		</c:if>
							         		</c:forEach>
										</c:if>

										<c:if test="${isWar eq true}">
											<c:choose>
											    <c:when test="${temp eq 0}">
									            	<%=lang.readGm(GMLangConstants.FARM_WAR)%>
									            </c:when>
									            <c:when test="${temp eq 1}">
									           		<%=lang.readGm(GMLangConstants.CITY_WAR)%>
									           	</c:when>
									           	<c:when test="${temp eq 2}">
									           		<%=lang.readGm(GMLangConstants.MINE_WAR)%>
									           	</c:when>
								         	</c:choose>
										</c:if>

										<c:if test="${isMoney ne true}">
											<c:if test="${isChat ne true}">
												<c:if test="${isWar ne true}">
													${temp}
												</c:if>
											</c:if>
										</c:if>

									</td>
								</c:when>

								<c:when test="${status.count eq 17}">
									<td>&nbsp;
										<c:if test="${isBattle eq true}">
											<c:choose>
											    <c:when test="${temp eq 1}">
									            	<%=lang.readGm(GMLangConstants.BATTLE_WIN)%>
									            </c:when>
									            <c:when test="${temp eq 0}">
									           		<%=lang.readGm(GMLangConstants.BATTLE_LOSE)%>
									           	</c:when>
								         	</c:choose>
										</c:if>
										<c:if test="${isBattle ne true}">
											${temp}
										</c:if>
									</td>
								</c:when>

								<c:when test="${status.count eq 19}">
									<td>&nbsp;
										<c:if test="${isGuild eq true}">
											<c:forEach items="${dataMap['guildState']}" var="guildState" >
							             		<c:if test="${guildState.key eq temp}"><c:out value="${language.readGm(guildState.value)}" /></c:if>
							         		</c:forEach>
										</c:if>
										<c:if test="${isGuild ne true}">
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
		   <td id="num_style" height="30" colspan="25" style="border-bottom: 0px;text-align:right;">
		     </data>
		    </td>
				</tr>
			</tbody>
		</table>
	</body>
</html>