using BetaFramework;
using Scripts.Utility;
using TMPro;
using UnityEngine;

namespace Scripts_Game.Controllers.Home.Elements
{
    public class FlashCrazeShortcut : BaseEntranceBtn
    {
        public Animator ani;
        public TextMeshProUGUI timeText;
        public GameObject VideoFlag;
        public GameObject TimeObj;
        
        private bool isCompleted;

        public void OnClick()
        {
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
            if (!AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().IsReady())
            {
                UIManager.OpenUIAsync(ViewConst.prefab_NetConnectFailDialog,null, null);
                AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().Load();
                return;
            }
            UIManager.OpenUIAsync(ViewConst.prefab_GameLoadingWindow, OpenType.Replace, (ui, para) =>
            {
                DataManager.ProcessData._GameMode = GameMode.OneWord;
                MainSceneDirector.Instance.SwitchUi(GameUI.Game, ok =>
                {
                    Timer.Schedule(AppThreadController.instance, 0.2f, () =>
                    {
                        UIManager.CloseUIWindow(
                            UIManager.GetWindow<GameLoadingWindow>(ViewConst.prefab_GameLoadingWindow));
                    });
                });
            });
        }

        public override void OnEnter()
        {
            base.OnEnter();
            AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().OnTimeUpdate += OnTimeUpdate;
            if (!AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().IsEnable())
            {
                gameObject.SetActive(false);
                TimeObj.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
                isCompleted = !AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().IsAllCompleted;
                AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().UpdateTime();
            }
        }

        public override void OnLeave()
        {
            base.OnLeave();
            AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().OnTimeUpdate -= OnTimeUpdate;
        }


        private void OnTimeUpdate(int sec)
        {
            if (AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().IsEnable())
            {
                if (!gameObject.activeSelf)
                {
                    isCompleted = !AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().IsAllCompleted;
                    gameObject.SetActive(true);
                }

                var time = new CountDownTime(sec);
                timeText.text = sec > CountDownTime.HourSeconds
                    ? $"{time.TotalHour:D2}h:{time.Minute:D2}m"
                    : $"{time.Minute:D2}m:{time.Second:D2}s";
                if (AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().IsAllCompleted != isCompleted)
                {
                    isCompleted = !isCompleted;
                    if (isCompleted)
                    {
                        ani.SetTrigger("wait");
                        TimeObj.SetActive(true);
                    }
                    else
                    {
                        ani.SetTrigger("now");
                        TimeObj.SetActive(false);
                    }
                }

                VideoFlag.SetActive(AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().CanRefreshExLevel);
            }
            else
            {
                ani.SetTrigger("wait");
                gameObject.SetActive(false);
                TimeObj.SetActive(false);
            }
        }
    }
}