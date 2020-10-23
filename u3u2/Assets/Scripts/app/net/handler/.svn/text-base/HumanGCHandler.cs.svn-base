using app.human;
using app.model;
using app.role;
using app.battle;
using app.pet;
using app.state;
using app.zone;
using app.chenghao;
using app.xianhu;
using app.yueka;

namespace app.net
{
    public class HumanGCHandler : IGCHandler
    {
        public const string GCHumanCdQueueUpdateEvent = "GCHumanCdQueueUpdateEvent";
        public const string GCPropertyChangedNumberEvent = "GCPropertyChangedNumberEvent";
        public const string GCPropertyChangedStringEvent = "GCPropertyChangedStringEvent";
        public const string GCFuncListEvent = "GCFuncListEvent";
        public const string GCFuncUpdateEvent = "GCFuncUpdateEvent";
        public const string GCOfflinerewardInfoEvent = "GCOfflinerewardInfoEvent";
        public const string GCOnlinegiftInfoEvent = "GCOnlinegiftInfoEvent";
        public const string GCBuyPowerTipsEvent = "GCBuyPowerTipsEvent";
        public const string GCSpecOnlineGiftShowInfoEvent = "GCSpecOnlineGiftShowInfoEvent";
		public const string GCChannelExchangeEvent = "GCChannelExchangeEvent";
        public const string GCVipInfoEvent = "GCVipInfoEvent";
		public const string GCBehaviorInfoEvent = "GCBehaviorInfoEvent";
		public const string GCDay7TaskUpdateEvent = "GCDay7TaskUpdateEvent";
		public const string GCDay7TaskListEvent = "GCDay7TaskListEvent";
		public const string GCLoginDaysEvent = "GCLoginDaysEvent";
		public const string GCCreateTimeEvent = "GCCreateTimeEvent";
        public const string GCXianhuPanelEvent = "GCXianhuPanelEvent";
        public const string GCXianhuRankListEvent = "GCXianhuRankListEvent";
        public const string GCMonthCardInfoEvent = "GCMonthCardInfoEvent";


        private FunctionModel functionModel;

        public HumanGCHandler()
        {
            EventCore.addRMetaEventListener(GCHumanCdQueueUpdateEvent, GCHumanCdQueueUpdateHandler);
            EventCore.addRMetaEventListener(GCPropertyChangedNumberEvent, GCPropertyChangedNumberHandler);
            EventCore.addRMetaEventListener(GCPropertyChangedStringEvent, GCPropertyChangedStringHandler);
            EventCore.addRMetaEventListener(GCFuncListEvent, GCFuncListHandler);
            EventCore.addRMetaEventListener(GCFuncUpdateEvent, GCFuncUpdateHandler);
            EventCore.addRMetaEventListener(GCOfflinerewardInfoEvent, GCOfflinerewardInfoHandler);
            EventCore.addRMetaEventListener(GCOnlinegiftInfoEvent, GCOnlinegiftInfoHandler);
            EventCore.addRMetaEventListener(GCBuyPowerTipsEvent, GCBuyPowerTipsHandler);
            EventCore.addRMetaEventListener(GCSpecOnlineGiftShowInfoEvent, GCSpecOnlineGiftShowInfoHandler);
			EventCore.addRMetaEventListener(GCChannelExchangeEvent, GCChannelExchangeHandler);
			EventCore.addRMetaEventListener(GCVipInfoEvent, GCVipInfoHandler);
			EventCore.addRMetaEventListener(GCBehaviorInfoEvent, GCBehaviorInfoHandler);
			EventCore.addRMetaEventListener(GCDay7TaskUpdateEvent, GCDay7TaskUpdateHandler);
            EventCore.addRMetaEventListener(GCDay7TaskListEvent, GCDay7TaskListHandler);
            EventCore.addRMetaEventListener(GCLoginDaysEvent, GCLoginDaysHandler);
			EventCore.addRMetaEventListener(GCCreateTimeEvent, GCCreateTimeHandler);
            EventCore.addRMetaEventListener(GCXianhuPanelEvent, GCXianhuPanelHandler);
            EventCore.addRMetaEventListener(GCXianhuRankListEvent, GCXianhuRankListHandler);
            EventCore.addRMetaEventListener(GCMonthCardInfoEvent, GCMonthCardInfoHandler);

            if (functionModel == null)
            {
                //functionModel = Singleton.getObj(typeof(FunctionModel)) as FunctionModel;
                functionModel = FunctionModel.Ins;
            }
        }


