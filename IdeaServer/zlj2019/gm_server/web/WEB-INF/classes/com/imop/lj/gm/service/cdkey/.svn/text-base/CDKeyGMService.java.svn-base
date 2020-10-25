package com.imop.lj.gm.service.cdkey;

import java.util.ArrayList;
import java.util.List;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.core.util.StringUtils;
import com.imop.lj.db.model.CDKeyEntity;
import com.imop.lj.gm.config.GmConfig;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.dao.ParamGenericDAO;
import com.imop.lj.gm.dao.cdkey.CDKeyDAO;
import com.imop.lj.gm.model.CDKeyVO;
import com.imop.lj.gm.service.BaseService;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.insertDBBatch.InsertDBService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.service.xls.XlsItemLoadService;
import com.imop.lj.gm.utils.CDKeyUtil;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月17日 下午12:10:23
 * @version 1.0
 */

public class CDKeyGMService extends BaseService {
	public GmConfig gmConfig;
	
	public void setGmConfig(GmConfig gmConfig) {
		this.gmConfig = gmConfig;
	}

	private static final Logger logger = LoggerFactory.getLogger("gm.cdkey");

	private ExcelLangManagerService excelLangManagerService;
	/** 加载物品编辑器表格 Service */
	private XlsItemLoadService xlsItemLoadService;

	/** 命令管理 Service */
	private CmdManageService cmdManageService;
	
	private DBFactoryService dbFactoryService;

	/** dao */
	private CDKeyDAO cdkeyDAO;

	public CDKeyDAO getCdkeyDAO() {
		return cdkeyDAO;
	}

	public void setCdkeyDAO(CDKeyDAO cdkeyDAO) {
		this.cdkeyDAO = cdkeyDAO;
	}

	public ExcelLangManagerService getExcelLangManagerService() {
		return excelLangManagerService;
	}

