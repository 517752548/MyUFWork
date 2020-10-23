using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using app.net;
using app.item;
using app.db;
using app.utils;
using app.pet;
using app.confirm;

public class XinFaSkillXianFuItemUI : MonoBehaviour, IPointerClickHandler
{
    public CommonItemScript item;
    public Text lv;
    public GameObject line;
    public Text desc;
    public GameObject suo;
    public Text emptyDesc;
    public GameUUButton switchBtn;
    public GameUUButton upgradeBtn;

    //格子序号，从1开始。
    public int index = 0;
    public int skillId = 0;

    private PetSkillEffectInfo mData = null;

    public void Init()
    {
        CommonItemUINoClick itemUI = transform.Find("CommonItemUINoClick70_70").gameObject.AddComponent<CommonItemUINoClick>();
        itemUI.Init();
        item = new CommonItemScript(itemUI);
        lv = transform.Find("lv").gameObject.GetComponent<Text>();
        line = transform.Find("Image").gameObject;
        desc = transform.Find("desc").gameObject.GetComponent<Text>();
        suo = transform.Find("suo").gameObject;
        emptyDesc = transform.Find("emptyDesc").gameObject.GetComponent<Text>();
        switchBtn = transform.Find("switchBtn").gameObject.GetComponent<GameUUButton>();
        switchBtn.AddClickCallBack(SwitchXianFu);
        upgradeBtn = transform.Find("upgradeBtn").gameObject.GetComponent<GameUUButton>();
        upgradeBtn.AddClickCallBack(UpgradeXianFu);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (mData == null)
        {
            //解锁。
            SkillEffectOpenTemplate skillEffectOpenTpl = SkillEffectOpenTemplateDB.Instance.getTemplate(PetModel.Ins.GetLeaderSkillInfo(skillId).embedSkillEffectList.Length + 1);
            ItemTemplate itemTpl = ItemTemplateDB.Instance.getTempalte(skillEffectOpenTpl.itemTplId);
            ConfirmWnd.Ins.ShowConfirm("仙符格子解锁", "确定使用<color='green'>" + skillEffectOpenTpl.itemNum + "</color>个<color='green'>" + itemTpl.name + "</color>解锁仙符格子吗？", ConfirmOpenPosition);
        }
        else if (mData.effectItemId == 0)
        {
            //镶嵌
            WndManager.open(GlobalConstDefine.XianFuUpgradeView_name, new int[]{0, skillId, index});
        }
    }

    private void ConfirmOpenPosition(RMetaEvent e)
    {
        PetCGHandler.sendCGPetSkillEffectOpenPosition(skillId);
    }

    private void SwitchXianFu()
    {
        WndManager.open(GlobalConstDefine.XianFuUpgradeView_name, new int[]{0, skillId, index});
    }

    private void UpgradeXianFu()
    {
        WndManager.open(GlobalConstDefine.XianFuUpgradeView_name, new int[]{1, skillId, index});
    }

    public void SetData(PetSkillEffectInfo data)
    {
        mData = data;
        if (data == null)
        {
            item.setEmpty();
            lv.gameObject.SetActive(false);
            line.SetActive(false);
            desc.gameObject.SetActive(false);
            emptyDesc.gameObject.SetActive(true);
            SkillEffectOpenTemplate skillEffectOpenTpl = SkillEffectOpenTemplateDB.Instance.getTemplate(index);
            ItemTemplate itemTpl = ItemTemplateDB.Instance.getTempalte(skillEffectOpenTpl.itemTplId);
            emptyDesc.text = "使用<color='green'>" + itemTpl.name + "</color>解锁";
            suo.SetActive(true);
            switchBtn.gameObject.SetActive(false);
            upgradeBtn.gameObject.SetActive(false);
        }
        else
        {
            lv.gameObject.SetActive(true);
            line.SetActive(true);
            desc.gameObject.SetActive(true);
            emptyDesc.gameObject.SetActive(false);
            suo.SetActive(false);

            if (data.effectItemId == 0)
            {
                item.setEmpty();
                lv.gameObject.SetActive(false);
                line.SetActive(false);
                desc.gameObject.SetActive(false);
                emptyDesc.gameObject.SetActive(true);
                emptyDesc.text = "点击镶嵌仙符";
                switchBtn.gameObject.SetActive(false);
                upgradeBtn.gameObject.SetActive(false);
            }
            else
            {
                lv.gameObject.SetActive(true);
                line.SetActive(true);
                desc.gameObject.SetActive(true);
                emptyDesc.gameObject.SetActive(false);
                SkillEffectItemTemplate itemTpl = SkillEffectItemTemplateDB.Instance.getTemplate(data.effectItemId);
                item.setTemplate(itemTpl);
                lv.text = "LV " + data.level + "/" + itemTpl.levelMax;
                SkillEffectDescTemplate descTpl = SkillEffectDescTemplateDB.Instance.getTemplate(itemTpl.skillEffectId);
                if (descTpl != null)
                {
                    desc.text = StringUtil.Assemble(descTpl.descInfo, new string[]{descTpl.coef1Desc.ToString(), descTpl.coef2Desc.ToString(), descTpl.coef3Desc.ToString()});
                }
                switchBtn.gameObject.SetActive(true);
                upgradeBtn.gameObject.SetActive(true);
            }
        }
    }
}