using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class WorldUnlock : UIWindowBase
{
    public SpriteRenderer WorldImageLock;
    public Image WorldImageUnLock;
    public TextMeshProUGUI TextMeshProUguiLock;
    public TextMeshProUGUI TextMeshProUguiUnlockLock;
    private string worldName;
    private string worldImageName;
    private ConstDelegate.RewardCallBack callback;

    public override void OnOpen()
    {
        base.OnOpen();
        AppEngine.SSoundManager.BgmPause();
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_unlockWorld);
        worldName = objs[0] as string;
        worldImageName = objs[1] as string;
        callback = objs[2] as ConstDelegate.RewardCallBack;
        TextMeshProUguiLock.text = worldName;
        TextMeshProUguiUnlockLock.text = worldName;
        LoadImageLock();
        if (Const.AutoPlay)
        {
            TimersManager.SetTimer(3, () => { ClickClaim(); });
        }
    }

    private async void LoadImageUnLock()
    {
        CommUtil.LoadCachedImage(string.Format(worldImageName, "_unlock"), sp =>
        {
            if(sp != null && WorldImageUnLock != null)
            WorldImageUnLock.sprite = sp;
        });
    }
    private async void LoadImageLock()
    {
        CommUtil.LoadCachedImage(string.Format(worldImageName, "_locked"), sp =>
        {
            if(sp != null && WorldImageLock != null)
                WorldImageLock.sprite = sp;
            LoadImageUnLock();
        });
        // AsyncOperationHandle<Sprite> imageSprite =
        //     Addressables.LoadAssetAsync<Sprite>(string.Format(worldImageName, "_locked"));
        // await imageSprite.Task;
        // WorldImageLock.sprite = imageSprite.Result;
    }

    public void ClickClaim()
    {
        UIManager.CloseUIWindow(this);
    }

    public void ChangeBG()
    {
        AppEngine.SSoundManager.BgmUnPause();
        callback?.Invoke();
    }

    public override IEnumerator ExitAnim(UICallBack l_callBack, params object[] objs)
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_airfly);
        return base.ExitAnim(l_callBack, objs);
    }
}