using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using app.pet;
using app.net;
using app.human;
using app.db;
using app.utils;

namespace app.team
{
    public class TeamApplyView : BaseWnd
    {
        //[Inject(ui = "TeamApplyUI")]
        //public GameObject ui;
        private const int FENGYAO_XIAOYAO_ID = 6;
        private const int FENGYAO_MOWANG_ID = 7;
        private const int HUNSHIMOWANG_ID = 8;

        public TeamApplyUI UI;

        private int mLastOpenedLv = 0;

        private List<TeamApplyListItemUI> mTeamItems = new List<TeamApplyListItemUI>();

        private List<GameObject> mPurposeListRootItems = new List<GameObject>();
        private Dictionary<int, TeamPurposeButtonUI> mPurposeListSingleBtns = new Dictionary<int, TeamPurposeButtonUI>();
        private Dictionary<int, TeamPurposeButtonUI> mPurposeListDropDownBtns = new Dictionary<int, TeamPurposeButtonUI>();

        private List<TeamPurposeButtonUI> mToggleGroupItems = new List<TeamPurposeButtonUI>();

        private int mOpenedTypeId = 0;
        private TeamPurposeButtonUI mSelectedBtn = null;
        private Coroutine mCreateTeamListCorotine = null;

        public TeamApplyView()
        {
            uiName = "TeamApplyUI";
            TeamModel.ins.teamApplyView = this;
        }

        public override void initWnd()
        {
            base.initWnd();
            UI = ui.AddComponent<TeamApplyUI>();
            UI.Init();
            UI.createTeamBtn.SetClickCallBack(OnCreateTeamBtnClicked);
            UI.autoMatchBtn.SetClickCallBack(OnApplyAutoBtnClicked);
            UI.cancelAutoMatchBtn.SetClickCallBack(OnCancelApplyAutoBtnClicked);
            UI.refreshBtn.SetClickCallBack(OnRefreshBtnClicked);
            UI.closeBtn.SetClickCallBack(ClickClose);
            UI.purposeListTabButtonGroup.TabChangeHandler = OnPurposeListTabChanged;
        }

        public override void show(RMetaEvent e)
        {
            base.show(e);
            UI.Show();
            if (Human.Instance.getLevel() != mLastOpenedLv)
            {
                mLastOpenedLv = Human.Instance.getLevel();
                UpdatePurposeList();
            }

            int len = mToggleGroupItems.Count;
            for (int i = 0; i < len; i++)
            {
                mToggleGroupItems[i].deng.SetActive(false);
            }
            SelectTarget(e);

            if (mPurposeListRootItems.Count > 0)
            {
                if (mSelectedBtn == null)
                {
                    GameObject btn = mPurposeListRootItems[0];
                    TeamPurposeButtonUI btnUI = btn.GetComponent<TeamPurposeButtonUI>();
                    if (PropertyUtil.IsLegalID(btnUI.typeId))
                    {
                        OnDropDownBtnClicked(btn);
                        btnUI.childList.buttons[0].gameObject.GetComponent<GameUUToggle>().isOn = true;
                    }
                    else
                    {
                        btn.GetComponent<GameUUToggle>().isOn = true;
                    }
                }
                else
                {
                    if (PropertyUtil.IsLegalID(mSelectedBtn.typeId))
                    {
                        OnDropDownBtnClicked(mSelectedBtn.gameObject);
                        mSelectedBtn.childList.buttons[0].gameObject.GetComponent<GameUUToggle>().isOn = true;
                    }
                    else
                    {
                        mSelectedBtn.GetComponent<GameUUToggle>().isOn = true;
                    }
                    OnTeamPurposeIdSelected(mSelectedBtn.teamPurposeId);
                }
            }
            app.main.GameClient.ins.OnBigWndShown();
            OnReceivedTeamApplyAuto();
            if (TeamModel.ins.teamApplyAuto != null)
            {
                UI.purposeListTabButtonGroup.SetIndexWithCallBack(GetIndexByType(TeamModel.ins.teamApplyAuto.getTargetId()));
            }
        }

