package com.imop.lj.gm.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.service.PetService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.db.model.PetEntity;

/**
 * 游戏玩家管理Controller
 *
 * @author lin fan
 *
 */
public class PetManageController extends MultiActionController {

	/** 宠物管理初始页面 */
	private String petInitView;

	/** 宠物基本信息页面 */
	private String petBasicInfoView;

	/** 编辑宠物页面 */
	private String editPetView;

	/** 宠物管理Service */
	private PetService petService;

	/** 管理管理Service */
	private CmdManageService cmdManageService;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	public String getEditPetView() {
		return editPetView;
	}

	public void setEditPetView(String editPetView) {
		this.editPetView = editPetView;
	}

	public String getPetInitView() {
		return petInitView;
	}

	public void setPetInitView(String petInitView) {
		this.petInitView = petInitView;
	}

	public String getPetBasicInfoView() {
		return petBasicInfoView;
	}

	public void setPetBasicInfoView(String petBasicInfoView) {
		this.petBasicInfoView = petBasicInfoView;
	}

	public PetService getPetService() {
		return petService;
	}

	public void setPetService(PetService petService) {
		this.petService = petService;
	}

	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}

	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	/**
	 * 角色管理页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getPetInitView());
		return mav;
	}

	/**
	 * 角色管理--宠物基本信息页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView petBasicInfo(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getPetBasicInfoView());
		String roleId = request.getParameter("roleId");
		String petId = request.getParameter("petId");
		PetEntity pet = petService.getPet(roleId, petId);
		mav.addObject("p", pet);
		mav.addObject("roleId", roleId);
		return mav;
	}

	/**
	 * 编辑宠物页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView editPet(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getEditPetView());
		String roleId = request.getParameter("roleId");
		String petId = request.getParameter("petId");
		PetEntity pet = petService.getPet(roleId, petId);
		mav.addObject("p", pet);
		mav.addObject("roleId", roleId);
		return mav;
	}

}
