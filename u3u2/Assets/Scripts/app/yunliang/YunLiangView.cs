using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using app.bag;
using app.model;
using app.net;
using app.tips;

namespace app.yunliang
{
    public class YunLiangView : BaseWnd
    {
        //[Inject(ui = "YunLiangUI")]
        //public GameObject ui;
        public YunLiangModel yunliangModel;
        public BagModel bagModel;

        private YunLiangUI UI;
        private List<YunLiangItemScript> yunliangItemList;
        private MoneyItemScript mShuaxinCost = null;

        public YunLiangView()
        {
            uiName = "YunLiangUI";
        }

        public override void initWnd()
        {
            base.initWnd();
            yunliangModel = YunLiangModel.Ins;
            yunliangModel.addChangeEvent(YunLiangModel.updateYunLiangPanel, updatePanel);
            yunliangModel.addChangeEvent(YunLiangModel.updateOneYunLiang, updatePanel);
            bagModel = BagModel.Ins;
            bagModel.addChangeEvent(BagModel.UPDATE_BAG_EVENT, updateShuaXinBtn);
            bagModel.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, updateShuaXinBtn);
            UI = ui.AddComponent<YunLiangUI>();
            UI.Init();
            UI.closeBtn.SetClickCallBack(clickClose);
            UI.shuaxinBtn.SetClickCallBack(clickShuaxin);
            UI.shuomingBtn.SetClickCallBack(clickShuoming);

            yunliangItemList = new List<YunLiangItemScript>();
            for (int i = 0; i < UI.renwuList.Count; i++)
            {
                YunLiangItemScript yunliang = new YunLiangItemScript(UI.renwuList[i]);
                yunliangItemList.Add(yunliang);
            }
            mShuaxinCost = new MoneyItemScript(UI.shuaxinCost);
            mShuaxinCost.setEmpty();
        }

        private void clickShuaxin()
        {
            ForagetaskCGHandler.sendCGForagetaskRefresh();
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            updatePanel();
            app.main.GameClient.ins.OnBigWndShown();
        }

        public override void hide(RMetaEvent e = null)
        {
            for (int i = 0; i < UI.renwuList.Count; i++)
            {
                yunliangItemList[i].HideAvatarModel();
            }
            base.hide(e);
            app.main.GameClient.ins.OnBigWndHidden();
        }

        public void updatePanel(RMetaEvent e = null)
        {
            UI.leftTimes.text = yunliangModel.PanelData.getFinishTimes() + " / " + yunliangModel.PanelData.getTotalTimes();
            setQuestList(yunliangModel.PanelData.getBackupForageTaskInfos().ToList());
            updateShuaXinBtn();
        }

        public void updateShuaXinBtn(RMetaEvent e = null)
        {
            int id = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.FORAGE_TASK_REFRESH_ITEMID);
            int num = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.FORAGE_TASK_REFRESH_ITEMNUM);
            mShuaxinCost.setItemData(id, num);
        }

        private void setQuestList(List<BackupForageTaskInfoData> questlistv)
        {
            if (questlistv == null)
            {
                UI.renwuItemGrid.SetActive(false);
                return;
            }
            UI.renwuItemGrid.SetActive(true);
            for (int i = 0; i < UI.renwuList.Count; i++)
            {
                UI.renwuList[i].gameObject.SetActive(false);
            }
            for (int i = 0; questlistv != null && i < questlistv.Count; i++)
            {
                UI.renwuList[i].gameObject.SetActive(true);
                yunliangItemList[i].setQuestData(questlistv[i]);
            }
        }

        private void clickClose()
        {
            hide();
        }

        private void clickShuoming()
        {
            PopInfoWnd.Ins.ShowInfo("1.每天可运粮3次\n2.运粮中被怪物打败,则扣除一定奖励\n3.每日0点重置运粮次数\n4.粮车品质越高，运送成功奖励越高");
        }

        public override void Destroy()
        {
            if (yunliangItemList != null)
            {
                for (int i = 0; i < UI.renwuList.Count; i++)
                {
                    yunliangItemList[i].Destroy();
                }
                yunliangItemList.Clear();
                yunliangItemList = null;
            }

            yunliangModel.removeChangeEvent(YunLiangModel.updateYunLiangPanel, updatePanel);
            yunliangModel.removeChangeEvent(YunLiangModel.updateOneYunLiang, updatePanel);
            bagModel.removeChangeEvent(BagModel.UPDATE_BAG_EVENT, updateShuaXinBtn);
            bagModel.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, updateShuaXinBtn);
            if (mShuaxinCost != null)
            {
                mShuaxinCost.Destroy();
                mShuaxinCost = null;
            }

            base.Destroy();
            UI = null;
        }
    }
}
