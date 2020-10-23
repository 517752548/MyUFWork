using System.Collections;
using System.Collections.Generic;
using app.item;
using app.model;
using UnityEngine;
using app.human;
using app.pet;
using app.role;
using app.net;
using UnityEngine.UI;

namespace app.bag
{
    public class BagView : BaseWnd
    {
        private const int WAIT_FRAME = 1;
        /// <summary>
        /// 服务器数据对象
        /// </summary>
        public BagModel bagModel;
        public PetModel petModel;
        public ChiBangModel chibangModel;

        private Text panelTitle;
        private BagLeftUI leftInfoUI;
        private BagLeftUIScript leftInfo;

        private BagRightUI rightInfoUI;
        public BagRightUIScript rightInfo;

        private CangkuUI cangkuUI;
        private CangKuUIScript cangkuInfo;

        /// <summary>
        /// 当前显示的功能是 背包 还是 仓库
        /// </summary>
        private int currentShowFunc=0;

        private ChiBangInfoUI chibangUI;
        /// <summary>
        /// 翅膀逻辑
        /// </summary>
        private ChiBangScript chibangScript;
        private bool needRequestChiBang = true;
        public int chibangTabIndex = 4;

        public BagView()
        {
            uiName = "bagUI";
            hasSubUI = true;
        }

        /// <summary>
        /// 当前显示的功能是 背包 还是 仓库
        /// </summary>
        public int CurrentShowFunc
        {
            get { return currentShowFunc == 0 ? FunctionIdDef.BEIBAO : currentShowFunc; }
            set { currentShowFunc = value; }
        }

        public override void initWnd()
        {
            base.initWnd();
            
            bagModel = BagModel.Ins;
            //bagModel.addChangeEvent(BagModel.UPDATE_BAG_EVENT, updateBag);
            bagModel.addChangeEvent(BagModel.UPDATE_ITEM_EVENT, updateItem);
            bagModel.addChangeEvent(BagModel.ADD_ITEM_EVENT, addItem);
            bagModel.addChangeEvent(BagModel.REMOVE_ITEM_EVENT, removeItem);
            bagModel.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateItemList);
            petModel = PetModel.Ins;
            petModel.addChangeEvent(PetModel.UPDATE_PET_EQUIP_BAG_EVENT, updatePetBag);
            petModel.addChangeEvent(PetModel.UPDATE_PET_EQUIP_BAG_LIST_EVENT, updatePetBag);
            petModel.addChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateCurrency);

            FunctionModel.Ins.addChangeEvent(FunctionModel.ADD_NEW_FUNC, OnFuncInfoChanged);
            FunctionModel.Ins.addChangeEvent(FunctionModel.FUNC_INFO_UPDATE, OnFuncInfoChanged);
            ChiBangModel.Ins.addChangeEvent(ChiBangModel.UPDATE_WINGLIST, updatewinglist);

            chibangModel = ChiBangModel.Ins;
            //chibangModel.addChangeEvent(ChiBangModel.UPDATE_CURWING, UpdateCurWing);

            panelTitle = ui.transform.Find("title").gameObject.GetComponent<Text>();

            leftInfoUI = ui.transform.Find("leftPanel").gameObject.AddComponent<BagLeftUI>();
            leftInfoUI.Init(true);
            leftInfo = new BagLeftUIScript(leftInfoUI);
            //rightInfoUI = getComponent<BagRightUI>("rightPanel");
            rightInfoUI = ui.transform.Find("rightPanel").gameObject.AddComponent<BagRightUI>();
            rightInfoUI.Init();
            rightInfo = new BagRightUIScript(rightInfoUI,this);

            cangkuUI = ui.transform.Find("cangku").gameObject.AddComponent<CangkuUI>();
            cangkuUI.Init();
            cangkuInfo = new CangKuUIScript(cangkuUI);
            cangkuUI.gameObject.SetActive(false);

            if (rightInfoUI.closeBtn!=null) rightInfoUI.closeBtn.SetClickCallBack(closePanel);

