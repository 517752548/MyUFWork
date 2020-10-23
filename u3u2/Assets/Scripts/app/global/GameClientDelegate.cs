using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameClientDelegate:AbsGameClientDelegate
{
    public override void PlayButtonMusic()
    {
        base.PlayButtonMusic();
        //AudioManager.Ins.PlayAudio(ClientConstantDef.BUTTON_CLICK_MUSIC_NAME,AudioEnumType.Role);
        AudioManager.Ins.PlatFormPlayAudio(AudioManager.Ins.btnClickSoundId);
    }
}
