using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FahongbaoUI : MonoBehaviour {

    public GameUUButton btn_close;
    public Transform tfMask;
    public Image image_bg_num;
    public Image image_bg_zhufu;
    public GameUUButton btn_fafang;
    public Text textNum;
    public Text textZhufu;
    public void Init()
    {
        btn_close = transform.Find("btn_close").GetComponent<GameUUButton>();
        tfMask = transform.Find("Image_mask");
        image_bg_num = transform.Find("MoneyItem/bg").GetComponent<Image>();
        image_bg_zhufu = transform.Find("zhufuBg").GetComponent<Image>();
        btn_fafang = transform.Find("btn_fafang").GetComponent<GameUUButton>();
        textNum = transform.Find("MoneyItem/Text").GetComponent<Text>();
        textZhufu = transform.Find("Text_liuyan").GetComponent<Text>();
    }
}
