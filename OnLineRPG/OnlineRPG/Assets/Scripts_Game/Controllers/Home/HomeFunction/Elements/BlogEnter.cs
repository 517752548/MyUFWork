using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using UnityEngine;

namespace Scripts_Game.Controllers.Home.Elements
{
    public class BlogEnter : BaseEntranceBtn
    {
        public override void OnShow()
        {
            //Debug.LogError(DataManager.PlayerData.KnowledgeCards.Value.allCards.Count);
            //gameObject.SetActive(DataManager.PlayerData.KnowledgeCards.Value.allCards.Count > 0);
            gameObject.SetActive(AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value >= 1);
            base.OnShow();
        }

        public void PlayHitAni(Action overCallback)
        {
            var ani = gameObject.GetComponent<Animator>();
            if (ani != null)
                ani.SetTrigger("hit");
            DOTween.Sequence().InsertCallback(0.5f, () => overCallback?.Invoke());
            //overCallback?.Invoke();
        }

        public void OnClick()
        {
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
            UIManager.OpenUIAsync(ViewConst.prefab_KnowledgeCardDialog, OpenType.Stack, null, ui => {
                //_homeRoot.HomeFsmManager.TriggerEvent(HomeFsmManager.Event_GuideClose);
            });
        }
    }
}
