using UnityEngine;
using app.db;
using app.net;
using app.pet;

namespace app.zone
{
    public class MainUITeamMemberItem
    {
        private MainUITeamMemberItemUI mUI = null;
        private TeamMemberInfo mData = null;
        private string mHeadIconPath = null;

        public MainUITeamMemberItem(MainUITeamMemberItemUI ui)
        {
            mUI = ui;
        }

        public MainUITeamMemberItemUI UI
        {
            get
            {
                return mUI;
            }
        }

        public void SetData(TeamMemberInfo data)
        {
            if (data == null && mUI!=null)
            {
                //mUI.headIcon.texture = null;
                mUI.headIcon.sprite = null;
                mUI.hp.Percent = 0;
                mUI.lvTxt.text = "";
                mUI.mp.Percent = 0;
                mUI.nameTxt.text = "";
                mUI.zan.SetActive(false);
                mUI.gameObject.SetActive(false);
            }
            else
            {
                if (mUI != null)
                {
                    mUI.gameObject.SetActive(true);

                    if ((mData == null || mData.tplId != data.tplId) && data.tplId!=0)
                    {
                        PetTemplate tpl = PetTemplateDB.Instance.getTemplate(data.tplId);
                        /*
                        mUI.headIcon.gameObject.SetActive(false);
                        mHeadIconPath = PathUtil.Ins.GetUITexturePath(tpl.modelId, PathUtil.TEXTUER_HEAD);
                        SourceLoader.Ins.load(mHeadIconPath, OnHeadIconLoaded);
                        */
                        PathUtil.Ins.SetHeadIcon(mUI.headIcon, tpl.modelId);
                    }
                    mUI.hp.Percent = 1;
                    mUI.lvTxt.text = "Lv " + data.level;
                    mUI.mp.Percent = 1;
                    mUI.nameTxt.text = data.name;
                    mUI.zan.SetActive(data.status == 2);

                    string jobImgName = PetJobType.GetJobIconName(data.jobTypeId);
                    mUI.job.sprite = SourceManager.Ins.GetAsset<Sprite>(PathUtil.Ins.uiDependenciesPath, jobImgName);
                }
            }

            mData = data;
        }

        public TeamMemberInfo GetData()
        {
            return mData;
        }
        /*
        private void OnHeadIconLoaded(RMetaEvent e)
        {
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                Texture2D t = SourceManager.Ins.GetAsset<Texture2D>(mHeadIconPath);
                if (t != null)
                {
                    mUI.headIcon.texture = t;
                    mUI.headIcon.gameObject.SetActive(true);
                }
            }
        }
        */
    }
}

