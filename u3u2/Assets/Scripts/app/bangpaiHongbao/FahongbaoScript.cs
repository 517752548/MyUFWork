using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using app.net;

public class FahongbaoScript : BaseUI
{

    private const int DEFAULTVALUE = 1000;
    private const string DEFAULT_CONTENT = "恭喜发财，天天开心";

    FahongbaoUI UI;
    InputField inputFieldNum;
    InputField inputFieldZhufu;



    public FahongbaoScript(FahongbaoUI UI)
    {
        this.UI = UI;
        UI.btn_close.SetClickCallBack(OnClickClose);
        UI.btn_fafang.SetClickCallBack(OnClickFafang);
        //EventTriggerListener.Get(UI.tfMask.gameObject).onClick = OnClickClose;
        inputFieldNum = CreateInputField(UI.textNum.color, 20, UI.image_bg_num);
        inputFieldNum.characterLimit = 10;
        inputFieldNum.contentType = InputField.ContentType.IntegerNumber;
        inputFieldNum.onValueChange.AddListener(OnValueChanged);
        inputFieldZhufu = CreateInputField(UI.textZhufu.color, 24, UI.image_bg_zhufu);
        UI.textNum.gameObject.SetActive(false);
        UI.textZhufu.gameObject.SetActive(false);

    }

    public void SetShow(bool show)
    {
        UI.gameObject.SetActive(show);

        if (show)
        {                  
            inputFieldNum.text = DEFAULTVALUE.ToString();                  
            inputFieldZhufu.text = DEFAULT_CONTENT;
        }
    }


    private void OnClickClose(GameObject obj)
    {
        UI.gameObject.SetActive(false);
    }

    private void OnValueChanged(string str)
    {
        int num;
        string beforeContent = inputFieldNum.text;
        if (!int.TryParse(str, out num))
        {
            inputFieldNum.text = GetIntString(beforeContent);
        }
    }

    private string GetIntString(string str)
    {
        List<char> chars = new List<char>();
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] >= '0' && str[i] <= '9')
            {
                chars.Add(str[i]);
            }
        }
        return chars.ToString();
    }

    private void OnClickFafang()
    {
        //1为红包类型 1代表帮派红包
        CorpsCGHandler.sendCGCreateCorpsRedEnvelope(1,inputFieldZhufu.text,int.Parse(inputFieldNum.text));
    }

    public override void Destroy()
    {
        GameObject.DestroyImmediate(UI.gameObject);
        inputFieldNum = null;
        inputFieldZhufu = null;
        base.Destroy();
    }


}
