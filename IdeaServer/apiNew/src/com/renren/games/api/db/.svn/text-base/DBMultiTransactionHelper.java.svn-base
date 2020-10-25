package com.renren.games.api.db;

import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.List;

import net.sf.json.JSONObject;

import org.hibernate.LockMode;
import org.hibernate.Query;
import org.hibernate.Session;

import com.renren.games.api.core.Globals;
import com.renren.games.api.core.Loggers;
import com.renren.games.api.core.config.ApiConfig;
import com.renren.games.api.core.config.QQConfig;
import com.renren.games.api.db.HibernateDBServcieImpl.HibernateCallback;
import com.renren.games.api.db.model.QQOrderEntity;
import com.renren.games.api.db.model.QQTaskMarketEntity;
import com.renren.games.api.db.po.QQTaskMarket;
import com.renren.games.api.enums.MarketStepState;
import com.renren.games.api.service.QQMarketService;

@SuppressWarnings("rawtypes")
public class DBMultiTransactionHelper {

	private DBService dbService;

	public DBMultiTransactionHelper(DBService dbService) {
		this.dbService = dbService;
	}

	/**
	 * @description: 查找没有兑换的订单，并将订单的兑换状态转化成已经兑换状态，保存同一事物完成
	 * @return
	 */
	public List<QQOrderEntity> chargeQQOrderTransaction(final long charId, final String appid, final String uuid) {
		HibernateCallback<List<QQOrderEntity>> callBack = new HibernateCallback<List<QQOrderEntity>>() {
			@Override
			public List<QQOrderEntity> doCall(Session session) {
				List<QQOrderEntity> entityList = new ArrayList<QQOrderEntity>();
				String hql = "from QQOrderEntity as order ";
				String wherehql = "where charId=:charId and appid=:appid and charged=:charged";
				hql = hql + wherehql;

				Query qry = session.createQuery(hql);
				qry.setLong("charId", charId);
				qry.setString("appid", appid);
				qry.setInteger("charged", QQConfig.QQ_NOT_CHARGE);
				// hibernate 悲观锁
				qry.setLockMode("order", LockMode.UPGRADE);
				List resultList = qry.list();
				if (resultList != null && !resultList.isEmpty()) {
					for (Object o : resultList) {
						QQOrderEntity entity = (QQOrderEntity) o;
						entityList.add(entity);
						entity.setCharged(QQConfig.QQ_CHARGED);
						entity.setChargeDate(new Timestamp(System.currentTimeMillis()));
						session.save(entity);
					}
				}
				return entityList;
			}
		};
		try {
			if (dbService instanceof HibernateDBServcieImpl) {
				return ((HibernateDBServcieImpl) dbService).call(callBack);
			} else {
				throw new UnsupportedOperationException();
			}
		} catch (Exception e) {
			Loggers.platformlocalLogger.error(uuid + "charge qqorder error:", e);
			return new ArrayList<QQOrderEntity>();
		}
	}