        private int GetIndexByType(int targetId)
        {
            for (int i = 0; i < mToggleGroupItems.Count; i++)
            {
                if (mToggleGroupItems[i].teamPurposeId == targetId)
                {
                    return i;
                }
            }
            return 0;
        }

        private void SelectTarget(RMetaEvent e)
        {
            if (e == null)
            {
                return;
            }

            object obj = WndParam.GetWndParam(e, WndParam.LINK_TO_FUNC);
            int selectTab = 0;
            int teamTargetId = 0;
            if (obj == null)
            {
                return;
            }
            if (int.TryParse(obj.ToString(), out selectTab))
            {
                switch (selectTab)
                {
                    case FunctionIdDef.FENGYAO_XIAOYAO:
                        teamTargetId = FENGYAO_XIAOYAO_ID;
                        break;
                    case FunctionIdDef.FENGYAO_MOWANG:
                        teamTargetId = FENGYAO_MOWANG_ID;
                        break;
                    case FunctionIdDef.HUNSHIMOWANG:
                        teamTargetId = HUNSHIMOWANG_ID;
                        break;
                }
            }
            else
            {
                return;
            }

            for (int i = 0; i < mToggleGroupItems.Count; i++)
            {
                if (mToggleGroupItems[i].teamPurposeId == teamTargetId)
                {
                    mSelectedBtn = mToggleGroupItems[i];
                    return;
                }
            }

        }

        private void UpdatePurposeList()
        {
            int len = mPurposeListRootItems.Count;
            for (int i = 0; i < len; i++)
            {
                GameObject.DestroyImmediate(mPurposeListRootItems[i], true);
                mPurposeListRootItems[i] = null;
            }
            mPurposeListRootItems.Clear();
            mPurposeListSingleBtns.Clear();
            mPurposeListDropDownBtns.Clear();
            mToggleGroupItems.Clear();
            mSelectedBtn = null;
            mOpenedTypeId = 0;

            UI.purposeListTabButtonGroup.ClearToggleList();

            TeamTargetTemplate tplAll = new TeamTargetTemplate();
            tplAll.typeId = 0;
            tplAll.typeName = "";
            tplAll.Id = 0;
            tplAll.name = LangConstant.ALL;
            CreateListSingleButton(tplAll);

            List<KeyValuePair<int, TeamTargetTemplate>> sortedIdKeyList = TeamTargetTemplateDB.Instance.GetSortedIdKeyList();
            len = sortedIdKeyList.Count;
            for (int i = 0; i < len; i++)
            {
                KeyValuePair<int, TeamTargetTemplate> kv = sortedIdKeyList[i];

                if (kv.Value.levelLimit <= mLastOpenedLv)
                {
                    if (kv.Value.typeId == 0)
                    {
                        CreateListSingleButton(kv.Value);
                    }
                    else
                    {
                        TeamPurposeButtonDropDownListUI dropDownListUIScript = null;
                        if (mPurposeListDropDownBtns.ContainsKey(kv.Value.typeId))
                        {
                            //已有此大类。
                            dropDownListUIScript = mPurposeListDropDownBtns[kv.Value.typeId].childList;
                        }
                        else
                        {
                            TeamPurposeButtonUI btnUI = GameObject.Instantiate(UI.dropDownButton);
                            btnUI.teamPurposeId = 0;
                            btnUI.typeId = kv.Value.typeId;
                            btnUI.typeName = kv.Value.typeName;
                            btnUI.mainLabel.text = kv.Value.typeName;
                            btnUI.mainLabel.gameObject.SetActive(true);
                            //btnUI.multLabelMain.text = kv.Value.typeName;
                            //btnUI.multLabelMain.gameObject.SetActive(false);
                            //btnUI.multLabelSub.gameObject.SetActive(false);
                            //btnUI.checkMark.SetActive(false);
                            btnUI.gameObject.SetActive(true);
                            btnUI.transform.SetParent(UI.dropDownButton.transform.parent);
                            btnUI.transform.localScale = UI.dropDownButton.transform.localScale;
                            btnUI.GetComponent<GameUUToggle>().isOn = false;
                            mPurposeListDropDownBtns.Add(kv.Value.typeId, btnUI);
                            mPurposeListRootItems.Add(btnUI.gameObject);
                            EventTriggerListener.Get(btnUI.gameObject).onClick = OnDropDownBtnClicked;

                            GameObject dropDownList = (GameObject)GameObject.Instantiate(UI.dropDownList);
                            dropDownList.SetActive(true);
                            dropDownList.transform.SetParent(UI.dropDownList.transform.parent);
                            dropDownList.transform.localScale = UI.dropDownList.transform.localScale;
                            dropDownListUIScript = dropDownList.GetComponent<TeamPurposeButtonDropDownListUI>();
                            dropDownListUIScript.layoutGroup.enabled = false;
                            mPurposeListRootItems.Add(dropDownList);
                            btnUI.childList = dropDownListUIScript;
                        }

                        if (dropDownListUIScript != null)
                        {
                            TeamPurposeButtonUI btnUI = GameObject.Instantiate(UI.dropDownListButton);
                            btnUI.teamPurposeId = kv.Value.Id;
                            btnUI.teamPurposeName = kv.Value.name;
                            btnUI.typeId = kv.Value.typeId;
                            btnUI.typeName = kv.Value.typeName;
                            btnUI.mainLabel.text = kv.Value.name;
                            btnUI.deng.SetActive(false);
                            btnUI.transform.SetParent(dropDownListUIScript.gameObject.transform);
                            btnUI.transform.localScale = UI.dropDownListButton.transform.localScale;
                            btnUI.gameObject.SetActive(true);
                            GameUUToggle toggle = btnUI.GetComponent<GameUUToggle>();
                            toggle.isOn = false;
                            UI.purposeListTabButtonGroup.AddToggle(toggle);
                            mToggleGroupItems.Add(btnUI);
                            dropDownListUIScript.buttons.Add(btnUI);

                            btnUI.parent = mPurposeListDropDownBtns[kv.Value.typeId];
                        }
                    }
                }
            }
        }