	public void setExcelLangManagerService(
			ExcelLangManagerService excelLangManagerService) {
		this.excelLangManagerService = excelLangManagerService;
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

	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}

	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}

	/**
	 * 通过活动名称得到发奖礼包
	 * 
	 * @param passportId
	 * @return @return 发奖礼包列表
	 */
	public List<CDKeyVO> getCDKeyListByCDKeyId(String cdkeyId) {
		List<CDKeyEntity> entityList = cdkeyDAO
				.getCDKeyEntityListByActivityName(cdkeyId);
		return buildCDKeyVO(entityList);
	}

	/**
	 * 通过活动名称或创建日期查询
	 * 
	 * @param giftName
	 * @return
	 */
	public List<CDKeyVO> getCDKeyListByCDKeyIdOrDate(String cdkeyId,
			long createTime) {
		List<CDKeyEntity> entityList = cdkeyDAO
				.getCDKeyEntitiesByCDKeyIdOrCreateTime(cdkeyId,
						createTime);
		return buildCDKeyVO(entityList);
	}

	public List<CDKeyVO> getAllCDKeyList() {
		List<CDKeyEntity> entityList = cdkeyDAO.getAllCDKeyEntity();
		return buildCDKeyVO(entityList);
	}
	
	public List<CDKeyVO> getAllCDKeyListNoEcho() {
		List<CDKeyEntity> entityList = cdkeyDAO.getAllCDKeyEntityNoEcho();
		return buildCDKeyVO(entityList);
	}
	/**
	 * 通过openId查询
	 * 
	 * @param giftName
	 * @return
	 */
	public List<CDKeyVO> getCDKeyListByOpenId(String openId) {
		List<CDKeyEntity> entityList = cdkeyDAO
				.getCDKeyEntityListByOpenId(openId);
		return buildCDKeyVO(entityList);
	}
	/**
	 * 通过plansId giftId and groupId查询
	 * @return
	 */
	public List<CDKeyVO> getListByPlansIdGiftIdAndGroupId(int plansId, int giftId, int groupId) {
		List<CDKeyEntity> entityList = cdkeyDAO
				.getListByPlansIdGiftIdAndGroupId(plansId, giftId, groupId);
		return buildCDKeyVO(entityList);
	}

	private List<CDKeyVO> buildCDKeyVO(List<CDKeyEntity> entityList) {
		List<CDKeyVO> cdkeyVOList = new ArrayList<CDKeyVO>();
		CDKeyEntity entity = null;
		if (null != entityList) {
			for (int i = 0; i < entityList.size(); i++) {
				entity = (CDKeyEntity) entityList.get(i);
				CDKeyVO vo = new CDKeyVO(entity);
				cdkeyVOList.add(vo);
			}
		}
		return cdkeyVOList;

	}
	/**
	 * 取分组id，取数据库最大值加1
	 * @return
	 */
	public int getMaxGroupId(int plansId, int giftId) {
		int groupId = cdkeyDAO.getMaxGroupId(plansId, giftId);
		groupId ++;
		return groupId;
	}

	public List<CDKeyVO> createCDKey(int plansId, int giftId, int groupId, int createNum, String gmId) {

		List<CDKeyVO> resList = new ArrayList<CDKeyVO>();
			
		saveCDKeyEntity(resList, plansId, giftId, groupId, createNum, gmId);
		return resList;
	}

	public int delByPlansIdAndGiftId(int plansId, int giftId, int groupId) {
		return cdkeyDAO.delCDKey(plansId, giftId, groupId);
	}

	/**
	 * 创建完成后重新加载创建的数据展示
	 * @param resList
	 * @param serverId
	 * @param entity
	 */
	private void saveCDKeyEntity(List<CDKeyVO> resList, int plansId, int giftId, int groupId, int createNum, String gmId) {
		
		String worldServerId = gmConfig.worldserverid;
		if(StringUtils.isEmpty(worldServerId)) {
			logger.error("#CDKeyGMService#saveCDKeyEntity, worldServerId is null!");
		}
		long createTime = System.currentTimeMillis();
		
		ParamGenericDAO dao = new ParamGenericDAO();
		dao.setRId(LoginUserService.getLoginRegionId());
		dao.setSId(worldServerId);
		dao.setDbFactoryService(dbFactoryService);
		
		List<Object> entityList = new ArrayList<Object>();
		
		List<String> cdkeyList = CDKeyUtil.genCDKey(createNum);
		CDKeyEntity entity = null;
		CDKeyVO vo = null;
		StringBuffer sb = null;
		for(String cdkeyStr : cdkeyList) {
			entity = new CDKeyEntity();
			entity.setId(cdkeyStr);
			entity.setPlansId(plansId);
			entity.setGiftId(giftId);
			entity.setGmId(gmId);
			entity.setCreateTime(createTime);
			entity.setGroupId(groupId);
			entity.setState(0);
			entity.setIsDel(0);
			
			entityList.add(entity);
			
			vo = new CDKeyVO(entity);
			// for log
			sb = new StringBuffer();
			sb.append(
					ExcelLangManagerService
							.readGmLang(GMLangConstants.COMMON_LOGIN)
							+ ExcelLangManagerService
									.readGmLang(GMLangConstants.COMMON_REGION)
							+ "：").append(LoginUserService.getLoginRegionId());
			sb.append("\t"	+ ExcelLangManagerService
									.readGmLang(GMLangConstants.COMMON_LOGIN)
							+ ExcelLangManagerService
									.readGmLang(GMLangConstants.COMMON_SERVER)
							+ "：").append(worldServerId);
			sb.append("\t" + ExcelLangManagerService
									.readGmLang(GMLangConstants.ROLEACCOUNT)+ ":")
									.append(LoginUserService.getLoginUser().getUsername())
									.append("\t"+ ExcelLangManagerService.readGmLang(GMLangConstants.GM_PRIZE_INFO));
			sb.append("\t" + ExcelLangManagerService.readGmLang(GMLangConstants.CDKEY)
					+ ":" + cdkeyStr);
			sb.append("\t" + ExcelLangManagerService.readGmLang(GMLangConstants.CDKEY_PLANS_ID)
							+ ":" + plansId);
			sb.append("\t" + ExcelLangManagerService
							.readGmLang(GMLangConstants.CDKEY_GIFT_ID) + ":"
							+ giftId);
			sb.append("\t" + ExcelLangManagerService
							.readGmLang(GMLangConstants.CDKEY_GROUP_ID) + ":"
							+ groupId);
			logger.info(sb.toString());
			resList.add(vo);
		}
		
		// 插库
		InsertDBService.insertDBBatch(dao, entityList);
	}

}
