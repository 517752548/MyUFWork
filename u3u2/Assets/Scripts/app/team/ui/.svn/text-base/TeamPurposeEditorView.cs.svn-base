using UnityEngine;
using System.Collections.Generic;
using app.db;
using app.human;
using app.net;
using app.utils;
using app.zone;

namespace app.team
{
    public class TeamPurposeEditorView : BaseWnd
    {
        //[Inject(ui = "TeamPurposeEditorUI")]
        //public GameObject ui;

        public TeamPurposeEditorUI UI;

        private int mLastOpenedLv = 0;

        private List<GameObject> mPurposeListRootItems = new List<GameObject>();
        private Dictionary<int, TeamPurposeButtonUI> mPurposeListSingleBtns = new Dictionary<int, TeamPurposeButtonUI>();
        private Dictionary<int, TeamPurposeButtonUI> mPurposeListDropDownBtns = new Dictionary<int, TeamPurposeButtonUI>();

        private int mOpenedTypeId = 0;
        private TeamPurposeButtonUI mSelectedBtn = null;
        private TeamTargetTemplate mSelectedTpl = null;

        private int mPlayerMaxLevel = 0;

        public TeamPurposeEditorView()
        {
            uiName = "TeamPurposeEditorUI";
            TeamModel.ins.teamPurposeEditorView = this;
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
            UI = ui.AddComponent<TeamPurposeEditorUI>();
            UI.Init();
            UI.closeBtn.SetClickCallBack(ClickClose);
            UI.okBtn.SetClickCallBack(ClickOk);
            UI.purposeListTabButtonGroup.TabChangeHandler = OnPurposeListTabChanged;

            mPlayerMaxLevel = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.PLAYER_MAX_LEVEL);

            int[] totalNumbers = new int[mPlayerMaxLevel];
            for (int i = 0; i < mPlayerMaxLevel; i++)
            {
                totalNumbers[i] = i + 1;
            }
            UI.minLv.Init(totalNumbers, 7);
            UI.maxLv.Init(totalNumbers, 7);
        }

