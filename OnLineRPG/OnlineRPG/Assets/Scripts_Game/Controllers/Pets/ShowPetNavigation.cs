using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowPetNavigation : MonoBehaviour
{
    public int index;
    public int count;
    private float aniDuration = 0.3f;
    
    [SerializeField]
    private Transform content;

    [SerializeField]
    private Image[] images;
    
    [SerializeField]
    private PageView pageView;

//    private void Start()
//    {
//        SetButtonsStates(false, true);
//    }

    public void bindNavigation()
    {
        pageView.OnPageChanged = pageChanged;
        if (content != null) { 
            Transform transform;
            for (int i = 0; i < content.transform.childCount; i++)
            {
                transform = content.transform.GetChild(i).GetComponent<Transform>();
                if (transform) {
                    count = count + 1;
                }
            }
        }
    }


    private void SetButtonsStates(bool leftOn, bool rightOn)
    {
        if (leftOn)
        {
            images[1].gameObject.SetActive(false);
        }
        else
        {
            images[1].gameObject.SetActive(true);
        }
        
        if (rightOn)
        {
            images[0].gameObject.SetActive(false);
        }
        else
        {
            images[0].gameObject.SetActive(true);
        }

//        buttons[0].interactable = leftOn;
//        buttons[0].transform.GetChild(0).GetComponent<Button>().interactable = leftOn;
//        buttons[1].interactable = rightOn;
//        buttons[1].transform.GetChild(0).GetComponent<Button>().interactable = rightOn;
    }
    
    public void onClick()
    {
        pageView.pageTo(0);
    }

    private void Destroy()
    {
        pageView.OnPageChanged = null;
    }
    
    private void pageChanged(int index)
    {
        this.index = index;
        SetImageIndexOn(index);
        setButtonStates(this.index);
    }

    private void setButtonStates(int index)
    {
        if (index == 0) {
            SetButtonsStates(false, true);
        } else if (index == count - 1) {
            SetButtonsStates(true, false);
        } else {
            SetButtonsStates(true, true);
        }

        setButtonStatusOnlyOne(index);
    }

    private void setButtonStatusOnlyOne(int index)
    {
        if (index == 0 && count == 1)
        {
            SetButtonsStates(false, false);
        }
    }

    public void pageTo(int index)
    {
        setButtonStates(index);
        pageView.pageTo(index);
    }

    private IEnumerator InitSelf()
    {
        yield return new WaitForSeconds(0.01f);

        pageView.gameObject.SetActive(true);
        pageView.pageTo(0);
    }
    
    private void SetImageIndexOn(int index)
    {
        /*for (int i = 0; i < ImageNavigation.Count; i++)
        {
            ImageNavigation[i].sprite = disableSprite;
            ImageNavigation[i].color = disableColor;
        }
        if (ImageNavigation.Count > index)
        {
            ImageNavigation[index].sprite = enableSprite;
            ImageNavigation[index].color = enableColor;
        }*/
    }
    
    public void NextPage()
    {
        int newIndex = this.index + 1;
        if (newIndex > count - 1) newIndex = count - 1;
        pageChanged(newIndex);
        pageView.PageToAnimation(newIndex, aniDuration);
        //CommandChannel.GetInstance().PostCommand(CommonCommandConst.PLAY_SFX, ViewConst.wav_panel_show);
    }

    public void PreviousPage()
    {
        int newIndex = this.index - 1;
        if (newIndex < 0) newIndex = 0;
        pageChanged(newIndex);
        pageView.PageToAnimation(newIndex, aniDuration);
        //CommandChannel.GetInstance().PostCommand(CommonCommandConst.PLAY_SFX, ViewConst.wav_panel_show);
    }
}
