using System;
using System.Collections.Generic;
using BetaFramework;
using TMPro;
using UnityEngine;

namespace Scripts_Game.Controllers.Home.Elements
{
    public class LevelPlayButton : BaseHomeUI
    {
        public Animator HomeLevelBtn;
        public TextMeshProUGUI ClassicButtonText;
        public TextMeshProUGUI ClassicButtonTextBG;
        public HomeThemeRoot homeThemeRoot => root as HomeThemeRoot;
        public BeeCountBar beeCountBar;

        // public override void Init(HomeThemeRoot homeRoot)
        // {
        //     Debug.Log($"init {homeRoot}");
        //     base.Init(homeRoot);
        // }

        public override void OnShow()
        {
            RefreshBtnText(AppEngine.SyncManager.Data.ClassicLevel.LastValue);
            beeCountBar.Refresh();
            base.OnShow();
        }

        public void RefreshBtnText(int level)
        {
            var ClassicWorldEntity = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().GetClassicWorld(level);
            if (ClassicWorldEntity == null)
            {
                return;
            }

            if (ClassicWorldEntity.WorldState == 1)
            {
                ClassicButtonText.text = $"LEVEL {level}";
                ClassicButtonTextBG.text = $"LEVEL {level}";
            }
            else
            {
                ClassicButtonText.text = "Coming Soon";
                ClassicButtonTextBG.text = "Coming Soon";
            }
        }

        public void ClickLevelButton()
        {
            if (homeThemeRoot.CurrentWorld.WorldState != 1)
            {
                //EnterChampionChallengeLevel();
                UIManager.OpenUIAsync(ViewConst.prefab_WorldComingSoon);
            }
            else
            {
                EnterClassicLevel();
            }
        }

        private void NetErrorCallBack(int ok)
        {
        }

        private void EnterClassicLevel()
        {
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_home);
            UIManager.OpenUIAsync(ViewConst.prefab_GameLoadingWindow, OpenType.Replace, (ui, para) =>
            {
                AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().LoadClassicLevel(
                    AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value,
                    (ok) =>
                    {
                        if (ok)
                        {
                            DataManager.ProcessData._GameMode = GameMode.Classic;
                            MainSceneDirector.Instance.SwitchUi(GameUI.Game, oks =>
                            {
                                Timer.Schedule(AppThreadController.instance, 0.2f,
                                    () =>
                                    {
                                        UIManager.CloseUIWindow(
                                            UIManager.GetWindow<GameLoadingWindow>(ViewConst.prefab_GameLoadingWindow));
                                    });
                            });
                            //UIManager.CloseUIWindow();
                            
                        }
                        else
                        {
                            LoadLevelFailed();
                        }
                    });
            });
            //WikiController.Instance.Preload();
        }

        private void LoadLevelFailed()
        {
            Timer.Schedule(AppThreadController.instance, 0.2f,
                () =>
                {
                    UIManager.CloseUIWindow(
                        UIManager.GetWindow<GameLoadingWindow>(ViewConst.prefab_GameLoadingWindow));
                });
            Timer.Schedule(AppThreadController.instance, 0.5f,
                () =>
                {
                    //获取失败
                    ConstDelegate.NetErrorCallBack error = NetErrorCallBack;
                    UIManager.OpenUIAsync(ViewConst.prefab_NetConnectFailDialog, null, error);
                });
        }

        // private void EnterChampionChallengeLevel()
        // {
        //     AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_home);
        //     UIManager.OpenUIAsync(ViewConst.prefab_GameLoadingWindow, OpenType.Replace, (ui, para) =>
        //     {
        //         if (AppEngine.SSystemManager.GetSystem<ChampionChallengeSystem>().CurLevelValid.Value)
        //         {
        //             DataManager.ProcessData._GameMode = GameMode.Champion;
        //             MainSceneDirector.Instance.SwitchUi(GameUI.Game);
        //             TimersManager.SetTimer(0.2f,
        //                 () =>
        //                 {
        //                     UIManager.CloseUIWindow(
        //                         UIManager.GetWindow<GameLoadingWindow>(ViewConst.prefab_GameLoadingWindow));
        //                 });
        //         }
        //         else
        //         {
        //             AppEngine.SSystemManager.GetSystem<ChampionChallengeSystem>().GetLevel(level =>
        //             {
        //                 if (level != null)
        //                 {
        //                     DataManager.ProcessData._GameMode = GameMode.Champion;
        //                     MainSceneDirector.Instance.SwitchUi(GameUI.Game);
        //                     TimersManager.SetTimer(0.2f,
        //                         () =>
        //                         {
        //                             UIManager.CloseUIWindow(
        //                                 UIManager.GetWindow<GameLoadingWindow>(ViewConst.prefab_GameLoadingWindow));
        //                         });
        //                 }
        //                 else
        //                 {
        //                     Timer.Schedule(AppThreadController.instance, 0.2f,
        //                         () =>
        //                         {
        //                             UIManager.CloseUIWindow(
        //                                 UIManager.GetWindow<GameLoadingWindow>(ViewConst.prefab_GameLoadingWindow));
        //                         });
        //                     Timer.Schedule(AppThreadController.instance, 0.5f,
        //                         () =>
        //                         {
        //                             //获取失败
        //                             ConstDelegate.NetErrorCallBack error = NetErrorCallBack;
        //                             UIManager.OpenUIAsync(ViewConst.prefab_NetConnectFailDialog, null, error);
        //                         });
        //                 }
        //             });
        //         }
        //     });
        // }
        //
        // private void EnterChampionChallenge()
        // {
        //     AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_home);
        //     if (AppEngine.SSystemManager.GetSystem<ChampionChallengeSystem>().CurLevelValid.Value)
        //     {
        //         UIManager.OpenUIAsync(ViewConst.prefab_GameLoadingWindow, OpenType.Replace, (ui, para) =>
        //         {
        //             DataManager.ProcessData._GameMode = GameMode.Champion;
        //             MainSceneDirector.Instance.SwitchUi(GameUI.Game);
        //             TimersManager.SetTimer(0.2f,
        //                 () =>
        //                 {
        //                     UIManager.CloseUIWindow(
        //                         UIManager.GetWindow<GameLoadingWindow>(ViewConst.prefab_GameLoadingWindow));
        //                 });
        //         });
        //         
        //     }
        //     else
        //     {
        //         WaitDialog.StartWait(5f,
        //             () => { UIManager.OpenUIAsync(ViewConst.prefab_NetConnectFailDialog, null, null); });
        //         AppEngine.SSystemManager.GetSystem<ChampionChallengeSystem>().GetLevel(level =>
        //         {
        //             if (!WaitDialog.IsWaitEnd())
        //             {
        //                 WaitDialog.EndWait();
        //                 if (level == null)
        //                 {
        //                     UIManager.OpenUIAsync(ViewConst.prefab_NetConnectFailDialog, null, null);
        //                 }
        //                 else
        //                 {
        //                     UIManager.OpenUIAsync(ViewConst.prefab_GameLoadingWindow, OpenType.Replace, (ui, para) =>
        //                     {
        //                         DataManager.ProcessData._GameMode = GameMode.Champion;
        //                         MainSceneDirector.Instance.SwitchUi(GameUI.Game);
        //                         TimersManager.SetTimer(0.2f,
        //                             () =>
        //                             {
        //                                 UIManager.CloseUIWindow(
        //                                     UIManager.GetWindow<GameLoadingWindow>(ViewConst.prefab_GameLoadingWindow));
        //                             });
        //                     });
        //                 }
        //             }
        //         });
        //     }
        // }
    }
}