using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BangpaijingsaijiangliUI : MonoBehaviour {

    public Text text_jinNum;
    public Text text_yinNum;
    public Text text_tieNum;
    public Transform tfGrid;
    public BangpaiItemUI defaultItemScript;
    public FenpeijiangliUI fenpeiJiangliUI;
    public GameObject objJin;
    public GameObject objYin;
    public GameObject objTie;
    public Transform tfYoujiangli;
    public Transform tfFenpeiwan;

    public void Init()
    {
        text_jinNum = transform.Find("youjiangli/Text_jin").GetComponent<Text>();
        text_yinNum = transform.Find("youjiangli/Text_yin").GetComponent<Text>();
        text_tieNum = transform.Find("youjiangli/Text_tie").GetComponent<Text>();
        tfGrid = transform.Find("scrollList/Image/grid");
        defaultItemScript = transform.Find("scrollList/Image/grid/bangpaiItem").gameObject.AddComponent<BangpaiItemUI>();
        defaultItemScript.Init();
        fenpeiJiangliUI = transform.Find("fenpeijiangli").gameObject.AddComponent<FenpeijiangliUI>();
        fenpeiJiangliUI.Init();
        objJin = transform.Find("youjiangli/Image_jin").gameObject;
        objYin = transform.Find("youjiangli/Image_yin").gameObject;
        objTie = transform.Find("youjiangli/Image_tie").gameObject;
        tfYoujiangli = transform.Find("youjiangli");
        tfFenpeiwan = transform.Find("feipeiwan");
    }

}
