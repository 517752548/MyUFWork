package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.MailEntity;

public class MailDao extends BaseDao<MailEntity>{
	
	private static final String GET_MAILS_BY_CHARID = "queryPlayerMail";
	
	private static final String[] GET_MAILS_BY_CHARID_PARAMS = new String[] { "charId" };
	
	
	public MailDao(DBService dbService) {
		super(dbService);
	}
	
	@SuppressWarnings("unchecked")
	public List<MailEntity> getMailsByCharId(long characterId) {
		return this.dbService.findByNamedQueryAndNamedParam(GET_MAILS_BY_CHARID, GET_MAILS_BY_CHARID_PARAMS,
				new Object[] { characterId });
	}

	@Override
	protected Class<MailEntity> getEntityClass() {
		return MailEntity.class;
	}
}
