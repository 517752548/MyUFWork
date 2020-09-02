using BetaFramework;

public class SettingSoundCommand : ICommand
{
    public object Data { get; set; }

    public void Execute()
    {
    }

    public void Initilize()
    {
        //CommandChannel.GetInstance().PostCommand(CommonCommandConst.BGM_ENABLE, Record.GetBool(PrefKeys.MusicEnable, true));
        //CommandChannel.GetInstance().PostCommand(CommonCommandConst.SFX_ENABLE, Record.GetBool(PrefKeys.SFXEnable, true));
    }

    public void Release()
    {
    }
}