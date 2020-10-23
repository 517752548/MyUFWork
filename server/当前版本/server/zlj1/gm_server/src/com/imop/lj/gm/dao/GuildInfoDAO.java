package com.imop.lj.gm.dao;


/**
 * 游戏公会信息DAO
 *
 * @author linfan
 *
 */
public class GuildInfoDAO extends GenericDAO {

//
//	/**
//	 * 根据条件查询GuildInfo
//	 *
//	 * @param guildName 公会名称
//	 * @return GuildInfo
//	 */
//	@SuppressWarnings("unchecked")
//	public List<CommerceEntity> searchGuildInfo(final String guildName) {
//		return (List<CommerceEntity>) getTemplate().doCall(
//				new HibernateCallback<List<?>>() {
//					@Override
//					public List<?> doCall(Session session) {
//						StringBuffer sql = new StringBuffer();
//						sql.append("select * from t_guild where 1=1");
//						sql.append(StringUtils.isBlank(guildName) ? "" : " and guildName = :guildName");
//						SQLQuery query = session.createSQLQuery(sql.toString());
//						if (StringUtils.isNotBlank(guildName)) {
//							query.setString("guildName", guildName.trim());
//						}
//						LogTypeUtils.addQueryScalar(query, CommerceEntity.class);
//						query.setResultTransformer(Transformers
//								.aliasToBean(CommerceEntity.class));
//						getPagerUtil().process(session, query);
//						return query.list();
//					}
//				});
//	}
//
//
//	/**
//	 * 根据条件查询GuildMemberInfo
//	 * @param guildId 公会id
//	 * @return GuildMemberInfo
//	 */
//	@SuppressWarnings("unchecked")
//	public List<CommerceMemberEntity> searchGuildMemberInfo(final String guildId) {
//		return (List<CommerceMemberEntity>) getTemplate().doCall(
//				new HibernateCallback<List<?>>() {
//					@Override
//					public List<?> doCall(Session session) {
//						StringBuffer sql = new StringBuffer();
//						sql.append("select * from t_guild_member where 1=1");
//						sql.append(StringUtils.isBlank(guildId) ? ""
//								: " and guildId = :guildId");
//						SQLQuery query = session.createSQLQuery(sql.toString());
//						if (StringUtils.isNotBlank(guildId)) {
//							query.setString("guildId", guildId.trim());
//						}
//						LogTypeUtils.addQueryScalar(query, CommerceMemberEntity.class);
//						query.setResultTransformer(Transformers
//								.aliasToBean(CommerceMemberEntity.class));
//						getPagerUtil().process(session, query);
//						return query.list();
//					}
//				});
//	}
//
//	/**
//	 * 根据条件查询GuildMemberInfo 里角色的职位
//	 * @param guildId 公会id
//	 * @param roleId 角色id
//	 * @return rank  角色职位
//	 */
//	public int getRank(final long guildId,final long roleId) {
//		return (int) getTemplate().doCall(
//				new HibernateCallback<Integer>() {
//					@Override
//					public Integer doCall(Session session) {
//						Query query = session.getNamedQuery("getRank");
//						query.setLong("guildId", guildId);
//						query.setLong("roleId", roleId);
//						if(query.uniqueResult()==null)return -1;
//						return (Integer) query.uniqueResult();
//					}
//		});
//	}
//
//	/**
//	 * 根据条件查询公会名字
//	 * @param guildId 公会id
//	 * @param characterId 角色id
//	 * @return rank  角色职位
//	 */
//	public String getGuildName(final long guildId) {
//		return (String) getTemplate().doCall(
//				new HibernateCallback<String>(){
//					@Override
//					public String doCall(Session session) {
//						Query query = session.getNamedQuery("getGuildName");
//						query.setLong("id", guildId);
//						getPagerUtil().process(session, query);
//						return (String) query.uniqueResult();
//			}
//		});
//	}
//
//	/**
//	 * 查询公会信息
//	 * @param guildId
//	 * @return
//	 */
//	public CommerceEntity getGuildInfo(final long guildId){
//		return (CommerceEntity) getTemplate().doCall(
//				new HibernateCallback<CommerceEntity>(){
//					@Override
//					public CommerceEntity doCall(Session session) {
//						Query query = session.getNamedQuery("getGuildInfo");
//						query.setLong("id", guildId);
//						if(query.uniqueResult()==null)return null;
//						return (CommerceEntity) query.uniqueResult();
//			}
//		});
//	}
}
