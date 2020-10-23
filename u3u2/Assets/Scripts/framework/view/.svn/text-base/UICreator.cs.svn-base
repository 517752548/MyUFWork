using System.Collections.Generic;
using UnityEngine;
using app.main;

public class UICreator : MonoBehaviour
{
    private Dictionary<string, GameObject> mPreCachedUI = new Dictionary<string, GameObject>();
    private static UICreator mIns = null;

    public UICreator()
    {

    }

    public static UICreator ins
    {
        get
        {
            if (mIns == null)
            {
                GameObject go = GameObject.Find("ScriptsRoot");
                if (go != null)
                {
                    mIns = go.GetComponent<UICreator>();
                }

                if (mIns == null)
                {
                    mIns = go.AddComponent<UICreator>();
                }
            }
            return mIns;
        }
    }

    void Awake()
    {
        mIns = this;
    }

    public void CreateUI(BaseUI ui, bool useCoroutine)
    {
        //StartCoroutine(StartCreateUI(ui, useCoroutine));
        GameObject go = null;
        if (mPreCachedUI.ContainsKey(ui.uiPath) && mPreCachedUI[ui.uiPath] != null)
        {
            go = mPreCachedUI[ui.uiPath];
        }
        else
        {
            go = SourceManager.Ins.createObjectFromAssetBundle(ui.uiPath);

        }
        /*
        if (go.name != "empty")
        {
            //ui.initUILayer();
            Vector3 v3 = go.GetComponent<RectTransform>().anchoredPosition3D;
            Vector2 v2 = go.GetComponent<RectTransform>().anchoredPosition;
            Vector2 offsetMin = go.GetComponent<RectTransform>().offsetMin;
            Vector2 offsetMax = go.GetComponent<RectTransform>().offsetMax;
            Vector2 anchorMin = go.GetComponent<RectTransform>().anchorMin;
            Vector2 anchorMax = go.GetComponent<RectTransform>().anchorMax;
            Canvas cv = UGUIConfig.GetCanvasByWndType(ui.UILayer);
            go.transform.SetParent(cv.transform);
            ui.CanvasName = cv.name;
            //ui.changeChildLayer(go, LayerConfig.MainUI + (int)ui.UILayer);
            go.GetComponent<RectTransform>().anchorMin = anchorMin;
            go.GetComponent<RectTransform>().anchorMax = anchorMax;
            go.GetComponent<RectTransform>().offsetMin = offsetMin;
            go.GetComponent<RectTransform>().offsetMax = offsetMax;
            go.GetComponent<RectTransform>().anchoredPosition3D = v3;
            go.GetComponent<RectTransform>().anchoredPosition = v2;
            go.transform.localScale = Vector3.one;
            go.SetActive(false);
            //_ui.transform.SetAsLastSibling();
        }
        */
        ui.OnUICreated(go.name == "empty" ? null : go, ui.PreLoadParam);
    }
    /*
    private IEnumerator StartCreateUI(BaseUI ui, bool isCoroutine)
    {
        GameObject go = null;
        if (mPreCachedUI.ContainsKey(ui.uiPath) && mPreCachedUI[ui.uiPath] != null)
        {
            go = mPreCachedUI[ui.uiPath];
        }
        else
        {
            go = SourceManager.Ins.createObjectFromAssetBundle(ui.uiPath);

        }
        if (go.name != "empty")
        {
            ui.initUILayer();
            Vector3 v3 = go.GetComponent<RectTransform>().anchoredPosition3D;
            Vector2 v2 = go.GetComponent<RectTransform>().anchoredPosition;
            Vector2 offsetMin = go.GetComponent<RectTransform>().offsetMin;
            Vector2 offsetMax = go.GetComponent<RectTransform>().offsetMax;
            Vector2 anchorMin = go.GetComponent<RectTransform>().anchorMin;
            Vector2 anchorMax = go.GetComponent<RectTransform>().anchorMax;
            Canvas cv = UGUIConfig.GetCanvasByWndType(ui.UILayer);
            go.transform.SetParent(cv.transform);
            ui.CanvasName = cv.name;
            ui.changeChildLayer(go, LayerConfig.MainUI + (int)ui.UILayer);
            go.GetComponent<RectTransform>().anchorMin = anchorMin;
            go.GetComponent<RectTransform>().anchorMax = anchorMax;
            go.GetComponent<RectTransform>().offsetMin = offsetMin;
            go.GetComponent<RectTransform>().offsetMax = offsetMax;
            go.GetComponent<RectTransform>().anchoredPosition3D = v3;
            go.GetComponent<RectTransform>().anchoredPosition = v2;
            go.transform.localScale = Vector3.one;
            go.SetActive(false);
            //_ui.transform.SetAsLastSibling();
        }
        if (isCoroutine)
        {
            yield return go;
        }
        ui.OnUICreated(go.name == "empty" ? null : go, ui.PreLoadParam);
    }
    */
    public void PreCacheUI(string uiPath)
    {
        GameObject go = SourceManager.Ins.createObjectFromAssetBundle(uiPath);
        go.transform.SetParent(GameClient.ins.cachedDisplayModels.transform);
        mPreCachedUI.Add(uiPath, go);
        go.SetActive(false);
    }
    
    public void ClearPreCachedUI()
    {
        mPreCachedUI.Clear();
    }
}

