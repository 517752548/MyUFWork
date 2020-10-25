package com.imop.lj.gm.dao.log;

import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import org.hibernate.Hibernate;
import org.hibernate.SQLQuery;
import org.hibernate.type.Type;
import org.hibernate.type.TypeFactory;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NodeList;

import com.imop.lj.db.model.ArenaSnapEntity;
import com.imop.lj.db.model.CorpsEntity;
import com.imop.lj.db.model.DoingQuestEntity;
import com.imop.lj.db.model.FinishedQuestEntity;
import com.imop.lj.db.model.ItemEntity;
import com.imop.lj.db.model.PetEntity;
import com.imop.lj.db.model.PrizeInfo;
import com.imop.lj.db.model.RelationEntity;
import com.imop.lj.db.model.UserPrize;
import com.imop.lj.gm.autolog.GMAutoLogConstants;
//import com.imop.lj.gm.autolog.model.BunLog;
//import com.imop.lj.gm.autolog.model.EveryDayTargetLog;
//import com.imop.lj.gm.autolog.model.EverydayChargeLog;
import com.imop.lj.gm.model.log.ArenaLog;
import com.imop.lj.gm.model.log.ArenaRecodeLog;
import com.imop.lj.gm.model.log.BasicPlayerLog;
import com.imop.lj.gm.model.log.BattleLog;
import com.imop.lj.gm.model.log.BehaviorLog;
import com.imop.lj.gm.model.log.CampLog;
import com.imop.lj.gm.model.log.ChargeLog;
import com.imop.lj.gm.model.log.ChatLog;
import com.imop.lj.gm.model.log.CheatLog;
import com.imop.lj.gm.model.log.CleanMissionLog;
import com.imop.lj.gm.model.log.CommerceLog;
import com.imop.lj.gm.model.log.CommercemeetingLog;
import com.imop.lj.gm.model.log.CompanyUpgradeLog;
import com.imop.lj.gm.model.log.DayChongRewardLog;
import com.imop.lj.gm.model.log.DistrictLog;
import com.imop.lj.gm.model.log.DropItemLog;
import com.imop.lj.gm.model.log.EmbedDiamondLog;
import com.imop.lj.gm.model.log.EmployeeLog;
import com.imop.lj.gm.model.log.EscortLog;
import com.imop.lj.gm.model.log.ExploitLog;
import com.imop.lj.gm.model.log.FeedCatLog;
import com.imop.lj.gm.model.log.FlowersLog;
import com.imop.lj.gm.model.log.GmCommandLog;
import com.imop.lj.gm.model.log.GrainLog;
import com.imop.lj.gm.model.log.GuildLog;
import com.imop.lj.gm.model.log.HeritageLog;
import com.imop.lj.gm.model.log.HuntItemLog;
import com.imop.lj.gm.model.log.HunterLog;
import com.imop.lj.gm.model.log.ItemGenLog;
import com.imop.lj.gm.model.log.ItemLog;
import com.imop.lj.gm.model.log.JewelryAllanceLog;
import com.imop.lj.gm.model.log.LevelLog;
import com.imop.lj.gm.model.log.LevyLog;
import com.imop.lj.gm.model.log.MailLog;
import com.imop.lj.gm.model.log.MateriaSynthesisLog;
import com.imop.lj.gm.model.log.MissionLog;
import com.imop.lj.gm.model.log.MoneyLog;
import com.imop.lj.gm.model.log.OnlineTimeLog;
import com.imop.lj.gm.model.log.PetExpLog;
import com.imop.lj.gm.model.log.PetLevelLog;
import com.imop.lj.gm.model.log.PetLog;
import com.imop.lj.gm.model.log.PlayerLoginLog;
import com.imop.lj.gm.model.log.PrestigeLog;
import com.imop.lj.gm.model.log.PrizeLog;
import com.imop.lj.gm.model.log.ProbeLog;
import com.imop.lj.gm.model.log.ReasonList;
import com.imop.lj.gm.model.log.RelationLog;
import com.imop.lj.gm.model.log.SecretaryLog;
import com.imop.lj.gm.model.log.SilveroreLog;
import com.imop.lj.gm.model.log.SnapLog;
import com.imop.lj.gm.model.log.SortLevelLog;
import com.imop.lj.gm.model.log.TaskLog;
import com.imop.lj.gm.model.log.UserActionLog;
import com.imop.lj.gm.model.log.VipLog;
import com.imop.lj.gm.model.log.WarLog;
import com.imop.lj.gm.model.log.WashDiamondLog;

