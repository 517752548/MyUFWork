using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using app.db;
using app.net;
using app.pet;
using DG.Tweening;

namespace app.battle
{
    public class BattleSkillListUI
    {
        public BattleSkillListUIBehav UI;
        public UnityAction<PetSkillInfo, SkillTemplate, SkillEffectTemplate> onManualSkillSelected = null;
        public UnityAction<PetSkillInfo, SkillTemplate, SkillEffectTemplate> onLeaderAutoSkillSelected = null;
        public UnityAction onLeaderAutoAtkSelected = null;
        public UnityAction onLeaderAutoDefSelected = null;
        public UnityAction<PetSkillInfo, SkillTemplate, SkillEffectTemplate> onPetAutoSkillSelected = null;
        public UnityAction onPetAutoAtkSelected = null;
        public UnityAction onPetAutoDefSelected = null;

        public float width { get; private set; }
        public float height { get; private set; }

        //长按技能图标是否显示技能详细信息
        public bool showSkillDetail = true;

        private PetType mPetType = PetType.NONE;

        private PetSkillInfo[] mLeaderSkillInfos = null;
        private SkillTemplate[] mLeaderSkillTpls = null;
        private SkillEffectTemplate[] mLeaderSkillEffectTpls = null;
        private List<BattleSkillListItemUI> mLeaderSkillListItems = new List<BattleSkillListItemUI>();
        private int mLeaderSkillListCount = 0;
        private bool mIsLeaderSkillListCreated = false;

        private PetSkillInfo[] mPetSkillInfos = null;
        private SkillTemplate[] mPetSkillTpls = null;
        private SkillEffectTemplate[] mPetSkillEffectTpls = null;
        private List<BattleSkillListItemUI> mPetSkillListItems = new List<BattleSkillListItemUI>();
        private int mPetSkillListCount = 0;
        private bool mIsPetSkillListCreated = false;

        private List<KeyValuePair<string, BattleSkillListItemUI>> mIconImageSettings = new List<KeyValuePair<string, BattleSkillListItemUI>>();
        //private List<string> mIconLoadingList = new List<string>();

        private bool mIsSetAutoAction = false;
        private bool mIsSetFrontSkill = false;
        private bool mIsShown = false;

        private GameObject mMaskImage = null;

        private BattleSkillDetailInfoUI mSkillDetailInfoUI = null;

        private bool mIsLongTouched = false;
        
        private long mLastPetUUID = 0;

        public BattleSkillListUI(BattleSkillListUIBehav uiBehav, GameObject maskImage)
        {
            UI = uiBehav;
            mMaskImage = maskImage;
            mSkillDetailInfoUI = new BattleSkillDetailInfoUI(UI.skillDetailInfoUI);
            UI.atkBtn.SetClickCallBack(OnAtkClicked);
            UI.defBtn.SetClickCallBack(OnDefClicked);
            InputManager.Ins.AddListener(InputManager.SCREEN_UP_EVENT_TYPE, UI.gameObject, OnScreenTouchUp);
        }

        public void Show(PetInfo petInfo, PetType petType, bool isSetAutoAction, bool isSetFrontSkill = false)
        {
            mIsShown = true;
            UI.gameObject.SetActive(true);
            this.mPetType = petType;
            this.mIsSetAutoAction = isSetAutoAction;
            this.mIsSetFrontSkill = isSetFrontSkill;
            if (petType == PetType.LEADER)
            {
                this.mLeaderSkillInfos = petInfo.skillList;
                UI.autoSkillTitle.text = LangConstant.SELECT_LEADER_AUTO_SKILL;
            }
            else if (petType == PetType.PET)
            {
                if (mLastPetUUID != petInfo.petId)
                {
                    mLastPetUUID = petInfo.petId;
                    ClearPetSkillList();
                }
                this.mPetSkillInfos = petInfo.skillList;
                UI.autoSkillTitle.text = LangConstant.SELECT_PET_AUTO_SKILL;
                
            }

            UpdateData();
            UI.autoSkillsTitleContainer.SetActive(isSetAutoAction);
            UI.atkDefList.SetActive(isSetAutoAction);
            //UI.atkBtn.gameObject.SetActive(isSetAutoAction);
            //UI.defBtn.gameObject.SetActive(isSetAutoAction);
            mMaskImage.SetActive(true);
        } 
        
