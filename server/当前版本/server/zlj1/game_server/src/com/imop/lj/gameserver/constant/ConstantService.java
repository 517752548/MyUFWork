package com.imop.lj.gameserver.constant;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.RoleConstants;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.KeyValueInfo;
import com.imop.lj.common.model.constant.ConstantInfo;
import com.imop.lj.common.model.constant.MusicConfigInfo;
import com.imop.lj.common.model.constant.MusicInfo;
import com.imop.lj.common.model.constant.ShowCurrencyInfo;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.msg.GCConstantList;
import com.imop.lj.gameserver.common.msg.GCMusicConfigList;
import com.imop.lj.gameserver.constant.ConstantDef.ConstantEnum;
import com.imop.lj.gameserver.constant.MusicDef.MusicModuleEnum;
import com.imop.lj.gameserver.constant.template.MusicConfigTemplate;
import com.imop.lj.gameserver.constant.template.OtherMusicTemplate;
import com.imop.lj.gameserver.constant.template.ShowCurrencyTemplate;
import com.imop.lj.gameserver.exam.ExamDef.ExamAssistItem;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.func.template.FuncOpenTemplate;
import com.imop.lj.gameserver.func.template.FuncTemplate;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.pet.PetDef;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;
import com.imop.lj.gameserver.scene.template.SceneTemplate;
import com.imop.lj.gameserver.vip.VipDef;

/**
 * 常量服务
 * 用于给前台发送一些后台的常量
 *
 * @author yu.zhao
 */
public class ConstantService implements InitializeRequired {
    /**
     * 常量信息列表
     */
    protected List<ConstantInfo> constantList = new ArrayList<ConstantInfo>();
    /**
     * 显示货币信息列表
     */
    protected List<ShowCurrencyInfo> showCurrencyList = new ArrayList<ShowCurrencyInfo>();
    /**
     * 音乐配置
     */
    protected Map<MusicModuleEnum, List<KeyValueInfo>> musicConfigMap = new HashMap<MusicModuleEnum, List<KeyValueInfo>>();

    public ConstantService() {

    }

    @Override
    public void init() {
        // 初始化常量
        initConstantList();
        // 初始化显示货币信息
        initShowCurrencyList();
//		// 初始化音乐配置
//		initMusicConfig();
//		// 检查一些全局的奖励Id是否合法
//		checkRewardId();
    }

    /**
     * 初始化常量列表
     */
    protected void initConstantList() {
        ConstantEnum[] arr = ConstantEnum.values();
        for (int i = 0; i < arr.length; i++) {
            constantList.add(buildConstantInfo(arr[i]));
        }
    }

