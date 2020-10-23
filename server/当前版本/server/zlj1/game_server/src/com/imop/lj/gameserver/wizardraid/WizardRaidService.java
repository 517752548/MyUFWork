package com.imop.lj.gameserver.wizardraid;

import java.awt.Point;
import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;

import com.google.common.collect.Maps;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.NpcInfo;
import com.imop.lj.core.util.RandomUtil;
import com.imop.lj.gameserver.battle.BattleProcess;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.map.PetIslandService;
import com.imop.lj.gameserver.map.model.AbstractGameMap;
import com.imop.lj.gameserver.npc.template.NpcTemplate;
import com.imop.lj.gameserver.offlinereward.OfflineRewardDef.OfflineRewardType;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef;
import com.imop.lj.gameserver.task.TaskDef;
import com.imop.lj.gameserver.team.TeamBattleProcess;
import com.imop.lj.gameserver.team.TeamDef.TeamStatus;
import com.imop.lj.gameserver.team.model.Team;
import com.imop.lj.gameserver.team.model.TeamMember;
import com.imop.lj.gameserver.vip.VipDef.VipFuncTypeEnum;
import com.imop.lj.gameserver.wizardraid.WizardRaidDef.WRMonsterType;
import com.imop.lj.gameserver.wizardraid.WizardRaidDef.WizardRaidType;
import com.imop.lj.gameserver.wizardraid.model.WizardRaidEnterTmp;
import com.imop.lj.gameserver.wizardraid.model.WizardRaidMonster;
import com.imop.lj.gameserver.wizardraid.model.WizardRaidRecordBase;
import com.imop.lj.gameserver.wizardraid.model.WizardRaidRecordSingle;
import com.imop.lj.gameserver.wizardraid.model.WizardRaidRecordTeam;
import com.imop.lj.gameserver.wizardraid.msg.GCWizardraidAskEnterTeam;
import com.imop.lj.gameserver.wizardraid.msg.GCWizardraidEnterSingle;
import com.imop.lj.gameserver.wizardraid.msg.GCWizardraidEnterTeam;
import com.imop.lj.gameserver.wizardraid.msg.GCWizardraidInfo;
import com.imop.lj.gameserver.wizardraid.msg.GCWizardraidLeftTimes;
import com.imop.lj.gameserver.wizardraid.template.WizardRaidMonsterTemplate;
import com.imop.lj.gameserver.wizardraid.template.WizardRaidTemplate;

public class WizardRaidService {
	/** 每次处理1/mod的数据量 */
	protected static int MOD = 1;
	protected static int CountMod = 0;
	
	/** 该活动是否开启的全局状态位 */
	protected static boolean OPEN = true;
	
	/** 能否进入的全局状态位 */
	protected static boolean ENTER = true;
	
	/** 副本进度数据，单人 */
	protected Map<Long, WizardRaidRecordSingle> singleMap = Maps.newHashMap();
	/** 副本进度数据，组队 */
	protected Map<Integer, WizardRaidRecordTeam> teamMap = Maps.newHashMap();
	
	/** 请求进入副本的临时数据 */
	protected Map<Long, WizardRaidEnterTmp> enterTmpMap = Maps.newHashMap();
	
	public WizardRaidService() {
		
	}
	
	public boolean isPlayerInSingle(long roleId) {
		return this.singleMap.containsKey(roleId);
	}
	
	protected void addSingleData(WizardRaidRecordSingle data) {
		singleMap.put(data.getRoleId(), data);
	}
	
	protected WizardRaidRecordSingle getSingleData(long roleId) {
		return singleMap.get(roleId);
	}
	
	protected void removeSingleData(long roleId) {
		this.singleMap.remove(roleId);
	}
	
	protected WizardRaidRecordTeam getTeamData(int teamId) {
		return teamMap.get(teamId);
	}
	
	protected void addTeamData(WizardRaidRecordTeam data) {
		teamMap.put(data.getTeamId(), data);
	}
	
	protected void removeTeamData(int teamId) {
		teamMap.remove(teamId);
	}
	
	protected boolean isTeamInRaid(int teamId) {
		return this.teamMap.containsKey(teamId);
	}
	
	protected void removeData(WizardRaidRecordBase data) {
		if (data instanceof WizardRaidRecordTeam) {
			removeTeamData(((WizardRaidRecordTeam)data).getTeamId());
		} else if (data instanceof WizardRaidRecordSingle) {
			removeSingleData(((WizardRaidRecordSingle)data).getRoleId());
		}
			
	}
	
	public int getWizardRaidFreeTimes(Human human) {
		return Globals.getVipService().getAddCountByVip(human, VipFuncTypeEnum.WIZARDRAID_ENTER_TIMES) +
				Globals.getGameConstants().getWizardRaidFreeTimes();
	}
	
	/**
	 * 玩家是否还有进入副本的次数
	 * @param human
	 * @return
	 */
	public boolean hasEnterTimes(Human human) {
		BehaviorTypeEnum bt = BehaviorTypeEnum.WIZARDRAID_ENTER_TIMES;
		int enterTimes = human.getBehaviorManager().getCount(bt);
		//免费次数是否还有
		if (enterTimes < getWizardRaidFreeTimes(human)) {
			return true;
		}
		
		//付费次数是否还有，且有相应道具
		if (!human.getBehaviorManager().canDo(bt)) {
			return false;
		}
		//使用付费次数，需要查看道具是否足够
		if (!human.getInventory().hasItemByTmplId(
				Globals.getGameConstants().getWizardRaidEnterItemId(), 
				Globals.getGameConstants().getWizardRaidEnterItemNum())) {
			return false;
		}
		return true;
	}
	
