using System.Collections.Generic;
using UnityEngine;
using app.db;
using app.human;
using app.pet;
using app.net;

namespace app.petstore
{
    public class PetStoreView : BaseWnd
    {
        public PetModel petModel;
        //[Inject(ui = "PetStoreUI")]
        //public GameObject ui;
        //总UI
        public PetStoreUI UI;

        private List<PetStoreLevelListItem> mallLevelItems = new List<PetStoreLevelListItem>();
        private List<PetStorePetListItem> mAllPetListItems = new List<PetStorePetListItem>();

        private MoneyItemScript mCurPetCost = null;
        private MoneyItemScript mMyMoney = null;

        private PetStorePetListItem mCurPetItem = null;

        private int m_store_id = 0;
        
        public PetStoreView()
        {
            uiName = "PetStoreUI";
        }

        public override void initWnd()
        {
            base.initWnd();
            
            petModel = PetModel.Ins;
            petModel.addChangeEvent(PetModel.UPDATE_HUMAN_PROP, OnHumanPropChanged);
            
            UI = ui.AddComponent<PetStoreUI>();
            UI.Init();
            UI.closeBtn.SetClickCallBack(close);
            UI.levelListGroup.TabChangeHandler = OnLevelChanged;
            UI.petListGroup.AllTabCloseHandler = OnAllPetUnselected;
            UI.petListGroup.TabChangeHandler = OnCurPetChanged;
            UI.buyBtn.SetClickCallBack(OnBuyBtnClicked);
            mCurPetCost = new MoneyItemScript(UI.petCost);
            mMyMoney = new MoneyItemScript(UI.ownMoney);

            
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);

            UI.m_title.text = LangConstant.CHONG_WU_SHANG_DIAN;
            UI.m_tag_title.text = LangConstant.CHU_ZHAN_DENG_JI;
            UI.m_des.gameObject.SetActive(true);
            //UI.m_des1.gameObject.SetActive(true);
            //UI.m_des2.gameObject.SetActive(true);
            if (e != null)
            {
                int funcId = 0;
                object obj = WndParam.GetWndParam(e, WndParam.LINK_TO_FUNC);
                if (obj != null && int.TryParse(obj.ToString(), out funcId))
                {
                    if (funcId == FunctionIdDef.PETSTORE)
                    {
                        m_store_id = 1;
                    }
                    else if (funcId == FunctionIdDef.SHENGHUOJINENG_STORE)
                    {
                        m_store_id = 7;
                        UI.m_title.text = LangConstant.SHENG_HUO_JI_NENG_SHANG_DIAN;
                        UI.m_tag_title.text = LangConstant.SHI_YONG_DENG_JI;
                        UI.m_des.gameObject.SetActive(false);
                        //UI.m_des1.gameObject.SetActive(false);
                        //UI.m_des2.gameObject.SetActive(false);
                    }
                    else
                    {
                        m_store_id = 1;
                    }
                }
                else
                {
                    m_store_id = 1;
                }
            }
            else
            {
                m_store_id = 1;
            }
            
