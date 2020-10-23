package com.imop.lj.gameserver.task.template;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.template.BeanFieldNumber;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.enemy.template.EnemyTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.map.template.MapMeetMonsterTemplate;
import com.imop.lj.gameserver.map.template.MapTemplate;
import com.imop.lj.gameserver.npc.template.NpcTemplate;
import com.imop.lj.gameserver.task.TaskDef.DestType;
import com.imop.lj.gameserver.task.TaskDef.NumRecordType;
import com.imop.lj.gameserver.task.dest.ColletionItemDest;
import com.imop.lj.gameserver.task.dest.EquipDest;
import com.imop.lj.gameserver.task.dest.EquipGemDest;
import com.imop.lj.gameserver.task.dest.EquipStarDest;
import com.imop.lj.gameserver.task.dest.IQuestDestination;
import com.imop.lj.gameserver.task.dest.LeaderLevelADest;
import com.imop.lj.gameserver.task.dest.LeaderMindALevelXDest;
import com.imop.lj.gameserver.task.dest.LeaderMindLevelADest;
import com.imop.lj.gameserver.task.dest.LeaderMindSkillLevelXDest;
import com.imop.lj.gameserver.task.dest.NoneDestinationDest;
import com.imop.lj.gameserver.task.dest.NumRecordDest;
import com.imop.lj.gameserver.task.dest.SkillEffectEmbedDest;

/**
 * 并非真正的任务目标，而是用于任务表中数据的加载 TODO 根据后期的情况进行修改
 * 
 */
@ExcelRowBinding
public class SpecialDestination {

	/** 目标类型编号 */
//	@ExcelCellBinding(offset = 32)
	@BeanFieldNumber(number = 1)
	private int type;

	/** 参数1 */
//	@ExcelCellBinding(offset = 33)
	@BeanFieldNumber(number = 2)
	private String param1st;

	/** 参数2 */
//	@ExcelCellBinding(offset = 34)
	@BeanFieldNumber(number = 3)
	private String param2nd;

	/** 参数3 */
//	@ExcelCellBinding(offset = 35)
	@BeanFieldNumber(number = 4)
	private String param3rd;

	/** 参数4 */
//	@ExcelCellBinding(offset = 36)
	@BeanFieldNumber(number = 5)
	private String param4th;

	/** 参数5 */
//	@ExcelCellBinding(offset = 37)
	@BeanFieldNumber(number = 6)
	private String param5th;

	private int getStringInt(String param) {
		int ret = 0;
		if (param != null && !param.isEmpty()) {
			ret = Integer.parseInt(param);
		}
		return ret;
	}
	
