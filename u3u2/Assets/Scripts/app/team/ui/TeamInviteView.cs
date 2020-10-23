using UnityEngine;
using System.Collections.Generic;
using app.net;
using app.human;

namespace app.team
{
    public class TeamInviteView : BaseWnd
    {
        //[Inject(ui = "TeamInviteListUI")]
        //public GameObject ui;

        public TeamInviteListUI UI;

        public List<TeamInviteListItem> mListItems = new List<TeamInviteListItem>();

        public TeamInviteView()
        {
            uiName = "TeamInviteListUI";
            TeamModel.ins.teamInviteView = this;
        }
        /*
        public override void initUILayer(WndType uilayer = WndType.FirstWND)
        {
            base.initUILayer(WndType.SecondWND);
        }
        */
        public override void initWnd()
        {
            base.initWnd();
            UI = ui.AddComponent<TeamInviteListUI>();
            UI.Init();
            UI.closeBtn.SetClickCallBack(ClickClose);
        }

        public override void show(RMetaEvent e)
        {
            base.show(e);
            ShowInviteList(TeamModel.ins.teamInviteListType, TeamModel.ins.teamInviteList);
        }

        /// <summary>
        /// Shows the invite list.
        /// </summary>
        /// <param name="inviteType">1、好友，2、帮派。</param>
        /// <param name="data">Data.</param>
        public void ShowInviteList(int inviteType, TeamInvitePlayerInfo[] data)
        {
            if (inviteType == 1)
            {
                UI.title.text = LangConstant.SELECT_FRIEND;
            }
            else if (inviteType == 2)
            {
                UI.title.text = LangConstant.SELECT_BANGPAI_MEMBER;
            }
            else
            {
                UI.title.text = "inviteType:" + inviteType;
            }

            int len = mListItems.Count;
            for (int i = 0; i < len; i++)
            {
                mListItems[i].Destroy();
            }

            mListItems.Clear();

            len = data.Length;
            for (int i = 0; i < len; i++)
            {
                if (data[i].uuid != Human.Instance.Id)
                {
                    TeamInviteListItemUI itemUI = GameObject.Instantiate(UI.invitelistItem);
                    itemUI.gameObject.transform.SetParent(UI.invitelistItem.gameObject.transform.parent);
                    itemUI.gameObject.transform.localScale = UI.invitelistItem.gameObject.transform.localScale;
                    itemUI.gameObject.SetActive(true);
                    TeamInviteListItem item = new TeamInviteListItem(itemUI);
                    item.SetData(data[i], inviteType);
                    mListItems.Add(item);
                }
            }
        }

        public void SetInviteItemToInvited(long playerUUID)
        {
            int len = mListItems.Count;
            for (int i = 0; i < len; i++)
            {
                if (mListItems[i].GetData().uuid == playerUUID)
                {
                    mListItems[i].SetInvited();
                    break;
                }
            }
        }

        private void ClickClose()
        {
            hide();
        }
        
        public override void Destroy()
        {
            int len = mListItems.Count;
            for (int i = 0; i < len; i++)
            {
                mListItems[i].Destroy();
            }

            mListItems.Clear();
            TeamModel.ins.teamInviteView = null;
            base.Destroy();
            UI = null;
        }
    }
}

