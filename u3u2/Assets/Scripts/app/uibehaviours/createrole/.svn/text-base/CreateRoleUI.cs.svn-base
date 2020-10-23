using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoleUI : MonoBehaviour
{
    public GameObject xiuzhenBgEffect;
    public GameObject modelcontainer;
    public List<GameObject> bigList;
    public List<GameObject> smallList;
    public List<Image> taiciList;
    public GameUUButton yuyinBtn;
    public PageTurner pageturner;

    public GameUUButton nextBtn;
    public ScrollRect scrollrect;
    public GridLayoutGroup grid;
    public Image scrollimage;

    public void Init()
    {
        xiuzhenBgEffect = transform.Find("xiuzhenBgEffect").gameObject;
        modelcontainer = transform.Find("uicontent/bodycontainer").gameObject;

        bigList = new List<GameObject>();
        bigList.Add(transform.Find("uicontent/jobgridbig/xiake").gameObject);
        bigList.Add(transform.Find("uicontent/jobgridbig/cike").gameObject);
        bigList.Add(transform.Find("uicontent/jobgridbig/shushi").gameObject);
        bigList.Add(transform.Find("uicontent/jobgridbig/xiuzhen").gameObject);
        smallList = new List<GameObject>();
        smallList.Add(transform.Find("uicontent/jobgridsmall/xiake").gameObject);
        smallList.Add(transform.Find("uicontent/jobgridsmall/cike").gameObject);
        smallList.Add(transform.Find("uicontent/jobgridsmall/shushi").gameObject);
        smallList.Add(transform.Find("uicontent/jobgridsmall/xiuzhen").gameObject);
        //jobTab = transform.Find("uicontent/jobgridbig").gameObject.AddComponent<TabButtonGroup>();

        taiciList = new List<Image>();
        
        taiciList.Add(transform.Find("uicontent/taici/xiakenv").gameObject.GetComponent<Image>());
        taiciList.Add(transform.Find("uicontent/taici/xiakenan").gameObject.GetComponent<Image>());
        
        taiciList.Add(transform.Find("uicontent/taici/cikenv").gameObject.GetComponent<Image>());
        taiciList.Add(transform.Find("uicontent/taici/cikenan").gameObject.GetComponent<Image>());
        
        taiciList.Add(transform.Find("uicontent/taici/shushinv").gameObject.GetComponent<Image>());
        taiciList.Add(transform.Find("uicontent/taici/shushinan").gameObject.GetComponent<Image>());
        
        taiciList.Add(transform.Find("uicontent/taici/xiuzhennv").gameObject.GetComponent<Image>());
        taiciList.Add(transform.Find("uicontent/taici/xiuzhennan").gameObject.GetComponent<Image>());

        yuyinBtn = transform.Find("uicontent/next/yuyin/Button").gameObject.GetComponent<GameUUButton>();
        pageturner = transform.Find("uicontent/PageTurner").gameObject.AddComponent<PageTurner>();
        pageturner.Init(pageturner.transform.Find("leftButton/leftButton").GetComponent<GameUUButton>(),
            pageturner.transform.Find("rightButton").GetComponent<GameUUButton>(),null);

        nextBtn = transform.Find("uicontent/next/nextbtn").gameObject.GetComponent<GameUUButton>();
        scrollrect = transform.Find("uicontent/ScrollViewHorizon").gameObject.GetComponent<ScrollRect>();
        grid = transform.Find("uicontent/ScrollViewHorizon/grid").gameObject.GetComponent<GridLayoutGroup>();
        scrollimage = transform.Find("uicontent/ScrollViewHorizon/grid/Image").gameObject.GetComponent<Image>();
    }

}
