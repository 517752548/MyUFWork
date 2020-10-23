using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QichongchengzhangUI : UIMonoBehaviour
{

    public Text chengzhanglv;


    public GameObject putong;

    public CommonItemUINoClick putongXiaohao;
    public GameUUButton lianhuaBtn;


    public GameObject wanmei;

    public Text wuxinglv;

    public CommonItemUINoClick wanmeiXiaohao;

    public GameUUButton tishengBtn;


    public GameObject chaofan;

    public override void Init()
    {
        base.Init();
        chengzhanglv = transform.Find("chengzhanglvInfo/chengzhanglv").GetComponent<UnityEngine.UI.Text>();
        putong = transform.Find("putong").gameObject;
        putongXiaohao = transform.Find("putong/xiaohao").gameObject.AddComponent<CommonItemUINoClick>();
        putongXiaohao.Init(
            putongXiaohao.transform.Find("Image").GetComponent<Image>(),
            putongXiaohao.transform.Find("Icon").GetComponent<Image>(),
            putongXiaohao.transform.Find("BianKuang").GetComponent<Image>(),
            putongXiaohao.transform.Find("Num").GetComponent<Text>(),
            //putongXiaohao.transform.Find("Name").GetComponent<Text>(),
            null,
            null
     );
        lianhuaBtn = transform.Find("putong/lianhuaBtn").GetComponent<GameUUButton>();
        wanmei = transform.Find("wanmei").gameObject;

        wanmeiXiaohao = transform.Find("wanmei/xiaohao 1").gameObject.AddComponent<CommonItemUINoClick>();
        wanmeiXiaohao.Init(
          wanmeiXiaohao.transform.Find("Image").GetComponent<Image>(),
          wanmeiXiaohao.transform.Find("Icon").GetComponent<Image>(),
          wanmeiXiaohao.transform.Find("BianKuang").GetComponent<Image>(),
          wanmeiXiaohao.transform.Find("Num").GetComponent<Text>(),
          //wanmeiXiaohao.transform.Find("Name").GetComponent<Text>(),
          null,
          null
     );
        tishengBtn = transform.Find("wanmei/tishengBtn").GetComponent<GameUUButton>();
        chaofan = transform.Find("chaofan").gameObject;
        chaofan.gameObject.SetActive(false);
        wanmei.gameObject.SetActive(false);

    }

}
