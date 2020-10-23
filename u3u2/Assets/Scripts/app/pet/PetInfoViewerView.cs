using System;
using System.Collections.Generic;
using System.Collections;
using app.db;
using app.net;
using app.role;
using app.utils;
using UnityEngine;
using UnityEngine.UI;
using app.tips;
using minijson;

namespace app.pet
{

    /// <summary>
    /// 宠物信息查看界面
    /// </summary>
    public class PetInfoViewerView : BaseWnd
    {
        private static PetInfoViewerView _ins;

        //[Inject(ui = "PetInfoViewerUI")]
        //public GameObject ui;
        //总UI
        public PetInfoViewerUI UI;

        public PetLeftViwerUI leftInfoUI;

        public PetRightViwerUI rightInfoUI;

        private Pet pet;
        private TradeInfo tradeInfo;
        private CPetInfo petInfo;
        private PetTemplate petTemplate;
        private ShopPetInfo shopPetInfo;
        /// <summary>
        /// 二级属性的文本
        /// </summary>
        private Text[] propBText;
        /// <summary>
        /// 资质 进度条 列表
        /// </summary>
        private ProgressBar[] zizhiPGList;
        //技能
        private List<PetSkillItem> mSkillItems;

        public static PetInfoViewerView Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = Singleton.GetObj(typeof(PetInfoViewerView)) as PetInfoViewerView;
                }
                return _ins;
            }
        }

        public enum EViewType
        {
            Normal,
            Paimaihang,
            CheckInfo,
        }
        public EViewType mCurViewType = EViewType.Normal;
        /*
        public override void initUILayer(WndType uilayer = WndType.FirstWND)
        {
            base.initUILayer(WndType.PopWND);
        }
        */
        
        public PetInfoViewerView()
        {
            uiName = "PetInfoViewerUI";
        }
        
        public override void initWnd()
        {
            base.initWnd();
            UI = ui.AddComponent<PetInfoViewerUI>();
            UI.Init();
            leftInfoUI = UI.petInfoLeft.AddComponent<PetLeftViwerUI>();
            leftInfoUI.Init();
            rightInfoUI = UI.petInfoRight.AddComponent<PetRightViwerUI>();
            rightInfoUI.Init();

            UI.closeBtn.SetClickCallBack(closewnd);
            rightInfoUI.defaultSkillItem.gameObject.SetActive(false);
            propBText = rightInfoUI.petPropGrid.GetComponentsInChildren<Text>();
        }

        private void closewnd()
        {
            hide();
        }

        public void showWithData(Pet petv)
        {
            setData(petv);
        }

        public void showWithData(TradeInfo tradeinfo)
        {
            setShopInfo(tradeinfo);
        }

        private void setData(Pet petv)
        {
            pet = petv;
            tradeInfo = null;
            petTemplate = pet.getTpl();
            petInfo = (CPetInfo)pet.PetInfo;
        }

        private void setShopInfo(TradeInfo tradeinfo)
        {
            mCurViewType = EViewType.Paimaihang;
            tradeInfo = tradeinfo;
            pet = null;
            petInfo = PaiMaiHangItemScript.CreatePetInfo(tradeinfo.commodityJson);
            shopPetInfo = PaiMaiHangItemScript.createShopPetInfo(tradeinfo.commodityJson);
            petTemplate = PetTemplateDB.Instance.getTemplate(petInfo.tplId);

        }
        /// <summary>
        /// 设置查看宠物信息
        /// </summary>
        /// <param name="json"></param>
        public void setViewInfo(string json)
        {
            mCurViewType = EViewType.CheckInfo;
            IDictionary petInfoDic = (IDictionary)Json.Deserialize(json);
            if (petInfo == null)
                petInfo = new CPetInfo();
            if (shopPetInfo == null)
                shopPetInfo = new ShopPetInfo();
            petInfo.petName = JsonHelper.GetStringData(ItemDefine.PetInfoPropKey.name, petInfoDic);
            petInfo.petId = JsonHelper.GetLongData(ItemDefine.PetInfoPropKey.petId, petInfoDic);
            petInfo.tplId = JsonHelper.GetIntData(ItemDefine.PetInfoPropKey.tempId, petInfoDic);
            petInfo.level = JsonHelper.GetIntData(ItemDefine.PetInfoPropKey.level, petInfoDic);
            petInfo.petType = JsonHelper.GetIntData(ItemDefine.PetInfoPropKey.typeId, petInfoDic);
            petInfo.petScore = JsonHelper.GetIntData(ItemDefine.PetInfoPropKey.score, petInfoDic);
            petInfo.fightPower = JsonHelper.GetIntData(ItemDefine.PetInfoPropKey.fightPower, petInfoDic);
            petInfo.colorId = JsonHelper.GetIntData(ItemDefine.PetInfoPropKey.growthColor, petInfoDic);
            petInfo.gene = JsonHelper.GetIntData(ItemDefine.PetInfoPropKey.gene, petInfoDic);
            petInfo.perceptLevel = JsonHelper.GetIntData(ItemDefine.PetInfoPropKey.perceptLevel, petInfoDic);
            //petInfo.life = JsonHelper.GetIntData()
            if (petInfoDic.Contains(PaiMaiHangTradeInfoKeyDef.skillMap))
            {
                IList skillListstr = JsonHelper.GetListData(PaiMaiHangTradeInfoKeyDef.skillMap, petInfoDic);
                petInfo.skillList = new PetSkillInfo[skillListstr.Count];
                for (int i = 0; i < skillListstr.Count; i++)
                {
                    PetSkillInfo tmpSkillInfo = new PetSkillInfo();
                    tmpSkillInfo.skillId = JsonHelper.GetIntData("1", (IDictionary)skillListstr[i]);
                    tmpSkillInfo.level = JsonHelper.GetIntData("2", (IDictionary)skillListstr[i]);
                    petInfo.skillList[i] = tmpSkillInfo;
                }
            }
            ///** 一级属性附加值 */
            //if (petInfoDic.Contains(PaiMaiHangTradeInfoKeyDef.aProp))
            //{
            //    shopPetInfo.aprop = JsonHelper.GetDictData(PaiMaiHangTradeInfoKeyDef.aProp, petInfoDic);
            //}
            ///** 装备位星级 */
            //petinfo.aEquipStar;
            ///** 宠物培养增加属性 */
            if (petInfoDic.Contains(ItemDefine.PetInfoPropKey.propBMap))
            {
                shopPetInfo.bprop = JsonHelper.GetDictData(ItemDefine.PetInfoPropKey.propBMap, petInfoDic);
                if (shopPetInfo.bprop.Contains(PetBProperty.LIFE.ToString()))
                {
                    petInfo.life = Convert.ToInt32(shopPetInfo.bprop[PetBProperty.LIFE.ToString()]);
                }

            }
            //一级属性附加值
            if (petInfoDic.Contains(ItemDefine.PetInfoPropKey.apropAdd))
            {
                shopPetInfo.aPropAddMap = JsonHelper.GetDictData(ItemDefine.PetInfoPropKey.apropAdd, petInfoDic);
            }
            petTemplate = PetTemplateDB.Instance.getTemplate(petInfo.tplId);
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            UI.Show();
            updateBaseInfo();
            updateBaseProp();
            updateZiZhiSkill();
        }

        private void updateBaseInfo()
        {
            leftInfoUI.levelText.text = "Lv." + petInfo.level;
            leftInfoUI.scoreText.text = petInfo.petScore.ToString(); //petInfo.petScore.ToString();
            //宝宝
            int geneType = 0;
            //if (pet != null)
            //{
            //    geneType = pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.GENE_TYPE);
            //}
            //else
            //{
            //    //拍卖行
            //    geneType = PaiMaiHangItemScript.GetItemIntPropValue(tradeInfo.commodityJson, PaiMaiHangTradeInfoKeyDef.geneType);
            //}
            switch (mCurViewType)
            {

                case EViewType.Normal:
                    geneType = pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.GENE_TYPE);
                    break;
                case EViewType.Paimaihang:
                    geneType = PaiMaiHangItemScript.GetItemIntPropValue(tradeInfo.commodityJson, PaiMaiHangTradeInfoKeyDef.geneType);
                    break;
                case EViewType.CheckInfo:
                    geneType = petInfo.gene;
                    break;
            }
            leftInfoUI.bianyi.SetActive(geneType == 1);
            /*
            if (geneType == 1)
            {
                //leftInfoUI.baobaoImage.gameObject.SetActive(false);
                leftInfoUI.bianyi.SetActive(true);
            }
            else
            {
                //leftInfoUI.baobaoImage.gameObject.SetActive(true);
                leftInfoUI.bianyi.SetActive(false);
            }
            */
            if (pet != null)
            {
                PetQuality petQuality =
                    (PetQuality)(pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.GROWTH_COLOR));
                leftInfoUI.putong.SetActive(petQuality == PetQuality.PUTONG);
                leftInfoUI.youxiu.SetActive(petQuality == PetQuality.YOUXIU);
                leftInfoUI.jiechu.SetActive(petQuality == PetQuality.JIECHU);
                leftInfoUI.zhuoyue.SetActive(petQuality == PetQuality.ZHUOYUE);
                leftInfoUI.chaofan.SetActive(petQuality == PetQuality.CHAOFAN);
                leftInfoUI.wanmei.SetActive(petQuality == PetQuality.WANMEI);

                //添加宠物模型
                AddPetModelToUI(Vector3.zero, Vector3.zero, Vector3.one, pet, leftInfoUI.modelContainer);
            }
            else if (petTemplate != null)
            {
                leftInfoUI.putong.SetActive(false);
                leftInfoUI.youxiu.SetActive(false);
                leftInfoUI.jiechu.SetActive(false);
                leftInfoUI.zhuoyue.SetActive(false);
                leftInfoUI.chaofan.SetActive(false);
                leftInfoUI.wanmei.SetActive(false);
                //ClearModelData();
                AddAvatarModelToUI(Vector3.zero, Vector3.zero, Vector3.one, petTemplate.modelId, leftInfoUI.modelContainer,null, (geneType == 1 && petTemplate.petpetTypeId != 2));
            }
            
            updatePetType();

            //EXP
            //leftInfoUI.expProgress.gameObject.SetActive(false);
            //leftInfoUI.expProgress.setLongPercent(pet.getExpLimit(), pet.getExp());
        }

        private void updatePetType()
        {
            int pettype = petTemplate.petpetTypeId;
            //if (leftInfoUI.pettype1 == null) return;
            leftInfoUI.pettype1_xiyou.SetActive(false);
            leftInfoUI.pettype1_shenshou.SetActive(false);
            switch (pettype)
            {
                case 1:
                    leftInfoUI.pettype1_xiyou.SetActive(true);
                    break;
                case 2:
                    leftInfoUI.pettype1_shenshou.SetActive(true);
                    break;

            }

        }

        private void updateBaseProp()
        {
            //成长率
            int petGroupthColor = 0;
            //if (pet != null)
            //{
            //    petGroupthColor = pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.GROWTH_COLOR);
            //}
            //else
            //{
            //    petGroupthColor = PaiMaiHangItemScript.GetItemIntPropValue(tradeInfo.commodityJson,
            //        PaiMaiHangTradeInfoKeyDef.growthColor);
            //}
            switch (mCurViewType)
            {

                case EViewType.Normal:
                    petGroupthColor = pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.GROWTH_COLOR);
                    break;
                case EViewType.Paimaihang:
                    petGroupthColor = PaiMaiHangItemScript.GetItemIntPropValue(tradeInfo.commodityJson,
                    PaiMaiHangTradeInfoKeyDef.growthColor);
                    break;
                case EViewType.CheckInfo:
                    petGroupthColor = petInfo.colorId;
                    break;
            }
            if (petGroupthColor > 0)
            {
                PetGrowthTemplate pgt = PetGrowthTemplateDB.Instance.getTemplate(petGroupthColor);
                rightInfoUI.chengzhanglvName.text = ColorUtil.getColorText(petGroupthColor, pgt.name); // pgt.name;
                rightInfoUI.chengzhanglvValue.text = (pgt.add / ClientConstantDef.PET_DIV_BASE) * 100 + "%";
            }
            //悟性
            int wuxingLv = 0;
            //if (pet != null)
            //{
            //    wuxingLv = pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.PERCEPT_LEVEL);
            //}
            //else
            //{
            //    wuxingLv = PaiMaiHangItemScript.GetItemIntPropValue(tradeInfo.commodityJson,
            //        PaiMaiHangTradeInfoKeyDef.perceptLevel);
            //}

            switch (mCurViewType)
            {

                case EViewType.Normal:
                    wuxingLv = pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.PERCEPT_LEVEL);
                    break;
                case EViewType.Paimaihang:
                    wuxingLv = PaiMaiHangItemScript.GetItemIntPropValue(tradeInfo.commodityJson,
                    PaiMaiHangTradeInfoKeyDef.perceptLevel);
                    break;
                case EViewType.CheckInfo:
                    wuxingLv = petInfo.perceptLevel;
                    break;
            }
            if (wuxingLv == 0)
            {
                rightInfoUI.wuxingValue.gameObject.SetActive(false);
                rightInfoUI.wuxingLevel.text = "未开启";
            }
            else
            {
                if (!rightInfoUI.wuxingValue.gameObject.activeSelf)
                {
                    rightInfoUI.wuxingValue.gameObject.SetActive(true);
                }
                PetPerceptLevelTemplate curLevelTpl = PetPerceptLevelTemplateDB.Instance.getTemplate(wuxingLv);
                rightInfoUI.wuxingLevel.text = StringUtil.Assemble(LangConstant.LEVEL, new string[1] { wuxingLv.ToString() });
                rightInfoUI.wuxingValue.text = ColorUtil.getColorText(ColorUtil.GREEN, (curLevelTpl.addtionAttr / ClientConstantDef.PET_DIV_BASE) * 100 + "%");
            }
            //寿命
            int shouming = 0;
            //if (pet != null)
            //{
            //    shouming = (pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.LIFE));
            //}
            //else
            //{
            //    shouming = PaiMaiHangItemScript.GetItemIntPropValue(tradeInfo.commodityJson,
            //        PaiMaiHangTradeInfoKeyDef.life);
            //}
            rightInfoUI.shoumingPG.gameObject.SetActive(true);
            switch (mCurViewType)
            {

                case EViewType.Normal:
                    shouming = (pet.life);
                    break;
                case EViewType.Paimaihang:
                    shouming = PaiMaiHangItemScript.GetItemIntPropValue(tradeInfo.commodityJson,
                    PaiMaiHangTradeInfoKeyDef.life);
                    break;
                case EViewType.CheckInfo:
                    rightInfoUI.shoumingPG.gameObject.SetActive(false);
                    shouming = petInfo.life;
                    break;
            }
            //TODO::
            rightInfoUI.shoumingPG.MaxValue = 10000;
            rightInfoUI.shoumingPG.Value = shouming;
            //属性
            List<int> list = PetDef.GetPetBSmallPropKeyListByJobType(petTemplate.attackTypeId);
            for (int i = 0; i < propBText.Length; i++)
            {
                if (list[i] == PetBProperty.LIFE)
                {
                    propBText[i].text = LangConstant.getPetPropertyName(list[i]) + " : "
                                        + ColorUtil.getColorText(ColorUtil.WHITE_ID, shouming.ToString());
                }
                else
                {
                    if (pet != null)
                    {
                        propBText[i].text = LangConstant.getPetPropertyName(list[i]) + " : "
                            + ColorUtil.getColorText(ColorUtil.WHITE_ID, pet.PropertyManager.getPetIntProp(list[i]).ToString());
                    }
                    else
                    {
                        propBText[i].text = LangConstant.getPetPropertyName(list[i]) + " : "
                            + ColorUtil.getColorText(ColorUtil.WHITE_ID, JsonHelper.GetIntData(list[i].ToString(), shopPetInfo.bprop).ToString());
                    }
                }
            }
        }

        private void updateZiZhiSkill()
        {
            //资质
            if (zizhiPGList == null)
            {
                zizhiPGList = new ProgressBar[rightInfoUI.zizhiPgGrid.transform.childCount];
                for (int i = 0; i < rightInfoUI.zizhiPgGrid.transform.childCount; i++)
                {
                    zizhiPGList[i] = rightInfoUI.zizhiPgGrid.transform.GetChild(i).GetComponent<ProgressBar>();
                    zizhiPGList[i].LabelType = ProgressBarLabelType.CurrentAndMax;
                }
                //zizhiPGList = rightInfoUI.zizhiPgGrid.GetComponentsInChildren<ProgressBar>();
                //for (int i = 0; i < zizhiPGList.Length; i++)
                //{
                //    zizhiPGList[i].LabelType = ProgressBarLabelType.CurrentAndMax;
                //}
            }
            if (pet == null)
            {
                zizhiPGList[0].MaxValue = petTemplate.strengthGrowth + petTemplate.randGrowth;
                zizhiPGList[0].Value = petTemplate.strengthGrowth + JsonHelper.GetIntData(PetAProperty.STRENGTH_GROWTH.ToString(), shopPetInfo.aPropAddMap);



                zizhiPGList[1].MaxValue = petTemplate.agilityGrowth + petTemplate.randGrowth;
                zizhiPGList[1].Value = petTemplate.agilityGrowth + JsonHelper.GetIntData(PetAProperty.AGILITY_GROWTH.ToString(), shopPetInfo.aPropAddMap);

                zizhiPGList[2].MaxValue = petTemplate.intellectGrowth + petTemplate.randGrowth;
                zizhiPGList[2].Value = petTemplate.intellectGrowth + JsonHelper.GetIntData(PetAProperty.INTELLECT_GROWTH.ToString(), shopPetInfo.aPropAddMap);

                zizhiPGList[3].MaxValue = petTemplate.faithGrowth + petTemplate.randGrowth;
                zizhiPGList[3].Value = petTemplate.faithGrowth + JsonHelper.GetIntData(PetAProperty.FAITH_GROWTH.ToString(), shopPetInfo.aPropAddMap);

                zizhiPGList[4].MaxValue = petTemplate.staminaGrowth + petTemplate.randGrowth;
                zizhiPGList[4].Value = petTemplate.staminaGrowth + JsonHelper.GetIntData(PetAProperty.STAMINA_GROWTH.ToString(), shopPetInfo.aPropAddMap);
            }
            else
            {
                zizhiPGList[0].MaxValue = petTemplate.strengthGrowth + petTemplate.randGrowth;
                zizhiPGList[0].Value = petTemplate.strengthGrowth + pet.PetInfo.aPropAddArr[5];

                zizhiPGList[1].MaxValue = petTemplate.agilityGrowth + petTemplate.randGrowth;
                zizhiPGList[1].Value = petTemplate.agilityGrowth + pet.PetInfo.aPropAddArr[6];

                zizhiPGList[2].MaxValue = petTemplate.intellectGrowth + petTemplate.randGrowth;
                zizhiPGList[2].Value = petTemplate.intellectGrowth + pet.PetInfo.aPropAddArr[7];

                zizhiPGList[3].MaxValue = petTemplate.faithGrowth + petTemplate.randGrowth;
                zizhiPGList[3].Value = petTemplate.faithGrowth + pet.PetInfo.aPropAddArr[8];

                zizhiPGList[4].MaxValue = petTemplate.staminaGrowth + petTemplate.randGrowth;
                zizhiPGList[4].Value = petTemplate.staminaGrowth + pet.PetInfo.aPropAddArr[9];
            }

            if (mSkillItems == null) mSkillItems = new List<PetSkillItem>();
            int len = petInfo.skillList.Length;
            int index = 0;
            for (int i = 0; i < len; i++)
            {
                //SkillTemplate skillTpl = SkillTemplateDB.Instance.getTemplate(petInfo.skillList[i].skillId);
                //if (skillTpl != null)
                //{
                if (index >= mSkillItems.Count)
                {
                    CommonItemUI go = GameObject.Instantiate(rightInfoUI.defaultSkillItem);
                    go.gameObject.SetActive(true);
                    PetSkillItem item = new PetSkillItem(go, clickSkillItem);
                    go.transform.SetParent(rightInfoUI.skillGrid.transform);
                    go.gameObject.transform.localScale = Vector3.one;
                    mSkillItems.Add(item);
                }
                mSkillItems[index].UI.gameObject.SetActive(true);
                mSkillItems[index].setEmpty();
                mSkillItems[index].SetData(petInfo.skillList[i]);
                index++;
                //
            }
            for (int i = len; i < mSkillItems.Count; i++)
            {
                mSkillItems[i].UI.gameObject.SetActive(false);
                mSkillItems[i].setEmpty();
            }
        }

        private void clickSkillItem(object obj)
        {
            if (obj is PetSkillInfo)
            {
                PetSkillInfo skillInfo = obj as PetSkillInfo;
                SkillTips.ins.ShowTips(skillInfo);
            }
            else if (obj is PetTemplate)
            {
                SkillTemplate skilltpl = obj as SkillTemplate;
                SkillTips.ins.ShowTips(skilltpl);
            }
        }
        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            UI.Hide();
            //RemoveAvatarModel();
        }
        
        public override void Destroy()
        {
            _ins = null;
            base.Destroy();
            UI = null;
        }
    }

    public class CPetInfo : PetInfo
    {
        public int gene;
        public int perceptLevel;
        public string petName;
        public int fightPower;
        public int life;
        public bool isUpdate = false;
    }

}
