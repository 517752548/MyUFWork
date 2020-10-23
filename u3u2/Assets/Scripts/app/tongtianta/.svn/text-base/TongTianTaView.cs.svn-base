using UnityEngine;
using app.battle;
using app.pet;
using UnityEngine.UI;
using app.net;
using app.db;
using app.main;
using System.Collections.Generic;
using app.zone;
using System.Collections;
using app.tips;
using app.model;


namespace app.tongtianta
{
    public class TongTianTaView : BaseWnd
    {
        private const int CHAPTER_FLOOR_COUNT = 4;
        //private const string DEFENCE_SPRITE_NAME = "fangyuy";
        //private const string ATTACK_SPRITE_NAME = "gongjiy";
        //private const int ATLASTYPE_NORMAL = 1;
        //private const int ATLASTYPE_SKILL = 2;
        //private static Vector3 sPlayerUIOrignal = new Vector3(114.03f, -146.01f, -400);
        //private static Vector3 sPlayerEndPos = new Vector3(114.03f, 174.22f, -400);
        //private static Vector3 sPetOrignal = new Vector3(383.26f, -146.01f, -400);
        //private static Vector3 sPetEndPos = new Vector3(383.26f, 174.22f, -400);
        public TongTianTaUI TongTianTaUi;

        //private BattleSkillListUI skillListUI;

        private TongTianTaJiangLiUI rewardUI;
        private TongTianTaJiangliScript jiangliScript;

        //Image image;
        //Text skillText;
        //int atlasType;
        //string spriteName;
        //string skillName;

        List<FloorItem> floorItems = new List<FloorItem>();

        List<TowerMapTemplate> towerTpls;
        private int mChapeter;
        public int chapter
        {
            get
            {
                return mChapeter;
            }
            set
            {
                mChapeter = value;
                InitChapter();
            }
        }

        private bool isInit = false;

        private static  TongTianTaView mIns;
        public static TongTianTaView ins
        {
            get
            {
                if (mIns == null)
                {
                    mIns = new TongTianTaView();
                }
                return mIns;
            }
        }
        

        public TongTianTaView():base()
        {
            uiName = "TongTianTaUI";
            hasSubUI = true;
        }

        public override void initWnd()
        {
            base.initWnd();
            TongTianTaUi = ui.AddComponent<TongTianTaUI>();
            TongTianTaUi.Init();
            //TongTianTaUi.playerSkillBtn.SetClickCallBack(OnClickPlayerSkill);
            //TongTianTaUi.petSkillBtn.SetClickCallBack(OnClickPetSkill);
            //skillListUI = new BattleSkillListUI(TongTianTaUi.battleSkillListUI,TongTianTaUi.skillMaskImage);
            TongTianTaUi.closeBtn.SetClickCallBack(Close);
            //EventTriggerListener.Get(TongTianTaUi.skillMaskImage).onClick = HidePop;
            //skillListUI.onLeaderAutoSkillSelected = OnLeaderAutoSkillSelected;
            //skillListUI.onLeaderAutoAtkSelected = OnLeaderAutoAtkSelected;
            //skillListUI.onLeaderAutoDefSelected = OnLeaderAutoDefSelected;
            //skillListUI.onPetAutoSkillSelected = OnPetAutoSkillSelected;
            //skillListUI.onPetAutoAtkSelected = OnPetAutoAtkSelected;
            //skillListUI.onPetAutoDefSelected = OnPetAutoDefSelected;
            //skillListUI.showSkillDetail = false;

            //BattleModel.ins.addChangeEvent(BattleModel.PLAYER_AUTO_SKILL_CHANE,OnPlayerAutoSkillChange);
            //BattleModel.ins.addChangeEvent(BattleModel.PET_AUTO_SKILL_CHANGE,OnPetAutoSkillChange);

            TongTianTaUi.chakanjiangliBtn.SetClickCallBack(OnClickReward);
            TongTianTaUi.shuomingBtn.SetClickCallBack(ClickShuoMing);
            //TongTianTaUi.kaiqiBtn.SetClickCallBack(ClickDoubleStatus);
            //TongTianTaUi.yuandiguajiBtn.SetClickCallBack(ClickGuaji);
            TongTianTaUi.btn_leftArrow.SetClickCallBack(OnClickLeftArrow);
            TongTianTaUi.btn_rightArrow.SetClickCallBack(OnClickRightArrow);          
            
            TongTianTaModel.ins.addChangeEvent(TongTianTaModel.UPDATE_TOWERINFO,SetTowerInfo);
            TongTianTaModel.ins.addChangeEvent(TongTianTaModel.GET_TOWER_REWARD,GetTowerReward);
            TongTianTaModel.ins.addChangeEvent(TongTianTaModel.START_AUTO,OnStartAuto);

            GetTowerMapTpls();
            CreatFloorItems();
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);              
            //TongTianTaUi.battleSkillListUI.gameObject.SetActive(false);
            GameClient.ins.OnBigWndShown();
            //InitSkillIcon();
            //TongTianTaUi.skillMaskImage.gameObject.SetActive(false);
            ModelShowSwitch(true);
            TowerCGHandler.sendCGTowerInfo();

        }

