using System;
using System.Collections.Generic;
using app.zone;
using app.model;
using app.db;
using app.pet;
using app.net;
using app.human;
using app.utils;
using app.team;
using DG.Tweening;
using UnityEngine;

namespace app.battle
{
    public class BattleUI : BaseUI
    {
        //[Inject(ui = "battleUI")]
        //public GameObject ui;

        public BattleUIBehav UI;

        private static BattleUI mIns = null;

        private bool mHasInitZoneUI = false;

        private UGUIImageText roundNumTxt = null;
        private UGUIImageText waitTimeTxt = null;

        private BattleSkillListUI mSkillListUI = null;
        private BattleItemListUI mItemListUI = null;
        private BattlePetListUI mPetListUI = null;

        private int mCurShowingRoundNum = 0;
        private int mLastShowingRoundWaitTimeLeft = 0;
        private int mCurShowingRoundWaitTimeLeft = 0;

        private bool mIsManualBtnsHidden = false;
        private bool mIsManualOptReseted = false;

        private ManualBattleOptItem mCurOptItem = null;
        private BatCharacter mCurOptCharacter = null;

        private BatCharacter mCharacterUnderTouch = null;

        private PetModel mPetModel = null;

        private bool mIsBattleStarted = false;
        private bool mIsManualNextRound = false;

        private bool mShowAutoBtnsAfterInitUI = false;
        private bool mShowManualBtnsAfterInitUI = false;

        private List<BatCharacter> mNotFadeOutChas = new List<BatCharacter>();

        //private bool mIsHiddenManualBtnsForPet = false;

        private PetSkillInfo mLeaderActivedSkillInfo = null;
        private SkillTemplate mLeaderActivedSkillTpl = null;
        private SkillEffectTemplate mLeaderActivedSkillEffectTpl = null;

        private PetSkillInfo mPetActivedSkillInfo = null;
        private SkillTemplate mPetActivedSkillTpl = null;
        private SkillEffectTemplate mPetActivedSkillEffectTpl = null;

        private GameObject mLastClickedBtn = null;

        private BattleFrontSkillListUI mLeaderFrontSkills = null;
        private BattleFrontSkillListUI mPetFrontSkills = null;

        public static BattleUI ins
        {
            get
            {
                if (mIns == null)
                {
                    mIns = Singleton.GetObj(typeof(BattleUI)) as BattleUI;
                }
                return mIns;
            }
        }

        public BattleUI()
        {
            if (mIns != null)
            {
                throw new Exception("BattleUI instance already exists!");
            }
            
            uiName = "battleUI";
            //mPetModel = Singleton.getObj(typeof(PetModel)) as PetModel;
            mPetModel = PetModel.Ins;
        }

        public void Init()
        {
            if (isShown)
            {
                UI.Show();
                UpdateData();
            }
            else
            {
                preLoadUI();
            }
        }
        /*
        public override void initUILayer(WndType uilayer = WndType.FirstWND)
        {
            base.initUILayer(WndType.MAINUI);
        }
        */

        public override void initUI()
        {
            base.initUI();
            roundNumTxt = new UGUIImageText();
            waitTimeTxt = new UGUIImageText();
            UI = ui.AddComponent<BattleUIBehav>();
            UI.Init();

            UI.autoLeaderAtkBtn.SetClickCallBack(OnLeaderAutoActionBtnClicked);
            UI.autoLeaderDefBtn.SetClickCallBack(OnLeaderAutoActionBtnClicked);
            UI.autoLeaderSkillBtn.SetClickCallBack(OnLeaderAutoActionBtnClicked);
            UI.autoPetAtkBtn.SetClickCallBack(OnPetAutoActionBtnClicked);
            UI.autoPetDefBtn.SetClickCallBack(OnPetAutoActionBtnClicked);
            UI.autoPetSkillBtn.SetClickCallBack(OnPetAutoActionBtnClicked);
            UI.manualBtn.SetClickCallBack(ManualBattleBtnClicked);
            UI.manualCancelBtn.SetClickCallBack(OnCancelBtnClicked);

            /*
            UI.autoBtn.SetClickCallBack(AutoBattleBtnClicked);
            UI.manualAtkBtn.SetClickCallBack(OnAtkClicked);
            UI.manualCatchBtn.SetClickCallBack(OnCatchClicked);
            UI.manualEscapeBtn.SetClickCallBack(OnEscapeClicked);
            UI.manualDefBtn.SetClickCallBack(OnDefClicked);
            UI.manualSkillBtn.SetClickCallBack(OnManualSkillBtnClicked);
            UI.manualItemsBtn.SetClickCallBack(OnManualItemBtnClicked);
            UI.manualCallBtn.SetClickCallBack(OnManualCallBtnClicked);
            UI.leaderActivedSkillBtn.SetClickCallBack(OnLeaderActivedSkillClicked);
            UI.petActivedSkillBtn.SetClickCallBack(OnPetActivedSkillClicked);
            */

            UI.manualBtnsTbg.TabChangeHandler = OnManualBtnsIdxChanged;
            UI.manualBtnsTbg.AllTabCloseHandler = OnManualBtnsUnselectAll;

            UI.manualCancelBtn.gameObject.SetActive(false);

            roundNumTxt.SetParent(UI.roundNumContainer.transform);
            roundNumTxt.gameObject.transform.localPosition = Vector3.zero;
            roundNumTxt.gameObject.transform.localScale = Vector3.one;
            waitTimeTxt.SetParent(UI.waitTimeContainer.transform);
            waitTimeTxt.gameObject.transform.localPosition = Vector3.zero;
            waitTimeTxt.gameObject.transform.localScale = Vector3.one;
            waitTimeTxt.gameObject.transform.SetAsFirstSibling();
            UI.JiaSuBtn.AddValueChangedCallBack(onClickJiasu);

            mSkillListUI = new BattleSkillListUI(UI.skillListUIBehav, UI.maskImage);
            mSkillListUI.onManualSkillSelected = OnManualSkillSelected;
            mSkillListUI.onLeaderAutoSkillSelected = OnLeaderAutoSkillSelected;
            mSkillListUI.onLeaderAutoAtkSelected = OnLeaderAutoAtkSelected;
            mSkillListUI.onLeaderAutoDefSelected = OnLeaderAutoDefSelected;
            mSkillListUI.onPetAutoSkillSelected = OnPetAutoSkillSelected;
            mSkillListUI.onPetAutoAtkSelected = OnPetAutoAtkSelected;
            mSkillListUI.onPetAutoDefSelected = OnPetAutoDefSelected;

            mItemListUI = new BattleItemListUI(UI.itemListUIBehav, UI.maskImage);
            mItemListUI.onItemSelected = OnManualItemSelected;

            mPetListUI = new BattlePetListUI(UI.petListUIBehav, UI.maskImage);
            mPetListUI.onPetSelected = OnPetItemSelected;

            EventTriggerListener.Get(UI.maskImage).onClick = OnMaskImageClicked;
            //UI.maskImage.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
            UI.maskImage.GetComponent<RectTransform>().sizeDelta = new Vector2(UGUIConfig.UISpaceWidth, UGUIConfig.UISpaceHeight);

            mLeaderFrontSkills = new BattleFrontSkillListUI(UI.leaderFrontSkills, OnLeaderFrontSkillSelected);
            mPetFrontSkills = new BattleFrontSkillListUI(UI.petFrontSkills, OnPetFrontSkillSelected);

            //UpdateData();

            //temp
            /*
            UI.aL.SetClickCallBack(OnALClicked);
            UI.aR.SetClickCallBack(OnARClicked);
            UI.aT.SetClickCallBack(OnATClicked);
            UI.aB.SetClickCallBack(OnABClicked);
            
            UI.dL.SetClickCallBack(OnDLClicked);
            UI.dR.SetClickCallBack(OnDRClicked);
            UI.dT.SetClickCallBack(OnDTClicked);
            UI.dB.SetClickCallBack(OnDBClicked);
            
            UI.start.SetClickCallBack(OnStartBtnClicked);
            */
        }

        private void OnManualBtnsIdxChanged(int idx)
        {
            if (idx >= 0 && idx < UI.manualBtnsTbg.toggleList.Count)
            {
                GameUUToggle toggle = UI.manualBtnsTbg.toggleList[idx];
                if (toggle != null)
                {
                    UI.tiao.gameObject.SetActive(true);
                    UI.tiao.SetParent(toggle.transform);
                    UI.tiao.localPosition = new Vector3(-30, -10, 0);
                }
                else
                {
                    UI.tiao.gameObject.SetActive(false);
                }
            }
            else
            {
                UI.tiao.gameObject.SetActive(false);
            }

            if (idx >= 0)
            {
                switch(idx)
                {
                    case 0:
                        AutoBattleBtnClicked();
                        break;
                    case 1:
                        OnManualSkillBtnClicked();
                        break;
                    case 2:
                        OnManualItemBtnClicked();
                        break;
                    case 3:
                        OnAtkClicked();
                        break;
                    case 4:
                        OnDefClicked();
                        break;
                    case 5:
                        OnManualCallBtnClicked();
                        break;
                    case 6:
                        OnCatchClicked();
                        break;
                    case 7:
                        OnEscapeClicked();
                        break;
                    default:
                        break;
                }
            }
        }

        private void OnManualBtnsUnselectAll()
        {
            OnManualBtnsIdxChanged(-1);
        }

        //private bool isJiasu = false;


        private void onClickJiasu(bool state)
        {
            /*
            isJiasu = state;
            if (isJiasu)
            {
                BattleModel.ins.battleSpeed = 5f;
            }
            else
            {
                BattleModel.ins.battleSpeed = 1f;
            }
            Time.timeScale = BattleModel.ins.battleSpeed;
            */

            if (BattleModel.ins.battleType == BattleType.PLAY_BATTLE_REPORT)
            {
                if (UI.JiaSuBtn.isOn)
                {
                    Time.timeScale = BattleModel.ins.battleSpeedFast;
                }
                else
                {
                    Time.timeScale = BattleDef.PLAY_REPORT_NOR_SPEED;
                }
            }

            if ((Human.Instance.PlayerModel.battlePlaySpeed == BattleDef.PLAY_REPORT_NOR_SPEED && state) ||
                (Human.Instance.PlayerModel.battlePlaySpeed == BattleModel.ins.battleSpeedFast && !state))
            {
                int speed = (state ? BattleModel.ins.battleSpeedFast : BattleDef.PLAY_REPORT_NOR_SPEED);
                Human.Instance.PlayerModel.battlePlaySpeed = speed;
                BattleCGHandler.sendCGBattleSpeedup(speed);
            }
        }

