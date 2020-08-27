using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BetaFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PetItemView : MonoBehaviour
{
    private Pets_Data petsData;
    public Transform petParent;
    public TextMeshProUGUI petName;
    public Image[] Images;
    public Image equippedImage;
    public GameObject lockObj;
    bool isLock;
    public void setPetData(Pets_Data petsData , bool islock = false)
    {
        this.petsData = petsData;
        petName.text = petsData.name;
        isLock = islock;
        lockObj.SetActive(islock);
        showIcon();
        currentUsePetStatus();
    }


    public void showIcon()
    {
        if (Const.defaultPet.Equals(this.petsData.ID))
        {
            Images[0].gameObject.SetActive(true);
        }
        else
        {
            Images[1].gameObject.SetActive(true);
        }
    }

    public void currentUsePetStatus()
    {
        equippedImage.gameObject.SetActive(false);
        if (AppEngine.SyncManager.Data.Pets.Value.currentPetId.Equals(this.petsData.ID))
        {
            equippedImage.gameObject.SetActive(true);
        }
    }

    public void openPetDialog()
    {
        UIManager.OpenUIAsync(ViewConst.prefab_ShowPetDialog,null, petsData);
    }
}
