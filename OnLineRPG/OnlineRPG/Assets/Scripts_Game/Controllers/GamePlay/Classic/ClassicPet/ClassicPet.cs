using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

public class ClassicPet : BasePet
{
    public SkeletonGraphic petSkeletonGraphic;

    // Start is called before the first frame update
    private PetStatesManager _petStatesManager;

    public Transform root; //小人的父控件

    public Animator AnswerTip;
    public TextMeshProUGUI answerTipText;

    public Animator CellAnswerTip;
    public TextMeshProUGUI cellAnswerTipText;

    private GameObject petIObj;
    private AsyncOperationHandle<GameObject> pet;

    public string[] petTip4 = new[]
    {
        ViewConst.prefab_Encourage_Bright, ViewConst.prefab_Encourage_Cool, ViewConst.prefab_Encourage_Fantastic,
        ViewConst.prefab_Encourage_Good, ViewConst.prefab_Encourage_Perfect, ViewConst.prefab_Encourage_Smart,
        ViewConst.prefab_Encourage_Wonderful, ViewConst.prefab_Encourage_Wow
    };

    void Start()
    {
        loadUserSelectPet();
    }

    private void loadUserSelectPet()
    {
        string petId = AppEngine.SyncManager.Data.Pets.Value.currentPetId;
        Pets pets = PreLoadManager.GetPreLoadConfig<Pets>(ViewConst.asset_Pets_Pet);
        List<Pets_Data> petsDatas = pets.dataList;
        foreach (var data in petsDatas)
        {
            if (petId.Equals(data.ID))
            {
                Addressables.LoadAssetAsync<GameObject>(string.Format("{0}.prefab", data.prefab)).Completed += op =>
                {
                    pet = op;
                    if (root.childCount > 0)
                    {
                        Destroy(root.GetChild(0).gameObject);
                    }

                    root.DetachChildren();
                    petIObj = Instantiate(op.Result, root, false);
                    petSkeletonGraphic = petIObj.GetComponent<SkeletonGraphic>();
                    _petStatesManager = new PetStatesManager(petSkeletonGraphic);
                    _petStatesManager.TransTo(PetBase.PetStates.Idle);
                };
                break;
            }
        }
    }

    private void OnDestroy()
    {
        if (_petStatesManager != null)
        {
            _petStatesManager = null;
        }

        if (petIObj != null)
        {
            Destroy(petIObj);
        }

        if (pet.IsValid())
        {
            if (petSkeletonGraphic != null)
            {
                petSkeletonGraphic.Clear();
                Destroy(petSkeletonGraphic.GetLastMesh());
            }

            Addressables.Release(pet);
        }
    }

    public void ClickPet()
    {
        CloseAnswerTip();
        CloseCellTip();
        if (_petStatesManager != null)
            _petStatesManager.TransTo(PetBase.PetStates.click);
        AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_petclick);
        if (!PlatformUtil.GetAppIsRelease())
        {
            BaseGameManager game = Object.FindObjectOfType<BaseGameManager>();
            if (game)
            {
                game.WinGame();
            }

            // BaseCellManager cellManager = Object.FindObjectOfType<BaseCellManager>();
            // cellManager.ShowAnswer();
        }
    }

    public override void ShowAnswerTip(string answer)
    {
        CloseCellTip();
        base.ShowAnswerTip(answer);
        if (AnswerTip && !isAnswerTipShow)
        {
            answerTipText.text = string.Format("Hmm, lets try \"{0}\"", answer);
            AnswerTip.gameObject.SetActive(true);
            AnswerTip.SetTrigger("out");
            isAnswerTipShow = true;
        }
    }

    public override void ShowCellTip(string cellAnswer)
    {
        base.ShowCellTip(cellAnswer);
        if (CellAnswerTip && !isCellAnswerShow)
        {
            PetTipsList config = PreLoadManager.GetPreLoadConfig<PetTipsList>(ViewConst.asset_PetTipsList_TipList);
            cellAnswerTipText.text = string.Format(config.GetRandomTip(3), "<color=blue>" + cellAnswer + "</color>");
            CellAnswerTip.gameObject.SetActive(true);
            CellAnswerTip.SetTrigger("out");
            isCellAnswerShow = true;
            TimersManager.SetTimer(3f, () => { CloseCellTip(); });
        }
    }

    private void ShowPetAutoCloseTip(string tips)
    {
        CloseAnswerTip();
        if (CellAnswerTip && !isCellAnswerShow)
        {
            cellAnswerTipText.text = string.Format("{0}", tips);
            CellAnswerTip.gameObject.SetActive(true);
            CellAnswerTip.SetTrigger("out");
            isCellAnswerShow = true;

            TimersManager.SetTimer(3f, () => { CloseCellTip(); });
        }
    }

    public override void CloseCellTip()
    {
        base.CloseCellTip();
        if (CellAnswerTip && isCellAnswerShow)
        {
            CellAnswerTip.SetTrigger("in");
            isCellAnswerShow = false;
        }
    }

    public override void CloseAnswerTip()
    {
        base.CloseAnswerTip();
        if (AnswerTip && isAnswerTipShow)
        {
            AnswerTip.SetTrigger("in");
            isAnswerTipShow = false;
        }
    }

    /// <summary>
    /// 小人的多种提示方式
    /// </summary>
    /// <param name="type"></param>
    public override void ShowPetTip(PetTip type)
    {

        switch (type)
        {
            case PetTip.Type1:
                PetTipsList config0 = PreLoadManager.GetPreLoadConfig<PetTipsList>(ViewConst.asset_PetTipsList_TipList);
                if (config0)
                    ShowPetAutoCloseTip(config0.GetRandomTip(1));
                break;
            case PetTip.Type2:
                PetTipsList config = PreLoadManager.GetPreLoadConfig<PetTipsList>(ViewConst.asset_PetTipsList_TipList);
                if (config)
                    ShowPetAutoCloseTip(config.GetRandomTip(2));
                break;
            case PetTip.Type3:
                PetTipsList config2 = PreLoadManager.GetPreLoadConfig<PetTipsList>(ViewConst.asset_PetTipsList_TipList);
                if (config2)
                    ShowPetAutoCloseTip(config2.GetRandomTip(3));
                break;
            case PetTip.Type4:
                PRPlay();
                break;
        }
    }

    public void PRPlay()
    {
        if (_petStatesManager != null)
            _petStatesManager.TransTo(PetBase.PetStates.hint);
        Addressables.LoadAssetAsync<GameObject>(petTip4[UnityEngine.Random.Range(0, petTip4.Length)]).Completed += op =>
        {
            GameObject enObj = Instantiate(op.Result, transform, false);
            Timer.Schedule(this, 3f, () => { Object.Destroy(enObj); });
        };
    }

    private bool isAnswerTipShow = false;
    private bool isCellAnswerShow = false;

    public override void HintUse()
    {
        base.HintUse();
        if (_petStatesManager != null)
            _petStatesManager.TransTo(PetBase.PetStates.hint);
    }

    public override void HintEnd()
    {
        base.HintEnd();
    }
}