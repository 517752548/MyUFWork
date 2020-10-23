using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using app.item;
using app.net;
using app.db;
using app.human;
using app.utils;
using app.tips;
using app.bag;
using app.zone;

namespace app.pet
{
    public class QuickData
    {
        public int m_index = -1;
        public int m_skillid = -1;
    }
    public class PetSkillUIScript
    {
        private PetSkillUI mUI = null;

        private List<QuickPetSkillItem> mSkillItems = new List<QuickPetSkillItem>();
        private List<QuickPetSkillItem> m_QuickSkillItems = new List<QuickPetSkillItem>();
        private List<SkillTemplate> m_learskills = new List<SkillTemplate>();
        private CommonItemScript mBookItem = null;
        private ItemDetailData mSelectedBookItemData = null;
        private UnityAction<ItemDetailData> mOnBookItemClicked = null;
        private UnityAction mOnTabChanged = null;
        private bool mIsShowingTalentSkills = false;
        private PetInfo mPetInfo = null;
        private ItemTemplate mTianfuItemTpl = null;

        /// <summary>
        /// 当前选择切页
        /// </summary>
        private int m_tabgroup_select_index = -1;

        /// <summary>
        /// 快捷技能临时列表
        /// </summary>
        private int[] m_quickskillid = new int[5];

        /// <summary>
        /// 当前选择快捷技能
        /// </summary>
        private int m_select_quick_index = -1;

        /// <summary>
        /// 是否正在设置快捷技能
        /// </summary>
        private bool m_ISSetQuick = false;

        /// <summary>
        /// 是否点击的是快捷技能
        /// </summary>
        private bool m_ISQuickClick = false;

        public PetSkillUIScript(PetSkillUI ui, UnityAction<ItemDetailData> onBookItemClicked, UnityAction onTabChanged)
        {
            mUI = ui;
            mUI.tabBtnGroup.TabChangeHandler = OnTabChanged;
            mUI.shengjiBtn.SetClickCallBack(Learn);
            mUI.xitianfuBtn.SetClickCallBack(XiTianFu);
            mUI.kuozhanjinenglanBtn.SetClickCallBack(kuozhanjinenglanBtn);

            mOnBookItemClicked = onBookItemClicked;
            mOnTabChanged = onTabChanged;
            mUI.defaultSkillItem.gameObject.SetActive(false);
            for (int i = 0; i < 5; i++)
            {
                QuickPetSkillItem item = new QuickPetSkillItem(mUI.skillItems.transform.Find(i.ToString()).gameObject.GetComponent<CommonItemUI>(), OnQuickSkillItemClicked);
                item.setEmpty();
                m_QuickSkillItems.Add(item);
            }

            GameObject.DestroyImmediate(mUI.bookItem.num, true);
            mUI.bookItem.num = null;
            mBookItem = new CommonItemScript(mUI.bookItem, OnBookItemClicked);
            mBookItem.setData(null);
            mBookItem.setClickFor(CommonItemClickFor.OnlyCallBack);
            EventTriggerListener.Get(mUI.tianfuCost.gameObject).onClick = OnXiaohaoItemClicked;
            EventTriggerListener.Get(mUI.m_jinenglanCost.gameObject).onClick = OnJinengLanItemClicked;
            InputManager.Ins.AddListener(InputManager.SCREEN_UP_EVENT_TYPE, mUI.gameObject, ClickOther);
            //PetModel.Ins.addChangeEvent(PetModel.PET_QUICK_SKILL_REFRESH, UpdateQuickSet);
            PetModel.Ins.addChangeEvent(PetModel.PET_JINENG_LAN_UPDATE, RefreshJiNengLan);
            
        }

        private void OnQuickSkillItemClicked(object obj)
        {
            if (obj is QuickData)
            {
                QuickData clickindex = obj as QuickData;
                int tab = clickindex.m_index;
                if (m_ISSetQuick)
                {
                    if (-1 == m_quickskillid[tab])
                    {

                    }
                    else
                    {
                        if (m_select_quick_index == tab)
                        {
                            ///卸下技能///
                            //HumanskillCGHandler.sendCGHsSubSkillOffShortcut(m_select_quick_index);
                            PetCGHandler.sendCGPetSkillOffShortcut(mPetInfo.petId, m_select_quick_index);
                        }
                        else
                        {
                            ///交换两个技能///
                            //HumanskillCGHandler.sendCGHsSubSkillShortcutChangePosition(m_quickskillid[tab], m_select_quick_index);
                            PetCGHandler.sendCGPetSkillShortcutChangePosition(mPetInfo.petId, m_quickskillid[tab], m_select_quick_index);
                        }
                    }
                    EndQuick();
                }
                else
                {
                    m_select_quick_index = tab;
                    StartQuick();
                }
                m_ISQuickClick = true;
            }
        }
        
