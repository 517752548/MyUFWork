package com.imop.lj.gameserver.overman;

import java.text.MessageFormat;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.db.model.OvermanEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.mail.MailDef;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.overman.msg.GCGetLowermanReward;
import com.imop.lj.gameserver.overman.msg.GCGetOvermanReward;
import com.imop.lj.gameserver.overman.msg.GCOvermanHongdian;
import com.imop.lj.gameserver.overman.msg.GCOvermanInfo;
import com.imop.lj.gameserver.overman.template.OvermanTemplate;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;

/**
 * Created by zhangzhe on 15/12/24.
 */
public class OvermanService implements InitializeRequired {

    protected Currency CURRENT_FORCE_FIRE_CURRENCY_TYPE = Currency.GOLD;

//    protected final static Integer NOT_HAD_GET_REWARD = 0; //奖励没有领取
    protected final static Integer HAD_GET_REWARD = 1; //奖励已经领取

    
    /** Map<师傅ID,师傅> */
    protected Map<Long, Overman> allOverman = Maps.newHashMap();
    /** Map<徒弟ID,师傅ID> */
    protected Map<Long, Long> allLowerman = Maps.newHashMap(); //按照徒弟查询
    protected Map<Long, OvermanDef.OVERMANTYPE> allOvermanMember = Maps.newHashMap(); //所有人的状态

    protected List<Long> needCheckOverman = Lists.newArrayList(); //需要延时处理的

    protected Map<Integer, TempFireOvermanInfo> tempFireOvermanList = Maps.newHashMap(); //临时纪录的解散师徒关系的id
    
    public OvermanService() {

    }

    public void checkAfterInit() {

    }

