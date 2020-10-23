using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using app.db;
using app.pet;
using app.human;
using app.utils;
using app.net;
using app.tips;
using minijson;
using app.confirm;

namespace app.partnerformation
{
    public class PartnerInfoView : BaseWnd
    {
        //[Inject(ui = "PartnerInfoUI")]
        //public GameObject ui;

        public PartnerInfoUI UI;
        
        private PetTemplate mPetTpl = null;

        private List<PetSkillItem> mSkillItems = new List<PetSkillItem>();

        private bool mIsInfoReceived = false;
        private bool mIsModelLoaded = false;
        
        /*
        public override void initUILayer(WndType uilayer = WndType.FirstWND)
        {
            base.initUILayer(WndType.SecondWND);
        }
        */
        
        public PartnerInfoView()
        {
            uiName = "PartnerInfoUI";
        }
        public override void initWnd()
        {
            base.initWnd();
            UI = ui.AddComponent<PartnerInfoUI>();
            UI.Init();
            UI.closeBtn.SetClickCallBack(Close);
            UI.prevBtn.SetClickCallBack(OnPrevBtnClicked);
            UI.nextBtn.SetClickCallBack(OnNextBtnClicked);
            UI.unlockBtn.SetClickCallBack(OnUnlockBtnClicked);
            UI.onBtn.SetClickCallBack(OnOnBtnClicked);
            UI.offBtn.SetClickCallBack(OnOffBtnClicked);
        }

        public override void show(RMetaEvent e)
        {
            base.show(e);
            UpdateView();
        }

        public void UpdateView()
        {
            mIsInfoReceived = false;
            mIsModelLoaded = true;
            PetTemplate tpl = PetTemplateDB.Instance.getTemplate(PartnerFormationModel.ins.curShowingPartnerTplId);
            if (tpl == null)
            {
                UI.partnerName.text = "";
                UI.partnerCareer.text = "";
                UI.partnerLevel.text = "";
                UI.partnerTips.text = "";
                UI.qixue.text = "0";
                UI.sudu.text = "0";
                UI.wugong.text = "0";
                UI.fagong.text = "0";
                UI.wufang.text = "0";
                UI.fafang.text = "0";
                UI.partnerTips.text = "";
                UI.unlockBtn.gameObject.SetActive(false);
                UI.onBtn.gameObject.SetActive(false);
                UI.offBtn.gameObject.SetActive(false);
                RemoveAvatarModel();
                mIsInfoReceived = true;
            }
            else
            {
                PartnerListItemUIScript item = PartnerFormationModel.ins.partnerUIScript.GetPartnerListItemUIScript(tpl.Id);
                UI.partnerLevel.text = "Lv " + Human.Instance.getLevel();

                UI.unlockBtn.gameObject.SetActive(item.leftTime == 0);
                UI.onBtn.gameObject.SetActive(item.leftTime != 0 && !item.isOnFight);
                UI.offBtn.gameObject.SetActive(item.leftTime != 0 && item.isOnFight);

                if (mPetTpl == null || mPetTpl.modelId != tpl.modelId)
                {
                    LoadPartnerModel(tpl);
                }

                if (mPetTpl == null || mPetTpl.Id != tpl.Id)
                {
                    UI.partnerName.text = tpl.name;
                    UI.partnerCareer.text = PetJobType.GetJobName(tpl.jobId);
                    UI.partnerLevel.text = "Lv " + Human.Instance.getLevel();
                    UI.partnerTips.text = "";
                    UI.qixue.text = "";
                    UI.sudu.text = "";
                    UI.wugong.text = "";
                    UI.fagong.text = "";
                    UI.wufang.text = "";
                    UI.fafang.text = "";
                    PetCGHandler.sendCGPetFriendInfo(tpl.Id);
                }
                else
                {
                    mIsInfoReceived = true;
                }
            }

            mPetTpl = tpl;
        }

        public void OnPetFriendInfoReceived(GCPetFriendInfo info)
        {
            UI.qixue.text = "";
            UI.sudu.text = "";
            UI.wugong.text = "";
            UI.fagong.text = "";
            UI.wufang.text = "";
            UI.fafang.text = "";
            UI.partnerTips.text = "";
            
            if (info.getTplId() == mPetTpl.Id)
            {
                UI.qixue.text = "0";
                List<object> props = (List<object>)Json.Deserialize(info.getProps());
                int len = props.Count;
                for (int i = 0; i < len; i++)
                {
                    int k = int.Parse(((IDictionary)props[i])["k"].ToString());
                    int v = int.Parse(((IDictionary)props[i])["b"].ToString());
                    if (k == PetBProperty.HP)
                    {
                        UI.qixue.text = v.ToString();
                    }
                    else if (k == PetBProperty.SPEED)
                    {
                        UI.sudu.text = v.ToString();
                    }
                    else if (k == PetBProperty.PHYSICAL_ATTACK)
                    {
                        UI.wugong.text = v.ToString();
                    }
                    else if (k == PetBProperty.PHYSICAL_ARMOR)
                    {
                        UI.wufang.text = v.ToString();
                    }
                    else if (k == PetBProperty.MAGIC_ATTACK)
                    {
                        UI.fagong.text = v.ToString();
                    }
                    else if (k == PetBProperty.MAGIC_ARMOR)
                    {
                        UI.fafang.text = v.ToString();
                    }
                }

                CreateSkillItems(info.getSkillList());
                mIsInfoReceived = true;
            }
        }

