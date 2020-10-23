using UnityEngine;
using app.model;
using app.utils;

public class CaiKuangScript
{
    public CaiKuangUI UI;

    private KuangDianScript leftKuangDian;
    private KuangDianScript rightKuangDian;

    public ShengChanModel shengchanModel;

    public CaiKuangScript(CaiKuangUI ui)
    {
        UI = ui;
        shengchanModel = ShengChanModel.Ins;
        shengchanModel.addChangeEvent(ShengChanModel.UPDATE_KUANG, UpdateList);
        initWnd();
    }

    private void initWnd()
    {
        UI.pageTurner.Loop = false;
        UI.pageTurner.AutoVisible = false;
        UI.pageTurner.MaxValue = 1;
        UI.pageTurner.Value = 0;
        UI.pageTurner.PageChangeHandler = changePage;
        //UpdateList();
    }

    public void UpdateList(RMetaEvent e=null)
    {
        int openedKuangDian = shengchanModel.GetMyKuangDianNum();
        UI.pageTurner.MaxValue = openedKuangDian%2==0?(openedKuangDian / 2):(openedKuangDian/2+1);
        changePage(UI.pageTurner.Value);
    }

    private void changePage(int page)
    {
        int openedKuangDian = shengchanModel.GetMyKuangDianNum();
        UI.leftkuang.gameObject.SetActive(page * 2 < openedKuangDian);
        UI.rightkuang.gameObject.SetActive((page * 2+1) < openedKuangDian);
        if (page*2<openedKuangDian)
        {
            UI.leftkuang.kuangdianName.text ="第"+StringUtil.GetCapstureNumberStr(page*2+1)+"个矿点";
            if (leftKuangDian==null) leftKuangDian = new KuangDianScript(UI.leftkuang);
            leftKuangDian.setKuangDianData(shengchanModel.CurrentKuangs.getPitList()[page*2]);
        }
        if ((page * 2+1) < openedKuangDian)
        {
            UI.rightkuang.kuangdianName.text = "第" + StringUtil.GetCapstureNumberStr(page * 2 + 1+1) + "个矿点";
            if (rightKuangDian == null) rightKuangDian = new KuangDianScript(UI.rightkuang);
            rightKuangDian.setKuangDianData(shengchanModel.CurrentKuangs.getPitList()[page * 2 + 1]);
        }
    }

    public void hide()
    {
        if (leftKuangDian!=null)
        {
            leftKuangDian.hide();
        }
        if (rightKuangDian != null)
        {
            rightKuangDian.hide();
        }
    }
    
    public void Destroy()
    {
        shengchanModel.removeChangeEvent(ShengChanModel.UPDATE_KUANG, UpdateList);
        if (leftKuangDian!=null)
        {
            leftKuangDian.Destroy();
            leftKuangDian = null;
        }
        if (rightKuangDian != null)
        {
            rightKuangDian.Destroy();
            rightKuangDian = null;
        }
        GameObject.DestroyImmediate(UI.gameObject, true);
        UI = null;
    }
}
