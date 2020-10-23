using UnityEngine;
using app.db;
using app.utils;
using app.net;
using app.human;

namespace app.partnerformation
{
    public class FormationPartnerItemUIScript
    {
        public FormationPartnerItemUI ui { get; private set; }

        public PetTemplate tpl { get; private set; }
        
        public int formationIndex { get; private set; }
        public int partnerPosIndex { get; private set; }
		
		private string mHeadIconPath = null;

        public FormationPartnerItemUIScript(FormationPartnerItemUI ui)
        {
            this.ui = ui;
            ui.jiaBtn.gameObject.SetActive(false);
            ui.headIcon.gameObject.SetActive(false);
            ui.jianBtn.gameObject.SetActive(false);
            ui.zhuanBtn.gameObject.SetActive(false);
            
            ui.jiaBtn.SetClickCallBack(OnJiaBtnClicked);
            ui.headIconBtn.SetClickCallBack(OnHeadIconClicked);
            ui.jianBtn.SetClickCallBack(OnJianBtnClicked);
            ui.zhuanBtn.SetClickCallBack(OnZhuanBtnClicked);
        }

        public void SetData(int formationIndex, int partnerIndex, int tplId)
        {
            this.formationIndex = formationIndex;
            this.partnerPosIndex = partnerIndex;
            if (PropertyUtil.IsLegalID(tplId))
            {
				if (tpl == null || tplId != tpl.Id)
				{
					tpl = PetTemplateDB.Instance.getTemplate(tplId);
                    //LoadHeadIcon();
                    PathUtil.Ins.SetHeadIcon(ui.headIcon, tpl.modelId);
				}
            }
            else
            {
                tpl = null;
            }
			
			ResetStatus();
        }
		/*
		private void LoadHeadIcon()
		{
            ui.headIcon.texture = null;
			mHeadIconPath = PathUtil.Ins.GetUITexturePath(tpl.modelId, PathUtil.TEXTUER_HEAD);
			SourceLoader.Ins.load(mHeadIconPath, OnHeadIconLoaded);
		}
		
		private void OnHeadIconLoaded(RMetaEvent e)
		{
			Texture2D t = null;
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                t = SourceManager.Ins.GetAsset<Texture2D>(mHeadIconPath);
                if (t != null)
                {
                    ui.headIcon.texture = t;
                    ui.headIcon.gameObject.SetActive(true);
                }
            }

            if (t == null)
            {
                string defaultHeadIconPath = PathUtil.Ins.GetUITexturePath("", PathUtil.TEXTUER_HEAD);
                if (mHeadIconPath != defaultHeadIconPath)
                {
                    mHeadIconPath = defaultHeadIconPath;
                    SourceLoader.Ins.load(mHeadIconPath, OnHeadIconLoaded);
                }
            }
		}
        */
        public void ResetStatus()
        {
            ui.jianBtn.gameObject.SetActive(false);
            ui.zhuanBtn.gameObject.SetActive(false);
            ui.selected.SetActive(false);
			
			if (tpl == null)
			{
                if (this.partnerPosIndex == 0)
                {
                    ui.jiaBtn.gameObject.SetActive(true);
                }
                else
                {
                    PetFriendArrayInfo arrayInfo = Human.Instance.PetModel.petFriendArrayInfoList[this.formationIndex];
                    ui.jiaBtn.gameObject.SetActive(PropertyUtil.IsLegalID(arrayInfo.tplIdList[this.partnerPosIndex - 1]));
                }
                
				ui.headIcon.sprite = null;
                ui.headIcon.gameObject.SetActive(false);
			}
			else
			{
				ui.jiaBtn.gameObject.SetActive(false);
				ui.headIcon.gameObject.SetActive(ui.headIcon.sprite != null);
			}
        }

        
        private void OnJiaBtnClicked()
        {
            PartnerFormationManager.ins.OnFormationPartnerItemUIJiaBtnClicked(this);
        }
        
        private void OnHeadIconClicked()
        {
            PartnerFormationManager.ins.OnFormationPartnerItemUIHeadBtnClicked(this);
        }

        private void OnJianBtnClicked()
        {
            PartnerFormationManager.ins.OnFormationPartnerItemUIJianBtnClicked(this);
        }

        private void OnZhuanBtnClicked()
        {
            PartnerFormationManager.ins.OnFormationPartnerItemUIZhuanBtnClicked(this);
        }
        
        public void Destroy()
        {
            GameObject.DestroyImmediate(ui.gameObject, true);
            ui = null;
        }
    }
}