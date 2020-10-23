package com.imop.lj.gm.service.maintenance;

import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.db.model.PrizeInfo;
import com.imop.lj.gm.config.GmConfig;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.dao.ParamGenericDAO;
import com.imop.lj.gm.dao.UserInfoDAO;
import com.imop.lj.gm.dao.maintenance.PrizeDAO;
import com.imop.lj.gm.dao.sys.SysUserDAO;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.model.CurrencyConfig;
import com.imop.lj.gm.model.PrizeVO;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.DateUtil;
import com.imop.lj.gm.utils.StringUtil;

/**
 * GM补偿Service
 *
 *
 */
public class PrizeService {
	
	public GmConfig gmConfig;
	
	public void setGmConfig(GmConfig gmConfig) {
		this.gmConfig = gmConfig;
	}


	private PrizeDAO prizeDAO;

	private SysUserDAO sysUserDAO;

	private UserInfoDAO userInfoDAO;

	private DBFactoryService dbFactoryService;

	/** 命令管理 Service */
	private CmdManageService cmdManageService;

	/**GM补偿Service */
	private UserPrizeService userPrizeService;

	/** UserPrizeService log */
	private static final Logger logger = LoggerFactory.getLogger("db");


	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	public UserPrizeService getUserPrizeService() {
		return userPrizeService;
	}

