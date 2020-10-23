using UnityEngine;
using UnityEngine.UI;


public class CommonItemUINoClick : MonoBehaviour
{
    public Image bg;

    public Image icon;

    public Image biangkuang;

    public Text num;

    public Text Name;
    
    public GameObject glowEffect;
    
    public void Init(Image bg, Image icon, Image biankuang, Text num, Text Name, GameObject glowEffect)
    {
        this.bg = bg;
        this.icon = icon;
        this.biangkuang = biankuang;
        this.num = num;
        this.Name = Name;
        this.glowEffect = glowEffect;
        if (this.biangkuang != null)
        {
            this.biangkuang.gameObject.SetActive(false);
        }
        if (this.icon != null)
        {
            this.icon.gameObject.SetActive(false);
        }
    }
    
    public void Init()
    {
        Transform bg = transform.Find("Image");
        if (bg != null)
        {
            this.bg = bg.GetComponent<Image>();
        }
        Transform icon = transform.Find("Icon");
        if (icon != null)
        {
            this.icon = icon.GetComponent<Image>();
        }
        Transform biankuang = transform.Find("BianKuang");
        if (biankuang != null)
        {
            this.biangkuang = biankuang.GetComponent<Image>();
        }
        Transform num = transform.Find("Num");
        if (num != null)
        {
            this.num = num.GetComponent<Text>();
        }
        Transform Name = transform.Find("Name");
        if (Name != null)
        {
            this.Name = Name.GetComponent<Text>();
        }
        Transform glowEffect = transform.Find("glowEffect");
        if (glowEffect != null)
        {
            this.glowEffect = glowEffect.gameObject;
        }
        if (biangkuang != null)
        {
            biangkuang.gameObject.SetActive(false);
        }
        if (this.icon != null)
        {
            this.icon.gameObject.SetActive(false);
        }
    }
}
