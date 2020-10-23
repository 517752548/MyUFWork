package com.imop.lj.gm.service;

import java.util.Map;

import javax.servlet.http.HttpServletRequest;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.template.TemplateService;

public class GMTemplateService{

	public <T extends TemplateObject> Map<Integer, T> getCompanyAll(Class<T> clazz,HttpServletRequest request) {
		TemplateService gmTemplateServices = (TemplateService) request.getSession().getAttribute("gmTemplateService");
		return (Map<Integer, T>) gmTemplateServices.getAll(clazz);
	}
	public <T extends TemplateObject> T get(int id, Class<T> clazz,HttpServletRequest request) {
		if (Loggers.templateLogger.isDebugEnabled()) {
			Loggers.templateLogger.debug("clazz:" + clazz);
		}
		Map<Integer, T> map = getCompanyAll(clazz,request);
		return (T) map.get(id);
	}
	public void plr(Map<Integer,TemplateObject> map)
	{
		for(TemplateObject vo:map.values())
		{
			System.out.println(vo.getId());
			System.out.println(vo.getSheetName());
		}
	}
}