        public void Close()
        {           
            hide();         
        }

        public override void hide(RMetaEvent e = null)
        {
            //if (skillListUI != null)
            //{
            //    skillListUI.Clear();
            //}
            GameClient.ins.OnBigWndHidden();
            base.hide(e);
            ModelShowSwitch(false);

        }

        protected override void clickSpaceArea(GameObject go)
        {
            Close();
        }



        private void HidePop(GameObject go)
        {
            //if(skillListUI != null)
            //{
            //    skillListUI.Hide();
            //}
        }
        /*
        #region 挂机技能
        private void OnPlayerAutoSkillChange(RMetaEvent e = null)
        {
            InitPlayerSkillIcon();
        }
        private void OnPetAutoSkillChange(RMetaEvent e = null)
        {
            InitPetSkillIcon();
        }

        private void InitSkillIcon()
        {
            InitPlayerSkillIcon();
            InitPetSkillIcon();
        }

        private void InitPlayerSkillIcon()
        {
            GetSkillInfo(1, BattleModel.ins.leaderActivedSkillId, out image, out skillText, out atlasType, out spriteName, out skillName);
            SetSkillIcon(image, skillText, atlasType, spriteName, skillName);
        }

        private void InitPetSkillIcon()
        {
            GetSkillInfo(2, BattleModel.ins.petActivedSkillId, out image, out skillText, out atlasType, out spriteName, out skillName);
            SetSkillIcon(image, skillText, atlasType, spriteName, skillName);
        }

        /// <summary>
        /// 得到技能所需要展示的信息
        /// </summary>
        /// <param name="type">1为人物技能 2为宠物技能</param>
        /// <param name="skillId"></param>
        /// <param name="image"></param>
        /// <param name="AtlasType"></param>
        /// <param name="atlasName"></param>
        private void GetSkillInfo(int type,int skillId,out Image image,out Text skillText,out int AtlasType,out string atlasName,out string skillName)
        {
            if(type == 1)
            {
               image = TongTianTaUi.imagePlayerSkill;
               skillText = TongTianTaUi.textPlayerSkill;
            }
            else
            {
                image = TongTianTaUi.imagePetSkill;
                skillText = TongTianTaUi.textPetSkill;
            }
            if (skillId == BatSkillID.NORMAL_ATTACK)
            {
                AtlasType = ATLASTYPE_NORMAL;
                atlasName = ATTACK_SPRITE_NAME;
                skillName = "普攻";

            }
            else if(skillId == BatSkillID.DEFENSE)
            {
                AtlasType = ATLASTYPE_NORMAL;
                atlasName = DEFENCE_SPRITE_NAME;
                skillName = "防御";
            }
            else
            { 
                AtlasType = ATLASTYPE_SKILL;
                SkillTemplate tpl = SkillTemplateDB.Instance.getTemplate(skillId);
                if(tpl == null)
                {
                   
                    atlasName = null;
                    skillName = "";
                }
                else
                {
                    atlasName = tpl.icon;
                    skillName = tpl.name;
                }
            }
                   
        }

       

        private void SetSkillIcon(Image image,Text textSkillName,int atlasType,string spriteName,string skillName)
        { 
            if(!image || !textSkillName)
            {
                return;
            }
            if(string.IsNullOrEmpty(spriteName))
            {
                image.gameObject.SetActive(false);
                return;
            }
            if(atlasType == ATLASTYPE_NORMAL)
            {
                 image.sprite = SourceManager.Ins.GetAsset<Sprite>(PathUtil.Ins.uiDependenciesPath, spriteName);
            }
            else if(atlasType == ATLASTYPE_SKILL)
            {
                PathUtil.Ins.SetSkillIcon(image,spriteName + "-1");
            }
            textSkillName.text = skillName;                      
        }
        private void OnClickPlayerSkill()
        {
            skillListUI.UI.transform.localPosition = sPlayerUIOrignal;
            skillListUI.Show(PetModel.Ins.getLeader().PetInfo, PetType.LEADER, true);                        
            TweenUtil.MoveTo(skillListUI.UI.transform, sPlayerEndPos, 0.1f);           
        }

        private void OnClickPetSkill()
        { 
            Pet fightPet = PetModel.Ins.getChongWu();
            if (fightPet != null)
            {
                skillListUI.UI.transform.localPosition = sPetOrignal;
                skillListUI.Show(fightPet.PetInfo, PetType.PET, true);
                TweenUtil.MoveTo(skillListUI.UI.transform, sPetEndPos, 0.1f);
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("无出战宠物");
            }
        }



        private void OnLeaderAutoSkillSelected(PetSkillInfo skillInfo, SkillTemplate skillTpl, SkillEffectTemplate skillEffectTpl)
        {
            ShowAutoLeaderSkill(skillInfo, skillTpl);
            BattleCGHandler.sendCGBattleUpdateAutoAction((int)PetType.LEADER, skillInfo.skillId);
        }

        private void ShowAutoLeaderSkill(PetSkillInfo skillInfo, SkillTemplate skillTpl)
        {
            skillListUI.OnActivedAutoSkillConfirmed(PetType.LEADER, skillInfo.skillId);
        }

        private void OnLeaderAutoAtkSelected()
        {
            ShowAutoLeaderAtkBtn();
            BattleCGHandler.sendCGBattleUpdateAutoAction((int)PetType.LEADER, BatSkillID.NORMAL_ATTACK);         
        }

        private void ShowAutoLeaderAtkBtn()
        {
            skillListUI.OnActivedAutoSkillConfirmed(PetType.LEADER, BatSkillID.NORMAL_ATTACK);
        }

        private void OnLeaderAutoDefSelected()
        {
            ShowAutoLeaderDefBtn();
            BattleCGHandler.sendCGBattleUpdateAutoAction((int)PetType.LEADER, BatSkillID.DEFENSE);
        }

        private void ShowAutoLeaderDefBtn()
        {
            skillListUI.OnActivedAutoSkillConfirmed(PetType.LEADER, BatSkillID.DEFENSE);
        }

        private void OnPetAutoSkillSelected(PetSkillInfo skillInfo, SkillTemplate skillTpl, SkillEffectTemplate skillEffectTpl)
        {
            ShowAutoPetSkill(skillInfo, skillTpl);
            BattleCGHandler.sendCGBattleUpdateAutoAction((int)PetType.PET, skillInfo.skillId);
        }

        private void ShowAutoPetSkill(PetSkillInfo skillInfo, SkillTemplate skillTpl)
        {

            skillListUI.OnActivedAutoSkillConfirmed(PetType.PET, skillInfo.skillId);
        }

        private void OnPetAutoAtkSelected()
        {
            ShowAutoPetAtkBtn();
            BattleCGHandler.sendCGBattleUpdateAutoAction((int)PetType.PET, BatSkillID.NORMAL_ATTACK);
           
        }

        private void ShowAutoPetAtkBtn()
        {
            skillListUI.OnActivedAutoSkillConfirmed(PetType.PET, BatSkillID.NORMAL_ATTACK);
        }
           

        private void OnPetAutoDefSelected()
        {
            ShowAutoPetDefBtn();
            BattleCGHandler.sendCGBattleUpdateAutoAction((int)PetType.PET, BatSkillID.DEFENSE);
        }
        
        private void ShowAutoPetDefBtn()
        {
            skillListUI.OnActivedAutoSkillConfirmed(PetType.PET, BatSkillID.DEFENSE);
        }
        #endregion
        */
        #region 通天塔

