using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class NormalNotice : UIWindowBase
{
    public Text msgText;
    public GameObject IphoneXSceen;
    public float height = 100;

    private float BeforeMoveY = 1260;//移动之前的y轴位置
    private float AfterMoveY = 930;//移动之后的y轴位置
    private Tweener tweener = null;
    private NoticeInfo info = null;

    public override void OnOpen()
    {
        info = GetNoticeInfo(objs);
        if (tweener != null)
        {
            tweener.Kill();
            tweener = null;
        }
        //transform.localPosition = new Vector3(transform.localPosition.x, BeforeMoveY, 0);
        msgText.text = info.message;
        //msgText.fontSize = info.fontSize;
        float parentH = transform.parent.gameObject.GetComponent<RectTransform>().rect.height;
        BeforeMoveY = (parentH / 2 + height + 100);
        AfterMoveY = parentH / 2;
        transform.localPosition = new Vector3(transform.localPosition.x, BeforeMoveY, 0);
        IphoneXSceen = transform.Find("IphoneX_shipei").gameObject;
        if (XUtils.IsIphoneX())
        {
            AfterMoveY -= 45;
            IphoneXSceen.SetActive(true);
        }
        else
        {
            IphoneXSceen.SetActive(false);
        }
        base.OnOpen();
    }

    public override IEnumerator EnterAnim(params object[] objs)
    {
        OpenSuccess();
        StartMove();
        yield break;
    }

    public override IEnumerator ExitAnim( UICallBack l_callBack, params object[] objs)
    {
        ExitSuccess();
        if (tweener != null)
        {
            tweener.Kill();
            tweener = null;
        }
        yield break;
    }

    private void StartMove()
    {
        tweener = transform.DOLocalMoveY(AfterMoveY, 0.5f).OnComplete(() =>
        {
            tweener = transform.DOLocalMoveY(BeforeMoveY, 0.5f).SetDelay(2f).OnComplete(() =>
            {
                tweener = null;
                Close();
            });
        });
    }

    public override void OnClose()
    {
        if (tweener != null)
        {
            tweener.Kill();
            tweener = null;
        }
        base.OnClose();
    }

    public override bool HaveDataChange(object[] objs)
    {
        NoticeInfo target = GetNoticeInfo(objs);
        if (info != null && target.message == info.message)
            return false;
        return true;
    }

    private NoticeInfo GetNoticeInfo(object[] objs)
    {
        NoticeInfo info = new NoticeInfo();
        if (objs == null || objs.Length == 0)
            return info;
        info.message = (string)objs[0];
        info.fontSize = objs.Length > 1 ? (int)objs[1] : 35;
        return info;
    }

    private class NoticeInfo
    {
        public string message = "null";
        public int fontSize = 35;
    }

    public void ShowMessage(params object[] objs)
    {
        NoticeInfo target = GetNoticeInfo(objs);
        if (info != null && target.message == info.message)
            return;
        info = target;
        if (tweener != null)
        {
            tweener.Kill();
            tweener = null;
        }
        //transform.localPosition = new Vector3(transform.localPosition.x, BeforeMoveY, 0);
        msgText.text = info.message;
       // msgText.fontSize = info.fontSize;
        float parentH = transform.parent.gameObject.GetComponent<RectTransform>().rect.height;
        BeforeMoveY = (height + 100 + parentH);
        AfterMoveY = parentH;
        transform.localPosition = new Vector3(transform.localPosition.x, BeforeMoveY, 0);
        IphoneXSceen = transform.Find("IphoneX_shipei").gameObject;
        if (XUtils.IsIphoneX())
        {
            AfterMoveY -= 45;
            IphoneXSceen.SetActive(true);
        }
        else
        {
            IphoneXSceen.SetActive(false);
        }
        gameObject.SetActive(true);
        NoticeMove();
    }

    void NoticeMove()
    {
        tweener = transform.DOLocalMoveY(AfterMoveY, 0.5f).OnComplete(() =>
        {
            tweener = transform.DOLocalMoveY(BeforeMoveY, 0.5f).SetDelay(2f).OnComplete(() =>
            {
                tweener = null;
                info = null;
            });
        });
    }
}