        private void GCHumanCdQueueUpdateHandler(RMetaEvent e)
        {
            //GCHumanCdQueueUpdate msg = e.data as GCHumanCdQueueUpdate;
            
        }

        private void GCPropertyChangedNumberHandler(RMetaEvent e)
        {
            GCPropertyChangedNumber msg = e.data as GCPropertyChangedNumber;
            short roleType = msg.getRoleType();
            long uuid = msg.getRoleUUID();
            KeyValuePairIntData[] propArr = msg.getProperties();
            int leaderLevel = Human.Instance.getLevel();
            if (roleType == (int)RoleTypes.HUMAN)
            {
                //humanֻ��һ�򣬲�������uuid
                Human.Instance.HumanIntPropertyChangeHandler(propArr);
                Human.Instance.PropertyManager.updateIntDic(propArr);
                Human.Instance.PetModel.dispatchHumanPropChange();

                int len = propArr.Length;

                for (int i = 0; i < len; i++)
                {
                    KeyValuePairIntData data = propArr[i];
                    if (data.key == RoleBaseIntProperties.AUTO_FIGHT_ACTION)
                    {
                        BattleModel.ins.ChangeActivedSkill(PetType.LEADER, data.value);
                    }
                    else if (data.key == RoleBaseIntProperties.PET_AUTO_FIGHT_ACTION)
                    {
                        BattleModel.ins.ChangeActivedSkill(PetType.PET, data.value);
                    }
                }
            }
            else if (roleType == (int)RoleTypes.PET)
            {
                //if (pet != null)
                //{
                    if (Human.Instance.PetModel.getLeader().Id == uuid)
                    {
                        Human.Instance.LeaderIntPropertyChangeHandler(propArr);
                        Human.Instance.HumanIntPropertyChangeHandler(propArr);
                    }
                    else
                    {
                        //Human.Instance.BubblePetIntPropertyChange(pet, propArr);
                    }

                    //pet.PropertyManager.updateIntDic(propArr);
                    //Human.Instance.PetModel.dispatchPetPropChange(pet.Id);
                //}
                //Pet pet = 
                Human.Instance.PetModel.UpdatePetIntProps(uuid, propArr);
            }

            int newleaderLevel = Human.Instance.getLevel();
            if (newleaderLevel > leaderLevel && 
                Human.Instance.PlayerModel.isLoginFinished)
            {
                if (StateManager.Ins.getCurState().state == StateDef.zoneState)
                {
                    //播放升级动画
                    EffectUtil.Ins.PlayEffect("common_shengji", LayerConfig.MainUI, false, null);
                    //EffectUtil.Ins.PlayEffect("common_shengji_renwu", LayerConfig.Layer_ZoneModel, false, ZoneCharacterManager.ins.player.displayModel.avatar.transform.parent.gameObject);
                    ZoneCharacterManager.ins.self.ShowUpgradeEffect();
                }
                else
                {
                    Human.Instance.PlayerModel.NeedPlayerUpgradeEffect = true;
                }
            }
           // Human.Instance.PetModel.UpdateState();
            ChenghaoModel.Ins.UpdateState();
        }

        private void GCPropertyChangedStringHandler(RMetaEvent e)
        {
            GCPropertyChangedString msg = e.data as GCPropertyChangedString;
            short roleType = msg.getRoleType();
            long uuid = msg.getRoleUUID();
            KeyValuePairStringData[] propArr = msg.getProperties();
            
            if (roleType == (int)RoleTypes.HUMAN)
            {
                Human.Instance.HumanStrPropertyChangeHandler(propArr);
                Human.Instance.PropertyManager.updateStrDic(propArr);
                Human.Instance.PetModel.dispatchHumanPropChange();
            }
            else if (roleType == (int)RoleTypes.PET)
            {
                Pet pet = Human.Instance.PetModel.getPet(uuid);
                if (pet != null)
                {
                    if (Human.Instance.PetModel.getLeader().Id == pet.Id)
                    {
                        Human.Instance.LeaderStrPropertyChangeHandler(propArr);
                        Human.Instance.HumanStrPropertyChangeHandler(propArr);
                    }
                    else
                    {
                        //Human.Instance.BubblePetStrPropertyChange(pet, propArr);
                    }

                    pet.PropertyManager.updateStrDic(propArr);
                    Human.Instance.PetModel.dispatchPetPropChange(pet.Id);
                    Human.Instance.PetModel.dispatchPetHorseNameChange();
                }
            }
           // Human.Instance.PetModel.UpdateState();
            ChenghaoModel.Ins.UpdateState();
        }

