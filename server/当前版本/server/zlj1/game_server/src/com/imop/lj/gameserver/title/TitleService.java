package com.imop.lj.gameserver.title;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.db.model.TitleEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.role.properties.RolePropertyManager;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

/**
 * Created by zhangzhe on 15/12/14.
 */
public class TitleService implements InitializeRequired {

    protected final static int NOT_USE_TITLE = 0;
    public Map<Long, Title> allTitle = Maps.newHashMap();
    public List<Long> needUpdateTitle = Lists.newArrayList();

    public void init() {
        List<TitleEntity> allList = Globals.getDaoService().getTitleDao().getAllTitle();
        if (allList == null || allList.isEmpty()) {
            if (Loggers.titleLogger.isDebugEnabled()) {
                Loggers.titleLogger.debug("TitleService init() : allList size = 0");
            }
        }
        for (TitleEntity titleEntity : allList) {
            Title t = new Title(titleEntity.getId());
            t.fromEntity(titleEntity);
            addToCache(t);
        }
    }

    protected void addToCache(Title t) {
        allTitle.put(t.getCharId(), t);
    }


    /**
     * 玩家使用称号
     *
     * @param human
     * @param tplid
     */
    public void useTitle(Human human, int tplid) {
        long charId = human.getCharId();
        if (!allTitle.containsKey(charId)) {
            human.sendErrorMessage(LangConstants.TITLE_NOT_HAVE);
            return;
        }
        Title humanTitle = allTitle.get(charId);
        if (humanTitle.getDisTitle() == Title.NOT_DIS_TITLE) {
            humanTitle.setDisTitle(Title.DIS_TITLE);
        }
        if (humanTitle.getInUseTplid() == tplid) {
            return;
        }
        if (!humanTitle.canUseTitle(tplid)) {
            return;
        }
        TitleInfo tinfo = humanTitle.getTitleInfo(tplid);
        humanTitle.setInUseTplid(tplid);
        human.setTitle(tplid);
        human.setTitleName(tinfo.getTitleName());
        human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_TITLE);
        human.snapChangedProperty(true);
        Globals.getLogService().sendTitleLog(human, LogReasons.TitleLogReason.CHANGE_TITLE, "", tplid + "");
        Globals.getMapService().noticeNearMapInfoChanged(human);

    }

    public Title createTitle(long charid) {
        if (allTitle.containsKey(charid)) {
            allTitle.get(charid);
        }
        Title t = new Title(charid);
        addToCache(t);
        return t;
    }


    public void updateCorpPlayer(long uuid) {
        boolean incorps = Globals.getCorpsService().inCorps(uuid);
        if (!incorps) {
            removeAllCorpTitle(uuid);
        } else {
            changeCorpTilte(uuid, Globals.getCorpsService().getUserCorpsMemberJob(uuid));
        }
    }

    protected void removeAllCorpTitle(long uuid) {

        removeTileByTemplate(uuid, getAllCorpsMemberList());
    }

    protected List<TitleDef.TitleTemplateType> getAllCorpsMemberList() {
        List<TitleDef.TitleTemplateType> titleTemplateTypeList = new ArrayList<TitleDef.TitleTemplateType>();
        titleTemplateTypeList.add(TitleDef.TitleTemplateType.CORPS_MEMBER);
        titleTemplateTypeList.add(TitleDef.TitleTemplateType.CORPS_PRESIDENT);
        titleTemplateTypeList.add(TitleDef.TitleTemplateType.CORPS_VICE_CHAIRMAN);
        titleTemplateTypeList.add(TitleDef.TitleTemplateType.CORPS_ELITE);
        return titleTemplateTypeList;
    }

    protected void removeTileByTemplate(long uuid, List<TitleDef.TitleTemplateType> list) {
        for (TitleDef.TitleTemplateType templatetype : list) {
            removeTitleByTplid(uuid, templatetype.getIndex());
        }
    }

    protected void removeTitleByTplid(long charid, int tplid) {
        if (!allTitle.containsKey(charid)) {
            return;
        }
        allTitle.get(charid).removeTitleInfo(tplid);
    }

    protected void changeCorpTilte(long uuid, CorpsDef.MemberJob userCorpsMemberJob) {
        //不在商会,删除所有的商会称号
        if (userCorpsMemberJob == null || userCorpsMemberJob == CorpsDef.MemberJob.NONE) {
            removeAllCorpTitle(uuid);
            return;
        }
        List<TitleDef.TitleTemplateType> allcorpsmemberlist = getAllCorpsMemberList();
        TitleDef.TitleTemplateType titleTemplateType = TitleDef.TitleTemplateType.CORPS_MEMBER;
        switch (userCorpsMemberJob) {
            case PRESIDENT:
                titleTemplateType = TitleDef.TitleTemplateType.CORPS_PRESIDENT;
                break;
            case VICE_CHAIRMAN:
                titleTemplateType = TitleDef.TitleTemplateType.CORPS_VICE_CHAIRMAN;
                break;
            case ELITE:
                titleTemplateType = TitleDef.TitleTemplateType.CORPS_ELITE;
                break;
        }
        allcorpsmemberlist.remove(titleTemplateType); //和现在商会职位相同的不删除
        removeTileByTemplate(uuid, allcorpsmemberlist); //删除其他的.
        if (!canAddTitleInfo(uuid, titleTemplateType.getIndex())) {
            return;
        }
        addTitleInfo(uuid, titleTemplateType.getIndex());

    }

    public boolean canAddTitleInfo(long charid, int tplid) {
        if (!this.allTitle.containsKey(charid)) {
            createTitle(charid);
        }
        return true;
    }

    /**
     * 给称号
     * @param charid
     * @param tplid
     * @return
     */
    public boolean addTitleInfo(long charid, int tplid) {
        Title t = this.allTitle.get(charid);
        if (t == null) {
            t = createTitle(charid);
        }
        t.addTitleInfo(tplid);

//        Globals.getLogService().sendTitleLog(); TODO 获取离线的human

        return true;
    }


    public void disTitle(Human human, int distitle) {
        long charid = human.getCharId();
        if (!this.allTitle.containsKey(charid)) {
            return;
        }
        Title t = this.allTitle.get(human.getCharId());
        t.setDisTitle(distitle);
        human.setTitleDis(distitle);
        human.snapChangedProperty(true);
    }

    public void updateMarryTitle(long humanRoleId) {
        if (!Globals.getMarryService().checkIsNormalMarry(humanRoleId)) {
            checkTitleForMarryOverman(humanRoleId, false, TitleDef.TitleTemplateType.MARRY_HASBAND);
            checkTitleForMarryOverman(humanRoleId, false, TitleDef.TitleTemplateType.MARRY_WIFE);
            return;
        }
        if (Globals.getMarryService().isNormalHusband(humanRoleId)) {
            checkTitleForMarryOverman(humanRoleId, true, TitleDef.TitleTemplateType.MARRY_HASBAND);
        }
        if (Globals.getMarryService().isNormalWife(humanRoleId)) {
            checkTitleForMarryOverman(humanRoleId, true, TitleDef.TitleTemplateType.MARRY_WIFE);
        }
    }

    public void updateLowermanTitle(long humanCharId) {
        Player p = Globals.getOnlinePlayerService().getPlayer(humanCharId);
        if (p == null) {
            return;
        }

        if (Globals.getOvermanService().isNormalLowerman(humanCharId)) {
            checkTitleForMarryOverman(humanCharId, true, TitleDef.TitleTemplateType.OVERMAN_LOWERMAN);
        } else {
            checkTitleForMarryOverman(humanCharId, false, TitleDef.TitleTemplateType.OVERMAN_LOWERMAN);
        }
    }


    /**
     * 检查师徒 师傅的称号
     *
     * @param charid
     * @param b     增加称号，删除称号
     */
    protected void checkTitleForMarryOverman(long charid, boolean b, TitleDef.TitleTemplateType titletype) {
        TitleInfo tinfo = getTitleInfo(charid, titletype.getIndex());
        if (b) {
            addTitleInfo(charid, titletype.getIndex());
        } else {
            removeTitleByTplid(charid, titletype.getIndex());
        }

    }

    public Title getHumanTitleList(long charId) {
        if (allTitle.containsKey(charId)) {
            return allTitle.get(charId);
        }
        return null;
    }

    public int getCurrentTitle(long charid) {
        if (!allTitle.containsKey(charid)) {
            return NOT_USE_TITLE;
        }
        return allTitle.get(charid).getInUseTplid();
    }

    public TitleInfo getCurrentTitleInfo(long charid) {
        if (!allTitle.containsKey(charid)) {
            return null;
        }
        Title t = allTitle.get(charid);
        return t.getAllTitleInfo().get(t.getInUseTplid());
    }

    public TitleInfo getTitleInfo(long charid, int tplid) {
        if (!allTitle.containsKey(charid)) {
            return null;
        }
        Title t = allTitle.get(charid);
        return t.getAllTitleInfo().get(tplid);
    }

    public String getCurrentTitleName(long charId) {
        String re = "";
        if (!allTitle.containsKey(charId)) {
            return re;
        }
        TitleInfo tinfo = getCurrentTitleInfo(charId);
        if(tinfo == null){
            return re;
        }
        return tinfo.getTitleName();

    }

    public void checkTitle() {
        for (long charid : needUpdateTitle) {
            Title t = this.allTitle.get(charid);
            t.checkTitle();
        }
    }

    public void emptyTitle(long charid) {
        if(!allTitle.containsKey(charid)){
            return;
        }
        Title t = allTitle.get(charid);
        t.setInUseTplid(Title.NOT_TITLE);
        Player player = Globals.getOnlinePlayerService().getPlayer(charid);
        if(player==null){
            return;
        }
        Human human = player.getHuman();
        human.setTitle(NOT_USE_TITLE);
        human.setTitleName("");
        human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_TITLE);
        human.snapChangedProperty(true);
        Globals.getMapService().noticeNearMapInfoChanged(human);
        Globals.getLogService().sendTitleLog(human, LogReasons.TitleLogReason.CHANGE_TITLE, "", "0");
    }
    public void addNeedCheck(long charid){
        this.needUpdateTitle.add(charid);
    }

    public void initHumanTitle(long charId) {
        if(canAddTitleInfo(charId,TitleDef.TitleTemplateType.GAME_PLAYER.getIndex())){
            addTitleInfo(charId,TitleDef.TitleTemplateType.GAME_PLAYER.getIndex());
        }
    }

    public void sendTitleInfo(Human human) {
        long charid = human.getCharId();
        Title t  = allTitle.get(charid);
        if(t == null){
            return ;
        }
        if(t.getInUseTplid()==0){
            return ;
        }
        TitleInfo tinfo = t.getTitleInfo(t.getInUseTplid());
        human.setTitleDis(t.getDisTitle());
        human.setTitle(tinfo.getTemplateId());
        human.setTitleName(tinfo.getTitleName());
//        human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_TITLE);
        human.snapChangedProperty(true);
        Globals.getMapService().noticeNearMapInfoChanged(human);

    }
}
