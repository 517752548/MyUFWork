using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UGUIImageText : Cacheable
{
    public GameObject gameObject { get; private set; }
    public float width { get; protected set; }
    public float height { get; protected set; }
    public CanvasGroup canvasGroup { get; private set; }

    private List<Image> mImgs = new List<Image>();
    
    private string mAtlasPath = null;

    private List<Image> mImgPool = new List<Image>();
    
    public UGUIImageText()
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

    public virtual void SetContent(string atlasPath, string[] content, float space = 0)
    {
        mAtlasPath = atlasPath;
        int len = content.Length;
        List<Sprite> ts = new List<Sprite>();
        for (int i = 0; i < len; i++)
        {
            ts.Add(SourceManager.Ins.GetAsset<Sprite>(atlasPath, content[i]));
        }
        SetContent(ts, space);
    }

    private void SetContent(List<Sprite> content, float space)
    {
        Clear();

        int len = content.Count;

        if (len > 0)
        {
            List<Vector3> poses = new List<Vector3>();
            for (int i = 0; i < len; i++)
            {
                Image img = null;
                if (mImgPool.Count > 0)
                {
                    img = mImgPool[0];
                    img.gameObject.SetActive(true);
                    mImgPool.RemoveAt(0);
                }
                else
                {
                    GameObject go = new GameObject();
                    RectTransform rt = go.AddComponent<RectTransform>();
                    rt.SetParent(gameObject.transform);
                    rt.localScale = Vector3.one;
                    go.layer = gameObject.layer;
                    img = go.AddComponent<Image>();
                    img.rectTransform.pivot = new Vector2(0f, 0.5f);
                    img.rectTransform.anchorMin = new Vector2(0, 0);
                    img.rectTransform.anchorMax = new Vector2(1, 1);
                    img.rectTransform.localScale = new Vector3(1, 1, 1);
                }

                img.sprite = content[i];
                img.SetNativeSize();
                poses.Add(new Vector3(width, 0, 0));
                mImgs.Add(img);
                width += (img.rectTransform.sizeDelta.x + space);
                height = Mathf.Max(img.rectTransform.sizeDelta.y, height);
            }

            for (int i = 0; i < len; i++)
            {
                Vector3 pos = poses[i];
                pos.x -= width / 2f;
                mImgs[i].rectTransform.localPosition = pos;
            }
        }
    }

    public void Clear()
    {
        if (mImgs != null)
        {
            int len = mImgs.Count;
            for (int i = 0; i < len; i++)
            {
                if (mImgs[i].sprite != null)
                {
                    SourceManager.Ins.removeReference(mAtlasPath, null);
                    mImgs[i].sprite = null;    
                }
                mImgs[i].gameObject.SetActive(false);
                mImgPool.Add(mImgs[i]);
            }
            mImgs.Clear();
        }

        width = 0;
        height = 0;
    }

    public override string GetPoolName()
    {
        return "UGUIImageText";
    }

    public override int GetCacheType()
    {
        return MemCacheType.OTHER;
    }

    public override void Destroy()
    {
        //Clear();
        if (mImgs != null)
        {
            int len = mImgs.Count;
            for (int i = 0; i < len; i++)
            {
                if (mImgs[i].sprite != null)
                {
                    SourceManager.Ins.removeReference(mAtlasPath, null);
                }
            }
        }
        mImgs.Clear();
        mImgPool.Clear();
        width = 0;
        height = 0;
        GameObject.DestroyImmediate(gameObject, true);
        gameObject = null;
    }
}