	/**
	 * 只有2、3步骤获得集市奖励
	 * 
	 * @param openid
	 * @param appid
	 * @param step
	 * @param uuid
	 * @return
	 */
	public String getQQMarketAward(final String openid, final String appid, final String uuid) {
		HibernateCallback<String> callBack = new HibernateCallback<String>() {
			@Override
			public String doCall(Session session) {
				final Timestamp now = new Timestamp(System.currentTimeMillis());

				String hql = "from QQTaskMarketEntity as market ";
				String wherehql = "where appid=:appid and openid=:openid ";

				hql = hql + wherehql;

				Query qry = session.createQuery(hql);
				qry.setString("appid", appid);
				qry.setString("openid", openid);
				// hibernate 悲观锁
				qry.setLockMode("market", LockMode.UPGRADE);

				List resultList = qry.list();
				QQTaskMarketEntity entity = null;
				if (resultList != null && !resultList.isEmpty()) {
					entity = (QQTaskMarketEntity) resultList.get(0);

					int step1Status = entity.getStep1Status();

					int step2Status = entity.getStep2Status();

					int step3Status = entity.getStep3Status();

					int step4Status = entity.getStep4Status();

					JSONObject jo = new JSONObject();
					boolean flag = false;
					if (step1Status == MarketStepState.CREATE_AWARD.getIndex()) {
						flag = true;
						jo.put("step1payitem", entity.getStep1PayItem());
						jo.put("step1billno", entity.getStep1Billno());
						
						entity.setStep1Status(MarketStepState.GET_AWARD.getIndex());
						entity.setStep1UpdateTime(now);
					}

					if (step2Status == MarketStepState.CREATE_AWARD.getIndex()) {
						flag = true;
						jo.put("step2payitem", entity.getStep2PayItem());
						jo.put("step2billno", entity.getStep2Billno());
						
						entity.setStep2Status(MarketStepState.GET_AWARD.getIndex());
						entity.setStep2UpdateTime(now);
					}

					if (step3Status == MarketStepState.CREATE_AWARD.getIndex()) {
						flag = true;
						jo.put("step3payitem", entity.getStep3PayItem());
						jo.put("step3billno", entity.getStep3Billno());
						
						entity.setStep3Status(MarketStepState.GET_AWARD.getIndex());
						entity.setStep3UpdateTime(now);
					}

					if (step4Status == MarketStepState.CREATE_AWARD.getIndex()) {
						flag = true;
						jo.put("step4payitem", entity.getStep4PayItem());
						jo.put("step4billno", entity.getStep4Billno());
						
						entity.setStep4Status(MarketStepState.GET_AWARD.getIndex());
						entity.setStep4UpdateTime(now);
					}

					// 存储
					session.save(entity);

					// 放入缓存里
					QQTaskMarket taskMarket = new QQTaskMarket();
					taskMarket.fromEntity(entity);
					Globals.getQqCacheService().putQQTaskMarket(taskMarket.getId(), taskMarket);
					if (flag) {
						JSONObject resultjo = new JSONObject();
						resultjo.put("ret", 0);
						resultjo.put("msg", "ok");
						resultjo.put("data", jo.toString());
						return resultjo.toString();
					} else {
						JSONObject resultjo = new JSONObject();
						resultjo.put("ret", 4);
						resultjo.put("msg", "no market award");
						return resultjo.toString();
					}
				} else {
					JSONObject resultjo = new JSONObject();
					resultjo.put("ret", 4);
					resultjo.put("msg", "no market award");
					return resultjo.toString();
				}
			}
		};
		try {
			if (dbService instanceof HibernateDBServcieImpl) {
				return ((HibernateDBServcieImpl) dbService).call(callBack);
			} else {
				throw new UnsupportedOperationException();
			}
		} catch (Exception e) {
			Loggers.platformlocalLogger.error(uuid + "modifyQQMarketStatusToFinish is error :", e);
			String result = ApiConfig.getResponseInfo(9999, "modifyQQMarketStatusToFinish is error");
			return result;
		}
	}

