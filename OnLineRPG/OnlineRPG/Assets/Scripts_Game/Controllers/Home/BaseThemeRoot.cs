using BetaFramework;

public class BaseThemeRoot : BaseHomeUI {
    public BaseThemeFsmManager fsmManager;

    public virtual bool IsIdle()
    {
        return fsmManager.IsIdle();
    }
}

public class BaseThemeFsmManager : StateMachine
{
    public const string Event_CheckRefresh = "checkRefresh";
    public const string Event_Popup = "Popup";
    public const string Event_PopupClose = "PopupClose";
    public const string Event_GuideClose = "GuideClose";
    
    public virtual bool IsIdle()
    {
        return false;
    }
}