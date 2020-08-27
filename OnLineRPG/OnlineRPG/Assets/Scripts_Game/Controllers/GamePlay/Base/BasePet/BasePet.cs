using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePet : GameEntity
{
    public virtual void ShowAnswerTip(string answer)
    {
        
    }

    public virtual void ShowCellTip(string cellAnswer)
    {
        
    }

    public virtual void ShowPetTip(PetTip type)
    {
        switch (type)
        {
            case PetTip.Type1:
                break;
            case PetTip.Type2:
                break;
            case PetTip.Type3:
                break;
            case PetTip.Type4:
                break;
        }
    }

    public virtual void CloseCellTip()
    {
        
    }

    public virtual void CloseAnswerTip()
    {
        
    }
    
    public virtual void HintUse()
    {
        
    }

    public virtual void HintEnd()
    {
        
    }
}

public enum PetTip
{
    /// <summary>
    /// 都打错了使用
    /// </summary>
    Type1,
    /// <summary>
    /// 符合了答对大部分逻辑的调价
    /// </summary>
    Type2,
    /// <summary>
    /// 出现了提示单个字母的cell
    /// </summary>
    Type3,
    /// <summary>
    /// 一口气全答对的音效,中间没有出现过任何提示的那种
    /// </summary>
    Type4
}
