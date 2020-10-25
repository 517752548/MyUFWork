package com.imop.lj.gm.platform;

import org.springframework.context.ApplicationContext;

import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.service.RoleService;
import com.imop.lj.gm.service.UserInfoService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.platform.core.log.Loggers;
import com.imop.platform.core.type.FailType;
import com.imop.platform.core.type.OkType;
import com.imop.platform.gm.service.IPlatformGmService;
import com.imop.platform.gm.servlet.param.FaqFeedbackParam;
import com.imop.platform.gm.servlet.param.ForbidTalkParam;
import com.imop.platform.gm.servlet.param.KickParam;
import com.imop.platform.gm.servlet.param.QueryInfoParam;
import com.imop.platform.gm.servlet.param.TalkParam;
import com.imop.platform.gm.servlet.result.FaqFeedbackResult;
import com.imop.platform.gm.servlet.result.ForbidTalkResult;
import com.imop.platform.gm.servlet.result.KickResult;
import com.imop.platform.gm.servlet.result.QueryInfoResult;
import com.imop.platform.gm.servlet.result.TalkResult;

/**
 * crm请求实现
 * 
 * @author yuanbo.gao
 *
 */
public class CsjPlatformGmService implements IPlatformGmService {

	protected ApplicationContext context;

	@Override
	public void kick(KickParam kickparam, KickResult kickresult) {
		Loggers.getGmLogger().info("[CRM] KICK KickParam - " + 
				"AreaId:" + kickparam.getAreaId() + ";" + 
				"ServerId:" + kickparam.getServerId() + ";" + 
				"RoleId:" + kickparam.getRoleId() + ";" );
		DBFactoryService dbFactoryService = (DBFactoryService)context.getBean("dbFactoryService",DBFactoryService.class);
		RoleService roleService = (RoleService)context.getBean("roleService",RoleService.class);
		DBServer svr = dbFactoryService.getServerByServerId(kickparam.getAreaId() + "", kickparam.getServerId() + "");
		long id = kickparam.getRoleId();
		if (roleService.kickOut("", id + "", svr)) {
			kickresult.setOkType(OkType.OK);
			Loggers.getGmLogger().info("[CRM] KICK RESULT - " + 
					"kickresult:" + kickresult.getOkType() + ";");
		}else{
			kickresult.setFailType(FailType.SysFail);
			Loggers.getGmLogger().info("[CRM] KICK RESULT - " + 
					"kickresult:" + kickresult.getFailType() + ";");
		}
		
	}

	@Override
	public void forbidTalk(ForbidTalkParam forbidtalkparam, ForbidTalkResult forbidtalkresult) {
		Loggers.getGmLogger().info("[CRM] FORBIDTALK ForbidTalkParam - " + 
				"AreaId:" + forbidtalkparam.getAreaId() + ";" + 
				"ServerId:" + forbidtalkparam.getServerId() + ";" + 
				"PassportId:" + forbidtalkparam.getPassportId() + ";" + 
				"ForbidTime:" + forbidtalkparam.getForbidTime() + ";"
				);
		
		DBFactoryService dbFactoryService = (DBFactoryService)context.getBean("dbFactoryService",DBFactoryService.class);
		UserInfoService userInfoService = (UserInfoService)context.getBean("userInfoService",UserInfoService.class);
		
		long now = System.currentTimeMillis();
		long foribeDataTimeLong = now + forbidtalkparam.getForbidTime() * 1000;
		
		DBServer svr = dbFactoryService.getServerByServerId(forbidtalkparam.getAreaId() + "", forbidtalkparam.getServerId() + "");
		if (userInfoService.foribdTalkDoByCrm(forbidtalkparam.getPassportId() + "", foribeDataTimeLong, svr)) {
			forbidtalkresult.setOkType(OkType.OK);
			Loggers.getGmLogger().info("[CRM] FORBIDTALK RESULT - " + 
					"forbidtalkresult:" + forbidtalkresult.getOkType() + ";");
		} else {
			forbidtalkresult.setFailType(FailType.SysFail);
			Loggers.getGmLogger().info("[CRM] FORBIDTALK RESULT - " + 
					"forbidtalkresult:" + forbidtalkresult.getFailType() + ";");
		}
	}

	@Override
	public void talk(TalkParam talkparam, TalkResult talkresult) {
		Loggers.getGmLogger().info("[CRM] TALK TalkParam - " + 
				"AreaId:" + talkparam.getAreaId() + ";" + 
				"ServerId:" + talkparam.getServerId() + ";" + 
				"PassportId:" + talkparam.getPassportId() + ";"
				);
		
		DBFactoryService dbFactoryService = (DBFactoryService)context.getBean("dbFactoryService",DBFactoryService.class);
		UserInfoService userInfoService = (UserInfoService)context.getBean("userInfoService",UserInfoService.class);
		
		DBServer svr = dbFactoryService.getServerByServerId(talkparam.getAreaId() + "", talkparam.getServerId() + "");
		if (userInfoService.cancleForibdTalkDoByCrm(talkparam.getPassportId() + "", svr)) {
			talkresult.setOkType(OkType.OK);
			Loggers.getGmLogger().info("[CRM] TALK RESULT - " + 
					"talkresult:" + talkresult.getOkType() + ";");
		} else {
			talkresult.setFailType(FailType.SysFail);
			Loggers.getGmLogger().info("[CRM] TALK RESULT - " + 
					"talkresult:" + talkresult.getFailType() + ";");
		}
	}

	@Override
	public void queryInfo(QueryInfoParam queryinfoparam, QueryInfoResult queryinforesult) {
		// TODO Auto-generated method stub

	}

	@Override
	public void faqFeedback(FaqFeedbackParam faqfeedbackparam, FaqFeedbackResult faqfeedbackresult) {
		// TODO Auto-generated method stub

	}

	public ApplicationContext getContext() {
		return context;
	}

	public void setContext(ApplicationContext context) {
		this.context = context;
	}
}