	public boolean canEnterRaidSingle(Human human, int raidId) {
		if (!ENTER) {
			return false;
		}
		//活动是否开启中
		if (!isOpening()) {
			return false;
		}
		
		long roleId = human.getCharId();
		//玩家组队中，不能进单人
		if (Globals.getTeamService().isInTeam(roleId)) {
			return false;
		}
		
		WizardRaidTemplate tpl = Globals.getTemplateCacheService().get(raidId, WizardRaidTemplate.class);
		//副本类型是否正确
		if (tpl.getWizardRaidType() != WizardRaidType.SINGLE) {
			return false;
		}
		
		//玩家等级是否满足
		int level = human.getLevel();
		if (!(level>= tpl.getLevelMin() && level <= tpl.getLevelMax())) {
			return false;
		}
		
		
		//玩家当前已经在单人副本中，可以不扣次数进
		if (isPlayerInSingle(roleId)) {
			return true;
		}
		//是否有进入次数
		if (!hasEnterTimes(human)) {
			return false;
		}
		return true;
	}
	
	public void sendWizardRaidLeftTimes(Human human) {
		if (!isOpening()) {
			return;
		}
		
		int leftFreeTimes = getWizardRaidFreeTimes(human) - human.getBehaviorManager().getCount(BehaviorTypeEnum.WIZARDRAID_ENTER_TIMES);
		if (leftFreeTimes < 0) {
			leftFreeTimes = 0;
		}
		human.sendMessage(new GCWizardraidLeftTimes(leftFreeTimes));
	}
	
