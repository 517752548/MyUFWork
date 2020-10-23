using app.net;
using app.pet;
using UnityEngine;
using app.human;
using app.utils;

/// <summary>
/// 帮派列表、帮派成员列表 中的一行元素
/// </summary>
public class CorpListItemScript
{
    public BangPaiListItemUI UI;
    private SimpleCorpsInfo corpData;
    private CorpsMemberInfo memberData;
    private MemberApplyInfo shenqingData;
    private CorpsEventInfo eventInfo;

    public CorpListItemScript(BangPaiListItemUI ui)
    {
        UI = ui;
    }

    public SimpleCorpsInfo CorpData
    {
        get { return corpData; }
    }

    public CorpsMemberInfo MemberData
    {
        get { return memberData; }
    }


    private string m_col_ziji = "#05741d";  //自己
    private string m_col_zaixian = "#774f31"; //在线
    private string m_col_lixian = "#6a6969"; //离线

    /// <summary>
    /// 设置帮派列表 信息
    /// </summary>
    /// <param name="corpdata"></param>
    /// <param name="bianhao"></param>
    public void setCorpListData(SimpleCorpsInfo corpdata,int bianhao)
    {
        corpData = corpdata;
		

		
        UI.bianhao.text = bianhao.ToString();
		UI.mingcheng.text = corpData.name;
        UI.dengji.text = corpData.level.ToString();
        UI.renshu.text = corpData.currMemNum + "/" + corpData.maxMemNum;
        UI.bangzhu.text = corpData.presidentName;

        UI.yishenqingImage.gameObject.SetActive(false);
        if (corpData.isApplied==0)
        {
            UI.yishenqingImage.gameObject.SetActive(false);
        }
        else
        {
            UI.yishenqingImage.gameObject.SetActive(true);
        }
    }
    /// <summary>
    /// 设置 帮派信息界面的 在线成员信息
    /// </summary>
    /// <param name="memberDatav"></param>
    public void setInfoMemberInfo(CorpsMemberInfo memberDatav)
    {
        memberData = memberDatav;
        UI.mingcheng.text = MemberData.name;
        UI.dengji.text = MemberData.level.ToString();
        UI.zhiye.text = PetJobType.GetJobName(MemberData.petJob);
        UI.zhiwu.text = CorpTitleDef.GetCorpTitleName(memberData.memJob);
        UI.banggong.text = MemberData.totalContribution.ToString();
    }

