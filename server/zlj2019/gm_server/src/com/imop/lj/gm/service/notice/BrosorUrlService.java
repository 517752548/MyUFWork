package com.imop.lj.gm.service.notice;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.dao.notice.BrosorDAO;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;

public class BrosorUrlService {
	/**db log */
	private   Logger logger = LoggerFactory.getLogger("db");

	/**telnet log */
	private   Logger telnetlogger = LoggerFactory.getLogger("telnet");

	/** 命令管理 Service */
	private CmdManageService cmdManageService;

	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}

	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}

	/** 处理Excel的多语言Service */
	private ExcelLangManagerService excelLangManagerService;
	//内置浏览器urldao
	private BrosorDAO brosorDAO;
	public BrosorDAO getBrosorDAO() {
		return brosorDAO;
	}
	public void setBrosorDAO(BrosorDAO brosorDAO) {
		this.brosorDAO = brosorDAO;
	}
//	/**
//	 * 查询所有内置浏览器url
//	 *
//	 * @return t_broser_url
//	 */
//	public List<BroserEntity> getBroserUrlList() {
//		return brosorDAO.getBroserEntityList();
//	}
//	/**
//	 * 发布url
//	 *
//	 * @param id
//	 */
//	public boolean releaseTimeNotice(BroserEntity broserEntity, DBServer svr) {
//		brosorDAO.saveOrUpdate(broserEntity);
//		String cmd = this.createBrosorUrlCmd(broserEntity);
//		List<String> result = cmdManageService.sendCmd(cmd, svr, false);
//		System.out.println(result.toString());
//		if (!"[ok]".equals(result.toString())) {
//			return false;
//		}
//		LoginUser loginUser = LoginUserService.getLoginUser();
//		String info = "success:\t" + ExcelLangManagerService.readGmLang(GMLangConstants.ADMIN) + ":"
//				+ loginUser.getUsername() + "\t" + ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_REGION)
//				+ ":" + loginUser.getLoginRegionId() + "\t"
//				+ ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_SERVER) + ":"
//				+ loginUser.getLoginServerId() + "\t" + "Release BroserEntity(id:" + broserEntity.getId() + ",terminalType:"
//				+ broserEntity.getTerminalType() + ",brosorUrl:" + broserEntity.getBrosorUrl() + ",BrosorUrlType:" + broserEntity.getBrosorUrlType()
//				+ ",updateTime:" + broserEntity.getUpdateTime() + ")";
//		logger.info(info);
//		return true;
//	}
//	/**
//	 * 发布url同步url
//	 *
//	 * @param id
//	 */
//	public boolean releaseTimeNoticeAnsyc(BroserEntity broserEntity, DBServer svr) {
//		String cmd = this.createBrosorUrlCmd(broserEntity);
//		List<String> result = cmdManageService.sendCmd(cmd, svr, false);
//		if (!"[ok]".equals(result.toString())) {
//			return false;
//		}
//		LoginUser loginUser = LoginUserService.getLoginUser();
//		String info = "success:\t" + ExcelLangManagerService.readGmLang(GMLangConstants.ADMIN) + ":"
//				+ loginUser.getUsername() + "\t" + ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_REGION)
//				+ ":" + loginUser.getLoginRegionId() + "\t"
//				+ ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_SERVER) + ":"
//				+ loginUser.getLoginServerId() + "\t" + "Release BroserEntity(id:" + broserEntity.getId() + ",terminalType:"
//				+ broserEntity.getTerminalType() + ",brosorUrl:" + broserEntity.getBrosorUrl() + ",BrosorUrlType:" + broserEntity.getBrosorUrlType()
//				+ ",updateTime:" + broserEntity.getUpdateTime() + ")";
//		logger.info(info);
//		return true;
//	}
//	/**
//	 * 创建url命令
//	 *
//	 * @param notice
//	 * @return
//	 */
//	public String createBrosorUrlCmd(BroserEntity broserEntity) {
//
//		JSONObject _o = new JSONObject();
//		if(broserEntity != null){
//			_o.put("terminalType", broserEntity.getTerminalType());
//			_o.put("brosorUrl", broserEntity.getBrosorUrl());
//			_o.put("type", broserEntity.getBrosorUrlType());
//		}else{
//			return "";
//		}
//
//		String _cmd = "borsorurl";
//		_cmd += " terminalType="+broserEntity.getTerminalType();
//		_cmd += " brosorUrl="+broserEntity.getBrosorUrl();
//		_cmd += " type="+broserEntity.getBrosorUrlType();
//
//		return _cmd;
//	}
//	/**
//	 * 获得url实体
//	 *
//	 * @param notice
//	 * @return
//	 */
//	public BroserEntity getBroserUrlById(String id) {
//		return brosorDAO.getById(BroserEntity.class, Integer.valueOf(id));
//	}
}
