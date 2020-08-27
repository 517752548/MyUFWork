using DG.Tweening;
using EventUtil;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// 字母格子类
/// </summary>
public class BaseCell : MonoBehaviour
{
    protected const ushort Flag_Disable = 0x0001; //未使用
    protected const ushort Flag_Normal = 0x0002; //正常状态
    protected const ushort Flag_Focus = 0x0004; //获得焦点待输入状态
    protected const ushort Flag_HintSel = 0x0008; //被hint选中状态
    protected const ushort Flag_Wrong = 0x0010; //答案词错误状态
    protected const ushort Flag_WordSel = 0x0020; //父级单词被选中状态
    protected const ushort Flag_WordCompleted = 0x0040; //父级单词已完成
    public RectTransform content;
    public Image bgImage;
    public CellLetter letterText;

    public Color FilledTextColor, InputTextColor, WrongTextColor, HintSelTextColor;

    public Sprite
        bg_sprite_disable,
        bg_sprite_normal,
        bg_sprite_focus,
        bg_sprite_error,
        bg_sprite_hint_select; //, bg_sprite_hint2;

    public GameObject EffectPrefab_Correct,
        EffectPrefab_Trail,
        EffectPrefab_Hint1,
        EffectPrefab_Hint3,
        EffectPrefab_Hint4,
        EffectPrefab_Hint4Correct,
        EffectPrefab_Hint4End;

    public CanvasGroup _CanvasGroup;
    public int ColIndex { get; private set; }
    public CellState State { get; protected set; }
    public Animator cellAnimator;
    protected ushort bgFlag;

    public GameObject beFlyToFlag;
    public BaseCell FlyToCell;

    protected BaseCellManager cellManager;
    [SerializeField] protected string answerLetter;
    protected string inputLetter;
    protected BaseNormalWord normalWord;
    protected float effectScale = 1f;
    protected float cellSize;
    protected CheckAnswerResult _checkAnswerResult;

    public void SetBeFlyToFlag(bool show)
    {
        beFlyToFlag.SetActive(show);
    }

    public BaseCellManager CellManager
    {
        get { return cellManager; }
    }

    public virtual void Init(BaseCellManager cellManager, string answerLetter, int index, float cellSize)
    {
        this.cellSize = cellSize;
        ColIndex = index;
        this.cellManager = cellManager;
        this.answerLetter = answerLetter;
        inputLetter = null;
        State = string.IsNullOrEmpty(answerLetter) ? CellState.none : CellState.normal;
        bgFlag = State == CellState.none ? Flag_Disable : Flag_Normal;
        normalWord = null;
        content.offsetMax = new Vector2(0, -10); //left top
        content.offsetMin = new Vector2(0, 10); //right bottom
        // RectTransform letterRT = letterText.GetComponent<RectTransform>();
        // letterRT.anchorMin = Vector2.one * 0.5f;
        // letterRT.anchorMax = Vector2.one * 0.5f;
        // letterRT.sizeDelta = Vector3.one * 0.7f * cellSize;
        letterText.SetSize(Vector3.one * cellSize * (cellManager.RowCellCount > 9 ? 0.68f : 0.62f));

        //增加Collider，使格子可以被射线检测到
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<BoxCollider2D>();
            gameObject.tag = "cell";
            collider.size = Vector2.one * cellSize;
        }

