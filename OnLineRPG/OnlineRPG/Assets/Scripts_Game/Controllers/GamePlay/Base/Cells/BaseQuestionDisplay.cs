using UnityEngine;
using System.Collections;
using BetaFramework;
using TMPro;
using UnityEngine.UI;

public class BaseQuestionDisplay : GameEntity
{
    public Text questionText;
    public GameObject leftBtn, rightBtn;

    protected BaseWord curWord;

    public virtual void Init()
    {
        questionText.text = "";
    }

    public virtual void OnWordChanged(BaseWord word)
    {
        curWord = word;
        if (AppEngine.SGameSettingManager.ShowAnswer.Value)
        {
            questionText.text = string.Format("{0}(<color=red>{1}</color>)",word.GetWordQuestion(),word.Answer);
        }
        else
        {
            questionText.text = string.Format("{0}",word.GetWordQuestion()); 
        }
        
    }

    public virtual void OnClickPrev()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_right_left);
        GameManager.GetEntity<BaseCellManager>().OnClickChangeWord(false);
    }

    public virtual void OnClickNext()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_right_left);
        GameManager.GetEntity<BaseCellManager>().OnClickChangeWord(true);
    }

    /// <summary>
    /// 退场动画结束后调用，隐藏局内高亮UI
    /// </summary>
    public virtual void OnGameCompleted()
    {
        
    }
}