	/**
	 * 只有2、3步骤能改finish状态
	 * 
	 * @param openid
	 * @param appid
	 * @param step
	 * @param uuid
	 * @return
	 */
	public String finishQQMarketTask(final String openid, final String appid, final int step, final String uuid) {
		if (step != 2 && step != 3) {
			// 返回错误结果
			String result = ApiConfig.getResponseInfo(103, "step is error:" + step);
			return result;
		}

		HibernateCallback<String> callBack = new HibernateCallback<String>() {
			@Override
			public String doCall(Session session) {
				final Timestamp now = new Timestamp(System.currentTimeMillis());

				String hql = "from QQTaskMarketEntity as market ";
				String wherehql = "where appid=:appid and openid=:openid ";

				hql = hql + wherehql;

				Query qry = session.createQuery(hql);
				qry.setString("appid", appid);
				qry.setString("openid", openid);
				// hibernate 悲观锁
				qry.setLockMode("market", LockMode.UPGRADE);

				List resultList = qry.list();
				QQTaskMarketEntity entity = null;
				if (resultList != null && !resultList.isEmpty()) {
					entity = (QQTaskMarketEntity) resultList.get(0);
					if (step == 2) {
						int status = entity.getStep2Status();
						if (status == MarketStepState.NOT_FINISHED.getIndex()) {
							entity.setStep2Status(MarketStepState.FINISHED.getIndex());
							entity.setStep2UpdateTime(now);
						}
					} else if (step == 3) {
						int status = entity.getStep3Status();
						if (status == MarketStepState.NOT_FINISHED.getIndex()) {
							entity.setStep3Status(MarketStepState.FINISHED.getIndex());
							entity.setStep3UpdateTime(now);
						}
					}

					// 存储
					session.save(entity);

					// 放入缓存里
					QQTaskMarket taskMarket = new QQTaskMarket();
					taskMarket.fromEntity(entity);
					Globals.getQqCacheService().putQQTaskMarket(taskMarket.getId(), taskMarket);
				}

				String result = ApiConfig.getResponseInfo(0, "ok");
				return result;
			}
		};
		try {
			if (dbService instanceof HibernateDBServcieImpl) {
				return ((HibernateDBServcieImpl) dbService).call(callBack);
			} else {
				throw new UnsupportedOperationException();
			}
		} catch (Exception e) {
			Loggers.platformlocalLogger.error(uuid + "modifyQQMarketStatusToFinish is error :", e);
			String result = ApiConfig.getResponseInfo(9999, "modifyQQMarketStatusToFinish is error");
			return result;
		}
	}

