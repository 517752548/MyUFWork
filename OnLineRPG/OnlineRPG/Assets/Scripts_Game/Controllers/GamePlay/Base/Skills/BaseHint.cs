using System;
using BetaFramework;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// hint道具基类
/// </summary>
public abstract class BaseHint : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject normalContent, lockContent;
    public Image iconImage;
    public RedDotText countText;
    public Text priceText;
    public Text saleCountDownTimeText;
    public GameObject freeTag;
    public GameObject lightFlag;

    protected BaseSkillManager skillManager;
    protected PropertyAB_Data configData;
    protected bool unlocked = false;
    protected int count = 0;
    protected bool hintEnable = true;
    protected bool isDuringPointerEvent = false;

    public virtual void Init(BaseSkillManager skillManager, PropertyAB_Data config)
    {
        this.skillManager = skillManager;
        this.configData = config;
        priceText.text = "" + config.Coast;
        freeCount = 0;
        if (!unlocked)
            unlocked = configData.StartLevel <=
                       AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value;
        UpdateCountText();
        UpdateLockState();

        //BoxCollider2D collider = GetComponent<BoxCollider2D>();
        //if (collider == null)
        //{
        //    collider = gameObject.AddComponent<BoxCollider2D>();
        //    collider.size = new Vector2(140, 120);
        //}
        UIManager.PreloadUI(ViewConst.prefab_HintNotice);
    }

    private int freeCount = 0;

    public int FreeCount
    {
        get { return freeCount; }
        set
        {
            freeCount = value;
            UpdateCountText();
        }
    }

    public virtual void SetHintEnable(bool enable)
    {
        this.hintEnable = enable;
    }

    /// <summary>
    /// 刷新道具数量和价格展示
    /// </summary>
    private void UpdateCountText()
    {
        if (FreeCount > 0)
        {
            if (freeTag)
                freeTag?.SetActive(true);
            countText.gameObject.SetActive(false);
            priceText.transform.parent.gameObject.SetActive(false);
        }
        else if (count <= 0)
        {
            if (freeTag)
                freeTag?.SetActive(false);
            countText.gameObject.SetActive(false);
            priceText.transform.parent.gameObject.SetActive(true);
        }
        else
        {
            if (freeTag)
                freeTag?.SetActive(false);
            countText.gameObject.SetActive(true);
            countText.SetText("" + count);
            priceText.transform.parent.gameObject.SetActive(false);
        }
    }

    protected void UpdateLockState()
    {
        if (IsUnlocked)
        {
            normalContent.SetActive(true);
            lockContent.SetActive(false);
        }
        else
        {
            normalContent.SetActive(false);
            lockContent.SetActive(true);
        }
    }

    public bool IsUnlocked
    {
        get
        {
            return unlocked || configData.StartLevel <=
                AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value;
        }
    }

    public virtual void OnClick()
    {
        //LoggerHelper.Log("hint点击");
    }

    /// <summary>
    /// 使用道具
    /// </summary>
    /// <returns></returns>
    public bool UseHint()
    {
        if (FreeCount > 0)
        {
            OnHintWork();
            OnUseHint();
            FreeCount--;

            return true;
        }

        if (count > 0)
        {
            OnHintWork();
            OnUseHint();
            ReduceHintCount();
            
            TimersManager.SetTimer(3, () =>
            {
                ReportUseHint(skillManager.GameManager.GetLevelSeq(), GetReportName(), "0", "1");
                AppEngine.SyncManager.DoSync(null);
            });
            return true;
        }
        else
        {
            if (configData.Coast <= AppEngine.SyncManager.Data.Coin.Value)
            {
                OnHintWork();
                OnUseHint();
                AppEngine.SyncManager.Data.Coin.Value -= configData.Coast;
                
                TimersManager.SetTimer(3, () =>
                {
                    ReportUseHint(skillManager.GameManager.GetLevelSeq(), "coin", configData.Coast.ToString(), "0");
                    AppEngine.SyncManager.DoSync(null);
                });
                return true;
            }
            else
            {
                OnCancelHint();
                DataManager.businessGiftData.MoneyNotEnough();
                return false;
            }
        }
    }

    /// <summary>
    /// 取消道具使用
    /// </summary>
    public void CancelHint()
    {
        OnCancelHint();
    }

    protected abstract void OnUseHint();

    protected abstract void OnCancelHint();

    /// <summary>
    /// 修改道具数量，减少一个
    /// </summary>
    protected abstract void ReduceHintCount();

    protected virtual void OnDataGot(int hintCount, bool hintIsUnlocked)
    {
        unlocked = hintIsUnlocked;
        count = hintCount;
        UpdateCountText();
        UpdateLockState();
    }

    protected virtual void OnDataChanged(bool result, int hintCount, bool hintIsUnlocked)
    {
        if (result)
        {
            unlocked = hintIsUnlocked;
            count = hintCount;
            UpdateCountText();
            UpdateLockState();
        }
    }

    protected bool isPointerDown;
    protected bool canPointDown = true;

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (!canPointDown)
        {
            return;
        }

        //Debug.LogError("zxf hint OnPointerDown " + eventData.position);
        isDuringPointerEvent = true;
        isPointerDown = true;
        if (!IsUnlocked || !hintEnable || skillManager.IsDuringUse
            || !(skillManager.GameManager.StateMachine.IsInPlayingState
                 || skillManager.GameManager.StateMachine.IsInGuideState))
        {
            isPointerDown = false;
            return;
        }

        if (FreeCount <= 0 && count <= 0
                           && configData.Coast > AppEngine.SyncManager.Data.Coin.Value)
        {
            canPointDown = false;
            TimersManager.SetTimer(3f, () => { canPointDown = true; });
            OnHintSelected(false);
            DataManager.businessGiftData.MoneyNotEnough();
            isPointerDown = false;
            return;
        }

        OnHintSelected(true);
        OnHintStart();
        skillManager.GameManager.StateMachine.TriggerEvent(BaseFSMManager.Event_GuideClose_Hint);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        //Debug.LogError("zxf hint OnPointerUp " + eventData.position);
        isDuringPointerEvent = false;
        // if (!IsUnlocked || !hintEnable || (skillManager.IsDuringUse && !skillManager.IsUsingHint(this))
        //     || !(skillManager.GameManager.StateMachine.IsInPlayingState 
        //          || skillManager.GameManager.StateMachine.IsInGuideState))
        //     return;
        if (!isPointerDown) return;
        OnHintSelected(false);
        //if (!eventData.hovered.Contains(gameObject)) //未完成点击
        if (eventData.pointerPress !=
            ExecuteEvents.GetEventHandler<IPointerClickHandler>(eventData.pointerCurrentRaycast.gameObject))
        {
            CancelHint();
        }
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (!IsUnlocked)
        {
            AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_clicklockhint);
            UIManager.OpenUIAsync(ViewConst.prefab_HintNotice, OpenType.Replace,
                (UIWindowBase UI, object[] objs) => { }, this, configData.StartLevel);
            return;
        }

        // if (!hintEnable || (skillManager.IsDuringUse && !skillManager.IsUsingHint(this))
        //                 || !(skillManager.GameManager.StateMachine.IsInPlayingState 
        //                      || skillManager.GameManager.StateMachine.IsInGuideState))
        //     return;
        if (!isPointerDown) return;
        OnClick();
    }

    /// <summary>
    /// 道具被选中时改变状态
    /// </summary>
    /// <param name="sel">是否被选中</param>
    protected virtual void OnHintSelected(bool sel)
    {
        //hint被选中放大
        //iconImage.transform.localScale = Vector3.one * (sel ? 1.2f : 1);
        //iconImage.transform.DOScale(Vector3.one * (sel ? 1.5f : 1), 0.4f);
    }

    /// <summary>
    /// 道具使用过程开始
    /// </summary>
    protected virtual void OnHintStart()
    {
        lightFlag.SetActive(true);
        skillManager.OnHintStart(this);
    }

    protected virtual void OnHintWork()
    {
        skillManager.GameManager.GameAnimationStart();
        skillManager.OnHintUse(this);
    }

    protected virtual void OnHintWorkEnd()
    {
        skillManager.GameManager.GameAnimationEnd();
        OnHintEnd();
    }

    /// <summary>
    /// 道具使用结束
    /// </summary>
    protected virtual void OnHintEnd()
    {
        lightFlag.SetActive(false);
        skillManager.OnHintEnd(this);
    }

    public abstract string GetHintTitle();

    public abstract string GetReportName();

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            OnLostFocus();
        }
    }

    protected virtual void OnLostFocus()
    {
        //Debug.LogError("zxf hint OnLostFocus");
        if (isDuringPointerEvent)
            ExecuteEvents.Execute<IPointerUpHandler>(gameObject, new PointerEventData(EventSystem.current),
                ExecuteEvents.pointerUpHandler);
        //CancelHint();
        //EventSystem.current.currentInputModule.Process
    }

    private void ReportUseHint(string levelSeq, string spendType, string coinCost, string hintCost)
    {
        int rightAnswer = skillManager.GameManager.GetEntity<BaseCellManager>().CompletedWordsCount;
        int levelanswers = skillManager.GameManager.GetEntity<BaseCellManager>().Words.Count;
        float progress = (float) rightAnswer / levelanswers;

        int coin = AppEngine.SyncManager.Data.Coin.Value;
        int hint1 = AppEngine.SyncManager.Data.Hint1.Value;
        int hint2 = AppEngine.SyncManager.Data.Hint2.Value;
        int Hint3 = AppEngine.SyncManager.Data.Hint3.Value;
        int Hint4 = AppEngine.SyncManager.Data.Hint4.Value;
        int hint5 = AppEngine.SyncManager.Data.Bee.Value;
        string SpendType = spendType.Contains("coin") ? "coin" : "hint";
        GameAnalyze.LogitemConsume(levelSeq, DataManager.ProcessData._GameMode.ToString(), "NULL",
            coin.ToString(), hint1.ToString(), hint2.ToString(), Hint3.ToString(), Hint4.ToString(),
            progress.ToString(), skillManager.GameManager.GetEntity<BaseCellManager>().WrongTimes.ToString(),
            SpendType, GetReportName(), coinCost, hintCost, hint5.ToString(),
            AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetUserRewardLib(),
            AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetABReportStr());
        // GameAnalyze.LogitemConsume(levelSeq,DataManager.ProcessData._GameMode.ToString(),"NULL",
        //     coin.ToString(),hint1.ToString(),hint2.ToString(),Hint3.ToString(),Hint4.ToString(),hint5.ToString(), 
        //     progress.ToString(),skillManager.GameManager.GetEntity<BaseCellManager>().WrongTimes.ToString(),
        //     SpendType, GetReportName(),coinCost, hintCost,
        //     AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetUserRewardLib(),
        //     AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetABReportStr());
    }
}