        public void DoMoveX(float to)
        {
            UI.gameObject.transform.DOLocalMoveX(to, 0.1f).OnComplete(moveEndCallBack);
        }
        
        public void DoMoveY(float to)
        {
            UI.gameObject.transform.DOLocalMoveY(to, 0.1f).OnComplete(moveEndCallBack);
        }

        private void moveEndCallBack()
        {
            if (mLeaderSkillListItems != null && mLeaderSkillListItems.Count > 0)
            {
                GuideManager.Ins.ShowGuide(GuideIdDef.FirstBattle, 2, mLeaderSkillListItems[0].gameObject, Vector3.zero,
                    new Vector3(-8, 8), new Vector3(5, -5), Vector2.zero, false);
            }
        }

        public void Hide()
        {
            if (mIsShown)
            {
                UI.gameObject.SetActive(false);
                mMaskImage.SetActive(false);
                if (mSkillDetailInfoUI != null && mSkillDetailInfoUI.isShown)
                {
                    mSkillDetailInfoUI.Hide();
                }
                mIsShown = false;
                mIsLongTouched = false;
            }
        }

        public void Clear()
        {
            if (UI.checkMark != null)
            {
                UI.checkMark.transform.SetParent(UI.transform);
            }

            int len = mIconImageSettings.Count;

            for (int i = 0; i < len; i++)
            {
                GameObject item = mIconImageSettings[i].Value.gameObject;
                InputManager.Ins.RemoveListener(InputManager.CLICK_EVENT_TYPE, item, OnSkillClicked);
                InputManager.Ins.RemoveListener(InputManager.STATIONARY_EVENT_TYPE, item, OnSkillLongTouched);
                InputManager.Ins.RemoveListener(InputManager.UP_EVENT_TYPE, item, OnSkillLongTouchUp);
                GameObject.DestroyImmediate(item, true);
                item = null;
            }
            mIconImageSettings.Clear();
            //mIconLoadingList.Clear();
            mLeaderSkillInfos = null;
            mLeaderSkillTpls = null;
            mLeaderSkillEffectTpls = null;
            mLeaderSkillListItems.Clear();
            mLeaderSkillListCount = 0;
            mIsLeaderSkillListCreated = false;

            mPetSkillInfos = null;
            mPetSkillTpls = null;
            mPetSkillEffectTpls = null;
            mPetSkillListItems.Clear();
            mPetSkillListCount = 0;
            mIsPetSkillListCreated = false;
        }
        
        public void Destroy()
        {
            Clear();
            GameObject.DestroyImmediate(mMaskImage, true);
            mMaskImage = null;
            GameObject.DestroyImmediate(UI.gameObject, true);
            UI = null;
        }
        
        private void ClearPetSkillList()
        {
            if (UI.checkMark != null)
            {
                UI.checkMark.transform.SetParent(UI.transform);
            }

            int len = mPetSkillListItems.Count;
            for (int i = 0; i < len; i++)
            {
                
                int len1 = mIconImageSettings.Count;
                for (int j = 0; j < len1; j++)
                {
                    if (mIconImageSettings[j].Value == mPetSkillListItems[i])
                    {
                        mIconImageSettings.RemoveAt(j);
                        break;
                    }
                }
                
                GameObject skillListItemUI = mPetSkillListItems[i].gameObject;
                InputManager.Ins.RemoveListener(InputManager.CLICK_EVENT_TYPE, skillListItemUI, OnSkillClicked);
                InputManager.Ins.RemoveListener(InputManager.STATIONARY_EVENT_TYPE, skillListItemUI, OnSkillLongTouched);
                InputManager.Ins.RemoveListener(InputManager.UP_EVENT_TYPE, skillListItemUI, OnSkillLongTouchUp);
                GameObject.DestroyImmediate(skillListItemUI, true);
                skillListItemUI = null;
            }
            
            mPetSkillInfos = null;
            mPetSkillTpls = null;
            mPetSkillEffectTpls = null;
            mPetSkillListItems.Clear();
            mPetSkillListCount = 0;
            mIsPetSkillListCreated = false;
        }

