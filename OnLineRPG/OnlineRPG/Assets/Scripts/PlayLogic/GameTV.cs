using BetaFramework;
using System.Collections;
using UnityEngine;

public class GameTV : MonoBehaviour
{
    public Animator ani;
    public GameObject coinEffect;
    public GameObject NormalEffect;
    public GameObject AppearEffect;
    public GameObject VideoGuidGameObject;
    private bool isShown { get; set; }
    private bool canClick = true;

    private void OnEnable()
    {
        isShown = true;
    }

    private void OnDisable()
    {
        isShown = false;
        if (VideoGuidGameObject && VideoGuidGameObject.activeSelf) VideoGuidGameObject.SetActive(false);
    }

    public void VideoGuidShow()
    {
        if (VideoGuidGameObject && isShown)
        {
            VideoGuidGameObject.SetActive(true);
        }

//        DataManager.ProcessData.tvWrong3Guid = true;
    }

    public void SetAppearEffect()
    {
        AppearEffect.SetActive(true);
        NormalEffect.SetActive(false);
    }

    public void SetNormalEffect()
    {
        StartCoroutine(SetNormalEffectCor());
    }

    public void ClickButton()
    {
        if (!canClick)
            return;
        if (VideoGuidGameObject && VideoGuidGameObject.activeSelf)
        {
        }
        else
        {
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
            //CommandChannel.GetInstance().PostCommand(CommonCommandConst.PLAY_SFX, ViewConst.wav_btn_normal);
        }
    }

    private IEnumerator SetNormalEffectCor()
    {
        NormalEffect.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        AppearEffect.SetActive(true);
    }
}