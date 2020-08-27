using System;
using BetaFramework;
using Scripts.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts_Game.Controllers.DailyOneWord
{
    public class NextOneWordTipDialog : UIWindowBase
    {
        public Text timeText;

        private Action onCloseCallBack;
        
        public override void OnOpen()
        {
            onCloseCallBack = (Action) (objs != null && objs.Length > 0 ? objs[0] : null);
            base.OnOpen();
            AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().OnTimeUpdate += OnTimeUpdate;
            AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().UpdateTime();
        }

        public override void OnClose()
        {
            base.OnClose();
            AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().OnTimeUpdate -= OnTimeUpdate;
            onCloseCallBack?.Invoke();
        }

        private void OnTimeUpdate(int sec)
        {
            var time = new CountDownTime(sec);
            timeText.text = sec > CountDownTime.HourSeconds ? $"{time.TotalHour}H {time.Minute}M" : $"{time.Minute}M {time.Second}S";
        }
    }
}