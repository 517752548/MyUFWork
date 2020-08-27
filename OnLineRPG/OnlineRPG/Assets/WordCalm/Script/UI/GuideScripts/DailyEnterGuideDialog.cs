using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class DailyEnterGuideDialog : UIWindowBase
{
    public Transform arrow2;
    private ConstDelegate.RewardCallBack back;
    private DailyController button;
    public override void OnOpen()
    {
        base.OnOpen();
        back = objs[0] as ConstDelegate.RewardCallBack;
        button = FindObjectOfType<DailyController>();
        if (button)
        {
            MainSceneDirector.Instance.GetUIRoot(GameUI.Home)._imageMask.Show();
            AppEngine.SSystemManager.GetSystem<UiLayerSystem>().HighLightUI(button.transform,UILayer.UI,UiLayerOrder.Noamrl,false);
            arrow2.position = new Vector3(button.transform.position.x,button.transform.position.y,arrow2.position.z);
        }
    }

    public void ClickOk()
    {
        if (back != null)
        {
            back.Invoke();
        }
        MainSceneDirector.Instance.GetUIRoot(GameUI.Home)._imageMask.Hide();
        AppEngine.SSystemManager.GetSystem<UiLayerSystem>().ResetUiLayer(button.transform);
        AppEngine.SSystemManager.GetSystem<GuideSystem>().GuideShown_DailyEnter.Value = true;
        UIManager.CloseUIWindow(this);
    }
}
