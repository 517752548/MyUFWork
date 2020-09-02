using System;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.Cross.Dialog
{
    public class CrossNewComingDialog : UIWindowBase
    {
        private Action<bool> act = null;
        public override void OnOpen()
        {
            base.OnOpen();
            act = objs[0] as Action<bool>;
        }

        
        public void OnClickClose()
        {
            act?.Invoke(false);
            Close();
        }

        public void OnClickPlay()
        {
            act?.Invoke(true);
            Close();
        }
    }
}