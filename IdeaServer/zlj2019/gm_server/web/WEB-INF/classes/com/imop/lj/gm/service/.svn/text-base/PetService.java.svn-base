package com.imop.lj.gm.service;

import java.util.List;

import net.sf.json.JSONObject;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.db.model.PetEntity;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.dao.PetDAO;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.page.IPaginationHelper;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.LangUtils;

/**
 * 宠物管理Service
 *
 * @author lin fan
 *
 */
public class PetService {

	private PetDAO petDAO;

	/** 分页工具 */
	private IPaginationHelper pagerUtil;

	private CmdManageService cmdManageService;
	
	// db log 
	private static final Logger petPropertyLog = LoggerFactory.getLogger("petPropertyLog");	
	
	public IPaginationHelper getPagerUtil() {
		return pagerUtil;
	}

	public void setPagerUtil(IPaginationHelper pagerUtil) {
		this.pagerUtil = pagerUtil;
	}

	public PetDAO getPetDAO() {
		return petDAO;
	}

	public void setPetDAO(PetDAO petDAO) {
		this.petDAO = petDAO;
	}

	
	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}

	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}

	/**
	 * 根据角色id和宠物id,得到宠物
	 *
	 * @param role_id
	 *            角色id
	 * @param pet_id
	 *            宠物id
	 * @return Pet
	 */
	@SuppressWarnings("unchecked")
	public PetEntity getPet(String role_id, String pet_id) {
		if (pet_id == null) {
			return null;
		}
		List pets = getPets(role_id);
		if (pets != null) {
			for (int i = 0; i < pets.size(); i++) {
				PetEntity pet = (PetEntity) pets.get(i);
				if (pet_id.equals(String.valueOf(pet.getId()))) {
					return pet;
				}
			}
		}
		return null;
	}


	/**
	 * 根据角色id,得到宠物对象列表
	 *
	 * @param id
	 *            角色id
	 * @return 宠物对象列表
	 */
	@SuppressWarnings("unchecked")
	public List getPets(String id) {
		List result = null;
		List temp = petDAO.getPets(id);
		result = getPagerUtil().processList(temp.toArray());

		return result;
	}

	/***
	 * 在线更改秘书的属性
	 * @param name
	 * @param humanId
	 * @param secId
	 * @param svr
	 * @return
	 */
	public boolean modifySecProperty(String name,String humanId,String secId,DBServer svr,String proKey,String proValue) {
		JSONObject _o = new JSONObject();
		_o.put("roleId", humanId);
		_o.put("secId", secId);
		_o.put("propKey", proKey);
		_o.put("propValue", proValue);
		String cmd = "modifySecProperty " + _o.toString();
		String result = cmdManageService.sendCmd(cmd, svr, false).toString();
		if (result.indexOf("Sended") != -1) {
			
			LoginUser loginUser = LoginUserService.getLoginUser();
			String info = "success:\t" + ExcelLangManagerService.readGmLang(GMLangConstants.ADMIN) + ":" + loginUser.getUsername() + "\t"
					+ ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_REGION) + ":" + loginUser.getLoginRegionId() + "\t"
					+ ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_SERVER) + ":" + loginUser.getLoginServerId() + "\t" + 
					"SecretaryService.modifySecProperty (humanId:"+ humanId + ",secId:" + secId
					+ ",proKey:" + proKey
					+ ",proValue:" + proValue
					+")";
			petPropertyLog.info(info);
			
			return true;
		}
		
		return false;
	}
	
	public boolean isCanModifySecMondyAndItem(int level) {
		if(!LangUtils.getDBType().equals("1")) {
			return false;
		}
		
		if(level <= 2 || level == 9) {
			return true;
		} else {
			return false;
		}
	}


//	/**
//	 * 搜索宠物
//	 * @param pets 宠物列表
//	 * @param name 名字参数
//	 * @return
//	 */
//	@SuppressWarnings("unchecked")
//	public ArrayList<PetEntity> searchPest(Object [] pets,String name) {
//		ArrayList <PetEntity> searchPest=  new ArrayList();
//		for(int i=0;i<pets.length;i++){
//			String petName=((PetEntity)pets[i]).getName();
//			if(petName.indexOf(name)!=-1){
//				searchPest.add((PetEntity)pets[i]);
//			}
//		}
//		return  searchPest;
//	}


}
