package com.imop.lj.gameserver.battlereport;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.util.Date;
import java.util.List;

import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.async.AsyncService;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.msg.sys.ScheduledMessage;
import com.imop.lj.core.schedule.ScheduleService;
import com.imop.lj.core.time.TimeService;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.battle.core.BattleDef.ReportMsgType;
import com.imop.lj.gameserver.battle.core.BattleDef.SideType;
import com.imop.lj.gameserver.battle.msg.GCBattleReportPart;
import com.imop.lj.gameserver.battle.msg.GCBattleReportPvp;
import com.imop.lj.gameserver.battle.msg.GCBattleReportTeam;
import com.imop.lj.gameserver.battle.msg.GCPlayBattleReport;
import com.imop.lj.gameserver.battlereport.async.CreateBattleReportDirOperation;
import com.imop.lj.gameserver.battlereport.async.CreateBattleReportTableOperation;
import com.imop.lj.gameserver.battlereport.async.LoadBattleReportFromFileOperation;
import com.imop.lj.gameserver.battlereport.async.SaveBattleReportToFileOperation;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.config.GameServerConfig;
import com.imop.lj.gameserver.human.Human;

/**
 * 战报服务类
 *
 */
public class BattleReportService {

	private static Logger logger = Loggers.battleReportLogger;
	private static final String BATTLE_REPORT_FILE_SUFFIX = ".br";
	
	
	private BattleReportIdGenerator idGenerator;
	
	/** 服务器配置 */
	private GameServerConfig gameServerConfig;
	/** 异步服务 */
	private AsyncService asyncService;
	/** 时间服务 */
	private TimeService timeService;
	/** 调度服务 */
	private ScheduleService scheduleService;
	/** 战报数据DAO */
	private BattleReportDao battleReportDao;
	
	/** 战报服务类型 */
	private BattleReportServiceType serviceType;
	/** 是否输出到文件展示 */
	private boolean fileViewOutput = false;
	
	public BattleReportService(AsyncService asyncService, TimeService timeService, ScheduleService scheduleService,
			GameServerConfig gameServerConfig) {
		idGenerator = new BattleReportIdGenerator();
		
		this.asyncService = asyncService; 
		this.timeService = timeService;
		this.scheduleService = scheduleService;
		this.gameServerConfig = gameServerConfig;
//		this.battleReportDao = battleReportDao;
	}
	
