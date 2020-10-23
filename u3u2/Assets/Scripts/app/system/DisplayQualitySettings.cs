using UnityEngine;
using UnityEngine.Events;
using app.state;

namespace app.system
{
    public class DisplayQualitySettings : AbsMonoBehaviour
    {
        public const int DISPLAY_QUALITY_HIGH = 0;
        public const int DISPLAY_QUALITY_NORMAL = 1;
        public const int DISPLAY_QUALITY_LOW = 2;
        public const int EXPECTED_FPS = 25;
        public const int CHECK_QUALITY_INTERVAL_SECONDS = 30;

        private float mStartCheckTime = 0f;
        private long mFpsUnexpectedCount = 0;
        private long mTotalCheckedCount = 0;
        private float mTotalCheckedTime = 0.0f;

        private bool mUserSelectedQuality = false;

        private int mCurDisplayQuality = 0;

        private int mSysResolutionWidth = 0;
        private int mSysResolutionHeight = 0;

        private bool mIsDisplayQualityInited = false;
        private static DisplayQualitySettings mIns = null;

        public static DisplayQualitySettings ins
        {
            get
            {
                if (mIns == null)
                {
                    mIns = new DisplayQualitySettings();
                }
                return mIns;
            }
        }

        public DisplayQualitySettings()
        {
			mSysResolutionWidth = Screen.currentResolution.width;
			mSysResolutionHeight = Screen.currentResolution.height;
            string displayQualityStr = PlayerDataManager.Ins.GetPlayerData(PlayerDataKeyDef.CUSTOM_DATA).getData(PlayerDataKeyDef.CUSTOM_DATA_DISPLAY_QUALITY);
            if (!string.IsNullOrEmpty(displayQualityStr))
            {
                int.TryParse(displayQualityStr, out mCurDisplayQuality);
            }
        }

        public void InitDisplayQuality()
        {
            StateDef curState = StateManager.Ins.getCurState().state;
            if (curState == StateDef.zoneState || curState == StateDef.battleState)
            {
                UpdateCurDisplayQuality(mCurDisplayQuality);
                mIsDisplayQualityInited = true;
            }
        }

        public override void DoUpdate(float delta)
        {
            if (!mIsDisplayQualityInited)
            {
                InitDisplayQuality();
            }

            if (mIsDisplayQualityInited)
            {
                float fps = Time.timeScale / Time.deltaTime;
                if (fps < EXPECTED_FPS)
                {
                    mFpsUnexpectedCount++;
                }
                mTotalCheckedCount++;
                mTotalCheckedTime += delta;

                if (!mUserSelectedQuality)
                {
                    StateDef curState = StateManager.Ins.getCurState().state;
                    if ((curState == StateDef.zoneState || curState == StateDef.battleState) && isCurDisplayQualityTooHigh)
                    {
                        if (!WndManager.Ins.IsWndShowing(typeof(DisplayQualitySettingView)))
                        {
                            ShowDisplayQualitySettingPanel();
                        }
                    }
                }
            }
        }

        public bool isCurDisplayQualityTooHigh
        {
            get
            {
                if (mTotalCheckedTime >= CHECK_QUALITY_INTERVAL_SECONDS)
                {
                    return (float)mFpsUnexpectedCount / (float)mTotalCheckedCount > 0.5f;
                }
                return false;
            }
        }

        public int currentDisplayQuality
        {
            get
            {
                return mCurDisplayQuality;
            }
        }

        private void ChangeToLowDisplayQuality(int quality)
        {
            mUserSelectedQuality = true;
            UpdateCurDisplayQuality(quality);
        }

        private void StayInCurDisplayQuality()
        {
            mUserSelectedQuality = true;
        }

        public void UpdateCurDisplayQuality(int quality)
        {
            switch (quality)
            {
                case 0:
                    Screen.SetResolution(mSysResolutionWidth, mSysResolutionHeight, true);
                    break;
                case 1:
                    Screen.SetResolution((int)(mSysResolutionWidth * 0.8f), (int)(mSysResolutionHeight * 0.8f), true);
                    break;
                case 2:
                    Screen.SetResolution((int)(mSysResolutionWidth * 0.5f), (int)(mSysResolutionHeight * 0.5f), true);
                    break;
                default:
                    break;
            }
            mCurDisplayQuality = quality;
            PlayerData data = PlayerDataManager.Ins.GetPlayerData(PlayerDataKeyDef.CUSTOM_DATA);
            data.addData(PlayerDataKeyDef.CUSTOM_DATA_DISPLAY_QUALITY, mCurDisplayQuality.ToString());
            PlayerDataManager.Ins.SaveData(PlayerDataKeyDef.CUSTOM_DATA, data);
        }

        public void ShowDisplayQualitySettingPanel()
        {
            DisplayQualitySettingView view = (DisplayQualitySettingView)(WndManager.open(GlobalConstDefine.DisplayQualitySettingView_Name));
            view.onOkBtnClicked = ChangeToLowDisplayQuality;
            view.onCancelBtnClicked = StayInCurDisplayQuality;
        }
    }

    public class DisplayQualitySettingView : BaseWnd
    {
        //[Inject(ui = "DisplayQualitySettingUI")]
        //public GameObject ui;

        public DisplayQualitySettingUI UI;

        public UnityAction<int> onOkBtnClicked = null;
        public UnityAction onCancelBtnClicked = null;
        /*
        public override void initUILayer(WndType uilayer = WndType.FirstWND)
        {
            base.initUILayer(WndType.PopWND);
        }
        */
        
        public DisplayQualitySettingView()
        {
            uiName = "DisplayQualitySettingUI";
        }
        
        public override void initWnd()
        {
            base.initWnd();
            UI = ui.AddComponent<DisplayQualitySettingUI>();
            UI.Init();  
            UI.okBtn.SetClickCallBack(OnOkBtnClicked);
            UI.cancelBtn.SetClickCallBack(OnCancelBtnClicked);
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            UI.toggleGroup.SetIndexWithCallBack(DisplayQualitySettings.ins.currentDisplayQuality);
            UI.infoTips.SetActive(DisplayQualitySettings.ins.isCurDisplayQualityTooHigh);
        }

        private void OnOkBtnClicked()
        {
            if (onOkBtnClicked != null)
            {
                onOkBtnClicked(UI.toggleGroup.index);
            }

            base.hide();
        }

        private void OnCancelBtnClicked()
        {
            if (onCancelBtnClicked != null)
            {
                onCancelBtnClicked();
            }

            base.hide();
        }

        public override void hide(RMetaEvent e = null)
        {
            OnCancelBtnClicked();
            base.hide(e);
        }
    }
}