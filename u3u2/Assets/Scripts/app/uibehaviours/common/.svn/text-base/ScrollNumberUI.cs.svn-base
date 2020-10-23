using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ScrollNumberUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public ScrollRect scroller;
    public GridLayoutGroup grid;
    public Text defaultText;

    private List<Text> mTotalTexts = new List<Text>();
    private int[] mTotalNumbers = null;
    private int mMinNumber = 0;
    private int mMinNumberIdx = 0;
    private int mMaxNumber = 0;
    private int mMAxNumberIdx = 0;
    private int mHideNumbersCount = 0;
    private int mVisibleCount = 0;
    private int mCurNumber = 0;
    private bool mInited = false;
    private Tweener mMoveTweener = null;
    private float mDownPointY = 0;
    private float mUpPointY = 0;
    private bool lastMoveIsUp = false;

    public void Init()
    {
        scroller = GetComponent<ScrollRect>();
        grid = transform.Find("container").GetComponent<GridLayoutGroup>();
        defaultText = transform.Find("container/Text").GetComponent<Text>();
        defaultText.gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData e)
    {
        //按下。
        if (mMoveTweener != null)
        {
            if (!mMoveTweener.IsComplete())
            {
                mMoveTweener.Pause();
                mMoveTweener.Kill();
                mMoveTweener = null;
            }
        }

        mDownPointY = e.position.y;
    }

    public void OnPointerUp(PointerEventData e)
    {
        //松开。
        mUpPointY = e.position.y;
        float moveStartPos = grid.gameObject.transform.localPosition.y;
        float moveEndPos = moveStartPos;
        float moveTime = 0;
        float posY = moveStartPos;
        float startY = posY - mVisibleCount * grid.cellSize.y / 2.0f;
        
        if (posY > (mVisibleCount * grid.cellSize.y / 2.0f) && posY < (grid.cellSize.y * (mTotalTexts.Count - mHideNumbersCount) - mVisibleCount * grid.cellSize.y / 2.0f))
        {
            //当前位置没越位，可以继续滚动。
            if (mUpPointY != mDownPointY)
            {
                //发生了滑动操作。
                float speed = e.delta.y / 100.0f;
                float delta = Time.fixedDeltaTime;

                if (speed > 0)
                {
                    //往上推。
                    float time = speed / 0.01f;
                    float dist = speed * time - 0.5f * 0.01f * time * time;
                    dist *= 100;
                    dist = startY + dist;
                    int num = Mathf.RoundToInt(dist / grid.cellSize.y);
                    dist = (num * grid.cellSize.y - startY) + grid.cellSize.y / 2.0f;
                    moveEndPos = startY + dist;
                    moveTime = time * delta;
                }
                else if (speed < 0)
                {
                    //往下拉。
                    float time = -speed / 0.01f;
                    float dist = -speed * time - 0.5f * 0.01f * time * time;
                    dist *= -100;
                    dist = startY + dist;
                    int num = Mathf.RoundToInt(dist / grid.cellSize.y);
                    dist = (num * grid.cellSize.y - startY) - grid.cellSize.y / 2.0f;
                    moveEndPos = startY + dist;
                    moveTime = time * delta;
                }
                else
                {
                    if (mUpPointY > mDownPointY)
                    {
                        //往上推。
                        if (startY < grid.cellSize.y * (mTotalTexts.Count - mHideNumbersCount))
                        {
                            float rest = startY % grid.cellSize.y;
                            moveEndPos = startY - rest + mVisibleCount * grid.cellSize.y / 2.0f;
                            if (rest > grid.cellSize.y / 2.0f)
                            {
                                moveEndPos += grid.cellSize.y;
                            }

                            moveTime = rest / 75.0f;
                        }
                    }
                    else
                    {
                        //往下拉。
                        if (startY > 0)
                        {
                            float rest = startY % grid.cellSize.y;
                            moveEndPos = startY - rest + grid.cellSize.y + mVisibleCount * grid.cellSize.y / 2.0f;
                            if (rest < grid.cellSize.y / 2.0f)
                            {
                                moveEndPos -= grid.cellSize.y;
                            }

                            moveTime = rest / 75.0f;
                        }
                    }
                }
            }
            else
            {
                //按下和松开是同一点。
                if (lastMoveIsUp)
                {
                    //上一次滑动是向上。
                    if (startY < grid.cellSize.y * (mTotalTexts.Count - mHideNumbersCount))
                    {
                        float rest = startY % grid.cellSize.y;
                        moveEndPos = startY - rest + mVisibleCount * grid.cellSize.y / 2.0f;
                        if (rest > grid.cellSize.y / 2.0f)
                        {
                            moveEndPos += grid.cellSize.y;
                        }
    
                        moveTime = rest / 75.0f;
                    }
                }
                else
                {
                    //上一次滑动是向下。
                    if (startY > 0)
                    {
                        float rest = startY % grid.cellSize.y;
                        moveEndPos = startY - rest + grid.cellSize.y + mVisibleCount * grid.cellSize.y / 2.0f;
                        if (rest < grid.cellSize.y / 2.0f)
                        {
                            moveEndPos -= grid.cellSize.y;
                        }
    
                        moveTime = rest / 75.0f;
                    }
                }
            }
    
            if (moveEndPos != moveStartPos)
            {
                float gridInitY = mVisibleCount * grid.cellSize.y / 2.0f;
                if (moveEndPos < gridInitY)
                {
                    moveEndPos = gridInitY;
                    moveTime = gridInitY / (gridInitY - moveEndPos + gridInitY) * moveTime;
                }
                else if (moveEndPos - gridInitY + mVisibleCount * grid.cellSize.y > ((mTotalTexts.Count - mHideNumbersCount) + mVisibleCount / 2 - 1) * grid.cellSize.y)
                {
                    float oldMoveEndPos = moveEndPos;
                    moveEndPos = ((mTotalTexts.Count - mHideNumbersCount) + mVisibleCount / 2 - 1) * grid.cellSize.y - mVisibleCount * grid.cellSize.y + gridInitY;
                    moveTime = moveEndPos / oldMoveEndPos * moveTime;
                }
                
                float moveDist = moveEndPos - moveStartPos;
                float absDist = Mathf.Abs(moveDist);
                
                if (absDist > 600)
                {
                    float tmp = (int)((absDist - 600) / grid.cellSize.y) * grid.cellSize.y;
                    if (moveDist < 0)
                    {
                        moveDist += tmp;
                    }
                    else
                    {
                        moveDist -= tmp;
                    }
                    moveEndPos = moveStartPos + moveDist;
                }
                
                if (moveTime > 0.5f)
                {
                    moveTime = 0.5f;
                }
                mMoveTweener = grid.transform.DOLocalMoveY(moveEndPos, moveTime).SetEase(Ease.OutCirc).OnComplete(OnFirstMoveComplete);
                lastMoveIsUp = moveEndPos > grid.gameObject.transform.localPosition.y;
                
                int index = (int)((moveEndPos - gridInitY) / grid.cellSize.y);
                if (index < 0)
                {
                    index = 0;
                }
                int finalIdx = index + mMinNumberIdx;
                if (finalIdx >= mTotalNumbers.Length)
                {
                    finalIdx = mTotalNumbers.Length - 1;
                }
                mCurNumber = mTotalNumbers[finalIdx];
            }
        }
        else
        {
            if (posY <= (mVisibleCount * grid.cellSize.y / 2.0f))
            {
                mCurNumber = mMinNumber;
            }
            else
            {
                mCurNumber = mMaxNumber;
            }
            OnFirstMoveComplete();
        }
    }
    
    private void OnFirstMoveComplete()
    {
        float curY = grid.gameObject.transform.localPosition.y;
        float gridInitY = mVisibleCount * grid.cellSize.y / 2.0f;
        if (curY - gridInitY + mVisibleCount * grid.cellSize.y > (mTotalTexts.Count - mHideNumbersCount) * grid.cellSize.y)
        {
            //需要向下移动进行修正。
            float finalY = (mTotalTexts.Count - mHideNumbersCount) * grid.cellSize.y - mVisibleCount * grid.cellSize.y + gridInitY;
            mMoveTweener = grid.transform.DOLocalMoveY(finalY, 0.2f).SetEase(Ease.OutCirc);
            lastMoveIsUp = false;
        }
        else if (curY < gridInitY)
        {
            //需要向上移动进行修正。
            float finalY = gridInitY;
            mMoveTweener = grid.transform.DOLocalMoveY(finalY, 0.2f).SetEase(Ease.OutCirc);
            lastMoveIsUp = true;
        }

    }

    /// <summary>
    /// Init the specified visibleCount.
    /// </summary>
    /// <param name="visibleCount">可以看到的的数字个数只能是奇数，这样选中的数字才能在正中间。</param>
    public void Init(int[] totalNumbers, int visibleCount)
    {
        if (visibleCount % 2 == 0)
        {
            throw new Exception("可以同时看到的的数字个数只能是奇数，这样选中的数字才能在正中间。");
        }
        mTotalNumbers = totalNumbers;
        mVisibleCount = visibleCount;
        mMinNumberIdx = 0;
        mMAxNumberIdx = mTotalNumbers.Length - 1;
        mMinNumber = mTotalNumbers[mMinNumberIdx];
        mMaxNumber = mTotalNumbers[mMAxNumberIdx];
        mHideNumbersCount = 0;
        RectTransform rt = scroller.gameObject.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, visibleCount * grid.cellSize.y);
        CreateTotalNumberList();
        mInited = true;
    }

    public void ShowNumberList(int minNumber, int maxNumber, int currentNumber)
    {
        if (!mInited)
        {
            throw new Exception("Init first!");
        }

        mMinNumber = minNumber;
        mMaxNumber = maxNumber;
        mMinNumberIdx = mMinNumber - mTotalNumbers[0];
        mMAxNumberIdx = mMaxNumber - mTotalNumbers[0];
        mHideNumbersCount = mMinNumberIdx + (mTotalNumbers.Length - mMAxNumberIdx - 1);
        UpdateNumberList();
        SetCurrentNumber(currentNumber);
    }

    public void SetCurrentNumber(int number)
    {
        if (mTotalNumbers != null)
        {
            int len = mTotalNumbers.Length;
            for (int i = 0; i < len; i++)
            {
                if (mTotalNumbers[i] == number)
                {
                    Vector3 pos = new Vector3(0, grid.cellSize.y * ((i - mMinNumberIdx) + mVisibleCount / 2.0f), 0);
                    grid.gameObject.transform.localPosition = pos;
                    mCurNumber = number;
                    break;
                }
            }
        }
    }

    public int GetCurrentNumber()
    {
        return mCurNumber;
    }

    private void CreateTotalNumberList()
    {
        int textsLen = mTotalTexts.Count;
        for (int i = 0; i < textsLen; i++)
        {
            GameObject.DestroyImmediate(mTotalTexts[i].gameObject, true);
            mTotalTexts[i] = null;
        }
        mTotalTexts.Clear();

        if (mTotalNumbers == null)
        {
            return;
        }

        int numbersLen = mTotalNumbers.Length;
        if (numbersLen == 0)
        {
            return;
        }

        int emptyTextCount = mVisibleCount / 2 * 2;
        for (int i = 0; i < numbersLen + emptyTextCount; i++)
        {
            Text text = ((GameObject)GameObject.Instantiate(defaultText.gameObject)).GetComponent<Text>();
            text.gameObject.transform.SetParent(defaultText.transform.parent);
            text.gameObject.transform.localScale = defaultText.transform.localScale;
            text.gameObject.SetActive(true);
            mTotalTexts.Add(text);

            int idx = i - emptyTextCount / 2;
            if (idx >= 0 && idx < numbersLen)
            {
                text.text = mTotalNumbers[idx].ToString();
            }
        }
    }

    private void UpdateNumberList()
    {
        int startIdx = mVisibleCount / 2;

        int total = mTotalNumbers.Length;
        for (int i = 0; i < mMinNumberIdx; i++)
        {
            mTotalTexts[i + startIdx].gameObject.SetActive(false);
        }

        for (int i = mMinNumberIdx; i <= mMAxNumberIdx; i++)
        {
            mTotalTexts[i + startIdx].gameObject.SetActive(true);
        }

        for (int i = mMAxNumberIdx + 1; i < total; i++)
        {
            mTotalTexts[i + startIdx].gameObject.SetActive(false);
        }
    }
}