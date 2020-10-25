package com.imop.lj.gm.controller;

import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gm.dao.StatisticsDAO;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.model.StatisticsInfoVO;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;

/**
 * 统计控制器
 * 
 * @author xiaowei.liu
 * 
 */
public class StatisticsController extends MultiActionController {
	private DBFactoryService dbFactoryService;
	private CmdManageService cmdManageService;
	
	private String statisticsInfoView;

	public final static DecimalFormat df = new DecimalFormat("0.0000%");
	
	public final static SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	public String getStatisticsInfoView() {
		return statisticsInfoView;
	}

	public void setStatisticsInfoView(String statisticsInfoView) {
		this.statisticsInfoView = statisticsInfoView;
	}

	
	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}

	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}

	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getStatisticsInfoView());
		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		List<DBServer> svrList = DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId());
		
		List<StatisticsInfoVO> infoList = new ArrayList<StatisticsInfoVO>();
		long now = System.currentTimeMillis();
		
		for(DBServer server : svrList){
			StatisticsDAO dao = new StatisticsDAO();
			dao.setDbFactoryService(this.dbFactoryService);
			dao.setRId(server.getRegionId());
			dao.setSId(server.getId());
				
			try {
				// 注册人数
				int registerNum = dao.getCountFromUser().get(0).intValue();
				// 角色人数
				int createRoleNum = dao.getCountFromCharacter().get(0).intValue();
				// 充值人数
				int chargeRoleNum = dao.getRoleNumForCharge().get(0).intValue();
				// 充值总额
				BigDecimal _totalCharge = dao.getSumCharge().get(0);				
				// 当日充值
				BigDecimal _todayCharge = dao.getTodaySumCharge(this.getBeginOfDay(now)).get(0);
				// 本周充值
				BigDecimal _weekCharge = dao.getWeekSumCharge(this.getBeginOfWeek(now)).get(0);
				// 本月充值
				BigDecimal _monthCharge = dao.getMonthSumCharge(this.getBeginOfMonth(now)).get(0);
				
				long totalCharge = 0;
				long todayCharge = 0;
				long weekCharge = 0;
				long monthCharge = 0;
				
				if (_totalCharge != null) {
					totalCharge = _totalCharge.longValue();
				}
				
				if(_todayCharge != null){
					todayCharge = _todayCharge.longValue();
				}
				
				if(_weekCharge != null){
					weekCharge = _weekCharge.longValue();
				}
				
				if(_monthCharge != null){
					monthCharge = _monthCharge.longValue();
				}
				
				List<String> list = cmdManageService.sendCmd("getOnlinePlayerSize", server, false);
				String size = "0";
				if(list != null && !list.isEmpty()){
					size = list.get(0);
				}
				
				String createDivRegister = this.div(createRoleNum, registerNum);
				String chargeDivCreate = this.div(chargeRoleNum, createRoleNum);
				double arup = 0;
				if (createRoleNum > 0) {
					arup = (double) totalCharge / createRoleNum;
				}

				StatisticsInfoVO vo = new StatisticsInfoVO();
				vo.setState(true);
				vo.setSvrName(server.getDbServerName() + "-" + server.getServerName());
				vo.setRegisterNum(registerNum);
				vo.setCreateRoleNum(createRoleNum);
				vo.setChargeRoleNum(chargeRoleNum);
				vo.setTotalCharge(totalCharge);
				vo.setTodayCharge(todayCharge);
				vo.setWeekCharge(weekCharge);
				vo.setMonthCharge(monthCharge);
				vo.setOnlinePlayerSize(size);
				
				vo.setCdr(createDivRegister);
				vo.setCdc(chargeDivCreate);
				vo.setArup(arup);

				infoList.add(vo);
			} catch (Exception ex) {
				StatisticsInfoVO vo = new StatisticsInfoVO();
				vo.setState(false);
				vo.setSvrName(server.getDbServerName() + "-" + server.getServerName());
				infoList.add(vo);
			}
			
		}
		mav.addObject("infoList", infoList);
		return mav;
	}
	
	public String getBeginOfDay(long time){
		long today = TimeUtils.getBeginOfDay(time);
		return sdf.format(new Date(today));
	}
	
	public String getBeginOfWeek(long time){
		long today = TimeUtils.getBeginOfWeek(time);
		return sdf.format(new Date(today));
	}
	
	public String getBeginOfMonth(long time){
		long today = TimeUtils.getBeginOfMonth(time);
		return sdf.format(new Date(today));
	}
	
	public String div(long a, long b){
		if(b == 0){
			return "0";
		}else{
			return df.format((double)a / b);
		}
	}
}