/**
 * @author <a href="mailto:dongyong.wang@opi-corp.com">wang dong yong<a>
 *
 */
@SuppressWarnings("unchecked")
public class LogTypeUtils {

	private static final Pattern GETTER_METHOD = Pattern.compile("get(.+)");

	private static final Pattern PRO_COLUNM = Pattern.compile("([A-Z]{1})");

	private static final Map<String, Type> INGORE_FIELDS = new HashMap<String, Type>();

	private static final Map<Class<?>, List<ColumnMapping>> LOG_COLUMN_MAPPING = new HashMap<Class<?>, List<ColumnMapping>>();

	private static final Map<Class, Map<String, String>> LOG_COLUMN_PROP_MAPPING = new HashMap<Class, Map<String, String>>();

	private static final Map<Class, List<ColumnMapping>> COLUMN_MAPPING = new HashMap<Class, List<ColumnMapping>>();

	/*
	 * 初始化不转换的类型
	 */
	static {
		INGORE_FIELDS.put("createTime", Hibernate.LONG);
	}

	/*
	 * 初始化各Log类型的字段对应关系
	 */
	static {
		// 注册数据库字段是以_分隔属性的表
		regLogTable(CampLog.class, LOG_COLUMN_MAPPING);
		regLogTable(MoneyLog.class, LOG_COLUMN_MAPPING);
		regLogTable(GrainLog.class, LOG_COLUMN_MAPPING);
		regLogTable(ExploitLog.class, LOG_COLUMN_MAPPING);
		regLogTable(PrestigeLog.class, LOG_COLUMN_MAPPING);
		regLogTable(GmCommandLog.class, LOG_COLUMN_MAPPING);
		regLogTable(BasicPlayerLog.class, LOG_COLUMN_MAPPING);
		regLogTable(TaskLog.class, LOG_COLUMN_MAPPING);
		regLogTable(LevelLog.class, LOG_COLUMN_MAPPING);
		regLogTable(SnapLog.class, LOG_COLUMN_MAPPING);
		regLogTable(PetLog.class, LOG_COLUMN_MAPPING);
		regLogTable(PetExpLog.class, LOG_COLUMN_MAPPING);
		regLogTable(PetLevelLog.class, LOG_COLUMN_MAPPING);
		regLogTable(MailLog.class, LOG_COLUMN_MAPPING);
		regLogTable(GuildLog.class, LOG_COLUMN_MAPPING);
		regLogTable(PrizeLog.class, LOG_COLUMN_MAPPING);
		regLogTable(ItemLog.class, LOG_COLUMN_MAPPING);
		regLogTable(ItemGenLog.class, LOG_COLUMN_MAPPING);
		regLogTable(ChatLog.class, LOG_COLUMN_MAPPING);
		regLogTable(CheatLog.class, LOG_COLUMN_MAPPING);
		regLogTable(OnlineTimeLog.class, LOG_COLUMN_MAPPING);
		regLogTable(ChargeLog.class, LOG_COLUMN_MAPPING);
		regLogTable(ReasonList.class, LOG_COLUMN_MAPPING);
		regLogTable(BattleLog.class, LOG_COLUMN_MAPPING);
		regLogTable(ChatLog.class, LOG_COLUMN_MAPPING);
		regLogTable(WarLog.class, LOG_COLUMN_MAPPING);
		regLogTable(EmployeeLog.class, LOG_COLUMN_MAPPING);
		regLogTable(SecretaryLog.class, LOG_COLUMN_MAPPING);
		regLogTable(CompanyUpgradeLog.class, LOG_COLUMN_MAPPING);
		regLogTable(LevyLog.class, LOG_COLUMN_MAPPING);
		regLogTable(ArenaLog.class, LOG_COLUMN_MAPPING);
		regLogTable(BehaviorLog.class, LOG_COLUMN_MAPPING);
		regLogTable(DistrictLog.class, LOG_COLUMN_MAPPING);
		regLogTable(DropItemLog.class, LOG_COLUMN_MAPPING);
		regLogTable(EscortLog.class, LOG_COLUMN_MAPPING);
		regLogTable(HuntItemLog.class, LOG_COLUMN_MAPPING);
		regLogTable(HunterLog.class, LOG_COLUMN_MAPPING);
		regLogTable(MissionLog.class, LOG_COLUMN_MAPPING);
		regLogTable(OnlineTimeLog.class, LOG_COLUMN_MAPPING);
		regLogTable(PlayerLoginLog.class, LOG_COLUMN_MAPPING);
		regLogTable(ProbeLog.class, LOG_COLUMN_MAPPING);
		regLogTable(RelationLog.class, LOG_COLUMN_MAPPING);
		regLogTable(UserActionLog.class, LOG_COLUMN_MAPPING);
		regLogTable(VipLog.class, LOG_COLUMN_MAPPING);
		regLogTable(SortLevelLog.class, LOG_COLUMN_MAPPING);
		regLogTable(CleanMissionLog.class, LOG_COLUMN_MAPPING);
		regLogTable(CommerceLog.class, LOG_COLUMN_MAPPING);
		regLogTable(ArenaRecodeLog.class, LOG_COLUMN_MAPPING);
		regLogTable(CommercemeetingLog.class, LOG_COLUMN_MAPPING);
		regLogTable(FeedCatLog.class, LOG_COLUMN_MAPPING);
		regLogTable(JewelryAllanceLog.class, LOG_COLUMN_MAPPING);
		regLogTable(EmbedDiamondLog.class, LOG_COLUMN_MAPPING);
		regLogTable(WashDiamondLog.class, LOG_COLUMN_MAPPING);
		regLogTable(FlowersLog.class, LOG_COLUMN_MAPPING);
		regLogTable(SilveroreLog.class, LOG_COLUMN_MAPPING);
		regLogTable(MateriaSynthesisLog.class, LOG_COLUMN_MAPPING);
		regLogTable(DayChongRewardLog.class, LOG_COLUMN_MAPPING);
		regLogTable(HeritageLog.class, LOG_COLUMN_MAPPING);
//		regLogTable(BunLog.class, LOG_COLUMN_MAPPING);
//		regLogTable(FriendLog.class, LOG_COLUMN_MAPPING);
//		regLogTable(BasicPlayerLog.class, LOG_COLUMN_MAPPING);
//		regLogTable(ChatLog.class, LOG_COLUMN_MAPPING);
//		regLogTable(CheatLog.class, LOG_COLUMN_MAPPING);
//		regLogTable(ExpLog.class, LOG_COLUMN_MAPPING);
//		regLogTable(EveryDayTargetLog.class, LOG_COLUMN_MAPPING);
//		regLogTable(EverydayChargeLog.class, LOG_COLUMN_MAPPING);
		//注册自动生成的日志
		regAutoLogTable(LOG_COLUMN_MAPPING);
		
		/** 注册数据库字段与java实体一致的表 */
		regTable(UserPrize.class, COLUMN_MAPPING);
		regTable(PrizeInfo.class, COLUMN_MAPPING);
//		regTable(CommerceEntity.class, COLUMN_MAPPING);
//		regTable(CommerceMemberEntity.class, COLUMN_MAPPING);
//		regTable(ShopmallEntity.class, COLUMN_MAPPING);
//		regTable(SortArenaLevelEntity.class, COLUMN_MAPPING);
//		regTable(EmployeeEntity.class, COLUMN_MAPPING);
//		regTable(BattleSnapEntity.class, COLUMN_MAPPING);
//		regTable(BranchEntity.class, COLUMN_MAPPING);
		regTable(ArenaSnapEntity.class, COLUMN_MAPPING);
//		regTable(DailyQuestEntity.class, COLUMN_MAPPING);
		regTable(RelationEntity.class, COLUMN_MAPPING);
//		regTable(EscortSnapEntity.class, COLUMN_MAPPING);
//		regTable(SecretaryEntity.class, COLUMN_MAPPING);
		regTable(DoingQuestEntity.class, COLUMN_MAPPING);
		regTable(FinishedQuestEntity.class, COLUMN_MAPPING);
//		regTable(HunterEntity.class, COLUMN_MAPPING);
		regTable(ItemEntity.class, COLUMN_MAPPING);
		regTable(PetEntity.class, COLUMN_MAPPING);
		regTable(CorpsEntity.class, COLUMN_MAPPING);
//		regTable(TempHuntBagEntity.class, COLUMN_MAPPING);
//		regTable(EscortHelpSnapEntity.class, COLUMN_MAPPING);
//		regTable(SortHonorLevelEntity.class, COLUMN_MAPPING);
//		regTable(SortCompanyIncomeLevelEntity.class, COLUMN_MAPPING);
//		regTable(CommerceEntity.class, COLUMN_MAPPING);
//		regTable(CommerceMemberEntity.class, COLUMN_MAPPING);
//		regTable(AddressBookEntity.class, COLUMN_MAPPING);
		//TODO

		// 初始化各日志表的数据库字段与Bean Property得映射
		for (Class _clazz : LOG_COLUMN_MAPPING.keySet()) {
			Map<String, String> _column2prop = new HashMap<String, String>();
			LOG_COLUMN_PROP_MAPPING.put(_clazz, _column2prop);
			for (ColumnMapping _mapping : LOG_COLUMN_MAPPING.get(_clazz)) {
				_column2prop.put(_mapping.columnName, _mapping.propName);
			}
		}
	}

