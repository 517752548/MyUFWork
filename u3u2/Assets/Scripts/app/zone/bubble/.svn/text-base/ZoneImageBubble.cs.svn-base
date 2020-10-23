using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace app.zone
{
    public class ZoneImageBubble : Cacheable, IZoneBubble
    {
        public const string CACHE_NAME = "app.zone.ZoneImageBubble";
        //public ZoneBubbleContentType contentType { get; private set; }
        public Tweener moveTweener { get; private set; }
        public Tweener fadeOutTweener { get; private set; }
        public Tweener fadeInTweener { get; private set; }
        public float secondsLeft { get; set; }
        public GameObject gameObject { get; private set; }
        public CanvasGroup canvasGroup { get; private set; }
        public float width { get; private set; }
        public float height { get; private set; }
        public string flyToBagTextureBundlePath { get; set; }
        public int flyToBagTimes { get; set; }
        public bool isDestroied { get; private set; }
        public bool isMoveFinished { get; private set; }

        private string mImageType = null;
        private string mBundlePath = null;
        private string mImgName = null;
        private GameObject mBackground = null;
        
        public ZoneImageBubble(string imageType, string bundlePath, string imgName = null, GameObject background = null)
        {
            //mImageType = imageType;
            //mBundlePath = bundlePath;
            //mImgName = imgName;
            mBackground = background;
            
            if (mBackground != null)
            {
                mBackground.SetActive(false);
            }
            
            gameObject = new GameObject("ZoneImageBubble");
            gameObject.transform.SetParent(UGUIConfig.GetCanvasByWndType(WndType.BUBBLES).transform);
            gameObject.layer = UGUIConfig.GetCanvasByWndType(WndType.BUBBLES).gameObject.layer;
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            gameObject.AddComponent<Canvas>();
            gameObject.AddComponent<CanvasRenderer>();
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            //this.contentType = contentType;
            isMoveFinished = false;
            SetContent(imageType, bundlePath, imgName);
            //LoadImageBundle();
        }

        public void SetContent(string imageType, string bundlePath, string imgName = null)
        {
            mImageType = imageType;
            mBundlePath = bundlePath;
            mImgName = imgName;
            LoadImageBundle();
        }

        private void LoadImageBundle()
        {
            SourceLoader.Ins.load(mBundlePath, OnImageBundleLoaded);
        }

        private void OnImageBundleLoaded(RMetaEvent e)
        {
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                Image img = gameObject.GetComponent<Image>();
                if (img == null)
                {
                    img = gameObject.AddComponent<Image>();
                }
                if (mImageType == "texture")
                {
                    Texture2D texture = SourceManager.Ins.GetAsset<Texture2D>(mBundlePath, mImgName);
                    img.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
                }
                else
                {
                    img.sprite = SourceManager.Ins.GetAsset<Sprite>(mBundlePath, mImgName);
                }
                
                img.rectTransform.localScale = new Vector3(1, 1, 1);
                img.SetNativeSize();
                width = img.rectTransform.sizeDelta.x;
                height = img.rectTransform.sizeDelta.y;

                if (mBackground != null)
                {
                    width += 20;
                    height += 20;

                    RectTransform rt = mBackground.AddComponent<RectTransform>();
                    mBackground.transform.SetParent(gameObject.transform);
                    mBackground.layer = gameObject.layer;
                    rt.localScale = Vector3.one;
                    rt.sizeDelta = new Vector2(width, height);
                    mBackground.transform.SetAsFirstSibling();
                    mBackground.SetActive(true);
                }
            }
        }

        public Tweener Move(Vector3 targetPos)
        {
            if (gameObject != null)
            {
                fadeInTweener = TweenUtil.FadeIn(gameObject.GetComponent<CanvasGroup>(), 0.2f, 0);
                moveTweener = TweenUtil.MoveTo(gameObject.transform, targetPos, 0.4f, null, delegate(){isMoveFinished = true;});
                return moveTweener;
            }
            return null;
        }

        public Tweener FadeOut()
        {
            if (gameObject != null)
            {
                //fadeOutTweener = TweenUtil.FadeOut(gameObject.GetComponent<CanvasGroup>(), 0.3f, ZoneBubbleManager.BUBBLE_EXIST_SECONDS - 1.5f);
                fadeOutTweener = TweenUtil.FadeOut(gameObject.GetComponent<CanvasGroup>(), 0.2f, 0);
                return fadeOutTweener;
            }
            return null;
        }

        public void KillMoveTweener()
        {
            if (moveTweener != null)
            {
                if (!moveTweener.IsInitialized())
                {
                    moveTweener.ForceInit();
                }

                if (!moveTweener.IsComplete())
                {
                    //moveTweener.Complete();
                }

                if (moveTweener.IsActive())
                {
                    DOTween.Kill(moveTweener);
                }

                moveTweener = null;
                isMoveFinished = true;
            }
        }

        public void KillFadeOutTweener()
        {
            if (fadeOutTweener != null)
            {
                if (!fadeOutTweener.IsInitialized())
                {
                    fadeOutTweener.ForceInit();
                }

                if (!fadeOutTweener.IsComplete())
                {
                    //fadeTweener.Complete();
                }

                if (fadeOutTweener.IsActive())
                {
                    DOTween.Kill(fadeOutTweener);
                }

                fadeOutTweener = null;
            }
        }
        
        public void KillFadeInTweener()
        {
            if (fadeInTweener != null)
            {
                if (!fadeInTweener.IsInitialized())
                {
                    fadeInTweener.ForceInit();
                }

                if (!fadeInTweener.IsComplete())
                {
                    //fadeTweener.Complete();
                }

                if (fadeInTweener.IsActive())
                {
                    DOTween.Kill(fadeInTweener);
                }

                fadeInTweener = null;
            }
        }

        public override string GetPoolName()
        {
            return ZoneImageBubble.CACHE_NAME;
        }

        public override int GetCacheType()
        {
            return MemCacheType.OTHER;
        }

        public override void Use()
        {
            base.Use();
            gameObject.SetActive(true);
            isMoveFinished = false;
        }

        public override void UnUse()
        {
            base.UnUse();
            KillMoveTweener();
            KillFadeOutTweener();
            KillFadeInTweener();
            gameObject.SetActive(false);
        }

        public override void Destroy()
        {
            UnUse();
            SourceManager.Ins.removeReference(mBundlePath, gameObject);
            gameObject = null;
            isDestroied = true;
        }
    }
}