	/**
	 * 初始化
	 */
	public void start() {
		serviceType = BattleReportServiceType.indexOf(gameServerConfig.getBattleReportServiceType());
		
		//数据库战报服务
		//服务器启动时建立数据表，并且初始化每天自动建表的事件
		if(serviceType == BattleReportServiceType.DB) {
			final long now = timeService.now();
			//建一次表
			createTable();
			
			//重置id生成的sequence
			int todayDatePrefix = idGenerator.getDatePrefix(new Date(now));
			long maxId = battleReportDao.getMaxId(todayDatePrefix);
			if(maxId == 0) {
				idGenerator.reset(todayDatePrefix, 0);
			}
			else {
				idGenerator.resetWithMaxId(todayDatePrefix, maxId);
			}
			
			//开始调度事件
			long delay = TimeUtils.getTodayBegin(timeService) + TimeUtils.DAY - now + 10000; //10000只是错开0点的高峰点
			ScheduleCreateBattleReportTable msg = new ScheduleCreateBattleReportTable(now);
			scheduleService.scheduleWithFixedDelay(msg, delay, TimeUtils.DAY);
		}
		//文件战报服务
		//服务器启动时创建当天日志目录，并且初始化每天自动建目录的事件
		else if(serviceType == BattleReportServiceType.FILE) {
			File reportRootDir = new File(gameServerConfig.getBattleReportRootPath());
			if(!reportRootDir.exists()) {
				reportRootDir.mkdir();
			}
			
			//创建目录
			createTodayAndTomorrowDir();
			
			//重置id生成的sequence:遍历所有文件，获取最大id，即为sequence
			long now = timeService.now();
			int todayDatePrefix = idGenerator.getDatePrefix(new Date(now));
			File dir = new File(getDirName(todayDatePrefix));
			File[] files = dir.listFiles();
			long maxId = 0;
			for(File file : files) {
				if(file.isDirectory()) continue;
				String fileName = file.getName();
				if(fileName.endsWith(BATTLE_REPORT_FILE_SUFFIX)) {
					try{
						long id = Long.parseLong(fileName.substring(0, fileName.indexOf(BATTLE_REPORT_FILE_SUFFIX)));
						if(maxId < id) maxId = id;
					} catch(Exception e) {
						logger.error("", e);
					}
				}
			}
			if(maxId == 0) {
				idGenerator.reset(todayDatePrefix, 0);
			}
			else {
				idGenerator.resetWithMaxId(todayDatePrefix, maxId);
			}
			
			//开始调度事件
			long delay = TimeUtils.getTodayBegin(timeService) + TimeUtils.DAY - now +  10000; //10000只是错开0点的高峰点
			ScheduleCreateBattleReportDir msg = new ScheduleCreateBattleReportDir(now);
			scheduleService.scheduleWithFixedDelay(msg, delay, TimeUtils.DAY);
		}
		
		//保存日志到文件的配置
		//条件：debug模式，并且打开开关
		//XXX暂时关闭此功能，留待需要时开启
//		if(gameServerConfig.getIsDebug() && gameServerConfig.getFuncSwitches().isBattleReportFileOutput()) {
//			//检查目录是否存在
//			File reportDir = new File(gameServerConfig.getBattleReportRootPath());
//			if(!reportDir.exists()) {
//				reportDir.mkdir();
//			}
//			fileViewOutput = true;
//		}

	}
	
	/**
	 * 读取战报并下发给客户端
	 */
	public void playBattleReport(Human human, long id, boolean isTeamWar,int toBackType) {
//		if(serviceType == BattleReportServiceType.DB) {
//			loadBattleReportFromDB(human, id, isTeamWar,toBackType);
//		} else {
			loadBattleReportFromFile(human, id, isTeamWar,toBackType);
//		}
	}

	
//	/**
//	 * 从数据库读取战报
//	 * @param human
//	 * @param id
//	 */
//	void loadBattleReportFromDB(Human human, long id, boolean isTeamWar,int toBackType) {
//		LoadBattleReportFromDBOperation operation = new LoadBattleReportFromDBOperation(human, id, isTeamWar,toBackType);
//		asyncService.createOperationAndExecuteAtOnce(operation, human.getUUID());
//	}
	
	/**
	 * 从文件读取战报
	 * @param human
	 * @param id
	 */
	void loadBattleReportFromFile(Human human, long id, boolean isTeamWar,int toBackType) {
		LoadBattleReportFromFileOperation operation = new LoadBattleReportFromFileOperation(human, id, isTeamWar,toBackType);
		asyncService.createOperationAndExecuteAtOnce(operation, human.getUUID());
	}
	
	
	/**
	 * 保存战报
	 * @param battleReportData
	 * @return
	 */
	public void saveBattleReport(long id, List<String> battleReportData) {
//		if(serviceType == BattleReportServiceType.DB) {
//			saveBattleReportToDB(id, battleReportData);
//		} else {
			saveBattleReportToFile(id, battleReportData);
//		}
	}
	
//	/**
//	 * 保存战报到数据库
//	 * @param id
//	 * @param battleReportData
//	 */
//	void saveBattleReportToDB(long id, String battleReportData) {
//		BattleReportEntity battleReportEntity = new BattleReportEntity();
//		battleReportEntity.setId(id);
//		battleReportEntity.setData(battleReportData);
//		long now = timeService.now();
//		battleReportEntity.setCreateTime(new Timestamp(now));
//		
//		SaveBattleReportToDBOperation operation = new SaveBattleReportToDBOperation(battleReportEntity, new Date(now));
//		asyncService.createOperationAndExecuteAtOnce(operation);
//	}
	
