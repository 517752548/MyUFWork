using UnityEngine;
using UnityEngine.UI;

    public class VipUI:MonoBehaviour
    {

        public GameUUButton closeBtn;
        public GameUUButton chongzhiBtn;
        public Text curVipLevel;
        public Text zaichongLabel;
        public Text zaichongMoney;
        public Text nextVipLevel;
        public ProgressBar pgbar;
        public Text tequanTitle;
        public Text tequanDesc;
        public GameUUButton leftBtn;
        public GameUUButton rightBtn;
        public Image bgimage;
        public GameObject libaoBtn;

        public void init()
        {
            closeBtn = transform.Find("BigPopWndWIthSideTab/closeBtn").gameObject.GetComponent<GameUUButton>();
            chongzhiBtn = transform.Find("vipui/chongzhibtn").gameObject.GetComponent<GameUUButton>();
            pgbar = transform.Find("vipui/pgbar").gameObject.AddComponent<ProgressBar>();
            pgbar.Init(
                pgbar.transform.Find("background").GetComponent<Image>(),
                pgbar.transform.Find("foreground").GetComponent<Image>(),
                pgbar.transform.Find("Text").GetComponent<Text>(),260);
            bgimage = transform.Find("vipui/leftbg").GetComponent<Image>();
            libaoBtn = transform.Find("vipui/getLibaobtn").gameObject;

            curVipLevel = transform.Find("vipui/curVipText").GetComponent<Text>();
            zaichongMoney = transform.Find("vipui/zaichongText").GetComponent<Text>();
            zaichongLabel = transform.Find("vipui/zaichongLabel").GetComponent<Text>();
            nextVipLevel = transform.Find("vipui/nextVipText").GetComponent<Text>();
            tequanTitle = transform.Find("vipui/curVip").GetComponent<Text>();
            tequanDesc = transform.Find("vipui/ScrollViewVertical/tequanText").GetComponent<Text>();
            leftBtn = transform.Find("vipui/leftBtn").gameObject.GetComponent<GameUUButton>();
            rightBtn = transform.Find("vipui/rightBtn").gameObject.GetComponent<GameUUButton>();
        }
    }
