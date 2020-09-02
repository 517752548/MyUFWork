using BetaFramework;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EliteEnter : BaseEntranceBtn
{
    public override void OnShow()
    {
        GetComponentInChildren<Button>().onClick.AddListener(OnClick);
        if (AppEngine.SSystemManager.GetSystem<EliteSystem>().CanShowNew())
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
        base.OnShow();
    }
    public void OnClick()
    {
        HomeRootFsmManager.GiveMessage(HomeRootFsmManager.Event_MoveTab, HomeRootTab.activity);
        DOTween.Sequence().InsertCallback(0.5f, () =>
        {
            UIManager.OpenUIAsync(ViewConst.prefab_MagazineListDialog);
            // UIManager.OpenUIAsync(ViewConst.prefab_GameLoadingWindow, OpenType.Replace, (ui, para) =>
            //          {
            //              DataManager.ProcessData._GameMode = GameMode.Elite;
            //              MainSceneDirector.Instance.SwitchUi(GameUI.Game, ok =>
            //              {
            //                  Timer.Schedule(AppThreadController.instance, 0.2f, () =>
            //                  {
            //                      UIManager.CloseUIWindow(
            //                          UIManager.GetWindow<GameLoadingWindow>(ViewConst.prefab_GameLoadingWindow));
            //                  });
            //              });
            //
            //          });
        });
        Debug.LogError("click me");
    }
}