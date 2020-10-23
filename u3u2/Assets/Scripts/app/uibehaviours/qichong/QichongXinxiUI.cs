using UnityEngine;
using System.Collections;

public class QichongXinxiUI : MonoBehaviour {

   // public QichongShuxingUI shuxingUI;
   // public QichongzizhiUI zizhiUI;
   // public QichongchengzhangUI chengzhangUI;
  //  public QichongwuxingUI wuxingUI;

    public GameObject objQiChongXinxi_chengzhang;
    public GameObject objQiChongXinxi_shuxing;
    public GameObject objQiChongXinxi_zizhi;
    public GameObject objQiChongXinxi_wuxing;
    public TabButtonGroup tabs;
    public void Init()
    {
      //  shuxingUI = transform.Find("qichongshuxing").gameObject.AddComponent<QichongShuxingUI>();
     //   shuxingUI.Init();
     //   zizhiUI = transform.Find("qichongzizhi").gameObject.AddComponent<QichongzizhiUI>();
     //   zizhiUI.Init();
     //   chengzhangUI = transform.Find("qichongchengzhang").gameObject.AddComponent<QichongchengzhangUI>();
     //   chengzhangUI.Init();
     //   wuxingUI = transform.Find("qichongWuxing").gameObject.AddComponent<QichongwuxingUI>();
      //  wuxingUI.Init();
        tabs = transform.Find("InfoTab/xichongTabGroup").gameObject.AddComponent<TabButtonGroup>();
        tabs.Init();
        tabs.AddToggle(tabs.transform.Find("shuxing").GetComponent<GameUUToggle>());
        tabs.AddToggle(tabs.transform.Find("zizhi").GetComponent<GameUUToggle>());
        tabs.AddToggle(tabs.transform.Find("chengzhang").GetComponent<GameUUToggle>());
        tabs.AddToggle(tabs.transform.Find("wuxing").GetComponent<GameUUToggle>());
    }

}
