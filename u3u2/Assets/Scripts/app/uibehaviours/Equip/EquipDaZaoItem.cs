using UnityEngine;
using UnityEngine.UI;

public class EquipDaZaoItem : MonoBehaviour
{
    public Image bg;
    public Image selectedBg;
    public GameUUToggle toggle;
    public CommonItemUINoClick item;
    public Text equipName;
    public Text equipLevel;
    public Text equipType;
    public int equipTemplateId;

    public void Init(
        Image bg,
        Image selectedBg,
        GameUUToggle toggle,
        CommonItemUINoClick item,
        Text equipName,
        Text equipLevel,
        Text equipType)
    {
        this.bg = bg;
        this.selectedBg = selectedBg;
        this.toggle = toggle;
        this.item = item;
        this.equipName = equipName;
        this.equipLevel = equipLevel;
        this.equipType = equipType;
    }

}