        private void OnSkillItemClicked(object obj)
        {
            if (obj is PetSkillInfo)
            {
                PetSkillInfo skillInfo = obj as PetSkillInfo;
                if (m_ISSetQuick)
                {
                    ///判断技能是否可以放到快捷技能中///
                    SkillTemplate skillTpl = SkillTemplateDB.Instance.getTemplate(skillInfo.skillId);
                    if (1 == skillTpl.isPassive || CheckInQuick(skillTpl.Id))
                    {
                    }
                    else
                    {
                        ///设置快捷技能///

                        PetCGHandler.sendCGPetSkillPutonShortcut(mPetInfo.petId, skillTpl.Id,m_select_quick_index);
                        EndQuick();
                    }
                    m_ISQuickClick = true;
                }
                else
                {
                    SkillTips.ins.ShowTips(skillInfo);
                }
            }
            else if (obj is SkillTemplate)
            {
                SkillTemplate skilltpl = obj as SkillTemplate;
                if (m_ISSetQuick)
                {
                    ///判断技能是否可以放到快捷技能中///

                    if (1 == skilltpl.isPassive || CheckInQuick(skilltpl.Id))
                    {
                    }
                    else
                    {
                        ///设置快捷技能///

                        PetCGHandler.sendCGPetSkillOffShortcut(mPetInfo.petId, m_select_quick_index);
                        EndQuick();
                    }
                    m_ISQuickClick = true;
                }
                else
                {
                    
                    SkillTips.ins.ShowTips(skilltpl);
                }
            }
        }

        /// <summary>
        /// 更换当前选择宠物
        /// </summary>
        /// <param name="petInfo"></param>
        public void UpdatePanel(PetInfo petInfo)
        {
            ClientLog.Log("PetSkillUIScript UpdatePanel");
            
            mPetInfo = petInfo;
            //setEmpty();
            if (mPetInfo != null)
            {
                mUI.gameObject.SetActive(true);
                RefershBaseInfo();

                if (0 == m_tabgroup_select_index)
                {
                    UpdateTianfu(mPetInfo);
                }
                else if (1 == m_tabgroup_select_index)
                {
                    UpdatePutong();
                }
                else
                {
                    UpdateJiNengLan();
                    RefreshQuickSkills();
                }   
            }
            else
            {
                mUI.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// 切换宠物选择之后，刷新基础信息
        /// </summary>
        private void RefershBaseInfo()
        {
            ///开启天赋技能所需物品///
            PetTemplate pettpl = PetTemplateDB.Instance.getTemplate(mPetInfo.tplId);
            if (null != pettpl)
            {
                int id = 0;
                ///神兽///
                if (2 == pettpl.petpetTypeId)
                {
                    if (PetModel.Ins.IsChongWu)
                    {
                        id = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.PET_TALENT_SHENSHOU_ITEMID);
                    }
                    else
                    {
                        id = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.PET_HORSE_TALENT_SHENSHOU_ITEMID);
                    }

                }
                else
                {
                    ///普通///
                    if (PetModel.Ins.IsChongWu)
                    {
                        id = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.PET_TALENT_ITEMID);
                    }
                    else
                    {
                        id = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.PET_HORSE_TALENT_ITEMID);
                    }
                }
                mTianfuItemTpl = ItemTemplateDB.Instance.getTempalte(id);

                if (mTianfuItemTpl != null)
                {

                    mUI.tianfuTxt3.text = mTianfuItemTpl.name;
                    PathUtil.Ins.SetItemIcon(mUI.tianfuCost.icon, mTianfuItemTpl.icon);
                }
                else
                {
                    mUI.tianfuCost.icon.gameObject.SetActive(false);
                }
            }
            else
            {
                mUI.tianfuCost.icon.gameObject.SetActive(false);
            }