	public void setUserPrizeService(UserPrizeService userPrizeService) {
		this.userPrizeService = userPrizeService;
	}

	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}

	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}

	public SysUserDAO getSysUserDAO() {
		return sysUserDAO;
	}

	public void setSysUserDAO(SysUserDAO sysUserDAO) {
		this.sysUserDAO = sysUserDAO;
	}

	public static Logger getLogger() {
		return logger;
	}

	public PrizeDAO getPrizeDAO() {
		return prizeDAO;
	}

	public void setPrizeDAO(PrizeDAO prizeDAO) {
		this.prizeDAO = prizeDAO;
	}

	public UserInfoDAO getUserInfoDAO() {
		return userInfoDAO;
	}

	public void setUserInfoDAO(UserInfoDAO userInfoDAO) {
		this.userInfoDAO = userInfoDAO;
	}

	/**
	 * 得到发奖礼包
	 *
	 * @param passportId
	 * @return @return 发奖礼包列表
	 */
	public List<PrizeVO> getPrizeList(String id) {
		List<PrizeVO> prizeVOList = new ArrayList<PrizeVO>();
		List<PrizeInfo> prizeList = prizeDAO.getPrizeList(id);
		if(null != prizeList){
			for (int i = 0; i < prizeList.size(); i++) {
				PrizeVO p = new PrizeVO();
				p.setPrize((PrizeInfo) prizeList.get(i));
				prizeVOList.add(p);
			}
		}
		return prizeVOList;
	}

	/**
	 * 删除发奖礼包
	 *
	 * @param id
	 *            发奖礼包id号
	 * @return
	 */
	public boolean delPrize(String id) {
		PrizeInfo s = prizeDAO.getById(PrizeInfo.class, Integer.valueOf(id));
		LoginUser loginUser = LoginUserService.getLoginUser();
		String result = cmdManageService.sendCmd("prizeclear",
				LoginUserService.getDBServer(),false).toString();
		if (result.indexOf("error")==-1&&prizeDAO.delete(s)) {
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
							.readGmLang(GMLangConstants.COMMON_SERVER)
					+ ":"
					+ loginUser.getLoginServerId()
					+ "\t"
					+ ExcelLangManagerService
							.readGmLang(GMLangConstants.COMMON_DELETE)
					+ ExcelLangManagerService.readGmLang(GMLangConstants.PRIZE)
					+ "ID" + ":" + s.getPrizeId() + "\t at:"
					+ (DateUtil.formatDateHour(new Date()));
			logger.info(info);
			return true;
		} else {
			return false;
		}

	}

	/**
	 * 新增发奖礼包
	 *
	 * @param passportIds
	 *            玩家账号
	 * @param currency
	 *            货币类型
	 * @param coinNum
	 *            数量
	 * @param item
	 *            物品
	 * @param petTemplateId
	 *            宠物模板ID
	 * @param petLevel
	 *            宠物级别
	 * @return
	 */
	public Boolean addPrize(String serverId, String currencyPack, String item, String prizeId, String prizeName) {
		PrizeInfo prize = new PrizeInfo();
		if(!validPrizeId(prizeId)){
			return false;
		};
		prize.setPrizeId(Integer.valueOf(prizeId));

		if (StringUtils.isNotBlank(prizeName)) {
			prize.setPrizeName(prizeName);
		}else{
			 setErroLog("failure:\t prizeName is null");
			 return false;
		}
		if (StringUtils.isNotBlank(currencyPack)) {
			/* Mask.java
			value.put(-1, GMLangConstants.MONEY_ALL);
			value.put(3, GMLangConstants.SYS_BOND);
			value.put(2, GMLangConstants.MONEY_GOLD);
			value.put(4, GMLangConstants.CURRENCY_HONOR);
			value.put(5, GMLangConstants.CURRENCY_EXP);
			value.put(6, GMLangConstants.POWER);
			value.put(7, GMLangConstants.HUNT_SUIPIAN);
			value.put(8, GMLangConstants.JEWELRYALLANCE_STONE);
			*/
			/*gm.cfg.js
			config.currencyNum = 10000;//GM补偿和礼包奖励[钻石]数量上限
			config.honorNum = 10000;		//声望
			config.powerNum = 1000;		//体力
			config.suipianNum = 10;		//商魂碎片
			config.jewelryStoneNum   = 1000;		//原石
			config.goldNum = 1000000000;//GM补偿和礼包奖励[金币]数量上限
			config.itemNum = 999;//GM补偿和礼包奖励物品数量上限
			*/
			Set<String> currencySet = new HashSet<String>();
			String[] currencyStrs = currencyPack.split(";");
			for (String currencyStr : currencyStrs) {
				String[] curr = currencyStr.split("=");
				String currency = curr[0];
				String coinNum = curr[1];
				CurrencyConfig cc = UserPrizeService.getCurrencyConfigMap().get(Integer.parseInt(currency));
				if(cc == null){
					setErroLog("failure:\t " + ExcelLangManagerService.readGmLang(GMLangConstants.CURRENCY_TYPE_ERROR) + ", currencyId = " + currency);
					return false;
				}
				
				if(!StringUtil.srtLDE(coinNum, cc.getMaxValue())){
					setErroLog("failure:\t " + ExcelLangManagerService.readGmLang(GMLangConstants.CURRENCY_NUM_WRONG) + ", currencyId = " + currency);
					return false;
				}
				
				if(currencySet.contains(currency)){
					setErroLog("failure:\t " + ExcelLangManagerService.readGmLang(GMLangConstants.CURRENCY_TYPE_DUP));
					return false;
				}else{
					currencySet.add(currency);
				}
			}
			
			prize.setCoin(currencyPack);
		}
		
		if(StringUtils.isNotBlank(item)){
			String[] arr=item.split(";");
			boolean itemFlag = true;
			ArrayList<String> itemArray = new ArrayList<String>();
			for(int j=0;j<arr.length;j++){
				itemFlag = userPrizeService.validItem(arr[j]);
				if(!itemFlag) {
					setErroLog("failure:\t"+ExcelLangManagerService.readGmLang(GMLangConstants.ITEM_NUM_WRONG));
					break;
				}
				String itId[]=arr[j].split("=");
				if(StringUtils.isBlank(itId[0])){
					itemFlag = false;
					break;
				}
				itId[0] = itId[0].trim();
				if(itemArray.contains(itId[0])){
					itemFlag = false;
					setErroLog("failure:\t"+"("+itId[0]+")"+ExcelLangManagerService.readGmLang(GMLangConstants.ECHO));
					return false;
				}else if(!userPrizeService.authItem(itId[0])){
					itemFlag = false;
					setErroLog("failure:\t"+"("+itId[0]+")"+ExcelLangManagerService.readGmLang(GMLangConstants.ITEM_WRONG));
					return false;
				}else{
					itemArray.add(itId[0]);
				}
			}
			prize.setItem(item);
		}
		prize.setCreateTime(new Timestamp(new Date().getTime()));
		if(!savePrize(serverId, currencyPack, item, prizeId, prize)){
			return false;
		};
		return true;
	}

	/**
	 * 保存礼包
	 * @param serverId 服务器ID
	 * @param currency 货币类型
	 * @param coinNum  货币数量
	 * @param item     物品
	 * @param petTemplateId  宠物模板ID
	 * @param petLevel  宠物级别
	 * @param prizeId  礼包ID
	 * @param loginUser
	 * @param sb
	 * @param prize
	 */
	private boolean savePrize(String serverId, String currencyPack, String item, String prizeId, PrizeInfo prize) {
		ParamGenericDAO dao= new ParamGenericDAO();
		dao.setRId(LoginUserService.getLoginRegionId());
		dao.setSId(serverId);
		dao.setDbFactoryService(dbFactoryService);
		StringBuilder sb= new StringBuilder();
		if (dao.saveObject(prize) != null) {
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
							+ "：").append(serverId);
			sb.append(
					"\t"
							+ ExcelLangManagerService
									.readGmLang(GMLangConstants.ROLEACCOUNT)
							+ ": ").append(LoginUserService.getLoginUser().getUsername()).append(
					"\t"
							+ ExcelLangManagerService
									.readGmLang(GMLangConstants.PRIZE));
			sb.append(
					"\t"
							+ ExcelLangManagerService
									.readGmLang(GMLangConstants.PRIZE_ID))
					.append(": " + prizeId);
			sb
					.append(
							"\t"
									+ ExcelLangManagerService
											.readGmLang(GMLangConstants.GM_PRIZE_INFO1))
					.append(currencyPack);
			sb.append(
					ExcelLangManagerService
							.readGmLang(GMLangConstants.GM_PRIZE_INFO2))
					.append(item + "\t" + DateUtil.formatDateHour(new Date()));

			logger.info(sb.toString());
			return true;
		}else{
			return false;
		}
	}

	/**
	 * 设置日志信息
	 * @param sb
	 * @return
	 */
	private void setErroLog(String logInfo) {
		StringBuilder sb = new StringBuilder();
		sb.append(logInfo);
		logger.info(sb.toString());
	}

	/**
	 * 验证礼包ID
	 * @param prizeId 礼包ID
	 * @return 礼包ID 不合理,返回false,反之返回true;
	 */
	private boolean validPrizeId(String prizeId) {
		try{
			StringBuilder sb = new StringBuilder();
			if (StringUtils.isBlank(prizeId)) {
				sb.append("failure:\t prizeId is null");
				logger.info(sb.toString());
				return false;
			} else if (Integer.valueOf(prizeId) < gmConfig.prizeID) {
				sb.append("failure:\t prizeId is less than "+gmConfig.prizeID);
				logger.info(sb.toString());
				return false;
			}
		}catch(Exception e){
			logger.info(e.getMessage(), e);
			return false;
		}
		return true;
	}


	/**
	 * 验证账号
	 *
	 * @param prizeId
	 * @return
	 */
	public boolean validatePrizeId(String prizeId) {
		try{
			if (StringUtils.isBlank(prizeId)) {
				return false;
			} else if (Integer.valueOf(prizeId.trim()) < 1000
					|| prizeDAO.queryPrize(prizeId) != null) {
				return false;
			}
		} catch (Exception e) {
			logger.info(e.getMessage(), e);
			return false;
		}
		return true;
	}

}
