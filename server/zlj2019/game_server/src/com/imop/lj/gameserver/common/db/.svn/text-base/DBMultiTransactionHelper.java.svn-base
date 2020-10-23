package com.imop.lj.gameserver.common.db;

import org.hibernate.Session;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.orm.DBService;
import com.imop.lj.core.orm.HibernateDBServcieImpl;
import com.imop.lj.core.orm.HibernateDBServcieImpl.HibernateCallback;
import com.imop.lj.core.util.Assert;
import com.imop.lj.core.util.ErrorsUtil;
import com.imop.lj.db.model.HumanEntity;
import com.imop.lj.db.model.PetEntity;

public class DBMultiTransactionHelper {
	
	private DBService dbService;
	
	public DBMultiTransactionHelper(DBService dbService) {
		Assert.notNull(dbService);
		this.dbService = dbService;
	}
	
	
	/** 
	 * @description: 
	 * 			将Save {@link HumanEntity} and {@link PetEntity}包裹成一个事务统一处理<br>
	 * 			在创建玩家数据时调用此方法，如果存储human/pet中任何一个抛出异常时，创建操作就不成功<Br>
	 * 			可以防止玩家创建角色成功但CustomPet为空的问题
	 * @param humanEntity
	 * @param petEntity
	 * @return
	 */ 
	public boolean saveHumanPetHibTransaction (final HumanEntity humanEntity, final PetEntity petEntity) {
		HibernateCallback<Boolean> callBack = new HibernateCallback<Boolean>() {
			@Override
			public Boolean doCall(Session session) {
				session.save(humanEntity);
				session.save(petEntity);
				return true;	
			}
		};
		try{
			if (dbService instanceof HibernateDBServcieImpl) {
				return ((HibernateDBServcieImpl)dbService).call(callBack);
			}else{
				throw new UnsupportedOperationException();
			}
		} catch (Exception e) {
			Loggers.gameLogger.error(
					ErrorsUtil.error(
							"save.human||pet.error", 
							"DBMultiQueryTransactionHelper.saveHumanPetHibTransaction", 
							String.format("humanId = %d", humanEntity.getPassportId()
									)));
			return false;
		}		
	}
	
	

}
