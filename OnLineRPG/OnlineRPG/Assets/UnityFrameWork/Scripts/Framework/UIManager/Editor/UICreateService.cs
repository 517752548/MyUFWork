using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;
using System;
using BetaFramework;

public class UICreateService
{
    public static void CreatUIManager(Vector2 referenceResolution, CanvasScaler.ScreenMatchMode MatchMode,
        bool isOnlyUICamera, bool isVertical)
    {
        //新增五个层级
        EditorExpand.AddSortLayerIfNotExist("GameUI");
        EditorExpand.AddSortLayerIfNotExist("Fixed");
        EditorExpand.AddSortLayerIfNotExist("Normal");
        EditorExpand.AddSortLayerIfNotExist("TopBar");
        EditorExpand.AddSortLayerIfNotExist("PopUp");

        //UIManager
        GameObject UIManagerGo = new GameObject("UIManager");
        UIManagerGo.layer = LayerMask.NameToLayer("UI");
        //UIManager UIManager = UIManagerGo.AddComponent<UIManager>();

        CreateUICamera(UIManagerGo, "DefaultUI", 1, referenceResolution, MatchMode, isOnlyUICamera, isVertical);

        ProjectWindowUtil.ShowCreatedAsset(UIManagerGo);

        //保存UIManager
        ReSaveUIManager(UIManagerGo);
    }

    public static void CreateUICamera(GameObject UIManagerGo, string key, float cameraDepth,
        Vector2 referenceResolution, CanvasScaler.ScreenMatchMode MatchMode, bool isOnlyUICamera, bool isVertical)
    {
        UILayerManager.UICameraData uICameraData = new UILayerManager.UICameraData();

        uICameraData.m_key = key;

        GameObject canvas = new GameObject(key);
        RectTransform canvasRt = canvas.AddComponent<RectTransform>();

        canvasRt.SetParent(UIManagerGo.transform);
        uICameraData.m_root = canvas;

        //UIcamera
        GameObject cameraGo = new GameObject("UICamera");
        cameraGo.transform.SetParent(canvas.transform);
        cameraGo.transform.localPosition = new Vector3(0, 0, -1000);
        Camera camera = cameraGo.AddComponent<Camera>();
        camera.cullingMask = LayerMask.GetMask("UI");
        camera.orthographic = true;
        camera.depth = cameraDepth;
        uICameraData.m_camera = camera;

        //Canvas
        Canvas canvasComp = canvas.AddComponent<Canvas>();
        canvasComp.renderMode = RenderMode.ScreenSpaceCamera;
        canvasComp.worldCamera = camera;

        //UI Raycaster
        canvas.AddComponent<GraphicRaycaster>();

        //CanvasScaler
        CanvasScaler scaler = canvas.AddComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = referenceResolution;
        scaler.screenMatchMode = MatchMode;

        if (!isOnlyUICamera)
        {
            camera.clearFlags = CameraClearFlags.Depth;
            camera.depth = 1;
        }
        else
        {
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = Color.black;
        }

        if (isVertical)
        {
            scaler.matchWidthOrHeight = 1;
        }
        else
        {
            scaler.matchWidthOrHeight = 0;
        }

        //挂载点
        GameObject goTmp = null;
        RectTransform rtTmp = null;
        UILayerManager UILayerManager = UIManagerGo.GetComponent<UILayerManager>();
        if (UILayerManager == null)
        {
            UILayerManager = UIManagerGo.AddComponent<UILayerManager>();
        }

        goTmp = new GameObject("GameUI");
        goTmp.layer = LayerMask.NameToLayer("UI");
        goTmp.transform.SetParent(canvas.transform);
        goTmp.transform.localScale = Vector3.one;
        rtTmp = goTmp.AddComponent<RectTransform>();
        rtTmp.anchorMax = new Vector2(1, 1);
        rtTmp.anchorMin = new Vector2(0, 0);
        rtTmp.anchoredPosition3D = Vector3.zero;
        rtTmp.sizeDelta = Vector2.zero;
        uICameraData.m_GameUILayerParent = goTmp.transform;

        goTmp = new GameObject("Fixed");
        goTmp.layer = LayerMask.NameToLayer("UI");
        goTmp.transform.SetParent(canvas.transform);
        goTmp.transform.localScale = Vector3.one;
        rtTmp = goTmp.AddComponent<RectTransform>();
        rtTmp.anchorMax = new Vector2(1, 1);
        rtTmp.anchorMin = new Vector2(0, 0);
        rtTmp.anchoredPosition3D = Vector3.zero;
        rtTmp.sizeDelta = Vector2.zero;
        uICameraData.m_FixedLayerParent = goTmp.transform;

        goTmp = new GameObject("Normal");
        goTmp.layer = LayerMask.NameToLayer("UI");
        goTmp.transform.SetParent(canvas.transform);
        goTmp.transform.localScale = Vector3.one;
        rtTmp = goTmp.AddComponent<RectTransform>();
        rtTmp.anchorMax = new Vector2(1, 1);
        rtTmp.anchorMin = new Vector2(0, 0);
        rtTmp.anchoredPosition3D = Vector3.zero;
        rtTmp.sizeDelta = Vector2.zero;
        uICameraData.m_NormalLayerParent = goTmp.transform;

        goTmp = new GameObject("TopBar");
        goTmp.layer = LayerMask.NameToLayer("UI");
        goTmp.transform.SetParent(canvas.transform);
        goTmp.transform.localScale = Vector3.one;
        rtTmp = goTmp.AddComponent<RectTransform>();
        rtTmp.anchorMax = new Vector2(1, 1);
        rtTmp.anchorMin = new Vector2(0, 0);
        rtTmp.anchoredPosition3D = Vector3.zero;
        rtTmp.sizeDelta = Vector2.zero;
        uICameraData.m_TopbarLayerParent = goTmp.transform;

        goTmp = new GameObject("PopUp");
        goTmp.layer = LayerMask.NameToLayer("UI");
        goTmp.transform.SetParent(canvas.transform);
        goTmp.transform.localScale = Vector3.one;
        rtTmp = goTmp.AddComponent<RectTransform>();
        rtTmp.anchorMax = new Vector2(1, 1);
        rtTmp.anchorMin = new Vector2(0, 0);
        rtTmp.anchoredPosition3D = Vector3.zero;
        rtTmp.sizeDelta = Vector2.zero;
        uICameraData.m_PopUpLayerParent = goTmp.transform;

        UILayerManager.UICameraList.Add(uICameraData);

        //重新保存
        ReSaveUIManager(UIManagerGo);
    }

