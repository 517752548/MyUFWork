using System;
using System.Collections.Generic;
using app.avatar;
using app.db;
using app.human;
using app.model;
using app.pet;
using app.report;
using app.state;
using DG.Tweening;
using UnityEngine;

namespace app.login
{
    public class CreateRoleView:BaseWnd
    {
        public CreateRoleUI UI;

        private List<Vector3> effectPosList;
        private int currentStep=0;
        private PetTemplate currentPetTpl;
        private List<int> weaponList;
        private List<int> wingList;
        private int startX;
        private int nextJobtype;
        private bool isScrollAvatar = false;

        public CreateRoleView()
        {
            avatarRotatable = true;
            avatarPlayAnim = true;
            useTween = false;
            uiName = "CreateRoleUI";
            isShowBgMask = false;
        }

        public void clickSpaceArea(UnityEngine.GameObject go)
        {
            return;
        }

        public override void initWnd()
        {
            base.initWnd();
            
            //女侠客 30505
            //男侠客 30176
            //女刺客 30019
            //男刺客 30284
            //女术士 30287
            //男术士 30286
            //女修真 30503
            //男修真 30007

            weaponList = new List<int>();
            weaponList.Add(30505);
            weaponList.Add(30176);
            weaponList.Add(30019);
            weaponList.Add(30284);
            weaponList.Add(30287);
            weaponList.Add(30286);
            weaponList.Add(30503);
            weaponList.Add(30007);
            wingList = new List<int>();
            wingList.Add(1001);
            wingList.Add(1002);
            
            effectPosList = new List<Vector3>();
            effectPosList.Add(new Vector3(-111,-38,-100));
            effectPosList.Add(new Vector3(-58,-55,-100));
            effectPosList.Add(new Vector3(-39,-56,-100));
            effectPosList.Add(new Vector3(-131,-36,-100));
            effectPosList.Add(new Vector3(-56,-17,-100));
            effectPosList.Add(new Vector3(-36,19,-100));
            effectPosList.Add(new Vector3(-116,-15,-100));
            effectPosList.Add(new Vector3(-160,-12,-100));

            UI = ui.AddComponent<CreateRoleUI>();
            UI.Init();
            UI.nextBtn.gameObject.SetActive(true);

            UI.yuyinBtn.SetClickCallBack(ClickYuYin);
            UI.nextBtn.SetClickCallBack(ClickNextBtn);
            
            UI.pageturner.PageChangeHandler = changeSelected;
            UI.pageturner.Loop = true;
            UI.pageturner.AutoVisible = false;
            UI.pageturner.MaxValue = Human.Instance.PlayerModel.RoleTemplate.Length;
            UI.pageturner.Value = 0;

            startX = (int)UI.grid.transform.localPosition.x;
            InputManager.Ins.AddListener(InputManager.DOWN_EVENT_TYPE, UI.scrollimage.gameObject, startScroll);
            InputManager.Ins.AddListener(InputManager.UP_EVENT_TYPE, UI.scrollimage.gameObject, scroll);

            for (int i = 0; i < UI.smallList.Count; i++)
            {
                EventTriggerListener.Get(UI.smallList[i].gameObject).onClick = clickNextJob;
            }
        }

        private void clickNextJob(GameObject go)
        {
            int nextIndex = 0;
            switch (nextJobtype)
            {
                case PetJobType.XIAKE:
                    nextIndex = 1;
                    break;
                case PetJobType.CIKE:
                    nextIndex = 3;
                    break;
                case PetJobType.SHUSHI:
                    nextIndex = 5;
                    break;
                case PetJobType.XIUZHEN:
                    nextIndex = 7;
                    break;
                default:
                    nextIndex = 0;
                    break;
            }
            UI.pageturner.Value = nextIndex;
            changeSelectedEffect(nextIndex,true);
        }

        private void startScroll(RMetaEvent e)
        {
            if (avatarBase != null && !avatarBase.IsAvatarRotating())
            {
                isScrollAvatar = true;
            }
            else
            {
                isScrollAvatar = false;
            }
        }

