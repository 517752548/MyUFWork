using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HuoDongListItem : MonoBehaviour
{
    public GameUUButton listbtn;
    /// <summary>
    /// 节日tag。
    /// </summary>
    //public GameObject huodongTag_jieri;
    /// <summary>
    /// 推荐tag。
    /// </summary>
    //public GameObject huodongTag_tuijian;
    public Image huodongTag;
    public Text huodongName;
    public Image icon;
    public Text textTitle1;
    public Text textContent1;
    public Text textTitle2;
    public Text textContent2;
    public GameUUButton canjia;
    public Text m_canjia_name;
    public Text wanchengText;

    public Transform tfContent2;
    public Transform tfDaojishi;
    public Text textRemianTime;

    public void Init()
    {
        //huodongTag_jieri=transform.Find("jieri").gameObject;
        //huodongTag_tuijian=transform.Find("tuijian").gameObject;
        huodongTag = transform.Find("Tag").GetComponent<Image>();
        huodongName=transform.Find("Text").GetComponent<UnityEngine.UI.Text>();
        icon=transform.Find("Icon").GetComponent<Image>();
        textTitle1 = transform.Find("cishu/Text").GetComponent<Text>();
        textContent1=transform.Find("cishu/Text 1").GetComponent<UnityEngine.UI.Text>();
        textTitle2 = transform.Find("huoyue/Text").GetComponent<Text>();
        textContent2=transform.Find("huoyue/Text 1").GetComponent<UnityEngine.UI.Text>();
        wanchengText=transform.Find("wanchengText").GetComponent<UnityEngine.UI.Text>();
        canjia = transform.Find("canjia").GetComponent<GameUUButton>();
        m_canjia_name = transform.Find("canjia/name").GetComponent<Text>();
        listbtn = GetComponent<GameUUButton>();
        tfDaojishi = transform.Find("Image_daojishi");
        tfContent2 = transform.Find("huoyue");
        textRemianTime = transform.Find("Image_daojishi/Text_time").GetComponent<Text>();



    }

}
