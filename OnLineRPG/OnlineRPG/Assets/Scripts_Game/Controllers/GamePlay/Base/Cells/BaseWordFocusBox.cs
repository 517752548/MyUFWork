using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class BaseWordFocusBox : MonoBehaviour
{
    protected RectTransform rectTransform;
    protected RectTransform content;
    protected float cellSize;
    protected float padding = 10f;
    protected List<GameObject> wordSpit = new List<GameObject>();

    public virtual void Init(float cellSize)
    {
        this.cellSize = cellSize;
        rectTransform = (RectTransform)transform;
        content = (RectTransform)transform.GetChild(0);

        gameObject.SetActive(false);
        rectTransform.sizeDelta = Vector2.one * (cellSize + padding * 2);
        transform.localPosition = Vector3.zero;
    }

    public virtual void MoveTo(BaseWord word, bool ani = false)
    {
        //gameObject.SetActive(true);

        if (ani)
        {
            transform.DOMove(word.GetFirstCellPos(), 0.3f);
            content.DOSizeDelta(new Vector2(word.GetCellCount() * cellSize + padding * 2, rectTransform.sizeDelta.y), 0.3f);
        }
        else
        {
            transform.position = word.GetFirstCellPos();
            content.sizeDelta = new Vector2(word.GetCellCount() * cellSize + padding * 2, rectTransform.sizeDelta.y);
        }

        SetWordSpit(word);
    }

    public virtual void SetWordSpit(BaseWord word)
    {
        for (int i = 0; i < wordSpit.Count; i++)
        {
            if (wordSpit[i].activeSelf)
            {
                wordSpit[i].SetActive(false);
            }
        }
        if (word.wordspit.Length == 0)
        {
            return;
        }

        for (int i = 0; i < word.wordspit.Length; i++)
        {
            if (wordSpit.Count > i)
            {
                wordSpit[i].SetActive(true);
                wordSpit[i].transform.SetParent(transform,false);
                wordSpit[i].transform.DOLocalMoveX(cellSize * (word.wordspit[i] - 0.5f), 0);
                wordSpit[i].GetComponent<WordSpit>().SetSize(cellSize);
            }
            else
            {
                GameObject wordspit =
                    Instantiate(PreLoadManager.GetPreLoad<GameObject>(PreLoadConst.preload_Prefab,ViewConst.prefab_WordSpit));
                wordspit.transform.SetParent(transform,false);
                wordspit.transform.DOLocalMoveX(cellSize * (word.wordspit[i] - 0.5f), 0);
                wordspit.GetComponent<WordSpit>().SetSize(cellSize);
                wordSpit.Add(wordspit);
            }
        }
    }
}
