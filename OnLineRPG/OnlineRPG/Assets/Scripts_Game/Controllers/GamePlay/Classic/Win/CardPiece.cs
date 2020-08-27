using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts_Game.Controllers.GamePlay.Classic.Win
{
    public class CardPiece : MonoBehaviour
    {
        public Image targetImg;
        
        public void Init(Sprite img)
        {
            targetImg.sprite = img;
            gameObject.SetActive(false);
        }

        public void PlayAppearAni(Action callback)
        {
            gameObject.SetActive(true);
            gameObject.GetComponent<Animator>()?.SetTrigger("appear");
            DOTween.Sequence().InsertCallback(0.6f, () => callback?.Invoke());
        }
    }
}