	public void enterRaidSingle(Human human, int raidId) {
		//玩家能否进入副本
		if (!canEnterRaidSingle(human, raidId)) {
			if (!hasEnterTimes(human)) {
				human.sendErrorMessage(LangConstants.WIZARD_RAID_NOT_ENOUGH_TIMES1);
			}
			return;
		}
		
		int raidMapId = Globals.getTemplateCacheService().getMapTemplateCache().getWizardRaidMapId();
		long roleId = human.getCharId();
		//玩家当前有副本进度
		if (isPlayerInSingle(roleId)) {
			//取地图，进入地图
			Globals.getMapService().enterMap(human, raidMapId);
			return;
		}

		boolean costItemFlag = isCostItem(human);
		//行为次数记录
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.WIZARDRAID_ENTER_TIMES);
		//任务监听
		human.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.ENTER_WIZARDRAID, 0, 1);
		//扣次数或道具
		//免费次数如果扣除成功，则不再扣道具
		if (costItemFlag) {
			//扣道具
			Collection<Item> itemRet = human.getInventory().removeItem(Globals.getGameConstants().getWizardRaidEnterItemId(), 
					Globals.getGameConstants().getWizardRaidEnterItemNum(), ItemLogReason.WIZARD_RAID_SINGLE_ENTER_COST, 
					ItemLogReason.WIZARD_RAID_SINGLE_ENTER_COST.getReasonText());
			if (itemRet == null || itemRet.isEmpty()) {
				//道具不足，不能进入
				return;
			}
		}
		
		//玩家新进入副本
		WizardRaidRecordSingle data = createSingleData(human, raidId);
		
		//加入map
		addSingleData(data);
		
		//进入地图
		Globals.getMapService().enterMap(human, raidMapId);
		
		//发消息
		human.sendMessage(new GCWizardraidEnterSingle(raidId));
		
		//更新剩余免费次数
		sendWizardRaidLeftTimes(human);
		
		//绿野仙踪副本状态数据
		sendWizardRaidInfo(human);
	}
	
	protected boolean isCostItem(Human human) {
		return human.getBehaviorManager().getCount(BehaviorTypeEnum.WIZARDRAID_ENTER_TIMES) 
				>= getWizardRaidFreeTimes(human);
	}
	
	protected WizardRaidRecordSingle createSingleData(Human human, int raidId) {
		WizardRaidRecordSingle data = new WizardRaidRecordSingle();
		data.setRoleId(human.getCharId());
		data.setType(WizardRaidType.SINGLE);
		data.setRaidId(raidId);
		long now = Globals.getTimeService().now();
		data.setEnterTime(now);
		data.setLastStartTime(now);
		return data;
	}
	
	public void sendWizardRaidInfo(Human human) {
		long roleId = human.getCharId();
		WizardRaidRecordBase data = null;
		if (getSingleData(roleId) != null) {
			data = getSingleData(roleId);
		} else {
			Team team = Globals.getTeamService().getHumanTeam(roleId);
			if (team != null) {
				if (getTeamData(team.getId()) != null) {
					data = getTeamData(team.getId());
				}
			}
		}
		if (data == null) {
			return;
		}
		
		human.sendMessage(buildGCWizardraidInfo(data));
	}
	
	public void sendWizardRaidInfo(WizardRaidRecordBase data) {
		if (data instanceof WizardRaidRecordSingle) {
			long roleId  = ((WizardRaidRecordSingle) data).getRoleId();
			Player player = Globals.getOnlinePlayerService().getPlayer(roleId);
			if (player != null && player.getHuman() != null) {
				player.sendMessage(buildGCWizardraidInfo(data));
			}
		} else if (data instanceof WizardRaidRecordTeam) {
			int teamId = ((WizardRaidRecordTeam) data).getTeamId();
			Team team = Globals.getTeamService().getTeam(teamId);
			if (team != null) {
				team.noticeTeamMember(buildGCWizardraidInfo(data), true, true);
			}
		}
	}
	
	public GCWizardraidInfo buildGCWizardraidInfo(WizardRaidRecordBase data) {
		long leftTime = Globals.getGameConstants().getWizardRaidMaxTime() - data.getPassTimeUntilNow();
		GCWizardraidInfo msg = new GCWizardraidInfo(data.getCurWave(), data.getWinMonsterNum(), leftTime);
		return msg;
	}
	
	public void checkSingleRaidHeartbeat(Human human) {
		//活动是否开启中
		if (!isOpening()) {
			return;
		}
		
		long roleId = human.getUUID();
		//是否正在副本中
		if (!isPlayerInSingle(roleId)) {
			return;
		}
		
		//获取玩家副本数据
		WizardRaidRecordSingle data = getSingleData(roleId);
		
		//检查波数
		checkWave(data);

		//检测副本超时时间，如果需要结束则结束
		boolean endFlag = checkEndRaid(data);
		if (!endFlag) {
			//刷出新怪物
			refreshNewMonster(data);
			
			//旧的怪检查是否该变南瓜了，如果有正在进行的战斗，需要变南瓜了，则强制结束战斗
			refreshOldMonster(data);
		}
	}
	
	protected void checkWave(WizardRaidRecordBase data) {
		long passTime = data.getPassTimeUntilNow();
		int curWave = data.getCurWave();
		//是否已经最大波数
		if (curWave >= Globals.getTemplateCacheService().getWizardRaidTemplateCache().getMaxWave()) {
			return;
		}
		
		int wave = 0;
		for (Entry<Integer, Integer> entry : Globals.getTemplateCacheService().getWizardRaidTemplateCache().getWaveMap().entrySet()) {
			if (passTime > entry.getKey()) {
				wave = entry.getValue();
			} else {
				break;
			}
		}
		
		if (curWave != wave) {
			data.setCurWave(wave);
			//更新副本信息
			sendWizardRaidInfo(data);
		}
	}
	
	protected boolean checkEndRaid(WizardRaidRecordBase data) {
		//在副本的超时检测
		if (data.getPassTimeUntilNow() < Globals.getGameConstants().getWizardRaidMaxTime()) {
			return false;
		}
		
		//退出副本
		onRaidEnd(data);
		//通知玩家，副本结束
		data.onEndRaidNotice();
		return true;
	}
	
	public void onEndRaidNotice(WizardRaidRecordSingle data) {
		if (Globals.getTeamService().isPlayerOnline(data.getRoleId())) {
			Player player = Globals.getOnlinePlayerService().getPlayer(data.getRoleId());
			player.sendErrorMessage(LangConstants.WIZARD_RAID_FAIL_FINISH);
		}
	}
	
	public void onEndRaidNotice(WizardRaidRecordTeam data) {
		Team team = Globals.getTeamService().getTeam(data.getTeamId());
		if (team != null) {
			team.noticeTeamMemberErrorMsg(LangConstants.WIZARD_RAID_FAIL_FINISH);
		}
	}
	
	public void noticeMonster(WizardRaidRecordSingle data, int npcId, WRMonsterType type) {
		if (Globals.getTeamService().isPlayerOnline(data.getRoleId())) {
			Player player = Globals.getOnlinePlayerService().getPlayer(data.getRoleId());
			NpcTemplate npcTpl = Globals.getTemplateCacheService().get(npcId, NpcTemplate.class);
			player.sendSystemMessage(type.getLangId(), npcTpl.getName());
		}
	}
	
	public void noticeMonster(WizardRaidRecordTeam data, int npcId, WRMonsterType type) {
		Team team = Globals.getTeamService().getTeam(data.getTeamId());
		if (team == null) {
			return;
		}
		NpcTemplate npcTpl = Globals.getTemplateCacheService().get(npcId, NpcTemplate.class);
		for (TeamMember tm : team.getMemberMap().values()) {
			long roleId = tm.getRoleId();
			Player player = Globals.getOnlinePlayerService().getPlayer(roleId);
			if (player != null && player.getHuman() != null) {
				player.sendSystemMessage(type.getLangId(), npcTpl.getName());
			}
		}
	}
	
	protected void refreshNewMonster(WizardRaidRecordBase data) {
		//根据过去的时间，刷出新怪
		int curMonsterNum = data.getGenNormalMonsterNum();
		//已经过去的时间
		long passTime = data.getPassTimeUntilNow();
		
		List<WizardRaidMonsterTemplate> tplList = Globals.getTemplateCacheService().getWizardRaidTemplateCache().getMonsterTplList(data.getRaidId(), data.getType());
		int count = 0;
		for (WizardRaidMonsterTemplate tpl : tplList) {
			if (passTime >= tpl.getStartTime()) {
				count++;
			} else {
				break;
			}
		}
		//当前已有这么多只怪物，不用再刷
		if (count <= curMonsterNum) {
			return;
		}
		
		//刷出需要出现的怪物
		for (int i = curMonsterNum; i < count; i++) {
			WizardRaidMonsterTemplate tpl = tplList.get(i);
			WizardRaidMonster monster = genMonsterInMap(data, tpl.getMonsterNpcId(), WRMonsterType.NORMAL, null);
			monster.setStartPassTime(passTime);
		}
	}
	
	protected WizardRaidMonster genMonsterInMap(WizardRaidRecordBase data, int npcId, WRMonsterType type, Point npcPoint) {
		if (npcPoint == null) {
			//随机地图中的一个点
			npcPoint = randNpcPos(data);
		}
		//构建npc
		NpcInfo npcInfo = PetIslandService.buildNpcInfo(data.getMap().getId(), npcId, npcPoint);
		//添加npc到地图中
		data.getMap().addNpc(npcInfo);
		//生成怪物
		WizardRaidMonster monster = buildWizardRaidMonster(npcInfo, type);
		//添加到副本中
		data.getMonsterMap().put(monster.getUuid(), monster);
		
		//刷普通怪，计数
		if (type == WRMonsterType.NORMAL) {
			data.setGenNormalMonsterNum(data.getGenNormalMonsterNum() + 1);
		}
		
		//通知玩家，刷出怪物了
		data.noticeMonster(npcId, type);
		
		return monster;
	}
	
	protected void removeMonsterInMap(WizardRaidRecordBase data, WizardRaidMonster monster) {
		//副本中移除
		data.getMonsterMap().remove(monster.getUuid());
		//地图中移除
		data.getMap().removeAddNpc(monster.getUuid());
	}
	
	protected Point randNpcPos(WizardRaidRecordBase data) {
		List<Integer> canPointList = new ArrayList<Integer>();
		//所有的点
		List<Integer> allPoint = Globals.getTemplateCacheService().getWizardRaidTemplateCache().getAllPointList();
		canPointList.addAll(allPoint);
		//已经占用的点
		List<Integer> usedPointList = data.getMap().getAddNpcUsedPoint();
		canPointList.removeAll(usedPointList);
		
		//如果点不够用了，那就取重复的点
		if (canPointList.isEmpty()) {
			canPointList.addAll(allPoint);
			Loggers.wizardRaidLogger.warn("monster point maybe overlap!data=" + data);
		}

		int randKey = RandomUtil.nextEntireInt(0, canPointList.size() - 1);
		int hit = canPointList.get(randKey);
		Point point = new Point(AbstractGameMap.calcPointX(hit), AbstractGameMap.calcPointY(hit));
		return point;
	}
	
	protected WizardRaidMonster buildWizardRaidMonster(NpcInfo npcInfo, WRMonsterType type) {
		WizardRaidMonster monster = new WizardRaidMonster();
		monster.setUuid(npcInfo.getUuid());
		monster.setNpcId(npcInfo.getNpcId());
		monster.setStartTime(Globals.getTimeService().now());
		monster.setType(type);
		return monster;
	}
	
	protected void refreshOldMonster(WizardRaidRecordBase data) {
		//旧的怪检查是否该变南瓜了，如果有正在进行的战斗，需要变南瓜了，则强制结束战斗
		long passTime = data.getPassTimeUntilNow();
		Set<String> uuidSet = new HashSet<String>();
		uuidSet.addAll(data.getMonsterMap().keySet());
		for (String uuid : uuidSet) {
			WizardRaidMonster monster = data.getMonsterMap().get(uuid);
			if (monster.isDead() ||
					monster.getType() != WRMonsterType.NORMAL) {
				continue;
			}
			//普通怪，看时间是否已到，到了就变南瓜怪
			if (passTime - monster.getStartPassTime() > 
				Globals.getGameConstants().getWizardRaidPumpkinTime()) {
				//变南瓜
				monsterChangeToPumpkin(data, monster);
			}
		}
	}
	
	/**
	 * 变南瓜怪，删除之前的怪物，强制结束战斗（如果进行中），该位置新增加南瓜怪
	 * @param data
	 * @param monster
	 */
	protected void monsterChangeToPumpkin(WizardRaidRecordBase data, WizardRaidMonster monster) {
		if (monster.getType() != WRMonsterType.NORMAL) {
			return;
		}
		
		int raidId = data.getRaidId();
		WizardRaidTemplate tpl = Globals.getTemplateCacheService().get(raidId, WizardRaidTemplate.class);
		int pumpkinNpcId = tpl.getPumpkinNpcId();
		String npcUUID = monster.getUuid();
		NpcInfo npcInfo = data.getMap().getAddNpc(npcUUID);
		if (npcInfo == null) {
			Loggers.wizardRaidLogger.error("npcInfo is null!data=" + data + ";npcUUID=" + npcUUID);
		}
		int x = npcInfo.getX();
		int y = npcInfo.getY();
		
		int npcBattleId = npcInfo.getBattleId();
		//npc正在战斗中，需要强制结束战斗
		if (npcBattleId > 0) {
			forceEndDoingFight(data, npcBattleId);
		}
		
		//移除该怪物
		removeMonsterInMap(data, monster);
		
		//在该怪物的位置，生成南瓜怪，放入地图中及副本中
		genMonsterInMap(data, pumpkinNpcId, WRMonsterType.PUMPKIN, new Point(x, y));
	}
	
	/**
	 * 检测是否需要强制结束正在进行的战斗
	 * @param data
	 * @param npcBattleId
	 */
	protected void forceEndDoingFight(WizardRaidRecordBase data, int npcBattleId) {
		if (npcBattleId <= 0) {
			return;
		}
		
		//单人
		if (data.getType() == WizardRaidType.SINGLE) {
			//判断玩家是否正在和该怪物战斗中，如果是则强制结束战斗
			Human human = Globals.getOnlinePlayerService().getPlayer(((WizardRaidRecordSingle)data).getRoleId()).getHuman();
			if (human.getLastBattleId() == npcBattleId) {
				Globals.getBattleService().forceEndBattle(human.getLastBattleId());
			}
		} else if (data.getType() == WizardRaidType.TEAM) {
			//组队
			Team team = Globals.getTeamService().getTeam(((WizardRaidRecordTeam)data).getTeamId());
			if (team != null) {
				//队伍正在与npc战斗
				if (team.getCurBattleId() == npcBattleId) {
					Globals.getTeamService().getTeamBattleLogic().forceEndBattle(
							Globals.getTeamService().getTeamBattleLogic().getBattle(team.getCurBattleId()), "monsterChangeToPumpkin");
				} else {
					//某个队员正在与npc战斗
					for (Long memberId : team.getMemberMap().keySet()) {
						Player memPlayer = Globals.getOnlinePlayerService().getPlayer(memberId);
						if (memPlayer != null && memPlayer.getHuman() != null && memPlayer.isInScene()) {
							if (memPlayer.getHuman().getLastBattleId() == npcBattleId) {
								Globals.getBattleService().forceEndBattle(memPlayer.getHuman().getLastBattleId());
								break;
							}
						}
					}
				}
			}
		}
	}
	
	public void onBattleEnd(BattleProcess bp, String npcUUID, boolean isAttackerWin, boolean isForceEnd) {
		//取副本数据
		WizardRaidRecordBase data = null;
		if (bp instanceof TeamBattleProcess) {
			TeamBattleProcess bpTeam = (TeamBattleProcess) bp;
			data = getTeamData(bpTeam.getTeam().getId());
		} else {
			data = getSingleData(bp.getAttackerId());
			
			if (data == null) {
				//这种是组队队员暂离打怪的情况
				long roleId = bp.getAttackerId();
				Team team = Globals.getTeamService().getHumanTeam(roleId);
				if (team != null && isTeamInRaid(team.getId())) {
					data = getTeamData(team.getId());
				}
			}
		}
		
		if (data == null) {
			Loggers.wizardRaidLogger.error("wizardRaidData is null!bp=" + bp + ";attackerId=" + bp.getAttackerId());
			return;
		}
		
		//副本id
		int raidId = data.getRaidId();
		
		//获取怪物对象
		WizardRaidMonster monster = data.getMonsterMap().get(npcUUID);
		if (monster == null) {
			Loggers.wizardRaidLogger.error("monster is null!bp=" + bp + 
					";attackerId=" + bp.getAttackerId() + ";npcUUID=" + npcUUID);
			return;
		}
		//设置怪物的battleId为0
		NpcInfo npc = data.getMap().getAddNpc(npcUUID);
		if (npc == null) {
			Loggers.wizardRaidLogger.error("npc is null!bp=" + bp + 
					";attackerId=" + bp.getAttackerId() + ";npcUUID=" + npcUUID);
			return;
		}
		npc.setBattleId(0);
		
		//如果攻击方胜利，则地图上移除怪物，副本中设置怪物为死亡状态
		if (isAttackerWin) {
			//设置怪物为死亡状态
			monster.setDead(true);
			monster.setDeadTime(Globals.getTimeService().now());
			
			//从地图中移除该npc
			data.getMap().removeAddNpc(npcUUID);
			
			//胜利计数+1
			data.setWinMonsterNum(data.getWinMonsterNum() + 1);
			
			WizardRaidTemplate raidTpl = Globals.getTemplateCacheService().get(raidId, WizardRaidTemplate.class);
			
			//战胜boss数量+1
			if (monster.isBoss()) {
				data.setWinBossNum(data.getWinBossNum() + 1);
				
				//给杀boss奖励
				if (data.getWinBossNum() <= raidTpl.getBossRewardIdList().size()) {
					int bossRewardId = raidTpl.getBossRewardIdList().get(data.getWinBossNum() - 1);
					data.giveBossReward(bossRewardId);
				} else {
					Loggers.wizardRaidLogger.error("boss num bigger than reward num!bp=" + bp + 
							";attackerId=" + bp.getAttackerId() + ";npcUUID=" + npcUUID + 
							";bossNum=" + data.getWinBossNum() + ";rewardNum=" + raidTpl.getBossRewardIdList().size());
				}
			}
			
			//总胜利次数
			int winNum = data.getWinMonsterNum();
			//除去战胜boss的胜利次数
			int winNumExceptBoss = winNum - data.getWinBossNum();
			//刷出boss要求打怪数量（不含boss数量）
			int bossCond = Globals.getGameConstants().getWizardRaidBossCond();
			//boss总数量
			int bossNum = raidTpl.getBossNpcIdList().size();
			
			//是否需要刷出最后一个boss，条件是 前面所有小怪都已击败，且前面的boss也都已击败
			boolean refreshLastBoss = winNum == bossCond * bossNum + bossNum - 1;
			int bossIndex = winNumExceptBoss / bossCond - 1;
			//是否需要刷出boss（非最后一个），条件是 杀小怪达到指定个数就刷一个
			boolean refreshBossNotLast = !monster.isBoss() && winNumExceptBoss % bossCond == 0 && bossIndex + 1 < bossNum;
			
			//是否击败了最后一个boss
			boolean isLastBossKilled = monster.isBoss() && data.getWinBossNum() == bossNum;
			
			//如果是最后一只boss，则获得活动奖励，退出副本
			if (isLastBossKilled) {
				//给活动奖励
				data.giveFinalReward();
				
				//退出副本
				onRaidEnd(data);
			} else {
				//满足刷boss条件，则刷
				if (refreshBossNotLast || refreshLastBoss) {
					int bossNpcId = raidTpl.getBossNpcIdList().get(bossIndex);
					//刷出布袋鼠
					genMonsterInMap(data, bossNpcId, WRMonsterType.BOSS, null);
				}
				
				//更新副本信息
				sendWizardRaidInfo(data);
			}
			//记录日志
			Loggers.wizardRaidLogger.info("data=" + data + ";bossIndex=" + bossIndex + ";isLastBossKilled=" + isLastBossKilled + 
					";refreshBossNotLast=" + refreshBossNotLast + ";refreshLastBoss=" + refreshLastBoss);
		}
		
		//记录日志
		Loggers.wizardRaidLogger.info("data=" + data + ";isAttackerWin=" + isAttackerWin);
	}
	
	protected void onRaidEnd(WizardRaidRecordBase data) {
		//看是否有正在进行的战斗，有则强制结束掉
		for (WizardRaidMonster monster : data.getMonsterMap().values()) {
			if (monster.isDead()) {
				continue;
			}
			NpcInfo npcInfo = data.getMap().getAddNpc(monster.getUuid());
			if (npcInfo == null) {
				continue;
			}
			int npcBattleId = npcInfo.getBattleId();
			if (npcBattleId > 0) {
				forceEndDoingFight(data, npcBattleId);
			}
		}
		
		//退出副本
		data.exitRaid();
		
		//删除副本数据
		removeData(data);
	}
	
	public void giveRewardSingle(WizardRaidRecordSingle data, int rewardId, boolean isFinal) {
		giveReward(data.getRoleId(), rewardId, isFinal, "WizardRaidRecordSingle");
	}
	
	protected void giveReward(long roleId, int rewardId, boolean isFinal, String source) {
		boolean giveRewardFlag = false;
		//可能是计算类奖励，需要传入一些计算奖励的参数进去
		Map<String, Object> params = new HashMap<String, Object>();
		params.put(RewardDef.CALC_KEY_LEVEL, Globals.getOfflineDataService().getUserLevel(roleId));
		Reward reward = Globals.getRewardService().createReward(roleId, rewardId, source, params);
		
		//玩家在线，直接给奖励
		if (Globals.getTeamService().isPlayerOnline(roleId)) {
			Human human = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman();
			giveRewardFlag = Globals.getRewardService().giveReward(human, reward, true);
			//通知玩家完成活动
			if (isFinal) {
				human.sendErrorMessage(LangConstants.WIZARD_RAID_SUCCESS_FINISH);
			}
		} else {
			//玩家离线，给离线奖励
			giveRewardFlag = Globals.getOfflineRewardService().sendOfflineReward(roleId, OfflineRewardType.WIZARD_RAID, reward, "");
		}
		if (!giveRewardFlag) {
			// 记录错误日志
			Loggers.wizardRaidLogger.error("#WizardRaidService#giveFinalRewardSignle#giveReward failed!uuid=" + 
					roleId + ";rewardId=" + rewardId + ";source=" + source);
		}
	}
	
	public void giveRewardTeam(WizardRaidRecordTeam data, int rewardId, boolean isFinal) {
		int teamId = data.getTeamId();
		Team team = Globals.getTeamService().getTeam(teamId);
		if (team == null) {
			Loggers.wizardRaidLogger.error("team is null!teamId=" + teamId);
			return;
		}
		
		for (TeamMember member : team.getMemberList()) {
			giveReward(member.getRoleId(), rewardId, isFinal, "WizardRaidRecordTeam");
		}
	}
	
	public void exitRaid(WizardRaidRecordSingle data) {
		leaveRaidMap(data.getRoleId(), null);
	}
	
	public void exitRaid(WizardRaidRecordTeam data) {
		int teamId = data.getTeamId();
		Team team = Globals.getTeamService().getTeam(teamId);
		if (team == null) {
			Loggers.wizardRaidLogger.warn("exitRaid team is null!teamId=" + 
					teamId + ",maybe team already dismissed.");
			return;
		}
		
		//设置队伍状态为普通
		Globals.getTeamService().changeTeamStatus(team.getId(), TeamStatus.NORMAL);
		
		//地图所有人离开，回到备用地图
		Globals.getMapService().allPlayerToBackMap(data.getMap());
		
//		//队长离开地图，队员会自动跟随
//		long leaderId = team.getLeader().getRoleId();
//		leaveRaidMap(leaderId, data);
//		
//		//暂离状态的队员，需要主动调用离开副本地图
//		for (TeamMember tm : team.getMemberList()) {
//			if (tm.getStatus() != MemberStatus.NORMAL) {
//				leaveRaidMap(tm.getRoleId(), data);
//			}
//		}
	}
	
	/**
	 * 离开副本地图
	 * @param roleId
	 * @param teamData
	 */
	protected void leaveRaidMap(long roleId, WizardRaidRecordTeam teamData) {
		Player player = Globals.getOnlinePlayerService().getPlayer(roleId);
		if (player != null && player.getHuman() != null && player.isInScene()) {
			//如果玩家当前正在副本地图中
			if (player.getHuman().getMapId() == Globals.getTemplateCacheService().getMapTemplateCache().getWizardRaidMapId()) {
				//玩家在线，则回到之前的地图，这里如果是组队需要传入地图，因为玩家离队后取不到地图了
				Globals.getMapService().enterMap(player.getHuman(), 
						player.getHuman().getBackMapId(), player.getHuman().getBackX(), player.getHuman().getBackY(),
						teamData != null ? teamData.getMap() : null);
			}
		}
	}
	
	public boolean canEnterRaidTeam(Human human, int raidId) {
		if (!ENTER) {
			return false;
		}
		//活动是否开启中
		if (!isOpening()) {
			return false;
		}
		
		long roleId = human.getCharId();
		//玩家是否队长
		Team team = Globals.getTeamService().getHumanTeam(roleId);
		if (!Globals.getTeamService().isTeamLeader(roleId)) {
			//非队长，不能进副本
			human.sendErrorMessage(LangConstants.WIZARD_RAID_NOT_LEADER);
			return false;
		}
		
		//队伍人数最低要求
		if (team.getMemberNum() < Globals.getGameConstants().getWizardRaidMinMemNum()) {
			human.sendErrorMessage(LangConstants.WIZARD_RAID_NOT_ENOUGH_MEMBER, 
					Globals.getGameConstants().getWizardRaidMinMemNum());
			return false;
		}
		
		//队伍是否已经在副本中
		if (isTeamInRaid(team.getId())) {
			return false;
		}
		
		//队伍正在战斗，不能进入
		if (team.isInBattle()) {
			return false;
		}
		
		WizardRaidTemplate tpl = Globals.getTemplateCacheService().get(raidId, WizardRaidTemplate.class);
		if (tpl == null || tpl.getWizardRaidType() != WizardRaidType.TEAM) {
			return false;
		}
			
		//对所有队员的要求
		for (TeamMember member : team.getMemberMap().values()) {
			//必须在线
			if (!Globals.getTeamService().isOnlineNow(member)) {
				team.noticeTeamMemberErrorMsg(LangConstants.WIZARD_RAID_NOT_ONLINE_NOW, member.getName());
				return false;
			}
			//状态必须都是正常状态
			if (!Globals.getTeamService().isInTeamNormal(member.getRoleId())) {
				team.noticeTeamMemberErrorMsg(LangConstants.WIZARD_RAID_NOT_VALID_STATUS, member.getName());
				return false;
			}
			//玩家等级是否满足
			if (!(member.getLevel() >= tpl.getLevelMin() && member.getLevel() <= tpl.getLevelMax())) {
				team.noticeTeamMemberErrorMsg(LangConstants.WIZARD_RAID_NOT_VALID_LEVEL, member.getName());
				return false;
			}
			
			Human memberHuman = Globals.getOnlinePlayerService().getPlayer(member.getRoleId()).getHuman();
			//是否有进入次数
			if (!hasEnterTimes(memberHuman)) {
				team.noticeTeamMemberErrorMsg(LangConstants.WIZARD_RAID_NOT_ENOUGH_TIMES, member.getName());
				return false;
			}
			//玩家不能是战斗中状态
			if (memberHuman.isInAnyBattle()) {
				team.noticeTeamMemberErrorMsg(LangConstants.WIZARD_RAID_NOT_VALID_STATUS, member.getName());
				return false;
			}
			//玩家当前已经在单人副本中，不能进入
			if (isPlayerInSingle(member.getRoleId())) {
				team.noticeTeamMemberErrorMsg(LangConstants.WIZARD_RAID_NOT_VALID_STATUS, member.getName());
				return false;
			}
		}
		
		return true;
	}
	
	protected void addEnterTmpData(TeamMember member, int raidId) {
		this.enterTmpMap.put(member.getRoleId(), new WizardRaidEnterTmp(
				member.getRoleId(), member.getTeam().getId(), raidId));
	}
	
	protected void removeEnterTmpData(long roleId) {
		this.enterTmpMap.remove(roleId);
	}
	
	protected WizardRaidEnterTmp getWizardRaidEnterTmp(long roleId) {
		return this.enterTmpMap.get(roleId);
	}
	
	/**
	 * 队长请求进入指定副本
	 * @param human
	 * @param raidId
	 */
	public void askEnterRaidTeam(Human human, int raidId) {
		//玩家能否进入副本
		if (!canEnterRaidTeam(human, raidId)) {
			return;
		}
		
		//通知队员，队长请求进入副本
		Team team = Globals.getTeamService().getHumanTeam(human.getCharId());
		for (TeamMember member : team.getMemberMap().values()) {
			//记录临时数据，队伍申请进入副本了
			addEnterTmpData(member, raidId);
			
			//给队员发消息，告知要进入副本了
			Human memberHuman = Globals.getOnlinePlayerService().getPlayer(member.getRoleId()).getHuman();
			memberHuman.sendMessage(new GCWizardraidAskEnterTeam(raidId));
		}
	}
	
	/**
	 * 队员应答，是否同意进入副本
	 * @param human
	 * @param agree
	 */
	public void answerEnterRaidTeam(Human human, boolean agree) {
		long roleId = human.getCharId();
		WizardRaidEnterTmp enterTmp = getWizardRaidEnterTmp(roleId);
		if (enterTmp == null) {
			return;
		}
		Team team = Globals.getTeamService().getHumanTeam(roleId);
		if (team == null || team.getId() != enterTmp.getTeamId()) {
			removeEnterTmpData(roleId);
			return;
		}
		
		//设置结果
		enterTmp.setAgree(agree);
		int raidId = enterTmp.getRaidId();
		
		//同意，则看是否都已经同意，是则进入副本
		if (agree) {
			boolean flag = true;
			//看队伍的其他人是否都已同意
			for (TeamMember member : team.getMemberMap().values()) {
				WizardRaidEnterTmp memEnterTmp = getWizardRaidEnterTmp(member.getRoleId());
				if (memEnterTmp != null && 
						!memEnterTmp.isAgree()) {
					flag = false;
					break;
				}
			}
			
			if (flag) {
				//队伍进入副本
				Player leaderPlayer = Globals.getOnlinePlayerService().getPlayer(team.getLeader().getRoleId());
				if (leaderPlayer != null && leaderPlayer.getHuman() != null && leaderPlayer.isOnline()) {
					enterRaidTeam(leaderPlayer.getHuman(), raidId);
				} else {
					Loggers.wizardRaidLogger.error("team leader is not online now!");
				}
			}
		} else {
			//拒绝，不能进入副本，删除临时数据
			for (TeamMember member : team.getMemberMap().values()) {
				//删除临时数据
				removeEnterTmpData(member.getRoleId());
				
				Player memberPlayer = Globals.getOnlinePlayerService().getPlayer(member.getRoleId());
				//通知其他人，该玩家拒绝进入副本
				if (memberPlayer == null || memberPlayer.getHuman() == null) {
					continue;
				}
				memberPlayer.getHuman().sendErrorMessage(LangConstants.WIZARD_RAID_NOT_AGREE, human.getName());
			}
		}
	}
	
	public void enterRaidTeam(Human human, int raidId) {
		//玩家能否进入副本
		if (!canEnterRaidTeam(human, raidId)) {
			return;
		}
		
		int raidMapId = Globals.getTemplateCacheService().getMapTemplateCache().getWizardRaidMapId();
		long leaderId = human.getCharId();
		
		Team team = Globals.getTeamService().getHumanTeam(leaderId);
		for (TeamMember member : team.getMemberMap().values()) {
			//删除临时数据
			removeEnterTmpData(member.getRoleId());
			
			//每个玩家扣次数或道具
			Human memberHuman = Globals.getOnlinePlayerService().getPlayer(member.getRoleId()).getHuman();
			if (memberHuman == null) {
				return;
			}
			
			boolean costItemFlag = isCostItem(memberHuman);
			//行为次数记录
			memberHuman.getBehaviorManager().doBehavior(BehaviorTypeEnum.WIZARDRAID_ENTER_TIMES);
			//任务监听
			human.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.ENTER_WIZARDRAID, 0, 1);
			
			//扣次数或道具
			//免费次数如果扣除成功，则不再扣道具
			if (costItemFlag) {
				//扣道具
				Collection<Item> itemRet = memberHuman.getInventory().removeItem(Globals.getGameConstants().getWizardRaidEnterItemId(), 
						Globals.getGameConstants().getWizardRaidEnterItemNum(), ItemLogReason.WIZARD_RAID_SINGLE_ENTER_COST, 
						ItemLogReason.WIZARD_RAID_SINGLE_ENTER_COST.getReasonText());
				if (itemRet == null || itemRet.isEmpty()) {
					//道具不足，不应该走到这里，前面验证了
					return;
				}
			}
			//更新剩余免费次数
			sendWizardRaidLeftTimes(memberHuman);
		}
		
		//设置队伍状态为活动中
		Globals.getTeamService().changeTeamStatus(team.getId(), TeamStatus.DOING);

		//队伍进入副本
		WizardRaidRecordTeam data = createTeamData(human, team, raidId);
		
		//加入map
		addTeamData(data);
		
		//队长进入副本，队员会跟着进入
		Globals.getMapService().enterMap(human, raidMapId);
		
		//发消息
		team.noticeTeamMember(new GCWizardraidEnterTeam(raidId), true, true);
		team.noticeTeamMember(buildGCWizardraidInfo(data), true, true);
	}
	
	protected WizardRaidRecordTeam createTeamData(Human human, Team team, int raidId) {
		WizardRaidRecordTeam data = new WizardRaidRecordTeam();
		data.setTeamId(team.getId());
		data.setType(WizardRaidType.TEAM);
		data.setRaidId(raidId);
		long now = Globals.getTimeService().now();
		data.setEnterTime(now);
		return data;
	}
	
	public void startNpcFight(Human human, NpcInfo npcInfo) {
		WizardRaidRecordBase data = null;
		long roleId = human.getCharId();
		if (Globals.getTeamService().isInTeam(roleId)) {
			//组队
			Team team = Globals.getTeamService().getHumanTeam(roleId);
			data = getTeamData(team.getId());
			
			//队长可以触发战斗，暂离状态的队员可触发战斗
			if (!Globals.getTeamService().isTeamLeader(roleId) && 
					!Globals.getTeamService().isAwayStatus(roleId)) {
				return;
			}
		} else {
			//单人
			data = getSingleData(roleId);
		}
		
		//怪物是否存在
		WizardRaidMonster monster = data.getMonster(npcInfo.getUuid());
		if (monster == null) {
			Loggers.wizardRaidLogger.error("monster not exist!roleId=" + roleId + ";npcInfo=" + npcInfo);
			return;
		}
		
		//与npc战斗
		Globals.getMapService().mapFightNpc(human, npcInfo, false);
	}
	
	/**
	 * 玩家点击离开副本
	 * @param human
	 */
	public void leaveRaid(Human human) {
		//战斗中不能离开
		if (human.isInAnyBattle()) {
			return;
		}
		
		long roleId = human.getCharId();
		//单人的，直接退出副本即可
		if (isPlayerInSingle(roleId)) {
			onRaidEnd(getSingleData(roleId));
			return;
		}
		
		//组队的话，只有队长可以点离开副本
		boolean isLeader = Globals.getTeamService().isTeamLeader(roleId);
		if (!isLeader) {
			human.sendErrorMessage(LangConstants.WIZARD_RAID_NOT_PERMIT);
			return;
		}
		
		//队伍退出副本
		Team team = Globals.getTeamService().getHumanTeam(roleId);
		if (team != null && 
				isTeamInRaid(team.getId())) {
			//退出副本
			onRaidEnd(getTeamData(team.getId()));
		}
	}
	
	/**
	 * 队伍中的队员离队时，退出副本
	 * @param roleId
	 * @param teamId
	 */
	public void onTeamMemberLeave(long roleId, int teamId, boolean isLast) {
		//玩家所在的队伍在副本中，则玩家单独退出副本
		if (isTeamInRaid(teamId)) {
			WizardRaidRecordTeam data = getTeamData(teamId);
			//队员退出副本地图，在队伍被清除之前调用，否则找不到之前的地图
			leaveRaidMap(roleId, data);
			
			//如果是队伍最后一个人，则删除副本数据
			if (isLast) {
				onRaidEnd(data);
			}
		}
	}
	
	/**
	 * 定时处理组队副本
	 */
	public void checkTeamRaidHeartbeat() {
		//活动是否开启中
		if (!isOpening()) {
			return;
		}
		//没有数据直接返回
		if (teamMap.isEmpty()) {
			return;
		}
		
		Set<Integer> allSet = new HashSet<Integer>();
		allSet.addAll(teamMap.keySet());
		
		int i = 0;
		for (Integer teamId : allSet) {
			WizardRaidRecordTeam data = getTeamData(teamId);
			i++;
			
			//如果队伍已经没了，则相关数据也没用了
			if (Globals.getTeamService().getTeam(teamId) == null) {
				//删除数据
				removeTeamData(teamId);
				continue;
			}
			
			//检测副本超时时间，如果需要结束则结束
			boolean endFlag = checkEndRaid(data);
			if (endFlag) {
				continue;
			}
			
			//检查波数
			checkWave(data);
			
			if ((i % MOD) == CountMod) {
				//刷出新怪物
				refreshNewMonster(data);
				
				//旧的怪检查是否该变南瓜了，如果有正在进行的战斗，需要变南瓜了，则强制结束战斗
				refreshOldMonster(data);
			}
		}
		
		CountMod = (CountMod + 1) % MOD;
	}
	
	public void onPlayerLogin(Human human) {
		//活动是否开启中
		if (!isOpening()) {
			return;
		}
		
		long roleId = human.getUUID();
		//是否正在副本中
		if (isPlayerInSingle(roleId)) {
			long now = Globals.getTimeService().now();
			
			WizardRaidRecordSingle data = getSingleData(roleId);
			//设置最近一次登录开始计时时间
			data.setLastStartTime(now);
		}
		
		sendWizardRaidInfo(human);
	}
	
	public void onPlayerLogout(long roleId) {
		//活动是否开启中
		if (!isOpening()) {
			return;
		}
		
		//是否正在副本中
		if (!isPlayerInSingle(roleId)) {
			return;
		}
		
		WizardRaidRecordSingle data = getSingleData(roleId);
		long lastStartTime = data.getLastStartTime();
		if (lastStartTime <= 0) {
			return;
		}
		
		long newPassTime = data.getTotalPassTime() + Globals.getTimeService().now() - lastStartTime;
		//更新时间
		data.setLastStartTime(0);
		data.setTotalPassTime(newPassTime);
	}
	
	public boolean isOpening() {
		return OPEN;
	}
	
	/**
	 * 获取玩家的绿野仙踪副本地图
	 * @param roleId
	 * @return
	 */
	public AbstractGameMap getGameMap(long roleId) {
		if (!isOpening()) {
			return null;
		}
		AbstractGameMap map = null;
		if (getSingleData(roleId) != null) {
			map = getSingleData(roleId).getMap();
		} else {
			Team team = Globals.getTeamService().getHumanTeam(roleId);
			if (team != null) {
				if (getTeamData(team.getId()) != null) {
					map = getTeamData(team.getId()).getMap();
				}
			}
		}
		return map;
	}
	
}
