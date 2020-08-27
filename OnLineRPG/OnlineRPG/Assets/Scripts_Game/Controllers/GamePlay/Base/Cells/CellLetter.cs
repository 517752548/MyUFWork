using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CellLetter : MonoBehaviour
{
    [SerializeField] private Image targetImg;
    [SerializeField]
    private Sprite[] letterSprites;

    private char letter = ' ';
    private Vector3 size;
    private RectTransform rt;

    public Vector3 Size => size;

    public void SetSize(Vector3 size)
    {
        this.size = size;
        rt = gameObject.GetComponent<RectTransform>();
        rt.anchorMin = Vector2.one * 0.5f;
        rt.anchorMax = Vector2.one * 0.5f;
        rt.sizeDelta = size;
    }
    
    public string text
    {
        get { return "" + letter; }
        set
        {
            targetImg.raycastTarget = false;
            if (string.IsNullOrEmpty(value))
            {
                letter = ' ';
                targetImg.sprite = null;
                rt.sizeDelta = Vector3.zero;
            }
            else
            {
                letter = value.ToUpper().Trim().ToCharArray()[0];
                targetImg.sprite = letterSprites[letter - 'A'];
                rt.sizeDelta = size;
            }
        }
    }
    
    public Color color
    {
        get => targetImg.color;
        set => targetImg.color = value;
    }

    public Tween DOFade(float endValue, float duration)
    {
        return targetImg.DOFade(endValue, duration);
    }
}