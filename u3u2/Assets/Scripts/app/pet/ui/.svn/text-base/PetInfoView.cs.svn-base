using app.bag;
using app.db;
using app.item;
using app.model;
using app.tips;
using app.utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using app.human;
using app.net;
using app.main;
using app.zone;

namespace app.pet
{
    public class PetInfoView : BaseWnd
    {
        //[Inject(ui = "PetInfoUI")]
        //public GameObject ui;
        //当前是否选中的图鉴页签，图鉴和宠物信息用的是一套界面资源，通过这个标志做逻辑判断
        public bool isTuJian=false;
        //总UI
        public PetUI UI;

        public PetLeftInfoUI leftInfoUI;
        /// <summary>
        /// 宠物信息逻辑
        /// </summary>
        private PetLeftInfoScript petLeftInfoScript;

        public PetInfoRightUI rightInfoUI;
        /// <summary>
        /// 宠物信息右侧逻辑
        /// </summary>
        public PetInfoRightScript petInfoRightScript;

        public RoleJiaDianUI jiadianUI;

        public PetXichongUI xichongUI;

        public PetHuantongUI huantongUI;
        public PetBianyiUI bianyiUI;
        public PetLianhuaUI lianhuaUI;
        public PetWuxingUI wuxingUI;

        public PetSkillUI skillUI;

        public PetTrainingUI trainingUI;

        /// <summary>
        /// 加点逻辑
        /// </summary>
        private PetJiaDianScript jiadianScript;

        private PetHuantongUIScript petHuantongUIScript;
        private PetBianyiUIScript petBianyiUIScript;
        private PetLianhuaUIScript petLianhuaUIScript;
        private PetWuXingUIScript petWuxingUIScript;

        private PetSkillUIScript petSkillUIScript;

        public PetSkillBooksUI skillBooksUI;
        private PetSkillBooksUIScript petSkillBooksUIScript;

        private PetTrainingUIScript petTrainingUIScript;

        private bool isShowingJiaDian = false;

        public PetModel petmodel;
        public BagModel bagModel;
        public FunctionModel functionModel;

        private List<System.Action> OnLoaded;

        private List<CanvasRenderer> mRenderers = new List<CanvasRenderer>();

        private bool m_isclickzujie = false;

        public PetInfoView()
        {
            uiName = "PetInfoUI";
            hasSubUI = true;
        }

        public override void initWnd()
        {
            base.initWnd();

            petmodel = PetModel.Ins;
            petmodel.addChangeEvent(PetModel.UPDATE_PET_INFO, updatePetProp);
            petmodel.addChangeEvent(PetModel.UPDATE_PET_PROP, updatePetProp);
            petmodel.addChangeEvent(PetModel.UPDATE_PET_FIGHT_STATE, updatePetProp);

            petmodel.addChangeEvent(PetModel.UPDATE_PET_LIST, UpdatePetList);
            petmodel.addChangeEvent(PetModel.UPDATE_SERVER_TIME, ShowZujieqi);
            EventCore.addRMetaEventListener(PetLeftInfoScript.SHOW_PET_UPGRADE_EFFECT, learnresult);

            bagModel = BagModel.Ins;
            bagModel.addChangeEvent(BagModel.UPDATE_BAG_EVENT, UpdatePetBookList);
            bagModel.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdatePetBookList);
            

            functionModel = FunctionModel.Ins;

            UI = ui.AddComponent<PetUI>();
            UI.Init();
           
            UI.tabBtnGroup.TabChangeHandler = changeMainTab;

            UI.m_zujieobj.SetActive(false);
            UI.m_zujiecloseBtn.SetClickCallBack(closezujie);
            EventTriggerListener.Get(UI.m_zujiebgclosebtn.gameObject).onClick = ClickCloseBg;
            UI.m_zujieBtn.SetClickCallBack(clickzujie);
            UI.m_zujiecost.ClickCommonItemHandler = zujieitemclick;
        }
        /// <summary>
        /// 选择宠物item
        /// </summary>
        /// <param name="e"></param>
        private void clickPetItem(RMetaEvent e = null)
        {
            Pet pt = petmodel.getPet(petLeftInfoScript.CurrentPetId);

            switch (UI.tabBtnGroup.index)
            {
                case 0:
                    if (pt != null)
                    {
                        petInfoRightScript.clickItemHandler(pt);
                        //添加宠物模型
                        AddPetModelToUI(Vector3.zero, Vector3.zero, Vector3.one, pt, leftInfoUI.modelContainer);
                    }
                    else
                    {
                        petInfoRightScript.setEmpty();
                        hide();
                    }
                    break;
                case 1:
                    if (pt != null)
                    {
                        OnXiChongUITabChanged(xichongUI.tabButtonGroup.index);
                        //添加宠物模型
                        AddPetModelToUI(Vector3.zero, Vector3.zero, Vector3.one, pt, leftInfoUI.modelContainer);
                    }
                    break;
                case 2:
                    if (pt != null)
                    {
                        petSkillUIScript.UpdatePanel(pt.PetInfo);
                        //添加宠物模型
                        AddPetModelToUI(Vector3.zero, Vector3.zero, Vector3.one, pt, leftInfoUI.modelContainer);
                    }
                    else
                    {
                        petSkillUIScript.setEmpty();
                    }
                    break;
                case 3:
                    if (pt != null)
                    {
                        petTrainingUIScript.updatePanel(pt);
                        //添加宠物模型
                        AddPetModelToUI(Vector3.zero, Vector3.zero, Vector3.one, pt, leftInfoUI.modelContainer);
                    }
                    break;
                case 4:
                    PetTemplate petTpl = PetTemplateDB.Instance.getTemplate((int)petLeftInfoScript.CurrentPetId);
                    if (petTpl != null)
                    {
                        petInfoRightScript.clickItemHandler(petTpl);
                        //添加宠物模型
                        AddPetModelToUI(Vector3.zero, Vector3.zero, Vector3.one, petTpl, leftInfoUI.modelContainer);
                    }
                    else
                    {
                        petInfoRightScript.setEmpty();
                        hide();
                    }
                    break;
                default:
                    RemoveAvatarModel();
                    break;
            }
        }

