package com.imop.lj.gm.service;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.dao.AddressBookDAO;
import com.imop.lj.gm.service.db.DBFactoryService;

public class AddressBookService {
	// db log
	private static final Logger logger = LoggerFactory.getLogger("db");
	private DBFactoryService dbFactoryService;

	private AddressBookDAO addressBookDAO;

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}
	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}
	public AddressBookDAO getAddressBookDAO() {
		return addressBookDAO;
	}
	public void setAddressBookDAO(AddressBookDAO addressBookDAO) {
		this.addressBookDAO = addressBookDAO;
	}
//	/*
//	 * 读取vip通讯录列表
//	 */
//	public List<AddressBookEntity> getAllAddressBooks(String searchType,String searchValue, String startDate, String endDate)throws Exception {
//		Date startDt = null;
//		Date endDt = null;
//		if (searchType != null) {
//			searchType = searchType.trim();
//		}
//		if (searchValue != null) {
//			searchValue = searchValue.trim();
//		}
//		if(StringUtils.isNotBlank(startDate)){
//			startDt = DateUtil.parseDate(startDate.trim());
//		}
//		if(StringUtils.isNotBlank(endDate)){
//			endDt = DateUtil.parseDate(endDate.trim());
//		}
//		return addressBookDAO.getAddressBookListSearch(searchType,searchValue,startDt,endDt);
//	}
}
