package com.imop.lj.gm.service.cdkey;

import java.util.ArrayList;
import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.db.model.CDKeyPlansEntity;
import com.imop.lj.gm.config.GmConfig;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.dao.ParamGenericDAO;
import com.imop.lj.gm.dao.cdkey.CDKeyPlansDAO;
import com.imop.lj.gm.model.CDKeyPlansVO;
import com.imop.lj.gm.service.BaseService;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.service.xls.XlsItemLoadService;
import com.imop.lj.gm.utils.DateUtil;

/**
 * cdkey套餐
 * 
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月27日 下午6:32:26
 * @version 1.0
 */

public class CDKeyPlansService extends BaseService {

	public GmConfig gmConfig;
	
	public void setGmConfig(GmConfig gmConfig) {
		this.gmConfig = gmConfig;
	}

	private CDKeyPlansDAO cdkeyPlansDAO;

	private DBFactoryService dbFactoryService;

	/** 加载物品编辑器表格 Service */
	private XlsItemLoadService xlsItemLoadService;

	/** log */
	private static final Logger logger = LoggerFactory.getLogger("gm.cdkeyplans");

	
	public List<CDKeyPlansVO> getAllCDKeyPlans() {
		List<CDKeyPlansVO> resultList = new ArrayList<CDKeyPlansVO>();
		List<CDKeyPlansEntity> entityList = cdkeyPlansDAO.getAllCDKeyPlans();
		CDKeyPlansVO tmpVO = null;
		for(CDKeyPlansEntity entity : entityList) {
			tmpVO = buildVO(entity);
			if( null != tmpVO) {
				resultList.add(tmpVO);
			}
		}
		return resultList;
	}
	
	public CDKeyPlansVO getCDKeyPlansByPlansId(String plansId) {
		CDKeyPlansEntity entity = cdkeyPlansDAO.getCDKeyPlansByPlansId(plansId);
		return buildVO(entity);
	}
	
	private CDKeyPlansVO buildVO(CDKeyPlansEntity entity) {
		CDKeyPlansVO vo = null;
		if(null != entity) {
			vo = new CDKeyPlansVO(entity);
		}
		return vo;
	}
	
	public List<CDKeyPlansVO> getByPlansNameOrDate(String plansName, long createTimeStart, long createTimeEnd) {
		List<CDKeyPlansVO> resultList = new ArrayList<CDKeyPlansVO>();
		List<CDKeyPlansEntity> entityList = cdkeyPlansDAO.getByPlansNameOrDate(plansName, createTimeStart, createTimeEnd);
		CDKeyPlansVO tmpVO = null;
		for(CDKeyPlansEntity entity : entityList) {
			tmpVO = buildVO(entity);
			if( null != tmpVO) {
				resultList.add(tmpVO);
			}
		}
		return resultList;
	}
	
	public List<CDKeyPlansVO> getByPlansName(String plansName) {
		List<CDKeyPlansVO> resultList = new ArrayList<CDKeyPlansVO>();
		List<CDKeyPlansEntity> entityList = cdkeyPlansDAO.getByPlansName(plansName);
		CDKeyPlansVO tmpVO = null;
		for(CDKeyPlansEntity entity : entityList) {
			tmpVO = buildVO(entity);
			if( null != tmpVO) {
				resultList.add(tmpVO);
			}
		}
		return resultList;
	}
	
