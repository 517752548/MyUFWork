package com.imop.lj.gm.controller;


import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.service.GuildInfoService;

/**
 * 游戏公会管理Controller
 *
 * @author lin fan
 *
 */
public class GuildInfoController extends MultiActionController {

	/** 公会管理初始页面 */
	private String guildInfoView;

	/** 公会成员管理初始页面 */
	private String guildMemberView;

	/** 公会基本信息页面 */
	private String guildBasicInfoView;
	/** 游戏公会信息Service */
	private GuildInfoService guildInfoService;

	public String getGuildMemberView() {
		return guildMemberView;
	}

	public void setGuildMemberView(String guildMemberView) {
		this.guildMemberView = guildMemberView;
	}

	public GuildInfoService getGuildInfoService() {
		return guildInfoService;
	}

	public void setGuildInfoService(GuildInfoService guildInfoService) {
		this.guildInfoService = guildInfoService;
	}

	public String getGuildInfoView() {
		return guildInfoView;
	}

	public void setGuildInfoView(String guildInfoView) {
		this.guildInfoView = guildInfoView;
	}

	/**
	 * 公会管理初始页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getGuildInfoView());
//		String guildName = request.getParameter("guildName");
//		List<CommerceEntity> guildInfoList = guildInfoService
//				.searchGuildInfo(guildName);
//		mav.addObject("guildInfoList", guildInfoList);
//		mav.addObject("guildName", guildName);
		return mav;
	}

	/**
	 * 公会成员管理初始页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView initGuildMember(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getGuildMemberView());
//		String guildId = request.getParameter("id");
//		String guildName = request.getParameter("guildName");
//		List<CommerceMemberEntity> guildMemberList = guildInfoService
//				.searchGuildMemberInfo(guildId);
//		mav.addObject("guildMemberList", guildMemberList);
//		mav.addObject("guildId", guildId);
//		mav.addObject("guildName", guildName);
//		mav.addObject("num", guildMemberList.size());
		return mav;
	}

	/**
	 * 公会成员管理初始页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView initGuildBasicInfo(HttpServletRequest request, HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getGuildBasicInfoView());
//		String _guildId = request.getParameter("id");
//		String _guildName = request.getParameter("guildName");
//		CommerceEntity _guild = guildInfoService.getGuildInfoById(_guildId);
////		GuildCityEntity guildCity = (GuildCityEntity)DataType.byte2obj(_guild.getCityInfo());
////		GuildExtraInfoEntity guildExtra = (GuildExtraInfoEntity)DataType.byte2obj(_guild.getExtraInfo());
//		mav.addObject("guild", _guild);
//		mav.addObject("guildId", _guildId);
//		mav.addObject("guildName", _guildName);
//
//		List<GuildTechInfo> guildTechInfoList = new ArrayList<GuildTechInfo>();
//		JSONArray jsonArray;
//		GuildTechInfo tempGuildTechInfo;
//		JSONObject guildTechs = JSONObject.fromObject(_guild.getProps());
//
//		for (Object object : guildTechs.values()) {
//			if (object == null) {
//				continue;
//			}
//
//			jsonArray = JSONArray.fromObject(object);
//			tempGuildTechInfo = new GuildTechInfo(
//					jsonArray.getInt(0), jsonArray.getInt(1));
//			guildTechInfoList.add(tempGuildTechInfo);
//		}
//
//		mav.addObject("guildTechInfoList", guildTechInfoList);
//		mav.addObject("guildCity", guildCity);
//		mav.addObject("guildExtra", guildExtra);
		return mav;
	}
	public void setGuildBasicInfoView(String guildBasicInfoView) {
		this.guildBasicInfoView = guildBasicInfoView;
	}

	public String getGuildBasicInfoView() {
		return guildBasicInfoView;
	}

	/**
	 * 用于记录军团科技信息的实体类
	 * @author zhiyuan.luo
	 *
	 */
	private class GuildTechInfo {
		/** 等级 */
		private int level;
		/** 进度 */
		private int progress;

		/**
		 * 类参数构造器
		 * @param level
		 * @param progress
		 */
		public GuildTechInfo(int level, int progress) {
			this.level = level;
			this.progress = progress;
		}

		@SuppressWarnings("unused")
		public int getLevel() {
			return level;
		}

		@SuppressWarnings("unused")
		public void setLevel(int level) {
			this.level = level;
		}

		@SuppressWarnings("unused")
		public int getProgress() {
			return progress;
		}

		@SuppressWarnings("unused")
		public void setProgress(int progress) {
			this.progress = progress;
		}
	}
}