        private void OnMaskImageClicked(GameObject go)
        {
            HideSubPopUps();
        }

        public void UpdateData()
        {
            if (BattleModel.ins.battleType == BattleType.PLAY_BATTLE_REPORT)
            {
                AutoBattle(true);
                mShowAutoBtnsAfterInitUI = false;
                mShowManualBtnsAfterInitUI = false;
            }
            else if (BattleModel.ins.battleType == BattleType.PVE)
            {
                if (GuideManager.Ins.CurrentGuideId == GuideIdDef.FirstBattle)
                {
                    ManualBattle(true);
                }
                else
                {
                    AutoBattle(true);
                }
                mShowAutoBtnsAfterInitUI = false;
                mShowManualBtnsAfterInitUI = false;
            }
            else
            {
                if (BattleModel.ins.curRoundData != null)
                {
                    if (BattleModel.ins.curRoundData.pvpRoundIsAutoBattle || BattleModel.ins.curRoundData.teamRoundIsAutoBattle)
                    {
                        AutoBattle(true);
                    }
                    else
                    {
                        ManualBattle(true);
                    }

                    mShowAutoBtnsAfterInitUI = false;
                    mShowManualBtnsAfterInitUI = false;
                }
            }

            if (mShowAutoBtnsAfterInitUI)
            {
                AutoBattle(true);
            }
            else if (mShowManualBtnsAfterInitUI)
            {
                ManualBattle(true);
            }

            if (!mHasInitZoneUI)
            {
                //ui.SetActive(false);
                //ZoneUI.ins.Init();
                //ZoneUI.ins.hideAll();
                mIsBattleStarted = false;
                mHasInitZoneUI = true;
            }

            ChangeActivedSkill(PetType.LEADER, BattleModel.ins.leaderActivedSkillId);
            mLeaderFrontSkills.SetData(mPetModel.getLeader());
            mPetFrontSkills.SetData(mPetModel.getChongWu());
            UpdateJiaSuBtnStatus();
            
            /*
            if (Human.Instance.PetModel.getChongWu() != null)
            {
                BatCharacter mainPet = BattleCharacterManager.ins.mainPet;
                
                ClientLog.LogError("mainPet:" + mainPet);
                if (mainPet != null)
                {
                    ClientLog.LogError(mainPet.isAlive + "  " + mainPet.isActive);
                }
                
                if (mainPet == null || (mainPet.isAlive && mainPet.isActive))
                {
                    ShowPetSkillBtns();
                    ChangeActivedSkill(PetType.PET, BattleModel.ins.petActivedSkillId);
                }
                else
                {
                    HidePetSkillBtns();
                }
            }
            else
            {
                HidePetSkillBtns();
            }
            */
            //UI.offsetValue.text = BattleModel.ins.defPosesOffset.ToString("f1") + "  " + BattleModel.ins.atkPosesOffset.ToString("f1");
        }

        private void OnFightPetChanged(RMetaEvent e)
        {
            mPetFrontSkills.SetData(mPetModel.getChongWu());
        }

        public void BattleRoundStarted()
        {
            if (isShown)
            {
                if (mIsManualBtnsHidden)
                {
                    OnCancelBtnClicked();
                }

                if (!mIsManualOptReseted)
                {
                    ResetManualOperation();
                }

                //HideSubPopUps();
            }
        }

        public void ShowPetSkillBtns()
        {
            if (BatSkillID.HasValue(BattleModel.ins.petActivedSkillId))
            {
                //UI.petActivedSkillBtn.gameObject.SetActive(false);
                UI.autoPetAtkBtn.gameObject.SetActive(BattleModel.ins.petActivedSkillId == BatSkillID.NORMAL_ATTACK);
                UI.autoPetDefBtn.gameObject.SetActive(BattleModel.ins.petActivedSkillId == BatSkillID.DEFENSE);
                UI.autoPetSkillBtn.gameObject.SetActive(false);
            }
            else
            {
                //UI.petActivedSkillBtn.gameObject.SetActive(true);
                UI.autoPetAtkBtn.gameObject.SetActive(false);
                UI.autoPetDefBtn.gameObject.SetActive(false);
                UI.autoPetSkillBtn.gameObject.SetActive(true);
            }
            UI.autoPetSkillSign.gameObject.SetActive(true);
        }

        public void HidePetSkillBtns()
        {
            UI.autoPetAtkBtn.gameObject.SetActive(false);
            UI.autoPetDefBtn.gameObject.SetActive(false);
            UI.autoPetSkillBtn.gameObject.SetActive(false);
            UI.autoPetSkillSign.gameObject.SetActive(false);
            //UI.petActivedSkillBtn.gameObject.SetActive(false);
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            UI.Show();
            UpdateData();
            mPetModel.addChangeEvent(PetModel.UPDATE_PET_FIGHT_STATE, OnFightPetChanged);
            /*
            if (BattleModel.ins.isPlayingBattleStartEffect || !BattleCharacterManager.ins.isReadyToFight)
            {
                ui.SetActive(false);
            }
            */
        }

        public override void hide(RMetaEvent e = null)
        {
            mHasInitZoneUI = false;
            mCurShowingRoundNum = 0;
            mLastShowingRoundWaitTimeLeft = 0;
            mCurShowingRoundWaitTimeLeft = 0;

            mIsManualBtnsHidden = false;
            mIsManualOptReseted = false;

            mCurOptItem = null;
            mCurOptCharacter = null;

            mCharacterUnderTouch = null;

            mIsBattleStarted = false;
            mIsManualNextRound = false;

            mShowAutoBtnsAfterInitUI = false;
            mShowManualBtnsAfterInitUI = false;

            if (UI != null && UI.selectedItemTips!=null) UI.selectedItemTips.SetActive(false);

            BattleCharacterManager.ins.FadeInAllCharacters();
            if (mNotFadeOutChas!=null) mNotFadeOutChas.Clear();
            if (mSkillListUI!=null) mSkillListUI.Clear();
            if (mItemListUI != null) mItemListUI.Clear();
            HideSubPopUps();
            base.hide(e);
            UI.Hide();

            mPetModel.removeChangeEvent(PetModel.UPDATE_PET_FIGHT_STATE, OnFightPetChanged);
        }
        
        public override void Update()
        {
            base.Update();
            if (!mIsBattleStarted)
            {
                /*
                if (BattleCharacterManager.ins.isReadyToFight &&
                    (!BattleModel.ins.isFirstRoundIsInitRound || (BattleModel.ins.isFirstRoundIsInitRound && BattleModel.ins.isBattleStartEffectPlayFinished)))
                */
                if (BattleCharacterManager.ins.isReadyToFight)
                {
                    mIsBattleStarted = true;
                    //ui.SetActive(true);
                    
                    //this.setAsLastSibling(UI.gameObject);

                    if (BattleModel.ins.battleType != BattleType.PLAY_BATTLE_REPORT)
                    {
                        BattleManager.ins.UpdateMainRoleInfo(BattleCharacterManager.ins.mainRole);

                        if (Human.Instance.PetModel.getChongWu() != null)
                        {
                            BatCharacter mainPet = BattleCharacterManager.ins.mainPet;

                            BattleManager.ins.UpdateMainPetInfo(mainPet);

                            if (mainPet.isAlive && mainPet.isActive)
                            {
                                ShowPetSkillBtns();
                                ChangeActivedSkill(PetType.PET, BattleModel.ins.petActivedSkillId);
                            }
                            else
                            {
                                HidePetSkillBtns();
                            }
                        }
                        else
                        {
                            HidePetSkillBtns();
                        }
                    }
                }
                return;
            }

            /*
            if (BattleModel.ins.battleType == BattleType.PVP)
            {
                if (BattleModel.ins.curRoundData != null)
                {
                    if (BattleModel.ins.curRoundData.pvpRoundIsAutoBattle)
                    {
                        AutoBattle(true);
                    }
                    else
                    {
                        ManualBattle();
                    }
                }
            }
            */
            if (BattleModel.ins.battleSubType == BattleSubType.MANUAL)
            {
                if (BattleModel.ins.curRoundWaitTimeLeft <= 0)
                {
                    /*
                    if (UI.manualBtns.activeSelf)
                    {
                        //ui.SetActive(false);
                        UI.manualBtns.SetActive(false);
                    }
                    */

                    if (mIsManualBtnsHidden)
                    {
                        OnCancelBtnClicked();
                    }

                    if (!mIsManualOptReseted)
                    {
                        ResetManualOperation();
                    }

                    HideSubPopUps();
                    mLeaderFrontSkills.Hide();
                    mPetFrontSkills.Hide();
                    if (GuideManager.Ins.CurrentGuideId==GuideIdDef.FirstBattle)
                    {
                        if (!GuideManager.Ins.isCurHightLight())
                        {
                            //等待30s没有操作，直接跳过战斗引导
                            GuideManager.Ins.RemoveGuide(GuideIdDef.FirstBattle);
                        }
                    }
                }
                else
                {
                    if (BattleModel.ins.mainRoleManualOptItem.isDone && BattleModel.ins.mainPetManualOptItem.isDone)
                    {
                        BattleManager.ins.RequestNextRound();
                        ResetManualOperation();
                        if (UI.manualBtns.activeSelf)
                        {
                            //ui.SetActive(false);
                            UI.manualBtns.SetActive(false);

                        }
                        mLeaderFrontSkills.Hide();
                        mPetFrontSkills.Hide();
                        //切换到高亮状态
                        GuideManager.Ins.switchMask(GuideIdDef.FirstBattle, true);
                    }
                    else
                    {
                        if (!UI.manualBtns.activeSelf)
                        {
                            //ui.SetActive(true);
                            UI.manualBtns.SetActive(true);
                            ResetManualOperation();
                            if (BattleModel.ins.battleSubType == BattleSubType.MANUAL &&
                                BattleModel.ins.curRoundStatus == BattleRoundStatusType.ROUND_END_FINISH &&
                                BattleModel.ins.curRoundWaitTimeLeft > 0)
                            {
                                GuideManager.Ins.ShowGuide(GuideIdDef.FirstBattle, 6, UI.autoBtn.gameObject,Vector3.zero,new Vector3(0,-17,0),Vector3.zero,new Vector2(60,26) );
                            }
                        }

                        NextManualOperation();

                        if (isCanCheckCharacterTouch)
                        {
                            CheckCharacterTouch();
                        }
                    }
                }
            }
            else
            {
                if (BattleModel.ins.curRoundWaitTimeLeft > 0 && mIsManualNextRound)
                {
                    ManualBattle(true);
                    mIsManualNextRound = false;
                }
            }

            UpdateRoundNum();
            UpdateRoundWaitTime();
        }