        effectScale = cellManager.effectScale;
        beFlyToFlag.SetActive(false);
    }

    public virtual void SetParentWord(BaseWord word)
    {
        if (word is BaseNormalWord)
            normalWord = word as BaseNormalWord;
        UpdateContent();
    }

    public float CellSize => cellSize;

    public virtual void Refresh()
    {
        UpdateContent();
        SetWordSelected(cellManager.IsCurWord(normalWord), normalWord);
    }

    /// <summary>
    /// 更新格子显示内容
    /// </summary>
    protected virtual void UpdateContent()
    {
        switch (State)
        {
            case CellState.none:
                letterText.text = "";
                break;
            case CellState.normal:

                if (AppEngine.SGameSettingManager.ShowAnswer.Value)
                {
                    letterText.text = answerLetter;
                    letterText.color = Color.green;
                }
                else
                {
                    letterText.text = "";
                }

                break;
            case CellState.filled:
                letterText.text = answerLetter;
                letterText.color = FilledTextColor;
                break;
            case CellState.inputted:
                letterText.text = inputLetter;
                letterText.color = InputTextColor;
                break;
        }

        if ((bgFlag & Flag_Disable) > 0)
        {
            bgImage.sprite = bg_sprite_disable;
        }
        else if ((bgFlag & Flag_Wrong) > 0)
        {
            letterText.color = WrongTextColor;
            bgImage.sprite = bg_sprite_error;
        }
        else if ((bgFlag & Flag_WordCompleted) > 0)
        {
            bgImage.sprite = bg_sprite_disable;
            letterText.color = InputTextColor;
        }
        else if ((bgFlag & Flag_HintSel) > 0)
        {
            letterText.color = HintSelTextColor;
            bgImage.sprite = bg_sprite_hint_select;
        }
        else if ((bgFlag & Flag_Focus) > 0)
        {
            bgImage.sprite = bg_sprite_focus;
        }
        else if ((bgFlag & Flag_Normal) > 0)
        {
            bgImage.sprite = bg_sprite_normal;
        }
    }

    /// <summary>
    /// 输入字母，输入字母为空时代表删除操作
    /// </summary>
    /// <param name="letter">输入字母</param>
    public virtual void InputLetter(string letter)
    {
        if (State == CellState.none)
            return;

        inputLetter = letter;
        if (string.IsNullOrEmpty(letter))
        {
            if (State == CellState.normal || State == CellState.filled)
            {
                normalWord.OnCellLetterDel(this);
            }
            else
            {
                State = CellState.normal;
            }
        }
        else
        {
            if (State != CellState.filled)
                State = CellState.inputted;
            CheckAnswer();
            FocusToNextCell();
        }

        UpdateContent();
    }

    /// <summary>
    /// 输入后检查格子所属word是否完成
    /// </summary>
    public virtual void CheckAnswer()
    {
        _checkAnswerResult = CheckAnswerResult.none;
        if (normalWord.IsComplete)
            return;
        _checkAnswerResult = normalWord.CheckAnswer(false);
    }

    public virtual void FocusToNextCell(bool ignoreSwitch = false)
    {
        if (normalWord.IsComplete)
            return;
        if (IsWordSelected && _checkAnswerResult == CheckAnswerResult.miss)
            normalWord.FocusNextCell(this, ignoreSwitch);
    }

    /// <summary>
    /// 设置格子为已输入状态（初始化时使用）
    /// </summary>
    /// <param name="letter"></param>
    internal void SetInput(string letter)
    {
        if (State == CellState.none)
            return;
        State = CellState.inputted;
        inputLetter = letter;
        UpdateContent();
    }

    /// <summary>
    /// 重置格子为normal状态
    /// </summary>
    public void ResetToNormalState()
    {
        if (State == CellState.none)
            return;
        if (State == CellState.filled)
        {
            return;
        }

        State = CellState.normal;
        inputLetter = "";
        UpdateContent();
    }

    /// <summary>
    /// 改变格子状态为已填充
    /// </summary>
    public virtual void SetFilled()
    {
        if (State == CellState.none)
            return;
        State = CellState.filled;
        if (FlyToCell != null && FlyToCell.State == CellState.filled)
            FlyToCell.SetBeFlyToFlag(false);
        if (cellManager.CurCell == this)
            cellManager.SetCurCell(null);
        UpdateContent();
    }

    /// <summary>
    /// 完成一个答案后飞出字母填充该格子
    /// </summary>
    public virtual void AutoHintFill()
    {
        SetFilled();
        normalWord.HintCount++;
        PlayCorrectAni();
        //AutoHintFillCheckAnswer();
    }

    public virtual void AutoHintFillCheckAnswer()
    {
        if (normalWord.IsComplete)
            return;
        normalWord.CheckAnswer(false);
    }

    public virtual void Hint2Filed()
    {
        KeyBoard me = (KeyBoard) Enum.Parse(typeof(KeyBoard), answerLetter);
        KeyboardOneKey target = null;
        for (int i = 0; i < CellManager.GameManager.GetEntity<BaseKeyBoard>()._KeyboardOneKeys.Length; i++)
        {
            if (CellManager.GameManager.GetEntity<BaseKeyBoard>()._KeyboardOneKeys[i]._key == me)
            {
                target = CellManager.GameManager.GetEntity<BaseKeyBoard>()._KeyboardOneKeys[i];
                break;
            }
        }

        if (target != null)
        {
            ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_KeyboardCellFly, op =>
            {
                GameObject prefab = Instantiate(op, MainSceneDirector.Instance.GetUIRoot(GameUI.Game).transform, false);
                prefab.transform.Find("LetterBox/Text").GetComponent<Text>().text = answerLetter;
                prefab.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, 0);
                RectTransform transfor = prefab.GetComponent<RectTransform>();
                transfor.sizeDelta = new Vector2(cellSize, cellSize + 20);
                prefab.transform.DOMove(transform.position, 1f).SetDelay(1);
                prefab.transform.DOScale(Vector3.one, 0.6f).SetDelay(1);
                TimersManager.SetTimer(1.9f, () =>
                {
                    PlayCorrectAni(() => { AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_AutoHintFill); });
                    SetFilled();
                    CheckAnswer();
                    FocusToNextCell(true);
                    CellManager.CacheLevelProgress();
                });
                Destroy(prefab, 2.2f);
            });
        }
    }

    /// <summary>
    /// 设置所属单词是否被选中
    /// </summary>
    /// <param name="sel"></param>
    public virtual void SetWordSelected(bool sel, BaseWord word)
    {
        //isWordSelected = sel;
        //BgState = isWordSelected ? CellBgState.wordSel : CellBgState.normal;
        if (sel)
            bgFlag |= Flag_WordSel;
        else if ((bgFlag & Flag_WordSel) > 0)
            bgFlag ^= Flag_WordSel;
        //UpdateContent();
        if (FlyToCell != null && word is BaseNormalWord)
        {
            if (!word.IsComplete && AppEngine.SGameSettingManager.MarkFlyCell.Value)
            {
                if (State == CellState.filled && FlyToCell.State == CellState.filled)
                    FlyToCell.SetBeFlyToFlag(false);
                else
                    FlyToCell.SetBeFlyToFlag(sel);
            }
            else
                FlyToCell.SetBeFlyToFlag(false);
        }
    }

    public virtual void SetWordCompleted(BaseWord word)
    {
        bgFlag |= Flag_WordCompleted;
        UpdateContent();
    }

    public bool CellInputRight()
    {
        if (inputLetter == answerLetter && State == CellState.inputted)
        {
            return true;
        }

        return false;
    }

    public void WordNearRight()
    {
        if (State == CellState.none)
            return;
        if (inputLetter == answerLetter || State == CellState.filled)
        {
            if (cellAnimator != null)
            {
                cellAnimator.SetTrigger("correct");
            }

            SetFilled();
        }
        else
        {
            if (cellAnimator != null)
            {
                cellAnimator.SetTrigger("wrong");
            }

            if (State != CellState.filled)
            {
                if (!AppEngine.SGameSettingManager.EraseWrongWord.Value)
                {
                }
                else
                {
                    TimersManager.SetTimer(0.5f, () =>
                    {
                        State = CellState.normal;
                        UpdateContent();
                    });
                }
            }
        }
    }

    public void SplitWordRight(bool right)
    {
        if (State == CellState.none)
            return;
        if (right)
        {
            cellAnimator.SetTrigger("correct");
            SetFilled();
        }
        else if (State == CellState.filled)
        {
            cellAnimator.SetTrigger("correct");
            SetFilled();
        }
        else
        {
            cellAnimator.SetTrigger("wrong");
            if (State != CellState.filled)
            {
                if (!AppEngine.SGameSettingManager.EraseWrongWord.Value)
                {
                }
                else
                {
                    TimersManager.SetTimer(0.5f, () =>
                    {
                        State = CellState.normal;
                        UpdateContent();
                    });
                }
            }
        }
    }

    /// <summary>
    /// 设置格子是否处于词条输入错误状态
    /// </summary>
    /// <param name="isWrong"></param>
    public void SetWrongState(bool isWrong)
    {
        if (State == CellState.none)
            return;
        if (isWrong)
        {
            bgFlag |= Flag_Wrong;
        }
        else
        {
            if ((bgFlag & Flag_Wrong) > 0)
                bgFlag ^= Flag_Wrong;
            if (State != CellState.filled)
            {
                State = CellState.normal;
                inputLetter = "";
            }
        }

        UpdateContent();
    }

    /// <summary>
    /// 响应格子点击
    /// </summary>
    public virtual void OnClick()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_clickwordcell);
        if (State == CellState.none)
        {
            if (!IsWordSelected)
            {
                normalWord.SetSelect(true);
                //AppEngine.SSoundManager.PlaySFX(ViewConst.wav_clickwordcell);
            }

            return;
        }

        cellManager.LastClickCell = this;

        //if (!AppEngine.SGameSettingManager.SkipFilledSquares.Value || State != CellState.filled)
        //    SetFocus(true);
        if (!AppEngine.SGameSettingManager.SelectFirstSolt.Value && State != CellState.filled)
            SetFocus(true);
        if (!IsWordSelected)
        {
            normalWord.SetSelect(true);
            //AppEngine.SSoundManager.PlaySFX(ViewConst.wav_clickwordcell);
        }
        else if (AppEngine.SGameSettingManager.SelectFirstSolt.Value)
        {
            normalWord.FocusFirstCanInputCell();
        }
    }

    /// <summary>
    /// 设置焦点。焦点所在格子才能输入
    /// </summary>
    /// <param name="focus"></param>
    public virtual void SetFocus(bool focus)
    {
        if (focus)
            bgFlag |= Flag_Focus;
        else if ((bgFlag & Flag_Focus) > 0)
            bgFlag ^= Flag_Focus;
        if (focus)
            cellManager.SetCurCell(this);
        UpdateContent();
    }

    /// <summary>
    /// 修改格子被hint选中状态
    /// </summary>
    /// <param name="sel">是否被选中</param>
    public void HintSel(bool sel)
    {
        if (State == CellState.none)
            return;
        if (sel)
            bgFlag |= Flag_HintSel;
        else if ((bgFlag & Flag_HintSel) > 0)
            bgFlag ^= Flag_HintSel;
        UpdateContent();
    }

    /// <summary>
    /// 展示的字母
    /// </summary>
    public string Letter
    {
        get
        {
            switch (State)
            {
                case CellState.filled:
                    return answerLetter;
                case CellState.inputted:
                    return inputLetter;
                default:
                    return "";
            }
        }
    }

    /// <summary>
    /// 是否填充了正确字母
    /// </summary>
    public bool IsRight
    {
        get
        {
            switch (State)
            {
                case CellState.filled:
                    return true;
                case CellState.inputted:
                    return !string.IsNullOrEmpty(inputLetter) && inputLetter.Equals(answerLetter);
                default:
                    return false;
            }
        }
    }

    /// <summary>
    /// 正确答案字母
    /// </summary>
    public char AnswerLetter
    {
        get { return answerLetter[0]; }
    }

    /// <summary>
    /// 所属行word
    /// </summary>
    public virtual BaseWord ParentWord
    {
        get { return normalWord; }
    }

    public virtual bool IsInSameWord(BaseCell cell)
    {
        return normalWord == cell.normalWord;
    }

    public bool IsWordSelected
    {
        get { return (bgFlag & Flag_WordSel) > 0; }
    }

    public bool IsFocused
    {
        get { return (bgFlag & Flag_Focus) > 0; }
    }

    public virtual BaseCell Clone()
    {
        GameObject obj = Instantiate(gameObject, transform.parent.parent, true);
        for (int i = obj.transform.childCount - 1; i > 0; i--)
        {
            Destroy(obj.transform.GetChild(i).gameObject);
        }

        obj.GetComponent<RectTransform>().sizeDelta = gameObject.GetComponent<RectTransform>().sizeDelta;
        obj.transform.localScale = Vector3.one;
        BaseCell cell = obj.GetComponent<BaseCell>();
        cell.Init(cellManager, answerLetter, ColIndex, cellSize);
        cell.SetFilled();
        cell.bgImage.sprite = bg_sprite_focus;
        return cell;
    }

    protected Transform PlayAni(GameObject prefab, float len, Action callback = null)
    {
        if (prefab == null || prefab.transform == null)
        {
            return null;
        }

        //Transform effect = Instantiate(prefab, transform, false).transform;
        Transform effect = AppEngine.SObjectPoolManager.Spawn(prefab.name, prefab.transform, Vector3.zero,
            default(Quaternion), transform);
        effect.localScale = Vector3.one * effectScale;
        effect.localPosition = Vector3.zero;
        effect.gameObject.SetActive(true);
        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(len);
        seq.AppendCallback(() =>
        {
            //Destroy(effect.gameObject);
            if (effect)
                AppEngine.SObjectPoolManager.Despawn(effect);
            callback?.Invoke();
        });
        return effect;
    }

    public void ShowTrailEffect()
    {
        Transform effect = Instantiate(EffectPrefab_Trail, transform, false).transform;
        //Transform effect = AppEngine.SObjectPoolManager.Spawn(EffectPrefab_Trail.name, EffectPrefab_Trail.transform, Vector3.zero, default(Quaternion), transform);
        effect.localScale = Vector3.one;
        effect.localPosition = Vector3.zero;
        effect.gameObject.SetActive(true);
    }

    public virtual void Disappear(float delay)
    {
    }

    public float PlayCompletedAni(Action callback = null)
    {
        return PlayCorrectAni(() =>
        {
            SetWordCompleted(normalWord);
            callback?.Invoke();
        });
    }

    public float PlayCorrectAni(Action callback = null)
    {
        float len = 0.667f;
        PlayAni(EffectPrefab_Correct, len, callback);
        return len;
    }

    public float PlayHint1Ani(Action callback = null)
    {
        float len = 0.833f;
        PlayAni(EffectPrefab_Hint1, len, callback);
        return len;
    }

    public float PlayHint3Ani(Vector3 startPos, TweenCallback onMoveOver, Action callback = null)
    {
        float len = 1.25f;
        Transform effect = PlayAni(EffectPrefab_Hint3, len, callback);
        effect.position = startPos;
        effect.DOLocalMove(Vector3.zero, 0.5f).OnComplete(onMoveOver);
        return len;
    }

    public float PlayHint4CorrectAni(Action callback = null)
    {
        float len = 0.667f;
        PlayAni(EffectPrefab_Hint4Correct, len, callback);
        return len;
    }

    public float PlayHint4EndAni(Action callback = null)
    {
        float len = 1f;
        PlayAni(EffectPrefab_Hint4End, len, () =>
        {
            SetWordCompleted(normalWord);
            callback?.Invoke();
        });
        return len;
    }

    public float PlayFadeInOut()
    {
        if (State == CellState.filled || State == CellState.none)
            return 0;
        string letter = letterText.text;
        Color color = letterText.color;

        letterText.text = answerLetter;
        letterText.color = new Color(FilledTextColor.r, FilledTextColor.g, FilledTextColor.b, 0);
        Sequence seq = DOTween.Sequence();
        seq.Append(letterText.DOFade(1f, 0.45f));
        seq.Append(letterText.DOFade(0f, 0.45f));
        seq.AppendCallback(() =>
        {
            color.a = 1;
            letterText.color = color;
            letterText.text = letter;
        });
        return 0.9f;
    }
}

public enum CellState
{
    none, //无用格
    normal, //空白格
    filled, //已填充答案字母
    inputted //已输入字母
}