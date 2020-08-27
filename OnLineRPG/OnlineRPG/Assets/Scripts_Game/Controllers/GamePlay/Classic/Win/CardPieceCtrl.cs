using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts_Game.Controllers.GamePlay.Classic.Win
{
    public class CardPieceCtrl : MonoBehaviour
    {
        public CardPiece[] pieces;
        public Image finish;
        public TextMeshProUGUI cardThemeText; 

        private CardPieceMode _cardPieceMode;
        private List<int> order;

        public void Init(KnowledgeCardEntity card, CardPieceMode mode)
        {
            _cardPieceMode = mode;
            CheckMode();
            order = GetOrder();
            for (int i = 0; i < order.Count; i++)
            {
                pieces[order[i]].transform.SetSiblingIndex(i);
            }

            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i].Init(card.Image);
            }
            cardThemeText.text = card.CardTheme.ToUpper();
            finish = transform.Find("PieceFinish/Img_Mask/Img_Puzzle")?.GetComponent<Image>();
            if (finish != null)
                finish.sprite = (card.Image);
        }

        public void SetProgress(int gotCount)
        {
            for (int i = 0; i < order.Count; i++)
            {
                pieces[order[i]].gameObject.SetActive(i < gotCount);
            }
        }

        public void PlayGotAni(int gotCount, Action callback)
        {
            pieces[order[gotCount - 1]].PlayAppearAni(callback);
        }

        public void PlayFinishAni(Action callback)
        {
            if (finish == null)
            {
                callback?.Invoke();
                return;
            }
            gameObject.GetComponent<Animator>().SetTrigger("finish");
            DOTween.Sequence().InsertCallback(2f, () => callback?.Invoke());
        }

        private List<int> GetOrder()
        {
            switch (_cardPieceMode)
            {
                case CardPieceMode.one:
                    return new List<int>(){0};
                case CardPieceMode.two_12:
                    return new List<int>(){0, 1};
                case CardPieceMode.two_21:
                    return new List<int>(){1, 0};
                case CardPieceMode.three_123:
                    return new List<int>(){0, 1, 2};
                case CardPieceMode.three_132:
                    return new List<int>(){0, 2, 1};
                case CardPieceMode.four_1243:
                    return new List<int>(){0,1,3,2};
                case CardPieceMode.four_1324:
                    return new List<int>(){0,2,1,3};
                case CardPieceMode.four_1432:
                    return new List<int>(){0,3,2,1};
                case CardPieceMode.four_4231:
                    return new List<int>(){3,1,2,0};
                case CardPieceMode.circle_four_1423:
                    return new List<int>(){0, 3, 1, 2};
                case CardPieceMode.five_12345:
                    return new List<int>(){0, 1, 2, 3, 4};
                case CardPieceMode.five_12435:
                    return new List<int>(){0, 1, 3, 2, 4};
                case CardPieceMode.five_12534:
                    return new List<int>(){0, 1, 4, 2, 3};
                case CardPieceMode.five_12543:
                    return new List<int>(){0, 1, 4, 3, 2};
                case CardPieceMode.five_14235:
                    return new List<int>(){0, 3, 1, 2, 4};
                case CardPieceMode.six_123456:
                    return new List<int>(){0, 1, 2, 3, 4, 5};
                case CardPieceMode.six_123654:
                    return new List<int>(){0, 1, 2, 5, 4, 3};
                case CardPieceMode.six_163425:
                    return new List<int>(){0, 5, 2, 3, 1, 4};
            }
            return null;
        }

        private void CheckMode()
        {
            bool isMatch = false;
            switch (_cardPieceMode)
            {
                case CardPieceMode.one:
                    isMatch = pieces.Length == 1;
                    break;
                case CardPieceMode.two_12:
                case CardPieceMode.two_21:
                    isMatch = pieces.Length == 2;
                    break;
                case CardPieceMode.three_123:
                case CardPieceMode.three_132:
                    isMatch = pieces.Length == 3;
                    break;
                case CardPieceMode.four_1243:
                case CardPieceMode.four_1324:
                case CardPieceMode.four_1432:
                case CardPieceMode.four_4231:
                case CardPieceMode.circle_four_1423:
                    isMatch = pieces.Length == 4;
                    break;
                case CardPieceMode.five_14235:
                case CardPieceMode.five_12345:
                case CardPieceMode.five_12435:
                case CardPieceMode.five_12534:
                case CardPieceMode.five_12543:
                    isMatch = pieces.Length == 5;
                    break;
                case CardPieceMode.six_163425:
                case CardPieceMode.six_123456:
                case CardPieceMode.six_123654:
                    isMatch = pieces.Length == 6;
                    break;
            }

            if (!isMatch)
            {
                switch (pieces.Length)
                {
                    case 1:
                        _cardPieceMode = CardPieceMode.one;
                        break;
                    case 2:
                        _cardPieceMode = CardPieceMode.two_12;
                        break;
                    case 3:
                        _cardPieceMode = CardPieceMode.three_123;
                        break;
                    case 4:
                        _cardPieceMode = CardPieceMode.four_1243;
                        break;
                    case 5:
                        _cardPieceMode = CardPieceMode.five_14235;
                        break;
                    case 6:
                        _cardPieceMode = CardPieceMode.six_163425;
                        break;
                }
            }
        }

        public static CardPieceCtrl Make(KnowledgeCardEntity card, CardPieceMode mode, Transform parent)
        {
            string prefabName = "";
            switch (mode)
            {
                case CardPieceMode.one:
                    prefabName = ViewConst.prefab_CardPieces_One;
                    break;
                case CardPieceMode.two_12:
                case CardPieceMode.two_21:
                    prefabName = ViewConst.prefab_CardPieces_Two;
                    break;
                case CardPieceMode.three_123:
                case CardPieceMode.three_132:
                    prefabName = ViewConst.prefab_CardPieces_Three;
                    break;
                case CardPieceMode.four_1243:
                case CardPieceMode.four_1324:
                case CardPieceMode.four_1432:
                case CardPieceMode.four_4231:
                    prefabName = ViewConst.prefab_CardPieces_Four;
                    break;
                case CardPieceMode.circle_four_1423:
                    prefabName = ViewConst.prefab_CardPieces_CircleFour;
                    break;
                case CardPieceMode.five_14235:
                case CardPieceMode.five_12345:
                case CardPieceMode.five_12435:
                case CardPieceMode.five_12534:
                case CardPieceMode.five_12543:
                    prefabName = ViewConst.prefab_CardPieces_Five;
                    break;
                case CardPieceMode.six_163425:
                case CardPieceMode.six_123456:
                case CardPieceMode.six_123654:
                    prefabName = ViewConst.prefab_CardPieces_Six;
                    break;
            }
            var obj = PreLoadManager.GetPreLoad<GameObject>(PreLoadConst.preload_Prefab, prefabName);
            if (obj != null)
            {
                var pieceCtrl = GameObject.Instantiate(obj, parent, false).GetComponent<CardPieceCtrl>();
                pieceCtrl.Init(card, mode);
                return pieceCtrl;
            }

            return null;
        }
    }
}