using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using EventUtil;

public class HomeRoot : BaseRoot
{
    [SerializeField] private GraphicRaycaster _HomeGraphicRaycaster;
    [SerializeField] private List<BaseHomeUI> _baseHomeUis;
    private Transform headUI;
    private PageView centerPageView;
    private Transform bottomUI;
    private Transform bottomSlideUI;
    private Transform bottomHome;//为了匹配slide宽度
    private const float scrollAniPerPage = 0.5f;
    private List<Toggle> toggles;
    private HomeRootFsmManager rootFsmManager;
    private bool ani;//切换tab是否使用animation, 提供控制动画的机会
    private Animator bottomAni;
    private const string shop = "shop";
    private const string decoration = "decoration";
    private const string home = "home";
    private const string activity = "activity";
    private const string rank = "rank";
    public HomeRootTab currentTab { get; private set; }
    private bool stopMove = true;
    public float smooting = 0.8f;      //滑动速度
    private float startTime;
    void Awake()
    {
        _HomeGraphicRaycaster = GetComponent<GraphicRaycaster>();
        headUI = transform.Find("Theme_HeadUI");
        centerPageView = transform.Find("Theme/Scroll View").GetComponent<PageView>();
        centerPageView.GetComponent<ScrollRect>().onValueChanged.AddListener(ListenerMethod);
        bottomUI = transform.Find("Theme_BottomUI");
        bottomSlideUI = bottomUI.Find("Slide");
        bottomHome = bottomUI.Find("Home");
        bottomAni = bottomUI.GetComponent<Animator>();
        toggles = new List<Toggle>();
        toggles.Add(bottomUI.transform.Find("Shop").GetComponentInChildren<Toggle>());
        toggles.Add(bottomUI.transform.Find("Decoration").GetComponentInChildren<Toggle>());
        toggles.Add(bottomUI.transform.Find("Home").GetComponentInChildren<Toggle>());
        toggles.Add(bottomUI.transform.Find("Activity").GetComponentInChildren<Toggle>());
        toggles.Add(bottomUI.transform.Find("Rank").GetComponentInChildren<Toggle>());

        toggles[0].onValueChanged.AddListener(ClickShop);
        toggles[1].onValueChanged.AddListener(ClickDecoration);
        toggles[2].onValueChanged.AddListener(ClickHome);
        toggles[3].onValueChanged.AddListener(ClickActivities);
        toggles[4].onValueChanged.AddListener(ClickRank);

        if (GetComponent<HomeRootFsmManager>() == null)
        {
            rootFsmManager = gameObject.AddComponent<HomeRootFsmManager>();
            rootFsmManager.Init(this);
        }
    }

    public void ListenerMethod(Vector2 value)
    {
        // //Debug.LogError("ListenerMethod: " + value);
    }

    void Start()
    {
        //匹配slide宽度
        DOTween.Sequence().InsertCallback(0.05f, () =>
        {
            (bottomSlideUI as RectTransform).sizeDelta = new Vector2((bottomHome as RectTransform).sizeDelta.x, (bottomSlideUI as RectTransform).sizeDelta.y);
        });

        ani = false;//第一次不要动画
        centerPageView.OnPageChanged = (index) =>
        {
            toggles[index].isOn = true;
        };
        toggles[(int)HomeRootTab.home].isOn = false;//确保可以进入home
        rootFsmManager.Enter();
    }

    public BaseThemeRoot GetCurrentShowRoot()
    {
        switch (currentTab)
        {
            case HomeRootTab.shop:
                return GetHomeUi<ShopThemeRoot>();
            case HomeRootTab.decoration:
                return GetHomeUi<DecorationThemeRoot>();
            case HomeRootTab.home:
                return GetHomeUi<HomeThemeRoot>();
            case HomeRootTab.activity:
                return GetHomeUi<ActivityThemeRoot>();
            case HomeRootTab.rank:
                return GetHomeUi<RankThemeRoot>();
        }
        return null;
    }

    private void SetBottomTrigger(string trigger)
    {
        bottomAni.ResetTrigger(trigger);
        bottomAni.SetTrigger(trigger);
    }
    private void ResetSlideAni()
    {
        stopMove = false;
        startTime = 0;
    }

    private void ClickRank(bool arg0)
    {
        if (arg0)
        {
            centerPageView.PageToAnimation(4, ani ? scrollAniPerPage : 0);
            GetHomeUi<RankThemeRoot>().OnEnter();
            ani = true;
            currentTab = HomeRootTab.rank;
            SetBottomTrigger(rank);
            rootFsmManager.TriggerEvent(HomeRootFsmManager.HRFSMtoRank);
            ResetSlideAni();
            //bottomSlideUI.DOMove(toggles[(int)HomeRootTab.rank].transform.parent.position, ani ? scrollAniPerPage : 0);
        }
        else
        {
            GetHomeUi<RankThemeRoot>().OnLeave();
        }
    }

    private void ClickActivities(bool arg0)
    {
        if (arg0)
        {
            centerPageView.PageToAnimation(3, ani ? scrollAniPerPage : 0);
            GetHomeUi<ActivityThemeRoot>().OnEnter();
            ani = true;
            currentTab = HomeRootTab.activity;
            SetBottomTrigger(activity);
            rootFsmManager.TriggerEvent(HomeRootFsmManager.HRFSMtoActivity);
            ResetSlideAni();
            //bottomSlideUI.DOMove(toggles[(int)HomeRootTab.activity].transform.parent.position, ani ? scrollAniPerPage : 0);
        }
        else
        {
            GetHomeUi<ActivityThemeRoot>().OnLeave();
        }
    }