        public void UpdateData()
        {
            int skillListHeight = 0;
            int skillListContainerHeight = 0;

            if (mPetType == PetType.LEADER)
            {
                if (!mIsLeaderSkillListCreated)
                {
                    UI.leaderSkillsList.SetActive(false);
                    int len = mLeaderSkillInfos.Length;
                    mLeaderSkillTpls = new SkillTemplate[len];
                    mLeaderSkillEffectTpls = new SkillEffectTemplate[len];
                    mLeaderSkillListCount = CreateSkillList(mLeaderSkillInfos, mLeaderSkillTpls, mLeaderSkillEffectTpls, mLeaderSkillListItems);
                    UI.leaderSkillsListScrollRect.enabled = mLeaderSkillListCount > 9;
                    UI.leaderSkillsListMask.enabled = mLeaderSkillListCount > 9;
                    UI.leaderSkillsListMaskImg.enabled = mLeaderSkillListCount > 9;
                    skillListHeight = Mathf.CeilToInt((float)Mathf.Min(mLeaderSkillListCount, 9) / 3.0f) * 110;
                    skillListContainerHeight = Mathf.CeilToInt((float)mLeaderSkillListCount / 3.0f) * 110;
                    UI.leaderSkillsListLayoutElem.preferredHeight = skillListHeight;
                    UI.leaderSkillsList.GetComponent<RectTransform>().sizeDelta = new Vector2(375, skillListContainerHeight);
                    UI.leaderSkillsList.SetActive(true);
                    mIsLeaderSkillListCreated = true;
                }
                else
                {
                    skillListHeight = (int)UI.leaderSkillsListLayoutElem.preferredHeight;
                }
                UI.leaderSkillsListContainer.SetActive(true);
                UI.petSkillsListContainer.SetActive(false);
                ShowCheckMark(BattleModel.ins.leaderActivedSkillId, mLeaderSkillListItems);
            }
            else if (mPetType == PetType.PET)
            {
                if (!mIsPetSkillListCreated)
                {
                    UI.petSkillsList.SetActive(false);
                    int len = mPetSkillInfos.Length;
                    mPetSkillTpls = new SkillTemplate[len];
                    mPetSkillEffectTpls = new SkillEffectTemplate[len];
                    mPetSkillListCount = CreateSkillList(mPetSkillInfos, mPetSkillTpls, mPetSkillEffectTpls, mPetSkillListItems);
                    UI.petSkillsListScrollRect.enabled = mPetSkillListCount > 9;
                    UI.petSkillsListMask.enabled = mPetSkillListCount > 9;
                    UI.petSkillsListMaskImg.enabled = mPetSkillListCount > 9;
                    skillListHeight = Mathf.CeilToInt((float)Mathf.Min(mPetSkillListCount, 9) / 3.0f) * 110;
                    skillListContainerHeight = Mathf.CeilToInt((float)mPetSkillListCount / 3.0f) * 110;
                    UI.petSkillsListLayoutElem.preferredHeight = skillListHeight;
                    UI.petSkillsList.GetComponent<RectTransform>().sizeDelta = new Vector2(375, skillListContainerHeight);
                    UI.petSkillsList.SetActive(true);
                    mIsPetSkillListCreated = true;
                }
                else
                {
                    skillListHeight = (int)UI.petSkillsListLayoutElem.preferredHeight;
                }
                UI.leaderSkillsListContainer.SetActive(false);
                UI.petSkillsListContainer.SetActive(true);
                ShowCheckMark(BattleModel.ins.petActivedSkillId, mPetSkillListItems);
            }

            width = 375;
            height = skillListHeight + 25;

            if (mIsSetAutoAction)
            {
                height += 27;
            }

            if (mIsSetAutoAction || height == 0)
            {
                height += 110;
            }
            UI.background.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        }