        private void GCFuncListHandler(RMetaEvent e)
        {
            GCFuncList msg = e.data as GCFuncList;
            functionModel.setFuncList(msg);
        }
        
        private void GCFuncUpdateHandler(RMetaEvent e)
        {
            GCFuncUpdate msg = e.data as GCFuncUpdate;
            functionModel.updateFunc(msg);
        }

        private void GCOfflinerewardInfoHandler(RMetaEvent e)
        {
            //GCOfflinerewardInfo msg = e.data as GCOfflinerewardInfo;

        }

        private void GCOnlinegiftInfoHandler(RMetaEvent e)
        {
            //GCOnlinegiftInfo msg = e.data as GCOnlinegiftInfo;

        }

        private void GCBuyPowerTipsHandler(RMetaEvent e)
        {
            //GCBuyPowerTips msg = e.data as GCBuyPowerTips;

        }

        private void GCSpecOnlineGiftShowInfoHandler(RMetaEvent e)
        {
            //GCSpecOnlineGiftShowInfo msg = e.data as GCSpecOnlineGiftShowInfo;

        }

		private void GCChannelExchangeHandler(RMetaEvent e)
        {
        	GCChannelExchange msg = e.data as GCChannelExchange;
        	
        }

        private void GCVipInfoHandler(RMetaEvent e)
        {
            GCVipInfo msg = e.data as GCVipInfo;
            PlayerModel.Ins.MyVipInfo = msg;
        }

		private void GCBehaviorInfoHandler(RMetaEvent e)
        {
        	GCBehaviorInfo msg = e.data as GCBehaviorInfo;
		    PlayerModel.Ins.BehaviorInfoList = msg;
        }

		private void GCDay7TaskUpdateHandler(RMetaEvent e)
        {
        	GCDay7TaskUpdate msg = e.data as GCDay7TaskUpdate;
        	QuestModel.Ins.updateOneQuest(msg.getQuestInfo());
        }
        
        private void GCDay7TaskListHandler(RMetaEvent e)
        {
        	GCDay7TaskList msg = e.data as GCDay7TaskList;
            for (int i = 0; i < msg.getQuestInfo().Length; i++)
            {
                QuestModel.Ins.updateOneQuest(msg.getQuestInfo()[i]);
            }
            QuestModel.Ins.dispatchChangeEvent(QuestModel.UPDATE_QIRI_MUBIAO_QUEST,msg);
        }
        
        private void GCLoginDaysHandler(RMetaEvent e)
        {
        	GCLoginDays msg = e.data as GCLoginDays;
            PlayerModel.Ins.HasLoginDays = msg.getDay();
        }

		private void GCCreateTimeHandler(RMetaEvent e)
        {
        	GCCreateTime msg = e.data as GCCreateTime;
			Human.Instance.CreateTime = msg.getCreateTime();
        }

        private void GCXianhuPanelHandler(RMetaEvent e)
        {
            GCXianhuPanel msg = e.data as GCXianhuPanel;
            XianHuModel.Ins.XianHuPanel = msg;
        }

        private void GCXianhuRankListHandler(RMetaEvent e)
        {
            GCXianhuRankList msg = e.data as GCXianhuRankList;
            XianHuModel.Ins.SetXianHuRankList(msg.getRankType(),msg);
        }
                
        private void GCMonthCardInfoHandler(RMetaEvent e)
        {
        	GCMonthCardInfo msg = e.data as GCMonthCardInfo;
            YueKaModel.Ins.MonthCardInfo = msg;
        }

    }
}