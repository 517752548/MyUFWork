using System;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.Cross.Dialog
{
    public class CrossReplayDialog : UIWindowBase
    {
        private Action<int> clickCallback;
        
        public override void OnOpen()
        {
            base.OnOpen();
            clickCallback = objs[0] as Action<int>;
        }

        public void OnClickReplay()
        {
            Close();
            clickCallback?.Invoke(1);
        }

        public void OnClickNotPlay()
        {
            Close();
            clickCallback?.Invoke(0);
        }
    }
}