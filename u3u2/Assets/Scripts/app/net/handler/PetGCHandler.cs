using System.Collections.Generic;
using app.human;
using app.pet;
using app.yunliang;
using app.zone;
using app.utils;
using app.partnerformation;
using app.xinfa;
using app.db;

namespace app.net
{
    public class PetGCHandler : IGCHandler
    {
        public const string GCAddPetEvent = "GCAddPetEvent";
        public const string GCPetListEvent = "GCPetListEvent";
        public const string GCPetInfoEvent = "GCPetInfoEvent";
        public const string GCPetAddPointEvent = "GCPetAddPointEvent";
        public const string GCPetChangeFightStateEvent = "GCPetChangeFightStateEvent";
        public const string GCPetChangeNameEvent = "GCPetChangeNameEvent";
        public const string GCPetFireEvent = "GCPetFireEvent";
        public const string GCPetRefreshTalentSkillEvent = "GCPetRefreshTalentSkillEvent";
        public const string GCPetStudyNormalSkillEvent = "GCPetStudyNormalSkillEvent";
        public const string GCPetRejuvenEvent = "GCPetRejuvenEvent";
        public const string GCPetVariationEvent = "GCPetVariationEvent";
        public const string GCPetArtificeEvent = "GCPetArtificeEvent";
        public const string GCPetTrainUpdateEvent = "GCPetTrainUpdateEvent";
        public const string GCPetPerceptAddExpEvent = "GCPetPerceptAddExpEvent";
        public const string GCPetHorseRideEvent = "GCPetHorseRideEvent";
        public const string GCPetHorseChangeNameEvent = "GCPetHorseChangeNameEvent";
		public const string GCPetHorseFireEvent = "GCPetHorseFireEvent";
		public const string GCPetHorseRejuvenEvent = "GCPetHorseRejuvenEvent";
		public const string GCPetHorseArtificeEvent = "GCPetHorseArtificeEvent";
		public const string GCPetHorseTrainUpdateEvent = "GCPetHorseTrainUpdateEvent";
		public const string GCPetHorsePerceptAddExpEvent = "GCPetHorsePerceptAddExpEvent";
        public const string GCPetHorseCurPropUpdateEvent = "GCPetHorseCurPropUpdateEvent";
        public const string GCPetFriendUnlockListEvent = "GCPetFriendUnlockListEvent";
        public const string GCPetFriendArrayListEvent = "GCPetFriendArrayListEvent";
        public const string GCPetFriendInfoEvent = "GCPetFriendInfoEvent";
        public const string GCPetAddExpEvent = "GCPetAddExpEvent";
        public const string GCPetCurPropUpdateEvent = "GCPetCurPropUpdateEvent";
        public const string GCPetPoolUpdateEvent = "GCPetPoolUpdateEvent";
        public const string GCPetResetPointEvent = "GCPetResetPointEvent";
		public const string GCPetLeaderStudySkillEvent = "GCPetLeaderStudySkillEvent";
		public const string GCPetSkillEffectUpdateEvent = "GCPetSkillEffectUpdateEvent";
		public const string GCPetSkillEffectUplevelEvent = "GCPetSkillEffectUplevelEvent";
		public const string GCPetAffinationEvent = "GCPetAffinationEvent";
		public const string GCAddPetSkillbarNumEvent = "GCAddPetSkillbarNumEvent";
		public const string GCPetHorseAffinationEvent = "GCPetHorseAffinationEvent";
		public const string GCAddPetHorseSkillbarNumEvent = "GCAddPetHorseSkillbarNumEvent";
		public const string GCPetHorseRefreshTalentSkillEvent = "GCPetHorseRefreshTalentSkillEvent";
		public const string GCPetHorseStudyNormalSkillEvent = "GCPetHorseStudyNormalSkillEvent";
		public const string GCPetHorseSoulLinkPetEvent = "GCPetHorseSoulLinkPetEvent";
		
        private YunLiangModel yunliangModel = null;
        private XinFaModel xinfaModel = null;
        private PetModel petModel = null;