        private void GetTowerMapTpls()
        {
            towerTpls = new List<TowerMapTemplate>();
            Dictionary<int, TowerMapTemplate> templates = TowerMapTemplateDB.Instance.getIdKeyDic();

            foreach (var item in templates)
            {
                towerTpls.Add(item.Value);
            }
            towerTpls.Sort(delegate(TowerMapTemplate x, TowerMapTemplate y)
            {
                return x.towerLevelId.CompareTo(y.towerLevelId);
            });
 
        }

        private void CreatFloorItems()
        {
            floorItems.Clear();
            for (int i = 0; i < TongTianTaUi.floorItemUIs.Length; i++)
            {
                FloorItem item = new FloorItem(TongTianTaUi.floorItemUIs[i],this);
                floorItems.Add(item);
            }
        }

        private void SetTowerInfo(RMetaEvent e = null)
        {
            TowerInfo towerInfo = TongTianTaModel.ins.towerInfo;
            if (towerInfo == null)
            {
                ClientLog.LogError("towerInfo is null");
                return;
            }
            //TongTianTaUi.textDoubleReward.text = "双倍点数："+ towerInfo.curDoublePoint.ToString();
            //TongTianTaUi.doubleText.text = towerInfo.openDouble == 1 ? "关闭" : "开启" ;
            GetCurretChapter();

            GuideManager.Ins.ShowGuide(GuideIdDef.TongTianTa, 2, floorItems[0].UI.itemBtn.gameObject,Vector3.zero,new Vector3(-15,15,0),Vector3.zero,new Vector2(207,347), true, 200);

        }

