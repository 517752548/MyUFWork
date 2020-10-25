package com.imop.lj.gm.service.maintenance;

import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.regex.Pattern;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.db.model.HumanEntity;
import com.imop.lj.db.model.UserPrize;
import com.imop.lj.gm.config.GmConfig;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.constants.Mask;
import com.imop.lj.gm.dao.ParamGenericDAO;
import com.imop.lj.gm.dao.maintenance.UserPrizeDAO;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.dto.UserPrizeRes;
import com.imop.lj.gm.model.SysUser;
import com.imop.lj.gm.model.UserPrizeVO;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.insertDBBatch.InsertDBService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.service.xls.XlsItemLoadService;
import com.imop.lj.gm.utils.DateUtil;
import com.imop.lj.gm.utils.StringUtil;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月20日 上午9:19:03
 * @version 1.0
 */

public class UserPrizeAllService {
	public GmConfig gmConfig;
	
	public void setGmConfig(GmConfig gmConfig) {
		this.gmConfig = gmConfig;
	}

	private UserPrizeDAO userPrizeDAO;
	
	private DBFactoryService dbFactoryService;

	/** db log */
	private static final Logger logger = LoggerFactory.getLogger("db");
	
	/**
	 * XXX 全服奖励条件之一，等级临界值
	 */
	public static int AllPrizeLevelMin = 40;
	/**
	 * XXX 全服奖励条件之一，最近一次登录时间临界值
	 */
	public static int AllPrizeLoginDayMin = 7;

	/** 加载物品编辑器表格 Service */
	private XlsItemLoadService xlsItemLoadService;

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

	public UserPrizeDAO getUserPrizeDAO() {
		return userPrizeDAO;
	}

	public void setUserPrizeDAO(UserPrizeDAO userPrizeDAO) {
		this.userPrizeDAO = userPrizeDAO;
	}
	
	/**
	 * 得到GM补偿实体
	 * 
	 * @param passportId
	 * @param type
	 *            补偿类型
	 * @return @return GM补偿实体列表
	 */
	public List<UserPrizeVO> getUserPrizeList(String passportId, String type,
			String id, String begin_time, String end_time, String date) {
		String begintime = "";
		if (StringUtils.isNotBlank(date)) {
			if (StringUtils.isNotBlank(begin_time)) {
				begintime = (date + " " + begin_time);
			} else {
				begintime = (date + " " + "00:00:00");
			}
		}
		String endtime = "";
		if (StringUtils.isNotBlank(date)) {
			if (StringUtils.isNotBlank(end_time)) {
				endtime = (date + " " + end_time);
			} else {
				endtime = (date + " " + "23:59:59");
			}
		}
		if (date != null && DateUtil.isAfterToday(date)) {
			return null;
		}
		List<UserPrizeVO> userPrizeVOList = new ArrayList<UserPrizeVO>();
		List<UserPrize> userPrizeList = userPrizeDAO.getUserPrizeList(
				passportId, type, id, begintime, endtime);
		for (int i = 0; i < userPrizeList.size(); i++) {
			UserPrizeVO p = new UserPrizeVO();
			p.setUserPrize((UserPrize) userPrizeList.get(i));
			userPrizeVOList.add(p);
		}

		return userPrizeVOList;
	}

	/**
	 * 删除GM补偿实体
	 * 
	 * @param id
	 *            GM补偿实体id号
	 * @return
	 */
	public boolean delUserPrize(String id) {
		UserPrize s = userPrizeDAO
				.getById(UserPrize.class, Integer.valueOf(id));
		LoginUser loginUser = LoginUserService.getLoginUser();
		if (userPrizeDAO.delete(s)) {
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
					+ ExcelLangManagerService
							.readGmLang(GMLangConstants.GM_USER_PRIZE) + "ID"
					+ ":" + s.getId() + "\t at:"
					+ (DateUtil.formatDateHour(new Date()));
			logger.info(info);
			return true;
		} else {
			return false;
		}

	}

