using System;
using System.Collections.Generic;
using Bag;
using UnityEngine;
using BetaFramework;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections;
using EventUtil;
using Spine.Unity;
using UnityEngine.UI;

public class PetsDialog : UIWindowBase
{

    private RectTransform root;
    private RectTransform petContent;
    private Dictionary<string, int>  petDictionary;
    private List<PetItemView> _petItemViews = new List<PetItemView>();
    private List<Pets_Data> _dataList = new List<Pets_Data>();
    private float waitTime = 0.0f;

    public void Awake()
	{
        root = transform.Find("Content").GetComponent<RectTransform>();
        petContent = root.transform.Find("Slider/ScrollView/Content").GetComponent<RectTransform>();
	}

    public override void OnOpen()
    {
        base.OnOpen();
        EventDispatcher.AddEventListener(GlobalEvents.RefreshPetsDialog,refreshDialog);
        completerContentCellSize();
        ShowPanel();
        GameAnalyze.LogCrazeFriendsUI();
    }

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
        petContent.GetComponent<GridLayoutGroup>().cellSize = new Vector2(changeCellSize,404);
    }

    public void refreshDialog()
    {
        foreach (var itemView in _petItemViews)
        {
            itemView.currentUsePetStatus();
        }
    }

    private void ShowPanel()
    {
        petDictionary = AppEngine.SyncManager.Data.Pets.Value.petItems;
        Addressables.LoadAssetAsync<GameObject>(ViewConst.prefab_PetsItem).Completed += op =>
        {
            try
            {
                Pets pets = PreLoadManager.GetPreLoadConfig<Pets>(ViewConst.asset_Pets_Pet);
                _dataList = pets.dataList;
                /*foreach (var petData in _dataList)
                {
                    addItemView(petData,op);
                }*/
                    
                foreach (var dicData in petDictionary)
                {
                    string key = dicData.Key;
                    foreach (var petData in _dataList)
                    {
                        string id = petData.ID;
                        if (key != null && key.Equals(id))
                        {
                            addItemView(petData,op);
                            break;
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Debug.Log(e.Message.ToString());
            }
        };
    }

    private void addItemView(Pets_Data datas, AsyncOperationHandle<GameObject> op)
    {
        var item = Instantiate(op.Result);
        item.transform.SetParent(petContent, false);
        var petItemView =  item.GetComponent<PetItemView>();
        petItemView.setPetData(datas);
        _petItemViews.Add(petItemView);
        StartCoroutine(wait(datas.prefab,petItemView));
    }

    IEnumerator wait(string name, PetItemView view)
    {
        yield return  new WaitForSeconds(waitTime);
        loadPet(name, view);
    }


    private void loadPet(string prefabName,PetItemView petItemView)
    {
        Addressables.LoadAssetAsync<GameObject>(string.Format("{0}.prefab",prefabName)).Completed += op =>
        {
            var item = Instantiate(op.Result);
            item.transform.SetParent(petItemView.petParent,false);
            item.transform.GetComponent<SkeletonGraphic>().raycastTarget = false;
        };
    }

    public void ClickOpenHelpWindow()
    {
        UIManager.OpenUIAsync(ViewConst.prefab_BookBuddiesDialog);
    }

    public void ClickCloseWindow()
    {
     //   KnowCardIdManager.getInstance().destory();
        UIManager.CloseUIWindow(this);
    }
}
