using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PetLeftViwerUI : MonoBehaviour {

    public GameObject bianyi;
    public GameObject pettype1_xiyou;
    public GameObject pettype1_shenshou;
    public GameObject pettype2;
    public GameObject pettype3;
    public GameObject pettype4;

    public GameObject putong;
    public GameObject youxiu;
    public GameObject jiechu;
    public GameObject zhuoyue;
    public GameObject chaofan;
    public GameObject wanmei;

    public Text levelText;

    public ProgressBar expProgress;

    public GridLayoutGroup petListGrid;

    public Text scoreText;


    public GameObject modelContainer;


    public void Init()
    {
        bianyi = transform.Find("bianyi").gameObject;
        pettype1_xiyou = transform.Find("pettype/pettype1_xiyou").gameObject;
        pettype1_shenshou = transform.Find("pettype/pettype1_shenshou").gameObject;
        pettype2 = transform.Find("pettype/pettype2").gameObject;
        pettype3 = transform.Find("pettype/pettype3").gameObject;
        pettype4 = transform.Find("pettype/pettype4").gameObject;
        putong = transform.Find("putong").gameObject;
        youxiu = transform.Find("youxiu").gameObject;
        jiechu = transform.Find("jiechu").gameObject;
        zhuoyue = transform.Find("zhuoyue").gameObject;
        chaofan = transform.Find("chaofan").gameObject;
        wanmei = transform.Find("wanmei").gameObject;
        levelText = transform.Find("level").GetComponent<UnityEngine.UI.Text>();
        petListGrid = transform.Find("petList 1/Image/scrollRect/grid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        modelContainer = transform.Find("modelContainer").gameObject;
        scoreText = transform.Find("pingfen/Text 1").GetComponent<Text>();
        pettype2.SetActive(false);
        pettype3.SetActive(false);
        pettype4.SetActive(false);
    }
}
