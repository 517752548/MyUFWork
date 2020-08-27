using BetaFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts_Game.Controllers.GamePlay.Cross
{
    public class CrossQuestionDisplay : BaseQuestionDisplay
    {
        public GameObject imageContent;
        public RectTransform imageRect;
        public Image questionImage;
        public CrossPopupWordPanel picBox;

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
            if (word != null && word is CrossNormalWord)
            {
                CrossNormalWord crossNormalWord = word as CrossNormalWord;
                if (crossNormalWord.Question.ImageSprite != null)
                {
                    if (!wordChanged)
                        return;
                    float width = crossNormalWord.Question.ImageSprite.textureRect.width;
                    float height = crossNormalWord.Question.ImageSprite.textureRect.height;
                    float viewH = imageRect.sizeDelta.y;
                    float viewW = width / height * viewH;
                    imageRect.sizeDelta = new Vector2(viewW, viewH);
                    questionImage.sprite = crossNormalWord.Question.ImageSprite;
                    imageContent.SetActive(true);

                    if (!crossNormalWord.IsComplete)
                        ShowPicBox(crossNormalWord);

                    return;
                }
            }

            if (!picBox.Close())
                OnPicBoxClosed();
            imageContent.SetActive(false);
        }

        public void OnPicBoxClosed()
        {
            
        }

        private void ShowPicBox(CrossNormalWord word)
        {
            if (word == null || word.Question.ImageSprite == null)
            {
                picBox.Close();
                return;
            }

            if (picBox.IsShown(word))
                return;
            picBox.Show(word, word.Question.ImageSprite);
        }

        public void OnClickQuestionImage()
        {
            if (picBox.IsShown())
            {
                picBox.Close();
                return;
            }

            ShowPicBox(curWord as CrossNormalWord);
        }

        public void OnClickQuestion()
        {
            curWord.CellManager.CurCell.OnClick();
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
            if (word != null && word is CrossNormalWord && curWord == word)
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
}