using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageContent : MonoBehaviour, IPointerClickHandler
{
    public Button[] buttonList;
    // Start is called before the first frame update
    void Start()
    {
        buttonList = transform.parent.GetComponentsInChildren<Button>();
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            Button button = buttonList[i];
            UnregularButtonWithCollider ubwc = button.transform.GetComponent<UnregularButtonWithCollider>();
            if (ubwc)
            {
                if (ubwc.IsInQuadrangle(eventData))
                {
                    ubwc.OnPointerClick(eventData);
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
