using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class UIMgr : MonoBehaviour
{
    private UiLayerController m_NormalController;
    private UiLayerController m_MiddleController;
    private UiLayerController m_HighController;
    public Transform Normal;
    public Transform Middle;
    public Transform High;
    private Dictionary<String,Queue<GameObject>> CachedUI = new Dictionary<string, Queue<GameObject>>();
    
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        m_NormalController = new UiLayerController(Normal);
        m_MiddleController = new UiLayerController(Middle);
        m_HighController = new UiLayerController(High);
    }

    /// <summary>
    /// 获取隐藏的ui面板
    /// </summary>
    /// <param name="prefabName"></param>
    /// <returns></returns>
    private GameObject GetUiPrefab(string prefabName)
    {
        if (CachedUI.ContainsKey(prefabName))
        {
            Queue<GameObject> queueObjs = CachedUI[prefabName];
            if (queueObjs.Count > 0)
            {
                return queueObjs.Dequeue();
            }
        }

        return null;
    }
    
    /// <summary>
    /// 打开一个window
    /// </summary>
    /// <param name="prefabName"></param>
    public async void OpenWindow(string prefabName,UILayer layer = UILayer.Normal,OpenUiType type = OpenUiType.First)
    {
        GameObject prefab = GetUiPrefab(prefabName);
        if (prefab == null)
        {
            prefab = await ResourceManager.LoadAsync<GameObject>(prefabName);
            if (prefab == null)
            {
                FastLog.Error(string.Format("Ui {0} not found!",prefabName));
                return;
            }
            else
            {
                prefab = Instantiate(prefab);
            }

        }

        BaseUI baseUi = prefab.GetComponent<BaseUI>();

        switch (layer)
        {
            case UILayer.Normal:
                m_NormalController.ShowWindow(baseUi);
                break;
            case UILayer.Middle:
                m_MiddleController.ShowWindow(baseUi);
                break;
            case UILayer.High:
                m_HighController.ShowWindow(baseUi);
                break;
        }
        

    }
    
}