        private void UpdateRoundNum()
        {
            int curRoundNum = BattleModel.ins.curRoundNum;
            if (mCurShowingRoundNum != curRoundNum && curRoundNum >= 0)
            {
                mCurShowingRoundNum = curRoundNum;
                char[] chars = mCurShowingRoundNum.ToString().ToCharArray();
                int len = chars.Length;
                string[] content = new string[len];
                for (int i = 0; i < len; i++)
                {
                    content[i] = chars[i].ToString() + "_4";
                }
                roundNumTxt.SetContent(PathUtil.Ins.uiDependenciesPath, content);
            }
        }

        private void UpdateRoundWaitTime()
        {
            int curRoundWaitTimeLeft = Mathf.CeilToInt(BattleModel.ins.curRoundWaitTimeLeft);

            if (mCurShowingRoundWaitTimeLeft != curRoundWaitTimeLeft && curRoundWaitTimeLeft >= 0)
            {
                mLastShowingRoundWaitTimeLeft = mCurShowingRoundWaitTimeLeft;
                mCurShowingRoundWaitTimeLeft = curRoundWaitTimeLeft;
                //List<Sprite> sps = new List<Sprite>();
                bool isRoundNeedWait = false;
                if (BattleModel.ins.battleSubType != BattleSubType.MANUAL)
                {
                    if (mCurShowingRoundWaitTimeLeft >= BattleDef.MANUAL_ROUND_CD_SECONDS - BattleDef.AUTO_ROUND_CD_SECONDS)
                    {
                        isRoundNeedWait = true;
                    }
                }
                else
                {
                    if (mCurShowingRoundWaitTimeLeft > 0)
                    {
                        isRoundNeedWait = true;
                    }
                }

                if (isRoundNeedWait)
                {
                    char[] chars = mCurShowingRoundWaitTimeLeft.ToString().ToCharArray();
                    int len = chars.Length;
                    string[] content = new string[len];
                    for (int i = 0; i < len; i++)
                    {
                        content[i] = chars[i].ToString() + "_5";
                        //sps.Add(SourceManager.Ins.GetImageText(chars[i].ToString() + "_5"));
                    }
                    waitTimeTxt.SetContent(PathUtil.Ins.uiDependenciesPath, content, -9.0f);
                    UI.waitTimeContainer.SetActive(true);
                }
                else
                {
                    waitTimeTxt.Clear();
                    UI.waitTimeContainer.SetActive(false);
                    if (mLastShowingRoundWaitTimeLeft - mCurShowingRoundWaitTimeLeft == 1)
                    {
                        AutoBattle(true);
                    }
                }
            }
        }

        private void CheckCharacterTouch()
        {
            /*
            if (Input.GetMouseButton(0))
            {
                BatCharacter character = GetCharacterUnderTouch();
                if (character != mCharacterUnderTouch)
                {
                    if (mCharacterUnderTouch != null)
                    {

                    }

                    mCharacterUnderTouch = character;
                }
            }
            */
            if (Input.GetMouseButtonUp(0))
            {
                mCharacterUnderTouch = GetCharacterUnderTouch();
                if (mCharacterUnderTouch != null)
                {
                    CharacterTouched(mCharacterUnderTouch);
                }
            }
        }

        private BatCharacter GetCharacterUnderTouch()
        {
            //获取屏幕坐标
            Vector3 mScreenPos = Input.mousePosition;
            //定义射线
            Camera cam = SceneModel.ins.battleCam.GetComponent<Camera>();
            Ray mRay = cam.ScreenPointToRay(mScreenPos);
            RaycastHit mHit;

            if (Physics.Raycast(mRay, out mHit))
            {
                GameObject hitGameObj = mHit.transform.gameObject;
                if (hitGameObj != null && hitGameObj.name != GlobalConstDefine.SCENE_GROUND_MODEL_NAME && !UGUIConfig.IsPointUI())
                {
                    if (hitGameObj.transform.parent != null)
                    {
                        BatCharacter character = BattleCharacterManager.ins.GetCharacter(hitGameObj.transform.parent.name);
                        return character;
                    }
                }
            }

            return null;
        }

        private void CharacterTouched(BatCharacter character)
        {
            if (character.siteType == BattleModel.ins.selfSiteType)
            {
                SelfOrPartnerTouched(character);
            }
            else
            {
                EnemyTouched(character);
            }

            if (mCurOptItem.skillId == BatSkillID.USE_ITEM)
            {
                mItemListUI.OnItemUsed(mCurOptItem.itemTplId);
            }

            if (mCurOptItem.type == PetType.LEADER)
            {
                if (BattleModel.ins.battleType == BattleType.PVP)
                {
                    BattleCGHandler.sendCGBattleLeaderReadyPvp();
                }
                else if (BattleModel.ins.battleType == BattleType.TEAM_PVE || BattleModel.ins.battleType == BattleType.TEAM_PVP)
                {
                    BattleCGHandler.sendCGBattleLeaderReadyTeam();
                }
            }
        }

        private void SelfOrPartnerTouched(BatCharacter character)
        {
            if (isCanDoManualOperate)
            {
                if (!character.isFadeOuted)
                {
                    mCurOptItem.targetPos = character.data.pos;
                    mCurOptItem.isDone = true;
                    UI.manualBtnsTbg.UnSelectAll();
                    ShowManualBtns();
                    BattleCharacterManager.ins.FadeInAllCharacters();
                    ClearNotFadeOutChas();
                }
            }
        }

