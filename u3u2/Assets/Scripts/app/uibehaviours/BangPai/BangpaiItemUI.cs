using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BangpaiItemUI : MonoBehaviour 
{
    public Text text_name;
    public Text text_gongxianjifen;
    public Text text_dengji;
    public Text text_zongheshili;
    public Text text_zhiwu;
    public GameUUButton btn_fenpeijiangli;
    public Transform tfJinXiangzi;
    public Transform tfYinXiangzi;
    public Transform tfTieXiangzi;
    
    public void Init()
    {
        text_name = transform.Find("name").GetComponent<Text>();
        text_gongxianjifen = transform.Find("jifen").GetComponent<Text>();
        text_dengji = transform.Find("dengji").GetComponent<Text>();
        text_zongheshili = transform.Find("zongheshili").GetComponent<Text>();
        text_zhiwu = transform.Find("zhiwu").GetComponent<Text>();
        btn_fenpeijiangli = transform.Find("Button0").GetComponent<GameUUButton>();
        tfJinXiangzi = transform.Find("Image_jin");
        tfYinXiangzi = transform.Find("Image_yin");
        tfTieXiangzi = transform.Find("Image_tie");
    }

}