            OnFuncInfoChanged();
        }

        public void OnFuncInfoChanged(RMetaEvent e = null)
        {
            rightInfoUI.tabButtonGroup.toggleList[chibangTabIndex].gameObject.
                SetActive(FunctionModel.Ins.IsFuncOpen(FunctionIdDef.CHIBANG) && ChiBangModel.Ins.WingList!=null&&ChiBangModel.Ins.WingList.Count > 0);
        }

        private void closePanel()
        {
            hide();
        }

        public override void show(RMetaEvent e = null)
        {
            bool hasinit = hasInit;
            base.show();
            
            if (e != null)
            {
                object selecttab = WndParam.GetWndParam(e, WndParam.LINK_TO_FUNC);
                if (selecttab != null)
                {
                    int.TryParse(selecttab.ToString(), out currentShowFunc);
                }
            }
            if (!hasinit)
            {
                SourceManager.Ins.ignoreDispose("UITextures/item");
            }
            //loadResComplete(null);
            rightInfo.CreateBagList();
            rightInfo.UpdateCurrency();
            if (CurrentShowFunc == FunctionIdDef.BEIBAO)
            {
                panelTitle.text = "背  包";
                leftInfo.init(true);
                leftInfo.updatePanel();
                AddRoleModelToUI(Vector3.zero, Vector3.one, Human.Instance.PetModel.getLeader().getTpl(), leftInfoUI.modelContainer);
                UpdateCurWing();
                UpdateCurWeapon();

                leftInfoUI.gameObject.SetActive(true);
                cangkuUI.gameObject.SetActive(false);

                rightInfoUI.tabButtonGroup.SetIndexWithCallBack(0);
                //更新翅膀功能页签是否显示
                OnFuncInfoChanged();
                rightInfo.CheckSkillGuide();
            }
            else if (CurrentShowFunc == FunctionIdDef.CANGKU)
            {
                panelTitle.text = "仓  库";
                RemoveAvatarModel();
                
                leftInfoUI.gameObject.SetActive(false);
                cangkuUI.gameObject.SetActive(true);
                cangkuInfo.show();

                rightInfoUI.gameObject.SetActive(true);
                rightInfoUI.tabButtonGroup.SetIndexWithCallBack(0);
                rightInfoUI.tabButtonGroup.toggleList[chibangTabIndex].gameObject.SetActive(false);
                hideChiBang();
            }
            else if (rightInfoUI.tabButtonGroup.index == chibangTabIndex 
                || (currentShowFunc == FunctionIdDef.CHIBANG))
            {
                panelTitle.text = "翅  膀";
                currentShowFunc = FunctionIdDef.CHIBANG;

                //leftInfo.init(true);
                //leftInfo.updatePanel();
                //AddRoleModelToUI(Vector3.zero, Vector3.one, Human.Instance.PetModel.getLeader().getTpl(), leftInfoUI.modelContainer);
                //UpdateCurWing();
                //UpdateCurWeapon();

                cangkuUI.gameObject.SetActive(false);

                rightInfoUI.tabButtonGroup.SetIndexWithCallBack(chibangTabIndex);
                rightInfoUI.tabButtonGroup.toggleList[chibangTabIndex].gameObject.SetActive(true);
            }

            app.main.GameClient.ins.OnBigWndShown();
            updatewinglist();
        }
        
        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);

            if (chibangScript != null)
            {
                chibangScript.setEmpty();
            }
            needRequestChiBang = true;
            app.main.GameClient.ins.OnBigWndHidden();
        }
        
        public void updatePetBag(RMetaEvent e)
        {
            if (WndManager.Ins.IsWndShowing(this))
            {
                leftInfo.updatePanel();
                UpdateCurWing();
                UpdateCurWeapon();
            }
        }

        IEnumerator InitChibang(int waitFrame)
        {
            for (int i = 0; i < waitFrame; i++)
            {
                yield return null;
            }
            GameObject chibangUIobj = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "Chibang"));
            chibangUIobj.transform.SetParent(ui.transform);
            chibangUIobj.transform.localScale = Vector3.one;
            chibangUIobj.gameObject.SetActive(true);
            chibangUI = chibangUIobj.AddComponent<ChiBangInfoUI>();
            chibangUI.Init();
            chibangScript = new ChiBangScript(chibangUI);

            chibangScript.UpdateWeapon();

            if (needRequestChiBang && WndManager.Ins.IsWndShowing(GlobalConstDefine.BagView_Name))
            {
                WingCGHandler.sendCGWingPanel();
                needRequestChiBang = false;
            }
        }

        public override void Update()
        {
            base.Update();
            if (chibangScript != null)
            {
                chibangScript.Update();
            }
        }

        public void showChiBangTab()
        {
            panelTitle.text = "翅  膀";
            currentShowFunc = FunctionIdDef.CHIBANG;
            if (chibangUI==null)
            {
                panelTitle.StartCoroutine(InitChibang(WAIT_FRAME));
            }
            else
            {
                chibangUI.Show();
                chibangScript.ShowAvatarModel();
                chibangScript.UpdateWeapon();
                if (needRequestChiBang && WndManager.Ins.IsWndShowing(GlobalConstDefine.BagView_Name))
                {
                    WingCGHandler.sendCGWingPanel();
                    needRequestChiBang = false;
                }
            }
        }

        public void hideChiBang()
        {
            if (chibangUI != null)
            {
                chibangScript.HideAvatarModel();
                chibangUI.Hide();
            }
        }

        public void showBag()
        {
            panelTitle.text = "背  包";
            leftInfoUI.gameObject.SetActive(true);
            rightInfoUI.gameObject.SetActive(true);
        }

        public void hideBag()
        {
            leftInfoUI.gameObject.SetActive(false);
            rightInfoUI.gameObject.SetActive(false);
        }

        public void UpdateItemList(RMetaEvent e)
        {
            List<KeyValuePair<CommonItemData, int>> list = e.data as List<KeyValuePair<CommonItemData, int>>;
            int len = list.Count;
            for (int i = 0; i < len; i++)
            {
                KeyValuePair<CommonItemData, int> item = list[i];
                if (item.Value == -1)
                {
                    rightInfo.removeItem(item.Key.uuid, false);
                }
                else if (item.Value == 1)
                {
                    rightInfo.addItem(bagModel.getItemBag(ItemDefine.BagId.MAIN_BAG).getItemByUUID(item.Key.uuid), false);
                }
                else if (item.Value == 0)
                {
                    rightInfo.updateItem(bagModel.getItemBag(ItemDefine.BagId.MAIN_BAG).getItemByUUID(item.Key.uuid));
                }
            }

            rightInfo.FillPageWithEmptyItems();
        }

        public void updateItem(RMetaEvent e)
        {
            //if (WndManager.Ins.IsWndShowing(this))
            {
                rightInfo.updateItem(e.data as ItemDetailData);
            }
        }

        public void addItem(RMetaEvent e)
        {
            //updateBag();
            //if (WndManager.Ins.IsWndShowing(this))
            {
                rightInfo.addItem(e.data as ItemDetailData);
            }
        }

        public void removeItem(RMetaEvent e)
        {
            //if (WndManager.Ins.IsWndShowing(this))
            {
                rightInfo.removeItem(e.data as string);
                //rightInfo.updateCurrentTab();
            }
        }

        public void updateCurrency(RMetaEvent e)
        {
            if (WndManager.Ins.IsWndShowing(this))
            {
                rightInfo.UpdateCurrency();
            }
        }

        public void UpdateCurWing(RMetaEvent e=null)
        {
            leftInfo.UpdateCurWing(chibangModel.GetCurWearWingInfo());
        }
        
        public void UpdateCurWeapon()
        {
            Human.Instance.updateSelfWeapon(avatarBase);
        }

        public void updatewinglist(RMetaEvent e=null)
        {
            if (FunctionModel.Ins.IsFuncOpen(FunctionIdDef.CHIBANG) && ChiBangModel.Ins.WingList!=null&&ChiBangModel.Ins.WingList.Count > 0)
            {
                rightInfoUI.tabButtonGroup.toggleList[chibangTabIndex].gameObject.SetActive(true); 
            }
            else
            {
                rightInfoUI.tabButtonGroup.toggleList[chibangTabIndex].gameObject.SetActive(false);   
            }
        }
        
        public override void Destroy()
        {
            //bagModel.removeChangeEvent(BagModel.UPDATE_BAG_EVENT, updateBag);
            bagModel.removeChangeEvent(BagModel.UPDATE_ITEM_EVENT, updateItem);
            bagModel.removeChangeEvent(BagModel.ADD_ITEM_EVENT, addItem);
            bagModel.removeChangeEvent(BagModel.REMOVE_ITEM_EVENT, removeItem);
            bagModel.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateItemList);

            petModel.removeChangeEvent(PetModel.UPDATE_PET_EQUIP_BAG_EVENT, updatePetBag);
            petModel.removeChangeEvent(PetModel.UPDATE_PET_EQUIP_BAG_LIST_EVENT, updatePetBag);
            petModel.removeChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateCurrency);
            //chibangModel.removeChangeEvent(ChiBangModel.UPDATE_CURWING, UpdateCurWing);

            FunctionModel.Ins.removeChangeEvent(FunctionModel.ADD_NEW_FUNC, OnFuncInfoChanged);
            FunctionModel.Ins.removeChangeEvent(FunctionModel.FUNC_INFO_UPDATE, OnFuncInfoChanged);
            ChiBangModel.Ins.removeChangeEvent(ChiBangModel.UPDATE_WINGLIST, updatewinglist);

            RemoveAvatarModel();
            leftInfo.Destroy();
            leftInfo = null;

            rightInfo.Destroy();
            rightInfo = null;

            base.Destroy();
            leftInfoUI=null;
            rightInfoUI=null;

            if(cangkuInfo!=null)cangkuInfo.Destroy();
            cangkuUI = null;

            if (chibangScript != null)
            {
                chibangScript.Destroy();
                chibangScript = null;
            }
        }
    }
}