        private void EnemyTouched(BatCharacter character)
        {
            if (isCanDoManualOperate)
            {
                if (!character.isFadeOuted)
                {
                    mCurOptItem.targetPos = character.data.pos + 100;
                    mCurOptItem.isDone = true;
                    UI.manualBtnsTbg.UnSelectAll();
                    BattleCharacterManager.ins.FadeInAllCharacters();
                    ClearNotFadeOutChas();
                    ShowManualBtns();
                }
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        private void AutoBattleBtnClicked()
        {
            AutoBattle(false);
            mLastClickedBtn = UI.autoBtn.gameObject;
        }

        private void ManualBattleBtnClicked()
        {
            ManualBattle(false);
            mLastClickedBtn = UI.manualBtn.gameObject;
        }

        public void AutoBattle(bool autoSwitch)
        {
            if (ui != null)
            {
                if (BattleModel.ins.battleSubType != BattleSubType.AUTO)
                {
                    BattleModel.ins.battleSubType = BattleSubType.AUTO;

                    if (mIsManualBtnsHidden)
                    {
                        OnCancelBtnClicked();
                    }

                    HideSubPopUps();
                    ResetManualOperation();
                    UI.manualBtnsTbg.UnSelectAll();
                    mLeaderFrontSkills.Hide();
                    mPetFrontSkills.Hide();
                    if (BattleModel.ins.battleType == BattleType.PLAY_BATTLE_REPORT)
                    {
                        UI.manualBtns.SetActive(false);
                        UI.autoBtns.SetActive(false);
                    }
                    else
                    {
                        UI.manualBtns.SetActive(false);
                        UI.autoBtns.SetActive(true);

                        if (BattleModel.ins.battleType == BattleType.PVP || BattleModel.ins.battleType == BattleType.TEAM_PVE || BattleModel.ins.battleType == BattleType.TEAM_PVP)
                        {
                            if (!autoSwitch)
                            {
                                BattleModel.ins.curRoundWaitTimeLeft = 0;
                            }
                        }
                    }
                }
            }
            else
            {
                mShowAutoBtnsAfterInitUI = true;
            }
        }

        public void ManualBattle(bool autoSwitch)
        {
            if (ui != null)
            {
                if (BattleModel.ins.battleSubType != BattleSubType.MANUAL)
                {
                    HideSubPopUps();
                    UI.autoBtns.SetActive(false);
                    ResetManualOperation();
                    UI.manualBtnsTbg.UnSelectAll();

                    if (BattleModel.ins.curRoundWaitTimeLeft <= 0)
                    {
                        if (!autoSwitch)
                        {
                            ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.MANUAL_NEXT_ROUND);
                        }
                        mIsManualNextRound = true;
                        //ui.SetActive(false);
                        UI.manualBtns.SetActive(false);
                    }
                    else
                    {
                        BattleModel.ins.battleSubType = BattleSubType.MANUAL;
                        UI.manualBtns.SetActive(true);
                        ShowManualBtns();
                        NextManualOperation();
                    }

                    if (BattleModel.ins.battleType == BattleType.PVP || BattleModel.ins.battleType == BattleType.TEAM_PVE || BattleModel.ins.battleType == BattleType.TEAM_PVP)
                    {
                        if (!autoSwitch)
                        {
                            if (BattleModel.ins.battleType == BattleType.PVP)
                            {
                                BattleCGHandler.sendCGBattlePvpCancelAuto();
                            }
                            else if (BattleModel.ins.battleType == BattleType.TEAM_PVE || BattleModel.ins.battleType == BattleType.TEAM_PVP)
                            {
                                BattleCGHandler.sendCGBattleTeamCancelAuto();
                            }
                        }
                    }
                }
            }
            else
            {
                mShowManualBtnsAfterInitUI = true;
            }
        }

        public void ChangeActivedSkill(PetType petType, int skillId)
        {
            if (petType == PetType.LEADER)
            {
                if (BatSkillID.HasValue(skillId))
                {
                    //UI.leaderActivedSkillBtn.gameObject.SetActive(false);
                    if (skillId == BatSkillID.NORMAL_ATTACK)
                    {
                        mLeaderActivedSkillInfo = null;
                        ShowAutoLeaderAtkBtn();
                    }
                    else if (skillId == BatSkillID.DEFENSE)
                    {
                        ShowAutoLeaderDefBtn();
                    }
                    return;
                }

                //UI.leaderActivedSkillBtn.gameObject.SetActive(true);
                //UI.leaderActivedSkillBtnIcon.gameObject.SetActive(false);

                if (mLeaderActivedSkillInfo == null || mLeaderActivedSkillInfo.skillId != skillId)
                {
                    PetSkillInfo[] skillInfos = mPetModel.GetLeaderSkillInfoList();
                    int len = skillInfos.Length;
                    for (int i = 0; i < len; i++)
                    {
                        if (skillInfos[i].skillId == skillId)
                        {
                            mLeaderActivedSkillInfo = skillInfos[i];
                            break;
                        }
                    }

                    if (mLeaderActivedSkillInfo != null)
                    {
                        mLeaderActivedSkillTpl = SkillTemplateDB.Instance.getTemplate(mLeaderActivedSkillInfo.skillId);
                        mLeaderActivedSkillEffectTpl = BattleModel.ins.GetLeaderSkillMainEffectTpl(mLeaderActivedSkillInfo);

                        ShowAutoLeaderSkill(mLeaderActivedSkillInfo, mLeaderActivedSkillTpl);
                        //ShowLeaderManualActivedSkill(mLeaderActivedSkillTpl);
                    }
                }
            }
            else if (petType == PetType.PET)
            {
                if (BatSkillID.HasValue(skillId))
                {
                    //UI.petActivedSkillBtn.gameObject.SetActive(false);
                    if (skillId == BatSkillID.NORMAL_ATTACK)
                    {
                        ShowAutoPetAtkBtn();
                    }
                    else if (skillId == BatSkillID.DEFENSE)
                    {
                        ShowAutoPetDefBtn();
                    }
                    return;
                }

                //UI.petActivedSkillBtn.gameObject.SetActive(true);
                //UI.petActivedSkillBtnIcon.gameObject.SetActive(false);

                if (mPetActivedSkillInfo == null || mPetActivedSkillInfo.skillId != skillId)
                {
                    PetSkillInfo[] skillInfos = mPetModel.GetPetSkillInfoList();
                    int len = skillInfos.Length;
                    for (int i = 0; i < len; i++)
                    {
                        if (skillInfos[i].skillId == skillId)
                        {
                            mPetActivedSkillInfo = skillInfos[i];
                            break;
                        }
                    }

                    if (mPetActivedSkillInfo != null)
                    {
                        mPetActivedSkillTpl = SkillTemplateDB.Instance.getTemplate(mPetActivedSkillInfo.skillId);
                        mPetActivedSkillEffectTpl = BattleModel.ins.GetPetSkillMainEffectTpl(mPetActivedSkillInfo);

                        ShowAutoPetSkill(mPetActivedSkillInfo, mPetActivedSkillTpl);
                        //ShowPetManualActivedSkill(mPetActivedSkillTpl);
                    }
                }
            }
        }

        /*
        private void OnLeaderActivedSkillClicked()
        {
            OnManualSkillSelected(mLeaderActivedSkillInfo, mLeaderActivedSkillTpl, mLeaderActivedSkillEffectTpl);
            mLastClickedBtn = UI.leaderActivedSkillBtn.gameObject;
        }

        private void OnPetActivedSkillClicked()
        {
            OnManualSkillSelected(mPetActivedSkillInfo, mPetActivedSkillTpl, mPetActivedSkillEffectTpl);
            mLastClickedBtn = UI.petActivedSkillBtn.gameObject;
        }
        */
        private void OnAtkClicked()
        {
            //mCurOptItem.skillTargetType = SkillTargetType.ANY_ENEMY;
            if (isCanDoManualOperate)
            {
                mCurOptItem.skillId = BatSkillID.NORMAL_ATTACK;
                mCurOptItem.needSelectTarget = true;
                HideManualBtns();
                //List<BatCharacter> chas = new List<BatCharacter>();

                List<BatCharacter> list = null;

                if (BattleModel.ins.selfSiteType == BatCharacterSiteType.ATTACKER)
                {
                    list = BattleCharacterManager.ins.defenders;
                }
                else if (BattleModel.ins.selfSiteType == BatCharacterSiteType.DEFENDER)
                {
                    list = BattleCharacterManager.ins.attackers;
                }
                else
                {
                    list = new List<BatCharacter>();
                }

                int count = list.Count;

                for (int i = 0; i < count; i++)
                {
                    if (list[i].isAlive)
                    {
                        /*
                        chas.Add(BattleCharacterManager.ins.defenders[i]);
                        BattleCharacterManager.ins.defenders[i].ShowSelectFrame();
                        */
                        AddNotFadeOutCha(list[i]);
                    }
                }
                if (list != null && list.Count>0)
                {
                    int mid = (int)(list.Count/2f);
                    GuideManager.Ins.ShowGuide(GuideIdDef.FirstBattle, 5, list[mid].GetSelectFrame(), new Vector3(100, 0, 0), Vector3.zero, Vector3.zero, new Vector2(230, 190), false);
                }
                BattleCharacterManager.ins.FadeOutAllCharacters(mNotFadeOutChas);
                UI.selectedItemTips.SetActive(true);
                UI.selectedItemName.text = "普通攻击";

                mLastClickedBtn = UI.manualAtkBtn.gameObject;
            }
        }

        private void OnCatchClicked()
        {
            if (isCanDoManualOperate)
            {
                mCurOptItem.skillId = BatSkillID.CATCH;
                mCurOptItem.needSelectTarget = true;
                HideManualBtns();

                List<BatCharacter> list = null;

                if (BattleModel.ins.selfSiteType == BatCharacterSiteType.ATTACKER)
                {
                    list = BattleCharacterManager.ins.defenders;
                }
                else if (BattleModel.ins.selfSiteType == BatCharacterSiteType.DEFENDER)
                {
                    list = BattleCharacterManager.ins.attackers;
                }
                else
                {
                    list = new List<BatCharacter>();
                }

                int count = list.Count;

                for (int i = 0; i < count; i++)
                {
                    if (list[i].data.isCanBeChatched && list[i].isAlive)
                    {
                        AddNotFadeOutCha(list[i]);
                    }
                }
                BattleCharacterManager.ins.FadeOutAllCharacters(mNotFadeOutChas);
                UI.selectedItemTips.SetActive(true);
                UI.selectedItemName.text = "捕捉";

                mLastClickedBtn = UI.manualCatchBtn.gameObject;
            }
        }

        private void OnEscapeClicked()
        {
            mCurOptItem.skillId = BatSkillID.ESCAPE;
            mCurOptItem.needSelectTarget = false;
            mCurOptItem.isDone = true;
            UI.manualBtnsTbg.UnSelectAll();
            mLastClickedBtn = UI.manualEscapeBtn.gameObject;
        }

        private void OnDefClicked()
        {
            //mCurOptCharacter.DoDefense();
            mCurOptItem.skillId = BatSkillID.DEFENSE;
            mCurOptItem.needSelectTarget = false;
            mCurOptItem.isDone = true;
            UI.manualBtnsTbg.UnSelectAll();
            mLastClickedBtn = UI.manualDefBtn.gameObject;
        }

        private void OnManualSkillBtnClicked()
        {
            if (isCanDoManualOperate)
            {
                PetInfo petInfo = null;

                if (mCurOptCharacter.data.type == PetType.LEADER)
                {
                    petInfo = mPetModel.getLeader().PetInfo;
                }
                else if (mCurOptCharacter.data.type == PetType.PET)
                {
                    petInfo = mPetModel.getChongWu().PetInfo;
                }

                if (petInfo != null)
                {
                    if (petInfo.skillList != null && petInfo.skillList.Length > 0)
                    {
                        int activeSkillCount = 0;
                        int len = petInfo.skillList.Length;
                        for (int i = 0; i < len; i++)
                        {
                            SkillTemplate skillTpl = SkillTemplateDB.Instance.getTemplate(petInfo.skillList[i].skillId);
                            if (skillTpl != null && skillTpl.isPassive == 0)
                            {
                                activeSkillCount++;
                            }
                        }

                        if (activeSkillCount > 0)
                        {
                            mSkillListUI.Show(petInfo, mCurOptCharacter.data.type, false);
                            RectTransform rt = UI.manualSkillBtn.gameObject.GetComponent<RectTransform>();
                            Vector3 xpos = UI.manualSkillBtn.gameObject.transform.TransformPoint(Vector3.zero);
                            xpos = UI.gameObject.transform.InverseTransformPoint(xpos);
                            xpos.x -= rt.sizeDelta.x / 1.0f;
                            xpos.y += rt.sizeDelta.y / 4.0f;
                            Vector3 ypos = UI.manualBtns.gameObject.transform.TransformPoint(Vector3.zero);
                            ypos = UI.gameObject.transform.InverseTransformPoint(ypos);
                            ypos.y += (mSkillListUI.height + 110);
                            mSkillListUI.UI.gameObject.transform.localPosition = new Vector3(xpos.x + 444.0f, Mathf.Min(Mathf.Max(xpos.y, ypos.y), 315.0f), 0);
                            mSkillListUI.DoMoveX(xpos.x);
                        }
                        else
                        {
                            ZoneBubbleManager.ins.BubbleSysMsg("当前宠物没有主动技能");
                            UI.manualBtnsTbg.UnSelectAll();
                        }
                    }
                    else
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg("当前宠物没有主动技能");
                        UI.manualBtnsTbg.UnSelectAll();
                    }
                }

                mLastClickedBtn = UI.manualSkillBtn.gameObject;
            }
            else
            {
                UI.manualBtnsTbg.UnSelectAll();
            }
        }

