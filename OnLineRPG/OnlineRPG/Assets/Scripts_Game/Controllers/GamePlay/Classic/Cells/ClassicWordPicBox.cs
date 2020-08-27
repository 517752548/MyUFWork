using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using BetaFramework;
using DG.Tweening;
using UnityEngine.AddressableAssets;

public class ClassicWordPicBox : MonoBehaviour
{
    public Image image;
    public RectTransform content;
    public float maxHeight;
    public float Height;
    public Animator ani;

    //private ClassicCellManager cellManager = null;
    private Action closeCallback = null;
    private BaseWord curPicWord = null;
    private bool isVisible;
    private Sequence closeAniSeq;

    public void Init()
    {
        Height = -1;
        gameObject.SetActive(false);
        //this.cellManager = cellManager;
        ani = GetComponent<Animator>();
        ani.enabled = true;
        isVisible = true;
        closeAniSeq = null;
    }

    public void SetCloseCallback(Action callback)
    {
        closeCallback = callback;
    }

    public bool Close()
    {
        if (Height < 0)
            return false;
        //LoggerHelper.Exception(new NotImplementedException("zxf===picBox close " + curPicWord.Answer));
        Height = -1;
        curPicWord = null;
        //gameObject.SetActive(false);
        //closeCallback?.Invoke();
        //ani.enabled = true;
        if (isVisible)
        {
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
            ani.SetTrigger("disappear");
            curTrigger = "disappear";
            closeAniSeq = DOTween.Sequence();
            closeAniSeq.AppendInterval(0.25f);
            // seq.AppendCallback(() => {
            //     gameObject.SetActive(false);
            //     closeCallback?.Invoke();
            // });seq.Kill();seq.Complete();
            closeAniSeq.OnComplete(() =>
            {
                closeAniSeq = null;
                gameObject.SetActive(false);
                closeCallback?.Invoke();
            });
        }
        else
        {
            isVisible = true;
            gameObject.SetActive(false);
            closeCallback?.Invoke();
        }

        return true;
    }

    public void ClickClose()
    {
        // if (!Record.GetBool(PrefKeys.KCDFirst))
        // {
        //     Addressables.LoadAssetAsync<GameObject>(ViewConst.prefab_AnswerImageGui).Completed += op =>
        //     {
        //         GameObject guide = Instantiate(op.Result);
        //         guide.transform.SetParent(transform.parent.Find("AnswerDes"), false);
        //     };
        // }

        Close();
    }

    public void Show(BaseWord word, Sprite sprite)
    {
        curPicWord = word;
        AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_PicBoxOpen);
        float width = sprite.textureRect.width;
        float height = sprite.textureRect.height;
        //Height = height;
        //if (height > maxHeight)
        {
            Height = maxHeight;
            width *= (maxHeight / height);
        }
        content.sizeDelta = new Vector2(width, Height);
        image.sprite = sprite;
        //ani.enabled = true;
        if (closeAniSeq != null)
        {
            closeAniSeq.Kill(true);
            closeAniSeq = null;
        }
        gameObject.SetActive(true);
        ani.SetTrigger("appear");
        curTrigger = "appear";
    }

    private string curTrigger = "";
    public void SetVisible(bool visible)
    {
        if (Height < 0)
            return;
        //LoggerHelper.Exception(new NotImplementedException("zxf===picBox visible " + curPicWord.Answer + " | " + visible));
        //ani.enabled = false;
        //gameObject.transform.localScale = visible ? Vector3.one : Vector3.zero;
        isVisible = visible;
        var trigger = visible ? "show" : "hide";
        // if (trigger.Equals(curTrigger))
        //     return;
        // curTrigger = trigger;
        ani.SetTrigger(trigger);
    }

    public bool IsShown(BaseWord word = null)
    {
        if (word == null)
            return curPicWord != null;
        return curPicWord == word && curPicWord != null;
    }

    public bool IsClosing()
    {
        return Height <= 0 && gameObject.activeSelf;
    }
    
    public void Hide()
    {
        if (Height < 0)
            return;
        //LoggerHelper.Exception(new NotImplementedException("zxf===picBox hide " + curPicWord.Answer));
        Height = -1;
        curPicWord = null;
        //gameObject.SetActive(false);
        //closeCallback?.Invoke();
        //ani.enabled = true;
        if (isVisible)
        {
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
            ani.SetTrigger("disappear");
            curTrigger = "disappear";
            closeAniSeq = DOTween.Sequence();
            closeAniSeq.AppendInterval(0.25f);
            closeAniSeq.OnComplete(() =>
            {
                closeAniSeq = null;
                gameObject.SetActive(false);
                //closeCallback?.Invoke();
            });
        }
        else
        {
            isVisible = true;
            gameObject.SetActive(false);
            //closeCallback?.Invoke();
        }
    }
}
