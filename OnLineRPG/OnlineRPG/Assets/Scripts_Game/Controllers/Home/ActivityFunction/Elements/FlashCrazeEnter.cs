using BetaFramework;
using Scripts.Utility;
using TMPro;
using UnityEngine;

namespace Scripts_Game.Controllers.Home.ActivityFunction.Elements
{
    public class FlashCrazeEnter : BaseHomeUI
    {
        public Animator ani;
        public TextMeshProUGUI timeText;
        public GameObject VideoFlag;
        public GameObject lockObj;
        //public GameObject TimeObj;
        public TextMeshProUGUI lockText;

        private bool isCompleted;

        public void OnClick()
        {
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
            if (!AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().IsUnlocked())
            {
                UIManager.OpenUIAsync(ViewConst.prefab_CommonNotice_Level, OpenType.Replace, null,
                    string.Format("Level {0}",
                        AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().GetUnlockLevel()));
                return;
            }

            if (!AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().IsReady())
            {
                UIManager.OpenUIAsync(ViewConst.prefab_NetConnectFailDialog, null, null);
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
            var sys = AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>();
            AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().OnTimeUpdate += OnTimeUpdate;
            if (!sys.IsEnable())
            {
                if (sys.IsUnlocked())
                    lockText.text = $"No Network";
                else
                    lockText.text = $"Reach Lv.{sys.GetUnlockLevel()}\r\nto unlock";
                lockObj.SetActive(true);
                timeText.SetActive(false);
            }
            else
            {
                lockObj.SetActive(false);
                isCompleted = !sys.IsAllCompleted;
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
                if (lockObj.activeSelf)
                {
                    isCompleted = !AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().IsAllCompleted;
                    lockObj.SetActive(false);
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
                        timeText.SetActive(true);
                    }
                    else
                    {
                        ani.SetTrigger("now");
                        timeText.SetActive(false);
                    }
                }

                VideoFlag.SetActive(AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().CanRefreshExLevel);
            }
            else
            {
                ani.SetTrigger("wait");
                lockObj.SetActive(true);
                timeText.SetActive(false);
            }
        }
    }
}