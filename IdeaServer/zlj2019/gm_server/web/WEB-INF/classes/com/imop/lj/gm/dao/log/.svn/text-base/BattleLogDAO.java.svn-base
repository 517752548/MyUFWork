package com.imop.lj.gm.dao.log;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.hibernate.SQLQuery;
import org.hibernate.Session;

import com.imop.lj.gm.dao.GMTransformers;
import com.imop.lj.gm.dao.GenericDAO;
import com.imop.lj.gm.model.log.BattleLog;

public class BattleLogDAO extends GenericDAO {

	/**
	 *
	 * @param roleID
	 * @param date
	 * @param reason
	 * @param sortType
	 * @param order
	 * @param startTimel
	 * @param endTimel
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<BattleLog> getBattleLogList(final String roleID,
			final String date, final String reason, final String sortType,
			final String order, final long startTimel, final long endTimel) {
		return (List<BattleLog>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						StringBuffer sql = new StringBuffer();
						sql.append("select * from battle_log_" + date
								+ " where 1=1");
						sql.append(StringUtils.isBlank(roleID) ? ""
								: " and char_id = :charId");
						if (StringUtils.isNotBlank(reason)
								&& !"-1".equals(reason)) {
							sql.append(" and reason = :reason");
						}
						if (startTimel != -1) {
							sql.append(" and  log_time >= :startTime");
						}
						if (endTimel != -1) {
							sql.append(" and  log_time <= :endTime");
						}
						if (StringUtils.isNotBlank(sortType)) {
							sql.append(" order by " + sortType + " " + order);
						}
						SQLQuery query = session.createSQLQuery(sql.toString());
						if (StringUtils.isNotBlank(roleID)) {
							query.setString("charId", roleID.trim());
						}
						if (StringUtils.isNotBlank(reason)
								&& !"-1".equals(reason)) {
							query.setString("reason", reason.trim());
						}
						if (startTimel != -1) {
							query.setLong("startTime", startTimel);
						}
						if (endTimel != -1) {
							query.setLong("endTime", endTimel);
						}
						LogTypeUtils.addLogQueryScalar(query, BattleLog.class);
						query.setResultTransformer(GMTransformers
								.aliasToBean(BattleLog.class));
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}

	/**
	 * 得到战斗的属性的信息
	 *
	 * @param id
	 *            日志ID
	 * @param date
	 *            日期
	 * @return 宠物的信息
	 */
	public byte[] getBattleData(final String id, final String date,
			final int type) {
		return (byte[]) getTemplate().doCall(new HibernateCallback<byte[]>() {
			@Override
			public byte[] doCall(Session session) {
				StringBuffer sql = new StringBuffer();
				sql.append("select * from battle_log_" + date
						+ " where id = :id");
				SQLQuery query = session.createSQLQuery(sql.toString());
				query.setString("id", id.trim());
				LogTypeUtils.addLogQueryScalar(query, BattleLog.class);
				query.setResultTransformer(GMTransformers
						.aliasToBean(BattleLog.class));
//				BattleLog battleLog = (BattleLog) query.uniqueResult();
				switch (type) {
//				case 1:
//					return battleLog.getProperty();
//				case 2:
//					return battleLog.getWearing();
//				case 3:
//					return battleLog.getPetInfo();
				default:
					return null;
				}

			}
		});

	}

	/**
	 * 得到战斗时玩家身上装备的详细信息
	 *
	 * @param id
	 * @param date
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<BattleLog> getBattleWearData(final String id, final String date) {
		return (List<BattleLog>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						StringBuffer sql = new StringBuffer();
						sql.append("select * from battle_log_" + date
								+ " where id = :id");
						SQLQuery query = session.createSQLQuery(sql.toString());
						query.setString("id", id.trim());
						LogTypeUtils.addLogQueryScalar(query, BattleLog.class);
						query.setResultTransformer(GMTransformers
								.aliasToBean(BattleLog.class));
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}
}
