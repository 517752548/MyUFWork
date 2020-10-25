package com.imop.lj.gameserver.dirtywords;

import java.util.HashSet;
import java.util.Set;

import net.sf.json.JSONObject;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.service.DirtFilterService.WordCheckType;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.i18n.SysLangService;
import com.imop.lj.core.util.IKeyWordsFilter;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.core.util.KeyWordsACFilter;
import com.imop.lj.core.util.MySqlUtil;
import com.imop.lj.core.util.StringUtils;
import com.imop.lj.db.model.DirtyWordsTypeEntity;
import com.imop.lj.gameserver.common.Globals;

/**
 * 脏语言过滤服务
 * @author yu.zhao
 *
 */
public class DirtyFilterNetService implements InitializeRequired{
	public static final char SUBSTITUTE_CHAR = '*';
	public static final char[] IGNORE_CHARS = { '　', ' ', '*', '-' };
	public static final char[] ILLEGAL_CHARS = {' ','　','<','>','_'};

	/** 过滤器，本地|简版|繁版 */
	protected volatile IKeyWordsFilter filter;
	/** 名字过滤器 */
	protected volatile IKeyWordsFilter namefilter;

	/** 多语言管理 */
	protected SysLangService sysLangService;
	/***下载过滤语言类*/
	protected WordFilterNetDownload worldFilterNetDownLoad;
	
	/***
	 * 
	 * @param sysLangService
	 */
	protected DirtyWordsType dirtyWorldsType;

	public DirtyFilterNetService(SysLangService sysLangService) {
		this.sysLangService = sysLangService;
		worldFilterNetDownLoad = new WordFilterNetDownload();
	}

	@Override
	public void init() {
		// 初始化过滤词类型
		initDirtyWorldsType();
		
		// 初始化名称过滤器
		initNameFilter();
		
		// 初始化过滤器
		DirtyWordsTypeEnum type = getDirtyWorldsTypeEnum();
		switch (type) {
		case GAMESERVER:
			buildNativeFilter();
			break;
		case PART:
			dirtyWorldsPartInit(true);
			break;
		case FULL:
			dirtyWorldsPartFull(true);
			break;
		default:
			buildNativeFilter();
			Loggers.dirtyWordsLogger.error("DirFilterNetService.init() DirtyWordsTypeEnum is invalide!");
			break;
		}
	}
	
	protected void buildNativeFilter() {
		this.filter = new KeyWordsACFilter(IGNORE_CHARS, SUBSTITUTE_CHAR);
		String[] dirtyWords = Globals.getDirtyWordsArr();
		// 去重
		Set<String> tmpSet = new HashSet<String>();
		for (String str : dirtyWords) {
			tmpSet.add(str);
		}
		String[] filterArr = new String[tmpSet.size()];
		int i = 0;
		for (String str : tmpSet) {
			filterArr[i++] = str;
		}
		filter.initialize(filterArr);
		
		// 更新db为本地
		updateDirtyWordsTypeInDb(DirtyWordsTypeEnum.GAMESERVER);
	}
	
	protected void initNameFilter() {
		this.namefilter = new KeyWordsACFilter(IGNORE_CHARS, SUBSTITUTE_CHAR);
		
		String[] nameDirtyWords = Globals.getNameDrityWordsArr();
		// 去重
		Set<String> tmpSet = new HashSet<String>();
		for (String str : nameDirtyWords) {
			tmpSet.add(str);
		}
		String[] filterArr = new String[tmpSet.size()];
		int i = 0;
		for (String str : tmpSet) {
			filterArr[i++] = str;
		}
		namefilter.initialize(filterArr);
	}
	
	protected void initDirtyWorldsType() {
		DirtyWordsTypeEntity entity = Globals.getDaoService().getDirtyWordsTypeDao().getDirtyWorldsTypeEntity();
		dirtyWorldsType = new DirtyWordsType();
		if (entity == null) {
			dirtyWorldsType.setDbId(1);
			dirtyWorldsType.setDirtyWordsType(DirtyWordsTypeEnum.GAMESERVER.getIndex());
			dirtyWorldsType.setUpdateTime(Globals.getTimeService().now());
			dirtyWorldsType.setModified();
			
		}else{
			dirtyWorldsType.fromEntity(entity);
		}
	}
	
	
	
	/**
	 * 获得DirtyWorldsType
	 * @return
	 */
	public DirtyWordsTypeEnum getDirtyWorldsTypeEnum() {
		DirtyWordsTypeEnum dirtyWorldsTypeEnum = null;
		dirtyWorldsTypeEnum = DirtyWordsTypeEnum.indexOf(dirtyWorldsType.getDirtyWordsType());
		return dirtyWorldsTypeEnum;
	}
	
