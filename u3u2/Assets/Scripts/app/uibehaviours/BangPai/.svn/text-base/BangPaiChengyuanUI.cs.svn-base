using UnityEngine;
using System.Collections;


public class BangPaiChengyuanUI : MonoBehaviour 
{
    public BangPaiMemberListUI memberListUI;
    public BangPaiShenQingListUI shenqingUI;
    public BangPaiShiJianListUI shijianUI;

    public TabButtonGroup chengyuanTBG;

    public void Init()
    {
        chengyuanTBG = transform.Find("btngrid").gameObject.AddComponent<TabButtonGroup>();
        chengyuanTBG.AddToggle(transform.Find("btngrid/chengyuanLiebiao").GetComponent<GameUUToggle>());
        chengyuanTBG.AddToggle(transform.Find("btngrid/shenqingLiebiao").GetComponent<GameUUToggle>());
        chengyuanTBG.AddToggle(transform.Find("btngrid/bangpaiShijian").GetComponent<GameUUToggle>());

        memberListUI = transform.Find("chengyuanList").gameObject.AddComponent<BangPaiMemberListUI>();
        memberListUI.Init();
        
        shenqingUI = transform.Find("shenqingList").gameObject.AddComponent<BangPaiShenQingListUI>();
        shenqingUI.Init();
        
        shijianUI = transform.Find("shijianList").gameObject.AddComponent<BangPaiShiJianListUI>();
        shijianUI.Init();
 
    }
}