        private void CreateListSingleButton(TeamTargetTemplate tpl)
        {
            TeamPurposeButtonUI btnUI = GameObject.Instantiate(UI.singleButton);
            btnUI.teamPurposeId = tpl.Id;
            btnUI.teamPurposeName = tpl.name;
            btnUI.typeId = tpl.typeId;
            btnUI.typeName = tpl.typeName;
            btnUI.mainLabel.text = tpl.name;
            btnUI.deng.SetActive(false);
            //btnUI.checkMark.SetActive(false);
            btnUI.gameObject.SetActive(true);
            btnUI.transform.SetParent(UI.singleButton.transform.parent);
            btnUI.transform.localScale = UI.singleButton.transform.localScale;
            mPurposeListSingleBtns.Add(tpl.Id, btnUI);
            mPurposeListRootItems.Add(btnUI.gameObject);
            GameUUToggle toggle = btnUI.GetComponent<GameUUToggle>();
            toggle.isOn = false;
            UI.purposeListTabButtonGroup.AddToggle(toggle);
            mToggleGroupItems.Add(btnUI);
        }

        private void OnPurposeListTabChanged(int index)
        {
            TeamPurposeButtonUI btnUI = UI.purposeListTabButtonGroup.toggleList[index].GetComponent<TeamPurposeButtonUI>();

            if (mSelectedBtn != null)
            {
                if (PropertyUtil.IsLegalID(mSelectedBtn.typeId))
                {
                    if (mSelectedBtn.parent != null && mSelectedBtn.typeId != btnUI.typeId)
                    {
                        mSelectedBtn.parent.gameObject.GetComponent<GameUUToggle>().isOn = false;
                    }
                }
            }

            if (PropertyUtil.IsLegalID(mOpenedTypeId) && mOpenedTypeId != btnUI.typeId)
            {
                mPurposeListDropDownBtns[mOpenedTypeId].childList.layoutGroup.enabled = false;
                mPurposeListDropDownBtns[mOpenedTypeId].gameObject.GetComponent<GameUUToggle>().isOn = false;
            }

            mSelectedBtn = btnUI;
            OnTeamPurposeIdSelected(btnUI.teamPurposeId);

            if (TeamModel.ins.teamApplyAuto != null && TeamModel.ins.teamApplyAuto.getTargetId() == btnUI.teamPurposeId)
            {
                UI.cancelAutoMatchBtn.gameObject.SetActive(true);
                UI.autoMatchBtn.gameObject.SetActive(false);
            }
            else
            {
                UI.cancelAutoMatchBtn.gameObject.SetActive(false);
                UI.autoMatchBtn.gameObject.SetActive(true);
            }

        }

