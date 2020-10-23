using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QichongzizhiUI : UIMonoBehaviour {

    public ProgressBar qiangzhuangBar;
    public ProgressBar minjieBar;
    public ProgressBar zhiliBar;
    public ProgressBar xinyangBar;
    public ProgressBar nailiBar;
    public CommonItemUINoClick xiaohaoItem;
    public GameUUButton huantongBtn;


    public override void Init()
    {
        base.Init();
        qiangzhuangBar = transform.Find("progressBars/qiangzhuang/expBar").gameObject.AddComponent<ProgressBar>();
        qiangzhuangBar.Init
        (
            qiangzhuangBar.transform.Find("background").GetComponent<Image>(),
            qiangzhuangBar.transform.Find("background/foreground").GetComponent<Image>(),
            qiangzhuangBar.transform.Find("Text").GetComponent<Text>(),
            324
        );
        minjieBar = transform.Find("progressBars/minjie/expBar").gameObject.AddComponent<ProgressBar>();
        minjieBar.Init
        (
            minjieBar.transform.Find("background").GetComponent<Image>(),
               minjieBar.transform.Find("background/foreground").GetComponent<Image>(),
               minjieBar.transform.Find("Text").GetComponent<Text>(),
              324
        );
        zhiliBar = transform.Find("progressBars/zhili/expBar").gameObject.AddComponent<ProgressBar>();
        zhiliBar.Init
        (
            zhiliBar.transform.Find("background").GetComponent<Image>(),
               zhiliBar.transform.Find("background/foreground").GetComponent<Image>(),
               zhiliBar.transform.Find("Text").GetComponent<Text>(),
              324
        );
        xinyangBar = transform.Find("progressBars/xinyang/expBar").gameObject.AddComponent<ProgressBar>();
        xinyangBar.Init
        (
            xinyangBar.transform.Find("background").GetComponent<Image>(),
               xinyangBar.transform.Find("background/foreground").GetComponent<Image>(),
               xinyangBar.transform.Find("Text").GetComponent<Text>(),
             324
        );
        nailiBar = transform.Find("progressBars/naili/expBar").gameObject.AddComponent<ProgressBar>();
        nailiBar.Init
        (
            nailiBar.transform.Find("background").GetComponent<Image>(),
               nailiBar.transform.Find("background/foreground").GetComponent<Image>(),
               nailiBar.transform.Find("Text").GetComponent<Text>(),
              324
        );
        xiaohaoItem = transform.Find("ZZCommonItemUINoClick").gameObject.AddComponent<CommonItemUINoClick>();
        xiaohaoItem.Init
        (
            xiaohaoItem.transform.Find("Image").GetComponent<Image>(),
            xiaohaoItem.transform.Find("Icon").GetComponent<Image>(),
            xiaohaoItem.transform.Find("BianKuang").GetComponent<Image>(),
            xiaohaoItem.transform.Find("Num").GetComponent<Text>(),
            //xiaohaoItem.transform.Find("Name").GetComponent<Text>(),
            null,
            null
        );

        huantongBtn = transform.Find("ResetBtn").GetComponent<GameUUButton>();
    }
}