        private void scroll(RMetaEvent e)
        {
            int currentx = (int)UI.grid.transform.localPosition.x;
            if (isScrollAvatar&&Math.Abs(currentx - startX) > 50)
            {
                int endvalue = 0;
                if (currentx - startX < 0)
                {
                    //增加
                    endvalue = (UI.pageturner.Value + 1) % UI.pageturner.MaxValue;
                }
                else
                {
                    //减少
                    if (UI.pageturner.Value == 0)
                    {
                        endvalue = UI.pageturner.MaxValue-1;
                    }
                    else
                    {
                        endvalue = (UI.pageturner.Value - 1) % UI.pageturner.MaxValue;
                    }
                }
                UI.pageturner.Value = endvalue;
                changeSelected(endvalue);
            }
            isScrollAvatar = false;
        }

        public void enterScene(RMetaEvent e = null)
        {
            //hide();
            //Destroy();
        }

        private void ClickYuYin()
        {
            if (currentPetTpl != null)
            {
                AudioManager.Ins.PlayAudio(currentPetTpl.musicIds, AudioEnumType.Role);
            }
        }

        private void ClickBackBtn()
        {
            if (currentStep==1)
            {
                UI.nextBtn.gameObject.SetActive(true);
                currentStep = 0;
            }
        }

        private void ClickNextBtn()
        {
            WndManager.open(GlobalConstDefine.CreateRoleInputWnd_Name, UI.pageturner.Value);
            //if (currentStep == 0)
            //{
            //    WndManager.open(GlobalConstDefine.CreateRoleInputWnd_Name, UI.pageturner.Value);
            //    UI.nextBtn.gameObject.SetActive(false);
            //    currentStep = 1;
            //}
        }

        private Sequence tweener;
        private int nextSmallIndex = 0;

        private void changeSelected(int tab)
        {
            if(tab%2==0){
                 changeSelectedEffect(tab,true);
            }else{
                changeSelectedEffect(tab,false);
            }
            
        }