	/**
	 * 数据表的字段类型定义
	 */
	public static class ColumnMapping {
		public final String columnName;
		public final String propName;
		public final Type type;

		public ColumnMapping(String columnName, String propName, Type type) {
			this.columnName = columnName;
			this.propName = propName;
			this.type = type;
		}
	}

	/**
	 *
	 * @param query
	 * @param logClass
	 */
	public static void addLogQueryScalar(SQLQuery query, Class<?> logClass) {
		List<ColumnMapping> _list = LOG_COLUMN_MAPPING.get(logClass);
		if (_list == null) {
			throw new IllegalArgumentException(
					"Can't find the column mapping for class [" + logClass
							+ "]");
		}

		for (ColumnMapping _mapping : _list) {
			query.addScalar(_mapping.columnName, _mapping.type);
		}
	}

	/**
	 *
	 * @param query
	 * @param logClass
	 */
	public static void addQueryScalar(SQLQuery query, Class logClass) {
		List<ColumnMapping> _list = COLUMN_MAPPING.get(logClass);
		if (_list == null) {
			throw new IllegalArgumentException(
					"Can't find the column sss mapping for class [" + logClass
							+ "]");
		}
		for (ColumnMapping _mapping : _list) {
//			System.out.println("##############################"+_mapping.propName+"############################"+_mapping.type);
			query.addScalar(_mapping.propName, _mapping.type);
		}
	}