	/**
	 * 保存战报到文件
	 * @param id
	 * @param battleReportData
	 */
	void saveBattleReportToFile(long id, List<String> battleReportData) {
		SaveBattleReportToFileOperation operation = new SaveBattleReportToFileOperation(id, battleReportData);
		asyncService.createOperationAndExecuteAtOnce(operation);
	}
	
	/**
	 * 是否开启保存战报到文件的功能
	 * @return
	 */
	public boolean isBattleReportFileViewOutputOn() {
		return fileViewOutput;
	}
	
	/**
	 * 保存战报到文件
	 * @param id
	 * @param battleReportData
	 */
	public void saveBattleReportToFileForView(final long id, final String battleReportData) {
		if(!fileViewOutput) return;
		
		
		IIoOperation saveBattleReportFileOperation = new IIoOperation() {
			
			@Override
			public int doStop() {
				return STAGE_STOP_DONE;
			}
			
			@Override
			public int doStart() {
				return STAGE_START_DONE;
			}
			
			@Override
			public int doIo() {
				try {
					OutputStreamWriter writer = new OutputStreamWriter(new FileOutputStream(getBattleReportFilePath(id)));
					writer.write(battleReportData);
					writer.close();
				} catch (IOException e) {
					logger.error("", e);
				} 
				return STAGE_IO_DONE;
			}
		};
		asyncService.createOperationAndExecuteAtOnce(saveBattleReportFileOperation);
		
	}
	
	/**
	 * 生成战报id
	 * @return
	 */
	public long generateReportId() {
		return idGenerator.generate(timeService.now());
	}
	
	/**
	 * 获得保存的战报文件路径
	 * @param reportId
	 * @return
	 */
	public String getBattleReportFilePath(long reportId) {
		return getDirName(getDatePrefix(reportId)) + File.separator + reportId + BATTLE_REPORT_FILE_SUFFIX;
	}
	
	/**
	 * 发送战报消息
	 * @param human
	 * @param reportData
	 */
	public void sendBattleReportMsg(Human human, String reportData, long reportId, boolean canClose, boolean hasUrl,int toBackType, String additionPack) {
		GCPlayBattleReport msg = new GCPlayBattleReport();
		msg.setId(reportId);
		msg.setReportPack(reportData);
		msg.setCanClose(canClose ? 1 : 0);
		msg.setHasUrl(hasUrl ? 1 : 0);
		msg.setToBackType(toBackType);
		msg.setAdditionPack(additionPack);
		human.sendMessage(msg);
	}
	
	/**
	 * 发送战斗开始或每轮的战报
	 * @param human
	 * @param playType
	 * @param reportPack
	 * @param additionPack
	 */
	public void sendBattlePartReport(Human human, ReportMsgType playType, String reportPack, String additionPack) {
		GCBattleReportPart msg = new GCBattleReportPart();
		msg.setPlayType(playType.getIndex());
		msg.setReportPack(reportPack);
		msg.setAdditionPack(additionPack);
		human.sendMessage(msg);
	}
	
	public void sendPvpBattleReport(Human human, ReportMsgType playType, String reportPack, 
			long attackerId, long defenderId, long roundStartTime, boolean isAuto) {
		GCBattleReportPvp msg = new GCBattleReportPvp(playType.getIndex(), reportPack, 
				attackerId, defenderId, roundStartTime, Globals.getTimeService().now(), isAuto ? 1 : 0);
		human.sendMessage(msg);
	}
	
