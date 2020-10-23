using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using app.net;

public class HongbaoxiangqingScript
{
    HongbaoXiangqingUI UI;
    List<HongbaoXiangqingItemUI> itemUIs = new List<HongbaoXiangqingItemUI>();
    
    public HongbaoxiangqingScript(HongbaoXiangqingUI UI)
    {
        this.UI = UI;
        UI.btnClose.SetClickCallBack(OnClickClose);
        UI.xiangqingItemUI.gameObject.SetActive(false);
    }

    public void InitData(CorpsRedEnvelopeInfo info)
    {
        UI.gameObject.SetActive(true);
        UI.textNum.text = info.bonusAmount.ToString();
        UI.textName.text = info.sendName;
        UI.textZhufu.text = info.content;
        UI.tfYilingwan.gameObject.SetActive(info.remainingNum <= 0);
        UI.tfYilingwanDes.gameObject.SetActive(info.remainingNum <= 0);
        for (int i = 0; i < info.openRedEnveloperInfoList.Length; i++)
        {
            if (i == itemUIs.Count)
            {
               GameObject obj = GameObject.Instantiate(UI.xiangqingItemUI.gameObject);
               obj.transform.SetParent(UI.tfGrid);
               obj.transform.localScale = Vector3.one;
               obj.SetActive(true);
               HongbaoXiangqingItemUI itemUI = obj.GetComponent<HongbaoXiangqingItemUI>();
               itemUIs.Add(itemUI);
            }
            itemUIs[i].gameObject.SetActive(true);
            itemUIs[i].textName.text = info.openRedEnveloperInfoList[i].recName;
            itemUIs[i].textNum.text = info.openRedEnveloperInfoList[i].gotBonus.ToString();
        }
        for (int i = info.openRedEnveloperInfoList.Length; i < itemUIs.Count; i++)
        {
            itemUIs[i].gameObject.SetActive(false);
        }
    }

    private void OnClickClose()
    {
        UI.gameObject.SetActive(false);
    }

    public void Destroy()
    {
        GameObject.DestroyImmediate(UI.gameObject);
        if (itemUIs != null)
        {
            itemUIs.Clear();
            itemUIs = null;
        }
    }

}