	/**
	 *
	 * @param logClass
	 * @param columnName
	 * @return
	 */
	public static String getPropName(Class logClass, String columnName) {
		System.out.println("**************************"+logClass+"************************"+columnName);
		return LOG_COLUMN_PROP_MAPPING.get(logClass).get(columnName);
	}
	/*
	 * COLUMN_MAPPING
	 * 只做main测试用
	 */
	public static String getTestPropName(Class logClass, String columnName){

		System.out.println("**************************"+logClass);
		for(ColumnMapping ss:COLUMN_MAPPING.get(logClass)){
			System.out.println("***************"+ss.columnName+"************"+ss.propName+"**************"+ss.type);
		}
		return null;
	}

	/**
	 *
	 *
	 * @param logClass
	 * @param map
	 */
	private static void regLogTable(Class logClass,
			Map<Class<?>, List<ColumnMapping>> map) {
		List<ColumnMapping> tableColumns = parseLogTableColumns(logClass);
		if (tableColumns.isEmpty()) {
			throw new IllegalArgumentException("The log type [" + logClass
					+ "] does not find the column mappings");
		}
		map.put(logClass, tableColumns);
	}

	/**
	 * 注册非日志类型的表
	 *
	 * @param entityClass
	 * @param log_column_mapping2
	 */
	private static void regTable(Class entityClass,
			Map<Class, List<ColumnMapping>> log_column_mapping2) {
		List<ColumnMapping> tableColumns = parseTableColumns(entityClass);
		if (tableColumns.isEmpty()) {
			throw new IllegalArgumentException("The log type [" + entityClass
					+ "] does not find the column mappings");
		}
//		System.out.println("---------------------------"+entityClass+"---------------------------"+tableColumns);
		log_column_mapping2.put(entityClass, tableColumns);
	}

