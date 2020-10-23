using UnityEngine;
using DG.Tweening;

namespace app.zone
{
    public class ZoneImageTextBubble : UGUIImageText, IZoneBubble
    {
        public const string CACHE_NAME = "app.zone.ZoneImageTextBubble";
        //public ZoneBubbleContentType contentType { get; private set; }
        public Tweener moveTweener { get; private set; }
        public Tweener fadeOutTweener { get; private set; }
        public Tweener fadeInTweener { get; private set; }
        public float secondsLeft { get; set; }
        public string flyToBagTextureBundlePath { get; set; }
        public int flyToBagTimes { get; set; }
        public bool isDestroied { get; private set; }
        public bool isMoveFinished { get; private set; }
        private GameObject mBackground = null;

        public ZoneImageTextBubble(string atlasPath, string[] content, GameObject background = null)
        {
            gameObject.AddComponent<Canvas>();
            gameObject.AddComponent<CanvasRenderer>();
            CanvasGroup canvasGroup = gameObject.AddComponent<CanvasGroup>();
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            mBackground = background;
            SetParent(UGUIConfig.GetCanvasByWndType(WndType.BUBBLES).transform);
            SetContent(atlasPath, content);
            //this.contentType = contentType;
            isMoveFinished = false;
        }

        public override void SetContent(string atlasPath, string[] content, float space = 0)
        {
            base.SetContent(atlasPath, content, space);
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
            return ZoneImageTextBubble.CACHE_NAME;
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
            base.Destroy();
            mBackground = null;
            isDestroied = true;
        }
    }
}