using UnityEngine;
using app.net;
using app.pet;
using app.db;
using app.zone;
using app.utils;
using app.human;

namespace app.team
{
    public class TeamInviteListItem
    {
        private TeamInviteListItemUI mUI = null;
        private TeamInvitePlayerInfo mData = null;
        private int mInviteType = 0;
        //private string mHeadPath = null;
        public TeamInviteListItem(TeamInviteListItemUI UI)
        {
            mUI = UI;
            mUI.icon.gameObject.SetActive(false);
            mUI.inviteBtn.SetClickCallBack(OnInviteBtnClicked);
        }

        public void SetData(TeamInvitePlayerInfo data, int inviteType)
        {
            mData = data;
            mInviteType = inviteType;
            mUI.nameTxt.text = data.name;
            mUI.lvTxt.text = "Lv " + data.level;
            mUI.careerTxt.text = PetJobType.GetJobName(data.jobTypeId);
            PetTemplate petTpl = PetTemplateDB.Instance.getTemplate(data.tplId);
            if (petTpl != null)
            {
                PathUtil.Ins.SetHeadIcon(mUI.icon, petTpl.modelId);
                /*
                mHeadPath = PathUtil.Ins.GetUITexturePath(petTpl.modelId, PathUtil.TEXTUER_HEAD);
                SourceLoader.Ins.load(mHeadPath, OnHeadIconLoaded);
                */
            }
        }
        
        public TeamInvitePlayerInfo GetData()
        {
            return mData;
        }
        /*
        private void OnHeadIconLoaded(RMetaEvent e)
        {
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                Texture2D t = SourceManager.Ins.GetAsset<Texture2D>(mHeadPath);
                if (t != null)
                {
                    mUI.icon.gameObject.SetActive(true);
                    mUI.icon.texture = t;
                }
            }
        }
        */

        private void OnInviteBtnClicked()
        {
            if (TeamModel.ins.myTeamMemberList.Length < 5)
            {
                TeamCGHandler.sendCGTeamInvitePlayer(mInviteType, mData.uuid);
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg(StringUtil.Assemble(LangConstant.TEAM_IS_FULL, new string[]{Human.Instance.getName()}));
            }
            
        }

        public void Destroy()
        {
            //SourceManager.Ins.removeReference(mHeadPath);
            GameObject.DestroyImmediate(mUI.gameObject, true);
            mUI = null;
        }
        
        public void SetInvited()
        {
            mUI.inviteBtnLabel.text = "已邀请";
        }
    }
}

