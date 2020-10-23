using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyItemUI : MonoBehaviour
{
    public Image moneyIcon;
    public Text moneyText;
    public Image inputBg;

    public void Init(Image moneyIcon, Text moneyText, Image inputBg)
    {
        this.moneyIcon = moneyIcon;
        this.moneyText = moneyText;
        this.inputBg = inputBg;
        if (this.moneyIcon!=null)
        {
            this.moneyIcon.gameObject.SetActive(false);
        }
    }

    public void Init()
    {
        if (transform.Find("Image") != null)
        {
            this.moneyIcon = transform.Find("Image").GetComponent<Image>();
        }
        if (transform.Find("Text") != null)
        {
            this.moneyText = transform.Find("Text").GetComponent<Text>();
        }
        if (transform.Find("bg/Text") != null)
        {
            this.moneyText = transform.Find("bg/Text").GetComponent<Text>();
        }
        if (transform.Find("bg") != null)
        {
            this.inputBg = transform.Find("bg").GetComponent<Image>();
        }
        if (this.moneyIcon != null)
        {
            this.moneyIcon.gameObject.SetActive(false);
        }
    }

}
