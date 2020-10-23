using System;
using UnityEngine;
using app.pet;
using app.db;
using app.human;

namespace app.partnerformation
{
    public class PartnerListItemUIScript : IComparable<PartnerListItemUIScript>
    {
        public PartnerListItemUI ui { get; private set; }
        public PetTemplate tpl { get; private set; }
        private PetFriendTemplate mData = null;
        private long mLeftTime = 0;
        private bool mIsOnFight = false;
        public PartnerListItemUIScript(PartnerListItemUI ui)
        {
            this.ui = ui;
            ui.shangBtn.gameObject.SetActive(false);
            ui.shangBtn.SetClickCallBack(OnShangBtnClicked);
            ui.headIconBtn.SetClickCallBack(OnHeadIconBtnClicked);
        }

        public PetFriendTemplate GetData()
        {
            return mData;
        }

        public void SetData(PetFriendTemplate data)
        {
            if (data != null)
            {
                tpl = PetTemplateDB.Instance.getTemplate(data.Id);
                ui.zhan.SetActive(false);
                ui.suo.SetActive(data.needUnlock == 1);
                ui.partnerName.text = tpl.name;
                ui.partnerCareer.text = PetJobType.GetJobName(tpl.jobId);
                ui.partnerTips.text = "";
                ui.tplId = data.Id;

                if (mData == null || mData.Id != data.Id)
                {
                    /*
                    ui.partnerHeadIcon.gameObject.SetActive(false);
                    SourceLoader.Ins.load(PathUtil.Ins.GetUITexturePath(tpl.modelId, PathUtil.TEXTUER_HEAD), OnHeadIconLoaded);
                    */
                    PathUtil.Ins.SetHeadIcon(ui.partnerHeadIcon, tpl.modelId);
                }
            }
            else
            {
                tpl = null;
                ui.zhan.SetActive(false);
                ui.suo.SetActive(false);
                ui.partnerName.text = "";
                ui.partnerCareer.text = "";
                ui.partnerTips.text = "";
                ui.partnerHeadIcon.sprite = null;
                ui.partnerHeadIcon.gameObject.SetActive(false);
                ui.tplId = 0;
            }

            ui.partnerLevel.text = "Lv " + Human.Instance.getLevel();

            mData = data;
        }
        /*
        private void OnHeadIconLoaded(RMetaEvent e)
        {
            Texture2D t = null;
            LoadInfo loadInfo = (LoadInfo)e.data;
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                t = SourceManager.Ins.GetAsset<Texture2D>(loadInfo.urlPath);
                if (t != null)
                {
                    ui.partnerHeadIcon.texture = t;
                    ui.partnerHeadIcon.gameObject.SetActive(true);
                }
            }

            if (t == null)
            {
                string defaultHeadIconPath = PathUtil.Ins.GetUITexturePath("", PathUtil.TEXTUER_HEAD);
                if (loadInfo.urlPath != defaultHeadIconPath)
                {
                    SourceLoader.Ins.load(defaultHeadIconPath, OnHeadIconLoaded);
                }
            }
        }
        */
        public long leftTime
        {
            get
            {
                return mLeftTime;
            }
            set
            {
                mLeftTime = value;
                ui.suo.SetActive(value == 0);
            }
        }

        public bool isOnFight
        {
            get
            {
                return mIsOnFight;
            }
            set
            {
                mIsOnFight = value;
                ui.zhan.SetActive(value);
            }
        }

        public void SetActive(bool value)
        {
            ui.gameObject.SetActive(value);
        }

        public void Destroy()
        {
            if (ui != null)
            {
                GameObject.DestroyImmediate(ui.gameObject, true);
                ui = null;
                mData = null;
            }
        }

        public int CompareTo(PartnerListItemUIScript item)
        {
            if (item == this)
            {
                return 0;
            }
            
            if (this.isOnFight != item.isOnFight)
            {
                if (this.isOnFight && !item.isOnFight)
                {
                    return -1;
                }
                else if (!this.isOnFight && item.isOnFight)
                {
                    return 1;
                }
            }
            
            if (this.leftTime != 0 && item.leftTime == 0)
            {
                return -1;
            }
            
            if (this.leftTime == 0 && item.leftTime != 0)
            {
                return 1;
            }

            if (this.leftTime == -1 && item.leftTime != -1)
            {
                return -1;
            }

            if (item.leftTime == -1 && this.leftTime != -1)
            {
                return 1;
            }

            if (this.leftTime > item.leftTime)
            {
                return -1;
            }
            else if (this.leftTime < item.leftTime)
            {
                return 1;
            }

            if (this.mData.Id < item.GetData().Id)
            {
                return -1;
            }
            else if (this.mData.Id > item.GetData().Id)
            {
                return 1;
            }

            return 0;
        }
        
        private void OnShangBtnClicked()
        {
            PartnerFormationManager.ins.OnPartnerListItemShangBtnClicked(tpl.Id);
        }
        
        private void OnHeadIconBtnClicked()
        {
            if (ui.shangBtn.gameObject.activeSelf)
            {
                OnShangBtnClicked();
            }
            else
            {
                PartnerFormationModel.ins.curShowingPartnerTplId = (tpl == null ? 0 : tpl.Id);
                PartnerFormationModel.ins.partnerInfoView = (PartnerInfoView)WndManager.open(GlobalConstDefine.PartnerInfoView_Name);
            }
        }
    }
}