    @Override
    public void init() {
        List<OvermanEntity> overmanlist = Globals.getDaoService().getOvermanDao().getAllOverman();
        if (overmanlist == null || overmanlist.isEmpty()) {
            if (Loggers.overmanLogger.isDebugEnabled()) {
                Loggers.overmanLogger.debug("OvermanService init() : overmanlist size = 0");
            }
        }
        for (OvermanEntity overmanEntity : overmanlist) {
            Overman overman = new Overman();
            overman.fromEntity(overmanEntity);
            overman.getLifeCycle().activate();
            this.addOverman(overman);
            checkneedCheckOverman(overman); //检查是否需要放到check列表中
        }
        
        // 奖励检查
        int rewardId1 = Globals.getGameConstants().getOverman_overman_reward();
        RewardConfigTemplate rewardTpl = Globals.getTemplateCacheService().get(rewardId1, RewardConfigTemplate.class);
        if (null == rewardTpl) {
        	throw new TemplateConfigException("", 0, String.format("师徒奖励Id不存在[%d]", rewardId1));
        }
        // 奖励类型检查
        if (rewardTpl.getRewardReasonType() != RewardReasonType.OVERMAN_REWARD) {
        	throw new TemplateConfigException("", 0, String.format("师徒奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
        }
        
        int rewardId2 = Globals.getGameConstants().getOverman_lowerman_reward();
        RewardConfigTemplate rewardTpl2 = Globals.getTemplateCacheService().get(rewardId2, RewardConfigTemplate.class);
        if (null == rewardTpl2) {
        	throw new TemplateConfigException("", 0, String.format("师徒奖励Id不存在[%d]", rewardId2));
        }
        // 奖励类型检查
        if (rewardTpl2.getRewardReasonType() != RewardReasonType.OVERMAN_REWARD) {
        	throw new TemplateConfigException("", 0, String.format("师徒奖励身份识别类型[%d]", rewardTpl2.getRewardReasonTypeId()));
        }
        
        int rewardId3 = Globals.getGameConstants().getOverman_finish_lowerman_reward();
        RewardConfigTemplate rewardTpl3 = Globals.getTemplateCacheService().get(rewardId3, RewardConfigTemplate.class);
        if (null == rewardTpl3) {
        	throw new TemplateConfigException("", 0, String.format("师徒奖励Id不存在[%d]", rewardId3));
        }
        // 奖励类型检查
        if (rewardTpl3.getRewardReasonType() != RewardReasonType.OVERMAN_REWARD) {
        	throw new TemplateConfigException("", 0, String.format("师徒奖励身份识别类型[%d]", rewardTpl3.getRewardReasonTypeId()));
        }
    }

    protected void checkneedCheckOverman(Overman overman) {
        List<LowermanInfo> lowerlist = overman.getLowermans();
        for (LowermanInfo l : lowerlist) {
            if (l.getDeleteTime() > 0) {
                needCheckOverman.add(overman.getCharId());
                break;
            }
        }
    }

    public void addOverman(Overman overman) {
        allOvermanMember.put(overman.getCharId(), OvermanDef.OVERMANTYPE.OVERMAN);
        List<LowermanInfo> lowermanInfos = overman.getLowermans();
        for (LowermanInfo l : lowermanInfos) {
            allOvermanMember.put(l.getUuid(), OvermanDef.OVERMANTYPE.LOWERMAN);
            allLowerman.put(l.getUuid(), overman.getCharId());
        }
        allOverman.put(overman.getCharId(), overman);

    }


    /**
     * 增加一个师徒关系
     *
     * @param overman  师傅
     * @param lowerman 徒弟
     */
    public boolean createOverman(Human overman, Human lowerman) {
        long overmancharid = overman.getCharId();
        long lowermancharid = lowerman.getCharId();
        if (overman.getLevel() < Globals.getGameConstants().getOverman_min_overman_level()) {
            sendErrorMessage(overman, lowerman, LangConstants.OVERMAN_MIN_OVERMAN_LEVEL); //师傅等级需要大于65级
            return false;
        }

        if (lowerman.getLevel() < Globals.getGameConstants().getOverman_min_lowerman_level() || lowerman.getLevel() > Globals.getGameConstants().getOverman_max_lowerman_level()) { //徒弟等级在[20,50]这个区间内
            sendErrorMessage(overman, lowerman, LangConstants.OVERMAN_LOWERMAN_LEVEL_NOT_IN_RANGE);
            return false;
        }
        if (allOvermanMember.containsKey(lowermancharid) && allOvermanMember.get(lowermancharid) == OvermanDef.OVERMANTYPE.LOWERMAN) {
            sendErrorMessage(overman, lowerman, LangConstants.OVERMAN_LOWERMAN_HAD_OVERMAN); //徒弟当前师傅
            return false;
        }
        if (allOvermanMember.containsKey(overmancharid) && allOvermanMember.get(overmancharid) == OvermanDef.OVERMANTYPE.LOWERMAN) {
            sendErrorMessage(overman, lowerman, LangConstants.OVERMAN_IS_LOWERMAN); //未出师的徒弟不允许收徒
            return false;
        }
        
        Overman o = allOverman.get(overmancharid);

        if (o != null) {
            List<LowermanInfo> lo = o.getLowermans();
            if (lo.size() > Globals.getGameConstants().getOverman_max_lowerman_count()) {
                sendErrorMessage(overman, lowerman, LangConstants.OVERMAN_MAX_LOWERMAN_COUNT); //师傅的徒弟已经超过了3个
                return false;
            }
            for (LowermanInfo info : lo) {
            	//当前时间  < 解除时间(已加24小时后的时间)
				if(Globals.getTimeService().now() < info.getDeleteTime()){
					sendErrorMessage(overman, lowerman, LangConstants.OVERMAN_IN_FORCE_FIRE);
		            return false;
				}
			}
        }
        if (o != null) {
            o.addNewLowerman(lowermancharid);
        } else {
            o = createOverman(overmancharid, lowermancharid);
        }
        addOverman(o);
        sendReward(Globals.getGameConstants().getOverman_overman_reward(), overman);
        sendReward(Globals.getGameConstants().getOverman_lowerman_reward(), lowerman);
        Globals.getTitleService().updateLowermanTitle(lowermancharid); //徒弟给称号
        sendCurOvermanMsg(lowerman);
        sendCurOvermanMsg(overman);
        overman.sendSystemMessage(LangConstants.OVERMAN_OVERMAN_SUCCESS);
        lowerman.sendSystemMessage(LangConstants.OVERMAN_LOWERMAN_SUCCESS);
        Globals.getLogService().sendOvermanLog(overman, LogReasons.OvermanLogReason.OVERMAN, "", overmancharid, lowermancharid, LogReasons.OvermanLogReason.OVERMAN.getReason());
        return true;
    }

    protected void sendErrorMessage(Human human, Human lowerman, int error) {
        human.sendErrorMessage(error);
        lowerman.sendErrorMessage(error);
    }

    protected Overman createOverman(Long overmancharId, Long lowermancharId) {
        Overman overman = new Overman();
        overman.setDbId(overmancharId);
        overman.addNewLowerman(lowermancharId);
        overman.activate();
        overman.setModified();
        return overman;
    }


    /**
     * 是否是徒弟
     *
     * @param lowermancharid
     * @return
     */
    protected boolean isLowerman(long lowermancharid) {
        if (!allOvermanMember.containsKey(lowermancharid)) {
            return false;
        }
        if(!allLowerman.containsKey(lowermancharid)){
            return false;
        }
        long overmancharId = allLowerman.get(lowermancharid);
        Overman o = allOverman.get(overmancharId);
        if (o == null) {
            return false;
        }
        return o.isLowerman(lowermancharid, true);
    }

    /**
     * 出师 ,有徒弟的奖励
     *
     * @param overman
     * @param lowerman
     * @return
     */
    public boolean fireOverman(Human overman, Human lowerman) {
        Long overmanCharId = overman.getCharId();
        Long lowermanCharId = lowerman.getCharId();
        if (!checkOvermaninfo(overmanCharId, lowermanCharId)) {
            sendErrorMessage(overman, lowerman, LangConstants.OVERMAN_NOT_OVERMAN);
            return false;
        }
        if (lowerman.getLevel() < Globals.getGameConstants().getOverman_over_lowerman()) {
            sendErrorMessage(overman, lowerman, LangConstants.OVERMAN_OVER_LOWERMAN);
            return false;
        }
        fireOvermanNow(overmanCharId, lowermanCharId);
        sendReward(Globals.getGameConstants().getOverman_finish_lowerman_reward(), lowerman);
        sendCurOvermanMsg(overman);
        sendCurOvermanMsg(lowerman);
        overman.sendSystemMessage(LangConstants.OVERMAN_FIRE_OVERMAN_SUCCESS);
        lowerman.sendSystemMessage(LangConstants.OVERMAN_FIRE_OVERMAN_SUCCESS);
        Globals.getTitleService().updateLowermanTitle(lowermanCharId);
        Globals.getLogService().sendOvermanLog(overman, LogReasons.OvermanLogReason.FIRE_OVERMAN, "", overmanCharId, lowermanCharId, LogReasons.OvermanLogReason.FIRE_OVERMAN.getReason());
        return true;
    }

    protected void sendReward(int rewardid, Human human) {
        Reward reward = Globals.getRewardService().createReward(
                human.getCharId(),
                rewardid,
                "human gain overman reward!  petId="
                        + human.getUUID() + ",vitalityNum=1 ,rewardId="
                        + rewardid);
        Globals.getRewardService().giveReward(human, reward, true);
    }

    /**
     * 延时解除师徒关系,没有奖励
     *
     * @param overmanCharId
     * @param lowermanCharId
     * @return
     */
    public boolean fireovermandelayed(long overmanCharId, long lowermanCharId) {
        Overman o = allOverman.get(overmanCharId);
        if (o == null) {
            return false;
        }
        o.fireLowerinfodelayed(lowermanCharId);
        needCheckOverman.add(overmanCharId); //需要定期的处理
        return true;
    }

    /**
     * 解除关系,不做时间限制
     *
     * @param overmanCharId
     * @param lowermanCharId
     */
    protected void fireOvermanNow(long overmanCharId, long lowermanCharId) {
        Overman o = allOverman.get(overmanCharId);
        o.fireLowerinfo(lowermanCharId);
        allOvermanMember.remove(lowermanCharId);
        allLowerman.remove(lowermanCharId); //删除徒弟char
        int alllowermancount = o.getLowermenCount();
        if (alllowermancount == 0) //没有徒弟了,删除所有的关系
        {
            allOvermanMember.remove(overmanCharId);
            allOverman.remove(overmanCharId); //删除师傅char
            o.Delete();
        }
    }

    /**
     * 强制解除师傅的关系
     * 徒弟发起,强制解除师傅
     * 放入定时任务中,过期自动删除
     *
     * @param lowermanHuman
     * @return
     */
    public boolean forceFireOverman(Human lowermanHuman) {
        Long lowermanCharId = lowermanHuman.getCharId();
        if ((!(allOvermanMember.containsKey(lowermanCharId) && allOvermanMember.get(lowermanCharId) == OvermanDef.OVERMANTYPE.LOWERMAN))) {
            lowermanHuman.sendErrorMessage(LangConstants.OVERMAN_FORCE_FIRE_OVERMAN_NOT_LOWERMAN);
            return false;
        }
        Long overmanCharId = allLowerman.get(lowermanCharId); // 根据徒弟找到师傅
        Overman o = allOverman.get(overmanCharId);
        if (o == null) {
            return false;
        }
        //判断是否在强制接触状态中
        if (checkInForceFire(overmanCharId, lowermanCharId)) {
            lowermanHuman.sendErrorMessage(LangConstants.OVERMAN_IN_FORCE_FIRE);
            return false;

        }
        if (!lowermanHuman.costMoney(Globals.getGameConstants().getOverman_current_force_fire_currency_number(), CURRENT_FORCE_FIRE_CURRENCY_TYPE, true, 0, LogReasons.MoneyLogReason.FORCE_FIRE_OVERMAN, LogReasons.MoneyLogReason.FORCE_FIRE_OVERMAN.getReasonText(), 0)) {
            //金币扣除失败
            lowermanHuman.sendErrorMessage(LangConstants.OVERMAN_NOT_ENOUGH_CURRENT);
            return false;
        }
        fireovermandelayed(o.getCharId(), lowermanCharId); //解除关系
        sendCurOvermanMsg(overmanCharId);
        sendCurOvermanMsg(lowermanHuman);
        lowermanHuman.sendSystemMessage(LangConstants.OVERMAN_FORCE_FIRE_OVERMAN_SUCCESS);
        Globals.getTitleService().updateLowermanTitle(lowermanCharId);
        Globals.getMailService().sendSysMail(overmanCharId, MailDef.MailType.SYSTEM, Globals.getLangService().readSysLang(LangConstants.OVERMAN_FORCE_OVERMAN_MAIL_TITLE), MessageFormat.format(Globals.getLangService().readSysLang(LangConstants.OVERMAN_FORCE_OVERMAN_MAIL_CONTENT), lowermanHuman.getName()), null);
        Globals.getLogService().sendOvermanLog(lowermanHuman, LogReasons.OvermanLogReason.FORCE_FIRE_LOWERMAN, "", overmanCharId, lowermanCharId, LogReasons.OvermanLogReason.FORCE_FIRE_LOWERMAN.getReason());
        return true;
    }

    /**
     * 强制接触徒弟的关系
     *
     * @param overmanHuman
     * @param lowermanCharId
     * @return
     */
    public boolean forceFireLowerman(Human overmanHuman, long lowermanCharId) {
        long overmanCharId = overmanHuman.getCharId();
        if (!checkOvermaninfo(overmanCharId, lowermanCharId)) {
            overmanHuman.sendErrorMessage(LangConstants.OVERMAN_NOT_OVERMAN);
            return false;
        }
        //判断是否在强制接触状态中
        if (checkInForceFire(overmanCharId, lowermanCharId)) {
            overmanHuman.sendErrorMessage(LangConstants.OVERMAN_IN_FORCE_FIRE);
            return false;

        }
        if (!overmanHuman.costMoney(Globals.getGameConstants().getOverman_current_force_fire_currency_number(), CURRENT_FORCE_FIRE_CURRENCY_TYPE, true, 0, LogReasons.MoneyLogReason.FORCE_FIRE_OVERMAN, LogReasons.MoneyLogReason.COST_GOLD_BY_RECAST_EQUIP.getReasonText(), 0)) {
            //金币扣除失败
            overmanHuman.sendErrorMessage(LangConstants.OVERMAN_NOT_ENOUGH_CURRENT);
            return false;
        }
        fireovermandelayed(overmanCharId, lowermanCharId); //延迟解除关系
        sendCurOvermanMsg(overmanHuman);
        sendCurOvermanMsg(lowermanCharId);
        Globals.getTitleService().updateLowermanTitle(lowermanCharId);
        overmanHuman.sendSystemMessage(LangConstants.OVERMAN_FORCE_FIRE_OVERMAN_SUCCESS);
        Globals.getMailService().sendSysMail(lowermanCharId, MailDef.MailType.SYSTEM, Globals.getLangService().readSysLang(LangConstants.OVERMAN_FORCE_OVERMAN_MAIL_TITLE), MessageFormat.format(Globals.getLangService().readSysLang(LangConstants.OVERMAN_FORCE_OVERMAN_MAIL_CONTENT), overmanHuman.getName()), null);
        Globals.getLogService().sendOvermanLog(overmanHuman, LogReasons.OvermanLogReason.FORCE_FIRE_OVERMAN, "", overmanCharId, lowermanCharId, LogReasons.OvermanLogReason.FORCE_FIRE_OVERMAN.getReason());
        return true;
    }

    /**
     * 组队解除师徒关系
     *
     * @param overmanHuman
     * @param lowermanHuman
     * @return
     */
    public boolean forceTeamFire(Human overmanHuman, Human lowermanHuman) {
        long overmanCharId = overmanHuman.getCharId();
        long lowermanCharId = lowermanHuman.getCharId();
        if (!checkOvermaninfo(overmanCharId, lowermanCharId)) {
            overmanHuman.sendErrorMessage(LangConstants.OVERMAN_NOT_OVERMAN);
            return false;
        }
        //判断是否在强制接触状态中
        if (checkInForceFire(overmanCharId, lowermanCharId)) {
            overmanHuman.sendErrorMessage(LangConstants.OVERMAN_IN_FORCE_FIRE);
            return false;
        }
        fireovermandelayed(overmanCharId, lowermanCharId); //延迟解除关系
        overmanHuman.sendSystemMessage(LangConstants.OVERMAN_FORCE_FIRE_OVERMAN_SUCCESS);
        lowermanHuman.sendSystemMessage(LangConstants.OVERMAN_FORCE_FIRE_OVERMAN_SUCCESS);
        sendCurOvermanMsg(overmanHuman);
        sendCurOvermanMsg(lowermanHuman);
        Globals.getTitleService().updateLowermanTitle(lowermanCharId);
        Globals.getMailService().sendSysMail(lowermanCharId, MailDef.MailType.SYSTEM, Globals.getLangService().readSysLang(LangConstants.OVERMAN_FORCE_OVERMAN_MAIL_TITLE), MessageFormat.format(Globals.getLangService().readSysLang(LangConstants.OVERMAN_FORCE_OVERMAN_MAIL_CONTENT), overmanHuman.getName()), null);
        Globals.getMailService().sendSysMail(overmanCharId, MailDef.MailType.SYSTEM, Globals.getLangService().readSysLang(LangConstants.OVERMAN_FORCE_OVERMAN_MAIL_TITLE), MessageFormat.format(Globals.getLangService().readSysLang(LangConstants.OVERMAN_FORCE_OVERMAN_MAIL_CONTENT), overmanHuman.getName()), null);
        Globals.getLogService().sendOvermanLog(overmanHuman, LogReasons.OvermanLogReason.FORCE_FIRE_TEMA, "", overmanCharId, lowermanCharId, LogReasons.OvermanLogReason.FORCE_FIRE_TEMA.getReason());
        return true;
    }

    protected boolean checkInForceFire(long overmanCharId, long lowermanCharId) {
        Overman o = allOverman.get(overmanCharId);
        if (o != null && o.getLowermanInfo(lowermanCharId).getDeleteTime() > 0) {
            return true;
        }
        return false;
    }


    /**
     * 判断2个人是否是师徒关系
     *
     * @param overmanCharId
     * @param lowermanCharId
     * @return
     */
    public boolean checkOvermaninfo(long overmanCharId, long lowermanCharId) {

        if (allOverman.containsKey(overmanCharId)) {
            Overman o = allOverman.get(overmanCharId);
            if (o != null && o.isLowerman(lowermanCharId, true)) {
                return true;
            }
        }
        return false;
    }

    /**
     * 获取师傅的奖励列表
     *
     * @return
     */
    public List<OvermanRewardInfo> getOvermanRewardList(Human owermanHuman, long lowermancharId) {
        List<OvermanRewardInfo> overmanRewardInfoList = Lists.newArrayList();
        long overmanCharId = owermanHuman.getCharId();
        if (!checkOvermaninfo(overmanCharId, lowermancharId)) {
            owermanHuman.sendErrorMessage(LangConstants.NOT_OVERMAN_INFO);
            return overmanRewardInfoList;
        }
        if (checkInForceFire(owermanHuman.getCharId(), lowermancharId)) {
            owermanHuman.sendErrorMessage(LangConstants.OVERMAN_FORCE_FIRE_OVERMAN_INCD);
            return overmanRewardInfoList;
        }
        Overman o = allOverman.get(overmanCharId);

        int lowermanlevel = Globals.getOfflineDataService().getUserLevel(lowermancharId);
        if(Globals.getOnlinePlayerService().getPlayer(lowermancharId)!=null){
            lowermanlevel = Globals.getOnlinePlayerService().getPlayer(lowermancharId).getHuman().getLevel();
        }
        OvermanDef.OVERMAN_REWARD[] allreward = OvermanDef.OVERMAN_REWARD.values();
        for (int i = 0; i < allreward.length; i++) {
            Integer overtemplateid = allreward[i].getIndex();
            OvermanTemplate overmanTemplate = Globals.getTemplateCacheService().get(overtemplateid, OvermanTemplate.class);
            if (lowermanlevel >= overmanTemplate.getLevel()) {
                OvermanRewardInfo r = new OvermanRewardInfo();
                r.setIndex(overtemplateid);
                r.setHadget(o.getOvermanRewardByLowermanIndex(lowermancharId, overtemplateid));
                overmanRewardInfoList.add(r);
            }
        }
        return overmanRewardInfoList;
    }


    /**
     * 师傅领取奖励
     */
    public void addOvermanReward(Human overmanHuman, long lowermancharId, int rewardId) {
        long overmancharId = overmanHuman.getCharId();
        if (!checkOvermaninfo(overmancharId, lowermancharId)) {
            overmanHuman.sendErrorMessage(LangConstants.OVERMAN_NOT_OVERMAN);
            return;
        }
        if (checkInForceFire(overmanHuman.getCharId(), lowermancharId)) {
            overmanHuman.sendErrorMessage(LangConstants.OVERMAN_FORCE_FIRE_OVERMAN_INCD);
            return;
        }
        Overman o = allOverman.get(overmancharId);
        if (o == null) {
            return;
        }

        if (HAD_GET_REWARD == o.getOvermanRewardByLowermanIndex(lowermancharId, rewardId)) {
            overmanHuman.sendErrorMessage(LangConstants.OVERMAN_HAD_GET_REWARD);
            return;
        }
        int lowermanlevel = Globals.getOfflineDataService().getUserLevel(lowermancharId);
        OvermanTemplate otemplate = Globals.getTemplateCacheService().get(rewardId, OvermanTemplate.class);
        if (otemplate == null) {
            return;
        }
        if (lowermanlevel < otemplate.getLevel()) {
            overmanHuman.sendErrorMessage(LangConstants.OVERMAN_LOWERMAN_LEVEL_IS_LOWER);
            return;
        }
        if (!o.addOvermanReward(lowermancharId, rewardId)) {
            return;
        }
        sendReward(otemplate.getOvermanReward(), overmanHuman);
        sendCurOvermanHongDianMsg(overmanHuman);
    }

    /**
     * 获取徒弟的奖励信息
     * 只发送符合等级的
     *
     * @param lowermanHuman
     * @return
     */
    public List<OvermanRewardInfo> getLowermanRewardList(Human lowermanHuman) {

        List<OvermanRewardInfo> lowermanRewardInfoList = Lists.newArrayList();
        long lowermancharId = lowermanHuman.getCharId();
        if (!isLowerman(lowermancharId)) {
            lowermanHuman.sendErrorMessage(LangConstants.OVERMAN_NOT_LOVERMAN);
            return lowermanRewardInfoList;
        }
        long overmanCharId = allLowerman.get(lowermancharId);
        Overman o = allOverman.get(overmanCharId);
        int lowermanlevel = lowermanHuman.getLevel();
        OvermanDef.OVERMAN_REWARD[] allreward = OvermanDef.OVERMAN_REWARD.values();
        for (int i = 0; i < allreward.length; i++) {
            Integer overtemplateid = allreward[i].getIndex();
            OvermanTemplate overmanTemplate = Globals.getTemplateCacheService().get(overtemplateid, OvermanTemplate.class);
            if (lowermanlevel >= overmanTemplate.getLevel()) {
                OvermanRewardInfo r = new OvermanRewardInfo();
                r.setIndex(overtemplateid);
                r.setHadget(o.getLowermanRewardByIndex(lowermancharId, overtemplateid));
                lowermanRewardInfoList.add(r);
            }
        }
        return lowermanRewardInfoList;
    }

    /**
     * 徒弟领取奖励
     *
     * @param rewardId
     */
    public void addLowermanReward(Human lowermanhuman, int rewardId) {

        long lowermancharId = lowermanhuman.getCharId();
        if (!isLowerman(lowermancharId)) {
            lowermanhuman.sendErrorMessage(LangConstants.OVERMAN_NOT_LOVERMAN);
            return;
        }

        long overmanCharId = allLowerman.get(lowermancharId);
        Overman o = allOverman.get(overmanCharId);
        if (HAD_GET_REWARD == o.getLowermanRewardByIndex(lowermancharId, rewardId)) {
            lowermanhuman.sendErrorMessage(LangConstants.OVERMAN_HAD_GET_REWARD);
            return;
        }
        int lowermanlevel = lowermanhuman.getLevel();

        OvermanTemplate otemplate = Globals.getTemplateCacheService().get(rewardId, OvermanTemplate.class);
        if (otemplate == null) {
            return;
        }
        if (lowermanlevel < otemplate.getLevel()) {
            lowermanhuman.sendErrorMessage(LangConstants.OVERMAN_LOWERMAN_LEVEL_IS_LOWER);
            return;
        }
        if (!o.addLowermanReward(lowermancharId, rewardId)) {
            return;
        }
        sendReward(otemplate.getLowermanReward(), lowermanhuman);
        sendCurLowermanHongDianMsg(lowermanhuman);
    }

    /**
     * 心跳检查
     */
    public void checkOvermanhartbeat() {
        Iterator<Long> it = needCheckOverman.iterator();
        while (it.hasNext()) {
            Long overmanid = it.next();
            updateoverman(overmanid);
        }
    }

    /**
     * 更新overman
     *
     * @param overmanid
     */
    protected void updateoverman(Long overmanid) {
        Overman o = allOverman.get(overmanid);
        if (o == null) {
            return;
        }
        List<LowermanInfo> lowermanList = o.getLowermans();
        for (int i = 0; i < lowermanList.size(); i++) {
            LowermanInfo l = lowermanList.get(i);
            if (l.getDeleteTime() > 0 && Globals.getTimeService().now() > l.getDeleteTime()) {
                o.fireLowerinfo(l.getUuid());
            }
            allOvermanMember.remove(l.getUuid());
            allLowerman.remove(l.getUuid()); //删除徒弟char
            int count = o.getLowermenCount();
            if (count == 0) //没有徒弟了,删除所有的关系
            {
                allOvermanMember.remove(overmanid);
                allOverman.remove(overmanid); //删除师傅char
                o.Delete();
            }
        }

    }

    public OvermanDef.OVERMANTYPE getOvermanType(long charId) {
        return allOvermanMember.get(charId);
    }

    /**
     * 判断是否是有效的师傅状态
     *
     * @param humanCharId
     * @return
     */
    public boolean isNormalOverman(long humanCharId) {
        if (allOverman.containsKey(humanCharId)) {
            Overman o = allOverman.get(humanCharId);
            List<LowermanInfo> ol = o.getLowermans();
            for (LowermanInfo l : ol) {
                if (l.getDeleteTime() == 0) {
                    return true;
                }
            }
        }
        return false;
    }

    /**
     * 判断徒弟是否在有效的徒弟状态中
     *
     * @param humanCharId
     * @return
     */
    public boolean isNormalLowerman(long humanCharId) {
        if (allLowerman.containsKey(humanCharId)) {
            long overmancharid = allLowerman.get(humanCharId);
            Overman o = allOverman.get(overmancharid);
            if (o == null) {
                return false;
            }
            LowermanInfo l = o.getLowermanInfo(humanCharId);
            if (l.getDeleteTime() == 0) {
                return true;
            }
        }
        return false;
    }

    public Overman getOverman(long humanCharId) {
        if (isNormalOverman(humanCharId)) {
            return allOverman.get(humanCharId);
        }
        if (isNormalLowerman(humanCharId)) {
            return allOverman.get(allLowerman.get(humanCharId));
        }
        return null;
    }

    public void sendCurOvermanMsg(long charid) {
        Player p = Globals.getOnlinePlayerService().getPlayer(charid);
        if (p == null) {
            return;
        }
        Human human = p.getHuman();
        if (human == null) {
            return;
        }
        sendCurOvermanMsg(human);
    }

    /**
     * 玩家登录的时候主动推送给玩家的
     *
     * @param human
     */
    public void sendCurOvermanMsg(Human human) {
        Overman o = getOverman(human.getCharId());
        //没有师傅,返回空的师徒消息
        if (o == null) {
            sendNullOvermanMsg(human);
            return;
        }
        List<LowermanInfo> tl = o.getNormalLowermans();
        //没有徒弟,返回空的师徒消息
        if (tl.size() == 0) {
            sendNullOvermanMsg(human);
        }
        //从离线中取得师徒各自的信息
        long overmancharid = o.getCharId();
        UserSnap overmansnap = Globals.getOfflineDataService().getUserSnap(overmancharid);
        //获得徒弟列表
        LowermanInfo[] l = buildLowermanArray(o, tl, overmansnap);
        //构造师徒消息
        GCOvermanInfo gc = new GCOvermanInfo(o.getCharId(), overmansnap.getName(), overmansnap.getHumanTplId(),
        		isOnline(o.getCharId()), l);
        //给在线的徒弟发送消息
        for (LowermanInfo lowermanInfo : l) {
        	if (isOnline(lowermanInfo.getUuid())) {
				Player p = Globals.getOnlinePlayerService().getPlayer(lowermanInfo.getUuid());
				if (p != null && p.getHuman() != null) {
					p.sendMessage(gc);
				}
			}
		}
        
        //给在线的师傅发送消息
        Player p =Globals.getOnlinePlayerService().getPlayer(overmancharid);
        if(p == null || p.getHuman() == null){
        	return;
        }
        p.getHuman().sendMessage(gc);
    }

    /**
     * 构造徒弟列表信息
     * @param o
     * @param tl
     * @param overmansnap
     * @param l
     */
	public LowermanInfo[] buildLowermanArray(Overman o, List<LowermanInfo> tl, UserSnap overmansnap) {
		 LowermanInfo[] l = new LowermanInfo[tl.size()];
		for (int i = 0; i < tl.size(); i++) {
            LowermanInfo linfo = tl.get(i);
            long uuid = linfo.getUuid();
            UserSnap usnap = Globals.getOfflineDataService().getUserSnap(uuid);
            linfo.setFightPower(usnap.getPsManager().getLeader().getFightPower());
            linfo.setHumanName(usnap.getName());
            linfo.setLevel(usnap.getLevel());
            linfo.setTemplateId(usnap.getHumanTplId());
            linfo.setIsOnline(isOnline(uuid));
            l[i] = linfo;
        }
		return l;
	}
    
    /**
     * 判断师傅或徒弟是否在线
     * @param uuid
     * @return
     */
	public boolean isOnline(long uuid) {
		return Globals.getOnlinePlayerService().getPlayer(uuid) != null ? true : false;
	}

    public void sendCurHongDian(Human human) {
        if (isNormalOverman(human.getCharId())) {
            this.sendCurOvermanHongDianMsg(human);
        } else if (isNormalLowerman(human.getCharId())) {
            this.sendCurLowermanHongDianMsg(human);
        }
    }

    protected void sendCurLowermanHongDianMsg(Human human) {
        if (human == null) {
            return;
        }
        if (!isNormalLowerman(human.getCharId())) {
            return;
        }
        List<Long> lowermanGetList = Lists.newArrayList(); //需要点红点的徒弟列表
        if(needHongDianOverman(human,0,false)){
            lowermanGetList.add(human.getCharId());
        }
        sendToClient(lowermanGetList, human); // 发送徒弟的

    }

    /**
     * 是否有红点
     *
     * @param human
     */

    protected void sendCurOvermanHongDianMsg(Human human) {

        if (human == null) {
            return;
        }
        long humanCharId = human.getCharId();

        if (!isNormalOverman(humanCharId)) {
            return;
        }
        List<Long> overmanGetList = Lists.newArrayList(); //需要点红点的徒弟列表
        List<LowermanInfo> lowerlists = this.getOverman(humanCharId).getNormalLowermans();
        for (LowermanInfo tl : lowerlists) {
            if (needHongDianOverman(human, tl.getUuid(),true)) {
                overmanGetList.add(tl.getUuid());
            }
        }
        sendToClient(overmanGetList, human); //通知在线的师傅

    }

    protected boolean needHongDianOverman(Human overmanHuman, long lowermanCharid ,boolean isoverman) {
        List<OvermanRewardInfo> lowerRewardInfo = null;
        if(isoverman) {
            lowerRewardInfo =this.getOvermanRewardList(overmanHuman, lowermanCharid);
        }else{
            lowerRewardInfo = this.getLowermanRewardList(overmanHuman);
        }
        for (OvermanRewardInfo lr : lowerRewardInfo) {
            if (lr.getHadget() == 0) {
                return true;
            }
        }
        return false;
    }

    /**
     * @param getList
     * @param human
     */
    protected void sendToClient(List<Long> getList, Human human) {
        long[] l;
        GCOvermanHongdian gc = new GCOvermanHongdian();
        if (!getList.isEmpty()) {
            l = new long[getList.size()];
            for (int i = 0; i < getList.size(); i++) {
                l[i] = getList.get(i);
            }
        } else {
            l = new long[1];
            l[0] = 0;
        }
        gc.setRewardInfo(l);
        human.sendMessage(gc);
    }

    protected void sendNullOvermanMsg(Human human) {
        LowermanInfo[] l = new LowermanInfo[0];
        GCOvermanInfo gc = new GCOvermanInfo(0, "", 0, false, l);
        human.sendMessage(gc);
    }

    public void addFireOvermanTeamInfo(int id, long overmanCharId, long lowermanCharId) {
        tempFireOvermanList.put(id, new TempFireOvermanInfo(overmanCharId, lowermanCharId));
    }

    /**
     * 解除师徒关系
     *
     * @param id
     * @param overmanHuman
     * @param lowermanHuman
     * @param overmancanagree
     * @param lowermancanagree
     */
    public void TeamFireOverman(int id, Human overmanHuman, Human lowermanHuman, int overmancanagree, int lowermancanagree) {
        if (!tempFireOvermanList.containsKey(id)) {
            sendErrorMessage(overmanHuman, lowermanHuman, LangConstants.OVERMAN_NOT_TEAM);
            return;
        }
        TempFireOvermanInfo tempFireOvermanInfo = tempFireOvermanList.get(id);
        if (overmancanagree >= 0) {
            tempFireOvermanInfo.setOvermanAgree(overmancanagree);
        }
        if (lowermancanagree >= 0) {
            tempFireOvermanInfo.setLowermanAgree(lowermancanagree);
        }
        if (tempFireOvermanInfo.needreturn()) {
            tempFireOvermanList.remove(id);
        } else {
            return;
        }
        if (!tempFireOvermanInfo.bothcanagree()) {
            sendErrorMessage(overmanHuman, lowermanHuman, LangConstants.OVERMAN_OVERMAN_LOWERNAM_NOT_APPLY_OVERMAN);
            return;
        }
        forceTeamFire(overmanHuman, lowermanHuman);

    }

    public void sendCurOvermanReward(Human human, long lowermanCharId) {
        List<OvermanRewardInfo> overmanRewardList = Globals.getOvermanService().getOvermanRewardList(human, lowermanCharId);
        OvermanRewardInfo[] o = new OvermanRewardInfo[overmanRewardList.size()];
        GCGetOvermanReward gc = new GCGetOvermanReward(lowermanCharId, overmanRewardList.toArray(o));
        human.sendMessage(gc);
    }

    public void sendCurLowermanReward(Human lowermanHuman) {
        List<OvermanRewardInfo> lowermanRewardList = Globals.getOvermanService().getLowermanRewardList(lowermanHuman);
        OvermanRewardInfo[] o = new OvermanRewardInfo[lowermanRewardList.size()];
        GCGetLowermanReward gc = new GCGetLowermanReward(lowermanRewardList.toArray(o));
        lowermanHuman.sendMessage(gc);
    }

    public String getOvermanName(long charId) {
        if (!allLowerman.containsKey(charId)) {
            return "";
        }
        long overmancharId = allLowerman.get(charId);
        return Globals.getOfflineDataService().getUserName(overmancharId);
    }

    /**
     * 徒弟升级的时候刷新红点,师傅升级不需要判断
     * @param human
     */
    public void onLevelUp(Human human) {
        if (!isNormalLowerman(human.getCharId())) {
            return;
        }
        sendCurLowermanHongDianMsg(human);
        Player p = Globals.getOnlinePlayerService().getPlayer(allLowerman.get(human.getCharId()));
        if (p == null) {
            return;
        }
        sendCurOvermanHongDianMsg(p.getHuman());
    }

}
