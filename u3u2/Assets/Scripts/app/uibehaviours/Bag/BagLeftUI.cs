
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BagLeftUI : MonoBehaviour
{

    public List<CommonItemUI> leftEquipImageList;

    public List<CommonItemUI> rightEqiupImageList;

    public List<CommonItemUI> topEqiupImageList;

    public List<CommonItemUI> downEqiupImageList;

    public Text roleLevel;

    public Text roleName;

    public ToggleGroup toggleGroup;
    public TabButtonGroup itemTabButtonGroup;
    public GameObject modelContainer;

    public void Init(bool isbagui)
    {
        toggleGroup = transform.GetComponent<ToggleGroup>();
        itemTabButtonGroup = transform.gameObject.AddComponent<TabButtonGroup>();
        roleName = transform.Find("RoleName").GetComponent<Text>();
        roleLevel = transform.Find("RoleLevel").GetComponent<Text>();
        modelContainer = transform.Find("container").gameObject;
        
        {
            leftEquipImageList = new List<CommonItemUI>();
            
            CommonItemUI itemUI = transform.Find("L_CommonItemUI").gameObject.AddComponent<CommonItemUI>();
            itemUI.Init();
            leftEquipImageList.Add(itemUI);
            
            CommonItemUI itemUI1 = transform.Find("L_CommonItemUI 1").gameObject.AddComponent<CommonItemUI>();
            itemUI1.Init();
            leftEquipImageList.Add(itemUI1);
            
            CommonItemUI itemUI2 = transform.Find("L_CommonItemUI 2").gameObject.AddComponent<CommonItemUI>();
            itemUI2.Init();
            leftEquipImageList.Add(itemUI2);
            
            CommonItemUI itemUI3 = transform.Find("L_CommonItemUI 3").gameObject.AddComponent<CommonItemUI>();
            itemUI3.Init();
            leftEquipImageList.Add(itemUI3);
            if (isbagui)
            {
                itemUI3.SelectedToggle.gameObject.SetActive(false);
                itemUI2.SelectedToggle.gameObject.SetActive(false);
                itemUI1.SelectedToggle.gameObject.SetActive(false);
                itemUI.SelectedToggle.gameObject.SetActive(false);
            }
            else
            {
                itemUI3.SelectedToggle.group = toggleGroup;
                itemUI2.SelectedToggle.group = toggleGroup;
                itemUI1.SelectedToggle.group = toggleGroup;
                itemUI.SelectedToggle.group = toggleGroup;
            }
            //itemTabButtonGroup.AddToggle(itemUI.SelectedToggle);
            //itemTabButtonGroup.AddToggle(itemUI1.SelectedToggle);
            //itemTabButtonGroup.AddToggle(itemUI2.SelectedToggle);
            //itemTabButtonGroup.AddToggle(itemUI3.SelectedToggle);
        }
        
        {
            rightEqiupImageList = new List<CommonItemUI>();
            
            CommonItemUI itemUI = transform.Find("R_CommonItemUI").gameObject.AddComponent<CommonItemUI>();
            itemUI.Init();
            rightEqiupImageList.Add(itemUI);
            
            CommonItemUI itemUI1 = transform.Find("R_CommonItemUI 1").gameObject.AddComponent<CommonItemUI>();
            itemUI1.Init();
            rightEqiupImageList.Add(itemUI1);
            
            CommonItemUI itemUI2 = transform.Find("R_CommonItemUI 2").gameObject.AddComponent<CommonItemUI>();
            itemUI2.Init();
            rightEqiupImageList.Add(itemUI2);
            
            CommonItemUI itemUI3 = transform.Find("R_CommonItemUI 3").gameObject.AddComponent<CommonItemUI>();
            itemUI3.Init();
            rightEqiupImageList.Add(itemUI3);
            if (isbagui)
            {
                itemUI3.SelectedToggle.gameObject.SetActive(false);
                itemUI2.SelectedToggle.gameObject.SetActive(false);
                itemUI1.SelectedToggle.gameObject.SetActive(false);
                itemUI.SelectedToggle.gameObject.SetActive(false);
            }
            else
            {
                itemUI3.SelectedToggle.group = toggleGroup;
                itemUI2.SelectedToggle.group = toggleGroup;
                itemUI1.SelectedToggle.group = toggleGroup;
                itemUI.SelectedToggle.group = toggleGroup;
            }
            //itemTabButtonGroup.AddToggle(itemUI.SelectedToggle);
            //itemTabButtonGroup.AddToggle(itemUI1.SelectedToggle);
            //itemTabButtonGroup.AddToggle(itemUI2.SelectedToggle);
            //itemTabButtonGroup.AddToggle(itemUI3.SelectedToggle);
        }
        
        {
            topEqiupImageList = new List<CommonItemUI>();
            
            CommonItemUI itemUI = transform.Find("T_CommonItemUI").gameObject.AddComponent<CommonItemUI>();
            itemUI.Init();
            topEqiupImageList.Add(itemUI);
            
            CommonItemUI itemUI1 = transform.Find("T_CommonItemUI 1").gameObject.AddComponent<CommonItemUI>();
            itemUI1.Init();
            topEqiupImageList.Add(itemUI1);
            
            CommonItemUI itemUI2 = transform.Find("T_CommonItemUI 2").gameObject.AddComponent<CommonItemUI>();
            itemUI2.Init();
            topEqiupImageList.Add(itemUI2);
            if (isbagui)
            {
                itemUI.SelectedToggle.gameObject.SetActive(false);
                itemUI1.SelectedToggle.gameObject.SetActive(false);
                itemUI2.SelectedToggle.gameObject.SetActive(false);
            }
            else
            {
                itemUI.SelectedToggle.group = toggleGroup;
                itemUI1.SelectedToggle.group = toggleGroup;
                itemUI2.SelectedToggle.group = toggleGroup;
            }
            //itemTabButtonGroup.AddToggle(itemUI.SelectedToggle);
            //itemTabButtonGroup.AddToggle(itemUI1.SelectedToggle);
            //itemTabButtonGroup.AddToggle(itemUI2.SelectedToggle);
        }
        
        {
            downEqiupImageList = new List<CommonItemUI>();
            
            CommonItemUI itemUI = transform.Find("D_CommonItemUI").gameObject.AddComponent<CommonItemUI>();
            itemUI.Init();
            downEqiupImageList.Add(itemUI);
            
            CommonItemUI itemUI1 = transform.Find("D_CommonItemUI 1").gameObject.AddComponent<CommonItemUI>();
            itemUI1.Init();
            downEqiupImageList.Add(itemUI1);
            if (isbagui)
            {
                itemUI.SelectedToggle.gameObject.SetActive(false);
                itemUI1.SelectedToggle.gameObject.SetActive(false);
            }
            else
            {
                itemUI.gameObject.SetActive(false);
                itemUI1.gameObject.SetActive(false);
            }
            //itemTabButtonGroup.AddToggle(itemUI.SelectedToggle);
            //itemTabButtonGroup.AddToggle(itemUI1.SelectedToggle);
        }
    }
}