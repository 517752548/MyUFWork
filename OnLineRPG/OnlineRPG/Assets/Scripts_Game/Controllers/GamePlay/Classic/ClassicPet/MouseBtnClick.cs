using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBtnClick : MonoBehaviour
{

    public BasePet _BasePet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _BasePet?.CloseCellTip();
        }
    }
}
