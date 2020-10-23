using app.config;
using app.main;
using app.pet;
using app.db;
using app.gameloading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace app.state
{
    public class InitUIState : StateBase
    {
        private List<KeyValuePair<string, LoadArgs>> mLoadingList = new List<KeyValuePair<string, LoadArgs>>();
        private string[] mPreloadUI = new string[]{};
        private mStep mCurStep = mStep.init;
        private int mCurLoadingIdx = 0;
        private bool mCurLoadingIdxLoaded = false;
        private int mCurCreatingIdx = 0;
        private int mUpdateCD = 0;

        private Transform mProgressBar = null;
        private Text mProgressBarLabel = null;
        private float mPgBarInitPositionX = 0.0f;

        private enum mStep
        {
            init,
            load,
            preinstui,
            alldone
        }

        public InitUIState()
        {
            this.state = StateDef.initUI;
        }

        public override void onEnter()
        {
            ClientLog.Log("==========InitUIState onEnter==========");
            base.onEnter();
            initUI();
        }

        /// <summary>
        /// 加载组件图集包，作为所有ui的依赖 需要先加载
        /// </summary>
        private void initUI()
        {
            ClientLog.Log("==========InitUIState initUI==========");
            UGUIConfig.init();
            ClientLog.Log("==========UGUIConfig init complete==========");
            
            if (ClientConfig.Ins.debug)
            {
                if (GameObject.Find("ScriptsRoot").GetComponent<GameInfoDisplay>() == null)
                {
                    GameObject.Find("ScriptsRoot").AddComponent<GameInfoDisplay>();
                }
            }

            mProgressBar = GameClient.ins.initViewProgressBar.transform;
            mProgressBarLabel = GameClient.ins.initViewProgressBarLabel.GetComponent<Text>();
            mPgBarInitPositionX = mProgressBar.localPosition.x;

            mCurStep = mStep.init;

            mLoadingList.Clear();
            if (ClientConfig.Ins.debug)
            {
                mLoadingList.Add(new KeyValuePair<string, LoadArgs>(PathUtil.Ins.GetUIPath("DebugPanel"),
                    LoadArgs.SLIMABLE));
                mLoadingList.Add(new KeyValuePair<string, LoadArgs>(PathUtil.Ins.GetUIPath("ProfilerPanel"),
                    LoadArgs.SLIMABLE));
            }
            mLoadingList.Add(new KeyValuePair<string, LoadArgs>(PathUtil.Ins.GetFontPath(CommonDefines.DEFAULT_FONT_NAME), LoadArgs.NONE));
            mLoadingList.Add(new KeyValuePair<string, LoadArgs>(PathUtil.Ins.uiDependenciesPath, LoadArgs.NONE));
            mLoadingList.Add(new KeyValuePair<string, LoadArgs>(PathUtil.Ins.uiEffectsPath, LoadArgs.NONE));
            mLoadingList.Add(new KeyValuePair<string, LoadArgs>(PathUtil.Ins.GetUIPath("CommonUI"), LoadArgs.NONE));
            mLoadingList.Add(new KeyValuePair<string, LoadArgs>(PathUtil.Ins.GetUITexturePath(PreLoadingView.Ins.bgName, PathUtil.LOADING_BG), LoadArgs.SLIMABLE));
            mLoadingList.Add(new KeyValuePair<string, LoadArgs>("effectDeps.abl", LoadArgs.NONE));

            mCurLoadingIdx = 0;
            mCurLoadingIdxLoaded = false;
            mCurStep = mStep.load;
            KeyValuePair<string, LoadArgs> loadItem = mLoadingList[mCurLoadingIdx];
            GameClient.ins.SimpleLoad(loadItem.Key, OnLoadOneResComplete, loadItem.Value);
        }

        private void OnLoadOneResComplete(RMetaEvent e)
        {
            SourceManager.Ins.ignoreDispose(mLoadingList[mCurLoadingIdx].Key);
            mCurLoadingIdxLoaded = true;
            if (mCurLoadingIdx == mLoadingList.Count - 1)
            {
                LoadListEnd(e);
            }
        }

        private void LoadListProgress(RMetaEvent e)
        {
            List<object> ary = e.data as List<object>;
            LoadInfo loadInfo = ary[2] as LoadInfo;
            ClientLog.Log("==========InitUIState LoadListProgress " + loadInfo.urlPath + " ==========");
        }

        private void LoadListEnd(RMetaEvent e)
        {
            ClientLog.Log("==========InitUIState LoadListEnd==========");
            SourceManager.Ins.defaultFont = SourceManager.Ins.GetAsset<Font>(PathUtil.Ins.GetFontPath(CommonDefines.DEFAULT_FONT_NAME));
            if (ClientConfig.Ins.debug)
            {
                ClientLog.Log("==========InitUIState LogPanel preLoadUI==========");
            }
            PreInstanteAssets();
        }

        private void PreInstanteAssets()
        {
            ClientLog.Log("==========InitUIState PreInstanteAssets==========");

            if (mPreloadUI.Length > 0)
            {
                mCurStep = mStep.preinstui;
                mCurCreatingIdx = 0;
            }
            else
            {
                mCurStep = mStep.alldone;
            }
        }

        

        public override void onLeave(StateDef nextState)
        {
            base.onLeave(nextState);
            mProgressBar = null;
            mProgressBarLabel = null;
        }

        public override void onUpdate()
        {
            base.onUpdate();
            if (mCurStep == mStep.init)
            {
                return;
            }

            if (mCurStep == mStep.load)
            {
                if (mUpdateCD > 0)
                {
                    mUpdateCD--;
                    return;
                }
                if (mCurLoadingIdxLoaded)
                {
                    //UpdatePgBar((float)mCurLoadingIdx / (float)mLoadingList.Count * 0.5f, "正在加载本地资源  " + mLoadingList[mCurLoadingIdx].Key/* + " [" + mCurLoadingIdx + "/" + mLoadingList.Count + "]"*/);
                    UpdatePgBar((float)mCurLoadingIdx / (float)mLoadingList.Count * 0.5f, "初始化游戏");
                    mCurLoadingIdx++;
                    mCurLoadingIdxLoaded = false;
                    KeyValuePair<string, LoadArgs> loadItem = mLoadingList[mCurLoadingIdx];
                    GameClient.ins.SimpleLoad(loadItem.Key, OnLoadOneResComplete, loadItem.Value);

#if !UNITY_EDITOR
#if UNITY_ANDROID
                    mUpdateCD = 1;
#else
                    mUpdateCD = 1;
#endif
#endif
                }
            }
            else if (mCurStep == mStep.preinstui)
            {
                if (mUpdateCD > 0)
                {
                    mUpdateCD--;
                    return;
                }
                string uipath = PathUtil.Ins.GetUIPath(mPreloadUI[mCurCreatingIdx]);
                //UpdatePgBar(0.5f + (float)(mCurCreatingIdx) / (float)mPreloadUI.Length * 0.5f, "正在预处理本地资源  " + mPreloadUI[mCurCreatingIdx] + " [" + (mCurCreatingIdx + 1) + "/" + mPreloadUI.Length + "]");
                UpdatePgBar(0.5f + (float)(mCurCreatingIdx) / (float)mPreloadUI.Length * 0.5f, "初始化游戏");
                UICreator.ins.PreCacheUI(uipath);
                if (mCurCreatingIdx < mPreloadUI.Length - 1)
                {
                    mCurCreatingIdx++;
                }
                else
                {
                    mCurStep = mStep.alldone;
                }
#if !UNITY_EDITOR
#if UNITY_ANDROID
                    mUpdateCD = 15;
#else
                    mUpdateCD = 5;
#endif
#endif
            }
            else if (mCurStep == mStep.alldone)
            {
                mProgressBar.parent.parent.gameObject.SetActive(false);
                StateManager.Ins.changeState(StateDef.login);
            }
        }

        private void UpdatePgBar(float percent, string tips)
        {
            float len = -mPgBarInitPositionX;
            mProgressBar.localPosition = new Vector3(mPgBarInitPositionX + len * percent, 0, 0);
            if (tips != null)
            {
                mProgressBarLabel.text = tips;
            }
        }
    }
}
