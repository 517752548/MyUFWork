public class ActivityRootMessageState : BaseThemeMessageState
{
    protected ActivityFsmManager fsm => stateMachine as ActivityFsmManager;
    protected ActivityThemeRoot homeRoot => fsm.root;
    
    protected class ThemeMsg : BaseThemeMsg
    {
        public const int Unknown = 10;
    }

    protected override int CheckToShowMessage()
    {
        return base.CheckToShowMessage();
    }

    protected override void ShowMessage()
    {
        switch (msgType)
        {
            case ThemeMsg.Unknown:
                break;
            default:
                base.ShowMessage();
                break;
        }
    }
}