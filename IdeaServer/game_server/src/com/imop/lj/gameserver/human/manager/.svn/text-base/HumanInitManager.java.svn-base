package com.imop.lj.gameserver.human.manager;

import java.awt.Point;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.LoginTypeEnum;
import com.imop.lj.db.model.HumanEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.HumanPropAttr;
import com.imop.lj.gameserver.human.msg.GCCreateTime;
import com.imop.lj.gameserver.human.msg.GCHumanCdQueueUpdate;
import com.imop.lj.gameserver.human.msg.GCLoginDays;
import com.imop.lj.gameserver.item.Inventory;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.PetDef.PetState;
import com.imop.lj.gameserver.pet.PetMessageBuilder;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.PlayerState;
import com.imop.lj.gameserver.player.msg.GCSceneInfo;
import com.imop.lj.gameserver.role.properties.RoleBaseStrProperties;
import com.imop.lj.gameserver.util.MapUtil;
import com.imop.lj.probe.PIProbeCollector;
import com.imop.lj.probe.PIProbeConstants.ProbeName;
import com.opi.gibp.probe.category.user.UsersExt;

import net.sf.json.JSONObject;

public class HumanInitManager {

    private Human human;

    public HumanInitManager(Human human) {
        super();
        this.human = human;
    }

    /**
     * 加载玩家角色基本信息
     *
     * @param entity
     */
    public void loadHuman(HumanEntity entity) {
        human.setDbId(entity.getId());
        human.setInDb(true);
        human.setName(entity.getName());
        human.setCreateTime(entity.getCreateTime() == null ? Globals.getTimeService().now() : entity.getCreateTime().getTime());

        human.setBond(entity.getBond());
        human.setSysBond(entity.getSysBond());
        human.setGiftBond(entity.getGiftBond());
        human.setGold(entity.getGold());
        human.setGold2(entity.getGold2());
        human.setGuaJiPoint(entity.getGuaJiPoint());
        human.setGuaJiPoint2(entity.getGuaJiPoint2());
//		human.setBlueHufu(entity.getBlueHufu());
//		human.setPurpleHufu(entity.getPurpleHufu());
//		human.setGoldedHufu(entity.getGoldenHufu());
        human.setHonor(entity.getHonor());
//		human.setSoul(entity.getSoul());
//		human.setLuckyDrawChip(entity.getLuckyDrawChip());
        human.setPower(entity.getPower());
        human.setLastGivePowerTime(entity.getLastGivePowerTime());
        human.setLastGiveDoublePointTime(entity.getLastGiveDoublePointTime());

        human.setSkillPoint(entity.getSkillPoint());
        human.setLastGiveSkillPointTime(entity.getLastGiveSkillPointTime());
        human.setEnergy(entity.getEnergy());
        human.setRedEnvelope(entity.getRedEnvelope());
//		human.setHeroSoul(entity.getHeroSoul());
//		human.setCardPoint(entity.getCardPoint());

        human.setLastChargeTime(entity.getLastChargeTime());
        human.setLastLoginIp(entity.getLastLoginIp());
        human.setLastLoginTime(entity.getLastLoginTime());
        human.setLastLogoutTime(entity.getLastLogoutTime());
        human.setLastVipTime(entity.getLastVipTime());
        human.setPhoto(entity.getPhoto());
        human.setTodayCharge(entity.getTodayCharge());
        human.setTotalCharge(entity.getTotalCharge());
        human.setTotalMinute(entity.getTotalMinute());
        human.getBaseStrProperties().setLong(RoleBaseStrProperties.CORPS_ID, 0);
        if (Loggers.humanLogger.isDebugEnabled()) {
            Loggers.humanLogger.debug("#HumanInitManager#loadHuman#sceneId=" +
                    entity.getSceneId() + ";lastCitySceneId=" + entity.getLastCitySceneId() + ";humanId=" + entity.getId());
        }
        human.setLastCitySceneId(entity.getLastCitySceneId());
        human.setSceneId(entity.getSceneId());
        human.setLevel(entity.getLevel());
        human.setExp(entity.getExp());

        human.setCountry(entity.getCountry());
        human.setCacheFlag(entity.getIdleTime());
        
//		human.getMissionManager().loadJsonProp(entity.getMissionPack());
//        human.setHadOpenPrimBagNum(entity.getHadOpenPrimBagNum());
        human.setStoreOpenNum(entity.getHadOpenPrimBagNum());
        human.setLevel(entity.getLevel());
        human.setLastLoginTime(entity.getLastLoginTime());
        human.setLastLogoutTime(entity.getLastLogoutTime());
        human.setTotalMinute(entity.getTotalMinute());
        human.setTodayCharge(entity.getTodayCharge());
        human.setTotalCharge(entity.getTotalCharge());
        human.setLastChargeTime(entity.getLastChargeTime());
        human.setLastVipTime(entity.getLastVipTime());
        human.getCdManager().loadJsonProp(entity.getCdQueuePack());
        human.setEternalCostMoney(entity.getEternalCostMoney());

        human.setCanRename(entity.getCanRename());
        human.setServerId(entity.getServerId());

        human.setWeekCharge(entity.getWeekCharge());
        human.setMonthCharge(entity.getMonthCharge());

        human.setTokenParam1(entity.getTokenParam1());
        human.setTokenParam2(entity.getTokenParam2());

        human.setMapId(entity.getMapId());
        human.setX(entity.getX());
        human.setY(entity.getY());
        Point tilePoint = MapUtil.image2TileCoord(human.getX(), human.getY());
        human.setTileX(tilePoint.x);
        human.setTileY(tilePoint.y);

        human.setBackMapId(entity.getBackMapId());
        human.setBackX(entity.getBackX());
        human.setBackY(entity.getBackY());

        human.setLastBattleId(entity.getLastBattleId());
        human.setLastBattleTime(entity.getLastBattleTime());
        human.setLastBattleEndTime(entity.getLastBattleEndTime());

        human.setAutoFightAction(entity.getAutoFightAction());
        human.setPetAutoFightAction(entity.getPetAutoFightAction());

        human.setPubLevel(entity.getPubLevel());
        human.setPubExp(entity.getPubExp());

//        human.setMainSkillLevel(entity.getMainSkillLevel());
//        human.setRunningMainSkillType(entity.getMainSkillType());

        human.mainSkillMapFromJson(entity.getMainSkillPack());
        human.setMineLevel(entity.getMineLevel());
        
        human.setBuyMonthCardTime(entity.getBuyMonthCardTime());
        human.setInvalidBattleNum(entity.getInvalidBattleNum());
        
        // 设置创建时间
//		human.setCreateCharacterIp(entity.getCreateCharacterIp());
        if ((entity.getProps() != null) && !entity.getProps().equals("")) {
            JSONObject json = JSONObject.fromObject(entity.getProps());
            for (HumanPropAttr humanPropAttr : HumanPropAttr.values()) {
                if (json.has(humanPropAttr.toString())) {
                    String entryStr = json.getString(humanPropAttr.toString());
                    switch (humanPropAttr) {
                        case BEHAVIOR:
                            humanPropAttr.resolve(human.getBehaviorManager(),
                                    entryStr);
                            break;
                        case CONSUME_CONFIRM:
                            human.getConsumeConfirmManager().loadJsonProp(entryStr);
                            break;
                        case BINDID_BEHAVIOR:
                            human.getBindIdBehaviorManager().loadJsonProp(entryStr);
                            break;
                        case FUNC:
                            human.getFuncManager().loadJsonProp(entryStr);
                            break;
                        case ONLINE_GIFT:
                            human.getOnlineGiftManager().loadJsonProp(entryStr);
                            break;
                        case MALL:
                            human.getMallManager().loadJsonProp(entryStr);
                            break;
                        case CHAT:
                            human.getChatManager().loadJsonProp(entryStr);
                            break;
                        case PUB_TASK:
                            human.getPubTaskManager().loadJsonProp(entryStr);
                            break;
                        case FORAGE:
                        	human.getForageTaskManager().loadJsonProp(entryStr);
                        	break;
                        case GUIDE:
    						human.getGuideManager().loadJsonProp(entryStr);
    						break;
                        case MYSTERY_SHOP:
                        	human.getMysteryShopManager().loadJsonProp(entryStr);
                        	break;
                        case TIME_LIMIT:
                        	human.getTimeLimitManager().loadJsonProp(entryStr);
                        	break;
                        case TOWER:
                        	human.getTowerManager().loadJsonProp(entryStr);
                        	break;
                        case CORPS_CULTIVATE:
                        	human.getCorpsCultivateManager().loadJsonProp(entryStr);
                        	break;
                        case CORPS_ASSIST:
                        	human.getCorpsAssistManager().loadJsonProp(entryStr);
                        	break;
                        case EASY_PLOT_DUNGEON:
                        	human.getEasyPlotDungeonManager().loadJsonProp(entryStr);
                        	break;
                        case HARD_PLOT_DUNGEON:
                        	human.getHardPlotDungeonManager().loadJsonProp(entryStr);
                        	break;
                        case BATTLE:
                        	human.getBattleManager().loadJsonProp(entryStr);
                        	break;
                        case GUA_JI:
                        	human.getGuaJiManager().loadJsonProp(entryStr);
                        	break;
                        case LIFE_SKILL:
                        	human.getLifeSkillManager().loadJsonProp(entryStr);
                        	break;
                        case MINE:
                        	break;
                        case RING_TASK:
                        	human.getRingTaskManager().loadJsonProp(entryStr);
                        	break;
                    }
                }
            }
        }
    }