        private void OnManualSkillSelected(PetSkillInfo skillInfo, SkillTemplate skillTpl, SkillEffectTemplate skillEffectTpl)
        {
            mCurOptItem.skillId = skillInfo.skillId;

            if (skillEffectTpl != null)
            {
                ClientLog.Log(">>>>>>>>>>  选中了手动技能  技能id:" + skillTpl.Id + "   技能名称:" + skillTpl.name + "  技能效果id:" + skillEffectTpl.Id + "  是否需要选择目标:" + skillEffectTpl.targetSelect + "  技能目标类型:" + (SkillTargetType)(skillEffectTpl.targetTypeId) + "  <<<<<<<<<<");

                if (skillEffectTpl.targetSelect == 0)
                {
                    mCurOptItem.needSelectTarget = false;
                    mCurOptItem.isDone = true;
                    UI.manualBtnsTbg.UnSelectAll();
                }
                else
                {
                    mCurOptItem.needSelectTarget = true;

                    List<BatCharacter> selfList = null;
                    List<BatCharacter> enemyList = null;

                    if (BattleModel.ins.selfSiteType == BatCharacterSiteType.ATTACKER)
                    {
                        selfList = BattleCharacterManager.ins.attackers;
                        enemyList = BattleCharacterManager.ins.defenders;
                    }
                    else if (BattleModel.ins.selfSiteType == BatCharacterSiteType.DEFENDER)
                    {
                        selfList = BattleCharacterManager.ins.defenders;
                        enemyList = BattleCharacterManager.ins.attackers;
                    }
                    else
                    {
                        selfList = new List<BatCharacter>();
                        enemyList = new List<BatCharacter>();
                    }

                    int selfCount = selfList.Count;
                    int enemyCount = enemyList.Count;

                    SkillTargetType targetType = (SkillTargetType)(skillEffectTpl.targetTypeId);

                    //List<BatCharacter> chas = new List<BatCharacter>();
                    if (targetType == SkillTargetType.ENEMY)
                    {
                        for (int i = 0; i < enemyCount; i++)
                        {
                            if (enemyList[i].isAlive)
                            {
                                /*
                                chas.Add(BattleCharacterManager.ins.defenders[i]);
                                BattleCharacterManager.ins.defenders[i].ShowSelectFrame();
                                */
                                AddNotFadeOutCha(enemyList[i]);
                            }
                        }
                        if (enemyList != null && enemyList.Count>0)
                        {
                            int mid = (int)(enemyList.Count/2f);
                            GuideManager.Ins.ShowGuide(GuideIdDef.FirstBattle, 3, enemyList[mid].GetSelectFrame(), new Vector3(100, 0, 0), Vector3.zero, Vector3.zero, new Vector2(230, 190), false);
                        }
                        //BattleCharacterManager.ins.FadeOutAllCharacters(mNotFadeOutChas);
                    }
                    else if (targetType == SkillTargetType.OUR)
                    {
                        for (int i = 0; i < selfCount; i++)
                        {
                            if (selfList[i].isAlive)
                            {
                                /*
                                chas.Add(BattleCharacterManager.ins.attackers[i]);
                                BattleCharacterManager.ins.attackers[i].ShowSelectFrame();
                                */
                                AddNotFadeOutCha(selfList[i]);
                            }
                        }
                        //BattleCharacterManager.ins.FadeOutAllCharacters(mNotFadeOutChas);
                    }
                    else if (targetType == SkillTargetType.MYSELF)
                    {
                        /*
                        chas.Add(BattleCharacterManager.ins.mainRole);
                        BattleCharacterManager.ins.mainRole.ShowSelectFrame();
                        */
                        AddNotFadeOutCha(BattleCharacterManager.ins.mainRole);
                        //BattleCharacterManager.ins.FadeOutAllCharacters(mNotFadeOutChas);
                    }
                    else if (targetType == SkillTargetType.LEADER)
                    {
                        //TODO
                    }
                    else if (targetType == SkillTargetType.PET)
                    {
                        //TODO
                    }
                    else if (targetType == SkillTargetType.ENEMY_CAN_CATCH)
                    {
                        for (int i = 0; i < enemyCount; i++)
                        {
                            if (enemyList[i].data.isCanBeChatched && enemyList[i].isAlive)
                            {
                                /*
                                chas.Add(BattleCharacterManager.ins.defenders[i]);
                                BattleCharacterManager.ins.defenders[i].ShowSelectFrame();
                                */
                                AddNotFadeOutCha(enemyList[i]);
                            }
                        }
                        //BattleCharacterManager.ins.FadeOutAllCharacters(mNotFadeOutChas);
                    }
                    else if (targetType == SkillTargetType.OUR_DEAD)
                    {
                        for (int i = 0; i < selfCount; i++)
                        {
                            if (!selfList[i].isAlive)
                            {
                                /*
                                chas.Add(BattleCharacterManager.ins.attackers[i]);
                                BattleCharacterManager.ins.attackers[i].ShowSelectFrame();
                                */
                                AddNotFadeOutCha(selfList[i]);
                            }
                        }
                        //BattleCharacterManager.ins.FadeOutAllCharacters(mNotFadeOutChas);
                    }
                    else if (targetType == SkillTargetType.OUR_ALL)
                    {
                        for (int i = 0; i < selfCount; i++)
                        {
                            AddNotFadeOutCha(selfList[i]);
                        }
                        //BattleCharacterManager.ins.FadeOutAllCharacters(BattleCharacterManager.ins.attackers);
                    }
                    else if (targetType == SkillTargetType.MY_OWN_ALL)
                    {
                        for (int i = 0; i < selfCount; i++)
                        {
                            AddNotFadeOutCha(selfList[i]);
                        }
                    }
                    else if (targetType == SkillTargetType.MY_OWN_PET)
                    {
                        for (int i = 0; i < selfCount; i++)
                        {
                            if (selfList[i].data.type == PetType.PET && selfList[i].isAlive)
                            {
                                AddNotFadeOutCha(selfList[i]);
                            }
                        }
                    }
                    else if (targetType == SkillTargetType.ENEMY_PET)
                    {
                        for (int i = 0; i < enemyCount; i++)
                        {
                            if (enemyList[i].data.type == PetType.PET && enemyList[i].isAlive)
                            {
                                AddNotFadeOutCha(enemyList[i]);
                            }
                        }
                    }
                    else if (targetType == SkillTargetType.ALL_NOT_DEAD)
                    {
                        for (int i = 0; i < selfCount; i++)
                        {
                            if (selfList[i].isAlive)
                            {
                                AddNotFadeOutCha(selfList[i]);
                            }
                        }

                        for (int i = 0; i < enemyCount; i++)
                        {
                            if (enemyList[i].isAlive)
                            {
                                AddNotFadeOutCha(enemyList[i]);
                            }
                        }
                    }

                    BattleCharacterManager.ins.FadeOutAllCharacters(mNotFadeOutChas);
                    HideManualBtns();
                    UI.selectedItemTips.SetActive(true);
                    UI.selectedItemName.text = ColorUtil.getColorText(0, skillTpl.name);
                }
            }
            else
            {
                mCurOptItem.needSelectTarget = false;
                mCurOptItem.isDone = true;
                UI.manualBtnsTbg.UnSelectAll();

                if (mCurOptItem.type == PetType.LEADER)
                {
                    if (BattleModel.ins.battleType == BattleType.PVP)
                    {
                        BattleCGHandler.sendCGBattleLeaderReadyPvp();
                    }
                    else if (BattleModel.ins.battleType == BattleType.TEAM_PVE || BattleModel.ins.battleType == BattleType.TEAM_PVP)
                    {
                        BattleCGHandler.sendCGBattleLeaderReadyTeam();
                    }
                }
            }
        }

        private void OnManualItemBtnClicked()
        {
            if (BattleModel.ins.useItemTimeLeft <= 0)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("剩余使用次数为0,无法使用物品");
                UI.manualBtnsTbg.UnSelectAll();
                return;
            }

            mItemListUI.Show();
            RectTransform rt = UI.manualItemsBtn.gameObject.GetComponent<RectTransform>();
            Vector3 xpos = UI.manualItemsBtn.gameObject.transform.TransformPoint(Vector3.zero);
            xpos = UI.gameObject.transform.InverseTransformPoint(xpos);
            xpos.x -= rt.sizeDelta.x / 1.0f;
            xpos.y += rt.sizeDelta.y / 4.0f;
            Vector3 ypos = UI.manualBtns.gameObject.transform.TransformPoint(Vector3.zero);
            ypos = UI.gameObject.transform.InverseTransformPoint(ypos);
            ypos.y += (mItemListUI.height + 110);

            mItemListUI.UI.gameObject.transform.localPosition = new Vector3(xpos.x + 444.0f, Mathf.Min(Mathf.Max(xpos.y, ypos.y), 315.0f), 0);
            mItemListUI.UI.gameObject.transform.DOLocalMoveX(xpos.x, 0.1f);

            mLastClickedBtn = UI.manualItemsBtn.gameObject;
        }


        private void OnManualItemSelected(ItemTemplate itemTpl)
        {
            mCurOptItem.skillId = BatSkillID.USE_ITEM;

            if (itemTpl != null)
            {
                ClientLog.Log(">>>>>>>>>>  准备使用道具  道具模版id:" + itemTpl.Id + "   道具名称:" + itemTpl.name + "  <<<<<<<<<<");

                mCurOptItem.itemTplId = itemTpl.Id;
                mCurOptItem.needSelectTarget = true;
                mCurOptItem.isDone = false;

                List<BatCharacter> selfList = null;
                List<BatCharacter> enemyList = null;

                if (BattleModel.ins.selfSiteType == BatCharacterSiteType.ATTACKER)
                {
                    selfList = BattleCharacterManager.ins.attackers;
                    enemyList = BattleCharacterManager.ins.defenders;
                }
                else if (BattleModel.ins.selfSiteType == BatCharacterSiteType.DEFENDER)
                {
                    selfList = BattleCharacterManager.ins.defenders;
                    enemyList = BattleCharacterManager.ins.attackers;
                }
                else
                {
                    selfList = new List<BatCharacter>();
                    enemyList = new List<BatCharacter>();
                }

                int selfCount = selfList.Count;
                int enemyCount = enemyList.Count;


                for (int i = 0; i < selfCount; i++)
                {
                    if (!selfList[i].isFlied && selfList[i].isActive)
                    {
                        AddNotFadeOutCha(selfList[i]);
                    }
                }

                BattleCharacterManager.ins.FadeOutAllCharacters(mNotFadeOutChas);
                HideManualBtns();
                UI.selectedItemTips.SetActive(true);
                UI.selectedItemName.text = ColorUtil.getColorText(itemTpl.rarityId, itemTpl.name);
            }
            else
            {
                mCurOptItem.needSelectTarget = false;
                mCurOptItem.isDone = true;
                UI.manualBtnsTbg.UnSelectAll();

                if (mCurOptItem.type == PetType.LEADER)
                {
                    if (BattleModel.ins.battleType == BattleType.PVP)
                    {
                        BattleCGHandler.sendCGBattleLeaderReadyPvp();
                    }
                    else if (BattleModel.ins.battleType == BattleType.TEAM_PVE || BattleModel.ins.battleType == BattleType.TEAM_PVP)
                    {
                        BattleCGHandler.sendCGBattleLeaderReadyTeam();
                    }
                }
            }
        }

