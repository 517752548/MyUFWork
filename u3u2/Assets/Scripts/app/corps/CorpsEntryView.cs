using System.Collections;
using System.Collections.Generic;
using app.human;
using app.net;
using app.pet;
using app.chat;
using app.role;
using app.zone;
using UnityEngine;
using UnityEngine.UI;

namespace app.corp
{
    /// <summary>
    /// 帮派列表
    /// </summary>
    public class CorpsEntryView : BaseWnd
    {
        //[Inject(ui = "BangPaiEntryUI")]
        //public GameObject ui;

        public BangPaiEntryUI UI;
        public CorpModel corpModel;
        public PetModel petModel;

        public InputField findInputText;

        private CreateCorpView createCorpView;

        private List<CorpListItemScript> corpItemList;
        private ScrollRectControl scrollRect;

        private ChatModel mChatModel = null;
        
        public CorpsEntryView()
        {
            uiName = "BangPaiEntryUI";
        }

        public override void initWnd()
        {
            base.initWnd();
            
            corpModel = CorpModel.Ins;
            corpModel.addChangeEvent(CorpModel.UPDATE_CORPSLIST, updateCorpsList);
            corpModel.addChangeEvent(CorpModel.UPDATE_CURRENT_CORP, updateCurrentCorp);
            corpModel.addChangeEvent(CorpModel.UPDATE_SEARCH_RESULT, searchResult);
            petModel = PetModel.Ins;
            petModel.addChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateRoleMoney);
            
            UI = ui.AddComponent<BangPaiEntryUI>();
            UI.Init();
            UI.closeBtn.SetClickCallBack(clickClose);
            findInputText = CreateInputField(Color.black, 20, UI.inputTextBg, true);
            createCorpView = new CreateCorpView(UI.createUI);

            UI.yijianShenqing.SetClickCallBack(clickYiJianShenQing);
            UI.shenqingJiaru.SetClickCallBack(clickShenQing);
            UI.lianxiBangzhu.SetClickCallBack(clickLianxiBangzhu);
            UI.chuangjianBangPai.SetClickCallBack(clickCreate);
            UI.clearSearchBtn.SetClickCallBack(clickBackToList);

            UI.listTBG.TabChangeHandler = selectOneCorp;
            //UI.listTBG.AllTabCloseHandler = noneSelectCrop;
            UI.shenqingJiaru.interactable = false;
            UI.lianxiBangzhu.interactable = false;
            UI.chazhaoBtn.SetClickCallBack(clickSearch);
            findInputText.onEndEdit.AddListener(doSubmit);
            UI.gongGaoText.text = "";

            UI.clearSearchBtn.gameObject.SetActive(false);

            UI.pageturner._leftImgBtn.SetClickCallBack(LastPageClick);
            UI.pageturner._rightImgBtn.SetClickCallBack(NextPageClick);

            UI.pageturner.AutoVisible = false;
            UI.pageturner.MaxValue = 1;
            UI.pageturner.Value = 0;
        }

        /// <summary>
        /// 上一页
        /// </summary>
        private void LastPageClick()
        {
            if (CorpModel.Ins.CorpListPanel.getCurrPage() > 1)
            {
                CorpsCGHandler.sendCGCorpsPageSkip(0, CorpModel.Ins.CorpListPanel.getCurrPage() - 1);
            }
        }

        /// <summary>
        /// 下一页
        /// </summary>
        private void NextPageClick()
        {
            if (CorpModel.Ins.CorpListPanel.getCurrPage() < CorpModel.Ins.CorpListPanel.getMaxPageNum())
            {
                CorpsCGHandler.sendCGCorpsPageSkip(0, CorpModel.Ins.CorpListPanel.getCurrPage() + 1);
            }
        }

        private void clickBackToList()
        {
            CorpsCGHandler.sendCGClickCorpsPanel();
            UI.clearSearchBtn.gameObject.SetActive(false);
            findInputText.text = "";
        }

        private void noneSelectCrop()
        {
            UI.shenqingJiaru.interactable = false;
            UI.lianxiBangzhu.interactable = false;
        }