        public PetGCHandler()
        {
            EventCore.addRMetaEventListener(GCAddPetEvent, GCAddPetHandler);
            EventCore.addRMetaEventListener(GCPetListEvent, GCPetListHandler);
            EventCore.addRMetaEventListener(GCPetInfoEvent, GCPetInfoHandler);
            EventCore.addRMetaEventListener(GCPetAddPointEvent, GCPetAddPointHandler);
            EventCore.addRMetaEventListener(GCPetChangeFightStateEvent, GCPetChangeFightStateHandler);
            EventCore.addRMetaEventListener(GCPetChangeNameEvent, GCPetChangeNameHandler);
            EventCore.addRMetaEventListener(GCPetFireEvent, GCPetFireHandler);
            EventCore.addRMetaEventListener(GCPetRefreshTalentSkillEvent, GCPetRefreshTalentSkillHandler);
            EventCore.addRMetaEventListener(GCPetStudyNormalSkillEvent, GCPetStudyNormalSkillHandler);
            EventCore.addRMetaEventListener(GCPetRejuvenEvent, GCPetRejuvenHandler);
            EventCore.addRMetaEventListener(GCPetVariationEvent, GCPetVariationHandler);
            EventCore.addRMetaEventListener(GCPetArtificeEvent, GCPetArtificeHandler);
            EventCore.addRMetaEventListener(GCPetTrainUpdateEvent, GCPetTrainUpdateHandler);
            EventCore.addRMetaEventListener(GCPetPerceptAddExpEvent, GCPetPerceptAddExpHandler);
            EventCore.addRMetaEventListener(GCPetHorseRideEvent, GCPetHorseRideHandler);
            EventCore.addRMetaEventListener(GCPetHorseChangeNameEvent, GCPetHorseChangeNameHandler);
            EventCore.addRMetaEventListener(GCPetHorseFireEvent, GCPetHorseFireHandler);
            EventCore.addRMetaEventListener(GCPetHorseRejuvenEvent, GCPetHorseRejuvenHandler);
            EventCore.addRMetaEventListener(GCPetHorseArtificeEvent, GCPetHorseArtificeHandler);
            EventCore.addRMetaEventListener(GCPetHorseTrainUpdateEvent, GCPetHorseTrainUpdateHandler);
            EventCore.addRMetaEventListener(GCPetHorsePerceptAddExpEvent, GCPetHorsePerceptAddExpHandler);
            EventCore.addRMetaEventListener(GCPetHorseCurPropUpdateEvent, GCPetHorseCurPropUpdateHandler);
            EventCore.addRMetaEventListener(GCPetFriendUnlockListEvent, GCPetFriendUnlockListHandler);
            EventCore.addRMetaEventListener(GCPetFriendArrayListEvent, GCPetFriendArrayListHandler);
            EventCore.addRMetaEventListener(GCPetFriendInfoEvent, GCPetFriendInfoHandler);
            EventCore.addRMetaEventListener(GCPetAddExpEvent, GCPetAddExpHandler);
            EventCore.addRMetaEventListener(GCPetCurPropUpdateEvent, GCPetCurPropUpdateHandler);
            EventCore.addRMetaEventListener(GCPetPoolUpdateEvent, GCPetPoolUpdateHandler);
            EventCore.addRMetaEventListener(GCPetResetPointEvent, GCPetResetPointHandler);
			EventCore.addRMetaEventListener(GCPetLeaderStudySkillEvent, GCPetLeaderStudySkillHandler);
            EventCore.addRMetaEventListener(GCPetSkillEffectUpdateEvent, GCPetSkillEffectUpdateHandler);
			EventCore.addRMetaEventListener(GCPetSkillEffectUplevelEvent, GCPetSkillEffectUplevelHandler);
			EventCore.addRMetaEventListener(GCPetAffinationEvent, GCPetAffinationHandler);
			EventCore.addRMetaEventListener(GCAddPetSkillbarNumEvent, GCAddPetSkillbarNumHandler);
            EventCore.addRMetaEventListener(GCPetHorseAffinationEvent, GCPetHorseAffinationHandler);
            EventCore.addRMetaEventListener(GCAddPetHorseSkillbarNumEvent, GCAddPetHorseSkillbarNumHandler);
            EventCore.addRMetaEventListener(GCPetHorseRefreshTalentSkillEvent, GCPetHorseRefreshTalentSkillHandler);
            EventCore.addRMetaEventListener(GCPetHorseStudyNormalSkillEvent, GCPetHorseStudyNormalSkillHandler);
            EventCore.addRMetaEventListener(GCPetHorseSoulLinkPetEvent, GCPetHorseSoulLinkPetHandler);
        }