	/**
	 * 新增GM补偿实体
	 * 
	 * @param reason
	 *            补偿原因
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
	public List<UserPrizeRes> addUserPrize(DBServer svr, String serverId,
			String userPrizeName, String reason,
			String currencyPack, String item) {
		return addUserPrize(svr, serverId, userPrizeName, reason,
				currencyPack, item, "");
	}

	public List<UserPrizeRes> addUserPrize(DBServer svr, String serverId,
			String userPrizeName, String reason,
			String currencyPack, String item, String specialItem) {
		List<UserPrizeRes> resList = validateRights(serverId);
		if (resList.size() != 0) {
			return resList;
		}

		resList = validateReason(reason, resList);
		if (resList.size() != 0) {
			return resList;
		}

		resList = new ArrayList<UserPrizeRes>();
		if (StringUtils.isBlank(userPrizeName)) {
			UserPrizeRes userPrizeRes = new UserPrizeRes();
			userPrizeRes.setResult("failure:\t userPrizeName is  null!");
			resList.add(userPrizeRes);
			logger.info("failure:\t userPrizeName is  null!");
			return resList;
		}
		
		//存库list
		List<Object> userPrizeForDB = new ArrayList<Object>();
		ParamGenericDAO userInfoDAO = new ParamGenericDAO();
		userInfoDAO.setRId(svr.getRegionId());
		userInfoDAO.setSId(serverId);
		userInfoDAO.setDbFactoryService(dbFactoryService);
		
		
		ParamGenericDAO humanDao = new ParamGenericDAO();
		humanDao.setRId(svr.getRegionId());
		humanDao.setSId(serverId);
		humanDao.setDbFactoryService(dbFactoryService);
		
		long now = System.currentTimeMillis();
		long sevenDayBefor = TimeUtils.getBeginOfDay(now) - AllPrizeLoginDayMin * TimeUtils.DAY;
		List<HumanEntity> tineyHumanList = humanDao.getAllTineyHumanEntity(new Timestamp(sevenDayBefor));
		if(null != tineyHumanList) {
			for (HumanEntity tineyHuman : tineyHumanList) {

				UserPrize userPrize = new UserPrize();
				userPrize.setPassportId(tineyHuman.getPassportId());
				userPrize.setUserPrizeName(userPrizeName);
				userPrize.setCharId(tineyHuman.getId());
	
				// 货币
				if (StringUtils.isNotBlank(currencyPack)) {
					Set<String> currencySet = new HashSet<String>();
					String[] currencyStrs = currencyPack.split(";");
					for (String currencyStr : currencyStrs) {
						String[] curr = currencyStr.split("=");
						String currency = curr[0];
						String coinNum = curr[1];
	
						if ("2".equals(currency)) {
							if (StringUtil.srtLDE(coinNum, gmConfig.goldNum)) {
								// userPrize.setCoin(currency + "=" + coinNum);
							} else {
								resList = setError(
										resList,
										"failure:\t "
												+ ExcelLangManagerService
														.readGmLang(GMLangConstants.GOLD_NUM_WRONG));
								return resList;
							}
						} else if ("3".equals(currency)) {// 内币
							if (StringUtil.srtLDE(coinNum, gmConfig.sysBond)) {
								// userPrize.setCoin(currency + "=" + coinNum);
							} else {
								resList = setError(
										resList,
										"failure:\t "
												+ ExcelLangManagerService
														.readGmLang(GMLangConstants.CURRENCY_NUM_WRONG));
								return resList;
							}
						} else if ("9".equals(currency)) {
							// 礼券
							if (StringUtil.srtLDE(coinNum, gmConfig.giftBond)) {
								// userPrize.setCoin(currency + "=" + coinNum);
							} else {
								resList = setError(
										resList,
										"failure:\t "
												+ ExcelLangManagerService
														.readGmLang(GMLangConstants.CURRENCY_NUM_WRONG));
								return resList;
							}
	
						} else {
							resList = setError(
									resList,
									"failure:\t "
											+ ExcelLangManagerService
													.readGmLang(GMLangConstants.CURRENCY_TYPE_ERROR));
							return resList;
						}
	
						if (currencySet.contains(currency)) {
							return setError(
									resList,
									"failure:\t "
											+ ExcelLangManagerService
													.readGmLang(GMLangConstants.CURRENCY_TYPE_DUP));
						} else {
							currencySet.add(currency);
						}
					}
					userPrize.setCoin(currencyPack);
				}
	
				// 设置物品
				if (StringUtils.isNotBlank(item)) {
					String[] arr = item.split(";");
					boolean itemFlag = true;
					ArrayList<String> itemArray = new ArrayList<String>();
					for (int j = 0; j < arr.length; j++) {
						itemFlag = validItem(arr[j]);
						if (!itemFlag) {
							break;
						}
						String itId[] = arr[j].split("=");
						if (StringUtils.isBlank(itId[0])) {
							itemFlag = false;
							break;
						}
						itId[0] = itId[0].trim();
						if (itemArray.contains(itId[0])) {
							itemFlag = false;
							resList = setError(
									resList,
									"failure:\t"
											+ "("
											+ itId[0]
											+ ")"
											+ ExcelLangManagerService
													.readGmLang(GMLangConstants.ECHO));
							return resList;
						} else if (!authItem(itId[0])) {
							itemFlag = false;
							resList = setError(
									resList,
									"failure:\t"
											+ "("
											+ itId[0]
											+ ")"
											+ ExcelLangManagerService
													.readGmLang(GMLangConstants.ITEM_WRONG));
							return resList;
						} else {
							itemArray.add(itId[0]);
						}
					}
					if (itemFlag) {
						userPrize.setItem(item);
					} else {
						resList = setError(
								resList,
								"failure:\t"
										+ ExcelLangManagerService
												.readGmLang(GMLangConstants.ITEM_NUM_WRONG));
						return resList;
					}
				}
	
				// 特殊道具
				if (StringUtils.isNotBlank(specialItem)) {
					userPrize.setItemParams(specialItem);
				}
				// 设置原因
				if (StringUtils.isNotBlank(reason)) {
					userPrize.setType(Integer.valueOf(reason));
				}
	
				userPrize.setCreateTime(new Timestamp(now));
				// 设置过期时间
				userPrize.setExpireTime(new Timestamp(now
						+ gmConfig.prizeValidPeriod));
	
				logger.info("UserPrizeAllService#addUserPrize#serverId=" + serverId 
						+ ", userPrizeName =" + userPrizeName
						+ ", tineyHuman.getPassportId() =" + tineyHuman.getPassportId() 
						+ ", humanChartId=" + tineyHuman.getId()
						+ ", item=" + item 
						);
				// 填加到list中
				userPrizeForDB.add(userPrize);
			}
		}
		// 分批保存保存
		InsertDBService.insertDBBatch(userInfoDAO, userPrizeForDB);
		
		UserPrizeRes vo = new UserPrizeRes();
		vo.setDbId(serverId);
		vo.setUserPrizeName(userPrizeName);
		vo.setResult("successful!");
		vo.setCoin(currencyPack);
		vo.setItem(item);
		resList.add(vo);
		
		return resList;
	}

	/**
	 * 验证passport的真实性
	 * 
	 * @param passportId
	 *            passportID
	 * @return passportID正确返回真,反之返回假
	 * @throws Exception
	 */
	public boolean authPassport(String passportId, String passName)
			throws Exception {
		try {
			if (userPrizeDAO.getPassport(passportId, passName)) {
				return true;
			} else {
				return false;
			}
		} catch (Exception e) {
			e.printStackTrace();
			throw e;
		}
	}

