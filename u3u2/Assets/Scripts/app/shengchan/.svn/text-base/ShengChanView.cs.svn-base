using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.pet;
using UnityEngine;

namespace app.shengchan
{
    public class ShengChanView:BaseWnd
    {
        //[Inject(ui = "ShengChanUI")]
        //public GameObject ui;

        private ShengChanUI UI;

        public CaiKuangScript caikuang;

        public ShengChanView()
        {
            uiName = "ShengChanUI";
        }

        public override void initWnd()
        {
            base.initWnd();
            UI = ui.AddComponent<ShengChanUI>();
            UI.Init();

            UI.panelTBG.TabChangeHandler = changeTab;
            UI.closeBtn.SetClickCallBack(clickClose);
        }

        private void clickClose()
        {
            hide();
        }

        private void changeTab(int tab)
        {
            switch (tab)
            {
                case 0:
                    if (caikuang ==null)
                    {
                        caikuang = new CaiKuangScript(UI.caikuangUI);
                    }
                    UI.panelTitle.text = "采 矿";
                    UI.caikuangUI.gameObject.SetActive(true);
                    caikuang.UpdateList();
                    break;
            }
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);

            UI.panelTBG.SetIndexWithCallBack(0);
            app.main.GameClient.ins.OnBigWndShown();
        }

        public override void hide(RMetaEvent e = null)
        {
            if (caikuang!=null)
            {
                caikuang.hide();
            }
            app.main.GameClient.ins.OnBigWndHidden();
            base.hide(e);
        }
        
        public override void Destroy()
        {
            if (caikuang != null)
            {
                caikuang.Destroy();
                caikuang = null;
            }
            base.Destroy();
            UI = null;
        }
    }
    
}
