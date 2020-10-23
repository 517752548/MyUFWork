using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UGUIRichText : Cacheable
{
    public delegate void UGUIRichTextResized(UGUIRichText richText);
    public CanvasGroup canvasGroup { get; private set; }
    public GameObject gameObject { get; private set; }
    public float width { get; protected set; }
    public float height { get; protected set; }
    private List<Dictionary<string, string>> mContent = null;
    private Font mFont = null;
    private int mFontSize = 0;
    private bool mOutline = false;
    private List<IUGUIRichTextElement> mElements = new List<IUGUIRichTextElement>();

    //private List<UGUIRichTextImage> mImages = new List<UGUIRichTextImage>();

    private UGUIRichTextResized mOnResized = null;

    private delegate void OnUGUIRichTextImageDleayShown(UGUIRichTextImage image);

    private List<UGUIRichTextText> mTextPool = new List<UGUIRichTextText>();
    private List<UGUIRichTextImage> mImagePool = new List<UGUIRichTextImage>();

    private interface IUGUIRichTextElement
    {
        GameObject gameObject { get; }
        int type { get; }//1:txt, 2:img
        float width { get; }
        float height { get; }
        void Use();
        void UnUse();
        void Destroy();
    }

    private class UGUIRichTextText : IUGUIRichTextElement
    {
        public GameObject gameObject { get; private set; }
        public float width { get; private set; }
        public float height { get; private set; }

        private Text mTxt = null;
        private ContentSizeFitter mSizeFitter = null;
        private RectTransform mRt = null;

        public UGUIRichTextText(GameObject container, string text, Color color, Font font, int fontSize, bool bold, bool italic, bool outline)
        {
            gameObject = new GameObject("text");
            gameObject.transform.SetParent(container.transform);
            gameObject.layer = container.layer;

            mRt = gameObject.AddComponent<RectTransform>();
            mRt.pivot = new Vector2(0f, 0.5f);
            mRt.anchorMin = new Vector2(0.0f, 0.5f);
            mRt.anchorMax = new Vector2(0.0f, 0.5f);
            mRt.localScale = Vector3.one;
            gameObject.AddComponent<CanvasRenderer>();
            mTxt = gameObject.AddComponent<Text>();
            mSizeFitter = gameObject.AddComponent<ContentSizeFitter>();
            mTxt.supportRichText = true;
            SetContent(text, color, font, fontSize, bold, italic, outline);
        }

        public void SetContent(string text, Color color, Font font, int fontSize, bool bold, bool italic, bool outline)
        {
            mTxt.font = font;
            mTxt.fontSize = fontSize;
            mSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
            mSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

            if (outline)
            {
                gameObject.AddComponent<Outline>();
            }

            mTxt.text = text;
            mTxt.color = color;

            if (bold && italic)
            {
                mTxt.fontStyle = FontStyle.BoldAndItalic;
            }
            else if (bold)
            {
                mTxt.fontStyle = FontStyle.Bold;
            }
            else if (italic)
            {
                mTxt.fontStyle = FontStyle.Italic;
            }

            mSizeFitter.SetLayoutHorizontal();
            mSizeFitter.SetLayoutVertical();
            width = mRt.sizeDelta.x;
            height = mRt.sizeDelta.y;
        }

        public void Use()
        {
            gameObject.SetActive(true);
        }

        public void UnUse()
        {
            gameObject.SetActive(false);
        }

        public void Destroy()
        {
            GameObject.DestroyImmediate(gameObject, true);
            gameObject = null;
        }

        public int type
        {
            get
            {
                return 1;
            }
        }
    }

    private class UGUIRichTextImage : IUGUIRichTextElement
    {
        public GameObject gameObject { get; private set; }
        public float width { get; private set; }
        public float height { get; private set; }

        private GameObject mContainer = null;

        private string mSrc = null;
        private string mName = null;
        private string mType = null;
        private int mWidth = 0;
        private int mHeight = 0;
        private OnUGUIRichTextImageDleayShown mOnImgDelayShown = null;
        private Image mImg = null;
        private RectTransform mRt = null;
        public UGUIRichTextImage(GameObject container, string src, string name, string type, int width, int height, OnUGUIRichTextImageDleayShown onImgDelayShown)
        {
            mContainer = container;
            gameObject = new GameObject("image");
            gameObject.transform.SetParent(container.transform);
            gameObject.layer = container.layer;
            mRt = gameObject.AddComponent<RectTransform>();
            mRt.pivot = new Vector2(0f, 0.5f);
            mRt.anchorMin = new Vector2(0f, 0.5f);
            mRt.anchorMax = new Vector2(0f, 0.5f);
            mRt.localScale = Vector3.one;
            gameObject.AddComponent<CanvasRenderer>();
            mImg = gameObject.AddComponent<Image>();
            SetContent(src, name, type, width, height, onImgDelayShown);
        }

        public void SetContent(string src, string name, string type, int width, int height, OnUGUIRichTextImageDleayShown onImgDelayShown)
        {
            mSrc = src;
            mName = name;
            mType = type;
            mWidth = width;
            mHeight = height;
            mOnImgDelayShown = onImgDelayShown;
            if (src != null)
            {
                if (SourceManager.Ins.hasAssetBundle(src))
                {
                    ShowImage();
                }
                else
                {
                    LoadImage();
                }
            }
        }

        private void LoadImage()
        {
            SourceLoader.Ins.load(mSrc, OnImageLoaded, null, null, true);
        }

        private void OnImageLoaded(RMetaEvent e)
        {
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                ShowImage();
                if (mOnImgDelayShown != null)
                {
                    mOnImgDelayShown(this);
                }
            }
        }

        private void ShowImage()
        {
            if (mType == "texture")
            {
                Texture2D texture = SourceManager.Ins.GetAsset<Texture2D>(mSrc, mName);
                mImg.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
            }
            else if (mType == "sprite")
            {
                mImg.sprite = SourceManager.Ins.GetAsset<Sprite>(mSrc, mName);
            }

            if (mImg.sprite != null)
            {
                if (mWidth > 0 || mHeight > 0)
                {
                    float imgW = mImg.sprite.rect.width;
                    float imgH = mImg.sprite.rect.height;
                    Vector2 sizeDelta = Vector2.zero;
                    if (mWidth > 0 && mHeight == 0)
                    {
                        sizeDelta = new Vector2(mWidth / imgW, mWidth / imgW);
                    }
                    else if (mWidth == 0 && mHeight > 0)
                    {
                        sizeDelta = new Vector2(mHeight / imgH, mHeight / imgH);
                    }
                    else if (mWidth == 0 && mHeight == 0)
                    {
                        sizeDelta = Vector2.zero;
                    }
                    else if (mWidth > 0 && mHeight > 0)
                    {
                        sizeDelta = new Vector2(mWidth / imgW, mHeight / imgH);
                    }
                    else
                    {
                        sizeDelta = Vector2.one;
                    }
                    imgW = imgW * sizeDelta.x;
                    imgH = imgH * sizeDelta.y;
                    mRt.sizeDelta = new Vector2(imgW, imgH);
                }
                else
                {
                    mImg.SetNativeSize();
                }
            }
            else
            {
                mRt.sizeDelta = new Vector2(mWidth, mHeight);
            }

            this.width = mRt.sizeDelta.x;
            this.height = mRt.sizeDelta.y;
        }

        public void Use()
        {
            gameObject.SetActive(true);
        }

        public void UnUse()
        {
            gameObject.SetActive(false);
            if (mImg.sprite != null)
            {
                mImg.sprite = null;
                SourceManager.Ins.removeReference(mSrc, null);
            }
        }

        public void Destroy()
        {
            if (mImg.sprite != null)
            {
                SourceManager.Ins.removeReference(mSrc, null);
            }
            GameObject.DestroyImmediate(gameObject, true);
            gameObject = null;
        }

        public int type
        {
            get
            {
                return 2;
            }
        }
    }

    public UGUIRichText()
    {
        gameObject = new GameObject("UGUIRichText");
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        //RectTransform rt = gameObject.AddComponent<RectTransform>();
        //Transform rt = gameObject.transform;
        //rt.SetParent(UGUIConfig.GetTopestWndCanvas().transform);
        //gameObject.layer = UGUIConfig.GetTopestWndCanvas().gameObject.layer;
        //rt.localPosition = Vector3.zero;
        //rt.localScale = Vector3.one;
    }

    public void SetParent(Transform parent)
    {
        gameObject.transform.SetParent(parent);
        gameObject.layer = parent.gameObject.layer;
        gameObject.transform.localScale = Vector3.one;
        gameObject.transform.localPosition = Vector3.zero;
    }

    public virtual void SetContent(List<Dictionary<string, string>> content, Font font, int fontSize, bool outline = false, UGUIRichTextResized onResized = null)
    {
        Clear();
        mContent = content;
        mFont = font;
        mFontSize = fontSize;
        mOutline = outline;
        mOnResized = onResized;
        Create();
    }

    public void Clear()
    {
        if (mElements != null)
        {
            int len = mElements.Count;
            for (int i = 0; i < len; i++)
            {
                IUGUIRichTextElement elem = mElements[i];
                elem.UnUse();
                if (elem.type == 1)
                {
                    mTextPool.Add((UGUIRichTextText)elem);
                }
                else if (elem.type == 2)
                {
                    mImagePool.Add((UGUIRichTextImage)elem);
                }
                else
                {
                    elem.Destroy();
                }
            }

            mElements.Clear();
        }

        if (mContent != null)
        {
            mContent.Clear();
        }

        width = 0;
        height = 0;
    }

    public override string GetPoolName()
    {
        return "UGUIRichText";
    }

    public override int GetCacheType()
    {
        return MemCacheType.OTHER;
    }

    public override void Destroy()
    {
        //Clear();
        mElements.Clear();
        mContent.Clear();
        width = 0;
        height = 0;
        GameObject.DestroyImmediate(gameObject, true);
        gameObject = null;
    }

    private void Create()
    {
        int len = mContent.Count;
        for (int i = 0; i < len; i++)
        {
            Dictionary<string, string> dic = mContent[i];
            string type = null;
            dic.TryGetValue("type", out type);

            if (type == "text")
            {
                mElements.Add(CreateText(dic));
            }
            else if (type == "img")
            {
                mElements.Add(CreateImage(dic));
            }
        }

        UpdateSize();
    }

    private void UpdateSize()
    {
        width = 0;
        height = 0;
        List<Vector3> poses = new List<Vector3>();
        int len = mElements.Count;
        for (int i = 0; i < len; i++)
        {
            IUGUIRichTextElement elem = mElements[i];
            poses.Add(new Vector3(width, 0, 0));
            width += elem.width;
            if (height < elem.height)
            {
                height = elem.height;
            }
        }

        for (int i = 0; i < len; i++)
        {
            RectTransform rt = mElements[i].gameObject.GetComponent<RectTransform>();
            Vector3 pos = poses[i];
            pos.x -= width / 2f;
            rt.localPosition = pos;
        }

        if (mOnResized != null)
        {
            mOnResized(this);
        }
    }

    private IUGUIRichTextElement CreateText(Dictionary<string, string> dic)
    {
        string colorStr = null;
        string boldStr = null;
        string italicStr = null;
        string text = null;

        dic.TryGetValue("color", out colorStr);
        dic.TryGetValue("bold", out boldStr);
        dic.TryGetValue("italic", out italicStr);
        dic.TryGetValue("text", out text);

        Color color = Color.white;

        if (colorStr != null)
        {
            colorStr = colorStr.Substring(colorStr.Length - 6, 6);
            float r = (float)(Convert.ToInt32(colorStr.Substring(0, 2), 16)) / 255.0f;
            float g = (float)(Convert.ToInt32(colorStr.Substring(2, 2), 16)) / 255.0f;
            float b = (float)(Convert.ToInt32(colorStr.Substring(4, 2), 16)) / 255.0f;
            color = new Color(r, g, b);
        }

        bool bold = (boldStr == "true" ? true : false);
        bool italic = (italicStr == "true" ? true : false);

        UGUIRichTextText txt = null;

        if (mTextPool.Count > 0)
        {
            txt = mTextPool[0];
            mTextPool.RemoveAt(0);
            txt.Use();
            txt.SetContent(text, color, mFont, mFontSize, bold, italic, mOutline);
        }
        else
        {
            txt = new UGUIRichTextText(gameObject, text, color, mFont, mFontSize, bold, italic, mOutline);
        }

        /*
        width += txt.width;
        if (height < txt.height)
        {
            height = txt.height;
        }
        */
        return txt;
    }

    private IUGUIRichTextElement CreateImage(Dictionary<string, string> dic)
    {
        string imgSrc = null;
        string imgName = null;
        string imgType = null;
        string imgWidth = null;
        string imgHeight = null;

        dic.TryGetValue("src", out imgSrc);
        dic.TryGetValue("name", out imgName);
        dic.TryGetValue("imageType", out imgType);
        dic.TryGetValue("width", out imgWidth);
        dic.TryGetValue("height", out imgHeight);

        int w = -1;
        int h = -1;
        int.TryParse(imgWidth, out w);
        int.TryParse(imgHeight, out h);

        UGUIRichTextImage img = null;

        if (mImagePool.Count > 0)
        {
            img = mImagePool[0];
            mImagePool.RemoveAt(0);
            img.Use();
            img.SetContent(imgSrc, imgName, imgType, w, h, OnImageDelayShown);
        }
        else
        {
            img = new UGUIRichTextImage(gameObject, imgSrc, imgName, imgType, w, h, OnImageDelayShown);
        }

        /*
        width += img.width;
        if (height < img.height)
        {
            height = img.height;
        }
        */
        return img;
    }

    private void OnImageDelayShown(UGUIRichTextImage img)
    {
        UpdateSize();
    }
}