    /**
     * 构建常量信息
     * 需要根据不同的常量定义获取不同的数据
     *
     * @param constantEnum
     * @return
     */
    protected ConstantInfo buildConstantInfo(ConstantEnum constantEnum) {
        ConstantInfo info = new ConstantInfo();
        String value = "";
        FuncOpenTemplate funcOpenTpl = null;        
        // XXX 根据不同的常量枚举获取不同的数
        switch (constantEnum) {
            case PET_PERCEPT_LEVEL_MAX:
                value = Globals.getGameConstants().getPetPerceptLevelMax() + "";
                break;
            case CREATE_CORPS_COST:
                value = Globals.getGameConstants().getCreateCorpsNeedGold() + "";
                break;
            case MAX_QUALITY:
                value = PetDef.PetQuality.values().length + "";
                break;
            case DEFALUT_SKILL_LEVEL:
                value = BattleDef.DEFAULT_SKILL_LEVEL + "";
                break;
            case ADD_POINT_PER_LEVEL_PET:
                value = Globals.getGameConstants().getPetLevelUpAddPoint() + "";
                break;
            case ADD_POINT_PER_LEVEL_LEADER:
                value = Globals.getGameConstants().getLeaderLevelUpAddPoint() + "";
                break;
            case MAX_LEVEL:
                value = Globals.getGameConstants().getLevelMax() + "";
                break;
            case EQUIP_MAX_STAR:
                value = Globals.getTemplateCacheService().getEquipTemplateCache().getMaxStars() + "";
                break;
            case GEM_MAX_LEVEL:
                value = Globals.getGameConstants().getGemMaxLevel() + "";
                break;
            case MAX_GEM_NUM_PERGRID:
                value = RoleConstants.PET_GEM_BAG_SUB_CAPACITY + "";
                break;
            case EXAM_ITEM1:
                value = ExamAssistItem.SONGMULING.getItemId() + "";
                break;
            case EXAM_ITEM2:
                value = ExamAssistItem.YUMULING.getItemId() + "";
                break;
            case TIMELIMIT_EXAM_ITEM1:
            	value = ExamAssistItem.CWLIBAO.getItemId() + "";
            	break;
            case PET_TALENT_ITEMID:
                value = Globals.getGameConstants().getPetTalentSkillResetItemId() + "";
                break;
            case PET_TALENT_ITEMNUM:
                value = Globals.getGameConstants().getPetTalentSkillResetItemNum() + "";
                break;
            case PUB_TASK_REFRESH_ITEMID:
                value = Globals.getGameConstants().getPubTaskRefreshManulItemId() + "";
                break;
            case PUB_TASK_REFRESH_GOLD_NUM:
                value = Globals.getGameConstants().getPubTaskRefreshManulGold() + "";
                break;
            case PUB_TASK_REFRESH_BOND_NUM:
            	value = Globals.getGameConstants().getPubTaskRefreshManulBond() + "";
            	break;
            case PUB_TASK_REFRESH_BOND_TYPE_ID:
            	value = Globals.getGameConstants().getPubTaskRefreshManulBondTypeId() + "";
            	break;
            case RESET_POINT_ITEMID:
                value = Globals.getGameConstants().getPetResetPointItemId() + "";
                break;

            case POOL_HP_MAX:
                value = Globals.getGameConstants().getMaxHpPool() + "";
                break;
            case POOL_MP_MAX:
                value = Globals.getGameConstants().getMaxMpPool() + "";
                break;
            case POOL_LIFE_MAX:
                value = Globals.getGameConstants().getMaxLifePool() + "";
                break;
            case SP_MAX:
                value = Globals.getGameConstants().getBattleSpMax() + "";
                break;
            case TRADE_TAX:
                value = Globals.getGameConstants().getCostTaxForTrade() + "";
                break;
            case BATTLE_LEFT_MIN:
                value = Globals.getGameConstants().getBattleLeftMin() + "";
                break;
            case FORAGE_TASK_REFRESH_ITEMID:
                value = Globals.getGameConstants().getForageTaskRefreshManulItemId() + "";
                break;
            case FORAGE_TASK_REFRESH_ITEMNUM:
                value = Globals.getGameConstants().getForageTaskRefreshManulItemNum() + "";
                break;
            case OVERMAN_FIRE_COST:
                value = Globals.getGameConstants().getOverman_current_force_fire_currency_number() + "";
                break;
            case MARRY_COST:
                value = Globals.getGameConstants().getMarryCost() + "";
                break;
            case MARRY_FORCE_FIRE:
                value = Globals.getGameConstants().getForceFireMarry() + "";
                break;
            case OVERMAN_MIN_OVERMAN_LEVEL:
                value = Globals.getGameConstants().getOverman_min_overman_level()+"";
                break;
            case OVERMAN_MIN_LOWERMAN_LEVEL:
                value = Globals.getGameConstants().getOverman_min_lowerman_level()+"";
                break;
            case OVERMAN_MAX_LOWERMAN_LEVEL:
                value = Globals.getGameConstants().getOverman_max_lowerman_level()+"";
                break;
            case OVERMAN_OVER_OVERMAN:
                value = Globals.getGameConstants().getOverman_over_lowerman()+"";
                break;
            case MARRY_LEVEL:
                value = Globals.getGameConstants().getMarryGrade()+"";
                break;
            case WIZARD_RAID_ENTER_ITEMID:
                value = Globals.getGameConstants().getWizardRaidEnterItemId()+"";
                break;
            case ACTIVITYUI_RECOMMOND_COEF:
            	value = Globals.getGameConstants().getRecommendActivityMultiple()+"";
            	break;
            case PRESIDENT_BENIFIT_COEF:
            	value = Globals.getGameConstants().getPresidentCoef()+"";
                break;
            case VICECHAIRMAN_BENIFIT_COEF:
            	value = Globals.getGameConstants().getViceChairmanCoef()+"";
            	break;
            case ELITE_BENIFIT_COEF:
            	value = Globals.getGameConstants().getEliteCoef()+"";
            	break;
            case GUIDE_QUESTID:
            	value = Globals.getGameConstants().getGuideQuestId()+"";
            	break;
            case VIP_MAX_LEVEL:
            	value = VipDef.VipMaxLevel+"";
            	break;
            case ENERGY_MAX:
            	value = Globals.getGameConstants().getEnergyMax()+"";
            	break;
            case CORPS_CULTIVATE_COST_CURRENCY:
            	value = Globals.getGameConstants().getCultivateCostCurrencyNum()+"";
            	break;
            case BATTLE_SPEEDUP_X:
            	value = Globals.getGameConstants().getBattleReportSpeedX()+"";
            	break;
            case SIEGE_DEMON_NORMAL_MIN_LEVEL:
            	funcOpenTpl = Globals.getTemplateCacheService().get(FuncTypeEnum.SIEGE_DEMON_NORMAL.getIndex(), FuncOpenTemplate.class);
             	value = funcOpenTpl != null ? funcOpenTpl.getLimitLevel()+"": "0" ;
            	break;
            case SIEGE_DEMON_HARD_MIN_LEVEL :
            	funcOpenTpl = Globals.getTemplateCacheService().get(FuncTypeEnum.SIEGE_DEMON_HARD.getIndex(), FuncOpenTemplate.class);
            	value = funcOpenTpl != null ? funcOpenTpl.getLimitLevel()+"": "0" ;
            	break;
            default:
                break;
        }

        info.setKey(constantEnum.getIndex() + "");
        info.setValue(value);
        return info;
    }

