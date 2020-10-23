using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JingJiChangItemUI : MonoBehaviour
{

    public Text paimingText;
    public Image headIcon;
    public Text roleName;
    public Text dengji;
    public Text zhanli;
    public GameUUButton tiaozhanBtn;

    public void Init()
     {
        paimingText=transform.Find("Image (1)/paiming").GetComponent<UnityEngine.UI.Text>();
        headIcon=transform.Find("CommonItemUINoClick80_80/Icon").GetComponent<Image>();
        roleName=transform.Find("mingcheng").GetComponent<UnityEngine.UI.Text>();
        dengji=transform.Find("dengji").GetComponent<UnityEngine.UI.Text>();
        zhanli=transform.Find("zhanli").GetComponent<UnityEngine.UI.Text>();
        tiaozhanBtn = transform.Find("tiaozhan").GetComponent<GameUUButton>();

     }

}