        private void OnManualCallBtnClicked()
        {
            List<Pet> pets = BattleModel.ins.GetAvaliableSummonPets();
            if (pets.Count > 0)
            {
                mPetListUI.Show(pets);
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("当前没有可召唤宠物");
                UI.manualBtnsTbg.UnSelectAll();
            }
        }
        private void OnPetItemSelected(long petUUID)
        {
            mCurOptItem.needSelectTarget = false;
            mCurOptItem.skillId = BatSkillID.SUMMON;
            mCurOptItem.summonPetUUID = petUUID;
            mCurOptItem.isDone = true;
            UI.manualBtnsTbg.UnSelectAll();
            /*
            Pet pet = Human.Instance.PetModel.getPet(petUUID);
            SourceLoader.Ins.load(PathUtil.Ins.GetCharacterDisplayModelPath(pet.getTpl().modelId), null, null, null, true);
            */
        }

        private void OnCancelBtnClicked()
        {
            ShowManualBtns();
            mCurOptItem.Reset();
            BattleCharacterManager.ins.FadeInAllCharacters();
            ClearNotFadeOutChas();

            if (BattleModel.ins.curRoundWaitTimeLeft > 0)
            {
                if (mLastClickedBtn == UI.manualSkillBtn.gameObject)
                {
                    UI.manualBtnsTbg.SetIndexWithCallBack(1);
                    //OnManualSkillBtnClicked();
                }
                else if (mLastClickedBtn == UI.manualItemsBtn.gameObject)
                {
                    UI.manualBtnsTbg.SetIndexWithCallBack(2);
                    //OnManualItemBtnClicked();
                }
                else if (mLastClickedBtn == UI.manualCallBtn.gameObject)
                {
                    UI.manualBtnsTbg.SetIndexWithCallBack(5);
                    //OnManualCallBtnClicked();
                }
                else
                {
                    UI.manualBtnsTbg.UnSelectAll();
                }
            }
        }

        private void ShowManualBtns()
        {
            if (mIsManualBtnsHidden)
            {
                if (!BattleModel.ins.mainRoleManualOptItem.isDone || !BattleModel.ins.mainPetManualOptItem.isDone)
                {
                    bool showForLeader = false;
                    if (!mCurOptItem.isDone)
                    {
                        showForLeader = (mCurOptItem.type == PetType.LEADER);
                    }

                    UI.autoBtn.gameObject.SetActive(true);
                    UI.manualAtkBtn.gameObject.SetActive(true);
                    UI.manualSkillBtn.gameObject.SetActive(true);
                    UI.manualDefBtn.gameObject.SetActive(true);
                    UI.manualItemsBtn.gameObject.SetActive(true);
                    UI.manualEscapeBtn.gameObject.SetActive(showForLeader);
                    UI.manualCallBtn.gameObject.SetActive(showForLeader);
                    UI.manualCatchBtn.gameObject.SetActive(showForLeader);
                    UI.manualCancelBtn.gameObject.SetActive(false);
                    //UI.manualBtns.SetActive(true);
                    UI.manualBtnsBg.enabled = true;
                    if (showForLeader)
                    {
                        mLeaderFrontSkills.Show();
                    }
                    else
                    {
                        mPetFrontSkills.Show();
                    }
                    //UI.leaderActivedSkillBtn.gameObject.SetActive(showForLeader && !BatSkillID.HasValue(BattleModel.ins.leaderActivedSkillId));
                    //UI.petActivedSkillBtn.gameObject.SetActive(!showForLeader && !BatSkillID.HasValue(BattleModel.ins.petActivedSkillId));
                    mIsManualBtnsHidden = false;
                }
            }
            
            GuideManager.Ins.ShowGuide(GuideIdDef.FirstBattle,1,UI.manualSkillBtn.gameObject,Vector3.zero,Vector3.zero,Vector3.zero,new Vector2(60,26));
        }

        private void HideManualBtns()
        {
            if (!mIsManualBtnsHidden)
            {
                UI.autoBtn.gameObject.SetActive(false);
                UI.manualAtkBtn.gameObject.SetActive(false);
                UI.manualSkillBtn.gameObject.SetActive(false);
                UI.manualDefBtn.gameObject.SetActive(false);
                UI.manualItemsBtn.gameObject.SetActive(false);
                UI.manualEscapeBtn.gameObject.SetActive(false);
                UI.manualCallBtn.gameObject.SetActive(false);
                UI.manualCatchBtn.gameObject.SetActive(false);
                UI.manualCancelBtn.gameObject.SetActive(true);
                //UI.manualBtns.SetActive(false);
                UI.manualBtnsBg.enabled = false;
                //UI.leaderActivedSkillBtn.gameObject.SetActive(false);
                //UI.petActivedSkillBtn.gameObject.SetActive(false);
                mIsManualBtnsHidden = true;
                mLeaderFrontSkills.Hide();
                mPetFrontSkills.Hide();
            }
        }

        private void ResetManualOperation()
        {
            BattleModel.ins.mainRoleManualOptItem.Reset();
            BattleModel.ins.mainPetManualOptItem.Reset();

            if (BattleCharacterManager.ins.mainRole == null ||
                !BattleCharacterManager.ins.mainRole.isAlive /*||
                BattleCharacterManager.ins.mainRole.data.HasStatus(BatCharacterStatus.DISABLE) ||
                BattleCharacterManager.ins.mainRole.data.HasStatus(BatCharacterStatus.CHAOS)*/)
            {
                BattleModel.ins.mainRoleManualOptItem.isDone = true;
            }

            if (BattleCharacterManager.ins.mainPet == null ||
                !BattleCharacterManager.ins.mainPet.isAlive /*||
                BattleCharacterManager.ins.mainPet.data.HasStatus(BatCharacterStatus.DISABLE) ||
                BattleCharacterManager.ins.mainPet.data.HasStatus(BatCharacterStatus.CHAOS)*/)
            {
                HidePetSkillBtns();
                BattleModel.ins.mainPetManualOptItem.isDone = true;
            }
            else
            {
                ShowPetSkillBtns();
            }
            UI.manualBtnsTbg.UnSelectAll();
            mIsManualOptReseted = true;
        }

        private void NextManualOperation()
        {
            if (!BattleModel.ins.mainRoleManualOptItem.isDone)
            {
                mCurOptItem = BattleModel.ins.mainRoleManualOptItem;
                mCurOptCharacter = BattleCharacterManager.ins.mainRole;
                //if (mIsHiddenManualBtnsForPet)
                //{
                //如果为宠物隐藏到了部分按钮，现在重新打开。
                if (!mIsManualBtnsHidden)
                {
                    UI.manualCatchBtn.gameObject.SetActive(true);
                    UI.manualCallBtn.gameObject.SetActive(true);
                    UI.manualEscapeBtn.gameObject.SetActive(true);
                    mLeaderFrontSkills.Show();
                    mPetFrontSkills.Hide();
                    //UI.leaderActivedSkillBtn.gameObject.SetActive(!BatSkillID.HasValue(BattleModel.ins.leaderActivedSkillId));
                }
                //UI.petActivedSkillBtn.gameObject.SetActive(false);
                //mIsHiddenManualBtnsForPet = false;
                //}
            }
            else if (!BattleModel.ins.mainPetManualOptItem.isDone)
            {
                mCurOptItem = BattleModel.ins.mainPetManualOptItem;
                mCurOptCharacter = BattleCharacterManager.ins.mainPet;
                //if (!mIsHiddenManualBtnsForPet)
                //{
                UI.manualCatchBtn.gameObject.SetActive(false);
                UI.manualCallBtn.gameObject.SetActive(false);
                UI.manualEscapeBtn.gameObject.SetActive(false);
                //UI.leaderActivedSkillBtn.gameObject.SetActive(false);
                if (!mIsManualBtnsHidden)
                {
                    //UI.petActivedSkillBtn.gameObject.SetActive(!BatSkillID.HasValue(BattleModel.ins.petActivedSkillId));
                    mPetFrontSkills.Show();
                    mLeaderFrontSkills.Hide();
                }

                GuideManager.Ins.ShowGuide(GuideIdDef.FirstBattle, 4, UI.manualAtkBtn.gameObject,false);
                //mIsHiddenManualBtnsForPet = true;
                //}
            }
            else
            {
                mCurOptItem = null;
                mCurOptCharacter = null;
                //if (mIsHiddenManualBtnsForPet)
                //{
                UI.manualCatchBtn.gameObject.SetActive(true);
                UI.manualCallBtn.gameObject.SetActive(true);
                UI.manualEscapeBtn.gameObject.SetActive(true);
                //mIsHiddenManualBtnsForPet = false;
                //}
            }

            if (BattleModel.ins.mainRoleManualOptItem.isDone)
            {
                if (BattleCharacterManager.ins.mainRole != null)
                {
                    BattleCharacterManager.ins.mainRole.SetPrepareSignActive(false);
                }
                mLeaderFrontSkills.Hide();
            }

            if (BattleModel.ins.mainPetManualOptItem.isDone)
            {
                if (BattleCharacterManager.ins.mainPet != null)
                {
                    BattleCharacterManager.ins.mainPet.SetPrepareSignActive(false);
                }
                mPetFrontSkills.Hide();
            }

            mIsManualOptReseted = false;
        }