            RefreshTag();
            UpdateMyMoney();
            UI.levelListGroup.SetIndexWithCallBack(0);
            app.main.GameClient.ins.OnBigWndShown();
            /*
            if (mCurPetItem != null)
            {
                UI.levelListGroup.UnSelectAll();
            }
            else
            {
                UpdateCurPetCost();
            }
            */
        }
        
        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            app.main.GameClient.ins.OnBigWndHidden();
        }

        private void close()
        {
            hide();
        }

        private void RefreshTag()
        {
            List<int> levels = new List<int>();
            ///标签下的所有物品///
            int index = 0;
            foreach (KeyValuePair<int, MallNormalItemTemplate> pair in MallNormalItemTemplateDB.Instance.getIdKeyDic())
            {
                if (pair.Value.catalogId == m_store_id)
                {
                    if (index >= mAllPetListItems.Count)
                    {
                        PetStorePetListItemUI petItemUI = GameObject.Instantiate(UI.petListItemUI);
                        petItemUI.transform.SetParent(UI.petListItemUI.transform.parent);
                        petItemUI.transform.localScale = UI.petListItemUI.transform.localScale;
                        petItemUI.gameObject.SetActive(true);

                        UI.petListGroup.AddToggle(petItemUI.toggle);
                        PetStorePetListItem petItem = new PetStorePetListItem(petItemUI);
                        mAllPetListItems.Add(petItem);
                    }
                    mAllPetListItems[index].SetData(pair.Value);
                    if (!levels.Contains(pair.Value.subTag))
                    {
                        levels.Add(pair.Value.subTag);
                    }
                    ++index;
                }
            }

            for (int i = index; i < mAllPetListItems.Count; ++i)
            {
                PetStorePetListItem levelItem = mAllPetListItems[i];
                UI.petListGroup.toggleList.RemoveAt(i);
                mAllPetListItems.RemoveAt(i);
                levelItem.Destroy();
                --i;
            }

            levels.Sort();

            ///所有二级标签///
            int len = levels.Count;
            for (int i = 0; i < len; i++)
            {
                if (i >= UI.levelListGroup.toggleList.Count)
                {
                    PetStoreLevelListItemUI levelItemUI = GameObject.Instantiate(UI.levelListItemUI);
                    levelItemUI.transform.SetParent(UI.levelListItemUI.transform.parent);
                    levelItemUI.transform.localScale = UI.levelListItemUI.transform.localScale;
                    levelItemUI.gameObject.SetActive(true);
                    UI.levelListGroup.AddToggle(levelItemUI.toggle);
                    PetStoreLevelListItem levelItem = new PetStoreLevelListItem(levelItemUI);
                    mallLevelItems.Add(levelItem);
                }
                mallLevelItems[i].SetLevel(levels[i]);
                
            }

            for (int i = len; i < mallLevelItems.Count; ++i)
            {
                PetStoreLevelListItem levelItem = mallLevelItems[i];
                UI.levelListGroup.toggleList.RemoveAt(i);
                mallLevelItems.RemoveAt(i);
                levelItem.Destroy();
                --i;
            }
        }

        private void OnLevelChanged(int index)
        {
            //bool gotFirstPet = false;
            UI.petListGroup.UnSelectAll(true);
            //OnCurPetChanged(-1);
            int level = mallLevelItems[index].level;
            int len = mAllPetListItems.Count;
            for (int i = 0; i < len; i++)
            {
                if (mAllPetListItems[i].GetData().subTag == level)
                {
                    mAllPetListItems[i].SetActive(true);
                    /*
                    if (!gotFirstPet)
                    {
                        UI.petListGroup.SetIndexWithCallBack(i);
                        gotFirstPet = true;
                    }
                    */
                }
                else
                {
                    mAllPetListItems[i].SetActive(false);
                }
            }
            /*
            if (!gotFirstPet)
            {
                OnCurPetChanged(-1);
            }
            */
        }
        
        private void OnAllPetUnselected()
        {
            OnCurPetChanged(-1);
        }

        private void OnCurPetChanged(int index)
        {
            if (index == -1)
            {
                mCurPetItem = null;
            }
            else
            {
                mCurPetItem = mAllPetListItems[index];
            }

            UpdateCurPetCost();
        }

        private void OnHumanPropChanged(RMetaEvent e)
        {
            UpdateMyMoney();
            UpdateCurPetCost();
        }

        private void UpdateMyMoney()
        {
            if (mMyMoney!=null) mMyMoney.SetMoney(CurrencyTypeDef.GOLD, Human.Instance.GetCurrencyValue(CurrencyTypeDef.GOLD), false, false);
        }

        private void UpdateCurPetCost()
        {
            if (mCurPetItem != null)
            {
                if (mCurPetCost!=null) mCurPetCost.SetMoney(mCurPetItem.GetData().priceList[1].currencyType, mCurPetItem.GetData().priceList[1].num, true, false);
            }
            else
            {
                if (mCurPetCost != null) mCurPetCost.SetMoney(CurrencyTypeDef.GOLD, 0, true, false);
            }
        }

        private void OnBuyBtnClicked()
        {
            if (mCurPetItem != null)
            {
                MoneyCheck.Ins.Check(mCurPetItem.GetData().priceList[1], sureHandler);
            }
        }

        private void sureHandler(RMetaEvent e)
        {
            MallCGHandler.sendCGBuyNormalItem(mCurPetItem.GetData().Id, 1);
        }

        public override void Destroy()
        {
            petModel.removeChangeEvent(PetModel.UPDATE_HUMAN_PROP, OnHumanPropChanged);
            if (mAllPetListItems != null)
            {
                int len = mAllPetListItems.Count;
                for (int i = 0; i < len; i++)
                {
                    mAllPetListItems[i].Destroy();
                }
                mAllPetListItems.Clear();
                mAllPetListItems = null;
            }

            if (mallLevelItems != null)
            {
                int len = mallLevelItems.Count;
                for (int i = 0; i < len; i++)
                {
                    mallLevelItems[i] = null;
                }
                mallLevelItems.Clear();
                mallLevelItems = null;
            }

            
            if (mCurPetCost != null)
            {
                mCurPetCost.Destroy();
                mCurPetCost = null;
            }
            
            if (mMyMoney != null)
            {
                mMyMoney.Destroy();
                mMyMoney = null;
            }
            if (mCurPetItem != null)
            {
                mCurPetItem.Destroy();
                mCurPetItem = null;
            }
            base.Destroy();
            UI = null;
        }
    }
}