	public String filt(String inputMsg) {
		return filter.filt(inputMsg);
	}

	public boolean contains(String msg) {
		return filter.contain(msg);
	}

	public String filtName(String name) {
		return namefilter.filt(filt(name));
	}

	public boolean containsName(String msg) {
		return contains(msg) ? true : namefilter.contain(msg);
	}

	/**
	 * 公用的输入文字检查工具，主要用于玩家姓名，宠物姓名，玩家签名等可能带中文字符的输入检查 包括以下检查：
	 * 
	 * 
	 * 1. 非法字符检查 2. 非法屏蔽字检查 3. 允许的中文字符长度检查 4. 允许的英文字符长度检查 5. 为空检查
	 * 
	 * @param input
	 *            需要检查的输入信息
	 * @param inputType
	 *            输入项信息 ： 角色名/宠物名/角色签名
	 * @param minChLen
	 *            全中文字符时最小长度
	 * @param maxChLen
	 *            全中文字符时最大长度
	 * @param minEngLen
	 *            全英文字符时最小长度
	 * @param maxEngLen
	 *            全英文字符时最大长度
	 * @param checkNull
	 *            是否进行为空，或者长度为0的判断
	 * @return 错误信息
	 */
	public String checkInput(WordCheckType type, String input, int inputType, int minLen, int maxLen, boolean checkNull) {

		// 获取多语言管理类
		// 参数
		Object[] _params = new Object[] { sysLangService.read(inputType) };
		Object[] _minparams = new Object[] { sysLangService.read(inputType), minLen };
		Object[] _maxparams = new Object[] { sysLangService.read(inputType), maxLen };

		// 检查是否为NULL
		if (input == null) {
			return sysLangService.read(LangConstants.GAME_INPUT_NULL, _params);
		}

		// 获取长度
		int _length = input.length();

		int len = 0;
		for (int i = 0; i < _length; i++) {
			char c = input.charAt(i);
			if (c > '\u4E00' && c < '\u9FA5') {
				len = len + 2;
			} else {
				len++;
			}
		}

		// 如果不能为空
		if (checkNull) {
			if (len < 1) {
				return sysLangService.read(LangConstants.GAME_INPUT_TOO_SHORT, _minparams);
			}
		}

		// 检查长度
		if (len < minLen) {
			// 如果输入的字符串小于最小长度
			return sysLangService.read(LangConstants.GAME_INPUT_TOO_SHORT, _minparams);
		}

		// 如果输入的字符串长度大于最大允许长度
		if (len > maxLen) {
			return sysLangService.read(LangConstants.GAME_INPUT_TOO_LONG, _maxparams);
		}

		if (type == WordCheckType.NAME) {
			// 检查字符是否有异常字符
			if (StringUtils.hasExcludeChar(input) || !MySqlUtil.isValidMySqlUTF8Fast(input)) {
				return sysLangService.read(LangConstants.GAME_INPUT_ERROR1, _params);
			}
			// 检查字符是否有非法关键字
			if (this.containsName(input)) {
				return sysLangService.read(LangConstants.GAME_INPUT_ERROR2, _params);
			}
			// 检查非法字符
			for (int i = 0; i < ILLEGAL_CHARS.length; i++) {
				if (input.indexOf(ILLEGAL_CHARS[i]) >= 0) {
					return sysLangService.read(LangConstants.GAME_INPUT_ERROR3, _params);
				}
			}
		} else if (type == WordCheckType.CHAT_ANNOUNCE_DESC) {
			// 检查字符是否有异常字符
			if (StringUtils.hasExcludeChar(input) || !MySqlUtil.isValidMySqlUTF8Fast(input)) {
				return sysLangService.read(LangConstants.GAME_INPUT_ERROR1, _params);
			}
			// 检查字符是否有非法关键字
			if (this.contains(input)) {
				return sysLangService.read(LangConstants.GAME_INPUT_ERROR2, _params);
			}
		}
		return null;
	}

