using BetaFramework;
using TMPro;
using UnityEngine;

public class SignItem : MonoBehaviour
{
    public Animator ani;
    public Transform content;
    public TextMeshProUGUI titleText;
    public Color todayColor, otherColor;
    public GameObject boxContent;
    public GameObject box1, box2;
    public GameObject completeFlag;
    public GameObject unknownBox1, unknownBox2;
    public GameObject unknownFlag;

    private const string Ani_go_toady = "gotoday";
    private const string Ani_toady = "today";
    private const string Ani_toady_now = "todaynow";
    private const string Ani_go_yesterday = "goyesterday";
    private const string Ani_yesterday = "yesterday";

    private int boxType;
    private int dayIndex;

    public void InitItem(int dayIndex, int todayIndex, int boxType)
    {
        this.boxType = boxType;
        this.dayIndex = dayIndex;

        content.localScale = Vector3.one;
        InitBox();
        if (dayIndex < todayIndex)
        {
            ani.SetTrigger(Ani_yesterday);
            titleText.color = otherColor;
            titleText.text = "Day " + (dayIndex + 1);
            boxContent.SetActive(false);
        }
        else if (dayIndex == todayIndex)
        {
            ani.SetTrigger(Ani_toady_now);
            boxContent.SetActive(true);
            //ShowBox(true, false, false, false);
            titleText.color = todayColor;
            titleText.text = "Today";
            //content.localScale = Vector3.one * 1.5f;
        }
        else if (dayIndex == (todayIndex + 1))
        {
            boxContent.SetActive(true);
            //ShowBox(false, true, true, false);
            titleText.color = otherColor;
            titleText.text = "Tomorrow";
        }
        else
        {
            boxContent.SetActive(true);
            //ShowBox(false, true, true, false);
            titleText.color = otherColor;
            titleText.text = "Day " + (dayIndex + 1);
        }
    }

    // private void ShowBox(bool box, bool unknownBox, bool unknown, bool complete)
    // {
    //     box1.SetActive(boxType == 1 && box);
    //     box2.SetActive(boxType == 2 && box);
    //     unknownBox1.SetActive(boxType == 1 && unknownBox);
    //     unknownBox2.SetActive(boxType == 2 && unknownBox);
    //     unknownFlag.SetActive(unknown);
    //     completeFlag.SetActive(complete);
    // }

    private void InitBox()
    {
        box1.SetActive(boxType == 1);
        box2.SetActive(boxType == 2);
        unknownBox1.SetActive(boxType == 1);
        unknownBox2.SetActive(boxType == 2);
    }

    public void PlayOpenBoxAni()
    {
    }

    public void PlayCompleteAni()
    {
        ani.SetTrigger(Ani_go_yesterday);
    }

    public void PlayUnlockAni()
    {
        ani.SetTrigger(Ani_go_toady);
        TimersManager.SetTimer(0.3f, () => { AppEngine.SSoundManager.PlaySFX(ViewConst.wav_sign_box_out); });
    }

    public int BoxType => boxType;
}