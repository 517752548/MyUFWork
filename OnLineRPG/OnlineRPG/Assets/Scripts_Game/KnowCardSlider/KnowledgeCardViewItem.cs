using System;
using Bag;
using UnityEngine;
using BetaFramework;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;


public class KnowledgeCardViewItem : MonoBehaviour
{
    public GameObject storyPanel; //故事面板
    public GameObject newFlagImage;
    public GameObject defaultImage;
    public Image photoImage = null; //知识卡牌图片
    public Image heartImage;
    public Text creatTimeText, praiseNumText, titleText, desText_1, desText_2;
    public string cardId;
    private int isClikeLike;
    private LoopScrollRect loopScrollRect;
    private LocalKnowledgeCard _localKnowledgeCard;

    private RectTransform rectTransform;

    // Start is called before the first frame update
    private int ordHeight = 0;

    public void Awake()
    {
        rectTransform = this.GetComponent<RectTransform>();
    }

    public void bindListener(LoopScrollRect loopScrollRect)
    {
        this.loopScrollRect = loopScrollRect;
    }

    public RectTransform getRectTransform()
    {
        return rectTransform;
    }

    /* 
    obj 知识卡牌即将更新的一个card
    ReCreatView 更新知识卡牌的内容
    */
    public void ReCreatView(object obj, bool isAtartItem)
    {
        LocalKnowledgeCard localKnowledgeCard = obj as LocalKnowledgeCard;
        _localKnowledgeCard = localKnowledgeCard;
        creatTimeText.SetText(XUtils.GetTimeDes(localKnowledgeCard.creatTime));
        praiseNumText.SetText(localKnowledgeCard.Praise_points.ToString());
        this.cardId = localKnowledgeCard.cardID;
        isShowNew(localKnowledgeCard.isNew);
        showOpenedCard();
        showHeart(localKnowledgeCard.isClickHeart);
        if (defaultImage != null)
            defaultImage.SetActive(true);
        if (rectTransform != null)
        {
            KnowCardIdManager.getInstance().LoadKnowledgeCard(localKnowledgeCard.cardID, (cardDesObj) =>
            {
                if (cardDesObj == null)
                {
                    return;
                }
                if (defaultImage != null)
                    defaultImage.SetActive(false);
                float ordSize = 0;
                ordSize += LayoutUtility.GetPreferredHeight(rectTransform);
                if (cardDesObj != null && cardDesObj.Image != null && !photoImage.IsDestroyed())
                {
                    photoImage.sprite = cardDesObj.Image;
                }

                titleText.SetText(cardDesObj.CardTheme.ToUpper());
                desText_1.SetText(cardDesObj.Description);
                desText_2.SetText(cardDesObj.Story);

                LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
                float newSize = LayoutUtility.GetPreferredHeight(rectTransform);
                float moveDis = newSize - ordSize;

                if (moveDis != 0)
                {
                    if (isAtartItem)
                    {
                        loopScrollRect.completeTextHeight(moveDis, newSize);
                    }
                    else
                    {
                        loopScrollRect.completeTextHeight(0, newSize, false);
                    }

                    loopScrollRect.updateBonusCallback(true);
                }
            });
        }
    }


    private void isShowNew(int isNew)
    {
        if (isNew == 0)
        {
            newFlagImage.SetActive(true);
            KnowCardIdManager.getInstance().addLocalKnowledgeCard(_localKnowledgeCard);
        }
        else
        {
            newFlagImage.SetActive(false);
        }
    }

    private void showHeart(int isShowHeart)
    {
        if (isShowHeart == 1)
        {
            heartImage.gameObject.SetActive(true);
        }
        else
        {
            heartImage.gameObject.SetActive(false);
        }
    }

    private void showOpenedCard()
    {
        bool change = false;
        bool isOpened = KnowCardIdManager.getInstance()
            .isOperationKnowCard(KnowCardIdManager.getInstance().showCard, cardId);
        if (isOpened && !storyPanel.activeSelf)
        {
            storyPanel.SetActive(true);
            change = true;
        }
        else if (storyPanel.activeSelf && !isOpened)
        {
            storyPanel.SetActive(false);
            change = true;
        }

        if (change && this.loopScrollRect != null)
        {
            this.loopScrollRect.updateBonusCallback(change);
        }
    }

    public void clickLike()
    {
        bool isClickLike = heartImage.gameObject.activeSelf;
        if (isClickLike)
        {
            heartImage.gameObject.SetActive(false);
            _localKnowledgeCard.isClickHeart = 0;
            _localKnowledgeCard.Praise_points -= 1;
        }
        else
        {
            heartImage.gameObject.SetActive(true);
            _localKnowledgeCard.isClickHeart = 1;
            _localKnowledgeCard.Praise_points += 1;
            Addressables.LoadAssetAsync<GameObject>(ViewConst.prefab_Heart_Fly).Completed += (obj) =>
            {
                GameObject effect = Instantiate(obj.Result, heartImage.transform, false);
                Destroy(effect, 2);
            };
        }

        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_tip_appear);
        newFlagImage.gameObject.SetActive(false);
        praiseNumText.SetText(_localKnowledgeCard.Praise_points.ToString());
    }

    public void hideStoryPanel()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_blog_itemclick);
        newFlagImage.gameObject.SetActive(false);
        _localKnowledgeCard.isNew = 1;
        KnowCardIdManager.getInstance().removeCardId(KnowCardIdManager.getInstance().showCard, this.cardId);
        storyPanel.SetActive(false);
    }

    public void showStoryPanel()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_blog_itemclick);
        newFlagImage.gameObject.SetActive(false);
        _localKnowledgeCard.isNew = 1;
        KnowCardIdManager.getInstance().addId(KnowCardIdManager.getInstance().showCard, this.cardId);
        storyPanel.SetActive(true);
    }
}