        private int CreateSkillList(PetSkillInfo[] skillInfos, SkillTemplate[] skillTpls, SkillEffectTemplate[] skillEffectTpls, List<BattleSkillListItemUI> listItems)
        {
            int listTileCount = 0;
            //List<string> iconLoadingList = new List<string>();
            int len = skillInfos.Length;

            /*
            int mindId = (mPetType == PetType.LEADER ? Human.Instance.PropertyManager.getIntProp(RoleBaseIntProperties.MAINSKILL_TYPE) : 0);
            int mindLv = (mPetType ==PetType.LEADER ? Human.Instance.PropertyManager.getIntProp(RoleBaseIntProperties.MAINSKILL_LEVEL) : 0);
            */
            for (int i = 0; i < len; i++)
            {
                SkillTemplate skillTpl = SkillTemplateDB.Instance.getTemplate(skillInfos[i].skillId);

                skillTpls[i] = skillTpl;

                if (skillTpl != null && skillTpl.isPassive == 1)
                {
                    continue;
                }

                /*
                List<int> skillEffectIdList = SkillAddTemplateDB.Instance.GetSkillEffectIdList(skillInfos[i].skillId, skillInfos[i].level, mindId, mindLv);
                if (skillEffectIdList != null)
                {
                    SkillEffectTemplate skillEffectTpl = SkillEffectTemplateDB.Instance.getTemplate(skillEffectIdList[0]);
                    skillEffectTpls[i] = skillEffectTpl;
                    //ClientLog.Log("skillId:  " + mPetSkillInfos[i].skillId + "  skillEffectTpl:" + skillEffectTpl.Id);
                    //ClientLog.Log("targetRangeTypeId:  " + skillEffectTpl.targetRangeTypeId + ",   targetSelect:  " + skillEffectTpl.targetSelect);
                }
                else
                {
                    ClientLog.LogError("没有找到技能效果! 技能Id=" + skillInfos[i].skillId + ",  技能Level=" + skillInfos[i].level + ",  心法Id=" + mindId + ",  心法Level=" + mindLv);
                }
                */

                if (mPetType == PetType.LEADER)
                {
                    skillEffectTpls[i] = BattleModel.ins.GetLeaderSkillMainEffectTpl(skillInfos[i]);
                }
                else if (mPetType == PetType.PET)
                {
                    skillEffectTpls[i] = BattleModel.ins.GetPetSkillMainEffectTpl(skillInfos[i]);
                }
                CreateSkillListItem(skillInfos[i], skillTpls[i], listItems);
                /*
                string path = CreateSkillListItem(skillInfos[i], skillTpls[i], listItems);
                if (path != null && !iconLoadingList.Contains(path))
                {
                    iconLoadingList.Add(path);
                }
                */

                listTileCount++;
            }
            
            //SourceLoader.Ins.loadList(iconLoadingList, null, OnSkillIconLoaded);
            return listTileCount;
        }

        private void CreateSkillListItem(PetSkillInfo skillInfo, SkillTemplate skillTpl, List<BattleSkillListItemUI> listItems)
        {
            string path = null;
            GameObject item = GameObject.Instantiate(UI.item);

            item.SetActive(true);
            item.name = skillInfo.skillId.ToString();
            if (mPetType == PetType.LEADER)
            {
                item.transform.SetParent(UI.leaderSkillsList.transform);
            }
            else if (mPetType == PetType.PET)
            {
                item.transform.SetParent(UI.petSkillsList.transform);
            }

            item.transform.localScale = UI.item.transform.localScale;
            item.transform.localPosition = Vector3.zero;
            BattleSkillListItemUI itemBehav = item.GetComponent<BattleSkillListItemUI>();
            itemBehav.icon.gameObject.SetActive(false);

            //EventTriggerListener.Get(item).onClick = OnSkillClicked;
            InputManager.Ins.AddListener(InputManager.CLICK_EVENT_TYPE, item, OnSkillClicked);
            InputManager.Ins.AddListener(InputManager.STATIONARY_EVENT_TYPE, item, OnSkillLongTouched);
            InputManager.Ins.AddListener(InputManager.UP_EVENT_TYPE, item, OnSkillLongTouchUp);

            if (skillTpl != null)
            {
                itemBehav.Name.text = skillTpl.name;
                PathUtil.Ins.SetSkillIcon(itemBehav.icon, skillTpl.icon + "-1");
                //path = PathUtil.Ins.GetUITexturePath(skillTpl.icon, PathUtil.TEXTUER_SKILL);
                /*
                if (!mIconLoadingList.Contains(path))
                {
                    mIconLoadingList.Add(path);
                }
                */
                mIconImageSettings.Add(new KeyValuePair<string, BattleSkillListItemUI>(path, itemBehav));
            }
            else
            {
                itemBehav.Name.text = skillInfo.skillId.ToString();
            }

            listItems.Add(itemBehav);
        }
        /*
        private void OnSkillIconLoaded(RMetaEvent e)
        {
            if (mIsShown)
            {
                LoadInfo info = (LoadInfo)((e.data as List<object>)[2]);
                string path = info.urlPath;
                int len = mIconImageSettings.Count;
                for (int i = 0; i < len; i++)
                {
                    if (mIconImageSettings[i].Key == path)
                    {
                        Texture t = SourceManager.Ins.GetAsset<Texture>(path);
                        if (t != null)
                        {
                            mIconImageSettings[i].Value.icon.gameObject.SetActive(true);
                            mIconImageSettings[i].Value.icon.texture = t;
                            mIconImageSettings[i].Value.icon.SetNativeSize();
                        }
                    }
                }
            }
        }
        */

