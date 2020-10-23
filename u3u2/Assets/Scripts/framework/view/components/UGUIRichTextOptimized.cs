using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UGUIRichTextOptimized : MonoBehaviour
{
    public CanvasGroup canvasGroup { get; private set; }
    //public GameObject gameObject { get; private set; }
    public int width { get; protected set; }
    public int height { get; protected set; }
    private UGUIRIchTextTextComponent mTextArea = null;
    private List<Dictionary<string, string>> mContent = null;
    private bool mOutline = false;
    private bool mMultLine = false;
    private int mTextAreaWidth = 0;
    private UnityAction<UGUIRichTextOptimized> mOnResized = null;
    private List<IUGUIRichTextElement> mElements = new List<IUGUIRichTextElement>();
    private int mElemsWaitCreate = 0;

    //private List<UGUIRichTextImage> mImages = new List<UGUIRichTextImage>();

    private interface IUGUIRichTextElement
    {
        GameObject gameObject { get; }
        int width { get; }
        int height { get; }
        int lastLineWidth { get; }
        int startX { get; }
        List<string> lines { get; }
        void Init();
        void CreateLines(int startX, bool multline);
        void Destroy();
        void Update();
    }

    private class UGUIRichTextText : IUGUIRichTextElement
    {
        /// <summary>
        /// 最后一行的宽度。
        /// </summary>
        public int width { get; private set; }
        /// <summary>
        /// 单行的高度。
        /// </summary>
        public int height { get; private set; }
        public int lastLineWidth { get; private set; }
        public string plainText { get; private set; }
        public string color { get; private set; }
        public Font font { get; private set; }
        public int fontSize { get; private set; }
        public bool bold { get; private set; }
        public bool italic { get; private set; }
        public List<string> lines { get; private set; }
        public int maxWidth { get; private set; }
        public int startX { get; private set; }
        private FontStyle mFontStyle = FontStyle.Normal;
        private string mHref = null;
        private UnityAction<IUGUIRichTextElement> mOnCreated = null;
        public UGUIRichTextText(int maxWidth, string text, string color, Font font, int fontSize, bool bold, bool italic, string href, UnityAction<IUGUIRichTextElement> onCreated)
        {
            this.maxWidth = maxWidth;
            this.plainText = text;
            this.color = color;
            this.font = font;
            this.fontSize = fontSize;
            this.bold = bold;
            this.italic = italic;
            this.lines = new List<string>();
            mHref = href;
            mOnCreated = onCreated;

            if (bold && italic)
            {
                mFontStyle = FontStyle.BoldAndItalic;
            }
            else if (bold)
            {
                mFontStyle = FontStyle.Bold;
            }
            else if (italic)
            {
                mFontStyle = FontStyle.Italic;
            }
        }

        public GameObject gameObject
        {
            get
            {
                return null;
            }
        }

        public void Init()
        {
            font.RequestCharactersInTexture(plainText, fontSize, mFontStyle);

            if (mOnCreated != null)
            {
                mOnCreated(this);
            }
        }

        public void Update()
        {

        }

        public void CreateLines(int startX, bool multLine)
        {
            //List<float> lineWidths = new List<float>();
            List<char> curLine = new List<char>();
            int curLineWidth = startX;
            int linesCount = 0;
            this.startX = startX;
            CharacterInfo charInfo;
            int len = plainText.Length;
            for (int i = 0; i < len; i++)
            {
                char chr = plainText[i];
                font.GetCharacterInfo(chr, out charInfo, fontSize, mFontStyle);
                int charWidth = charInfo.advance;
                if (chr == '\n' || (maxWidth > 0 && (curLineWidth + charWidth) > maxWidth))
                {
                    if (!multLine)
                    {
                        lastLineWidth = curLineWidth;
                        break;
                    }
                    else
                    {
                        lines.Add(GetHtmlText(new string(curLine.ToArray())));
                        //lineWidths.Add(curLineWidth);
                        width = Mathf.Max(curLineWidth, width);
                        curLine = new List<char>();
                        curLineWidth = 0;
                        //this.startX = 0;
                        curLine.Add('\n');
                    }
                }

                if (chr != '\n')
                {
                    curLine.Add(chr);
                    curLineWidth += charWidth;
                }
            }

            width = Mathf.Max(curLineWidth, width);
            lastLineWidth = curLineWidth;

            if (curLine.Count > 0)
            {
                lines.Add(GetHtmlText(new string(curLine.ToArray())));
            }
            if (lines.Count > 0 && !string.IsNullOrEmpty(mHref))
            {
                lines[0] = "<a href=" + mHref + ">" + lines[0];
                lines[lines.Count - 1] = lines[lines.Count - 1] + "</a>";
            }

            //height = fontSize + fontSize / 7;
            if (lines.Count > 0)
            {
                height = fontSize;
            }
        }

        public void Destroy()
        {
            font = null;
            plainText = null;
            lines.Clear();
            lines = null;
        }

        private string GetHtmlText(string text)
        {
            string htmlText = "<color=" + color + "><size=" + fontSize + ">" + text + "</size></color>";
            if (bold)
            {
                htmlText = "<b>" + htmlText + "</b>";
            }
            if (italic)
            {
                htmlText = "<i>" + htmlText + "</i>";
            }
            return htmlText;
        }
    }

    private class UGUIRichTextImage : IUGUIRichTextElement
    {
        public GameObject gameObject { get; private set; }
        public Image image { get; private set; }
        public int width { get; private set; }
        public int height { get; private set; }
        public int lastLineWidth { get; private set; }
        public int imgWidth { get; private set; }
        public int imgHeight { get; private set; }
        public int startX { get; private set; }
        public List<string> lines { get; private set; }

        private string mImgType = null;

        private int mMaxWidth = 0;
        private GameObject mContainer = null;

        private string mSrc = null;
        private string mName = null;
        private int mWidth = 0;
        private int mHeight = 0;
        private string mHref = null;
        private UnityAction<IUGUIRichTextElement> mOnCreated = null;
        public UGUIRichTextImage(string imgType, int maxWidth, GameObject container, string src, string name, int width, int height, string href, UnityAction<IUGUIRichTextElement> onCreated)
        {
            mImgType = imgType;
            mMaxWidth = maxWidth;
            mContainer = container;
            mSrc = src;
            mName = name;
            mWidth = width;
            mHeight = height;
            mHref = href;
            mOnCreated = onCreated;

            gameObject = new GameObject("image");
            gameObject.transform.SetParent(container.transform);
            gameObject.layer = container.layer;
            RectTransform rt = gameObject.AddComponent<RectTransform>();
            rt.anchorMin = new Vector2(0, 1);
            rt.anchorMax = new Vector2(0, 1);
            rt.pivot = new Vector2(0, 1);
            rt.localScale = Vector3.one;
            gameObject.AddComponent<CanvasRenderer>();
            CanvasGroup canvasGroup = gameObject.AddComponent<CanvasGroup>();
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            this.lines = new List<string>();
        }

        public void Init()
        {
            if (mSrc != null)
            {
                if (SourceManager.Ins.hasAssetBundle(mSrc))
                {
                    CreateImage();
                }
                else
                {
                    LoadImage();
                }
            }
        }

        public void Update()
        {

        }

        public void CreateLines(int startX, bool multLine)
        {
            width = imgWidth;
            height = imgHeight;

            if (mMaxWidth > 0 && startX + width > mMaxWidth)
            {
                if (!multLine)
                {
                    width = 0;
                    height = 0;
                    lastLineWidth = 0;
                    return;
                }
                
                lines.Add("\n");
                //startX = 0;
            }
            else
            {
                width += startX;
            }

            lastLineWidth = width;

            this.startX = startX;

            string str = "<quad material=1 x=0 y=0 ysize=" + (imgHeight + 4) + " width=" + (float)imgWidth / (float)imgHeight + " />";
            //if (lines.Count > 0)
            //{
                //lines[0] = lines[0] + str;
            //}
            //else
            //{
                lines.Add(str);
            //}

            if (!string.IsNullOrEmpty(mHref))
            {
                lines[0] = "<a href=" + mHref + ">" + lines[0];
                lines[lines.Count - 1] = lines[lines.Count - 1] + "</a>";
            }
        }

        private void LoadImage()
        {
            SourceLoader.Ins.load(mSrc, OnImageLoaded, null, null, true);
        }

        private void OnImageLoaded(RMetaEvent e)
        {
            CreateImage();
        }

        private void CreateImage()
        {
            RectTransform rt = gameObject.GetComponent<RectTransform>();
            image = gameObject.AddComponent<Image>();
            if (mImgType == "texture")
            {
                Texture2D texture = SourceManager.Ins.GetAsset<Texture2D>(mSrc, mName);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
                image.sprite = sprite;
            }
            else if (mImgType == "sprite")
            {
                Sprite sprite = SourceManager.Ins.GetAsset<Sprite>(mSrc, mName);
                image.sprite = sprite;
            }

            if (image.sprite != null)
            {
                if (mWidth > 0 || mHeight > 0)
                {
                    float imgW = image.sprite.rect.width;
                    float imgH = image.sprite.rect.height;
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
                    rt.sizeDelta = new Vector2(imgW, imgH);
                }
                else
                {
                    image.SetNativeSize();
                }
            }
            else
            {
                rt.sizeDelta = new Vector2(mWidth, mHeight);
            }

            imgWidth = (int)rt.sizeDelta.x;
            imgHeight = (int)rt.sizeDelta.y;

            image.enabled = false;

            if (mOnCreated != null)
            {
                mOnCreated(this);
            }
        }

        public void Destroy()
        {
            SourceManager.Ins.removeReference(mSrc, gameObject);
            gameObject = null;
        }
    }

    private class UGUIRichTextAnimClip : IUGUIRichTextElement
    {
        public GameObject gameObject { get; private set; }
        public Image image { get; private set; }
        public int width { get; private set; }
        public int height { get; private set; }
        public int lastLineWidth { get; private set; }
        public int imgWidth { get; private set; }
        public int imgHeight { get; private set; }
        public int startX { get; private set; }
        public List<string> lines { get; private set; }

        private string mImgType = null;

        private int mMaxWidth = 0;
        private GameObject mContainer = null;

        private string mSrc = null;
        private string[] mFrames = null;
        private Sprite[] mClips = null;
        private int mWidth = 0;
        private int mHeight = 0;
        private int mFrameRate = 0;
        private string mHref = null;
        private UnityAction<IUGUIRichTextElement> mOnCreated = null;
        private int mCurClipIdx = 0;
        private int mTotalClips = 0;
        private float mSecondsPassed = 0.0f;
        private float mFrameSecondsNeed = 0.0f;
        private float mTotalSecondsNeed = 0.0f;

        public UGUIRichTextAnimClip(string imgType, int maxWidth, GameObject container, string src, string[] frames, int width, int height, int frameRate, string href, UnityAction<IUGUIRichTextElement> onCreated)
        {
            mImgType = imgType;
            mMaxWidth = maxWidth;
            mContainer = container;
            mSrc = src;
            mFrames = frames;
            mWidth = width;
            mHeight = height;
            mFrameRate = frameRate;
            mHref = href;
            mOnCreated = onCreated;

            gameObject = new GameObject("animClip");
            gameObject.transform.SetParent(container.transform);
            gameObject.layer = container.layer;
            RectTransform rt = gameObject.AddComponent<RectTransform>();
            rt.anchorMin = new Vector2(0, 1);
            rt.anchorMax = new Vector2(0, 1);
            rt.pivot = new Vector2(0, 1);
            rt.localScale = Vector3.one;
            gameObject.AddComponent<CanvasRenderer>();
            CanvasGroup canvasGroup = gameObject.AddComponent<CanvasGroup>();
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            this.lines = new List<string>();
        }

        public void Init()
        {
            if (mSrc != null)
            {
                if (SourceManager.Ins.hasAssetBundle(mSrc))
                {
                    CreateImage();
                }
                else
                {
                    LoadImage();
                }
            }
        }

        public void Update()
        {
            if (mTotalSecondsNeed > 0)
            {
                mSecondsPassed += Time.deltaTime;
                if (mSecondsPassed > mTotalSecondsNeed)
                {
                    mSecondsPassed = 0;
                }
                int idx = (int)(mSecondsPassed / mFrameSecondsNeed);
                image.sprite = mClips[idx];
                mCurClipIdx = idx;
            }
        }

        public void CreateLines(int startX, bool multLine)
        {
            width = imgWidth;
            //height = imgHeight + imgHeight / 7;
            height = imgHeight;

            if (mMaxWidth > 0 && startX + width > mMaxWidth)
            {
                if (!multLine)
                {
                    width = 0;
                    height = 0;
                    lastLineWidth = 0;
                    return;
                }

                lines.Add("\n");
                //startX = 0;
            }
            else
            {
                width += startX;
            }

            lastLineWidth = width;
            this.startX = startX;

            string str = "<quad material=1 x=0 y=0 size=" + (imgHeight + 4) + " width=" + (float)imgWidth / (float)imgHeight + " />";
            //if (lines.Count > 0)
            //{
                //lines[0] = lines[0] + str;
            //}
            //else
            //{
                lines.Add(str);
            //}

            if (!string.IsNullOrEmpty(mHref))
            {
                lines[0] = "<a href=" + mHref + ">" + lines[0];
                lines[lines.Count - 1] = lines[lines.Count - 1] + "</a>";
            }
        }

        private void LoadImage()
        {
            SourceLoader.Ins.load(mSrc, OnImageLoaded, null, null, true);
        }

        private void OnImageLoaded(RMetaEvent e)
        {
            CreateImage();
        }

        private void CreateImage()
        {
            RectTransform rt = gameObject.GetComponent<RectTransform>();
            image = gameObject.AddComponent<Image>();
            mClips = new Sprite[mFrames.Length];
            int len = mClips.Length;
            for (int i = 0; i < len; i++)
            {
                Sprite sprite = null;
                if (mImgType == "texture")
                {
                    Texture2D texture = SourceManager.Ins.GetAsset<Texture2D>(mSrc, mFrames[i]);
                    sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
                    //image.sprite = sprite;
                }
                else if (mImgType == "sprite")
                {
                    sprite = SourceManager.Ins.GetAsset<Sprite>(mSrc, mFrames[i]);
                    //image.sprite = sprite;
                }
                mClips[i] = sprite;
            }

            if (len > 0)
            {
                image.sprite = mClips[0];
                mCurClipIdx = 0;
                mFrameSecondsNeed = 1.0f / (float)mFrameRate;
                mTotalSecondsNeed = mFrameSecondsNeed * len;
            }
            else
            {
                mCurClipIdx = -1;
                mFrameSecondsNeed = 0;
                mTotalSecondsNeed = 0;
            }

            mTotalClips = len;
            mSecondsPassed = 0.0f;

            if (image.sprite != null)
            {
                if (mWidth > 0 || mHeight > 0)
                {
                    float imgW = image.sprite.rect.width;
                    float imgH = image.sprite.rect.height;
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
                    rt.sizeDelta = new Vector2(imgW, imgH);
                }
                else
                {
                    image.SetNativeSize();
                }
            }
            else
            {
                rt.sizeDelta = new Vector2(mWidth, mHeight);
            }

            imgWidth = (int)rt.sizeDelta.x;
            imgHeight = (int)rt.sizeDelta.y;

            image.enabled = false;

            if (mOnCreated != null)
            {
                mOnCreated(this);
            }
        }

        public void Destroy()
        {
            //SourceManager.Ins.removeReference(mSrc, gameObject);
            int len = mClips.Length;
            for (int i = 0; i < len; i++)
            {
                SourceManager.Ins.removeReference(mSrc);
            }
            mClips = null;
            GameObject.DestroyImmediate(gameObject);
            gameObject = null;
        }
    }

    private class UGUIRIchTextTextComponent : Text, IPointerClickHandler
    {
        public class HrefClickEvent : UnityEvent<string> { }

        private HrefClickEvent mOnHrefClick = new HrefClickEvent();

        /// <summary>
        /// 超链接点击事件
        /// </summary>
        public HrefClickEvent onHrefClick
        {
            get { return mOnHrefClick; }
            set { mOnHrefClick = value; }
        }
        public List<Image> images = new List<Image>();
        /// <summary>
        /// 图片的最后一个顶点的索引
        /// </summary>
        private readonly List<int> mImagesVertexIndex = new List<int>();
        private int mImagesVertexCount = 0;

        /// <summary>
        /// 超链接信息列表
        /// </summary>
        private readonly List<HrefInfo> mHrefInfos = new List<HrefInfo>();

        /// <summary>
        /// 文本构造器
        /// </summary>
        private static readonly StringBuilder smTextBuilder = new StringBuilder();

        /// <summary>
        /// 超链接正则
        /// </summary>
        private static readonly Regex smHrefRegex =
            new Regex(@"<a href=([^>\n\s]+)>(.*?)(</a>)", RegexOptions.Singleline);


        /// <summary>
        /// 正则取出所需要的属性
        /// </summary>
        private static readonly Regex smRegex =
            new Regex(@"<quad material=1 x=0 y=0 size=(\d*\.?\d+%?) width=(\d*\.?\d+%?) />", RegexOptions.Singleline);

        private VertexHelper mToFill = null;

        public override void SetVerticesDirty()
        {
            base.SetVerticesDirty();
            UpdateQuadImage();
        }

        /// <summary>
        /// 解析完最终的文本
        /// </summary>
        private string mOutputText;

        protected void UpdateQuadImage()
        {
#if UNITY_EDITOR
            if (UnityEditor.PrefabUtility.GetPrefabType(this) == UnityEditor.PrefabType.Prefab)
            {
                return;
            }
#endif

            mOutputText = GetOutputText();
            mImagesVertexIndex.Clear();
            int imageIndex = 0;
            foreach (Match match in smRegex.Matches(mOutputText))
            {
                int picIndex = match.Index + match.Length - 1;
                int endIndex = picIndex * 4 + 3;
                mImagesVertexIndex.Add(endIndex);
                images[imageIndex].enabled = true;
                imageIndex++;
            }

            mImagesVertexCount = mImagesVertexIndex.Count;
        }

        protected override void OnPopulateMesh(VertexHelper toFill)
        {
            string orignText = m_Text;
            m_Text = mOutputText;
            base.OnPopulateMesh(toFill);
            m_Text = orignText;

            mToFill = toFill;

            UIVertex vert = new UIVertex();
            for (int i = 0; i < mImagesVertexIndex.Count; i++)
            {
                int endIndex = mImagesVertexIndex[i];
                RectTransform rt = images[i].rectTransform;
                Vector2 size = rt.sizeDelta;
                if (endIndex < toFill.currentVertCount)
                {
                    toFill.PopulateUIVertex(ref vert, endIndex);
                    rt.anchoredPosition = new Vector2(vert.position.x, vert.position.y + size.y - 4);
                    // 抹掉左下角的小黑点
                    /*
                    toFill.PopulateUIVertex(ref vert, endIndex - 3);
                    Vector3 pos = vert.position;
                    for (int j = endIndex, m = endIndex - 3; j > m; j--)
                    {
                        toFill.PopulateUIVertex(ref vert, endIndex);
                        vert.position = pos;
                        toFill.SetUIVertex(vert, j);
                    }
                    */
                }
            }

            /*
            if (mImagesVertexIndex.Count > 0)
            {
                mImagesVertexIndex.Clear();
            }
            */

            // 处理超链接包围框
            foreach (HrefInfo hrefInfo in mHrefInfos)
            {
                hrefInfo.boxes.Clear();

                if (hrefInfo.startIndex >= toFill.currentVertCount)
                {
                    continue;
                }

                if (hrefInfo.sourceIsImg)
                {
                    //图片超链接
                    /*
                    string quadStr = hrefInfo.source;
                    Vector2 imgSize = GetQuadSize(quadStr);
                    
                    toFill.PopulateUIVertex(ref vert, hrefInfo.startIndex);
                    Vector3 startPos = vert.position;
                    Vector3 endPos = vert.position;
                    
                    for (int i = hrefInfo.endIndex - 1; i >= hrefInfo.startIndex; i--)
                    {
                        if (i < toFill.currentVertCount)
                        {
                            toFill.PopulateUIVertex(ref vert, i);
                            endPos = vert.position;
                            break;
                        }
                    }
                    
                    Vector3 leftCenter = new Vector3(startPos.x, startPos.y + endPos.y, 0);
                    hrefInfo.boxes.Add(new Rect(leftCenter.x, leftCenter.y - imgSize.y / 2.0f, imgSize.x, imgSize.y));
                    */
                }
                else
                {
                    //文字超链接
                    // 将超链接里面的文本顶点索引坐标加入到包围框
                    toFill.PopulateUIVertex(ref vert, hrefInfo.startIndex);
                    Vector3 pos = vert.position;
                    Bounds bounds = new Bounds(pos, Vector3.zero);

                    for (int i = hrefInfo.startIndex, m = hrefInfo.endIndex; i < m; i++)
                    {
                        if (i >= toFill.currentVertCount)
                        {
                            break;
                        }

                        toFill.PopulateUIVertex(ref vert, i);
                        pos = vert.position;
                        if (pos.x < bounds.min.x) // 换行重新添加包围框
                        {
                            hrefInfo.boxes.Add(new Rect(bounds.min, bounds.size));
                            bounds = new Bounds(pos, Vector3.zero);
                        }
                        else
                        {
                            bounds.Encapsulate(pos); // 扩展包围框
                        }
                    }
                    hrefInfo.boxes.Add(new Rect(bounds.min, bounds.size));
                }
            }

            mUpdateSecPassed = mUpdateDelta;
            LateUpdate();
        }

        private float mUpdateDelta = 5.0f;
        private float mUpdateSecPassed = 0.0f;

        public void LateUpdate()
        {
            if (mImagesVertexCount > 0)
            {
                mUpdateSecPassed += Time.unscaledDeltaTime;
                if (mUpdateSecPassed >= mUpdateDelta)
                {
                    if (mToFill != null && gameObject.activeInHierarchy)
                    {
                        UIVertex vert = new UIVertex();
                        for (int i = 0; i < mImagesVertexCount; i++)
                        {
                            int endIndex = mImagesVertexIndex[i];
                            if (endIndex < mToFill.currentVertCount)
                            {
                                mToFill.PopulateUIVertex(ref vert, endIndex);
                                // 抹掉左下角的小黑点
                                mToFill.PopulateUIVertex(ref vert, endIndex - 3);
                                Vector3 pos = vert.position;
                                for (int j = endIndex, m = endIndex - 3; j > m; j--)
                                {
                                    mToFill.PopulateUIVertex(ref vert, endIndex);
                                    vert.position = pos;
                                    mToFill.SetUIVertex(vert, j);
                                }
                            }
                        }
                    }
                    mUpdateSecPassed = 0.0f;
                }
            }
        }

        private Vector2 GetQuadSize(string quadStr)
        {
            string[] strArr = quadStr.Split(new char[] { '=' });
            string heightStr = strArr[1].Substring(0, strArr[1].IndexOf(" "));
            string widthScaleStr = strArr[2].Substring(0, strArr[2].IndexOf(" "));
            float height = float.Parse(heightStr);
            float widthScale = float.Parse(widthScaleStr);
            return new Vector2(height * widthScale, height);
        }

        /// <summary>
        /// 获取超链接解析后的最后输出文本
        /// </summary>
        /// <returns></returns>
        protected string GetOutputText()
        {
            smTextBuilder.Length = 0;
            mHrefInfos.Clear();
            int indexText = 0;
            foreach (Match match in smHrefRegex.Matches(text))
            {
                smTextBuilder.Append(text.Substring(indexText, match.Index - indexText));
                Group group = match.Groups[1];

                Match quadMatch = smRegex.Match(match.Value);
                if (string.IsNullOrEmpty(quadMatch.Value))
                {
                    //处理文字的超链接
                    HrefInfo hrefInfo = new HrefInfo
                    {
                        //int picIndex = match.Index + match.Length - 1;
                        //int endIndex = picIndex * 4 + 3;
                        startIndex = smTextBuilder.Length * 4, // 超链接里的文本起始顶点索引
                        endIndex = (smTextBuilder.Length + match.Groups[2].Length - 1) * 4 + 3,
                        source = match.Groups[2].Value,
                        name = group.Value,
                        sourceIsImg = false
                    };
                    mHrefInfos.Add(hrefInfo);
                }
                else
                {
                    //处理图片的超链接
                    HrefInfo hrefInfo = new HrefInfo
                    {
                        //int picIndex = match.Index + match.Length - 1;
                        //int endIndex = picIndex * 4 + 3;
                        startIndex = smTextBuilder.Length * 4, // 超链接里的文本起始顶点索引
                        endIndex = (smTextBuilder.Length + match.Groups[2].Length - 1) * 4 + 3,
                        source = match.Groups[2].Value,
                        name = group.Value,
                        sourceIsImg = true
                    };
                    mHrefInfos.Add(hrefInfo);
                }

                smTextBuilder.Append(match.Groups[2].Value);
                indexText = match.Index + match.Length;
            }
            smTextBuilder.Append(text.Substring(indexText, text.Length - indexText));
            return smTextBuilder.ToString();
        }

        /// <summary>
        /// 点击事件检测是否点击到超链接文本
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerClick(PointerEventData eventData)
        {
            Vector2 lp;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rectTransform, eventData.position, eventData.pressEventCamera, out lp);

            foreach (HrefInfo hrefInfo in mHrefInfos)
            {
                List<Rect> boxes = hrefInfo.boxes;
                for (int i = 0; i < boxes.Count; ++i)
                {
                    if (boxes[i].Contains(lp))
                    {
                        if (onHrefClick != null)
                        {
                            onHrefClick.Invoke(hrefInfo.name);
                        }
                        return;
                    }
                }
            }
        }

        public void Clear()
        {
            images.Clear();
            mImagesVertexIndex.Clear();
            mImagesVertexCount = 0;
            mHrefInfos.Clear();
            onHrefClick.RemoveAllListeners();
            text = "";
        }

        /// <summary>
        /// 超链接信息类
        /// </summary>
        private class HrefInfo
        {
            public int startIndex;

            public int endIndex;

            public string name;
            public string source;

            public bool sourceIsImg;
            public Vector2 imgSize;

            public readonly List<Rect> boxes = new List<Rect>();
        }
    }


    public void Awake()
    {
        //gameObject = new GameObject("UGUIRichTextOptimized");
        //GameObject textGo = new GameObject("text");
        //textGo.transform.SetParent(gameObject.transform);
        //RectTransform textRt = textGo.AddComponent<RectTransform>();
        //textRt.pivot = new Vector2(0, 1);
        //textRt.anchorMin = new Vector2(0, 1);
        //textRt.anchorMax = new Vector2(0, 1);
        //textRt.localScale = Vector3.one;
        mTextArea = gameObject.AddComponent<UGUIRIchTextTextComponent>();
        //ContentSizeFitter textSizeFitter = textGo.AddComponent<ContentSizeFitter>();
        //textSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        //textSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        //textGo.AddComponent<LayoutElement>();
    }

    public void Update()
    {
        int len = mElements.Count;
        for (int i = 0; i < len; i++)
        {
            mElements[i].Update();
        }
    }

    public UGUIRichTextOptimized SetParent(Transform parent)
    {
        gameObject.transform.SetParent(parent);
        gameObject.layer = parent.gameObject.layer;
        gameObject.transform.localScale = Vector3.one;
        gameObject.transform.localPosition = Vector3.zero;
        return this;
    }

    /// <summary>
    /// 设置内容。
    /// </summary>
    /// <param name="content"></param>
    /// <param name="font"></param>
    /// <param name="fontSize"></param>
    /// <param name="outline"></param>
    /// <param name="multline"></param>
    /// <param name="textAreaWidth"></param>
    /// <param name="onResized"></param>
    public UGUIRichTextOptimized SetContent(List<Dictionary<string, string>> content, Font font, int fontSize, Color? fontColor = null, bool outline = false, Color? outlineColor = null, bool multline = false, int textAreaWidth = 0, UnityAction<UGUIRichTextOptimized> onResized = null, UnityAction<string> onHrefClick = null)
    {
        Clear();
        mContent = content;
        mOutline = outline;
        mMultLine = multline;
        mTextAreaWidth = textAreaWidth;
        mOnResized = onResized;

        mTextArea.font = font;
        mTextArea.fontSize = fontSize;
        mTextArea.color = (fontColor ?? Color.white);
        mTextArea.lineSpacing = 1;
        mTextArea.supportRichText = true;
        mTextArea.alignment = TextAnchor.UpperLeft;
        //mTextArea.alignByGeometry = false;
        mTextArea.horizontalOverflow = HorizontalWrapMode.Overflow;
        mTextArea.verticalOverflow = VerticalWrapMode.Overflow;
        mTextArea.resizeTextForBestFit = false;

        if (outline)
        {
            Outline outlineComp = mTextArea.gameObject.GetComponent<Outline>();
            if (outlineComp == null)
            {
                outlineComp = mTextArea.gameObject.AddComponent<Outline>();
            }
            outlineComp.effectColor = (outlineColor ?? Color.black);
        }
        else
        {
            GameObject.DestroyImmediate(mTextArea.gameObject.GetComponent<Outline>(), true);
        }

        mTextArea.onHrefClick.AddListener(onHrefClick);

        /*
        font.RequestCharactersInTexture(" ", fontSize, FontStyle.Normal);
        CharacterInfo characterInfo;
        font.GetCharacterInfo(' ', out characterInfo, fontSize, FontStyle.Normal);
        mSpaceWidth = (int)characterInfo.advance;
        */
        Create();
        return this;
    }

    public void Clear()
    {
        if (mElements != null)
        {
            int len = mElements.Count;
            for (int i = 0; i < len; i++)
            {
                mElements[i].Destroy();
            }

            mElements.Clear();
        }

        if (mContent != null)
        {
            mContent.Clear();
        }

        mTextArea.Clear();

        width = 0;
        height = 0;
        mElemsWaitCreate = 0;
    }

    public virtual void Destroy()
    {
        Clear();
        GameObject.DestroyImmediate(gameObject, true);
    }

    private void Create()
    {
        bool hasImg = false;
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
                hasImg = true;
            }
            else if (type == "animClip")
            {
                mElements.Add(CreateAnimClip(dic));
            }
        }

        for (int i = 0; i < len; i++)
        {
            mElements[i].Init();
        }

        if (!hasImg)
        {
            //Show();
        }
    }

    private void Show()
    {
        string text = "";

        IUGUIRichTextElement lastElem = null;
        IUGUIRichTextElement curElem = null;
        IUGUIRichTextElement nextElem = null;

        int maxLineElemHeight = 0;
        int totalWidth = 0;
        int totalHeight = 0;
        int totalLineCount = 0;
        int len = mElements.Count;

        for (int i = 0; i < len; i++)
        {
            if (i > 0)
            {
                lastElem = mElements[i - 1];
                if (i < len - 1)
                {
                    nextElem = mElements[i + 1];
                }
            }

            curElem = mElements[i];

            if (lastElem == null)
            {
                curElem.CreateLines(0, mMultLine);
            }
            else
            {
                curElem.CreateLines(lastElem.lastLineWidth, mMultLine);
            }

            int linesCount = curElem.lines.Count;

            for (int j = 0; j < linesCount; j++)
            {
                text = text + curElem.lines[j];
            }

            if (curElem.startX == 0)
            {
                maxLineElemHeight = curElem.height;
                totalHeight += curElem.height * curElem.lines.Count;
                totalLineCount += curElem.lines.Count;
                //totalWidth = curElem.width;
                //int w = curElem.width;
            }
            else
            {
                //totalWidth = curElem.startX + curElem.width;
                totalHeight -= maxLineElemHeight;
                totalHeight += Mathf.Max(maxLineElemHeight, curElem.height);
                if (curElem.lines.Count > 1)
                {
                    totalHeight += curElem.height * (curElem.lines.Count - 1);
                }

                maxLineElemHeight = Mathf.Max(curElem.height, maxLineElemHeight);
            }

            if (curElem is UGUIRichTextImage)
            {
                //curElem.gameObject.transform.localPosition = new Vector3(curElem.startX, -(totalHeight - curElem.height), 0);
                curElem.gameObject.transform.localPosition = Vector3.zero;
                curElem.gameObject.transform.SetParent(gameObject.transform);
                curElem.gameObject.transform.localEulerAngles = Vector3.one;
                Image image = (curElem as UGUIRichTextImage).image;
                mTextArea.images.Add(image);
            }
            else if (curElem is UGUIRichTextAnimClip)
            {
                curElem.gameObject.transform.localPosition = Vector3.zero;
                curElem.gameObject.transform.SetParent(gameObject.transform);
                curElem.gameObject.transform.localEulerAngles = Vector3.one;
                Image image = (curElem as UGUIRichTextAnimClip).image;
                mTextArea.images.Add(image);
            }

            totalWidth = Mathf.Max(totalWidth, curElem.width);
        }

        mTextArea.text = text;
        width = Mathf.Max(width, mTextAreaWidth);
        height = totalHeight + Mathf.CeilToInt((float)totalLineCount * 2.5f) + 5;
        if (mOnResized != null)
        {
            mOnResized(this);
        }
        LayoutElement le = gameObject.GetComponent<LayoutElement>();
        le.preferredWidth = width;
        le.preferredHeight = height;
    }

    private IUGUIRichTextElement CreateText(Dictionary<string, string> dic)
    {
        string fontSizeStr = null;
        string color = null;
        string boldStr = null;
        string italicStr = null;
        string text = null;
        string hrefStr = null;

        dic.TryGetValue("size", out fontSizeStr);
        dic.TryGetValue("color", out color);
        dic.TryGetValue("bold", out boldStr);
        dic.TryGetValue("italic", out italicStr);
        dic.TryGetValue("text", out text);
        dic.TryGetValue("href", out hrefStr);

        int fontSize = mTextArea.fontSize;
        if (!string.IsNullOrEmpty(fontSizeStr))
        {
            int.TryParse(fontSizeStr, out fontSize);
        }

        if (string.IsNullOrEmpty(color))
        {
            color = "#" + ColorUtility.ToHtmlStringRGB(mTextArea.color);
        }

        bool bold = (boldStr == "true" ? true : false);
        bool italic = (italicStr == "true" ? true : false);

        mElemsWaitCreate++;
        UGUIRichTextText txt = new UGUIRichTextText(mTextAreaWidth, text, color, mTextArea.font, fontSize, bold, italic, hrefStr, OnElemCreated);
        return txt;
    }

    private IUGUIRichTextElement CreateImage(Dictionary<string, string> dic)
    {
        string imgType = null;
        string imgSrc = null;
        string imgName = null;
        string imgWidth = null;
        string imgHeight = null;
        string hrefStr = null;

        dic.TryGetValue("imageType", out imgType);
        dic.TryGetValue("src", out imgSrc);
        dic.TryGetValue("name", out imgName);
        dic.TryGetValue("width", out imgWidth);
        dic.TryGetValue("height", out imgHeight);
        dic.TryGetValue("href", out hrefStr);

        int w = -1;
        int h = -1;
        int.TryParse(imgWidth, out w);
        int.TryParse(imgHeight, out h);

        mElemsWaitCreate++;
        UGUIRichTextImage img = new UGUIRichTextImage(imgType, mTextAreaWidth, gameObject, imgSrc, imgName, w, h, hrefStr, OnElemCreated);
        /*
        width += img.width;
        if (height < img.height)
        {
            height = img.height;
        }
        */
        return img;
    }

    private IUGUIRichTextElement CreateAnimClip(Dictionary<string, string> dic)
    {
        string imgType = null;
        string imgSrc = null;
        string imgFrames = null;
        string imgFrameRateStr = null;
        string imgWidth = null;
        string imgHeight = null;
        string hrefStr = null;

        dic.TryGetValue("imageType", out imgType);
        dic.TryGetValue("src", out imgSrc);
        dic.TryGetValue("frames", out imgFrames);
        dic.TryGetValue("frameRate", out imgFrameRateStr);
        dic.TryGetValue("width", out imgWidth);
        dic.TryGetValue("height", out imgHeight);
        dic.TryGetValue("href", out hrefStr);

        int w = -1;
        int h = -1;
        int frameRate = 0;
        int.TryParse(imgWidth, out w);
        int.TryParse(imgHeight, out h);
        int.TryParse(imgFrameRateStr, out frameRate);
        mElemsWaitCreate++;
        UGUIRichTextAnimClip anim = new UGUIRichTextAnimClip(imgType, mTextAreaWidth, gameObject, imgSrc, imgFrames.Split(new char[] { ',' }), w, h, frameRate, hrefStr, OnElemCreated);
        /*
        width += img.width;
        if (height < img.height)
        {
            height = img.height;
        }
        */
        //return img;
        return anim;
    }

    private void OnElemCreated(IUGUIRichTextElement elem)
    {
        mElemsWaitCreate--;

        if (mElemsWaitCreate == 0)
        {
            Show();
        }
    }

    public static Dictionary<string, string> CreateTextElement(string text, int size, Color color, bool bold = false, bool italic = false, string href = "")
    {
        Dictionary<string, string> res = new Dictionary<string, string>();
        res.Add("type", "text");
        res.Add("text", text);
        res.Add("size", size.ToString());
        res.Add("color", "#" + ColorUtility.ToHtmlStringRGB(color));
        res.Add("href", href);
        res.Add("bold", bold.ToString());
        res.Add("italic", italic.ToString());
        return res;
    }

    public static Dictionary<string, string> CreateTextureElement(string src, string name, int width, int height, string href = "")
    {
        return CreateImageElement("texture", src, name, width, height, href);
    }

    public static Dictionary<string, string> CreateSpriteElement(string src, string name, int width, int height, string href = "")
    {
        return CreateImageElement("sprite", src, name, width, height, href);
    }

    private static Dictionary<string, string> CreateImageElement(string imgType, string src, string name, int width, int height, string href = "")
    {
        Dictionary<string, string> res = new Dictionary<string, string>();
        res.Add("type", "img");
        res.Add("imageType", imgType);
        res.Add("src", src);
        res.Add("name", name);
        res.Add("width", width.ToString());
        res.Add("height", height.ToString());
        res.Add("href", href);
        return res;
    }

    public static Dictionary<string, string> CreateTextureAnimClipElement(string src, string[] frames, int width, int height, int frameRate, string href = "")
    {
        return CreateAnimClipElement("texture", src, frames, width, height, frameRate, href);
    }

    public static Dictionary<string, string> CreateSpriteAnimClipElement(string src, string[] frames, int width, int height, int frameRate, string href = "")
    {
        return CreateAnimClipElement("sprite", src, frames, width, height, frameRate, href);
    }
    private static Dictionary<string, string> CreateAnimClipElement(string imgType, string src, string[] frames, int width, int height, int frameRate, string href = "")
    {
        Dictionary<string, string> res = new Dictionary<string, string>();
        res.Add("type", "animClip");
        res.Add("imageType", imgType);
        res.Add("src", src);
        string framesStr = "";
        int framesLen = frames.Length;
        for (int i = 0; i < framesLen; i++)
        {
            framesStr += frames[i];
            if (i < framesLen - 1)
            {
                framesStr += ",";
            }
        }
        res.Add("frames", framesStr);
        res.Add("frameRate", frameRate.ToString());
        res.Add("width", width.ToString());
        res.Add("height", height.ToString());
        res.Add("href", href);
        return res;
    }

    public static UGUIRichTextOptimized Create(Transform parent, string name = "UGUIRichTextOptimized")
    {
        GameObject go = new GameObject(name);
        RectTransform rt = go.AddComponent<RectTransform>();
        rt.pivot = new Vector2(0, 1);
        rt.anchorMin = new Vector2(0, 1);
        rt.anchorMax = new Vector2(0, 1);
        
        if (go.GetComponent<LayoutElement>() == null)
        {
            go.AddComponent<LayoutElement>();
        }
        /*
        ContentSizeFitter textSizeFitter = go.GetComponent<ContentSizeFitter>();
        if (textSizeFitter == null)
        {
            textSizeFitter = go.AddComponent<ContentSizeFitter>();
        }
        textSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        textSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        */
        UGUIRichTextOptimized res = go.AddComponent<UGUIRichTextOptimized>();
        res.SetParent(parent);
        res.transform.localScale = Vector3.one;
        res.transform.localEulerAngles = Vector3.zero;
        return res;
    }
}