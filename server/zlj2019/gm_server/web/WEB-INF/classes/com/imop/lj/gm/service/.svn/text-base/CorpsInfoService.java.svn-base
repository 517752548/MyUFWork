package com.imop.lj.gm.service;

import java.util.List;

import com.imop.lj.db.model.CorpsEntity;
import com.imop.lj.gm.dao.CorpsInfoDAO;

/**
 * 军团信息Service
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsInfoService {
	private CorpsInfoDAO corpsInfoDAO;

	public CorpsInfoDAO getCorpsInfoDAO() {
		return corpsInfoDAO;
	}

	public void setCorpsInfoDAO(CorpsInfoDAO corpsInfoDAO) {
		this.corpsInfoDAO = corpsInfoDAO;
	}

	/**
	 * 查询军团列表
	 * 
	 * @param serchType
	 * @param serchValue
	 * @return
	 */
	public List<CorpsEntity> searchCorpsInfoList(String searchType,
			String searchValue) {
		if (searchType != null) {
			searchType = searchType.trim();
		}
		if (searchValue != null) {
			searchValue = searchValue.trim();
		}
		return corpsInfoDAO.searchCorpsInfo(searchType, searchValue);
	}
}