	/***
	 * gm 设置过滤选择
	 */
	public void dirtyWorldsGM(String str){
		if(str==null || str.equals("")){
			//日志
			Loggers.dirtyWordsLogger.info("DirFilterNetService.dirtyWorldsGM() str is null");
			return;
		}
		
		JSONObject json = JSONObject.fromObject(str);
		if(json==null || json.isNullObject() || json.isEmpty()){
			//日志
			Loggers.dirtyWordsLogger.info("DirFilterNetService.dirtyWorldsGM() json is null");
			return ;
		}
		
		int dirtyWorldsTypeSet = JsonUtils.getInt(json, "dirtyWorldsType");
		DirtyWordsTypeEnum dirtyWorldsTypeEnum = DirtyWordsTypeEnum.indexOf(dirtyWorldsTypeSet);
		if (dirtyWorldsTypeEnum == null) {
			Loggers.dirtyWordsLogger.info("DirFilterNetService.dirtyWorldsGM() dirtyWorldsTypeEnum is null");
			return ;
		}
		
		switch (dirtyWorldsTypeEnum) {
		case GAMESERVER:
			buildNativeFilter();
			break;
		case PART:
			dirtyWorldsPartInit(false);
			break;
		case FULL:
			dirtyWorldsPartFull(false);
			break;
		default:
			buildNativeFilter();
			Loggers.dirtyWordsLogger.error("DirFilterNetService.init() DirtyWordsTypeEnum is invalide!");
			break;
		}
		
		Loggers.dirtyWordsLogger.info("DirFilterNetService.dirtyWorldsGM() dirtyWorldsTypeEnum="+dirtyWorldsTypeEnum.getIndex());
	}
	
	/***
	 * 简版
	 */
	public void dirtyWorldsPartInit(boolean isStartServer){
		Loggers.dirtyWordsLogger.info("DirFilterNetService.dirtyWorldsPartInit() start");
		DirtyWordsNetOperation operation = new DirtyWordsNetOperation(worldFilterNetDownLoad,
				Globals.getServerConfig().getDirtyWordsPartUrl(), new WorldsDirtyNetCallBack(DirtyWordsTypeEnum.PART));
		// 开服时直接做操作，不用在异步线程做，否则可能执行不到doStop
		if (isStartServer) {
			if (operation.doIo() == IIoOperation.STAGE_IO_DONE) {
				operation.doStop();
			}
		} else {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(operation);
		}
		Loggers.dirtyWordsLogger.info("DirFilterNetService.dirtyWorldsPartInit() end");
	}
	
	/***
	 * 繁版
	 */
	public void dirtyWorldsPartFull(boolean isStartServer){
		Loggers.dirtyWordsLogger.info("DirFilterNetService.dirtyWorldsPartFull() start");
		DirtyWordsNetOperation operation = new DirtyWordsNetOperation(worldFilterNetDownLoad,
				Globals.getServerConfig().getDirtyWordsFullUrl(), new WorldsDirtyNetCallBack(DirtyWordsTypeEnum.FULL));
		// 开服时直接做操作，不用在异步线程做，否则可能执行不到doStop
		if (isStartServer) {
			if (operation.doIo() == IIoOperation.STAGE_IO_DONE) {
				operation.doStop();
			}
		} else {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(operation);	
		}
		Loggers.dirtyWordsLogger.info("DirFilterNetService.dirtyWorldsPartFull() end");
	}
	
	/**
	 * 更新filter
	 * 注：如果成功则替换filter并更新db中的type；如果失败，则强制更新为本地的
	 * @param filter
	 */
	public void updateFilter(IKeyWordsFilter filter, DirtyWordsTypeEnum type) {
		DirtyWordsTypeEnum oldType = getDirtyWorldsTypeEnum();
		if (filter != null) {
			// 记录日志
			Loggers.dirtyWordsLogger.info("DirFilterNetService.updateFilter ok!DirtyWordsTypeEnum=" + 
					type + ";oldType=" + oldType);
			// 替换filter
			this.filter = filter;
			// filter更新成功后，再更新db
			updateDirtyWordsTypeInDb(type);
		} else {
			// 记录错误日志
			Loggers.dirtyWordsLogger.error("DirFilterNetService.updateFilter failed!fiter is null!DirtyWordsTypeEnum=" + 
					type + ";oldType=" + oldType);
			
			// 失败后，如果原来不是本地的，则强制更新为本地的
			if (oldType != DirtyWordsTypeEnum.GAMESERVER) {
				buildNativeFilter();
			}
		}
	}
	
	/**
	 * 更新数据库的type
	 * @param dirtyWorldsTypeEnum
	 */
	protected void updateDirtyWordsTypeInDb(DirtyWordsTypeEnum dirtyWorldsTypeEnum) {
		// 更新db
		dirtyWorldsType.setDirtyWordsType(dirtyWorldsTypeEnum.getIndex());
		dirtyWorldsType.setUpdateTime(Globals.getTimeService().now());
		dirtyWorldsType.setModified();
	}
	
}
