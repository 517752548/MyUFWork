using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoleJiaDianItem : MonoBehaviour
{
    public GameUUButton jianBtn;
    public GameUUButton jiaBtn;
    public ProgressBar pg;
    public Text addText;

    public void Init()
    {
        jianBtn = transform.Find("jian").GetComponent<GameUUButton>();
        jiaBtn = transform.Find("jia").GetComponent<GameUUButton>();
        pg = transform.Find("ZZProgress Bar 1").gameObject.AddComponent<ProgressBar>();
        pg.Init
        (
            pg.transform.Find("background").GetComponent<Image>(), 
            pg.transform.Find("background/foreground").GetComponent<Image>(),
            pg.transform.Find("Text").GetComponent<Text>(), 195
        );
        addText = transform.Find("AddText").GetComponent<Text>();

    }

}
