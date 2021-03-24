using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


[AddComponentMenu("UI/RollText")]
public class RollText : MonoBehaviour
{
	public float speedTime = 2f;
	public bool isDefaultPlay = false;
	public RectTransform mask;
	public RectTransform textTSF;
	private Sequence seq = null;

	void Awake()
	{
		InitData();
	}

	// Start is called before the first frame update
	void Start()
	{
		if (isDefaultPlay)
		{
			PlayTween();
		}
	}

	public void InitData()
	{
		if (textTSF == null)
		{
			return;
		}

		textTSF.anchorMin = new Vector2(0, 0.5f);
		textTSF.anchorMax = new Vector2(0, 0.5f);
		textTSF.pivot = new Vector2(0, 0.5f);
		textTSF.sizeDelta = new Vector2(mask.rect.width, mask.rect.height);
	}

	public void PlayTween()
	{
		if (textTSF == null || mask == null)
		{
			return;
		}

		if (seq != null)
		{
			seq.Kill();
		}

		textTSF.DOKill();
		textTSF.anchoredPosition = new Vector2(0, textTSF.anchoredPosition.y);

		float preferredWidth = textTSF.GetComponent<Text>().preferredWidth;
		float maskWidth = mask.rect.width;
		float rectHeight = textTSF.rect.height;
		if (preferredWidth <= maskWidth)
		{
			textTSF.sizeDelta = new Vector2(maskWidth, rectHeight);
			return;
		}

		textTSF.sizeDelta = new Vector2(preferredWidth, rectHeight);


		seq = DOTween.Sequence();
		seq.AppendInterval(2);
		seq.Append(textTSF.DOAnchorPosX(0 - (preferredWidth - maskWidth), speedTime));
		seq.AppendInterval(2);
		seq.SetLoops(-1, LoopType.Restart);
	}


	public void StopPlayTween()
	{
		if (textTSF == null)
		{
			return;
		}

		if (seq == null)
		{
			return;
		}

		seq.Kill();
		seq = null;

		textTSF.DOKill();
		textTSF.anchoredPosition = new Vector2(0, textTSF.anchoredPosition.y);
	}

	private void OnDestroy()
	{
		StopPlayTween();
		mask = null;
	}
}