        private void GCAddPetHandler(RMetaEvent e)
        {
            GCAddPet msg = e.data as GCAddPet;
            PetInfo petInfo = msg.getPetInfo();
            Pet pet = new Pet(petInfo.petId);
            pet.PetInfo = petInfo;
            Human.Instance.AddPetHandler(pet);
            Human.Instance.PetModel.addPet(pet);
            Human.Instance.PetModel.dispathcAddPet();
        }

        private void GCPetListHandler(RMetaEvent e)
        {
            GCPetList msg = e.data as GCPetList;
            PetInfo[] petArr = msg.getPetInfoList();

            List<Pet> petList = new List<Pet>();
            for (int i = 0; i < petArr.Length; i++)
            {
                PetInfo petInfo = petArr[i];
                Pet pet = new Pet(petInfo.petId);
                pet.PetInfo = petInfo;
                petList.Add(pet);
            }
            Human.Instance.PetModel.initPetList(petList);
        }

        private void GCPetInfoHandler(RMetaEvent e)
        {
            GCPetInfo msg = e.data as GCPetInfo;
            Human.Instance.PetModel.UpdatePetInfo(msg.getPetInfo());
        }

        private void GCPetAddPointHandler(RMetaEvent e)
        {
            GCPetAddPoint msg = e.data as GCPetAddPoint;
            Human.Instance.PetModel.petAddPointCallBack(msg);
        }

        private void GCPetChangeFightStateHandler(RMetaEvent e)
        {
            GCPetChangeFightState msg = e.data as GCPetChangeFightState;
            //刷新界面显示
            Human.Instance.PetModel.GCPetChangeFightStateHandler(msg);
        }

        private void GCPetChangeNameHandler(RMetaEvent e)
        {
            GCPetChangeName msg = e.data as GCPetChangeName;
            //刷新界面显示
            Human.Instance.PetModel.GCPetChangeNameHandler(msg);
        }

        private void GCPetFireHandler(RMetaEvent e)
        {
            GCPetFire msg = e.data as GCPetFire;
            if (msg.getResult() == 1)
            {
                Human.Instance.PetModel.removePet(msg.getPetId());
            }
        }

        private void GCPetRejuvenHandler(RMetaEvent e)
        {
            GCPetRejuven msg = e.data as GCPetRejuven;
            EventCore.dispathRMetaEventByParms(PetLeftInfoScript.SHOW_PET_UPGRADE_EFFECT, null);
        }

        private void GCPetVariationHandler(RMetaEvent e)
        {
            GCPetVariation msg = e.data as GCPetVariation;
            Human.Instance.PetModel.GCPetVariationHandler(msg);
            EventCore.dispathRMetaEventByParms(PetLeftInfoScript.SHOW_PET_UPGRADE_EFFECT, null);
        }

        private void GCPetArtificeHandler(RMetaEvent e)
        {
            GCPetArtifice msg = e.data as GCPetArtifice;
            if (msg.getResult() == 1)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("炼化成功，获得新的成长率");
            }

