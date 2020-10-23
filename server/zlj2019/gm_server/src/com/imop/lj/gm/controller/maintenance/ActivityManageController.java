package com.imop.lj.gm.controller.maintenance;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.dto.ActivityStatusVo;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;



public class ActivityManageController extends MultiActionController {

	/** 命令管理初始页面 */
	private String cmdInitView;

	private String cmdActivityManageView;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/**命令管理Service **/
	private CmdManageService cmdManageService;

	/**处理Excel的多语言类 */
	private ExcelLangManagerService excelLangManagerService;


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

	public String getCmdInitView() {
		return cmdInitView;
	}

	public void setCmdInitView(String cmdInitView) {
		this.cmdInitView = cmdInitView;
	}

	public String getCmdActivityManageView() {
		return cmdActivityManageView;
	}

	public void setCmdActivityManageView(String cmdActivityManageView) {
		this.cmdActivityManageView = cmdActivityManageView;
	}

	public ExcelLangManagerService getExcelLangManagerService() {
		return excelLangManagerService;
	}

	public void setExcelLangManagerService(
			ExcelLangManagerService excelLangManagerService) {
		this.excelLangManagerService = excelLangManagerService;
	}

	/** 命令管理初始页面 */
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav= new ModelAndView(getCmdInitView());
		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		mav.addObject("serverList", DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId()));
		List<DBServer> servers = DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId());


		return mav;
	}
	public ModelAndView viewActivityStatus(HttpServletRequest request,
			HttpServletResponse response) throws Exception
	{
		ModelAndView mav= new ModelAndView(getCmdActivityManageView());
		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		mav.addObject("serverList", DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId()));
		List<DBServer> servers = DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId());
		String[] sIds = request.getParameterValues("sId");
		Map<Integer,List<ActivityStatusVo>> activityInfo =new HashMap<Integer, List<ActivityStatusVo>>();
		for(int i=0;i<sIds.length;i++){
			DBServer svr= dbFactoryService.getServer(u.getLoginRegionId(),sIds[i]);
			activityInfo.put(i,this.getActivityInfo(svr, "")) ;
		}
		mav.addObject("activityInfos",activityInfo);
		return mav;
	}
	public ModelAndView initActivityStatus(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav= new ModelAndView(getCmdActivityManageView());
		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		mav.addObject("serverList", DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId()));
		List<DBServer> servers = DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId());

		Map<Integer,List<ActivityStatusVo>> activityInfo =new HashMap<Integer, List<ActivityStatusVo>>();
		mav.addObject("activityInfos",activityInfo);
		return mav;
	}
	/** 发送命令 */
	public ModelAndView sendCmd(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav= new ModelAndView(getCmdInitView());
		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		String cmd = request.getParameter("cmd");
		String[] sIds = request.getParameterValues("sId");
		//命令内容。 空就不发送
		String activityId = request.getParameter("activity_id");

		String open = request.getParameter("open");
		JSONObject _o = new JSONObject();
		_o.put("open", open==null?false:true);
		_o.put("activityId",activityId==null?0:activityId);
		cmd += _o.toString();


		StringBuilder totalResult = new StringBuilder();
		for(int i=0;i<sIds.length;i++){
			DBServer svr= dbFactoryService.getServer(u.getLoginRegionId(),sIds[i]);
			String msg=cmdManageService.sendCmdResult(cmd, svr);
			if(msg.equals("slave")){
				totalResult.append(svr.getDbServerName()+":"+excelLangManagerService.readGm(GMLangConstants.TELNET_SLAVE_DB)+"!");
			}else if(msg.equals("connect error")){
				totalResult.append(svr.getDbServerName()+":"+excelLangManagerService.readGm(GMLangConstants.ERR_TELNET_AS_DISCON)+"!");
			}
			else if(msg.equals("error")){
				totalResult.append(svr.getDbServerName()+":"+excelLangManagerService.readGm(GMLangConstants.CMDFAILED)+"!");
			}
			else if(msg.equals("unknown")){
				totalResult.append(svr.getDbServerName()+":"+excelLangManagerService.readGm(GMLangConstants.UNKNOWNCMD)+"!");
			}
			else{
				totalResult.append(svr.getDbServerName()+":"+excelLangManagerService.readGm(GMLangConstants.CMDSUCCESS)+"!");
			}
			totalResult.append("\t");
		}
		mav.addObject("error_msg", totalResult);
		mav.addObject("serverList", DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId()));
		return mav;
	}

	/**
	 * 得到活动信息 如 boss战等
	 * @param svr
	 * @param cmd
	 * @return
	 */
	private List<ActivityStatusVo> getActivityInfo(DBServer svr,String cmd)
	{
		List<ActivityStatusVo> serverObjectList = new ArrayList<ActivityStatusVo>();
		List<String> jostring = cmdManageService.sendCmd("activitystatus", svr,true);
		String result = jostring.toString();
		if("gs_status".equals(cmd) || "log_status".equals(cmd)){
			result = result.substring(1, result.length()-1);
		}
		if(result.indexOf("error")!=-1||result.indexOf("slave")!=-1||result.indexOf("unknown")!=-1){
			return serverObjectList;
		}
		if(result.startsWith("[")){
			JSONArray _arrays = JSONArray.fromObject(result);
			for (int i = 0; i < _arrays.size(); i++) {
				//JSONObject[] os = (JSONObject[]) _arrays.get(i);
				//JSONObject os = (JSONObject[])_arrays.getJSONArray(0);
				JSONArray oo=_arrays.getJSONArray(0);
				for(int j=0;j<oo.size();j++)
				{

					JSONObject o = (JSONObject)oo.get(j);
					ActivityStatusVo vo = new ActivityStatusVo();
					vo.setActivityId(o.getInt("id"));
					vo.setName(o.getString("name"));
					vo.setStatus(o.getInt("status"));

					serverObjectList.add(vo);
				}
			}
		}
		return serverObjectList;
	}
}