	public void sendTeamBattleReport(Human human, ReportMsgType playType, String reportPack, 
			int teamId, long roundStartTime, boolean isAuto, boolean isAttacker, String additionPack) {
		GCBattleReportTeam msg = new GCBattleReportTeam(playType.getIndex(), reportPack, 
				teamId, roundStartTime, Globals.getTimeService().now(), isAuto ? 1 : 0,
						isAttacker ? SideType.ATTACKER.getIndex() : SideType.DEFENDER.getIndex(), additionPack);
		human.sendMessage(msg);
	}
	
//	/**
//	 * 发送战报消息
//	 * @param human
//	 * @param reportData
//	 */
//	public void sendBattleReportMsg(Human human, String reportData, long reportId, boolean canClose, boolean hasUrl) {
//		this.sendBattleReportMsg(human, reportData, reportId, canClose, hasUrl,0);
//	}
	
//	/**
//	 * 发送团战战报消息
//	 * @param human
//	 * @param reportData
//	 */
//	public void sendTeamWarReportMsg(Human human, String reportData) {
//		GCPlayTeamWarReport msg = new GCPlayTeamWarReport();
//		msg.setReportPack(reportData);
//		human.sendMessage(msg);
//	}
	
	/**
	 * 建表
	 */
	public void createTable() {
		Date today = new Date(timeService.now());
		battleReportDao.createTable(today);
		
		Date tomorrow = new Date(timeService.now() + TimeUtils.DAY);
		battleReportDao.createTable(tomorrow);

	}
	
	/**
	 * 创建今天和明天的战报文件目录
	 */
	public void createTodayAndTomorrowDir() {
		Date today = new Date(timeService.now());
		File todayDir = new File(getDirName(idGenerator.getDatePrefix(today)));
		if(!todayDir.exists()) {
			todayDir.mkdir();
		}
		
		Date tomorrow = new Date(timeService.now() + TimeUtils.DAY);
		File tomorrowDir = new File(getDirName(idGenerator.getDatePrefix(tomorrow)));
		if(!tomorrowDir.exists()) {
			tomorrowDir.mkdir();
		}
	}
	
	String getDirName(int datePrefix) {
		return gameServerConfig.getBattleReportRootPath() + File.separator + String.valueOf(datePrefix);
	}
	
	/**
	 * 重置id
	 * @param date
	 * @param sequence
	 */
	public void resetIdSequence(Date date) {
		idGenerator.reset(idGenerator.getDatePrefix(date), 0);
	}
	
	public int getDatePrefix(long id) {
		return idGenerator.getDatePrefix(id);
	}
	
	/**
	 * 战报服务的类型
	 * @author yue.yan
	 *
	 */
	public static enum BattleReportServiceType implements IndexedEnum
	{
		/** 文件 */
		FILE(0),
		/** 数据库 */
		DB(1),
		;
		
		private final int index;
		
		/** 按索引顺序存放的枚举数组 */
		private static final List<BattleReportServiceType> indexes = IndexedEnumUtil.toIndexes(BattleReportServiceType.values());
		
		private BattleReportServiceType(int index) {
			this.index = index;
		}
		
		/**
		 * 根据指定的索引获取枚举的定义
		 * 
		 * @param index
		 * @return
		 */
		public static BattleReportServiceType indexOf(final int index) {
			return indexes.get(index);
		}
		
		public int getIndex() {
			return index;
		}
	}
	
	/**
	 * 用于自动建战报表的调度事件
	 * @author yue.yan
	 *
	 */
	public class ScheduleCreateBattleReportTable extends ScheduledMessage {

		public ScheduleCreateBattleReportTable(long createTime) {
			super(createTime);
		}

		@Override
		public void execute() {
			//建表
			CreateBattleReportTableOperation operation = new CreateBattleReportTableOperation();
			asyncService.createOperationAndExecuteAtOnce(operation);
			
			//重置id
			Globals.getBattleReportService().resetIdSequence(new Date());
		}

	}
	
	/**
	 * 用于自动建战报目录的调度事件
	 * @author yue.yan
	 *
	 */
	public class ScheduleCreateBattleReportDir extends ScheduledMessage {
		
		public ScheduleCreateBattleReportDir(long createTime) {
			super(createTime);
		}
		
		@Override
		public void execute() {
			CreateBattleReportDirOperation operation = new CreateBattleReportDirOperation();
			asyncService.createOperationAndExecuteAtOnce(operation);
			
			//重置id
			Globals.getBattleReportService().resetIdSequence(new Date());
		}
	}

}
