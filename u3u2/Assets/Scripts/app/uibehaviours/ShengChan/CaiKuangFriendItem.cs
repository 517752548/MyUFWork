using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CaiKuangFriendItem : MonoBehaviour
{
    public Image headIcon;
    public Text nameText;
    public Text levelText;
    public GameUUToggle toggle;

    public void Init()
    {
        headIcon = transform.Find("CommonItemUINoClick82_82/Icon").GetComponent<Image>();
        nameText = transform.Find("name").GetComponent<Text>();
        levelText = transform.Find("level").GetComponent<Text>();
        toggle = gameObject.GetComponent<GameUUToggle>();

    }

}
