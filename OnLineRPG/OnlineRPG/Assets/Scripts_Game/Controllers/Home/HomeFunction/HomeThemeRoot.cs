using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using EventUtil;
using UnityEngine;
using UnityEngine.UI;

public class HomeThemeRoot : BaseThemeRoot
{
    [SerializeField] private GraphicRaycaster _HomeGraphicRaycaster;
    [SerializeField] private GameObject _home;
    public HomeFsmManager HomeFsmManager => fsmManager as HomeFsmManager;
    public ClassicWorldEntity CurrentWorld { get; private set; }

    public BGController _bgcontroller;
    public HomeAnimatorController _HomeAnimatorController;

    public GameObject SkinPoint;
    public GameObject EmailPoint;

    private int LevelProgressCallbackID;

    public override void Init(HomeRoot root)
    {
        InitData();
        base.Init(root);
    }

    private void Start()
    {
        EventDispatcher.AddEventListener(GlobalEvents.PetAdd, PetAdd);
        AppEngine.SSystemManager.GetSystem<EmailSystem>().SetEmailRedPoint(EmailPoint);

    }

    private void InitData()
    {
        CurrentWorld = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().GetCurClassicWorld();
        if (fsmManager == null)
        {
            fsmManager = gameObject.GetComponent<HomeFsmManager>();
            if (fsmManager == null)
            {
                fsmManager = gameObject.AddComponent<HomeFsmManager>();
                HomeFsmManager.Init(this);
            }
        }
        _bgcontroller.ChangeBGFirst(CurrentWorld.HomeImage);
    }

    private void PlayBackgroundMusic()
    {
        if (CurrentWorld != null)
        {
            AppEngine.SSoundManager.PlayBGM(CurrentWorld.HomeMusic);
        }
    }

    public void SetGraphicRaycasterEnable(bool enable)
    {
        _HomeGraphicRaycaster.enabled = enable;
    }

    public override bool IsIdle()
    {
        return HomeFsmManager.IsIdle();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        PlayBackgroundMusic();
    }

    public override void OnLeave()
    {
        base.OnLeave();
    }

    public override void OnShow()
    {
        CheckSkinPoint();
        base.OnShow();
    }

    public override void OnHidden()
    {
        base.OnHidden();
    }

    private void CheckSkinPoint()
    {
        // SkinPoint.gameObject.SetActive(AppEngine.SyncManager.Data.Pets.Value.hasNewPet);
    }

    public void ClickPetButton()
    {
        UIManager.OpenUIAsync(ViewConst.prefab_PetsDialog);
        AppEngine.SyncManager.Data.Pets.Value.hasNewPet = false;
        SkinPoint.gameObject.SetActive(false);
    }

    public void ShowWorldMap()
    {
        UIManager.OpenUIAsync(ViewConst.prefab_WorldMap);
    }

    public void ClickEmailButton()
    {
        UIManager.OpenUIAsync(ViewConst.prefab_EmaliSliderDialog);
    }

    private void OnDestroy()
    {
        EventDispatcher.RemoveEventListener(GlobalEvents.PetAdd, PetAdd);
    }

    private void PetAdd()
    {
        SkinPoint.SetActive(true);
    }
    
}
