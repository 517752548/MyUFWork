/**
 *
 */
package com.imop.lj.gm.controller.notice;

import java.io.BufferedWriter;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.apache.commons.lang.StringUtils;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.config.GmConfig;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.model.notice.GameNotice;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.notice.GameNoticeService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.JavaShellUtil;
import com.imop.lj.gm.utils.LangUtils;

/**
 * 游戏公告 Controller
 *
 * @author linfan
 *
 */
public class GameNoticeController extends MultiActionController {

	private static String NoticeFileName = "game_notice.txt";
	
	private GmConfig gmConfig;
	
	
	public void setGmConfig(GmConfig gmConfig) {
		this.gmConfig = gmConfig;
	}

	/** 游戏公告初始页面 */
	private String gameNoticeListView;

	/** 编辑游戏公告页面 */
	private String editGameNoticeView;

	/** 游戏公告Service */
	private GameNoticeService gameNoticeService;

	/** 命令管理 Service */
	private CmdManageService cmdManageService;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/** 处理Excel的多语言类 */
	private ExcelLangManagerService excelLangManagerService;

	public String getGameNoticeListView() {
		return gameNoticeListView;
	}

	public void setGameNoticeListView(String gameNoticeListView) {
		this.gameNoticeListView = gameNoticeListView;
	}

	public String getEditGameNoticeView() {
		return editGameNoticeView;
	}

	public void setEditGameNoticeView(String editGameNoticeView) {
		this.editGameNoticeView = editGameNoticeView;
	}

	public GameNoticeService getGameNoticeService() {
		return gameNoticeService;
	}

	public void setGameNoticeService(GameNoticeService gameNoticeService) {
		this.gameNoticeService = gameNoticeService;
	}

	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}

	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	public ExcelLangManagerService getExcelLangManagerService() {
		return excelLangManagerService;
	}

	public void setExcelLangManagerService(
			ExcelLangManagerService excelLangManagerService) {
		this.excelLangManagerService = excelLangManagerService;
	}

	/** 游戏公告初始页面 */
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getGameNoticeListView());
		gameNoticeView(request, response, mav);
		return mav;
	}

	/** 删除游戏公告 */
	public ModelAndView delGameNotice(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getGameNoticeListView());
		String id = request.getParameter("id");
		gameNoticeService.delGameNotice(id);
		return mav;
	}

	/** 编辑游戏公告 */
	public ModelAndView editGameNotice(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getEditGameNoticeView());
		String id = request.getParameter("id");
		if (StringUtils.isBlank(id)) {
			getServers(request, response, mav);
			mav.addObject("noticeLen", gmConfig.noticeLen);
			return mav;
		} else {
			GameNotice notice = gameNoticeService.loadGameNotice(id);
			mav.addObject("content", notice.getContent());
			mav.addObject("sId", notice.getServerIds());
			mav.addObject("noticeLen", gmConfig.noticeLen);
			mav.addObject("id", id);
			getServers(request, response, mav);
			return mav;
		}

	}

	/** 保存游戏公告 */
	public ModelAndView saveGameNotice(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getEditGameNoticeView());
		String content = request.getParameter("content");
		String sId = request.getParameter("serIds").trim();
		String id = request.getParameter("id").trim();
		String path = request.getRealPath("") + NoticeFileName;
		
		if (checkContent(content)) {
			boolean saveFlag = false;
			try {
				BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(new FileOutputStream(path), "UTF-8"));
				writer.write(content);
				writer.flush();
				writer.close();
				
				String copyCmd = excelLangManagerService.readGm(GMLangConstants.GAME_NOTICE_COPY_CMD1) + " " + path + " "
						+ excelLangManagerService.readGm(GMLangConstants.GAME_NOTICE_COPY_CMD2);
				int shellRet = JavaShellUtil.executeShell(copyCmd);
				System.out.println("shellRet=" + shellRet);
				
				saveFlag = true;
			} catch (FileNotFoundException e) {
				e.printStackTrace();
			} catch (IOException e) {
				e.printStackTrace();
			}
			
			if (saveFlag) {
				mav = new ModelAndView(getGameNoticeListView());
				gameNoticeView(request, response, mav);
			} else {
				mav.addObject("fail", true);
			}
		} else {
			mav.addObject("htmlFail", true);
		}
		
//		mav = new ModelAndView(getGameNoticeListView());
//		gameNoticeView(request, response, mav);
		
		getServers(request, response, mav);
		mav.addObject("content", content);
		mav.addObject("noticeLen", gmConfig.noticeLen);
		mav.addObject("sId", sId);
		mav.addObject("id", id);
		return mav;
	}
	
	/**
	 * 异步要校验的数据
	 *
	 * @param request
	 * @param response
	 * @throws Exception
	 */
	public void checkData(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		String content = request.getParameter("content");
		response.setCharacterEncoding("utf-8");

		boolean flag = checkContent(content);
		
		if (!flag) {
			response.getWriter().print(
					ExcelLangManagerService
							.readGmLang(GMLangConstants.CONTENT_NOT_MATCH));
			return;
		}
		response.getWriter().print("ok");
	}
	
	private boolean checkContent(String content) {
		boolean flag = false;
		//只允许这三个标签
//		<color=#ff0011>带颜色</color>
//		<size=30>字号</size>
//		<i>斜体</i>
		content = content.trim();
		if (!content.contains("<") &&
				!content.contains(">")) {
			flag = true;
		} else {
			//左右<>是否一样多
			content = "a" + content + "a";
			int n1 = content.split("<").length;
			int n2 = content.split(">").length;
			if (n1 != n2) {
				flag = false;
			} else {
				int c1 = content.split("<color").length;
				int c2 = content.split("</color").length;
				
				int s1 = content.split("<size").length;
				int s2 = content.split("</size").length;
				
				int i1 = content.split("<i").length;
				int i2 = content.split("</i").length;
				
				if (c1 != c2 || s1 != s2 || i1 != i2 || 
						(c1+c2+s1+s2+i1+i2) == 6) {
					flag = false;
				} else {
					flag = true;
				}
			}
		}
		
		return flag;
	}

	/**
	 * 转换链接
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView coverLink(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		String content = request.getParameter("content").trim();
		content = gameNoticeService.addLinkLabel(content);
		response.setCharacterEncoding("utf-8");
		response.getWriter().print(content);
		return null;
	}

	/** 发布游戏公告 */
	public ModelAndView releaseGameNotice(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		String id = request.getParameter("id");
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u
				.getLoginServerId());
		if (gameNoticeService.releaseGameNotice(id, svr)) {
			response.getWriter().print("true");
		} else {
			response.getWriter().print("false");
		}
		;
		return null;

	}

	private void gameNoticeView(HttpServletRequest request,
			HttpServletResponse response, ModelAndView mav) {
		List<GameNotice> gameNoticeList = gameNoticeService.getGameNoticeList();
		getServers(request, response, mav);
		mav.addObject("gameNoticeList", gameNoticeList);
		mav.addObject("DBType", LangUtils.getDBType());
	}

	@SuppressWarnings("unchecked")
	private void getServers(HttpServletRequest request,
			HttpServletResponse response, ModelAndView mav) {
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u
				.getLoginServerId());
		List serverIds = cmdManageService.getServerIds(svr);
		mav.addObject("serverIds", serverIds);

	}

}
