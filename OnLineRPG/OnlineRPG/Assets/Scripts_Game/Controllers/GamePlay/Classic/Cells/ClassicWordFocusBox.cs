using UnityEngine;
using System.Collections;
using DG.Tweening;
using System.Collections.Generic;

public class ClassicWordFocusBox : BaseWordFocusBox
{
    private List<GameObject> themeWordFocusList = null;
    private List<PartCell> parts = null;
    private BaseWord lastThemeWord = null;

    public override void Init(float cellSize)
    {
        base.Init(cellSize);
        if (themeWordFocusList != null)
        {
            for (int i = themeWordFocusList.Count - 1; i >= 0; i--)
            {
                Destroy(themeWordFocusList[i]);
            }
            themeWordFocusList.Clear();
            themeWordFocusList = null;
            parts = null;
        }
    }

    public override void MoveTo(BaseWord word, bool ani = false)
    {
        if (word is ClassicThemeWord)
        {
            if (lastThemeWord == word)
                return;
            lastThemeWord = word;
            gameObject.SetActive(true);

            if (parts == null)
            {
                parts = new List<PartCell>();
                PartCell lastPart = null;
                word.Cells.ForEach(cell => {
                    if (lastPart == null || lastPart.firstCell.ColIndex != cell.ColIndex)
                    {
                        lastPart = new PartCell();
                        lastPart.firstCell = cell;
                        parts.Add(lastPart);
                    }
                    lastPart.cellCount++;
                });
            }
            
            if (ani)
            {
                transform.DOMove(word.GetFirstCellPos(), 0.3f);
                content.DOSizeDelta(new Vector2(rectTransform.sizeDelta.x , word.GetCellCount() * cellSize + padding * 2), 0.3f);
            }
            else
            {
                transform.position = word.GetFirstCellPos();
                content.sizeDelta = new Vector2(rectTransform.sizeDelta.x, parts[0].cellCount * (cellSize + 20) - 20 + padding * 2);
            }

            if (themeWordFocusList == null)
            {
                themeWordFocusList = new List<GameObject>();
                
                RectTransform lastFocusBox = content;
                for (int i = 1; i < parts.Count; i++)
                {
                    GameObject focusBox = Instantiate(lastFocusBox.gameObject, content.parent, true);
                    focusBox.SetActive(false);
                    float colOffset = (parts[i].firstCell.ColIndex - parts[i-1].firstCell.ColIndex) * cellSize;
                    float rowOffset = parts[i - 1].cellCount * (cellSize + 20);
                    RectTransform curFocusBox = focusBox.GetComponent<RectTransform>();
                    curFocusBox.localPosition += new Vector3(colOffset, -rowOffset, 0);
                    curFocusBox.sizeDelta = new Vector2(rectTransform.sizeDelta.x, parts[i].cellCount * (cellSize + 20) - 20 + padding * 2);
                    themeWordFocusList.Add(focusBox);
                    lastFocusBox = curFocusBox;
                }
            }
            ShowThemeFocusBox(true);
            return;
        }
        lastThemeWord = null;
        ShowThemeFocusBox(false);

        base.MoveTo(word, ani);
    }

    private void ShowThemeFocusBox(bool show)
    {
        if (themeWordFocusList != null)
        {
            themeWordFocusList.ForEach(obj => obj.SetActive(show));
        }

        if (show)
        {
            for (int i = 0; i < wordSpit.Count; i++)
            {
                wordSpit[i].gameObject.SetActive(false);
            }
        }
    }

    class PartCell
    {
        public BaseCell firstCell = null;
        public int cellCount = 0;
    }
}
