using System.Collections;
using System.Collections.Generic;
using app.db;
using app.human;
using app.net;
using app.role;
using UnityEngine;
using UnityEngine.UI;
using app.tips;
using app.confirm;

namespace app.pet
{
    public class PetLeftInfoScript
    {
        public const string SHOW_PET_UPGRADE_EFFECT = "SHOW_PET_UPGRADE_EFFECT";

        private PetLeftInfoUI UI;

        public List<PetTemplate> petTplList;
        public List<Pet> petList;
        private List<PetItem> petItemList;

        private long currentPetId = 0;

        private RMetaEventHandler clickPetCallBack;
        private RMetaEventHandler clickZujieCallBack;

        private Coroutine mUpdatePetListCoroutine = null;

        private int mSelectedIndex = 0;

        private PetInfoView petinfoview;

        private List<string> tujianDropDownName = new List<string>() { "全部宠物", "普通宠物", "稀有宠物", "神兽宠物", "坐骑" };
        private List<int> tujiantype = new List<int>() { 2, 2, 2, 2, 5 };
        private List<int> tujianpettype = new List<int>() { -1, 0, 1, 2, 0 };
        private bool m_IsCreateTuJian = true;

        public int selectedIndex
        {
            get
            {
                return mSelectedIndex;
            }
        }

        public PetLeftInfoScript(PetLeftInfoUI ui, RMetaEventHandler clickPetCall, RMetaEventHandler clickZujieCall)
        {
            petinfoview = Singleton.GetObj(typeof(PetInfoView)) as PetInfoView;

            UI = ui;
            UI.bianyiToggle.onValueChanged.AddListener(setbianyi);
            clickPetCallBack = clickPetCall;
            clickZujieCallBack = clickZujieCall;
            UI.m_zujieqi.SetClickCallBack(zujieqi);
            UI.m_petczinfo.SetClickCallBack(petczinfo);
            UI.m_pethqinfo.SetClickCallBack(pethqinfo);
            UI.m_petraceinfo.SetClickCallBack(petraceinfo);

            EventCore.addRMetaEventListener(SHOW_PET_UPGRADE_EFFECT, ShowPetUpgradeEffect);
            init();
        }

        private void setbianyi(bool bianyivalue)
        {
            if (null != petinfoview && petinfoview.isTuJian)
            {
                PetTemplate pettpl = PetTemplateDB.Instance.getTemplate((int)currentPetId);
                if (pettpl != null && null != petinfoview.GetAvatarBase() && null != petinfoview.GetAvatarBase().displayModel)//&& !string.IsNullOrEmpty(pettpl.petTransColor)
                {
                    petinfoview.GetAvatarBase().displayModel.SetIsVariant(bianyivalue);
                }
            }
        }

        public long CurrentPetId
        {
            get { return currentPetId; }
        }

        private void init()
        {
            UI.expProgress.LabelType = ProgressBarLabelType.CurrentAndMax;
            UI.petRenameBtn.SetClickCallBack(clickRename);
        }

        private void clickRename()
        {
            ConfirmWnd.Ins.ShowInput("请输入新的宠物名字（4-12个字符）", renameHandler);
        }

        private void renameHandler(RMetaEvent e)
        {
            if (e != null && e.data is string && currentPetId != 0)
            {
                if (PetModel.Ins.IsChongWu)
                {
                    PetCGHandler.sendCGPetChangeName(currentPetId, e.data as string);
                }
                else
                {
                    PetCGHandler.sendCGPetHorseChangeName(currentPetId, e.data as string);
                }
            }
        }

        public Pet getCurrentPet()
        {
            if (currentPetId != 0)
            {
                Pet pet = Human.Instance.PetModel.getPet(currentPetId);
                if (pet != null)
                {
                    return pet;
                }
            }
            return null;
        }

