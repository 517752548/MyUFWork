package com.imop.lj.gameserver.pet;

import java.util.List;

import com.imop.lj.common.constants.CommonErrorLogInfo;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.orm.DataAccessException;
import com.imop.lj.core.util.ErrorsUtil;
import com.imop.lj.db.dao.PetDao;
import com.imop.lj.db.model.PetEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.helper.PetHelper;

public class PetDbManager {

	/** 武将数据库操作管理 */
	private static PetDbManager petDbManager = new PetDbManager();

	private PetDbManager() {

	}

	/**
	 * 获取武将数据库操作管理类
	 * 
	 * @return
	 */
	public static PetDbManager getInstance() {
		return petDbManager;
	}

	/**
	 * 从数据库中读取武将
	 * 
	 * @param petUUID
	 * @return
	 */
	public PetEntity loadPetFromDB(long petUUID) {
		PetEntity petEntity = null;
		try {
			petEntity = getPetDao().get(petUUID);
		} catch (DataAccessException e) {
			if (Loggers.petLogger.isErrorEnabled()) {
				Loggers.petLogger.error(ErrorsUtil.error(CommonErrorLogInfo.DB_OPERATE_FAIL, "#GS.PetDbManager.loadPetFromDB", null), e);
			}
		}
		return petEntity;
	}

	/**
	 * 将玩家的所有武将数据从数据库中读取
	 * 
	 * @param petContainer
	 */
	public void loadAllPetFromDB(PetManager petManager) {

		long _charId = petManager.getOwner().getCharId();
		List<PetEntity> _pets = null;

		try {
			_pets = getPetDao().getPetsByCharId(_charId);
//			boolean hasLeader = false;
			for (PetEntity _petInfo : _pets) {

				Pet pet = PetHelper.newPetFromEntity(_petInfo);
				pet.fromEntity(_petInfo);
				pet.setOwner(petManager.getOwner());
				pet.setInDb(true);
				// TODO::可能需要进行初始化
				pet.init();
				// 如果是自定义武将，则设置

//				final boolean _isLeader = pet.isLeader();
				petManager.getOwner().getPetManager().addPet(pet);
//				if (_isLeader) {
//					hasLeader = true;
//				}
			}

//			if (!hasLeader) {
//				throw new IllegalStateException(String.format("no leader pet, owner = %d", petManager.getOwner().getCharId()));
//			}

		} catch (DataAccessException e) {
			if (Loggers.petLogger.isErrorEnabled()) {
				Loggers.petLogger.error(ErrorsUtil.error(CommonErrorLogInfo.DB_OPERATE_FAIL, "#GS.PetDbManager.loadAllPetFromDB", null), e);
			}
			return;
		}
	}

	/**
	 * 取得武将的Dao实例
	 * 
	 * @return
	 */
	private PetDao getPetDao() {
		return Globals.getDaoService().getPetDao();
	}
}
