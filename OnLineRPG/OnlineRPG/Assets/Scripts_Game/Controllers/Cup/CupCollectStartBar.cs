using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts_Game.Controllers.Cup
{
    public class CupCollectStartBar : MonoBehaviour
    {
        public Transform cupImg;
        public TextMeshProUGUI cupCountText;

        private int cupCount;

        public void Show(int count)
        {
            cupCount = count;
            cupCountText.text = "+" + count;
            gameObject.SetActive(true);
        }

        public void PlayReduceAni(float duration)
        {
            int count = cupCount;
            DOTween.To(()=>count,x => count = x,  0, duration)
                .OnUpdate(() =>
                {
                    cupCountText.text = "+" + count;
                }).OnComplete(()=>gameObject.SetActive(false));
        }
    }
}