            EventCore.dispathRMetaEventByParms(PetLeftInfoScript.SHOW_PET_UPGRADE_EFFECT, null);
        }
        private void GCPetPerceptAddExpHandler(RMetaEvent e)
        {
            GCPetPerceptAddExp msg = e.data as GCPetPerceptAddExp;
            string str = null;
            if (msg.getResult() == 1)
            {
                if (msg.getBigCritNum() > 0)
                {
                    //触发了大暴击。
                    str = "恭喜您触发" + msg.getBigCritNum() + "次大暴击，直接提升" + msg.getBigCritNum() + "级！";
                    ZoneBubbleManager.ins.BubbleSysMsg(str);
                }
                if (msg.getSmallCritNum() > 0)
                {
                    //触发了小暴击。
                    str = "恭喜您，触发" + msg.getSmallCritNum() + "次小暴击获得10倍经验，获得" + msg.getSmallCritSumExp() + "经验！";
                    ZoneBubbleManager.ins.BubbleSysMsg(str);
                }
                if (msg.getNormalSumExp() > 0)
                {
                    str = "恭喜您获得" + msg.getNormalSumExp() + "经验！";
                    ZoneBubbleManager.ins.BubbleSysMsg(str);
                }
            }

            EventCore.dispathRMetaEventByParms(PetLeftInfoScript.SHOW_PET_UPGRADE_EFFECT, null);
        }

        private void GCPetHorseRideHandler(RMetaEvent e)
        {
            GCPetHorseRide msg = e.data as GCPetHorseRide;
            if (ZoneCharacterManager.ins.self != null && PropertyUtil.IsLegalID(msg.getPetId()) && msg.getResult() == 1)
            {
                if (yunliangModel == null)
                {
                    //yunliangModel = Singleton.getObj(typeof(YunLiangModel)) as YunLiangModel;
                    yunliangModel = YunLiangModel.Ins;
                }
                if (msg.getState() == 1 && !yunliangModel.isYunLiangIng())
                {
                    Pet pet = Human.Instance.PetModel.getPet(msg.getPetId());
                    if (pet != null)
                    {
                        ZoneCharacterManager.ins.self.Ride(pet.getTpl().Id);
                    }
                }
                else
                {
                    ZoneCharacterManager.ins.self.UnRide(true);
                }
            }
            Human.Instance.PetModel.GCPetHorseChangeFightState(msg);
        }

        private void GCPetHorseChangeNameHandler(RMetaEvent e)
        {
        	GCPetHorseChangeName msg = e.data as GCPetHorseChangeName;
        	
        }
        
        private void GCPetHorseFireHandler(RMetaEvent e)
        {
        	GCPetHorseFire msg = e.data as GCPetHorseFire;
            if(msg.getResult() == 1 )
            {
                PetModel.Ins.removePet(msg.getPetId());
            }

        	
        }
        
        private void GCPetHorseRejuvenHandler(RMetaEvent e)
        {
        	GCPetHorseRejuven msg = e.data as GCPetHorseRejuven;
            PetModel.Ins.dispatchChangeEvent(PetModel.PET_HORSE_HUAN_TONG, msg);
        	
        }
        
        private void GCPetHorseArtificeHandler(RMetaEvent e)
        {
        	GCPetHorseArtifice msg = e.data as GCPetHorseArtifice;
            if (msg.getResult() == 1)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("炼化成功，获得新的成长率");
            }

