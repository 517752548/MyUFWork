using BetaFramework;

public class SelectHowToPlay : UIWindowBase
{
    public void OpenHowToPlayDialog()
    {
        UIManager.OpenUIAsync(ViewConst.prefab_HowToPlayDialog);
    }

    public void OpenSpecialLevelDialog()
    {
//        UIManager.OpenUIAsync(ViewConst.prefab_SpecialLevelDialog);
    }

    public void OpenBonusWorldDialog()
    {
//        UIManager.OpenUIAsync(ViewConst.prefab_BonusWorldDialog);
    }
}