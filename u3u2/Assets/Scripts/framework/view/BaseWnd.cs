using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BaseWnd : BaseUI
{
    public bool useTween { get; set; }
    public bool isShowBgMask { get; set; }
    public float bgMaskAlpha { get; set; }
    private Image bgimage;

    public BaseWnd()
    {
        useTween = false;
        isShowBgMask = true;
        bgMaskAlpha = 0.5f;
    }

    /// <summary>
    /// 初始化界面，当hasInit为false时执行
    /// </summary>
    public virtual void initWnd()
    {
    }

    public override void initUI()
    {
        base.initUI();
        initWnd();
    }

    public override void show(RMetaEvent e = null)
    {
        //为ui属性赋值
        base.show(e);
        //Vector3 v3 = _ui.GetComponent<RectTransform>().anchoredPosition3D;
        //v3.z = -(int)WndType * ClientConstantDef.PER_LAYER_Z_DEPTH;
        //_ui.GetComponent<RectTransform>().anchoredPosition3D = v3;
        //Renderer render = _ui.GetComponent<Renderer>();
        //if (render!=null)
        //{
        //    render.material.renderQueue = 3000 + (int)WndType;
        //}
        //CanvasRenderer cr = _ui.GetComponent<CanvasRenderer>();
        //if (cr!=null)
        //{
        //    Material m = cr.GetMaterial();
        //    if (m != null)
        //    {
        //        m.renderQueue = 3000 + (int)WndType;
        //    }
        //    Renderer[] _renderers = _ui.GetComponentsInChildren<Renderer>();
        //    for (int i = 0; _renderers!=null&&i < _renderers.Length; i++)
        //    {
        //        _renderers[i].material.renderQueue = 3000 + (int)WndType;
        //    }
        //}

        BaseWnd bw = WndManager.Ins.GetCurrentShowWndByType(UILayer);
        if (bw != null && bw != this)
        {
            bw.hide();
        }
        WndManager.Ins.SetCurrentShowWndByType(UILayer, this);
        if (isShowBgMask)
        {
            //显示面板的背景底
            showBgImage();
        }
        if (useTween)
        {
            //_ui.SetActive(false);
            //_ui.transform.localScale = new Vector3(1.1f, 1.1f, 1f);
            //_ui.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutCubic);
            
            ui.transform.DOScale(new Vector3(1.1f, 1.1f, 1f), 0.1f).SetEase(Ease.OutCubic).OnComplete(delegate ()
            {
                ui.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutCubic);
            });
            
        }
    }

    private void showBgImage()
    {
        if (ui != null)
        {
            if (bgimage == null)
            {
                GameObject go = new GameObject("wndbgImage");
                bgimage = go.AddComponent<Image>();
                RectTransform rt = go.GetComponent<RectTransform>();
                go.transform.SetParent(ui.transform);
                changeChildLayer(go, ui.layer);
                go.transform.localScale = Vector3.one;
                go.transform.localPosition = Vector3.zero;
                Vector3 v3 = new Vector3(rt.anchoredPosition3D.x, rt.anchoredPosition3D.y, 0);
                rt.anchoredPosition3D = v3;
                go.transform.SetAsFirstSibling();
                //rt.sizeDelta = new Vector2(UGUIConfig.DeviceWidth, UGUIConfig.DeviceHeight);
                rt.sizeDelta = new Vector2(UGUIConfig.UISpaceWidth, UGUIConfig.UISpaceHeight);
                EventTriggerListener.Get(bgimage.gameObject).onClick = clickSpaceArea;
                if (Application.platform != RuntimePlatform.WindowsEditor)
                {
                    go.transform.localScale = Vector3.one;
                }
            }
            bgimage.color = new Color(0, 0, 0, bgMaskAlpha);
            bgimage.gameObject.SetActive(true);
        }
    }

    public static void hideBgImage(GameObject go)
    {
        Transform imagetmp = go.gameObject.transform.Find("wndbgImage");
        if (imagetmp != null)
        {
            imagetmp.gameObject.SetActive(false);
        }
    }

    public static void setBgImageFullScreen(GameObject go)
    {
        Transform imagetmp = go.gameObject.transform.Find("wndbgImage");
        RectTransform rt = imagetmp.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0,0);
        rt.anchorMax = new Vector2(1,1);
        rt.anchoredPosition = Vector2.zero;
    }

    protected virtual void clickSpaceArea(UnityEngine.GameObject go)
    {
        //base.clickSpaceArea(go);
        hide();
    }

    public override void hide(RMetaEvent e = null)
    {
        if (ui != null)
        {
            //ui.transform.localScale = Vector3.one;
        }
        base.hide();
        if (WndManager.Ins.GetCurrentShowWndByType(UILayer) == this)
        {
            WndManager.Ins.RemoveCurrentShowWndByType(UILayer);
        }
        //Destroy();
    }
    
    public override void Destroy()
    {
        base.Destroy();
        bgimage = null;
    }
}