        private void OnDropDownBtnClicked(GameObject go)
        {
            int typeId = go.GetComponent<TeamPurposeButtonUI>().typeId;

            if (typeId != mOpenedTypeId)
            {
                if (PropertyUtil.IsLegalID(mOpenedTypeId))
                {
                    mPurposeListDropDownBtns[mOpenedTypeId].gameObject.GetComponent<GameUUToggle>().isOn = false;
                    mPurposeListDropDownBtns[mOpenedTypeId].childList.layoutGroup.enabled = false;
                }

                mPurposeListDropDownBtns[typeId].childList.layoutGroup.enabled = true;

                mOpenedTypeId = typeId;
            }
            else
            {
                bool isEnabled = !mPurposeListDropDownBtns[typeId].childList.layoutGroup.enabled;
                mPurposeListDropDownBtns[typeId].childList.layoutGroup.enabled = isEnabled;
                if (!isEnabled)
                {
                    mOpenedTypeId = 0;
                }
                //mPurposeListDropDownBtns[typeId].gameObject.GetComponent<GameUUToggle>().isOn = mPurposeListDropDownBtns[typeId].childList.gameObject.activeSelf;
            }
        }

        private void OnTeamPurposeIdSelected(int id)
        {
            UI.autoMatchBtn.gameObject.SetActive(true);
            UI.cancelAutoMatchBtn.gameObject.SetActive(false);
            TeamCGHandler.sendCGTeamShowList(id);
        }

        public void ShowTeamList(TeamInfo[] data)
        {
            int len = mTeamItems.Count;
            for (int i = 0; i < len; i++)
            {
                GameObject.DestroyImmediate(mTeamItems[i].gameObject, true);
                mTeamItems[i] = null;
            }
            mTeamItems.Clear();

            if (mCreateTeamListCorotine != null)
            {
                UI.StopCoroutine(mCreateTeamListCorotine);
                mCreateTeamListCorotine = null;
            }
            mCreateTeamListCorotine = UI.StartCoroutine(CreateTeamList(data));
        }

        private IEnumerator CreateTeamList(TeamInfo[] data)
        {
            int len = data.Length;
            for (int i = 0; i < len; i++)
            {
                TeamApplyListItemUI listItem = GameObject.Instantiate(UI.applyListItem);
                listItem.gameObject.transform.SetParent(UI.applyListItem.gameObject.transform.parent);
                listItem.gameObject.transform.localScale = UI.applyListItem.gameObject.transform.localScale;
                listItem.teamId = data[i].teamId;
                listItem.teamLeaderName.text = data[i].name;
                listItem.teamLeaderLv.text = "Lv " + data[i].level;
                listItem.teamLeaderCareer.text = PetJobType.GetJobName(data[i].jobTypeId);
                TeamTargetTemplate teamTargetTpl = null;
                if (PropertyUtil.IsLegalID(data[i].targetId))
                {
                    teamTargetTpl = TeamTargetTemplateDB.Instance.getTemplate(data[i].targetId);
                }
                if (teamTargetTpl != null)
                {
                    listItem.teamPurposeName.text = teamTargetTpl.name;
                }
                else
                {
                    listItem.teamPurposeName.text = LangConstant.TARGET + LangConstant.NONE;
                }
                listItem.teamMemberProgress.LabelType = ProgressBarLabelType.CurrentAndMax;
                listItem.teamMemberProgress.MaxValue = 5;
                listItem.teamMemberProgress.Value = data[i].memberNum;
                listItem.applyBtn.gameObject.name = data[i].teamId.ToString();
                listItem.applyBtn.gameObject.SetActive(data[i].applyStatus == 0);
                listItem.appliedBtn.gameObject.SetActive(data[i].applyStatus == 1);
                //EventTriggerListener.Get(listItem.applyBtn.gameObject).onClick = OnApplyBtnClicked;
                listItem.applyBtn.SetClickCallBack(OnApplyBtnClicked);
                listItem.gameObject.SetActive(true);
                mTeamItems.Add(listItem);
                yield return 0;
            }
            mCreateTeamListCorotine = null;
        }

