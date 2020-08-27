using System;
using BetaFramework;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts_Game.Controllers.GamePlay.Cross
{
    public class CrossPopupWordPanel : MonoBehaviour
    {
        public Image image;
        public RectTransform content;
        public float maxHeight;
        public float Height;
        public Animator ani;
        public GridLayoutGroup gridLayout;
        public TextMeshProUGUI quesNumText;

        //private ClassicCellManager cellManager = null;
        private Action closeCallback = null;
        private BaseWord curPicWord = null;
        private bool isVisible;
        private Sequence closeAniSeq;

        public void Init()
        {
            Height = -1;
            SetActive(false);
            //this.cellManager = cellManager;
            ani = GetComponent<Animator>();
            ani.enabled = true;
            isVisible = true;
            closeAniSeq = null;
        }

        private void SetActive(bool active)
        {
            gameObject.SetActive(active);
            gridLayout.SetParentActive(active);
        }

        public void SetCloseCallback(Action callback)
        {
            closeCallback = callback;
        }

        public bool Close()
        {
            SetCellMaskVisiable(false);
            if (Height < 0)
                return false;
            //LoggerHelper.Exception(new NotImplementedException("zxf===picBox close " + curPicWord.Answer));
            Height = -1;
            curPicWord = null;
            //gameObject.SetActive(false);
            //closeCallback?.Invoke();
            //ani.enabled = true;
            if (isVisible)
            {
                AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
                ani.SetTrigger("disappear");
                curTrigger = "disappear";
                closeAniSeq = DOTween.Sequence();
                closeAniSeq.AppendInterval(0.25f);
                // seq.AppendCallback(() => {
                //     gameObject.SetActive(false);
                //     closeCallback?.Invoke();
                // });seq.Kill();seq.Complete();
                closeAniSeq.OnComplete(() =>
                {
                    closeAniSeq = null;
                    SetActive(false);
                    closeCallback?.Invoke();
                });
            }
            else
            {
                isVisible = true;
                SetActive(false);
                closeCallback?.Invoke();
            }

            RefreshWordCells();
            return true;
        }

        public void ClickClose()
        {
            Close();
        }

        public void Show(BaseWord word, Sprite sprite)
        {
            curPicWord = word;
            AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_PicBoxOpen);
            float width = sprite.textureRect.width;
            float height = sprite.textureRect.height;
            //Height = height;
            //if (height > maxHeight)
            {
                Height = maxHeight;
                width *= (maxHeight / height);
            }
            content.sizeDelta = new Vector2(width, Height);
            image.sprite = sprite;
            //ani.enabled = true;
            if (closeAniSeq != null)
            {
                closeAniSeq.Kill(true);
                closeAniSeq = null;
            }

            SetActive(true);
            ani.SetTrigger("appear");
            curTrigger = "appear";
            SetCellMaskVisiable(true);
            RefreshWordCells();
        }

        private string curTrigger = "";

        public void SetVisible(bool visible)
        {
            SetCellMaskVisiable(visible);
            if (Height < 0)
                return;
            //LoggerHelper.Exception(new NotImplementedException("zxf===picBox visible " + curPicWord.Answer + " | " + visible));
            //ani.enabled = false;
            //gameObject.transform.localScale = visible ? Vector3.one : Vector3.zero;
            isVisible = visible;
            var trigger = visible ? "show" : "hide";
            // if (trigger.Equals(curTrigger))
            //     return;
            // curTrigger = trigger;
            ani.SetTrigger(trigger);
            gridLayout.SetParentActive(visible);
        }

        public bool IsShown(BaseWord word = null)
        {
            if (word == null)
                return curPicWord != null;
            return curPicWord == word && curPicWord != null;
        }

        public bool IsClosing()
        {
            return Height <= 0 && gameObject.activeSelf;
        }

        public void Hide()
        {
            SetCellMaskVisiable(false);
            if (Height < 0)
                return;
            //LoggerHelper.Exception(new NotImplementedException("zxf===picBox hide " + curPicWord.Answer));
            Height = -1;
            curPicWord = null;
            //gameObject.SetActive(false);
            //closeCallback?.Invoke();
            //ani.enabled = true;
            if (isVisible)
            {
                AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
                ani.SetTrigger("disappear");
                curTrigger = "disappear";
                closeAniSeq = DOTween.Sequence();
                closeAniSeq.AppendInterval(0.25f);
                closeAniSeq.OnComplete(() =>
                {
                    closeAniSeq = null;
                    SetActive(false);
                    //closeCallback?.Invoke();
                });
            }
            else
            {
                isVisible = true;
                SetActive(false);
                //closeCallback?.Invoke();
            }

            RefreshWordCells();
        }

        private void SetCellMaskVisiable(bool visiable)
        {
            if (curPicWord != null)
            {
                curPicWord.CellManager.ShowMask(visiable);
            }
        }

        private void RefreshWordCells()
        {
            int count = gridLayout.transform.childCount;
            for (int i = count - 1; i >= 0; i--)
            {
                gridLayout.transform.GetChild(i).GetComponent<CrossCell>().ReleaseShadow();
            }
            if (curPicWord != null)
            {
                CrossNormalWord word = curPicWord as CrossNormalWord;
                quesNumText.text = word.NumTag;
                gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
                gridLayout.constraintCount = curPicWord.Cells.Count;
                curPicWord.Cells.ForEach(cell =>
                {
                    var shadowCell = (cell as CrossCell).MakeShadow(gridLayout.cellSize.x);
                    shadowCell.transform.SetParent(gridLayout.transform);
                    cell.Refresh();
                });
            }
        }
    }
}