using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BangPaiListItemUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public GameUUToggle toggle;
    public Image yishenqingImage;
    public Text bianhao;
    public Text mingcheng;
    public Text dengji;
    public Text renshu;
    public Text bangzhu;

    public GameUUToggle selectToggle;
    public Text zhiye;
    public Text zhiwu;
    public Text banggong;
    public Text lishiBanggong;
    public Text zuihouzaixian;

    public Text xingbie;
    public GameUUButton tongyiBtn;
    public GameUUButton jujueBtn;

	public GameObject danshuBg;
	public GameObject shuanshuBg;

    public ScrollRect scrollRect;

	public void Init(
		Transform toggle,
		Transform yishenqingImage, 
		Transform bianhao, 
		Transform mingcheng, 
		Transform dengji, 
		Transform renshu, 
		Transform bangzhu, 
		Transform selectToggle,
		Transform zhiye,
		Transform zhiwu,
		Transform banggong,
		Transform lishiBanggong,
		Transform zuihouzaixian,
		Transform xingbie,
		Transform tongyiBtn,
		Transform jujueBtn,
		Transform dansuBg,
		Transform shuanshuBg)
	{
		if (toggle != null)
		{
			this.toggle = toggle.GetComponent<GameUUToggle>();
		}
		
		if (yishenqingImage != null)
		{
			this.yishenqingImage = yishenqingImage.GetComponent<Image>();
		}
		
		if (bianhao != null)
		{
			this.bianhao = bianhao.GetComponent<Text>();
		}
		
		if (mingcheng != null)
		{
			this.mingcheng = mingcheng.GetComponent<Text>();
		}
		
		if (dengji != null)
		{
			this.dengji = dengji.GetComponent<Text>();
		}
		
		if (renshu != null)
		{
			this.renshu = renshu.GetComponent<Text>();
		}
		
		if (bangzhu != null)
		{
			this.bangzhu = bangzhu.GetComponent<Text>();
		}
		
		if (selectToggle != null)
		{
			this.selectToggle = selectToggle.GetComponent<GameUUToggle>();
		}
		
		if (zhiye != null)
		{
			this.zhiye = zhiye.GetComponent<Text>();
		}
		
		if (zhiwu != null)
		{
			this.zhiwu = zhiwu.GetComponent<Text>();
		}
		
		if (banggong != null)
		{
			this.banggong = banggong.GetComponent<Text>();
		}
		
		if (lishiBanggong != null)
		{
			this.lishiBanggong = lishiBanggong.GetComponent<Text>();
		}
		
		if (zuihouzaixian != null)
		{
			this.zuihouzaixian = zuihouzaixian.GetComponent<Text>();
		}
		
		if (xingbie != null)
		{
			this.xingbie = xingbie.GetComponent<Text>();
		}
		
		if (tongyiBtn != null)
		{
			this.tongyiBtn = tongyiBtn.GetComponent<GameUUButton>();
		}
		
		if (jujueBtn != null)
		{
			this.jujueBtn = jujueBtn.GetComponent<GameUUButton>();
		}
		
		if (dansuBg != null)
		{
			this.danshuBg = dansuBg.gameObject;
		}
		
		if (shuanshuBg != null)
		{
			this.shuanshuBg = shuanshuBg.gameObject;
		}
		
	}

	public void SetIndex(int i)
	{
		if (danshuBg != null && shuanshuBg != null)
		{
			if (i % 2 == 0)
			{
				danshuBg.SetActive (false);
				shuanshuBg.SetActive (true);
                toggle.targetGraphic = shuanshuBg.GetComponent<Image>();
			}
			else
			{
				danshuBg.SetActive (true);
				shuanshuBg.SetActive (false);
                toggle.targetGraphic = danshuBg.GetComponent<Image>();
			}
		}
	}

    public void OnDrag(PointerEventData eventData)
    {
        if (scrollRect != null)
        {
            scrollRect.OnDrag(eventData);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (scrollRect != null)
        {
            scrollRect.OnBeginDrag(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (scrollRect != null)
        {
            scrollRect.OnEndDrag(eventData);
        }
    }
}