        private void OnSkillClicked(RMetaEvent e)
        {
            if (mIsLongTouched)
            {
                return;
            }

            GameObject go = e.GameObject;
            int skillId = int.Parse(go.name);

            PetSkillInfo[] skillInfos = (mPetType == PetType.LEADER ? mLeaderSkillInfos : mPetSkillInfos);
            SkillTemplate[] skillTpls = (mPetType == PetType.LEADER ? mLeaderSkillTpls : mPetSkillTpls);
            SkillEffectTemplate[] skillEffectTpls = (mPetType == PetType.LEADER ? mLeaderSkillEffectTpls : mPetSkillEffectTpls);

            int len = skillInfos.Length;
            for (int i = 0; i < len; i++)
            {
                if (skillInfos[i].skillId == skillId)
                {
                    if (mIsSetAutoAction)
                    {
                        if (mPetType == PetType.LEADER)
                        {
                            Hide();
                            this.onLeaderAutoSkillSelected(skillInfos[i], skillTpls[i], skillEffectTpls[i]);
                        }
                        else if (mPetType == PetType.PET)
                        {
                            Hide();
                            this.onPetAutoSkillSelected(skillInfos[i], skillTpls[i], skillEffectTpls[i]);
                        }
                    }
                    else
                    {
                        Hide();
                        this.onManualSkillSelected(skillInfos[i], skillTpls[i], skillEffectTpls[i]);
                    }

                    break;
                }
            }
        }

        private void OnSkillLongTouched(RMetaEvent e)
        {
            if (!showSkillDetail)
            {
                return;
            }
            if (!mSkillDetailInfoUI.isShown)
            {
                GameObject go = e.GameObject;
                if (go != null)
                {
                    int skillId = int.Parse(go.name);
                    PetSkillInfo skillInfo = GetSkillInfoBySKillId(skillId);
                    SkillTemplate skillTpl = GetSkillTplBySKillId(skillId);
                    mSkillDetailInfoUI.Show(skillInfo, skillTpl);

                    Vector3 selectedItemPos = go.transform.TransformPoint(Vector3.zero);
                    selectedItemPos = mSkillDetailInfoUI.UI.gameObject.transform.parent.InverseTransformPoint(selectedItemPos);
                    float detailInfoUIHeight = mSkillDetailInfoUI.UI.GetComponent<RectTransform>().sizeDelta.y;
                    Vector3 pos = new Vector3(UI.gameObject.transform.localPosition.x - width, selectedItemPos.y, -500);
                    if (pos.y - detailInfoUIHeight < UI.transform.localPosition.y - height)
                    {
                        pos.y = (UI.transform.localPosition.y - height) + detailInfoUIHeight;
                    }
                    mSkillDetailInfoUI.UI.gameObject.transform.localPosition = pos;
                }
            }

            mIsLongTouched = true;
        }

        private void OnSkillLongTouchUp(RMetaEvent e)
        {
            if (mIsLongTouched)
            {
                if (mSkillDetailInfoUI.isShown)
                {
                    mSkillDetailInfoUI.Hide();
                }

                mIsLongTouched = false;
            }
        }

        private void OnAtkClicked()
        {
            Hide();
            if (mPetType == PetType.LEADER)
            {
                onLeaderAutoAtkSelected();
            }
            else if (mPetType == PetType.PET)
            {
                onPetAutoAtkSelected();
            }
        }

