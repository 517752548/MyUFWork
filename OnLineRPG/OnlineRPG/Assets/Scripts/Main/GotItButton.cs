using BetaFramework;
using UnityEngine;
using UnityEngine.UI;

public class GotItButton : MonoBehaviour
{
    private Button button;

    // Use this for initialization
    private void Start()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    public void OnButtonClick()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
        //CommandChannel.GetInstance().PostCommand(CommonCommandConst.PLAY_SFX, ViewConst.wav_btn_normal);
    }
}