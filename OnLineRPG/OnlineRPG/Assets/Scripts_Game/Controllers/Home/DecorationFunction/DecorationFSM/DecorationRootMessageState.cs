public class DecorationRootMessageState : BaseThemeMessageState
{
    protected DecorationFsmManager fsm => stateMachine as DecorationFsmManager;
    protected DecorationThemeRoot homeRoot => fsm.root;
    
    protected class ThemeMsg : BaseThemeMsg
    {
        public const int Unknown = 10;
        public const int Browsing = 11;
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
            case ThemeMsg.Browsing:
                
                break;
            default:
                base.ShowMessage();
                break;
        }
    }
}