	/**
	 * 添加奖励
	 * @param giftId
	 * @param giftName
	 * @param currencyPack
	 * @param items
	 * @return
	 */
	public CDKeyPlansVO addPlans(String plansId, String plansName, long startTime, long endTime, String gmId) {
		
		logger.info("#CDKeyPlansService#addPlans#start, plansId= "  + plansId + ", plansName=" + plansName
				+ ", startTime=" + startTime + ", endTime=" + endTime + ", gmId=" + gmId);
		
		CDKeyPlansVO resultVO = new CDKeyPlansVO();
		CDKeyPlansEntity entity = new CDKeyPlansEntity();

		StringBuffer sb = new StringBuffer();
		
		if(validPlansIdExist(plansId, sb)){
			resultVO.setResult(sb.toString());
			return resultVO;
		};
		
		if (!StringUtils.isNotBlank(plansName)) {
			setErroLog("failure:\t giftName is null", logger);
			return resultVO;
		}
		
		entity.setCdkeyPlansId(Integer.valueOf(plansId));
		entity.setCdkeyPlansName(plansName);
		entity.setStartTime(startTime);
		entity.setEndTime(endTime);
		entity.setCreateTime(System.currentTimeMillis());
		entity.setGmId(Integer.parseInt(gmId));
		entity.setIsDel(0);
		
		if(!saveCDKeyPlansEntity(entity)) {
			resultVO.setResult("fail");
			return resultVO;
		}
		resultVO.setResult("succ");
		resultVO.init(entity);
		return resultVO;
	}
	/**
	 * 验证是否存在，存在返回true
	 * @param plansId
	 * @return
	 */
	public boolean validPlansIdExist(String plansId) {
		return validPlansIdExist(plansId, new StringBuffer());
	}
	/**
	 * 验证是否存在，存在返回true
	 * @param plansId
	 * @param sb
	 * @return
	 */
	public boolean validPlansIdExist(String plansId, StringBuffer sb) {
		CDKeyPlansEntity entity = this.cdkeyPlansDAO.getCDKeyPlansByPlansId(plansId);
		if(null != entity) {
			setErroLog("failure:\t plansId already exist;", logger);
			return true;
		}
		return false;
	}
	
	
	private boolean saveCDKeyPlansEntity(CDKeyPlansEntity entity) {
		String worldServerId = gmConfig.worldserverid;
		if(StringUtils.isEmpty(worldServerId)) {
			logger.error("#CDKeyPlansService#saveCDKeyPlansEntity, worldServerId is null!");
		}
		logger.info("#CDKeyPlansService#saveCDKeyPlansEntity#start,save entity");
		ParamGenericDAO dao= new ParamGenericDAO();
		dao.setRId(LoginUserService.getLoginRegionId());
		dao.setSId(worldServerId);
		dao.setDbFactoryService(dbFactoryService);
		StringBuilder sb= new StringBuilder();
		
		logger.info("#CDKeyPlansService#saveCDKeyPlansEntity#start,save");
		if (dao.saveObject(entity) != null) {
			sb.append(
					ExcelLangManagerService
							.readGmLang(GMLangConstants.COMMON_LOGIN)
							+ ExcelLangManagerService
									.readGmLang(GMLangConstants.COMMON_REGION)
							+ "：").append(LoginUserService.getLoginRegionId());
			sb.append(
					"\t"
							+ ExcelLangManagerService
									.readGmLang(GMLangConstants.COMMON_LOGIN)
							+ ExcelLangManagerService
									.readGmLang(GMLangConstants.COMMON_SERVER)
							+ "：").append(worldServerId);
			sb.append(
					"\t"
							+ ExcelLangManagerService
									.readGmLang(GMLangConstants.ROLEACCOUNT)
							+ ": ").append(LoginUserService.getLoginUser().getUsername()).append(
					"\t"
							+ ExcelLangManagerService
									.readGmLang(GMLangConstants.WORLD_GIFT));
			sb.append(
					"\t" 	+ ExcelLangManagerService
									.readGmLang(GMLangConstants.WORLD_GIFT_ID))
					.append(": " + entity.getCdkeyPlansId());
			sb.append(
					"\t"	+ ExcelLangManagerService
									.readGmLang(GMLangConstants.WORLD_GIFT_PARAMS))
									.append(entity.getCdkeyPlansName());
			sb.append(
					ExcelLangManagerService
							.readGmLang(GMLangConstants.WORLD_GIFT_CREATE_TIME))
					.append("\t" + DateUtil.formatDateHour(entity.getCreateTime()));

			logger.info(sb.toString());
			return true;
		}else{
			return false;
		}
	}
	/**
	 * =============getter/setter=============
	 */
	public CDKeyPlansDAO getCdkeyPlansDAO() {
		return cdkeyPlansDAO;
	}

	public void setCdkeyPlansDAO(CDKeyPlansDAO cdkeyPlansDAO) {
		this.cdkeyPlansDAO = cdkeyPlansDAO;
	}

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	public XlsItemLoadService getXlsItemLoadService() {
		return xlsItemLoadService;
	}

	public void setXlsItemLoadService(XlsItemLoadService xlsItemLoadService) {
		this.xlsItemLoadService = xlsItemLoadService;
	}

	public static Logger getLogger() {
		return logger;
	}
	
	
}
