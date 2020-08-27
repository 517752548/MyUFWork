using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClassicQuestionDisplay : BaseQuestionDisplay
{
    public GameObject imageContent;
    public RectTransform imageRect;
    public Image questionImage;
    public ClassicWordPicBox picBox;

    public override void Init()
    {
        base.Init();
        imageContent.SetActive(false);
        picBox.Init();
        picBox.SetCloseCallback(OnPicBoxClosed);
    }

    public override void OnWordChanged(BaseWord word)
    {
        bool wordChanged = (word != curWord);
        
        base.OnWordChanged(word);
        if (word != null && word is ClassicNormalWord)
        {
            ClassicNormalWord classicNormalWord = word as ClassicNormalWord;
            if (classicNormalWord.Question.ImageSprite != null)
            {
                if (!wordChanged)
                    return;
                float width = classicNormalWord.Question.ImageSprite.textureRect.width;
                float height = classicNormalWord.Question.ImageSprite.textureRect.height;
                float viewH = imageRect.sizeDelta.y;
                float viewW = width / height * viewH;
                imageRect.sizeDelta = new Vector2(viewW, viewH);
                questionImage.sprite = classicNormalWord.Question.ImageSprite;
                imageContent.SetActive(true);

                if (!classicNormalWord.IsComplete)
                    ShowPicBox(classicNormalWord);

                return;
            }
        }
        if (!picBox.Close())
            OnPicBoxClosed();
        imageContent.SetActive(false);
    }
    
    public void OnPicBoxClosed()
    {
        GameManager.GetEntity<ClassicCellManager>().ChangeScrollRect(0);
    }

    private void ShowPicBox(ClassicNormalWord word)
    {
        if (word == null || word.Question.ImageSprite == null)
        {
            picBox.Close();
            return;
        }
        if (picBox.IsShown(word))
            return;
        picBox.Show(word, word.Question.ImageSprite);
        GameManager.GetEntity<ClassicCellManager>().ChangeScrollRect(picBox.Height + 40);
    }

    public void OnClickQuestionImage()
    {
        if (picBox.IsShown())
        {
            picBox.Close();
            return;
        }
        ShowPicBox(curWord as ClassicNormalWord);
    }

    public override void OnGameCompleted()
    {
        base.OnGameCompleted();
        if (picBox.IsShown())
        {
            picBox.SetVisible(false);
            return;
        }
    }

    public bool ClosePicBox()
    {
        if (picBox.IsShown())
        {
            picBox.Close();
            return true;
        }
        return false;
    }

    public override void OnClickNext()
    {
        base.OnClickNext();
    }

    public override void OnClickPrev()
    {
        base.OnClickPrev();
    }

    public void OnCompleteOneWord(BaseWord word)
    {
        if (word != null && word is ClassicNormalWord && curWord == word)
        {
            //ClosePicBox();
            if (picBox.IsShown())
            {
                //picBox.SetVisible(false);
                picBox.Hide();
            }
        }
    }
}