        public void ShowLeft()
        {
            if (!petinfoview.isTuJian)
            {
                //宠物信息
                UI.lefttopObj.transform.localPosition = new Vector3(0, 3, 0);
                UI.tujianTypeDropdown.gameObject.SetActive(false);
                UI.bianyiToggle.gameObject.SetActive(false);
                UI.expProgress.gameObject.SetActive(true);
                UI.petRenameBtn.gameObject.SetActive(true);
            }
            else
            {
                //图鉴
                UI.lefttopObj.transform.localPosition = new Vector3(0, -45, 0);
                UI.tujianTypeDropdown.gameObject.SetActive(true);
                UI.expProgress.gameObject.SetActive(false);
                UI.petRenameBtn.gameObject.SetActive(false);
                UI.isChuzhan.gameObject.SetActive(false);

                ///第一次创建图鉴时设置宠物类型dropdown///
                if (m_IsCreateTuJian)
                {
                    UI.tujianDropDown.onValueChanged.AddListener(DropdownEvent);
                    List<Dropdown.OptionData> listdata = new List<Dropdown.OptionData>();
                    for (int i = 0; i < tujianDropDownName.Count; i++)
                    {
                        listdata.Add(new Dropdown.OptionData(tujianDropDownName[i]));
                    }
                    UI.tujianDropDown.options = listdata;
                    m_IsCreateTuJian = false;
                }

                UI.tujianDropDown.value = 0;
                //神兽不能变异
                //UI.bianyiToggle.gameObject.SetActive(pet.getTpl().petpetTypeId != 2);

                petTplList = PetTemplateDB.Instance.getTuJianPetTplList(
                    tujiantype[UI.tujianDropDown.value], tujianpettype[UI.tujianDropDown.value]);

            }

            UpdateList();
        }

        /// <summary>
        /// 更新宠物列表
        /// </summary>
        public void UpdateList()
        {
            if (mUpdatePetListCoroutine != null)
            {
                UI.StopCoroutine(mUpdatePetListCoroutine);
                mUpdatePetListCoroutine = null;
            }
            ///重新获得自己的宠物列表，因为增加、删除等修改///
            if (PetModel.Ins.IsChongWu)
            {
                petList = Human.Instance.PetModel.getPetListByType(PetType.PET, true);
            }
            else
            {
                petList = Human.Instance.PetModel.getPetListByType(PetType.PET_FOR_RIDE, true);
            }
            if (UI.isActiveAndEnabled)
            {
                mUpdatePetListCoroutine = UI.StartCoroutine(UpdatePetList());
            }
            else
            {
                UpdatePetList();
            }
        }

        /// <summary>
        /// 图鉴分类选择
        /// </summary>
        /// <param name="selectTab"></param>
        private void DropdownEvent(int selectTab)
        {
            petTplList = PetTemplateDB.Instance.getTuJianPetTplList(
                    tujiantype[selectTab], tujianpettype[selectTab]);

            mSelectedIndex = -1;
            if (petTplList.Count > 0)
            {
                mSelectedIndex = 0;
            }

            if (mUpdatePetListCoroutine != null)
            {
                UI.StopCoroutine(mUpdatePetListCoroutine);
                mUpdatePetListCoroutine = null;
            }
            mUpdatePetListCoroutine = UI.StartCoroutine(UpdatePetList());
        }