        private void OnDefClicked()
        {
            Hide();
            if (mPetType == PetType.LEADER)
            {
                onLeaderAutoDefSelected();
            }
            else if (mPetType == PetType.PET)
            {
                onPetAutoDefSelected();
            }
        }

        public bool isShown
        {
            get
            {
                return mIsShown;
            }
        }

        public void OnActivedAutoSkillConfirmed(PetType petType, int skillId)
        {
            List<BattleSkillListItemUI> listItems = null;
            if (petType == PetType.LEADER)
            {
                listItems = mLeaderSkillListItems;
            }
            else if (petType == PetType.PET)
            {
                listItems = mPetSkillListItems;
            }

            ShowCheckMark(skillId, listItems);
        }

        private PetSkillInfo GetSkillInfoBySKillId(int skillId)
        {
            PetSkillInfo[] listItems = null;
            if (mPetType == PetType.LEADER)
            {
                listItems = mLeaderSkillInfos;
            }
            else if (mPetType == PetType.PET)
            {
                listItems = mPetSkillInfos;
            }

            if (listItems != null)
            {
                int len = listItems.Length;
                for (int i = 0; i < len; i++)
                {
                    if (listItems[i].skillId == skillId)
                    {
                        return listItems[i];
                    }
                }
            }

            return null;
        }

        private SkillTemplate GetSkillTplBySKillId(int skillId)
        {
            SkillTemplate[] listItems = null;
            if (mPetType == PetType.LEADER)
            {
                listItems = mLeaderSkillTpls;
            }
            else if (mPetType == PetType.PET)
            {
                listItems = mPetSkillTpls;
            }

            if (listItems != null)
            {
                int len = listItems.Length;
                for (int i = 0; i < len; i++)
                {
                    if (listItems[i].Id == skillId)
                    {
                        return listItems[i];
                    }
                }
            }

            return null;
        }

        private void ShowCheckMark(int skillId, List<BattleSkillListItemUI> listItems)
        {
            if (!(UI!=null&&UI.checkMark!=null))
            {
                return;
            }
            if (skillId == BatSkillID.NORMAL_ATTACK)
            {
                //Vector3 pos = UI.atkBtn.gameObject.transform.TransformPoint(Vector3.zero);
                //pos = UI.checkMark.transform.parent.transform.InverseTransformPoint(pos);
                //pos.x += 118;
                //pos.y -= 85;
                UI.checkMark.transform.SetParent(UI.atkBtn.transform);
                UI.checkMark.SetActive(true);
                //UI.checkMark.transform.localPosition = pos;
                UI.checkMark.transform.localPosition = new Vector3(59, -43);
                return;
            }
            else if (skillId == BatSkillID.DEFENSE)
            {
                //Vector3 pos = UI.defBtn.gameObject.transform.TransformPoint(Vector3.zero);
                //pos = UI.checkMark.transform.parent.transform.InverseTransformPoint(pos);
                //pos.x += 118;
                //pos.y -= 85;
                UI.checkMark.transform.SetParent(UI.defBtn.transform);
                UI.checkMark.SetActive(true);
                //UI.checkMark.transform.localPosition = pos;
                UI.checkMark.transform.localPosition = new Vector3(59, -43);
                return;
            }
            else
            {
                if (listItems != null)
                {
                    string skillIdStr = skillId.ToString();
                    int len = listItems.Count;
                    for (int i = 0; i < len; i++)
                    {
                        GameObject itemGo = listItems[i].gameObject;
                        if (itemGo.name == skillIdStr)
                        {
                            UI.checkMark.transform.SetParent(itemGo.transform);
                            //Vector3 pos = itemGo.transform.TransformPoint(Vector3.zero);
                            //pos = UI.checkMark.transform.parent.transform.InverseTransformPoint(pos);
                            //pos.x += 118;
                            //pos.y -= 85;
                            UI.checkMark.SetActive(true);
                            //UI.checkMark.transform.localPosition = pos;
                            UI.checkMark.transform.localPosition = new Vector3(118, -85);
                            return;
                        }
                    }
                }
            }

            UI.checkMark.SetActive(false);
        }

        private void OnScreenTouchUp(RMetaEvent e)
        {
            if (mSkillDetailInfoUI != null && mSkillDetailInfoUI.isShown)
            {
                mSkillDetailInfoUI.Hide();
            }
        }
    }
}