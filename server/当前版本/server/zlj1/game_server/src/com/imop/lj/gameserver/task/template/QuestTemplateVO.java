package com.imop.lj.gameserver.task.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;
import java.util.List;

/**
 * 任务模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class QuestTemplateVO extends TemplateObject {

	/**  标题多语言 Id */
	@ExcelCellBinding(offset = 1)
	protected long titleLangId;

	/** 标题 */
	@ExcelCellBinding(offset = 2)
	protected String title;

	/** 任务主类型（区分主线和日常） */
	@ExcelCellBinding(offset = 3)
	protected int questType;

	/** 是否是重复任务 */
	@ExcelCellBinding(offset = 4)
	protected boolean repeat;

	/** 每日完成的次数 */
	@ExcelCellBinding(offset = 5)
	protected int dailyTimes;

	/** 必须完成的前置任务ID */
	@ExcelCellBinding(offset = 6)
	protected int preQuestId;

	/** 等级限制 */
	@ExcelCellBinding(offset = 7)
	protected int acceptMinLevel;

	/** 要求组队最少人数，0表示不需要组队 */
	@ExcelCellBinding(offset = 8)
	protected int minTeamMemberNum;

	/** 接任务的特殊任务条件 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.task.template.SpecialCondition.class, collectionNumber = "9,10,11;12,13,14")
	protected List<com.imop.lj.gameserver.task.template.SpecialCondition> specialCondition;

	/** 奖励ID */
	@ExcelCellBinding(offset = 15)
	protected int rewardId;

	/** 显示奖励Id */
	@ExcelCellBinding(offset = 16)
	protected int showRewardId;

	/** 任务描述 */
	@ExcelCellBinding(offset = 17)
	protected String desc;

	/**  任务完成npc说话内容多语言 Id */
	@ExcelCellBinding(offset = 18)
	protected long finishNpcTalkDescLangId;

	/** 任务完成npc说话内容 */
	@ExcelCellBinding(offset = 19)
	protected String finishNpcTalkDesc;

	/**  开启的条件描述多语言 Id */
	@ExcelCellBinding(offset = 20)
	protected long requireDescLangId;

	/** 开启的条件描述 */
	@ExcelCellBinding(offset = 21)
	protected String requireDesc;

	/**  任务完成信息多语言 Id */
	@ExcelCellBinding(offset = 22)
	protected long finishDescLangId;

	/** 任务完成信息 */
	@ExcelCellBinding(offset = 23)
	protected String finishDesc;

	/** 接取任务NPC地图Id */
	@ExcelCellBinding(offset = 24)
	protected int startNpcMapId;

	/** 接取任务NPC */
	@ExcelCellBinding(offset = 25)
	protected int startNpc;

	/** 交付任务NPC地图ID */
	@ExcelCellBinding(offset = 26)
	protected int endNpcMapId;

	/** 交付任务NPC */
	@ExcelCellBinding(offset = 27)
	protected int endNpc;

	/** 是否自动接取 */
	@ExcelCellBinding(offset = 28)
	protected int autoAccept;

	/** 是否自动完成 */
	@ExcelCellBinding(offset = 29)
	protected int autoFinish;

	/** 剧情id */
	@ExcelCellBinding(offset = 30)
	protected int storyId;

	/** 寻路字符串 */
	@ExcelCellBinding(offset = 31)
	protected String pathStr;

	/** 特殊任务目标 */
	@ExcelRowBinding
	protected com.imop.lj.gameserver.task.template.SpecialDestination specialDestination;

	/** 条件奖励ID */
	@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "38;39;40;41;42;43;44;45")
	protected List<Integer> rewardIdOnCondition;

	/** 任务怪IdList */
	@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "46;47;48;49;50")
	protected List<Integer> enemyArmyIdList;

	/** 任务物品掉落奖励 */
	@ExcelCellBinding(offset = 51)
	protected int taskDropRewardId;


	public long getTitleLangId() {
		return this.titleLangId;
	}

	public void setTitleLangId(long titleLangId) {
		if (titleLangId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[ 标题多语言 Id]titleLangId的值不得小于0");
		}
		this.titleLangId = titleLangId;
	}
	
	public String getTitle() {
		return this.title;
	}

	public void setTitle(String title) {
		if (StringUtils.isEmpty(title)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[标题]title不可以为空");
		}
		if (title != null) {
			this.title = title.trim();
		}else{
			this.title = title;
		}
	}
	
	public int getQuestType() {
		return this.questType;
	}

	public void setQuestType(int questType) {
		if (questType == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[任务主类型（区分主线和日常）]questType不可以为0");
		}
		if (questType < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[任务主类型（区分主线和日常）]questType的值不得小于1");
		}
		this.questType = questType;
	}
	
	public boolean isRepeat() {
		return this.repeat;
	}

	public void setRepeat(boolean repeat) {
		this.repeat = repeat;
	}
	
	public int getDailyTimes() {
		return this.dailyTimes;
	}

	public void setDailyTimes(int dailyTimes) {
		this.dailyTimes = dailyTimes;
	}
	
	public int getPreQuestId() {
		return this.preQuestId;
	}

	public void setPreQuestId(int preQuestId) {
		this.preQuestId = preQuestId;
	}
	
	public int getAcceptMinLevel() {
		return this.acceptMinLevel;
	}

	public void setAcceptMinLevel(int acceptMinLevel) {
		if (acceptMinLevel == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[等级限制]acceptMinLevel不可以为0");
		}
		if (acceptMinLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[等级限制]acceptMinLevel的值不得小于1");
		}
		this.acceptMinLevel = acceptMinLevel;
	}
	
	public int getMinTeamMemberNum() {
		return this.minTeamMemberNum;
	}

	public void setMinTeamMemberNum(int minTeamMemberNum) {
		this.minTeamMemberNum = minTeamMemberNum;
	}
	
	public List<com.imop.lj.gameserver.task.template.SpecialCondition> getSpecialCondition() {
		return this.specialCondition;
	}

	public void setSpecialCondition(List<com.imop.lj.gameserver.task.template.SpecialCondition> specialCondition) {
		if (specialCondition == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[接任务的特殊任务条件]specialCondition不可以为空");
		}	
		this.specialCondition = specialCondition;
	}
	
	public int getRewardId() {
		return this.rewardId;
	}

	public void setRewardId(int rewardId) {
		if (rewardId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					16, "[奖励ID]rewardId不可以为0");
		}
		this.rewardId = rewardId;
	}
	
	public int getShowRewardId() {
		return this.showRewardId;
	}

	public void setShowRewardId(int showRewardId) {
		if (showRewardId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					17, "[显示奖励Id]showRewardId的值不得小于0");
		}
		this.showRewardId = showRewardId;
	}
	
	public String getDesc() {
		return this.desc;
	}

	public void setDesc(String desc) {
		if (desc != null) {
			this.desc = desc.trim();
		}else{
			this.desc = desc;
		}
	}
	
	public long getFinishNpcTalkDescLangId() {
		return this.finishNpcTalkDescLangId;
	}

	public void setFinishNpcTalkDescLangId(long finishNpcTalkDescLangId) {
		if (finishNpcTalkDescLangId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					19, "[ 任务完成npc说话内容多语言 Id]finishNpcTalkDescLangId的值不得小于0");
		}
		this.finishNpcTalkDescLangId = finishNpcTalkDescLangId;
	}
	
	public String getFinishNpcTalkDesc() {
		return this.finishNpcTalkDesc;
	}

	public void setFinishNpcTalkDesc(String finishNpcTalkDesc) {
		if (finishNpcTalkDesc != null) {
			this.finishNpcTalkDesc = finishNpcTalkDesc.trim();
		}else{
			this.finishNpcTalkDesc = finishNpcTalkDesc;
		}
	}
	
	public long getRequireDescLangId() {
		return this.requireDescLangId;
	}

	public void setRequireDescLangId(long requireDescLangId) {
		if (requireDescLangId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					21, "[ 开启的条件描述多语言 Id]requireDescLangId的值不得小于0");
		}
		this.requireDescLangId = requireDescLangId;
	}
	
	public String getRequireDesc() {
		return this.requireDesc;
	}

	public void setRequireDesc(String requireDesc) {
		if (requireDesc != null) {
			this.requireDesc = requireDesc.trim();
		}else{
			this.requireDesc = requireDesc;
		}
	}
	
	public long getFinishDescLangId() {
		return this.finishDescLangId;
	}

	public void setFinishDescLangId(long finishDescLangId) {
		if (finishDescLangId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					23, "[ 任务完成信息多语言 Id]finishDescLangId的值不得小于0");
		}
		this.finishDescLangId = finishDescLangId;
	}
	
	public String getFinishDesc() {
		return this.finishDesc;
	}

	public void setFinishDesc(String finishDesc) {
		if (finishDesc != null) {
			this.finishDesc = finishDesc.trim();
		}else{
			this.finishDesc = finishDesc;
		}
	}
	
	public int getStartNpcMapId() {
		return this.startNpcMapId;
	}

	public void setStartNpcMapId(int startNpcMapId) {
		if (startNpcMapId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					25, "[接取任务NPC地图Id]startNpcMapId的值不得小于0");
		}
		this.startNpcMapId = startNpcMapId;
	}
	
	public int getStartNpc() {
		return this.startNpc;
	}

	public void setStartNpc(int startNpc) {
		if (startNpc < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					26, "[接取任务NPC]startNpc的值不得小于0");
		}
		this.startNpc = startNpc;
	}
	
	public int getEndNpcMapId() {
		return this.endNpcMapId;
	}

	public void setEndNpcMapId(int endNpcMapId) {
		if (endNpcMapId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					27, "[交付任务NPC地图ID]endNpcMapId的值不得小于0");
		}
		this.endNpcMapId = endNpcMapId;
	}
	
	public int getEndNpc() {
		return this.endNpc;
	}

	public void setEndNpc(int endNpc) {
		if (endNpc < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					28, "[交付任务NPC]endNpc的值不得小于0");
		}
		this.endNpc = endNpc;
	}
	
	public int getAutoAccept() {
		return this.autoAccept;
	}

	public void setAutoAccept(int autoAccept) {
		if (autoAccept > 1 || autoAccept < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					29, "[是否自动接取]autoAccept的值不合法，应为0至1之间");
		}
		this.autoAccept = autoAccept;
	}
	
	public int getAutoFinish() {
		return this.autoFinish;
	}

	public void setAutoFinish(int autoFinish) {
		if (autoFinish > 1 || autoFinish < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					30, "[是否自动完成]autoFinish的值不合法，应为0至1之间");
		}
		this.autoFinish = autoFinish;
	}
	
	public int getStoryId() {
		return this.storyId;
	}

	public void setStoryId(int storyId) {
		if (storyId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					31, "[剧情id]storyId的值不得小于0");
		}
		this.storyId = storyId;
	}
	
	public String getPathStr() {
		return this.pathStr;
	}

	public void setPathStr(String pathStr) {
		if (pathStr != null) {
			this.pathStr = pathStr.trim();
		}else{
			this.pathStr = pathStr;
		}
	}
	
	public com.imop.lj.gameserver.task.template.SpecialDestination getSpecialDestination() {
		return this.specialDestination;
	}

	public void setSpecialDestination(com.imop.lj.gameserver.task.template.SpecialDestination specialDestination) {
		if (specialDestination == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					33, "[特殊任务目标]specialDestination不可以为空");
		}	
		this.specialDestination = specialDestination;
	}
	
	public List<Integer> getRewardIdOnCondition() {
		return this.rewardIdOnCondition;
	}

	public void setRewardIdOnCondition(List<Integer> rewardIdOnCondition) {
		if (rewardIdOnCondition == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					39, "[条件奖励ID]rewardIdOnCondition不可以为空");
		}	
		this.rewardIdOnCondition = rewardIdOnCondition;
	}
	
	public List<Integer> getEnemyArmyIdList() {
		return this.enemyArmyIdList;
	}

	public void setEnemyArmyIdList(List<Integer> enemyArmyIdList) {
		if (enemyArmyIdList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					47, "[任务怪IdList]enemyArmyIdList不可以为空");
		}	
		this.enemyArmyIdList = enemyArmyIdList;
	}
	
	public int getTaskDropRewardId() {
		return this.taskDropRewardId;
	}

	public void setTaskDropRewardId(int taskDropRewardId) {
		if (taskDropRewardId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					52, "[任务物品掉落奖励]taskDropRewardId的值不得小于0");
		}
		this.taskDropRewardId = taskDropRewardId;
	}
	

	@Override
	public String toString() {
		return "QuestTemplateVO[titleLangId=" + titleLangId + ",title=" + title + ",questType=" + questType + ",repeat=" + repeat + ",dailyTimes=" + dailyTimes + ",preQuestId=" + preQuestId + ",acceptMinLevel=" + acceptMinLevel + ",minTeamMemberNum=" + minTeamMemberNum + ",specialCondition=" + specialCondition + ",rewardId=" + rewardId + ",showRewardId=" + showRewardId + ",desc=" + desc + ",finishNpcTalkDescLangId=" + finishNpcTalkDescLangId + ",finishNpcTalkDesc=" + finishNpcTalkDesc + ",requireDescLangId=" + requireDescLangId + ",requireDesc=" + requireDesc + ",finishDescLangId=" + finishDescLangId + ",finishDesc=" + finishDesc + ",startNpcMapId=" + startNpcMapId + ",startNpc=" + startNpc + ",endNpcMapId=" + endNpcMapId + ",endNpc=" + endNpc + ",autoAccept=" + autoAccept + ",autoFinish=" + autoFinish + ",storyId=" + storyId + ",pathStr=" + pathStr + ",specialDestination=" + specialDestination + ",rewardIdOnCondition=" + rewardIdOnCondition + ",enemyArmyIdList=" + enemyArmyIdList + ",taskDropRewardId=" + taskDropRewardId + ",]";

	}
}