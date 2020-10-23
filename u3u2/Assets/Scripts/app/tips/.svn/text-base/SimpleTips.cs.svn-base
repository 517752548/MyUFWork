using UnityEngine;

namespace app.tips
{
    public class SimpleTips : BaseTips
    {
        private static SimpleTips _ins;

        //[Inject(ui = "simpleTips")]
        //public GameObject ui;

        public SimpleTipsUI UI;

        private string _str;
        private int _offset = 20;

        public SimpleTips()
        {
            bgMaskAlpha = 0;
            uiName = "simpleTips";
        }

        public static SimpleTips Ins
        {
            get
            {
                if (_ins == null)
                {
                    //_ins = new SimpleTips();
                    _ins = Singleton.GetObj(typeof(SimpleTips)) as SimpleTips;
                }
                return _ins;
            }
        }

        public void ShowTips(string str)
        {
            _str = str;
            preLoadUI();
        }

        public override void initUI()
        {
            base.initUI();
            UI = ui.AddComponent<SimpleTipsUI>();
            UI.Init();
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            setData();
        }

        /*
    protected override void clickSpaceArea(GameObject go)
    {
        hide();
    }
    */

        private void setData()
        {
            if (UI!=null)
            {
                UI.tipsText.text = _str;
                UI.textSizeFilter.SetLayoutHorizontal();
                UI.textSizeFilter.SetLayoutVertical();
                Vector2 currentV2 = UI.tipsBg.rectTransform.sizeDelta;
                currentV2.x = UI.tipsText.preferredWidth + 20;
                currentV2.y = UI.tipsText.preferredHeight + 20;
                UI.tipsBg.rectTransform.sizeDelta = currentV2;
            }
        }
    }
}