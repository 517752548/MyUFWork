using DG.Tweening;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.Cross
{
    public class CrossWordFocusBox : BaseWordFocusBox
    {
        public override void MoveTo(BaseWord word, bool ani = false)
        {
            var isHorizontal = (word as CrossNormalWord).IsHorizontal;
            var _size = word.GetCellCount() * cellSize + padding * 2;
            var size = isHorizontal ? new Vector2(_size, rectTransform.sizeDelta.y) : new Vector2(rectTransform.sizeDelta.x, _size);
            if (ani)
            {
                transform.DOMove(word.GetFirstCellPos(), 0.3f);
                content.DOSizeDelta(size, 0.3f);
            }
            else
            {
                transform.position = word.GetFirstCellPos();
                content.sizeDelta = size;
            }

            SetWordSpit(word);
        }
    }
}