	/**
	 * 验证用户权限
	 * 
	 * @param serverId
	 * @return
	 */
	private List<UserPrizeRes> validateRights(String serverId) {
		StringBuilder sb = new StringBuilder();
		List<UserPrizeRes> resList = new ArrayList<UserPrizeRes>();
		UserPrizeRes userPrizeRes = new UserPrizeRes();
		SysUser sysUser = null;
		try {
			sysUser = dbFactoryService.getUserByName(LoginUserService
					.getLoginUser().getUsername(), LoginUserService
					.getLoginUser().getLoginRegionId());
		} catch (Exception e) {
			e.printStackTrace();
		}
		if (sysUser == null || sysUser.getServerIds().indexOf(serverId) == -1) {
			String info = "failure:\t(你全服奖励的"
					+ ExcelLangManagerService
							.readGmLang(GMLangConstants.COMMON_SERVER)
					+ serverId
					+ "):与你所拥有的权限服务器id不一致。(db.xml的id)"
					+ ExcelLangManagerService
							.readGmLang(GMLangConstants.NO_RIGHT);
			userPrizeRes.setResult(info);
			sb.append(info);
			logger.info(sb.toString());
			resList.add(userPrizeRes);
			return resList;
		} else {
			return resList;
		}
	};

	/**
	 * 
	 * 多个用户账号字符串传入空条件验证
	 * 
	 * @param serverId
	 * @param resList
	 *            结果列表
	 * @return resList
	 */
	private List<UserPrizeRes> validatePassportIds(String passportIds,
			List<UserPrizeRes> resList) {
		StringBuilder sb = new StringBuilder();
		UserPrizeRes userPrizeRes = new UserPrizeRes();
		if (StringUtils.isBlank(passportIds)) {
			String info = "failure:\t"
					+ ExcelLangManagerService
							.readGmLang(GMLangConstants.USERID_WRONG);
			userPrizeRes.setResult(info);
			sb.append(info);
			resList.add(userPrizeRes);
			logger.info(sb.toString());
			return resList;
		} else {
			return resList;
		}
	};

