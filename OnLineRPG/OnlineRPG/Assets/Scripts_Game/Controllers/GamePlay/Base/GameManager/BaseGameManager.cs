using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public abstract class BaseGameManager : MonoBehaviour
{

    [SerializeField] private List<GameEntity> m_gameEntity;
    public GameObject BanClickPanel;
    /// <summary>
    /// 游戏中产生的数据
    /// </summary>
    public GameCollectData GameTempData = new GameCollectData();
    private BaseFSMManager fsmManager;
    public BaseFSMManager StateMachine { get { return fsmManager; } }

    //层级管理集合
    private Dictionary<string, Transform> m_movedObjectParents = new Dictionary<string, Transform>();
    
    //答案正确委托
    public Action RightAnswer;

    //答案错误委托
    public Action WrongAnswer;

    public Action ExistAnswer;

    protected BaseWord curWord = null;
    
    public abstract BaseFSMManager InstantiateFSM();

    public abstract void ShowGameADVideo();

    /// <summary>
    /// 禁止操作，只展示动画
    /// </summary>
    public virtual void BanClick(bool banclick)
    {
        if (banclick)
        {
            BanClickPanel.SetActive(true);
        }
        else
        {
            BanClickPanel.SetActive(false);
        }
    }
    

    /// <summary>
    /// 初始化方法
    /// </summary>
    public virtual void Init()
    {
        Debug.Log(this.gameObject.name);
        curWord = null;
        for (int i = 0; i < m_gameEntity.Count; i++)
        {
            m_gameEntity[i].GameManager = this;
        }
        fsmManager = InstantiateFSM();
        fsmManager.StartGame();
        GameTempData.Init();
        EventUtil.EventDispatcher.AddEventListener<string>(GlobalEvents.OpenUI, OnOpenUI);
        EventUtil.EventDispatcher.AddEventListener<string>(GlobalEvents.CloseUI, OnCloseUI);
    }

    private void OnDestroy()
    {
        EventUtil.EventDispatcher.RemoveEventListener<string>(GlobalEvents.OpenUI, OnOpenUI);
        EventUtil.EventDispatcher.RemoveEventListener<string>(GlobalEvents.CloseUI, OnCloseUI);
    }

    private void OnOpenUI(string uiname)
    {
        //LoggerHelper.Error("open ui " + uiname);
        if (ViewConst.prefab_StoreDialog == uiname) 
            fsmManager.TriggerEvent(BaseFSMManager.Event_Popup);
    }

    private void OnCloseUI(string uiname)
    {
        //LoggerHelper.Error("close ui " + uiname);
        if (ViewConst.prefab_StoreDialog == uiname) 
            fsmManager.TriggerEvent(BaseFSMManager.Event_PopupClose);
    }

    public virtual void GameAnimationStart()
    {
        fsmManager.TriggerEvent(BaseFSMManager.Event_PlayAni);
    }

    public virtual void GameAnimationEnd()
    {
        fsmManager.TriggerEvent(BaseFSMManager.Event_PlayAniEnd);
    }

    private void OnApplicationFocus(bool focus)
    {
       GameTempData.GameOnApplicationFocus(focus);
    }

    /// <summary>
    /// 获取某个实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetEntity<T>() where T : GameEntity
    {
        for (int i = 0; i < m_gameEntity.Count; i++)
        {
            if (m_gameEntity[i] is T)
            {
                return m_gameEntity[i] as T;
            }
        }
        return null;
    }

    /// <summary>
    /// 当单词焦点变化的时候调用
    /// </summary>
    /// <param name="index"></param>
    public virtual void OnWordChangeFocus(BaseWord word)
    {
        GetEntity<BaseQuestionDisplay>().OnWordChanged(word);
        GetEntity<BaseKeyBoard>().OnWordChangeFocus(word.Answer, word.IsKeyboardHintUsed);
        //GetEntity<BaseSkillManager>().keyboardHint.SetHintEnable(!usedHint2);
        if (word != null && curWord != word)
        {
            curWord = word;
            GameTempData.WordStayTimeForTip = 0;
        }
    }

    public virtual void PlayerInput(string inputString)
    {
        if (inputString.Equals(KeyBoard.Speech.ToString())) {
            GetEntity<ClassicVoiceKeyboard>()?.Active();
        } else {
			GetEntity<BaseCellManager>().InputLetter(inputString);
		}
    }
    
    public void AutoInputRightAnswer()
    {
        StartCoroutine(AutoInput());
    }

    private IEnumerator AutoInput()
    {
        yield return new WaitForSeconds(0.3f);
        BaseWord word =  GetEntity<BaseCellManager>().GetCruBaseWord();
        for (int i = 0; i < word.Cells.Count; i++)
        {
            if (AppEngine.SGameSettingManager.SkipFilledSquares.Value)
            {
                if (word.Cells[i].State != CellState.filled && word.Cells[i].State != CellState.none)
                {
                    PlayerInput(word.Cells[i].AnswerLetter.ToString());
                    yield return new WaitForSeconds(0.4f);
                }
            }
            else
            {
                if (word.Cells[i].State != CellState.none)
                {
                    PlayerInput(word.Cells[i].AnswerLetter.ToString());
                    yield return new WaitForSeconds(0.4f);
                }

            }
            
        }
    }


    public virtual void CacheLevelProgress()
    {
        
    }
    // 清除存档
    public virtual void ClearLevelProgress()
    {

    }

    public virtual void SaveLocal()
    {
        
    }

    /// <summary>
    /// hint开始方法
    /// </summary>
    public virtual void HintUse()
    {
        GetEntity<BasePet>().HintUse();
    }

    /// <summary>
    /// hint结束方法
    /// </summary>
    public virtual void HintEnd()
    {
        GetEntity<BasePet>().HintEnd();
    }
    
    public virtual void EndGame()
    {
        //fsmManager.EndGame();
        GetEntity<BaseCellManager>().OnGameCompleted();
        GetEntity<BaseSkillManager>().OnGameCompleted();
        GetEntity<BaseQuestionDisplay>().OnGameCompleted();
        GameTempData.GameWin();
    }

    public virtual string GetLevelSeq()
    {
        return null;
    }
    
    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.N))
        {
            //GetEntity<BaseCellManager>().GameComplete();
            fsmManager.EndGame();
        }
#endif
        time += Time.deltaTime;
        if (time > 1f && fsmManager != null)
        {
            time = 0f;
            if (fsmManager.IsInPlayingState)
            {
                GameTempData.WordStayTimeForTip += 1;
                CheckAnswerTip();
            }
        }
    }

    private float time = 0;

    public void WinGame()
    {
        fsmManager.EndGame();
    }

    protected virtual void CheckAnswerTip()
    {

    }
	
    public BaseWord GetCurrentFoucesAnswer()
    {
        if (curWord != null) {
            return curWord;
        }

        return null;
    }
}
