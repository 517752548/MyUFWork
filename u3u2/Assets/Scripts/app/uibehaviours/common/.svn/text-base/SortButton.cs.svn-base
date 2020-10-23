using UnityEngine.UI;

public delegate void SortButtonHandler(int sortType);
/// <summary>
/// 排序按钮
/// </summary>
public class SortButton
{
    private GameUUButton btn;

    private Text btnText;
    private string btnOriginalText;
    /// <summary>
    /// 0，默认
    /// -1，升序，从小到大
    /// 1，降序，从大到小
    /// </summary>
    private int currentSortType = 0;

    private SortButtonHandler _callBackHandler;

    public SortButton(GameUUButton button, SortButtonHandler clickHandler)
    {
        btn = button;
        btn.SetClickCallBack(clickBtn);
        _callBackHandler = clickHandler;
    }

    public void setToNormal()
    {
        if (btnText != null)
        {
            btnText.text = btnOriginalText;
        }
        currentSortType = 0;
    }

    private void clickBtn()
    {
        if (btnText==null)
        {
            btnText = btn.GetComponentInChildren<Text>();
            if (btnText!=null)
            {
                btnOriginalText = btnText.text;
            }
        }
        switch (currentSortType)
        {
            case 1:
                if (btnText != null)
                {
                    btnText.text = btnOriginalText + "▲";
                }
                currentSortType = -1;
            break;
            case 0:
            case -1:
                if (btnText != null)
                {
                    btnText.text = btnOriginalText + "▼";
                }
                currentSortType = 1;
            break;
        }
        if (_callBackHandler != null)
        {
            _callBackHandler(currentSortType);
        }
    }
    
}