        /// <summary>
        /// 具体更新宠物显示列表
        /// </summary>
        /// <returns></returns>
        private IEnumerator UpdatePetList()
        {
            int petListCount = 0;
            if (!petinfoview.isTuJian)
            {
                petListCount = petList.Count;
            }
            else
            {
                //图鉴
                petListCount = petTplList.Count;
            }
            if (petItemList == null)
            {
                petItemList = new List<PetItem>();
            }
            //bool hasChuZhan = false;
            UI.petListTBG.ClearToggleList();
            UI.petListTBG.TabChangeHandler = clickItemHandler;
            UI.defaultPetItem.gameObject.SetActive(false);

            UI.petListGrid.transform.localPosition = Vector3.zero;

            for (int i = 0; i < petListCount; i++)
            {
                PetItem petItem;
                if (i < petItemList.Count)
                {
                    petItem = petItemList[i];
                    //petItem.setEmpty();
                }
                else
                {
                    CommonItemUI bagitem = GameObject.Instantiate(UI.defaultPetItem);
                    bagitem.gameObject.transform.SetParent(UI.petListGrid.transform);
                    bagitem.gameObject.transform.localScale = Vector3.one;
                    bagitem.ScrollRect = UI.petListGrid.transform.parent.GetComponent<ScrollRect>();
                    petItem = new PetItem(bagitem);
                    petItemList.Add(petItem);
                }
                petItem.UI.gameObject.SetActive(true);
                UI.petListTBG.AddToggle(petItem.UI.SelectedToggle);
                if (!petinfoview.isTuJian)
                {
                    petItem.setData(petList[i]);
                }
                else
                {
                    petItem.setTplData(petTplList[i]);
                }
                petItem.UI.transform.SetSiblingIndex(i);
                //if (pet==null&&petList[i].IsPetOnFight())
                /*
                if (pet == null && petList[i].isOnFight)
                {
                    //当前无选中的，则选择正在出战的宠物
                    hasChuZhan = true;
                    mSelectedIndex = i;
                }
                if (pet != null && pet.Id == petList[i].Id)
                {
                    //当前有选中的，刷新当前宠物
                    mSelectedIndex = i;
                }
                */

                if (0 == i)
                {
                    mSelectedIndex = 0;
                    UI.petListTBG.SetIndexWithCallBack(mSelectedIndex);

                }
                yield return 0;
            }
            
            for (int i = petListCount; i < petItemList.Count; i++)
            {
                //删除多余的
                petItemList[i].setEmpty();
                petItemList[i].Dispose();
            }
            //if (petItemList.Count > petListCount)
            //{
            //    petItemList.RemoveRange(petListCount, petItemList.Count - petListCount);
            //}
            /*
            if (pet == null && !hasChuZhan && petListCount > 0)
            {
                //当前无选中，也没有出战的宠物，默认选择第一个
                mSelectedIndex = 0;
            }
            */

            if (petListCount == 0)
            {
                setEmpty();
                UI.petListTBG.UnSelectAll();
            }
            mUpdatePetListCoroutine = null;
        }

        /// <summary>
        /// 点击宠物或图鉴
        /// </summary>
        /// <param name="index"></param>
        private void clickItemHandler(int index)
        {
            if (!petinfoview.isTuJian)
            {
                Pet pet = petList[index];
                ClientLog.Log("点击pet了！" + pet.Id);
                currentPetId = pet.Id;
                mSelectedIndex = index;
                updateInfo(pet);
            }
            else
            {
                PetTemplate pettpl = petTplList[index];
                ClientLog.Log("点击pet了！" + pettpl.Id);
                currentPetId = pettpl.Id;
                updateInfo(pettpl);
            }
            if (clickPetCallBack != null)
            {
                clickPetCallBack(new RMetaEvent("clickpetitem", null));
            }
        }

        private void setEmpty()
        {
            currentPetId = 0;
            UI.levelText.text = "";
            UI.petname.text = "没宠物快去抓";
            UI.expProgress.Percent = 0.1f;
            UI.expProgress.Percent = 0;

            if (clickPetCallBack != null)
            {
                clickPetCallBack(new RMetaEvent("clickpetitem", null));
            }
        }

        public void UpdateSelectInfo()
        {
            UI.petListTBG.SetIndexWithCallBack(mSelectedIndex);
        }