	public String modifyQQMarketStatus(final String openid, final String appid, final int step, final String cmd, final String contractid,
			final String billno, final String payitem, final String uuid) {
		if (step != 1 && step != 2 && step != 3 && step != 4) {
			// 返回错误结果
			String result = ApiConfig.getResponseInfo(103, "step is error:" + step);
			return result;
		}
		Loggers.platformlocalLogger
				.debug("modifyQQMarketStatus:" + "uuid=" + uuid + "," + "appid=" + appid + "," + "openid=" + openid + "," + "step=" + step + ","
						+ "cmd=" + cmd + "," + "contractid=" + contractid + "," + "billno=" + billno + "," + "payitem=" + payitem + "");
		// 缓存用于check操作
		if (step == 2 || step == 3) {
			if (QQMarketService.cmd_check.equals(cmd)) {
				String id = appid + "_" + openid;
				QQTaskMarket taskMarket = Globals.getQqCacheService().getQQTaskMarket(id);
				if (taskMarket != null) {
					int status = 0;
					// 第二、三步
					if (step == 2) {
						status = taskMarket.getStep2Status();
					} else if (step == 3) {
						status = taskMarket.getStep3Status();
					}

					if (status == MarketStepState.NOT_FINISHED.getIndex()) {
						// 2：用户尚未完成本步骤
						String result = ApiConfig.getResponseInfo(2, "user did not finish task");
						return result;
					} else if (status == MarketStepState.FINISHED.getIndex()) {
						// 0: 步骤已完成
						String result = ApiConfig.getResponseInfo(0, "user finish task");
						return result;
					} else if (status == MarketStepState.CREATE_AWARD.getIndex() || status == MarketStepState.GET_AWARD.getIndex()) {
						// 3：该步骤奖励已发放过
						String result = ApiConfig.getResponseInfo(3, "user get award");
						return result;
					} else {
						Loggers.platformlocalLogger.error(uuid + "status is vaild taskMarket :" + taskMarket);
						String result = ApiConfig.getResponseInfo(9999, "status is vaild");
						return result;
					}
				}
			}
		}

		HibernateCallback<String> callBack = new HibernateCallback<String>() {
			@Override
			public String doCall(Session session) {
				final Timestamp now = new Timestamp(System.currentTimeMillis());
				String hql = "from QQTaskMarketEntity as market ";
				String wherehql = "where appid=:appid and openid=:openid ";

				hql = hql + wherehql;

				Query qry = session.createQuery(hql);
				qry.setString("appid", appid);
				qry.setString("openid", openid);
				// hibernate 悲观锁
				qry.setLockMode("market", LockMode.UPGRADE);

				List resultList = qry.list();
				QQTaskMarketEntity entity = null;
				if (resultList != null && !resultList.isEmpty()) {
					entity = (QQTaskMarketEntity) resultList.get(0);
				} else {
					entity = new QQTaskMarketEntity();
					entity.setId(appid + "_" + openid);
					entity.setOpenid(openid);
					entity.setAppid(appid);
					entity.setContractid(contractid);
					entity.setCreateTime(now);
				}

				String result = null;

				if (step == 1) {
					if (QQMarketService.cmd_award.equals(cmd)) {
						int status = entity.getStep1Status();
						// 如果没领过奖
						if (status == MarketStepState.NOT_FINISHED.getIndex()) {
							entity.setStep1Status(MarketStepState.CREATE_AWARD.getIndex());
							entity.setStep1Billno(billno);
							entity.setStep1PayItem(payitem);
							entity.setStep1UpdateTime(now);

							result = ApiConfig.getResponseInfo(0, "ok");
						} else {
							// 3：该步骤奖励已发放过
							result = ApiConfig.getResponseInfo(3, "user get award");
						}
					} else {
						// 返回错误结果
						result = ApiConfig.getResponseInfo(103, "step 1 cmd is error:" + cmd);
						return result;
					}
				} else if (step == 2) {
					int status = entity.getStep2Status();
					if (QQMarketService.cmd_check.equals(cmd)) {
						// 查询步骤状态
						if (status == MarketStepState.NOT_FINISHED.getIndex()) {
							// 2：用户尚未完成本步骤
							result = ApiConfig.getResponseInfo(2, "user did not finish task");
						} else if (status == MarketStepState.FINISHED.getIndex()) {
							// 0: 步骤已完成
							result = ApiConfig.getResponseInfo(0, "user finish task");
						} else if (status == MarketStepState.CREATE_AWARD.getIndex() || status == MarketStepState.GET_AWARD.getIndex()) {
							// 3：该步骤奖励已发放过
							result = ApiConfig.getResponseInfo(3, "user get award");
						} else {
							Loggers.platformlocalLogger.error(uuid + "status is vaild entity :" + entity);
							result = ApiConfig.getResponseInfo(9999, "status is vaild");
						}
					} else if (QQMarketService.cmd_check_award.equals(cmd)) {
						if (status == MarketStepState.NOT_FINISHED.getIndex()) {
							// 2：用户尚未完成本步骤
							result = ApiConfig.getResponseInfo(2, "user did not finish task");
						} else if (status == MarketStepState.FINISHED.getIndex()) {
							// 发奖
							entity.setStep2Status(MarketStepState.CREATE_AWARD.getIndex());
							entity.setStep2Billno(billno);
							entity.setStep2PayItem(payitem);
							entity.setStep2UpdateTime(now);

							// 0: 奖励发放成功
							result = ApiConfig.getResponseInfo(0, "user get award");
						} else if (status == MarketStepState.CREATE_AWARD.getIndex() || status == MarketStepState.GET_AWARD.getIndex()) {
							// 3：该步骤奖励已发放过
							result = ApiConfig.getResponseInfo(3, "user get award");
						} else {
							Loggers.platformlocalLogger.error(uuid + "status is vaild entity :" + entity);
							result = ApiConfig.getResponseInfo(9999, "status is vaild");
						}
					} else {
						// 返回错误结果
						result = ApiConfig.getResponseInfo(103, "step 2 cmd is error:" + cmd);
						return result;
					}
				} else if (step == 3) {
					int status = entity.getStep3Status();
					if (QQMarketService.cmd_check.equals(cmd)) {
						if (status == MarketStepState.NOT_FINISHED.getIndex()) {
							// 2：用户尚未完成本步骤
							result = ApiConfig.getResponseInfo(2, "user did not finish task");
						} else if (status == MarketStepState.FINISHED.getIndex()) {
							// 0: 步骤已完成
							result = ApiConfig.getResponseInfo(0, "user finish task");
						} else if (status == MarketStepState.CREATE_AWARD.getIndex() || status == MarketStepState.GET_AWARD.getIndex()) {
							// 3：该步骤奖励已发放过
							result = ApiConfig.getResponseInfo(3, "user get award");
						} else {
							Loggers.platformlocalLogger.error(uuid + "status is vaild entity :" + entity);
							result = ApiConfig.getResponseInfo(9999, "status is vaild");
						}
					} else if (QQMarketService.cmd_check_award.equals(cmd)) {
						if (status == MarketStepState.NOT_FINISHED.getIndex()) {
							// 2：用户尚未完成本步骤
							result = ApiConfig.getResponseInfo(2, "user did not finish task");
						} else if (status == MarketStepState.FINISHED.getIndex()) {
							// 发奖
							entity.setStep3Status(MarketStepState.CREATE_AWARD.getIndex());
							entity.setStep3Billno(billno);
							entity.setStep3PayItem(payitem);
							entity.setStep3UpdateTime(now);

							// 0: 奖励发放成功
							result = ApiConfig.getResponseInfo(0, "user get award");
						} else if (status == MarketStepState.CREATE_AWARD.getIndex() || status == MarketStepState.GET_AWARD.getIndex()) {
							// 3：该步骤奖励已发放过
							result = ApiConfig.getResponseInfo(3, "user get award");
						} else {
							Loggers.platformlocalLogger.error(uuid + "status is vaild entity :" + entity);
							result = ApiConfig.getResponseInfo(9999, "status is vaild");
						}
					} else {
						// 返回错误结果
						result = ApiConfig.getResponseInfo(103, "step 3 cmd is error:" + cmd);
						return result;
					}
				} else if (step == 4) {
					if (QQMarketService.cmd_award.equals(cmd)) {
						int status = entity.getStep4Status();
						// 如果没领过奖
						if (status == MarketStepState.NOT_FINISHED.getIndex()) {
							entity.setStep4Status(MarketStepState.CREATE_AWARD.getIndex());
							entity.setStep4Billno(billno);
							entity.setStep4PayItem(payitem);
							entity.setStep4UpdateTime(now);

							result = ApiConfig.getResponseInfo(0, "ok");
						} else {
							// 3：该步骤奖励已发放过
							result = ApiConfig.getResponseInfo(3, "user get award");
						}
					} else {
						// 返回错误结果
						result = ApiConfig.getResponseInfo(103, "step 4 cmd is error:" + cmd);
						return result;
					}
				}

				// 存储
				session.save(entity);

				// 放入缓存里
				QQTaskMarket taskMarket = new QQTaskMarket();
				taskMarket.fromEntity(entity);
				Globals.getQqCacheService().putQQTaskMarket(taskMarket.getId(), taskMarket);

				return result;
			}
		};
		try {
			if (dbService instanceof HibernateDBServcieImpl) {
				return ((HibernateDBServcieImpl) dbService).call(callBack);
			} else {
				throw new UnsupportedOperationException();
			}
		} catch (Exception e) {
			Loggers.platformlocalLogger.error(uuid + "market execute step:" + step + ";cmd is error :", e);
			String result = ApiConfig.getResponseInfo(9999, "market execute step:" + step + ";cmd is error");
			return result;
		}
	}

}
