package com.imop.lj.gm.service;

import java.util.ArrayList;
import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.db.model.WorldGiftEntity;
import com.imop.lj.gm.config.GmConfig;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.dao.ParamGenericDAO;
import com.imop.lj.gm.dao.WorldGiftDAO;
import com.imop.lj.gm.model.WorldGiftVO;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.service.xls.XlsItemLoadService;
import com.imop.lj.gm.utils.CommonCheckUtil;
import com.imop.lj.gm.utils.DateUtil;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月27日 下午12:12:34
 * @version 1.0
 */

public class WorldGiftService extends BaseService {

	public GmConfig gmConfig;
	
	public void setGmConfig(GmConfig gmConfig) {
		this.gmConfig = gmConfig;
	}

	private WorldGiftDAO worldGiftDAO;

	private DBFactoryService dbFactoryService;

	/** 加载物品编辑器表格 Service */
	private XlsItemLoadService xlsItemLoadService;

	/** log */
	private static final Logger logger = LoggerFactory.getLogger("gm.worldgif");


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

	public WorldGiftDAO getWorldGiftDAO() {
		return worldGiftDAO;
	}

	public void setWorldGiftDAO(WorldGiftDAO worldGiftDAO) {
		this.worldGiftDAO = worldGiftDAO;
	}

	/**
	 * 全服礼包
	 * @param giftId
	 * @return
	 */
	public WorldGiftVO getWorldGift(String giftId) {
		WorldGiftEntity entity = worldGiftDAO.getWorldGiftById(giftId);
		return toVO(entity);
	}
	
	public List<WorldGiftVO> getAllWorldGift() {
		List<WorldGiftVO> result = new ArrayList<WorldGiftVO>();
		List<WorldGiftEntity> entityList = worldGiftDAO.getAllWorldGift();
		if(null != entityList) {
			WorldGiftVO vo = null;
			for (WorldGiftEntity entity : entityList) {
				vo = toVO(entity);
				if(null != vo) {
					result.add(vo);
				}
			}
		}
		return result;
	}
	
	private WorldGiftVO toVO(WorldGiftEntity entity) {
		WorldGiftVO vo = null;
		if(null != entity) {
			vo = new WorldGiftVO(entity);
		}
		return vo;
	}
	/**
	 * 添加奖励
	 * @param giftId
	 * @param giftName
	 * @param currencyPack
	 * @param items
	 * @return
	 */
	public WorldGiftVO addWorldGift(String giftId, String giftName, String currencyPack, String items) {
		
		logger.info("#WorldGiftService#addWorldGift#start, giftId= "  + giftId + ", giftName=" + giftName
				+ ", currencyPack=" + currencyPack + ",items=" + items);
		
		WorldGiftVO resultVO = new WorldGiftVO();
		
		WorldGiftEntity entity = new WorldGiftEntity();

		StringBuffer sb = new StringBuffer();
		
		if(!validGiftId(giftId, sb)){
			resultVO.setResult(sb.toString());
			return resultVO;
		};
		
		if (!StringUtils.isNotBlank(giftName)) {
			setErroLog("failure:\t giftName is null", logger);
			return resultVO;
		}
		// 验证参数
		boolean checkFlag = CommonCheckUtil.checkCurrencyAndItemStr(sb, currencyPack, items, logger, xlsItemLoadService);
		if(!checkFlag) {
			setErroLog(sb.toString(), logger);
			return resultVO;
		}
		// 参数
		String giftParams = CommonCheckUtil.buildJsonStr(currencyPack, items);
		
		entity.setGiftId(Integer.valueOf(giftId));
		entity.setGiftName(giftName);
		entity.setGiftParams(giftParams);
		entity.setCreateTime(System.currentTimeMillis());
		entity.setIsDel(0);
		if(!saveWorldGift(entity)) {
			resultVO.setResult("fail");
			return resultVO;
		}
		resultVO.setResult("succ");
		resultVO.init(entity);
		return resultVO;
	}
	
	public boolean validGiftId(String giftId) {
		return validGiftId(giftId, new StringBuffer());
	}
	/**
	 * 验证礼包ID--不可以重复
	 * 
	 * @param giftId 礼包ID
	 * @return 礼包ID 不合理,返回false,反之返回true;
	 */
	public boolean validGiftId(String giftId, StringBuffer sb) {
		try{
			if (StringUtils.isBlank(giftId)) {
				setErroLog(sb, "failure:\t giftId is null", logger);
				return false;
			}
		}catch(Exception e){
			logger.error(e.getMessage(), e);
			return false;
		}
		return true;
	}
	public boolean validGiftIdExist(String giftId) {
		return validGiftIdExist(giftId, new StringBuffer());
	}
	public boolean validGiftIdExist(String giftId, StringBuffer sb) {
		WorldGiftEntity entity = this.worldGiftDAO.getWorldGiftById(giftId);
		if(null != entity) {
			setErroLog(sb, "failure:\t giftId already exist;", logger);
			return false;
		}
		return true;
	}
	
	private boolean saveWorldGift(WorldGiftEntity entity) {
		String worldServerId = gmConfig.worldserverid;
		if(StringUtils.isEmpty(worldServerId)) {
			logger.error("#WorldGiftService#saveWorldGift, worldServerId is null!");
		}
		logger.info("#WorldGiftService#saveWorldGift#start,save entity");
		ParamGenericDAO dao= new ParamGenericDAO();
		dao.setRId(LoginUserService.getLoginRegionId());
		dao.setSId(worldServerId);
		dao.setDbFactoryService(dbFactoryService);
		StringBuilder sb= new StringBuilder();
		
		logger.info("#WorldGiftService#saveWorldGift#start,save");
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
					.append(": " + entity.getGiftId());
			sb.append(
					"\t"	+ ExcelLangManagerService
									.readGmLang(GMLangConstants.WORLD_GIFT_PARAMS))
									.append(entity.getGiftParams());
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
}
