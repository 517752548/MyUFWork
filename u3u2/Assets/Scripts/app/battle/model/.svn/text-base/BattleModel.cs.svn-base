using System;
using app.model;
using app.zone;
using UnityEngine;
using System.Collections.Generic;
using app.net;
using app.db;
using app.pet;
using app.human;
using app.role;

namespace app.battle
{
    public class BattleModel:AbsModel
    {
        public const string PLAYER_AUTO_SKILL_CHANE = "PLAYER_AUTO_SKILL_CHANE";
        public const string PET_AUTO_SKILL_CHANGE = "PET_AUTO_SKILL_CHANGE";

        public float battleTime { get; set; }
        public float battleFixedTime { get; set; }

        public float viewportWidth { get; set; }
        public float viewportHeight { get; set; }
        /// <summary>
        /// 战斗结束返回类型
        /// </summary>
        public int battleToBackType { get; set; }
        public BattleType battleType { get; set; }
        public BattleSubType battleSubType { get; set; }
        public List<BatRoundData> roundData { get; set; }

        public BatRoundData lastRoundData { get; set; }
        public BatRoundData curRoundData { get; set; }
        public BattleRoundStatusType curRoundStatus { get; set; }
        public int curRoundNum { get; set; }
        public float curRoundWaitTimeLeft { get; set; }

        public ManualBattleOptItem mainRoleManualOptItem { get; private set; }
        public ManualBattleOptItem mainPetManualOptItem { get; private set; }

        //public float battleSpeed { get; set; }

        public float maxModelHeight { get; set; }

        public BatCharacterSiteType selfSiteType { get; set; }

        public int leaderActivedSkillId { get; private set; }
        public int petActivedSkillId { get; private set; }

        public bool canUpdate { get; set; }

        public List<long> charactersNeedHidePrepareSign { get; set; }
        /*
        public bool isPlayingBattleStartEffect { get; set; }
        public bool isBattleStartEffectPlaied { get; set; }
        public bool isBattleStartEffectPlayFinished { get; set; }
        public bool isFirstRoundIsInitRound { get; set; }
        */
        public int useItemTimeLeft { get; set; }
        //本场战斗中死亡的宠物。
        public List<long> deadPetIds = new List<long>();
        /// <summary>
        /// 战斗结果，1:胜利；2:失败
        /// </summary>
        private int battleResult = 0;
        //public Vector3 atkPosesOffset { get; set; }
        //public Vector3 defPosesOffset { get; set; }

        private List<string> mUndisposableResPathList = new List<string>();
        /// <summary>
        /// 当前pvp目标
        /// </summary>
        public GCBattleStartPvpInvite pvptarget{ get; set; }

        public RoleInfoView roleInfoView { get; set; }
        
        public int battleSpeedFast
        {
            get
            {
                return ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.BATTLE_SPEEDUP_X);
            }
        }

        private static BattleModel mIns;

        public static BattleModel ins
        {
            get
            {
                if (mIns == null)
                {
                    mIns = new BattleModel();
                }
                return mIns;
            }
        }

        /// <summary>
        /// 战斗结果，1:胜利；2:失败
        /// </summary>
        public int BattleResult
        {
            get { return battleResult; }
            set { battleResult = value; }
        }

        public BattleModel()
        {
            //if (BattleModel.ins != null)
            //{
            //    throw new Exception("BattleModel instance already exists!");
            //}

            roundData = new List<BatRoundData>();
            mainRoleManualOptItem = new ManualBattleOptItem(PetType.LEADER);
            mainPetManualOptItem = new ManualBattleOptItem(PetType.PET);
            charactersNeedHidePrepareSign = new List<long>();
        }

        /// <summary>
        /// 根据实时帧率修正速度。
        /// </summary>
        /// <param name="speed">默认帧率下的速度。</param>
        /// <returns>实时速度。</returns>
        public Vector3 ReviseSpeed(Vector3 speed)
        {
            return speed * (CommonDefines.FPS / (Time.timeScale / Time.deltaTime));
        }

        /// <summary>
        /// 根据实时帧率修正速度。
        /// </summary>
        /// <param name="speed">默认帧率下的速度。</param>
        /// <returns>实时速度。</returns>
        public float ReviseSpeed(float speed)
        {
            return speed * (Application.targetFrameRate / (Time.timeScale / Time.deltaTime));
        }

        public void SetResUndisposable(string resPath)
        {
            if (!mUndisposableResPathList.Contains(resPath))
            {
                SourceManager.Ins.ignoreDispose(resPath);
                mUndisposableResPathList.Add(resPath);
            }
        }