	/**
	 * 检验所填任务目标是否正确
	 */
	public void check(int questId) {
		DestType destType = DestType.valueOf(type);
		if (destType == null) {
			Loggers.questLogger.error("type=" + type);
		}
		switch (destType) {
		case NULL:
			break;
		case NUM_RECORD:
			checkNumRecordDest(questId, Integer.parseInt(param1st), Integer.parseInt(param2nd), Integer.parseInt(param3rd), getStringInt(param4th), getStringInt(param5th));
			break;
		case LEADER_LEVEL_A:
			LeaderLevelADest.check(Integer.parseInt(param1st));
			break;
		case COLLECTION_ITEM:
			if (Globals.getTemplateCacheService().get(Integer.parseInt(param1st), ItemTemplate.class) == null) {
				throw new TemplateConfigException("任务主表", questId, "收集物品Id不存在 targetId = " + Integer.parseInt(param1st));
			}
			if (Integer.parseInt(param2nd) <= 0) {
				throw new TemplateConfigException("任务主表", questId, "收集物品数量非法！ " + Integer.parseInt(param2nd));
			}
			
			//地图id是否存在
			int mapId = getStringInt(param3rd);
			if (mapId > 0) {
				if (Globals.getTemplateCacheService().get(mapId, MapTemplate.class) == null) {
					throw new TemplateConfigException("任务主表", questId, "遇怪的地图id不存在! " + mapId);	
				}
			}
			//遇怪方案是否存在
			int p1 = getStringInt(param4th);
			if (p1 > 0) {
				if (Globals.getTemplateCacheService().get(p1, MapMeetMonsterTemplate.class) == null) {
					throw new TemplateConfigException("任务主表", questId, "遇怪方案不存在! " + p1);	
				}
			}
			break;
		case LEADER_MIND_LEVEL_A:
			LeaderMindLevelADest.check(Integer.parseInt(param1st));
			break;
		case LEADER_MIND_A_LEVEL_X:
			LeaderMindALevelXDest.check(Integer.parseInt(param1st));
			break;
		case SKILL_EFFECT_EMBED_NUM_X_COLOR_Y_LEVEL_Z:
			SkillEffectEmbedDest.check(Integer.parseInt(param1st), Integer.parseInt(param2nd), Integer.parseInt(param3rd));
			break;
		case EQUIP_NUM_X_COLOR_Y_GRADE_Z:
			EquipDest.check(Integer.parseInt(param1st), Integer.parseInt(param2nd), Integer.parseInt(param3rd));
			break;
		case EQUIPSTAR_NUM_X_STAR_Y:
			EquipStarDest.check(Integer.parseInt(param1st), Integer.parseInt(param2nd));
			break;
		case EQUIP_GEM_NUM_X_LEVEL_Y:
			EquipGemDest.check(Integer.parseInt(param1st), Integer.parseInt(param2nd));
			break;
		case LEADER_MIND_SKILL_LEVEL_X:
			LeaderMindSkillLevelXDest.check(Integer.parseInt(param1st));
			break;
			
		}
	}

	/**
	 * 将该任务转换成相应的任务目标
	 * 
	 * @return
	 */
	public List<IQuestDestination> buildQuestDestination(int questId) {
		List<IQuestDestination> dests = new ArrayList<IQuestDestination>();

		DestType destType = DestType.valueOf(type);
		switch (destType) {
		case NULL:
			dests.add(new NoneDestinationDest(questId, NumRecordType.NONE));
			break;
		case NUM_RECORD:
			dests.add(new NumRecordDest(questId, NumRecordType.indexOf(Integer.parseInt(param1st)), Integer.parseInt(param2nd), Integer.parseInt(param3rd), getStringInt(param4th), getStringInt(param5th)));
			break;
		case LEADER_LEVEL_A:
			dests.add(new LeaderLevelADest(questId, Integer.parseInt(param1st)));
			break;
		case COLLECTION_ITEM:
			dests.add(new ColletionItemDest(questId, Integer.parseInt(param1st), Integer.parseInt(param2nd), getStringInt(param3rd), getStringInt(param4th)));
			break;
		case LEADER_MIND_LEVEL_A:
			dests.add(new LeaderMindLevelADest(questId, Integer.parseInt(param1st)));
			break;
		case LEADER_MIND_A_LEVEL_X:
			dests.add(new LeaderMindALevelXDest(questId, Integer.parseInt(param1st)));
			break;
		case SKILL_EFFECT_EMBED_NUM_X_COLOR_Y_LEVEL_Z:
			dests.add(new SkillEffectEmbedDest(questId, Integer.parseInt(param1st), Integer.parseInt(param2nd), Integer.parseInt(param3rd)));
			break;
		case EQUIP_NUM_X_COLOR_Y_GRADE_Z:
			dests.add(new EquipDest(questId, Integer.parseInt(param1st), Integer.parseInt(param2nd), Integer.parseInt(param3rd)));
			break;
		case EQUIPSTAR_NUM_X_STAR_Y:
			dests.add(new EquipStarDest(questId, Integer.parseInt(param1st), Integer.parseInt(param2nd)));
			break;
		case EQUIP_GEM_NUM_X_LEVEL_Y:
			dests.add(new EquipGemDest(questId, Integer.parseInt(param1st), Integer.parseInt(param2nd)));
			break;
		case LEADER_MIND_SKILL_LEVEL_X:
			dests.add(new LeaderMindSkillLevelXDest(questId, Integer.parseInt(param1st)));
			break;
		}

		return dests;
	}

