using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class DailyViewGuide : MonoBehaviour
{
    public GameObject firstUI;
    // Start is called before the first frame update
    void Start()
    {
        AppEngine.SSystemManager.GetSystem<UiLayerSystem>().HighLightUI(firstUI.transform, UILayer.UI, UiLayerOrder.High, false);
    }


    public void ClickOk()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
        gameObject.SetActive(false);
        AppEngine.SSystemManager.GetSystem<UiLayerSystem>().ResetUiLayer(firstUI.transform);
    }
}
