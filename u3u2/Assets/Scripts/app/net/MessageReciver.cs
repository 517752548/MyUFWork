namespace app.net
{
	public class MessageReciver
	{
		
		public static BaseMessage createMessage(int msgType)
        {
            switch (msgType)
            {
			case MessageType.GC_BATTLE_REPORT_PVP:
				return new GCBattleReportPvp();
			case MessageType.GC_XIANHU_PANEL:
				return new GCXianhuPanel();
			case MessageType.GC_PET_STUDY_NORMAL_SKILL:
				return new GCPetStudyNormalSkill();
			case MessageType.GC_MAP_PLAYER_SET_POSITION:
				return new GCMapPlayerSetPosition();
			case MessageType.GC_TL_NPC_UPDATE:
				return new GCTlNpcUpdate();
			case MessageType.GC_DALIY_GIFT_LIST_APPLY:
				return new GCDaliyGiftListApply();
			case MessageType.GC_MONTH_CARD_INFO:
				return new GCMonthCardInfo();
			case MessageType.GC_WIZARDRAID_ENTER_TEAM:
				return new GCWizardraidEnterTeam();
			case MessageType.GC_ADD_RELATION:
				return new GCAddRelation();
			case MessageType.GC_SCENE_INFO:
				return new GCSceneInfo();
			case MessageType.GC_ACTIVITY_LIST:
				return new GCActivityList();
			case MessageType.GC_WIZARDRAID_INFO:
				return new GCWizardraidInfo();
			case MessageType.GC_TL_NPC_DONE:
				return new GCTlNpcDone();
			case MessageType.GC_PET_ARTIFICE:
				return new GCPetArtifice();
			case MessageType.GC_BATTLE_START_PVP_INVITE:
				return new GCBattleStartPvpInvite();
			case MessageType.GC_FINISH_QUEST:
				return new GCFinishQuest();
			case MessageType.GC_FINISHED_GUIDE_LIST_BY_FUNC:
				return new GCFinishedGuideListByFunc();
			case MessageType.GC_MAP_ADD_NPC:
				return new GCMapAddNpc();
			case MessageType.GC_CHAT_MSG_LIST:
				return new GCChatMsgList();
			case MessageType.GC_TOWER_REWARD:
				return new GCTowerReward();
			case MessageType.GC_ACCEPT_QUEST:
				return new GCAcceptQuest();
			case MessageType.GC_OFFLINEREWARD_INFO:
				return new GCOfflinerewardInfo();
			case MessageType.GC_PET_SKILL_EFFECT_UPLEVEL:
				return new GCPetSkillEffectUplevel();
			case MessageType.GC_HS_MAIN_SKILL_UPGRADE:
				return new GCHsMainSkillUpgrade();
			case MessageType.GC_TEAM_APPLY_AUTO:
				return new GCTeamApplyAuto();
			case MessageType.GC_PET_ADD_EXP:
				return new GCPetAddExp();
			case MessageType.GC_STOP_GUAJI:
				return new GCStopGuaji();
			case MessageType.GC_CORPSWAR_RANK_LIST:
				return new GCCorpswarRankList();
			case MessageType.GC_PLAYER_QUERY_ACCOUNT:
				return new GCPlayerQueryAccount();
			case MessageType.GC_GAME_ENTER_PLAYER_NUM:
				return new GCGameEnterPlayerNum();
			case MessageType.GC_WATCH_FIRST_KILLER_REPLAY:
				return new GCWatchFirstKillerReplay();
			case MessageType.GC_SPEC_ONLINE_GIFT_SHOW_INFO:
				return new GCSpecOnlineGiftShowInfo();
			case MessageType.GC_ACTIVITY_UPDATE:
				return new GCActivityUpdate();
			case MessageType.GC_FORAGETASK_DONE:
				return new GCForagetaskDone();
			case MessageType.GC_SIEGEDEMONTASK_DONE:
				return new GCSiegedemontaskDone();
			case MessageType.GC_ARENA_KILL_CD:
				return new GCArenaKillCd();
			case MessageType.GC_FIRST_FIRE_MARRY:
				return new GCFirstFireMarry();
			case MessageType.GC_SIEGEDEMON_ASK_ENTER_TEAM:
				return new GCSiegedemonAskEnterTeam();
			case MessageType.GC_FIRST_FIRE_OVERMAN:
				return new GCFirstFireOverman();
			case MessageType.GC_ACTIVITY_UI_INFO:
				return new GCActivityUiInfo();
			case MessageType.GC_PET_HORSE_PERCEPT_ADD_EXP:
				return new GCPetHorsePerceptAddExp();
			case MessageType.GC_PET_FRIEND_INFO:
				return new GCPetFriendInfo();
			case MessageType.GC_CORPS_BOSS_INFO:
				return new GCCorpsBossInfo();
			case MessageType.GC_DEL_MAIL:
				return new GCDelMail();
			case MessageType.GC_PLAY_BATTLE_REPORT:
				return new GCPlayBattleReport();
			case MessageType.GC_PET_HORSE_CHANGE_NAME:
				return new GCPetHorseChangeName();
			case MessageType.GC_OVERMAN_INFO:
				return new GCOvermanInfo();
			case MessageType.GC_CORPS_CHANGED_MEMBER_INFO:
				return new GCCorpsChangedMemberInfo();
			case MessageType.GC_FUNC_HAS_GUIDE:
				return new GCFuncHasGuide();
			case MessageType.GC_SHOW_ARENA_PANEL_MAIN:
				return new GCShowArenaPanelMain();
			case MessageType.GC_OPEN_CORPSTASK_PANEL:
				return new GCOpenCorpstaskPanel();
			case MessageType.GC_SEND_MAIL:
				return new GCSendMail();
			case MessageType.GC_GUA_JI_PANEL:
				return new GCGuaJiPanel();
			case MessageType.GC_SYSTEM_NOTICE:
				return new GCSystemNotice();
			case MessageType.GC_FIRST_MARRY:
				return new GCFirstMarry();
			case MessageType.GC_BUY_POWER_TIPS:
				return new GCBuyPowerTips();
			case MessageType.GC_PING:
				return new GCPing();
			case MessageType.GC_MAP_TEAM_LEADER_POSITION:
				return new GCMapTeamLeaderPosition();
			case MessageType.GC_OFFLINE_USER_PET_INFO:
				return new GCOfflineUserPetInfo();
			case MessageType.GC_MAKE_ITEM:
				return new GCMakeItem();
			case MessageType.GC_EQP_GEM_SYNTHESIS:
				return new GCEqpGemSynthesis();
			case MessageType.GC_EXAM_INFO:
				return new GCExamInfo();
			case MessageType.GC_FAILED_MSG:
				return new GCFailedMsg();
			case MessageType.GC_GET_BENIFIT:
				return new GCGetBenifit();
			case MessageType.GC_PET_HORSE_STUDY_NORMAL_SKILL:
				return new GCPetHorseStudyNormalSkill();
			case MessageType.GC_TRADE_COMMODITY_LIST:
				return new GCTradeCommodityList();
			case MessageType.GC_OPEN_PUBTASK_PANEL:
				return new GCOpenPubtaskPanel();
			case MessageType.GC_NEXT_QUEUE_CD:
				return new GCNextQueueCd();
			case MessageType.GC_TEAM_INVITE_PLAYER_NOTICE:
				return new GCTeamInvitePlayerNotice();
			case MessageType.GC_POP_FLAG:
				return new GCPopFlag();
			case MessageType.GC_DAILY_PLOT_DUNGEON_INFO:
				return new GCDailyPlotDungeonInfo();
			case MessageType.GC_OFFLINE_USER_LEADER_INFO:
				return new GCOfflineUserLeaderInfo();
			case MessageType.GC_ADD_PET:
				return new GCAddPet();
			case MessageType.GC_USE_LIFE_SKILL:
				return new GCUseLifeSkill();
			case MessageType.GC_EQP_DECOMPOSE:
				return new GCEqpDecompose();
			case MessageType.GC_ROLE_TEMPLATE:
				return new GCRoleTemplate();
			case MessageType.GC_MYSTERY_SHOP_INFO:
				return new GCMysteryShopInfo();
			case MessageType.GC_CHANNEL_EXCHANGE:
				return new GCChannelExchange();
			case MessageType.GC_NVN_MATCH_STATUS:
				return new GCNvnMatchStatus();
			case MessageType.GC_PET_FRIEND_ARRAY_LIST:
				return new GCPetFriendArrayList();
			case MessageType.GC_MAIL_UPDATE:
				return new GCMailUpdate();
			case MessageType.GC_ADD_PET_SKILLBAR_NUM:
				return new GCAddPetSkillbarNum();
			case MessageType.GC_OPEN_ALLOCATE_PANEL:
				return new GCOpenAllocatePanel();
			case MessageType.GC_BATTLE_FORCE_END:
				return new GCBattleForceEnd();
			case MessageType.GC_OPEN_CORPS_MEMBER_LIST:
				return new GCOpenCorpsMemberList();
			case MessageType.GC_TL_MONSTER_DONE:
				return new GCTlMonsterDone();
			case MessageType.GC_PET_CUR_PROP_UPDATE:
				return new GCPetCurPropUpdate();
			case MessageType.GC_CHAT_MSG:
				return new GCChatMsg();
			case MessageType.GC_PET_HORSE_TRAIN_UPDATE:
				return new GCPetHorseTrainUpdate();
			case MessageType.GC_HS_OPEN_PANEL:
				return new GCHsOpenPanel();
			case MessageType.GC_DALIY_GIFT_SIGN:
				return new GCDaliyGiftSign();
			case MessageType.GC_DAY7_TASK_LIST:
				return new GCDay7TaskList();
			case MessageType.GC_PET_TRAIN_UPDATE:
				return new GCPetTrainUpdate();
			case MessageType.GC_QUEST_UPDATE:
				return new GCQuestUpdate();
			case MessageType.GC_EXAM_USE_ITEM:
				return new GCExamUseItem();
			case MessageType.GC_NVN_MY_INFO:
				return new GCNvnMyInfo();
			case MessageType.GC_DALIY_GIFT_PANNEL_APPLY:
				return new GCDaliyGiftPannelApply();
			case MessageType.GC_SIEGEDEMON_ENTER_TEAM:
				return new GCSiegedemonEnterTeam();
			case MessageType.GC_ONLINEGIFT_INFO:
				return new GCOnlinegiftInfo();
			case MessageType.GC_LIFE_SKILL_UPGRADE:
				return new GCLifeSkillUpgrade();
			case MessageType.GC_PET_HORSE_CUR_PROP_UPDATE:
				return new GCPetHorseCurPropUpdate();
			case MessageType.GC_PET_FIRE:
				return new GCPetFire();
			case MessageType.GC_WALLOW_OPEN_PANEL:
				return new GCWallowOpenPanel();
			case MessageType.GC_ARENA_RANK_REWARD_LIST:
				return new GCArenaRankRewardList();
			case MessageType.GC_SWAP_ITEM:
				return new GCSwapItem();
			case MessageType.GC_RINGTASK_UPDATE:
				return new GCRingtaskUpdate();
			case MessageType.GC_EXAM_CHOSE:
				return new GCExamChose();
			case MessageType.GC_LIFE_SKILL_INFO:
				return new GCLifeSkillInfo();
			case MessageType.GC_GET_MAIL_ATTACHMENT:
				return new GCGetMailAttachment();
			case MessageType.GC_ROLE_RANDOM_NAME:
				return new GCRoleRandomName();
			case MessageType.GC_RELOGIN:
				return new GCRelogin();
			case MessageType.GC_CORPSBOSS_ASK_ENTER_TEAM:
				return new GCCorpsbossAskEnterTeam();
			case MessageType.GC_DAY7_TASK_UPDATE:
				return new GCDay7TaskUpdate();
			case MessageType.GC_OPEN_TL_MONSTER_PANEL:
				return new GCOpenTlMonsterPanel();
			case MessageType.GC_CORPS_MEMBER_INFO:
				return new GCCorpsMemberInfo();
			case MessageType.GC_CORPS_LIST_PANEL:
				return new GCCorpsListPanel();
			case MessageType.GC_WALLOW_ADD_INFO_RESULT:
				return new GCWallowAddInfoResult();
			case MessageType.GC_MAIL_LIST:
				return new GCMailList();
			case MessageType.GC_PET_HORSE_ARTIFICE:
				return new GCPetHorseArtifice();
			case MessageType.GC_LOGIN_DAYS:
				return new GCLoginDays();
			case MessageType.GC_BATTLE_READY_CHANGED_PVP:
				return new GCBattleReadyChangedPvp();
			case MessageType.GC_WALLOW_LOGIN_NOTICE:
				return new GCWallowLoginNotice();
			case MessageType.GC_GET_LOWERMAN_REWARD:
				return new GCGetLowermanReward();
			case MessageType.GC_TEAM_APPLY:
				return new GCTeamApply();
			case MessageType.GC_PLOT_DUNGEON_INFO:
				return new GCPlotDungeonInfo();
			case MessageType.GC_SHOW_OPTION_DLG:
				return new GCShowOptionDlg();
			case MessageType.GC_FIRST_OVERMAN:
				return new GCFirstOverman();
			case MessageType.GC_TITLE_PANEL:
				return new GCTitlePanel();
			case MessageType.GC_PROPERTY_CHANGED_STRING:
				return new GCPropertyChangedString();
			case MessageType.GC_PRIZE_LIST:
				return new GCPrizeList();
			case MessageType.GC_CREATE_TIME:
				return new GCCreateTime();
			case MessageType.GC_MAP_ADD_NPC_LIST:
				return new GCMapAddNpcList();
			case MessageType.GC_MAP_PLAYER_CHANGED_LIST:
				return new GCMapPlayerChangedList();
			case MessageType.GC_ITEM_UPDATE:
				return new GCItemUpdate();
			case MessageType.GC_OVERMAN_HONGDIAN:
				return new GCOvermanHongdian();
			case MessageType.GC_PET_INFO:
				return new GCPetInfo();
			case MessageType.GC_CHARGE_RECORD:
				return new GCChargeRecord();
			case MessageType.GC_COMMON_QUEST_LIST:
				return new GCCommonQuestList();
			case MessageType.GC_UPDATE_SINGLE_CORPS:
				return new GCUpdateSingleCorps();
			case MessageType.GC_STORAGE_ITEM_LIST:
				return new GCStorageItemList();
			case MessageType.GC_SCENE_PLAYER_LIST:
				return new GCScenePlayerList();
			case MessageType.GC_CULTIVATE_SKILL:
				return new GCCultivateSkill();
			case MessageType.GC_PET_POOL_UPDATE:
				return new GCPetPoolUpdate();
			case MessageType.GC_PET_HORSE_AFFINATION:
				return new GCPetHorseAffination();
			case MessageType.GC_OPEN_CORPS_RED_ENVELOPE_PANEL:
				return new GCOpenCorpsRedEnvelopePanel();
			case MessageType.GC_EQP_CRAFT_INFO:
				return new GCEqpCraftInfo();
			case MessageType.GC_MAP_PLAYER_ENTER:
				return new GCMapPlayerEnter();
			case MessageType.GC_PET_AFFINATION:
				return new GCPetAffination();
			case MessageType.GC_GOT_CORPS_RED_ENVELOPE:
				return new GCGotCorpsRedEnvelope();
			case MessageType.GC_SHOW_RECOMMEND_FRIEND_LIST:
				return new GCShowRecommendFriendList();
			case MessageType.GC_WING_UPGRADE:
				return new GCWingUpgrade();
			case MessageType.GC_WIZARDRAID_ENTER_SINGLE:
				return new GCWizardraidEnterSingle();
			case MessageType.GC_TEAM_INVITE_LIST:
				return new GCTeamInviteList();
			case MessageType.GC_SHOW_GUIDE_INFO:
				return new GCShowGuideInfo();
			case MessageType.GC_ARENA_BATTLE_RECORD:
				return new GCArenaBattleRecord();
			case MessageType.GC_TREASUREMAP_UPDATE:
				return new GCTreasuremapUpdate();
			case MessageType.GC_OPEN_CORPS_BENIFIT_PANEL:
				return new GCOpenCorpsBenifitPanel();
			case MessageType.GC_TEAM_QUIT:
				return new GCTeamQuit();
			case MessageType.GC_PET_SKILL_EFFECT_UPDATE:
				return new GCPetSkillEffectUpdate();
			case MessageType.GC_ROLE_LIST:
				return new GCRoleList();
			case MessageType.GC_XIANHU_RANK_LIST:
				return new GCXianhuRankList();
			case MessageType.GC_HS_SUB_SKILL_UPGRADE:
				return new GCHsSubSkillUpgrade();
			case MessageType.GC_PUBTASK_MAX_STAR:
				return new GCPubtaskMaxStar();
			case MessageType.GC_FUNC_LIST:
				return new GCFuncList();
			case MessageType.GC_PRIZE_LIST_TIP:
				return new GCPrizeListTip();
			case MessageType.GC_CORPSBOSS_COUNT_RANK_LIST:
				return new GCCorpsbossCountRankList();
			case MessageType.GC_EQP_RECAST:
				return new GCEqpRecast();
			case MessageType.GC_BATTLE_REPORT_TEAM:
				return new GCBattleReportTeam();
			case MessageType.GC_SIEGEDEMONTASK_UPDATE:
				return new GCSiegedemontaskUpdate();
			case MessageType.GC_GET_SMS_CHECKCODE:
				return new GCGetSmsCheckcode();
			case MessageType.GC_CHARGE_GEN_ORDERID:
				return new GCChargeGenOrderid();
			case MessageType.GC_CORPSBOSS_RANK_LIST:
				return new GCCorpsbossRankList();
			case MessageType.GC_USR_TITLE:
				return new GCUsrTitle();
			case MessageType.GC_NVN_MATCHED_TEAM_INFO:
				return new GCNvnMatchedTeamInfo();
			case MessageType.GC_EQP_GEM_TAKEDOWN:
				return new GCEqpGemTakedown();
			case MessageType.GC_THESWEENEYTASK_UPDATE:
				return new GCThesweeneytaskUpdate();
			case MessageType.GC_TOWER_INFO:
				return new GCTowerInfo();
			case MessageType.GC_BATTLE_SPEEDUP:
				return new GCBattleSpeedup();
			case MessageType.GC_CORPSWAR_INFO:
				return new GCCorpswarInfo();
			case MessageType.GC_SCENE_PLAYER_REMOVE_LIST:
				return new GCScenePlayerRemoveList();
			case MessageType.GC_BAG_UPDATE:
				return new GCBagUpdate();
			case MessageType.GC_HS_MAIN_SKILL_INFO:
				return new GCHsMainSkillInfo();
			case MessageType.GC_OPEN_CORPS_CULTIVATE_PANEL:
				return new GCOpenCorpsCultivatePanel();
			case MessageType.GC_NOTIFY_EXCEPTION:
				return new GCNotifyException();
			case MessageType.GC_OPEN_FORAGETASK_PANEL:
				return new GCOpenForagetaskPanel();
			case MessageType.GC_TEAM_SHOW_LIST:
				return new GCTeamShowList();
			case MessageType.GC_NOTICE_TIPS_INFO_ADD:
				return new GCNoticeTipsInfoAdd();
			case MessageType.GC_START_GUA_JI:
				return new GCStartGuaJi();
			case MessageType.GC_PET_LEADER_STUDY_SKILL:
				return new GCPetLeaderStudySkill();
			case MessageType.GC_ACITVITY_UI_REWARD_INFO:
				return new GCAcitvityUiRewardInfo();
			case MessageType.GC_TL_MONSTER_UPDATE:
				return new GCTlMonsterUpdate();
			case MessageType.GC_CORPS_STORAGE:
				return new GCCorpsStorage();
			case MessageType.GC_EQP_HOLE:
				return new GCEqpHole();
			case MessageType.GC_EQP_UPSTAR:
				return new GCEqpUpstar();
			case MessageType.GC_WING_PANEL:
				return new GCWingPanel();
			case MessageType.GC_FIRST_TEAM_FIRE_OVERMAN:
				return new GCFirstTeamFireOverman();
			case MessageType.GC_GOOD_ACTIVITY_LIST:
				return new GCGoodActivityList();
			case MessageType.GC_PET_HORSE_SOUL_LINK_PET:
				return new GCPetHorseSoulLinkPet();
			case MessageType.GC_CORPSTASK_DONE:
				return new GCCorpstaskDone();
			case MessageType.GC_PET_ADD_POINT:
				return new GCPetAddPoint();
			case MessageType.GC_MALL_CATALOG_INFO_LIST:
				return new GCMallCatalogInfoList();
			case MessageType.GC_HUMAN_CD_QUEUE_UPDATE:
				return new GCHumanCdQueueUpdate();
			case MessageType.GC_CORPSTASK_UPDATE:
				return new GCCorpstaskUpdate();
			case MessageType.GC_TIME_LIMIT_ITEM_LIST:
				return new GCTimeLimitItemList();
			case MessageType.GC_TEAM_INVITE_PLAYER:
				return new GCTeamInvitePlayer();
			case MessageType.GC_SHOW_CURRENCY:
				return new GCShowCurrency();
			case MessageType.GC_WIZARDRAID_LEFT_TIMES:
				return new GCWizardraidLeftTimes();
			case MessageType.GC_ENTER_SCENE:
				return new GCEnterScene();
			case MessageType.GC_NVN_RANK_LIST:
				return new GCNvnRankList();
			case MessageType.GC_CREATE_CORPS_RED_ENVELOPE:
				return new GCCreateCorpsRedEnvelope();
			case MessageType.GC_REMOVE_QUEST:
				return new GCRemoveQuest();
			case MessageType.GC_RESET_CAPACITY:
				return new GCResetCapacity();
			case MessageType.GC_PET_LIST:
				return new GCPetList();
			case MessageType.GC_BATTLE_END:
				return new GCBattleEnd();
			case MessageType.GC_LEARN_ASSIST_SKILL:
				return new GCLearnAssistSkill();
			case MessageType.GC_SCENE_PLAYER_CHANGED_LIST:
				return new GCScenePlayerChangedList();
			case MessageType.GC_TEST_LONG:
				return new GCTestLong();
			case MessageType.GC_ARENA_BUY_CHALLENGE_TIME:
				return new GCArenaBuyChallengeTime();
			case MessageType.GC_EQP_GEM_SET:
				return new GCEqpGemSet();
			case MessageType.GC_EQP_CRAFT:
				return new GCEqpCraft();
			case MessageType.GC_PROPERTY_CHANGED_NUMBER:
				return new GCPropertyChangedNumber();
			case MessageType.GC_CLICK_RELATION_PANEL:
				return new GCClickRelationPanel();
			case MessageType.GC_MALL_ITEM_LIST:
				return new GCMallItemList();
			case MessageType.GC_FINISHED_GUIDE_BY_FUNC:
				return new GCFinishedGuideByFunc();
			case MessageType.GC_PUBTASK_DONE:
				return new GCPubtaskDone();
			case MessageType.GC_RINGTASK_DONE:
				return new GCRingtaskDone();
			case MessageType.GC_TEAM_MY_TEAM_INFO:
				return new GCTeamMyTeamInfo();
			case MessageType.GC_PET_REFRESH_TALENT_SKILL:
				return new GCPetRefreshTalentSkill();
			case MessageType.GC_GUAJI:
				return new GCGuaji();
			case MessageType.GC_UPDATE_TOKEN:
				return new GCUpdateToken();
			case MessageType.GC_PET_VARIATION:
				return new GCPetVariation();
			case MessageType.GC_POPUP_PANEL_END:
				return new GCPopupPanelEnd();
			case MessageType.GC_BEHAVIOR_INFO:
				return new GCBehaviorInfo();
			case MessageType.GC_PUBTASK_UPDATE:
				return new GCPubtaskUpdate();
			case MessageType.GC_PET_PERCEPT_ADD_EXP:
				return new GCPetPerceptAddExp();
			case MessageType.GC_SYSTEM_MESSAGE_LIST:
				return new GCSystemMessageList();
			case MessageType.GC_OPEN_SIEGEDEMONTASK_PANEL:
				return new GCOpenSiegedemontaskPanel();
			case MessageType.GC_PET_HORSE_REJUVEN:
				return new GCPetHorseRejuven();
			case MessageType.GC_CHECK_SMS_CHECKCODE:
				return new GCCheckSmsCheckcode();
			case MessageType.GC_PET_RESET_POINT:
				return new GCPetResetPoint();
			case MessageType.GC_GOOD_ACTIVITY_UPDATE:
				return new GCGoodActivityUpdate();
			case MessageType.GC_MAP_REMOVE_ADD_NPC:
				return new GCMapRemoveAddNpc();
			case MessageType.GC_PET_CHANGE_NAME:
				return new GCPetChangeName();
			case MessageType.GC_OPEN_TL_NPC_PANEL:
				return new GCOpenTlNpcPanel();
			case MessageType.GC_FUNC_UPDATE:
				return new GCFuncUpdate();
			case MessageType.GC_SCENE_PLAYER_ADDED_LIST:
				return new GCScenePlayerAddedList();
			case MessageType.GC_USE_POOL_ADD_RESULT:
				return new GCUsePoolAddResult();
			case MessageType.GC_OPEN_CORPS_PANEL:
				return new GCOpenCorpsPanel();
			case MessageType.GC_ITEM_UPDATE_LIST:
				return new GCItemUpdateList();
			case MessageType.GC_THESWEENEYTASK_DONE:
				return new GCThesweeneytaskDone();
			case MessageType.GC_PET_HORSE_RIDE:
				return new GCPetHorseRide();
			case MessageType.GC_VIP_INFO:
				return new GCVipInfo();
			case MessageType.GC_SYSTEM_MESSAGE:
				return new GCSystemMessage();
			case MessageType.GC_OPEN_RINGTASK_PANEL:
				return new GCOpenRingtaskPanel();
			case MessageType.GC_PRIZE_SUCCESS:
				return new GCPrizeSuccess();
			case MessageType.GC_BATTLE_REPORT_PART:
				return new GCBattleReportPart();
			case MessageType.GC_TEST:
				return new GCTest();
			case MessageType.GC_ADD_PET_HORSE_SKILLBAR_NUM:
				return new GCAddPetHorseSkillbarNum();
			case MessageType.GC_REMOVE_ITEM:
				return new GCRemoveItem();
			case MessageType.GC_PROMOTE_PANEL:
				return new GCPromotePanel();
			case MessageType.GC_PET_FRIEND_UNLOCK_LIST:
				return new GCPetFriendUnlockList();
			case MessageType.GC_PET_REJUVEN:
				return new GCPetRejuven();
			case MessageType.GC_OFFLINE_USER_BASE_INFO:
				return new GCOfflineUserBaseInfo();
			case MessageType.GC_PET_HORSE_REFRESH_TALENT_SKILL:
				return new GCPetHorseRefreshTalentSkill();
			case MessageType.GC_NOTICE_TIPS_INFO_LIST:
				return new GCNoticeTipsInfoList();
			case MessageType.GC_DEL_RELATION:
				return new GCDelRelation();
			case MessageType.GC_RANK_APPLY:
				return new GCRankApply();
			case MessageType.GC_GET_OVERMAN_REWARD:
				return new GCGetOvermanReward();
			case MessageType.GC_LOGIN_POP_PANEL:
				return new GCLoginPopPanel();
			case MessageType.GC_MARRY_INFO:
				return new GCMarryInfo();
			case MessageType.GC_TEAM_CALL_BACK_NOTICE:
				return new GCTeamCallBackNotice();
			case MessageType.GC_TRADE_SELL_RESULT:
				return new GCTradeSellResult();
			case MessageType.GC_TEAM_MY_TEAM_MEMBER_LIST:
				return new GCTeamMyTeamMemberList();
			case MessageType.GC_OPEN_CORPS_ASSIST_PANEL:
				return new GCOpenCorpsAssistPanel();
			case MessageType.GC_MUSIC_CONFIG_LIST:
				return new GCMusicConfigList();
			case MessageType.GC_SCENE_PLAYER_FORCE_TO_CITY_SCENE:
				return new GCScenePlayerForceToCityScene();
			case MessageType.GC_CORPS_EVENT_NOTICE:
				return new GCCorpsEventNotice();
			case MessageType.GC_NVN_LEAVE:
				return new GCNvnLeave();
			case MessageType.GC_OPEN_THESWEENEYTASK_PANEL:
				return new GCOpenThesweeneytaskPanel();
			case MessageType.GC_WIZARDRAID_ASK_ENTER_TEAM:
				return new GCWizardraidAskEnterTeam();
			case MessageType.GC_TRADE_BOOTHINFO:
				return new GCTradeBoothinfo();
			case MessageType.GC_OPEN_TREASUREMAP_PANEL:
				return new GCOpenTreasuremapPanel();
			case MessageType.GC_ARENA_TOP_RANK_LIST:
				return new GCArenaTopRankList();
			case MessageType.GC_PLAYER_CHARGE_DIAMOND:
				return new GCPlayerChargeDiamond();
			case MessageType.GC_BATTLE_READY_CHANGED_TEAM:
				return new GCBattleReadyChangedTeam();
			case MessageType.GC_TEST1:
				return new GCTest1();
			case MessageType.GC_BUY_ITEM_PANEL_OPERATE:
				return new GCBuyItemPanelOperate();
			case MessageType.GC_DEGRADE_CORPS:
				return new GCDegradeCorps();
			case MessageType.GC_SMS_CHECKCODE_PANEL:
				return new GCSmsCheckcodePanel();
			case MessageType.GC_DALIY_GIFT_RETROACTIVE:
				return new GCDaliyGiftRetroactive();
			case MessageType.GC_OPEN_DOUBLE_STATUS:
				return new GCOpenDoubleStatus();
			case MessageType.GC_EXAM_APPLY:
				return new GCExamApply();
			case MessageType.GC_PET_HORSE_FIRE:
				return new GCPetHorseFire();
			case MessageType.GC_PRIZE_EXIST:
				return new GCPrizeExist();
			case MessageType.GC_OPEN_CORPS_BUILDING_PANEL:
				return new GCOpenCorpsBuildingPanel();
			case MessageType.GC_NVN_RULE:
				return new GCNvnRule();
			case MessageType.GC_WATCH_BEST_KILLER_REPLAY:
				return new GCWatchBestKillerReplay();
			case MessageType.GC_CONSTANT_LIST:
				return new GCConstantList();
			case MessageType.GC_FORAGETASK_UPDATE:
				return new GCForagetaskUpdate();
			case MessageType.GC_UPGRADE_CORPS:
				return new GCUpgradeCorps();
			case MessageType.GC_TEAM_APPLY_LIST:
				return new GCTeamApplyList();
			case MessageType.GC_SCENE_PLAYER_MOVED_LIST:
				return new GCScenePlayerMovedList();
			case MessageType.GC_SHOW_ITEM:
				return new GCShowItem();
			case MessageType.GC_PET_CHANGE_FIGHT_STATE:
				return new GCPetChangeFightState();
			case MessageType.GC_MAP_UPDATE_ADD_NPC:
				return new GCMapUpdateAddNpc();
			case MessageType.GC_TREASUREMAP_DONE:
				return new GCTreasuremapDone();
			case MessageType.GC_FUNC_HAS_GUIDE_LIST:
				return new GCFuncHasGuideList();
			default:
				break;
            }
            return null;
        }
        
        public static void handleReviceMessage(BaseMessage baseMsg)
        {
            string eventType = baseMsg.getEventType();
            if (eventType != null && eventType != "")
            {
                EventCore.dispathRMetaEventByParms(baseMsg.getEventType(), baseMsg);
            }
            else
            {
                ClientLog.LogError("baseMsg eventType is invalid!msgType=" + baseMsg.GetMessageType());
            }
        }
	}
}