	/**
	 *
	 * @param logClass
	 * @return
	 */
	private static List<ColumnMapping> parseLogTableColumns(Class<?> logClass) {
		List<ColumnMapping> _columnMappings = new ArrayList<ColumnMapping>();
		Method[] _allMethods = logClass.getMethods();
		for (Method _method : _allMethods) {
			String _name = _method.getName();
			Matcher _matcher = GETTER_METHOD.matcher(_name);
			if (!_matcher.matches()) {
				continue;
			}
			ColumnMapping _columnMapping = null;
			String _fieldName = _matcher.group(1);
			String _setterName = "set" + _fieldName;
			try {
				logClass.getMethod(_setterName, _method.getReturnType());
			} catch (Exception e) {
				continue;
			}
			_fieldName = _fieldName.substring(0, 1).toLowerCase()
					+ _fieldName.substring(1);
			if (INGORE_FIELDS.containsKey(_fieldName)) {
				_columnMapping = new ColumnMapping(_fieldName, _fieldName,
						INGORE_FIELDS.get(_fieldName));
			} else {
				String _columnName = PRO_COLUNM.matcher(_fieldName).replaceAll(
						"_$1").toLowerCase();
				Class<?> _returnType = _method.getReturnType();
				Type _type = TypeFactory.basic(_returnType.getName());
				if (_type == null) {
					throw new IllegalArgumentException("Can't mapt the type ["
							+ _returnType + "] to the hibernate type");
				}
				_columnMapping = new ColumnMapping(_columnName, _fieldName,
						_type);
			}
			_columnMappings.add(_columnMapping);
		}
		return _columnMappings;
	}

	/**
	 *
	 * @param logClass
	 * @return
	 */
	private static List<ColumnMapping> parseTableColumns(Class logClass) {
		List<ColumnMapping> _columnMappings = new ArrayList<ColumnMapping>();
		Method[] _allMethods = logClass.getMethods();
		for (Method _method : _allMethods) {
			String _name = _method.getName();
			if (_method.getReturnType().isInterface()) {
				continue;
			}
			Matcher _matcher = GETTER_METHOD.matcher(_name);
			if (!_matcher.matches()) {
				continue;
			}
			ColumnMapping _columnMapping = null;
			String _fieldName = _matcher.group(1);
			String _setterName = "set" + _fieldName;
			try {
				logClass.getMethod(_setterName, _method.getReturnType());
			} catch (Exception e) {
				continue;
			}
			_fieldName = _fieldName.substring(0, 1).toLowerCase()
					+ _fieldName.substring(1);
			String _columnName = PRO_COLUNM.matcher(_fieldName).replaceAll(
					"_$1").toLowerCase();
			Class<?> _returnType = _method.getReturnType();
			Type _type = TypeFactory.basic(_returnType.getName());
			if (_type == null) {
				throw new IllegalArgumentException("Can't mapt the type ["
						+ _returnType + "] to the hibernate type");
			}
//			System.out.println("%%%%%%%%%%%%%%%%"+_columnName+"%%%%%%%%%%%%%%%%%"+_fieldName+"%%%%%%%%%%%%%%%%"+_type);
			_columnMapping = new ColumnMapping(_columnName, _fieldName, _type);
			_columnMappings.add(_columnMapping);
		}
		return _columnMappings;
	}

	public static void main(String[] args) {
//		regTable(EmployeeEntity.class, COLUMN_MAPPING);
//		LogTypeUtils.getTestPropName(SortArenaLevelEntity.class,"name");
//		List<ColumnMapping> parseLogTableColumns = parseTableColumns(EmployeeEntity.class);
//		for (ColumnMapping _mapping : parseLogTableColumns) {
//			System.out.println("column:" + _mapping.columnName + " prop:"
//					+ _mapping.propName + " type:" + _mapping.type);
//		}
//		for(ColumnMapping _mapping : COLUMN_MAPPING.get(EmployeeEntity.class)){
//			System.out.println(LogTypeUtils.getPropName(EmployeeEntity.class,_mapping.propName));
//		}
		//LogTypeUtils.getPropName(SortArenaLevelEntity.class,"name");
	}
	
	/***
	 * 注册自动化log的map
	 * @param map
	 */
	public static void regAutoLogTable(Map<Class<?>, List<ColumnMapping>> map) {
		Document doc = GMAutoLogConstants.getLogTypesDoc();
		NodeList types = doc.getElementsByTagName("type");
		for (int i = 0; i < types.getLength(); i++) {
			Element m = (Element) types.item(i);
			String className = m.getAttribute("class");
			
			Class instance = null;
			try {
				instance = Class.forName(className);
			} catch (ClassNotFoundException e) {
				e.printStackTrace();
			}
			if(instance == null) {
				continue;
			}
			
			if(map.containsKey(instance)) {
				continue;
			}
			regLogTable(instance, map);
		}
	}
}