    /**
     * <pre>
     * 异步加载玩家角色列表之后调用此方法
     * 此方法在主线程中调用
     *
     * <pre>
     */
    public void humanLogin() {
        boolean isFirstLogin = human.getLastLoginTime() == null ? true : false;
        human.onLogin(isFirstLogin);

        Player player = human.getPlayer(); // 更新玩家状态

        if (isFirstLogin) { // 如果玩家是首次登陆
            // 那么给玩家分配一个城市 Id
            player.setTargetSceneId(Globals.getSceneService().getFirstCityId(human));
            // 初始化地盘的human信息
        } else { // 如果玩家已经登陆过
            // XXX 这里改为玩家最近一次的城市场景Id，因为玩家可能进入其他的活动场景，但是登陆的时候都要在城市场景中
            int lastSceneId = human.getLastCitySceneId();//int lastSceneId = human.getSceneId();

            // 如果最近一次的场景Id非法或不是城市Id，则让玩家进入初始的城市
            if (lastSceneId <= 0 || !Globals.getSceneService().isCityId(lastSceneId)) {
                lastSceneId = Globals.getSceneService().getFirstCityId(human);
            }

            // 那么进入玩家上一次所在场景
            player.setTargetSceneId(lastSceneId);
        }

        player.setState(PlayerState.incoming);

        // 激活此角色
        human.getLifeCycle().activate();

        // 通知消息
        noticeHuman();

        if (!isFirstLogin) {
            // TODO 根据终端类型 发送url
            // TerminalTypeEnum terminalTypeEnum =
            // human.getPlayer().getCurrTerminalType();
            // BrosorUrlModel brosorUrlModel =
            // Globals.getBrosorUrlService().getBrosorUrlModel(terminalTypeEnum.index);
            // // String url = "http://192.168.1.20/pop1.html";
            // if(brosorUrlModel != null){
            // //状态位 0关闭 1开启
            // if(brosorUrlModel.getType() == 1){
            // String url = brosorUrlModel.getBrosorUrl();
            // if(url != null && !url.equals("")){
            // GCBrowserUrl gcBrowserUrl = new GCBrowserUrl();
            // gcBrowserUrl.setUrl(url);
            // human.sendMessage(gcBrowserUrl);
            // }
            // }
            // }
            // GCBrowserUrl gcBrowserUrl = new GCBrowserUrl();
            // gcBrowserUrl.setUrl(url);
            // human.sendMessage(gcBrowserUrl);
        }
        // long nowTime = Globals.getTimeService().now();

        // // 结算银矿和农田收益数量
        // Globals.getSilveroreService().settlementAll(this.human, nowTime);
        // Globals.getFarmService().settlementAll(
        // this.human, nowTime);

        // 统计用户登录
        PIProbeCollector.collect(ProbeName.USERS_EXT, UsersExt.LOGIN, 1);
    }