	/**
	 * 判断某个参数是否为空或数字
	 * 
	 * @param param
	 * @return
	 */
	@SuppressWarnings("unused")
	private boolean isNumberOrEmpty(String param) {
		if ("".equals(param)) {
			return true;
		}

		if (param.matches("\\d+")) {
			return true;
		}

		return false;
	}

	/**
	 * 判断是否为数字
	 * 
	 * @param param
	 * @return
	 */
	@SuppressWarnings("unused")
	private boolean isNumber(String param) {
		if (param == null) {
			return false;
		}

		if (param.matches("\\d+")) {
			return true;
		}
		return false;
	}

	public int getType() {
		return type;
	}

	public void setType(int type) {
		this.type = type;
	}

	public String getParam1st() {
		return param1st;
	}

	public void setParam1st(String param1st) {
		this.param1st = param1st;
	}

	public String getParam2nd() {
		return param2nd;
	}

	public void setParam2nd(String param2nd) {
		this.param2nd = param2nd;
	}

	public String getParam3rd() {
		return param3rd;
	}

	public void setParam3rd(String param3rd) {
		this.param3rd = param3rd;
	}

	public String getParam4th() {
		return param4th;
	}

	public void setParam4th(String param4th) {
		this.param4th = param4th;
	}

	public String getParam5th() {
		return param5th;
	}

	public void setParam5th(String param5th) {
		this.param5th = param5th;
	}
	
	public void checkNumRecordDest(int questId, int numRecordTypeId, int targetId, int num, int mapId, int meetMonsterPlanId) {
		// 检查计数类型是否存在
		NumRecordType type = NumRecordType.indexOf(numRecordTypeId);
		if (type == null) {
			throw new TemplateConfigException("任务主表", questId, "计数类型不存在 numRecordTypeId = " + numRecordTypeId);
		}
		
		// 检查计数是否正确
		if (num <= 0) {
			throw new TemplateConfigException("任务主表", questId, "计数值非法 num = " + num);
		}
		
		// 检查计数目标Id
		if (targetId != 0) {
			switch (type) {
			case MAP_ENEMY:
				//怪物是否存在
				if (Globals.getTemplateCacheService().get(targetId, EnemyTemplate.class) == null) {
					throw new TemplateConfigException("任务主表", questId, "怪物Id不存在 targetId = " + targetId);
				}
				//地图id是否存在
				if (mapId > 0) {
					if (Globals.getTemplateCacheService().get(mapId, MapTemplate.class) == null) {
						throw new TemplateConfigException("任务主表", questId, "遇怪的地图id不存在! " + mapId);	
					}
				}
				//遇怪方案是否存在
				if (meetMonsterPlanId > 0) {
					if (Globals.getTemplateCacheService().get(meetMonsterPlanId, MapMeetMonsterTemplate.class) == null) {
						throw new TemplateConfigException("任务主表", questId, "遇怪方案不存在! " + meetMonsterPlanId);	
					}
				}
				break;
			case MAP_NPC_WIN:
				if (Globals.getTemplateCacheService().get(targetId, NpcTemplate.class) == null) {
					throw new TemplateConfigException("任务主表", questId, "NPCId不存在 targetId = " + targetId);
				}
				break;
			case MAP_COLLECTION:
				throw new TemplateConfigException("任务主表", questId, "收集物品条件已废弃，请改为拥有A道具B个（3）的任务目标！");
//				if (Globals.getTemplateCacheService().get(targetId, ItemTemplate.class) == null) {
//					throw new TemplateConfigException("任务主表", questId, "收集物品Id不存在 targetId = " + targetId);
//				}
//				break;
			case MAP_USE_ITEM:
				if (Globals.getTemplateCacheService().get(targetId, ItemTemplate.class) == null) {
					throw new TemplateConfigException("任务主表", questId, "在地图指定区域使用物品Id不存在 targetId = " + targetId);
				}
				break;
			case ARENA_ATTACK:
				break;
			case WIN_ANY_ENEMY:
				break;
			default:
				break;
			}
		}
	}
	
}
