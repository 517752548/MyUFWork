using System;
using System.Collections.Generic;
using BetaFramework;
using EventUtil;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class ShowPetDialog : UIWindowBase
{
    private Transform root;
    private RectTransform childContent;
    private PageView pageView;
    private ShowPetNavigation showPetNavigation;
    private List<PetShowItem> list = new List<PetShowItem>();
    private PetData _petItem;
    private string selectPetId = "";

    public Transform petParent;
    public Text desText;

    public void Awake()
    {
        root = transform.Find("Content").GetComponent<RectTransform>();
        childContent = root.transform.Find("Scroll_View/Viewport/Content").GetComponent<RectTransform>();
        pageView = root.transform.Find("Scroll_View").GetComponent<PageView>();
        showPetNavigation = root.transform.Find("Navigation").GetComponent<ShowPetNavigation>();
    }
    public override void OnOpen()
    {
        base.OnOpen();
        Pets_Data petsData = objs[0] as Pets_Data;
        if (petsData != null)
        {
            selectPetId = petsData.ID;
        }
        
        _petItem = AppEngine.SyncManager.Data.Pets.Value;
        initItemView();
    }

    private void initItemView()
    {
        Addressables.LoadAssetAsync<GameObject>(ViewConst.prefab_PetShowItem).Completed += op =>
        {
            Pets pets = PreLoadManager.GetPreLoadConfig<Pets>(ViewConst.asset_Pets_Pet);
            List<Pets_Data> petsDatas = pets.dataList;
            Dictionary<string, int>  dictionary = _petItem.petItems;
            foreach (var data in petsDatas)
            {                
                var item = Instantiate(op.Result);
                PetShowItem petShowItem = item.GetComponent<PetShowItem>();
                petShowItem.bindListener(this);
                petShowItem.setPetId(data.ID);
                //petShowItem.loadThemeLogo();
                //petShowItem.loadBg();
                foreach (var owend in dictionary.Keys)
                {
                    if (data.ID.Equals(owend))
                    {
                        petShowItem.setItemData(data , false);
                    }
                    else
                    {
                        petShowItem.setItemData(data, true);
                    }
                }
                petShowItem.loadUnlockPetView();
                petShowItem.setButtonStatus();
                item.transform.SetParent(childContent, false);
                list.Add(petShowItem);
            }
            pageView.ContentChildCountChanged();
            showPetNavigation.bindNavigation();
            loadSelectPetPanel();
        };
    }

    public void callBackPetStatus()
    {
        if (list != null)
        {
            for (int i = 0; i < list.Count; i++)
            {
                PetShowItem petShowItem = list[i];
                petShowItem.setButtonStatus();
            }
        }
    }

    private void loadSelectPetPanel()
    {
        for (int i = 0; i < list.Count; i++)
        {
            var view = list[i];
            if (this.selectPetId.Equals(view.getPetId()))
            {
                showPetNavigation.pageTo(i);
            }
        }
    }
    
    public void closeWindow()
    {
        if (windowStatus == WindowStatus.Opened)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].PanelClose();
            }
        }

        EventDispatcher.TriggerEvent(GlobalEvents.RefreshPetsDialog);
        UIManager.CloseUIWindow(this);
    }
}
