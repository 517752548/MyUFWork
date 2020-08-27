using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MasterStars : MonoBehaviour
{
    public Sprite lightSprite, darkSprite;
    public Image[] stars;

    public void SetStars(int count, bool light)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].gameObject.SetActive(i < count);
            stars[i].sprite = light ? lightSprite : darkSprite;
        }
    }

    public void UpdateState(bool light)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].sprite = light ? lightSprite : darkSprite;
        }
    }
}
