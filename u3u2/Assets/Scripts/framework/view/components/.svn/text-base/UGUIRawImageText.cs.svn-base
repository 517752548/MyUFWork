using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UGUIRawImageText
{
    /*
    public GameObject gameObject { get; private set; }
    public float width { get; protected set; }
    public float height { get; protected set; }
    public CanvasGroup canvasGroup { get; private set; }

    private List<GameObject> mGameObjs = new List<GameObject>();
    
    public UGUIRawImageText()
    {
        gameObject = new GameObject("UGUIImageText");
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        //RectTransform rt = gameObject.AddComponent<RectTransform>();
        //rt.SetParent(UGUIConfig.GetTopestWndCanvas().transform);
        //gameObject.layer = UGUIConfig.GetTopestWndCanvas().gameObject.layer;
        //rt.localScale = Vector3.one;
        //rt.localPosition = Vector3.zero;
    }

    public void SetParent(Transform parent)
    {
        gameObject.transform.SetParent(parent);
        gameObject.layer = parent.gameObject.layer;
        gameObject.transform.localScale = Vector3.one;
        gameObject.transform.localPosition = Vector3.zero;
    }

    public virtual void SetContent(string[] content, float space = 0)
    {
        int len = content.Length;
        List<Texture2D> ts = new List<Texture2D>();
        for (int i = 0; i < len; i++)
        {
            ts.Add(SourceManager.Ins.GetImageText(content[i]));
        }
        SetContent(ts, space);
    }

    private void SetContent(List<Texture2D> content, float space)
    {
        Clear();

        int len = content.Count;

        if (len > 0)
        {
            List<Vector3> poses = new List<Vector3>();
            List<RawImage> imges = new List<RawImage>();
            for (int i = 0; i < len; i++)
            {
                GameObject go = new GameObject(content[i].name);
                RectTransform rt = go.AddComponent<RectTransform>();
                rt.SetParent(gameObject.transform);
                rt.localScale = Vector3.one;
                go.layer = gameObject.layer;
                RawImage img = go.AddComponent<RawImage>();
                img.texture = content[i];
                img.rectTransform.pivot = new Vector2(0f, 0.5f);
                img.rectTransform.anchorMin = new Vector2(0, 0);
                img.rectTransform.anchorMax = new Vector2(1, 1);
                img.rectTransform.localScale = new Vector3(1, 1, 1);
                img.SetNativeSize();
                poses.Add(new Vector3(width, 0, 0));
                imges.Add(img);
                mGameObjs.Add(go);
                width += (img.rectTransform.sizeDelta.x + space);
                height = Mathf.Max(img.rectTransform.sizeDelta.y, height);
            }

            for (int i = 0; i < len; i++)
            {
                Vector3 pos = poses[i];
                pos.x -= width / 2f;
                imges[i].rectTransform.localPosition = pos;
            }
        }
    }

    public void Clear()
    {
        if (mGameObjs != null)
        {
            int len = mGameObjs.Count;
            for (int i = 0; i < len; i++)
            {
                SourceManager.Ins.removeReference(PathUtil.Ins.GetSingleCommonTexturesPath(), mGameObjs[i]);
            }
            mGameObjs.Clear();
        }

        width = 0;
        height = 0;
    }

    public virtual void Destroy()
    {
        Clear();
        GameObject.DestroyImmediate(gameObject, true);
    }
    */
}