    /**
     * 初始化显示货币列表
     */
    protected void initShowCurrencyList() {
        for (ShowCurrencyTemplate tpl : Globals.getTemplateCacheService().getAll(ShowCurrencyTemplate.class).values()) {
            showCurrencyList.add(buildShowCurrencyInfo(tpl));
        }
    }

    /**
     * 构建显示货币数据
     *
     * @param tpl
     * @return
     */
    protected ShowCurrencyInfo buildShowCurrencyInfo(ShowCurrencyTemplate tpl) {
        ShowCurrencyInfo info = new ShowCurrencyInfo();
        info.setShowType(tpl.getShowType());
        info.setTypeName(tpl.getTypeName());
        info.setName(tpl.getName());
        info.setDesc(tpl.getDesc());
        info.setIcon(tpl.getIcon());
        info.setMin(tpl.getMin());
        info.setMax(tpl.getMax());
        return info;
    }

    /**
     * 一些全局奖励Id的检查
     * XXX 全局奖励验证可以放在这里写
     */
    protected void checkRewardId() {
        // 手机验证奖励Id检查
        int smsCheckCodeRewardId = Globals.getGameConstants().getSmsCheckCodeRewardId();
        RewardConfigTemplate smsCheckCodeRewardTpl = Globals.getTemplateCacheService().get(smsCheckCodeRewardId, RewardConfigTemplate.class);
        if (smsCheckCodeRewardTpl == null) {
            throw new TemplateConfigException("", 0, String.format("手机验证奖励Id不存在%d！", smsCheckCodeRewardId));
        }
//		if (smsCheckCodeRewardTpl.getRewardReasonType() != RewardReasonType.SMS_CHECKCODE_REWARD) {
//			throw new TemplateConfigException("", 0, String.format("手机验证奖励身份识别类型[%d]", smsCheckCodeRewardTpl.getRewardReasonTypeId()));
//		}

        // TODO 全局奖励验证可以放在下面继续写

    }

