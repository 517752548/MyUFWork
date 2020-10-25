package com.imop.lj.gameserver.marry;

import java.text.MessageFormat;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.LogReasons;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.NoticeTypes;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.db.model.MarryEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.mail.MailDef;
import com.imop.lj.gameserver.marry.msg.GCMarryInfo;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;

public class MarryService {

    protected Map<Long, Marry> allMarry = Maps.newHashMap();
    protected List<Long> needCheckMarry = Lists.newArrayList();
    protected Map<Integer, TempCanMarry> tempMarry = Maps.newHashMap(); //临时储存是否组队结婚,离婚信息

    public void init() {
        List<MarryEntity> marrylist = Globals.getDaoService().getMarryDao().getAllMarry();
        if (marrylist == null || marrylist.isEmpty()) {
            if (Loggers.marryLogger.isDebugEnabled()) {
                Loggers.marryLogger.debug("MarryService init() : marrrylist size = 0");
            }
        }
        for (MarryEntity marryEntity : marrylist) {
            Marry marry = new Marry();
            marry.fromEntity(marryEntity);
            marry.getLifeCycle().activate();
            allMarry.put(marry.getDbId(), marry);
            allMarry.put(marry.getCharId(), marry);
            checkMarry(marry);
        }
        
        //奖励检查
        int rewardId = Globals.getGameConstants().getMarryRewardId();
        RewardConfigTemplate rewardTpl = Globals.getTemplateCacheService().get(rewardId, RewardConfigTemplate.class);
        if (null == rewardTpl) {
        	throw new TemplateConfigException("", 0, String.format("结婚奖励Id不存在[%d]", rewardId));
        }
        //奖励类型检查
        if (rewardTpl.getRewardReasonType() != RewardReasonType.MARRY_REWARD) {
        	throw new TemplateConfigException("", 0, String.format("结婚奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
        }
    }

    protected void checkMarry(Marry marry) {
        if (marry.getMarryCorrelationInfo().getFiretime() > 0) {
            needCheckMarry.add(marry.getDbId());
        }
    }

    public void marry(Human husbandHuman, Human wifeHuman) {
        long husbandCharId = husbandHuman.getRoleUUID();
        long wifeCharId = wifeHuman.getRoleUUID();


        if (!checkCanMarry(husbandHuman)) {
            return;
        }
        if (!checkCanMarry(wifeHuman)) {
            return;
        }

        //3.双方为异性
        if (husbandHuman.getSex() == wifeHuman.getSex()) {
            //“结婚双方性别必须是一男一女才能结婚”
            sendErrorMessage(husbandHuman, wifeHuman, LangConstants.MARRY_SEX_DIFFERENT);
            return;
        }

        //4.双方必须是好友（双向的）
        if (!(Globals.getRelationService().isTargetInFriendList(husbandHuman, wifeCharId)
                && Globals.getRelationService().isTargetInFriendList(wifeHuman, husbandCharId))) {
            //“两个人必须是对方的好友”
            sendErrorMessage(husbandHuman, wifeHuman, LangConstants.MARRY_IS_MATEY);
            return;
        }
        //5.双方等级>=40级
        if (!(husbandHuman.getLevel() >= Globals.getGameConstants().getMarryGrade() && wifeHuman.getLevel() >= Globals.getGameConstants().getMarryGrade())) {
            //“结婚双方等级必须>=40级才可结婚”
            sendErrorMessage(husbandHuman, wifeHuman, LangConstants.MARRY_GRADE_FALL_SHORT_OF);
            return;
        }

        //7.扣除结婚费用
        Human needCost = null;
        if(Globals.getTeamService().isTeamLeader(husbandHuman.getCharId())) {
            needCost = husbandHuman;
        }else {
            needCost = wifeHuman;
        }
        if (needCost == null || !needCost.costMoney(Globals.getGameConstants().getMarryCost(), Currency.GOLD, true, 0, LogReasons.MoneyLogReason.MARRY_COST, LogUtils.genReasonText(LogReasons.MoneyLogReason.MARRY_COST), 0)) {
            //游戏币扣除失败
            husbandHuman.sendErrorMessage(LangConstants.LEADER_MARRY_GOLD_LACKING);
            wifeHuman.sendErrorMessage(LangConstants.LEADER_MARRY_GOLD_LACKING);
            return;
        }

        //8.创建夫妻关系
        createMarry(husbandCharId, wifeCharId);
        //9.给结婚礼包 ,丈夫,妻子都发
        sendReward(Globals.getGameConstants().getMarryRewardId(), husbandHuman);
        sendReward(Globals.getGameConstants().getMarryRewardId(), wifeHuman);
        Globals.getTitleService().updateMarryTitle(husbandCharId);
        Globals.getTitleService().updateMarryTitle(wifeCharId);
        sendCurMarryInfo(husbandHuman);
        sendCurMarryInfo(wifeHuman);
        Globals.getNoticeService().sendNotice(NoticeTypes.system, Globals.getLangService().readSysLang(LangConstants.MARRY_SERVER_NOTICE, getSpouseName(wifeCharId), getSpouseName(husbandCharId), (allMarry.size() / 2)));
    }

    /**
     * 同意结婚结婚
     */
    public void wangMarry(int teamid, Human husbandHuman, Human wifeHuman, int husbandAgree, int wifeAgree) {

        if (!tempMarry.containsKey(teamid)) {
            return;
        }
        TempCanMarry tempCanMarry = tempMarry.get(teamid);
        if (husbandAgree >= 0) {
            tempCanMarry.setHusbandAgree(husbandAgree);
        }
        if (wifeAgree >= 0) {
            tempCanMarry.setWifeAgree(wifeAgree);
        }
        if (tempCanMarry.needReturn()) {
            tempMarry.remove(teamid);
        } else {
            return;
        }
        if (!tempCanMarry.bothAgree()) {
            sendErrorMessage(husbandHuman, wifeHuman, LangConstants.MARRY_NOT_AGREE_MARRY);
            return;
        }

        marry(husbandHuman, wifeHuman);
    }

    /**
     * 判断是否能结婚
     *
     * @param leadercharId
     * @param spousecharId
     * @return
     */
    protected Marry createMarry(Long leadercharId, Long spousecharId) {
        Marry marry = new Marry();
        marry.setDbId(leadercharId);
        marry.setCharId(spousecharId);
        marry.addMarryInfo(Globals.getTimeService().now());
        marry.activate();
        marry.setModified();

        allMarry.put(marry.getDbId(), marry);
        allMarry.put(marry.getCharId(), marry);
        return marry;
    }

    protected void sendErrorMessage(Human leaderhuman, Human spousehuman, int error) {
        leaderhuman.sendErrorMessage(error);
        spousehuman.sendErrorMessage(error);
    }

    /**
     * 组队解除婚姻
     *
     * @param husbandHuman
     * @param wifeHuman    canagree -1不做处理 0 不同意 1同意
     */
    public void teamFireMarry(int teamid, Human husbandHuman, Human wifeHuman, int husbandAgree, int wifeAgree) {

        if (!checkIsNormalMarry(husbandHuman.getCharId(), wifeHuman.getCharId())) {
            sendErrorMessage(husbandHuman, wifeHuman, LangConstants.MARRY_BEFORE_SET_UP_TEAM);
            return;
        }
        if (!tempMarry.containsKey(teamid)) {
            return;
        }
        TempCanMarry tempCanMarry = tempMarry.get(teamid);
        if (husbandAgree >= 0) {
            tempCanMarry.setHusbandAgree(husbandAgree);
        }
        if (wifeAgree >= 0) {
            tempCanMarry.setWifeAgree(wifeAgree);
        }
        if (tempCanMarry.needReturn()) {
            tempMarry.remove(teamid);
        } else {
            return;
        }
        if (!tempCanMarry.bothAgree()) {
            sendErrorMessage(husbandHuman, wifeHuman, LangConstants.MARRY_TEAM_FORCE_FIRE_NOT_AGREE);
            return;
        }
        fireMarryDelay(husbandHuman);
        Globals.getTitleService().updateMarryTitle(husbandHuman.getDbId());
        Globals.getTitleService().updateMarryTitle(wifeHuman.getDbId());
        sendCurMarryInfo(husbandHuman);
        sendCurMarryInfo(wifeHuman);

    }


    /**
     * 强制解除婚姻
     *
     * @param human
     */
    public void froceFireMarry(Human human) {
        long humanRoleId = human.getRoleUUID();
        if (!checkCanFire(human)) {
            return;
        }

        //3.扣除强制离婚费用
        if (!human.costMoney(Globals.getGameConstants().getForceFireMarry(), Currency.GOLD, true, 0, LogReasons.MoneyLogReason.FORCE_FIRE_MARRY_COST, LogUtils.genReasonText(LogReasons.MoneyLogReason.FORCE_FIRE_MARRY_COST), 0)) {
            human.sendErrorMessage(LangConstants.FORCE_FIRE_MARRY);
            return;
        }
        //3.离婚
        long otherCharId = getSpouseCharId(human.getCharId());
        fireMarryDelay(humanRoleId);
        Globals.getTitleService().updateMarryTitle(humanRoleId);
        Globals.getTitleService().updateMarryTitle(otherCharId);
        Globals.getMailService().sendSysMail(otherCharId, MailDef.MailType.SYSTEM, Globals.getLangService().readSysLang(LangConstants.FORCE_MARRY_MAIL_TITLE), MessageFormat.format(Globals.getLangService().readSysLang(LangConstants.MARRY_FORCE_MARRY_MAIL_CONTENT), human.getName()), null);
        sendCurMarryInfo(human);
        sendCurMarryInfo(otherCharId);
        String otherName = Globals.getOfflineDataService().getUserName(otherCharId);
        human.sendErrorMessage(MessageFormat.format(Globals.getLangService().readSysLang(LangConstants.MARRY_HAD_FORCE_MARRY),otherName));
    }

    /**
     * 必须是单身
     *
     * @param human
     * @return
     */
    protected boolean checkCanMarry(Human human) {
        MarryDef.MARRYSTATUS humanStatus = getHumanMarryStatus(human.getCharId());
        boolean r = false;
        switch (humanStatus) {
            case MARRY:
                human.sendErrorMessage(LangConstants.MARRY_NEED_TWO_PEOPLE_SINGLEHOOD);
                break;
            case INCD:
                human.sendErrorMessage(LangConstants.MARRY_HUMAN_IN_CD);
                break;
            case ALONE:
                r = true;
                break;
        }
        return r;

    }

    protected boolean checkCanFire(Human human) {
        MarryDef.MARRYSTATUS humanStatus = getHumanMarryStatus(human.getCharId());
        boolean r = false;
        switch (humanStatus) {
            case ALONE:
                human.sendErrorMessage(LangConstants.MARRY_SINGLEHOOD_NOT_DIVORCE);
                break;
            case INCD:
                human.sendErrorMessage(LangConstants.MARRY_HUMAN_IN_CD);
                break;
            case MARRY:
                r = true;
                break;
        }
        return r;
    }

    protected MarryDef.MARRYSTATUS getHumanMarryStatus(long humancharId) {
        if (!allMarry.containsKey(humancharId)) {
            return MarryDef.MARRYSTATUS.ALONE;
        }
        Marry m = allMarry.get(humancharId);
        if (m.isNormalMarry()) {
            return MarryDef.MARRYSTATUS.MARRY;
        } else {
            return MarryDef.MARRYSTATUS.INCD;
        }
    }

//    /**
//     * 有婚姻关系,但处于cd期
//     *
//     * @param humanRoleId
//     * @return
//     */
//    protected boolean checkHumanInCD(long humanRoleId) {
//        Marry m = allMarry.get(humanRoleId);
//        if (m == null) {
//            return false;
//        }
//        if (!m.isNormalMarry()) {
//            return true;
//        }
//        return false;
//    }

    protected long getSpouseCharId(long charId) {
        Marry m = allMarry.get(charId);
        if (m == null) {
            return 0;
        }
        return m.getDbId() == charId ? m.getCharId() : m.getDbId();
    }


    /**
     * 判断是否是结婚
     *
     * @param CharId
     * @return
     */
    public boolean checkIsNormalMarry(long CharId) {
        if (!allMarry.containsKey(CharId)) {
            return false;
        }
        Marry m = allMarry.get(CharId);
        if (m.isNormalMarry()) {
            return true;
        }
        return false;
    }

    /**
     * 判断2个人是否是夫妻关系
     *
     * @param husbandCharId
     * @param wifeCharId
     * @return
     */
    public boolean checkIsNormalMarry(long husbandCharId, long wifeCharId) {
        if (allMarry.containsKey(husbandCharId)) {
            Marry marry = allMarry.get(husbandCharId);
            if ((marry.getCharId() == wifeCharId) && marry.isNormalMarry()) {
                return true;
            }
        }
        return false;
    }

    /**
     * 强制接触婚姻关系
     *
     * @param humanCharId
     * @return
     */
    protected boolean fireMarryDelay(long humanCharId) {
        Marry m = allMarry.get(humanCharId);
        if (m == null) {
            return false;
        }
        m.fireMarryDelay();
        needCheckMarry.add(m.getDbId());
        return true;
    }

    protected boolean fireMarryDelay(Human human) {
        return fireMarryDelay(human.getCharId());
    }

    public void checkMarryhartbeat() {
        Iterator<Long> it = needCheckMarry.iterator();
        while (it.hasNext()) {
            Long marryid = it.next();
            updatemarry(marryid);
        }
    }

    protected void updatemarry(Long leaderid) {
        Marry m = allMarry.get(leaderid);
        if (m == null) {
            allMarry.remove(leaderid);
            return;
        }
        if (m.getFiretime() > 0 && Globals.getTimeService().now() > m.getFiretime()) {
            long leaderCharId = m.getDbId();
            long spouseCharId = m.getCharId();
            m.Delete();
            allMarry.remove(leaderCharId);
            allMarry.remove(spouseCharId);
//            needCheckMarry.remove(leaderid); //删除定时check list
        }

    }

    /**
     * 是否是正式的丈夫
     *
     * @param humanRoleId
     * @return
     */
    public boolean isNormalHusband(long humanRoleId) {
        Marry m = allMarry.get(humanRoleId);
        if (m == null) {
            return false;
        }
        if (m.getDbId() != humanRoleId) {
            return false;
        }
        if (m.getMarryCorrelationInfo().getFiretime() == 0) {
            return true;
        }
        return false;
    }

    /**
     * 是否是正式的妻子
     *
     * @param humanRoleId
     * @return
     */
    public boolean isNormalWife(long humanRoleId) {
        Marry m = allMarry.get(humanRoleId);
        if (m == null) {
            return false;
        }
        if (m.getCharId() != humanRoleId) {
            return false;
        }
        if (m.getMarryCorrelationInfo().getFiretime() == 0) {
            return true;
        }
        return false;
    }

    /**
     * 发送当前的婚姻信息
     *
     * @param human
     */
    public void sendCurMarryInfo(Human human) {
        GCMarryInfo gc = new GCMarryInfo();

        if (!checkIsNormalMarry(human.getCharId()))
        {
            gc.setHusbandName("");
            gc.setWifeName("");
            human.sendMessage(gc);
            return;
        }
        Marry m = allMarry.get(human.getCharId());
        gc.setHusband(m.getDbId());
        gc.setWife(m.getCharId());
        gc.setHusbandName(Globals.getOfflineDataService().getUserName(m.getDbId()));
        gc.setWifeName(Globals.getOfflineDataService().getUserName(m.getCharId()));

        human.sendMessage(gc);
    }

    public void sendCurMarryInfo(long charid) {
        Player p = Globals.getOnlinePlayerService().getPlayer(charid);
        if (p == null) {
            return;
        }
        Human human = p.getHuman();
        if (human == null) {
            return;
        }
        sendCurMarryInfo(human);
    }

    public void addFirstMarry(int id, Long dbId, Long dbId1) {
        tempMarry.put(id, new TempCanMarry(dbId, dbId1));
    }

    public String getSpouseName(long charId) {
        long spouseCharid = this.getSpouseCharId(charId);
        return Globals.getOfflineDataService().getUserName(spouseCharid);
    }


    class TempCanMarry {
//        protected long husbandCharid;
//        protected long wifeCharid;
        protected int husbandAgree;
        protected int wifeAgree;

        public TempCanMarry(long husbandCharid, long wifeCharid) {
//            this.husbandCharid = husbandCharid;
//            this.wifeCharid = wifeCharid;
            this.husbandAgree = -1;
            this.wifeAgree = -1;
        }

        public int getHusbandAgree() {
            return husbandAgree;
        }

        public void setHusbandAgree(int husbandAgree) {
            this.husbandAgree = husbandAgree;
        }

        public int getWifeAgree() {
            return wifeAgree;
        }

        public void setWifeAgree(int wifeAgree) {
            this.wifeAgree = wifeAgree;
        }

        public boolean needReturn() {
            return (this.husbandAgree != -1) && (this.wifeAgree != -1);
        }

        public boolean bothAgree() {
            return (this.husbandAgree == 1) && (this.wifeAgree == 1);
        }
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
}
