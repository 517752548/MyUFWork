using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChangeNameDialog : UIWindowBase
{
    public InputField input;
    public GameObject clearBtn;

    private Action<string> onChange;

    public override void OnOpen()
    {
        base.OnOpen();
        input.onValueChanged.AddListener(OnValueCahnge);
        if (objs != null && objs.Length > 1)
        {
            input.text = (string)objs[0];
            onChange = (Action<string>)objs[1];
        }
        clearBtn.SetActive(!string.IsNullOrEmpty(input.text));
    }

    private void OnValueCahnge(string text)
    {
        clearBtn.SetActive(!string.IsNullOrEmpty(text));
    }

    public void ClickClear()
    {
        input.text = "";
    }

    public void ClickSave()
    {
        onChange?.Invoke(input.text);
        Close();
    }
}
