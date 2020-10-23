using UnityEngine;
using System.Collections;
using app.net;
using app.bangpaiHongbao;
using app.human;

public class BangpaihongbaoItemScript 
{
    HongbaoItemUI UI;
    CorpsRedEnvelopeInfo mInfo;
    HongbaoxiangqingScript xiangqingScript;
    bool haveGetRedEnvelope = false;
    public BangpaihongbaoItemScript(HongbaoItemUI UI,HongbaoxiangqingScript xiangqingScript)
    {
        this.UI = UI;
        UI.btn_lingqu.SetClickCallBack(OnclickLingqu);
        this.xiangqingScript = xiangqingScript;
    }

    public void SetData(CorpsRedEnvelopeInfo info)
    {
        mInfo = info;
        HaveGotRedEnvelope();
        UI.textShuliang.text = string.Format("{0}/{1}",info.remainingNum,BangpaiHongbaoView.HONGBAOMAXNUM);
        UI.tfYIlingwan.gameObject.SetActive(info.remainingNum <= 0);
        UI.text_btn.text = haveGetRedEnvelope ? "查看" : "领取";
        UI.text_name.text = info.sendName;
    }

    private void HaveGotRedEnvelope()
    {
        for (int i = 0; i < mInfo.openRedEnveloperInfoList.Length; i++)
        {
            if (mInfo.openRedEnveloperInfoList[i].recId == Human.Instance.Id)
            {
                haveGetRedEnvelope = true;
                return;
            }
        }
        haveGetRedEnvelope = false;
       
    }

    public void SetVisible(bool visible)
    {
        UI.gameObject.SetActive(visible);
    }

    private void OnclickLingqu()
    {
        if (mInfo.remainingNum == 0 || haveGetRedEnvelope)
        {
            xiangqingScript.InitData(mInfo);
        }
        else
        {
            CorpsCGHandler.sendCGGotCorpsRedEnvelope(1,mInfo.uuid);
        }
    }
    

}
