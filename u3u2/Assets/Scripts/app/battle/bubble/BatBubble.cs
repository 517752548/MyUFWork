using app.story;
using UnityEngine;
using UnityEngine.UI;
using app.model;
using DG.Tweening;

namespace app.battle
{
    public class BatBubble : Cacheable
    {
        public UGUIImageText imgText { get; private set; }
        public Tweener moveTweener { get; private set; }
        public Tweener fadeTweener { get; private set; }
        
        private Tweener mBgScaleTweener = null;
        
        private float mSecondsLeft = 0f;
        //private int mContentLen = 0;
        private GameObject mBackground = null;

        public BatBubble()
        {
            imgText = new UGUIImageText();
            imgText.SetParent(UGUIConfig.GetCanvasByWndType(WndType.BUBBLES).transform);
            imgText.gameObject.AddComponent<Canvas>();
            imgText.gameObject.AddComponent<CanvasRenderer>();
        }

        public void Show(string[] content, Vector3 globalPos, float startY, bool isCrit, BatCharacterAttackType attackType,bool isStoryUse=false)
        {
            //mContentLen = content.Length;
            imgText.SetContent(PathUtil.Ins.uiDependenciesPath, content, -13.0f);
            Camera avatarCam = isStoryUse?StoryManager.ins.ModelCam.GetComponent<Camera>():SceneModel.ins.battleCam.GetComponent<Camera>();
            Vector3 v3 = globalPos;
            v3.y += startY;
            v3 = avatarCam.WorldToScreenPoint(v3);
            v3.z = 0f;
            Vector3 viewPt = UGUIConfig.GetCameraByWndType(WndType.BUBBLES).ScreenToWorldPoint(v3);
            viewPt = UGUIConfig.GetCanvasByWndType(WndType.BUBBLES).transform.InverseTransformPoint(viewPt);
            viewPt.y += imgText.height / 2.0f;
            viewPt.z = 0f;
            imgText.gameObject.transform.localPosition = viewPt;

            moveTweener = TweenUtil.MoveTo(imgText.gameObject.transform, new Vector3(viewPt.x, viewPt.y + 30, viewPt.z), 0.2f, null, null, null, 0, Ease.OutBack);
            fadeTweener = TweenUtil.FadeOut(imgText.gameObject.GetComponent<CanvasGroup>(), 0.5f, 0.6f);
            if (isCrit)
            {
                Sprite t = null;
                if (attackType == BatCharacterAttackType.STRENGTH)
                {
                    t = SourceManager.Ins.GetAsset<Sprite>(PathUtil.Ins.uiDependenciesPath, "baoji1");
                }
                else if (attackType == BatCharacterAttackType.INTELLECT)
                {
                    t = SourceManager.Ins.GetAsset<Sprite>(PathUtil.Ins.uiDependenciesPath, "baoji2");
                }

                if (t != null)
                {
                    if (mBackground == null)
                    {
                        mBackground = new GameObject();
                        mBackground.AddComponent<Image>();
                        mBackground.transform.SetParent(imgText.gameObject.transform);
                        mBackground.layer = imgText.gameObject.layer;
                    }

                    mBackground.gameObject.SetActive(true);
                    Image img = mBackground.GetComponent<Image>();

                    img.sprite = t;
                    RectTransform rt = mBackground.GetComponent<RectTransform>();
                    if (rt == null)
                    {
                        rt = mBackground.AddComponent<RectTransform>();
                    }

                    rt.localScale = Vector3.one;
                    rt.localPosition = Vector3.zero;
                    img.SetNativeSize();
                    //rt.sizeDelta = new Vector2(imgText.width + 120, imgText.height);
                    mBackground.transform.SetAsFirstSibling();
                    mBackground.transform.localScale = Vector3.zero;
                    TweenUtil.ScaleTo(mBackground.transform, Vector3.one, 0.2f, null, null, null, 0, Ease.OutBack);
                }
                else
                {
                    if (mBackground != null)
                    {
                        mBackground.gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                if (mBackground != null)
                {
                    mBackground.gameObject.SetActive(false);
                }
            }

            mSecondsLeft = 1.8f;
        }

        public float height
        {
            get
            {
                return imgText.height;
            }
        }

        public void Update()
        {
            if (GetIsUsed())
            {
                mSecondsLeft -= Time.deltaTime;
                if (mSecondsLeft <= 0)
                {
                    UnUse();
                };
            }
        }

        public override void Use()
        {
            base.Use();
            SetActive(true);
            imgText.gameObject.GetComponent<CanvasGroup>().alpha = 1.0f;
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
            }
        }

        public void KillFadeTweener()
        {
            if (fadeTweener != null)
            {
                if (!fadeTweener.IsInitialized())
                {
                    fadeTweener.ForceInit();
                }

                if (!fadeTweener.IsComplete())
                {
                    //fadeTweener.Complete();
                }

                if (fadeTweener.IsActive())
                {
                    DOTween.Kill(fadeTweener);
                }

                fadeTweener = null;
            }
        }
        
        private void KillBGScaleTweener()
        {
            if (mBgScaleTweener != null)
            {
                if (!mBgScaleTweener.IsInitialized())
                {
                    mBgScaleTweener.ForceInit();
                }

                if (!mBgScaleTweener.IsComplete())
                {
                    //fadeTweener.Complete();
                }

                if (mBgScaleTweener.IsActive())
                {
                    DOTween.Kill(mBgScaleTweener);
                }

                mBgScaleTweener = null;
            }
        }

        public override void UnUse()
        {
            KillMoveTweener();
            KillFadeTweener();
            KillBGScaleTweener();
            base.UnUse();
            SetActive(false);
        }

        public override string GetPoolName()
        {
            return BattleBubbleManager.BUBBLE_CATCH_NAME;
        }
        
        public override int GetCacheType()
        {
            return MemCacheType.OTHER;
        }
        
        public override bool IsBroken()
        {
            return (imgText == null);
        }

        public override void Destroy()
        {
            if (GetIsUsed())
            {
                UnUse();
            }

            imgText.Destroy();
            imgText = null;

        }

        public void SetActive(bool value)
        {
            imgText.gameObject.SetActive(value);
        }

        public bool GetActive()
        {
            return imgText.gameObject.activeSelf;
        }
    }
}