    /// <summary>
    /// 设置 成员列表界面的 在线成员信息
    /// </summary>
    /// <param name="memberDatav"></param>
    public void setListMemberInfo(CorpsMemberInfo memberDatav,int bianhao)
    {
        memberData = memberDatav;
        //UI.bianhao.text = "" + (bianhao+1);
        string name = MemberData.name;
        string level = MemberData.level.ToString();
        string zhiye = PetJobType.GetJobName(MemberData.petJob);
        string zhiwu = CorpTitleDef.GetCorpTitleName(memberData.memJob);
        string banggong = MemberData.weekContribution.ToString();
        string lishibanggong = MemberData.totalContribution.ToString();
        string zuihouzaixian = MemberData.onlineDesc;
        if (memberData.memId == Human.Instance.Id)
        {
            name = ColorUtil.getColorText(m_col_ziji, name);
            level = ColorUtil.getColorText(m_col_ziji, level);
            zhiye = ColorUtil.getColorText(m_col_ziji, zhiye);
            zhiwu = ColorUtil.getColorText(m_col_ziji, zhiwu);
            banggong = ColorUtil.getColorText(m_col_ziji, banggong);
            lishibanggong = ColorUtil.getColorText(m_col_ziji, lishibanggong);
            zuihouzaixian = ColorUtil.getColorText(m_col_ziji, zuihouzaixian);
        }
        else if (memberData.onlineDesc==LangConstant.ZAIXIAN) {
            name = ColorUtil.getColorText(m_col_zaixian, name);
            level = ColorUtil.getColorText(m_col_zaixian, level);
            zhiye = ColorUtil.getColorText(m_col_zaixian, zhiye);
            zhiwu = ColorUtil.getColorText(m_col_zaixian, zhiwu);
            banggong = ColorUtil.getColorText(m_col_zaixian, banggong);
            lishibanggong = ColorUtil.getColorText(m_col_zaixian, lishibanggong);
            zuihouzaixian = ColorUtil.getColorText(m_col_zaixian, zuihouzaixian);
        }
        else
        {
            name = ColorUtil.getColorText(m_col_lixian, name);
            level = ColorUtil.getColorText(m_col_lixian, level);
            zhiye = ColorUtil.getColorText(m_col_lixian, zhiye);
            zhiwu = ColorUtil.getColorText(m_col_lixian, zhiwu);
            banggong = ColorUtil.getColorText(m_col_lixian, banggong);
            lishibanggong = ColorUtil.getColorText(m_col_lixian, lishibanggong);
            zuihouzaixian = ColorUtil.getColorText(m_col_lixian, zuihouzaixian);
        }
        UI.mingcheng.text = name;
        UI.dengji.text = level;
        UI.zhiye.text = zhiye;
        UI.zhiwu.text = zhiwu;
        UI.banggong.text = banggong;
        UI.lishiBanggong.text = lishibanggong;
        UI.zuihouzaixian.text = zuihouzaixian;
        UI.selectToggle.gameObject.SetActive(false);
    }

    /// <summary>
    /// 设置申请列表的数据
    /// </summary>
    /// <param name="shenqingDatav"></param>
    /// <param name="bianhao"></param>
    public void setShenQingData(MemberApplyInfo shenqingDatav,int bianhao)
    {
        shenqingData = shenqingDatav;
        UI.bianhao.text = bianhao.ToString();
        UI.mingcheng.text = shenqingData.name;
        UI.dengji.text = shenqingData.level.ToString();
        UI.xingbie.text = PetSexType.GetSexName(shenqingData.sex);
        UI.zhiye.text = PetJobType.GetJobName(shenqingData.petJob);
        UI.selectToggle.gameObject.SetActive(false);
        //EventTriggerListener.Get(UI.tongyiBtn.gameObject).onClick = clickTongyi;
        //EventTriggerListener.Get(UI.jujueBtn.gameObject).onClick = clickJujue;
        UI.tongyiBtn.SetClickCallBack(clickTongyi);
        UI.jujueBtn.SetClickCallBack(clickJujue);
    }

    private void clickTongyi(GameObject go)
    {
        CorpsCGHandler.sendCGClickCorpsMemberFunction(shenqingData.memId,CorpFuncIdDef.TONGYI_SHENQING);
    }

    private void clickJujue(GameObject go)
    {
        CorpsCGHandler.sendCGClickCorpsMemberFunction(shenqingData.memId, CorpFuncIdDef.JUJUE_SHENQING);
    }

    /// <summary>
    /// 设置帮派事件的数据
    /// </summary>
    /// <param name="eventInfov"></param>
    public void setShiJian(CorpsEventInfo eventInfov)
    {
        eventInfo = eventInfov;
        UI.bianhao.text = eventInfo.onlineDesc;
        UI.mingcheng.text = eventInfo.corpsLog;
    }

    public void changeSelectToggleVisi(bool visi)
    {
        UI.selectToggle.gameObject.SetActive(visi);
        UI.selectToggle.isOn = false;
    }

    public bool IsToggleSelected()
    {
        return UI.selectToggle.isOn;
    }

    public void Destroy()
    {
        if (UI)
        {
            GameObject.DestroyImmediate(UI.gameObject, true);
        }
        UI = null;
        corpData=null;
        memberData=null;
        shenqingData=null;
        eventInfo=null;
    }
}
