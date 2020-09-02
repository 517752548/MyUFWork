using System.Collections;
using BetaFramework;
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class PetShowItem : MonoBehaviour
{
   private string petId;
   private string petName;
   private string prefabName;
   private string petDes;
//   private string petThemme;
//   private string petBg;
   private ShowPetDialog _showPetDialog;

   public Text petNameView, petDesView;
   public TextMeshProUGUI petSiereView;
   public Transform petParent;
   public Image ImageSelect;
   public GameObject lockObj;
    bool islock;
   public SkeletonGraphic petSkeletonGraphic;
   private PetStatesManager _petStatesManager;
   private GameObject pet;
   public void bindListener(ShowPetDialog showPetDialog)
   {
      _showPetDialog = showPetDialog;
   }

   public void setPetId(string id)
   {
      this.petId = id != null ? id : "";
   }

   public string getPetId()
   {
      return this.petId;
   }

   public void setItemData(Pets_Data petsData , bool islock = false)
   {
        this.islock = islock;
        lockObj?.SetActive(islock);
        if (petsData != null)
        {
            this.petNameView.text = petsData.name != null ? petsData.name : "";
            this.petDesView.text = petsData.des != null ? petsData.des : "";
            this.prefabName = petsData.prefab != null ? petsData.prefab : "";
            this.petSiereView.text = petsData.SiereName != null ? petsData.SiereName : "";
    //         this.petThemme = petsData.theme != null ? petsData.theme : "";
    //         this.petBg = petsData.bgSprite != null ? petsData.bgSprite : "";
        }
   }

   public void setButtonStatus()
   {
      if (AppEngine.SyncManager.Data.Pets.Value.currentPetId.Equals(this.petId))
      {
         ImageSelect.gameObject.SetActive(true);
      }
      else
      {
         ImageSelect.gameObject.SetActive(false);
      }
      lockObj?.SetActive(islock);
    }

   public void loadUnlockPetView()
   {
      loadUnlockPet();
   }

//   public void loadLockPetView()
//   {
//      StartCoroutine(waiteLockPet());
//   }

//   public async void loadThemeLogo()
//   {
//      Sprite sprite = await Addressables.LoadAssetAsync<Sprite>(this.petThemme);
//      themeImage.sprite = sprite;
//   }
//
//   public async void loadBg()
//   {
//      Sprite sprite = await Addressables.LoadAssetAsync<Sprite>(this.petBg);
//      bgImage.sprite = sprite;
//   }

   private void loadUnlockPet()
   {
      Addressables.LoadAssetAsync<GameObject>(string.Format("{0}.prefab",this.prefabName)).Completed += op =>
      {
         var item = Instantiate(op.Result);
         item.transform.SetParent(petParent,false);
         petSkeletonGraphic = item.GetComponent<SkeletonGraphic>();
         _petStatesManager = new PetStatesManager(petSkeletonGraphic);
         _petStatesManager.TransTo(PetBase.PetStates.Idle);
         pet = item;
      };
   }

//   private void loadLockPet()
//   {
//      Addressables.LoadAssetAsync<GameObject>(string.Format("{0}.prefab", this.prefabName)).Completed += op =>
//      {
//         var item = Instantiate(op.Result);
//         item.transform.SetParent(petParent, false);
//         item.transform.GetComponent<SkeletonGraphic>().color = new Color(200, 200, 200);
//         this.petDesView.text = "? ? ?";
//         button.gameObject.SetActive(false);
//      };
//   }

   public bool isMattchId(string id)
   {
      if (this.petId.Equals(id))
      {
         return true;
      }
      return false;
   }
//   IEnumerator waiteLockPet()
//   {
//      yield return  new WaitForSeconds(0.2f);
//      loadLockPet();
//   }
   
   public void ClickPet()
   {
      _petStatesManager.TransTo(PetBase.PetStates.click);
      AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_petclick);
   }

   public void close()
   {
      _showPetDialog.closeWindow();
   }

   public void PanelClose()
   {
      if (pet != null)
      {
         pet.SetActive(false);
      }
   }
   public void selectPet()
   {
      AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_EquipPet);
      AppEngine.SyncManager.Data.Pets.UpdateValue(petData =>
      {
         GameAnalyze.LogChangeFriend(petData.currentPetId,this.petId);
         petData.currentPetId = this.petId;
         _petStatesManager.TransTo(PetBase.PetStates.hint);
         _showPetDialog.callBackPetStatus();
         return petData;
      });
   }
}
