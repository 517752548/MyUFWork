package com.imop.lj.gameserver.guaji;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTaskExecutor;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTaskExecutorImpl;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;

import net.sf.json.JSONObject;

/**
 * 挂机管理器
 */
public class GuaJiManager implements JsonPropDataHolder {
	
	public static final String ENCOUNTER_SECOND = "encounterSecond";
	public static final String HUMAN_EXP_TIMES = "humanExpTimes";
	public static final String PET_EXP_TIMES = "petExpTimes";
	public static final String FULL_ENEMY = "fullEnemy";
	public static final String SWITCH_SCENE = "switchScene";
	public static final String GUA_JI_MINUTE = "guaJiMinute";
	public static final String LAST_PAUSE_TIME = "lastPauseTime";
	public static final String GUA_JI = "guaJi";
	public static final String PASS_TIME = "passTime";
	
	private Human owner;
	//遇敌间隔
	private int encounterSecond;
	//增加人物经验(1-1倍经验,2-2倍经验)
	private int humanExpTimes;
	//增加宠物经验(当前出战宠物会加上)
	private int petExpTimes;
	//是否开启满怪(true,false)
	private boolean fullEnemy;
	//切换场景暂停(true,false)
	private boolean switchScene;
	//挂机分钟
	private int guaJiMinute;
	//开始时间
	private long startTime;
	//上次暂停时间
	private long lastPauseTime;
	//是否挂机
	private boolean guaJi;
	//挂机走的时间
	private long passTime;
	
	/** 心跳任务处理器 */
	private HeartbeatTaskExecutor hbTaskExecutor;
	
	public GuaJiManager(Human human){
		this.owner = human;
		hbTaskExecutor = new HeartbeatTaskExecutorImpl();
		hbTaskExecutor.submit(new GuaJiChecker(this));
		humanExpTimes = 1;
		petExpTimes = 1;
	}
	
	@Override
	public String toJsonProp() {
		JSONObject obj = new JSONObject();
		obj.put(ENCOUNTER_SECOND, encounterSecond);
		obj.put(HUMAN_EXP_TIMES, humanExpTimes);
		obj.put(PET_EXP_TIMES, petExpTimes);
		obj.put(FULL_ENEMY, fullEnemy);
		obj.put(SWITCH_SCENE, switchScene);
		obj.put(GUA_JI_MINUTE, guaJiMinute);
		obj.put(LAST_PAUSE_TIME, lastPauseTime);
		obj.put(GUA_JI, guaJi);
		obj.put(PASS_TIME, passTime);
		return obj.toString();
	}

	@Override
	public void loadJsonProp(String value) {
		if(value == null || value.isEmpty()){
			return;
		}
		
		JSONObject obj = JSONObject.fromObject(value);
		if(obj == null || obj.isEmpty()){
			return;
		}
		
		this.encounterSecond = JsonUtils.getInt(obj, ENCOUNTER_SECOND);
		this.humanExpTimes = JsonUtils.getInt(obj, HUMAN_EXP_TIMES);
		this.petExpTimes = JsonUtils.getInt(obj, PET_EXP_TIMES);
		this.fullEnemy = JsonUtils.getBoolean(obj, FULL_ENEMY);
		this.switchScene = JsonUtils.getBoolean(obj, SWITCH_SCENE);
		this.guaJiMinute = JsonUtils.getInt(obj, GUA_JI_MINUTE);
		this.lastPauseTime = JsonUtils.getLong(obj, LAST_PAUSE_TIME);
		this.guaJi = JsonUtils.getBoolean(obj, GUA_JI);
		this.passTime = JsonUtils.getLong(obj, PASS_TIME);
	}
	
	public int getEncounterSecond() {
		return encounterSecond;
	}

	public void setEncounterSecond(int encounterSecond) {
		this.encounterSecond = encounterSecond;
	}

	public int getHumanExpTimes() {
		return humanExpTimes;
	}

	public void setHumanExpTimes(int humanExpTimes) {
		this.humanExpTimes = humanExpTimes;
	}

	public int getPetExpTimes() {
		return petExpTimes;
	}

	public void setPetExpTimes(int petExpTimes) {
		this.petExpTimes = petExpTimes;
	}

	public boolean isFullEnemy() {
		return fullEnemy;
	}

	public void setFullEnemy(boolean fullEnemy) {
		this.fullEnemy = fullEnemy;
	}

	public boolean isSwitchScene() {
		return switchScene;
	}

	public void setSwitchScene(boolean switchScene) {
		this.switchScene = switchScene;
	}

	public int getGuaJiMinute() {
		return guaJiMinute;
	}

	public void setGuaJiMinute(int guaJiMinute) {
		this.guaJiMinute = guaJiMinute;
	}

	public long getStartTime() {
		return startTime;
	}

	public void setStartTime(long startTime) {
		this.startTime = startTime;
	}

	public long getLastPauseTime() {
		return lastPauseTime;
	}

	public void setLastPauseTime(long lastPauseTime) {
		this.lastPauseTime = lastPauseTime;
	}

	public boolean isGuaJi() {
		return guaJi;
	}

	public void setGuaJi(boolean guaJi) {
		this.guaJi = guaJi;
	}
	
	public long getPassTime() {
		return passTime;
	}

	public void setPassTime(long passTime) {
		this.passTime = passTime;
	}

	public Human getOwner() {
		return owner;
	}

	public void onHeatBeat() {
		this.hbTaskExecutor.onHeartBeat();
	}

	public void checkTimeout() {
		//玩家是否开启挂机
		if(!this.isGuaJi()){
			return;
		}
		
		//挂机时间为0,暂停挂机
		if(Globals.getGuaJiService().calculateGuaJiLeftTime(this.owner) <= 0){
			Globals.getGuaJiService().pauseGuaJi(this.owner);
			return;
		}
		
		//开启挂机,读取挂机参数
		boolean canStartBattle = Globals.getMapService().canStartBattleForGuaJi(this.owner);
		if(canStartBattle){
			Globals.getBattleService().meetMapMonsterBattle(this.owner);
		}
	}
}
