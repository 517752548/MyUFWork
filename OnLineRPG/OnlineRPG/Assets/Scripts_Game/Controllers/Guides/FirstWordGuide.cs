using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using BetaFramework;

public class FirstWordGuide : BaseBoardArrowGuide
{
    public Transform hand;

    private BaseKeyBoard keyBoard;
    private KeyboardOneKey curKey;
    private int letterIndex = 0;
    private string answer;
    private Camera mainCamera;

    public override void OnOpen()
    {
        keyBoard = objs[1] as BaseKeyBoard;
        answer = (string)objs[2];
        base.OnOpen();
        GameObject gameObject = GameObject.Find("GamePlayCamera");
        mainCamera = gameObject.GetComponent<Camera>();
        ToNextLetter();
    }

    private void OnClickLetter(string letter)
    {
        ToNextLetter();
    }

    private void ToNextLetter()
    {
        if (letterIndex >= answer.Length)
        {
            if (curKey != null)
            {
                curKey.keyAction -= OnClickLetter;
                AppEngine.SSystemManager.GetSystem<UiLayerSystem>().ResetUiLayer(curKey.transform);
                AppEngine.SSystemManager.GetSystem<UiLayerSystem>().ResetUiLayer(curKey.text.transform.parent);
            }
            return;
        }
        char s = answer[letterIndex];
        bool newKey = false;
        if (curKey != null && !curKey._key.ToString().Equals(s + ""))
        {
            newKey = true;
            curKey.keyAction -= OnClickLetter;
            AppEngine.SSystemManager.GetSystem<UiLayerSystem>().ResetUiLayer(curKey.transform);
            AppEngine.SSystemManager.GetSystem<UiLayerSystem>().ResetUiLayer(curKey.text.transform.parent);
        }
        if (newKey || curKey == null)
        {
            curKey = keyBoard.GetOneKey(s + "");
            curKey.keyAction += OnClickLetter;
            AppEngine.SSystemManager.GetSystem<UiLayerSystem>().HighLightUI(curKey.transform,
                UILayer.UI, UiLayerOrder.Guide, true);
            AppEngine.SSystemManager.GetSystem<UiLayerSystem>().HighLightUI(curKey.text.transform.parent,
                 UILayer.UI, UiLayerOrder.Guide, false);
            Vector3 pos = mainCamera.WorldToScreenPoint(curKey.transform.position);
            float centerX = Screen.width / 2f;
            if (pos.x < centerX)
            {
                hand.rotation = Quaternion.Euler(0, 180, 0);
                hand.position = curKey.transform.position;
            }
            else
            {
                hand.position = curKey.transform.position;
                hand.rotation = Quaternion.Euler(0, 0, 0);
            } 
        }
        letterIndex++;
    }
}
