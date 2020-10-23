using System.Collections.Generic;
using UnityEngine;

namespace app.gameloading
{
    /// <summary>
    /// 游戏内部 任何需要预加载的地方，需要显示loading场景的地方，用此loading场景
    /// </summary>
    class PreLoadingView : BaseWnd
    {
        //[Inject(ui = "loadingPanel")]
        //public GameObject ui;
        public string bgName { get; private set; }
        private bool mAutoClose = false;
        private LoadingPanelUI UI;

        private static PreLoadingView _ins;

        internal static PreLoadingView Ins
        {
            get
            {
                if (_ins == null)
                {
                     _ins = (Singleton.GetObj(typeof(PreLoadingView)) as PreLoadingView);
                    //_ins = new PreLoadingView();
                }
                return _ins;
            }
        }

        private RMetaEventHandler completeCallBack;
        private RMetaEventHandler progressCallBack;

        private string loadingText;
        private List<object[]> loadList;
        //本次的背景名称
        //下次的背景名称
        //private string nextBgName = "0";
        //private int maxBgNumber = 2;

        public PreLoadingView()
        {
            uiName = "loadingPanel";
            if (Random.Range(0, 10) > 5)
            {
                bgName = "1";
            }
            else
            {
                bgName = "0";
            }
        }

        public override void initWnd()
        {
            base.initWnd();
            UI = ui.AddComponent<LoadingPanelUI>();
            UI.Init();
            UI.loadingPG.MaxValue = 1;
            //UI.loadingbg.texture = SourceManager.Ins.GetAsset<Texture>(PathUtil.Ins.GetUITexturePath(currentBgName, PathUtil.LOADING_BG));
        }

        public override void show(RMetaEvent e = null)
        {
            base.show();
            //使用上次加载的背景
            //ClientLog.LogWarning("正在使用！" + nextBgName);
            //currentBgName = nextBgName;
            string bgpath = PathUtil.Ins.GetUITexturePath(bgName, PathUtil.LOADING_BG);
            /*
            Texture2D texture=null;
            if (SourceManager.Ins.hasAssetBundle(bgpath))
            {
                texture = SourceManager.Ins.GetAsset<Texture2D>(bgpath);
            }
            else
            {
                SourceLoader.Ins.load(bgpath, bgReloadEnd);
            }
            */
            Texture2D texture = SourceManager.Ins.GetAsset<Texture2D>(bgpath);
            if (texture!=null) UI.loadingbg.texture = texture;
            float orgWidth = 960;
            float orgHeight = 640;
            
            float widthScale = UGUIConfig.UISpaceWidth / orgWidth;
            float heightScale = UGUIConfig.UISpaceHeight / orgHeight;
            float scale = Mathf.Max(widthScale, heightScale);
            
            UI.loadingbg.rectTransform.sizeDelta = new Vector2(orgWidth * scale, orgHeight * scale);
            //加载下一个背景
            //nextBgName = Mathf.FloorToInt(UnityEngine.Random.Range(0, maxBgNumber)).ToString();
            //while (nextBgName == currentBgName)
            //{
                //nextBgName = UnityEngine.Random.Range(0, maxBgNumber).ToString();
            //}
            //string nextBgPath = PathUtil.Ins.GetUITexturePath(nextBgName, PathUtil.LOADING_BG);
            //SourceManager.Ins.ignoreDispose(nextBgPath);
            //ClientLog.LogWarning("下次使用！" + nextBgName);
            //loadList.Add(nextBgPath);

            UI.loadingText.text = loadingText;
            //SourceLoader.Ins.load(nextBgPath, onNextBgLoadComplete);
            SourceLoader.Ins.loadList(loadList, onComplete, onProgress);
        }
        /*
        private void bgReloadEnd(RMetaEvent e)
        {
            string bgpath = PathUtil.Ins.GetUITexturePath(currentBgName, PathUtil.LOADING_BG);
            Texture2D texture = null;
            if (SourceManager.Ins.hasAssetBundle(bgpath))
            {
                texture = SourceManager.Ins.GetAsset<Texture2D>(bgpath);
            }
            if (texture != null) UI.loadingbg.texture = texture;
        }
        
        private void onNextBgLoadComplete(RMetaEvent e)
        {
            SourceLoader.Ins.loadList(loadList, onComplete, onProgress);
        }
        */

        /// <summary>
        /// 加载列表资源
        /// </summary>
        /// <param name="loadListv">资源路径列表List<object[]{url, LoadArgs, LoadContentType}></param>
        /// <param name="loadingTextv">进度条上的文本</param>
        /// <param name="completeHandler">列表加载完成回调</param>
        /// <param name="progressHandler">列表加载进度回调</param>
        /// <param name="autoClose">列表加载完成后自动关闭界面</param>
        public void startLoading(List<object[]> loadListv, string loadingTextv, RMetaEventHandler completeHandler, RMetaEventHandler progressHandler, bool autoClose = true)
        {
            loadList = loadListv;
            loadingText = loadingTextv;
            completeCallBack = completeHandler;
            progressCallBack = progressHandler;
            mAutoClose = autoClose;
            preLoadUI(null);
        }

        private void onComplete(RMetaEvent e)
        {
            UI.loadingPG.Value = 1f;
            //RTimer timer = TimerManager.Ins.createTimer(1000, 1 * 1000, null, doCallBack);
            //timer.start();

            if (completeCallBack != null)
            {
                completeCallBack(e);
            }
            if (mAutoClose)
            {
                //WndManager.Ins.close(GlobalConstDefine.PreLoadingView_Name);
                hide(null);
            }
        }

        public override void hide(RMetaEvent e = null)
        {
            if (isShown)
            {
                //ClientLog.LogWarning("回收！" + currentBgName);
                string bgpath = PathUtil.Ins.GetUITexturePath(bgName, PathUtil.LOADING_BG);
                SourceManager.Ins.removeReference(bgpath);
                SourceManager.Ins.unignoreDispose(bgpath);
                base.hide(e);
            }
        }

        private void doCallBack(RTimer r)
        {
            if (completeCallBack != null)
            {
                completeCallBack(null);
            }
            if (mAutoClose)
            {
                //WndManager.Ins.close(GlobalConstDefine.PreLoadingView_Name);
                hide(null);
            }
        }

        private void onProgress(RMetaEvent e)
        {
            int a = (int)((e.data as List<object>)[0]);
            int b = (int)((e.data as List<object>)[1]);
            float percent = b > 0 ? (float)( a * 100 / b) / 100.0f : 0.0f;

            if (string.IsNullOrEmpty(loadingText))
            {
                if ((e.data as List<object>).Count == 3)
                {
                    LoadInfo loadinfo = ((e.data as List<object>)[2]) as LoadInfo;
                    if (loadinfo != null)
                    {
                        UI.loadingPG.label.text = loadinfo.urlPath + "(" + a + "/" + b + ")";
                    }
                }
            }

            UI.loadingPG.Value = percent;
            
            if (progressCallBack != null)
            {
                progressCallBack(e);
            }
        }
        
        public override void Destroy()
        {
            //currentBgName = "0";
            //nextBgName = "0";
            _ins = null;
            base.Destroy();
            UI = null;
        }

    }
}