using BetaFramework;
using TMPro;
using UnityEngine;

public class RankThemeRoot : BaseThemeRoot
{
    public TextMeshProUGUI unlockLevel;
    public GameObject loading;
    public RankFsmManager FsmManager => fsmManager as RankFsmManager;

    public override void Init(HomeRoot root)
    {
        if (fsmManager == null)
        {
            fsmManager = gameObject.AddComponent<RankFsmManager>();
            FsmManager.Init(this);
        }
        base.Init(root);
    }

    public override void OnEnter()
    {
        base.OnEnter();
        if (AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value < 15)
        {
            unlockLevel.text =
                string.Format("Complete <color=#DEDDB7>Level {0}</color> to unlock <color=#DEDDB7>Titles</color>", 15);
        }
        else
        {
            unlockLevel.gameObject.SetActive(false);
        }
    }

    public void ShowLoading(bool show)
    {
        loading.SetActive(show);
    }
}