    private void ClickHome(bool arg0)
    {
        //Debug.LogError($"click home {arg0}");
        if (arg0)
        {
            centerPageView.PageToAnimation(2, ani ? scrollAniPerPage : 0);
            GetHomeUi<HomeThemeRoot>().OnEnter();
            ani = true;
            currentTab = HomeRootTab.home;
            SetBottomTrigger(home);
            rootFsmManager.TriggerEvent(HomeRootFsmManager.HRFSMtoHome);
            ResetSlideAni();
            //bottomSlideUI.DOMove(toggles[(int)HomeRootTab.home].transform.parent.position, ani ? scrollAniPerPage : 0);
        }
        else
        {
            GetHomeUi<HomeThemeRoot>().OnLeave();
        }
    }

    private void ClickDecoration(bool arg0)
    {
        //Debug.LogError($"decoration {arg0}");
        if (arg0)
        {
            centerPageView.PageToAnimation(1, ani ? scrollAniPerPage : 0);
            GetHomeUi<DecorationThemeRoot>().OnEnter();
            ani = true;
            currentTab = HomeRootTab.decoration;
            SetBottomTrigger(decoration);
            rootFsmManager.TriggerEvent(HomeRootFsmManager.HRFSMtoDecoration);
            ResetSlideAni();
            //bottomSlideUI.DOMove(toggles[(int)HomeRootTab.decoration].transform.parent.position, ani ? scrollAniPerPage : 0);
        }
        else
        {
            GetHomeUi<DecorationThemeRoot>().OnLeave();
        }
    }

    private void ClickShop(bool arg0)
    {
        if (arg0)
        {
            centerPageView.PageToAnimation(0, ani ? scrollAniPerPage : 0);
            GetHomeUi<ShopThemeRoot>().OnEnter();
            ani = true;
            currentTab = HomeRootTab.shop;
            SetBottomTrigger(shop);
            rootFsmManager.TriggerEvent(HomeRootFsmManager.HRFSMtoShop);
            ResetSlideAni();
            //bottomSlideUI.DOMove(toggles[(int)HomeRootTab.shop].transform.parent.position, ani ? scrollAniPerPage : 0);
        }
        else
        {
            GetHomeUi<ShopThemeRoot>().OnLeave();
        }
    }

    public override void Show(Action<bool> callback)
    {
        base.Show(callback);
        // _home.SetActive(true);
        rootFsmManager.Enter();
        GetComponent<Canvas>().enabled = true;
        GetComponentInChildren<Camera>().enabled = true;
        _baseHomeUis.ForEach(ui => ui.OnShow());
        PlayBackgroundMusic();
        EventDispatcher.AddEventListener<BanRegion, bool>(GlobalEvents.HomeRootBanClick, BanClk);
    }

    private void BanClk(BanRegion regon, bool flag)
    {
        _HomeGraphicRaycaster.enabled = flag;
    }
    /// <summary>
    /// 屏蔽点击
    /// </summary>
    /// <param name="regon">区域</param>
    /// <param name="flag">true 可以点击，false不可点击</param>
    public static void BanClick(BanRegion regon, bool flag)
    {
        EventDispatcher.TriggerEvent(GlobalEvents.HomeRootBanClick, regon, flag);
    }

    public override void Hidden()
    {
        base.Hidden();
        //先这样隐藏
        GetComponent<Canvas>().enabled = false;
        GetComponentInChildren<Camera>().enabled = false;
        _baseHomeUis.ForEach(ui => ui.OnHidden());
        rootFsmManager.Leave();
        // _home.SetActive(false);
        EventDispatcher.RemoveEventListener<BanRegion, bool>(GlobalEvents.HomeRootBanClick, BanClk);
    }

    public override bool IsVisible()
    {
        return GetComponent<Canvas>().enabled;
    }

    private void PlayBackgroundMusic()
    {
        // if (CurrentWorld != null)
        // {
        // }
        //     AppEngine.SSoundManager.PlayBGM(CurrentWorld.HomeMusic);
    }

    public void MoveTo(HomeRootTab index, bool ani = true)
    {
        this.ani = ani;
        toggles[(int)index].isOn = true;
    }

    public T GetHomeUi<T>() where T : BaseHomeUI
    {
        for (int i = 0; i < _baseHomeUis.Count; i++)
        {
            if (_baseHomeUis[i] is T)
            {
                return _baseHomeUis[i] as T;
            }
            else
            {
                var ui = _baseHomeUis[i].GetHomeUi<T>();
                if (ui != null)
                    return ui;
            }
        }
        return null;
    }

    void Update()
    {
        if (!stopMove)
        {
            startTime += Time.deltaTime;
            float t = startTime * smooting;
            if (bottomSlideUI)
            {
                float x = Mathf.Lerp(bottomSlideUI.transform.position.x, toggles[(int)currentTab].transform.parent.position.x, t);
                bottomSlideUI.position = new Vector3(x, bottomSlideUI.position.y, bottomSlideUI.position.z);
            }
            if (t >= 1)
            {
                startTime = 0;
                stopMove = true;
            }
        }
    }
}

public enum HomeRootTab
{
    shop = 0,
    decoration = 1,
    home = 2,
    activity = 3,
    rank = 4,
    root = 1000//homeroot
}

public enum BanRegion
{
    all,//禁用整个区域 顶、中间、底
    part//禁用中间部分
}