/// <summary>
/// 能通过拖拽使用的hint基类
/// </summary>
public abstract class BaseDragHint : BaseHint, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public HintClickArea clickArea;
    public Transform DraggedObj; //被拖拽的物体

    private bool dragStarted = false; //是否开始拖拽
    private UIWindowBase topTipWindow = null;

    /// <summary>
    /// 选择道具使用目标时触发点击
    /// </summary>
    /// <param name="eventData"></param>
    public virtual void OnChooseTargetClick(PointerEventData eventData)
    {
        //LoggerHelper.Log("hint点击使用目标 " + eventData.position);
        //LoggerHelper.Error("zxf draghint choose target");
        IsChooseEnable = false;
        OnHintSelected(false);
        HideTopTip();
    }

    /// <summary>
    /// 是否在选择道具使用目标过程
    /// </summary>
    protected bool IsChooseEnable
    {
        get { return clickArea.IsDuringChoose; }
        set
        {
            clickArea.IsDuringChoose = value;
            if (value)
                clickArea.hint = this;
        }
    }

    public override void OnClick()
    {
        base.OnClick();
        if (FreeCount <= 0 && count <= 0
                           && configData.Coast > AppEngine.SyncManager.Data.Coin.Value)
        {
            OnHintSelected(false);
            OnCancelHint();
            DataManager.businessGiftData.MoneyNotEnough();
            return;
        }

        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_hintfocuson);
        if (IsChooseEnable)
        {
            //LoggerHelper.Error("zxf draghint click repeat disable");
            return;
        }

        IsChooseEnable = true;
        ShowTopTip();
        //LoggerHelper.Error("zxf draghint click");
    }

    protected override void OnLostFocus()
    {
        //Debug.LogError("zxf draghint OnLostFocus");
        base.OnLostFocus();
        if (dragStarted)
        {
            ExecuteEvents.Execute<IEndDragHandler>(gameObject, new PointerEventData(EventSystem.current),
                ExecuteEvents.endDragHandler);
            dragStarted = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.LogError("zxf draghint OnBeginDrag");
        if (!IsUnlocked || !hintEnable)
            return;
        if (FreeCount <= 0 && count <= 0
                           && configData.Coast > AppEngine.SyncManager.Data.Coin.Value)
        {
            return;
        }

        dragStarted = true;
        //Debug.LogError("zxf draghint OnHintDragStart");
        OnHintDragStart(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.LogError("zxf draghint OnDrag");
        if (!dragStarted || !IsUnlocked || !hintEnable)
            return;
        //Debug.LogError("zxf draghint OnHintDrag");
        OnHintDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.LogError("zxf draghint OnEndDrag");
        if (!canPointDown)
            return;
        if (!dragStarted)
            return;
        dragStarted = false;
        if (!IsUnlocked || !hintEnable)
            return;
        //Debug.LogError("zxf draghint OnHintDragEnd");
        OnHintDragEnd(eventData);
        OnHintSelected(false);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        //Debug.LogError("zxf draghint OnPointerDown");
        base.OnPointerDown(eventData);
        //LoggerHelper.Error("zxf draghint pointer down " + isPointerDown);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        isDuringPointerEvent = false;
        //Debug.LogError("zxf draghint OnPointerUp");
        if (!isPointerDown) return;
        if (dragStarted)
            return;
        if (eventData.pointerPress !=
            ExecuteEvents.GetEventHandler<IPointerClickHandler>(eventData.pointerCurrentRaycast.gameObject))
        {
            CancelHint();
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        //Debug.LogError("zxf draghint OnPointerClick");
        if (dragStarted)
            return;
        //Debug.LogError("zxf draghint base.OnPointerClick");
        base.OnPointerClick(eventData);
    }

    protected virtual void OnHintDragStart(PointerEventData eventData)
    {
        DraggedObj.position = GetWorldPos(eventData);
        DraggedObj.gameObject.SetActive(true);
    }

    protected virtual void OnHintDrag(PointerEventData eventData)
    {
        DraggedObj.position = GetWorldPos(eventData);
    }

    protected virtual void OnHintDragEnd(PointerEventData eventData)
    {
        DraggedObj.gameObject.SetActive(false);
    }

    /// <summary>
    /// 将点击点转换成世界坐标
    /// </summary>
    /// <param name="eventData"></param>
    /// <returns></returns>
    protected Vector3 GetWorldPos(PointerEventData eventData)
    {
        if (eventData.enterEventCamera == null)
        {
            Vector3 pos1 = FindObjectOfType<GameRoot>().transform.GetChild(0).GetComponent<Camera>()
                .ScreenToWorldPoint(eventData.position);
            pos1.z = 0;
            return pos1;
        }

        Vector3 pos = eventData.enterEventCamera.ScreenToWorldPoint(eventData.position);
        pos.z = 0;
        return pos;
    }

    /// <summary>
    /// 将点击点转换成世界坐标
    /// </summary>
    /// <param name="eventData"></param>
    /// <returns></returns>
    protected Vector2 GetWorldPos2(PointerEventData eventData)
    {
        Vector3 pos = GetWorldPos(eventData);
        return new Vector2(pos.x, pos.y);
    }

    /// <summary>
    /// 点击位置是否在格子展示区域内
    /// </summary>
    /// <param name="eventData"></param>
    /// <returns></returns>
    protected bool IsPointerInCellsRect(PointerEventData eventData)
    {
        RectTransform viewport = skillManager.CellManager.scrollViewport;
        return RectTransformUtility.RectangleContainsScreenPoint(viewport, eventData.position,
            eventData.enterEventCamera);
        // Vector2 viewportPos = RectTransformUtility.WorldToScreenPoint(eventData.enterEventCamera, viewport.position);
        // float height = viewport.rect.height;
        // float top = viewportPos.y + (1 - viewport.pivot.y) * height;
        // float bottom = viewportPos.y - viewport.pivot.y * height;
        // return eventData.position.y < top && eventData.position.y > bottom;
    }

    /// <summary>
    /// 展示顶部提示面板
    /// </summary>
    protected virtual void ShowTopTip()
    {
        if (topTipWindow != null)
            return;
        //UIManager.OpenUIAsync(ViewConst.prefab_HintTopTips, OpenType.Replace, (UIWindowBase UI, object[] objs) =>
        //{
        //    topTipWindow = UI;
        //}, this);
        topTipWindow = UIManager.OpenUIWindow(ViewConst.prefab_HintNotice,
            null, null, null, OpenType.Replace, this);
    }

    /// <summary>
    /// 隐藏顶部提示面板
    /// </summary>
    protected virtual void HideTopTip()
    {
        if (topTipWindow != null)
        {
            topTipWindow.Close();
            topTipWindow = null;
        }
    }

    protected override void OnHintStart()
    {
        base.OnHintStart();
        //LoggerHelper.Error("zxf draghint OnHintStart");
        ShowTopTip();
    }

    protected override void OnHintEnd()
    {
        //LoggerHelper.Error("zxf draghint OnHintEnd");
        base.OnHintEnd();
        HideTopTip();
    }
}