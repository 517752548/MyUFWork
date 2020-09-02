using System;

public class DecorationThemeRoot : BaseThemeRoot
{
    public DecorationFsmManager FsmManager => fsmManager as DecorationFsmManager;
  
    public override bool IsIdle()
    {
        
        if (TitleData.isBrowsing || PetData.isBrowsing)
        {
            return false;
        }
        else
        {
            return FsmManager.IsIdle();
        }

        
    }
    
    public override void Init(HomeRoot root)
    {
        if (fsmManager == null)
        {
            fsmManager = gameObject.GetComponent<DecorationFsmManager>();
            if (fsmManager == null)
            {
                fsmManager = gameObject.AddComponent<DecorationFsmManager>();
                FsmManager.Init(this);
            }
        }
        base.Init(root);
    }

    public override void OnEnter() {
        base.OnEnter();
        //GetHomeUi<DecorationDialog>().OnShow();
    }
}