using UnityEngine;
using app.item;

namespace app.tips
{
    public class EquipTips : BaseTips
    {
        private static EquipTips _ins;
        private const int equipTipsWidth = 480;

        //[Inject(ui = "EquipTips")]
        //public GameObject ui;
        
        private ItemDetailData mData;
        private TipsBtnType tipsBtnType;
        private int mshowPositionX;

        private ItemDetailData mCompareData;
        private GameObject mCompareui;

        private bool mShowButtons = true;

        public static EquipTips Ins
        {
            get
            {
                if (_ins == null)
                {
                    //_ins = new EquipTips();
                    _ins = Singleton.GetObj(typeof(EquipTips)) as EquipTips;
                }
                return _ins;
            }
        }

        public ItemDetailData EquipData
        {
            get { return mData; }
        }

        public ItemDetailData CompareData
        {
            get { return mCompareData; }
        }

        private static EquipTipsManager compareTips;
        
        public EquipTips()
        {
            uiName = "EquipTips";
        }

        public override void initWnd()
        {
            base.initWnd();
        }

        public void ShowTips(ItemDetailData data,bool showButtons = true, TipsBtnType tipsBtnTypev = TipsBtnType.NORMAL, int showpositionx = 0, int delayMillisecond = 0)
        {
            if (data==null)
            {
                return;
            }
            mCompareData = null;
            tipsBtnType = tipsBtnTypev;
            mData = data;
            mshowPositionX = showpositionx;
            mShowButtons = showButtons;
            if (delayMillisecond <= 0)
            {
                preLoadUI();
            }
            else
            {
                TimerManager.Ins.createTimer(delayMillisecond, delayMillisecond, null, OnDelayTimeUp).start();
            }
        }
        
        private void OnDelayTimeUp(RTimer timer)
        {
            preLoadUI();
        }

        public void ShowCompareTips(ItemDetailData weardata,ItemDetailData bagdata, int delayMillisecond = 0)
        {
            if (weardata == null||bagdata==null)
            {
                return;
            }
            mCompareData = weardata;
            tipsBtnType = TipsBtnType.NORMAL;
            mData = bagdata;
            mshowPositionX = -equipTipsWidth / 2;

            if (delayMillisecond <= 0)
            {
                preLoadUI();
            }
            else
            {
                TimerManager.Ins.createTimer(delayMillisecond, delayMillisecond, null, OnDelayTimeUp).start();
            }
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            
            if (mCompareData!=null)
            {
                EquipTipsManager.Ins.setTipsData(ui, mData,mShowButtons, TipsBtnType.NORMAL, equipTipsWidth / 2);
                if (mCompareui==null)
                {
                    mCompareui = GameObject.Instantiate(ui);
                    mCompareui.transform.SetParent(ui.transform.parent);
                    mCompareui.transform.localScale = Vector3.one;
                }
                mCompareui.SetActive(true);
                if (compareTips == null)
                {
                    compareTips = new EquipTipsManager();
                }
                compareTips.setTipsData(mCompareui, mCompareData,true, TipsBtnType.NORMAL, -equipTipsWidth / 2);
                BaseWnd.hideBgImage(mCompareui);
                BaseWnd.setBgImageFullScreen(ui);
                mCompareui.transform.SetAsLastSibling();
            }
            else
            {
                EquipTipsManager.Ins.setTipsData(ui, mData, mShowButtons,tipsBtnType, mshowPositionX);
            }
        }

        public override void hide(RMetaEvent e = null)
        {
            if (mCompareui!=null) mCompareui.SetActive(false);
            base.hide(e);
        }

        public override void Destroy()
        {
            mData = null;

            mCompareData = null;
            GameObject.DestroyImmediate(mCompareui,true);
            mCompareui = null;
            base.Destroy();
            mCompareui = null;
            EquipTipsManager.Ins.ui = null;
            EquipTipsManager.Ins.UI = null;
            
        }
    }
}