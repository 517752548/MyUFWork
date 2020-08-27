using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class ToastWindow : UIWindowBase
{

    public static bool isMessageShowing = false;
    private float[] toastPositionsY;
    public RectTransform backgroundTransform;
    /// <summary>
    /// 这个是静态的text 只是用来获取大小用的，不设置active为false 
    /// </summary>
    [SerializeField]
    private Text consText;
    public Text messageText;

    private ToastInfo toastInfo;
    //UI的初始化请放在这里
    public override void OnOpen()
    {
        InitToastPositions();
        toastInfo = (ToastInfo) objs[0];
        messageText.text = toastInfo.message;
        AmendTransform(toastInfo);
    }
    
    void InitToastPositions()
    {
        float screenHight = Screen.height;
        toastPositionsY = new float[4];
        toastPositionsY[0] = screenHight / 2 - screenHight / 5;
        toastPositionsY[1] = 0;
        toastPositionsY[2] = -screenHight / 2 + screenHight / 5;
        toastPositionsY[3] = -screenHight / 2 + screenHight / 20;
    }
    //校正位置 
    void AmendTransform(ToastInfo aToast)
    {
        backgroundTransform.localPosition = new Vector3(0, toastPositionsY[(int)aToast.positionEnum], 0);
    }

    public override IEnumerator EnterAnim(params object[] objs)
    {
        backgroundTransform.GetComponent<CanvasGroup>().DOFade(1, 0.5f ).OnComplete(() =>
        {
            OpenSuccess();
            UIManager.CloseUIWindow(this);
        });
        yield break;
    }

    public override IEnumerator ExitAnim(UICallBack l_callBack, params object[] objs)
    {
        yield return new WaitForSeconds(toastInfo.time);
        backgroundTransform.GetComponent<CanvasGroup>().DOFade(0, 0.3f ).OnComplete(() =>
        {
            ExitSuccess();
            UIManager.CloseMessage();
        });
        yield break;
    }

    //请在这里写UI的更新逻辑，当该UI监听的事件触发时，该函数会被调用
    public override void OnRefresh()
    {

    }

}
public enum ToastPositionEnum
{
    high,
    middle,
    low,
    verylow
}