        public void updatePetProp(RMetaEvent e)
        {
            if (!isShown)
            {
                return;
            }
            if (e != null && e.data != null)
            {
                long petId = (long)e.data;
                if (petId != petLeftInfoScript.CurrentPetId)
                {
                    return;
                }
            }

            if (isShowingJiaDian)
            {
                jiadianScript.initAPropDian(petLeftInfoScript.CurrentPetId);
            }
            else
            {
                Pet curPet = petLeftInfoScript.getCurrentPet();
                //根据当前是 哪个页签 去刷新数据
                switch (UI.tabBtnGroup.index)
                {
                    case 0:
                        petLeftInfoScript.UpdateSelectInfo();
                        petInfoRightScript.updateCanZhanORXiuXi();
                        break;
                    case 1:
                        petLeftInfoScript.UpdateSelectInfo();
                        OnXiChongUITabChanged(xichongUI.tabButtonGroup.index, e.type);
                        break;
                    case 2:
                        petLeftInfoScript.UpdateSelectInfo();
                        if (curPet != null)
                        {
                            petSkillUIScript.UpdatePanel(curPet.PetInfo);
                            UpdatePetBookList(null);
                        }
                        break;
                    case 3:
                        petTrainingUIScript.updatePanel(curPet);
                        break;
                    default:
                        break;
                }
            }
        }

        public void UpdatePetList(RMetaEvent e)
        {
            petLeftInfoScript.UpdateList();
        }

        public void UpdatePetBookList(RMetaEvent e)
        {
            if (skillBooksUI != null && skillBooksUI.gameObject.activeSelf)
            {
                petSkillBooksUIScript.UpdatePanel(petLeftInfoScript.getCurrentPet().PetInfo);
            }

            if (UI.tabBtnGroup.index == 2)
            {
                if (skillUI.tabBtnGroup.index == 0 || 2 == skillUI.tabBtnGroup.index)
                {
                    //正在显示天赋技能。
                    petSkillUIScript.UpdateTianfuItemNum();
                }
            }
        }

        /// <summary>
        /// 学习技能书回调
        /// </summary>
        public void learnresult(RMetaEvent e = null)
        {
            if (UI.tabBtnGroup.index == 2)
            {
                if (skillUI.tabBtnGroup.index == 1)
                {
                    //正在显示普通技能。
                    petSkillBooksUIScript.HideUI();
                    //SetChildVisible(skillBooksUI, false);
                    petSkillUIScript.OnSkillBookSelected(null);
                }
            }
        }

