using BetaFramework;
using EventUtil;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class DecorationDialog : BaseHomeUI
{
    public ToggleButton titleToggle;
    public ToggleButton petToggle;
    public RectTransform petContent;
    public RectTransform titleContent;
    private Dictionary<string, int> petDictionary;
    private Dictionary<int, TitleReceiveData> titleDictionary;
    private List<PetItemView> _petItemViews = new List<PetItemView>();
    private List<TitlesViewItem> titleItemView = new List<TitlesViewItem>();
    private List<Pets_Data> _dataList = new List<Pets_Data>();
    private float waitTime = 0.0f;

    private List<TitleReceiveData> title_data_list;

    public void Awake()
    {
        
    }
    private void Start()
    {
        completerContentCellSize();
        //CompleterContentCellSize();
        
        titleToggle.IsOn = false;
    }


    public override void OnEnter()
    {
        base.OnEnter();
        
    }
    public override void OnLeave()
    {
        base.OnLeave();

    }
    public override void OnShow()
    {
        base.OnShow();
        OnOpen();
        TitleData.GetWebTitle();
        ShowTitlePanel();
        ShowPetPanel();
    }
    public override void OnHidden()
    {
        base.OnHidden();
        EventDispatcher.RemoveEventListener(GlobalEvents.RefreshPetsDialog, refreshDialog);
        EventDispatcher.RemoveEventListener(GlobalEvents.RefreshTitleDialog, RefreshTitleDialog);
    }

    public void OnOpen()
    {
        EventDispatcher.AddEventListener(GlobalEvents.RefreshPetsDialog, refreshDialog);
        EventDispatcher.AddEventListener(GlobalEvents.RefreshTitleDialog, RefreshTitleDialog);
        GameAnalyze.LogCrazeFriendsUI();
    }
    //适配layout
    private void completerContentCellSize()
    {
        float contentWidth = petContent.rect.size.x;
        float currentCellSize = petContent.GetComponent<GridLayoutGroup>().cellSize.x;
        float spacingX = petContent.GetComponent<GridLayoutGroup>().spacing.x;
        float part = 2;
        while (((contentWidth - ((part - 1) * spacingX)) / part) >= currentCellSize)
        {
            part++;
        }

        float changeCellSize = (contentWidth - ((part - 2) * spacingX)) / (part - 1);
        petContent.GetComponent<GridLayoutGroup>().cellSize = new Vector2(changeCellSize, 404);
    }
    private void CompleterContentCellSize()
    {
        float contentWidth = titleContent.rect.size.x;
        float currentCellSize = titleContent.GetComponent<GridLayoutGroup>().cellSize.x;
        float spacingX = titleContent.GetComponent<GridLayoutGroup>().spacing.x;
        float part = 2;
        while (((contentWidth - ((part - 1) * spacingX)) / part) >= currentCellSize)
        {
            part++;
        }

        float changeCellSize = (contentWidth - ((part - 2) * spacingX)) / (part - 1);
        titleContent.GetComponent<GridLayoutGroup>().cellSize = new Vector2(changeCellSize, 404);
    }


    private void ShowTitlePanel()
    {
        title_data_list = TitleData.configList;
        titleDictionary = TitleData.titleDic;
        Addressables.LoadAssetAsync<GameObject>(ViewConst.prefab_TitlesViewItem).Completed += op =>
        {
            try
            {
                if (title_data_list != null)
                {
                    //按稀有度排序
                    for (int i = 0; i < title_data_list.Count; i++)
                    {
                        for (int j = i + 1; j < title_data_list.Count; j++)
                        {
                            if (title_data_list[i].scarcity < title_data_list[j].scarcity)
                            {
                                var t = title_data_list[i];
                                title_data_list[i] = title_data_list[j];
                                title_data_list[j] = t;
                            }
                        }
                    }
                    //按限时排序
                    for (int i = 0; i < title_data_list.Count; i++)
                    {
                        for (int j = i + 1; j < title_data_list.Count; j++)
                        {
                            if (title_data_list[i].scarcity == title_data_list[i].scarcity)
                            {
                                if (title_data_list[i].limit > title_data_list[j].limit)
                                {
                                    var t = title_data_list[i];
                                    title_data_list[i] = title_data_list[j];
                                    title_data_list[j] = t;
                                }
                            }
                            
                        }
                    }

                    List<TitleReceiveData> no_have_list = new List<TitleReceiveData>();
                    int index = 0;
                    foreach (var titleItem in title_data_list)
                    {
                        if (titleDictionary.Count > 0)
                        {
                            foreach (var dicData in titleDictionary)
                            {
                                int key = dicData.Key;
                                int id = titleItem.id;
                                if (key != 0 && key.Equals(id))
                                {
                                    LoadTitle(titleItem, op, index, false);
                                    index++;
                                }
                                else
                                    no_have_list.Add(titleItem);
                            }
                        }
                        else {
                            
                            LoadTitle(titleItem, op, index, true);
                            index++;
                        }

                    }

                    foreach (var item in no_have_list)
                    {
                        LoadTitle(item, op, index, true);
                        index++;
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Debug.Log(e.Message.ToString());
            }
        };
    }

    //展示宠物面板
    private void ShowPetPanel()
    {
        petDictionary = AppEngine.SyncManager.Data.Pets.Value.petItems;
        Addressables.LoadAssetAsync<GameObject>(ViewConst.prefab_PetsItem).Completed += op =>
        {
            try
            {
                Pets pets = PreLoadManager.GetPreLoadConfig<Pets>(ViewConst.asset_Pets_Pet);
                _dataList = pets.dataList;
                int index = 0;
                List<Pets_Data> list = new List<Pets_Data>();

                foreach (var petData in _dataList)
                {
                    foreach (var dicData in petDictionary)
                    {
                        string key = dicData.Key;
                        string id = petData.ID;
                        if (key != null && key.Equals(id))
                        {
                            AddItemView(petData, op, index,false);
                            index++;                           
                        }
                        else
                        list.Add(petData);
                    }
                            
                }
                
                foreach (var item in list)
                {
                    AddItemView(item, op, index,true);
                    index++;
                }
            }
            catch (NullReferenceException e)
            {
                Debug.Log(e.Message.ToString());
            }
        };
    }
    private void AddItemView(Pets_Data datas, AsyncOperationHandle<GameObject> op,int index,bool isLock)
    {
        var item = Instantiate(op.Result);
        item.transform.SetParent(petContent, false);
        item.transform.SetSiblingIndex(index);
        var petItemView = item.GetComponent<PetItemView>();
        petItemView.setPetData(datas , isLock);
        _petItemViews.Add(petItemView);
        StartCoroutine(wait(datas.prefab, petItemView));
    }
    private void LoadTitle(TitleReceiveData datas, AsyncOperationHandle<GameObject> op, int index, bool isLock)
    {
        var item = Instantiate(op.Result);
        item.transform.SetParent(titleContent, false);
        item.transform.SetSiblingIndex(index);
        var titleItem = item.GetComponent<TitlesViewItem>();
        titleItem.SetData(datas, isLock);
        titleItemView.Add(titleItem);
       
    }
    IEnumerator wait(string name, PetItemView view)
    {
        yield return new WaitForSeconds(waitTime);
        loadPet(name, view);
    }
    private void loadPet(string prefabName, PetItemView petItemView)
    {
        Addressables.LoadAssetAsync<GameObject>(string.Format("{0}.prefab", prefabName)).Completed += op =>
        {
            var item = Instantiate(op.Result);
            item.transform.SetParent(petItemView.petParent, false);
            item.transform.GetComponent<SkeletonGraphic>().raycastTarget = false;
        };
    }


    public void refreshDialog()
    {
        foreach (var itemView in _petItemViews)
        {
            itemView.currentUsePetStatus();
        }
    }

    public void RefreshTitleDialog()
    {
        foreach (var item in titleItemView)
        {
            item.currentUseTitleStatus();
        }
    }


    //↓↓↓↓↓↓↓↓点击事件 ↓↓↓↓↓↓↓↓

    public void ClickTitleToggle(bool isOn)
    {        
        titleToggle.IsOn = isOn;
    }
    public void ClickPetToggle(bool isOn)
    {       
        petToggle.IsOn = isOn;
    }

    public void ClickOpenHelpWindow()
    {
        UIManager.OpenUIAsync(ViewConst.prefab_BookBuddiesDialog);
    }

}