	private List<UserPrizeRes> validateReason(String reason,
			List<UserPrizeRes> resList) {
		if (Mask.getMap("rolePrizeReason1").get(Integer.parseInt(reason)) == null) {
			UserPrizeRes userPrizeRes = new UserPrizeRes();
			String info = "failure:\t"
					+ ExcelLangManagerService
							.readGmLang(GMLangConstants.REASON_TYPE_ERROR)
					+ ", reason = " + reason;
			userPrizeRes.setResult(info);
			userPrizeRes.setResult(info);
			resList.add(userPrizeRes);
			logger.info(info);
			return resList;
		} else {
			return resList;
		}
	}

	/**
	 * 验证每条补偿账号的格式
	 * 
	 * @param resList
	 *            操作结果
	 * @param passportInfo
	 *            每条补偿账号信息(包括用户账号和用户名)
	 * @param u
	 * @return
	 */
	private List<UserPrizeRes> authPsInfoFmt(String passportInfo,
			String idName[], List<UserPrizeRes> resList) {
		StringBuilder sb = new StringBuilder();
		UserPrizeRes userPrizeRes = new UserPrizeRes();
		// if (idName.length < 2) {
		// userPrizeRes.setResult("failure:\t("
		// + passportInfo
		// + ")\t"
		// + ExcelLangManagerService
		// .readGmLang(GMLangConstants.USERID_WRONG));
		// resList.add(userPrizeRes);
		// sb.append("failure:\t("
		// + passportInfo
		// + ")\t"
		// + ExcelLangManagerService
		// .readGmLang(GMLangConstants.USERID_WRONG));
		// logger.info(sb.toString());
		// return resList;
		// }
		// else {
		String passportId = idName[0];
		// boolean b = Pattern.matches("^([0-9]+)$", passportId);
		if (passportId == null || passportId.isEmpty()) {
			userPrizeRes.setResult("failure:\t("
					+ passportId
					+ ")\t"
					+ ExcelLangManagerService
							.readGmLang(GMLangConstants.USERID_WRONG));
			resList.add(userPrizeRes);
			sb.append("failure:\t("
					+ passportId
					+ ")\t"
					+ ExcelLangManagerService
							.readGmLang(GMLangConstants.USERID_WRONG));
			logger.info(sb.toString());
			return resList;
		}
		// String passportName = idName[1];
		// if (StringUtils.isBlank(passportName)) {
		// userPrizeRes.setResult("failure:\t("
		// + passportInfo
		// + ")\t"
		// + ExcelLangManagerService
		// .readGmLang(GMLangConstants.USENAME_FMT_WRONG));
		// resList.add(userPrizeRes);
		// sb.append("failure:\t("
		// + passportInfo
		// + ")\t"
		// + ExcelLangManagerService
		// .readGmLang(GMLangConstants.USENAME_FMT_WRONG));
		// logger.info(sb.toString());
		// return resList;
		// }
		// }
		return resList;

	}

	/**
	 * 验证补偿的玩家账号存在性
	 * 
	 * @param passportInfo
	 *            每条补偿账号信息
	 * @param u
	 *            玩家信息
	 * @return 操作结果
	 */
//	private List<UserPrizeRes> authPlayer(String passportInfo,
//			HumanEntity human, String idName[], List<UserPrizeRes> resList) {
//		StringBuilder sb = new StringBuilder();
//		UserPrizeRes userPrizeRes = new UserPrizeRes();
//		if (human == null || !human.getPassportId().equals(idName[0])) {
//			userPrizeRes.setResult("failure:\t passPortId(" + passportInfo
//					+ ") is not exist!");
//			resList.add(userPrizeRes);
//			sb.append("failure:\t passPortId(" + passportInfo
//					+ ") is not exist!");
//			logger.info(sb.toString());
//			return resList;
//		}
//		// 这么加主要是因为不影响他之前的结构,想改回去的时候直接把这个else去掉,把之前的注释打开即可
//		else {
//			return resList;
//		}
//	}

	/**
	 * 设置错误提示
	 * 
	 * @param resList
	 * @param hint
	 *            错误提示
	 * @return 操作结果
	 */
	private List<UserPrizeRes> setError(List<UserPrizeRes> resList, String hint) {
		StringBuilder sb = new StringBuilder();
		UserPrizeRes userPrizeRes = new UserPrizeRes();
		userPrizeRes.setResult(hint);
		resList.add(userPrizeRes);
		sb.append(hint);
		logger.info(sb.toString());
		return resList;
	}

