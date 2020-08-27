using BetaFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Scripts_Game.Controllers.Guides;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassicPlayerGuideState : BasePlayerGuideState
{
    enum ClassicGuide
    {
        none,
        welcome,
        firstWord,
        hint1,
        hint2,
        hint3,
        hint4,
		VoiceWordGui1,
        VoiceWordGui2,
        VoiceWordGui3,
        themeWord,
        bee,
        rateReward,
        rateReward2,
    }

    ClassicGuide guide = ClassicGuide.none;

    public override bool CheckCondition()
    {
        guide = CheckToShowGuide();
        return guide != ClassicGuide.none;
    }

    private ClassicGuide CheckToShowGuide()
    {
        if (Const.AutoPlay)
        {
            return ClassicGuide.none;
        }
        int curLevel = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value;
        GuideSystem guideSystem = AppEngine.SSystemManager.GetSystem<GuideSystem>();
        if (curLevel == 1 && !guideSystem.GuideShown_Welcome.Value)
        {
            guideSystem.GuideShown_Welcome.Value = true;
            return ClassicGuide.welcome;
        }
        if (curLevel == 1 && !guideSystem.GuideShown_FirstWord.Value)
        {
            guideSystem.GuideShown_FirstWord.Value = true;
            return ClassicGuide.firstWord;
        }
        // var level = (GameManager as ClassicGameManager).GetLevel();
        // CommConfig_Data config = PreLoadManager.GetPreLoadConfig<CommConfig>(ViewConst.asset_CommConfig_config)?.dataList[0];
        // if (!AppEngine.SyncManager.Data.GuideThemeWord.Value 
        //     && level != null && level._SolutionCard != null 
        //     && AppEngine.SyncManager.Data.KnowledgeCards.Value.allCards.Count >= (config.ThemeWordGuideCardIndex - 1))
        // {
        //     AppEngine.SyncManager.Data.GuideThemeWord.Value = true;
        //     return ClassicGuide.themeWord;
        // }
        if (false && (GameManager as ClassicGameManager).GameTempData.hint5num > 0 &&
            !AppEngine.SyncManager.Data.GuideBeeUse.Value)
        {
            AppEngine.SyncManager.Data.GuideBeeUse.Value = true;
            return ClassicGuide.bee;
        }
        if (curLevel == 2 && !guideSystem.GuideShown_Hint1Unlock.Value)
        {
            guideSystem.GuideShown_Hint1Unlock.Value = true;
            return ClassicGuide.hint1;
        }
        if (curLevel == 10 && !guideSystem.GuideShown_Hint2Unlock.Value)
        {
            guideSystem.GuideShown_Hint2Unlock.Value = true;
            return ClassicGuide.hint2;
        }
        if (curLevel == 22 && !guideSystem.GuideShown_Hint3Unlock.Value)
        {
            guideSystem.GuideShown_Hint3Unlock.Value = true;
            return ClassicGuide.hint3;
        }
        if (curLevel == 36 && !guideSystem.GuideShown_Hint4Unlock.Value)
        {
            guideSystem.GuideShown_Hint4Unlock.Value = true;
            return ClassicGuide.hint4;
        }

        if (!DataManager.ProcessData.CanShowRateRewardStep2 
            && !AppEngine.SyncManager.Data.GuideRateReward.Value 
            && DataManager.ProcessData.CanShowRateRewardWord != null)
        {
            DataManager.ProcessData.CanShowRateRewardStep2 = true;
            return ClassicGuide.rateReward;
        }
        if (DataManager.ProcessData.CanShowRateRewardStep2 
            && DataManager.ProcessData.CanShowRateRewardWord != null)
        {
            DataManager.ProcessData.CanShowRateRewardStep2 = false;
            AppEngine.SyncManager.Data.GuideRateReward.Value = true;
            return ClassicGuide.rateReward2;
        }
        
#if !UNITY_ANDROID
        if ((curLevel == ClassicVoiceKeyboard.GuideLevel || curLevel >= ClassicVoiceKeyboard.GuideLevel2) && !guideSystem.GuideShown_GuideVoice.Value) {
            guideSystem.GuideShown_GuideVoice.Value = true;
            return ClassicGuide.VoiceWordGui1;
        }
#endif

        ClassicVoiceKeyboard voiceBoard = GameManager.GetEntity<ClassicVoiceKeyboard>();
        //if (ClassicVoiceKeyboard.netStatuOk && (curLevel == ClassicVoiceKeyboard.GuideLevel || curLevel >= ClassicVoiceKeyboard.GuideLevel2) && (guideSystem.GuideShown_GuideVoice2Step.Value < 2 || guideSystem.GuideShown_GuideVoice2Step.Value == 3) && !DataManager.ProcessData.voiceMicPressDown && voiceBoard.gameObject.activeSelf && UIManager.GetUI(ViewConst.prefab_FBPermissionDialog) == null) {
        //    Debug.LogError("DataManager.ProcessData.voiceMicPressDown1 " + guideSystem.GuideShown_GuideVoice2Step.Value);
        //    return ClassicGuide.VoiceWordGui2;
        //} else {
        //    Debug.LogError("DataManager.ProcessData.voiceMicPressDown2 " + DataManager.ProcessData.voiceMicPressDown+" -- "+ guideSystem.GuideShown_GuideVoice2Step.Value);
        //}
        //if ((curLevel == ClassicVoiceKeyboard.GuideLevel || curLevel >= ClassicVoiceKeyboard.GuideLevel2) && !guideSystem.GuideShown_GuideVoice3.Value && guideSystem.FinishWord_GuideVoice3.Value) {
        //    Debug.LogError("FinishWord_GuideVoice3");
        //    guideSystem.GuideShown_GuideVoice3.Value = true;
        //    return ClassicGuide.VoiceWordGui3;
        //}

        return ClassicGuide.none;
    }

    public override void Enter()
    {
        base.Enter();
        //GameManager.BanClick(true);
        if (guide == ClassicGuide.none)
        {
            guide = CheckToShowGuide();
            if (guide == ClassicGuide.none)
            {
                OnCompleted();
                return;
            }
        }
        ShowGuide();
    }

    public override void Leave()
    {
        if (guide != ClassicGuide.none)
        {
            guide = ClassicGuide.none;
            CloseCurrentGuide();
        }
        //GameManager.BanClick(false);
        base.Leave();
    }

    private void OnGuideClickGot()
    {
        guide = ClassicGuide.none;
        OnCompleted();
    }

    private void OnGuideClose()
    {
        if (guide != ClassicGuide.none)
        {
            guide = ClassicGuide.none;
            OnCompleted(); 
        }
    }

    private void ShowGuide()
    {
        Debug.LogError(guide);
        switch (guide)
        {
            case ClassicGuide.welcome:
                UIManager.OpenUIAsync(ViewConst.prefab_WelcomeGui, null, new GuideParam(null,
                   OnGuideClickGot, OnGuideClose, null));
                break;
            case ClassicGuide.firstWord:
                ShowFirstWordGuide();
                break;
            case ClassicGuide.hint1:
                ShowHintGuide(GameManager.GetEntity<BaseSkillManager>().specificCellHint);
                break;
            case ClassicGuide.hint2:
                GameManager.GetEntity<ClassicVoiceKeyboard>().gameObject.SetActive(false);
                ShowHintGuide(GameManager.GetEntity<BaseSkillManager>().keyboardHint);
                break;
            case ClassicGuide.hint3:
				ShowHintGuide(GameManager.GetEntity<BaseSkillManager>().multiCellsHint);
                break;
            case ClassicGuide.hint4:
                ShowHintGuide(GameManager.GetEntity<BaseSkillManager>().specificWordHint);
                break;
            case ClassicGuide.VoiceWordGui1:
                BaseKeyBoard keyBoard1 = GameManager.GetEntity<BaseKeyBoard>();
                var transform1 = keyBoard1.GetOneKey("Speech" + "");
                UIManager.OpenUIAsync(ViewConst.prefab_VoiceWordGui1, null, new GuideParam(new UILayerTarget() { target = transform1.GetComponent<RectTransform>(), hasRaycaster = true},
                   OnGuideClickGot, OnGuideClose, null), transform1);
                break;
            case ClassicGuide.VoiceWordGui2:
                ClassicVoiceKeyboard voiceBoard = GameManager.GetEntity<ClassicVoiceKeyboard>();
                RectTransform rt = voiceBoard.transform.Find("Btn_Voice").GetComponent<RectTransform>();
                Debug.LogError("ViewConst.prefab_VoiceWordGui2");
                UIManager.OpenUIAsync(ViewConst.prefab_VoiceWordGui2, null, new GuideParam(new UILayerTarget() { target = rt, hasRaycaster = true },
                   OnGuideClickGot, OnGuideClose, null), rt.GetComponent<UnityEngine.UI.Button>());
                break;
            case ClassicGuide.VoiceWordGui3:
                UIManager.OpenUIAsync(ViewConst.prefab_VoiceWordGui3, null, new GuideParam(null, OnGuideClickGot,OnGuideClose, null));
                break;
            case ClassicGuide.themeWord:
                DOTween.Sequence().InsertCallback(1f, ShowThemeWordGuide);
                //ShowThemeWordGuide();
                break;
            case ClassicGuide.bee:
                ShowBeeUseGuide();
                break;
            case ClassicGuide.rateReward:
                ShowRateRewardGuide(1);
                break;
            case ClassicGuide.rateReward2:
                ShowRateRewardGuide(2);
                break;
        }
    }

    private void ShowFirstWordGuide()
    {
        BaseKeyBoard keyBoard = GameManager.GetEntity<BaseKeyBoard>();
        BaseCellManager cellManager = GameManager.GetEntity<BaseCellManager>();
        BaseQuestionDisplay ques = GameManager.GetEntity<BaseQuestionDisplay>();
        List<UILayerTarget> uis = new List<UILayerTarget>();
        string answer = cellManager.Words[0].Answer;
        List<BaseCell> cells = cellManager.Words[0].ValidCells;
        cells.ForEach(cell => {
            uis.Add(new UILayerTarget() { target = cell.GetComponent<RectTransform>() });
        });
        uis.Add(new UILayerTarget() { target = cellManager.focusWordFlag.GetComponent<RectTransform>() });
        //uis.Add(new UILayerTarget() { target = keyBoard.GetComponent<RectTransform>(), hasRaycaster = true });
        //keyBoard.ShowMask(true);
        string text = String.Format("Welcome to our journey.\nTry to type <color=\"#FF5B01\">\"{0}\"</color>\nto answer this question!", answer.ToUpper());
        UIManager.OpenUIAsync(ViewConst.prefab_FirstWordGui, null, new GuideParam(
            new UILayerTarget() { target = ques.GetComponent<RectTransform>(), hasRaycaster = false },
            OnGuideClickGot, OnGuideClose, uis), keyBoard, answer.ToUpper());
    }

    private void ShowHintGuide(BaseHint hint)
    {
        List<UILayerTarget> uis = new List<UILayerTarget>();
        //uis.Add(new UILayerTarget() { target = hint.lightFlag.GetComponent<RectTransform>(), hasRaycaster = false });
        uis.Add(new UILayerTarget() { target = hint.freeTag.GetComponent<RectTransform>(), hasRaycaster = false });
        hint.FreeCount += 1;
        UIManager.OpenUIAsync(ViewConst.prefab_HintPropGui, null, new GuideParam(
           new UILayerTarget() { target = hint.GetComponent<RectTransform>(), hasRaycaster = true },
           OnGuideClickGot, OnGuideClose, uis), hint);
    }

    private void ShowRateRewardGuide(int step)
    {
        if (step == 1)
        {
            ClassicNormalWord word = DataManager.ProcessData.CanShowRateRewardWord as ClassicNormalWord;
            List<UILayerTarget> uis = new List<UILayerTarget>();
            List<BaseCell> cells = word.ValidCells;
            UILayerTarget target = null;
            float cellSize = 0;
            cells.ForEach(cell =>
            {
                if (target == null)
                {
                    target = new UILayerTarget() {target = cell.GetComponent<RectTransform>(), hasRaycaster = true};
                    cellSize = cell.CellSize;
                }
                else
                    uis.Add(new UILayerTarget() { target = cell.GetComponent<RectTransform>(), hasRaycaster = true });
            });
            UIManager.OpenUIAsync(ViewConst.prefab_PlayWordRewardCoinGui, null, new GuideParam(
                target, OnGuideClickGot, OnGuideClose, uis), cellSize, cells.Count);
        }
        else if (step == 2)
        {
            var rate = GameManager.GetEntity<ClassicQuestionRate>();
            BaseQuestionDisplay ques = GameManager.GetEntity<BaseQuestionDisplay>();
            //var shading = GameManager.GetEntity<BaseShading>();
            List<UILayerTarget> uis = new List<UILayerTarget>();
            //uis.Add(new UILayerTarget() { target = shading.questionBG.GetComponent<RectTransform>() });
            uis.Add(new UILayerTarget() { target = rate.GetComponent<RectTransform>(), hasRaycaster = true});
            UIManager.OpenUIAsync(ViewConst.prefab_PlayWordRewardCoinGui2, null, new GuideParam(
                new UILayerTarget() { target = ques.GetComponent<RectTransform>(), hasRaycaster = false },
                OnGuideClickGot, OnGuideClose, uis));
            rate.PlayGuideAni(true);
            DataManager.ProcessData.CanShowRateRewardWord = null;
        }
    }

    private void ShowThemeWordGuide()
    {
        var root = GameManager.GetComponent<RectTransform>();
        var cellMgr = GameManager.GetEntity<ClassicCellManager>();
        var view = cellMgr.scrollViewport.GetComponent<RectTransform>();
        var cellSize = cellMgr.gridLayout.cellSize;
        var firstPos = root.InverseTransformPoint(cellMgr.ThemeWord.Cells.First().transform.position);
        var lastPos = root.InverseTransformPoint(cellMgr.ThemeWord.Cells.Last().transform.position);
        Rect rt = new Rect(
            firstPos.x - cellSize.x / 2 - 10, 
            firstPos.y + cellSize.y / 2, 
            lastPos.x - firstPos.x + cellSize.x + 20, 
            firstPos.y - lastPos.y + cellSize.y);
        var viewPos = root.InverseTransformPoint(view.position);
        float top = viewPos.y + (1 - view.pivot.y) * view.rect.height;
        var bottom = viewPos.y - view.pivot.y * view.rect.height;
        RectTransform targetCell = null;
        foreach (var cell in cellMgr.ThemeWord.Cells)
        {
            var pos = root.InverseTransformPoint(cell.transform.position);
            if (pos.y > bottom)
                targetCell = cell.GetComponent<RectTransform>();
            else
            {
                break;
            }
        }

        if (rt.y > top)
            rt.y = top;
        if (rt.y - rt.height < bottom)
            rt.height = rt.y - bottom;
        
        var target = new UILayerTarget() {target = targetCell, hasRaycaster = true};
        UIManager.OpenUIAsync(ViewConst.prefab_PrepositionWordGui, null, 
            new ThemeWordGuideParam(target, rt, 
            OnGuideClickGot, OnGuideClose));
        //cellMgr.ThemeWord.Select();
    }
    
    private void ShowBeeUseGuide()
    {
        var beeWord = GameManager.GetEntity<BaseCellManager>().Words.Find(w => (w as ClassicNormalWord).IsBeeWord());
        List<BaseCell> beeWordCells = beeWord.ValidCells;
        List<UILayerTarget> uis = new List<UILayerTarget>();
        UILayerTarget target = null;
        float cellSize = 0;
        beeWordCells.ForEach(cell =>
        {
            if (target == null)
            {
                target = new UILayerTarget() {target = cell.GetComponent<RectTransform>(), hasRaycaster = true};
                cellSize = cell.CellSize;
            }
            else
                uis.Add(new UILayerTarget() { target = cell.GetComponent<RectTransform>(), hasRaycaster = true });
        });
        UIManager.OpenUIAsync(ViewConst.prefab_BeeInGameGui, null, new GuideParam(
            target, OnGuideClickGot, OnGuideClose, uis), cellSize, beeWordCells.Count);
    }
    
    public override void HandleEvent(string eventName)
    {
        base.HandleEvent(eventName);
        switch (eventName)
        {
            case BaseFSMManager.Event_GuideClose_Hint:
                if (guide == ClassicGuide.hint1 
                    || guide == ClassicGuide.hint2
                    || guide == ClassicGuide.hint3
                    || guide == ClassicGuide.hint4)
                {
                    guide = ClassicGuide.none;
                    CloseCurrentGuide();
                    OnCompleted();
                }
                break;
            case BaseFSMManager.Event_GuideClose_First:
                if (guide == ClassicGuide.firstWord)
                {
                    guide = ClassicGuide.none;
                    CloseCurrentGuide();
                    OnCompleted();
                }
                break;
            case BaseFSMManager.Event_GuideClose_RateReward:
                if (guide == ClassicGuide.rateReward)
                {
                    guide = ClassicGuide.none;
                    CloseCurrentGuide();
                    OnCompleted();
                }
                else if (guide == ClassicGuide.rateReward2)
                {
                    guide = ClassicGuide.none;
                    CloseCurrentGuide();
                    GameManager.GetEntity<ClassicQuestionRate>().PlayGuideAni(false);
                    OnCompleted();
                }
                // else if (guide == ClassicGuide.bee)
                // {
                //     guide = ClassicGuide.none;
                //     CloseCurrentGuide();
                //     OnCompleted();
                // }
                break;
        }
    }
}
