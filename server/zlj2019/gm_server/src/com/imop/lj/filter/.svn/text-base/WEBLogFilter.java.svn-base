package com.imop.lj.filter;

import java.io.IOException;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;

import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.constants.GMLogConstants;
import com.imop.lj.gm.constants.Mask;
import com.imop.lj.gm.page.PagerResponse;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.CharsetUtil;

/**
 * 为log追加相应代码的filter
 *
 * @author kai.shi
 *
 */
public class WEBLogFilter implements Filter {

	@Override
	public void doFilter(ServletRequest arg0, ServletResponse arg1,
			FilterChain arg2) throws ServletException, IOException {

		HttpServletRequest request = (HttpServletRequest) arg0;
		HttpServletResponse response = (HttpServletResponse) arg1;
		PagerResponse pagerResponse = new PagerResponse(response);
		arg2.doFilter(request, pagerResponse);
		docheck(request, pagerResponse, response);
	}

	@SuppressWarnings("unchecked")
	private void docheck(HttpServletRequest request,
			PagerResponse pagerResponse, HttpServletResponse response)
			throws IOException {
		String logType = (String) request.getAttribute("logType");
		if (StringUtils.isBlank(logType)) {
			return;
		}
		List logs = (List) request.getAttribute("logList");
		if (logs == null) {
			return;
		}
		appendData(request, response, pagerResponse, logType);
	}
	/**
	 * 为通用log类中不同log添加jsp代码
	 * @param request
	 * @param response
	 * @param pagerResponse
	 * @param logType
	 * @throws IOException
	 */
	@SuppressWarnings("unchecked")
	private void appendData(HttpServletRequest request,
			HttpServletResponse response, PagerResponse pagerResponse,
			String logType) throws IOException {
//		PrintWriter out = response.getWriter();
		String originalStr = pagerResponse.getServletOutput();
		System.out.println(originalStr);
		int rowsIndex = originalStr.indexOf("</logparam>");
		int gotoIndex1 = originalStr.indexOf("//Mark1");
		int gotoIndex2 = originalStr.indexOf("//Mark2");
		int searchIndex1 = originalStr.indexOf("//Mark3");
		int searchIndex2 = originalStr.indexOf("//Mark4");
		String beforeParamStr =  -1==rowsIndex?"":originalStr.substring(0, rowsIndex);
		String beforeGotoStr = -1==gotoIndex1?"":originalStr.substring(rowsIndex, gotoIndex1);
		String afterGotoStr = -1==gotoIndex1?"":originalStr.substring(gotoIndex1, gotoIndex2);
		String beforeSearchStr = -1==gotoIndex2?"":originalStr
				.substring(gotoIndex2, searchIndex1);
		String afterSearchStr = searchIndex1==-1?"":originalStr.substring(searchIndex1,
				searchIndex2);
		String remainSearch = searchIndex2==-1?"":originalStr.substring(searchIndex2);
		String newStr = beforeParamStr + "<logparam>";
		// 用于js的var语句
		String parameterString = "";
		// 用于js URL的'&xxx=xxx'语句
		String urlString = "";
		// 用于搜索的input语句
		String inputString = "";
		String searchStr = "<script type='text/javascript'>function gotoSearch(){var opporationValue = document.getElementById('moneyType').value;var opporationType = '&moneyType=';searchs(opporationType,opporationValue);}</script>";
//		String searchStr = "";
		ExcelLangManagerService lang = new ExcelLangManagerService();
		switch (GMLogConstants.getIndexByLogName(logType)) {
		// camp_log 兵力日志
		case 0:
			break;
		// money_log 金钱日志
		case 1:
			String ge = (String) request
			.getParameter("ge");
			inputString = "&nbsp;&nbsp;<span>" + lang.readGm(GMLangConstants.MONEYTYPE) + "："
					+ "<select id=\"moneyType\">";
			Map moneyTypes = Mask.getMap("currency");
			for (Iterator i = moneyTypes.keySet().iterator(); i.hasNext();) {
				int key = (Integer) i.next();
				Integer value = (Integer) moneyTypes.get(key);
				inputString += "<option id=\"moption" + key + "\" value=\""
						+ key + "\">" + lang.readGm(value) + "</option>";
			}
			inputString += "</select>";
			ge=ge==null?"":ge;
			//onchange='gotoSearchGe()'
			inputString +="&nbsp;&nbsp;数值>=<input id=\"ge\" type=\"text\" class=\"limitWidth\" value=\""+ge+"\" />&nbsp;&nbsp; ";
			inputString +="<input id=\"selectNumber\" type=\"button\"  value=\"过滤\" onclick='gotoSearchGe()'/></span>";

			String search2 ="<script type='text/javascript'>function gotoSearchGe(){var moneyType = document.getElementById('moneyType').value;var opporationValue = document.getElementById('ge').value;var opporationType = '&moneyType='+moneyType+'&ge=';searchs(opporationType,opporationValue);}</script>";
			searchStr = searchStr.replace("moneyType", "moneyType");



			searchStr +=search2;
//			parameterString = "var taskID = $(\"#taskID\").val();";
//			urlString = "+\"&taskID=\"+taskID;";
			break;
		// grain_log 粮草日志
		case 2:
			break;
		// exploit_log 军功日志
		case 3:
			break;
		// prestige_log 威望日志
		case 4:
			break;
		// gm_command_log GC操作日志
		case 5:
			break;
		// basic_player_log 角色基本日志
		case 6:
			break;
		// task_log 任务日志
		case 7:
			String taskID = request.getParameter("taskID");
			if (taskID == null) {
				taskID = "";
			}
			inputString = "&nbsp;&nbsp;<span>"
					+ lang.readGm(GMLangConstants.TASK_ID)
					+ "：<input id=\"taskID\" type=\"text\" class=\"limitWidth\" value=\""
					+ taskID + "\"  onchange='gotoSearch()'/></span>";
			searchStr = searchStr.replace("moneyType", "taskID");
			System.out.println(searchStr);
			break;
		// level_log 升级日志
		case 8:
			break;
		// snap_log 快照日志
		case 9:
			break;
		// pet_log 武将日志
		case 10:
			String petTempId = request.getParameter("petTempId");
			if (petTempId == null) {
				petTempId = "";
			}
			inputString = "&nbsp;&nbsp;<span>"
					+ lang.readGm(GMLangConstants.PET_ID)
					+ "：<input id=\"petTempId\" type=\"text\" class=\"limitWidth\" value=\""
					+ petTempId + "\" onchange='gotoSearch()'/></span>";
			searchStr = searchStr.replace("moneyType", "petTempId");
			break;
		// mail_log 邮件日志
		case 11:
			break;
		// guild_log 帮派日志
		case 12:
			break;
		// prize_log 奖励日志
		case 13:
			inputString = "&nbsp;&nbsp;<span>" + lang.readGm(GMLangConstants.AWARD_TYPE) + "："
					+ "<select id=\"prizeType\" onchange='gotoSearch()'>";
			Map prizeTypes = Mask.getMap("prizeType");
			for (Iterator i = prizeTypes.keySet().iterator(); i.hasNext();) {
				int key = (Integer) i.next();
				Integer value = (Integer) prizeTypes.get(key);
				inputString += "<option id=\"moption" + key + "\" value=\""
						+ key + "\">" + lang.readGm(value) + "</option>";
			}
			inputString += "</select></span>";
			searchStr = searchStr.replace("moneyType", "prizeType");
//			parameterString = "var prizeType = $(\"#prizeType\").val();";
//			urlString += "+\"&prizeType=\"+prizeType;";
			break;
		// item_log 物品监控日志
		case 14:
			String itemTemplateId = (String) request
					.getParameter("itemTemplateId");
			if (itemTemplateId == null) {
				itemTemplateId = "";
			}
			inputString = "&nbsp;&nbsp;<span>"
					+ lang.readGm(GMLangConstants.TEMPLATE_ID)
					+ "："
					+ "<input id=\"itemTemplateId\" type=\"text\" class=\"limitWidth\" value=\""
					+ itemTemplateId + "\" onchange='gotoSearch()'/></span>";
//			parameterString = "var itemTemplateId = $(\"#itemTemplateId\").val();";
//			urlString = "+\"&itemTemplateId=\"+itemTemplateId;";
			searchStr = searchStr.replace("moneyType", "itemTemplateId");
			break;
		// battle_log 战斗日志
		case 15:
			break;
		// item_gen_log 物品产生日志
		case 16:
			break;
		// chat_log 聊天日志
		case 17:
			inputString = "&nbsp;&nbsp;<span>" + lang.readGm(GMLangConstants.SCOPE) + "："
			+ "<select id=\"scope\" onchange='gotoSearch()'>";
			Map scopes = Mask.getMap("chatLogScope");
			for (Iterator i = scopes.keySet().iterator(); i.hasNext();) {
				int key = (Integer) i.next();
				Integer value = (Integer) scopes.get(key);
				inputString += "<option id=\"soption" + key + "\" value=\""
						+ key + "\">" + lang.readGm(value) + "</option>";
			}
			inputString += "</select></span>";
//			parameterString = "var scope = $(\"#scope\").val();";
//			urlString += "+\"&scope=\"+scope;";
			searchStr = searchStr.replace("moneyType", "scope");
			break;
			//war_log
		case 18:
			break;
			//employee_log员工日志
		case 19:
			break;
			//secretary_log秘书日志
		case 20:
			break;
			//company_upgrade_log公司升级日志
		case 21:
			break;
			//levy_log征收日志
		case 22:
			break;
			//arena_log竞技场日志
		case 23:
			break;
			//behavior_log用户日常行为活动日志
		case 24:
			break;
			//charge_log充值日志
		case 25:
			break;
			//cheat_log作弊日志
		case 26:
			break;
			//district_log地域日志
		case 27:
			break;
			//drop_item_log掉落日志
		case 28:
			break;
			//escort_log护航日志
		case 29:
			break;
			//hunt_item_log猎命道具日志
		case 30:
			break;
			//hunter_log猎命师日志
		case 31:
			break;
			//mission_log推图日志
		case 32:
			break;
			//online_time_log在线时间日志
		case 33:
			break;
			//player_login_log用户登录日志
		case 34:
			break;
			//probe_log消息处理日志
		case 35:
			break;
			//relation_log好友关系日志
		case 36:
			break;
			//user_action_log用户操作日志
		case 37:
			break;
			//vip_log vip日志
		case 38:
			break;
			//排行榜日志sort_level_log
		case 39:
			break;
			//扫荡日志clean_mission_log
		case 40:
			break;
			//商会日志commerce_log
		case 41:
			break;
			//竞技场新日志arena_recode_log
		case 42:
			break;
			//贸易大会日志commercemeeting_log
		case 43:
			break;
			//招财猫日志feed_cat_log
		case 44:
			break;
			//珠宝商会联盟日志jewelry_allance_log
		case 45:
			break;
			//宝石镶嵌日志 embed_diamond_log
		case 46:
			break;
			//宝石洗练日志wash_diamond_log
		case 47:
			break;
			//鲜花
		case 48:
			break;
			//贸易争夺战
		case 49:
			break;
			//物品合成
		case 50:
			break;
			//每日充值奖励
		case 51:
			break;
			//heritage_log  传承日志
		case 52:
			break;
			//TODO
			// camp_log 兵力日志
//		// pet_log
//		/** 目前不用通用，因为有宠物恢复功能。 */
//		// case 5:
//		// /** 宠物日志的参数 */
//		// task_log
//		case 6:
//			/** 任务日志的参数 */
//			String taskID = request.getParameter("taskID");
//			if (taskID == null) {
//				taskID = "";
//			}
//			inputString = "	<span>"
//					+ lang.readGm(GMLangConstants.TASK_ID)
//					+ ":<input id=\"taskID\" type=\"text\" class=\"limitWidth\" value=\""
//					+ taskID + "\"/></span>";
//			parameterString = "var taskID = $(\"#taskID\").val();";
//			urlString = "+\"&taskID=\"+taskID;";
//			break;
//		// chat_log
//		case 7:
//			/** 聊天日志的参数 */
//			inputString = "<span>" + lang.readGm(GMLangConstants.SCOPE)
//					+ "<select id=\"scope\">";
//			Map scopes = Mask.getMap("chatLogScope");
//			for (Iterator i = scopes.keySet().iterator(); i.hasNext();) {
//				int key = (Integer) i.next();
//				Integer value = (Integer) scopes.get(key);
//				inputString += "<option id=\"soption" + key + "\" value=\""
//						+ key + "\">" + lang.readGm(value) + "</option>";
//			}
//			inputString += "</select></span>";
//			parameterString = "var scope = $(\"#scope\").val();";
//			urlString = "+\"&scope=\"+scope;";
//			break;
//		// pet_exp_log
//		case 11:
//			/** 宠物经验日志的参数 */
//			// index 0 宠物ID
//			String petID = request.getParameter("petID");
//			if (petID == null) {
//				petID = "";
//			}
//			inputString = "<span>"
//					+ lang.readGm(GMLangConstants.PET_ID)
//					+ ":<input id=\"petID\" type=\"text\" class=\"limitWidth\" value=\""
//					+ petID + "\"/></span>";
//			parameterString = "var petID = $(\"#petID\").val();";
//			urlString = "+\"&petID=\"+petID;";
//			break;
//		// pet_level_log
//		case 12:
//			/** 宠物升级日志的参数 */
//			String petID1 = request.getParameter("petID");
//			if (petID1 == null) {
//				petID1 = "";
//			}
//			inputString = "<span>"
//					+ lang.readGm(GMLangConstants.PET_ID)
//					+ ":<input id=\"petID\" type=\"text\" class=\"limitWidth\" value=\""
//					+ petID1 + "\"/></span>";
//			parameterString = "var petID = $(\"#petID\").val();";
//			urlString = "+\"&petID=\"+petID;";
//			break;
//		// gm_command_log
//		case 14:
//			/** GM命令日志的参数 */
//			inputString = "<span>" + lang.readGm(GMLangConstants.ACCOUNTTYPE)
//					+ "</span>" + "<select id=\"accountType\">"
//					+ "<option id=\"pri-1\" value=\"-1\">"
//					+ lang.readGm(GMLangConstants.REASON_ALL) + "</option>"
//					+ "<option id=\"pri0\" value=\"0\">"
//					+ lang.readGm(GMLangConstants.PLAYER) + "</option>"
//					+ "<option id=\"pri1\" value=\"1\">"
//					+ lang.readGm(GMLangConstants.GM) + "</option>"
//					+ "<option id=\"pri2\" value=\"2\">"
//					+ lang.readGm(GMLangConstants.DEBUG) + "</option>"
//					+ "</select>";
//			parameterString = "var accountType = $(\"#accountType\").val();";
//			urlString = "+\"&accountType=\"+accountType;";
//			break;
//		// item_gen_log
//		case 16:
//			/** 物品更新日志的参数 */
//			String templeteID1 = request.getParameter("templeteID");
//			String itemGenId = request.getParameter("itemGenId");
//			if (templeteID1 == null) {
//				templeteID1 = "";
//			}
//			if (itemGenId == null) {
//				itemGenId = "";
//			}
//			inputString = "<span>"
//					+ lang.readGm(GMLangConstants.ITEM)
//					+ lang.readGm(GMLangConstants.TEMPLATE_ID)
//					+ ""
//					+ "<input id=\"itemTemplateID\" type=\"text\" class=\"limitWidth\" value=\""
//					+ templeteID1 + "\"/></span>";
//			inputString += "<span>"
//					+ lang.readGm(GMLangConstants.ITEM_GEN_ID)
//					+ ":<input id=\"itemGenId\" type=\"text\" class=\"limitWidth\" value=\""
//					+ itemGenId + "\"/></span>";
//			parameterString = "var itemTemplateID = $(\"#itemTemplateID\").val();"
//					+ "var itemGenId = $(\"#itemGenId\").val();";
//			urlString = "+\"&itemTemplateID=\"+itemTemplateID+\"&itemGenId=\"+itemGenId;";
//			break;
//		// charge_log
//		case 18:
//			/** 充值日志的参数 */
//			inputString = "<span>" + lang.readGm(GMLangConstants.MONEYTYPE)
//					+ "<select id=\"moneyType\">";
//			Map moneyTypes1 = Mask.getMap("currency");
//			for (Iterator i = moneyTypes1.keySet().iterator(); i.hasNext();) {
//				int key = (Integer) i.next();
//				Integer value = (Integer) moneyTypes1.get(key);
//				inputString += "<option id=\"moption" + key + "\" value=\""
//						+ key + "\">" + lang.readGm(value) + "</option>";
//			}
//			inputString += "</select></span>";
//			parameterString = "var moneyType = $(\"#moneyType\").val();";
//			urlString = "+\"&moneyType=\"+moneyType;";
//			break;
//		// prize_log
//		case 19:
//			/** 奖励日志的参数 */
//			inputString = "<span>" + lang.readGm(GMLangConstants.AWARD_TYPE)
//					+ "<select id=\"awardType\">";
//			Map awardTypes = Mask.getMap("awardType");
//			for (Iterator i = awardTypes.keySet().iterator(); i.hasNext();) {
//				int key = (Integer) i.next();
//				Integer value = (Integer) awardTypes.get(key);
//				inputString += "<option id=\"aoption" + key + "\" value=\""
//						+ key + "\">" + lang.readGm(value) + "</option>";
//			}
//			inputString += "</select></span>";
//			parameterString = "var awardType = $(\"#awardType\").val();";
//			urlString = "+\"&awardType=\"+awardType;";
//			break;
//		// treasure_log
//		case 21:
//			/** 宝箱日志的参数 */
//			String boxId = request.getParameter("boxId");
//			if (boxId == null) {
//				boxId = "";
//			}
//			inputString = "<span>" + lang.readGm(GMLangConstants.TROPHY_TYPE)
//					+ "<select id=\"treasurePrizeType\">";
//			inputString += "<option id=\"toption-1\" value=\"-1\">"
//					+ lang.readGm(GMLangConstants.REASON_ALL) + "</option>";
//			Map treasurePrizeTypes = Mask.getMap("treasurePrizeType");
//			for (Iterator i = treasurePrizeTypes.keySet().iterator(); i
//					.hasNext();) {
//				int key = (Integer) i.next();
//				Integer value = (Integer) treasurePrizeTypes.get(key);
//				inputString += "<option id=\"toption" + key + "\" value=\""
//						+ key + "\">" + lang.readGm(value) + "</option>";
//			}
//			inputString += "</select></span>";
//			inputString += "<span>" + lang.readGm(GMLangConstants.BOXID) + ":"
//					+ "<input id=\"boxId\" type=\"text\" class=\"limitWidth\""
//					+ "value=\"" + boxId + "\"/></span>";
//			parameterString = "var treasurePrizeType = $(\"#treasurePrizeType\").val();"
//					+ "var boxId = $(\"#boxId\").val();";
//			urlString = "+\"&boxId=\"+boxId+\"&treasurePrizeType=\"+treasurePrizeType;";
//			break;
		default:
			break;
		}
		newStr += inputString;
		newStr += beforeGotoStr;
		newStr += parameterString;
		newStr += afterGotoStr;
		newStr += urlString;
		newStr += beforeSearchStr;
		newStr += parameterString;
		newStr += afterSearchStr;
		newStr += urlString;
		newStr += remainSearch;
		newStr += searchStr;
		response.getOutputStream().write(newStr.trim().getBytes(CharsetUtil.UTF8_CHARSET));
//		out.println(newStr.trim());
		// System.out.println(newStr.trim());
	}

	@Override
	public void init(FilterConfig arg0) throws ServletException {
		// TODO Auto-generated method stub

	}

	@Override
	public void destroy() {
		// TODO Auto-generated method stub

	}

}