        private void InitChapter()
        {
            for (int i = 0; i < floorItems.Count; i++)
            {
                floorItems[i].SetData(towerTpls[i + mChapeter * CHAPTER_FLOOR_COUNT]);
            }
            CheckArrowState();
        }

        private void GetCurretChapter()
        {
            int currentLevel = TongTianTaModel.ins.towerInfo.curTowerLevel;
            if (currentLevel % CHAPTER_FLOOR_COUNT == 0 && currentLevel > 0)
            {
                chapter = currentLevel / CHAPTER_FLOOR_COUNT - 1;
            }
            else
            {
                chapter = currentLevel / CHAPTER_FLOOR_COUNT;
            }
        }

        private void OnClickLeftArrow()
        {
            if (0 == chapter)
            {
                return;
            }
            chapter -= 1;
        }

        private void OnClickRightArrow()
        {
            if (chapter >= ((towerTpls.Count / CHAPTER_FLOOR_COUNT)-1))
            {
                return;
            }
            chapter += 1;
        }

        private void CheckArrowState()
        {
            TongTianTaUi.btn_leftArrow.gameObject.SetActive(chapter > 0);
            TongTianTaUi.btn_rightArrow.gameObject.SetActive(chapter < towerTpls.Count/CHAPTER_FLOOR_COUNT - 1);
        }

