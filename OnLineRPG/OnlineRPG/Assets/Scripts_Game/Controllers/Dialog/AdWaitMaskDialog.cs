using System;
using System.Collections;
using UnityEngine;

namespace Scripts_Game.Controllers.Dialog
{
    public class AdWaitMaskDialog : UIWindowBase
    {
        public int adType;
        private Action<int> clickCloseCallback = null;
        
        public override void OnOpen()
        {
            KeyEventManager.Instance.AddBackPressListener(KeyEventManager.Priority.hppp, onBackPressed);
            clickCloseCallback = (Action<int>) objs[0];
        }

        public override IEnumerator EnterAnim(params object[] objs)
        {
            //return base.EnterAnim(objs);
            yield return new WaitForEndOfFrame();
            OpenSuccess();
        }

        public override IEnumerator ExitAnim(UICallBack l_callBack, params object[] objs)
        {
            //return base.ExitAnim(l_callBack, objs);
            yield return new WaitForEndOfFrame();
            ExitSuccess();
        }

        public override void Close()
        {
            windowStatus = WindowStatus.Opened;
            base.Close();
        }

        public void ClickClose()
        {
            Close();
            clickCloseCallback?.Invoke(adType);
        }
    }
}