            EventCore.dispathRMetaEventByParms(PetLeftInfoScript.SHOW_PET_UPGRADE_EFFECT, null);
        }
        
        private void GCPetHorseTrainUpdateHandler(RMetaEvent e)
        {
        	GCPetHorseTrainUpdate msg = e.data as GCPetHorseTrainUpdate;
        	
        }
        
        private void GCPetHorsePerceptAddExpHandler(RMetaEvent e)
        {
        	GCPetHorsePerceptAddExp msg = e.data as GCPetHorsePerceptAddExp;
            string str = null;
            if (msg.getResult() == 1)
            {
                if (msg.getBigCritNum() > 0)
                {
                    //触发了大暴击。
                    str = "恭喜您触发" + msg.getBigCritNum() + "次大暴击，直接提升" + msg.getBigCritNum() + "级！";
                    ZoneBubbleManager.ins.BubbleSysMsg(str);
                }
                if (msg.getSmallCritNum() > 0)
                {
                    //触发了小暴击。
                    str = "恭喜您，触发" + msg.getSmallCritNum() + "次小暴击获得10倍经验，获得" + msg.getSmallCritSumExp() + "经验！";
                    ZoneBubbleManager.ins.BubbleSysMsg(str);
                }
                if (msg.getNormalSumExp() > 0)
                {
                    str = "恭喜您获得" + msg.getNormalSumExp() + "经验！";
                    ZoneBubbleManager.ins.BubbleSysMsg(str);
                }
            }

            EventCore.dispathRMetaEventByParms(PetLeftInfoScript.SHOW_PET_UPGRADE_EFFECT, null);
        	
        }
        private void GCPetHorseCurPropUpdateHandler(RMetaEvent e)
        {
            GCPetHorseCurPropUpdate msg = e.data as GCPetHorseCurPropUpdate;
            PetModel.Ins.GCPetHorseCurPropUpdateHandler(msg);
        }


        private void GCPetFriendUnlockListHandler(RMetaEvent e)
        {
            GCPetFriendUnlockList msg = e.data as GCPetFriendUnlockList;
            PartnerFormationManager.ins.OnPetFriendUnlockListReceived(msg.getPetFriendUnlockInfoList());
        }

        private void GCPetFriendArrayListHandler(RMetaEvent e)
        {
            GCPetFriendArrayList msg = e.data as GCPetFriendArrayList;
            Human.Instance.PetModel.UpdatePetFriendArrayInfoList(msg.getPetFriendArrayInfoList(), msg.getCurArrayIndex());
        }

        private void GCPetFriendInfoHandler(RMetaEvent e)
        {
            GCPetFriendInfo msg = e.data as GCPetFriendInfo;
            PartnerFormationManager.ins.OnPetFriendInfoReceived(msg);
        }

        private void GCPetAddExpHandler(RMetaEvent e)
        {
            GCPetAddExp msg = e.data as GCPetAddExp;
            if (msg.getPetId() == Human.Instance.PetModel.getLeader().Id)
            {
                ZoneBubbleManager.ins.BubbleHumanEXPChange(msg.getAddExp());
            }
        }

        private void GCPetCurPropUpdateHandler(RMetaEvent e)
        {
            GCPetCurPropUpdate msg = e.data as GCPetCurPropUpdate;
            Human.Instance.PetModel.GCPetCurPropUpdateHandler(msg);
        }

        private void GCPetPoolUpdateHandler(RMetaEvent e)
        {
            GCPetPoolUpdate msg = e.data as GCPetPoolUpdate;
            Human.Instance.PetModel.GCPetPoolUpdateHandler(msg);
        }

        private void GCPetRefreshTalentSkillHandler(RMetaEvent e)
        {
            GCPetRefreshTalentSkill msg = e.data as GCPetRefreshTalentSkill;
            EventCore.dispathRMetaEventByParms(PetLeftInfoScript.SHOW_PET_UPGRADE_EFFECT, null);
        }

        private void GCPetStudyNormalSkillHandler(RMetaEvent e)
        {
            GCPetStudyNormalSkill msg = e.data as GCPetStudyNormalSkill;
            EventCore.dispathRMetaEventByParms(PetLeftInfoScript.SHOW_PET_UPGRADE_EFFECT, null);
        }

        private void GCPetTrainUpdateHandler(RMetaEvent e)
        {
            GCPetTrainUpdate msg = e.data as GCPetTrainUpdate;
            EventCore.dispathRMetaEventByParms(PetLeftInfoScript.SHOW_PET_UPGRADE_EFFECT, null);
        }

        private void GCPetResetPointHandler(RMetaEvent e)
        {
            GCPetResetPoint msg = e.data as GCPetResetPoint;
            if (msg.getResult() == 1)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("洗点成功");
            }
        }

		private void GCPetLeaderStudySkillHandler(RMetaEvent e)
        {
        	GCPetLeaderStudySkill msg = e.data as GCPetLeaderStudySkill;
            if (msg.getResult() == 1)
            {
                if (xinfaModel == null)
                {
                    xinfaModel = XinFaModel.instance;
                }
                xinfaModel.dispatchChangeEvent(XinFaModel.SKILL_LEARN_SUCCESS, msg);
                LeaderSkillBookTemplate skillBookTpl = LeaderSkillBookTemplateDB.Instance.getTemplate(msg.getItemTplId());
                SkillTemplate skillTpl = SkillTemplateDB.Instance.getTemplate(skillBookTpl.skillId);
                ZoneBubbleManager.ins.BubbleSysMsg("恭喜你，获得新技能：" + skillTpl.name);
            }
        }
        
        private void GCPetSkillEffectUpdateHandler(RMetaEvent e)
        {
        	GCPetSkillEffectUpdate msg = e.data as GCPetSkillEffectUpdate;

            if (petModel == null)
            {
                petModel = PetModel.Ins;
            }

            petModel.GetLeaderSkillInfo(msg.getSkillId()).embedSkillEffectList = msg.getEmbedSkillEffectList();

            if (xinfaModel == null)
            {
                xinfaModel = XinFaModel.instance;
            }
            xinfaModel.dispatchChangeEvent(XinFaModel.SKILL_EFFECT_UPDATE, msg);
        }
		private void GCPetSkillEffectUplevelHandler(RMetaEvent e)
        {
        	GCPetSkillEffectUplevel msg = e.data as GCPetSkillEffectUplevel;
            if (msg.getResult() == 1)
            {
                xinfaModel.dispatchChangeEvent(XinFaModel.SKILL_EFFECT_UPGRADE_SUCCESS, msg);
            }
        }

                
        private void GCPetAffinationHandler(RMetaEvent e)
        {
        	GCPetAffination msg = e.data as GCPetAffination;
            if (1 == msg.getResult())
            {
                EventCore.dispathRMetaEventByParms(PetLeftInfoScript.SHOW_PET_UPGRADE_EFFECT, null);
            }
        }
		
		
		private void GCAddPetSkillbarNumHandler(RMetaEvent e)
        {
        	GCAddPetSkillbarNum msg = e.data as GCAddPetSkillbarNum;
            PetModel.Ins.dispatchChangeEvent(PetModel.PET_JINENG_LAN_UPDATE, msg);
        }
		
		        
        private void GCPetHorseAffinationHandler(RMetaEvent e)
        {
        	GCPetHorseAffination msg = e.data as GCPetHorseAffination;
            if (1 == msg.getResult())
            {
                EventCore.dispathRMetaEventByParms(PetLeftInfoScript.SHOW_PET_UPGRADE_EFFECT, null);
            }
        }
        
        private void GCAddPetHorseSkillbarNumHandler(RMetaEvent e)
        {
        	GCAddPetHorseSkillbarNum msg = e.data as GCAddPetHorseSkillbarNum;
            PetModel.Ins.dispatchChangeEvent(PetModel.PET_JINENG_LAN_UPDATE, msg);
        }
        
        private void GCPetHorseRefreshTalentSkillHandler(RMetaEvent e)
        {
        	GCPetHorseRefreshTalentSkill msg = e.data as GCPetHorseRefreshTalentSkill;
            EventCore.dispathRMetaEventByParms(PetLeftInfoScript.SHOW_PET_UPGRADE_EFFECT, null);
        }
        
        private void GCPetHorseStudyNormalSkillHandler(RMetaEvent e)
        {
        	GCPetHorseStudyNormalSkill msg = e.data as GCPetHorseStudyNormalSkill;
            EventCore.dispathRMetaEventByParms(PetLeftInfoScript.SHOW_PET_UPGRADE_EFFECT, null);
        }

        private void GCPetHorseSoulLinkPetHandler(RMetaEvent e)
        {
        	GCPetHorseSoulLinkPet msg = e.data as GCPetHorseSoulLinkPet;
            PetSoulLinkInfo[] list = msg.getPetSoulLinkInfoList();
            for (int i = 0; i < list.Length; ++i)
            {
                Pet temp = Human.Instance.PetModel.getPet(list[i].petId);
                temp.PetInfo.soulLinkPetHorseId = list[i].soulLinkPetHorseId;
            }
        }
		
    }
}