            ///开启天赋技能需要的寿命和技能栏数量///
            Pet ttt = Human.Instance.PetModel.getPet(mPetInfo.petId);
            if (null != ttt)
            {
                if (PetModel.Ins.IsChongWu)
                {
                    mUI.tianfuTxt7.text = ttt.life + "/" + ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.PET_LING_WU_JI_NENG_SHOU_MING);
                }
                else
                {
                    mUI.tianfuTxt7.text = ttt.life + "/" + ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.PET_HORSE_LING_WU_JI_NENG_SHOU_MING);
                }
                mUI.tianfuTxt8.text = mPetInfo.skillList.Length + "/" + mPetInfo.petSkillBarNum;
                mUI.putongTxt5.text = mPetInfo.skillList.Length + "/" + mPetInfo.petSkillBarNum;
                mUI.jinenglan3.text = mPetInfo.skillList.Length + "/" + mPetInfo.petSkillBarNum;
            }
            else
            {
                mUI.tianfuTxt7.text = "0/0";
                mUI.tianfuTxt8.text = "";
                mUI.putongTxt5.text = "0/0";
                mUI.jinenglan3.text = "0/0";
            }
            UpdateTianfuItemNum();
        }

        /// <summary>
        /// 更新天赋技能
        /// </summary>
        private void UpdateTianfu(PetInfo petInfo)
        {
            ///显示宠物所有可学技能///
            List<SkillTemplate> talentskills = new List<SkillTemplate>();
            if (PetModel.Ins.IsChongWu)
            {
                PetTemplate petTpl = PetTemplateDB.Instance.getTemplate((int)petInfo.tplId);
                PetTalentSkillPackTemplate skillPack = PetTalentSkillPackTemplateDB.Instance.getTemplate(petTpl.petTalentSkillPackId);
                if (null != skillPack)
                {
                    for (int i = 0; i < skillPack.talentSkillList.Count; i++)
                    {
                        if (0 == skillPack.talentSkillList[i].skillId)
                        {
                            continue;
                        }

                        SkillTemplate skillTpl = SkillTemplateDB.Instance.getTemplate(skillPack.talentSkillList[i].skillId);
                        if (null != skillTpl)
                        {
                            talentskills.Add(skillTpl);
                        }
                    }
                }
            }
            else
            {
                PetTemplate petTpl = PetTemplateDB.Instance.getTemplate((int)petInfo.tplId);
                PetHorseTalentSkillPackTemplate skillPack = PetHorseTalentSkillPackTemplateDB.Instance.getTemplate(petTpl.petTalentSkillPackId);
                if (null != skillPack)
                {
                    for (int i = 0; i < skillPack.talentSkillList.Count; i++)
                    {
                        if (0 == skillPack.talentSkillList[i].skillId)
                        {
                            continue;
                        }

                        SkillTemplate skillTpl = SkillTemplateDB.Instance.getTemplate(skillPack.talentSkillList[i].skillId);
                        if (null != skillTpl)
                        {
                            talentskills.Add(skillTpl);
                        }
                    }
                }
            }
            int tlen = talentskills.Count;
            int slen = petInfo.skillList.Length;
            bool isexited = false;
            int index = 0;
            for (int i = 0; i < tlen; i++)
            {
                SkillTemplate skillTpl = talentskills[i];

                if (index >= mSkillItems.Count)
                {
                    CommonItemUI go = GameObject.Instantiate(mUI.defaultSkillItem);
                    go.gameObject.SetActive(true);
                    go.ScrollRect = mUI.defaultSkillItem.transform.parent.parent.GetComponent<ScrollRect>();
                    QuickPetSkillItem item = new QuickPetSkillItem(go, OnSkillItemClicked);
                    go.transform.SetParent(mUI.defaultSkillItem.transform.parent);
                    go.gameObject.transform.localScale = Vector3.one;
                    mSkillItems.Add(item);
                }
                mSkillItems[index].UI.gameObject.SetActive(true);
                mSkillItems[index].setEmpty();

                mSkillItems[index].SetData(skillTpl);

                isexited = false;
                for (int j = 0; j < slen; j++)
                {

                    if (petInfo.skillList[j].skillId == skillTpl.Id)
                    {
                        isexited = true;
                        break;
                    }
                }
                mSkillItems[index].SetOpen(isexited);
                ++index;
            }

            OtherSkill(tlen, 10);
        }

        private void UpdatePutong()
        {
            ///已学习的技能///
            int itemIdx = 0;
            int tlen = mPetInfo.skillList.Length;
            for (int i = 0; i < tlen; i++)
            {
                SkillTemplate skillTpl = SkillTemplateDB.Instance.getTemplate(mPetInfo.skillList[i].skillId);
                if (skillTpl != null)
                {
                    if (skillTpl.skillTypeId == 2)
                    {
                        if (itemIdx >= mSkillItems.Count)
                        {
                            CommonItemUI go = GameObject.Instantiate(mUI.defaultSkillItem);
                            go.gameObject.SetActive(true);
                            go.ScrollRect = mUI.defaultSkillItem.transform.parent.parent.GetComponent<ScrollRect>();
                            QuickPetSkillItem item = new QuickPetSkillItem(go, OnSkillItemClicked);
                            go.transform.SetParent(mUI.defaultSkillItem.transform.parent);
                            go.gameObject.transform.localScale = Vector3.one;
                            mSkillItems.Add(item);
                        }
                        mSkillItems[itemIdx].UI.gameObject.SetActive(true);
                        mSkillItems[itemIdx].SetData(mPetInfo.skillList[i]);
                        mSkillItems[itemIdx].SetOpen(true);
                        itemIdx++;
                    }
                }
            }

            OtherSkill(itemIdx,15);
        }

        private void UpdateJiNengLan()
        {
            ///已学习的技能///
            int itemIdx = 0;
            int tlen = mPetInfo.skillList.Length;
            m_learskills.Clear();
            for (int i = 0; i < tlen; i++)
            {
                SkillTemplate skillTpl = SkillTemplateDB.Instance.getTemplate(mPetInfo.skillList[i].skillId);
                if (skillTpl != null)
                {
                    m_learskills.Add(skillTpl);
                    if (itemIdx >= mSkillItems.Count)
                    {
                        CommonItemUI go = GameObject.Instantiate(mUI.defaultSkillItem);
                        go.gameObject.SetActive(true);
                        go.ScrollRect = mUI.defaultSkillItem.transform.parent.parent.GetComponent<ScrollRect>();
                        QuickPetSkillItem item = new QuickPetSkillItem(go, OnSkillItemClicked);
                        go.transform.SetParent(mUI.defaultSkillItem.transform.parent);
                        go.gameObject.transform.localScale = Vector3.one;
                        mSkillItems.Add(item);
                    }
                    mSkillItems[itemIdx].UI.gameObject.SetActive(true);
                    mSkillItems[itemIdx].SetData(mPetInfo.skillList[i]);

                    if (1 == skillTpl.isPassive)
                    {
                        mSkillItems[i].SetOpen(false);
                    }
                    else
                    {
                        mSkillItems[i].SetOpen(true);
                    }
                    itemIdx++;

                }
            }

            OtherSkill(itemIdx, 10);
        }

        public void OtherSkill(int itemIdx, int showcount)
        {
            int count = 0;
            if (0 != itemIdx % 5)
            {
                count = 5 - itemIdx % 5;
            }
            for (int i = itemIdx; i < itemIdx + count; ++i)
            {
                if (i >= mSkillItems.Count)
                {
                    CommonItemUI go = GameObject.Instantiate(mUI.defaultSkillItem);
                    go.gameObject.SetActive(true);
                    go.ScrollRect = mUI.defaultSkillItem.transform.parent.parent.GetComponent<ScrollRect>();
                    QuickPetSkillItem item = new QuickPetSkillItem(go, OnSkillItemClicked);
                    go.transform.SetParent(mUI.defaultSkillItem.transform.parent);
                    go.gameObject.transform.localScale = Vector3.one;
                    mSkillItems.Add(item);
                }
                mSkillItems[i].UI.gameObject.SetActive(true);
                mSkillItems[i].setEmpty();
            }
            itemIdx += count;

            if (itemIdx < showcount)
            {
                for (int i = itemIdx; i < showcount; i++)
                {
                    if (i >= mSkillItems.Count)
                    {
                        CommonItemUI go = GameObject.Instantiate(mUI.defaultSkillItem);
                        go.gameObject.SetActive(true);
                        go.ScrollRect = mUI.defaultSkillItem.transform.parent.parent.GetComponent<ScrollRect>();
                        QuickPetSkillItem item = new QuickPetSkillItem(go, OnSkillItemClicked);
                        go.transform.SetParent(mUI.defaultSkillItem.transform.parent);
                        go.gameObject.transform.localScale = Vector3.one;
                        mSkillItems.Add(item);
                    }
                    mSkillItems[i].UI.gameObject.SetActive(true);
                    mSkillItems[i].setEmpty();
                }
                itemIdx = showcount;
            }

            ///隐藏剩下的///
            for (int i = itemIdx; i < mSkillItems.Count; i++)
            {
                mSkillItems[i].UI.gameObject.SetActive(false);
                mSkillItems[i].setEmpty();
            }
        }

        public void setEmpty()
        {
            for (int i = 0; i < 15; i++)
            {
                mSkillItems[i].setEmpty();
            }

            if (mUI.bookItem.gameObject.activeSelf)
            {
                mBookItem.setData(null);
                Text text = mUI.shengjiBtn.GetComponentInChildren<Text>();
                if (text!=null) text.text = LangConstant.LEARN;
            }
        }

        public void OnSkillBookSelected(ItemDetailData data)
        {
            mSelectedBookItemData = data;
            mBookItem.setData(data);
            Text text = mUI.shengjiBtn.GetComponentInChildren<Text>();
            if (data == null)
            {
                if (text != null) text.text = LangConstant.LEARN;
            }
            else {
                if (data.petSkillBookItemTemplate.bookLevel == 1)
                {
                    if (text != null) text.text = LangConstant.LEARN;
                }
                else
                {
                    if (text != null) text.text = LangConstant.UPGRADE;
                }
            }
            
        }

        private void OnTabChanged(int curIndex)
        {
            if (m_tabgroup_select_index == curIndex)
            {
                return;
            }
            m_tabgroup_select_index = curIndex;
            if (m_tabgroup_select_index == 0)
            {
                mIsShowingTalentSkills = true;
                mUI.zizhiskillRTF.transform.localPosition = new Vector3(-41, 55,0);
                mUI.zizhiskillRTF.sizeDelta = new Vector2(440, 164);
                mUI.m_tianfuobj.SetActive(true);
                mUI.m_putongobj.SetActive(false);
                mUI.m_jinenglanobj.SetActive(false);

            }
            else if (m_tabgroup_select_index == 1)
            {
                mIsShowingTalentSkills = false;
                mUI.zizhiskillRTF.transform.localPosition = new Vector3(-41, 135, 0);
                mUI.zizhiskillRTF.sizeDelta = new Vector2(440, 246);
                mUI.m_tianfuobj.SetActive(false);
                mUI.m_putongobj.SetActive(true);
                mUI.m_jinenglanobj.SetActive(false);
                OnSkillBookSelected(null);
            }
            else if (m_tabgroup_select_index == 2)
            {
                mUI.zizhiskillRTF.transform.localPosition = new Vector3(-41, 40, 0);
                mUI.zizhiskillRTF.sizeDelta = new Vector2(440, 164);
                mUI.m_tianfuobj.SetActive(false);
                mUI.m_putongobj.SetActive(false);
                mUI.m_jinenglanobj.SetActive(true);

                ///扩展技能栏所需物品///
                if (mUI.m_jinenglanCost.icon.sprite == null)
                {
                    ItemTemplate temp = ItemTemplateDB.Instance.getTempalte(ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.KUO_ZHAN_JI_NENG_LAN_ID));
                    mUI.m_jinenglanCost.icon.gameObject.SetActive(false);
                    if (temp != null)
                    {
                        mUI.jinenglan5.text = temp.name;
                        PathUtil.Ins.SetItemIcon(mUI.m_jinenglanCost.icon, temp.icon);
                    }
                }
                
                
            }


            UpdatePanel(mPetInfo);

            if (mOnTabChanged != null)
            {
                mOnTabChanged();
            }
        }

        public void UpdateTianfuItemNum()
        {
            if (mTianfuItemTpl == null)
            {
                mUI.tianfuCost.num.text = "";
            }
            else
            {
                int numNeed = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.PET_TALENT_ITEMNUM);
                int myNum = Human.Instance.BagModel.getHasNum(mTianfuItemTpl.Id);
                if (myNum >= numNeed)
                {
                    mUI.tianfuCost.num.text = ColorUtil.getColorText(ColorUtil.GREEN, myNum.ToString()) + " / " + numNeed;
                }
                else
                {
                    mUI.tianfuCost.num.text = ColorUtil.getColorText(ColorUtil.RED, myNum.ToString()) + " / " + numNeed;
                }
            }

            int neednum = 1;//ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.KUO_ZHAN_JI_NENG_LAN_NUM);
            int itemid = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.KUO_ZHAN_JI_NENG_LAN_ID);
            int itemnum = BagModel.Ins.getHasNum(itemid);
            if (itemnum >= neednum)
            {
                mUI.m_jinenglanCost.num.text = ColorUtil.getColorText(ColorUtil.GREEN, itemnum.ToString()) + " / " + neednum;
            }
            else
            {
                mUI.m_jinenglanCost.num.text = ColorUtil.getColorText(ColorUtil.RED, itemnum.ToString()) + " / " + neednum;
            }
        }

        /*
        private void OnItemIconLoaded(RMetaEvent e)
        {
            string str = PathUtil.Ins.GetUITexturePath(mTianfuItemTpl.icon, PathUtil.TEXTUER_ITEM);
            Texture2D t = SourceManager.Ins.GetAsset<Texture2D>(str);
            if (t != null)
            {
                mUI.tianfuCost.icon.texture = t;
                mUI.tianfuCost.icon.gameObject.SetActive(true);
            }
        }
        */

        private void OnBookItemClicked(ItemDetailData itemData)
        {
            if (mOnBookItemClicked != null)
            {
                mOnBookItemClicked(itemData);
            }
        }

        private void Learn()
        {
            if (mPetInfo != null && mBookItem.itemData != null)
            {
                if (PetModel.Ins.IsChongWu)
                {
                    PetCGHandler.sendCGPetStudyNormalSkill(mPetInfo.petId, mBookItem.itemData.itemTemplate.Id);
                }
                else
                {
                    PetCGHandler.sendCGPetHorseStudyNormalSkill(mPetInfo.petId, mBookItem.itemData.itemTemplate.Id);
                }
            }
        }

        private void XiTianFu()
        {
            GuideManager.Ins.RemoveGuide(GuideIdDef.PetTalent);
            
            if (mPetInfo != null)
            {
                if (PetModel.Ins.IsChongWu)
                {
                    PetCGHandler.sendCGPetRefreshTalentSkill(mPetInfo.petId);
                }
                else
                {
                    PetCGHandler.sendCGPetHorseRefreshTalentSkill(mPetInfo.petId);
                }
            }
        }

        private void kuozhanjinenglanBtn()
        {
            if (mPetInfo != null)
            {
                /////判断道具///
                ////PetCGHandler.sendCGPetRefreshTalentSkill(mPetInfo.petId);
                //int itemid = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.KUO_ZHAN_JI_NENG_LAN_ID);
                //int itemnum = BagModel.Ins.getHasNum(itemid);
                //if (itemnum > 0)
                //{
                //}
                //else
                //{
                //    ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.KUO_ZHAN_JI_NENG_BU_ZU);
                //    return;
                //}
                if (PetModel.Ins.IsChongWu)
                {
                    PetCGHandler.sendCGAddPetSkillbarNum(mPetInfo.petId);
                }
                else
                {
                    PetCGHandler.sendCGAddPetHorseSkillbarNum(mPetInfo.petId);
                }
            }

            
        }
        
        private void OnXiaohaoItemClicked(GameObject go)
        {
            ItemTips.Ins.ShowTips(mTianfuItemTpl,true);
        }

        private void OnJinengLanItemClicked(GameObject go)
        {
            ItemTemplate temp = ItemTemplateDB.Instance.getTempalte(ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.KUO_ZHAN_JI_NENG_LAN_ID));
            if (null != temp)
            {
                ItemTips.Ins.ShowTips(temp, true);
            }
        }
        
        public void Destroy()
        {
            InputManager.Ins.RemoveListener(InputManager.SCREEN_UP_EVENT_TYPE, mUI.gameObject, ClickOther);
            //PetModel.Ins.removeChangeEvent(PetModel.PET_QUICK_SKILL_REFRESH, UpdateQuickSet);
            PetModel.Ins.removeChangeEvent(PetModel.PET_JINENG_LAN_UPDATE, RefreshJiNengLan);
            GameObject.DestroyImmediate(mUI.gameObject, true);
            mUI = null;
        }

        

        /// <summary>
        /// 技能栏扩展回调
        /// </summary>
        public void RefreshJiNengLan(RMetaEvent e = null)
        {
            if (null != e)
            {
                if (PetModel.Ins.IsChongWu)
                {
                    GCAddPetSkillbarNum msg = e.data as GCAddPetSkillbarNum;
                    if (1 == msg.getResult())
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.KUO_ZHAN_JI_NENG_CHENG_GONG);
                    }
                    else
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.KUO_ZHAN_JI_NENG_SHI_BAI);
                    }
                }
                else
                {
                    GCAddPetHorseSkillbarNum msg = e.data as GCAddPetHorseSkillbarNum;
                    if (1 == msg.getResult())
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.KUO_ZHAN_JI_NENG_CHENG_GONG);
                    }
                    else
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.KUO_ZHAN_JI_NENG_SHI_BAI);
                    }
                }
            }
        }

        ///// <summary>
        ///// 回掉设置快捷技能
        ///// </summary>
        //public void UpdateQuickSet(RMetaEvent e = null)
        //{
        //    RefreshQuickSkills();
        //}

        /// <summary>
        /// 重新刷新快捷技能
        /// </summary>
        private void RefreshQuickSkills()
        {
            if (null != mPetInfo)
            {
                PetSkillShortcutInfo[] temp = PetModel.Ins.getPet(mPetInfo.petId).PetInfo.shortcutList;
                if (null != temp)
                {
                    for (int i = 0; i < m_quickskillid.Length; ++i)
                    {
                        bool isexited = false;
                        for (int j = 0; j < temp.Length; ++j)
                        {
                            if (i == temp[j].shortcutIndex)
                            {
                                m_quickskillid[i] = temp[j].skillId;
                                isexited = true;
                                break;
                            }
                        }
                        if (!isexited)
                        {
                            m_quickskillid[i] = -1;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < m_quickskillid.Length; ++i)
                    {
                        m_quickskillid[i] = -1;
                    }
                }
                
                for (int i = 0; i < m_QuickSkillItems.Count; ++i)
                {
                    m_QuickSkillItems[i].SetQuick(m_quickskillid[i]);
                    m_QuickSkillItems[i].SetQuickJiantou(false,false);
                }
            }
            m_select_quick_index = -1;
        }

        /// <summary>
        /// 开始设置快捷技能，初始化设置快捷技能界面信息
        /// </summary>
        private void StartQuick()
        {
            m_ISSetQuick = true;

            for (int i = 0; i < m_learskills.Count; ++i)
            {
                if (null == m_learskills[i] || CheckInQuick(m_learskills[i].Id))
                {
                    mSkillItems[i].SetJiantou(false);
                }
                else
                {
                    mSkillItems[i].SetJiantou(true);
                }
            }

            if (-1 == m_quickskillid[m_select_quick_index])
            {
                for (int i = 0; i < m_QuickSkillItems.Count; ++i)
                {
                    if (i == m_select_quick_index)
                    {
                        m_QuickSkillItems[i].SetQuickJiantou(true, true);
                    }
                    else
                    {
                        m_QuickSkillItems[i].SetQuickJiantou(false, false);
                    }

                }
            }
            else
            {
                for (int i = 0; i < m_QuickSkillItems.Count; ++i)
                {
                    if (i == m_select_quick_index)
                    {
                        m_QuickSkillItems[i].SetQuickJiantou(true, true);
                    }
                    else
                    {
                        m_QuickSkillItems[i].SetQuickJiantou(true, false);
                    }

                }
            }
        }

        /// <summary>
        /// 点击其他位置，取消设置快捷技能
        /// </summary>
        /// <param name="e"></param>
        private void ClickOther(RMetaEvent e = null)
        {
            if (m_ISSetQuick && !m_ISQuickClick)
            {
                EndQuick();                
            }
            m_ISQuickClick = false;
        }

        /// <summary>
        /// 结束设置快捷技能，恢复界面显示
        /// </summary>
        private void EndQuick()
        {
            m_ISSetQuick = false;

            for (int i = 0; i < m_learskills.Count; ++i)
            {
                mSkillItems[i].SetJiantou(false);
            }

            for (int i = 0; i < m_QuickSkillItems.Count; ++i)
            {
                //m_QuickSkillItems[i].SetQuick(m_quickskillid[i]);
                m_QuickSkillItems[i].SetQuickJiantou(false, false);
            }
        }

        /// <summary>
        /// 判断技能是否再快捷技能列表中
        /// </summary>
        /// <param name="skillid"></param>
        /// <returns></returns>
        private bool CheckInQuick(int skillid)
        {
            for (int i = 0; i < m_quickskillid.Length; ++i)
            {
                if (m_quickskillid[i] == skillid)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