    /**
     * 给前台发所有的常量数据消息
     *
     * @param human
     */
    public void sendAllConstant(Human human) {
        human.sendMessage(new GCConstantList(constantList.toArray(new ConstantInfo[0])));
        //	human.sendMessage(new GCShowCurrency(showCurrencyList.toArray(new ShowCurrencyInfo[0])));
        //	this.sendMusicConfig(human);
    }

    /**
     * 初始化音乐配置
     */
    public void initMusicConfig() {
        // 公共场景
        List<KeyValueInfo> sceneMusicList = new ArrayList<KeyValueInfo>();
        for (SceneTemplate scene : Globals.getTemplateCacheService().getAll(SceneTemplate.class).values()) {
            KeyValueInfo info = new KeyValueInfo();
            info.setKey(scene.getId());
            info.setValue(scene.getMusicId());
            sceneMusicList.add(info);
        }

        musicConfigMap.put(MusicModuleEnum.COMMON_SCENE, sceneMusicList);

        // 功能
        List<KeyValueInfo> funcMusicList = new ArrayList<KeyValueInfo>();
        for (FuncTemplate func : Globals.getTemplateCacheService().getAll(FuncTemplate.class).values()) {
            KeyValueInfo info = new KeyValueInfo();
            info.setKey(func.getId());
            info.setValue(func.getMusicId());
            funcMusicList.add(info);
        }

        musicConfigMap.put(MusicModuleEnum.FUNC, funcMusicList);

//		// 战斗
//		List<KeyValueInfo> battleTypeList = new ArrayList<KeyValueInfo>();
//		for(BattleTypeTemplate tmpl : Globals.getTemplateCacheService().getAll(BattleTypeTemplate.class).values()){
//			KeyValueInfo info = new KeyValueInfo();
//			info.setKey(tmpl.getId());
//			info.setValue(tmpl.getMusicId());
//			battleTypeList.add(info);	
//		}

//		musicConfigMap.put(MusicModuleEnum.BATTLE_TYPE, battleTypeList);

        // 其它
        List<KeyValueInfo> otherList = new ArrayList<KeyValueInfo>();
        for (OtherMusicTemplate tmpl : Globals.getTemplateCacheService().getAll(OtherMusicTemplate.class).values()) {
            KeyValueInfo info = new KeyValueInfo();
            info.setKey(tmpl.getId());
            info.setValue(tmpl.getMusicId());
            otherList.add(info);
        }

        musicConfigMap.put(MusicModuleEnum.OTHER, otherList);
    }

    /**
     * 发送音乐配置
     *
     * @param human
     */
    public void sendMusicConfig(Human human) {
        GCMusicConfigList resp = new GCMusicConfigList();

        // 音乐配置
        List<MusicConfigInfo> musicConfigList = new ArrayList<MusicConfigInfo>();
        for (MusicConfigTemplate config : Globals.getTemplateCacheService().getAll(MusicConfigTemplate.class).values()) {
            MusicConfigInfo info = new MusicConfigInfo();
            info.setId(config.getId());
            info.setResId(config.getResId());
            info.setLoop(config.getLoop());
            musicConfigList.add(info);
        }

        resp.setMusicConfigInfoList(musicConfigList.toArray(new MusicConfigInfo[0]));

        // 音乐功能配置
        List<MusicInfo> musicList = new ArrayList<MusicInfo>();
        for (Entry<MusicModuleEnum, List<KeyValueInfo>> entry : musicConfigMap.entrySet()) {
            MusicInfo info = new MusicInfo();
            info.setModuleId(entry.getKey().getIndex());
            info.setKeyValueList(entry.getValue().toArray(new KeyValueInfo[0]));
            musicList.add(info);
        }

        resp.setMusicInfoList(musicList.toArray(new MusicInfo[0]));

        human.sendMessage(resp);
    }
    
}
