using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.net;
using app.utils;
using app.zone;

using UnityEngine;

namespace app.shitu
{
    public class JieChuTuDiView:BaseWnd
    {
        //[Inject(ui = "JieChuTuDiUI")]
        //public GameObject ui;

        public JieChuTuDiUI UI;

        /// <summary>
        /// 服务器数据对象
        /// </summary>
        public ShiTuModel shituModel;
        /// <summary>
        /// 当前选择的徒弟信息
        /// </summary>
        private LowermanInfo tudiInfo;

        public JieChuTuDiView()
        {
            uiName = "JieChuTuDiUI";
        }
        /*
        public override void initUILayer(WndType uilayer = WndType.FirstWND)
        {
            base.initUILayer(WndType.PopWND);
        }
        */
        public override void initWnd()
        {
            base.initWnd();
            
            shituModel = ShiTuModel.Ins;
            shituModel.addChangeEvent(ShiTuModel.UPDATE_SHITU_INFO, UpdateShiTuInfo);
            
            UI = ui.AddComponent<JieChuTuDiUI>();
            UI.Init();
            
            UI.cancelBtn.SetClickCallBack(closewnd);
            UI.sureBtn.SetClickCallBack(sureJieChu);
            UI.xuanzeTBG.ReSelected = true;
            UI.xuanzeTBG.SelectDefault = false;
            UI.xuanzeTBG.AllTabCloseHandler = nonSelect;
            UI.xuanzeTBG.TabChangeHandler = selectTudi;
        }

        private void closewnd()
        {
            hide();
        }

        private void sureJieChu()
        {
            if (tudiInfo==null)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("请选择要解除师徒关系的徒弟");
                return;
            }
            int cost = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.JIECHU_SHITU_COST);
            MoneyCheck.Ins.Check(CurrencyTypeDef.GOLD,cost,sureHandler);
        }

        private void sureHandler(RMetaEvent e)
        {
            OvermanCGHandler.sendCGForceFireOverman(tudiInfo.uuid);
            hide();
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            int cost = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.JIECHU_SHITU_COST);
            string tishi = "强制解除师徒关系需要扣除" + cost + "银票，请选择要解除的徒弟";
            UI.jiechuHuaFei.text = tishi;
            UpdateShiTuInfo();
        }

        public void UpdateShiTuInfo(RMetaEvent e=null)
        {
            int len = 0;
            if (shituModel.MyShiTuInfo.getLowerList().Length > 0)
            {
                len = shituModel.MyShiTuInfo.getLowerList().Length;
                for (int i = 0; i < UI.tudiList.Count; i++)
                {
                    if (i < len)
                    {
                        //头像
                        //PathUtil.Ins.SetPetIconSource(UI.tudiList[i].icon,shituModel.MyShiTuInfo.getLowerList()[i].templateId);
                        PathUtil.Ins.SetHeadIcon(UI.tudiList[i].icon, shituModel.MyShiTuInfo.getLowerList()[i].templateId);
                        //名字
                        UI.tudiList[i].Name.text = shituModel.MyShiTuInfo.getLowerList()[i].humanName;
                        //等级
                        UI.tudiList[i].num.text = "Lv."+shituModel.MyShiTuInfo.getLowerList()[i].level;

                        UI.tudiList[i].gameObject.SetActive(true);
                        UI.tudiList[i].SelectedToggle.isOn=false;
                    }
                }
            }
            for (int i = len; i < UI.tudiList.Count; i++)
            {
                UI.tudiList[i].SelectedToggle.isOn = false;
                UI.tudiList[i].gameObject.SetActive(false);
            }
        }

        public void selectTudi(int tudiIndex)
        {
            if (tudiIndex >= 0 && tudiIndex < shituModel.MyShiTuInfo.getLowerList().Length)
            {
                tudiInfo = shituModel.MyShiTuInfo.getLowerList()[tudiIndex];
            }
        }

        public void nonSelect()
        {
            tudiInfo = null;
        }
        
        public override void Destroy()
        {
            shituModel.removeChangeEvent(ShiTuModel.UPDATE_SHITU_INFO, UpdateShiTuInfo);
            base.Destroy();
            UI = null;
        }
    }
}