        private void changeSelectedEffect(int tab,bool jobeffect)
        {
            if (tweener!=null)
            {
                tweener.Kill();
                tweener = null;
                tweenCompleteFunc();
            }
            //int selectIndex = (int)Mathf.Pow(2,UI.pageturner.Value/2);
            UI.xiuzhenBgEffect.SetActive(false);
            UI.xiuzhenBgEffect.SetActive(true);
            if (currentPetTpl!=null)
            {
                AudioManager.Ins.StopAudio(currentPetTpl.musicIds,AudioEnumType.Role);
            }
            
            int selectIndex = tab;
            int pettemplateId = PlayerModel.Ins.RoleTemplate[selectIndex].petTemplateId;
            PetTemplate pt = PetTemplateDB.Instance.getTemplate(pettemplateId);
            currentPetTpl = pt;

            string[] mResPathes = PathUtil.Ins.GetCharacterDisplayModelPath(currentPetTpl.modelId);
            int len = mResPathes.Length;
            List<object[]> kvList = new List<object[]>();
            for (int i = 0; i < len; i++)
            {
                if (!SourceManager.Ins.hasAssetBundle(mResPathes[i]))
                {
                    kvList.Add(new object[] { mResPathes[i], LoadArgs.SLIMABLE, LoadContentType.ABL });
                }
            }
            if (kvList.Count > 0)
            {
                SourceLoader.Ins.loadList(kvList, InitDisplayModel);
            }
            else
            {
                InitDisplayModel();
            }
            if (!jobeffect)
            {
                UI.bigList[0].SetActive(pt.jobId == PetJobType.XIAKE);
                UI.bigList[1].SetActive(pt.jobId == PetJobType.CIKE);
                UI.bigList[2].SetActive(pt.jobId == PetJobType.SHUSHI);
                UI.bigList[3].SetActive(pt.jobId == PetJobType.XIUZHEN);
                int nextjob;
                if (pt.jobId == PetJobType.XIUZHEN)
                {
                    nextjob = PetJobType.XIAKE;
                }
                else
                {
                    nextjob = pt.jobId*2;
                }
                nextJobtype = nextjob;
                UI.smallList[0].SetActive(nextjob == PetJobType.XIAKE);
                UI.smallList[1].SetActive(nextjob == PetJobType.CIKE);
                UI.smallList[2].SetActive(nextjob == PetJobType.SHUSHI);
                UI.smallList[3].SetActive(nextjob == PetJobType.XIUZHEN);

                switch (nextjob)
                {
                    case PetJobType.XIAKE:
                        nextSmallIndex = 0;
                        break;
                    case PetJobType.CIKE:
                        nextSmallIndex = 1;
                        break;
                    case PetJobType.SHUSHI:
                        nextSmallIndex = 2;
                        break;
                    case PetJobType.XIUZHEN:
                        nextSmallIndex = 3;
                        break;
                }
            }
            else
            {
                for (int i=0;i<UI.bigList.Count;i++)
                {
                    UI.bigList[i].SetActive(false);
                }
                int nextjob;
                if (pt.jobId == PetJobType.XIUZHEN)
                {
                    nextjob = PetJobType.XIAKE;
                }
                else
                {
                    nextjob = pt.jobId * 2;
                }
                nextJobtype = nextjob;

                if (nextSmallIndex != 0) UI.smallList[0].SetActive(nextjob == PetJobType.XIAKE);
                if (nextSmallIndex != 1) UI.smallList[1].SetActive(nextjob == PetJobType.CIKE);
                if (nextSmallIndex != 2) UI.smallList[2].SetActive(nextjob == PetJobType.SHUSHI);
                if (nextSmallIndex != 3) UI.smallList[3].SetActive(nextjob == PetJobType.XIUZHEN);

                //上一次的保留，用作移动效果
                UI.smallList[nextSmallIndex].SetActive(true);
                // UI.smallList[nextSmallIndex].transform.localScale = Vector3.one;
                // tweener = TweenUtil.MoveTo(UI.smallList[nextSmallIndex].transform, new Vector3(-118, -55, 0), 2, null, tweenCompleteFunc, null, 0, Ease.OutBack);
                // TweenUtil.MoveScaleTo(UI.smallList[nextSmallIndex].transform,new Vector3(1.2f,1.2f,1),new Vector3(-118,-55,0),2,null,tweenCompleteFunc,null,0,Ease.OutBack);
                 tweener = TweenUtil.MoveScaleTo(UI.smallList[nextSmallIndex].transform, new Vector3(1f,1f,1),new Vector3(-118, -55, 0),1, null, tweenCompleteFunc, null, 0, Ease.OutBack);
                switch (nextjob)
                {
                    case PetJobType.XIAKE:
                        nextSmallIndex = 0;
                        break;
                    case PetJobType.CIKE:
                        nextSmallIndex = 1;
                        break;
                    case PetJobType.SHUSHI:
                        nextSmallIndex = 2;
                        break;
                    case PetJobType.XIUZHEN:
                        nextSmallIndex = 3;
                        break;
                }
            }
            for (int i=0;i<UI.pageturner.MaxValue;i++)
            {
                UI.taiciList[i].gameObject.SetActive(i == UI.pageturner.Value);
            }
            //ClientLog.LogError("UI.pageturner.Value: " + UI.pageturner.Value);
            AudioManager.Ins.PlayAudio(pt.musicIds,AudioEnumType.Role);
            //UI.xiakeEffect.transform.localPosition = effectPosList[tab];
            //UI.cikeEffect.transform.localPosition = effectPosList[tab];
            //UI.shushiEffect.transform.localPosition = effectPosList[tab];
            //UI.xiuzhenEffect.transform.localPosition = effectPosList[tab];

            //SourceLoader.Ins.load(PathUtil.Ins.GetUITexturePath(pt.modelId, PathUtil.TEXTUER_CREATEROLE), loadBodyComplete);
        }