        public void SetAllResDisposable(bool clearAllRes)
        {
            int len = mUndisposableResPathList.Count;
            for (int i = 0; i < len; i++)
            {
                SourceManager.Ins.unignoreDispose(mUndisposableResPathList[i]);
                if (clearAllRes)
                {
                    SourceManager.Ins.ClearAllReference(mUndisposableResPathList[i]);
                }
            }
            mUndisposableResPathList.Clear();
        }

        public void ChangeActivedSkill(PetType petType, int skillId)
        {
            if (petType == PetType.LEADER)
            {
                ClientLog.LogWarning("接收到后台推送 主将技能切换为  " + skillId);
                leaderActivedSkillId = skillId;
                dispatchChangeEvent(PLAYER_AUTO_SKILL_CHANE,skillId);
            }
            else if (petType == PetType.PET)
            {
                ClientLog.LogWarning("接收到后台推送 宠物技能切换为  " + skillId);
                petActivedSkillId = skillId;
                dispatchChangeEvent(PET_AUTO_SKILL_CHANGE,skillId);
            }

            if (BattleUI.ins.isShown)
            {
                BattleUI.ins.ChangeActivedSkill(petType, skillId);
            }
        }

        public SkillEffectTemplate GetLeaderSkillMainEffectTpl(PetSkillInfo skillInfo)
        {
            //int mindId = Human.Instance.PropertyManager.getIntProp(RoleBaseIntProperties.MAINSKILL_TYPE);
            //int mindLv = Human.Instance.PropertyManager.getIntProp(RoleBaseIntProperties.MAINSKILL_LEVEL);
            int xinfaid = HumanMainSkillToSubSkillTemplateDB.Instance.GetXinFaIdBySkillId(skillInfo.skillId);
            return GetSkillMainEffectTpl(skillInfo.skillId, skillInfo.level, xinfaid, 0);
        }

        public SkillEffectTemplate GetPetSkillMainEffectTpl(PetSkillInfo skillInfo)
        {
            return GetSkillMainEffectTpl(skillInfo.skillId, skillInfo.level, 0, 0);
        }

        public SkillEffectTemplate GetSkillMainEffectTpl(int skillId, int skillLv, int mindId, int mindLv)
        {
            List<int> skillEffectIdList = SkillAddTemplateDB.Instance.GetSkillEffectIdList(skillId, skillLv, mindId, mindLv);
            if (skillEffectIdList != null && skillEffectIdList.Count > 0)
            {
                SkillEffectTemplate skillEffectTpl = SkillEffectTemplateDB.Instance.getTemplate(skillEffectIdList[0]);
                if (skillEffectTpl != null)
                {
                    return skillEffectTpl;
                }
            }

            ClientLog.LogError("没有找到技能效果! 技能Id=" + skillId + ",  技能Level=" + skillLv + ",  心法Id=" + mindId + ",  心法Level=" + mindLv);
            return null;
        }
        
        public List<Pet> GetAvaliableSummonPets()
        {
            List<Pet> allPets = Human.Instance.PetModel.getPetListByType(PetType.PET);
            List<Pet> avaliablePets = new List<Pet>();
            int humanLv = Human.Instance.getLevel();
            int petCount = allPets.Count;
            for (int i = 0; i < petCount; i++)
            {
                Pet pet = allPets[i];
                if ((BattleCharacterManager.ins.mainPet == null || pet.Id != BattleCharacterManager.ins.mainPet.data.uuidL) && pet.getTpl().fightLevel <= humanLv &&
                    pet.curHp > 1 && !BattleModel.ins.deadPetIds.Contains(pet.Id) &&
                    pet.life >= ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.BATTLE_PET_LIFE_MIN))
                {
					avaliablePets.Add(pet);
                }
            }
            return avaliablePets;
        }

        public void LinkToBackType()
        {
            switch (battleToBackType)
            {
                case FunctionIdDef.JINGJICHANG:
                    if (!FunctionModel.Ins.hasNewFuncOpen()&&!GuideManager.Ins.hasWaitigGuide())
                    {
                        LinkParse.Ins.linkToFunc(FunctionIdDef.JINGJICHANG);
                    }
                    if (BattleResult==1)
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg("恭喜你：挑战成功，与对方排名互换！");
                    }
                    else if (BattleResult == 2)
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg("很遗憾：挑战失败！");
                    }
                    break;
                case FunctionIdDef.DANRENFUBEN:
                    LinkParse.Ins.linkToFunc(FunctionIdDef.DANRENFUBEN);
                    break;
                case FunctionIdDef.CORPS_BOSS:
                    LinkParse.Ins.linkToFunc(FunctionIdDef.CORPSBOSS_CHANLLGE);
                    break;
            }
            battleToBackType = 0;
        }


        public override void Destroy()
        {
            mIns = null;
        }
    }
}