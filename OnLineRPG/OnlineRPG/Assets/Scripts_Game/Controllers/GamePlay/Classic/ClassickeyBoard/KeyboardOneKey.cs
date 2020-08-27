using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using BetaFramework;
using DG.Tweening;
using UnityEngine.EventSystems;

public class KeyboardOneKey : MonoBehaviour
{
	public Text text;
	public Action<string> keyAction;
	public OneKeyType oneKeyType;

	public KeyBoard _key;
	private Animator oneKeyAnimator;

	private bool ban = false;
	private AnimStatus _animStatus = AnimStatus.idle;

	private float delayAnimator = 0;
	private void Start()
	{
		oneKeyAnimator = GetComponent<Animator>();
		if (text)
			text.raycastTarget = false;

		OneKeyButton keyButton = gameObject.AddComponent<OneKeyButton>();
		keyButton.onClick.AddListener(Click);
		keyButton.press += Press;
		keyButton.idle += Idle;
        if (oneKeyType == OneKeyType.DeleteKey)
            keyButton.longPress += LongPress;
        Image image = transform.Find("Img_Box_Bg")?.GetComponent<Image>();
        image.raycastTarget = true;
		keyButton.targetGraphic = image;
	}

	public void Init()
	{

	}

	private void Press()
	{
		if (oneKeyType == OneKeyType.FunctionKey)
			return;
		if(oneKeyType == OneKeyType.DeleteKey)
			return;
		if (ban) return;
		if (_animStatus != AnimStatus.press)
		{
			_animStatus = AnimStatus.press;
			oneKeyAnimator?.SetTrigger("press");
		}
	}

	private void Idle()
	{
		if(oneKeyType == OneKeyType.DeleteKey)
			return;
		if (ban) return;
		if (_animStatus != AnimStatus.idle)
		{
			_animStatus = AnimStatus.idle;
			oneKeyAnimator?.SetTrigger("idle");
		}

	}

	public void SetBanDelay(float delay)
	{
		delayAnimator = delay * 0.1f + 0.5f;
	}
	
	public void SetStatus(KeyStatus status)
	{
		if (oneKeyType == OneKeyType.FunctionKey) {
			return;
		}
		if(oneKeyType == OneKeyType.DeleteKey)
			return;
		switch (status)
		{
			case KeyStatus.Normal:
				ban = false;
				if (_animStatus != AnimStatus.idle)
				{
					_animStatus = AnimStatus.idle;
					oneKeyAnimator?.SetTrigger("idle");
					text?.DOFade(1, 0.5f);
				}

				break;
			case KeyStatus.Ban:
				ban = true;
                if (delayAnimator > 0 && _animStatus != AnimStatus.idle)
                {
                    _animStatus = AnimStatus.idle;
                    oneKeyAnimator?.SetTrigger("idle");
                    text?.DOFade(1, 0.5f);
                    TimersManager.SetTimer(delayAnimator, () =>
                    {
                        _animStatus = AnimStatus.disable;
                        oneKeyAnimator?.SetTrigger("disable");
                        text?.DOFade(0, 0.5f);
                        delayAnimator = 0;
                    });
                }
				else if (_animStatus != AnimStatus.disable)
				{
					_animStatus = AnimStatus.disable;
					TimersManager.SetTimer(delayAnimator, () =>
					{
						oneKeyAnimator?.SetTrigger("disable");
						text?.DOFade(0, 0.5f);
						delayAnimator = 0;
					});

				}
				else
				{
					
				}

				break;
		}
	}
	
	public void Click() {
		if (ban) return;
		if (oneKeyType == OneKeyType.TextKey) {
			keyAction?.Invoke(_key.ToString());
		} else if (oneKeyType == OneKeyType.FunctionKey) {
			keyAction?.Invoke(_key.ToString());
		} else {
			keyAction?.Invoke("");
		}
	}

    private void LongPress(bool bStart)
    {
        if (bStart)
        {
            loopLongPressCor = StartCoroutine(LoopLongPress());
        }
        else
        {
            if (loopLongPressCor != null)
            {
                StopCoroutine(loopLongPressCor);
                loopLongPressCor = null;
            }
        }
    }
    private Coroutine loopLongPressCor = null;
    private IEnumerator LoopLongPress()
    {
        for (int i=0; i<20; i++)
        {
            if (i > 0)
                yield return new WaitForSeconds(0.15f);
            Click();
        }
        loopLongPressCor = null;
    }
}

public enum KeyStatus
{
	//可以点击的普通状态
	Normal,
	//禁止点击的状态
	Ban
}

public enum AnimStatus
{
	press,
	idle,
	disable
}

public enum OneKeyType
{
    TextKey,
    DeleteKey,
	FunctionKey,
}

public enum KeyBoard
{
	A,
	B,
	C,
	D,
	E,
	F,
	G,
	H,
	I,
	J,
	K,
	L,
	M,
	N,
	O,
	P,
	Q,
	R,
	S,
	T,
	U,
	V,
	W,
	X,
	Y,
	Z,
	Delete,
	Speech
}