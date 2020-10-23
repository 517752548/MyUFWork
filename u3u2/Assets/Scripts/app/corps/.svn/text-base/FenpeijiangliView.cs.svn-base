using UnityEngine;
using System.Collections;
using app.net;
using app.utils;
using app.db;

public class FenpeijiangliView  
{
    public FenpeijiangliUI UI;
    AllocateMemberInfo memberInfo;
    int chooseIndex = -1;

    public FenpeijiangliView(FenpeijiangliUI UI)
    {
        this.UI = UI;
        UI.btnFenpei.SetClickCallBack(OnClickFenpeijingli);
        UI.btnClose.SetClickCallBack(OnClickCloseFenpeijiangli);
        UI.btn_fenpeiquxiao.SetClickCallBack(OnClickCloseQuerenfenpei);
        UI.btn_fenpeiQueding.SetClickCallBack(OnClickQuedingFenpei);
    }

    public void SetData(AllocateMemberInfo memberInfo)
    {
        this.memberInfo = memberInfo;
        SetFenpeiJiangliData();
        UI.gameObject.SetActive(true);
        UI.fenpeiquedingObj.SetActive(false);
    }

    private void SetFenpeiJiangliData()
    {
        GCOpenAllocatePanel data = CorpModel.Ins.GCOpenAllocatePanel;
        AllocateItemInfo[] itemInfos = data.getBeforeAllocateItemInfos();
        for (int i = 0; i < itemInfos.Length; i++)
        {
            if (itemInfos[i].itemId == BangpaiJingsaiJiangliView.JINBAOXIANG_ITEM_ID)
            {
                UI.text_jinRemin.text = itemInfos[i].num.ToString();
            }
            else if (itemInfos[i].itemId == BangpaiJingsaiJiangliView.YINBAOXIANG_ITEM_ID)
            {
                UI.text_yinRemin.text = itemInfos[i].num.ToString();
            }
            else if (itemInfos[i].itemId == BangpaiJingsaiJiangliView.TIEBAOXIANG_ITEM_ID)
            {
                UI.text_tieRemin.text = itemInfos[i].num.ToString();
            }
        }
    }

    private void OnClickFenpeijingli()
    {
        chooseIndex = -1;
        int tplId = -1;
        if (UI.toggle_jin.isOn)
        {
            chooseIndex = 0;
        }
        else if (UI.toggle_yin.isOn)
        {
            chooseIndex = 1;
        }
        else
        {
            chooseIndex = 2;
        }
        if (chooseIndex == 0)
        {
            tplId = BangpaiJingsaiJiangliView.JINBAOXIANG_ITEM_ID;
        }
        else if (chooseIndex == 1)
        {
            tplId = BangpaiJingsaiJiangliView.YINBAOXIANG_ITEM_ID;
        }
        else if (chooseIndex == 2)
        {
            tplId = BangpaiJingsaiJiangliView.TIEBAOXIANG_ITEM_ID;
        }

        ItemTemplate tpl = ItemTemplateDB.Instance.getTempalte(tplId);

        UI.fenpeiquedingObj.gameObject.SetActive(true);
        UI.text_fenpei.text = string.Format("确定要将{0}分配给{1}玩家吗", tpl.name, ColorUtil.getColorText(ColorUtil.GREEN_ID, memberInfo.playerName));

    }

    private void OnClickCloseFenpeijiangli()
    {
        UI.gameObject.SetActive(false);
    }

    private void OnClickCloseQuerenfenpei()
    {
        UI.fenpeiquedingObj.SetActive(false);
    }

    private void OnClickQuedingFenpei()
    {
        UI.gameObject.SetActive(false);
        AllocateItemInfo[] iteminfo = new AllocateItemInfo[1];
        iteminfo[0] = new AllocateItemInfo();
        if (chooseIndex == 0)
        {
            iteminfo[0].itemId = BangpaiJingsaiJiangliView.JINBAOXIANG_ITEM_ID;
        }
        else if (chooseIndex == 1)
        {
            iteminfo[0].itemId = BangpaiJingsaiJiangliView.YINBAOXIANG_ITEM_ID;
        }
        else
        {
            iteminfo[0].itemId = BangpaiJingsaiJiangliView.TIEBAOXIANG_ITEM_ID;
        }
        iteminfo[0].num = 1;
        CorpsCGHandler.sendCGAllocateActivityItem(3, memberInfo.roleId, iteminfo);
    }

    public void Destroy()
    {
        if(UI != null)
        {
            GameObject.DestroyImmediate(UI.gameObject,false);
            UI = null;
        }
        memberInfo = null;
    }
}
