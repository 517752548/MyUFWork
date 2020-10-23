/**
 *
 */
package com.imop.lj.gm.service.notice;

import java.util.Date;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import net.sf.json.JSONObject;

import com.imop.lj.gm.config.GmConfig;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.dao.notice.GameNoticeDAO;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.model.notice.GameNotice;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.DateUtil;

/**
 * 游戏公告 Service
 *
 * @author linfan
 *
 */
public class GameNoticeService {

	public GmConfig gmConfig;
	
	public void setGmConfig(GmConfig gmConfig) {
		this.gmConfig = gmConfig;
	}

	/** 游戏公告 DAO */
	private GameNoticeDAO gameNoticeDAO;

	/** 命令管理 Service */
	private CmdManageService cmdManageService;

	/** 处理Excel的多语言Service */
	private ExcelLangManagerService excelLangManagerService;

	/** db log */
	private Logger logger = LoggerFactory.getLogger("db");

	public ExcelLangManagerService getExcelLangManagerService() {
		return excelLangManagerService;
	}

	public void setExcelLangManagerService(
			ExcelLangManagerService excelLangManagerService) {
		this.excelLangManagerService = excelLangManagerService;
	}

	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}

	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}

	public GameNoticeDAO getGameNoticeDAO() {
		return gameNoticeDAO;
	}

	public void setGameNoticeDAO(GameNoticeDAO gameNoticeDAO) {
		this.gameNoticeDAO = gameNoticeDAO;
	}

	/**
	 * 查询所有的游戏公告
	 *
	 * @return 游戏公告列表
	 */
	public List<GameNotice> getGameNoticeList() {
		return gameNoticeDAO.getGameNoticeList();
	}

	/**
	 * 添加游戏公告
	 *
	 * @param serverIDs
	 *            服务器IDs
	 * @param content
	 *            游戏公告内容
	 * @throws 添加成功
	 *             ,返回true,反之返回false
	 */
	public boolean addGameNotice(String content, String serverIDs)
			throws Exception {
		if (serverIDs == null) {
			return false;
		}

		if (content.length() > gmConfig.noticeLen) {
			return false;
		}
		GameNotice notice = new GameNotice();
		notice.setContent(content);
		notice.setStatus(SystemConstants.NOTRELEASE);
		notice.setServerIds(serverIDs);
		LoginUser loginUser = LoginUserService.getLoginUser();
		if (gameNoticeDAO.save(notice) != null) {
			String info = "success:\t"
					+ ExcelLangManagerService.readGmLang(GMLangConstants.ADMIN)
					+ ":"
					+ loginUser.getUsername()
					+ "\t"
					+ ExcelLangManagerService
							.readGmLang(GMLangConstants.COMMON_REGION)
					+ ":"
					+ loginUser.getLoginRegionId()
					+ "\t"
					+ ExcelLangManagerService
							.readGmLang(GMLangConstants.COMMON_SERVER) + ":"
					+ loginUser.getLoginServerId() + "\t"
					+ "Add GameNotice(id:" + notice.getId() + ",content:"
					+ content + ",ServerIds:" + serverIDs + ")" + "\t Date:"
					+ DateUtil.formatDateHour(new Date());
			logger.info(info);
			return true;
		} else {
			return false;
		}
	}

	/**
	 * 删除游戏公告
	 *
	 * @param id
	 */
	public void delGameNotice(String id) {
		GameNotice notice = gameNoticeDAO.loadById(GameNotice.class, Integer
				.valueOf(id));
		gameNoticeDAO.delete(notice);
		LoginUser loginUser = LoginUserService.getLoginUser();
		String info = "success:\t"
				+ ExcelLangManagerService.readGmLang(GMLangConstants.ADMIN)
				+ ":"
				+ loginUser.getUsername()
				+ "\t"
				+ ExcelLangManagerService
						.readGmLang(GMLangConstants.COMMON_REGION)
				+ ":"
				+ loginUser.getLoginRegionId()
				+ "\t"
				+ ExcelLangManagerService
						.readGmLang(GMLangConstants.COMMON_SERVER) + ":"
				+ loginUser.getLoginServerId() + "\t" + "Delete GameNotice(id:"
				+ id + ")\t Date:" + (DateUtil.formatDateHour(new Date()));
		logger.info(info);

	}

	/**
	 * 根据id 加载GameNotic实体
	 *
	 * @param id
	 *            GameNotic的id
	 * @return GameNotic实体
	 */
	public GameNotice loadGameNotice(String id) {
		if (id == null) {
			return null;
		}
		return gameNoticeDAO.getById(GameNotice.class, Integer.valueOf(id));
	}

	/**
	 * 保存游戏公告
	 *
	 * @param id
	 *            游戏公告 id
	 * @param content
	 *            游戏公告内容
	 * @param serverIDs
	 *            服务器IDs
	 * @return 保存成功,返回true,反之返回false
	 * @throws Exception
	 */
	public boolean saveGameNotice(String id, String content, String serverIDs)
			throws Exception {
		if (serverIDs == null) {
			return false;
		}
		if (StringUtils.isBlank(content)) {
			return false;
		}
		if (content.length() > gmConfig.noticeLen) {
			return false;
		}
		if (StringUtils.isBlank(id)) {
			return addGameNotice(content, serverIDs);
		} else {
			GameNotice notice = gameNoticeDAO.getById(GameNotice.class, Integer
					.valueOf(id));
			notice.setContent(content);
			notice.setStatus(SystemConstants.NOTRELEASE);
			notice.setServerIds(serverIDs);
			LoginUser loginUser = LoginUserService.getLoginUser();
			if (gameNoticeDAO.merge(notice) != null) {
				String info = "success:\t"
						+ ExcelLangManagerService
								.readGmLang(GMLangConstants.ADMIN)
						+ ":"
						+ loginUser.getUsername()
						+ "\t"
						+ ExcelLangManagerService
								.readGmLang(GMLangConstants.COMMON_REGION)
						+ ":"
						+ loginUser.getLoginRegionId()
						+ "\t"
						+ ExcelLangManagerService
								.readGmLang(GMLangConstants.COMMON_SERVER)
						+ ":" + loginUser.getLoginServerId() + "\t"
						+ "Edit GameNotice(id:" + id + ",content:" + content
						+ ",ServerIds:" + serverIDs + ")" + "\t Date:"
						+ DateUtil.formatDateHour(new Date());
				logger.info(info);
				return true;
			} else {
				return false;
			}
		}
	}

	/**
	 * 发布公告
	 *
	 * @param id
	 */
	public boolean releaseGameNotice(String id, DBServer svr) {
		GameNotice notice = gameNoticeDAO.getById(GameNotice.class, Integer
				.valueOf(id));
		notice.setStatus(SystemConstants.RELEASE);
		JSONObject _o = new JSONObject();
		_o.put("ids", notice.getServerIds());
		_o.put("content", notice.getContent());
		_o.put("type", SystemConstants.GAME_NOTICE_TYPE);
		String cmd = "notice " + _o.toString();
		List<String> result = cmdManageService.sendCmd(cmd, svr, false);
		if (!"[]".equals(result.toString())) {
			return false;
		}
		LoginUser loginUser = LoginUserService.getLoginUser();
		if (gameNoticeDAO.merge(notice) != null) {
			String info = "success:\t"
					+ ExcelLangManagerService.readGmLang(GMLangConstants.ADMIN)
					+ ":"
					+ loginUser.getUsername()
					+ "\t"
					+ ExcelLangManagerService
							.readGmLang(GMLangConstants.COMMON_REGION)
					+ ":"
					+ loginUser.getLoginRegionId()
					+ "\t"
					+ ExcelLangManagerService
							.readGmLang(GMLangConstants.COMMON_SERVER) + ":"
					+ loginUser.getLoginServerId() + "\t"
					+ "Release GameNotice(id:" + id + ",content:"
					+ notice.getContent() + ",ServerIds:"
					+ notice.getServerIds() + ")" + "\t Date:"
					+ DateUtil.formatDateHour(new Date());
			logger.info(info);
			return true;
		} else {
			return false;
		}
	}

	/**
	 * 加超链接标签
	 *
	 * @param content
	 *            公告内容
	 * @return 公告内容
	 */
	public String addLinkLabel(String content) {
		String regLink = "((<(A|a) (HREF|href)=\"(http|HTTP)://)(.*?)(</(a|A)>))";
		Pattern plink = Pattern.compile(regLink);
		Matcher _matcherLink = plink.matcher(content);
		String reg = "<(A|a) (HREF|href)=\"";
		Pattern p = Pattern.compile(reg);
		while (_matcherLink.find()) {
			String l = _matcherLink.group();
			Matcher _matcher = p.matcher(l);
			String link = "";
			while (_matcher.find()) {
				String temp = _matcher.group();
				link = temp + "event:" + l.replace(temp, "");
				break;
			}
			if (StringUtils.isNotBlank(link)) {
				content = content.replace(l, "<U>" + link + "</U>");
			}
		}
		return content;

	}
}