        private void clickJiaDian()
        {
            isShowingJiaDian = true;

            SetChildVisible(leftInfoUI, false);
            SetChildVisible(rightInfoUI, false);
            SetChildVisible(skillUI, false);
            SetChildVisible(skillBooksUI, false);
            SetChildVisible(bianyiUI, false);
            SetChildVisible(huantongUI, false);
            SetChildVisible(lianhuaUI, false);
            SetChildVisible(trainingUI, false);
            SetChildVisible(wuxingUI, false);
            SetChildVisible(xichongUI, false);
            
            HideAvatarModel();

            if (UI.petJiadian == null)
            {
                UI.petJiadian = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "Jiadian"));
                UI.petJiadian.transform.SetParent(UI.transform);
                UI.petJiadian.transform.localScale = Vector3.one;
                UI.petJiadian.SetActive(true);
                jiadianUI = UI.petJiadian.AddComponent<RoleJiaDianUI>();
                jiadianUI.Init();
                jiadianUI.JiaDianShuoMing.SetClickCallBack(jiadianshuomingOnClick);
                jiadianScript = new PetJiaDianScript(jiadianUI);
            }
            else
            {
                if (!jiadianUI.visibleParent)
                {
                    jiadianUI.visibleParent = UI.transform;
                }
                jiadianUI.Show();
                if (jiadianScript != null)
                {
                    jiadianScript.show();
                }
                //UI.petJiadian.SetActive(true);
            }

            SetChildVisible(UI.tabBtnGroup.gameObject, false);

            if (petLeftInfoScript.petList != null && petLeftInfoScript.petList.Count > 0 && petLeftInfoScript.selectedIndex >= 0)
            {
                jiadianScript.initAPropDian(petLeftInfoScript.petList[petLeftInfoScript.selectedIndex].Id);
            }
        }

        private void closePanel()
        {
            hide();
        }

        public override void hide(RMetaEvent e = null)
        {
            SetChildVisible(leftInfoUI.shengjiEffect, false);
            if (jiadianScript!=null)
            {
                jiadianScript.hide();
            }
            if (isShowingJiaDian)
            {
                UI.tabBtnGroup.gameObject.SetActive(true);
                changeMainTab(0);
                isShowingJiaDian = false;
            }
            else
            {
                RemoveAvatarModel();
                app.main.GameClient.ins.OnBigWndHidden();
                base.hide(e);
                UI.Hide();
            }
            ClearCanvas();
        }

        private void changeMainTab(int currentTabIndex)
        {
            bool lastIsTuJian = isTuJian;
            isTuJian = false;
            switch (currentTabIndex)
            {
                case 0:
                    if (!UI.petInfoLeft || !UI.petInfoRight)
                    {
                        UI.StartCoroutine(InitLeftInfo(1));
                        UI.StartCoroutine(InitRightInfo(1));

                        //UI.petInfoLeft.transform.SetParent(UI.transform);
                        //UI.petInfoLeft.transform.localScale = Vector3.one;
                        //leftInfoUI = UI.petInfoLeft.AddComponent<PetLeftInfoUI>();
                        //leftInfoUI.Init();
                        //petLeftInfoScript = new PetLeftInfoScript(leftInfoUI, clickPetItem);
                    }
                    else
                    {
                        SetChildVisible(leftInfoUI, true);
                        SetChildVisible(rightInfoUI, true);
                        petLeftInfoScript.ShowLeft();
                    }

                    //UI.petInfoRight.transform.SetParent(UI.transform);
                    //UI.petInfoRight.transform.localScale = Vector3.one;
                    //rightInfoUI = UI.petInfoRight.AddComponent<PetInfoRightUI>();
                    //rightInfoUI.Init();
                    //rightInfoUI.jiadianBtn.SetClickCallBack(clickJiaDian);
                    //petInfoRightScript = new PetInfoRightScript(rightInfoUI);

                    SetChildVisible(jiadianUI, false);
                    SetChildVisible(skillUI, false);
                    SetChildVisible(skillBooksUI, false);
                    SetChildVisible(xichongUI, false);
                    SetChildVisible(wuxingUI, false);
                    SetChildVisible(trainingUI, false);
                    SetChildVisible(lianhuaUI, false);
                    SetChildVisible(bianyiUI, false);
                    SetChildVisible(huantongUI, false);

                    if (PetModel.Ins.IsChongWu)
                    {
                        UI.title.text = LangConstant.PET_INFO;
                    }
                    else
                    {
                        UI.title.text = LangConstant.PET_HORSE_INFO;
                    }

                    //AssetBundleContainer bundleContainer = SourceManager.Ins.GetBundleConainer(uiPath);
                    //bundleContainer.InitAssets(new string[] { "PetInfoUIBianyi", "PetInfoUIHuantong", "PetInfoUIJiadian", "PetInfoUIJineng", "PetInfoUIJinengshu", "PetInfoUILianhua", "PetInfoUIPeiyang", "PetInfoUIWuxing", "PetInfoUIXichong" });
                    //bundleContainer.Unload(false);

                    break;
                case 1:
                    SetChildVisible(leftInfoUI, true);
                    SetChildVisible(rightInfoUI, false);
                    SetChildVisible(jiadianUI, false);
                    SetChildVisible(skillUI, false);
                    SetChildVisible(skillBooksUI, false);
                    SetChildVisible(wuxingUI, false);
                    SetChildVisible(trainingUI, false);
                    SetChildVisible(lianhuaUI, false);
                    SetChildVisible(bianyiUI, false);
                    SetChildVisible(huantongUI, false);

                    if (UI.petXichong == null)
                    {
                        UI.petXichong = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "Xichong"));
                        UI.petXichong.transform.SetParent(UI.transform);
                        UI.petXichong.transform.localScale = Vector3.one;
                        UI.petXichong.gameObject.SetActive(true);
                        xichongUI = UI.petXichong.AddComponent<PetXichongUI>();
                        xichongUI.Init();
                        xichongUI.tabButtonGroup.TabChangeHandler = OnXiChongUITabChangTab;
                    }
                    else
                    {
                        SetChildVisible(xichongUI, true);
                    }

                    if (petLeftInfoScript != null)
                    {
                        if (lastIsTuJian)
                        {
                            petLeftInfoScript.ShowLeft();
                        }
                        if (xichongUI.tabButtonGroup.index != 0)
                        {
                            xichongUI.tabButtonGroup.SetIndexWithCallBack(0);
                        }
                        else
                        {
                            OnXiChongUITabChanged(0);
                        }
                    }
                    
                    functionModel.AddFuncBindObj(FunctionIdDef.WUXING, xichongUI.tabButtonGroup.toggleList[3].gameObject);
                    if (PetModel.Ins.IsChongWu)
                    {
                        UI.title.text = LangConstant.PET_XILIAN;
                    }
                    else
                    {
                        UI.title.text = LangConstant.PET_HORSE_XILIAN;
                    }
                    break;
                case 2:
                    SetChildVisible(leftInfoUI, true);
                    SetChildVisible(rightInfoUI, false);
                    SetChildVisible(jiadianUI, false);
                    SetChildVisible(skillBooksUI, false);
                    SetChildVisible(xichongUI, false);
                    SetChildVisible(wuxingUI, false);
                    SetChildVisible(trainingUI, false);
                    SetChildVisible(lianhuaUI, false);
                    SetChildVisible(bianyiUI, false);
                    SetChildVisible(huantongUI, false);

                    if (UI.petJineng == null)
                    {
                        UI.petJineng = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "Jineng"));
                        UI.petJineng.transform.SetParent(UI.transform);
                        UI.petJineng.transform.localScale = Vector3.one;
                        skillUI = UI.petJineng.AddComponent<PetSkillUI>();
                        skillUI.Init();
                        petSkillUIScript = new PetSkillUIScript(skillUI, OnBookItemClicked, OnSkillUITabChanged);
                    }
                    else
                    {
                        SetChildVisible(skillUI, true);
                    }

                    if (skillUI != null)
                    {
                        GuideManager.Ins.ShowGuide(GuideIdDef.PetTalent, 3, skillUI.xitianfuBtn.gameObject, false,
                            200);
                    }

                    if (PetModel.Ins.IsChongWu)
                    {
                        UI.title.text = LangConstant.PET_SKILL;
                        skillUI.tianfuTxt1.text = skillUI.tianfuTxt1.text.Replace(LangConstant.QI_CHONG, LangConstant.CHONG_WU);
                        skillUI.tianfuTxt4.text = skillUI.tianfuTxt4.text.Replace(LangConstant.QI_CHONG, LangConstant.CHONG_WU);
                        skillUI.tianfuTxt5.text = skillUI.tianfuTxt5.text.Replace(LangConstant.QI_CHONG, LangConstant.CHONG_WU);
                        skillUI.putongTxt3.text = skillUI.putongTxt3.text.Replace(LangConstant.QI_CHONG, LangConstant.CHONG_WU);
                    }
                    else
                    {
                        UI.title.text = LangConstant.PET_HORSE_SKILL;
                        skillUI.tianfuTxt1.text = skillUI.tianfuTxt1.text.Replace(LangConstant.CHONG_WU, LangConstant.QI_CHONG);
                        skillUI.tianfuTxt4.text = skillUI.tianfuTxt4.text.Replace(LangConstant.CHONG_WU, LangConstant.QI_CHONG);
                        skillUI.tianfuTxt5.text = skillUI.tianfuTxt5.text.Replace(LangConstant.CHONG_WU, LangConstant.QI_CHONG);
                        skillUI.putongTxt3.text = skillUI.putongTxt3.text.Replace(LangConstant.CHONG_WU, LangConstant.QI_CHONG);
                    }

                    if (petLeftInfoScript != null)
                    {
                        if (lastIsTuJian)
                        {
                            petLeftInfoScript.ShowLeft();
                        }
                        if (PetModel.Ins.IsChongWu)
                        {
                            skillUI.m_quickobj.SetActive(true);
                            skillUI.m_qichongobj.SetActive(false);
                        }
                        else
                        {
                            skillUI.m_quickobj.SetActive(false);
                            skillUI.m_qichongobj.SetActive(true);
                        }
                        skillUI.tabBtnGroup.SetIndexWithCallBack(0);
                        clickPetItem();
                    }
                    
                    break;
                case 3:
                    SetChildVisible(leftInfoUI, true);
                    SetChildVisible(rightInfoUI, false);
                    SetChildVisible(jiadianUI, false);
                    SetChildVisible(skillUI, false);
                    SetChildVisible(skillBooksUI, false);
                    SetChildVisible(xichongUI, false);
                    SetChildVisible(wuxingUI, false);
                    SetChildVisible(lianhuaUI, false);
                    SetChildVisible(bianyiUI, false);
                    SetChildVisible(huantongUI, false);

                    if (UI.petPeiyang == null)
                    {
                        UI.petPeiyang = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "Peiyang"));
                        UI.petPeiyang.transform.SetParent(UI.transform);
                        UI.petPeiyang.transform.localScale = Vector3.one;
                        trainingUI = UI.petPeiyang.AddComponent<PetTrainingUI>();
                        trainingUI.Init();
                        petTrainingUIScript = new PetTrainingUIScript(trainingUI);
                    }
                    SetChildVisible(trainingUI, true);
                    if (petLeftInfoScript != null)
                    {
                        if (lastIsTuJian)
                        {
                            petLeftInfoScript.ShowLeft();
                        }
                        else
                        {
                            clickPetItem();
                        }
                    }
                    if (PetModel.Ins.IsChongWu)
                    {
                        UI.title.text = LangConstant.PET_TRANING;
                    }
                    else
                    {
                        UI.title.text = LangConstant.PET_HORSE_TRANING;
                    }
                    break;
                case 4:
                    isTuJian = true;
                    SetChildVisible(leftInfoUI, true);
                    SetChildVisible(rightInfoUI, true);
                    SetChildVisible(jiadianUI, false);
                    SetChildVisible(skillUI, false);
                    SetChildVisible(skillBooksUI, false);
                    SetChildVisible(xichongUI, false);
                    SetChildVisible(wuxingUI, false);
                    SetChildVisible(trainingUI, false);
                    SetChildVisible(lianhuaUI, false);
                    SetChildVisible(bianyiUI, false);
                    SetChildVisible(huantongUI, false);
                    SetChildVisible(leftInfoUI.shengjiEffect, false);
                    UI.title.text = LangConstant.PET_TUJIAN;

                    petLeftInfoScript.ShowLeft();
                    break;
                default:
                    SetChildVisible(leftInfoUI, false);
                    SetChildVisible(rightInfoUI, false);
                    SetChildVisible(jiadianUI, false);
                    SetChildVisible(skillUI, false);
                    SetChildVisible(skillBooksUI, false);
                    SetChildVisible(xichongUI, false);
                    SetChildVisible(wuxingUI, false);
                    SetChildVisible(trainingUI, false);
                    SetChildVisible(lianhuaUI, false);
                    SetChildVisible(bianyiUI, false);
                    SetChildVisible(huantongUI, false);
                    SetChildVisible(leftInfoUI.shengjiEffect, false);
                    UI.title.text = "";
                    RemoveAvatarModel();
                    break;
            }

            ClearCanvas();
        }

        private void ClearCanvas()
        {
            int len = mRenderers.Count;
            for (int i = 0; i < len; i++)
            {
                mRenderers[i].Clear();
            }
        }

        public override void show(RMetaEvent e = null)
        {   
            //初始按钮不可点击，初始化完毕后才可点击
            //bool hasinit = hasInit;
            base.show();
            UI.Show();
            //petLeftInfoScript.updatePanel();

            bool issetindex = true;
            int funcId = 0;
            PetModel.Ins.IsChongWu = true;
            if (e != null)
            {
                UI.tabBtnGroup.toggleList[2].gameObject.SetActive(true);
                UI.tabBtnGroup.toggleList[4].gameObject.SetActive(true);
                object obj = WndParam.GetWndParam(e, WndParam.LINK_TO_FUNC);
                if (obj != null && int.TryParse(obj.ToString(), out funcId))
                {
                    if (funcId == FunctionIdDef.CHONGWU_JIADIAN)
                    {
                        if (!UI.petInfoLeft || !UI.petInfoRight)
                        {
                            if (OnLoaded == null)
                            {
                                OnLoaded = new List<System.Action>();
                            }
                            OnLoaded.Add(clickJiaDian);
                            UI.tabBtnGroup.SetIndexWithCallBack(0);
                        }
                        else
                        {
                            UI.tabBtnGroup.SetIndexWithCallBack(0);
                            clickJiaDian();
                        }
                        issetindex = false;
                    }
                    else if (funcId==FunctionIdDef.PETTALENTSKILL)
                    {
                        if (!UI.petInfoLeft || !UI.petInfoRight)
                        {
                            if (OnLoaded == null)
                            {
                                OnLoaded = new List<System.Action>();
                            }
                            OnLoaded.Add(clickSkill);
                            UI.tabBtnGroup.SetIndexWithCallBack(0);
                        }
                        else
                        {
                            UI.tabBtnGroup.SetIndexWithCallBack(0);
                            clickSkill();
                        }
                        issetindex = false;
                    }
                    else if (funcId == FunctionIdDef.QICHONG)
                    {
                        PetModel.Ins.IsChongWu = false;
                        UI.tabBtnGroup.toggleList[2].gameObject.SetActive(false);
                        UI.tabBtnGroup.toggleList[4].gameObject.SetActive(false);
                    }
                    else if (funcId == FunctionIdDef.QICHONGJIADIAN)
                    {
                        PetModel.Ins.IsChongWu = false;
                        UI.tabBtnGroup.toggleList[2].gameObject.SetActive(false);
                        UI.tabBtnGroup.toggleList[4].gameObject.SetActive(false);
                        if (!UI.petInfoLeft || !UI.petInfoRight)
                        {
                            if (OnLoaded == null)
                            {
                                OnLoaded = new List<System.Action>();
                            }
                            OnLoaded.Add(clickJiaDian);
                            UI.tabBtnGroup.SetIndexWithCallBack(0);
                        }
                        else
                        {
                            UI.tabBtnGroup.SetIndexWithCallBack(0);
                            clickJiaDian();
                        }
                        issetindex = false;
                    }
                }
            }
            if (funcId==0)
            {
                GuideManager.Ins.ShowGuide(GuideIdDef.PetTalent,2,UI.tabBtnGroup.toggleList[2].gameObject,false,200);
            }
            ///直接打开其他界面，不需要再选择初始界面///
            if (issetindex)
            {
                UI.tabBtnGroup.SetIndexWithCallBack(0);
            }
            //if (!hasinit)
            //{
            //    SourceManager.Ins.ignoreDispose("UITextures/item");
            //}
            //loadIconList();
            //SourceManager.Ins.ignoreDispose(PathUtil.Ins.GetEffectPath("common_baozizhi"));
            //SourceLoader.Ins.load(PathUtil.Ins.GetEffectPath("common_baozizhi"));
            if (null != petInfoRightScript)
            {
                petInfoRightScript.showright();
            }
            app.main.GameClient.ins.OnBigWndShown();
            ClearCanvas();
        }

        private void clickSkill()
        {
            UI.tabBtnGroup.SetIndexWithCallBack(2);
        }

        /// <summary>
        /// 加载背包道具图片资源
        /// </summary>
        /*
        public void loadIconList(RMetaEvent e = null)
        {
            //生成需要加载的图片列表
            List<string> iconList = genIconList();
            //加载所有图片资源
            if (!SourceLoader.Ins.isAllLoaded(iconList))
            {
                SourceLoader.Ins.loadList(iconList, loadResComplete);
            }
            else
            {
                loadResComplete(null);
            }
        }
        
        private List<string> genIconList()
        {
            List<string> iconList = new List<string>();
            iconList.Add(PathUtil.Ins.GetUITexturePath("10001", PathUtil.TEXTUER_ITEM));
            return iconList;
        }

        /// <summary>
        /// 加载完毕所有资源后，构建显示数据并显示
        /// </summary>
        /// <param name="e"></param>
        private void loadResComplete(RMetaEvent e)
        {
            ClientLog.Log("petInfoView call loadResComplete");

            //构建并显示道具
            //changeMainTab(0);
            UI.tabBtnGroup.SetIndexWithCallBack(0);
        }
        */
        private void OnBookItemClicked(ItemDetailData data)
        {
            if (data != null)
            {
                OnSkillBookSelected(null);
            }

            if (UI.petJinengshu == null)
            {
                UI.petJinengshu = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "Jinengshu"));
                UI.petJinengshu.transform.SetParent(UI.transform);
                UI.petJinengshu.transform.localScale = Vector3.one;
                UI.petJinengshu.gameObject.SetActive(true);
                skillBooksUI = UI.petJinengshu.AddComponent<PetSkillBooksUI>();
                skillBooksUI.Init();
                petSkillBooksUIScript = new PetSkillBooksUIScript(skillBooksUI, OnSkillBookSelected, OnSkillBooksUIHide);
                //UI.petInfoLeft.SetActive(false);
            }
            else
            {
                /*
                if (!UI.petJinengshu.activeSelf)
                {
                    UI.petJinengshu.SetActive(true);
                }
                */
                SetChildVisible(skillBooksUI, true);
            }

            SetChildVisible(leftInfoUI, false);
            HideAvatarModel();
            SetChildVisible(leftInfoUI.shengjiEffect, false);
            if (PetModel.Ins.IsChongWu)
            {
                petSkillBooksUIScript.BooksType = ItemDefine.ItemTypeDefine.SKILL_BOOK;
            }
            else
            {
                petSkillBooksUIScript.BooksType = ItemDefine.ItemTypeDefine.QICHONG_SKILL_BOOK;
            }
            petSkillBooksUIScript.UpdatePanel(petLeftInfoScript.getCurrentPet().PetInfo);
        }

        private void OnSkillUITabChanged()
        {
            if (skillUI.tabBtnGroup.index == 0 || skillUI.tabBtnGroup.index == 2)
            {
                if (petSkillBooksUIScript != null)
                {
                    SetChildVisible(skillBooksUI, false);
                    //petSkillBooksUIScript.HideUI();
                }
                //UI.petInfoLeft.SetActive(true);
                SetChildVisible(leftInfoUI, true);
                ShowAvatarModel();
            }
        }

        private void OnSkillBookSelected(ItemDetailData data)
        {
            petSkillUIScript.OnSkillBookSelected(data);
        }

        private void OnSkillBooksUIHide()
        {
            //leftInfoUI.gameObject.SetActive(true);
            SetChildVisible(leftInfoUI, true);
            ShowAvatarModel();
        }

        private void OnXiChongUITabChangTab(int index)
        {
            OnXiChongUITabChanged(index);
        }
        private void OnXiChongUITabChanged(int index, string eventType = null)
        {
            Pet curPet = petLeftInfoScript.getCurrentPet();

            //petHuantongUIScript = new PetHuantongUIScript(huantongUI);
            //petBianyiUIScript = new PetBianyiUIScript(bianyiUI);
            //petLianhuaUIScript = new PetLianhuaUIScript(lianhuaUI);
            //petWuxingUIScript = new PetWuXingUIScript(wuxingUI);

            switch (index)
            {
                case 0:
                    //还童。
                    SetChildVisible(wuxingUI, false);
                    SetChildVisible(lianhuaUI, false);
                    SetChildVisible(bianyiUI, false);

                    if (UI.petHuantong == null)
                    {
                        UI.petHuantong = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "Huantong"));
                        UI.petHuantong.transform.SetParent(UI.transform);
                        UI.petHuantong.transform.localScale = Vector3.one;
                        huantongUI = UI.petHuantong.AddComponent<PetHuantongUI>();
                        huantongUI.Init();
                        petHuantongUIScript = new PetHuantongUIScript(huantongUI);
                    }
                    else
                    {
                        SetChildVisible(huantongUI, true);
                    }

                    petHuantongUIScript.UpdatePanel(curPet, eventType);
                    break;
                case 1:
                    //变异。
                    SetChildVisible(wuxingUI, false);
                    SetChildVisible(lianhuaUI, false);
                    SetChildVisible(huantongUI, false);

                    if (UI.petBianyi == null)
                    {
                        UI.petBianyi = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "Bianyi"));
                        UI.petBianyi.transform.SetParent(UI.transform);
                        UI.petBianyi.transform.localScale = Vector3.one;
                        bianyiUI = UI.petBianyi.AddComponent<PetBianyiUI>();
                        bianyiUI.Init();
                        petBianyiUIScript = new PetBianyiUIScript(bianyiUI);
                    }
                    else
                    {
                        SetChildVisible(bianyiUI, true);
                    }

                    petBianyiUIScript.UpdatePanel(curPet);
                    break;
                case 2:
                    //炼化。
                    SetChildVisible(wuxingUI, false);
                    SetChildVisible(bianyiUI, false);
                    SetChildVisible(huantongUI, false);

                    if (UI.petLianhua == null)
                    {
                        UI.petLianhua = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "Lianhua"));
                        UI.petLianhua.transform.SetParent(UI.transform);
                        UI.petLianhua.transform.localScale = Vector3.one;
                        lianhuaUI = UI.petLianhua.AddComponent<PetLianhuaUI>();
                        lianhuaUI.Init();
                        petLianhuaUIScript = new PetLianhuaUIScript(lianhuaUI);
                    }
                    else
                    {
                        SetChildVisible(lianhuaUI, true);
                    }

                    petLianhuaUIScript.UpdatePanel(curPet);
                    break;
                case 3:
                    //悟性。
                    SetChildVisible(lianhuaUI, false);
                    SetChildVisible(bianyiUI, false);
                    SetChildVisible(huantongUI, false);
                    if (UI.petWuxing == null)
                    {
                        UI.petWuxing = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "Wuxing"));
                        UI.petWuxing.transform.SetParent(UI.transform);
                        UI.petWuxing.transform.localScale = Vector3.one;
                        wuxingUI = UI.petWuxing.AddComponent<PetWuxingUI>();
                        wuxingUI.Init();
                        petWuxingUIScript = new PetWuXingUIScript(wuxingUI);
                    }
                    else
                    {
                        SetChildVisible(wuxingUI, true);
                    }
                    petWuxingUIScript.UpdatePanel(curPet);
                    break;
                default:
                    break;
            }

        }


        /// <summary>
        /// 加点说明按钮点击
        /// </summary>
        private void jiadianshuomingOnClick()
        {
            PopInfoWnd.Ins.ShowInfo(
                ColorUtil.getColorText(ColorUtil.PURPLE, "强壮") + "  影响物理攻击、物理命中、物理抗暴、速度\n" +
                ColorUtil.getColorText(ColorUtil.PURPLE, "耐力") + "  影响生命、物理护甲、法术抗性\n" +
                ColorUtil.getColorText(ColorUtil.PURPLE, "敏捷") + "  影响物理护甲、物理闪避、物理暴击、速度\n" +
                ColorUtil.getColorText(ColorUtil.PURPLE, "智力") + "  影响法术强度、法术命中、法术抗暴、法力\n" +
                ColorUtil.getColorText(ColorUtil.PURPLE, "信仰") + "  影响法术抗性、法术暴击、速度", "加点说明", TextAnchor.MiddleLeft, 520);
        }

        public void showUsePetGuide()
        {
            GuideManager.Ins.ShowGuide(GuideIdDef.UsePet, 4, UI.closeBtn.gameObject);
        }

        public override void Destroy()
        {
            petmodel.removeChangeEvent(PetModel.UPDATE_PET_INFO, updatePetProp);
            petmodel.removeChangeEvent(PetModel.UPDATE_PET_PROP, updatePetProp);
            petmodel.removeChangeEvent(PetModel.UPDATE_PET_FIGHT_STATE, updatePetProp);

            petmodel.removeChangeEvent(PetModel.UPDATE_PET_LIST, UpdatePetList);
            petmodel.removeChangeEvent(PetModel.UPDATE_SERVER_TIME, ShowZujieqi);
            EventCore.removeRMetaEventListener(PetLeftInfoScript.SHOW_PET_UPGRADE_EFFECT, learnresult);

            bagModel.removeChangeEvent(BagModel.UPDATE_BAG_EVENT, UpdatePetBookList);
            bagModel.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdatePetBookList);

            RemoveAvatarModel();

            if (petLeftInfoScript != null)
            {
                petLeftInfoScript.Destroy();
                petLeftInfoScript = null;
            }

            if (petInfoRightScript != null)
            {
                petInfoRightScript.Destroy();
                petInfoRightScript = null;
            }

            if (petHuantongUIScript != null)
            {
                petHuantongUIScript.Destroy();
                petHuantongUIScript = null;
            }

            if (petBianyiUIScript != null)
            {
                petBianyiUIScript.Destroy();
                petBianyiUIScript = null;
            }

            if (petLianhuaUIScript != null)
            {
                petLianhuaUIScript.Destroy();
                petLianhuaUIScript = null;
            }

            if (petWuxingUIScript != null)
            {
                petWuxingUIScript.Destroy();
                petWuxingUIScript = null;
            }

            if (petSkillUIScript != null)
            {
                petSkillUIScript.Destroy();
                petSkillUIScript = null;
            }

            if (petSkillBooksUIScript != null)
            {
                petSkillBooksUIScript.Destroy();
                petSkillBooksUIScript = null;
            }

            if (petTrainingUIScript != null)
            {
                petTrainingUIScript.Destroy();
                petSkillBooksUIScript = null;
            }

            if (OnLoaded != null)
            {
                OnLoaded.Clear();
                OnLoaded = null;
            }

            base.Destroy();
            UI = null;
        }


        private IEnumerator InitLeftInfo(int waitFrame)
        {

            for (int i = 0; i < waitFrame; i++)
            {
                yield return null;
            }
            UI.petInfoLeft = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "LeftInfo"));
            UI.petInfoLeft.transform.SetParent(UI.transform);
            UI.petInfoLeft.transform.localScale = Vector3.one;
            UI.petInfoLeft.SetActive(true);
            leftInfoUI = UI.petInfoLeft.AddComponent<PetLeftInfoUI>();
            leftInfoUI.Init();
            petLeftInfoScript = new PetLeftInfoScript(leftInfoUI, clickPetItem, ClickZujieqi);
            //yield return 0;
            OnLeftOrRightInfoInited();
        }

        private IEnumerator InitRightInfo(int waitFrame)
        {
            for (int i = 0; i < waitFrame; i++)
            {
                yield return null;
            }
            UI.petInfoRight = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "RightInfo"));
            UI.petInfoRight.transform.SetParent(UI.transform);
            UI.petInfoRight.transform.localScale = Vector3.one;
            if (UI.tabBtnGroup.index == 0)
            {
                UI.petInfoRight.SetActive(true);
            }
            rightInfoUI = UI.petInfoRight.AddComponent<PetInfoRightUI>();
            rightInfoUI.Init();
            rightInfoUI.jiadianBtn.SetClickCallBack(clickJiaDian);
            rightInfoUI.m_zizhidanshuoming.SetClickCallBack(zizidanshuoming);
            petInfoRightScript = new PetInfoRightScript(rightInfoUI);
            petInfoRightScript.showright();
            mRenderers.Add(rightInfoUI.skillObj.transform.parent.GetComponent<CanvasRenderer>());
            OnLeftOrRightInfoInited();
        }

        private void OnLeftOrRightInfoInited()
        {
            if (petLeftInfoScript != null && petInfoRightScript != null)
            {
                petLeftInfoScript.ShowLeft();
                UI.closeBtn.SetClickCallBack(closePanel);

                if (OnLoaded != null)
                {
                    for (int i = 0; i < OnLoaded.Count; i++)
                    {
                        OnLoaded[i]();
                    }
                }
            }
        }

        private void zizidanshuoming(GameObject clickobj)
        {
            PopInfoScrollWnd.Ins.ShowInfo(LangConstant.ZI_ZHI_DAN_SHUOMING_INFO, LangConstant.ZI_ZHI_DAN_SHUOMING_TITLE);
        }

        private void ClickZujieqi(RMetaEvent e = null)
        {
            CommonCGHandler.sendCGPing();
            m_isclickzujie = true;
        }

        private void ShowZujieqi(RMetaEvent e = null)
        {
            if (!m_isclickzujie)
            {
                return;
            }
            m_isclickzujie = false;
            UI.m_zujieobj.transform.SetAsLastSibling();
            UI.m_zujieobj.SetActive(true);
            ///续租所需物品///
            int itemid = petLeftInfoScript.getCurrentPet().getTpl().leaseItemId;
            ItemTemplate temp = ItemTemplateDB.Instance.getTempalte(itemid);
            UI.m_zujiecost.icon.gameObject.SetActive(false);
            if (temp != null)
            {
                UI.m_zujiename.text = temp.name;
                PathUtil.Ins.SetItemIcon(UI.m_zujiecost.icon, temp.icon);
            }
            int numNeed = 1;
            int myNum = Human.Instance.BagModel.getHasNum(itemid);
            if (myNum >= numNeed)
            {
                UI.m_zujiecost.num.text = ColorUtil.getColorText(ColorUtil.GREEN, myNum.ToString()) + " / " + numNeed;
            }
            else
            {
                UI.m_zujiecost.num.text = ColorUtil.getColorText(ColorUtil.RED, myNum.ToString()) + " / " + numNeed;
            }

            System.DateTime dt = new System.DateTime(1970, 1, 1);
            System.DateTime daoqi = dt.AddMilliseconds(petLeftInfoScript.getCurrentPet().deadline);
            System.DateTime curtime = dt.AddMilliseconds(GameClient.ins.serverTime);
            System.TimeSpan cha = daoqi - curtime;
            
            double chami = cha.TotalMilliseconds;
            if(chami<0)
            {
                chami = 0;
            }
            int seconds = (int)(chami / 1000);
            int day = (int)(seconds / 86400);
            int hour = (int)(seconds % 86400 / 3600);
            int minute = (int)(seconds % 3600 / 60);
            //int second = (int)(seconds % 3600 % 60);
            string str = "";

            if (day != 0)
            {
                str += day + "天";////"天"
            }

            if (hour != 0 || day != 0)
            {
                str += hour + "小时";////"小时"
            }

            //if (minute != 0 || hour != 0 || day != 0)
            //{
            //    str += minute + "分钟";////"分"
            //}

            if (0 == chami)
            {
                UI.m_zujietime.text = "已到期";
            }
            else if (0 == day && hour==0 && minute>0)
            {
                UI.m_zujietime.text = "小于1小时";
            }
            else
            {
                UI.m_zujietime.text = str;
            }
        }

        public void ClickCloseBg(UnityEngine.GameObject go)
        {
            closezujie();
        }

        private void closezujie()
        {
            UI.m_zujieobj.SetActive(false);
        }

        private void clickzujie()
        {
            int itemid = petLeftInfoScript.getCurrentPet().getTpl().leaseItemId;

            ItemDetailData itemDetailData = bagModel.getItemBag(ItemDefine.BagId.MAIN_BAG).getItemDetail(itemid);
            if (null != itemDetailData)
            {
                ItemCGHandler.sendCGUseItem(itemDetailData.commonItemData.bagId, itemDetailData.commonItemData.index, 1, 3, petLeftInfoScript.getCurrentPet().Id);
                closezujie();
            }
            else
            {
                ItemTemplate temp = ItemTemplateDB.Instance.getTempalte(itemid);
                string pinzhi = StringUtil.Assemble(LangConstant.ZUJIE_WUPIN_BUZU, new string[1] { temp.name});
                ZoneBubbleManager.ins.BubbleSysMsg(pinzhi);
            }
            
        }

        private void zujieitemclick()
        {
            int itemid = petLeftInfoScript.getCurrentPet().getTpl().leaseItemId;
            ItemTemplate temp = ItemTemplateDB.Instance.getTempalte(itemid);
            if (null != temp)
            {
                ItemTips.Ins.ShowTips(temp, true);
            }
        }

    }
}