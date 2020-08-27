using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;
using UnityEngine.Scripting;

[Preserve]
public class GameSettingManager : IModule
{
    public RecordExtra.BoolPrefData Sound;
    public RecordExtra.BoolPrefData Music;
    public RecordExtra.BoolPrefData Notification;
    public RecordExtra.BoolPrefData SkipFilledSquares;
    public RecordExtra.BoolPrefData EraseWrongWord;
    public RecordExtra.BoolPrefData SelectFirstSolt;
    public RecordExtra.BoolPrefData ShowAnswer;
    public RecordExtra.BoolPrefData MarkFlyCell;
    public override void Init()
    {
        base.Init();
        Sound = new RecordExtra.BoolPrefData("PlayerSound",true);
        Music = new RecordExtra.BoolPrefData("PlayerMusic",true);
        Notification = new RecordExtra.BoolPrefData("PlayerNotification",true);
        SkipFilledSquares = new RecordExtra.BoolPrefData("SkipFilledSquares",true);
        EraseWrongWord = new RecordExtra.BoolPrefData("EraseWrongWord",false);
        SelectFirstSolt = new RecordExtra.BoolPrefData("SelectFirstSolt",false);
        ShowAnswer = new RecordExtra.BoolPrefData("ShowAnswer",false);
        MarkFlyCell = new RecordExtra.BoolPrefData("MarkFlyCell", true);
        if (PlatformUtil.GetNotificationState() != 1)
        {
            Notification.Value = false;
        }
        else
        {
            Notification.Value = true;
        }
        Music.ValueChanged.AddListener(BGMClick);
    }

    private void BGMClick()
    {
        AppEngine.SSoundManager.BgmEnable = Music.Value;
        if (!AppEngine.SSoundManager.BGMPlaying &&  AppEngine.SSoundManager.BgmEnable)
        {
            ClassicWorldEntity classicWorldEntity = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>()
                .GetClassicWorld(AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value);
            AppEngine.SSoundManager.PlayBGM(classicWorldEntity.BGMusic);
        }
        
    }
}
