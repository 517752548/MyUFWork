using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class BGController : MonoBehaviour
{
    public Image bg1;
    public Image bg2;
    private string currentBGName;

    private void Start()
    {
    }
    public async void ChangeBGFirst(string baImage)
    {
        if (baImage == currentBGName)
        {
            return;
        }
        CommUtil.LoadCachedImage(baImage, bg =>
        {
            //Sprite bg = await Addressables.LoadAssetAsync<Sprite>(baImage).Task;
            if (!bg)
            {
                return;
            }

            if (bg == null)
            {
                return;
            }
            bg1.sprite = bg;
            bg2.sprite = bg;
            currentBGName = baImage;
        });
        
    }
    public async void ChangeBG(string baImage)
    {
        if (baImage == currentBGName)
        {
            return;
        }

        CommUtil.LoadCachedImage(baImage, bg =>
        {
            //Sprite bg = await Addressables.LoadAssetAsync<Sprite>(baImage).Task;
            if (!bg)
            {
                return;
            }
            bg1.sprite = bg;
            bg2.DOFade(0, 1f).OnComplete(() =>
            {
                bg2.sprite = bg;
                bg2.DOFade(1, 0);
            });
            currentBGName = baImage;
        });
        
    }
}
