namespace app.db
{
    public class LoadCfg
    {
        public void initAllCfg()
        {
            // 加载所有道具数据
            ItemTemplateDB.Instance.clearAllCfg();
            ItemTemplateDB.Instance.loadAllCfg();

            //地图
            MapTemplateDB.Instance.getIdKeyDic().Clear();
            MapTemplateDB.Instance.loadAllTemplate();

            // 加载武将相关
            PetTemplateDB.Instance.getIdKeyDic().Clear();
            PetTemplateDB.Instance.loadAllTemplate();
            
            PetPropTemplateDB.Instance.getIdKeyDic().Clear();
            PetPropTemplateDB.Instance.loadAllTemplate();
            
            PetGrowthTemplateDB.Instance.getIdKeyDic().Clear();
            PetGrowthTemplateDB.Instance.loadAllTemplate();
            
            PetTrainCostTemplateDB.Instance.getIdKeyDic().Clear();
            PetTrainCostTemplateDB.Instance.loadAllTemplate();
            
            PetArtificeTemplateDB.Instance.getIdKeyDic().Clear();
            PetArtificeTemplateDB.Instance.loadAllTemplate();
            
            PetPerceptLevelTemplateDB.Instance.getIdKeyDic().Clear();
            PetPerceptLevelTemplateDB.Instance.loadAllTemplate();
            
            PetPerceptPromoteTemplateDB.Instance.getIdKeyDic().Clear();
            PetPerceptPromoteTemplateDB.Instance.loadAllTemplate();

            PetPerceptTypeTemplateDB.Instance.getIdKeyDic().Clear();
            PetPerceptTypeTemplateDB.Instance.loadAllTemplate();

            PetHorseArtificeTemplateDB.Instance.getIdKeyDic().Clear();
            PetHorseArtificeTemplateDB.Instance.loadAllTemplate();

            PetHorseRejuvenationTemplateDB.Instance.getIdKeyDic().Clear();
            PetHorseRejuvenationTemplateDB.Instance.loadAllTemplate();

            PetHorsePerceptTypeTemplateDB.Instance.getIdKeyDic().Clear();
            PetHorsePerceptTypeTemplateDB.Instance.loadAllTemplate();

            PetHorseGrowthTemplateDB.Instance.getIdKeyDic().Clear();
            PetHorseGrowthTemplateDB.Instance.loadAllTemplate();

            PetHorseTrainCostTemplateDB.Instance.getIdKeyDic().Clear();
            PetHorseTrainCostTemplateDB.Instance.loadAllTemplate();

            PetHorsePerceptLevelTemplateDB.Instance.getIdKeyDic().Clear();
            PetHorsePerceptLevelTemplateDB.Instance.loadAllTemplate();

            PetRejuvenationTemplateDB.Instance.getIdKeyDic().Clear();
            PetRejuvenationTemplateDB.Instance.loadAllTemplate();
            
            PetVariationTemplateDB.Instance.getIdKeyDic().Clear();
            PetVariationTemplateDB.Instance.loadAllTemplate();
            
            PetFriendTemplateDB.Instance.getIdKeyDic().Clear();
            PetFriendTemplateDB.Instance.loadAllTemplate();

            PetPropItemTemplateDB.Instance.getIdKeyDic().Clear();
            PetPropItemTemplateDB.Instance.loadAllTemplate();

            PetHorsePropItemTemplateDB.Instance.getIdKeyDic().Clear();
            PetHorsePropItemTemplateDB.Instance.loadAllTemplate();

            //技能相关
            SkillTemplateDB.Instance.getIdKeyDic().Clear();
            SkillTemplateDB.Instance.loadAllTemplate();
            
            SkillEffectTemplateDB.Instance.getIdKeyDic().Clear();
            SkillEffectTemplateDB.Instance.loadAllTemplate();
            
            SkillPerformTemplateDB.Instance.getIdKeyDic().Clear();
            SkillPerformTemplateDB.Instance.loadAllTemplate();
            
            SkillBuffTemplateDB.Instance.getIdKeyDic().Clear();
            SkillBuffTemplateDB.Instance.loadAllTemplate();
            
            SkillAddTemplateDB.Instance.getIdKeyDic().Clear();
            SkillAddTemplateDB.Instance.loadAllTemplate();

            PetTalentSkillPackTemplateDB.Instance.getIdKeyDic().Clear();
            PetTalentSkillPackTemplateDB.Instance.loadAllTemplate();

            PetHorseTalentSkillPackTemplateDB.Instance.getIdKeyDic().Clear();
            PetHorseTalentSkillPackTemplateDB.Instance.loadAllTemplate();

            //NPC
            NpcTemplateDB.Instance.getIdKeyDic().Clear();
            NpcTemplateDB.Instance.loadAllTemplate();
            
            MapNpcTemplateDB.Instance.getIdKeyDic().Clear();
            MapNpcTemplateDB.Instance.loadAllTemplate();
            MapNpcTemplateDB.Instance.initMapNpcDic();
            
            //任务
            QuestTemplateDB.Instance.getIdKeyDic().Clear();
            QuestTemplateDB.Instance.loadAllTemplate();

            //怪物
            EnemyTemplateDB.Instance.getIdKeyDic().Clear();
            EnemyTemplateDB.Instance.loadAllTemplate();
            
            EnemyArmyTemplateDB.Instance.getIdKeyDic().Clear();
            EnemyArmyTemplateDB.Instance.loadAllTemplate();

            ///野外挂机///
            EnemyGuaJiValueTemplateDB.Instance.getIdKeyDic().Clear();
            EnemyGuaJiValueTemplateDB.Instance.loadAllTemplate();
            
            MapMeetMonsterTemplateDB.Instance.getIdKeyDic().Clear();
            MapMeetMonsterTemplateDB.Instance.loadAllTemplate();

            //装备
            UpgradeEquipStarTemplateDB.Instance.getIdKeyDic().Clear();
            UpgradeEquipStarTemplateDB.Instance.loadAllTemplate();

            EquipDecomposeTemplateDB.Instance.getIdKeyDic().Clear();
            EquipDecomposeTemplateDB.Instance.loadAllTemplate();
            
            EquipRecastLockAttrTemplateDB.Instance.getIdKeyDic().Clear();
            EquipRecastLockAttrTemplateDB.Instance.loadAllTemplate();

            //酒馆任务
            PubLevelTemplateDB.Instance.getIdKeyDic().Clear();
            PubLevelTemplateDB.Instance.loadAllTemplate();

            //科举
            ExamTemplateDB.Instance.clearAllCfg();
			ExamTemplateDB.Instance.loadAllCfg();
            
            //心法技能
            HumanMainSkillTemplateDB.Instance.getIdKeyDic().Clear();
            HumanMainSkillTemplateDB.Instance.loadAllTemplate();
            
            HumanMainSkillLevelTemplateDB.Instance.getIdKeyDic().Clear();
            HumanMainSkillLevelTemplateDB.Instance.loadAllTemplate();
            
            HumanMainSkillToSubSkillTemplateDB.Instance.getIdKeyDic().Clear();
            HumanMainSkillToSubSkillTemplateDB.Instance.loadAllTemplate();
            
            HumanSubSkillTemplateDB.Instance.getIdKeyDic().Clear();
            HumanSubSkillTemplateDB.Instance.loadAllTemplate();
            
            HumanSubSkillLevelTemplateDB.Instance.getIdKeyDic().Clear();
            HumanSubSkillLevelTemplateDB.Instance.loadAllTemplate();
            
            HumanSubPassiveSkillTemplateDB.Instance.getIdKeyDic().Clear();
            HumanSubPassiveSkillTemplateDB.Instance.loadAllTemplate();
            
            //打造
            CraftEquipTypeTemplateDB.Instance.getIdKeyDic().Clear();
            CraftEquipTypeTemplateDB.Instance.loadAllTemplate();

            CraftEquipCostTemplateDB.Instance.getIdKeyDic().Clear();
            CraftEquipCostTemplateDB.Instance.loadAllTemplate();

            CraftEquipItemProbTemplateDB.Instance.getIdKeyDic().Clear();
            CraftEquipItemProbTemplateDB.Instance.loadAllTemplate();

            //宝石
            EquipHoleCostTemplateDB.Instance.getIdKeyDic().Clear();
            EquipHoleCostTemplateDB.Instance.loadAllTemplate();
            
            GemUpTemplateDB.Instance.getIdKeyDic().Clear();
            GemUpTemplateDB.Instance.loadAllTemplate();

            GemDownTemplateDB.Instance.getIdKeyDic().Clear();
            GemDownTemplateDB.Instance.loadAllTemplate();

            EquipHoleRefreshTemplateDB.Instance.getIdKeyDic().Clear();
            EquipHoleRefreshTemplateDB.Instance.loadAllTemplate();

            EquipGemLimitTemplateDB.Instance.getIdKeyDic().Clear();
            EquipGemLimitTemplateDB.Instance.loadAllTemplate();
                
            GemSynthesisTemplateDB.Instance.getIdKeyDic().Clear();
            GemSynthesisTemplateDB.Instance.loadAllTemplate();
            
            //商城
            MallNormalItemTemplateDB.Instance.getIdKeyDic().Clear();
            MallNormalItemTemplateDB.Instance.loadAllTemplate();
            MallCatalogTemplateDB.Instance.getIdKeyDic().Clear();
            MallCatalogTemplateDB.Instance.loadAllTemplate();
            //商城 之 神秘商店！！~~
            MysteryShopItemTemplateDB.Instance.getIdKeyDic().Clear();
            MysteryShopItemTemplateDB.Instance.loadAllTemplate();
            
            //商城 之 拍卖行
            TradeMainTagTemplateDB.Instance.getIdKeyDic().Clear();
            TradeMainTagTemplateDB.Instance.loadAllTemplate();
            
            TradeSubTagTemplateDB.Instance.getIdKeyDic().Clear();
            TradeSubTagTemplateDB.Instance.loadAllTemplate();
            
            TradeSaleableTemplateDB.Instance.getIdKeyDic().Clear();
            TradeSaleableTemplateDB.Instance.loadAllTemplate();
            
            TradeSortableFieldTemplateDB.Instance.getIdKeyDic().Clear();
            TradeSortableFieldTemplateDB.Instance.loadAllTemplate();

            //活动入口
            ActivityUITemplateDB.Instance.getIdKeyDic().Clear();
            ActivityUITemplateDB.Instance.loadAllTemplate();

            //组队，队伍目标
            TeamTargetTemplateDB.Instance.getIdKeyDic().Clear();
            TeamTargetTemplateDB.Instance.loadAllTemplate();
            
            //采矿
            LifeSkillMineTemplateDB.Instance.getIdKeyDic().Clear();
            LifeSkillMineTemplateDB.Instance.loadAllTemplate();
            
            LifeSkillMineLevelTemplateDB.Instance.getIdKeyDic().Clear();
            LifeSkillMineLevelTemplateDB.Instance.loadAllTemplate();
            
            LifeSkillMinePitTemplateDB.Instance.getIdKeyDic().Clear();
            LifeSkillMinePitTemplateDB.Instance.loadAllTemplate();
            
            LifeSkillMineCostTemplateDB.Instance.getIdKeyDic().Clear();
            LifeSkillMineCostTemplateDB.Instance.loadAllTemplate();
            
            LifeSkillMineMinerTemplateDB.Instance.getIdKeyDic().Clear();
            LifeSkillMineMinerTemplateDB.Instance.loadAllTemplate();

            //生活技能
            LifeSkillMapTemplateDB.Instance.getIdKeyDic().Clear();
            LifeSkillMapTemplateDB.Instance.loadAllTemplate();
            LifeSkillMapTemplateDB.Instance.initMapResDic();

            LifeSkillLevelTemplateDB.Instance.getIdKeyDic().Clear();
            LifeSkillLevelTemplateDB.Instance.loadAllTemplate();

            LifeSkillTemplateDB.Instance.getIdKeyDic().Clear();
            LifeSkillTemplateDB.Instance.loadAllTemplate();

            //绿野仙踪
            WizardRaidTemplateDB.Instance.getIdKeyDic().Clear();
            WizardRaidTemplateDB.Instance.loadAllTemplate();
            
            //称号
            TitleTemplateDB.Instance.getIdKeyDic().Clear();
            TitleTemplateDB.Instance.loadAllTemplate();
            
            //护送粮草
            ForageTaskRewardTemplateDB.Instance.getIdKeyDic().Clear();
            ForageTaskRewardTemplateDB.Instance.loadAllTemplate();
            
            //师徒
            OvermanTemplateDB.Instance.getIdKeyDic().Clear();
            OvermanTemplateDB.Instance.loadAllTemplate();
            
            //剧情
            StoryTemplateDB.Instance.getIdKeyDic().Clear();
            StoryTemplateDB.Instance.loadAllTemplate();
            
            //翅膀
            WingTemplateDB.Instance.getIdKeyDic().Clear();
            WingTemplateDB.Instance.loadAllTemplate();
            
            WingUpgradeTemplateDB.Instance.getIdKeyDic().Clear();
            WingUpgradeTemplateDB.Instance.loadAllTemplate();
            
            //帮派升级
            CorpsUpgradeTemplateDB.Instance.getIdKeyDic().Clear();
            CorpsUpgradeTemplateDB.Instance.loadAllTemplate();
            
            //帮派福利
            CorpsBenifitTemplateDB.Instance.getIdKeyDic().Clear();
            CorpsBenifitTemplateDB.Instance.loadAllTemplate();
            
            //提升
            PromoteTemplateDB.Instance.getIdKeyDic().Clear();
            PromoteTemplateDB.Instance.loadAllTemplate();
            //充值、vip
            ChargeTemplateDB.Instance.getIdKeyDic().Clear();
            ChargeTemplateDB.Instance.loadAllTemplate();

            VipConfigTemplateDB.Instance.getIdKeyDic().Clear();
            VipConfigTemplateDB.Instance.loadAllTemplate();

            VipUpgradeTemplateDB.Instance.getIdKeyDic().Clear();
            VipUpgradeTemplateDB.Instance.loadAllTemplate();
			
			//爬塔
            TowerMapTemplateDB.Instance.getIdKeyDic().Clear();
            TowerMapTemplateDB.Instance.loadAllTemplate();

            //帮派Boss
            CorpsBossTemplateDB.Instance.getIdKeyDic().Clear();
            CorpsBossTemplateDB.Instance.loadAllTemplate();

            //仙符描述
            SkillEffectDescTemplateDB.Instance.getIdKeyDic().Clear();
            SkillEffectDescTemplateDB.Instance.loadAllTemplate();

            //仙符等级
            SkillEffectItemLevelTemplateDB.Instance.getIdKeyDic().Clear();
            SkillEffectItemLevelTemplateDB.Instance.loadAllTemplate();
            //仙符开启
            SkillEffectOpenTemplateDB.Instance.getIdKeyDic().Clear();
            SkillEffectOpenTemplateDB.Instance.loadAllTemplate();

            //帮派修炼技能
            CorpsCultivateCostTemplateDB.Instance.getIdKeyDic().Clear();
            CorpsCultivateCostTemplateDB.Instance.loadAllTemplate();
            CorpsCultivateTemplateDB.Instance.getIdKeyDic().Clear();
            CorpsCultivateTemplateDB.Instance.loadAllTemplate();

            //帮派辅助技能
            CorpsAssistCostTemplateDB.Instance.getIdKeyDic().Clear();
            CorpsAssistCostTemplateDB.Instance.loadAllTemplate();
            CorpsAssistGenTemplateDB.Instance.getIdKeyDic().Clear();
            CorpsAssistGenTemplateDB.Instance.loadAllTemplate();
            CorpsAssistTemplateDB.Instance.getIdKeyDic().Clear();
            CorpsAssistTemplateDB.Instance.loadAllTemplate();

            //帮派建筑升级
            CorpsBuildingUpgradeTemplateDB.Instance.getIdKeyDic().Clear();
            CorpsBuildingUpgradeTemplateDB.Instance.loadAllTemplate();

            //七日目标
            Day7TargetTemplateDB.Instance.getIdKeyDic().Clear();
            Day7TargetTemplateDB.Instance.loadAllTemplate();

            //显示奖励
            ShowRewardTemplateDB.Instance.getIdKeyDic().Clear();
            ShowRewardTemplateDB.Instance.loadAllTemplate();
            //剧情副本
            PlotDungeonTemplateDB.Instance.getIdKeyDic().Clear();
            PlotDungeonTemplateDB.Instance.loadAllTemplate();
            //过场动画
            VideoTemplateDB.Instance.getIdKeyDic().Clear();
            VideoTemplateDB.Instance.loadAllTemplate();
            //侠义之心
            SkillLabelTemplateDB.Instance.getIdKeyDic().Clear();
            SkillLabelTemplateDB.Instance.loadAllTemplate();
            //固定战报
            StoryBattleTemplateDB.Instance.getIdKeyDic().Clear();
            StoryBattleTemplateDB.Instance.loadAllTemplate();
            //兑换
            ExchangeTemplateDB.Instance.getIdKeyDic().Clear();
            ExchangeTemplateDB.Instance.loadAllTemplate();
            //月卡
            MonthCardTemplateDB.Instance.getIdKeyDic().Clear();
            MonthCardTemplateDB.Instance.loadAllTemplate();
            //环任务奖励
            RingTaskRewardTemplateDB.Instance.getIdKeyDic().Clear();
            RingTaskRewardTemplateDB.Instance.loadAllTemplate();
        }
    }
}
