package com.imop.lj.gameserver.timelimit;

import java.util.Map;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.activity.function.ActivityDef;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTaskExecutor;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTaskExecutorImpl;
import com.imop.lj.gameserver.exam.ExamDef.ExamState;
import com.imop.lj.gameserver.exam.ExamDef.ExamType;
import com.imop.lj.gameserver.exam.bean.AbstractExam;
import com.imop.lj.gameserver.exam.bean.ExamInfo;
import com.imop.lj.gameserver.exam.bean.ExamTimeLimit;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;
import com.imop.lj.gameserver.timelimit.monster.TimeLimitMonster;
import com.imop.lj.gameserver.timelimit.npc.TimeLimitNpc;

import net.sf.json.JSONObject;

/**
 * 限时活动管理器
 * 
 */
public class TimeLimitManager implements JsonPropDataHolder {
	
	public static final String PUSH_TYPE = "pushType";
	public static final String START_TIME = "startTime";
	public static final String PUSH_QUEST_ID = "pushQuestId";
	
	private Human owner;
	private int pushType;
	private long startTime;
	private int pushQuestId;
	
	/** 心跳任务处理器 */
	private HeartbeatTaskExecutor hbTaskExecutor;
	
	public TimeLimitManager(Human human){
		this.owner = human;
		hbTaskExecutor = new HeartbeatTaskExecutorImpl();
		hbTaskExecutor.submit(new TimeLimitChecker(this));
	}
	
	@Override
	public String toJsonProp() {
		JSONObject obj = new JSONObject();
		obj.put(PUSH_TYPE, pushType);
		obj.put(START_TIME, startTime);
		obj.put(PUSH_QUEST_ID, pushQuestId);
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
		
		this.pushType = JsonUtils.getInt(obj, PUSH_TYPE);
		this.startTime = JsonUtils.getLong(obj, START_TIME);
		this.pushQuestId = JsonUtils.getInt(obj, PUSH_QUEST_ID);
	}
	
	public Human getOwner() {
		return owner;
	}

	/**
	 * 检查玩家身上的限时活动是否过期,过期则删除掉
	 */
	public void checkTimeout() {
		long roleId = this.owner.getCharId();
		//玩家身上没有限时活动
		if(this.pushType ==0){
			return;
		}
		//答题
		if(ActivityDef.TimeLimitType.DT.index == this.pushType){
			if(Globals.getTimeService().now() - this.startTime > Globals.getGameConstants().getTimeLimitExistenceTime()){
				//检测玩家的答题状态是否是正常完成,记录日志
				Map<Long, Map<ExamType, AbstractExam>> examMap = Globals.getExamService().getExamMap();
				if(examMap.containsKey(roleId)){
					if(examMap.get(roleId).containsKey(pushType)){
						ExamTimeLimit exam = (ExamTimeLimit) examMap.get(roleId).get(pushType);
						ExamInfo info = exam.getExamInfo();
						if(info != null){
							Loggers.timeLimitLogger.info("timelimit exam state=" + info.getExamState());
							info.setExamState(ExamState.END.index);
							exam.setExamInfo(info);
							//清除限时答题活动
							this.owner.sendMessage(exam.buildGCExamInfo(this.owner, exam));
						}
					}
				}
				
				//清除玩家身上的限时活动
				this.resetTimeLimit(this.owner);
				//发消息刷新活动列表
				Globals.getActivityUIService().freshActivityUI(this.owner);
				//告诉玩家,很遗憾
				this.owner.sendErrorMessage(LangConstants.TIMELIMIT_TIME_OUT);
			}
		}
		
		//限时杀怪
		if(ActivityDef.TimeLimitType.SG.index == this.pushType){
			if(Globals.getTimeService().now() - this.startTime > Globals.getGameConstants().getTimeLimitExistenceTime()){
				//检测玩家限时刷怪任务是否正常完成,记录日志
				TimeLimitMonster task= this.owner.getTimeLimitMonsterManager().getCurTask();
				if(task != null){
					Loggers.timeLimitLogger.info("timelimit monster task state=" + task.getStatus());
				}
				//清除限时杀怪任务
				Globals.getTimeLimitMonsterTaskService().giveUpTask(this.owner);
				//清除玩家身上的限时活动
				this.resetTimeLimit(this.owner);
				//发消息刷新活动列表
				Globals.getActivityUIService().freshActivityUI(this.owner);
				//告诉玩家,很遗憾
				this.owner.sendErrorMessage(LangConstants.TIMELIMIT_TIME_OUT);

			}
		}
		
		//限时挑战npc
		if(ActivityDef.TimeLimitType.NPC.index == this.pushType){
			if(Globals.getTimeService().now() - this.startTime > Globals.getGameConstants().getTimeLimitExistenceTime()){
				//检测玩家限时刷怪任务是否正常完成,记录日志
				TimeLimitNpc task= this.owner.getTimeLimitNpcManager().getCurTask();
				if(task != null){
					Loggers.timeLimitLogger.info("timelimit npc task state=" + task.getStatus());
				}
				//清除限时挑战npc任务
				Globals.getTimeLimitNpcTaskService().giveUpTask(this.owner);
				//清除玩家身上的限时活动
				this.resetTimeLimit(this.owner);
				//发消息刷新活动列表
				Globals.getActivityUIService().freshActivityUI(this.owner);
				//告诉玩家,很遗憾
				this.owner.sendErrorMessage(LangConstants.TIMELIMIT_TIME_OUT);

			}
		}
	}
	
	
	/**
	 * 初始化玩家身上的限时活动
	 * @param human
	 */
	public void resetTimeLimit(Human human){
		//玩家身上是否有限时活动
		if(human == null || human.getTimeLimitManager() == null){
			return;
		}
		human.getTimeLimitManager().setPushType(ActivityDef.TimeLimitType.NULL.index);
		human.getTimeLimitManager().setPushQuestId(0);
		human.getTimeLimitManager().setStartTime(0);
		human.setModified();
		
	}

	public int getPushType() {
		return pushType;
	}

	public void setPushType(int pushType) {
		this.pushType = pushType;
	}

	public long getStartTime() {
		return startTime;
	}

	public void setStartTime(long startTime) {
		this.startTime = startTime;
	}

	public int getPushQuestId() {
		return pushQuestId;
	}

	public void setPushQuestId(int pushQuestId) {
		this.pushQuestId = pushQuestId;
	}

	public void onHeatBeat() {
		this.hbTaskExecutor.onHeartBeat();
	}

}
