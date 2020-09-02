﻿
using System.Collections.Generic;

public class PetData : BaseSyncHandData
{
    /// <summary>
    /// 当前小人的id
    /// </summary>
    public string currentPetId = Const.defaultPet;
    public Dictionary<string, int> petItems = new Dictionary<string, int>();
    public bool hasNewPet = false;
    public static bool isBrowsing = false;

    public PetData()
    {
        if (!petItems.ContainsKey(Const.defaultPet))
        {
            petItems.Add(Const.defaultPet, 1);
        }
    }
    
    //增加一个小人
    public void AddPet(string petId)
    {
        hasNewPet = true;
        bool isFindId = false;
        foreach (var item in petItems)
        {
            string id = item.Key;
            if (id != null && id.Equals(petId))
            {
                isFindId = true;
            }
        }

        if (!isFindId)
        {
            petItems.Add(petId,1);
        }
        
        OnDataChange();
    }
    
    public override BaseSyncHandData Clone()
    {
        PetData obj = new PetData();
        obj.currentPetId = currentPetId;
        obj.hasNewPet = hasNewPet;
        obj.petItems.Clear();
        foreach (string petItemsKey in petItems.Keys)
        {
            obj.petItems.Add(petItemsKey, petItems[petItemsKey]);
        }
        return obj;
    }

    public override bool IsEqual(BaseSyncHandData other)
    {
        return (other as PetData).petItems.Count == petItems.Count;
    }
}