        private void LoadPartnerModel(PetTemplate modelId)
        {
            mIsInfoReceived = true;
            AddRoleModelToUI(Vector3.zero, Vector3.one, modelId, UI.partnerModelContainer);
        }

        private void CreateSkillItems(PetSkillInfo[] skillInfos)
        {
            int len = skillInfos.Length;
            for (int i = 0; i < len; i++)
			{
                if(i == mSkillItems.Count)
                {
                    CommonItemUI skillItemUI = GameObject.Instantiate(UI.skillItem);
                    skillItemUI.gameObject.transform.SetParent(UI.skillItem.gameObject.transform.parent);
                    skillItemUI.gameObject.transform.localScale = UI.skillItem.gameObject.transform.localScale;
                    skillItemUI.gameObject.SetActive(true);
                    PetSkillItem skillItem = new PetSkillItem(skillItemUI, OnSkillItemClicked);
                    skillItem.UI.Name.gameObject.SetActive(false);
                    mSkillItems.Add(skillItem);
                }
                if (PropertyUtil.IsLegalID(skillInfos[i].skillId))
                {
                    mSkillItems[i].SetData(skillInfos[i]);
                }
			}
            for (int i = len; i < mSkillItems.Count; i++)
            {
                mSkillItems[i].UI.gameObject.SetActive(false);  
            }
        }

        private void OnSkillItemClicked(object obj)
        {
            if (obj is PetSkillInfo)
            {
                PetSkillInfo skillInfo = obj as PetSkillInfo;
                SkillTips.ins.ShowTips(skillInfo);
            }else if (obj is PetTemplate)
            {
                SkillTemplate skilltpl = obj as SkillTemplate;
                SkillTips.ins.ShowTips(skilltpl);
            }
        }

        
        
        private void DestroySkillItems()
        {
            int len = mSkillItems.Count;
            for (int i = 0; i < len; i++)
            {
                GameObject.DestroyImmediate(mSkillItems[i].UI.gameObject, true);
                mSkillItems[i].UI = null;
            }
            mSkillItems.Clear();
        }
        

        private void Close()
        {
            hide(null);
        }

        private void OnPrevBtnClicked()
        {
            if (mIsInfoReceived && mIsModelLoaded)
            {
                int idx = PartnerFormationModel.ins.partnerUIScript.GetPartnerItemIndex(mPetTpl.Id);
                if (idx == -1)
                {
                    idx = 0;
                }
                else if (idx == 0)
                {
                    idx = PartnerFormationModel.ins.partnerUIScript.allPartnersList.Count - 1;
                }
                else
                {
                    idx = idx - 1;
                }

                PartnerFormationModel.ins.curShowingPartnerTplId = PartnerFormationModel.ins.partnerUIScript.allPartnersList[idx].GetData().Id;
                UpdateView();
            }
        }

        private void OnNextBtnClicked()
        {
            if (mIsInfoReceived && mIsModelLoaded)
            {
                int idx = PartnerFormationModel.ins.partnerUIScript.GetPartnerItemIndex(mPetTpl.Id);
                if (idx == -1)
                {
                    idx = 0;
                }
                else if (idx == PartnerFormationModel.ins.partnerUIScript.allPartnersList.Count - 1)
                {
                    idx = 0;
                }
                else
                {
                    idx = idx + 1;
                }

                PartnerFormationModel.ins.curShowingPartnerTplId = PartnerFormationModel.ins.partnerUIScript.allPartnersList[idx].GetData().Id;
                UpdateView();
            }
        }

        private void OnUnlockBtnClicked()
        {
            PetFriendTemplate tpl = PetFriendTemplateDB.Instance.getTemplate(mPetTpl.Id);
            ConfirmWnd.Ins.ShowConfirm("解锁伙伴", "永久解锁" + mPetTpl.name + "需要支付" + tpl.unlockCostList[2] + "银票。", Unlock);
        }

        private void Unlock(RMetaEvent e)
        {
            PetCGHandler.sendCGPetFriendUnlock(mPetTpl.Id, 3);
        }

        private void OnOnBtnClicked()
        {
            int arrayIndex = Human.Instance.PetModel.curPetFriendArrayIdx;
            PetFriendArrayInfo arrayInfo = Human.Instance.PetModel.petFriendArrayInfoList[arrayIndex];
            int targetPosIndex = -1;
            int len = arrayInfo.tplIdList.Length;
            for (int i = 0; i < len; i++)
            {
                if (!PropertyUtil.IsLegalID(arrayInfo.tplIdList[i]))
                {
                    targetPosIndex = i;
                    break;
                }
            }
            PetCGHandler.sendCGPetFriendPutonArray(arrayIndex, mPetTpl.Id, targetPosIndex);
        }

        private void OnOffBtnClicked()
        {
            int arrayIdx = Human.Instance.PetModel.curPetFriendArrayIdx;
            PetFriendArrayInfo arrayInfo = Human.Instance.PetModel.petFriendArrayInfoList[arrayIdx];
            int idx = -1;
            int len = arrayInfo.tplIdList.Length;
            for (int i = 0; i < len; i++)
            {
                if (arrayInfo.tplIdList[i] == mPetTpl.Id)
                {
                    idx = i;
                    break;
                }
            }

            PetCGHandler.sendCGPetFriendOffArray(Human.Instance.PetModel.curPetFriendArrayIdx, idx);
        }

        public override void Destroy()
        {
            mPetTpl = null;
            for (int i = 0; i < mSkillItems.Count; i++)
            {
                mSkillItems[i].Destroy();
            }
            mSkillItems.Clear();
            mSkillItems = null;
            base.Destroy();
            UI = null;
        }
    }
}