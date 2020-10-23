package com.imop.lj.gameserver.npc.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * npc模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class NpcTemplateVO extends TemplateObject {

	/** npc类型 */
	@ExcelCellBinding(offset = 1)
	protected int type;

	/** 是否不显示对话面板，0显示，1不显示 */
	@ExcelCellBinding(offset = 2)
	protected int notShowPanelInt;

	/** NPC名字多语言Id */
	@ExcelCellBinding(offset = 3)
	protected long nameLangId;

	/** npc名字 */
	@ExcelCellBinding(offset = 4)
	protected String name;

	/** NPC对话多语言Id */
	@ExcelCellBinding(offset = 5)
	protected long talkLangId;

	/** npc常规对话内容 */
	@ExcelCellBinding(offset = 6)
	protected String talk;

	/** 3D模型 */
	@ExcelCellBinding(offset = 7)
	protected String model3DId;

	/** 2D模型 */
	@ExcelCellBinding(offset = 8)
	protected String model2DId;

	/** 方向 */
	@ExcelCellBinding(offset = 9)
	protected int direction;

	/** 功能Id列表 */
	@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "10;11;12;13;14")
	protected List<Integer> fuctionIdList;

	/** 目标地图Id */
	@ExcelCellBinding(offset = 15)
	protected int targetMapId;

	/** 战斗敌人组Id */
	@ExcelCellBinding(offset = 16)
	protected int enemyGroupId;

	/** 音乐Id */
	@ExcelCellBinding(offset = 17)
	protected String musicId;

	/** 任务限制（多个分号隔开，只有有这个任务的时候，才显示） */
	@ExcelCellBinding(offset = 18)
	protected String questLimit;

	/** NPC循环播放文字列表 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.npc.template.npcGetLoopStrTemplate.class, collectionNumber = "19,20;21,22;23,24")
	protected List<com.imop.lj.gameserver.npc.template.npcGetLoopStrTemplate> loopStrList;


	public int getType() {
		return this.type;
	}

	public void setType(int type) {
		this.type = type;
	}
	
	public int getNotShowPanelInt() {
		return this.notShowPanelInt;
	}

	public void setNotShowPanelInt(int notShowPanelInt) {
		this.notShowPanelInt = notShowPanelInt;
	}
	
	public long getNameLangId() {
		return this.nameLangId;
	}

	public void setNameLangId(long nameLangId) {
		this.nameLangId = nameLangId;
	}
	
	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public long getTalkLangId() {
		return this.talkLangId;
	}

	public void setTalkLangId(long talkLangId) {
		this.talkLangId = talkLangId;
	}
	
	public String getTalk() {
		return this.talk;
	}

	public void setTalk(String talk) {
		if (talk != null) {
			this.talk = talk.trim();
		}else{
			this.talk = talk;
		}
	}
	
	public String getModel3DId() {
		return this.model3DId;
	}

	public void setModel3DId(String model3DId) {
		if (model3DId != null) {
			this.model3DId = model3DId.trim();
		}else{
			this.model3DId = model3DId;
		}
	}
	
	public String getModel2DId() {
		return this.model2DId;
	}

	public void setModel2DId(String model2DId) {
		if (model2DId != null) {
			this.model2DId = model2DId.trim();
		}else{
			this.model2DId = model2DId;
		}
	}
	
	public int getDirection() {
		return this.direction;
	}

	public void setDirection(int direction) {
		this.direction = direction;
	}
	
	public List<Integer> getFuctionIdList() {
		return this.fuctionIdList;
	}

	public void setFuctionIdList(List<Integer> fuctionIdList) {
		if (fuctionIdList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[功能Id列表]fuctionIdList不可以为空");
		}	
		this.fuctionIdList = fuctionIdList;
	}
	
	public int getTargetMapId() {
		return this.targetMapId;
	}

	public void setTargetMapId(int targetMapId) {
		this.targetMapId = targetMapId;
	}
	
	public int getEnemyGroupId() {
		return this.enemyGroupId;
	}

	public void setEnemyGroupId(int enemyGroupId) {
		this.enemyGroupId = enemyGroupId;
	}
	
	public String getMusicId() {
		return this.musicId;
	}

	public void setMusicId(String musicId) {
		if (musicId != null) {
			this.musicId = musicId.trim();
		}else{
			this.musicId = musicId;
		}
	}
	
	public String getQuestLimit() {
		return this.questLimit;
	}

	public void setQuestLimit(String questLimit) {
		if (questLimit != null) {
			this.questLimit = questLimit.trim();
		}else{
			this.questLimit = questLimit;
		}
	}
	
	public List<com.imop.lj.gameserver.npc.template.npcGetLoopStrTemplate> getLoopStrList() {
		return this.loopStrList;
	}

	public void setLoopStrList(List<com.imop.lj.gameserver.npc.template.npcGetLoopStrTemplate> loopStrList) {
		if (loopStrList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					20, "[NPC循环播放文字列表]loopStrList不可以为空");
		}	
		this.loopStrList = loopStrList;
	}
	

	@Override
	public String toString() {
		return "NpcTemplateVO[type=" + type + ",notShowPanelInt=" + notShowPanelInt + ",nameLangId=" + nameLangId + ",name=" + name + ",talkLangId=" + talkLangId + ",talk=" + talk + ",model3DId=" + model3DId + ",model2DId=" + model2DId + ",direction=" + direction + ",fuctionIdList=" + fuctionIdList + ",targetMapId=" + targetMapId + ",enemyGroupId=" + enemyGroupId + ",musicId=" + musicId + ",questLimit=" + questLimit + ",loopStrList=" + loopStrList + ",]";

	}
}