using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PaiMaiHangItemUI : MonoBehaviour
{
    public CommonItemUI commonItemUI;
    public Image icon;
    public Text itemName;
    public Text levelText;
    public MoneyItemUI sellPrice;
    public CommonItemUINoClick commonItemUINoClick;
    public Transform tfZhekou;
    public Text textZheKou;
    public Transform tfShouqing;
    
    public void Init(CommonItemUI cmui,Image image,Text itemName,Text levelText,MoneyItemUI sellPrice,CommonItemUINoClick cclick)
     {
         this.commonItemUI = cmui;
         this.icon = image;
         this.itemName = itemName;
         this.levelText = levelText;
         this.sellPrice = sellPrice;
         this.commonItemUINoClick = cclick;

         tfZhekou = transform.Find("Image_zhekou");
         if (tfZhekou != null)
         {
             textZheKou = tfZhekou.Find("Text_zhekou").GetComponent<Text>();
         }
         tfShouqing = transform.Find("Image_shouqing");
         if (tfZhekou != null)
         {
             tfZhekou.gameObject.SetActive(false);
         }
         
         if (tfShouqing != null)
         {
             tfShouqing.gameObject.SetActive(false);
         }
      }

}
