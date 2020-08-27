using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BetaFramework;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class LevelRewardDialog : UIWindowBase
{
    public Text desText;
    public TextMeshProUGUI progressText;
    public Slider progressImage;

    // Start is called before the first frame update
    void Start()
    {
        int oldLevel = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.LastValue;
        ClassicSubWorldEntity subWorldEntity = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().GetClassicSubWorld(oldLevel);
        
        var sys = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>();
        var completedLevelIndex = sys.currentLevel.Value - 1;
        sys.GetSubWorldBoxProgress(completedLevelIndex, out var currentProgress, out var currentMax);
        
        progressText.text = string.Format("{0}/{1}", currentProgress, currentMax);
        progressImage.value = (float)currentProgress / currentMax;
        desText.text = string.Format("Complete <color=#81191C><size=100>LEVEL {0}</size></color>\nto open!", completedLevelIndex + currentMax - currentProgress);
        LoadText();
    }

    public override IEnumerator EnterAnim(params object[] objs)
    {
        if (anim != null && hidingAnimation != null)
        {
            anim.SetTrigger("show");
        }

        yield return new WaitForSeconds(0.2f);

        OpenSuccess();
    }

    private async void LoadText()
    {
//        AsyncOperationHandle<TextAsset> level = Addressables.LoadAssetAsync<TextAsset>(
//            "version.txt");
//        await level;
//        if (level.Status == AsyncOperationStatus.Succeeded)
//        {
//            Debug.LogError("下载关卡成功" + level.Result.text);
//        }
//        else
//        {
//            Debug.LogError("下载关卡失败");
//        }
    }

    public void ClickOK()
    {
        UIManager.CloseUIWindow(this);
    }
}
