
class LayerConfig
{
    public const int Layer_Default = 0;
    public const int Layer_TransparentFX = 1;
    public const int Layer_IgnoreRaycast = 2;

    public const int Layer_Water = 4;
    public const int Layer_UI = 5;

    public const int Layer_Ground = 8;
    public const int Layer_Cover = 9;
    public const int Layer_Zone = 10;
    public const int Layer_ZoneModel = 11;
    public const int Layer_Battle = 12;
    public const int Layer_BattleGround = 13;
    public const int Layer_BattleModel = 14;
    public const int MainUI = 15;
    public const int FirstWnd = 16;
    public const int SecondWnd = 17;
    public const int PopWnd = 18;
    public const int PopTips = 19;
    public const int Bubbles = 20;
    public const int Guide = 21;
    public const int Invisible = 22;
	public const int Layer_StoryModel = 23;

    public static WndType getWndTypeByLayer(int layer)
    {
        WndType wndtype = WndType.MAINUI;
        switch (layer)
        {
            case MainUI:
                wndtype = WndType.MAINUI;
                break;
            case FirstWnd:
                wndtype = WndType.FirstWND;
                break;
            case SecondWnd:
                wndtype = WndType.SecondWND;
                break;
            case PopWnd:
                wndtype = WndType.PopWND;
                break;
            case PopTips:
                wndtype = WndType.POPTIPS;
                break;
            case Bubbles:
                wndtype = WndType.BUBBLES;
                break;
            case Guide:
                wndtype = WndType.GUIDE;
                break;
            case Invisible:
                wndtype = WndType.INVISIBLE;
                break;
        }
        return wndtype;
    }

    public static int getLayerIntByWndType(WndType wndtype)
    {
        return LayerConfig.MainUI + (int)wndtype;
    }
    /// <summary>
    /// 根据层级 获得 canvas下camera的order in layer参数
    /// </summary>
    /// <param name="layer"></param>
    /// <returns></returns>
    public static int getOrderByLayerint(int layer)
    {
        int startOrder = 2;
        int order=startOrder;
        order = startOrder + layer - MainUI;
        return order;
    }
}