        public override void show(RMetaEvent e)
        {
            base.show(e);
            if (mLastOpenedLv != Human.Instance.getLevel())
            {
                mLastOpenedLv = Human.Instance.getLevel();
                UpdatePurposeList();
            }

            if (mPurposeListRootItems.Count > 0)
            {
                if (TeamModel.ins.teamPurposeInfo == null)
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

                    UI.autoMatchBtn.isOn = true;
                }
                else
                {
                    GCTeamMyTeamInfo teamPurposeInfo = TeamModel.ins.teamPurposeInfo;
                    if (teamPurposeInfo != null && PropertyUtil.IsLegalID(teamPurposeInfo.getTargetId()))
                    {
                        UpdateTeamPurposeInfo(teamPurposeInfo);
                    }
                    else
                    {
                        UI.minLv.ShowNumberList(1, mPlayerMaxLevel, 1);
                        UI.maxLv.ShowNumberList(1, mPlayerMaxLevel, mPlayerMaxLevel);
                        UI.desc.text = "";
                        UI.autoMatchBtn.isOn = true;
                    }
                }

                UI.minLv.gameObject.SetActive(true);
                UI.maxLv.gameObject.SetActive(true);
            }
            else
            {
                UI.minLv.gameObject.SetActive(false);
                UI.maxLv.gameObject.SetActive(false);
                UI.desc.text = "";
                UI.autoMatchBtn.isOn = true;
            }
        }

        public void UpdatePurposeList()
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
            mSelectedBtn = null;
            mSelectedTpl = null;
            mOpenedTypeId = 0;

            UI.purposeListTabButtonGroup.ClearToggleList();

            List<KeyValuePair<int, TeamTargetTemplate>> sortedIdKeyList = TeamTargetTemplateDB.Instance.GetSortedIdKeyList();
            len = sortedIdKeyList.Count;
            for (int i = 0; i < len; i++)
            {
                KeyValuePair<int, TeamTargetTemplate> kv = sortedIdKeyList[i];

                if (kv.Value.levelLimit <= mLastOpenedLv)
                {
                    if (kv.Value.typeId == 0)
                    {
                        GameObject singleBtn = (GameObject)GameObject.Instantiate(UI.singleButton);
                        TeamPurposeButtonUI btnUI = singleBtn.GetComponent<TeamPurposeButtonUI>();
                        btnUI.teamPurposeId = kv.Value.Id;
                        btnUI.teamPurposeName = kv.Value.name;
                        btnUI.typeId = kv.Value.typeId;
                        btnUI.typeName = kv.Value.typeName;
                        btnUI.mainLabel.text = kv.Value.name;
                        btnUI.checkMark.SetActive(false);
                        singleBtn.SetActive(true);
                        singleBtn.transform.SetParent(UI.singleButton.transform.parent);
                        singleBtn.transform.localScale = UI.singleButton.transform.localScale;
                        mPurposeListSingleBtns.Add(kv.Value.Id, btnUI);
                        mPurposeListRootItems.Add(singleBtn);
                        GameUUToggle toggle = singleBtn.GetComponent<GameUUToggle>();
                        toggle.isOn = false;
                        UI.purposeListTabButtonGroup.AddToggle(toggle);
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
                            GameObject dropDownBtn = (GameObject)GameObject.Instantiate(UI.dropDownButton);
                            TeamPurposeButtonUI btnUI = dropDownBtn.GetComponent<TeamPurposeButtonUI>();
                            btnUI.teamPurposeId = 0;
                            btnUI.typeId = kv.Value.typeId;
                            btnUI.typeName = kv.Value.typeName;
                            btnUI.mainLabel.text = kv.Value.typeName;
                            btnUI.mainLabel.gameObject.SetActive(true);
                            btnUI.multLabelMain.text = kv.Value.typeName;
                            btnUI.multLabelMain.gameObject.SetActive(false);
                            btnUI.multLabelSub.gameObject.SetActive(false);
                            btnUI.checkMark.SetActive(false);
                            dropDownBtn.SetActive(true);
                            dropDownBtn.transform.SetParent(UI.dropDownButton.transform.parent);
                            dropDownBtn.transform.localScale = UI.dropDownButton.transform.localScale;
                            dropDownBtn.GetComponent<GameUUToggle>().isOn = false;
                            mPurposeListDropDownBtns.Add(kv.Value.typeId, btnUI);
                            mPurposeListRootItems.Add(dropDownBtn);
                            EventTriggerListener.Get(dropDownBtn).onClick = OnDropDownBtnClicked;

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
                            GameObject dropDownListBtn = (GameObject)GameObject.Instantiate(UI.dropDownListButton);
                            TeamPurposeButtonUI btnUI = dropDownListBtn.GetComponent<TeamPurposeButtonUI>();
                            btnUI.teamPurposeId = kv.Value.Id;
                            btnUI.teamPurposeName = kv.Value.name;
                            btnUI.typeId = kv.Value.typeId;
                            btnUI.typeName = kv.Value.typeName;
                            btnUI.mainLabel.text = kv.Value.name;
                            dropDownListBtn.transform.SetParent(dropDownListUIScript.gameObject.transform);
                            dropDownListBtn.transform.localScale = UI.dropDownListButton.transform.localScale;
                            dropDownListBtn.SetActive(true);
                            GameUUToggle toggle = dropDownListBtn.GetComponent<GameUUToggle>();
                            toggle.isOn = false;
                            UI.purposeListTabButtonGroup.AddToggle(toggle);
                            dropDownListUIScript.buttons.Add(btnUI);

                            btnUI.parent = mPurposeListDropDownBtns[kv.Value.typeId];
                        }
                    }
                }
            }
        }

        private void OnPurposeListTabChanged(int index)
        {
            TeamPurposeButtonUI btnUI = UI.purposeListTabButtonGroup.toggleList[index].GetComponent<TeamPurposeButtonUI>();

            if (mSelectedBtn != null)
            {
                if (mSelectedBtn.typeId == 0)
                {
                    mSelectedBtn.checkMark.SetActive(false);
                }
                else
                {
                    if (mSelectedBtn.parent != null && mSelectedBtn.typeId != btnUI.typeId)
                    {
                        mSelectedBtn.parent.checkMark.SetActive(false);
                        mSelectedBtn.parent.mainLabel.gameObject.SetActive(true);
                        mSelectedBtn.parent.multLabelMain.gameObject.SetActive(false);
                        mSelectedBtn.parent.multLabelSub.gameObject.SetActive(false);
                        mSelectedBtn.parent.gameObject.GetComponent<GameUUToggle>().isOn = false;
                    }
                }
            }

            if (PropertyUtil.IsLegalID(mOpenedTypeId) && mOpenedTypeId != btnUI.typeId)
            {
                mPurposeListDropDownBtns[mOpenedTypeId].childList.layoutGroup.enabled = false;
                mPurposeListDropDownBtns[mOpenedTypeId].gameObject.GetComponent<GameUUToggle>().isOn = false;
                //mPurposeListDropDownBtns[mOpenedTypeId].checkMark.SetActive(false);
            }

            if (PropertyUtil.IsLegalID(btnUI.typeId) && btnUI.parent != null)
            {
                btnUI.parent.checkMark.SetActive(true);
                btnUI.parent.mainLabel.gameObject.SetActive(false);
                btnUI.parent.multLabelMain.gameObject.SetActive(true);
                btnUI.parent.multLabelSub.gameObject.SetActive(true);
                btnUI.parent.multLabelSub.text = btnUI.teamPurposeName;
            }
            else
            {
                btnUI.checkMark.SetActive(true);
            }

            mSelectedTpl = TeamTargetTemplateDB.Instance.getTemplate(btnUI.teamPurposeId);
            GCTeamMyTeamInfo teamPurposeInfo = TeamModel.ins.teamPurposeInfo;

            if (teamPurposeInfo != null && btnUI.teamPurposeId == teamPurposeInfo.getTargetId())
            {
                UI.minLv.ShowNumberList(mSelectedTpl.levelLimit, mPlayerMaxLevel, teamPurposeInfo.getLevelMin());
                UI.maxLv.ShowNumberList(mSelectedTpl.levelLimit, mPlayerMaxLevel, teamPurposeInfo.getLevelMax());
            }
            else
            {
                UI.minLv.ShowNumberList(mSelectedTpl.levelLimit, mPlayerMaxLevel, mSelectedTpl.levelLimit);
                UI.maxLv.ShowNumberList(mSelectedTpl.levelLimit, mPlayerMaxLevel, mPlayerMaxLevel);
            }

            UI.desc.text = mSelectedTpl.desc;

            mSelectedBtn = btnUI;
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

        public void UpdateTeamPurposeInfo(GCTeamMyTeamInfo data)
        {
            if (PropertyUtil.IsLegalID(data.getTargetId()))
            {
                TeamTargetTemplate tpl = TeamTargetTemplateDB.Instance.getTemplate(data.getTargetId());
                if (tpl != null)
                {
                    TeamPurposeButtonUI btnUI = null;
                    if (tpl.typeId == 0)
                    {
                        btnUI = mPurposeListSingleBtns[tpl.Id];
                    }
                    else
                    {
                        TeamPurposeButtonDropDownListUI dropDownList = mPurposeListDropDownBtns[tpl.typeId].childList;
                        int len = dropDownList.buttons.Count;
                        for (int i = 0; i < len; i++)
                        {
                            if (tpl.Id == dropDownList.buttons[i].teamPurposeId)
                            {
                                btnUI = dropDownList.buttons[i];
                                break;
                            }
                        }
                    }

                    if (btnUI != null)
                    {
                        if (PropertyUtil.IsLegalID(btnUI.typeId) && btnUI.parent != null)
                        {
                            OnDropDownBtnClicked(btnUI.parent.gameObject);
                        }
                        btnUI.gameObject.GetComponent<GameUUToggle>().isOn = true;
                    }
                }
            }

            UI.autoMatchBtn.isOn = (data.getIsAutoMatch() == 1);
        }

        private void ClickClose()
        {
            hide();
        }

        private void ClickOk()
        {
            if (mSelectedTpl == null)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("请选择队伍目标");
            }
            else
            {
                TeamCGHandler.sendCGTeamChooseTarget(mSelectedTpl.Id, UI.minLv.GetCurrentNumber(), UI.maxLv.GetCurrentNumber(), UI.autoMatchBtn.isOn ? 1 : 0);
                hide();
            }
        }
        
        public override void Destroy()
        {
            TeamModel.ins.teamPurposeEditorView = null;
            base.Destroy();
            UI = null;
        }
    }
}