	/**
	 * 验证物品填写格式
	 * 
	 * @param itemInfo
	 *            每条补偿物品信息
	 * @return 不符合返回false,反之返回true
	 */
	public boolean validItem(String itemInfo) {
		itemInfo = itemInfo.trim();
		boolean b = Pattern
				.matches("^[0-9]{1,10}=[0-9]{1,3}$", itemInfo.trim());
		if (!b) {
			return false;
		}
		String itId[] = itemInfo.split("=");
		if (StringUtil.srtGE(itId[1], gmConfig.itemNum)
				|| StringUtil.srtLE(itId[1], 0)) {
			return false;
		}
		return true;
	}

	/**
	 * 验证passport填写格式
	 * 
	 * @param passportInfo
	 *            每条补偿物品信息
	 * @return 不符合返回false,反之返回true
	 */
	public boolean validPassportInfo(String passportInfo) {
		// passportInfo = passportInfo.trim();
		// boolean b = Pattern.matches("^[0-9]{1,10}=.+$", passportInfo.trim());
		// if (!b) {
		// return false;
		// }
		// return true;
		return StringUtils.isBlank(passportInfo);
	}

	/**
	 * 保存UserPrize
	 * 
	 * @param passportInfo
	 *            账号信息
	 * @param resList
	 *            返回结果列表
	 * @param serverId
	 *            服务器ID
	 * @param userPrize
	 *            补偿实体
	 * @return 结果列表
	 */
	@SuppressWarnings("unused")
	@Deprecated
	private List<UserPrizeRes> saveUserPrize(String passportInfo,
			List<UserPrizeRes> resList, String serverId, UserPrize userPrize,
			String currency, String item, String params) {
		ParamGenericDAO dao = new ParamGenericDAO();
		dao.setRId(LoginUserService.getLoginRegionId());
		dao.setSId(serverId);
		dao.setDbFactoryService(dbFactoryService);
		UserPrizeRes userPrizeRes = new UserPrizeRes();
//		if (dao.saveObject(userPrize) != null) {
			UserPrizeVO userPrizeVo = new UserPrizeVO();
			userPrizeVo.setUserPrize(userPrize);
			userPrizeRes.setResult("success");
			userPrizeRes.setDbId(serverId);
			userPrizeRes.setUserIdAndName(passportInfo);
			userPrizeRes.setType(userPrize.getType());
			userPrizeRes.setCoin(userPrizeVo.getFormatCoin());
			userPrizeRes.setItem(userPrizeVo.getFormatItem());
			userPrizeRes.setUserPrizeName(userPrize.getUserPrizeName());
			userPrizeRes.setItemParams(userPrize.getItemParams());
			StringBuilder sb = new StringBuilder();
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
							+ ":")
					.append(LoginUserService.getLoginUser().getUsername())
					.append("\t"
							+ ExcelLangManagerService
									.readGmLang(GMLangConstants.GM_PRIZE_INFO));
			sb.append("\t"
					+ ExcelLangManagerService
							.readGmLang(GMLangConstants.USER_PRIZE_NAME) + ":"
					+ userPrize.getUserPrizeName());
			sb.append(
					"\t"
							+ ExcelLangManagerService
									.readGmLang(GMLangConstants.GM_PRIZE_INFO1)
							+ "\t").append(currency);
			// .append(
			// "\t"
			// + ExcelLangManagerService
			// .readGmLang(GMLangConstants.NUM) + "：")
			// .append(coinNum);
			sb.append(
					"\t"
							+ ExcelLangManagerService
									.readGmLang(GMLangConstants.GM_PRIZE_INFO2)
							+ "\t").append(item);
			sb.append(
					"\t"
							+ ExcelLangManagerService
									.readGmLang(GMLangConstants.GM_PRIZE_ITEM_PARAMS)
							+ "\t").append(params);
			logger.info(sb.toString());
//		}
		resList.add(userPrizeRes);
		return resList;
	}

	/**
	 * 验证物品的真实性
	 * 
	 * @param itemId
	 *            物品ID
	 * @return 物品ID正确返回真,反之返回假
	 */
	public boolean authItem(String itemId) {
		if (StringUtils.isBlank(itemId)) {
			return true;
		}
		itemId = itemId.trim();
		logger.error(itemId);
		HashMap<String, Map<String, String>> xlsData = xlsItemLoadService
				.getXlsData();
		Map<String, String> itemMap = xlsData.get("items");
		if (itemMap != null && itemMap.containsKey(itemId)) {
			return true;
		}
		return false;
	}

}