        /// <summary>
        /// 更新选择的宠物信息
        /// </summary>
        /// <param name="pet"></param>
        private void updateInfo(Pet pet)
        {
            UI.levelText.text = "Lv." + pet.getLevel();
            UI.petname.text = pet.getName();

            ///变异，成长率
            PetQuality petQuality = PetQuality.NONE;
            if (PetModel.Ins.IsChongWu)
            {
                UI.m_zujieqi.gameObject.SetActive(false);
                UI.bianyi.SetActive(pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.GENE_TYPE) == 1);
                petQuality = (PetQuality)(pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.GROWTH_COLOR));
            }
            else
            {
                UI.bianyi.SetActive(pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.PET_HORSE_GENE_TYPE) == 1);
                petQuality = (PetQuality)(pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.PET_HORSE_GROWTH_COLOR));
                if (pet.getTpl().leasehold > 0)
                {
                    UI.m_zujieqi.gameObject.SetActive(true);
                }
                else
                {
                    UI.m_zujieqi.gameObject.SetActive(false);
                }
            }

            if (petinfoview.isTuJian)
            {
                petQuality = PetQuality.NONE;
                UI.m_petczinfo.gameObject.SetActive(false);
            }
            else
            {
                UI.m_petczinfo.gameObject.SetActive(true);
            }
            UI.putong.SetActive(petQuality == PetQuality.PUTONG);
            UI.youxiu.SetActive(petQuality == PetQuality.YOUXIU);
            UI.jiechu.SetActive(petQuality == PetQuality.JIECHU);
            UI.zhuoyue.SetActive(petQuality == PetQuality.ZHUOYUE);
            UI.chaofan.SetActive(petQuality == PetQuality.CHAOFAN);
            UI.wanmei.SetActive(petQuality == PetQuality.WANMEI);

            updatePetType(pet.getTpl());
            //绑定状态
            int bind = pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.PET_BIND);
            if (bind == 0)
            {
                //绑定
                UI.bindtag.gameObject.SetActive(true);
                UI.nobindtag.gameObject.SetActive(false);
            }
            else if (bind == 1)
            {
                //非绑定
                UI.bindtag.gameObject.SetActive(false);
                UI.nobindtag.gameObject.SetActive(true);
            }
            else
            {
                UI.bindtag.gameObject.SetActive(false);
                UI.nobindtag.gameObject.SetActive(false);
            }

            //出战
            //if (pet.IsPetOnFight())
            if (pet.isOnFight)
            {
                if (PetModel.Ins.IsChongWu)
                {
                    UI.isChuzhan.gameObject.SetActive(true);
                    UI.isQiCheng.gameObject.SetActive(false);
                }
                else
                {
                    UI.isChuzhan.gameObject.SetActive(false);
                    UI.isQiCheng.gameObject.SetActive(true);
                }
            }
            else
            {
                UI.isChuzhan.gameObject.SetActive(false);
                UI.isQiCheng.gameObject.SetActive(false);
            }
            if (petinfoview.isTuJian)
            {
                //图鉴
                UI.isChuzhan.gameObject.SetActive(false);
            }
            //EXP
            UI.expProgress.setLongPercent(pet.getExpLimit(), pet.getExp());
        }

        /// <summary>
        /// 更新选择的宠物图鉴信息
        /// </summary>
        /// <param name="pet"></param>
        private void updateInfo(PetTemplate pet)
        {
            UI.levelText.text = "";
            UI.petname.text = pet.name;

            UI.bianyi.SetActive(false);
            UI.bianyiToggle.gameObject.SetActive(pet.typeId == 2 && pet.petpetTypeId != 2);
            // && !string.IsNullOrEmpty(pet.petTransColor)
            UI.bianyiToggle.isOn = false;

            PetQuality petQuality = PetQuality.NONE;
            //if (petinfoview.isTuJian)
            //{
            //    petQuality = PetQuality.NONE;
            //}
            UI.m_petczinfo.gameObject.SetActive(false);
            UI.putong.SetActive(petQuality == PetQuality.PUTONG);
            UI.youxiu.SetActive(petQuality == PetQuality.YOUXIU);
            UI.jiechu.SetActive(petQuality == PetQuality.JIECHU);
            UI.zhuoyue.SetActive(petQuality == PetQuality.ZHUOYUE);
            UI.chaofan.SetActive(petQuality == PetQuality.CHAOFAN);
            UI.wanmei.SetActive(petQuality == PetQuality.WANMEI);

            updatePetType(pet);
            //绑定状态
            UI.bindtag.gameObject.SetActive(false);
            UI.nobindtag.gameObject.SetActive(false);
            
            //出战
            if (petinfoview.isTuJian)
            {
                //图鉴
                UI.isChuzhan.gameObject.SetActive(false);
            }
            //EXP
            UI.expProgress.gameObject.SetActive(false);
        }

        private void updatePetType(PetTemplate pet)
        {
            int pettype = pet.petpetTypeId;
            //if (UI.pettype1 == null) return;
            UI.pettype1_xiyou.SetActive(false);
            UI.pettype1_shenshou.SetActive(false);
            switch (pettype)
            {
                //case 0:
                //UI.pettype1.gameObject.SetActive(false);
                //break;
                case 1:
                    //PathUtil.Ins.SetRawImageSource(UI.pettype1, "xiyou", "pet/");
                    //UI.pettype1.gameObject.SetActive(true);
                    UI.m_pethqinfo.gameObject.SetActive(true);
                    UI.pettype1_xiyou.SetActive(true);
                    break;
                case 2:
                    //PathUtil.Ins.SetRawImageSource(UI.pettype1, "shenshou", "pet/");
                    //UI.pettype1.gameObject.SetActive(true);
                    UI.m_pethqinfo.gameObject.SetActive(true);
                    UI.pettype1_shenshou.SetActive(true);
                    break;
                default:
                    UI.m_pethqinfo.gameObject.SetActive(false);
                    break;

            }

            if (PetModel.Ins.IsChongWu)
            {
                UI.m_petraceinfo.gameObject.SetActive(true);
                for (int i = 0; i < UI.m_petraces.Length; ++i)
                {
                    if (pet.petpetKindId == i + 1)
                    {
                        UI.m_petraces[i].gameObject.SetActive(true);
                    }
                    else
                    {
                        UI.m_petraces[i].gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                UI.m_petraceinfo.gameObject.SetActive(false);
                for (int i = 0; i < UI.m_petraces.Length; ++i)
                {
                    UI.m_petraces[i].gameObject.SetActive(false);
                }
            }
        }

        private void ShowPetUpgradeEffect(RMetaEvent e)
        {
            if (UI.shengjiEffect == null)
            {
                UI.shengjiEffect = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(PathUtil.Ins.uiEffectsPath, "shengji_chongwu"));
                UI.shengjiEffect.SetActive(false);
                UI.shengjiEffect.transform.SetParent(UI.effectContainer.transform);
                UI.shengjiEffect.transform.localPosition = new Vector3(0, 0, 0);
                UI.shengjiEffect.transform.localScale = Vector3.Scale(UI.shengjiEffect.transform.localScale, new Vector3(0.01f, 0.01f, 0.01f));
                GameObjectUtil.SetLayer(UI.shengjiEffect, UI.gameObject.layer);
            }
            else
            {
                UI.shengjiEffect.SetActive(false);
            }
            UI.shengjiEffect.SetActive(true);
        }

        private void zujieqi()
        {
            if (null != clickZujieCallBack)
            {
                clickZujieCallBack(null);
            }
        }

        private void petczinfo()
        {
            PopInfoScrollWnd.Ins.ShowInfo(LangConstant.PET_CZ_INFO, LangConstant.PET_CZ_TITIE);
        }

        private void pethqinfo()
        {
            PopInfoScrollWnd.Ins.ShowInfo(LangConstant.PET_HQ_INFO, LangConstant.PET_HQ_TITLE);
        }

        private void petraceinfo()
        {
            PopInfoScrollWnd.Ins.ShowInfo(LangConstant.PET_RACE_INFO, LangConstant.PET_RACE_TITLE);
        }

        public void Destroy()
        {
            EventCore.removeRMetaEventListener(SHOW_PET_UPGRADE_EFFECT, ShowPetUpgradeEffect);
            GameObject.DestroyImmediate(UI.gameObject, true);
            UI = null;
        }

        public void UpdatePetInfoInBattle()
        {
            
        }
    }
}