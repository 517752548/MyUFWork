using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;
using UnityEngine.UI;

public class HomeAnimatorController : MonoBehaviour
{
    public Animator flyLevel;
    public Animator flyWeb;
    public Animator flyBlogCard;
    private Action flyLevelCallBack;
    private Action flyWebCallBack;
    private Action flyBlogCardCallBack;

    public void FlyLevel(Action callback)
    {
        this.flyLevelCallBack = callback;
        TimersManager.SetTimer(1, () =>
        {
            flyLevel.gameObject.SetActive(true);
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_flyKey);
        });
    }
    
    public void FlyLevelFinish()
    {
        if (flyLevelCallBack != null)
        {
            flyLevelCallBack.Invoke();
        }
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_Downkey);
        TimersManager.SetTimer(1, () => { flyLevel.gameObject.SetActive(false); });
    }

    public void FlyWeb(Action callback)
    {
        this.flyWebCallBack = callback;
        flyWeb.gameObject.SetActive(true);
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_flyHeart);
    }
    
    public void FlyWebFinish()
    {
        
        if (flyWebCallBack != null)
        {
            flyWebCallBack.Invoke();
        }
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_DownHeart);
        TimersManager.SetTimer(1, () =>
        {
            flyWeb.gameObject.SetActive(false);
        });
        
    }
    
    public void FlyBlogCard(Sprite img, Action callback)
    {
        flyBlogCardCallBack = callback;
        var blogImg = flyBlogCard.transform.Find("Fly/Fly_root/Piece1/Img_Mask/Img_Puzzle").GetComponent<Image>();
        blogImg.sprite = img;
        flyBlogCard.gameObject.SetActive(true);
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_fly_blog);
    }
    
    public void FlyBlogCardFinish()
    {
        flyBlogCardCallBack?.Invoke();
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_flyblog_down);
        TimersManager.SetTimer(1, () => { flyBlogCard.gameObject.SetActive(false); });
    }
}