    /**
     * 发送初始的消息接口
     * 注意：该方法中只发消息，不要有更新操作，如果需要登录时更新，挪到 {link:UpdateOnPlayerLoginMsg}中调用
     */
    public void noticeHuman() {
        // 发送场景信息
        GCSceneInfo sceneInfo = new GCSceneInfo();
        human.sendMessage(sceneInfo);

        LoginTypeEnum loginType = human.getPlayer().getLoginType();
        // 如果是token登录方式，则不发送初始的消息给前台
        if (loginType == LoginTypeEnum.TOKEN) {
            Loggers.loginLogger.info("token login,not send init msg!uuid=" +
                    human.getUUID() + ";pid=" + human.getPassportId());
            return;
        }


        // 发送常量消息
        Globals.getConstantService().sendAllConstant(human);

        human.change();
        // 新增，给前台发一次数据更新的消息
        human.snapChangedProperty(true);
        //角色创建时间
        human.sendMessage(new GCCreateTime(human.getCreateTime()));
        // cd队列更新
        human.sendMessage(new GCHumanCdQueueUpdate(human.getCdManager().getCdQueueInfos()));

        Inventory inv = human.getInventory();
        human.sendMessage(inv.getPrimBagInfoMsg());
        human.sendMessage(inv.getStoreBagInfoMsg());
        human.sendMessage(inv.getSkillEffectBagInfoMsg());
        //武将装备包
        for (Pet pet : human.getPetManager().getAllPet()) {
            if (pet.getPetState() != PetState.NORMAL.getIndex()) {
                continue;
            }
            human.sendMessage(inv.getPetBagInfoMsg(pet.getUUID()));
//            human.sendMessage(inv.getPetGemBagInfoMsg(pet.getUUID()));
        }
        //发送主背包和仓库背包容量
        inv.sendBagCapacity();
        
        //登录时检测一下是否可以打造
        inv.getCraftChecker().checkCanCraft();

        //发送武将列表
        human.sendMessage(PetMessageBuilder.getGCPetList(human));
        //发送武将属性
        for (Pet pet : human.getPetManager().getAllPet()) {
            if (pet.getPetState() != PetState.NORMAL.getIndex()) {
                continue;
            }
            pet.change();
            pet.snapChangedProperty(true);
        }
        //发送心法列表
        Globals.getHumanSkillService().sendMainSkillInfo(human);
        //发送生活技能
        Globals.getLifeSkillService().sendLifeSkillInfo(human);
        
        //发送行为信息
        human.getBehaviorManager().noticeBehaviorInfo();
        //发登录天数
        human.sendMessage(new GCLoginDays(human.getTotalLoginDays()));

        //发出战宠物Id
        Globals.getPetService().noticeFightPetOnLogin(human);
        //发出战骑宠Id
        Globals.getPetService().noticeFightPetHorseOnLogin(human);

        //发送池子数值和部分战斗属性当前值
        Globals.getOfflineDataService().sendCurPropOnLogin(human);

        //普通任务列表
        Globals.getCommonTaskService().sendCommonTaskList(human);

        // 功能按钮列表
        Globals.getFuncService().sendFuncListOnLogin(human);

        Globals.getPrizeService().onLogin(human);

        //酒馆任务
        Globals.getPubTaskService().sendCurPubTaskMsg(human);

        //小信封列表
        Globals.getNoticeTipsInfoService().sendNoticeTipsInfoList(human);

        // 防沉迷检查
        Globals.getWallowService().checkOnLogin(human.getPlayer());

        //发送好友列表和黑名单列表
        Globals.getRelationService().sendRelations(human);

//        //发送伙伴阵容列表
//        Globals.getPetService().sendFriendArrayListMsg(human);

        //除暴安良任务
        Globals.getTheSweeneyTaskService().sendCurTheSweeneyTaskMsg(human);

        //绿野仙踪剩余免费次数
        Globals.getWizardRaidService().sendWizardRaidLeftTimes(human);

        //藏宝图任务
        Globals.getTreasureMapService().sendCurTreasureMapMsg(human);
        
        //酒馆任务数据
        Globals.getPubTaskService().onPlayerLogin(human);
      
        //护送粮草任务
        Globals.getForageTaskService().sendCurForageTaskMsg(human);

        //师徒关系推送
        Globals.getOvermanService().sendCurOvermanMsg(human);
        Globals.getOvermanService().sendCurHongDian(human);
        //结婚推送
        Globals.getMarryService().sendCurMarryInfo(human);
        
        //翅膀推送
        Globals.getWingService().openWingPanel(human);
        //称号推送
        Globals.getTitleService().sendTitleInfo(human);
        
        //帮派任务
        Globals.getCorpsTaskService().sendCurCorpsTaskMsg(human);
        
        //限时杀怪任务
        Globals.getTimeLimitMonsterTaskService().sendCurTimeLimitMonsterMsg(human);
        
        //限时挑战Npc任务
        Globals.getTimeLimitNpcTaskService().sendCurTimeLimitNpcMsg(human);
        
        //跑环任务
        Globals.getRingTaskService().sendCurRingTaskMsg(human);
        
        //vip
        Globals.getVipService().onLogin(human);
        
        //通知前台玩家充值记录，用于显示首冲奖励
        Globals.getChargeLogicalProcessor().noticeChargeRecord(human);
        
        //七日目标
        Globals.getDay7TargetService().sendDay7TaskList(human);
        
        //剧情副本
        Globals.getPlotDungeonService().noticePlotDungeonReward(human);
        
        //战斗加速信息
        Globals.getBattleService().noticeBattleSpeedup(human);
        
        //酒馆最大星数
        Globals.getPubTaskService().noticePubTaskMaxStar(human);
        
        //围剿魔族普通任务
        Globals.getSiegeDemonTaskService().sendCurSiegeDemonNormalTaskMsg(human);
        
        //围剿魔族困难任务
        Globals.getSiegeDemonTaskService().sendCurSiegeDemonHardTaskMsg(human);
        
        //挂机
        Globals.getGuaJiService().noticeGuaJiInfo(human);
    }

    /**
     * 是否有车轮战的排名奖励需要领
     *
     * @param human
     *            对应的角色
     * @return true 表示有;false 表示没有;
     */
    // private boolean hasBossWarRankReward(Human human) {
    // // && human.getBossWarManager().getBossWarRank() <= BossWarDef.RANK10
    // if (human.getBossWarManager().getActivityId() > 0 &&
    // human.getBossWarManager().getBossWarRank() > 0) {
    // return true;
    // }
    // return false;
    // }


}