        private void selectOneCorp(int tab)
        {
            SimpleCorpsInfo corpInfo = corpModel.CorpList[tab];
            int hascorp = Human.Instance.PropertyManager.getIntProp(RoleBaseIntProperties.HAS_CORPS);
            if (hascorp == 0)
            {
                if (corpInfo.isApplied == 0)
                {
                    UI.shenqingJiaru.interactable = true;
                    UI.shenqingBtnText.text = LangConstant.SHENQING_JIARU;
                }
                else
                {
                    UI.shenqingJiaru.interactable = true;
                    UI.shenqingBtnText.text = LangConstant.CHEXIAO_SHENQING;
                }
            }
            UI.gongGaoText.text = corpInfo.notice;
            UI.lianxiBangzhu.interactable = true;
        }

        private void doSubmit(string str)
        {
            if (findInputText.text.Length>0)
            {
                UI.clearSearchBtn.gameObject.SetActive(true);
            }
            clickSearch();
        }

        private void clickSearch()
        {
            if (findInputText.text.Length == 0)
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.CORPNAME_CANNOT_EMPTY);
                return;
            }
            else if (findInputText.text.Length < 2 || findInputText.text.Length > 12)
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.CORPNAME_BUHEFA);
                return;
            }
            //CorpsCGHandler.sendCGClickCorpsPanel();
            corpModel.isSearch = true;
            CorpsCGHandler.sendCGSearchCorps(0, findInputText.text);
        }

        private void clickYiJianShenQing()
        {
            if (corpModel.CorpList != null && corpModel.CorpList.Count > 0)
            {
                CorpsCGHandler.sendCGCorpsQuickApply(CorpModel.Ins.CorpListPanel.getCurrPage());
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.NOCORP_CAN_SHENQING);
            }
        }

        private void clickLianxiBangzhu()
        {
            if (UI.listTBG.index >= 0)
            {
                SimpleCorpsInfo corpsInfo = corpModel.CorpList[UI.listTBG.index];
                if (mChatModel == null)
                {
                    //mChatModel = (Singleton.getObj(typeof(ChatModel)) as ChatModel);
                    mChatModel = ChatModel.Ins;
                }
                //mChatModel.SaveZuiJinLianXiRen(corpsInfo.presidentId.ToString(), corpsInfo.presidentName, corpsInfo.presidentLevel.ToString(), corpsInfo.presidentTplId.ToString());
                //RelationView relationView = (RelationView)WndManager.open(GlobalConstDefine.RelationView_Name, "ChatWithCorpsMember");
                mChatModel.OpenRelationViewAndChat(corpsInfo.presidentId.ToString(), corpsInfo.presidentName, corpsInfo.presidentLevel.ToString(), corpsInfo.presidentTplId.ToString());
            }
        }

        private void clickShenQing()
        {
            if (UI.listTBG.index >= 0)
            {
                if (UI.shenqingBtnText.text == LangConstant.SHENQING_JIARU)
                {
                    CorpsCGHandler.sendCGClickCorpsFunction(corpModel.CorpList[UI.listTBG.index].corpsId, CorpFuncIdDef.SHENQING_JIARU);
                }
                else if (UI.shenqingBtnText.text == LangConstant.CHEXIAO_SHENQING)
                {
                    CorpsCGHandler.sendCGClickCorpsFunction(corpModel.CorpList[UI.listTBG.index].corpsId, CorpFuncIdDef.CHEXIAO_SHENQING);
                }
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.PLEASE_SELECT_CORP);
            }
        }

        private void clickCreate()
        {
            createCorpView.showCreate();
        }

        private void clickClose()
        {
            hide();
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            UI.Show();
            int hascorp = Human.Instance.PropertyManager.getIntProp(RoleBaseIntProperties.HAS_CORPS);
            UI.yijianShenqing.gameObject.SetActive(hascorp == 0 ? true : false);
            UI.shenqingJiaru.gameObject.SetActive(hascorp == 0 ? true : false);
            UI.chuangjianBangPai.gameObject.SetActive(hascorp == 0 ? true : false);
            updateCorpsList();
            app.main.GameClient.ins.OnBigWndShown();
            SetChildVisible(UI.createUI.gameObject,false);
        }
        
        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            UI.Hide();
            app.main.GameClient.ins.OnBigWndHidden();
        }

        public void updateCorpsList(RMetaEvent e = null)
        {
            if (corpItemList == null)
            {
                corpItemList = new List<CorpListItemScript>();
            }
            UI.defaultListItemUI.gameObject.SetActive(false);
            UI.listTBG.ClearToggleList();

            ScrollRect sr = UI.liebiaoGrid.transform.parent.GetComponent<ScrollRect>();
            if (scrollRect == null)
            {
                scrollRect = ScrollerManager.Ins.createScroll(sr, UI.defaultListItemUI.gameObject
                    , UI.liebiaoGrid.gameObject, addOnePage);
            }
            scrollRect.setItemNum(10, corpModel.CorpList.Count);

            UI.gongGaoText.text = "";
            UI.shenqingBtnText.text = LangConstant.SHENQING_JIARU;
            UI.shenqingJiaru.interactable = false;
            UI.lianxiBangzhu.interactable = false;

            UI.pageturner.MaxValue = CorpModel.Ins.CorpListPanel.getMaxPageNum();
            UI.pageturner.Value = CorpModel.Ins.CorpListPanel.getCurrPage()-1;
        }

        private IEnumerator addOnePage(int startIndex, int count)
        {
            for (int i = startIndex; i < startIndex + count; i++)
            {
                if (i >= corpItemList.Count)
                {
                    //BangPaiListItemUI item = GameObject.Instantiate(UI.defaultListItemUI);
                    //item.transform.SetParent(UI.liebiaoGrid.transform);
                    //item.transform.localScale = Vector3.one;
                    //item.gameObject.SetActive(true);
                    CorpListItemScript script = new CorpListItemScript(scrollRect.goList[i].GetComponent<BangPaiListItemUI>());
                    corpItemList.Add(script);
                }
                corpItemList[i].UI = scrollRect.goList[i].GetComponent<BangPaiListItemUI>();
                corpItemList[i].UI.gameObject.SetActive(true);
                corpItemList[i].UI.SetIndex(i);
                UI.listTBG.AddToggle(corpItemList[i].UI.toggle);
                corpItemList[i].setCorpListData(corpModel.CorpList[i], i + 1);
                corpItemList[i].UI.toggle.isOn = false;
                if (i % 6 == 0)
                {
                    yield return 0;
                }
            }
            UI.listTBG.UnSelectAll();
            //for (int i = corpModel.CorpList.Count; i < corpItemList.Count; i++)
            //{
            //    corpItemList[i].UI.toggle.isOn = false;
            //    corpItemList[i].UI.gameObject.SetActive(false);
            //}
        }

        public void updateCurrentCorp(RMetaEvent e)
        {
            if (UI.listTBG.index >= 0)
            {
                selectOneCorp(UI.listTBG.index);
                SimpleCorpsInfo currentCorpInfo = e.data as SimpleCorpsInfo;
                corpItemList[UI.listTBG.index].setCorpListData(currentCorpInfo, UI.listTBG.index + 1);
            }
        }

        public void updateRoleMoney(RMetaEvent e)
        {
            if (createCorpView != null) createCorpView.updateRoleMoney();
        }

        public void searchResult(RMetaEvent e)
        {
            ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.CORP_NOT_EXSIT);
        }
        
        public override void Destroy()
        {
            corpModel.removeChangeEvent(CorpModel.UPDATE_CORPSLIST, updateCorpsList);
            corpModel.removeChangeEvent(CorpModel.UPDATE_CURRENT_CORP, updateCurrentCorp);
            corpModel.removeChangeEvent(CorpModel.UPDATE_SEARCH_RESULT, searchResult);
            petModel.removeChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateRoleMoney);

            findInputText=null;

            if (createCorpView!=null)
            {
                createCorpView.Destroy();
            }

            if (corpItemList != null)
            {
                for (int i = 0; i < corpItemList.Count; i++)
                {
                    corpItemList[i].Destroy();
                    corpItemList[i] = null;
                }
                corpItemList.Clear();
                corpItemList = null;
            }

            scrollRect=null;

            base.Destroy();
            UI = null;
        }

    }

}