        //private void ClickDoubleStatus()
        //{
        //    if (TongTianTaModel.ins.towerInfo != null)
        //    {
        //        TowerCGHandler.sendCGOpenDoubleStatus(TongTianTaModel.ins.towerInfo.openDouble == 1 ? 0 : 1);
        //    }
            
        //}

        private void ClickGuaji()
        {
            TowerCGHandler.sendCGGuaji(ZoneModel.ins.tryEnterZoneId);
        }

        private void ModelShowSwitch(bool show)
        {
            if (floorItems == null)
            {
                return;
            }
            for (int i = 0; i < floorItems.Count; i++)
            {
                if (show)
                {
                    floorItems[i].ShowAvatarModel();
                }
                else
                {
                    floorItems[i].HideAvatarModel();
                }
            }
        }


        #endregion

        #region 查看奖励

        private void OnClickReward()
        {
            TowerCGHandler.sendCGTowerReward();
        }

        private void GetTowerReward(RMetaEvent e = null)
        {
            if (TongTianTaUi.objJiangLi)
            {
                if (jiangliScript == null)
                {
                    jiangliScript = new TongTianTaJiangliScript(rewardUI);
                }
                jiangliScript.Show();
            }
            else
            {
                TongTianTaUi.StartCoroutine(InitRewardPanel(1));
            }
        }
        IEnumerator InitRewardPanel(int waitFrame)
        {
            for (int i = 0; i < waitFrame; i++)
            {
                yield return null;
            }
            TongTianTaUi.objJiangLi = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "JiangLi"));
            TongTianTaUi.objJiangLi.transform.SetParent(TongTianTaUi.transform);
            TongTianTaUi.objJiangLi.transform.localPosition = new Vector3(0,0,-500);
            TongTianTaUi.objJiangLi.transform.localScale = Vector3.one;
            rewardUI = TongTianTaUi.objJiangLi.AddComponent<TongTianTaJiangLiUI>();
            rewardUI.Init();
            jiangliScript = new TongTianTaJiangliScript(rewardUI);
            jiangliScript.Show();
            
        }
        #endregion

        private void OnStartAuto(RMetaEvent e = null)
        {
            hide();
        }


        private void ClickShuoMing()
        {
            PopInfoWnd.Ins.ShowInfo(
         "1、通天塔内挂机可获得丰厚奖励\n2、组队人数越多，经验值越丰厚\n"
         +"3、打败通天塔守护者可获得一次性丰厚奖励\n4、帮助他人打败守护者，可获得助战经验奖励\n",
         "通天塔说明", TextAnchor.MiddleLeft, 520);
        }

        public override void Destroy()
        {
            //BattleModel.ins.removeChangeEvent(BattleModel.PLAYER_AUTO_SKILL_CHANE, OnPlayerAutoSkillChange);
            //BattleModel.ins.removeChangeEvent(BattleModel.PET_AUTO_SKILL_CHANGE, OnPetAutoSkillChange);
            if (floorItems != null)
            {
                for (int i = 0; i < floorItems.Count; i++)
                {
                    floorItems[i].Destroy();
                }
                floorItems.Clear();
                floorItems = null;
            }
            TongTianTaModel.ins.removeChangeEvent(TongTianTaModel.UPDATE_TOWERINFO, SetTowerInfo);
            TongTianTaModel.ins.removeChangeEvent(TongTianTaModel.GET_TOWER_REWARD, GetTowerReward);
            TongTianTaModel.ins.removeChangeEvent(TongTianTaModel.START_AUTO, OnStartAuto);
            //if (skillListUI != null)
            //{
            //    skillListUI.Destroy();
            //    skillListUI = null;
            //}
            if (jiangliScript != null)
            {
                jiangliScript.Destroy();
                jiangliScript = null;
            }

            base.Destroy();
            TongTianTaUi = null;
            
        }




    }
}