        private bool isCanDoManualOperate
        {
            get
            {
                return BattleModel.ins.battleSubType == BattleSubType.MANUAL &&
                    BattleModel.ins.curRoundStatus == BattleRoundStatusType.ROUND_END_FINISH &&
                    BattleModel.ins.curRoundWaitTimeLeft > 0 && mCurOptItem != null &&
                    !mCurOptItem.isDone;
            }
        }

        private bool isCanCheckCharacterTouch
        {
            get
            {
                return isCanDoManualOperate && mCurOptItem.needSelectTarget;
            }
        }

        private void AddNotFadeOutCha(BatCharacter cha)
        {
            mNotFadeOutChas.Add(cha);
            cha.ShowSelectFrame();
        }

        private void ClearNotFadeOutChas()
        {
            int len = mNotFadeOutChas.Count;
            for (int i = 0; i < len; i++)
            {
                mNotFadeOutChas[i].HideSelectFrame();
            }
            mNotFadeOutChas.Clear();
            UI.selectedItemTips.SetActive(false);
        }

        /*
        private void ShowLeaderManualActivedSkill(SkillTemplate skillTpl)
        {
            if (skillTpl != null)
            {
                PathUtil.Ins.SetSkillIcon(UI.leaderActivedSkillBtnIcon, skillTpl.icon + "-1");
            }
        }
        */
        /*
        private void OnLeaderManualActivedSkillBtnIconLoaded(RMetaEvent e)
        {
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                LoadInfo info = (LoadInfo)(e.data);
                string path = info.urlPath;
                Texture t = SourceManager.Ins.GetAsset<Texture>(path);
                if (t != null)
                {
                    UI.leaderActivedSkillBtnIcon.texture = t;
                    UI.leaderActivedSkillBtnIcon.SetNativeSize();
                    UI.leaderActivedSkillBtnIcon.gameObject.SetActive(true);
                }
                else
                {
                    UI.leaderActivedSkillBtnIcon.gameObject.SetActive(false);
                }
            }
            else
            {
                UI.leaderActivedSkillBtnIcon.gameObject.SetActive(false);
            }
        }
        */
        /*
        private void ShowPetManualActivedSkill(SkillTemplate skillTpl)
        {
            if (skillTpl != null)
            {
                PathUtil.Ins.SetSkillIcon(UI.petActivedSkillBtnIcon, skillTpl.icon + "-1");
            }
        }
        */
        /*
        private void OnPetManualActivedSkillBtnIconLoaded(RMetaEvent e)
        {
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                LoadInfo info = (LoadInfo)(e.data);
                string path = info.urlPath;
                Texture t = SourceManager.Ins.GetAsset<Texture>(path);
                if (t != null)
                {
                    UI.petActivedSkillBtnIcon.texture = t;
                    UI.petActivedSkillBtnIcon.SetNativeSize();
                    UI.petActivedSkillBtnIcon.gameObject.SetActive(true);
                }
                else
                {
                    UI.petActivedSkillBtnIcon.gameObject.SetActive(false);
                }
            }
            else
            {
                UI.petActivedSkillBtnIcon.gameObject.SetActive(false);
            }
        }
        */
        private void OnLeaderAutoActionBtnClicked(GameObject btn)
        {
            mSkillListUI.Show(mPetModel.getLeader().PetInfo, PetType.LEADER, true);
            RectTransform rt = UI.manualSkillBtn.gameObject.GetComponent<RectTransform>();
            Vector3 xpos = UI.manualSkillBtn.gameObject.transform.TransformPoint(Vector3.zero);
            xpos = UI.gameObject.transform.InverseTransformPoint(xpos);
            xpos.x -= rt.sizeDelta.x / 1.0f;
            Vector3 ypos = UI.manualBtns.gameObject.transform.TransformPoint(Vector3.zero);
            ypos = UI.gameObject.transform.InverseTransformPoint(ypos);
            ypos.y += mSkillListUI.height;

            mSkillListUI.UI.gameObject.transform.localPosition = new Vector3(xpos.x, -ypos.y - 120, 0);
            //mSkillListUI.UI.gameObject.transform.DOLocalMoveY(Math.Min(ypos.y, 315.0f), 0.1f);
            //mSkillListUI.Show(mPetModel.getLeader().PetInfo, PetType.LEADER, true, -1, Math.Min(ypos.y, 315.0f));
            mSkillListUI.DoMoveY(Math.Min(ypos.y, 315.0f));
            mLastClickedBtn = btn;
        }

        private void OnPetAutoActionBtnClicked(GameObject btn)
        {
            mSkillListUI.Show(mPetModel.getChongWu().PetInfo, PetType.PET, true);
            RectTransform rt = UI.manualSkillBtn.gameObject.GetComponent<RectTransform>();
            Vector3 xpos = UI.manualSkillBtn.gameObject.transform.TransformPoint(Vector3.zero);
            xpos = UI.gameObject.transform.InverseTransformPoint(xpos);
            xpos.x -= rt.sizeDelta.x / 1.0f;
            Vector3 ypos = UI.manualBtns.gameObject.transform.TransformPoint(Vector3.zero);
            ypos = UI.gameObject.transform.InverseTransformPoint(ypos);
            ypos.y += mSkillListUI.height;

            mSkillListUI.UI.gameObject.transform.localPosition = new Vector3(xpos.x, -ypos.y - 120, 0);
            //mSkillListUI.UI.gameObject.transform.DOLocalMoveY(Math.Min(ypos.y, 315.0f), 0.1f);
            //mSkillListUI.Show(mPetModel.getChongWu().PetInfo, PetType.PET, true, -1, Math.Min(ypos.y, 315.0f));
            mSkillListUI.DoMoveY(Math.Min(ypos.y, 315.0f));
            mLastClickedBtn = btn;
        }

        private void OnLeaderAutoSkillSelected(PetSkillInfo skillInfo, SkillTemplate skillTpl, SkillEffectTemplate skillEffectTpl)
        {
            ShowAutoLeaderSkill(skillInfo, skillTpl);
            BattleCGHandler.sendCGBattleUpdateAutoAction((int)PetType.LEADER, skillInfo.skillId);
        }

        private void ShowAutoLeaderSkill(PetSkillInfo skillInfo, SkillTemplate skillTpl)
        {
            UI.autoLeaderAtkBtn.gameObject.SetActive(false);
            UI.autoLeaderDefBtn.gameObject.SetActive(false);
            UI.autoLeaderSkillBtn.gameObject.SetActive(true);
            UI.autoLeaderSkillIcon.gameObject.SetActive(false);
            if (skillTpl != null)
            {
                /*
                string path = PathUtil.Ins.GetUITexturePath(skillTpl.icon, PathUtil.TEXTUER_SKILL);
                SourceLoader.Ins.load(path, OnAutoLeaderSkillBtnIconLoaded);
                */
                PathUtil.Ins.SetSkillIcon(UI.autoLeaderSkillIcon, skillTpl.icon + "-1");
            }

            mSkillListUI.OnActivedAutoSkillConfirmed(PetType.LEADER, skillInfo.skillId);
        }
        /*
        private void OnAutoLeaderSkillBtnIconLoaded(RMetaEvent e)
        {
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                UI.autoLeaderSkillIcon.gameObject.SetActive(true);
                LoadInfo info = (LoadInfo)(e.data);
                string path = info.urlPath;
                Texture t = SourceManager.Ins.GetAsset<Texture>(path);
                if (t != null)
                {
                    UI.autoLeaderSkillIcon.texture = SourceManager.Ins.GetAsset<Texture>(path);
                    UI.autoLeaderSkillIcon.SetNativeSize();
                }
            }
        }
        */
        private void OnLeaderAutoAtkSelected()
        {
            ShowAutoLeaderAtkBtn();
            BattleCGHandler.sendCGBattleUpdateAutoAction((int)PetType.LEADER, BatSkillID.NORMAL_ATTACK);
        }

        private void ShowAutoLeaderAtkBtn()
        {
            UI.autoLeaderAtkBtn.gameObject.SetActive(true);
            UI.autoLeaderDefBtn.gameObject.SetActive(false);
            UI.autoLeaderSkillBtn.gameObject.SetActive(false);
            mSkillListUI.OnActivedAutoSkillConfirmed(PetType.LEADER, BatSkillID.NORMAL_ATTACK);
        }

        private void OnLeaderAutoDefSelected()
        {
            ShowAutoLeaderDefBtn();
            BattleCGHandler.sendCGBattleUpdateAutoAction((int)PetType.LEADER, BatSkillID.DEFENSE);
        }

        private void ShowAutoLeaderDefBtn()
        {
            UI.autoLeaderAtkBtn.gameObject.SetActive(false);
            UI.autoLeaderDefBtn.gameObject.SetActive(true);
            UI.autoLeaderSkillBtn.gameObject.SetActive(false);
            mSkillListUI.OnActivedAutoSkillConfirmed(PetType.LEADER, BatSkillID.DEFENSE);
        }

        private void OnPetAutoSkillSelected(PetSkillInfo skillInfo, SkillTemplate skillTpl, SkillEffectTemplate skillEffectTpl)
        {
            ShowAutoPetSkill(skillInfo, skillTpl);
            BattleCGHandler.sendCGBattleUpdateAutoAction((int)PetType.PET, skillInfo.skillId);
        }

        private void ShowAutoPetSkill(PetSkillInfo skillInfo, SkillTemplate skillTpl)
        {
            UI.autoPetAtkBtn.gameObject.SetActive(false);
            UI.autoPetDefBtn.gameObject.SetActive(false);
            UI.autoPetSkillBtn.gameObject.SetActive(true);
            UI.autoPetSkillIcon.gameObject.SetActive(false);

            if (skillTpl != null)
            {
                /*
                string path = PathUtil.Ins.GetUITexturePath(skillTpl.icon, PathUtil.TEXTUER_SKILL);
                SourceLoader.Ins.load(path, OnAutoPetSkillBtnIconLoaded);
                */
                PathUtil.Ins.SetSkillIcon(UI.autoPetSkillIcon, skillTpl.icon + "-1");
            }

            mSkillListUI.OnActivedAutoSkillConfirmed(PetType.PET, skillInfo.skillId);
        }
        /*
        private void OnAutoPetSkillBtnIconLoaded(RMetaEvent e)
        {
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                UI.autoPetSkillIcon.gameObject.SetActive(true);
                LoadInfo info = (LoadInfo)(e.data);
                string path = info.urlPath;
                Texture t = SourceManager.Ins.GetAsset<Texture>(path);
                if (t != null)
                {
                    UI.autoPetSkillIcon.texture = SourceManager.Ins.GetAsset<Texture>(path);
                    UI.autoPetSkillIcon.SetNativeSize();
                }
            }
        }
        */
        private void OnPetAutoAtkSelected()
        {
            ShowAutoPetAtkBtn();
            BattleCGHandler.sendCGBattleUpdateAutoAction((int)PetType.PET, BatSkillID.NORMAL_ATTACK);
        }

