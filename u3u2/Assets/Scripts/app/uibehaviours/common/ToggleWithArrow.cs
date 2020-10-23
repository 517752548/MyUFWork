using UnityEngine;
using UnityEngine.UI;

//[System.Serializable]
public enum ToggleWithArrowDirection
{
    Vertical,
    Horizonal
}

public class ToggleWithArrow : MonoBehaviour
{
    public GameUUToggle toggle;
    public Image upArrow;
    public Image downArrow;
    public Image rightArrow;
    public Text btnText;
    //public bool horizon;
    //public bool vertical;
    public ToggleWithArrowDirection direction;
    public bool isArrowChangable = true;

    public void Init(GameUUToggle toggle, Image upArrow, Image downArrow, Image rightArrow, Text btnText, ToggleWithArrowDirection direction, bool isArrowChangable = true)
    {
        this.toggle = toggle;
        this.upArrow = upArrow;
        this.downArrow = downArrow;
        this.rightArrow = rightArrow;
        this.btnText = btnText;

        this.direction = direction;
        this.isArrowChangable = isArrowChangable;

        if (this.direction == ToggleWithArrowDirection.Horizonal)
        {
            if (this.rightArrow != null)
            {
                this.rightArrow.gameObject.SetActive(true);
            }

            if (this.upArrow != null)
            {
                this.upArrow.gameObject.SetActive(false);
            }

            if (this.downArrow != null)
            {
                this.downArrow.gameObject.SetActive(false);
            }
        }
        else if (this.direction == ToggleWithArrowDirection.Vertical)
        {
            if (this.rightArrow != null)
            {
                this.rightArrow.gameObject.SetActive(false);
            }

            if (this.upArrow != null)
            {
                this.upArrow.gameObject.SetActive(true);
            }

            if (this.downArrow != null)
            {
                this.downArrow.gameObject.SetActive(true);
            }
            this.toggleValueChange(this.toggle.isOn);
        }
    }
    
    public void InitListener()
    {
        this.toggle.AddValueChangedCallBack(this.toggleValueChange);
    }

    private void toggleValueChange(bool ison)
    {
        if (isArrowChangable)
        {
            upArrow.gameObject.SetActive(ison);
            downArrow.gameObject.SetActive(!ison);
        }
    }
}
