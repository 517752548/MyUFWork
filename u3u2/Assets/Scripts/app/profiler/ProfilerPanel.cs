using System;
using System.Collections.Generic;
using app.main;
using UnityEngine;

class ProfilerPanel : BaseUI
{
    private bool stopUpdateContent = false;
    private Vector3 UnVisiblePos;
    private Vector3 visiblePos;
    private ProfilerUI UI;

    private int printcount=20;

    private static ProfilerPanel _ins;

    public static ProfilerPanel Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = new ProfilerPanel();
            }
            return _ins;
        }
    }
    /*
    public override void initUILayer(WndType uilayer = WndType.FirstWND)
    {
        base.initUILayer(WndType.POPTIPS);
    }
    */

    public ProfilerPanel()
    {
        uiName = "ProfilerPanel";
        SourceManager.Ins.ignoreDispose(PathUtil.Ins.GetUIPath("ProfilerPanel"));
    }

    public override void initUI()
    {
        base.initUI();
        UnVisiblePos = new Vector3(10, -55, 0);
        visiblePos = new Vector3(510, -55, 0);
        UI = ui.AddComponent<ProfilerUI>();
        UI.Init();
        //EventTriggerListener.Get(UI.sendBtn.gameObject).onClick = clickSend;
        //EventTriggerListener.Get(UI.clearBtn.gameObject).onClick = clickClear;
        //EventTriggerListener.Get(UI.stopBtn.gameObject).onClick = clickStop;
        UI.stopBtn.SetClickCallBack(clickStop);
        UI.gcBtn.SetClickCallBack(clickGC);
        UI.sb.ClickCallBack = clickSwitch;
        UI.tbg.SetIndexWithCallBack(0);
        UI.tbg.TabChangeHandler = tabChange;

        GameClient.ins.AddBehaviour(Ins);
    }

    public override void show(RMetaEvent e = null)
    {
        base.show(e);

        UI.sb.IsSelected = true;
        clickSwitch();
    }

    private void clickGC()
    {
        MemCache.DestroyAllFreeCaches();

        WndManager.Ins.DestroyUnusedWnds();

        SourceManager.Ins.CheckForUnusedBundles();

        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

    private void clickClear(GameObject go)
    {
        UI.contentText.text = "";
    }

    public override void Destroy()
    {
        GameClient.ins.RemoveBehaviour(Ins);
        base.Destroy();
        UI = null;
    }

    private void clickStop(GameObject go)
    {
        stopUpdateContent = !stopUpdateContent;
        UI.stopBtnText.text = stopUpdateContent ? "继续" : "暂停";
    }

    private void clickSwitch(UGUISwitchButton sb = null)
    {
        if (UI.sb.IsSelected)
        {
            UI.sbrtf.anchoredPosition3D = UnVisiblePos;

            UI.stopBtn.gameObject.SetActive(false);
            UI.bg.gameObject.SetActive(false);
            UI.gcBtn.gameObject.SetActive(false);
            UI.tbg.gameObject.SetActive(false);
        }
        else
        {
            UI.sbrtf.anchoredPosition3D = visiblePos;

            UI.bg.gameObject.SetActive(true);
            UI.stopBtn.gameObject.SetActive(true);
            UI.gcBtn.gameObject.SetActive(true);
            UI.tbg.gameObject.SetActive(true);
        }
    }

    private void tabChange(int index)
    {
        DoUpdate(0);
    }

    public override void DoUpdate(float deltaTime)
    {
        if (!isShown || stopUpdateContent)
        {
            return;
        }
        string str = "";
        if (UI.tbg.index == 0)
        {
            str += "\n FPS: " + GameInfoDisplay.MLastFps;
            str += "\n GetTotalMemory: " + System.GC.GetTotalMemory(false) / (1024f * 1024) + " M";
            str += "\n usedHeapSize: " + UnityEngine.Profiling.Profiler.usedHeapSize / (1024f * 1024) + " M";
            str += "\n Total MonoHeapSize: " + UnityEngine.Profiling.Profiler.GetMonoHeapSize() / (1024f * 1024) + " M";
            str += "\n Total MonoUsedSize: " + UnityEngine.Profiling.Profiler.GetMonoUsedSize() / (1024f * 1024) + " M";
            str += "\n Total Allocated: " + UnityEngine.Profiling.Profiler.GetTotalAllocatedMemory() / (1024f * 1024) + " M";
            str += "\n Total Reserved: " + UnityEngine.Profiling.Profiler.GetTotalReservedMemory() / (1024f * 1024) + " M";
            str += "\n Total UnusedReserved: " + UnityEngine.Profiling.Profiler.GetTotalUnusedReservedMemory() / (1024f * 1024) + " M";
            
        }
        else if (UI.tbg.index == 1)
        {
            //Dictionary<string, AssetBundleContainer> dic = SourceManager.Ins.AssetBundles;
            //float totalAblMem = 0;
            //foreach (KeyValuePair<string, AssetBundleContainer> pair in dic)
            //{
            //    if ((pair.Value != null && pair.Value.assetBundle != null))
            //    {
            //        string[] arr = pair.Key.Split(new char[] {'\\'});
            //        string ablName = arr[arr.Length-1];
            //        float mem = Profiler.GetRuntimeMemorySize(pair.Value.assetBundle) / (1024f * 1024);
            //        totalAblMem += mem;
            //        str += " \n AssetBundle : " + ablName + " 占用内存：" + mem + " M";
            //    }
            //}
            //str += " \n Total AssetBundle: " + totalAblMem + " M";

            List<MemoryItem> itemlist = new List<MemoryItem>();

            //Textures
            var textures = Resources.FindObjectsOfTypeAll(typeof(Texture));
            float totalTexture = 0;
            int textureCount = 0;
            foreach (Texture t in textures)
            {
                MemoryItem mi = new MemoryItem();
                mi.itemname = t.name;
                mi.memorysize = UnityEngine.Profiling.Profiler.GetRuntimeMemorySize(t)/(1024f*1024);
                itemlist.Add(mi);
                totalTexture += mi.memorysize;
            }
            itemlist.Sort(sortSize);
            textureCount = itemlist.Count;
            int texturelen = itemlist.Count > printcount ? printcount : itemlist.Count;

            for (int i = 0; i < texturelen; i++)
            {
                str += "\n Texture: " + itemlist[i].itemname + " 占用：" + itemlist[i].memorysize + " M";
                bool hasReference = false;
                Dictionary<string, AssetBundleContainer> dic = SourceManager.Ins.AssetBundles;
                foreach (KeyValuePair<string, AssetBundleContainer> pair in dic)
                {
                    if ((pair.Value != null && pair.Value.assetBundle != null)&&pair.Value.assetBundle.Contains(itemlist[i].itemname))
                    {
                        string[] arr = pair.Key.Split(new char[] {'\\'});
                        string ablName = arr[arr.Length-1];
                        if (!hasReference)
                        {
                            hasReference = true;
                            str += " \n 引用的AssetBundle : ";
                        }
                        str += " \n " + ablName;
                    }
                }
            }

            //Material
            itemlist.Clear();
            var materials = Resources.FindObjectsOfTypeAll(typeof(Material));
            float totalMaterial = 0;
            int materialCount = 0;
            foreach (Material t in materials)
            {
                MemoryItem mi = new MemoryItem();
                mi.itemname = t.name;
                mi.memorysize = UnityEngine.Profiling.Profiler.GetRuntimeMemorySize(t) / (1024f * 1024);
                itemlist.Add(mi);
                totalMaterial += mi.memorysize;
            }
            itemlist.Sort(sortSize);
            materialCount = itemlist.Count;
            int materiallen = itemlist.Count > printcount ? printcount : itemlist.Count;

            for (int i = 0; i < materiallen; i++)
            {
                str += "\n Material: " + itemlist[i].itemname + " 占用：" + itemlist[i].memorysize + " M";
                bool hasReference = false;
                Dictionary<string, AssetBundleContainer> dic = SourceManager.Ins.AssetBundles;
                foreach (KeyValuePair<string, AssetBundleContainer> pair in dic)
                {
                    if ((pair.Value != null && pair.Value.assetBundle != null)&&pair.Value.assetBundle.Contains(itemlist[i].itemname))
                    {
                        string[] arr = pair.Key.Split(new char[] {'\\'});
                        string ablName = arr[arr.Length-1];
                        if (!hasReference)
                        {
                            hasReference = true;
                            str += " \n 引用的AssetBundle : ";
                        }
                        str += " \n " + ablName;
                    }
                }
            }

            //Mesh
            itemlist.Clear();
            var meshs = Resources.FindObjectsOfTypeAll(typeof(Mesh));
            float totalmesh = 0;
            int meshCount = 0;
            foreach (Mesh t in meshs)
            {
                MemoryItem mi = new MemoryItem();
                mi.itemname = t.name;
                mi.memorysize = UnityEngine.Profiling.Profiler.GetRuntimeMemorySize(t) / (1024f * 1024);
                itemlist.Add(mi);
                totalmesh += mi.memorysize;
            }
            itemlist.Sort(sortSize);
            meshCount = itemlist.Count;
            int meshlen = itemlist.Count > printcount ? printcount : itemlist.Count;

            for (int i = 0; i < meshlen; i++)
            {
                str += "\n Mesh: " + itemlist[i].itemname + " 占用：" + itemlist[i].memorysize + " M";
                bool hasReference = false;
                Dictionary<string, AssetBundleContainer> dic = SourceManager.Ins.AssetBundles;
                foreach (KeyValuePair<string, AssetBundleContainer> pair in dic)
                {
                    if ((pair.Value != null && pair.Value.assetBundle != null)&&pair.Value.assetBundle.Contains(itemlist[i].itemname))
                    {
                        string[] arr = pair.Key.Split(new char[] {'\\'});
                        string ablName = arr[arr.Length-1];
                        if (!hasReference)
                        {
                            hasReference = true;
                            str += " \n 引用的AssetBundle : ";
                        }
                        str += " \n " + ablName;
                    }
                }
            }

            //AnimationClip
            itemlist.Clear();
            var AnimationClips = Resources.FindObjectsOfTypeAll(typeof(AnimationClip));
            float totalAnimationClip = 0;
            int AnimationClipCount = 0;
            foreach (AnimationClip t in AnimationClips)
            {
                MemoryItem mi = new MemoryItem();
                mi.itemname = t.name;
                mi.memorysize = UnityEngine.Profiling.Profiler.GetRuntimeMemorySize(t) / (1024f * 1024);
                itemlist.Add(mi);
                totalAnimationClip += mi.memorysize;
            }
            itemlist.Sort(sortSize);
            AnimationClipCount = itemlist.Count;
            int AnimationCliplen = itemlist.Count > printcount ? printcount : itemlist.Count;

            for (int i = 0; i < AnimationCliplen; i++)
            {
                str += "\n AnimationClip: " + itemlist[i].itemname + " 占用：" + itemlist[i].memorysize + " M";
                bool hasReference = false;
                Dictionary<string, AssetBundleContainer> dic = SourceManager.Ins.AssetBundles;
                foreach (KeyValuePair<string, AssetBundleContainer> pair in dic)
                {
                    if ((pair.Value != null && pair.Value.assetBundle != null)&&pair.Value.assetBundle.Contains(itemlist[i].itemname))
                    {
                        string[] arr = pair.Key.Split(new char[] {'\\'});
                        string ablName = arr[arr.Length-1];
                        if (!hasReference)
                        {
                            hasReference = true;
                            str += " \n 引用的AssetBundle : ";
                        }
                        str += " \n " + ablName;
                    }
                }
            }
            str += "\n Textures Count:" + textureCount + ",Total Textures Mem: " + totalTexture + " M";
            str += "\n Materials Count:" + materialCount + ",Total Materials Mem: " + totalMaterial + " M";
            str += "\n Mesh Count:" + meshCount + ",Total Meshs Mem: " + totalmesh + " M";
            str += "\n AnimationClip Count:" + AnimationClipCount + ",Total AnimationClip Mem: " + totalAnimationClip + " M";
            
            str += "\n FPS: " + GameInfoDisplay.MLastFps;
            str += "\n GetTotalMemory: " + System.GC.GetTotalMemory(false) / (1024f * 1024) + " M";
            str += "\n usedHeapSize: " + UnityEngine.Profiling.Profiler.usedHeapSize / (1024f * 1024) + " M";
            str += "\n Total MonoHeapSize: " + UnityEngine.Profiling.Profiler.GetMonoHeapSize() / (1024f * 1024) + " M";
            str += "\n Total MonoUsedSize: " + UnityEngine.Profiling.Profiler.GetMonoUsedSize() / (1024f * 1024) + " M";
            str += "\n Total Allocated: " + UnityEngine.Profiling.Profiler.GetTotalAllocatedMemory() / (1024f * 1024) + " M";
            str += "\n Total Reserved: " + UnityEngine.Profiling.Profiler.GetTotalReservedMemory() / (1024f * 1024) + " M";
            str += "\n Total UnusedReserved: " + UnityEngine.Profiling.Profiler.GetTotalUnusedReservedMemory() / (1024f * 1024) + " M";
            
        }

        AddLog(str);

        stopUpdateContent = true;
        UI.stopBtnText.text = stopUpdateContent ? "继续" : "暂停";

        //AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        //AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        //jo.Call("getMeminfo");
    }

    private int sortSize(MemoryItem a,MemoryItem b)
    {
        //由大到小
        if (a.memorysize > b.memorysize)
        {
            return -1;
        }
        else if (a.memorysize < b.memorysize)
        {
            return 1;
        }
        return 0;
    }

    public void AddLog(string msg)
    {
        if (UI == null || stopUpdateContent)
        {
            return;
        }
        if (UI.contentText.text.Length > 10000)
        {
            clickClear(null);
        }
        if (UI.contentText != null)
        {
            UI.contentText.text = msg;
        }
    }

    public void changeSibling()
    {
        setAsLastSibling(ui.gameObject);
    }

}

class MemoryItem
{
    public float memorysize;
    public string itemname;
}