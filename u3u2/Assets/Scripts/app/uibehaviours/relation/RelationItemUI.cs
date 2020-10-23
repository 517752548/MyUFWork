using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RelationItemUI : MonoBehaviour
{
    public Image icon;
    public GameUUToggle toggel;
    public Text nameText;
    public Text levelText;
    public Text riqiText;
    public GameUUButton zhankaiBtn;
    public GameUUButton shanchuBtn;
    public GameObject yiduSign;
    public void Init()
    {
        Transform tfIcon = transform.Find("Icon");
        if (tfIcon)
        {
             icon = tfIcon.GetComponent<UnityEngine.UI.Image>();
        }
       
        toggel = GetComponent<GameUUToggle>();
        nameText = transform.Find("equipName").GetComponent<UnityEngine.UI.Text>();
        levelText = transform.Find("mailTime").GetComponent<UnityEngine.UI.Text>();
        riqiText = transform.Find("mailTime").GetComponent<UnityEngine.UI.Text>();

        Transform tfZhankai = transform.Find("zhankaiBtn");
        if (tfZhankai)
        {
            zhankaiBtn = tfZhankai.GetComponent<GameUUButton>();

        }
        Transform tfShanchu = transform.Find("deleteBtn");
        if (tfShanchu)
        {
            shanchuBtn = tfShanchu.GetComponent<GameUUButton>();
        }
        if (transform.Find("selectedRead") != null)
        {
            yiduSign = transform.Find("selectedRead").gameObject;
        }
        if (icon)
        {
            icon.gameObject.SetActive(false);
        }

        
    }
}
