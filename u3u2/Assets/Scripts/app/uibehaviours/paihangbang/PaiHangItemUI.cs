using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PaiHangItemUI : MonoBehaviour//, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public GameUUToggle toggle;
    public Image danshuBG;
    public Image shuangshuBG;

    public Text paiming;
    public Text jueseming;
    public Text zhiye;
    public Text dengji;
    public Text zhanli;
    public Text bangpai;
    public Text chongwuming;
    public Text yongyouzhe;
    public Text pingfen;
    public Text liansheng;
    public Text jifen;
    public Text xianhu;

    //帮派进度
    public Text suoshubangpai_jindu;
    public GameUUButton zhanbaoluxiang;
    public Text zuigaojilu;
    public Text zhandouhuiheshu;

    //帮派次数
    public Text youxiaocishu;
    public Text suoshubangpai_cishu;
    public Text bangzhu;
    public Text bangpaichengyuan;
    

    public Image qiansan;
    public GameUUButton showinfoBtn;

    public ScrollRect scrollRect;

    public void SetIndex(int i)
    {
        if (danshuBG != null && shuangshuBG != null)
        {
            if (i % 2 == 0)
            {
                danshuBG.gameObject.SetActive(false);
                shuangshuBG.gameObject.SetActive(true);
                toggle.targetGraphic = shuangshuBG;
            }
            else
            {
                danshuBG.gameObject.SetActive(true);
                shuangshuBG.gameObject.SetActive(false);
                toggle.targetGraphic = danshuBG;
            }
        }
    }
    public void Init()
    {
        toggle = GetComponent<GameUUToggle>();  //TODO this
        danshuBG = transform.Find("danshuBg").GetComponent<UnityEngine.UI.Image>();
        shuangshuBG = transform.Find("shuangshuBg").GetComponent<UnityEngine.UI.Image>();

        Transform tfPaiming = transform.Find("paiming");
        if (tfPaiming)
        {
            paiming = transform.Find("paiming").GetComponent<UnityEngine.UI.Text>();
            paiming.text = "";
        }

        Transform tfjueseming = transform.Find("jueseming");
        if (tfjueseming)
        {
            jueseming = transform.Find("jueseming").GetComponent<UnityEngine.UI.Text>();
            jueseming.text = "";
        }
        Transform tfzhiye = transform.Find("zhiye");
        if (tfzhiye)
        {
            zhiye = transform.Find("zhiye").GetComponent<UnityEngine.UI.Text>();
            zhiye.text = "";
        }


        Transform tfdengji = transform.Find("dengji");
        if (tfdengji)
        {
            dengji = transform.Find("dengji").GetComponent<UnityEngine.UI.Text>();
            dengji.text = "";
        }
        Transform tfzhanli = transform.Find("zhanli");
        if (tfzhanli)
        {
            zhanli = transform.Find("zhanli").GetComponent<UnityEngine.UI.Text>();
            zhanli.text = "";
        }
        Transform tfbangpai = transform.Find("bangpai");
        if (tfbangpai)
        {
            bangpai = transform.Find("bangpai").GetComponent<UnityEngine.UI.Text>();
            bangpai.text = "";
        }
        Transform tfchongwuming = transform.Find("chongwuming");
        if (tfchongwuming)
        {
            chongwuming = transform.Find("chongwuming").GetComponent<UnityEngine.UI.Text>();
            chongwuming.text = "";
        }


        Transform tfyongyouzhe = transform.Find("yongyouzhe");
        if (tfyongyouzhe)
        {
            yongyouzhe = transform.Find("yongyouzhe").GetComponent<UnityEngine.UI.Text>();
            yongyouzhe.text = "";
        }
        Transform tfpingfen = transform.Find("pingfen");
        if (tfpingfen)
        {
            pingfen = transform.Find("pingfen").GetComponent<UnityEngine.UI.Text>();
            pingfen.text = "";
        }
        Transform tfliansheng = transform.Find("liansheng");
        if (tfliansheng)
        {
            liansheng = transform.Find("liansheng").GetComponent<UnityEngine.UI.Text>();
            liansheng.text = "";
        }
        Transform tfjifen = transform.Find("jifen");
        if (tfjifen)
        {
            jifen = transform.Find("jifen").GetComponent<UnityEngine.UI.Text>();
            jifen.text = "";
        }
        Transform tfqiansan = transform.Find("qiansan");
        if (tfqiansan)
        {
            qiansan = transform.Find("qiansan").GetComponent<Image>();
            qiansan.enabled = false;
        }
        Transform tfshowinfoBtn = transform.Find("showinfoBtn");
        if (tfshowinfoBtn)
        {
            showinfoBtn = transform.Find("showinfoBtn").GetComponent<GameUUButton>();
        }

        //Transform tfSuoshubangpai = transform.Find("suoshubangpai");
        //if (tfshowinfoBtn)
        //{
        //    suoshubangpai_jindu = tfshowinfoBtn.GetComponent<Text>();
        //}

        Transform tfZhandouluxiang = transform.Find("zhanbaoluxiang");
        if (tfZhandouluxiang)
        {
            zhanbaoluxiang = tfZhandouluxiang.GetComponent<GameUUButton>();
        }

        Transform tfZuigaojilu = transform.Find("zuigaojilu");
        if (tfZuigaojilu)
        {
            zuigaojilu = tfZuigaojilu.GetComponent<Text>();
        }

        Transform tfZhandouhuiheshu = transform.Find("zhandouhuiheshu");
        if (tfZhandouhuiheshu)
        {
            zhandouhuiheshu = tfZhandouhuiheshu.GetComponent<Text>();
        }

        Transform tfyouxiaocishu = transform.Find("youxiaocishu");
        if (tfyouxiaocishu)
        {
            youxiaocishu = tfyouxiaocishu.GetComponent<Text>();
        }

        Transform tfSuozaibangpai_jindu = transform.Find("suoshubangpai_jindu");
        if (tfSuozaibangpai_jindu)
        {
            suoshubangpai_jindu = tfSuozaibangpai_jindu.GetComponent<Text>();
        }

        Transform tfSuoshubangpai_cishu = transform.Find("suoshubangpai_cishu");
        if (tfSuoshubangpai_cishu)
        {
            suoshubangpai_cishu = tfSuoshubangpai_cishu.GetComponent<Text>();
        }

        Transform tfbangzhu = transform.Find("bangzhu");
        if(tfbangzhu)
        {
            bangzhu = tfbangzhu.GetComponent<Text>();
        }

        Transform tfbangpaichengyuan = transform.Find("bangpaichengyuan");
        if (tfbangpaichengyuan)
        {
            bangpaichengyuan = tfbangpaichengyuan.GetComponent<Text>();
        }

        Transform tfxianhu = transform.Find("xianhu");
        if (tfxianhu)
        {
            xianhu = tfxianhu.GetComponent<Text>();
        }
    }

    public void Init(Text paiming, Text jueseming, Text zhiye,
 Text dengji, Text zhanli, Text bangpai, Text chongwuming, Text yongyouzhe, Text pingfen, Text liansheng, Text jifen)
    {
        toggle = GetComponent<GameUUToggle>();
        danshuBG = transform.Find("danshuBg").GetComponent<UnityEngine.UI.Image>();
        shuangshuBG = transform.Find("shuangshuBg").GetComponent<UnityEngine.UI.Image>();
        this.paiming = paiming;
        this.jueseming = jueseming;
        this.zhiye = zhiye;
        this.dengji = dengji;
        this.zhanli = zhanli;
        this.bangpai = bangpai;
        this.chongwuming = chongwuming;
        this.yongyouzhe = yongyouzhe;
        this.pingfen = pingfen;
        this.liansheng = liansheng;
        this.jifen = jifen;

    }

    //public void OnDrag(PointerEventData eventData)
    //{
    //    if (scrollRect != null)
    //    {
    //        scrollRect.OnDrag(eventData);
    //    }
    //}

    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    if (scrollRect != null)
    //    {
    //        scrollRect.OnBeginDrag(eventData);
    //    }
    //}

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    if (scrollRect != null)
    //    {
    //        scrollRect.OnEndDrag(eventData);
    //    }
    //}
}