        private void ShowAutoPetAtkBtn()
        {
            UI.autoPetAtkBtn.gameObject.SetActive(true);
            UI.autoPetDefBtn.gameObject.SetActive(false);
            UI.autoPetSkillBtn.gameObject.SetActive(false);
            mSkillListUI.OnActivedAutoSkillConfirmed(PetType.PET, BatSkillID.NORMAL_ATTACK);
        }

        private void OnPetAutoDefSelected()
        {
            ShowAutoPetDefBtn();
            BattleCGHandler.sendCGBattleUpdateAutoAction((int)PetType.PET, BatSkillID.DEFENSE);
        }

        private void OnLeaderFrontSkillSelected(PetSkillInfo skillInfo)
        {
            HideSubPopUps();

            if (skillInfo != null)
            {
                SkillTemplate skillTpl = SkillTemplateDB.Instance.getTemplate(skillInfo.skillId);
                SkillEffectTemplate skillEffectTpl = BattleModel.ins.GetLeaderSkillMainEffectTpl(skillInfo);
                OnManualSkillSelected(skillInfo, skillTpl, skillEffectTpl);
            }
        }

        private void OnPetFrontSkillSelected(PetSkillInfo skillInfo)
        {
            HideSubPopUps();
            
            if (skillInfo != null)
            {
                SkillTemplate skillTpl = SkillTemplateDB.Instance.getTemplate(skillInfo.skillId);
                SkillEffectTemplate skillEffectTpl = BattleModel.ins.GetPetSkillMainEffectTpl(skillInfo);
                OnManualSkillSelected(skillInfo, skillTpl, skillEffectTpl);
            }
        }

        private void ShowAutoPetDefBtn()
        {
            UI.autoPetAtkBtn.gameObject.SetActive(false);
            UI.autoPetDefBtn.gameObject.SetActive(true);
            UI.autoPetSkillBtn.gameObject.SetActive(false);
            mSkillListUI.OnActivedAutoSkillConfirmed(PetType.PET, BatSkillID.DEFENSE);
        }

        private void HideSubPopUps()
        {
            if (mSkillListUI != null)
            {
                mSkillListUI.Hide();
            }

            if (mItemListUI != null)
            {
                mItemListUI.Hide();
            }

            if (mPetListUI != null)
            {
                mPetListUI.Hide(UI.petListUIBehav.closeBtn.gameObject);
            }

            UI.manualBtnsTbg.UnSelectAll();
        }

        public void UpdateJiaSuBtnStatus()
        {
            if (isShown)
            {
                if (Human.Instance.PlayerModel.canBattlePlayFastForward == 1)
                {
                    if (BattleModel.ins.battleType == BattleType.PVE ||
                    BattleModel.ins.battleType == BattleType.TEAM_PVE ||
                    BattleModel.ins.battleType == BattleType.PLAY_BATTLE_REPORT)
                    {
                        if (BattleModel.ins.battleType == BattleType.PLAY_BATTLE_REPORT)
                        {
                            UI.JiaSuBtn.gameObject.SetActive(true);
                            UI.JiaSuBtn.isOn = (Human.Instance.PlayerModel.battlePlaySpeed != BattleDef.PLAY_REPORT_NOR_SPEED);
                            if (UI.JiaSuBtn.isOn)
                            {
                                Time.timeScale = BattleModel.ins.battleSpeedFast;
                            }
                            else
                            {
                                Time.timeScale = BattleDef.PLAY_REPORT_NOR_SPEED;
                            }
                            UI.JiaSuBtnDisabled.SetActive(false);
                            UI.JiaSuBtnDisabledX.SetActive(false);
                            return;
                        }
                        if (BattleModel.ins.curRoundStatus == BattleRoundStatusType.NONE || BattleModel.ins.curRoundStatus == BattleRoundStatusType.ROUND_END_FINISH)
                        {
                            if (BattleModel.ins.battleType == BattleType.TEAM_PVE)
                            {
                                if (TeamModel.ins.GetLeaderUUID() == Human.Instance.Id)
                                {
                                    UI.JiaSuBtn.gameObject.SetActive(true);
                                    UI.JiaSuBtn.isOn = (Human.Instance.PlayerModel.battlePlaySpeed != BattleDef.PLAY_REPORT_NOR_SPEED);
                                }
                                else
                                {
                                    UI.JiaSuBtn.gameObject.SetActive(false);
                                    if (BattleModel.ins.curRoundData != null)
                                    {
                                        if (BattleModel.ins.curRoundData.roundPlaySpeed == BattleDef.PLAY_REPORT_NOR_SPEED)
                                        {
                                            UI.JiaSuBtnDisabled.SetActive(true);
                                            UI.JiaSuBtnDisabledX.SetActive(false);
                                        }
                                        else
                                        {
                                            UI.JiaSuBtnDisabled.SetActive(false);
                                            UI.JiaSuBtnDisabledX.SetActive(true);
                                        }
                                    }
                                    else
                                    {
                                        UI.JiaSuBtnDisabled.SetActive(true);
                                        UI.JiaSuBtnDisabledX.SetActive(false);
                                    }
                                }
                            }
                            else
                            {
                                UI.JiaSuBtn.gameObject.SetActive(true);
                                UI.JiaSuBtn.isOn = (Human.Instance.PlayerModel.battlePlaySpeed != BattleDef.PLAY_REPORT_NOR_SPEED);
                            }
                        }
                        else
                        {
                            UI.JiaSuBtn.gameObject.SetActive(false);
                            if (BattleModel.ins.curRoundData != null)
                            {
                                if (BattleModel.ins.curRoundData.roundPlaySpeed == BattleDef.PLAY_REPORT_NOR_SPEED)
                                {
                                    UI.JiaSuBtnDisabled.SetActive(true);
                                    UI.JiaSuBtnDisabledX.SetActive(false);
                                }
                                else
                                {
                                    UI.JiaSuBtnDisabled.SetActive(false);
                                    UI.JiaSuBtnDisabledX.SetActive(true);
                                }
                            }
                            else
                            {
                                UI.JiaSuBtnDisabled.SetActive(true);
                                UI.JiaSuBtnDisabledX.SetActive(false);
                            }
                        }
                    }
                    else
                    {
                        UI.JiaSuBtn.gameObject.SetActive(false);
                        UI.JiaSuBtnDisabled.SetActive(true);
                        UI.JiaSuBtnDisabledX.SetActive(false);
                    }
                }
                else
                {
                    UI.JiaSuBtn.gameObject.SetActive(false);
                    UI.JiaSuBtnDisabled.SetActive(false);
                    UI.JiaSuBtnDisabledX.SetActive(false);
                }
            }
        }
        
        public override void Destroy()
        {
            if (mSkillListUI != null)
            {
                mSkillListUI.Destroy();
                mSkillListUI = null;
            }
            
            if (mItemListUI != null)
            {
                mItemListUI.Destroy();
                mItemListUI = null;
            }
            
            if (mPetListUI != null)
            {
                mPetListUI.Destroy();
                mPetListUI = null;
            }
            
            base.Destroy();
            UI = null;
            mIns = null;
        }

        //temp
        /*
        private void OnALClicked()
        {
            BattleModel.ins.atkPosesOffset += new Vector3(-0.1f, 0, 0);
            UpdatePos();
        }
        
        private void OnARClicked()
        {
            BattleModel.ins.atkPosesOffset += new Vector3(0.1f, 0, 0);
            UpdatePos();
        }
        
        private void OnATClicked()
        {
            BattleModel.ins.atkPosesOffset += new Vector3(0, 0, 0.1f);
            UpdatePos();
        }
        
        private void OnABClicked()
        {
            BattleModel.ins.atkPosesOffset += new Vector3(0, 0, -0.1f);
            UpdatePos();
        }
        
        private void OnDLClicked()
        {
            BattleModel.ins.defPosesOffset += new Vector3(-0.1f, 0, 0);
            UpdatePos();
        }
        
        private void OnDRClicked()
        {
            BattleModel.ins.defPosesOffset += new Vector3(0.1f, 0, 0);
            UpdatePos();
        }
        
        private void OnDTClicked()
        {
            BattleModel.ins.defPosesOffset += new Vector3(0, 0, 0.1f);
            UpdatePos();
        }
        
        private void OnDBClicked()
        {
            BattleModel.ins.defPosesOffset += new Vector3(0, 0, -0.1f);
            UpdatePos();
        }
        
        private void OnStartBtnClicked()
        {
            UI.tempContainer.SetActive(false);
        }
        
        private void UpdatePos()
        {
            int atkLen = BattleCharacterManager.ins.attackersCount;
            for (int i = 0; i < atkLen; i++)
            {
                BatCharacter atker = BattleCharacterManager.ins.GetAttackerAt(i);
                atker.SetInitPos(BattleDef.ATTACKER_POSES[atker.data.pos - 1] + BattleModel.ins.atkPosesOffset);
            }
            
            int defLen = BattleCharacterManager.ins.defendersCount;
            for (int i = 0; i < defLen; i++)
            {
                BatCharacter defer = BattleCharacterManager.ins.GetDefenderAt(i);
                defer.SetInitPos(BattleDef.DEFENDER_POSES[defer.data.pos - 1] + BattleModel.ins.defPosesOffset);
            }
            
            UI.offsetValue.text = BattleModel.ins.defPosesOffset.ToString("f1") + "  " + BattleModel.ins.atkPosesOffset.ToString("f1");
        }
        */
    }
}