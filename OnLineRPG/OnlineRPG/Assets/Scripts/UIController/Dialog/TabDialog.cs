using BetaFramework;
using UnityEngine;

public class TabDialog : UIWindowBase
{
    public GameObject[] tabButtons;
    public GameObject[] tabContents;
    public GameObject[] tabNameObjects;
    public string[] tabName;

    protected int currentTab;

    public void TabChanged(int index)
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
        //CommandChannel.GetInstance().PostCommand(CommonCommandConst.PLAY_SFX, ViewConst.wav_btn_normal);
        currentTab = index;
        for (int i = 0; i < tabButtons.Length; i++)
        {
            // TabVisible(i);
            if (i == index)
            {
                TabSelected(i);
            }
            else
            {
                TabUnselected(i);
            }
        }
    }

    //protected virtual void TabVisible(int index)
    //{
    //}

    protected virtual void TabSelected(int index)
    {
        tabContents[index].SetActive(true);
    }

    protected virtual void TabUnselected(int index)
    {
        tabContents[index].SetActive(false);
    }

    public void SetCurrentTab(int index)
    {
        if (index == currentTab) return;
        TabChanged(index);
    }
}