        private void tweenCompleteFunc()
        {
            tweener = null;
            for (int i=0;i<UI.smallList.Count;i++)
            {
                UI.smallList[i].transform.localPosition = new Vector3(0, -55, 0);
                UI.smallList[i].transform.localScale = Vector3.one * 0.8f;
            }

            UI.smallList[0].SetActive(nextJobtype == PetJobType.XIAKE);
            UI.smallList[1].SetActive(nextJobtype == PetJobType.CIKE);
            UI.smallList[2].SetActive(nextJobtype == PetJobType.SHUSHI);
            UI.smallList[3].SetActive(nextJobtype == PetJobType.XIUZHEN);

            int pettemplateId = PlayerModel.Ins.RoleTemplate[UI.pageturner.Value].petTemplateId;
            PetTemplate pt = PetTemplateDB.Instance.getTemplate(pettemplateId);
            UI.bigList[0].SetActive(pt.jobId == PetJobType.XIAKE);
            UI.bigList[1].SetActive(pt.jobId == PetJobType.CIKE);
            UI.bigList[2].SetActive(pt.jobId == PetJobType.SHUSHI);
            UI.bigList[3].SetActive(pt.jobId == PetJobType.XIUZHEN);
        }

        private void InitDisplayModel(RMetaEvent e=null)
        {
            //ClientLog.LogError("InitDisplayModel: " + UI.pageturner.Value);
            EquipItemTemplate eit = EquipItemTemplateDB.Instance.getTemplate(weaponList[UI.pageturner.Value]);
            AddAvatarModelToUI(Vector3.zero, new Vector3(0, 180, 0), Vector3.one,
                currentPetTpl.modelId, UI.modelcontainer,null,false,false);
            avatarBase.ShowWeapon(eit);
            WingTemplate wt = WingTemplateDB.Instance.getTemplate(wingList[UI.pageturner.Value % 2]);
            //if (avatarBase.wing == null || (avatarBase.wing != null && avatarBase.wing.displayModelId != wt.modelId))
            //{
                avatarBase.ShowWing(wt);
            //}
            avatarBase.PlayAnimation(AvatarBase.ANIM_NAME_ATTACK);
            //ClientLog.LogError("InitDisplayModel end :" + UI.pageturner.Value);
        }

        public override void show(RMetaEvent e = null)
        {
            base.show();
            int random = Mathf.FloorToInt(UnityEngine.Random.Range(1, 8));
            UI.pageturner.Value = random;
            changeSelected(random);
            //List<object[]> headList = new List<object[]>();
            //int len = playerModel.RoleTemplate.Length;
            //for (int i=0;i<len;i++)
            //{
            //    int pettemplateId = playerModel.RoleTemplate[i].petTemplateId;
            //    PetTemplate pt = PetTemplateDB.Instance.getTemplate(pettemplateId);
            //    headList.Add(new object[]{PathUtil.Ins.GetUITexturePath(pt.modelId, PathUtil.TEXTUER_YUAN_HEAD), LoadArgs.NONE, LoadContentType.ABL});
            //}
            //SourceLoader.Ins.loadList(headList,loadheadComplete);
            
            DataReport.Instance.Game_SetEventBeforeLogin("c_shown", "view", "create_role");
        }

        public override void hide(RMetaEvent e = null)
        {
            if (UI != null)
            {
                InputManager.Ins.RemoveListener(InputManager.DOWN_EVENT_TYPE, UI.scrollimage.gameObject, startScroll);
                InputManager.Ins.RemoveListener(InputManager.UP_EVENT_TYPE, UI.scrollimage.gameObject, scroll);
            }
            RemoveAvatarModel();
            if (currentPetTpl != null)
            {
                AudioManager.Ins.StopAudio(currentPetTpl.musicIds, AudioEnumType.Role);
            }
            WndManager.Ins.close(GlobalConstDefine.CreateRoleInputWnd_Name);
            //SourceManager.Ins.unignoreDispose(PathUtil.UI_TEXTUER_RELATIVE_DIR + PathUtil.TEXTUER_CREATEROLE);
            //SourceManager.Ins.unignoreDispose(PathUtil.UI_TEXTUER_RELATIVE_DIR + PathUtil.TEXTUER_YUAN_HEAD);
            base.hide(e);
            Destroy();
            StateManager.Ins.ClearMemery();
        }
        
        public override void Destroy()
        {
            base.Destroy();
            UI = null;
        }
    }

}
