using UnityEngine;
using System.Collections;
using DG.Tweening;
using NaughtyAttributes;

[AddComponentMenu("UI/HybridUITween")]
public class HybridUITween : MonoBehaviour
{
	public enum TweenType
	{
		NONE,
		ALPHA,
		SCALE,
		LEFT_TO_RIGHT,
		RIGHT_TO_LEFT,
		TOP_TO_BOTTOM,
		BOTTOM_TO_TOP
	}
	public TweenType tweenType = TweenType.NONE;
	public Ease easeType = Ease.Linear;
	[Slider(0f, 3f)]
	public float delay = 0f;
	[Slider(0.1f, 1f)]
	public float duration = 0.3f;
	[Slider(100, 1000)]
	public int beginOffset = 200;
	[HideInInspector]
	private bool _isPlaying = false;

	public bool IsPlaying
	{
		get
		{
			return _isPlaying;
		}
	}

	void Start()
	{
		Execute();
	}

	public Tween Execute()
	{
		RectTransform rectTransform = transform as RectTransform;
		if (rectTransform == null)
			return null;

		Tween t = null;
		Rect rect = GetComponentAnchorToScreenRect(rectTransform);	
		float oldX = rectTransform.anchoredPosition.x;
		float oldY = rectTransform.anchoredPosition.y;
		switch (tweenType)
		{
			case TweenType.ALPHA:
				CanvasGroup cg = gameObject.GetComponent<CanvasGroup>();
				if (cg == null)
				{
					cg = gameObject.AddComponent<CanvasGroup>();
				}
				cg.alpha = 0f;
				t = cg.DOFade(1f, duration).SetEase(easeType).SetDelay(delay);
				break;
			case TweenType.SCALE:
				Animator animator = gameObject.GetComponent<Animator>();
				if (animator)
				{
					animator.enabled = false;
				}
				rectTransform.localScale = Vector3.zero;
				t = rectTransform.DOScale(1f, duration).SetEase(easeType).SetDelay(delay).OnComplete(delegate ()
				{
					if (animator)
					{
						animator.enabled = true;
					}
				});
				break;
			case TweenType.LEFT_TO_RIGHT:
				rectTransform.anchoredPosition = new Vector2((-rect.xMin) - rectTransform.sizeDelta.x - beginOffset, rectTransform.anchoredPosition.y);
				t = rectTransform.DOAnchorPosX(oldX, duration).SetEase(easeType).SetDelay(delay);
				break;
			case TweenType.RIGHT_TO_LEFT:
				rectTransform.anchoredPosition = new Vector2((rect.xMax) + rectTransform.sizeDelta.x + beginOffset, rectTransform.anchoredPosition.y);
				t = rectTransform.DOAnchorPosX(oldX, duration).SetEase(easeType).SetDelay(delay);
				break;
			case TweenType.TOP_TO_BOTTOM:
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, (rect.yMin) + rectTransform.sizeDelta.y + beginOffset);
				t = rectTransform.DOAnchorPosY(oldY, duration).SetEase(easeType).SetDelay(delay);
				break;
			case TweenType.BOTTOM_TO_TOP:
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, (-rect.yMin) - rectTransform.sizeDelta.y - beginOffset);
				t = rectTransform.DOAnchorPosY(oldY, duration).SetEase(easeType).SetDelay(delay);
				break;
		}
		if (t != null)
		{
			_isPlaying = true;
			Invoke("OnTweenPlayComplete", t.Delay() + t.Duration() + 0.2f);
		}
		return t;
	}

	void OnTweenPlayComplete()
	{
		_isPlaying = false;
	}
	//获取组件的锚点相对于Screen的Rect偏移 也就是锚点到left,right,top,bottom的距离
	Rect GetComponentAnchorToScreenRect(RectTransform rectTSF)
	{
		float screenWidth = Mathf.Max(1334, Screen.width);
		float screenHeight = Mathf.Max(750, Screen.height);
		Rect rect = new Rect();
		rect.xMin = screenWidth * rectTSF.anchorMin.x;
		rect.xMax = screenWidth * (1 - rectTSF.anchorMax.x);
		rect.yMin = screenHeight * (1 - rectTSF.anchorMin.y);
		rect.yMax = screenHeight * rectTSF.anchorMax.y;
		return rect;
	}
}
