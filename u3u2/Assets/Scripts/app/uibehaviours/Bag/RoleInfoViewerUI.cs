using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RoleInfoViewerUI : MonoBehaviour
{
    public GameUUButton closeBtn;

    public List<CommonItemUI> leftEquipImageList;

    public List<CommonItemUI> rightEqiupImageList;

    public List<CommonItemUI> topEqiupImageList;

    public List<CommonItemUI> downEqiupImageList;

    public List<CommonItemUI> allEquipList;

    public Text roleName;
    public Text roleJob;
    public Text roleLevel;
    public Text bangpai;
    public Text roleZhanli;

    public ToggleGroup toggleGroup;
    public TabButtonGroup itemTabButtonGroup;

    public GameUUButton fasongxiaoxi;
    public GameUUButton yaoqingrubang;
    public GameUUButton jiaweihaoyou;

    public GameObject modelContainer;
    
    public void Init()
    {
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        
        roleName = transform.Find("rightInfo/rolename").GetComponent<Text>();
        roleJob = transform.Find("rightInfo/rolejob").GetComponent<Text>();
        roleLevel = transform.Find("rightInfo/rolelevel").GetComponent<Text>();
        bangpai = transform.Find("rightInfo/bangpai").GetComponent<Text>();
        roleZhanli = transform.Find("rightInfo/zhanlizhi").GetComponent<Text>();
        
        fasongxiaoxi = transform.Find("fasongxiaoxi").GetComponent<GameUUButton>();
        yaoqingrubang = transform.Find("yaoqingrubang").GetComponent<GameUUButton>();
        jiaweihaoyou = transform.Find("jiaweihaoyou").GetComponent<GameUUButton>();
        
        modelContainer = transform.Find("modelContainerBg/modelContainer").gameObject;
        
        toggleGroup = transform.Find("leftPanel").GetComponent<ToggleGroup>();
        itemTabButtonGroup = transform.Find("leftPanel").gameObject.AddComponent<TabButtonGroup>();
        
        allEquipList = new List<CommonItemUI>();
        
        {
            leftEquipImageList = new List<CommonItemUI>();
            
            CommonItemUI itemUI = transform.Find("leftPanel/leftEquipBgList/CommonItemUIWithXing").gameObject.AddComponent<CommonItemUI>();
            itemUI.Init
            (
                itemUI.transform.Find("Image").GetComponent<Image>(),
                itemUI.transform.Find("Icon").GetComponent<Image>(),
                itemUI.transform.Find("BianKuang").GetComponent<Image>(),
                null,null,
                itemUI.transform.Find("xing").gameObject,
                itemUI.transform.Find("xing/Text").GetComponent<Text>(),
                null, null, null
            );
            leftEquipImageList.Add(itemUI);
            allEquipList.Add(itemUI);
            
            CommonItemUI itemUI1 = transform.Find("leftPanel/leftEquipBgList/CommonItemUIWithXing 1").gameObject.AddComponent<CommonItemUI>();
            itemUI1.Init
            (
                itemUI1.transform.Find("Image").GetComponent<Image>(),
                itemUI1.transform.Find("Icon").GetComponent<Image>(),
                itemUI1.transform.Find("BianKuang").GetComponent<Image>(),
                null, null,
                itemUI1.transform.Find("xing").gameObject,
                itemUI1.transform.Find("xing/Text").GetComponent<Text>(),
                null, null, null
            );
            leftEquipImageList.Add(itemUI1);
            allEquipList.Add(itemUI1);
            
            CommonItemUI itemUI2 = transform.Find("leftPanel/leftEquipBgList/CommonItemUIWithXing 2").gameObject.AddComponent<CommonItemUI>();
            itemUI2.Init
            (
                itemUI2.transform.Find("Image").GetComponent<Image>(),
                itemUI2.transform.Find("Icon").GetComponent<Image>(),
                itemUI2.transform.Find("BianKuang").GetComponent<Image>(),
                null, null,
                itemUI2.transform.Find("xing").gameObject,
                itemUI2.transform.Find("xing/Text").GetComponent<Text>(),
                null, null, null
            );
            leftEquipImageList.Add(itemUI2);
            allEquipList.Add(itemUI2);
            
            CommonItemUI itemUI3 = transform.Find("leftPanel/leftEquipBgList/CommonItemUIWithXing 3").gameObject.AddComponent<CommonItemUI>();
            itemUI3.Init
            (
                itemUI3.transform.Find("Image").GetComponent<Image>(),
                itemUI3.transform.Find("Icon").GetComponent<Image>(),
                itemUI3.transform.Find("BianKuang").GetComponent<Image>(),
                null, null,
                itemUI3.transform.Find("xing").gameObject,
                itemUI3.transform.Find("xing/Text").GetComponent<Text>(),
                null, null, null
            );
            leftEquipImageList.Add(itemUI3);
            allEquipList.Add(itemUI3);
        }
        
        {
            rightEqiupImageList = new List<CommonItemUI>();
            
            CommonItemUI itemUI = transform.Find("leftPanel/rightEquipBgList 1/CommonItemUIWithXing").gameObject.AddComponent<CommonItemUI>();
            itemUI.Init
            (
                itemUI.transform.Find("Image").GetComponent<Image>(),
                itemUI.transform.Find("Icon").GetComponent<Image>(),
                itemUI.transform.Find("BianKuang").GetComponent<Image>(),
                null, null,
                itemUI.transform.Find("xing").gameObject,
                itemUI.transform.Find("xing/Text").GetComponent<Text>(),
                null, null, null
            );
            rightEqiupImageList.Add(itemUI);
            allEquipList.Add(itemUI);
            
            CommonItemUI itemUI1 = transform.Find("leftPanel/rightEquipBgList 1/CommonItemUIWithXing 1").gameObject.AddComponent<CommonItemUI>();
            itemUI1.Init
            (
                itemUI1.transform.Find("Image").GetComponent<Image>(),
                itemUI1.transform.Find("Icon").GetComponent<Image>(),
                itemUI1.transform.Find("BianKuang").GetComponent<Image>(),
                null, null,
                itemUI1.transform.Find("xing").gameObject,
                itemUI1.transform.Find("xing/Text").GetComponent<Text>(),
                null, null, null
            );
            rightEqiupImageList.Add(itemUI1);
            allEquipList.Add(itemUI1);
            
            CommonItemUI itemUI2 = transform.Find("leftPanel/rightEquipBgList 1/CommonItemUIWithXing 2").gameObject.AddComponent<CommonItemUI>();
            itemUI2.Init
            (
                itemUI2.transform.Find("Image").GetComponent<Image>(),
                itemUI2.transform.Find("Icon").GetComponent<Image>(),
                itemUI2.transform.Find("BianKuang").GetComponent<Image>(),
                null, null,
                itemUI2.transform.Find("xing").gameObject,
                itemUI2.transform.Find("xing/Text").GetComponent<Text>(),
                null, null, null
            );
            rightEqiupImageList.Add(itemUI2);
            allEquipList.Add(itemUI2);
            
            CommonItemUI itemUI3 = transform.Find("leftPanel/rightEquipBgList 1/CommonItemUIWithXing 3").gameObject.AddComponent<CommonItemUI>();
            itemUI3.Init
            (
                itemUI3.transform.Find("Image").GetComponent<Image>(),
                itemUI3.transform.Find("Icon").GetComponent<Image>(),
                itemUI3.transform.Find("BianKuang").GetComponent<Image>(),
                null, null,
                itemUI3.transform.Find("xing").gameObject,
                itemUI3.transform.Find("xing/Text").GetComponent<Text>(),
                null, null, null
            );
            rightEqiupImageList.Add(itemUI3);
            allEquipList.Add(itemUI3);
        }
        
        {
            topEqiupImageList = new List<CommonItemUI>();
            
            CommonItemUI itemUI = transform.Find("leftPanel/topEquipBgList/CommonItemUIWithXing 4").gameObject.AddComponent<CommonItemUI>();
            itemUI.Init
            (
                itemUI.transform.Find("Image").GetComponent<Image>(),
                itemUI.transform.Find("Icon").GetComponent<Image>(),
                itemUI.transform.Find("BianKuang").GetComponent<Image>(),
                null, null,
                itemUI.transform.Find("xing").gameObject,
                itemUI.transform.Find("xing/Text").GetComponent<Text>(),
                null, null, null
            );
            topEqiupImageList.Add(itemUI);
            allEquipList.Add(itemUI);
            
            CommonItemUI itemUI1 = transform.Find("leftPanel/topEquipBgList/CommonItemUIWithXing 5").gameObject.AddComponent<CommonItemUI>();
            itemUI1.Init
            (
                itemUI1.transform.Find("Image").GetComponent<Image>(),
                itemUI1.transform.Find("Icon").GetComponent<Image>(),
                itemUI1.transform.Find("BianKuang").GetComponent<Image>(),
                null, null,
                itemUI1.transform.Find("xing").gameObject,
                itemUI1.transform.Find("xing/Text").GetComponent<Text>(),
                null, null, null
            );
            topEqiupImageList.Add(itemUI1);
            allEquipList.Add(itemUI1);
            
            CommonItemUI itemUI2 = transform.Find("leftPanel/topEquipBgList/CommonItemUIWithXing 6").gameObject.AddComponent<CommonItemUI>();
            itemUI2.Init
            (
                itemUI2.transform.Find("Image").GetComponent<Image>(),
                itemUI2.transform.Find("Icon").GetComponent<Image>(),
                itemUI2.transform.Find("BianKuang").GetComponent<Image>(),
                null, null,
                itemUI2.transform.Find("xing").gameObject,
                itemUI2.transform.Find("xing/Text").GetComponent<Text>(),
                null, null, null
            );
            topEqiupImageList.Add(itemUI2);
            allEquipList.Add(itemUI2);
        }
        
        {
            downEqiupImageList = new List<CommonItemUI>();
            
            CommonItemUI itemUI = transform.Find("leftPanel/downEquipBgList/CommonItemUIWithXing 7").gameObject.AddComponent<CommonItemUI>();
            itemUI.Init
            (
                itemUI.transform.Find("Image").GetComponent<Image>(),
                itemUI.transform.Find("Icon").GetComponent<Image>(),
                itemUI.transform.Find("BianKuang").GetComponent<Image>(),
                null, null,
                itemUI.transform.Find("xing").gameObject,
                itemUI.transform.Find("xing/Text").GetComponent<Text>(),
                null, null, null
            );
            downEqiupImageList.Add(itemUI);
            allEquipList.Add(itemUI);
            
            CommonItemUI itemUI1 = transform.Find("leftPanel/downEquipBgList/CommonItemUIWithXing 8").gameObject.AddComponent<CommonItemUI>();
            itemUI1.Init
            (
                itemUI1.transform.Find("Image").GetComponent<Image>(),
                itemUI1.transform.Find("Icon").GetComponent<Image>(),
                itemUI1.transform.Find("BianKuang").GetComponent<Image>(),
                null, null,
                itemUI1.transform.Find("xing").gameObject,
                itemUI1.transform.Find("xing/Text").GetComponent<Text>(),
                null, null, null
            );
            downEqiupImageList.Add(itemUI1);
            allEquipList.Add(itemUI1);
        }
        
        int len = allEquipList.Count;
        for (int i = 0; i < len; i++)
        {
            itemTabButtonGroup.AddToggle(allEquipList[i].transform.Find("Toggle").GetComponent<GameUUToggle>());
        }
        
    }

}
