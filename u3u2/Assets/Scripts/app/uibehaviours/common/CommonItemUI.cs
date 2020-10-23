using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public delegate void ClickCommonItemHandler();
public delegate void ClickCommonItemHandlerObj(PointerEventData eventData);

public class CommonItemUI : MonoBehaviour, IPointerClickHandler//, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image bg;

    public Image icon;

    public Image biangkuang;

    public Text num;

    public Text Name;

    public GameObject Xing;
    public Text XingTxt;

    public GameUUToggle SelectedToggle;

    public Image jiahao;

    public GameObject glowEffect;
    public Image yizhuangbei;
    private ClickCommonItemHandler clickCommonItemHandler;
    private ClickCommonItemHandlerObj clickCommonItemHandlerobj;
    private ScrollRect scrollRect;

    public void Init(
        Image bg,
        Image icon,
        Image biankuang,
        Text num,
        Text Name,
        GameObject Xing,
        Text XingTxt,
        GameUUToggle selectedToggle,
        GameObject glowEffect,
        Image yizhuangbei)
    {
        this.bg = bg;
        this.icon = icon;
        this.biangkuang = biankuang;
        this.num = num;
        this.Name = Name;
        this.Xing = Xing;
        this.XingTxt = XingTxt;
        this.SelectedToggle = selectedToggle;
        this.glowEffect = glowEffect;
        this.yizhuangbei = yizhuangbei;
        if (this.biangkuang != null)
        {
            this.biangkuang.gameObject.SetActive(false);
        }
        if (this.icon != null)
        {
            this.icon.gameObject.SetActive(false);
        }
    }

    public void Init()
    {
        Transform bg = transform.Find("Image");
        if (bg != null)
        {
            this.bg = bg.GetComponent<Image>();
        }
        Transform icon = transform.Find("Icon");
        if (icon != null)
        {
            this.icon = icon.GetComponent<Image>();
        }
        Transform biankuang = transform.Find("BianKuang");
        if (biankuang != null)
        {
            this.biangkuang = biankuang.GetComponent<Image>();
        }
        Transform num = transform.Find("Num");
        if (num != null)
        {
            this.num = num.GetComponent<Text>();
        }
        Transform Name = transform.Find("Name");
        if (Name != null)
        {
            this.Name = Name.GetComponent<Text>();
        }
        Transform Xing = transform.Find("xing");
        if (Xing != null)
        {
            this.Xing = Xing.gameObject;
        }
        Transform XingTxt = transform.Find("xing/Text");
        if (XingTxt != null)
        {
            this.XingTxt = XingTxt.GetComponent<Text>();
        }
        Transform selectedToggle = transform.Find("Toggle");
        if (selectedToggle != null)
        {
            this.SelectedToggle = selectedToggle.GetComponent<GameUUToggle>();
        }
        Transform glowEffect = transform.Find("glowEffect");
        if (glowEffect != null)
        {
            this.glowEffect = glowEffect.gameObject;
        }
        Transform yizhuangbei = transform.Find("yizhuangbei");
        if (yizhuangbei != null)
        {
            this.yizhuangbei = yizhuangbei.GetComponent<Image>();
        }
        else
        {
            if (transform.Find("Image (1)")!=null)
            {
                this.yizhuangbei = transform.Find("Image (1)").GetComponent<Image>();
            }
            if (transform.Find("yizhuangbei") != null)
            {
                this.yizhuangbei = transform.Find("yizhuangbei").GetComponent<Image>();
            }
        }
        if (transform.Find("jiahao")!=null)
        {
            jiahao = transform.Find("jiahao").GetComponent<Image>();
        }
        if (biangkuang != null)
        {
            biangkuang.gameObject.SetActive(false);
        }
        if (this.icon != null)
        {
            this.icon.gameObject.SetActive(false);
        }
    }

    public ClickCommonItemHandler ClickCommonItemHandler
    {
        set { clickCommonItemHandler = value; }
    }

    public ClickCommonItemHandlerObj ClickCommonItemHanderObj
    {
        set
        {
            clickCommonItemHandlerobj = value;
        }
    }

    public ScrollRect ScrollRect
    {
        set { scrollRect = value; }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickCommonItemHandler != null)
        {
            clickCommonItemHandler();
        }
        if (clickCommonItemHandlerobj != null)
        {
            clickCommonItemHandlerobj(eventData);
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

    public void ShowGlowEffect(GameObject glowEffect)
    {
        HideGlowEffect();
        glowEffect.transform.SetParent(this.transform);
        glowEffect.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        this.glowEffect = glowEffect;
    }

    public void HideGlowEffect()
    {
        if (this.glowEffect != null)
        {
            GameObject.DestroyImmediate(this.glowEffect, true);
            this.glowEffect = null;
        }
    }

    public bool HasGlowEffect()
    {
        return this.glowEffect != null;
    }
}
