using UnityEngine;
using System.Collections;
using app.net;

public class QianghongbaoScript 
{
    private const int HIDETIME = 2000;
    LingHongbaoUI UI;
    RTimer mTimer;
    public QianghongbaoScript(LingHongbaoUI UI)
    {
        this.UI = UI;
        EventTriggerListener.Get(UI.tfMask.gameObject).onClick = OnClickClose;
    }

    public void SetData(GCGotCorpsRedEnvelope info)
    {
        UI.gameObject.SetActive(true);
        if (mTimer != null)
        {
            mTimer.stop();
            mTimer = null;
        }

        mTimer = TimerManager.Ins.createTimer(HIDETIME, HIDETIME, null, TimerEnd);           
        mTimer.start();
        GCOpenCorpsRedEnvelopePanel panelInfo = CorpModel.Ins.GCOpenCorpsRedEnvelopePanel;
        CorpsRedEnvelopeInfo hongbaoInfo = null;
        CorpsRedEnvelopeInfo[] hongbaoInfos = panelInfo.getCorpsRedEnvelopeInfoList();
        for (int i = 0; i < hongbaoInfos.Length; i++)
        {
            if (hongbaoInfos[i].uuid == info.getUuid())
            {
                hongbaoInfo = hongbaoInfos[i];
                break;
            }
        }
        UI.textNum.text = info.getGotBonus().ToString();
        UI.textDec.text = string.Format("你抢到了,{0}发放的红包",hongbaoInfo.sendName);
        UI.textZhufu.text = hongbaoInfo.content;
    }

    

    private void OnClickClose(GameObject obj)
    {
        UI.gameObject.SetActive(false);
    }

    private void TimerEnd(RTimer timer)
    {
        OnClickClose(null);
    }

    public void Destroy()
    {
        GameObject.DestroyImmediate(UI.gameObject);
        if (mTimer != null)
        {
            mTimer.stop();
        }
    }
	
}
