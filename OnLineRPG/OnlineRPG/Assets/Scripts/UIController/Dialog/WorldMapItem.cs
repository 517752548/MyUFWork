using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class WorldMapItem : MonoBehaviour
{
    private int[] levelRegion;
    private Image worldImage;
    public GameObject LockedGameObject;
    public GameObject UnlockedGameObject;

    public TextMeshProUGUI worldNameLock;
    public TextMeshProUGUI worldIndexLock;
    public TextMeshProUGUI LevelIndexLock;
    
    public TextMeshProUGUI worldNameUnLock;
    public TextMeshProUGUI worldIndexUnLock;
    public TextMeshProUGUI LevelIndexUnLock;

    public Image LockImage;
    public Image UnlockImage;
    public Image bottom;
    public bool SetData(ClassicWorldEntity currentWorld,bool showBottom)
    {
        bool locked = true;

        levelRegion = currentWorld.GetLevelRegion();
        bottom.enabled = showBottom;
        if (levelRegion[0] <= AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value)
        {
            //已经解锁
            locked = false;
            UnlockedGameObject.SetActive(true);
            worldImage = UnlockImage;
            
        }
        else
        {
            LockedGameObject.SetActive(true);
            worldImage = LockImage;
        }

        if (!locked)
        {
            worldNameLock.text = currentWorld.Name;
            worldIndexLock.text = string.Format("Episode {0}", currentWorld.ID);
            LevelIndexLock.text = string.Format("Levels {0}-{1}", levelRegion[0], levelRegion[1]);
        }
        else
        {
            worldNameUnLock.text = currentWorld.Name;
            worldIndexUnLock.text = string.Format("Episode {0}", currentWorld.ID);
            LevelIndexUnLock.text = string.Format("Levels {0}-{1}", levelRegion[0], levelRegion[1]);
        }
        
        LoadImage(currentWorld.HomeSmall,locked);
        return locked;
    }

    private async void LoadImage(string imageName,bool locked)
    {
        CommUtil.LoadCachedImage(string.Format(imageName,locked?"_locked":"_unlock"), image =>
        {
            if(image != null && !worldImage.IsDestroyed())
            worldImage.sprite = image;
        });
        // AsyncOperationHandle<Sprite> image = Addressables.LoadAssetAsync<Sprite>();
        // await image.Task;
        // worldImage.sprite = image.Result;
    }
    
}
