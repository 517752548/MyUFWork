// using System;
// using BetaFramework;
// using DG.Tweening;
// using Scripts_Game.Managers.Systems;
// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;
//
// namespace Scripts_Game.Controllers.Home.Elements
// {
//     public class ChampionBoxPanel : BaseHomeUI
//     {
//         public TextMeshProUGUI progressText;
//         public Slider progressImage;
//         public Animator ani;
//
//         // Use this for initialization
//         private void Start()
//         {
//             ShowOldView();
//         }
//
//         public override void OnShow()
//         {
//             base.OnShow();
//             gameObject.SetActive(_homeRoot.CurrentWorld.WorldState == 0);
//             ShowOldView();
//         }
//
//         private void ShowOldView()
//         {
//             var sys = AppEngine.SSystemManager.GetSystem<ChampionChallengeSystem>();
//             var currentProgress = sys.SectionLevelProgress.LastValue;
//             var currentMax = sys.GetSectionLevelCount();
//
//             progressText.text = string.Format("{0}/{1}", currentProgress, currentMax);
//             progressImage.value = (float) currentProgress / currentMax;
//         }
//
//         public void PlayProgressAni(Action overCallback)
//         {
//             ani.SetTrigger("hit");
//             var sys = AppEngine.SSystemManager.GetSystem<ChampionChallengeSystem>();
//             var currentProgress = sys.SectionLevelProgress.Value;
//             var currentMax = sys.GetSectionLevelCount();
//             float imageProgress = (float) currentProgress / currentMax;
//             progressImage.DOValue(imageProgress, 0.5f).OnComplete(() =>
//             {
//                 progressText.text = string.Format("{0}/{1}", currentProgress, currentMax);
//
//                 if (currentProgress == currentMax)
//                 {
//                     //如果达到最大值就发送这个subworld的奖励
//                     ani.SetTrigger("full");
//                     AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_subBoxOpen);
//                     var rewardId = sys.GetSectionRewardId();
//                     var seq = DOTween.Sequence();
//                     seq.InsertCallback(1.2f, () =>
//                     {
//                         CommonRewardData _commonRewardData = new CommonRewardData();
//                         _commonRewardData.rewardId = rewardId;
//                         _commonRewardData.boxType = RewardBoxType.SubWorld;
//                         _commonRewardData.RewardSource = RewardSource.subWorld;
//                         _commonRewardData.callback = () =>
//                         {
//                             sys.SectionIndex.Value++;
//                             sys.SectionLevelProgress.Value = 0;
//                             currentProgress = sys.SectionLevelProgress.Value;
//                             currentMax = sys.GetSectionLevelCount();
//                             progressText.text = string.Format("{0}/{1}", currentProgress, currentMax);
//                             progressImage.value = 0;
//                         };
//                         UIManager.OpenUIAsync(ViewConst.prefab_CommonRewardDialog, OpenType.Over,
//                             ui => { overCallback?.Invoke(); }, null, null, _commonRewardData);
//                     });
//                     seq.InsertCallback(2.5f, () => ani.SetTrigger("idle"));
//                 }
//                 else
//                 {
//                     overCallback?.Invoke();
//                 }
//             });
//         }
//
//         public void ClickBox()
//         {
//             UIManager.OpenUIAsync(ViewConst.prefab_LevelRewardDialog);
//         }
//     }
// }