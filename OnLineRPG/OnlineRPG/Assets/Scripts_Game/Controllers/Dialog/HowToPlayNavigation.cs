using BetaFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayNavigation : MonoBehaviour
{
    public int index;
	public int count;

    [SerializeField]
    private Transform content;

    [SerializeField]
    private Button[] buttons;

    public Image[] images;

    [SerializeField]
    private PageView pageView;

    private float aniDuration = 0.3f;

    // Use this for initialization
    private List<Image> ImageNavigation = new List<Image>();

    public Color disableColor;
    public Color enableColor;
    public Sprite disableSprite;
    public Sprite enableSprite;
    private Text pageIndexText;
	public bool hasPageText = false;

    private void Start()
    {
        SetButtonsStates(false, true);
        pageView.OnPageChanged = pageChanged;
		if (content != null) { 
			Image image;
			for (int i = 0; i < content.transform.childCount; i++)
			{
				image = content.transform.GetChild(i).GetComponent<Image>();
				if (image) { 
					ImageNavigation.Add(image);
					count = count + 1;
				}
			}
		}
		if (hasPageText) { 
			pageIndexText = transform.Find("Text_Page").GetComponent<Text>();
			pageIndexText.text = 1 + "/" + count;
		}
    }

    private void pageChanged(int index)
    {
        this.index = index;
        SetImageIndexOn(index);

		if (index == 0) {
			SetButtonsStates(false, true);
		} else if (index == count - 1) {
			SetButtonsStates(true, false);
		} else {
			SetButtonsStates(true, true);
		}
		if (hasPageText)
		    pageIndexText.text = index + 1 + "/" + count;
	}

    private IEnumerator InitSelf()
    {
        yield return new WaitForSeconds(0.01f);

        pageView.gameObject.SetActive(true);
        pageView.pageTo(0);
    }

    private void SetImageIndexOn(int index)
    {
        for (int i = 0; i < ImageNavigation.Count; i++)
        {
            ImageNavigation[i].sprite = disableSprite;
        //    ImageNavigation[i].color = disableColor;
        }
        if (ImageNavigation.Count > index)
        {
            ImageNavigation[index].sprite = enableSprite;
      //      ImageNavigation[index].color = enableColor;
        }
    }

    private void SetButtonsStates(bool leftOn, bool rightOn)
    {
        buttons[0].interactable = leftOn;
        //buttons[0].transform.GetChild(0).GetComponent<Button>().interactable = leftOn;
        buttons[1].interactable = rightOn;
        //buttons[1].transform.GetChild(0).GetComponent<Button>().interactable = rightOn;
    }

    public void onClick()
    {
        pageView.pageTo(0);
    }

    private void Destroy()
    {
        pageView.OnPageChanged = null;
    }

    public void NextPage()
    {
        int newIndex = this.index + 1;
        if (newIndex > count - 1) newIndex = count - 1;
        pageChanged(newIndex);
        pageView.PageToAnimation(newIndex, aniDuration);
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_panel_show);
        //CommandChannel.GetInstance().PostCommand(CommonCommandConst.PLAY_SFX, ViewConst.wav_panel_show);
    }

    public void PreviousPage()
    {
        int newIndex = this.index - 1;
        if (newIndex < 0) newIndex = 0;
        pageChanged(newIndex);
        pageView.PageToAnimation(newIndex, aniDuration);
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_panel_show);
        //CommandChannel.GetInstance().PostCommand(CommonCommandConst.PLAY_SFX, ViewConst.wav_panel_show);
    }
}