        private void OnApplyBtnClicked(GameObject go)
        {
            int teamId = int.Parse(go.name);
            TeamCGHandler.sendCGTeamApply(teamId);
        }

        public void SetApplyItemToApplied(int teamId)
        {
            int len = mTeamItems.Count;
            for (int i = 0; i < len; i++)
            {
                if (mTeamItems[i].teamId == teamId)
                {
                    mTeamItems[i].applyBtn.gameObject.SetActive(false);
                    mTeamItems[i].appliedBtn.gameObject.SetActive(true);
                    break;
                }
            }
        }

        private void OnCreateTeamBtnClicked()
        {
            TeamCGHandler.sendCGTeamCreate();
        }

        private void OnApplyAutoBtnClicked()
        {
            if (mSelectedBtn != null)
            {
                TeamCGHandler.sendCGTeamApplyAuto(1, mSelectedBtn.teamPurposeId);
            }
        }

        private void OnCancelApplyAutoBtnClicked()
        {
            if (mSelectedBtn != null)
            {
                TeamCGHandler.sendCGTeamApplyAuto(0, mSelectedBtn.teamPurposeId);
            }
        }

        private void OnRefreshBtnClicked()
        {
            if (mSelectedBtn != null)
            {
                TeamCGHandler.sendCGTeamShowList(mSelectedBtn.teamPurposeId);
            }
        }

        public void OnReceivedTeamApplyAuto()
        {
            GCTeamApplyAuto teamApplyAuto = TeamModel.ins.teamApplyAuto;
            if (teamApplyAuto == null)
            {
                return;
            }
            int len = mToggleGroupItems.Count;
            for (int i = 0; i < len; i++)
            {
                if (mToggleGroupItems[i].teamPurposeId == teamApplyAuto.getTargetId())
                {
                    mToggleGroupItems[i].deng.SetActive(teamApplyAuto.getIsAuto() == 1);
                }
                else
                {
                    mToggleGroupItems[i].deng.SetActive(false);
                }
            }

            if (mSelectedBtn != null && mSelectedBtn.teamPurposeId == teamApplyAuto.getTargetId())
            {
                UI.autoMatchBtn.gameObject.SetActive(teamApplyAuto.getIsAuto() == 0);
                UI.cancelAutoMatchBtn.gameObject.SetActive(teamApplyAuto.getIsAuto() == 1);
            }
        }

        private void ClickClose()
        {
            hide();
        }

        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            UI.Hide();
            app.main.GameClient.ins.OnBigWndHidden();
            WndManager.open(GlobalConstDefine.TeamMainView_Name);
        }

        public override void Destroy()
        {
            int len = mTeamItems.Count;
            for (int i = 0; i < len; i++)
            {
                GameObject.DestroyImmediate(mTeamItems[i].gameObject, true);
                mTeamItems[i] = null;
            }
            mTeamItems.Clear();
            TeamModel.ins.teamApplyView = null;
            base.Destroy();
            UI = null;
        }
    }
}