    static void ReSaveUIManager(GameObject UIManagerGo)
    {
        string Path = "Resources/UI/UIManager.prefab";
        FileTool.CreatFilePath(Application.dataPath + "/" + Path);
        PrefabUtility.CreatePrefab("Assets/" + Path, UIManagerGo, ReplacePrefabOptions.ConnectToPrefab);
    }

    public static void CreatUI(string UIWindowName, string UIcameraKey, UIType UIType, UILayerManager UILayerManager,
        bool isAutoCreatePrefab)
    {
        GameObject uiGo = new GameObject(UIWindowName);

        Type type = EditorTool.GetType(UIWindowName);
        UIWindowBase uiBaseTmp = uiGo.AddComponent(type) as UIWindowBase;

        uiGo.layer = LayerMask.NameToLayer("UI");

        uiBaseTmp.m_UIType = UIType;

        Canvas canvas = uiGo.AddComponent<Canvas>();

        if (EditorExpand.isExistShortLayer(UIType.ToString()))
        {
            canvas.overrideSorting = true;
            canvas.sortingLayerName = UIType.ToString();
        }

        uiGo.AddComponent<GraphicRaycaster>();

        RectTransform ui = uiGo.GetComponent<RectTransform>();
        ui.sizeDelta = Vector2.zero;
        ui.anchorMin = Vector2.zero;
        ui.anchorMax = Vector2.one;

        GameObject BgGo = new GameObject("BG");

        BgGo.layer = LayerMask.NameToLayer("UI");
        RectTransform Bg = BgGo.AddComponent<RectTransform>();
        Bg.SetParent(ui);
        Bg.sizeDelta = Vector2.zero;
        Bg.anchorMin = Vector2.zero;
        Bg.anchorMax = Vector2.one;

        GameObject rootGo = new GameObject("root");
        rootGo.layer = LayerMask.NameToLayer("UI");
        RectTransform root = rootGo.AddComponent<RectTransform>();
        root.SetParent(ui);
        root.sizeDelta = Vector2.zero;
        root.anchorMin = Vector2.zero;
        root.anchorMax = Vector2.one;

        uiBaseTmp.m_bgMask = BgGo;
        uiBaseTmp.m_uiRoot = rootGo;

        if (UILayerManager)
        {
            UILayerManager.SetLayer(uiBaseTmp);
        }

        if (isAutoCreatePrefab)
        {
            string Path = "AssetsPackage/AnsycLoad/UI/" + UIWindowName + "/" + UIWindowName + ".prefab";
            FileTool.CreatFilePath(Application.dataPath + "/" + Path);
            PrefabUtility.CreatePrefab("Assets/" + Path, uiGo, ReplacePrefabOptions.ConnectToPrefab);
        }

        ProjectWindowUtil.ShowCreatedAsset(uiGo);
    }


    public static void CreatUIScript(string UIWindowName)
    {
        string LoadPath = Application.dataPath + "/UnityFrameWork/Scripts/Framework/UIManager/UITemplate/UIWindowClassTemplate.txt";
        string SavePath = Application.dataPath + "/WordCalm/Script/UI/" + UIWindowName + "/" + UIWindowName + ".cs";

        string UItemplate = ResourceIOTool.ReadStringByFile(LoadPath);
        string classContent = UItemplate.Replace("{0}", UIWindowName);

        EditorUtil.WriteStringByFile(SavePath, classContent);

        AssetDatabase.Refresh();
    }
}