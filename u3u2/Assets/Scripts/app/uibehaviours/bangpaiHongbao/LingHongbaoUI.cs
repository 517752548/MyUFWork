using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LingHongbaoUI : MonoBehaviour {

    public Transform tfMask;
    public Text textNum;
    public Text textDec;
    public Text textZhufu;
    public void Init()
    {
        tfMask = transform.Find("Image_mask");
        textNum = transform.Find("MoneyItem/Text").GetComponent<Text>();
        textDec = transform.Find("Text_lingqu").GetComponent<Text>();
        textZhufu = transform.Find("Text_zhufu").GetComponent<Text>();
    }
}
