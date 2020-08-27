using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using BetaFramework;
using TMPro;

public class DailyQuestionDisplay : BaseQuestionDisplay
{
    public Image categotyImage;
    public TextMeshProUGUI categotyTitleText;
    public Sprite[] categotyIcons;

    public override void Init()
    {
        base.Init();
        categotyImage.gameObject.SetActive(false);
    }

    public override void OnWordChanged(BaseWord word)
    {
        base.OnWordChanged(word);
        if (word != null)
        {
            WordCategoryEntity cate = AppEngine.SSystemManager.GetSystem<WordCategorySystem>()
                .GetCategory((word as BaseNormalWord).BaseQuestion.CategoryID);
            if (cate != null)
            {
                categotyImage.sprite = cate.Icon;
                categotyImage.gameObject.SetActive(true);
                categotyTitleText.text = cate.Name;
            }
        }
    }

    public void ClickDailyIcon()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
    }
}
