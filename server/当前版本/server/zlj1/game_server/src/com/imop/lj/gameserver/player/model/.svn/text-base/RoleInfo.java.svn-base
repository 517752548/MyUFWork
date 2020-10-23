package com.imop.lj.gameserver.player.model;

import com.imop.lj.common.constants.RoleConstants;
import com.imop.lj.db.model.HumanEntity;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.map.template.MapTemplate;
import com.imop.lj.gameserver.pet.template.PetTemplate;
import com.imop.lj.gameserver.player.PlayerSelection;

public class RoleInfo {

	/** 账户id */
	private String passportId;
	/** 角色ID */
	private long roleUUID;
	/** 名字 */
	private String name;
	/** 是否为首次登陆 */
	private int firstLogin;
	/** 角色等级 */
	private int level;
	/** 主将模板id */
	private int petTemplateId;
	/** 主将图片 */
	private int petPhotoId;
	/** 主将资质 */
	private int petRarity;
	
	/** 选择 */
	private PlayerSelection selection;
	
	/** 角色所属服务器Id */
	private int serverId;

	public RoleInfo() {

	}

	public RoleInfo(long roleUUID, String name) {
		super();
		this.roleUUID = roleUUID;
		this.name = name;

	}

	public String getPassportId() {
		return passportId;
	}

	public void setPassportId(String passportId) {
		this.passportId = passportId;
	}

	public long getRoleUUID() {
		return roleUUID;
	}

	public void setRoleUUID(long roleUUID) {
		this.roleUUID = roleUUID;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public HumanEntity toEntity() {
		HumanEntity entity = new HumanEntity();
		entity.setPassportId(this.passportId);
		entity.setId(this.roleUUID);
		entity.setName(this.name);
		entity.setLevel(RoleConstants.HUMAN_INIT_LEVEL_NUM);
		// 增加玩家所属服务器字段
		entity.setServerId(this.serverId);
		
		//玩家初始位置
		int mapId = Globals.getGameConstants().getInitMapId();
		entity.setMapId(mapId);
		entity.setBackMapId(mapId);
		
		MapTemplate mapTpl = Globals.getTemplateCacheService().get(mapId, MapTemplate.class);
		int initX = mapTpl.getInitX();
		int initY = mapTpl.getInitY();
		entity.setX(initX);
		entity.setY(initY);
		
		//设置自动战斗为普通攻击
		entity.setAutoFightAction(BattleDef.NORMAL_ATTACK_SKILL_ID);
		entity.setPetAutoFightAction(BattleDef.NORMAL_ATTACK_SKILL_ID);
		
		//设置初始心法
		PetTemplate petTpl = Globals.getTemplateCacheService().get(this.selection.getPetTemplateId(), PetTemplate.class);
		entity.setMainSkillType(petTpl.getJobType().getDefaultMainSkillType().getIndex());
		//设置初始心法等级
		entity.setMainSkillLevel(RoleConstants.HUMAN_INIT_LEVEL_NUM);
		//设置采矿等级
		entity.setMineLevel(RoleConstants.HUMAN_INIT_LEVEL_NUM);
		//设置最后一次系统给双倍经验点时间
		entity.setLastGiveDoublePointTime(Globals.getTimeService().now());
		return entity;
	}

	public PlayerSelection getSelection() {
		return selection;
	}

	public void setSelection(PlayerSelection selection) {
		this.selection = selection;
	}

	public int getFirstLogin() {
		return firstLogin;
	}

	public void setFirstLogin(int firstLogin) {
		this.firstLogin = firstLogin;
	}

	public int getLevel() {
		return level;
	}

	public void setLevel(int level) {
		this.level = level;
	}

	public int getPetTemplateId() {
		return petTemplateId;
	}

	public void setPetTemplateId(int petTemplateId) {
		this.petTemplateId = petTemplateId;
	}

	public int getPetPhotoId() {
		return petPhotoId;
	}

	public void setPetPhotoId(int petPhotoId) {
		this.petPhotoId = petPhotoId;
	}

	public int getPetRarity() {
		return petRarity;
	}

	public void setPetRarity(int petRarity) {
		this.petRarity = petRarity;
	}

	public int getServerId() {
		return serverId;
	}

	public void setServerId(int serverId) {
		this.serverId = serverId;
	}

}
