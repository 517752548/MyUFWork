using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts_Game.Controllers.Home.Elements
{
    public class EmailEnter : BaseEntranceBtn
    {
        public override void OnShow()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
            gameObject.SetActive(AppEngine.SSystemManager.GetSystem<EmailSystem>().HasNewEmail());
            AppEngine.SSystemManager.GetSystem<EmailSystem>().newStateChangeAction += (flag)=>{
                gameObject.SetActive(flag);
            };
            base.OnShow();
        }

        // public void PlayHitAni(Action overCallback)
        // {
        //     var ani = gameObject.GetComponent<Animator>();
        //     if (ani != null)
        //         ani.SetTrigger("hit");
        //     DOTween.Sequence().InsertCallback(0.5f, () => overCallback?.Invoke());
        //     //overCallback?.Invoke();
        // }

        public void OnClick()
        {
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
            UIManager.OpenUIAsync(ViewConst.prefab_EmaliSliderDialog, OpenType.Stack, (ui) =>
            {
                gameObject.SetActive(AppEngine.SSystemManager.GetSystem<EmailSystem>().HasNewEmail());
            });
        }
    }
}
